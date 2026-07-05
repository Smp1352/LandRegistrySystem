using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LandRegistrySystem.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // برای اطمینان از اینکه ConnectionString را از appsettings.json می‌خواند
            // می‌توانید از کد زیر استفاده کنید، اما مقدار دهی مستقیم نیز کافی است:
            // var configuration = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("appsettings.json")
            //     .Build();
            // var connectionString = configuration.GetConnectionString("DefaultConnection");

            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=LandRegistryDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}