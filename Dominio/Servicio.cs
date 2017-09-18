
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

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

        public override bool Leer()
        {
            return true;
        }

        public override List<Servicio> ListarTodos()
        {
            List<Servicio> a = null;
            return a;
        }

        public static DataSet ListarCatalogo()
        {
            SqlConnection cn = null;
            DataSet ret = new DataSet();
            string cadenaConexion = ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                SqlCommand cmd = new SqlCommand("Select * from Servicios", cn);
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ret);
            }
            catch (Exception ex)
            {
                System.Diagnostics.
                Debug.Assert(false, "Error: " + ex.Message);
                //trn.Rollback();

            }
            finally { cn.Close(); cn.Dispose(); }

            return ret;
        }
    }
}
