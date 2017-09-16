using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoEvento:IActiveRecord<TipoEvento>
    {
        public string nombre { set; get; }

        public bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public bool Insertar()
        {
            throw new NotImplementedException();
        }

        public bool Modificar()
        {
            throw new NotImplementedException();
        }
    }
}
