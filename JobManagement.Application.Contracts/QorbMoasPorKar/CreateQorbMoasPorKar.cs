using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using JobManagement.Application.Contracts.Qorb;
using JobManagement.Application.Contracts.QorbMoas;
using JobManagement.Application.Contracts.QorbMoasPor;

namespace JobManagement.Application.Contracts.QorbMoasPorKar
{
    public class CreateQorbMoasPorKar
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long QorbMoasPorKarId_sana { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }

        public long QorbId { get; set; }
        public long QorbMoasId { get; set; }
        public List<QorbViewModel> Qorbs { get; set; }
        public List<QorbMoasViewModel> QorbMoass { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long QorbMoasPorId { get; set; }
        public List<QorbMoasPorViewModel> QorbMoasPors { get; set; }
    }
}
