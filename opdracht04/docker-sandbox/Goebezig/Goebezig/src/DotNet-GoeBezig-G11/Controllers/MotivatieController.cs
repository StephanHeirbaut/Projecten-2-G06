using System;
using System.Collections.Generic;
using System.Linq;
using DotNet_GoeBezig_G11.Filters;
using DotNet_GoeBezig_G11.Models.Domein;
using DotNet_GoeBezig_G11.Models.Domein.State;
using DotNet_GoeBezig_G11.Models.MotivatieViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sakura.AspNetCore;

namespace DotNet_GoeBezig_G11.Controllers
{
    [Authorize]
    [Authorize(policy: "GroepNodig")]
    [ServiceFilter(typeof(CursistFilter))]
    public class MotivatieController : Controller
    {

        private IBerichtRepository _berichtRepository;
        private IOrganisatieRepository _organisatieRepository;
        private IMotivatieRepository _motivatieRepository;


        public MotivatieController(IBerichtRepository berichtRepository,
            IOrganisatieRepository organisatieRepository, IMotivatieRepository motivatieRepository)
        {
            _berichtRepository = berichtRepository;
            _organisatieRepository = organisatieRepository;
            _motivatieRepository = motivatieRepository;

        }


        [HttpGet]
        public IActionResult Index(Cursist cursist)
        {
            ViewBag.Groep = cursist.Groep;
            try
            {
                if (cursist.Groep.GeefGoedgekeurdeMotivatie().BerichtAangemaakt)
                {
                    ViewBag.Aankondiging =
                        _berichtRepository.GetBy(cursist.Groep.GeefGoedgekeurdeMotivatie().MotivatieId).Aankondiging;
                }
                return View("Index");

            }
            catch (Exception e)
            {
                //ViewBag._userError = e.Message;
                return View("Index");
            }
           
            
        }


        [HttpGet]
        public IActionResult KiesOrganisatie(Cursist cursist,
            string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<Organisatie> schools = _organisatieRepository.GetAll();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EmailSortParm = sortOrder == "email" ? "email_desc" : "email";
            ViewBag.Groep = cursist.Groep;

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

            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View("KiesOrganisatie", schools.ToPagedList(pageSize, pageNumber));
        }

        [HttpGet]
        public IActionResult VoegOrganisatieToe(Cursist cursist, string naam, int? page)
        {
            ViewBag.Groep = cursist.Groep;
            try
            {
                Motivatie motivatie = cursist.Groep.GeefLaatstIngediendeMotivatie();
                if (motivatie.Feedback.Equals(""))
                {
                    motivatie.Organisatie = _organisatieRepository.GetBy(naam);
                    motivatie.VerwijderContactpersonen();
                }
                else
                {
                    cursist.Groep.MaakNieuweMotivatie(_organisatieRepository.GetBy(naam));
                }
                _motivatieRepository.SaveChanges();
                
            }
            catch (ArgumentException e)
            {
                IEnumerable<Organisatie> schools = _organisatieRepository.GetAll();
                int pageSize = 8;
                int pageNumber = (page ?? 1);
                ViewBag._userError = e.Message;

                return View("KiesOrganisatie", schools.ToPagedList(pageSize, pageNumber));
            }
            return RedirectToAction("MaakMotivatie");
        }

        [HttpGet]
        public IActionResult MaakMotivatie(Cursist cursist)
        {
            ViewBag.Groep = cursist.Groep;
            return View("MaakMotivatie", cursist.Groep.GeefLaatstIngediendeMotivatie().Inhoud == null ? new MaakMotivatieViewModel() : new MaakMotivatieViewModel(cursist.Groep.GeefLaatstIngediendeMotivatie().Inhoud));
        }


