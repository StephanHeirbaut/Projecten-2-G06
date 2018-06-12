using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein;

namespace DotNet_GoeBezig_G11.Models.ActieViewModels
{
    public class VerwijderActieModel
    {
        [Required]
        public int actieId { get; set; }
      
    }
}
