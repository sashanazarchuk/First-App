using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        public string Action { get; set; }
        public int CardId { get; set; }
        public DateTime Date { get; set; } 
    }
}
