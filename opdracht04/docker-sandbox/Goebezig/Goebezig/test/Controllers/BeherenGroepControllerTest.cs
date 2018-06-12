    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using DotNet_GoeBezig_G11.Controllers;
    using DotNet_GoeBezig_G11.Data.Repositories;
    using DotNet_GoeBezig_G11.Models.BeheerGroepViewModels;
using DotNet_GoeBezig_G11.Models.Domein;
using Microsoft.AspNetCore.Mvc;
using Moq;
    using Sakura.AspNetCore;
    using Xunit;

namespace test.Controllers
{
    public class BeherenGroepControllerTest
    {
        private readonly BeherenGroepController _controller;
        private readonly Mock<IGroepRepository> _groepRepository;
        private readonly Mock<ICursistRepository> _cursistRepository;
        private readonly Mock<ISchoolRepository> _schoolRepository;
        private readonly Cursist _cursistZonderOrganisatie;
        private readonly Cursist _cursistMetGroepMetLector;
        private readonly Cursist _cursistMetGroepMetMeldingen;
        private readonly Cursist _cursistZonderGroepMetLector;
        private readonly Cursist _cursistZonderLector;
        private readonly Mock<IMotivatieRepository> _motivatieRepository;
        private readonly School _school;

        public BeherenGroepControllerTest()
        {
            var locatie = new Locatie("a", 2, "Bel", 9000, "Gent");
            _school = new School("Test", "hogeschool@hogent.be", locatie);
            var lector = new Lector("Sebastiaan","Labijn" ,"seba@hogent.be");
            _groepRepository = new Mock<IGroepRepository>();
            _cursistRepository = new Mock<ICursistRepository>();
            _schoolRepository = new Mock<ISchoolRepository>();
            _motivatieRepository = new Mock<IMotivatieRepository>();
            _controller = new BeherenGroepController(_groepRepository.Object,_cursistRepository.Object,_schoolRepository.Object,_motivatieRepository.Object);
            _cursistZonderOrganisatie = new Cursist("Jochem","Van Hespen","jochemvanhespen@hogent.be");
            _cursistZonderLector = new Cursist("Fulvio", "Gentile", "fulviogentile@hogent.be")
            {
                School = _school
            };
            _cursistMetGroepMetMeldingen = new Cursist("Robin","Gammoudi", "robingammoudi@hogent.be")
            {
                Groep = new Groep("TestGroep",false),
                Lector = lector,
                Meldingen = new List<Melding>()
                {
                    new Melding("U bent uitgenodigd", "testgroep2"),
                    new Melding("U bent uitgenodigd","testgroep3"),
                    new Melding("U bent uitgenodigd","testgroep4")
                }

            };
            _cursistMetGroepMetLector = new Cursist("Steve", "Sinaeve", "stevesinaeve@hogent.be")
            {
                Lector = lector,
                Groep = new Groep("TestGroep", false),
                School = _school
            };
            _cursistZonderGroepMetLector = new Cursist("Jochem", "VanHespen", "jochemvanhespen@hogent.be")
            {
                Lector = lector,
                School = _school
            };
        }

        [Fact]
        public void Index_CursistZonderSchool_RedirectNaarToonOrganisaties()
        {
            var result = _controller.Index(_cursistZonderOrganisatie);
            var redirectNaarActionResult = result as RedirectToActionResult;
            Assert.Equal("ToonOrganisaties", redirectNaarActionResult?.ActionName);
        }
        [Fact]
        public void Index_CursistMetGroep_RedirectNaarBekijkGroep()
        {
            var result = _controller.Index(_cursistMetGroepMetLector);
            var redirectNaarActionResult = result as RedirectToActionResult;
            Assert.Equal("BekijkGroep", redirectNaarActionResult?.ActionName);
        }

        [Fact]
        public void Index_CursistGroepNull_RedirectNaarMaakGroep()
        {
            var result = _controller.Index(_cursistZonderGroepMetLector);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.Equal("BevestigGroep", redirectToActionResult?.ActionName);
            //Assert.Null(_cursistZonderGroepMetLector.Groep);
            //Assert.NotNull(_cursistZonderGroepMetLector.Lector);
        }
        [Fact]
        public void Index_CursistZonderLector_ToonIndex()
        {
            
            var result = _controller.Index(_cursistZonderLector);
            var viewResult = result as ViewResult;
            
            Assert.Equal("Index",viewResult?.ViewName);
        }

