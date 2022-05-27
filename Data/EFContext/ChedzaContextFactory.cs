using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ChedzaApp.api.Data.EFContext
{
    public class ChedzaContextFactory : IDesignTimeDbContextFactory<ChedzaContext>
    {
        public ChedzaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChedzaContext>();
            var connectionString = @"Server=., 41970;Database=ChedzaDB;User ID=sa;Password=Shared4u;MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            Console.WriteLine(connectionString);
            return new ChedzaContext(optionsBuilder.Options);
        }       
    }
}