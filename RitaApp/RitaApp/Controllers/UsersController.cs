//using FluentValidation;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using RitaApp.DTOs;
//using RitaApp.DTOs.CreateDto;
//using RitaApp.DTOs.UpdateDto;
//using RitaApp.Services;

//namespace RitaApp.Controllers
//{
//    [Authorize]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        private readonly IUserService _userService;
//        private readonly IValidator<CreateUserDto> _createUserDtoValidator;
//        private readonly IValidator<UpdateUserDto> _updateUserDtoValidator;

//        public UsersController(
//            IUserService userService,
//            IValidator<CreateUserDto> createUserDtoValidator,
//            IValidator<UpdateUserDto> updateUserDtoValidator,
//            ILogger<UsersController> logger)
//        {
//            _userService = userService;
//            _createUserDtoValidator = createUserDtoValidator;
//            _updateUserDtoValidator = updateUserDtoValidator;
//            logger.LogInformation("We are in users");
//        }

//        [HttpGet]
//        public async Task<ActionResult<List<UserDto>>> GetAll()
//        {
//            var usersDto = await _userService.GetAll();
//            return Ok(usersDto);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<UserDto>> GetById([FromRoute] int id)
//        {
//            var userDto = await _userService.GetById(id);
//            return Ok(userDto);
//        }

//		[AllowAnonymous]
//        [HttpPost]
//        public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserDto createUserDto)
//        {
//            _createUserDtoValidator.ValidateAndThrow(createUserDto);
//            var userDto = await _userService.Create(createUserDto);
//            return Ok(userDto);
//        }

//        [HttpPut]
//        public async Task<ActionResult<UserDto>> Update([FromBody] UpdateUserDto updateUserDto)
//        {
//            _updateUserDtoValidator.ValidateAndThrow(updateUserDto);
//            var userDto = await _userService.Update(updateUserDto);
//            return Ok(userDto);
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult> Delete([FromRoute] int id)
//        {
//            await _userService.Delete(id);
//            return NoContent();
//        }
//    }
//}
