﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entites
{
    public class CartBook
    {
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Book Book { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
