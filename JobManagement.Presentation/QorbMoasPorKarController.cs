using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.Application.Contracts.Qorb;
using JobManagement.Application.Contracts.QorbMoas;
using JobManagement.Application.Contracts.QorbMoasPor;
using JobManagement.Application.Contracts.QorbMoasPorKar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobManagement.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class QorbMoasPorKarController : ControllerBase
    {
        public QorbMoasPorSearchModel SearchModel;
        public SelectList qorbmoasporkars;
        public readonly IQorbMoasPorKarApplication _qorbMoasPorKarApplication;

        public QorbMoasPorKarController( IQorbMoasPorKarApplication qorbMoasPorKarApplication)
        {
            _qorbMoasPorKarApplication = qorbMoasPorKarApplication;
        }

        [HttpPost("{id}")]
        public JsonResult PostQorbMoasPorKarsBy(long id)
        {
            qorbmoasporkars = new SelectList(_qorbMoasPorKarApplication.GetQorbMoasPorKarsWithQorbMoasPor(id), "Id", "Name");
            return new JsonResult(new { status = "success", qorbmoasporkars });
        }
    }

   
}
