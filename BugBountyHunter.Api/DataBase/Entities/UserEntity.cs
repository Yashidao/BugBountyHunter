using System.ComponentModel.DataAnnotations;

namespace BugBountyHunter.Api.DataBase.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Role { get; set; }
        public int Reward { get; set; } = 0;
    }
}