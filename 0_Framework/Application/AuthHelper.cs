using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using _0_Framework.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace _0_Framework.Application
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public AuthViewModel CurrentAccountInfo()
        {
            var result = new AuthViewModel();
            if (!IsAuthenticated())
                return result;

            var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            result.Id = long.Parse(claims.FirstOrDefault(x => x.Type == "AccountId").Value);
            result.Username = claims.FirstOrDefault(x => x.Type == "Username").Value;
            result.RoleIds = JsonConvert.DeserializeObject<List<long>>(claims.FirstOrDefault(x => x.Type == "roleIds").Value);
            result.Fullname = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            result.Roles = JsonConvert.DeserializeObject < List<string>> (claims.FirstOrDefault(x => x.Type == "accountRoles").Value);
            result.ProfilePhoto = claims.FirstOrDefault(x => x.Type == "ProfilePhoto").Value;
            return result;
        }

        public List<int> GetPermissions()
        {
            if (!IsAuthenticated())
                return new List<int>();

            var permissions = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "permissions")
                ?.Value;
            return JsonConvert.DeserializeObject<List<int>>(permissions);
        }

        public long CurrentAccountId()
        {
            return IsAuthenticated()
                ? long.Parse(_contextAccessor.HttpContext.User.Claims.First(x => x.Type == "AccountId")?.Value)
                : 0;
        }

        public string CurrentAccountMobile()
        {
            return IsAuthenticated()
                ? _contextAccessor.HttpContext.User.Claims.First(x => x.Type == "Mobile")?.Value
                : "";
        }

        public List<long> CurrentAccountRole()
        {
            if (!IsAuthenticated())
                return new List<long>();

            var roleIds = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "roleIds")?.Value;
            return JsonConvert.DeserializeObject<List<long>>(roleIds);


           

            
           
        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
            //var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            ////if (claims.Count > 0)
            ////    return true;
            ////return false;
            //return claims.Count > 0;
        }

        public void Signin(AuthViewModel account)
        {

            
            var permissions = JsonConvert.SerializeObject(account.Permissions);
            var accountRoles = JsonConvert.SerializeObject(account.Roles);
            var roleIds = JsonConvert.SerializeObject(account.RoleIds);
            var claims = new List<Claim>
            {
                new Claim("AccountId", account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.Fullname),
                new Claim(ClaimTypes.Role, account.RoleIds.First().ToString()),
                new Claim("accountRoles", accountRoles),
                new Claim("roleIds", roleIds),
                new Claim("Username", account.Username), // Or Use ClaimTypes.NameIdentifier
                new Claim("permissions", permissions),
                new Claim("Mobile", account.Mobile),
                new Claim("ProfilePhoto", account.ProfilePhoto)
                
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                AllowRefresh = true
                //ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(10)
            };
            _contextAccessor.HttpContext.SignInAsync( CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

           
        }

        public void SignOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public string CurrentAccountUserName()
        {
            return IsAuthenticated()
                ? _contextAccessor.HttpContext.User.Claims.First(x => x.Type == "Username")?.Value
                : "";
        } }
}