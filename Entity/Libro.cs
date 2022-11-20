using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVIS_WEB_PROYECTO.Entity
{
    public class Libro
    {
        public int IDE_Lib { get; set; }
        public string DES_Lib { get; set; }
        public int idAsignatura { get; set; }
        public double PRE_Lib { get; set; }
        public string IMG_PRO { get; set; }
    }
}