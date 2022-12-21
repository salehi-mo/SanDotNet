using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.Domain.QorbMoasPorAgg;
using JobManagement.Domain.QorbMoasPorKarAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobManagement.Infrastructure.EFCore.Mapping
{
    public class QorbMoasPorKarMapping : IEntityTypeConfiguration<QorbMoasPorKar>
    {
        public void Configure(EntityTypeBuilder<QorbMoasPorKar> builder)
        {
            builder.ToTable("QorbMoasPorKars");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.QorbMoasPorKarId_sana).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();


            builder.HasMany(x => x.Persons).WithOne(x => x.QorbMoasPorKar).HasForeignKey(x => x.QorbMoasPorKarId);

        }
    }
}
