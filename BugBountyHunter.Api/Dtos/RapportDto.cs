using BugBountyHunter.Api.DataBase.Entities;

namespace BugBountyHunter.Api.Dtos
{
    public class RapportDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string EtsName { get; set; }
    }
}
