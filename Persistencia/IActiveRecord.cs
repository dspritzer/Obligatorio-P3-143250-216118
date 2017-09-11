using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public interface IActiveRecord
    {
        bool Insertar();
        bool Eliminar();
        bool Modificar();

    }
}
