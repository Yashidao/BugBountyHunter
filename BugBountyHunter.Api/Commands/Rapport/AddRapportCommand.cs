using BugBountyHunter.Tools.Commands;

namespace BugBountyHunter.Api.Commands.Rapport
{
    public class AddRapportCommand : ICommandDefinition
    {
        public required string Name { get; set; }
        public required string Description { get; set; } = string.Empty;
        public required int UserId { get; set; }
        public required int ProgramId { get; set; }
        
        public AddRapportCommand(string name, string description, int userId, int programId)
        {
            Name = name;
            Description = description;
            UserId = userId;
            ProgramId = programId;
        }
    }
}
