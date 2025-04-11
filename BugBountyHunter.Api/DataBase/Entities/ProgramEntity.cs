using System.ComponentModel.DataAnnotations;

namespace BugBountyHunter.Api.DataBase.Entities
{
    public class ProgramEntity
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int EtsId { get; set; }
        public EtsEntity? Ets { get; set; }
        public IEnumerable<RapportEntity> Rapports { get; set; } = new List<RapportEntity>();
    }
}
