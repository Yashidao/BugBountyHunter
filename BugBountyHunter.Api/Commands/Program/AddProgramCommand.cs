using BugBountyHunter.Tools.Commands;

namespace BugBountyHunter.Api.Commands.Program
{
    public class AddProgramCommand : ICommandDefinition
    {
        public string Name { get; set; }
        public int EtsId { get; set; }

        public AddProgramCommand(string name, int etsId)
        {
            Name = name;
            EtsId = etsId;
        }
    }
}
