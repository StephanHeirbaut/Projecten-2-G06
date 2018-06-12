using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet_GoeBezig_G11.Models.BeheerGroepViewModels
{
    public class BewerkViewModel
    {
        
        [Required]
        [EmailAddress]
        public string EmailCursist { get; set; }





        

    }
}
