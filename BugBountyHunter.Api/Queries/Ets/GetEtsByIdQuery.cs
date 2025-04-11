using BugBountyHunter.Api.Dtos;
using BugBountyHunter.Tools.Queries;

namespace BugBountyHunter.Api.Queries.Ets
{
    public class GetEtsByIdQuery : IQueryDefinition<EtsDto>
    {
        public int Id { get; set; }

        public GetEtsByIdQuery(int id)
        {
            Id = id;
        }
    }
}
