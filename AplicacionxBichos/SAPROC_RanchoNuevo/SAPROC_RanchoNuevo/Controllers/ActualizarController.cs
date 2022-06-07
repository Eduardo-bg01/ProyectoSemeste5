using SAPROC_RanchoNuevo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPROC_RanchoNuevo.Controllers
{
    public class ActualizarController : Controller
    {
        // GET: Actualizar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(int temperatura,int volteos, string observaciones)
        {
            DateTime hoy = DateTime.Today;

            using (var db = new ranchonuevoEntities2())
            {
                int insert = db
                    .Database
                    .ExecuteSqlCommand("INSERT INTO [Actualizacion](temperatura, nVolteos, Observaciones, fechaActualizacion) " +
                    "VALUES (@temperatura, @nvolteos, @observaciones, @fechaActualizacion)"
                    , new SqlParameter("@temperatura", temperatura)
                    , new SqlParameter("@nvolteos", volteos)
                    , new SqlParameter("@observaciones", observaciones)
                    , new SqlParameter("@fechaActualizacion", hoy)
                    );
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/"));
        }
    }
}