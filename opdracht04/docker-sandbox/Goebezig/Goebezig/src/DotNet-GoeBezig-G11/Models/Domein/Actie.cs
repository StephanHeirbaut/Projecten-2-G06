using System;
using System.Collections.Generic;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public class Actie
    {

        private string _omschrijving;
        private string _titel;
        public int ActieId { get; set; }
        public List<Bericht> Bericht { get; set; }
        

        public string Titel
        {
            get { return _titel; }
            set
            {
                if (value == null || value.Trim(' ').Length == 0)
                {
                    throw new ArgumentException("Titel is verplicht!");
                }
                _titel = value;
            }
        }

        public string Omschrijving
        {
            get { return _omschrijving; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Omschrijving is verplicht");
                }
                _omschrijving = value;
            }
        }

        public DateTime? Datum { get; set; }

        public IList<Taak> Taken { get; set; }

        public bool Goedgekeurd { get; set; }
        public bool BerichtAangemaakt { get; set; }
        
        
        protected Actie()
        {

        }

        public Actie(string titel, string omschrijving, DateTime? datum = null)
        {
            Titel = titel;
            Omschrijving = omschrijving;
            Datum = datum;
            Taken = new List<Taak>();
            Goedgekeurd = false;
        }

        public void MaakBericht(Actie actie,string aankodiging)
        {
           
            Bericht = new List<Bericht>() { new Bericht(actie,aankodiging)};
        
           
            BerichtAangemaakt = true;
            
        }

        public override string ToString()
        {
            return Titel;
        }
    }
}
