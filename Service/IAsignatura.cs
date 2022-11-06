using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVIS_WEB_PROYECTO.Service
{
    public interface IAsignatura<T>
    {
        void InsertarAsignatura(T p);

        void ActualizarAsignatura(T p);

        List<T> AsignaturaListar();

        T BuscarAsignatura(int idAsignatura);

        void Eliminar(int id);
    }
}
