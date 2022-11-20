using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SERVIS_WEB_PROYECTO.ModeloDatos;
using SERVIS_WEB_PROYECTO.Permisos;

namespace SERVIS_WEB_PROYECTO.Controllers
{
    [ValidarSesion]
    public class LibroController : Controller
    {
        private BDInstituto2Entities db = new BDInstituto2Entities();
        // GET: Libro
        public ActionResult Index()
        {
            return View(db.TBLibro.ToList().OrderBy(x=>x.DES_Lib));
        }
    }
}