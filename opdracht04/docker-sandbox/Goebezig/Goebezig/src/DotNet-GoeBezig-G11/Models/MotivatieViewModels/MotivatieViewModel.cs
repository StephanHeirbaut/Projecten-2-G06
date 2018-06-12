using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein;

namespace DotNet_GoeBezig_G11.Models.MotivatieViewModels
{
    public class MotivatieViewModel
    {
        [Required]
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 100)]
        public string Inhoud { get; set; }
        [Required]
        public string Organisatie { get; set; }
    }
}
