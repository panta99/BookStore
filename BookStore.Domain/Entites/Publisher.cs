﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entites
{
    public class Publisher : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
