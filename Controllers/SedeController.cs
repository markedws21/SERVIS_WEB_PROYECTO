using SERVIS_WEB_PROYECTO.Entity;
using SERVIS_WEB_PROYECTO.Models;
using SERVIS_WEB_PROYECTO.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVIS_WEB_PROYECTO.Controllers
{
    [ValidarSesion]
    public class SedeController : Controller
    {
        // GET: Asignatura
        SedeDAO sede = new SedeDAO();
        public ActionResult Index()
        {
            return View(sede.SedeListar().ToList());
        }

        public ActionResult Details(int id)
        {
            return View(sede.BuscarSede(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Sede sed)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sed.idSede = 0;
                    sede.InsertarSede(sed);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(sede.BuscarSede(id));
        }

        [HttpPost]
        public ActionResult Edit(Sede sed)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sede.ActualizarSede(sed);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Sede sed= sede.BuscarSede(id);
            if (sed == null)
            {
                return HttpNotFound();
            }
            return View(sed);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Sede se = sede.BuscarSede(id);
            sede.Eliminar(se.idSede);
            return RedirectToAction("Index");

        }


    }
}