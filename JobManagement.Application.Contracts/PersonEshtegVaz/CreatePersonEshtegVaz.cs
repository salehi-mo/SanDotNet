using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Application.Contracts.PersonEshtegVaz
{
    public class CreatePersonEshtegVaz
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long PersonEshtegVazId { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }

    }
}