        [HttpPost]
        public IActionResult MaakMotivatie(Cursist cursist, MaakMotivatieViewModel model)
        {
            ViewBag.Groep = cursist.Groep;
            if (ModelState.IsValid)
            {
                try
                {
                    Motivatie motivatie = cursist.Groep.GeefLaatstIngediendeMotivatie();
                    motivatie.Inhoud = model.Inhoud;
                    _berichtRepository.SaveChanges();
                    
                }
                catch (Exception e)
                {
                    ViewBag._userError = e.Message;
                    return View("MaakMotivatie", model);
                }
            }
            return RedirectToAction("KiesContactpersonen");
        }

        [HttpPost]
        public IActionResult BewerkMotivatie(Cursist cursist, MaakMotivatieViewModel model, string action)
        {
            ViewBag.Groep = cursist.Groep;
            if (ModelState.IsValid)
            {
                try
                {
                    Motivatie motivatie = cursist.Groep.GeefLaatstIngediendeMotivatie();
                    if (action == "verwijder")
                    {
                        cursist.Groep.CurrentState.VerwijderIngediendeMotivatie(motivatie);
                        _motivatieRepository.DeleteMotivatie(motivatie);
                        _motivatieRepository.UpdateMotivatie(motivatie);
                    }
                    else
                    {
                        motivatie.Inhoud = model.Inhoud;
                    }
                    _motivatieRepository.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewBag._userError = e.Message;
                    return View("Index");
                }
            }
            return View("Index");
        }


        [HttpGet] 
        public IActionResult KiesContactpersonen(Cursist cursist)
        {
            ViewBag.Motivatie = cursist.Groep.GeefLaatstIngediendeMotivatie();
            return View("KiesContactPersonen", cursist.Groep.GeefLaatstIngediendeMotivatie().Organisatie);
        }


        [HttpPost]
        public IActionResult KiesContactpersonen(Cursist cursist, Contactpersoon c, string action)
        {
            try
            {
                Motivatie motivatie = cursist.Groep.GeefLaatstIngediendeMotivatie();
                Contactpersoon contact = _organisatieRepository.GetContactpersonen(cursist.Groep.GeefLaatstIngediendeMotivatie().Organisatie.Naam,action);
                if (!motivatie.Contactpersonen.Contains(contact))
                {
                    motivatie.Contactpersonen.Add(contact);
                }
                else
                {
                    motivatie.Contactpersonen.Remove(contact);
                }
                _motivatieRepository.UpdateMotivatie(motivatie);
                _motivatieRepository.SaveChanges();
            }
            catch (ArgumentException e)
            {
                ViewBag._userError = e.Message;
                ViewBag.Motivatie = cursist.Groep.GeefLaatstIngediendeMotivatie();
                return View("KiesContactpersonen", cursist.Groep.GeefLaatstIngediendeMotivatie().Organisatie);
            }
            ViewBag.Motivatie = cursist.Groep.GeefLaatstIngediendeMotivatie();
            return View("KiesContactpersonen",cursist.Groep.GeefLaatstIngediendeMotivatie().Organisatie);
        }


        [HttpGet]
        public IActionResult Overzicht(Cursist cursist)
        {
            ViewBag.Motivatie = cursist.Groep.GeefLaatstIngediendeMotivatie();
            return View("Overzicht");
        }
  
        [HttpPost]
        public IActionResult MotivatieBevestigen(Cursist cursist)
        {
            Motivatie m = cursist.Groep.GeefLaatstIngediendeMotivatie();
            try
            {
                m.DienMotivatieIn(cursist.Groep);
                _berichtRepository.SaveChanges();
            }catch(ArgumentException e)
            {
                ViewBag._userError = e.Message;
                return View("Overzicht");
            }

            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public IActionResult BerichtAanmaken(Cursist cursist)
        {
           
           
            try
            {
                ViewBag.Groep = cursist.Groep;

                var motivatie = cursist.Groep.GeefGoedgekeurdeMotivatie();
                motivatie.MaakBericht(motivatie);
                _berichtRepository.SaveChanges();
                
                return RedirectToAction("Index");
            }
            catch (ArgumentException )
            {
               // ViewBag._userError = e.Message;
                return RedirectToAction("Index");
            }

        }

    }
}