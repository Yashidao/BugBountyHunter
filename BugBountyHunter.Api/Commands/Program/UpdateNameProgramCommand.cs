using BugBountyHunter.Tools.Commands;

namespace BugBountyHunter.Api.Commands.Program
{
    public class UpdateNameProgramCommand : ICommandDefinition
    {
        public int Id { get; set; }
        public required int EtsId { get; set; }
      
        public UpdateNameProgramCommand(int id, int etsId)
        {
            Id = id;
            EtsId = etsId;
        }
    }
}
