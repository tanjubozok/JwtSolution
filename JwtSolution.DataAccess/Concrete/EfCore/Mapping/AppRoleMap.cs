using JwtSolution.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtSolution.DataAccess.Concrete.EfCore.Mapping
{
    public class AppRoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("AppRoles");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.HasMany(x => x.AppUserRoles)
                .WithOne(x => x.AppRole)
                .HasForeignKey(x => x.AppRoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
