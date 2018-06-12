using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public class Organisatie
    {
        public int OrganisatieId { get; set; }

        public string Email { get; set; }

        public string Naam { get; set; }

        
        public string Type { get; set; }
        public Locatie Locatie { get; private set; }

        public bool HeeftLabel { get; set; }

        public List<Contactpersoon> Contactpersonen { get; set; }

        protected Organisatie()
        {
            
        }
        public Organisatie(string naam, string email, Locatie locatie, string type)
        {
            Naam = naam;
            Email = email;
            Locatie = locatie;
            Type = type;
            HeeftLabel = false;
            Contactpersonen = new List<Contactpersoon>();
        }
        public Organisatie(string naam, string email, Locatie locatie)
        {
            Naam = naam;
            Email = email;
            Locatie = locatie;
            HeeftLabel = false;
            Contactpersonen = new List<Contactpersoon>();
        }

        public bool HeeftContactpersonen()
        {
            if (Contactpersonen.Count > 0)
            {
                return true;
            }
            return false;
        }

    }

    
}
