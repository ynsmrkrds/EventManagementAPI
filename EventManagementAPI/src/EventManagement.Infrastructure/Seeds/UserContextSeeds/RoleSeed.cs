using EventManagement.Domain.Entities.UserContextEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagement.Infrastructure.Seeds.UserContextSeeds
{
    internal class RoleSeed : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            RoleEntity adminUserRoleEntity = new("Admin", "This is a role for admin users.")
            {
                ID = 1
            };

            RoleEntity standardUserRoleEntity = new("Standard", "This is a role for standard users.")
            {
                ID = 2
            };

            builder.HasData(adminUserRoleEntity);
            builder.HasData(standardUserRoleEntity);
        }
    }
}
