using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Application.Contracts.Person
{
    public class PersonSearchModel
    {
        public string Nam { get; set; }
        public string Fam { get; set; }
        public string NamPed { get; set; }
        public string Noshe { get; set; }
        public string CodMelli { get; set; }
        public long QorbId { get; set; }
        public long QorbMoasId { get; set; }
        public long QorbMoasPorId { get; set; }
        public long QorbMoasPorKarId { get; set; }
        public long PersonEshtegVazId { get; set; }
        public long PersonOzvNoaId { get; set; }

    }
}
