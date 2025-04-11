using BugBountyHunter.Api.Commands.Ets;
using BugBountyHunter.Api.Commands.Program;
using BugBountyHunter.Api.DataBase.Context;
using BugBountyHunter.Api.DataBase.Entities;
using BugBountyHunter.Api.Repositories;
using BugBountyHunter.Tools.Commands;
using Microsoft.EntityFrameworkCore;

namespace BugBountyHunter.Api.Services
{
    public class ProgramService : IProgramRepository
    {
        private readonly IDataContext _context;

        public ProgramService(IDataContext context)
        {
            _context = context;
        }

        public CommandResult Execute(AddProgramCommand command)
        {
            ProgramEntity programToInsert = new()
            {
                Name = command.Name,
                EtsId = command.EtsId
            };

            try
            {
                _context.Programs.Add(programToInsert);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure("Une erreur s'est produite lors de l'enregistrement de votre program.", ex);
            }
        }
        // Update le nom du programme
        public CommandResult Execute(UpdateNameProgramCommand command)
        {
            try
            {
                ProgramEntity? entity = _context.Programs.SingleOrDefault(x => x.Id == command.Id);
                if (entity is null)
                {
                    return CommandResult.Failure("Une erreur s'est produite car l'id n'est pas correct.");
                }

                entity.EtsId = command.EtsId;

                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex.Message, ex);
            }
        }
        // Update l'Ets du programme
        public CommandResult Execute(UpdateEtsProgramCommand command)
        {
            try
            {
                ProgramEntity? entity = _context.Programs.SingleOrDefault(x => x.Id == command.Id);
                if (entity is null)
                {
                    return CommandResult.Failure("Une erreur s'est produite car l'id n'est pas correct.");
                }

                entity.Name = command.Name;

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
