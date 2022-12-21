using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Application.Contracts.QorbMoasPor
{
    public class QorbMoasPorViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long QorbMoasPorId_sana { get; set; }
        public long QorbId { get; set; }
        public string Qorb { get; set; }
        public long QorbMoasId { get; set; }
        public string QorbMoas { get; set; }
        public string CreationDate { get; set; }
        public long QorbMoasPorCount { get; set; }
    }
}
