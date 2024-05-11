﻿// <auto-generated />
using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240511151700_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .HasColumnType("text");

                    b.Property<int>("CardId")
                        .HasColumnType("integer");

                    b.Property<string>("Date")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Entities.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Date")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("ListId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Priority")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = "Fri, 10 May",
                            Description = "Prepare a short project presentation for a meeting with the client.",
                            ListId = 1,
                            Name = "Prepare presentation",
                            Priority = "High"
                        },
                        new
                        {
                            Id = 2,
                            Date = "Fri, 10 May",
                            Description = "Organize a meeting with the supplier to discuss terms of delivery.",
                            ListId = 1,
                            Name = "Negotiate with supplier",
                            Priority = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            Date = "Fri, 10 May",
                            Description = "Prepare a detailed report on the work done for the past month for management.",
                            ListId = 2,
                            Name = "Prepare monthly report",
                            Priority = "Low"
                        },
                        new
                        {
                            Id = 4,
                            Date = "Fri, 10 May",
                            Description = "Plan and organize a corporate event for company employees.",
                            ListId = 2,
                            Name = "Organize corporate event",
                            Priority = "High"
                        },
                        new
                        {
                            Id = 5,
                            Date = "Fri, 10 May",
                            Description = "Develop a proposal for collaboration to present to a potential client.",
                            ListId = 1,
                            Name = "Prepare proposal for potential client",
                            Priority = "Medium"
                        });
                });

            modelBuilder.Entity("Entities.Models.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .HasColumnType("text");

                    b.Property<string>("Date")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("Entities.Models.List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Lists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Planned"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Completed"
                        });
                });

            modelBuilder.Entity("Entities.Models.Card", b =>
                {
                    b.HasOne("Entities.Models.List", "List")
                        .WithMany("Cards")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("List");
                });

            modelBuilder.Entity("Entities.Models.List", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
