using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Application.Contracts.Qorb
{
    public class QorbViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long QorbId_sana { get;  set; }
        public string CreationDate { get; set; }
        public long QorbCount { get; set; }
    }
}
