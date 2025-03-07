using BugBountyHunter.Api.DataBase.Entities;
using BugBountyHunter.Tools.Queries;

namespace BugBountyHunter.Api.Queries
{
    public class LoginQuery : IQueryDefinition<UserEntity?>
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public LoginQuery(string email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}
