using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public class Contactpersoon
    {
        

        public int ContactpersoonId { get; private set; }

        public Organisatie Organisatie { get; set; }

        public string Email { get; set; }

        public string Naam { get; set; }

        public string Voornaam { get; set; }

        public string AanspreekTitel { get; set; }

        public string TelefoonNummer { get; set; }

        public string Functie { get; set; }
        
        

        public Contactpersoon( string naam, string voornaam, string email, string aanspreekTitel, string telefoonNummer, string functie)
        {
            
            Naam = naam;
            Voornaam = voornaam;
            Email = email;
            AanspreekTitel = aanspreekTitel;
            TelefoonNummer = telefoonNummer;
            Functie = functie;
        }

        public Contactpersoon(string naam, string voornaam, string email, string aanspreekTitel, string telefoonNummer, string functie,Organisatie organisatie)
        {

            Naam = naam;
            Voornaam = voornaam;
            Email = email;
            AanspreekTitel = aanspreekTitel;
            TelefoonNummer = telefoonNummer;
            Functie = functie;
            Organisatie = organisatie;
        }

        protected Contactpersoon()
        {

        }

    }
}
