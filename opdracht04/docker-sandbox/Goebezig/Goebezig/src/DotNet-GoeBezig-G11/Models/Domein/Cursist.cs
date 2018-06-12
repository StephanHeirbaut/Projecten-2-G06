using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MimeKit;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public class Cursist : User
    {
       

        private School _school;
        private Groep _groep;




        public School School
        {
            get { return _school;}
            set
            {
                string eindemail = Email.Split('@')[1].ToLower();
                if (!value.Email.ToLower().Contains(eindemail))
                {
                    throw new ArgumentException("E-mail extensie moet overeenkomen met die van de organisatie");
                }
                //value.Cursisten.Add(this);
                _school = value;
            }
        }

        public Lector Lector { get; set; }

        public Groep Groep
        {
            get { return _groep;}
            set
            {
                //if (_groep != null)
                //{
                //    throw new ArgumentException("Cursist is al ingeschreven in een groep");
                //}
                _groep = value;
            }
        }

        




        protected Cursist()
        {

        }

        public Cursist(string voornaam, string naam, string email  /*, Groep groep = null*/) : base(naam,voornaam,email)
        {
        
            
            //Groep = groep;
            Meldingen = new List<Melding>();
            
        }


        public string GetEmailExtensie()
        {
            string[] emailStrings = Email.ToLower().Split('@');
            return emailStrings[1];
        }

        public void NodigUitVoorGroep(string email, string naam)
        {
            if (Meldingen.Any(c => c.GroepNaam == naam))
            {
                throw new ArgumentException(Email + " is al uitgenodigd voor deze groep");
            }
            if (Groep != null)
            {
                throw new ArgumentException(Email +" zit al in groep: " + Groep.Naam + ". Deze cursist kan niet uitgenodig worden");
            }
            if (!GetEmailExtensie().Contains(email.ToLower().Split('@')[1]))
            {
                throw new ArgumentException("Extensie moet dezelfde zijn voor iedereen in de groep");
            }

            string message = "U bent uitgenodigd voor groep " + naam;
            string sub = "Uitnodiging voor groep " + naam;

            Meldingen.Add(new Melding("U bent uitgenodigd voor een groep", naam));
        }

        public bool IsUitgenodigd()
        {
            foreach (Melding melding in Meldingen)
            {
                return melding.Inhoud.Contains("U bent uitgenodigd voor een groep");
            }
            return false;
        }

        public string GroepsnaamMelding()
        {
            foreach (Melding melding in Meldingen)
            {
                if (melding.GroepNaam != null)
                {
                    return melding.GroepNaam;
                }
            }

            return null;
        }

        public void DienMotivatieIn(Motivatie motivatie)
        {
            if (Groep == null)
            {
                throw new ArgumentException($"{Naam} {Voornaam} u bent nog niet ingeschreven in een groep");
            }
            Groep.DienMotivatieIn(motivatie);
        }

        public void StuurMelding(Melding melding)
        {
            Meldingen.Add(melding);
        }

        public IEnumerable<Organisatie> SorteerOrganisaties(IEnumerable<Organisatie> schools, string sortOrder)
        {
            switch (sortOrder)
            {
                case "name_desc":
                    return schools.OrderByDescending(s => s.Naam);
                case "email":
                    return schools.OrderBy(s => s.Email);
                case "email_desc":
                    return schools.OrderByDescending(s => s.Email);
                default:
                    return schools.OrderBy(s => s.Naam);
            }
        }

        public bool HeeftGroep()
        {
            return Groep != null;
        }

        public void MaakNieuweMotivatie()
        {
            Groep.Motivaties.Add(new Motivatie());
        }

        public void VoegTaakToe(Taak taak, int actieid)
        {
            Groep.VoegTaakToe(taak,actieid);
        }
    }
}
