using Microsoft.EntityFrameworkCore;

namespace IdentifiersService.Models.DBModels
{
    public partial class IdentifiersServiceContext : DbContext
    {
        public IdentifiersServiceContext()
        {
        }

        public IdentifiersServiceContext(DbContextOptions<IdentifiersServiceContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
