using EventManagement.Domain.Entities.UserContextEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagement.Infrastructure.Seeds.UserContextSeeds
{
    internal class UserRoleSeed : IEntityTypeConfiguration<UserRoleEntity>
    {
        public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
        {
            UserRoleEntity userRoleEntity = new(1, 1)
            {
                ID = 1
            };

            builder.HasData(userRoleEntity);
        }
    }
}
