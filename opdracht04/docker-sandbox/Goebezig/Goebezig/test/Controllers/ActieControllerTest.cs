using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Controllers;
using DotNet_GoeBezig_G11.Models.ActieViewModels;
using DotNet_GoeBezig_G11.Models.Domein;
using DotNet_GoeBezig_G11.Models.Domein.State;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace test.Controllers
{
    public class ActieControllerTest
    {
        private readonly ActieController _controller;
        private readonly Mock<IGroepRepository> _groepRepository;
        private readonly Mock<ICursistRepository> _cursistRepository;
        private readonly Mock<IActieContainerRepository> _containerRepository;
        private readonly Mock<IActieRepository> _actieRepository;
        private readonly Cursist _cursist;
        private readonly Cursist _cursist2;
        private readonly Groep _groep;
        private readonly Groep _groep2;
        private Mock<IBerichtRepository> _berichtRepository;

        public ActieControllerTest()
        {
            _groepRepository = new Mock<IGroepRepository>();
            _actieRepository = new Mock<IActieRepository>();
            _cursistRepository = new Mock<ICursistRepository>();
            _containerRepository = new Mock<IActieContainerRepository>();
            _berichtRepository = new Mock<IBerichtRepository>();
            _controller = new ActieController(_actieRepository.Object, _groepRepository.Object,
                _cursistRepository.Object, _containerRepository.Object, _berichtRepository.Object);
            _cursist = new Cursist("Fulvio", "Gentile", "Fulvio@hogent.be");
            _groep = new Groep("G11", false);
            _cursist.Groep = _groep;
            _groep.VoegCursistToe(_cursist);

             _cursist2 = new Cursist("Robin", "Gammoudi", "robingm@hogent.be");
             _groep2 = new Groep("G12", false);
            _cursist2.Groep = _groep2;
            _groep2.VoegCursistToe(_cursist2);
            _groep2.CurrentState = new MotivatieGoedgekeurdState(_groep);
            _groep2.AddContainer(new ActieContainer());
            
            _groep2.VoegActieToe(new Actie("Testactie", "Testomschrijving"));
            _controller.DienActiesIn(_cursist2);
        }

        [Fact]
        public void IndexStartState()
        {
            _groep.CurrentState = new StartState(_groep);
            var result = _controller.Index(_cursist);
            var action = result as ViewResult;
            Assert.Equal("ActieMoetGoedgekeurdWorden", action?.ViewName);
        }

        [Fact]
        public void IndexMotivatieIngediendState()
        {
            _groep.CurrentState = new StartState(_groep);
            var result = _controller.Index(_cursist);
            var action = result as ViewResult;
            Assert.Equal("ActieMoetGoedgekeurdWorden", action?.ViewName);
        }

        [Fact]
        public void IndexMotivatieGoedgekeurdState()
        {
            _groep.CurrentState = new MotivatieGoedgekeurdState(_groep);
            var result = _controller.Index(_cursist);
            var action = result as RedirectToActionResult;
            Assert.Equal("ActieMaken", action?.ActionName);

        }

        [Fact]
        public void VoegActieToeGeenContainer()
        {
            _groep.CurrentState = new MotivatieGoedgekeurdState(_groep);
            var model = new ActieViewModel();
            _controller.ActieMaken(_cursist);
            model.Titel = "Test";
            model.Omschrijving = "Test";
            var result = _controller.VoegActieToe(_cursist, model) as ViewResult;

            Assert.Equal("MaakActie", result?.ViewName);
            _actieRepository.Verify(a => a.SaveChanges(), Times.Once);

        }

        [Fact]
        public void VoegActieToeAfgekeurdeContainer()
        {
            _groep.CurrentState = new MotivatieGoedgekeurdState(_groep);
            var model = new ActieViewModel();
            var container = new ActieContainer();
            container.Beoordeeld = true;
            _groep.AddContainer(container);
            _controller.ActieMaken(_cursist);
            model.Titel = "Test";
            model.Omschrijving = "Test";
            _controller.VoegActieToe(_cursist, model);

            _actieRepository.Verify(a => a.SaveChanges(), Times.Once);

        }


        [Fact]
        public void VoegActieToeMetContainer()
        {
            _groep.CurrentState = new MotivatieGoedgekeurdState(_groep);
            var model = new ActieViewModel();
            var container = new ActieContainer();
            _groep.AddContainer(container);
            _controller.ActieMaken(_cursist);
            model.Titel = "Test";
            model.Omschrijving = "Test";

            _controller.VoegActieToe(_cursist, model);

            _actieRepository.Verify(a => a.SaveChanges(), Times.Once);
            Assert.Equal(container, _groep.GeefLaatsteContainer());
        }

        [Fact]
        public void UpdateActie()
        {
            _groep.CurrentState = new MotivatieGoedgekeurdState(_groep);
            var model = new ActieViewModel();

            model.Id = 1;
            model.Titel = "Test";
            model.Omschrijving = "Actie";
            var container = new ActieContainer();
            _groep.AddContainer(container);


            var actie = new Actie("Test", "Actie");
            container.VoegActieToe(actie);

            _actieRepository.Setup(c => c.GetById(1)).Returns(actie);


            var result = _controller.UpdateActie(_cursist, model);
            var redirect = result as ViewResult;

            _actieRepository.Verify(a => a.SaveChanges(), Times.Once);
            Assert.Equal("MaakActie", redirect?.ViewName);


        }

        [Fact]
        public void VerwijderActie()
        {
            _groep.CurrentState = new MotivatieGoedgekeurdState(_groep);

            var model = new VerwijderActieModel();

            model.actieId = 1;

            var container = new ActieContainer();
            _groep.AddContainer(container);


            var actie = new Actie("Test", "Actie");
            container.VoegActieToe(actie);

            _actieRepository.Setup(c => c.GetById(1)).Returns(actie);


            var result = _controller.VerWijderActie(_cursist, model);
            var redirect = result as ViewResult;

            _actieRepository.Verify(a => a.SaveChanges(), Times.Once);
            Assert.Equal("MaakActie", redirect?.ViewName);
        }

        [Fact]
        public void DienActiesInMetActies()
        {
            _groep.CurrentState = new MotivatieGoedgekeurdState(_groep);
            _groep.AddContainer(new ActieContainer());
            _groep.VoegActieToe(new Actie("test", "actie"));
            _controller.DienActiesIn(_cursist);
            _groepRepository.Verify(g => g.SaveChanges(), Times.Once);


            Assert.Equal(typeof(ActieIngediendState), _groep.CurrentState.GetType());
        }

        [Fact]
        public void MaakBericht_MaaktBerichtAan()
        {
            var model = new DeelActieViewModel();

            _groep2.CurrentState = new MotivatieGoedgekeurdState(_groep);

            model.Id= 1;

            var container = new ActieContainer();
            _groep2.AddContainer(container);
            var actie = new Actie("Test", "Actie");
            container.VoegActieToe(actie);
            _actieRepository.Setup(c => c.GeefActie(1)).Returns(actie);
            _actieRepository.Setup(c => c.GetById(1)).Returns(actie);

            model.Aankodiging = "TestBeschrijving";
            _controller.MaakBericht(_cursist2, model);

            _actieRepository.Verify(a=>a.SaveChanges());
        }

        [Fact]
        public void MaakBericht_ReturntIndex()
        {
            var model = new DeelActieViewModel();

            _groep2.CurrentState = new MotivatieGoedgekeurdState(_groep);

            model.Id = 1;

            var container = new ActieContainer();
            _groep2.AddContainer(container);
            var actie = new Actie("Test", "Actie");
            container.VoegActieToe(actie);
            _actieRepository.Setup(c => c.GeefActie(1)).Returns(actie);
            _actieRepository.Setup(c => c.GetById(1)).Returns(actie);

            model.Aankodiging = "TestBeschrijving";
            _controller.MaakBericht(_cursist2, model);
            var result = _controller.ActieMaken(_cursist);
            var action = result as RedirectToActionResult;
            Assert.Equal("Index", action?.ActionName);
        }


    }
}
