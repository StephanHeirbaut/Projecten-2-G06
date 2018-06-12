using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein;

namespace DotNet_GoeBezig_G11.Models.ActieViewModels
{
    public class DeelActieViewModel
    {
        
            public int Id { get; set; }

           public Actie Actie { get; set; }
           
        public string Aankodiging { get; set; }
        
    }
}
