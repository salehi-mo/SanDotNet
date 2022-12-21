using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Account
{
    public class RolesModel : PageModel
    {
        public AccountViewModel Command;
        public List<RoleViewModel> Roles;
        public List<SelectListItem> RolesPermission = new List<SelectListItem>();
        private readonly IRoleApplication _roleApplication;
        private readonly IAccountApplication _accountApplication;


        public RolesModel(IRoleApplication roleApplication, IAccountApplication accountApplication)
        {
            _roleApplication = roleApplication;
            _accountApplication = accountApplication;
        }

        public void OnGet(long id)
        {
            Command = _accountApplication.GetAccountByRoles(id);
            Roles = _roleApplication.List();

            foreach (var role in Roles)
            {
                var item = new SelectListItem(role.Name, role.Id.ToString());

                if (Command.Roles.Contains( role.Id))
                    item.Selected = true;

                RolesPermission.Add(item);
            }

        }

        public IActionResult OnPost(EditAccount command)
        {
            var result = _accountApplication.Edit(command);
            return RedirectToPage("Index");
        }
    }
}
