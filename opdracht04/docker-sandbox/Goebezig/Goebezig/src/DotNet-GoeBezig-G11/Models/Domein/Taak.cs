using System;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public class Taak
    {
        private DateTime? _van;
        private DateTime? _tot;
        public int TaakId { get; set; }
        public string Wie { get; set; }
        public string Wat { get; set; }

        public DateTime? Van
        {
            get { return _van; }
            set
            {
                if (value < DatumCreatie)
                    throw new ArgumentException("Datum kan niet kleiner zijn dan de datum waarop de taak is aangemaakt");
                if(Tot != null && value > Tot)
                    throw new ArgumentException("Einddatum moet na startdatum liggen");
                _van = value;
            }
        }

        public DateTime? Tot
        {
            get
            {
                return _tot;
            }
            set
            {
                if(value < DatumCreatie)
                    throw new ArgumentException("Datum kan niet kleiner zijn dan de datum waarop de taak is aangemaakt");
                if(Van !=null && value < _van)
                    throw new ArgumentException("Einddatum moet na startdatum liggen");
                _tot = value;
            }
        }

        public Niveaus NiveauVanRealisatie { get; set; }
        public string Bijsturing { get; set; }
        public string Feedback { get; set; }
        public DateTime DatumCreatie { get; set; }
        public DateTime? DatumWijziging { get; set; }
        public Actie Actie { get; set; }

        protected Taak()
        {
            
        }

        public Taak(string wie, string wat, string bijsturing, Actie actie, DateTime? van = null, DateTime? tot = null)
        {
            DatumCreatie = DateTime.Now;
            Wie = wie;
            Wat = wat;
            Bijsturing = bijsturing;
            Actie = actie;
            Van = van;
            Tot = tot;
            NiveauVanRealisatie = Niveaus.ToDo;
        }

        public void Wijzig()
        {
            DatumWijziging = DateTime.Now;
        }
    }
}
