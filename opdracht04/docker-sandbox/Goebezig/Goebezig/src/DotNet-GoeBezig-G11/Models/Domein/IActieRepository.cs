using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public interface IActieRepository
    {
        void AddActie(Actie actie);
        void UpdateActie(Actie actie);
        void SaveChanges();

        List<Actie> GeefAlles();
        List<Actie> GeeActies();

        List<Actie> GeefEvenementen();

        void DeleteActie(Actie actie);

        Actie GetById(int id);

        Actie GeefActie(int i);

        void VerwijderActie(Actie actie);


    }
}
