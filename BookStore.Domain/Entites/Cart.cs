using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entites
{
    public class Cart : Entity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CartBook> CartBooks { get; set; } = new List<CartBook>();
    }
}
