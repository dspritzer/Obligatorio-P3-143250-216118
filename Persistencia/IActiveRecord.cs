using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public interface IActiveRecord<T>
    {

        bool Insertar();
        bool Eliminar();
        bool Modificar();

    }
}
