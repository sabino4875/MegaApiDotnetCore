namespace Api.Megaman.InfraStructure.Context
{
    using Api.Megaman.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RobotsContext: DbContext
    {
        public RobotsContext(DbContextOptions<RobotsContext> options):base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Robot>(new RobotConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Robot> Robots { get; set; }

        private class RobotConfiguration : IEntityTypeConfiguration<Robot>
        {
            public void Configure(EntityTypeBuilder<Robot> builder)
            {
                builder.ToTable("tblRobots");
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id).HasColumnName("id").IsRequired().UseIdentityColumn();
                builder.Property(e => e.Name).HasColumnName("nome").IsRequired().HasMaxLength(80);
                builder.Property(e => e.Code).HasColumnName("codigo").IsRequired().HasMaxLength(20);
                builder.Property(e => e.HP).HasColumnName("hp").IsRequired();
                builder.Property(e => e.Picture).HasColumnName("imagem").IsRequired().HasMaxLength(200);

            }
        }
    }
}