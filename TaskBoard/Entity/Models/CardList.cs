﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CardList
    {
        [Key]
        public int CardListId { get; set; }
        public string Name { get; set; }


        [ForeignKey("BoardId")]
        public int BoardId { get; set; }
        public virtual Board Board { get; set; }

        public virtual List<Card> Cards { get; set; }
    }
}
