using BookStore.Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Configuration
{
    public class GenreConfiguration : EntityConfiguration<Genre>
    {
        protected override void ConfigureEntityRules(EntityTypeBuilder<Genre> builder)
        {
            //Indexes
            builder.HasIndex(x => x.Name)
                   .IsUnique();
            //Properties
            builder.Property(x => x.Name)
                   .HasMaxLength(255);
            //Relations
            builder.HasMany(x => x.BookGenres)
                   .WithOne(x => x.Genre)
                   .HasForeignKey(x => x.GenreId)
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
