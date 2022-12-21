using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Application.Contracts.Qorb
{
    public class EditQorb : CreateQorb
    {
        public long Id { get; set; }
    }
}
