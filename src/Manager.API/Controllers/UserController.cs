using AutoMapper;
using Manager.API.Responses;
using Manager.Core.Exceptions;
using Manager.Core.Extensions;
using Manager.Domain.ViewModels.User;
using Manager.Services.DTOs;
using Manager.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        [Route("api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel createUserViewModel)
        {
            try
            {
                var userDto = _mapper.Map<UserDto>(createUserViewModel);
                var createUser = await _userService.CreateAsync(userDto);

                return Ok(ResultViewModelTemplates.Success(createUser));
            }
            catch (DomainException domainException)
            {
                return BadRequest(ResultViewModelTemplates.DomainError(domainException.Message, domainException.Errors));
            }
            catch (Exception exception)
            {
                return StatusCode(500, ResultViewModelTemplates.Exception(exception.Message));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/v1/users/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var usersDto = await _userService.GetAsync(id.ToLong());
                return Ok(ResultViewModelTemplates.Success(usersDto));
            }
            catch (DomainException domainException)
            {
                return BadRequest(ResultViewModelTemplates.DomainError(domainException.Message, domainException.Errors));
            }
            catch (Exception exception)
            {
                return StatusCode(500, ResultViewModelTemplates.Exception(exception.Message));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/v1/users")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usersDto = await _userService.GetAsync();
                return Ok(ResultViewModelTemplates.Success(usersDto));
            }
            catch (DomainException domainException)
            {
                return BadRequest(ResultViewModelTemplates.DomainError(domainException.Message, domainException.Errors));
            }
            catch (Exception exception)
            {
                return StatusCode(500, ResultViewModelTemplates.Exception(exception.Message));
            }
        }

        [HttpPut]
        [Authorize]
        [Route("api/v1/users/update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel updateUserViewModel)
        {
            try
            {
                var userDto = _mapper.Map<UserDto>(updateUserViewModel);
                var updatedUser = await _userService.UpdateAsync(userDto);
                return Ok(ResultViewModelTemplates.Success(updatedUser));
            }
            catch (DomainException domainException)
            {
                return BadRequest(ResultViewModelTemplates.DomainError(domainException.Message, domainException.Errors));
            }
            catch (Exception exception)
            {
                return StatusCode(500, ResultViewModelTemplates.Exception(exception.Message));
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("api/v1/users/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _userService.RemoveAsync(id.ToLong());
                return Ok(ResultViewModelTemplates.Success());
            }
            catch (DomainException domainException)
            {
                return BadRequest(ResultViewModelTemplates.DomainError(domainException.Message, domainException.Errors));
            }
            catch (Exception exception)
            {
                return StatusCode(500, ResultViewModelTemplates.Exception(exception.Message));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/v1/users/get-by-email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            try
            {
                var userDto = await _userService.GetByEmailAsync(email);
                return Ok(ResultViewModelTemplates.Success(userDto));
            }
            catch (DomainException domainException)
            {
                return BadRequest(ResultViewModelTemplates.DomainError(domainException.Message, domainException.Errors));
            }
            catch (Exception exception)
            {
                return StatusCode(500, ResultViewModelTemplates.Exception(exception.Message));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/v1/users/search-by-email")]
        public async Task<IActionResult> SearchByEmail([FromQuery] string email)
        {
            try
            {
                var usersDto = await _userService.SearchByEmailAsync(email);
                return Ok(ResultViewModelTemplates.Success(usersDto));
            }
            catch (DomainException domainException)
            {
                return BadRequest(ResultViewModelTemplates.DomainError(domainException.Message, domainException.Errors));
            }
            catch (Exception exception)
            {
                return StatusCode(500, ResultViewModelTemplates.Exception(exception.Message));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/v1/users/search-by-name")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                var usersDto = await _userService.SearchByNameAsync(name);
                return Ok(ResultViewModelTemplates.Success(usersDto));
            }
            catch (DomainException domainException)
            {
                return BadRequest(ResultViewModelTemplates.DomainError(domainException.Message, domainException.Errors));
            }
            catch (Exception exception)
            {
                return StatusCode(500, ResultViewModelTemplates.Exception(exception.Message));
            }
        }
    }
}