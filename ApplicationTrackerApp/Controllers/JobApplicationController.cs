using ApplicationTrackerApp.Dto;
using ApplicationTrackerApp.Interface;
using ApplicationTrackerApp.Models;
using ApplicationTrackerApp.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController : Controller
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IMapper _mapper;

        public JobApplicationController(IJobApplicationRepository jobApplicationRepository, IMapper mapper)
        {
            this._jobApplicationRepository = jobApplicationRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<JobApplication>))]
        public IActionResult GetJobApplications()
        {
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

            var jobApplication = _jobApplicationRepository.GetJobApplication(jobApplicationId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(jobApplication);
        }
    }
}
