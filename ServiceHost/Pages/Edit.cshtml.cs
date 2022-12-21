using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Role;
using JobManagement.Application.Contracts.Qorb;
using JobManagement.Application.Contracts.QorbMoas;
using JobManagement.Application.Contracts.QorbMoasPor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Pages
{
    public class EditModel : PageModel
    {
        public EditQorbMoasPor Command;
        public SelectList Qorbs;
        public SelectList QorbMoass;

        private readonly IQorbMoasPorApplication _qorbMoasPorApplication;
        private readonly IQorbMoasApplication _qorbMoasApplication;
        private readonly IQorbApplication _qorbApplication;

       
       

        public EditModel(IQorbMoasPorApplication qorbMoasPorApplication, IQorbMoasApplication qorbMoasApplication, IQorbApplication qorbApplication)
        {
            _qorbMoasPorApplication = qorbMoasPorApplication;
            _qorbMoasApplication = qorbMoasApplication;
            _qorbApplication = qorbApplication;
        }

        public void OnGet(long id)
        {
            Command = _qorbMoasPorApplication.GetDetails(id);
            Command.Qorbs = _qorbApplication.GetQorbs();
            Command.QorbMoass = _qorbMoasApplication.GetQorbMoass();
        }

        public IActionResult OnPost(EditQorbMoasPor command)
        {
            var result = _qorbMoasPorApplication.Edit(command);
            return RedirectToPage("Index");
        }
    }
}