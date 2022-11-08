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
    public class MatriculaController : Controller
    {
        // GET: Matricula
        MatriculaDAO matricu = new MatriculaDAO();
        AlumnoDAO alum = new AlumnoDAO();
        SedeDAO sed = new SedeDAO();
        CarreraDAO carrera = new CarreraDAO();
        public ActionResult Index()
        {
            return View(matricu.ListarMatricula().ToList());
        }
        public ActionResult Details(int id)
        {
            return View(matricu.BuscarMatricula(id));
        }

        public ActionResult Create()
        {
            ViewBag.alumnos = new SelectList(alum.AlumnoListar(), "codAlumno", "nomAlumno");
            ViewBag.sedes = new SelectList(sed.SedeListar(), "idSede", "nomSede");
            ViewBag.carreras = new SelectList(carrera.CarreraListar(), "idCarrera", "nomCarrera");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Matricula matri)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    matri.codMatricula = 0;
                    matricu.InsertarMatricula(matri);
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
            ViewBag.alumnos = new SelectList(alum.AlumnoListar(), "codAlumno", "nomAlumno");
            ViewBag.sedes = new SelectList(sed.SedeListar(), "idSede", "nomSede");
            ViewBag.carreras = new SelectList(carrera.CarreraListar(), "idCarrera", "nomCarrera");
            return View(matricu.BuscarMatricula(id));
        }

        [HttpPost]
        public ActionResult Edit(Matricula matri)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    matricu.ActualizarMatricula(matri);
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
