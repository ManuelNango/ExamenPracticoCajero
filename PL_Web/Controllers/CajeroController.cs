using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_Web.Controllers
{
    public class CajeroController : Controller
    {
        // GET: Cajero
        [HttpGet]
        public ActionResult DineroCajero()
        {
            ML.Cajero cajero = new ML.Cajero();
            cajero.Tipo = new ML.Tipo();

            ML.Result result = BL.Cajero.CajeroGetAll();

            cajero.Cajeros = result.Objects;

            return View(cajero);
        }

        [HttpGet]
        public ActionResult VistaCajero()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Retirar(decimal retiro)
        {
            ML.Result result = BL.Cajero.RetirarEfectivo(retiro);

            return RedirectToAction("DineroCajero");
        }
    }
}