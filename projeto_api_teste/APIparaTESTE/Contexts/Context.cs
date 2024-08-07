using Microsoft.EntityFrameworkCore;
using APIparaTESTE.Domains;

namespace APIparaTESTE.Contexts
    {
    public class Context : DbContext
        {
        public DbSet<Product> Produto { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            //optionsBuilder.UseSqlServer("Server = NOTE11-SALA21; Database = BancoTesteTarde; User Id = sa; Password = Senai@134; TrustServerCertificate = True;");
            optionsBuilder.UseSqlServer("Server = DESKTOP-G6K3C1V; Database = BancoTesteTarde; User Id = sampaio; Password = 2605; TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
            }
        }
    }
