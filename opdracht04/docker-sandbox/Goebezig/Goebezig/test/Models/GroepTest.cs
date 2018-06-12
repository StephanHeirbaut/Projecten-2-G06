using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Controllers;
using DotNet_GoeBezig_G11.Data;
using DotNet_GoeBezig_G11.Data.Repositories;
using DotNet_GoeBezig_G11.Models.BeheerGroepViewModels;
using DotNet_GoeBezig_G11.Models.Domein;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace test.Models
{
    public class GroepTest
    {
        //private Mock<IGroepRepository> _groepRepository;
        //private Mock<ICursistRepository> _cursistRepository;
        //private Mock<ISchoolRepository> _schoolRepository;
        //private BeherenGroepController _controller;
        //public GroepTest()
        //{
        //    _groepRepository = new Mock<IGroepRepository>();
        //    _cursistRepository = new Mock<ICursistRepository>();
        //    _controller = new BeherenGroepController(_groepRepository.Object, _cursistRepository.Object,_schoolRepository.Object);
        //}
        //[Fact]
        //public void MaakGroepMetBestaandeNaam()
        //{

        //    _controller.ModelState.AddModelError("","Naam is in gebruik");
        //    _controller.MaakGroep(It.IsAny<Cursist>());
        //    _groepRepository.Verify(c => c.AddGroep(It.IsAny<Groep>()),Times.Never);
        //    _groepRepository.Verify(c => c.SaveChanges(),Times.Never);



        //}

        private Locatie locatie;
        private School school;
        private Cursist cursist, cursist1, cursist2, cursist3,cursist4,cursist5, cursist6;
        private Groep groep,groep1;
        private Motivatie motivatie, motivatie1;

        public GroepTest()
        {
            locatie = new Locatie("a", 2, "Bel", 9000, "Gent");
            school = school = new School("Test", "hogeschool@hogent.be", locatie);

            groep = new Groep("groep1", false);
            groep1 = new Groep("blablabla", false);

            cursist1 = new Cursist("Steve", "Sinaeve", "steve@hogent.be");
            cursist6 = new Cursist("test", "testen", "bsdqflkhq@hogent.be");

            Melding melding = new Melding("U bent uitgenodigd",groep.Naam);
            cursist6.Meldingen.Add(melding);

            cursist  = new Cursist("Jochem", "Van Hespen", "jochemvanhespen@hogent.be");
            groep.VoegCursistToe(cursist);

            cursist2 = new Cursist("Jochem", "Van Hespen", "jochem@hogent.be");
            cursist3 = new Cursist("Jochem", "Van Hespen", "vanhespen@hogent.be");
            cursist4 = new Cursist("Jochem", "Van Hespen", "jon@hogent.be");
            cursist5 = new Cursist("Jochem", "Van Hespen", "j@hogent.be");
            groep1.VoegCursistToe(cursist2);
            groep1.VoegCursistToe(cursist3);
            groep1.VoegCursistToe(cursist4);
            groep1.VoegCursistToe(cursist5);
            Locatie locatie5 = new Locatie("Poortstraat", 52, "België", 8820, "Torhout");

            Organisatie org2 = new Organisatie("SK Torhout", "info@sk.be", locatie5, "iets");
            org2.Contactpersonen.Add(It.IsAny<Contactpersoon>());
            String inhoudMotivatie =
                "ok ok ok ok ok ok  kook ok ok o kok ok ok o kok o ko kook ok ok o kok ok ok o kok o ko kook ok ok o kok ok ok o kok o ko kook ok ok o kok ok ok o kok o ko ko ko ko ko k ok ok ok o k ok ok ok o ko k ok okk ok ok ok o ko k ok okk ok ok ok o ko k ok okk ok ok ok o ko k ok okk ok ok ok o ko k ok okk ok ok ok o ko k ok okk ok ok ok o ko k ok okk ok ok ok o ko k ok okk ok ok ok o ko k ok ok ok o k";
            motivatie = new Motivatie(inhoudMotivatie, org2);
            motivatie1 = new Motivatie(inhoudMotivatie, org2);
            


        }

        [Fact]
        public void LedenToevoegenMetGoedgekeurdeMotivatie()
        {
            
            motivatie.Goedgekeurd = true;

            groep.Motivaties.Add(motivatie);
            Assert.Throws<ArgumentException>(() => groep.VoegCursistToe(cursist1));
        }

        [Fact]
        public void LedenToevoegenMetMaximumAantalLeden()
        {
            motivatie1.Goedgekeurd = false;
            groep1.Motivaties.Add(motivatie1);
            Assert.Throws<ArgumentException>(() => groep1.VoegCursistToe(cursist1));
        }


        [Fact]
        public void LedenToevoegenSuccesvol()
        {
            motivatie.Goedgekeurd = false;
            groep.Motivaties.Add(motivatie);
            groep.VoegCursistToe(cursist6);
            Assert.Equal(groep.Cursisten.Count, 2);
        }

        [Fact]
        public void LedenUitnodigenVoorGroep()
        {
            Assert.Equal(cursist.Meldingen.Count,0);
            motivatie.Goedgekeurd = false;
            groep.Motivaties.Add(motivatie);
            groep.VoegCursistToe(cursist6);
            Assert.Equal(cursist6.Meldingen.Count,0);
            Assert.Equal(cursist.Meldingen.Count,1);
        }
    }
}
