using BugBountyHunter.Api.DataBase.Entities;
using BugBountyHunter.Tools.Queries;

namespace BugBountyHunter.Api.Queries.User
{
    public class GetAllUsersQuery : IQueryDefinition<IEnumerable<UserEntity>>
    {       
    }
}
