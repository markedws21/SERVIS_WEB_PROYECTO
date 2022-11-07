﻿using SERVIS_WEB_PROYECTO.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVIS_WEB_PROYECTO.Controllers
{
    [ValidarSesion]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CerrarSesion()
        {
            Session["usuario"] = null;
            return RedirectToAction("Login", "Acceso");
        }
      
    }
}