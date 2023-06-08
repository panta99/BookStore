using BookStore.Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Configuration
{
    public class CoverConfiguration : EntityConfiguration<Cover>
    {
        protected override void ConfigureEntityRules(EntityTypeBuilder<Cover> builder)
        {
            //Properties
            builder.Property(x => x.CoverType)
                   .IsRequired()
                   .HasMaxLength(150);
        }
    }
}
