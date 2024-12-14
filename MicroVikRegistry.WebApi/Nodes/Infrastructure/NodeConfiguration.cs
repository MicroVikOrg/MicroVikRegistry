using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroVikRegistry.WebApi.Nodes.Infrastructure
{
    public sealed class NodeConfiguration : IEntityTypeConfiguration<Node>
    {
        public void Configure(EntityTypeBuilder<Node> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.ToTable("nodes");

            builder.Property(p => p.Url)
                .HasColumnName("url")
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(p => p.StartedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("started_at");
            builder.Property(p => p.Wallet)
                .HasColumnName("wallet");
            builder.Property(p => p.Location)
                .HasMaxLength(100)
                .HasColumnName("location");
            builder.Property(p => p.IsOffical)
                .HasColumnName("is_offical");
        }
    }
}
