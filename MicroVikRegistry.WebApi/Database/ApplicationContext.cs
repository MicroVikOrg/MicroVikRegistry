using Microsoft.EntityFrameworkCore;
using MicroVikRegistry.WebApi.Nodes;

namespace MicroVikRegistry.WebApi.Database
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Node> Nodes { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
