using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class BoardDto
    {
        public int BoardId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CardListDto> ListDtos { get; set; }
        public virtual ICollection<CardDto> CardDtos { get; set; }
    }
}
