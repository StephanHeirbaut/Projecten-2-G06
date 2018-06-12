using System;
using System.Linq;
using DotNet_GoeBezig_G11.Filters;
using DotNet_GoeBezig_G11.Models.Domein;
using DotNet_GoeBezig_G11.Models.Domein.State;
using DotNet_GoeBezig_G11.Models.DraaiboekViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNet_GoeBezig_G11.Controllers
{
    [Authorize]
    [Authorize(policy: "GroepNodig")]
    [ServiceFilter(typeof(CursistFilter))]
  
    public class DraaiboekController : Controller
    {
        private readonly IActieRepository _actieRepository;
        private readonly ITaakRepository _taakRepository;
        //private IList<Taak> _taken;

        public DraaiboekController(IActieRepository actieRepository, ITaakRepository taakRepository)
        {
            
            _actieRepository = actieRepository;
            _taakRepository = taakRepository;
        }

        [HttpGet]
        public IActionResult Index(Cursist cursist)
        {
            if (!cursist.HeeftGroep())
                return RedirectToAction("Index", "BeherenGroep");
            if (cursist.Groep.CurrentState.GetType() == typeof(ActieGoedgekeurdState))
            {
                ViewData["Cursist"] = cursist;
                ViewData["Acties"] = GetActiesAsSelectList(cursist);
                return View("Index2", cursist.Groep.Acties().Where(actie => actie.Goedgekeurd).ToList());
            }
                
            ViewBag._userError = "Je groep heeft nog geen goedgekeurde acties";
            return View("NietInActieGoekgekeurdState");
        }

        [HttpGet]
        public IActionResult Edit(Cursist cursist, int id)
        {
            ViewData["Acties"] = GetActiesAsSelectList(cursist);
            EditViewModel editViewModel = new EditViewModel(cursist, _taakRepository.GetBy(id));
            return View("Edit", editViewModel);
        }

        [HttpPost]
        public IActionResult Edit(Cursist cursist, EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string cursisten = "";
                    foreach (var cursist2 in editViewModel.ToegevoegdeCursisten)
                    {
                        cursisten += cursist2 + " ";
                    }
                    Taak taak = _taakRepository.GetBy(editViewModel.TaakId);
                    taak.Wie = cursisten;
                    taak.Wijzig();
                    taak.Wat = editViewModel.Wat;
                    taak.Bijsturing = editViewModel.Opmerking;
                    taak.Van = editViewModel.Van;
                    taak.Tot = editViewModel.Tot;
                    _taakRepository.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View(nameof(Edit), editViewModel);
        }


        [HttpPost]
        public IActionResult Delete(DeleteViewModel model)
        {
            Taak taak = _taakRepository.GetBy(model.TaakId);
                _taakRepository.Delete(taak);
            _taakRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create(Cursist cursist)
        {
            ViewData["Acties"] = GetActiesAsSelectList(cursist);
            return View(nameof(Edit), new EditViewModel(cursist));
        }

        [HttpPost]
        public IActionResult Create(Cursist cursist, EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Taak taak = MapModelNaarTaak(editViewModel);
                    cursist.VoegTaakToe(taak, editViewModel.Actie);
                    _actieRepository.SaveChanges();
                    ViewBag._userMessage = "Taak toegevoegd";
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return Index(cursist);
        }

        private Taak MapModelNaarTaak(EditViewModel editViewModel)
        {
            string cursisten = " ";
            foreach (var cursist in editViewModel.ToegevoegdeCursisten)
            {
                cursisten += cursist;
            }
            return new Taak(
                cursisten,
                editViewModel.Wat,
                editViewModel.Opmerking,
                _actieRepository.GetById(editViewModel.Actie),
                editViewModel.Van,
                editViewModel.Tot);
        }

        private SelectList GetActiesAsSelectList(Cursist cursist)
        {
            return new SelectList(
                cursist.Groep.Acties().Where(actie => actie.Goedgekeurd).OrderBy(actie => actie.Titel).ToList(),
                nameof(Actie.ActieId),
                nameof(Actie.Titel));
        }

        [AcceptVerbs("Get", "Post")]
        public JsonResult CheckDate(DateTime date)
        {
            return date < DateTime.Now ? Json(data: false) : Json(data: true);
        }
    }
}