        [Fact]
        public void BevestigGroep_VoegtGroepToeAanDeViewBag()
        {
            List<Melding> meldingen = _cursistMetGroepMetMeldingen.Meldingen;
            List<Groep> groepen = new List<Groep>();
            meldingen.ForEach(m =>
            {
                groepen.Add(_groepRepository.Object.GetBy(m.GroepNaam));
            });
            var result = _controller.BevestigGroep(_cursistMetGroepMetMeldingen);
            var viewResult = result as ViewResult;
            Assert.Equal(groepen.Count, ((List<Groep>)viewResult?.ViewData["groep"])?.Count);
        }

        [Fact]
        public void MaakGroep_VoegtGroepToeAanRepository()
        {

            BewerkGroepViewModel model = new BewerkGroepViewModel()
            {
                Naam = "TestGroep",
            };
            Groep groep = new Groep(model.Naam);
            var result = _controller.MaakGroep(_cursistZonderGroepMetLector, model);
            var redirectToActionResult = result as RedirectToActionResult;
            _groepRepository.Object.AddGroep(groep);
            Assert.Equal("ToonLeden", redirectToActionResult?.ActionName);
            _groepRepository.Verify(g => g.AddGroep(groep), Times.Once);
            _groepRepository.Verify(g => g.SaveChanges(), Times.AtLeastOnce);

        }

        [Fact]
        public void BekijkGroep_VoegtGroepVanCursistToeAanViewbag()
        {
            var result = _controller.BekijkGroep(_cursistMetGroepMetLector);
            var viewresult = result as ViewResult;
            var groep = _cursistMetGroepMetLector.Groep;
            Assert.Equal(groep, viewresult?.ViewData["Groep"]);
        }

        [Fact]
        public void BekijkGroep_ToontBekijkGroepView()
        {
            var result = _controller.BekijkGroep(_cursistMetGroepMetLector);
            var viewresult = result as ViewResult;
            Assert.Equal("Overzicht", viewresult?.ViewName);
        }

        [Fact]
        public void ToonLeden_ToontBewerkGroepView()
        {
            var result = _controller.ToonLeden(_cursistMetGroepMetLector);
            var viewresult = result as ViewResult;
            Assert.Equal("BewerkGroep",viewresult?.ViewName);
        }

        [Fact]
        public void AccepteerGroep()
        {
            var cursist = new Cursist("Fulvio", "Gentile","fulvio@hogent.be");
            var cursist1 = new Cursist("Test","Gebruiker","Test@hogent.be");
            var groep = new Groep("Test");
            _groepRepository.Setup(r => r.GetBy("Test")).Returns(groep);
            _cursistRepository.Setup(r => r.GetBy("fulvio@hogent.be")).Returns(cursist);
            _cursistRepository.Setup(r => r.GetBy("Test@hogent.be")).Returns(cursist1);
            var controller = new BeherenGroepController(_groepRepository.Object,_cursistRepository.Object,It.IsAny<SchoolRepository>(),_motivatieRepository.Object);
            cursist1.Groep = groep;
            groep.Cursisten.Add(cursist1);
            cursist.NodigUitVoorGroep(cursist1.Email,groep.Naam);
            var model = new AccepteerGroepViewModel();
            model.GroepNaam = "Test";
            controller.AccepteerGroep(cursist, model);
            Assert.Equal(groep, cursist.Groep);
            Assert.Equal(false,cursist.Meldingen.Any( c => c.GroepNaam!=null));

        }
        [Fact]
        public void WeigerGroep()
        {
            var cursist = new Cursist("Fulvio", "Gentile", "fulvio@hogent.be");
            var cursist1 = new Cursist("Test", "Gebruiker", "Test@hogent.be");
            var groep = new Groep("Test");
            _groepRepository.Setup(r => r.GetBy("Test")).Returns(groep);
            _cursistRepository.Setup(r => r.GetBy("fulvio@hogent.be")).Returns(cursist);
            _cursistRepository.Setup(r => r.GetBy("Test@hogent.be")).Returns(cursist1);
            var controller = new BeherenGroepController(_groepRepository.Object, _cursistRepository.Object, It.IsAny<SchoolRepository>(), _motivatieRepository.Object);
            cursist1.Groep = groep;
            groep.Cursisten.Add(cursist1);
            cursist.NodigUitVoorGroep(cursist1.Email, groep.Naam);
            var model = new AccepteerGroepViewModel();
            var melding = cursist.Meldingen.Find(c => c.GroepNaam == groep.Naam);
            model.GroepNaam = "Test";
            controller.WeigerGroep(cursist, model);
            Assert.Equal(false, cursist.Meldingen.Any( c => c==melding));

        }

