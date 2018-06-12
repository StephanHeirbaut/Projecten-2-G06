using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public interface IActieContainerRepository
    {
        void AddContainer(ActieContainer actieContainer);
        List<ActieContainer> GetAll();
        void UpdateContainer(ActieContainer actieContainer);

        void SaveChanges();
    }
}
