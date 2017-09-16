using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public abstract class ActiveRecord<T>
    {
        private static string stringConexion = "";
        public static string StringConexion
        {
            get
            {
                return stringConexion;
            }

            set
            {
                stringConexion = value;
            }
        }

        public abstract bool Insertar();
        public abstract bool Eliminar();
        public abstract bool Modificar();
        public abstract bool Leer();

        public abstract List<T> ListarTodos();


    }
}
