using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAPROC_RanchoNuevo.Models;
using SAPROC_RanchoNuevo.Models.TableViewModel;

namespace SAPROC_RanchoNuevo.Controllers
{
    public class AccesController : Controller
    {
        // GET: Acces
        public ActionResult Index()
        {
            string a = "En proceso";
            List<LoteViewModel> list = null;
            using (var db = new ranchonuevoEntities2())
            {
                //list = db.Database.SqlQuery<LoteViewModel>("SELECT * FROM [Lote]").ToList();
                list = (from d in db.lote
                       where d.estadoLote == a
                       orderby d.idLote
                       select new LoteViewModel
                       {
                           idLote = d.idLote
                       }).ToList();
                    
            }
            return View(list);
        }

        public ActionResult Enter(string usuario, string pass)
        {
            try
            {
                using (var db = new ranchonuevoEntities2())
                {
                    var list = db.usuario               
                        .SqlQuery("SELECT * FROM [usuario] WHERE [usuario].usr = @usuario AND [usuario].contraseña = @pass",
                         new SqlParameter("@usuario", usuario), new SqlParameter("@pass", pass)).ToList();

                    if(list.Count > 0)
                    {
                        usuario nuser = list.First();
                        Session["Usuario"] = nuser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario incorrecto");
                    }
                }
        
            }
            catch (Exception ex)
            {
                return Content("Ha ocurrido un error" + ex.Message);
            }
          
        }
    }
}