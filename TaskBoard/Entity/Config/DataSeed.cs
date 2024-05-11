using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Config
{
    public class DataSeed : IEntityTypeConfiguration<Card>, IEntityTypeConfiguration<List>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasData(
                new Card
                {
                    Id = 1,
                    Name = "Prepare presentation",
                    Description = "Prepare a short project presentation for a meeting with the client.",
                    Date = new DateTime(2024, 5, 10).ToString("ddd, d MMMM"),
                    Priority = "High",
                    ListId = 1
                },
                new Card
                {
                    Id = 2,
                    Name = "Negotiate with supplier",
                    Description = "Organize a meeting with the supplier to discuss terms of delivery.",
                    Date = new DateTime(2024, 5, 10).ToString("ddd, d MMMM"),
                    Priority = "Medium",
                    ListId = 1
                },
                new Card
                {
                    Id = 3,
                    Name = "Prepare monthly report",
                    Description = "Prepare a detailed report on the work done for the past month for management.",
                    Date = new DateTime(2024, 5, 10).ToString("ddd, d MMMM"),
                    Priority = "Low",
                    ListId = 2
                },
                new Card
                {
                    Id = 4,
                    Name = "Organize corporate event",
                    Description = "Plan and organize a corporate event for company employees.",
                    Date = new DateTime(2024, 5, 10).ToString("ddd, d MMMM"),
                    Priority = "High",
                    ListId = 2
                },
                new Card
                {
                    Id = 5,
                    Name = "Prepare proposal for potential client",
                    Description = "Develop a proposal for collaboration to present to a potential client.",
                    Date = new DateTime(2024, 5, 10).ToString("ddd, d MMMM"),
                    Priority = "Medium",
                    ListId = 1
                });
        }

        public void Configure(EntityTypeBuilder<List> builder)
        {
            builder.HasData(
                new List { Id = 1, Name = "Planned" },
                new List { Id = 2, Name = "Completed" }
                );
        }
    }
}