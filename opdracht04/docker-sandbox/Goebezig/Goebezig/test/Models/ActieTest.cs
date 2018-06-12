using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein;
using Moq;
using Xunit;

namespace test.Models
{
    public class ActieTest
    {
       
        public ActieTest()
        {
            
        }

        [Fact]
        public void ActieMetLegeTitel_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Actie("  ","omschrijving"));
            Assert.Throws<ArgumentException>(() => new Actie(null,"oms"));
        }
    }
}
