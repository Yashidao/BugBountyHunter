using BugBountyHunter.Tools.Commands;

namespace BugBountyHunter.Api.Commands
{
    public class UpdateRewardCommand : ICommandDefinition
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public UpdateRewardCommand(int id, int amount)
        {
            Id = id;
            Amount = amount;
        }
    }
}
