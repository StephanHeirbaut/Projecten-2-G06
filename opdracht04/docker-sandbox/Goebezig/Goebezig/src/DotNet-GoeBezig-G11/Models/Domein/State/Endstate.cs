using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein.State
{
    public class Endstate : CurrentState
    {
        public Endstate(Groep groep) : base(groep)
        {
            
        }

        protected Endstate()
        {
            
        }
        public override string ToString()
        {
            return "De groep heeft alles afgerond, proficiat!";
        }
    }
}
