using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DotNet_GoeBezig_G11.Filters;
using DotNet_GoeBezig_G11.Models.BeheerGroepViewModels;
using DotNet_GoeBezig_G11.Models.Domein;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sakura.AspNetCore;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNet_GoeBezig_G11.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(CursistFilter))]
    public class BeherenGroepController : Controller
    {
        private readonly IGroepRepository _groepRepository;
        private readonly ICursistRepository _cursistRepository;
        private readonly ISchoolRepository _schoolRepository;

        public BeherenGroepController(IGroepRepository groepRepository, ICursistRepository cursistRepository,
            ISchoolRepository schoolRepository, IMotivatieRepository motivatieRepository)
        {
            _groepRepository = groepRepository;
            _cursistRepository = cursistRepository;
            _schoolRepository = schoolRepository;
        }

        // GET: /<controller>/
        public IActionResult Index(Cursist cursist)
        {
            if (cursist.School == null)
            {
                return RedirectToAction("ToonOrganisaties", "BeherenGroep");
            }
            if (cursist.Lector == null)
            {
                return View("Index");
            }
            return RedirectToAction(cursist.Groep == null ? nameof(BevestigGroep) : nameof(BekijkGroep), "BeherenGroep");
        }

        [HttpGet]
        public IActionResult ToonOrganisaties(Cursist cursist,string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<Organisatie> schools = _schoolRepository.GetAll();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EmailSortParm = sortOrder == "email" ? "email_desc" : "email";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                schools = schools.Where(s => s.Naam.Contains(searchString)
                || s.Email.Contains(searchString));
            }
            schools = cursist.SorteerOrganisaties(schools, sortOrder);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View("ToonOrganisaties", schools.ToPagedList(pageSize, pageNumber));
        }

        [HttpGet]
        public IActionResult InschrijvenOrganisatie(Cursist cursist, string naam, int? page)
        {
            try
            {
                cursist.School = _schoolRepository.GetBy(naam.Replace("_", " "));
                _cursistRepository.SaveChanges();
            }
            catch (ArgumentException e)
            {
                ViewBag._userError = e.Message;
                IEnumerable<School> schools = _schoolRepository.GetAll();
                int pageSize = 5;
                int pageNumber = (page ?? 1);

                return View("ToonOrganisaties", schools.ToPagedList(pageSize, pageNumber));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MaakGroep(Cursist cursist, BewerkGroepViewModel groepViewModel)
        {
            if (ModelState.IsValid)
            {
                Groep groep = new Groep(groepViewModel.Naam);
                groep.Cursisten.Add(cursist);
                groep.Motivaties.Add(new Motivatie());
                groep.Open = cursist.School.IsOpen;
                cursist.Groep = groep;
                _groepRepository.AddGroep(groep);
                _groepRepository.SaveChanges();
            }


            return RedirectToAction("ToonLeden");
        }

        [HttpGet]
        public IActionResult BewerkGroep(Cursist cursist)
        {

            return View("BewerkGroep", new BewerkViewModel());
        }

        [HttpPost]
        public IActionResult BewerkGroep(Cursist cursist, BewerkViewModel bewerkViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cursist cursist1 = _cursistRepository.GetBy(bewerkViewModel.EmailCursist);
                    cursist1.NodigUitVoorGroep(cursist.Email, cursist.Groep.Naam);
                    _cursistRepository.SaveChanges();
                    ViewBag.Cursist = cursist1;
                    ViewBag._userMessage = $"{cursist1.Email} is succesvol uitgenodigd voor de groep";
                    ViewBag.Uitgenodigd = _cursistRepository.GeefUitgenodigden(cursist);
                    ViewBag.Leden = cursist.Groep.Cursisten;
                    return View("BewerkGroep");

                }
                catch (Exception e)
                {
                    ViewBag._userError = e.Message;
                    ViewBag.Uitgenodigd = _cursistRepository.GeefUitgenodigden(cursist);
                    ViewBag.Leden = cursist.Groep.Cursisten;
                    return View("BewerkGroep", new BewerkViewModel());
                }

                // bewerkViewModel.EmailCursist;
            }
            
                return RedirectToAction("ToonLeden");
            

        }

        [HttpGet]
        public IActionResult BevestigGroep(Cursist cursist)
        {
            List<Melding> meldingen = cursist.Meldingen;
            List<Groep> groepen = new List<Groep>();

            meldingen.ForEach(m =>
            {
                String naam = m.GroepNaam;
                if (naam != null)
                {
                    groepen.Add(_groepRepository.GetBy(naam));
                }

            });
            //ViewBag._userError = TempData["ErrorMessage"] as string;
            ViewBag.groep = groepen;
            return View("MaakGroep");
        }

        [HttpGet]
        public IActionResult BekijkGroep(Cursist cursist)
        {
            ViewBag.Groep = cursist.Groep;
            ViewBag.Leden = cursist.Groep.Cursisten;
            ViewBag.Status = cursist.Groep.CurrentState.ToString();
            return View("Overzicht");
        }

        [HttpGet]
        public IActionResult ToonLeden(Cursist cursist)
        {
            if (cursist.Groep == null)
                return RedirectToAction("Index");
            var uitgenodigden = _cursistRepository.GeefUitgenodigden(cursist);
            ViewBag.Uitgenodigd = uitgenodigden;
            ViewBag.Leden = cursist.Groep.Cursisten;
            return View("BewerkGroep");
        }

        [AcceptVerbs("Get", "Post")]
        public JsonResult IsUniqueNaam(string naam)
        {
            return Json(data: !_groepRepository.GetAll().ToList().Exists(g => g.Naam.Equals(naam)));
        }

        public IActionResult WeigerGroep(Cursist cursist, AccepteerGroepViewModel model)
        {
            cursist.Meldingen.Remove(cursist.Meldingen.Find(c => c.GroepNaam == model.GroepNaam));
            _cursistRepository.SaveChanges();
            ViewBag._userMessage = $"U heeft succesvol de uitnodiging van {model.GroepNaam} afgewezen ";

            return RedirectToAction("Index");
        }

        public IActionResult AccepteerGroep(Cursist cursist, AccepteerGroepViewModel model)
        {
            try
            {
                Groep groep = _groepRepository.GetBy(model.GroepNaam);
                groep.VoegCursistToe(cursist);
                _groepRepository.UpdateGroep(groep);
                _cursistRepository.UpdateCursist(cursist);
                
                _groepRepository.SaveChanges();
                // melding verwijderen + message meegeven?
                //ViewBag._userMessage = $"U bent succesvol toegevoegd aan {groep.Naam} ";
                return RedirectToAction(nameof(ToonLeden), "BeherenGroep");
            }
            catch (ArgumentException e)
            {
                cursist.Meldingen.Remove(cursist.Meldingen.Find(c => c.GroepNaam == model.GroepNaam));
                _cursistRepository.SaveChanges();
                @ViewBag._userError = e.Message;
                List<Melding> meldingen = cursist.Meldingen;
                List<Groep> groepen = new List<Groep>();

                meldingen.ForEach(m =>
                {
                    String naam = m.GroepNaam;
                    if (naam != null)
                    {
                        groepen.Add(_groepRepository.GetBy(naam));
                    }

                });

                ViewBag.groep = groepen;
                return View("MaakGroep");

            }
        }
    }
}
