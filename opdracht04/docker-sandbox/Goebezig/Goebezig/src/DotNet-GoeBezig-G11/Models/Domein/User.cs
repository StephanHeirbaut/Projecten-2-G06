using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public abstract class User
    {
        private string _naam;

        private string _voornaam;

        public List<Melding> Meldingen { get; set; }
        public int UserId { get; set; }
        public string Naam
        {
            get { return _naam; }
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException("Naam mag niet leeg zijn!");
                _naam = value;
            }
        }

        public string Voornaam
        {
            get
            {
                return _voornaam;
            }
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException("Voornaam mag niet leeg zijn!");
                _voornaam = value;
            }
        }

        public string Email { get; set; }

        protected User()
        {
            //Database
        }
        protected User( string naam, string voornaam, string email)
        {
                
            Naam = naam;
            Voornaam = voornaam;
            Email = email;
        }
    }
}
