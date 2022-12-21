using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JobManagement.Application.Contracts.PersonEshtegVaz;
using JobManagement.Application.Contracts.PersonOzvNoa;
using JobManagement.Application.Contracts.Qorb;
using JobManagement.Application.Contracts.QorbMoas;
using JobManagement.Application.Contracts.QorbMoasPor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Serialization;

namespace ServiceHost.Areas.Administration.Pages.Systems.QorbMoasPors
{
    //[Authorize(Roles = "1, 3")]
    public class IndexModel : PageModel
    {
        public QorbMoasPorSearchModel SearchModel;
        public List<QorbMoasPorViewModel> QorbMoasPors;
        public SelectList Qorbs;
        public SelectList QorbMoass;

        private readonly IQorbMoasPorApplication _qorbMoasPorApplication;
        private readonly IQorbMoasApplication _qorbMoasApplication;
        private readonly IQorbApplication _qorbApplication;

        public IndexModel(IQorbMoasApplication qorbMoasApplication, IQorbApplication qorbApplication, IQorbMoasPorApplication qorbMoasPorApplication)
        {
            _qorbMoasApplication = qorbMoasApplication;
            _qorbApplication = qorbApplication;
            _qorbMoasPorApplication = qorbMoasPorApplication;
        }

        //[NeedsPermission(ShopPermissions.ListProductCategories)]
        public void OnGet(QorbMoasPorSearchModel searchModel)
        {
            Qorbs = new SelectList(_qorbApplication.GetQorbs(), "Id", "Name");
            //QorbMoass = new SelectList(_qorbMoasApplication.GetQorbMoass(), "Id", "Name");
            QorbMoass = new SelectList(_qorbMoasApplication.GetQorbMoassWithQorb(searchModel.QorbId), "Id", "Name");
            QorbMoasPors = _qorbMoasPorApplication.Search(searchModel);
        }


       


        //public IActionResult OnGetCreate()
        //{
        //    var command = new CreateQorbMoasPor
        //    {
        //       Qorbs  = _qorbApplication.GetQorbs(),
        //       QorbMoass = _qorbMoasApplication.GetQorbMoass()
        //    };
        //    return Partial("./Create", command);
        //}

        ////[NeedsPermission(ShopPermissions.CreateProductCategory)]
        //public JsonResult OnPostCreate(CreateQorbMoasPor command)
        //{
        //    var result = _qorbMoasPorApplication.Create(command);
        //    return new JsonResult(result);
        //}

       
        
        
        //public IActionResult OnGetEdit(long id)
        //{
        //    var qorbMoasPor = _qorbMoasPorApplication.GetDetails(id);
        //    qorbMoasPor.Qorbs = _qorbApplication.GetQorbs();
        //    qorbMoasPor.QorbMoass = _qorbMoasApplication.GetQorbMoass();

        //    return Partial("Edit", qorbMoasPor);
        //}

        ////[NeedsPermission(ShopPermissions.EditProductCategory)]
        //public JsonResult OnPostEdit(EditQorbMoasPor command)
        //{
        // if (ModelState.IsValid)
        //    {
        //    }

        //    var result = _qorbMoasPorApplication.Edit(command);
        //    return new JsonResult(result);
        //}
    }

}
