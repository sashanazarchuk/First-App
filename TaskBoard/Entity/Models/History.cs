﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class History
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public DateTime Date { get; set; }
    }
}
