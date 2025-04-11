using BugBountyHunter.Tools.Commands;

namespace BugBountyHunter.Api.Commands.Program
{
    public class UpdateEtsProgramCommand : ICommandDefinition
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public UpdateEtsProgramCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
