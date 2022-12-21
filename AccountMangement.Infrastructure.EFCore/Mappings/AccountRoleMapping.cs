using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Domain.AccountRoleAgg;
using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountMangement.Infrastructure.EFCore.Mappings
{
    public class AccountRoleMapping : IEntityTypeConfiguration<AccountRole>
    {
        public void Configure(EntityTypeBuilder<AccountRole> builder)
        {
            builder.ToTable("AccountRoles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AccountId).IsRequired();
            builder.Property(x => x.RoleId).IsRequired();

            builder.HasOne(x => x.Account).WithMany(x => x.AccountRoles).HasForeignKey(x => x.AccountId);
            builder.HasOne(x => x.Role).WithMany(x => x.AccountRoles).HasForeignKey(x => x.RoleId);
        }
    }
}
