using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.Application.Contracts.Qorb;
using JobManagement.Application.Contracts.QorbMoas;
using JobManagement.Application.Contracts.QorbMoasPor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobManagement.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        public QorbMoasPorSearchModel SearchModel;
        public List<QorbMoasPorViewModel> QorbMoasPors;
        public SelectList qorbs;
        public SelectList qorbmoass;

        private readonly IQorbMoasPorApplication _qorbMoasPorApplication;
        public readonly IQorbMoasApplication _qorbMoasApplication;
        private readonly IQorbApplication _qorbApplication;

        public JobController(IQorbMoasPorApplication qorbMoasPorApplication, IQorbMoasApplication qorbMoasApplication, IQorbApplication qorbApplication)
        {
            _qorbMoasPorApplication = qorbMoasPorApplication;
            _qorbMoasApplication = qorbMoasApplication;
            _qorbApplication = qorbApplication;
        }


        [HttpGet("{id}")]
        public SelectList GetQorbMoassBy(long id)
        {
            qorbmoass = new SelectList(_qorbMoasApplication.GetQorbMoassWithQorb(id), "Id", "Name");
            return qorbmoass;
        }

        [HttpPost("{id}")]
        public JsonResult PostQorbMoassBy(long id)
        {
            qorbmoass = new SelectList(_qorbMoasApplication.GetQorbMoassWithQorb(id), "Id", "Name");
            return new JsonResult(new { status = "success", qorbmoass });
        }
    }

   
}
