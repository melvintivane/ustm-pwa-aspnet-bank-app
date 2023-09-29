using parteII_pwa_teste.Models;
using Microsoft.EntityFrameworkCore;

namespace parteII_pwa_teste.Data
{
    public class ContaDBContext : DbContext
    {
        public ContaDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Conta> Contas { get; set; }

    }
}