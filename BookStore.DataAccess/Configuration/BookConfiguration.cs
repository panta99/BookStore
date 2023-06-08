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
    public class BookConfiguration : EntityConfiguration<Book>
    {
        protected override void ConfigureEntityRules(EntityTypeBuilder<Book> builder)
        {
            //Indexes
            builder.HasIndex(x => x.Name);
            //Properties
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(150);
            builder.Property(x => x.NumberOfPages)
                   .IsRequired()
                   .HasPrecision(5);
            builder.Property(x => x.Description)
                   .IsRequired();
            builder.Property(x => x.QuantityInStock)
                   .IsRequired()
                   .HasDefaultValue(0);
            builder.Property(x => x.Price)
                   .IsRequired()
                   .HasPrecision(8, 2);
            //Relations
            builder.HasMany(x => x.BookAuthors)
                   .WithOne(x => x.Book)
                   .HasForeignKey(x => x.BookId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.BookGenres)
                   .WithOne(x => x.Book)
                   .HasForeignKey(x => x.BookId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.OrderBooks)
                   .WithOne(x => x.Book)
                   .HasForeignKey(x => x.BookId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.CartBooks)
                   .WithOne(x => x.Book)
                   .HasForeignKey(x => x.BookId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Publisher)
                   .WithMany(x => x.Books)
                   .HasForeignKey(x => x.PublisherId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.YearPublished)
                   .WithMany(x => x.Books)
                   .HasForeignKey(x => x.PublishYearId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Cover)
                   .WithMany(x => x.Books)
                   .HasForeignKey(x => x.CoverId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Image)
                   .WithOne(x => x.Book)
                   .HasForeignKey<Book>(x => x.ImageId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
