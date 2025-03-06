using System.ComponentModel.DataAnnotations;

namespace BugBountyHunter.Api.DataBase.Entities
{
    public class EtsEntity
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public IEnumerable<ProgramEntity> Programs { get; set; } = [];
    }
}
