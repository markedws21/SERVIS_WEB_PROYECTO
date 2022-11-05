using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVIS_WEB_PROYECTO.Entity
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string ConfirmarClave { get; set; }
    }
}