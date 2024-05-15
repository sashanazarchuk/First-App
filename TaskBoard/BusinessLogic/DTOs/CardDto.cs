using Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class CardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public CardPriority Priority { get; set; }
       
        public int BoardId { get; set; }
        public string Board { get; set; }


        public int CardListId { get; set; }
        public string CardList { get; set; }

    }
}
