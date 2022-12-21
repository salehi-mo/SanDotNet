using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Application.Contracts.PersonEshtegVaz
{
    public class EditPersonEshtegVaz : CreatePersonEshtegVaz
    {
        public long Id { get; set; }
    }
}
