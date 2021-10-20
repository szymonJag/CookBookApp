using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CookBookApp.DataAccess
{
    public class CookBookAppContextFactory : IDesignTimeDbContextFactory<CookBookAppContext>
    {
        public CookBookAppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CookBookAppContext>();
            //optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=CookBook;Integrated Security=True");
            optionsBuilder.UseSqlServer("Server=tcp:cookbook.database.windows.net,1433;Initial Catalog=CookBook;Persist Security Info=False;User ID=szymon;Password=gt3QuT4Hop2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new CookBookAppContext(optionsBuilder.Options);
        }
    }
}
