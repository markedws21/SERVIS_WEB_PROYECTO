using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVIS_WEB_PROYECTO.Service
{
    public interface IMatricula<T>
    {
        void InsertarMatricula(T p);

        void ActualizarMatricula(T p);

        List<T> ListarMatricula();

        T BuscarMatricula(int idMatricula);
    }
}
