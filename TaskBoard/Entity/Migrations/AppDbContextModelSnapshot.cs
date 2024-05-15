﻿// <auto-generated />
using System;
using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ActivityId"));

                    b.Property<string>("Action")
                        .HasColumnType("text");

                    b.Property<int>("CardId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ActivityId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Entities.Models.Board", b =>
                {
                    b.Property<int>("BoardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BoardId"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("BoardId");

                    b.ToTable("Boards");

                    b.HasData(
                        new
                        {
                            BoardId = 1,
                            Name = "Home Board"
                        },
                        new
                        {
                            BoardId = 2,
                            Name = "Work Board"
                        });
                });

            modelBuilder.Entity("Entities.Models.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CardId"));

                    b.Property<int>("BoardId")
                        .HasColumnType("integer");

                    b.Property<int>("CardListId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.HasKey("CardId");

                    b.HasIndex("BoardId");

                    b.HasIndex("CardListId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            CardId = 1,
                            BoardId = 1,
                            CardListId = 1,
                            Date = new DateTime(2024, 5, 9, 21, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Prepare a short project presentation for a meeting with the client.",
                            Name = "Prepare presentation",
                            Priority = 1
                        },
                        new
                        {
                            CardId = 2,
                            BoardId = 1,
                            CardListId = 1,
                            Date = new DateTime(2024, 5, 9, 21, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Organize a meeting with the supplier to discuss terms of delivery.",
                            Name = "Negotiate with supplier",
                            Priority = 2
                        },
                        new
                        {
                            CardId = 3,
                            BoardId = 1,
                            CardListId = 2,
                            Date = new DateTime(2024, 5, 9, 21, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Prepare a detailed report on the work done for the past month for management.",
                            Name = "Prepare monthly report",
                            Priority = 3
                        },
                        new
                        {
                            CardId = 4,
                            BoardId = 1,
                            CardListId = 2,
                            Date = new DateTime(2024, 5, 9, 21, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Plan and organize a corporate event for company employees.",
                            Name = "Organize corporate event",
                            Priority = 1
                        },
                        new
                        {
                            CardId = 5,
                            BoardId = 1,
                            CardListId = 1,
                            Date = new DateTime(2024, 5, 9, 21, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Develop a proposal for collaboration to present to a potential client.",
                            Name = "Prepare proposal for potential client",
                            Priority = 2
                        });
                });

            modelBuilder.Entity("Entities.Models.CardList", b =>
                {
                    b.Property<int>("CardListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CardListId"));

                    b.Property<int>("BoardId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("CardListId");

                    b.HasIndex("BoardId");

                    b.ToTable("Lists");

                    b.HasData(
                        new
                        {
                            CardListId = 1,
                            BoardId = 1,
                            Name = "Home Planned"
                        },
                        new
                        {
                            CardListId = 2,
                            BoardId = 1,
                            Name = "Home Completed"
                        },
                        new
                        {
                            CardListId = 3,
                            BoardId = 2,
                            Name = "Work Planned"
                        },
                        new
                        {
                            CardListId = 4,
                            BoardId = 2,
                            Name = "Work Completed"
                        });
                });

            modelBuilder.Entity("Entities.Models.History", b =>
                {
                    b.Property<int>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("HistoryId"));

                    b.Property<string>("Action")
                        .HasColumnType("text");

                    b.Property<int>("BoardId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("HistoryId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("Entities.Models.Card", b =>
                {
                    b.HasOne("Entities.Models.Board", "Board")
                        .WithMany("Cards")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.CardList", "CardList")
                        .WithMany("Cards")
                        .HasForeignKey("CardListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");

                    b.Navigation("CardList");
                });

            modelBuilder.Entity("Entities.Models.CardList", b =>
                {
                    b.HasOne("Entities.Models.Board", "Board")
                        .WithMany("Lists")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("Entities.Models.Board", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("Lists");
                });

            modelBuilder.Entity("Entities.Models.CardList", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
