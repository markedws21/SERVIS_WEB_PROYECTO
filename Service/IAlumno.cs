using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVIS_WEB_PROYECTO.Service
{
    public interface IAlumno<T>
    {
        void InsertarAlumno(T p);

        void ActualizarAlumno(T p);

        List<T> AlumnoListar();

        T BuscarAlumno(int idAlumno);
    }
}
