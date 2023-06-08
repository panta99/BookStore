﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entites
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; } 
        public DateTime? ModifiedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
