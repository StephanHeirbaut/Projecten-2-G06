using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public class Melding
    {
        public int MeldingId { get; private set; }
        public bool Gelezen { get; set; }
        public string Inhoud { get; set; }

        public DateTime Datum { get; set; }

        public string GroepNaam { get; set; }

        public User FromUser { get; set; }

        public User ToUser { get; set; }

        protected Melding()
        {
            //Voor database
        }

        public Melding(string inhoud, string groepNaam = null)
        {
            GroepNaam = groepNaam;
            Gelezen = false;
            Inhoud = inhoud;
            Datum = new DateTime();
        }
    }
}
