using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Application.Contracts.Role;
using JobManagement.Application.Contracts.Qorb;
using JobManagement.Application.Contracts.QorbMoas;
using JobManagement.Application.Contracts.QorbMoasPor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Systems.QorbMoasPors
{
    public class CreateModel : PageModel
    {
        public CreateQorbMoasPor Command;
        public SelectList Qorbs;
        public SelectList QorbMoass;
        
        private readonly IQorbMoasPorApplication _qorbMoasPorApplication;
        private readonly IQorbMoasApplication _qorbMoasApplication;
        private readonly IQorbApplication _qorbApplication;

        public CreateModel(IQorbMoasPorApplication qorbMoasPorApplication, IQorbMoasApplication qorbMoasApplication, IQorbApplication qorbApplication)
        {
            _qorbMoasPorApplication = qorbMoasPorApplication;
            _qorbMoasApplication = qorbMoasApplication;
            _qorbApplication = qorbApplication;
        }

        public void OnGet()
        {
            Qorbs = new SelectList(_qorbApplication.GetQorbs(), "Id", "Name");
            QorbMoass = new SelectList(_qorbMoasApplication.GetQorbMoass(), "Id", "Name");
            //QorbMoass = new SelectList(_qorbMoasApplication.GetQorbMoassWithQorb(searchModel.QorbId), "Id", "Name");
            //QorbMoasPors = _qorbMoasPorApplication.Search(searchModel);
        }
        
        public IActionResult OnPost(CreateQorbMoasPor command)
        {
            var result = _qorbMoasPorApplication.Create(command);
            return RedirectToPage("Index");
        }
    }
}