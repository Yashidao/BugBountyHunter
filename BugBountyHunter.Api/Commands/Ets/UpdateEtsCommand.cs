using BugBountyHunter.Tools.Commands;

namespace BugBountyHunter.Api.Commands.Ets
{
    public class UpdateEtsCommand : ICommandDefinition
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UpdateEtsCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
