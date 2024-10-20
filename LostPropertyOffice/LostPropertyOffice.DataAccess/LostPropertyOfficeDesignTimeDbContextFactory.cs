using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LostPropertyOffice.DataAccess
{
    public class LostPropertyOfficeDesignTimeDbContextFactory : IDesignTimeDbContextFactory<LostPropertyOfficeDbContext>
    {
        public LostPropertyOfficeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LostPropertyOfficeDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=LostPropertyOfficeDb;Username=myuser;Password=mypassword");

            return new LostPropertyOfficeDbContext(optionsBuilder.Options);
        }
    }
}