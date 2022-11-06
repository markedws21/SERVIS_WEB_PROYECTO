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
    public class AsignaturaController : Controller
    {
        // GET: Asignatura
        AsignaturaDAO asig = new AsignaturaDAO();
        public ActionResult Index()
        {
            return View(asig.AsignaturaListar().ToList());
        }

        public ActionResult Details(int id)
        {
            return View(asig.BuscarAsignatura(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Asignatura asi)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    asi.idAsignatura = 0;
                    asig.InsertarAsignatura(asi);
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
            return View(asig.BuscarAsignatura(id));
        }

        [HttpPost]
        public ActionResult Edit(Asignatura asi)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    asig.ActualizarAsignatura(asi);
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
            Asignatura asignatura = asig.BuscarAsignatura(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Asignatura asignatura = asig.BuscarAsignatura(id);
            asig.Eliminar(asignatura.idAsignatura);
            return RedirectToAction("Index");

        }


    }
}