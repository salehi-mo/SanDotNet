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
    public class QorbMoasPorController : ControllerBase
    {
        public QorbMoasPorSearchModel SearchModel;
        public SelectList qorbmoaspors;
        public readonly IQorbMoasPorApplication _qorbMoasPorApplication;

        public QorbMoasPorController( IQorbMoasPorApplication qorbMoasPorApplication)
        {
            _qorbMoasPorApplication = qorbMoasPorApplication;
        }

        [HttpPost("{id}")]
        public JsonResult PostQorbMoasPorsBy(long id)
        {
            qorbmoaspors = new SelectList(_qorbMoasPorApplication.GetQorbMoasPorsWithQorbMoas(id), "Id", "Name");
            return new JsonResult(new { status = "success", qorbmoaspors });
        }
    }

   
}
