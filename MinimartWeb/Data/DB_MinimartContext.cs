using Microsoft.EntityFrameworkCore;

namespace MinimartWeb.Data
{
    public class DB_MinimartContext : DbContext
    {
        public DB_MinimartContext(DbContextOptions<DB_MinimartContext> options):base(options) { }

        public DbSet<tdAccountEntity> AccountEntity { get; set; }
        public DbSet<tdCategoryEntity> CategoryEntity { get; set; }
        public DbSet<tdProductEntity> ProductEntity { get; set; }
        public DbSet<tdBlogEntity> BlogEntity { get; set; }
    }
}
