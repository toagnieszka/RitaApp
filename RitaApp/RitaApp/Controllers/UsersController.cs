using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;
using RitaApp.Services;

namespace RitaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<CreateUserDto> _createUserDtoValidator;

        public UsersController(
            IUserService userService,
            IValidator<CreateUserDto> createUserDtoValidator)
        {
            _userService = userService;
            _createUserDtoValidator = createUserDtoValidator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            var usersDto = await _userService.GetAll();
            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById([FromRoute] int id)
        {
            var userDto = await _userService.GetById(id);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserDto createUserDto)
        {
            _createUserDtoValidator.ValidateAndThrow(createUserDto);
            var userDto = await _userService.Create(createUserDto);
            return Ok(userDto);
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> Update([FromBody] UpdateUserDto updateUserDto)
        {
            var userDto = await _userService.Update(updateUserDto);
            return Ok(userDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _userService.Delete(id);
            return NoContent();
        }
    }
}
