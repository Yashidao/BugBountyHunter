using BugBountyHunter.Api.Commands.Rapport;
using BugBountyHunter.Api.DataBase.Context;
using BugBountyHunter.Api.DataBase.Entities;
using BugBountyHunter.Api.Dtos;
using BugBountyHunter.Api.Queries.Rapport;
using BugBountyHunter.Api.Repositories;
using BugBountyHunter.Tools.Commands;
using BugBountyHunter.Tools.Queries;
using Microsoft.EntityFrameworkCore;

namespace BugBountyHunter.Api.Services
{
    public class RapportService : IRapportRepository
    {
        private readonly IDataContext _context;

        public RapportService(IDataContext context)
        {
            _context = context;
        }

        public CommandResult Execute(AddRapportCommand command)
        {
            RapportEntity entityToAdd = new()
            {
                Name = command.Name,
                Description = command.Description,
                UserId = command.UserId,
                ProgramId = command.ProgramId,
            };

            try
            {
                _context.Rapports.Add(entityToAdd);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure("Une erreur s'est produite lors de l'enregistrement de votre rapport.", ex);
            }
        }

        public CommandResult Execute(UpdateAllRapportCommand command)
        {
            try
            {
                RapportEntity? entity = _context.Rapports.SingleOrDefault(x => x.Id == command.Id);
                if (entity is null)
                {
                    return CommandResult.Failure("Une erreur s'est produite car l'id n'est pas correct.");
                }

                // TODO on ne vérifie pas si il est pas juste vide
                entity.Name = command.Name ?? entity.Name;
                entity.Description = command.Description ?? entity.Description;
                entity.Status = command.Status ?? entity.Status;
                entity.ProgramId = command.ProgramId ?? entity.ProgramId;
                entity.UserId = command.UserId ?? entity.UserId;

                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex.Message, ex);
            }
        }

        public QueryResult<IEnumerable<RapportDto>> Execute(GetAllRapportQuery query)
        {
            List<RapportDto> rapportDtoList = new();
            try
            {
                // TODO Probleme ici avec userId
                List<RapportEntity> entity = _context.Rapports.Include(x => x.UserId).Include(x => x.ProgramId).ToList();
                if (entity is null)
                {
                    return QueryResult<IEnumerable<RapportDto>>.Failure("Une erreur s'est produite lors de la mise en liste.");
                }

                foreach (RapportEntity entityRapport in entity)
                {
                    RapportDto rapport = new()
                    {
                        Id = entityRapport.Id,
                        Name = entityRapport.Name,
                        UserName = entityRapport.UserId.ToString(),
                        EtsName = entityRapport.ProgramId.ToString()
                    };
                    rapportDtoList.Add(rapport);
                }

                return QueryResult<IEnumerable<RapportDto>>.Success(rapportDtoList);
                //foreach (RapportEntity entityRapport in entity)
                //{
                //    foreach (var item in entityRapport.)
                //    {

                //    }
                //}
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
