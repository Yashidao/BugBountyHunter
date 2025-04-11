using BugBountyHunter.Tools.Commands;

namespace BugBountyHunter.Api.Commands.Rapport
{
    // TODO attention chaque élément ne doit pas être null!
    public class UpdateAllRapportCommand : ICommandDefinition
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public int? UserId { get; set; }
        public int? ProgramId { get; set; }

        public UpdateAllRapportCommand(string? name, string? description, string? status, int? userId, int? programId)
        {
            Name = name;
            Description = description;
            Status = status;
            UserId = userId;
            ProgramId = programId;
        }
    }
}
