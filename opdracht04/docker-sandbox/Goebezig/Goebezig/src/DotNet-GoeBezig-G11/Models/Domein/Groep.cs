using System;
using System.Collections.Generic;
using System.Linq;
using DotNet_GoeBezig_G11.Models.Domein.State;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public class Groep
    {
        public int GroepId { get; set; }

        public string Naam { get; set; }

        public bool Open { get; set; }
        public List<Cursist> Cursisten { get; set; }
        public List<Motivatie> Motivaties { get; set; }
        public CurrentState CurrentState { get; set; }

        public List<ActieContainer> ActieContainers { get; set; }



        protected Groep()
        {

        }
        public Groep(string naam)
        {
            Naam = naam;

            Cursisten = new List<Cursist>();
            Motivaties = new List<Motivatie>();
            CurrentState = new StartState(this);
            ActieContainers = new List<ActieContainer>();
        }
        //Constructor voor de testen
        public Groep(string naam, Boolean isopen)
        {
            Naam = naam;
            Open = isopen;
            Cursisten = new List<Cursist>();
            Motivaties = new List<Motivatie>();
            CurrentState = new StartState(this);
            ActieContainers = new List<ActieContainer>();
        }

        public void DienMotivatieIn(Motivatie motivatie)
        {
            CurrentState.DienMotivatieIn(motivatie);
            motivatie.DatumIngediend = DateTime.Now;
            Melding melding = new Melding($"Je groep {Naam} heeft een motiavtie ingediend!");
            VerstuurMeldingNaarAlleCursisten(melding);

        }

        public void VoegCursistToe(Cursist cursist)
        {
            //vragen aan state voor cursist toevoegen
            //currentstate voeg cursist toe illegal argument exception
            //bij states waar een cursist kan toegevoegd worden, deze implementeren
            ControleerMotivatie();

            if (Cursisten.Any(c => c == cursist))
            {
                throw new ArgumentException("Cursist zit al in deze groep");
            }
            if (Cursisten.Count >= 4)
            {
                throw new ArgumentException(
                    "De groep is alreeds volzet");
            }

            cursist.Groep = this;
            Cursisten.ForEach(c => c.Meldingen.Add(new Melding(cursist.Email + " is toegevoegd aan groep " + Naam)));


            cursist.Meldingen.FindAll(c => c.GroepNaam != null).ForEach(x => cursist.Meldingen.Remove(x));



            Cursisten.Add(cursist);
        }

        public void ControleerMotivatie()
        {
            if (Motivaties.Any(c => (bool)c.Goedgekeurd))
            {
                throw new ArgumentException(
                    "U kunt zich niet meer inschrijven in de groep. Motivatie werd alreeds goedgekeurd");
            }

        }



        public Motivatie GeefLaatstIngediendeMotivatie() // laatst afgekeurde of ingediende motivatie
        {
            List<Motivatie> motivaties = new List<Motivatie>();
            foreach (Motivatie m in Motivaties)
            {
              //  if (m.Goedgekeurd == false)
                    motivaties.Add(m);
            }
            return motivaties.OrderBy(c => c.MotivatieId).ToList().Last();
        }

        public Motivatie GeefGoedgekeurdeMotivatie()
        {
            Motivatie motivatie = Motivaties.Find(c => c.Goedgekeurd);
            if (motivatie == null)
            {
                return null;
            }

            return Motivaties.Find(c => c.Goedgekeurd);
        }


        public void VerstuurMeldingNaarAlleCursisten(Melding melding)
        {
            Cursisten.ForEach(c => c.StuurMelding(melding));
        }

        public List<Actie> Acties()
        {
            if (HeeftNieuweContainerNodig())
            {
                ActieContainers.Add(new ActieContainer());
            }
            return ActieContainers.Last().Acties;
        }

        public bool HeeftInTeDienenContainer()
        {
            if (ActieContainers.Count == 0)
            {
                return false;
            }
            return ActieContainers.Any(c => !c.Beoordeeld);
        }

        public List<Actie> GeefActies()
        {
            return Acties().Where(a => a.Datum == null).ToList();
        }
        public List<Actie> GeefEvenementen()
        {
            return Acties().Where(a => a.Datum != null).ToList();
        }
        public void AddContainer(ActieContainer container)
        {
            ActieContainers.Add(container);
        }

        public ActieContainer GeefLaatsteContainer()
        {
            return ActieContainers.Last();
        }

        public bool HeeftNieuweContainerNodig()
        {
            return ActieContainers.Count == 0 || (GeefLaatsteContainer().Beoordeeld && CurrentState.GetType() == typeof(MotivatieGoedgekeurdState));
        }

        public void DienContainerIn()
        {
            if (!GeefLaatsteContainer().HeeftActies())
            {
                throw new ArgumentException("Gelieve eerst acties toe te voegen alvorens in te dienen");
            }
            CurrentState.DienActiesIn();
            //VerstuurMeldingNaarAlleCursisten(new Melding($"De groep {Naam} heeft de acties ingediend!"));
        }
        //Hier de Actiecontainer toevoegen
        public void VoegActieToe(Actie actie)
        {
            if (HeeftNieuweContainerNodig())
            {
                ActieContainers.Add(new ActieContainer());
            }
            CurrentState.VoegActieToe(actie);
            
        }

        public List<Motivatie> GetMotivatiesIngediend()
        {
            List<Motivatie> motivaties = new List<Motivatie>();
            foreach (Motivatie m in Motivaties)
            {
                if(m.DatumIngediend != DateTime.MinValue && !m.Feedback.Equals(""))
                    motivaties.Add(m);
            }
            return  motivaties.OrderBy(c => c.MotivatieId).Reverse().ToList();
        }

        public void VerwijderActie(Actie actie)
        {
            CurrentState.VerwijderActie(actie);
        }

        public void MaakNieuweMotivatie(Organisatie org)
        {
            Motivatie m = new Motivatie();
            m.Organisatie = org;
            Motivaties.Add(m);
        }

        public int GeefStatus()
        {
            Motivatie m = GeefLaatstIngediendeMotivatie();
            if (m.Contactpersonen.Count >= 1)
            {
                return 3;
            }
            if (m.Inhoud != null)
            {
                return 2;
            }
            if (m.Organisatie != null)
            {
                return 1;
            }
            return 0;
        }

        public void VoegTaakToe(Taak taak, int actieid)
        {
            CurrentState.VoegTaakToe(taak,actieid);
        }
    }
}
