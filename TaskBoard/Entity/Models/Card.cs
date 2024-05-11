using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }  
        public string Priority { get; set; }

        [ForeignKey("ListId")]
        public int ListId { get; set; }
        public virtual List List { get; set; }
       
    }
}
