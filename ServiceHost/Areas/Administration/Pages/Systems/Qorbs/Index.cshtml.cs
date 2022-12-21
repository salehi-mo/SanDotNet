using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JobManagement.Application.Contracts.PersonEshtegVaz;
using JobManagement.Application.Contracts.PersonOzvNoa;
using JobManagement.Application.Contracts.Qorb;

namespace ServiceHost.Areas.Administration.Pages.Systems.Qorbs
{
    //[Authorize(Roles = "1, 3")]
    public class IndexModel : PageModel
    {
        public QorbSearchModel SearchModel;
        public List<QorbViewModel> Qorbs;

        private readonly IQorbApplication _QorbApplication;

        public IndexModel(IQorbApplication qorbApplication)
        {
            _QorbApplication = qorbApplication;
        }

        //[NeedsPermission(ShopPermissions.ListProductCategories)]
        public void OnGet(QorbSearchModel searchModel)
        {
            Qorbs = _QorbApplication.Search(searchModel);
        }
       
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateQorb());
        }

        //[NeedsPermission(ShopPermissions.CreateProductCategory)]
        public JsonResult OnPostCreate(CreateQorb command)
        {
            var result = _QorbApplication.Create(command);
            return new JsonResult(result);
        }

       
        
        
        public IActionResult OnGetEdit(long id)
        {
            var Qorb = _QorbApplication.GetDetails(id);
            return Partial("Edit", Qorb);
        }

        //[NeedsPermission(ShopPermissions.EditProductCategory)]
        public JsonResult OnPostEdit(EditQorb command)
        {
            if (ModelState.IsValid)
            {
            }

            var result = _QorbApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
