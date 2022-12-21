using System.Collections.Generic;
using JobManagement.Application.Contracts.Person;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JobManagement.Application.Contracts.PersonEshtegVaz;
using JobManagement.Application.Contracts.PersonOzvNoa;
using JobManagement.Application.Contracts.Qorb;
using JobManagement.Application.Contracts.QorbMoas;
using JobManagement.Application.Contracts.QorbMoasPor;
using JobManagement.Application.Contracts.QorbMoasPorKar;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Serialization;

namespace ServiceHost.Areas.Administration.Pages.Jobs.Persons
{
    //[Authorize(Roles = "1, 3")]
    public class IndexModel : PageModel
    {
        public PersonSearchModel SearchModel;
        public List<PersonViewModel> Persons;
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
        private readonly IPersonEshtegVazApplication _personEshtegVazApplication;
        private readonly IPersonOzvNoaApplication _personOzvNoaApplication;
        private readonly IPersonApplication _personApplication;

        public IndexModel(IQorbMoasApplication qorbMoasApplication, IQorbApplication qorbApplication, IQorbMoasPorApplication qorbMoasPorApplication, IQorbMoasPorKarApplication qorbMoasPorKarApplication, IPersonEshtegVazApplication personEshtegVazApplication, IPersonOzvNoaApplication personOzvNoaApplication, IPersonApplication personApplication)
        {
            _qorbMoasApplication = qorbMoasApplication;
            _qorbApplication = qorbApplication;
            _qorbMoasPorApplication = qorbMoasPorApplication;
            _qorbMoasPorKarApplication = qorbMoasPorKarApplication;
            _personEshtegVazApplication = personEshtegVazApplication;
            _personOzvNoaApplication = personOzvNoaApplication;
            _personApplication = personApplication;
        }

        //[NeedsPermission(ShopPermissions.ListProductCategories)]
        public void OnGet(PersonSearchModel searchModel)
        {
            Qorbs = new SelectList(_qorbApplication.GetQorbs(), "Id", "Name");
            QorbMoass = new SelectList(_qorbMoasApplication.GetQorbMoass(), "Id", "Name");
            QorbMoasPors = new SelectList(_qorbMoasPorApplication.GetQorbMoasPors(), "Id", "Name");
            QorbMoasPorKars = new SelectList(_qorbMoasPorKarApplication.GetQorbMoasPorKars(), "Id", "Name");
            PersonEshtegVazs = new SelectList(_personEshtegVazApplication.GetPersonEshtegVazs(), "Id", "Name");
            PersonOzvNoas = new SelectList(_personOzvNoaApplication.GetPersonOzvNoas(), "Id", "Name");

            Persons = _personApplication.Search(searchModel);
        }



        //public IActionResult OnGetCreate()
        //{
        //    var command = new CreateQorbMoasPorKar
        //    {
        //       Qorbs  = _qorbApplication.GetQorbs(),
        //       QorbMoass = _qorbMoasApplication.GetQorbMoass(),
        //       QorbMoasPors = _qorbMoasPorApplication.GetQorbMoasPors()
        //    };
        //    return Partial("./Create", command);
        //}

        ////[NeedsPermission(ShopPermissions.CreateProductCategory)]
        //public JsonResult OnPostCreate(CreateQorbMoasPorKar command)
        //{
        //    var result = _qorbMoasPorKarApplication.Create(command);
        //    return new JsonResult(result);
        //}

       
        
        
        //public IActionResult OnGetEdit(long id)
        //{
        //    var qorbMoasPorKar = _qorbMoasPorKarApplication.GetDetails(id);
        //    qorbMoasPorKar.Qorbs = _qorbApplication.GetQorbs();
        //    qorbMoasPorKar.QorbMoass = _qorbMoasApplication.GetQorbMoass();
        //    qorbMoasPorKar.QorbMoasPors = _qorbMoasPorApplication.GetQorbMoasPors();

        //    return Partial("Edit", qorbMoasPorKar);
        //}

        ////[NeedsPermission(ShopPermissions.EditProductCategory)]
        //public JsonResult OnPostEdit(EditQorbMoasPorKar command)
        //{
        // if (ModelState.IsValid)
        //    {
        //    }

        //    var result = _qorbMoasPorKarApplication.Edit(command);
        //    return new JsonResult(result);
        //}
    }

}
