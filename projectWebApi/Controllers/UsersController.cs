using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using DTOs;
using AutoMapper;


namespace projectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IUserService _userService;
        private IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, IMapper mapper, ILogger<UsersController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            User user = await _userService.GetUserById(id);
            if (user==null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost]
        [Route("checkPassword")]

        public ActionResult<int> CheckPassword([FromBody] string password)
        {
            return _userService.StrongPassword(password);
        }


        [HttpPost]

        public async Task<ActionResult> Register([FromBody] User user)
        {
           int score= _userService.StrongPassword(user.Password);
            if (score < 2)
                return BadRequest();
            User NewUser = await _userService.Register(user);
            if (NewUser == null)
                return ValidationProblem();
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }



        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> Login([FromBody] UserLoginDto userLogindto)
        {
            User user = _mapper.Map<UserLoginDto, User>(userLogindto);
            User NewUser = await _userService.Login(user);
            if (NewUser == null)
            {
                return Unauthorized();
            }
            return Ok(NewUser);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] User userToUpdate)
        {
            User updateUser = await _userService.UpdateUser(id, userToUpdate);
            if (updateUser == null)
                return ValidationProblem();
            return updateUser;
        }


    }
}
