using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public class ActieContainer
    {

        public int ContainerId { get; set; }
        public List<Actie> Acties { get; set; }

        public bool Beoordeeld { get; set; } = false;



        public ActieContainer()
        {

            Acties = new List<Actie>();
        }

        public void VoegActieToe(Actie actie)
        {
            Acties.Add(actie);
        }



        public bool HeeftActies()
        {
            return Acties.Count > 0;
        }

        
    }
}
