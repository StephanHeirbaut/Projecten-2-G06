using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public class Lector : User
    {



        public IList<Cursist> Cursisten { get; set; }

        protected Lector()
        {

        }

        public Lector(string naam, string voornaam, string email) : base(naam, voornaam, email)
        {

            Cursisten = new List<Cursist>();
        }
    }
}
