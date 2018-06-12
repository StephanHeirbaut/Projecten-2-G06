using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Models.Domein;
using Moq;
using Xunit;

namespace test.Models
{
    public class MotivatieTest
    {
        private Motivatie _motivatie;
        private string _goeieMotivatieString;
        private string _langeMotivatieString;
        private Organisatie _organisatie;
        private Contactpersoon _contactpersoon;
        public MotivatieTest()
        {
            _goeieMotivatieString = "ok ok ok ok ok ok  kook ok ok o kok ok ok o kok o ko kook ok ok o kok ok ok o kok o ko kook ok ok o kok ok ok o kok o ko kook ok ok o kok ok ok o kok o ko ko ko ko ko k ok ok ok o k ok ok ok o ko k ok okk ok ok ok o ko k ok okk ok ok ok o ko k ok okk ok ok ok o ko k ok okk ok ok ok o ko k ok okk ok ok ok o ko k ok okk ok ok ok o ko k ok okk ok ok ok o ko k ok okk ok ok ok o ko k ok ok ok o k";
            _langeMotivatieString = $"{_goeieMotivatieString} {_goeieMotivatieString}";
            _contactpersoon = It.IsAny<Contactpersoon>();
            _organisatie = new Organisatie("Test","test@hogent.be", It.IsAny<Locatie>());
            _organisatie.Contactpersonen.Add(_contactpersoon);
            //_organisatie.Contactpersonen.Add(_contactpersoon);
        }

        [Fact]
        public void MotivatieTeKortOfTeLang_ArgumentException()
        {
            
            Assert.Throws<ArgumentException>(() => new Motivatie("te kort", _organisatie));
            Assert.Throws<ArgumentException>(() => new Motivatie(_langeMotivatieString, _organisatie));
        }
        [Fact]
        public void MotivatieMetOrganisatieZonderContactperonen_ArgumentException()
        {
            _organisatie.Contactpersonen.Clear();
            Assert.Throws<ArgumentException>(() => new Motivatie(_goeieMotivatieString, _organisatie));
        }

        [Fact]
        public void JuisteMotivatie()
        {
            _motivatie = new Motivatie(_goeieMotivatieString, _organisatie);
        }
    }
}
