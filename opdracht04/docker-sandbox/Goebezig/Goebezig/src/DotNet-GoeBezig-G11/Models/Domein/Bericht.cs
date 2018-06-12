using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public class Bericht
    {
        public int BerichtId { get; set; }
       
        public Motivatie Motivatie{get;set;}

        public Actie Actie { get; set; }

        public string Aankondiging { get; set; }
        


        public Bericht(Motivatie motivatie)
        {
            Motivatie = motivatie;
            Aankondiging = string.Format(motivatie.Organisatie.Naam + " heeft het Goed Bezig label gekregen!");
            
        }

        public Bericht(Actie actie,string aankondiging)
        {
            Actie = actie;
            //if (actie.Datum != null)
          //      Aankondiging = string.Format(actie.Titel + "vindt plaats op" + actie.Datum+"iedereen is welkom!");
          //  Aankondiging = string.Format(actie.Titel +"wordt georganiseerd!");
            Aankondiging = aankondiging;
        }
        public Bericht(string s)
        {
            
            Aankondiging = s;
           
        }

        protected Bericht()
        {
            
        }

    }
}