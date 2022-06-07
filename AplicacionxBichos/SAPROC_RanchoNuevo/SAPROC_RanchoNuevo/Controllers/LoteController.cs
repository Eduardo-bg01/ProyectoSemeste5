using SAPROC_RanchoNuevo.Models.TableViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAPROC_RanchoNuevo.Controllers;
using SAPROC_RanchoNuevo.Models;
using System.Data.SqlClient;
using System.Data.Entity;

namespace SAPROC_RanchoNuevo.Controllers
{
    public class LoteController : Controller
    {
        // GET: Lote
        public ActionResult Index()
        {
            string a = "En proceso";
            List<LoteViewModel> list = null;

            using (var db = new ranchonuevoEntities2())
            {
                list = (from d in db.lote
                        select new LoteViewModel
                        {
                            idLote = d.idLote,
                            identificadorLote = d.identificadorLote,
                            nFilas = d.nFilas,
                            fecha_Inicio = d.fecha_Inicio,
                            fecha_Termino = d.fecha_Termino,
                            estadoLote = d.estadoLote,
                            fecha_Registro = d.fechaRegistro,
                        }).ToList();

            }
            return View(list);
        }

        public ActionResult Add(string lote, DateTime fechai, int filas)
        {
            string fecha = fechai.ToString();

                //VARIABLES
                int[] arreglo = new int[filas];
                int c;
                DateTime terminando = Convert.ToDateTime("01/01/2000");
                int auxxx = 0;

                //CREACION DE FILAS
                for (int i = 0; i < arreglo.Length; i++)
                {
                    auxxx = i + 1;
                    string idlote = auxxx + lote + "-22";

                    using (var dtb = new ranchonuevoEntities2())
                    {
                        int insert = dtb
                        .Database
                        .ExecuteSqlCommand("INSERT INTO [Fila](identificadorFila) VALUES (@identificadorFila)"

                        , new SqlParameter("@identificadorFila", idlote)
                        );
                        dtb.SaveChanges();
                    }
                }

                ////////////

                //CREAR LOTEE
                using (var db = new ranchonuevoEntities2())
                {
                    int insert = db
                        .Database
                        .ExecuteSqlCommand("INSERT INTO [Lote](identificadorLote, nFilas, fecha_Inicio," +
                        "estadoLote, fechaRegistro) VALUES (@identificadorLote, @nFilas, @fecha_inicio, @estadoLote" +
                        ", @fechaRegistro)"
                        , new SqlParameter("@identificadorLote", lote)
                        , new SqlParameter("@nFilas", filas)
                        , new SqlParameter("@fecha_inicio", fechai)
                        , new SqlParameter("@estadoLote", "En proceso")
                        , new SqlParameter("@fechaRegistro", System.DateTime.Today)
                        );
                    ViewBag.Alert = "Registro exitoso";
                    db.SaveChanges();
                }
                return Redirect(Url.Content("~/"));
        }

        public ActionResult Edit (int id,DateTime fechai, string identificadorLote, int nfilas)
        {
            string a = "En proceso";
            List<LoteViewModel> list = null;

            using (var db = new ranchonuevoEntities2())
            {
                list = (from d in db.lote
                        where d.idLote == id
                        select new LoteViewModel
                        {
                            idLote = d.idLote,
                            identificadorLote = d.identificadorLote,
                            nFilas = d.nFilas,
                            fecha_Inicio = d.fecha_Inicio,
                            fecha_Termino = d.fecha_Termino,
                            estadoLote = d.estadoLote,
                            fecha_Registro = d.fechaRegistro,
                        }).ToList();

                if(list != null)
                {
                    int insert = db
                   .Database
                   .ExecuteSqlCommand("UPDATE [Lote] SET [Lote].identificadorLote = @identificadorLote, [Lote].nFilas = @nFilas,[Lote].fecha_Inicio = @fecha_Inicio " +
                                       "WHERE idLote = @idLote"
                                       , new SqlParameter("@identificadorLote", identificadorLote)
                                       , new SqlParameter("@nFilas", nfilas)
                                      , new SqlParameter("@fecha_Inicio", fechai)
                                       , new SqlParameter("@idLote", id));
                    db.SaveChanges();
                }
                else
                {
                    Content("NO SE ENCONTRO LOTE");
                }
            }
            return Redirect(Url.Content("~/"));
        }


        //NO SE UTILIZA
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new ranchonuevoEntities2())
            {
                var oUser = db.Database.ExecuteSqlCommand("DELETE FROM [Lote] WHERE [Lote].idLote = @Id", new SqlParameter("@Id", Id));
                db.SaveChanges();
            }
            return Content("1");
        }

        [HttpPost]
        public ActionResult Finalizar(int id)
        {
            string estado = "Finalizado";
            DateTime hoy = DateTime.Today;

            using (var db = new ranchonuevoEntities2())
            {
                int insert = db
                   .Database
                   .ExecuteSqlCommand("UPDATE [Lote] SET [Lote].estadoLote = @estado, [Lote].fecha_Termino = @fechaf " +
                                       "WHERE idLote = @idLote"
                                       , new SqlParameter("@estado", estado)
                                       , new SqlParameter("@fechaf", hoy)
                                       , new SqlParameter("@idLote", id));
                db.SaveChanges();
            }
            return Content("1");
        }

        //[HttpPost]
        //public ActionResult Finalizar([Bind(Include = "idLote, identificadorLote, nFilas, fecha_Inicio, fecha_Termino, estadoLote, fechaRegistro")] lote lt)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using(var db = new ranchonuevoEntities2())
        //        {
        //            db.lote.Attach(lt);
        //            db.Entry(lt).State = EntityState.Modified;

        //            db.SaveChanges();
        //        }   
        //    }
        //    return Redirect(Url.Content("~/"));
        //}
    }



}


                 