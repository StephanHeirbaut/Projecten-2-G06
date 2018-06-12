using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Utilities.Encoders;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public class School : Organisatie
    {
        //public int SchoolId { get; set; }
        //public string Naam { get; private set; }

        //public string Email { get; private set; }
        //public Locatie Locatie { get; private set; }
        public List<Cursist> Cursisten { get; set; }

        public bool IsOpen { get; set; }
        

        public string WeergaveString => $"{Naam} - {Locatie.Stad}";


        protected School() : base()
        {
        }

        public School(string naam, string email, Locatie locatie) : base(naam, email, locatie)
        {

            //Naam = naam;
            //Email = email;
            //Locatie = locatie;
            IsOpen = false;
            Cursisten = new List<Cursist>();

        }


    }
}