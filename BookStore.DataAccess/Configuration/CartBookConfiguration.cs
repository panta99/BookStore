using BookStore.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Configuration
{
    public class CartBookConfiguration : IEntityTypeConfiguration<CartBook>
    {
        public void Configure(EntityTypeBuilder<CartBook> builder)
        {
            //Indexes  
            builder.HasKey(x => new { x.BookId, x.CartId });
            //Properties
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price).IsRequired();
        }
    }
}
