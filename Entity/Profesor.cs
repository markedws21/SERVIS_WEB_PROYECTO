using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SERVIS_WEB_PROYECTO.Entity
{
    public class Profesor
    {
        [Display(Name = "CÓDIGO")]
        public int codProf { get; set; }
        [Display(Name = "NOMBRE")]
        public string nombre { get; set; }
        [Display(Name = "APELLIDO")]
        public string apellido { get; set; }
        [Display(Name = "DNI")]
        public string dni { get; set; }
        [Display(Name = "CORREO")]
        public string correo { get; set; }
        [Display(Name = "CELULAR")]
        public string celular { get; set; }
    }
}