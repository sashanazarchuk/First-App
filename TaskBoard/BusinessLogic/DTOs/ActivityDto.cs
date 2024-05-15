﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public int CardId { get; set; }
        public DateTime Date { get; set; }
      
    }
}
