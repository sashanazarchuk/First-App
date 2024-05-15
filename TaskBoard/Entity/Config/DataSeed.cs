using Entities.Enum;
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
    public class DataSeed : IEntityTypeConfiguration<Card>, IEntityTypeConfiguration<CardList>, IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasData(
                new Card
                {
                    CardId = 1,
                    Name = "Prepare presentation",
                    Description = "Prepare a short project presentation for a meeting with the client.",
                    Date = new DateTime(2024, 5, 10).ToUniversalTime(),
                    Priority = CardPriority.Low,
                    BoardId = 1,
                    CardListId = 1
                },
                new Card
                {
                    CardId = 2,
                    Name = "Negotiate with supplier",
                    Description = "Organize a meeting with the supplier to discuss terms of delivery.",
                    Date = new DateTime(2024, 5, 10).ToUniversalTime(),
                    Priority = CardPriority.Medium,
                    BoardId = 1,
                    CardListId = 1
                },
                new Card
                {
                    CardId = 3,
                    Name = "Prepare monthly report",
                    Description = "Prepare a detailed report on the work done for the past month for management.",
                    Date = new DateTime(2024, 5, 10).ToUniversalTime(),
                    Priority = CardPriority.High,
                    BoardId = 1,
                    CardListId = 2
                },
                new Card
                {
                    CardId = 4,
                    Name = "Organize corporate event",
                    Description = "Plan and organize a corporate event for company employees.",
                    Date = new DateTime(2024, 5, 10).ToUniversalTime(),
                    Priority = CardPriority.Low,
                    BoardId = 1,
                    CardListId = 2
                },
                new Card
                {
                    CardId = 5,
                    Name = "Prepare proposal for potential client",
                    Description = "Develop a proposal for collaboration to present to a potential client.",
                    Date = new DateTime(2024, 5, 10).ToUniversalTime(),
                    Priority = CardPriority.Medium,
                    BoardId = 1,
                    CardListId = 1
                });
        }

        public void Configure(EntityTypeBuilder<CardList> builder)
        {
            builder.HasData(
                 new CardList { CardListId = 1, Name = "Home Planned", BoardId = 1 },
                 new CardList { CardListId = 2, Name = "Home Completed", BoardId = 1 },

                 new CardList { CardListId = 3, Name = "Work Planned", BoardId = 2 },
                 new CardList { CardListId = 4, Name = "Work Completed", BoardId = 2 }
                );
        }

        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasData(
                new Board { BoardId = 1, Name = "Home Board" },
                new Board { BoardId = 2, Name = "Work Board" }
                );
        }
    }
}