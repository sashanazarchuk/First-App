using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class History
    {
        [Key]
        public int HistoryId { get; set; }
        public string Action { get; set; }
        public int BoardId { get; set; }
        public DateTime Date { get; set; }
    }
}
