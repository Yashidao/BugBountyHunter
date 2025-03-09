using BugBountyHunter.Tools.Commands;

namespace BugBountyHunter.Api.Commands.Ets
{
    public class AddEtsCommand : ICommandDefinition
    {
        public string Name { get; set; }

        public AddEtsCommand(string name)
        {
            Name = name;
        }
    }
}
