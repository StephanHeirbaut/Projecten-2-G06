using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public interface ICursistRepository
    {
        Cursist GetBy(string email);
        IEnumerable<Cursist> GetAll();
        void SaveChanges();
        void AddCursist(Cursist cursist);

        void UpdateCursist(Cursist cursist);

        IList<Cursist> GeefUitgenodigden(Cursist cursist);
    }
}
