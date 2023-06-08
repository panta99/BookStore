using BookStore.Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Configuration
{
    public class AuthorConfiguration : EntityConfiguration<Author>
    {
        protected override void ConfigureEntityRules(EntityTypeBuilder<Author> builder)
        {
            //Indexes
            builder.HasIndex(x => x.FirstName);
            builder.HasIndex(x => x.LastName);

            //Properties
            builder.Property(x => x.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(x => x.LastName)
                   .IsRequired()
                   .HasMaxLength(100);
            //Relations
            builder.HasMany(x => x.BookAuthors)
                   .WithOne(y => y.Author)
                   .HasForeignKey(x => x.AuthorId)
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
