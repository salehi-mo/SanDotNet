using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class CreateModel : PageModel
    {
        public CreateQorbMoasPorKar Command;
        public SelectList Qorbs;
        public SelectList QorbMoass;
        public SelectList QorbMoasPors;

        private readonly IQorbMoasPorKarApplication _qorbMoasPorKarApplication;
        private readonly IQorbMoasPorApplication _qorbMoasPorApplication;
        private readonly IQorbMoasApplication _qorbMoasApplication;
        private readonly IQorbApplication _qorbApplication;

        public CreateModel(IQorbMoasPorApplication qorbMoasPorApplication, IQorbMoasApplication qorbMoasApplication, IQorbApplication qorbApplication, IQorbMoasPorKarApplication qorbMoasPorKarApplication)
        {
            _qorbMoasPorApplication = qorbMoasPorApplication;
            _qorbMoasApplication = qorbMoasApplication;
            _qorbApplication = qorbApplication;
            _qorbMoasPorKarApplication = qorbMoasPorKarApplication;
        }

        public void OnGet()
        {
            Qorbs = new SelectList(_qorbApplication.GetQorbs(), "Id", "Name");
            QorbMoass = new SelectList(_qorbMoasApplication.GetQorbMoass(), "Id", "Name");
            QorbMoasPors = new SelectList(_qorbMoasPorApplication.GetQorbMoasPors(), "Id", "Name");
            //QorbMoass = new SelectList(_qorbMoasApplication.GetQorbMoassWithQorb(searchModel.QorbId), "Id", "Name");
            //QorbMoasPors = _qorbMoasPorApplication.Search(searchModel);
        }
        
        public IActionResult OnPost(CreateQorbMoasPorKar command)
        {
            var result = _qorbMoasPorKarApplication.Create(command);
            return RedirectToPage("Index");
        }
    }
}