using ApplicationTrackerApp.Dto;
using ApplicationTrackerApp.Interface;
using ApplicationTrackerApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClosedReasonController : Controller
    {
        private readonly IClosedReasonRepository _closedReasonRepository;
        private readonly IMapper _mapper;

        public ClosedReasonController(IClosedReasonRepository closedReasonRepository, IMapper mapper)
        {
            this._closedReasonRepository = closedReasonRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ClosedReason>))]
        public IActionResult GetClosedReasons()
        {
            var closedReasons = _mapper.Map<List<ClosedReasonDto>>(_closedReasonRepository.GetClosedReasons());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(closedReasons);
        }

        [HttpGet("{closedReasonId}")]
        [ProducesResponseType(200, Type = typeof(ClosedReason))]
        [ProducesResponseType(400)]
        public IActionResult GetClosedReason(int closedReasonId)
        {
            if (!_closedReasonRepository.ClosedReasonExists(closedReasonId))
                return NotFound();

            var closedReason = _mapper.Map<ClosedReasonDto>(_closedReasonRepository.GetClosedReason(closedReasonId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(closedReason);
        }
    }
}
