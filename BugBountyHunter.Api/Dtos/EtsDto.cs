namespace BugBountyHunter.Api.Dtos
{
    public class EtsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Programs { get; set; } = new List<string>();
    }
}