        [Fact]
        public void ToonOrganisaties_sortOrderSorteertScholen()
        {
            var locatie = new Locatie("teststaart",33,"belgie",9240,"zele");
            

            List<School> scholen = new List<School>()
            {
                new School("CCCC", "CCCC@school.be", locatie),
                new School("AAAA", "AAA@school.be", locatie),
                new School("BBBB", "BBBB@school.be", locatie),
                
            };

            _schoolRepository.Setup(s => s.GetAll()).Returns(scholen);

            var result = _controller.ToonOrganisaties(_cursistMetGroepMetMeldingen, "name_desc", null, null, 1);
            var viewResult = result as ViewResult;

            List<School> resultaat = viewResult?.Model as List<School>;

            Assert.NotEqual(resultaat,scholen);
        }

        [Fact]
        public void ToonOrganisaties_ReturntToonOrganisatiesView()
        {
            var locatie = new Locatie("teststaart", 33, "belgie", 9240, "zele");


            List<School> scholen = new List<School>()
            {
                new School("CCCC", "CCCC@school.be", locatie),
                new School("AAAA", "AAA@school.be", locatie),
                new School("BBBB", "BBBB@school.be", locatie),

            };

            _schoolRepository.Setup(s => s.GetAll()).Returns(scholen);
            var result = _controller.ToonOrganisaties(_cursistMetGroepMetMeldingen, null, null, null, 1);
            var viewResult = result as ViewResult;
            Assert.Equal("ToonOrganisaties",viewResult?.ViewName);
        }
        //[Fact]
        //public void ToonLijstVanUitgenodigdenVoorGroep()
        //{
        //    Groep groep = new Groep("G11");
        //    Cursist cursist10 = new Cursist("Steve", "Sinaeve", "Steve_Sinaeve@hogent.be");
        //    Cursist cursist20 = new Cursist("Test", "Testen", "Test@hogent.be");
        //    groep.VoegCursistToe(cursist10);

        //    Melding melding = new Melding("U bent uitgenodigd voor een groep", cursist10.Groep.Naam);
        //    Cursist cursist3 = new Cursist("Test", "Testen", "Test@hogent.be");
        //    cursist3.Meldingen.Add(melding);
        //    List<Cursist> lijsten = new List<Cursist>();
        //    lijsten.Add(cursist3);

        //    _groepRepository.Setup(r => r.GetBy("G11")).Returns(groep);
        //    _cursistRepository.Setup(r => r.GetBy("Steve_Sinaeve@hogent.be")).Returns(cursist10);
        //    _cursistRepository.Setup(r => r.GetBy("Test@hogent.be")).Returns(cursist20);
        //    //_cursistRepository.Setup(r => r.GetAll()).Returns(new List<Cursist>() {cursist10, cursist20});
        //    var controller = new BeherenGroepController(_groepRepository.Object, _cursistRepository.Object, _schoolRepository.Object, _motivatieRepository.Object);
        //    cursist20.NodigUitVoorGroep(cursist10.Email, cursist10.Groep.Naam);
        //   // Assert.Equal(cursist10.Groep.Naam,_cursistRepository.Object.GetBy("Test@hogent.be").Meldingen[0].GroepNaam); --> Dit klopt!
        //    var all = _cursistRepository.Object.GetAll();
        //    //var uitg = _cursistRepository.Object.GeefUitgenodigden(cursist10);
        //    var ar = controller.ToonLeden(cursist10) as ViewResult;
        //    Assert.Equal(lijsten, ar?.ViewData["Uitgenodigd"]);
        //}
    }
}
