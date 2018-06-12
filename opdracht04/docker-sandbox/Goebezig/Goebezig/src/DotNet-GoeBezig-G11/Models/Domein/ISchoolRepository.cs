using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public interface ISchoolRepository
    {
        School GetBy(string naam);
        List<School> GetAll();
    }
}
