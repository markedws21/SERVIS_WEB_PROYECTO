using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVIS_WEB_PROYECTO.Service
{
    public interface ICarrera<T>
    {
        void InsertarCarrera(T p);

        void ActualizarCarrera(T p);

        List<T> CarreraListar();

        T BuscarCarrera(int idCarrera);

        void Eliminar(int id);
    }
}
