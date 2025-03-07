using BugBountyHunter.Api.Commands;
using BugBountyHunter.Api.DataBase.Context;
using BugBountyHunter.Api.DataBase.Entities;
using BugBountyHunter.Api.Repositories;
using BugBountyHunter.Tools.Commands;

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
    }
}
