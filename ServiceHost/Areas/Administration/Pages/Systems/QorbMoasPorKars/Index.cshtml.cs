using System.Collections.Generic;
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

namespace ServiceHost.Areas.Administration.Pages.Systems.QorbMoasPorKars
{
    //[Authorize(Roles = "1, 3")]
    public class IndexModel : PageModel
    {
        public QorbMoasPorKarSearchModel SearchModel;
        public List<QorbMoasPorKarViewModel> QorbMoasPorKars;
        public SelectList Qorbs;
        public SelectList QorbMoass;
        public SelectList QorbMoasPors;

        private readonly IQorbMoasPorKarApplication _qorbMoasPorKarApplication;
        private readonly IQorbMoasPorApplication _qorbMoasPorApplication;
        private readonly IQorbMoasApplication _qorbMoasApplication;
        private readonly IQorbApplication _qorbApplication;

        public IndexModel(IQorbMoasApplication qorbMoasApplication, IQorbApplication qorbApplication, IQorbMoasPorApplication qorbMoasPorApplication, IQorbMoasPorKarApplication qorbMoasPorKarApplication)
        {
            _qorbMoasApplication = qorbMoasApplication;
            _qorbApplication = qorbApplication;
            _qorbMoasPorApplication = qorbMoasPorApplication;
            _qorbMoasPorKarApplication = qorbMoasPorKarApplication;
        }

        //[NeedsPermission(ShopPermissions.ListProductCategories)]
        public void OnGet(QorbMoasPorKarSearchModel searchModel)
        {
            Qorbs = new SelectList(_qorbApplication.GetQorbs(), "Id", "Name");
            QorbMoass = new SelectList(_qorbMoasApplication.GetQorbMoassWithQorb(searchModel.QorbId), "Id", "Name");
            QorbMoasPors = new SelectList(_qorbMoasPorApplication.GetQorbMoasPorsWithQorbMoas(searchModel.QorbMoasId), "Id", "Name");
            QorbMoasPorKars = _qorbMoasPorKarApplication.Search(searchModel);
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
