using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Board
    {
        [Key]
        public int BoardId { get; set; }
        public string Name { get; set; }
        public virtual List<Card> Cards { get; set; }
        public virtual List<CardList> Lists { get; set; }
    }
}
