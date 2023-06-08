using BookStore.Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Configuration
{
    public class CartConfiguration : EntityConfiguration<Cart>
    {
        protected override void ConfigureEntityRules(EntityTypeBuilder<Cart> builder)
        {
            //Relations
            builder.HasMany(x => x.CartBooks)
                   .WithOne(x => x.Cart)
                   .HasForeignKey(x => x.CartId)
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
