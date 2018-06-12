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
    public class TaakTest
    {
        private Taak _taak;
        public TaakTest()
        {
            DateTime van = DateTime.Now.AddDays(1);
            DateTime tot = DateTime.Now.AddMonths(5);
            _taak = new Taak("ik", "wat", "bijsturing", It.IsAny<Actie>(), van, tot);
        }

        

        [Fact]
        public void TaakMetFouteData()
        {
            Assert.Throws<ArgumentException>(() => _taak.Van = DateTime.Now.AddMonths(-5));
            Assert.Throws<ArgumentException>(() => _taak.Tot = DateTime.Now.AddDays(-5));
           
        }

        [Fact]
        public void EindDatumVoorStartDatum()
        {
            _taak.Van = DateTime.Now.AddDays(5);
            Assert.Throws<ArgumentException>(() => _taak.Tot = DateTime.Now.AddDays(4));
            
        }
        [Fact]
        public void StartDatumNaEinddatum()
        {
            _taak.Tot = DateTime.Now.AddDays(5);
            Assert.Throws<ArgumentException>(() => _taak.Van = DateTime.Now.AddDays(6));
        }
    }
}
