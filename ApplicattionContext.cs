using Microsoft.EntityFrameworkCore;
using SBIgraphic.Model;

namespace SBIgraphic
{
    public class ApplicattionContext : DbContext
    {
        public DbSet<Plavka> Plavka { get; set; }
        public DbSet<ZamerHirina> ZamerHirinas { get; set; }
        public DbSet<ZamerTolchina> ZamerTolchinas { get; set; }

       
        public ApplicattionContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DbSbi;Trusted_Connection=True;");
        }
    }
}
