using BookStore.Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Configuration
{
    public class PublisherConfiguration : EntityConfiguration<Publisher>
    {
        protected override void ConfigureEntityRules(EntityTypeBuilder<Publisher> builder)
        {
            //Indexes
            builder.HasIndex(x => x.Name)
                   .IsUnique();
            //Properties
            builder.Property(x => x.Name)
                   .IsRequired();
        }
    }
}
