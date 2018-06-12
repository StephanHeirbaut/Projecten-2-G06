using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public class Locatie
    {
        public int LocatieId { get; set; }
        public string Straat { get; private set; }
        public int Nummer { get; private set; }
        public string Land { get; private set; }
        public int Postcode { get; private set; }
        public string Stad { get; private set; }

        protected Locatie()
        {
            
        }

        public Locatie(string straat, int nummer, string land, int postcode, string stad)
        {
            Straat = straat;
            Nummer = nummer;
            Land = land;
            Postcode = postcode;
            Stad = stad;
        }
    }
}
