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
    public class OrderConfiguration : EntityConfiguration<Order>
    {
        protected override void ConfigureEntityRules(EntityTypeBuilder<Order> builder)
        {
            //Properties
            builder.Property(x => x.OrderStatus)
                   .HasDefaultValue(StatusOfOrder.Recived);
            builder.Property(x => x.OrderDate)
                   .IsRequired();
            builder.Property(x => x.Address)
                   .IsRequired()
                   .HasMaxLength(150);
            //Relations
            builder.HasOne(x => x.User)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.OrderBooks)
                   .WithOne(x => x.Order)
                   .HasForeignKey(x => x.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
