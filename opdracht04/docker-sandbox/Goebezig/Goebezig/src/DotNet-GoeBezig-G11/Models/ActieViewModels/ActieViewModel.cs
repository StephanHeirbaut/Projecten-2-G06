using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.ActieViewModels
{
    public class ActieViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Titel is verplicht!")]
        public string Titel { get; set; }

        [Required(ErrorMessage = "Omschrijving is verplicht!")]
        public string Omschrijving { get; set; }
        
    }
}
