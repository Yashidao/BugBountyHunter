using BugBountyHunter.Api.Dtos;
using BugBountyHunter.Tools.Queries;

namespace BugBountyHunter.Api.Queries.Ets
{
    public class GetAllEtsQuery : IQueryDefinition<IEnumerable<EtsDto>>
    {
    }
}
