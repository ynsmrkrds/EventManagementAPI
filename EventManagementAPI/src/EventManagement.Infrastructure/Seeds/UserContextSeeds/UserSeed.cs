using EventManagement.Domain.Entities.UserContextEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagement.Infrastructure.Seeds.UserContextSeeds
{
    internal class UserSeed : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            string passwordHash = "fmHozsVo2XK8en7u0/+SU5KMtuAG/N3OpZzORpQLHyNIxPiFG0ID0kQPuyDmKrgkScdwqsxDgI2QU3pVu3wZsg=="; // 123456
            UserEntity userEntity = new("Admin", "Admin", "admin@xyz.com", passwordHash)
            {
                ID = 1
            };

            builder.HasData(userEntity);
        }
    }
}
