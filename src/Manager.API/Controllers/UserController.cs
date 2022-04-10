using AutoMapper;
using Manager.API.ViewModels;
using Manager.API.ViewModels.User;
using Manager.Core.Exceptions;
using Manager.Core.Extensions;
using Manager.Services.DTOs;
using Manager.Services.Interfaces;
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
        [Route("api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel createUserViewModel)
        {
            try
            {
                var userDto = _mapper.Map<UserDto>(createUserViewModel);
                var createUser = await _userService.CreateAsync(userDto);

                return Ok(ResultViewModelTemplates.CreatedSuccess(createUser));
            }
            catch (DomainException domainException)
            {
                return BadRequest();
            }
            catch (Exception exception)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpGet]
        [Route("api/v1/users/{id?}")]
        public async Task<IActionResult> Get([FromQuery] long? id)
        {
            try
            {
                if(id.IsIdValid())
                {
                    var usersDto = await _userService.GetAsync(id.ToLong());
                    return Ok(ResultViewModelTemplates.GetSuccess(usersDto));
                }

                var userDto = await _userService.GetAsync();
                return Ok(ResultViewModelTemplates.GetSuccess(userDto));
            }
            catch (DomainException domainException)
            {
                return BadRequest();
            }
            catch (Exception exception)
            {
                return StatusCode(500, "Error");
            }         
        }
    }
}