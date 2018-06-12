using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNet_GoeBezig_G11.Models.DraaiboekViewModels
{
    public class EditViewModel
    {
        [HiddenInput]
        public int TaakId { get; set; }

        [Required]
        public IEnumerable<string> ToegevoegdeCursisten { get; set; }

        
        [Display(Name = "Kies leden van je groep voor de taak")]
        public List<SelectListItem> Wie { get; set; }

        [Required]
        [Display(Name = "Titel")]
        [StringLength(50, ErrorMessage = "{0} may not contain more than 50 characters")]
        public string Wat { get; set; }

        [Display(Name = "Geef hier je opmerkingen")]
        public string Opmerking { get; set; }

        [Display(Name = "Wanneer start de taak")]
        [DataType(DataType.DateTime)]
        //[Remote("CheckDate","Draaiboek", ErrorMessage = "Datum moet in de toekomst liggen")]
        public DateTime? Van { get; set; }
        
        [Display(Name = "Wanneer is de taak afgerond")]
        [DataType(DataType.DateTime)]
        //[Remote("CheckDate", "Draaiboek")]
        public DateTime? Tot { get; set; }

        [Required]
        public int Actie { get; set; }

        public EditViewModel()
        {
        }

        public EditViewModel(Cursist cursist) : this()
        {
            Wie = new List<SelectListItem>();
            cursist.Groep.Cursisten.ForEach(c => Wie.Add(new SelectListItem()
            {
                Value = c.Naam + " " + c.Voornaam,
                Text = c.Naam + " " + c.Voornaam
            }));
        }

        public EditViewModel(Cursist cursist, Taak taak) : this()
        {
            TaakId = taak.TaakId;
            Wie = new List<SelectListItem>();
            cursist.Groep.Cursisten.ForEach(c => Wie.Add(new SelectListItem()
            {
                Value = c.Naam + " " + c.Voornaam,
                Text = c.Naam + " " + c.Voornaam
            }));
            Wat = taak.Wat;
            Actie = taak.Actie.ActieId;
            Opmerking = taak.Bijsturing;
            Van = taak.Van;
            Tot = taak.Tot;
        }
        public EditViewModel(Taak taak) : this()
        {
            TaakId = taak.TaakId;
            Wat = taak.Wat;
            Actie = taak.Actie.ActieId;
            Opmerking = taak.Bijsturing;
            Van = taak.Van;
            Tot = taak.Tot;
        }
    }
}
