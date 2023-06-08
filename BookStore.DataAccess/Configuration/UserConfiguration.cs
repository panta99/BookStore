using BookStore.Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Configuration
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureEntityRules(EntityTypeBuilder<User> builder)
        {
            //Indexed
            builder.HasIndex(x => x.Email).IsUnique();
            //Properties
            builder.Property(x => x.FirstName)
                   .IsRequired()
                   .HasMaxLength(150);
            builder.Property(x => x.LastName)
                   .IsRequired()
                   .HasMaxLength(150);
            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(150);
            builder.Property(x => x.Password)
                   .IsRequired()
                   .HasMaxLength(150);
            //Relations
            builder.HasMany(x => x.Carts)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
