using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPROC_RanchoNuevo.Controllers
{
    public class CerrarController : Controller
    {
        // GET: Cerrar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logoff()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Acces");
        }
    }
}