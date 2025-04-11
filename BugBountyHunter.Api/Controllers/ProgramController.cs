using BugBountyHunter.Api.Commands.Program;
using BugBountyHunter.Api.Repositories;
using BugBountyHunter.Tools.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugBountyHunter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramRepository _prog;

        public ProgramController(IProgramRepository prog)
        {
            _prog = prog;
        }

        [HttpPost("insert")]
        public IActionResult Insert(AddProgramCommand command)
        {
            CommandResult result = _prog.Execute(command);
            if (result.IsFailure)
            {
#if DEBUG
                return BadRequest($"{result.ErrorMessage}\n{result.Exception}");
#endif
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.IsSuccess);
        }

        [HttpPost("updateName")]
        public IActionResult UpdateName(UpdateNameProgramCommand command)
        {
            CommandResult result = _prog.Execute(command);
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
        public IActionResult UpdateEts(UpdateEtsProgramCommand command)
        {
            CommandResult result = _prog.Execute(command);
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
