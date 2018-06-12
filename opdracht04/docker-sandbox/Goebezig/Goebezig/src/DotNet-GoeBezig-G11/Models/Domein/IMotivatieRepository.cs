using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public abstract class IMotivatieRepository
    {


        public abstract List<Motivatie> GetAll();
        public abstract void AddMotivatie(Motivatie motivatie);

        public abstract void UpdateMotivatie(Motivatie motivatie);

        public abstract void DeleteMotivatie(Motivatie motivatie);
        public abstract void SaveChanges();
    }
}
