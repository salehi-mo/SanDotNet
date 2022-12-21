using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace JobManagement.Application.Contracts.Qorb
{
    public class CreateQorb
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long QorbId_sana { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
    }
}
