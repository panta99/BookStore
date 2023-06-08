using BookStore.Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Configuration
{
    public class OrderBookConfiguration : EntityConfiguration<OrderBook>
    {
        protected override void ConfigureEntityRules(EntityTypeBuilder<OrderBook> builder)
        {
            //Properties
            builder.Property(x => x.BookName)
                   .IsRequired()
                   .HasMaxLength(150);
            builder.Property(x => x.Quantity)
                   .IsRequired();
            builder.Property(x => x.Price)
                   .IsRequired();
        }
    }
}
