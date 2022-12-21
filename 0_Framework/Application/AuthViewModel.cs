using System.Collections.Generic;

namespace _0_Framework.Application
{
    public class AuthViewModel
    {
        public long Id { get; set; }
        //public long RoleId { get; set; }
        //public string Role { get; set; }
        public List<string> Roles { get; set; }
        public List<long> RoleIds { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }

        public string ProfilePhoto { get; set; }
        public List<int> Permissions { get; set; }

        public AuthViewModel()
        {
        }

        public AuthViewModel(long id, List<string> roles, List<long> roleIds, string fullname, string username, string mobile,string profilePhoto,
            List<int> permissions)
        {
            Id = id;
            Roles = roles;
            RoleIds = roleIds;
            Fullname = fullname;
            Username = username;
            Mobile = mobile;
            Permissions = permissions;
            ProfilePhoto = profilePhoto;
        }
    }
}