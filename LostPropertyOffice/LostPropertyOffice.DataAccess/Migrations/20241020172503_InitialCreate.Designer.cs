﻿// <auto-generated />
using System;
using LostPropertyOffice.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LostPropertyOffice.DataAccess.Migrations
{
    [DbContext(typeof(LostPropertyOfficeDbContext))]
    [Migration("20241020172503_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LostPropertyOffice.DataAccess.Entities.ItemTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("NextPointId")
                        .HasColumnType("integer");

                    b.Property<decimal>("StorageCost")
                        .HasColumnType("numeric");

                    b.Property<int>("StoragePeriod")
                        .HasColumnType("integer");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NextPointId");

                    b.ToTable("item_types");
                });

            modelBuilder.Entity("LostPropertyOffice.DataAccess.Entities.LostItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FoundLocation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FoundTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ItemTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReturnStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ItemTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("lost_items");
                });

            modelBuilder.Entity("LostPropertyOffice.DataAccess.Entities.NextPointEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("next_points");
                });

            modelBuilder.Entity("LostPropertyOffice.DataAccess.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UserEntity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("LostPropertyOffice.DataAccess.Entities.EmployeeEntity", b =>
                {
                    b.HasBaseType("LostPropertyOffice.DataAccess.Entities.UserEntity");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("users");

                    b.HasDiscriminator().HasValue("EmployeeEntity");
                });

            modelBuilder.Entity("LostPropertyOffice.DataAccess.Entities.VisitorEntity", b =>
                {
                    b.HasBaseType("LostPropertyOffice.DataAccess.Entities.UserEntity");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("users");

                    b.HasDiscriminator().HasValue("VisitorEntity");
                });

            modelBuilder.Entity("LostPropertyOffice.DataAccess.Entities.ItemTypeEntity", b =>
                {
                    b.HasOne("LostPropertyOffice.DataAccess.Entities.NextPointEntity", "NextPoint")
                        .WithMany()
                        .HasForeignKey("NextPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NextPoint");
                });

            modelBuilder.Entity("LostPropertyOffice.DataAccess.Entities.LostItemEntity", b =>
                {
                    b.HasOne("LostPropertyOffice.DataAccess.Entities.ItemTypeEntity", "ItemType")
                        .WithMany("LostItems")
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LostPropertyOffice.DataAccess.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LostPropertyOffice.DataAccess.Entities.ItemTypeEntity", b =>
                {
                    b.Navigation("LostItems");
                });
#pragma warning restore 612, 618
        }
    }
}
