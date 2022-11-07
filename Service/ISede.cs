using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVIS_WEB_PROYECTO.Service
{
    public interface ISede<T>
    {
        void InsertarSede(T p);

        void ActualizarSede(T p);

        List<T> SedeListar();

        T BuscarSede(int idAsignatura);

        void Eliminar(int id);
    }
}