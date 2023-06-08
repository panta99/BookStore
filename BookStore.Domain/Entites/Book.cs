using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entites
{
    public class Book : Entity
    {
        public string Name { get; set; }
        public int NumberOfPages { get; set; }
        public string Description { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }
        public int PublisherId { get; set; }
        public int PublishYearId { get; set; }
        public int CoverId { get; set; }
        public int ImageId { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new HashSet<BookAuthor>();
        public virtual ICollection<BookGenre> BookGenres { get; set; } = new HashSet<BookGenre>();
        public virtual ICollection<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();
        public virtual ICollection<CartBook> CartBooks { get; set; } = new List<CartBook>();
        public virtual Publisher Publisher { get; set; }
        public virtual YearPublished YearPublished { get; set; }
        public virtual Cover Cover { get; set; }
        public virtual Image Image { get; set; }
    }
}
