using BugBountyHunter.Api.Commands.Ets;
using BugBountyHunter.Api.Commands.User;
using BugBountyHunter.Api.Repositories;
using BugBountyHunter.Tools.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugBountyHunter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EtsController : ControllerBase
    {
        private readonly IEtsRepository _ets;

        public EtsController(IEtsRepository ets)
        {
            _ets = ets;
        }

        [HttpPost("insert")]
        public IActionResult Insert(AddEtsCommand etsToInsert)
        {
            CommandResult result = _ets.Execute(etsToInsert);
            if (result.IsFailure)
            {
#if DEBUG
                return BadRequest($"{result.ErrorMessage}\n{result.Exception}");
#endif
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.IsSuccess);
        }

        [HttpPost("updateEts")]
        public IActionResult Update(UpdateEtsCommand etsToUpdate)
        {
            CommandResult result = _ets.Execute(etsToUpdate);
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
