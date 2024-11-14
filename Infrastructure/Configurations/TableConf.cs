using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TableConf: IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.HasKey(t => t.TableId);
        builder.HasMany(t => t.Reservations)
            .WithOne(t => t.Table)
            .HasForeignKey(r => r.TableId);
    }
    
}