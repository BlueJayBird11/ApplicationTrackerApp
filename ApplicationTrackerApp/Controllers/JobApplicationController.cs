using ApplicationTrackerApp.Dto;
using ApplicationTrackerApp.Interface;
using ApplicationTrackerApp.Models;
using ApplicationTrackerApp.Repository;
using ApplicationTrackerApp.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApplicationTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController : Controller
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public JobApplicationController(IJobApplicationRepository jobApplicationRepository, ILoginRepository loginRepository, IMapper mapper, UserService userService)
        {
            this._jobApplicationRepository = jobApplicationRepository;
            this._loginRepository = loginRepository;
            this._mapper = mapper;
            this._userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<JobApplication>))]
        public IActionResult GetJobApplications([FromQuery] string adminPassword)
        {
            var secret = Environment.GetEnvironmentVariable("ADMIN_PASSWORD");
            if (adminPassword != secret)
                return Unauthorized();

            var jobApplications = _mapper.Map<List<JobApplicationDto>>(_jobApplicationRepository.GetJobApplications());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(jobApplications);
        }

        [HttpGet("{jobApplicationId}")]
        [ProducesResponseType(200, Type = typeof(JobApplication))]
        [ProducesResponseType(400)]
        public IActionResult GetJobApplication(int jobApplicationId)
        {
            if (!_jobApplicationRepository.JobApplicationExists(jobApplicationId))
                return NotFound();

            var jobApplication = _mapper.Map<JobApplicationFullDto>(_jobApplicationRepository.GetJobApplication(jobApplicationId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(jobApplication);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateApplication([FromQuery] int userId, [FromQuery] int jobTypeId, [FromQuery] int closedReasonId, [FromQuery] string sessionKey, [FromBody] JobApplicationDto jobApplicationCreate)
        {
            var login = _loginRepository.GetUserLogin(userId);

            if (login == null)
            {
                return BadRequest();
            }

            if (!_userService.ValidateSessionKey(login, sessionKey))
            {
                ModelState.AddModelError("", "Invalid Session Key");
                return StatusCode(401, ModelState);
            }

            if (_loginRepository.SessionExpired(login.Id))
            {
                ModelState.AddModelError("", "Session Expired");
                return StatusCode(440, ModelState);
            }
            
            if (jobApplicationCreate == null)
                return BadRequest(ModelState);

            if (jobTypeId == 0)
            {
                ModelState.AddModelError("", "Job Application requires a job type");
                return StatusCode(422, ModelState);
            }

            var jobApplication = _jobApplicationRepository.GetJobApplications()
                .Where(j => j.Id == jobApplicationCreate.Id)
                .FirstOrDefault();

            if (jobApplication != null)
            {
                ModelState.AddModelError("", "Job Application with that id already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var jobApplicationMap = _mapper.Map<JobApplication>(jobApplicationCreate);

            if (jobApplicationMap.LinkToCompanySite == "")
                jobApplicationMap.LinkToCompanySite = null;

            if (jobApplicationMap.LinkToJobPost == "")
                jobApplicationMap.LinkToJobPost = null;

            /* // DateClosed doesn't allow nulls?
            if (jobApplicationMap.DateClosed == new DateOnly(0001, 01, 01))
                jobApplicationMap.DateClosed = null;
            */

            if (!_jobApplicationRepository.CreateJobApplication(jobApplicationMap, userId, jobTypeId, closedReasonId))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("jobApplicationId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateApplication(int jobApplicationId, [FromQuery] int userId, [FromQuery] int jobTypeId, [FromQuery] int closedReasonId, [FromQuery] string sessionKey, [FromBody] JobApplicationDto updatedJobApplication)
        {
            var login = _loginRepository.GetUserLogin(userId);

            if (login == null)
            {
                return BadRequest();
            }

            if (!_userService.ValidateSessionKey(login, sessionKey))
            {
                ModelState.AddModelError("", "Invalid Session Key");
                return StatusCode(401, ModelState);
            }

            if (_loginRepository.SessionExpired(login.Id))
            {
                ModelState.AddModelError("", "Session Expired");
                return StatusCode(440, ModelState);
            }

            if (updatedJobApplication == null)
                return BadRequest(ModelState);

            if (jobApplicationId != updatedJobApplication.Id)
                return BadRequest(ModelState);

            if (jobTypeId == 0)
            {
                ModelState.AddModelError("", "Job Application requires a job type");
                return StatusCode(422, ModelState);
            }

            if (!_jobApplicationRepository.JobApplicationExists(jobApplicationId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var jobApplicationMap = _mapper.Map<JobApplication>(updatedJobApplication);

            if (jobApplicationMap.LinkToCompanySite == "")
                jobApplicationMap.LinkToCompanySite = null;

            if (jobApplicationMap.LinkToJobPost == "")
                jobApplicationMap.LinkToJobPost = null;

            if (!_jobApplicationRepository.UpdateJobApplication(jobApplicationMap, jobTypeId, closedReasonId))
            {
                ModelState.AddModelError("", "Something went wrong updating job application");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{jobApplicationId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteJobApplication(int jobApplicationId, [FromQuery] int userId, [FromQuery] string sessionKey)
        {
            var login = _loginRepository.GetUserLogin(userId);

            if (login == null)
            {
                return BadRequest();
            }

            if (!_userService.ValidateSessionKey(login, sessionKey))
            {
                ModelState.AddModelError("", "Invalid Session Key");
                return StatusCode(401, ModelState);
            }

            if (_loginRepository.SessionExpired(login.Id))
            {
                ModelState.AddModelError("", "Session Expired");
                return StatusCode(440, ModelState);
            }

            if (!_jobApplicationRepository.JobApplicationExists(jobApplicationId))
            {
                return NotFound();
            }

            var jobAppToDelete = _jobApplicationRepository.GetJobApplication(jobApplicationId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Check to make sure the User owns this application

            if (_jobApplicationRepository.GetJobApplicationsUser(jobApplicationId).Id != userId)
            {
                ModelState.AddModelError("", "Forbidden: Cannot delete other user's job applications");
                return StatusCode(403, ModelState);
            }

            if (!_jobApplicationRepository.DeleteJobApplication(jobAppToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting job application");
            }

            return NoContent();
        }
    }
}
