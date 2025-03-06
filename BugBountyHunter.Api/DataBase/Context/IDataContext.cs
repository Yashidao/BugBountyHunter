using BugBountyHunter.Api.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace BugBountyHunter.Api.DataBase.Context
{
    public interface IDataContext
    {

        DbSet<UserEntity> Users { get; set; }
        DbSet<ProgramEntity> Programs { get; set; }
        DbSet<RapportEntity> Rapports { get; set; }
        DbSet<EtsEntity> Ets { get; set; }

        int SaveChanges();
        IQueryable<T> Set<T>()
            where T : class;

    }
}
