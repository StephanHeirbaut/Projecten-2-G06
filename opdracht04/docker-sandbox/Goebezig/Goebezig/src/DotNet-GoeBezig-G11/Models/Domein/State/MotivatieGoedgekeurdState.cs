using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.ActieViewModels;

namespace DotNet_GoeBezig_G11.Models.Domein.State
{
    public class MotivatieGoedgekeurdState : CurrentState
    {
        public MotivatieGoedgekeurdState(Groep groep) : base(groep)
        {

        }

        protected MotivatieGoedgekeurdState()
        {

        }






        public override void DienActiesIn()
        {
            Groep.CurrentState = new ActieIngediendState(Groep);
        }

        public override void VoegActieToe(Actie actie)
        {
            Groep.Acties().Add(actie);
        }

        public override string ToString()
        {
            return "Motivatie is goedgekeurd, jullie kunnen doorgaan tot actie!";
        }

        public override void VerwijderActie(Actie actie)
        {
            Groep.Acties().Remove(actie);
        }
    }
}
