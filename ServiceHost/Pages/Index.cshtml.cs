using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobManagement.Application.Contracts.Qorb;
using JobManagement.Application.Contracts.QorbMoas;
using JobManagement.Application.Contracts.QorbMoasPor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Pages
{
    public class IndexModel : PageModel
    {
        public QorbMoasPorSearchModel SearchModel;
        public List<QorbMoasPorViewModel> QorbMoasPors;
        public SelectList Qorbs;
        public SelectList QorbMoass;

        private readonly IQorbMoasPorApplication _qorbMoasPorApplication;
        public readonly IQorbMoasApplication _qorbMoasApplication;
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


       
        public JsonResult OnPostmosi(int id)
        {
            QorbMoass = new SelectList(_qorbMoasApplication.GetQorbMoassWithQorb(id), "Id", "Name");
            //var cityList = _db.cityTbl.Where(c => c.ProvinceID == id)
            //    .Select(c => new { id = c.ID, cname = c.CityName }).ToList();
            return new JsonResult(new { status = "success", QorbMoass });
        }
    }
}
