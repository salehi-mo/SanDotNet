using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Application.Contracts.PersonOzvNoa
{
   public class PersonOzvNoaViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long PersonOzvNoaId { get;  set; }
        public string CreationDate { get; set; }
        public long PersonOzvNoaCount { get; set; }
    }
}
