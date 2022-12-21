using System.Collections.Generic;
using _0_Framework.Domain;
using AccountManagement.Domain.AccountRoleAgg;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account : EntityBase
    {
        public string Fullname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
       
        //public List<Role> Roles { get; private set; }
        public string ProfilePhoto { get; private set; }

        public List<AccountRole> AccountRoles { get; set; }

        public Account(string fullname, string username, string password, string mobile,
             string profilePhoto)
        {
            Fullname = fullname;
            Username = username;
            Password = password;
            Mobile = mobile;
            //Roles = new List<Role>();
            AccountRoles = new List<AccountRole>();
            ProfilePhoto = profilePhoto;
        }

        public void Edit(string fullname, string username, string mobile,
             string profilePhoto, List<AccountRole> accountRoles)
        {
            if (!string.IsNullOrWhiteSpace(fullname))
                Fullname = fullname;
            
            if (!string.IsNullOrWhiteSpace(username))
                Username = username;

            if (!string.IsNullOrWhiteSpace(mobile)) 
                Mobile = mobile;

            
            AccountRoles = accountRoles;

            if (!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;
        }

        public void Edit(string fullname, string username, string mobile,
            string profilePhoto)
        {
            if (!string.IsNullOrWhiteSpace(fullname))
                Fullname = fullname;

            if (!string.IsNullOrWhiteSpace(username))
                Username = username;

            if (!string.IsNullOrWhiteSpace(mobile))
                Mobile = mobile;

            if (!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}
