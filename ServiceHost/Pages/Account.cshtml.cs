using System;
using _0_Framework.Application;
using _0_Framework.Application.Sms;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        [TempData]
        public string LoginMessage { get; set; }

        [TempData]
        public string RegisterMessage { get; set; }

        
        private readonly IAccountApplication _accountApplication;

        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {

            TempData["msg"] = LoginMessage;
        }

        public IActionResult OnPostLogin(Login command)
        {
            if ((!string.IsNullOrWhiteSpace(command.Username)) && (!string.IsNullOrWhiteSpace(command.Password)))
            {
                var result = _accountApplication.Login(command);
                if (result.IsSuccedded)
                {
                   return RedirectToPage("/AccountVerify");
                }
                LoginMessage = result.Message;
                return RedirectToPage("/Account");
            }
            else
            {
                return RedirectToPage("/Account");
            }
        }

        public IActionResult OnGetLogout()
        {
            _accountApplication.Logout();
            TempData["SmsCode"] = "";
            return RedirectToPage("/Account");
        }

        public IActionResult OnPostRegister(RegisterAccount command)
        {
            var result = _accountApplication.Register(command);
            if (result.IsSuccedded)
                return RedirectToPage("/Account");
            RegisterMessage = result.Message;
            return RedirectToPage("/Account");
        }
        //public IActionResult OnPostVerifycode(Login command)
        //{
        //    if ((!string.IsNullOrWhiteSpace(command.Verifycode)))
        //    {
        //        if (TempData["SmsCode"] == command.Verifycode)
        //            return RedirectToPage("/Index");
        //    }

        //    return RedirectToPage("/Index");
        //}
    }
}
