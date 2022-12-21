using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JobManagement.Application.Contracts.PersonEshtegVaz;

namespace ServiceHost.Areas.Administration.Pages.Jobs.PersonEshtegVazs
{
    //[Authorize(Roles = "1, 3")]
    public class IndexModel : PageModel
    {
        public PersonEshtegVazSearchModel SearchModel;
        public List<PersonEshtegVazViewModel> PersonEshtegVazs;

        private readonly IPersonEshtegVazApplication _PersonEshtegVazApplication;

        public IndexModel(IPersonEshtegVazApplication personEshtegVazApplication)
        {
            _PersonEshtegVazApplication = personEshtegVazApplication;
        }

        //[NeedsPermission(ShopPermissions.ListProductCategories)]
        public void OnGet(PersonEshtegVazSearchModel searchModel)
        {
            PersonEshtegVazs = _PersonEshtegVazApplication.Search(searchModel);
        }
       
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreatePersonEshtegVaz());
        }

        //[NeedsPermission(ShopPermissions.CreateProductCategory)]
        public JsonResult OnPostCreate(CreatePersonEshtegVaz command)
        {
            var result = _PersonEshtegVazApplication.Create(command);
            return new JsonResult(result);
        }

       
        
        
        public IActionResult OnGetEdit(long id)
        {
            var personEshtegVaz = _PersonEshtegVazApplication.GetDetails(id);
            return Partial("Edit", personEshtegVaz);
        }

        //[NeedsPermission(ShopPermissions.EditProductCategory)]
        public JsonResult OnPostEdit(EditPersonEshtegVaz command)
        {
            if (ModelState.IsValid)
            {
            }

            var result = _PersonEshtegVazApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
