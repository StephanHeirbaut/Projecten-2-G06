using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.ActieViewModels
{
    public class EvenementViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Titel is verplicht!")]
        public string Titel { get; set; }

        [Required(ErrorMessage = "Omschrijving is verplicht!")]
        public string Omschrijving { get; set; }
        [Required (ErrorMessage = "Datum is verplicht bij een evenement!")]
        [Display(Name ="Datum evenement")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Datum { get; set; }

        public EvenementViewModel()
        {
            Datum = DateTime.Now;
        }
    }
}
