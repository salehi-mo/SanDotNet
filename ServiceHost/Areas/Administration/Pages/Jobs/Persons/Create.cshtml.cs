using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Application.Contracts.Role;
using JobManagement.Application.Contracts.Person;
using JobManagement.Application.Contracts.PersonEshtegVaz;
using JobManagement.Application.Contracts.PersonOzvNoa;
using JobManagement.Application.Contracts.Qorb;
using JobManagement.Application.Contracts.QorbMoas;
using JobManagement.Application.Contracts.QorbMoasPor;
using JobManagement.Application.Contracts.QorbMoasPorKar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Jobs.Persons
{
    public class CreateModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public CreatePerson Command;
        public SelectList Qorbs;
        public SelectList QorbMoass;
        public SelectList QorbMoasPors;
        public SelectList QorbMoasPorKars;
        public SelectList PersonEshtegVazs;
        public SelectList PersonOzvNoas;

        private readonly IQorbMoasPorKarApplication _qorbMoasPorKarApplication;
        private readonly IQorbMoasPorApplication _qorbMoasPorApplication;
        private readonly IQorbMoasApplication _qorbMoasApplication;
        private readonly IQorbApplication _qorbApplication;
        private readonly IPersonApplication _personApplication;
        private readonly IPersonEshtegVazApplication _personEshtegVazApplication;
        private readonly IPersonOzvNoaApplication _personOzvNoaApplication;

        public CreateModel(IQorbMoasPorApplication qorbMoasPorApplication, IQorbMoasApplication qorbMoasApplication, IQorbApplication qorbApplication, IQorbMoasPorKarApplication qorbMoasPorKarApplication, IPersonApplication personApplication, IPersonEshtegVazApplication personEshtegVazApplication, IPersonOzvNoaApplication personOzvNoaApplication)
        {
            _qorbMoasPorApplication = qorbMoasPorApplication;
            _qorbMoasApplication = qorbMoasApplication;
            _qorbApplication = qorbApplication;
            _qorbMoasPorKarApplication = qorbMoasPorKarApplication;
            _personApplication = personApplication;
            _personEshtegVazApplication = personEshtegVazApplication;
            _personOzvNoaApplication = personOzvNoaApplication;
        }

        public void OnGet()
        {
            Qorbs = new SelectList(_qorbApplication.GetQorbs(), "Id", "Name");
            QorbMoass = new SelectList(_qorbMoasApplication.GetQorbMoass(), "Id", "Name");
            QorbMoasPors = new SelectList(_qorbMoasPorApplication.GetQorbMoasPors(), "Id", "Name");
            QorbMoasPorKars = new SelectList(_qorbMoasPorKarApplication.GetQorbMoasPorKars(), "Id", "Name");
            PersonEshtegVazs = new SelectList(_personEshtegVazApplication.GetPersonEshtegVazs(), "Id", "Name");
            PersonOzvNoas = new SelectList(_personOzvNoaApplication.GetPersonOzvNoas(), "Id", "Name");
        }
        
        public IActionResult OnPost(CreatePerson command)
        {
            var result = _personApplication.Create(command);
            if (!result.IsSuccedded)
            {
                Message = result.Message;
                return RedirectToPage("Create");
            }
            else
            {
                return RedirectToPage("Index");
            }

            
        }
    }
}