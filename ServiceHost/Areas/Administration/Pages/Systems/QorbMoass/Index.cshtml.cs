using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JobManagement.Application.Contracts.PersonEshtegVaz;
using JobManagement.Application.Contracts.PersonOzvNoa;
using JobManagement.Application.Contracts.Qorb;
using JobManagement.Application.Contracts.QorbMoas;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Systems.QorbMoass
{
    //[Authorize(Roles = "1, 3")]
    public class IndexModel : PageModel
    {
        public QorbMoasSearchModel SearchModel;
        public List<QorbMoasViewModel> QorbMoass;
        public SelectList Qorbs;

        private readonly IQorbMoasApplication _qorbMoasApplication;
        private readonly IQorbApplication _qorbApplication;

        public IndexModel(IQorbMoasApplication qorbMoasApplication, IQorbApplication qorbApplication)
        {
            _qorbMoasApplication = qorbMoasApplication;
            _qorbApplication = qorbApplication;
        }

        //[NeedsPermission(ShopPermissions.ListProductCategories)]
        public void OnGet(QorbMoasSearchModel searchModel)
        {
            Qorbs = new SelectList(_qorbApplication.GetQorbs(), "Id", "Name");
            QorbMoass = _qorbMoasApplication.Search(searchModel);
        }
       
        public IActionResult OnGetCreate()
        {
            var command = new CreateQorbMoas
            {
               Qorbs  = _qorbApplication.GetQorbs()
            };
            return Partial("./Create", command);
        }

        //[NeedsPermission(ShopPermissions.CreateProductCategory)]
        public JsonResult OnPostCreate(CreateQorbMoas command)
        {
            var result = _qorbMoasApplication.Create(command);
            return new JsonResult(result);
        }

       
        
        
        public IActionResult OnGetEdit(long id)
        {
            var qorbMoas = _qorbMoasApplication.GetDetails(id);
            qorbMoas.Qorbs = _qorbApplication.GetQorbs();

            return Partial("Edit", qorbMoas);
        }

        //[NeedsPermission(ShopPermissions.EditProductCategory)]
        public JsonResult OnPostEdit(EditQorbMoas command)
        {
            if (ModelState.IsValid)
            {
            }

            var result = _qorbMoasApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
