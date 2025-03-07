using BugBountyHunter.Api.Commands;
using BugBountyHunter.Api.Repositories;
using BugBountyHunter.Tools.Commands;
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
        public IActionResult Register(RegisterCommand UserToRegister)
        {
            CommandResult result = _us.Execute(UserToRegister);
            if (result.IsFailure)
            {
#if DEBUG
                return BadRequest($"{result.ErrorMessage}\n{result.Exception}"); 
#endif
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.IsSuccess);
        }
    }
}
