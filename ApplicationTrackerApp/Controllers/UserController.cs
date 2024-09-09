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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult RegisterUser([FromBody] CreateUserDto userCreate)
        {
            if (userCreate == null)
                return BadRequest(ModelState);

            var user = _userRepository.GetUsers()
                .Where(u => u.Email.ToUpper() == userCreate.Email.ToUpper())
                .FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("", "User with that email already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(userCreate);
            _userService.RegisterUser(userMap, userMap.PasswordHash);

            if (!_userRepository.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpGet("login")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult LoginUser([FromQuery] string email, [FromQuery] string password)
        {
            if (email == null || password == null)
                return BadRequest(ModelState);

            var user = _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userService.ValidateUser(user, password))
            {
                ModelState.AddModelError("", "Incorrect Password");
                return StatusCode(401, ModelState);
            }

            var userInfo = new
            {
                Id = user.Id,
            };

            return Ok(userInfo);
        }
    }
}
