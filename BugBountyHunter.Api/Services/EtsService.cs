using BugBountyHunter.Api.Commands.Ets;
using BugBountyHunter.Api.DataBase.Context;
using BugBountyHunter.Api.DataBase.Entities;
using BugBountyHunter.Api.Dtos;
using BugBountyHunter.Api.Queries.Ets;
using BugBountyHunter.Api.Repositories;
using BugBountyHunter.Tools.Commands;
using BugBountyHunter.Tools.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


// TODO faire un mapper pour les dtos
// TODO faire le getAllEts avec includes (avoir plus de ligne dans ets et program)
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

        public QueryResult<EtsDto> Execute(GetEtsByIdQuery query)
        {
            List<string> programListName = new();

            try
            {
                EtsEntity? entity = _context.Ets.Include(x => x.Programs).SingleOrDefault(x => x.Id == query.Id);
                if (entity is null)
                {
                    return QueryResult<EtsDto>.Failure("Une erreur s'est produite car l'id n'est pas correct.");
                }

                foreach (ProgramEntity program in entity.Programs)
                {
                    programListName.Add(program.Name);
                }

                EtsDto entityDto = new()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Programs = programListName
                };

                return QueryResult<EtsDto>.Success(entityDto);
            }
            catch (Exception ex)
            {
                return QueryResult<EtsDto>.Failure(ex.Message, ex);
            }
        }

        public QueryResult<IEnumerable<EtsDto>> Execute(GetAllEtsQuery query)
        {
            List<string> programListName = new();

            try
            {
                List<EtsEntity> entity = _context.Ets.Include(x => x.Programs).ToList();
                if (entity is null)
                {
                    return QueryResult<IEnumerable<EtsDto>>.Failure("Une erreur s'est produite lors de la mise en liste.");
                }
                
                foreach (EtsEntity entityEts in entity)
                {
                    foreach (ProgramEntity program in entityEts.Programs)
                    {
                        programListName.Add(program.Name);
                    }

                    EtsDto entityDto = new()
                    {
                        Id = entityEts.Id,
                        Name = entityEts.Name,
                        Programs = programListName
                    };

                    programListName.Clear();
                }

                // Méthode trouvée avec copilot mais je ne la comprends pas trop :/
                IEnumerable<EtsDto> mappedEntities = entity.Select(e => new EtsDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Programs = e.Programs.Select(p => p.Name)
                });

                return QueryResult<IEnumerable<EtsDto>>.Success(mappedEntities);
            }
            catch (Exception ex)
            {
                return QueryResult<IEnumerable<EtsDto>>.Failure(ex.Message, ex);
            }
        }
    }
}
