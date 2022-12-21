using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace AccountManagement.Configuration.Permissions
{
    public class AccountPermissionExposer : IPermissionExposer
    {
        public Dictionary<List<string>, List<PermissionDto>> Expose()
        {
            return new Dictionary<List<string>, List<PermissionDto>>
            {
                {
                    new List<string>()
                   {
                       "Roles",
                       "نقش ها"
                   },
                   new List<PermissionDto>
                    {
                        new PermissionDto(AccountPermissions.ListRoles ,  "ListRoles","لیست نقش ها"),
                        new PermissionDto(AccountPermissions.SearchRoles, "SearchRoles","جستجوی نقش ها"),
                        new PermissionDto(AccountPermissions.CreateRole, "CreateRole","نقش جدید"),
                        new PermissionDto(AccountPermissions.EditRole, "EditRole","ویرایش نقش"),
                    }
                },
                {
                    new List<string>()
                    {
                        "Accounts",
                        "کاربران"
                    },
                    new List<PermissionDto>
                    {
                        new PermissionDto(AccountPermissions.ListAccounts, "ListAccounts","لیست کاربران"),
                        new PermissionDto(AccountPermissions.SearchAccounts, "SearchAccounts","جستجوی کاربران"),
                        new PermissionDto(AccountPermissions.CreateAccount, "CreateAccount","ایجاد کاربر جدید"),
                        new PermissionDto(AccountPermissions.EditAccount, "EditAccount","ویرایش کاربر"),
                        new PermissionDto(AccountPermissions.EditAccountRoles, "EditAccountRoles","ویرایش نقش کاربر"),

                    }
                }
            };
        }
    }
}