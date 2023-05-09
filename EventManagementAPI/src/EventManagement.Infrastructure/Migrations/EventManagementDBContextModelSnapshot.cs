﻿// <auto-generated />
using System;
using EventManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventManagement.Infrastructure.Migrations
{
    [DbContext(typeof(EventManagementDBContext))]
    partial class EventManagementDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventManagement.Domain.Entities.CategoryContextEntities.CategoryEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EventManagement.Domain.Entities.EventContextEntities.EventEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("CreatedByID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.Property<int>("Quota")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("CreatedByID");

                    b.HasIndex("LocationID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventManagement.Domain.Entities.LocationContextEntities.LocationEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("EventManagement.Domain.Entities.TicketContextEntities.TicketEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PurchasedByID")
                        .HasColumnType("int");

                    b.Property<string>("TicketNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EventID");

                    b.HasIndex("PurchasedByID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("EventManagement.Domain.Entities.UserContextEntities.RoleEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreatedDate = new DateTime(2023, 5, 9, 20, 35, 48, 715, DateTimeKind.Local).AddTicks(92),
                            Description = "This is a role for admin users.",
                            Name = "Admin"
                        },
                        new
                        {
                            ID = 2,
                            CreatedDate = new DateTime(2023, 5, 9, 20, 35, 48, 715, DateTimeKind.Local).AddTicks(108),
                            Description = "This is a role for standard users.",
                            Name = "Standard"
                        });
                });

            modelBuilder.Entity("EventManagement.Domain.Entities.UserContextEntities.UserEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreatedDate = new DateTime(2023, 5, 9, 20, 35, 48, 715, DateTimeKind.Local).AddTicks(3941),
                            Email = "admin@xyz.com",
                            Name = "Admin",
                            PasswordHash = "fmHozsVo2XK8en7u0/+SU5KMtuAG/N3OpZzORpQLHyNIxPiFG0ID0kQPuyDmKrgkScdwqsxDgI2QU3pVu3wZsg==",
                            Surname = "Admin"
                        });
                });

            modelBuilder.Entity("EventManagement.Domain.Entities.UserContextEntities.UserRoleEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.HasIndex("UserID");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreatedDate = new DateTime(2023, 5, 9, 20, 35, 48, 715, DateTimeKind.Local).AddTicks(2085),
                            RoleID = 1,
                            UserID = 1
                        });
                });

            modelBuilder.Entity("EventManagement.Domain.Entities.EventContextEntities.EventEntity", b =>
                {
                    b.HasOne("EventManagement.Domain.Entities.CategoryContextEntities.CategoryEntity", "Category")
                        .WithMany("Events")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EventManagement.Domain.Entities.UserContextEntities.UserEntity", "CreatedBy")
                        .WithMany("Events")
                        .HasForeignKey("CreatedByID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventManagement.Domain.Entities.LocationContextEntities.LocationEntity", "Location")
                        .WithMany("Events")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("CreatedBy");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("EventManagement.Domain.Entities.TicketContextEntities.TicketEntity", b =>
                {
                    b.HasOne("EventManagement.Domain.Entities.EventContextEntities.EventEntity", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EventManagement.Domain.Entities.UserContextEntities.UserEntity", "PurchasedBy")
                        .WithMany("Tickets")
                        .HasForeignKey("PurchasedByID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("PurchasedBy");
                });

            modelBuilder.Entity("EventManagement.Domain.Entities.UserContextEntities.UserRoleEntity", b =>
                {
                    b.HasOne("EventManagement.Domain.Entities.UserContextEntities.RoleEntity", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EventManagement.Domain.Entities.UserContextEntities.UserEntity", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventManagement.Domain.Entities.CategoryContextEntities.CategoryEntity", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("EventManagement.Domain.Entities.EventContextEntities.EventEntity", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("EventManagement.Domain.Entities.LocationContextEntities.LocationEntity", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("EventManagement.Domain.Entities.UserContextEntities.RoleEntity", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("EventManagement.Domain.Entities.UserContextEntities.UserEntity", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Tickets");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
