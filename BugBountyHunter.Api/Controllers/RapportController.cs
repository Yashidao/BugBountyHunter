using BugBountyHunter.Api.Commands.Rapport;
using BugBountyHunter.Api.DataBase.Context;
using BugBountyHunter.Api.Dtos;
using BugBountyHunter.Api.Queries.Rapport;
using BugBountyHunter.Api.Repositories;
using BugBountyHunter.Tools.Commands;
using BugBountyHunter.Tools.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugBountyHunter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RapportController : ControllerBase
    {
        private readonly IRapportRepository _rap;

        public RapportController(IRapportRepository rap)
        {
            _rap = rap;
        }

        [HttpPost("insert")]
        public IActionResult Insert(AddRapportCommand command)
        {
            CommandResult result = _rap.Execute(command);
            if (result.IsFailure)
            {
#if DEBUG
                return BadRequest($"{result.ErrorMessage}\n{result.Exception}");
#endif
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.IsSuccess);
        }

        [HttpPost("updateAll")]
        public IActionResult UpdateAll(UpdateAllRapportCommand command)
        {
            CommandResult result = _rap.Execute(command);
            if (result.IsFailure)
            {
#if DEBUG
                return BadRequest($"{result.ErrorMessage}\n{result.Exception}");
#endif
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.IsSuccess);
        }

        [HttpPost("getAllRapport")]
        public IActionResult GetAllRapport(GetAllRapportQuery query)
        {
            QueryResult<IEnumerable<RapportDto>> result = _rap.Execute(query);
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
