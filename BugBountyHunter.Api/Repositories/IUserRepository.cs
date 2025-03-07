using BugBountyHunter.Api.Commands;
using BugBountyHunter.Tools.Commands;

namespace BugBountyHunter.Api.Repositories
{
    public interface IUserRepository : ICommandHandler<RegisterCommand>
    {
    }
}
