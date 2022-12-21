using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.Domain.PersonAgg;
using JobManagement.Domain.PersonEshtegVazAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobManagement.Infrastructure.EFCore.Mapping
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PerId).IsRequired();
            builder.Property(x => x.Nam).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Fam).HasMaxLength(500).IsRequired();
            builder.Property(x => x.NamPed).HasMaxLength(500).IsRequired();
            builder.Property(x => x.NoShe).HasMaxLength(500).IsRequired();
            builder.Property(x => x.CodMelli).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();


            builder.HasOne(x => x.PersonEshtegVaz)
                .WithMany(x => x.Persons)
                .HasForeignKey(x => x.PersonEshtegVazId);

            builder.HasOne(x => x.PersonOzvNoa)
                .WithMany(x => x.Persons)
                .HasForeignKey(x => x.PersonOzvNoaId);

            builder.HasOne(x => x.Qorb)
                .WithMany(x => x.Persons)
                .HasForeignKey(x => x.QorbId);

            builder.HasOne(x => x.QorbMoas)
                .WithMany(x => x.Persons)
                .HasForeignKey(x => x.QorbMoasId);

            builder.HasOne(x => x.QorbMoasPor)
                .WithMany(x => x.Persons)
                .HasForeignKey(x => x.QorbMoasPorId);

            builder.HasOne(x => x.QorbMoasPorKar)
                .WithMany(x => x.Persons)
                .HasForeignKey(x => x.QorbMoasPorKarId);


        }
    }
}
