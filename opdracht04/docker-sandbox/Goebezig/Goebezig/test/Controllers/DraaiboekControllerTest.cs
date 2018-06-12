using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Controllers;
using DotNet_GoeBezig_G11.Models.Domein;
using DotNet_GoeBezig_G11.Models.Domein.State;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace test.Controllers
{
    public class DraaiboekControllerTest
    {

        private DraaiboekController _controller;
        private Cursist _testCursist;
        private Groep _groepTestCursist;
        private Cursist _testCursistZonderGroep;
        private Mock<IActieRepository> _actieRepositoryMock;
        private Mock<ITaakRepository> _taakRepositoryMock;

        public DraaiboekControllerTest()
        {
            _actieRepositoryMock = new Mock<IActieRepository>();
            _taakRepositoryMock = new Mock<ITaakRepository>();
            _actieRepositoryMock.Setup(a => a.GeefAlles()).Returns(new List<Actie>()
            {
                new Actie("actie1","omschrijving1")
                {
                    ActieId = 5,
                    Goedgekeurd = true
                },
                new Actie("actie2","omschrijving2"),
                new Actie("actie3","omschrijving3")
                {
                    Goedgekeurd = true
                },
                new Actie("actie4","omschrijving4"),
                new Actie("actie5","omschrijving5"),
                new Actie("actie6","omschrijving6"){
                    Goedgekeurd = true
                }
            });
            _actieRepositoryMock.Setup(a => a.GetById(5)).Returns(new Actie("Actie1", "omschrijving1"));
            _controller = new DraaiboekController(_actieRepositoryMock.Object,_taakRepositoryMock.Object);
            _testCursistZonderGroep = new Cursist("Jochem","VanHespen","jochemvanhespen@hogent.be");
            _groepTestCursist = new Groep("G11",false)
            {
                CurrentState = new ActieGoedgekeurdState(_groepTestCursist),
                ActieContainers = new List<ActieContainer>()
                {
                    new ActieContainer()
                    {
                        Acties = new List<Actie>()
                        {
                                            new Actie("actie1","omschrijving1")
                {
                    ActieId = 5,
                    Goedgekeurd = true
                },
                new Actie("actie2","omschrijving2"),
                new Actie("actie3","omschrijving3")
                {
                    Goedgekeurd = true
                },
                new Actie("actie4","omschrijving4"),
                new Actie("actie5","omschrijving5"),
                new Actie("actie6","omschrijving6"){
                    Goedgekeurd = true
                }
                        }
                    }
                }
            };
            _testCursist = new Cursist("Jochem","VanHespen","jochemvanhespen@gmail.com")
            {
                Groep = _groepTestCursist
                
                
            };
        }

        [Fact]
        public void Index_ReturntIndexView()
        {
            var result = _controller.Index(_testCursist);
            var viewResult = result as ViewResult;
            Assert.Equal("Index2", viewResult?.ViewName);
        }

        [Fact]
        public void Index_CursistZonderGroepWordtDoorverwezenNaarDeGroepPagina()
        {
            var result = _controller.Index(_testCursistZonderGroep);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.Equal("BeherenGroep", redirectToActionResult?.ControllerName);
            Assert.Equal("Index", redirectToActionResult?.ActionName);
        }

        [Fact]
        public void Index_CursistMetGroepNietInActieGoedgekeurdStateKrijgtViewTeZienMetFoutBoodschap()
        {
            _testCursist.Groep.CurrentState = new MotivatieGoedgekeurdState(_testCursist.Groep);
            var result = _controller.Index(_testCursist);
            var viewResult = result as ViewResult;
            Assert.Equal("NietInActieGoekgekeurdState", viewResult?.ViewName);
        }

        [Fact]
        public void Index_CursistMetGroepActieGoedgekeurdStateModelOfTypeListActie()
        {
            var result = _controller.Index(_testCursist);
            var viewResult = result as ViewResult;
            Assert.True(viewResult?.Model.GetType() == typeof(List<Actie>));
        }

        //[Fact]
        //public void Taken_ReturntView()
        //{
        //    var result = _controller.Taken(_testCursist, 5);
        //    var viewResult = result as ViewResult;
        //    Assert.Equal("ToonTaken",viewResult?.ViewName);
        //    _actieRepositoryMock.Verify(a => a.GetById(It.IsAny<int>()),Times.Once);
        //}
    }
}
