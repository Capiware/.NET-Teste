using Capiware.Technologies.TesteTecnico.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace Capiware.Technologies.TesteTecnico.WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Servico> Servicos { get; set; }
    }
}
