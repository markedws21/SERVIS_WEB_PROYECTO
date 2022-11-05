using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SERVIS_WEB_PROYECTO.Entity
{
    public class Matricula
    {
        [Display(Name = "Código Matrícula")]
        public int codMatricula { get; set; }
        [Display(Name = "Alumno")]
        public int codAlumno { get; set; }
        [Display(Name = "Carrera")]
        public int idCarrera { get; set; }
        [Display(Name = "Ciclo")]
        public string ciclo { get; set; }
        [Display(Name = "Sede")]
        public int idSede { get; set; }
    }
}
