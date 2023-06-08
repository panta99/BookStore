using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entites
{
    public class Image : Entity
    {
        public string Path { get; set; }
        public int Size { get; set; }
        public Book Book { get; set; }
    }
}
