using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SERVIS_WEB_PROYECTO.Entity;
using SERVIS_WEB_PROYECTO.Models;
using SERVIS_WEB_PROYECTO.Permisos;

namespace SERVIS_WEB_PROYECTO.Controllers
{
    [ValidarSesion]
    public class ProfesorController : Controller
    {      
        // GET: Profesor
        ProfesorDAO prof = new ProfesorDAO();
        public ActionResult Index()
        {
            return View(prof.ProfesorListar().ToList());
        }
        public ActionResult Details(int id)
        {
            return View(prof.BuscarProfesor(id));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Profesor pro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    pro.codProf = 0;
                    prof.InsertaProfesor(pro);
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
            return View(prof.BuscarProfesor(id));
        }

        [HttpPost]
        public ActionResult Edit(Profesor pro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    prof.ActualizarProfesor(pro);
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
            Profesor profe = prof.BuscarProfesor(id);
            if(profe == null)
            {
                return HttpNotFound();
            }
            return View(profe);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Profesor profe = prof.BuscarProfesor(id);
            prof.Eliminar(profe.codProf);
            return RedirectToAction("Index");
        }
        /*
         public ActionResult Delete(int id)
        {
            Alumno alumnno = alum.BuscarAlumno(id);
            if(alumnno == null)
            {
                return HttpNotFound();
            }
            return View(alumnno);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Alumno alumno = alum.BuscarAlumno(id);
            alum.Eliminar(alumno.codAlumno);
            return RedirectToAction("Index");

        }
         */
    }
}