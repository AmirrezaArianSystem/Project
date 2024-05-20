using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Persistence
{
    internal class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasMany(current=>current.Citys).
                WithOne(other=>other.Province).
                HasForeignKey(other => other.ProvinceId).
                OnDelete(DeleteBehavior.Cascade);
        }
    }
}