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
        
        public ActionResult Edit(int codigo)
        {
            return View(prof.BuscarProfesor(codigo));
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
    }
}