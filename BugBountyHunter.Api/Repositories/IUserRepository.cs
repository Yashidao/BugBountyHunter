using BugBountyHunter.Api.Commands.User;
using BugBountyHunter.Api.DataBase.Entities;
using BugBountyHunter.Api.Queries.User;
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
