using BugBountyHunter.Api.Commands;
using BugBountyHunter.Api.DataBase.Entities;
using BugBountyHunter.Api.Queries;
using BugBountyHunter.Api.Repositories;
using BugBountyHunter.Tools.Commands;
using BugBountyHunter.Tools.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugBountyHunter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _us;

        public UserController(IUserRepository user)
        {
            _us = user;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterCommand userToRegister)
        {
            CommandResult result = _us.Execute(userToRegister);
            if (result.IsFailure)
            {
#if DEBUG
                return BadRequest($"{result.ErrorMessage}\n{result.Exception}"); 
#endif
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.IsSuccess);
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginQuery userToLogin)
        {
            QueryResult<UserEntity?> result = _us.Execute(userToLogin);
            if (result.IsFailure)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Result);
        }
    }
}
