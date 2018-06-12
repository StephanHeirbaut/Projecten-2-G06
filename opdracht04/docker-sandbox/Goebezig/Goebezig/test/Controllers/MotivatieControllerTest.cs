using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Controllers;
using DotNet_GoeBezig_G11.Models.Domein;
using DotNet_GoeBezig_G11.Models.Domein.State;
using DotNet_GoeBezig_G11.Models.MotivatieViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace test.Controllers
{
    public class MotivatieControllerTest
    {
        private readonly MotivatieController _controller;
        private readonly Mock<IGroepRepository> _groepRepository;
        private readonly Mock<ICursistRepository> _cursistRepository;
        private readonly Mock<ISchoolRepository> _schoolRepository;
        private readonly Mock<IOrganisatieRepository> _organisatieRepository;
        private readonly Mock<IBerichtRepository> _berichtRopository;
        private readonly Cursist _cursistZonderOrganisatie;
        private readonly Cursist _cursistMetGroepMetLector;
        private readonly Cursist _cursistMetGroepMetMeldingen;
        private readonly Cursist _cursistMetGroepMetMotivatieGoedgekeurd;
        private readonly Cursist _cursistZonderGroepMetLector;
        private readonly Cursist _cursistZonderLector;
        private readonly School _school;
        private Mock<IMotivatieRepository> _motivatieRopistory;
        private List<Organisatie> _organisaties;
        private Organisatie _organisatie;

        public MotivatieControllerTest()
        {
            var locatie = new Locatie("a", 2, "Bel", 9000, "Gent");
            _organisaties = new List<Organisatie>()
            {
                new Organisatie("organisatie1","organisatie1@test.be",locatie,"test")
                {
                    Contactpersonen = new List<Contactpersoon>()
                    {
                        new Contactpersoon(It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>()),
                        new Contactpersoon(It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>()),
                        new Contactpersoon(It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>()),

                    }
                },
                new Organisatie("organisatie2","organisatie2@test.be",locatie,"test")
                {
                    Contactpersonen = new List<Contactpersoon>()
                    {
                        new Contactpersoon(It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>()),
                        new Contactpersoon(It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>()),
                        new Contactpersoon(It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>()),

                    }
                },
                new Organisatie("organisatie3","organisatie3@test.be",locatie,"test")
                {
                    Contactpersonen = new List<Contactpersoon>()
                    {
                        new Contactpersoon(It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>()),
                        new Contactpersoon(It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>()),
                        new Contactpersoon(It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>()),

                    }
                }
            };
            _organisatie = new Organisatie("organisatie4","organisatie4@test.be",locatie,"test")
            {
                Contactpersonen = new List<Contactpersoon>()
                    {
                        new Contactpersoon(It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>()),
                        new Contactpersoon(It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>()),
                        new Contactpersoon(It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>(),It.IsAny<String>()),

                    }
            };
            var lector = new Lector("Sebastiaan", "Labijn", "seba@hogent.be");
            _school = new School("hogeschool", "hogeschool@hogent.be", locatie);
            _groepRepository = new Mock<IGroepRepository>();
            _cursistRepository = new Mock<ICursistRepository>();
            _schoolRepository = new Mock<ISchoolRepository>();
            _organisatieRepository = new Mock<IOrganisatieRepository>();
            _motivatieRopistory = new Mock<IMotivatieRepository>();
            _berichtRopository = new Mock<IBerichtRepository>();
            _controller = new MotivatieController(_berichtRopository.Object,_organisatieRepository.Object,_motivatieRopistory.Object);
            _cursistZonderOrganisatie = new Cursist("Jochem", "Van Hespen", "jochemvanhespen@hogent.be");
            _cursistZonderLector = new Cursist("Fulvio", "Gentile", "fulviogentile@hogent.be");
            var groep = new Groep("TestGroep", false);
            groep.Motivaties.Add(new Motivatie());

            Groep g = new Groep("Groepje");
            var org = new Organisatie("TestOrg", "testmail@test.be", new Locatie("s", 1, "be", 8800, "se"));
            var cp1 = new Contactpersoon("jan", "janssen", "janjans@tz.be", "meneer", "050222222", "ceo");
          
            Motivatie m = new Motivatie("Wij hebben deze jeudgwerking gekozen omdat de jeudgtrainers zich elke dag inzetten voor hun spelertjes.Ze streven om een familiale sportclub te zijn waar hun spelers zich thuis voelen en uitgedaagd worden om op een faire manier voetbal te spelen én zich in deze sport steeds verder te ontwikkelen. Ze dragen RESPECT hoog in het vaandel, en dit niet alleen tegenover elkaar, de tegenstrever en alle betrokken partijen (scheidsrechter, begeleiders, ouders,…), maar ook voor het materiaal en de infrastructuur. Door hun inzet en missie vinden wij dat ze goed bezig zijn. Daarom hebben we deze organisatie gekozen om aan hen het goed bezig label te schenken.") {Goedgekeurd = true };
            var cp = new Contactpersoon("jan", "janssen", "janjans@tz.be", "meneer", "050222222", "ceo",org);
            m.Contactpersonen.Add(cp);
            org.Contactpersonen.Add(cp1);
            m.Organisatie = org;
            org.Contactpersonen.Add(cp);
            
            g.Motivaties.Add(m);
            g.GeefLaatstIngediendeMotivatie().Organisatie = org;


            _cursistMetGroepMetMeldingen = new Cursist("Robin", "Gammoudi", "robingammoudi@hogent.be")
            {
                Groep = new Groep("testgroep2", true),
                Lector = lector,
                Meldingen = new List<Melding>()
                {
                    new Melding("U bent uitgenodigd", "testgroep2"),
                    new Melding("U bent uitgenodigd","testgroep3"),
                    new Melding("U bent uitgenodigd","testgroep4")
                }

            };
            _cursistMetGroepMetMeldingen.Groep.VoegCursistToe(_cursistZonderOrganisatie);
            
            _cursistMetGroepMetLector = new Cursist("Steve", "Sinaeve", "stevesinaeve@hogent.be")
            {
                School = _school,
                Lector = lector,
                Groep = groep
            };
            _cursistZonderGroepMetLector = new Cursist("Jochem", "VanHespen", "jochemvanhespen@hogent.be")
            {
                Lector = lector
            };
            _cursistMetGroepMetMotivatieGoedgekeurd = new Cursist("Robin", "Gammoudi", "robingammoudi@hogent.be")
            {
                School = _school,
                Lector =lector,
               
                Groep = g,
                
              
                
                
            };
        }

        [Fact]
        public void Groep_NieuweGroepBevindZichInStartState()
        {
            Assert.True(_cursistMetGroepMetLector.Groep.CurrentState.GetType() == typeof(StartState));
        }


        [Fact]
        public void IndexGroepInMotivatieIngediendStateReturntStatusView()
        {
            _cursistMetGroepMetLector.Groep.CurrentState = new MotivatieIngediendState(_cursistMetGroepMetLector.Groep);
            var result = _controller.Index(_cursistMetGroepMetLector);
            var viewresult = result as ViewResult;
            //Assert.True(_cursistMetGroepMetLector.Groep.CurrentState.GetType() == typeof(MotivatieIngediendState));
            Assert.Equal("Index", viewresult?.ViewName);
        }

        [Fact]
        public void Index_GroepInMotivatieGoedgekeurdStateReturnStatusView()
        {
            _cursistMetGroepMetLector.Groep.CurrentState = new MotivatieGoedgekeurdState(_cursistMetGroepMetLector.Groep);
            var result = _controller.Index(_cursistMetGroepMetLector);
            var viewresult = result as ViewResult;
            Assert.Equal("Index", viewresult?.ViewName);
        }

        [Fact]
        public void KiesOrganisatie_ReturntKiesOrganisatieView()
        {
            _organisatieRepository.Setup(o => o.GetAll()).Returns(_organisaties);
            var result = _controller.KiesOrganisatie(_cursistMetGroepMetLector,"","","",1);
            var viewresult = result as ViewResult;
            Assert.Equal("KiesOrganisatie", viewresult?.ViewName);
            _organisatieRepository.Verify(c => c.GetAll(),Times.Once);
        }

        [Fact]
        public void VoegOrganisatieToe_UpdatetHuidigeMotivatieMetOrgansiatie()
        {
            _organisatieRepository.Setup(o => o.GetAll()).Returns(_organisaties);
            _organisatieRepository.Setup(o => o.GetBy("organisatie4")).Returns(_organisatie);
            Motivatie motivatie = _cursistMetGroepMetLector.Groep.GeefLaatstIngediendeMotivatie();
            motivatie.Organisatie = _organisatieRepository.Object.GetBy("organisatie4");
            _motivatieRopistory.Setup(m => m.UpdateMotivatie(motivatie));
            _cursistRepository.Setup(c => c.UpdateCursist(_cursistMetGroepMetLector));
            var result = _controller.VoegOrganisatieToe(_cursistMetGroepMetLector, "organisatie4", 1);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.Equal("MaakMotivatie",redirectToActionResult?.ActionName);
            _motivatieRopistory.Verify(m => m.SaveChanges(),Times.Once);
          
        }

        [Fact]
        public void MaakMotivatie_ReturntLaatstIndiendeMotivatieMetLeegMaakMotivatieViewModel()
        {
            var result = _controller.MaakMotivatie(_cursistMetGroepMetLector);
            var viewResult = result as ViewResult;
            Assert.Equal("MaakMotivatie",viewResult?.ViewName);
            Assert.True(viewResult?.Model.GetType() == typeof(MaakMotivatieViewModel));
        }

        [Fact]
        public void MaakMotivatiePost_VoegtInhoudToeAanMotivatieVanDeGroep()
        {
            MaakMotivatieViewModel motivatieViewModel =
                new MaakMotivatieViewModel()
                {
                    Inhoud = " diam lobortis amet integer quisque mauris fames sollicitudin volutpat excepturi non pellentesque inceptos magna eu duis magna quis turpis sit enim sit sit rhoncus arcu sed ultrices urna rhoncus adipiscing congue lobortis cras aenean eget elementum eu parturient purus duis sollicitudin tristique mauris dui quisque vestibulum dignissim libero maecenas orci faucibus ligula ullamcorper metus nibh morbi luctus nisl lectus eget ultrices pretium velit esse sed pede tincidunt lectus phasellus eu morbi est a lectus a dui massa et volutpat vel et ultrices class in ac nulla orci vestibulum vel mollis dui augue dictum fermentum libero ipsum urna vel sodales tellus dui malesuada sit sit curae id leo sed aliquam quis nulla pede morbi aliquam arcu conubia aliquam aenean eu per molestie at proin velit proin etiam augue felis dolor malesuada metus nibh elementum tristique tincidunt eleifend ultricies dapibus porttitor eu sed phasellus suspendisse gravida turpis lacinia donec suspendisse eleifend vestibulum lorem lacus a lectus leo non nunc placerat est in urna turpis amet tellus illo felis vestibulum fringilla wisi consectetuer quam ac neque et luctus et pede magna augue a pellentesque varius at orci a blandit consequat purus ultricies aliquam cursus fermentum nam massa in pede ut purus arcu ut cursus vestibulum dis ut est tellus eget mollis eget posuere laoreet quis tempor ante non ultricies velit at nunc feugiat fusce hendrerit vel nuncsad"
                };
            var result = _controller.MaakMotivatie(_cursistMetGroepMetLector, motivatieViewModel);
            var viewResult = result as RedirectToActionResult;
            Assert.Equal("index",viewResult?.ActionName);
            _motivatieRopistory.Verify(m => m.SaveChanges(), Times.Once);
            _cursistRepository.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Fact]
        public void MotivatieBevestigen_ModelIsVanTypeMotivatie()
        {
            var result = _controller.MotivatieBevestigen(_cursistMetGroepMetLector);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.Equal("Index", redirectToActionResult?.ActionName);
            _groepRepository.Verify(g => g.SaveChanges());
        }

        [Fact]
        public void MaakBericht_ReturntIndex()
        {
            var result = _controller.BerichtAanmaken(_cursistMetGroepMetMotivatieGoedgekeurd);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.Equal("Index", redirectToActionResult?.ActionName);
            
        }

        [Fact]
        public void MaakBericht_MaaktBerichtAan()
        {
            _controller.BerichtAanmaken(_cursistMetGroepMetMotivatieGoedgekeurd);

            _berichtRopository.Verify(a => a.SaveChanges(), Times.Once);

        }



    }
}
