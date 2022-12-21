using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.Domain.PersonEshtegVazAgg;
using JobManagement.Domain.PersonOzvNoaAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobManagement.Infrastructure.EFCore.Mapping
{
    public class PersonOzvNoaMapping : IEntityTypeConfiguration<PersonOzvNoa>
    {
        public void Configure(EntityTypeBuilder<PersonOzvNoa> builder)
        {
            builder.ToTable("PersonOzvNoas");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PersonOzvNoaId).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();

            builder.HasMany(x => x.Persons).WithOne(x => x.PersonOzvNoa).HasForeignKey(x => x.PersonOzvNoaId);
        }
    }
}
