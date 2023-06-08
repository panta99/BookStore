using BookStore.Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Configuration
{
    public class ImageConfiguration : EntityConfiguration<Image>
    {
        protected override void ConfigureEntityRules(EntityTypeBuilder<Image> builder)
        {
            //Properties
            builder.Property(x => x.Path)
                   .IsRequired()
                   .HasMaxLength(255);
        }
    }
}
