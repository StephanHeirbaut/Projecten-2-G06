namespace DotNet_GoeBezig_G11.Models.Domein.State
{
        public class MotivatieIngediendState : CurrentState
        {
            protected MotivatieIngediendState()
            {
            }

            public MotivatieIngediendState(Groep groep) : base(groep)
            {
            }

            public override string ToString()
            {
                return "Motivatie is ingediend, gelieve te wachten op feedback van de lector.";
            }

            public override void VerwijderIngediendeMotivatie(Motivatie motivatie)
            {
                Groep.Motivaties.Remove(motivatie);
                Groep.CurrentState = new StartState(Groep);
            }
        }
}
