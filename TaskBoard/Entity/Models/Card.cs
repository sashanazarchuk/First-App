using Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }  
        public CardPriority Priority { get; set; }


        [ForeignKey("BoardId")]
        public int BoardId { get; set; }
        public virtual Board Board { get; set; }


        [ForeignKey("CardListId")]
        public int CardListId { get; set; }
        public virtual CardList CardList { get; set; }
       
    }
}
