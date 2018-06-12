using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public interface IBerichtRepository
    {
        Bericht GetBy(int id);
        void AddBericht(Bericht bericht);
        void SaveChanges();
        List<Bericht> GetAll();
    }
}
