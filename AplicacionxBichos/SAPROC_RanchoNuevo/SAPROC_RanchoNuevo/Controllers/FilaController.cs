using SAPROC_RanchoNuevo.Models;
using SAPROC_RanchoNuevo.Models.TableViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPROC_RanchoNuevo.Controllers
{
    public class FilaController : Controller
    {
        // GET: Fila
        public ActionResult Index()
        {
            List<FilaViewModel> list = null;

            using (var db = new ranchonuevoEntities2())
            {
                list = (from d in db.fila
                        select new FilaViewModel
                        {
                            idFila = d.idFila,
                            identificadorFila = d.identificadorFila,
                            nViajes = d.nViajes,
                            cCascarrillo = d.cCascarrillo,
                            Comentarios = d.Comentarios,
                            toneladasLinea = d.toneladasLinea,
                            produccion = d.Produccion,
                        }).ToList();

            }
            return View(list);
        }

        public ActionResult Edit(int idfila, int nviajes, float cantidad, float toneladas, float prod, string comentarios)
        {
            List<FilaViewModel> list = null;

            using (var db = new ranchonuevoEntities2())
            {
                list = (from d in db.fila
                        where d.idFila == idfila
                        select new FilaViewModel
                        {
                            idFila = d.idFila,
                            identificadorFila = d.identificadorFila,
                            nViajes = d.nViajes,
                            cCascarrillo =d.cCascarrillo,
                            Comentarios =d.Comentarios,
                            toneladasLinea =d.toneladasLinea,
                            produccion=d.Produccion,
                        }).ToList();

                if (list != null)
                {
                    int insert = db
                   .Database
                   .ExecuteSqlCommand("UPDATE [Fila] SET [Fila].nViajes = @nviajes, [Fila].cCascarrillo = @ccascarrillo, [Fila].toneladasLinea = @toneladas, [Fila].produccion = @produccion, [Fila].Comentarios = @comentarios " +
                                       "WHERE idFila = @idFila"
                                       , new SqlParameter("@nviajes", nviajes)
                                       , new SqlParameter("@ccascarrillo", cantidad)
                                      , new SqlParameter("@toneladas", toneladas)
                                       , new SqlParameter("@produccion", prod)
                                       , new SqlParameter("@comentarios", comentarios)
                                        , new SqlParameter("@idFila", idfila));
                    db.SaveChanges();
                }
                else
                {
                    Content("NO SE ENCONTRO FILA");
                }
            }
            return Redirect(Url.Content("~/"));
        }
    }
}