using BugBountyHunter.Api.Commands.Ets;
using BugBountyHunter.Api.DataBase.Context;
using BugBountyHunter.Api.DataBase.Entities;
using BugBountyHunter.Api.Repositories;
using BugBountyHunter.Tools.Commands;

namespace BugBountyHunter.Api.Services
{
    public class EtsService : IEtsRepository
    {
        private readonly IDataContext _context;

        public EtsService(IDataContext context)
        {
            _context = context;
        }
        public CommandResult Execute(AddEtsCommand command)
        {
            EtsEntity etsToAdd = new()
            {
                Name = command.Name
            };

            try
            {
                _context.Ets.Add(etsToAdd);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure("Une erreur s'est produite lors de l'enregistrement de votre entreprise.", ex);
            }
        }
        
        public CommandResult Execute(UpdateEtsCommand command)
        {
            try
            {
                EtsEntity? etsToUpdate = _context.Ets.SingleOrDefault(x => x.Id == command.Id);
                if (etsToUpdate is null) 
                {
                    return CommandResult.Failure("Une erreur s'est produite car l'id n'est pas correct.");
                }

                etsToUpdate.Name = command.Name;

                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex.Message, ex);
            }
        }
    }
}
