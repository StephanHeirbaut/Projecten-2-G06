using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein.State
{
    public class ActieGoedgekeurdState : CurrentState
    {
        public ActieGoedgekeurdState(Groep groep) : base(groep)
        {
            
        }

        protected ActieGoedgekeurdState()
        {
            
        }
        public override string ToString()
        {
            return "Acties zijn goedgekeurd ga door naar het draaiboek";
        }

        public override void VoegTaakToe(Taak taak, int actieId)
        {
            Groep.Acties().Single(actie => actie.ActieId == actieId).Taken.Add(taak);
        }
    }
}
