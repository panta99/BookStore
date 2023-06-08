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
    public class RoleUseCaseConfiguration : IEntityTypeConfiguration<RoleUseCase>
    {
        public void Configure(EntityTypeBuilder<RoleUseCase> builder)
        {
            builder.HasKey(x => new { x.RoleId, x.UseCaseId });
        }
    }
}
