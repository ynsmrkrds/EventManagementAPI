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
