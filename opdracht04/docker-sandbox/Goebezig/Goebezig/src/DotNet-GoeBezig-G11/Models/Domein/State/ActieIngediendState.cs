using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein.State
{
    public class ActieIngediendState : CurrentState
    {
        public ActieIngediendState(Groep groep) : base(groep)
        {
            
        }

        protected ActieIngediendState()
        {
            
        }
        public override string ToString()
        {
            return "De acties zijn ingediend, de groep wacht op goedkeuring van de lector";
        }
        
    }
}
