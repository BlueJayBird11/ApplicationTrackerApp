using ApplicationTrackerApp.Dto;
using ApplicationTrackerApp.Interface;
using ApplicationTrackerApp.Models;
using ApplicationTrackerApp.Repository;
using ApplicationTrackerApp.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ILoginRepository _loginRepository;
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, ILoginRepository loginRepository, UserService userService, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._loginRepository = loginRepository;
            this._userService = userService;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(JobType))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int userId)
        {
            if (!_userRepository.UserExists(userId))
                return NotFound();

            var user = _mapper.Map<UserDto>(_userRepository.GetUser(userId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }

        [HttpGet("{userId}/applications")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<JobApplication>))]
        public IActionResult GetUserJobApplications(int userId)
        {
            var jobApplications = _userRepository.GetUsersJobApplications(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(jobApplications);
        }


    }
}
