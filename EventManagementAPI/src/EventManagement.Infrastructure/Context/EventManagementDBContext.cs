using EventManagement.Domain.Entities.CategoryContextEntities;
using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.Entities.LocationContextEntities;
using EventManagement.Domain.Entities.TicketContextEntities;
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

        #region Ticket Bounded Context DbSets 
        public DbSet<TicketEntity> Tickets { get; set; }
        #endregion

        public EventManagementDBContext(DbContextOptions<EventManagementDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #region Event Bounded Context Configurations
            modelBuilder.Entity<EventEntity>()
                .HasOne(x => x.Location)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.LocationID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EventEntity>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.CategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EventEntity>()
               .HasOne(x => x.CreatedBy)
               .WithMany(x => x.Events)
               .HasForeignKey(x => x.CreatedByID)
               .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Ticket Bounded Context Configurations
            modelBuilder.Entity<TicketEntity>()
                .HasOne(x => x.Event)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.EventID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TicketEntity>()
                .HasOne(x => x.PurchasedBy)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.PurchasedByID)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region User Bounded Context Configurations
            modelBuilder.Entity<UserRoleEntity>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRoleEntity>()
                .HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleID)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
