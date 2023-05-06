using EventManagement.Domain.Entities.UserContextEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagement.Infrastructure.Seeds.UserContextSeeds
{
    internal class UserSeed : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            string passwordHash = "7621e5c63ac7b718709bfc509a91e4b9368253c8b72849a8d68bfa857ae27c8800c2fc0b586dea78ac4cf1031fe15e653e2af7619800c12f4af14ec771d3f9ea"; // &XYZ.2023
            UserEntity userEntity = new("Admin", "Admin", "admin@xyz.com", passwordHash)
            {
                ID = 1
            };

            builder.HasData(userEntity);
        }
    }
}
