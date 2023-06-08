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
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Entity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.ModifiedAt).HasDefaultValue(null);
            builder.Property(x => x.DeletedAt).HasDefaultValue(null);

            ConfigureEntityRules(builder);
        }
        protected abstract void ConfigureEntityRules(EntityTypeBuilder<T> builder);
    }
}
