using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public interface IOrganisatieRepository
    {
        Organisatie GetBy(string naam);
        List<Organisatie> GetAll();

        Contactpersoon GetContactpersonen(string naam, string email);
    }
}
