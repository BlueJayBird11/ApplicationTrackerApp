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
    public class JobTypeController : Controller
    {
        private readonly IJobTypeRepository _jobTypeRepository;
        private readonly IMapper _mapper;

        public JobTypeController(IJobTypeRepository jobTypeRepository, IMapper mapper)
        {
            this._jobTypeRepository = jobTypeRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<JobType>))]
        public IActionResult GetJobTypes()
        {
            var jobTypes = _mapper.Map<List<JobTypeDto>>(_jobTypeRepository.GetJobTypes());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(jobTypes);
        }

        [HttpGet("{jobTypeId}")]
        [ProducesResponseType(200, Type = typeof(JobType))]
        [ProducesResponseType(400)]
        public IActionResult GetJobApplication(int jobTypeId)
        {
            if (!_jobTypeRepository.JobTypeExists(jobTypeId))
                return NotFound();

            var jobType = _mapper.Map<JobTypeDto>(_jobTypeRepository.GetJobType(jobTypeId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(jobType);
        }

        [HttpPost("fillData")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult FillJobTypeData()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_jobTypeRepository.FillData())
            {
                ModelState.AddModelError("", "Data already exists");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }
    }
}
