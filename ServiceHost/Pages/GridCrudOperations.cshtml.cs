using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobManagement.Application.Contracts.Qorb;
using JobManagement.Application.Contracts.QorbMoas;
using JobManagement.Application.Contracts.QorbMoasPor;
//using Telerik.Examples.RazorPages.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Pages
{
    public class GridCrudOperationsModel : PageModel
    {
        public EditQorbMoasPor Command_EditQorbMoasPor;

        public static IList<OrderViewModel> orders;
        public QorbMoasPorSearchModel SearchModel;
        public static List<QorbMoasPorViewModel> QorbMoasPors;
        public SelectList Qorbs;
        public SelectList QorbMoass;

        private readonly IQorbMoasPorApplication _qorbMoasPorApplication;
        public readonly IQorbMoasApplication _qorbMoasApplication;
        private readonly IQorbApplication _qorbApplication;
        

        public GridCrudOperationsModel(IQorbMoasPorApplication qorbMoasPorApplication, IQorbMoasApplication qorbMoasApplication, IQorbApplication qorbApplication)
        {
            _qorbMoasPorApplication = qorbMoasPorApplication;
            _qorbMoasApplication = qorbMoasApplication;
            _qorbApplication = qorbApplication;
        }

        public void OnGet(QorbMoasPorSearchModel searchModel)
        {
            Qorbs = new SelectList(_qorbApplication.GetQorbs(), "Id", "Name");
            QorbMoass = new SelectList(_qorbMoasApplication.GetQorbMoassWithQorb(searchModel.QorbId), "Id", "Name");
            QorbMoasPors = _qorbMoasPorApplication.Search(searchModel);
            
            //if (orders == null)
            //{
            //    orders = new List<OrderViewModel>();

            //    Enumerable.Range(1, 50).ToList().ForEach(i => orders.Add(new OrderViewModel
            //    {
            //        OrderID = i,
            //        OrderDate = DateTime.Now.AddDays(i % 7),
            //        Freight = i * 10,
            //        ShipName = "ShipName " + i,
            //        ShipCity = "ShipCity " + i
            //    }));

            //}
        }





        

        public JsonResult OnPostRead([DataSourceRequest] DataSourceRequest request)
        {
            return new JsonResult(QorbMoasPors.ToDataSourceResult(request));
        }

        public JsonResult OnPostCreate([DataSourceRequest] DataSourceRequest request, QorbMoasPorViewModel order)
        {
            //order.Id = orders.Count + 2;
            QorbMoasPors.Add(order);

            return new JsonResult(new[] { order }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult OnPostUpdate([DataSourceRequest] DataSourceRequest request, QorbMoasPorViewModel order, EditQorbMoasPor command)
        {
            QorbMoasPors.Where(x => x.Id == order.Id).Select(x => order);

            //Command_EditQorbMoasPor = _qorbMoasPorApplication.GetDetails(order.Id);
            //Command_EditQorbMoasPor.Qorbs = _qorbApplication.GetQorbs();
            //Command_EditQorbMoasPor.QorbMoass = _qorbMoasApplication.GetQorbMoass();

            var result = _qorbMoasPorApplication.Edit(command);
            //return RedirectToPage("Index");

            return new JsonResult(new[] { order }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult OnPostDestroy([DataSourceRequest] DataSourceRequest request, QorbMoasPorViewModel order)
        {
            QorbMoasPors.Remove(QorbMoasPors.FirstOrDefault(x => x.Id == order.Id));

            return new JsonResult(new[] { order }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult OnPostSave(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    }
}
