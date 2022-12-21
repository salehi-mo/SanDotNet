using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.Domain.QorbMoasAgg;
using JobManagement.Domain.QorbMoasPorAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobManagement.Infrastructure.EFCore.Mapping
{
    public class QorbMoasPorMapping : IEntityTypeConfiguration<QorbMoasPor>
    {
        public void Configure(EntityTypeBuilder<QorbMoasPor> builder)
        {
            builder.ToTable("QorbMoasPors");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.QorbMoasPorId_sana).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();

            builder.HasMany(x => x.QorbMoasPorKars).WithOne(x => x.QorbMoasPor).HasForeignKey(x => x.QorbMoasPorId);
            builder.HasMany(x => x.Persons).WithOne(x => x.QorbMoasPor).HasForeignKey(x => x.QorbMoasPorId);

        }
    }
}
