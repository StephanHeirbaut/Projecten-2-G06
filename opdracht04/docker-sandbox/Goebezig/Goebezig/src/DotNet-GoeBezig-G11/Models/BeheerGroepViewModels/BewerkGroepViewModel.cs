using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_GoeBezig_G11.Models.BeheerGroepViewModels
{

    public class BewerkGroepViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Remote("IsUniqueNaam","BeherenGroep", ErrorMessage = "Er bestaat al een groep met deze naam.")]
        public string Naam { get; set; }

        //[Required]
        //[Display(Name = "Type")]
        //public bool Open { get; set; }
    }
}
