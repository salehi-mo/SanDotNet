using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Application.Contracts.QorbMoas
{
    public class QorbMoasViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long QorbMoasId_sana { get; set; }
        public long QorbId { get; set; }
        public string Qorb { get; set; }
        public string CreationDate { get; set; }
        public long QorbMoasCount { get; set; }
    }
}
