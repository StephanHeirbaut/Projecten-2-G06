using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public interface IGroepRepository
    {
        IEnumerable<Groep> GetAll();
        void SaveChanges();
        void AddGroep(Groep groep);

        Groep GetBy(string naam);   

        void UpdateGroep(Groep groep);
    }
}
