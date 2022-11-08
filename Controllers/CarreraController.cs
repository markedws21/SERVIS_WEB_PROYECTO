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
    public class CarreraController : Controller
    {
        CarreraDAO carrera = new CarreraDAO();
        // GET: Carrera
        public ActionResult Index()
        {
            return View(carrera.CarreraListar().ToList());
        }
        public ActionResult Details(int id)
        {
            return View(carrera.BuscarCarrera(id));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Carrera carr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    carr.idCarrera = 0;
                    carrera.InsertarCarrera(carr);
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
            return View(carrera.BuscarCarrera(id));
        }

        [HttpPost]
        public ActionResult Edit(Carrera carr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    carrera.ActualizarCarrera(carr);
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
            Carrera carre = carrera.BuscarCarrera(id);
            if (carre == null)
            {
                return HttpNotFound();
            }
            return View(carre);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Carrera carre = carrera.BuscarCarrera(id);
            carrera.Eliminar(carre.idCarrera);
            return RedirectToAction("Index");

        }
    }
}