using BugBountyHunter.Api.Commands.Rapport;
using BugBountyHunter.Api.Dtos;
using BugBountyHunter.Api.Queries.Rapport;
using BugBountyHunter.Tools.Commands;
using BugBountyHunter.Tools.Queries;

namespace BugBountyHunter.Api.Repositories
{
    public interface IRapportRepository : 
        ICommandHandler<AddRapportCommand>,
        ICommandHandler<UpdateAllRapportCommand>,
        IQueryHandler<GetAllRapportQuery, IEnumerable<RapportDto>>
    {
    }
}
