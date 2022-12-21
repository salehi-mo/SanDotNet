using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using _0_Framework.Infrastructure;
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
    public class EditModel : PageModel
    {
        public EditPerson Command;
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




        public EditModel(IQorbMoasPorApplication qorbMoasPorApplication, IQorbMoasApplication qorbMoasApplication, IQorbApplication qorbApplication, IQorbMoasPorKarApplication qorbMoasPorKarApplication, IPersonApplication personApplication, IPersonEshtegVazApplication personEshtegVazApplication, IPersonOzvNoaApplication personOzvNoaApplication)
        {
            _qorbMoasPorApplication = qorbMoasPorApplication;
            _qorbMoasApplication = qorbMoasApplication;
            _qorbApplication = qorbApplication;
            _qorbMoasPorKarApplication = qorbMoasPorKarApplication;
            _personApplication = personApplication;
            _personEshtegVazApplication = personEshtegVazApplication;
            _personOzvNoaApplication = personOzvNoaApplication;
        }

        public void OnGet(long id)
        {
            Command = _personApplication.GetDetails(id);
            Command.Qorbs = _qorbApplication.GetQorbs();
            Command.QorbMoass = _qorbMoasApplication.GetQorbMoass();
            Command.QorbMoasPors = _qorbMoasPorApplication.GetQorbMoasPors();
            Command.QorbMoasPorKars = _qorbMoasPorKarApplication.GetQorbMoasPorKars();
            Command.PersonEshtegVazs = _personEshtegVazApplication.GetPersonEshtegVazs();
            Command.PersonOzvNoas = _personOzvNoaApplication.GetPersonOzvNoas();
        }

        public IActionResult OnPost(EditPerson command)
        {
            var result = _personApplication.Edit(command);
            return RedirectToPage("Index");
        }
    }
}