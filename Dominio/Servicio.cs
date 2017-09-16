using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using System.Data.SqlClient;

namespace Dominio
{
    public class Servicio: ActiveRecord<Servicio>
    {
        public string descripcion { set; get; }
        public string foto { set; get; }
        public List<TipoEvento> listaDeEventos { set; get; }

        public Servicio(string desc,string foto,List<TipoEvento> lista)
        {
            this.descripcion = desc;
            this.foto = foto;
            this.listaDeEventos = lista;
        }

        public override bool Insertar()
        {
            SqlConnection cn = new SqlConnection();

            return true;
        }

        public override bool Eliminar()
        {
            return true;
        }

        public override bool Modificar()
        {
            return true;
        }

        
    }
}
