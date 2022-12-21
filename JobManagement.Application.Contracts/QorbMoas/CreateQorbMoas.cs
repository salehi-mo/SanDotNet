using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using JobManagement.Application.Contracts.Qorb;

namespace JobManagement.Application.Contracts.QorbMoas
{
    public class CreateQorbMoas
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long QorbMoasId_sana { get; set; }
        
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
        
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long QorbId { get; set; }
        public List<QorbViewModel> Qorbs { get; set; }
    }
}
