using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using SERVIS_WEB_PROYECTO.Entity;
using SERVIS_WEB_PROYECTO.Models;
using SERVIS_WEB_PROYECTO.Permisos;

namespace SERVIS_WEB_PROYECTO.Controllers
{
    [ValidarSesion]
    public class AlumnoController : Controller
    {
        // GET: Alumno
        AlumnoDAO alum = new AlumnoDAO();

        public ActionResult Index()
        {
            return View(alum.AlumnoListar().ToList());
        }

        public ActionResult Details(int id)
        {
            return View(alum.BuscarAlumno(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Alumno alu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    alu.codAlumno = 0;
                    alum.InsertarAlumno(alu);
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
            return View(alum.BuscarAlumno(id));
        }

        [HttpPost]
        public ActionResult Edit(Alumno alu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    alum.ActualizarAlumno(alu);
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


    }
}