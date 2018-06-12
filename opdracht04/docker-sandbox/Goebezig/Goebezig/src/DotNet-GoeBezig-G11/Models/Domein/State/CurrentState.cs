using System;

namespace DotNet_GoeBezig_G11.Models.Domein.State
{
    public abstract class CurrentState
    {
        public  Groep Groep { get; set; }
        public int CurrentStateId { get; set; }

        public int ForeignKeyGroep { get; set; }

        protected CurrentState()
        {

        }

        protected CurrentState(Groep groep)
        {
               Groep = groep;
        }

        public virtual void DienMotivatieIn(Motivatie motivatie)
        {
            // Dit throwen ipv IllegalStateException
            throw new InvalidOperationException("Er kan momenteel geen motivatie ingediend worden");
        }

        public virtual void VerwijderIngediendeMotivatie(Motivatie motivatie)
        {
            throw new InvalidOperationException("Er kan momenteel geen motivatie verwijderd worden");
        }

        public virtual void DienActiesIn()
        {
            throw new InvalidOperationException("Uw groep kan momenteel geen acties indienen");
        }

        


        public virtual void VoegActieToe(Actie actie)
        {
            throw new InvalidOperationException("Er kunnen geen acties toegevoegd worden");
        }

        public virtual void VerwijderActie(Actie actie)
        {
            throw new InvalidOperationException("U kan momenteel geen acties verwijderen");
        }

        public virtual void VoegTaakToe(Taak taak, int actieId)
        {
            throw new InvalidOperationException("U kan momenteel geen taken toevoegen");
        }
    }
}
