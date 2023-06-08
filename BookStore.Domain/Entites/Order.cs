using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entites
{
    public class Order : Entity
    {
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public StatusOfOrder OrderStatus { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();
    }
    public enum StatusOfOrder
    {
        Recived,
        Shipped,
        Canceled,
        Delivered
    }
}
