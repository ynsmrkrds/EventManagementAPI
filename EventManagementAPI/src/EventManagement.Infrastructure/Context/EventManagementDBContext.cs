using EventManagement.Domain.Entities.CategoryContextEntities;
using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.Entities.LocationContextEntities;
using EventManagement.Domain.Entities.UserContextEntities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EventManagement.Infrastructure.Context
{
    public class EventManagementDBContext : DbContext
    {
        #region User Bounded Context DbSets 
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }

        public DbSet<UserRoleEntity> UserRoles { get; set; }
        #endregion

        #region Category Bounded Context DbSets 
        public DbSet<CategoryEntity> Categories { get; set; }
        #endregion

        #region Location Bounded Context DbSets 
        public DbSet<LocationEntity> Locations { get; set; }
        #endregion

        #region Event Bounded Context DbSets 
        public DbSet<EventEntity> Events { get; set; }
        #endregion

        public EventManagementDBContext(DbContextOptions<EventManagementDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
