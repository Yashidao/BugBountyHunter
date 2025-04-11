using BugBountyHunter.Api.DataBase.Entities;
using BugBountyHunter.Tools.Queries;

namespace BugBountyHunter.Api.Queries.User
{
    public class GetUserQuery : IQueryDefinition<UserEntity?>
    {      
        public string Email { get; set; }
        
        public GetUserQuery(string email)
        {           
            Email = email;
        }
    }
}
