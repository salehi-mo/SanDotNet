using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.Domain.PersonEshtegVazAgg;
using JobManagement.Domain.QorbAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobManagement.Infrastructure.EFCore.Mapping
{
    public class QorbMapping : IEntityTypeConfiguration<Qorb>
    {
        public void Configure(EntityTypeBuilder<Qorb> builder)
        {
            builder.ToTable("Qorbs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.QorbId_sana).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();

            builder.HasMany(x => x.QorbMoass).WithOne(x => x.Qorb).HasForeignKey(x => x.QorbId);
            builder.HasMany(x => x.Persons).WithOne(x => x.Qorb).HasForeignKey(x => x.QorbId);

        }
    }
}
