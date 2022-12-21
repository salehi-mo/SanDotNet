using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.Domain.QorbAgg;
using JobManagement.Domain.QorbMoasAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobManagement.Infrastructure.EFCore.Mapping
{
    public class QorbMoasMapping : IEntityTypeConfiguration<QorbMoas>
    {
        public void Configure(EntityTypeBuilder<QorbMoas> builder)
        {
            builder.ToTable("QorbMoass");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.QorbMoasId_sana).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();

            builder.HasMany(x => x.QorbMoasPors).WithOne(x => x.QorbMoas).HasForeignKey(x => x.QorbMoasId);
            builder.HasMany(x => x.Persons).WithOne(x => x.QorbMoas).HasForeignKey(x => x.QorbMoasId);

        }
    }
}
