using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SERVIS_WEB_PROYECTO.ModeloDatos;

namespace SERVIS_WEB_PROYECTO.ModeloDatos
{
    public class Fuente
    {
        private TBLibro _libro;

        public TBLibro TBLibro
        {
            get { return _libro; }
            set { _libro = value; }
        }

        private int _cantidad;

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public Fuente() { }

        public Fuente(TBLibro libro, int cantidad)
        {
            this._libro = libro;
            this._cantidad = cantidad;
        }

    }
}