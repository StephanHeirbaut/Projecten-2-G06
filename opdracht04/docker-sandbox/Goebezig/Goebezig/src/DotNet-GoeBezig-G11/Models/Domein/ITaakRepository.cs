using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein.State;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public interface ITaakRepository
    {
        Taak GetBy(int id);

        List<Taak> GetAll();

        void SaveChanges();

        void Delete(Taak taak);
    }
}
