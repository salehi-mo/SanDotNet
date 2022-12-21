using System.ComponentModel;

namespace AccountManagement.Configuration.Permissions
{
    public static class AccountPermissions
    {
        //Roles
        public const int ListRoles = 11000;
        public const int SearchRoles = 11001;
        public const int CreateRole = 11002;
        public const int EditRole = 11003;


        //Accounts
        public const int ListAccounts = 11100;
        public const int SearchAccounts = 11101;
        public const int CreateAccount = 11102;
        public const int EditAccount = 11103;
        public const int ChangePassword = 11104;
        public const int EditAccountRoles = 11105;



    }
}