using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Filters;
using DotNet_GoeBezig_G11.Models.ActieViewModels;
using DotNet_GoeBezig_G11.Models.Domein;
using DotNet_GoeBezig_G11.Models.Domein.State;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNet_GoeBezig_G11.Controllers
{
    [Authorize]
    [Authorize(policy:"GroepNodig")]
    [ServiceFilter(typeof(CursistFilter))]
    public class ActieController : Controller
    {
        private readonly IActieRepository _actieRepository;
        private readonly IGroepRepository _groepRepository;
        private readonly ICursistRepository _cursistRepository;
        private readonly IActieContainerRepository _actieContainerRepository;
        private readonly IBerichtRepository _berichtRepository;

        // GET: /<controller>/
        public ActieController(IActieRepository actieRepository, IGroepRepository groepRepository, ICursistRepository cursistRepository, IActieContainerRepository actieContainerRepository, IBerichtRepository berichtRepository)
        {
            _actieRepository = actieRepository;
            _groepRepository = groepRepository;
            _cursistRepository = cursistRepository;
            _actieContainerRepository = actieContainerRepository;
            _berichtRepository = berichtRepository;
        }


        [HttpGet]
        public IActionResult Index(Cursist cursist)
        {

            CurrentState state = cursist.Groep.CurrentState;
            Type type = state.GetType();
            if (!cursist.HeeftGroep())
                return RedirectToAction("Index", "BeherenGroep");
            if (state.GetType() == typeof(StartState) || state.GetType() == typeof(MotivatieIngediendState))
            {

                return View("ActieMoetGoedgekeurdWorden");
            }
            if (state.GetType() == typeof(MotivatieGoedgekeurdState))
            {
                //TempData["shortMessage"] = "MyMessage";
                return RedirectToAction("ActieMaken");
            }
           
            return RedirectToAction("BekijkActie");



        }
        [HttpGet]
        public IActionResult ActieMaken(Cursist cursist)
        {
            if (cursist.Groep.CurrentState.GetType() == typeof(MotivatieGoedgekeurdState))
            {
                Groep groep = cursist.Groep;
                //ViewBag._userMessage = TempData["shortMessage"];
                ViewBag.Acties = groep.GeefActies();
                ViewBag.Berichten = _berichtRepository.GetAll();
                ViewBag.Evenementen = groep.GeefEvenementen();
                return View("MaakActie");
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult BekijkActie(Cursist cursist)
        {
            Groep groep = cursist.Groep;
            ViewBag.Status = groep.CurrentState.ToString();
            ViewBag.Acties = groep.GeefActies();
            ViewBag.Berichten = _berichtRepository.GetAll();
            ViewBag.Evenementen = groep.GeefEvenementen();
            ViewBag.Goedgekeurd = groep.CurrentState.GetType() == typeof(ActieGoedgekeurdState);

            return View("BekijkActie");
        }
        [HttpPost]
        public IActionResult VoegEvenementToe(Cursist cursist, EvenementViewModel model)
        {
            Groep groep = cursist.Groep;
            if (ModelState.IsValid)
            {
                try
                {
                    var evenement = new Actie(model.Titel, model.Omschrijving, model.Datum);
                    groep.VoegActieToe(evenement);
                    _cursistRepository.SaveChanges();
                    ViewBag._userMessage = $"Evenement {evenement.Titel} is succesvol aangemaakt";
                    return ActieMaken(cursist);
                }
                catch (ArgumentException e)
                {
                    ViewBag._userError = e.Message;
                    return ActieMaken(cursist);
                }
            }

            ViewBag._userError = "Gelieve alle velden correct in te vullen";
            return ActieMaken(cursist);
        }

        [HttpPost]
        public IActionResult VoegActieToe(Cursist cursist, ActieViewModel model)
        {
            Groep groep = cursist.Groep;
            if (ModelState.IsValid)
            {
                try
                {
                    var actie = new Actie(model.Titel, model.Omschrijving);
                    groep.VoegActieToe(actie);
                    _actieRepository.SaveChanges();
                    ViewBag._userMessage = $"Actie {actie.Titel} is succesvol toegevoegd";
                    return ActieMaken(cursist);
                }
                catch (ArgumentException e)
                {
                    ViewBag._userError = e.Message;
                    return ActieMaken(cursist);
                }
            }
            ViewBag._userError = "Gelieve alle velden correct in te vullen";
            return ActieMaken(cursist);
        }
        [HttpPost]
        public IActionResult VerWijderActie(Cursist cursist, VerwijderActieModel model)
        {
            Groep groep = cursist.Groep;
            Actie actie = _actieRepository.GetById(model.actieId);
            groep.VerwijderActie(actie);
            _actieRepository.VerwijderActie(actie);
            _actieRepository.SaveChanges();
            
            ViewBag._userMessage = String.Format("{0} {1} is succesvol verwijderd", actie.Datum == null ? "Actie" : "Evenement", actie.Titel);
            

            return ActieMaken(cursist);
        }
        [HttpPost]
        public IActionResult UpdateEvenment(Cursist cursist, EvenementViewModel model)
        {
            Groep groep = cursist.Groep;
            if (ModelState.IsValid)
            {

                Actie actie = _actieRepository.GetById(model.Id);
                actie.Titel = model.Titel;
                actie.Omschrijving = model.Omschrijving;
                actie.Datum = model.Datum;
                _actieRepository.SaveChanges();
                ViewBag._userMessage = $"Evenement is succesvol gewijzigd";
                return ActieMaken(cursist);
            }


            ViewBag._userError = "Gelieve alle velden correct in te vullen";
            return ActieMaken(cursist);
        }
        [HttpPost]
        public IActionResult UpdateActie(Cursist cursist, ActieViewModel model)
        {
            Groep groep = cursist.Groep;
            if (ModelState.IsValid)
            {

                Actie actie = _actieRepository.GetById(model.Id);
                actie.Titel = model.Titel;
                actie.Omschrijving = model.Omschrijving;
                _actieRepository.SaveChanges();
                ViewBag._userMessage = "Actie is succesvol gewijzigd";
                return ActieMaken(cursist);
            }
            ViewBag._userError = "Gelieve alle velden correct in te vullen";
            return ActieMaken(cursist);
        }
        [HttpPost]
        public IActionResult DienActiesIn(Cursist cursist)
        {
            Groep groep = cursist.Groep;
            try
            {

                groep.DienContainerIn();
                _groepRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException e)
            {
                ViewBag._userError = e.Message;
                return ActieMaken(cursist);
            }
            catch (ArgumentException e)
            {
                ViewBag._userError = e.Message;
                return ActieMaken(cursist);
            }


        }

        [HttpPost]
        public IActionResult MaakBericht(Cursist cursist, DeelActieViewModel model)
        {
            try
            {
               

                // var actie = model.Actie;
                var actieId = model.Id;
                var aankondiging = model.Aankodiging;
              var actie = _actieRepository.GeefActie(actieId);
                actie.MaakBericht(actie,aankondiging);
                _actieRepository.SaveChanges();
                return ActieMaken(cursist);
            }
            catch (ArgumentException e)
            {
                 ViewBag._userError = e.Message;
                return ActieMaken(cursist);
            }
        }

    }


}
