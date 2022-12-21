using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Application.Contracts.Person
{
    public class PersonViewModel
    {
        public long Id { get; set; }
        public long PerId { get; set; }
        public string Nam { get; set; }
        public string Fam { get; set; }
        public string NamPed { get; set; }
        public string NoShe { get; set; }
        public string CodMelli { get; set; }
        public string CreationDate { get; set; }
        public long PersonCount { get; set; }

        public long QorbId { get; set; }
        public string Qorb { get; set; }
        public long QorbMoasId { get; set; }
        public string QorbMoas { get; set; }
        public long QorbMoasPorId { get; set; }
        public string QorbMoasPor { get; set; }
        public long QorbMoasPorKarId { get; set; }
        public string QorbMoasPorKar { get; set; }
        public long PersonEshtegVazId { get; set; }
        public string PersonEshtegVaz { get; set; }
        public long PersonOzvNoaId { get; set; }
        public string PersonOzvNoa { get; set; }
    }
}
