using System.ComponentModel.DataAnnotations;

namespace BugBountyHunter.Api.DataBase.Entities
{
    public class RapportEntity
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string Status { get; set; } = "In progress";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public required string UserId { get; set; }
        public required int ProgramId { get; set; }
        public required ProgramEntity Program { get; set; }
    }
}
