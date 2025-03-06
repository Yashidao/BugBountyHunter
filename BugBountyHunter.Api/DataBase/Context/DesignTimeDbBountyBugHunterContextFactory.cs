using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BugBountyHunter.Api.DataBase.Context
{
    public class DesignTimeDbBountyBugHunterContextFactory : IDesignTimeDbContextFactory<DbBugBountyHunterContext>
    {
        public DbBugBountyHunterContext CreateDbContext(string[] args)
        {
            // Charger la configuration depuis appSettings.json
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: false)
                .Build();

            // Obtenir la chaîne de connexion
            string connectionString = config.GetConnectionString("Default")!;

            // Configurer les options du DbContext
            DbContextOptionsBuilder<DbBugBountyHunterContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5, // Nombre maximal de tentatives
                    maxRetryDelay: TimeSpan.FromSeconds(30), // Délai maximal entre les tentatives
                    errorNumbersToAdd: null); // Numéros d'erreur SQL spécifiques à prendre en compte pour les nouvelles tentatives (optionnel)
            });

            return new DbBugBountyHunterContext(optionsBuilder.Options);
        }
    }
}
