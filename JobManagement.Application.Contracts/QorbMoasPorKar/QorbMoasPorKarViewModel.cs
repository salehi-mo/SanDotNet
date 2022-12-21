using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.Application.Contracts.QorbMoasPor;

namespace JobManagement.Application.Contracts.QorbMoasPorKar
{
    public class QorbMoasPorKarViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long QorbMoasPorKarId_sana { get; set; }
        public long QorbId { get; set; }
        public string Qorb { get; set; }
        public long QorbMoasId { get; set; }
        public string QorbMoas { get; set; }
        public long QorbMoasPorId { get; set; }
        public string QorbMoasPor { get; set; }
        public string CreationDate { get; set; }
        public long QorbMoasPorKarCount { get; set; }
      
    }
}
