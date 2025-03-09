using BugBountyHunter.Api.Commands.Ets;
using BugBountyHunter.Tools.Commands;

namespace BugBountyHunter.Api.Repositories
{
    public interface IEtsRepository : 
        ICommandHandler<AddEtsCommand>,
        ICommandHandler<UpdateEtsCommand>
    {
    }
}
