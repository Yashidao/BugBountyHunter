using BugBountyHunter.Api.Commands.Ets;
using BugBountyHunter.Api.Dtos;
using BugBountyHunter.Api.Queries.Ets;
using BugBountyHunter.Tools.Commands;
using BugBountyHunter.Tools.Queries;

namespace BugBountyHunter.Api.Repositories
{
    public interface IEtsRepository :
        ICommandHandler<AddEtsCommand>,
        ICommandHandler<UpdateEtsCommand>,
        IQueryHandler<GetEtsByIdQuery, EtsDto>,
        IQueryHandler<GetAllEtsQuery, IEnumerable<EtsDto>>
    {
    }
}
