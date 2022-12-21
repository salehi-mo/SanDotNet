using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Role;
using JobManagement.Application.Contracts.Qorb;
using JobManagement.Application.Contracts.QorbMoas;
using JobManagement.Application.Contracts.QorbMoasPor;
using JobManagement.Application.Contracts.QorbMoasPorKar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Systems.QorbMoasPorKars
{
    public class EditModel : PageModel
    {
        public EditQorbMoasPorKar Command;
        public SelectList Qorbs;
        public SelectList QorbMoass;
        public SelectList QorbMoasPors;

        private readonly IQorbMoasPorKarApplication _qorbMoasPorKarApplication;
        private readonly IQorbMoasPorApplication _qorbMoasPorApplication;
        private readonly IQorbMoasApplication _qorbMoasApplication;
        private readonly IQorbApplication _qorbApplication;

       
       

        public EditModel(IQorbMoasPorApplication qorbMoasPorApplication, IQorbMoasApplication qorbMoasApplication, IQorbApplication qorbApplication, IQorbMoasPorKarApplication qorbMoasPorKarApplication)
        {
            _qorbMoasPorApplication = qorbMoasPorApplication;
            _qorbMoasApplication = qorbMoasApplication;
            _qorbApplication = qorbApplication;
            _qorbMoasPorKarApplication = qorbMoasPorKarApplication;
        }

        public void OnGet(long id)
        {
            Command = _qorbMoasPorKarApplication.GetDetails(id);
            Command.Qorbs = _qorbApplication.GetQorbs();
            Command.QorbMoass = _qorbMoasApplication.GetQorbMoass();
            Command.QorbMoasPors = _qorbMoasPorApplication.GetQorbMoasPors();
        }

        public IActionResult OnPost(EditQorbMoasPorKar command)
        {
            var result = _qorbMoasPorKarApplication.Edit(command);
            return RedirectToPage("Index");
        }
    }
}