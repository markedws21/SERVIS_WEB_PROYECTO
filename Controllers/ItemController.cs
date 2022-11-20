using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SERVIS_WEB_PROYECTO.ModeloDatos;

namespace SERVIS_WEB_PROYECTO.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        BDInstituto2Entities db = new BDInstituto2Entities();

        private int getIndice(int id)
        {
            List<Fuente> compras = (List<Fuente>)Session["item"];
            for (int i=0; i<compras.Count; i++)
            {
                if (compras[i].TBLibro.IDE_Lib == id)
                    return i;
            }
            return -1;
        }

        [HttpGet]
        public ActionResult AgregarCarrito()
        {
            ViewBag.carrera = new SelectList((IEnumerable<TBCarrera>)db.TBCarrera.ToList().OrderBy(x=>x.nomCarrera),
                "idCarrera", "nomCarrera");
            ViewBag.alumno = new SelectList((IEnumerable<TBAlumno>)db.TBAlumno.ToList().OrderBy(x => x.nombre),
                "codAlu", "nombre");
            return View();
        }

        [HttpPost]
        public ActionResult AgregarCarrito(int id, int cantidad)
        {
            if (Session["item"] == null)
            {
                List<Fuente> compras = new List<Fuente>();
                compras.Add(new Fuente(db.TBLibro.Find(id), cantidad));
                Session["item"] = compras;
            }
            else
            {
                List<Fuente> compras = (List<Fuente>)Session["item"];
                int indice = getIndice(id);
                if(indice == -1)
                { compras.Add(new Fuente(db.TBLibro.Find(id), cantidad)); }
                
                else
                { compras[indice].Cantidad += cantidad; }
                Session["item"] = compras;
            }
            return Json(new { response = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            List<Fuente> compras = (List<Fuente>)Session["item"];
            compras.RemoveAt(getIndice(id));
            ViewBag.carrera = new SelectList((IEnumerable<TBCarrera>)db.TBCarrera.ToList().OrderBy(x => x.nomCarrera),
                "idCarrera", "nomCarrera");
            ViewBag.alumno = new SelectList((IEnumerable<TBAlumno>)db.TBAlumno.ToList().OrderBy(x => x.nombre),
                "codAlu", "nombre");
            return View("AgregarCarrito");
        }

        public ActionResult FinalizarCompra(int idCar, int idAlu)
        {
            List<Fuente> compras = (List<Fuente>)Session["item"];
            if(compras!=null && compras.Count > 0)
            {
                BOLETA newBoleta = new BOLETA();
                newBoleta.FEC_BOL = DateTime.Now;
                newBoleta.idCarrera = idCar;
                newBoleta.codAlu = idAlu;
                newBoleta.DETALLEBOLETA = (from TBLibro in compras
                                           select new DETALLEBOLETA
                                           {
                                               IDE_Lib = TBLibro.TBLibro.IDE_Lib,
                                               CAN_ART = TBLibro.Cantidad
                                           }).ToList();
                db.BOLETA.Add(newBoleta);
                db.SaveChanges();
                Session["item"] = new List<Fuente>();
            }
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }
    }
}