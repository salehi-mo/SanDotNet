using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Domain.AccountRoleAgg
{
    public class AccountRole : EntityBase
    {
        public long AccountId { get;  set; }
        public Account Account { get; private set; }
        public long RoleId { get;  set; }
        public Role Role { get; private set; }

        public AccountRole()
        {
        }
        public AccountRole(long accountId,long roleId)
        {
            AccountId = accountId;
            RoleId = roleId;
        }
    }

}
