using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVIS_WEB_PROYECTO.Service
{
    public interface IProfesor<T>
    {
        void InsertaProfesor(T p);

        void ActualizarProfesor(T p);

        List<T> ProfesorListar();

        T BuscarProfesor(int idProf);

        void Eliminar(int cod);
    }
}