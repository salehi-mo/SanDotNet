using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using JobManagement.Application.Contracts.PersonEshtegVaz;
using JobManagement.Application.Contracts.PersonOzvNoa;
using JobManagement.Application.Contracts.Qorb;
using JobManagement.Application.Contracts.QorbMoas;
using JobManagement.Application.Contracts.QorbMoasPor;
using JobManagement.Application.Contracts.QorbMoasPorKar;

namespace JobManagement.Application.Contracts.Person
{
    public class CreatePerson
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long PerId { get;  set; }
        
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Nam { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)] 
        public string Fam { get;  set; }
        
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string NamPed { get;  set; }
       
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string NoShe { get;  set; }
      
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string CodMelli { get;  set; }
       
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get;  set; }
        public long? PersonEshtegVazId { get; set; }
        public long? PersonOzvNoaId { get; set; }
        public long? QorbId { get; set; }
        public long? QorbMoasId { get; set; }
        public long? QorbMoasPorId { get; set; }
        public long? QorbMoasPorKarId { get; set; }
        
        public List<QorbViewModel> Qorbs { get; set; }
        public List<QorbMoasViewModel> QorbMoass { get; set; }
        public List<QorbMoasPorViewModel> QorbMoasPors { get; set; }
        public List<QorbMoasPorKarViewModel> QorbMoasPorKars { get; set; }
        public List<PersonEshtegVazViewModel> PersonEshtegVazs { get; set; }
        public List<PersonOzvNoaViewModel> PersonOzvNoas { get; set; }

    }
}
