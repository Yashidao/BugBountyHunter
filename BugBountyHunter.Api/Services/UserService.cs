using BugBountyHunter.Api.Commands.User;
using BugBountyHunter.Api.DataBase.Context;
using BugBountyHunter.Api.DataBase.Entities;
using BugBountyHunter.Api.Queries.User;
using BugBountyHunter.Api.Repositories;
using BugBountyHunter.Tools.Commands;
using BugBountyHunter.Tools.Queries;

namespace BugBountyHunter.Api.Services
{
    public class UserService : IUserRepository
    {
        private readonly IDataContext _context;

        public UserService(IDataContext context)
        {
            _context = context;
        }

        public CommandResult Execute(RegisterCommand command)
        {
            UserEntity UserToRegister = new()
            {
                Name = command.Name,
                Email = command.Email
            };

            try
            {
                _context.Users.Add(UserToRegister);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure("Une erreur s'est produite lors de l'enregistrement d'un utilisateur.", ex);
            }
        }

        public QueryResult<UserEntity?> Execute(LoginQuery query)
        {
            try
            {
                UserEntity? userToLogin = _context.Users.SingleOrDefault(x => x.Email == query.Email && x.Name == query.Name);
                if (userToLogin is null)
                {
                    return QueryResult<UserEntity?>.Failure("Cet user n'existe pas dans notre base de donnée");
                }
                return QueryResult<UserEntity>.Success(userToLogin)!;
            }
            catch (Exception ex)
            {
                return QueryResult<UserEntity?>.Failure(ex.Message, ex);
            }
        }

        public CommandResult Execute(UpdateRoleCommand userToUpdate)
        {
            try
            {
                UserEntity? userById = _context.Users.SingleOrDefault(x => x.Id == userToUpdate.Id);
                if (userById is null)
                {
                    return CommandResult.Failure("Cet userId n'existe pas dans notre base de donnée");
                }

                userById!.Role = userToUpdate.Role;

                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure($"{ex.Message}", ex);
            }
        }

        public CommandResult Execute(UpdateRewardCommand userUpdateReward)
        {
            try
            {
                UserEntity? userById = _context.Users.SingleOrDefault(x => x.Id == userUpdateReward.Id);
                if (userById is null)
                {
                    return CommandResult.Failure("Cet userId n'existe pas dans notre base de donnée");
                }

                userById.Reward += userUpdateReward.Amount;

                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure($"{ex.Message}", ex);
            }
        }
    }
}
