using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Application.Contracts.PersonEshtegVaz
{
    public class PersonEshtegVazViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long PersonEshtegVazId { get;  set; }
        public string CreationDate { get; set; }
        public long PersonEshtegVazCount { get; set; }
    }
}
