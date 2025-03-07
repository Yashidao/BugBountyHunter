using BugBountyHunter.Tools.Commands;

namespace BugBountyHunter.Api.Commands
{
    public class RegisterCommand : ICommandDefinition
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public RegisterCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }

}
