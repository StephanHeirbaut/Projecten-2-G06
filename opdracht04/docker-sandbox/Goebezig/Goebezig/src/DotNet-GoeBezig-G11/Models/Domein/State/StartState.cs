using System;

namespace DotNet_GoeBezig_G11.Models.Domein.State
{
    public class StartState : CurrentState
    {
        protected StartState()
        {

        }

        public StartState(Groep groep) : base(groep)
        {

        }

        public override string ToString()
        {
            return "Begin met een motivatie in te dienen";
        }

        public override void DienMotivatieIn(Motivatie motivatie)
        {
            if (!motivatie.MagIngediendWorden())
            {
                throw new ArgumentException("Alle velden moeten ingevuld zijn");
            }
            Groep.Motivaties.Add(motivatie);
            Groep.CurrentState = new MotivatieIngediendState(Groep);
        }
    }
}
