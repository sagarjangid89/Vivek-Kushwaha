using Microsoft.EntityFrameworkCore;
using Tiko_Entities.Concrete;

namespace Tiko_DataAccess.Concrete.EntityFramework
{
    public class TikoDbContext : DbContext
    {
        public TikoDbContext(DbContextOptions<TikoDbContext> options) : base(options)
        {
        }

        public TikoDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=LAPN202130\\MSSQL2019;Initial Catalog = Test;Integrated Security=SSPI;",
                b => b.MigrationsAssembly("Tiko_WebAPI"));
        }

        public DbSet<Agent> Agents { get; set; }
    }
}