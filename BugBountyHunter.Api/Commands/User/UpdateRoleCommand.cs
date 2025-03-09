using BugBountyHunter.Tools.Commands;

namespace BugBountyHunter.Api.Commands.User
{
    public class UpdateRoleCommand : ICommandDefinition
    {
        public UpdateRoleCommand(int id, string role)
        {
            Id = id;
            Role = role;
        }

        public int Id { get; set; }
        public string Role { get; set; }
    }
}
