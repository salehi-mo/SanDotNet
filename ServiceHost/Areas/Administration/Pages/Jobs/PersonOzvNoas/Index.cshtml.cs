using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JobManagement.Application.Contracts.PersonEshtegVaz;
using JobManagement.Application.Contracts.PersonOzvNoa;

namespace ServiceHost.Areas.Administration.Pages.Jobs.PersonOzvNoas
{
    //[Authorize(Roles = "1, 3")]
    public class IndexModel : PageModel
    {
        public PersonOzvNoaSearchModel SearchModel;
        public List<PersonOzvNoaViewModel> PersonOzvNoas;

        private readonly IPersonOzvNoaApplication _PersonOzvNoaApplication;

        public IndexModel(IPersonOzvNoaApplication personOzvNoaApplication)
        {
            _PersonOzvNoaApplication = personOzvNoaApplication;
        }

        //[NeedsPermission(ShopPermissions.ListProductCategories)]
        public void OnGet(PersonOzvNoaSearchModel searchModel)
        {
            PersonOzvNoas = _PersonOzvNoaApplication.Search(searchModel);
        }
       
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreatePersonOzvNoa());
        }

        //[NeedsPermission(ShopPermissions.CreateProductCategory)]
        public JsonResult OnPostCreate(CreatePersonOzvNoa command)
        {
            var result = _PersonOzvNoaApplication.Create(command);
            return new JsonResult(result);
        }

       
        
        
        public IActionResult OnGetEdit(long id)
        {
            var personOzvNoa = _PersonOzvNoaApplication.GetDetails(id);
            return Partial("Edit", personOzvNoa);
        }

        //[NeedsPermission(ShopPermissions.EditProductCategory)]
        public JsonResult OnPostEdit(EditPersonOzvNoa command)
        {
            if (ModelState.IsValid)
            {
            }

            var result = _PersonOzvNoaApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
