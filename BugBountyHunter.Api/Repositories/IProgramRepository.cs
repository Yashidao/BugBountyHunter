using BugBountyHunter.Api.Commands.Program;
using BugBountyHunter.Api.Dtos;
using BugBountyHunter.Api.Queries.Rapport;
using BugBountyHunter.Tools.Commands;
using BugBountyHunter.Tools.Queries;

namespace BugBountyHunter.Api.Repositories
{
    public interface IProgramRepository : 
        ICommandHandler<AddProgramCommand>,
        ICommandHandler<UpdateEtsProgramCommand>,
        ICommandHandler<UpdateNameProgramCommand>
    {
    }
}
