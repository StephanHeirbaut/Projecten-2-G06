using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public class Motivatie
    {
        public int MotivatieId { get; set; }
        private string _inhoud;
        private string _feedback;

        private Organisatie _organisatie;
       
       
       
        public bool BerichtAangemaakt { get; set; }
        public Bericht Bericht { get; set; }


        public string Inhoud
        {
            get
            {
                return _inhoud;
            }
            set
            {
                int woorden = value.Split(' ').Length;
                if (woorden < 100 || woorden > 250)
                {
                    throw new ArgumentException("Motivatie mag tussen de 100 en 250 woorden bevatten");
                }
                _inhoud = value;
            }
        }

        public string Feedback
        {
            get
            {
                if (_feedback == null)
                {
                    return "";
                }
                return _feedback;
            }
            set { _feedback = value; }
        }

        public DateTime DatumIngediend { get; set; }
        public bool Goedgekeurd { get; set; }

        

        public List<Contactpersoon> Contactpersonen { get; set; }

        public Organisatie Organisatie
        {
            get { return _organisatie; }
            set
            {
                if (value.HeeftLabel)
                {
                    throw new ArgumentException("Organisatie is al in het bezit van een label, kies een andere organisatie");
                }
                if (!value.HeeftContactpersonen())
                {
                    throw new ArgumentException("Deze organisatie heeft geen contactpersonen, kies een andere organisatie");
                }
                _organisatie = value;
            }
        }



        //public string 
        public Motivatie()
        {
            //Database
            

        }

        public Motivatie(string inhoud)
        {
            Inhoud = inhoud;
            Goedgekeurd = false;
            Feedback = "";
            Contactpersonen = new List<Contactpersoon>();
           
        }
        public Motivatie(string inhoud, Organisatie organisatie)
        {
            Inhoud = inhoud;
            Feedback = "";
            Goedgekeurd = false;
            Organisatie = organisatie;
            BerichtAangemaakt = false;
            Contactpersonen = new List<Contactpersoon>();
        }

        public bool MagIngediendWorden()
        {
            return !(Organisatie == null || Inhoud == null || Contactpersonen.Count == 0);
        }

        public void MaakBericht(Motivatie motivatie)
        {
            
            Bericht = new Bericht(motivatie);
            BerichtAangemaakt = true;
           
        }

        public void DienMotivatieIn(Groep groep)
        {
            DatumIngediend = DateTime.Now;
            groep.CurrentState.DienMotivatieIn(this);
        }

        public void VerwijderContactpersonen()
        {
            Contactpersonen = new List<Contactpersoon>();
        }
    }
}
