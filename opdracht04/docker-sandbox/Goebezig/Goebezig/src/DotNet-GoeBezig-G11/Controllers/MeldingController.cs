using System.Collections.Generic;
using DotNet_GoeBezig_G11.Filters;
using DotNet_GoeBezig_G11.Models.Domein;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_GoeBezig_G11.Controllers
{
    [ServiceFilter(typeof(CursistFilter))]
    public class MeldingController : Controller
    {
        [HttpGet]
        public IActionResult Index(Cursist cursist)
        {
            List<Melding> meldingen = cursist.Meldingen;
            ViewBag.Meldingen = meldingen;
            return View();
        }
    }
}