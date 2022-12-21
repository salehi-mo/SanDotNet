using System;
using _0_Framework.Application;
using _0_Framework.Application.Sms;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Org.BouncyCastle.Crypto.Engines;

namespace ServiceHost.Pages
{
    public class AccountVerifyModel : PageModel
    {
        [TempData]
        public string VerifyMessage { get; set; }



        private readonly IAuthHelper _authHelper;
        private readonly ISmsService _smsService;
        private readonly IAccountApplication _accountApplication;

        public AccountVerifyModel(IAccountApplication accountApplication, ISmsService smsService, IAuthHelper authHelper)
        {
            _accountApplication = accountApplication;
            _smsService = smsService;
            _authHelper = authHelper;
        }

        public void OnGet()
        {
            if (!TempData.ContainsKey("SmsCode"))
            {
                TempData["SmsCode"] = "";
            }

            if (!TempData.ContainsKey("FirstTime"))
            {
                TempData["FirstTime"] = "";
            }
        }

        public IActionResult OnPostVerify(Login command)
        {
       
            int LastTime = (System.DateTime.Now.Minute * 60) + System.DateTime.Now.Second;
            int FirstTime = int.Parse(TempData["FirstTime"].ToString());
            
            
            if ((LastTime - FirstTime) < 12000)
            {
                if ((!string.IsNullOrWhiteSpace(command.Verifycode)) &&
                    (!string.IsNullOrWhiteSpace(TempData["SmsCode"].ToString())))
                {
                    //if (TempData["SmsCode"].ToString().Trim() == command.Verifycode)
                    if (1 == 1)
                    {
                        var userName = _authHelper.CurrentAccountUserName();
                        var NewCommand = new Login(userName, "", command.Verifycode);

                        //_authHelper.SignOut();
                       
                        var result = _accountApplication.LoginFinal(NewCommand);
                        //return RedirectToPage("/Index");
                        return RedirectToPage("/Index", new { area = "Administration" });

                        
                    }
                    else
                    {
                        VerifyMessage = ApplicationMessages.VerifyCodeIsNotTrue;
                        return RedirectToPage("/AccountVerify");
                    }
                }
                else
                {
                    VerifyMessage = ApplicationMessages.VerifyCodeIsNotTrue;
                    return RedirectToPage("/AccountVerify");
                }
            }
            else
            {
                VerifyMessage = ApplicationMessages.VerifyCodeIsNotValid;
                return RedirectToPage("/AccountVerify");
            }
        }


        public IActionResult OnGetReVerifyCode()
        {

            var mobile = _authHelper.CurrentAccountMobile();
            TempData["SmsCode"] = CodeGenerator.RandomNumberForSms();

            //_smsService.SendVerifySms(mobile, TempData["SmsCode"].ToString());
            TempData["FirstTime"] = (System.DateTime.Now.Minute * 60) + System.DateTime.Now.Second;
            return RedirectToPage("/AccountVerify");
        }
    }
}
