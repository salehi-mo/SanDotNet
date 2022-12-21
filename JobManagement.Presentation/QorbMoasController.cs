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
    public class QorbMoasController : ControllerBase
    {
        public QorbMoasPorSearchModel SearchModel;
        public SelectList qorbmoass;
        public readonly IQorbMoasApplication _qorbMoasApplication;

        public QorbMoasController( IQorbMoasApplication qorbMoasApplication)
        {
            _qorbMoasApplication = qorbMoasApplication;
        }

        [HttpPost("{id}")]
        public JsonResult PostQorbMoassBy(long id)
        {
            qorbmoass = new SelectList(_qorbMoasApplication.GetQorbMoassWithQorb(id), "Id", "Name");
            return new JsonResult(new { status = "success", qorbmoass });
        }
    }

   
}
