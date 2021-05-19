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

        public virtual DbSet<Counters> Counters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Counters>(entity =>
            {
                entity.HasKey(e => e.CounterId).HasName("PRIMARY");

                entity.ToTable("counters");

                entity.Property(e => e.CounterId).HasColumnName("counter_id");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
