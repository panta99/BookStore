using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entites
{
    public class Cover : Entity
    {
        public string CoverType { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>(); 
    }
}
