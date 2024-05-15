using Entities.Config;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Card>(new DataSeed());
            modelBuilder.ApplyConfiguration<CardList>(new DataSeed());
            modelBuilder.ApplyConfiguration<Board>(new DataSeed());

            modelBuilder.Entity<Card>()
               .HasOne(c => c.Board)
               .WithMany(c => c.Cards)
               .HasForeignKey(c => c.BoardId);

            modelBuilder.Entity<Card>()
                .HasOne(c => c.CardList)
                .WithMany(c => c.Cards)
                .HasForeignKey(c => c.CardListId);

            modelBuilder.Entity<CardList>()
                .HasOne(c => c.Board)
                .WithMany(c => c.Lists)
                .HasForeignKey(c => c.BoardId);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<CardList> Lists { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Board> Boards { get; set; }
    }
}
