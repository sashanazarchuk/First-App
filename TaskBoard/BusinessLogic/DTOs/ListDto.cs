﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class ListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CardDto> Cards { get; set; }
        public int CardCount => Cards?.Count ?? 0;

    }
}