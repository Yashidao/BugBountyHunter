using BugBountyHunter.Api.Commands;
using BugBountyHunter.Api.DataBase.Entities;
using BugBountyHunter.Api.Queries;
using BugBountyHunter.Tools.Commands;
using BugBountyHunter.Tools.Queries;

namespace BugBountyHunter.Api.Repositories
{
    public interface IUserRepository : 
        ICommandHandler<RegisterCommand>, 
        ICommandHandler<UpdateRoleCommand>,
        ICommandHandler<UpdateRewardCommand>,
        IQueryHandler<LoginQuery, UserEntity?>
    {
    }
}
