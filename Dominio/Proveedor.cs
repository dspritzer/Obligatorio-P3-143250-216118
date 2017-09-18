using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Dominio
{
    public class Proveedor: ActiveRecord<Proveedor>

    {
        public int Id { get; set; }
        public string RUT { get; set; }

        public string pass { get; set; }
        public string Nombre { get; set; }

        public string email { get; set; }

        public string telefono { get; set; }

        public DateTime FechaIni { get; set; }

        public bool VIP { get; set; }

        public static double Arancel { get; set; }

        public static double ArancelVIP { get; set; }

        public Proveedor(string RUT, string Nombre, string email, string Telefono, DateTime FechaIni, bool VIP, string pass)
        {
            this.RUT = RUT;
            this.Nombre = Nombre;
            this.email = email;
            this.telefono = Telefono;
            this.FechaIni = FechaIni;
            this.VIP = VIP;
            this.pass = pass;
            
        }

        public Proveedor()
        {
        }

        public static DataSet ListarProveedores()
        {
            SqlConnection cn = null;
            DataSet ret = new DataSet();

            string cadenaConexion = ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString;

            try
            {
                cn = new SqlConnection(cadenaConexion);
                SqlCommand cmd = new SqlCommand("Select * from Proveedor",cn);
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ret);
                

            }
            catch (Exception ex)
            {
                System.Diagnostics.
                    Debug.Assert(false, "Error: " + ex.Message);
                //      trn.Rollback();
                
            }
            finally { cn.Close(); cn.Dispose(); }

            return ret;
        }

        public static List<Proveedor> UltimoProv(string i)
        {
            List<Proveedor> ret = new List<Proveedor>();

            ret.Add(BuscarProveeodr(i));

            return ret;
        }

        public override bool Insertar()
        {
            SqlConnection cn = null;
            

            string cadenaConexion = ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString;

            cn = new SqlConnection(cadenaConexion);
            cn.Open();
            
            SqlTransaction tran = cn.BeginTransaction();
            try
            {
                SqlCommand cmnd = new SqlCommand();
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.CommandText = "InsertarUsuario";
                cmnd.Connection = cn;
                cmnd.Parameters.AddWithValue
                    ("@RUT", this.RUT);
                cmnd.Parameters.AddWithValue
                    ("@pass", this.pass);
                cmnd.Parameters.AddWithValue
                    ("@TipoUser", 2);
                cmnd.Transaction = tran;
                cmnd.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertarProveedor";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue
                    ("@RUT", this.RUT);
                cmd.Parameters.AddWithValue
                    ("@Nombre", this.Nombre);
                cmd.Parameters.AddWithValue
                    ("@email", this.email);
                cmd.Parameters.AddWithValue
                    ("@telefono", this.telefono);
                cmd.Parameters.AddWithValue
                    ("@FechaIni", this.FechaIni);
                cmd.Parameters.AddWithValue
                    ("@VIP", this.VIP);
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@idprov";
                par.SqlDbType = SqlDbType.Int;
                par.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(par);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                this.Id = (int)par.Value;             
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.
                    Debug.Assert(false, "Error: " + ex.Message);
                      tran.Rollback();
                return false;
            }
            finally { cn.Close(); cn.Dispose(); }
        }

        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public override bool Modificar()
        {
            throw new NotImplementedException();
        }
        public override bool Leer()
        {
            bool retorno = false;
            SqlConnection con = null;
            SqlDataReader reader = null;
            try
            {

                string cadenaConexion = ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString;

                con = new SqlConnection(cadenaConexion);
                SqlCommand cmd = new SqlCommand("ProveedorPorId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RUT", this.RUT);
                con.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    
                    this.Id = (int)reader["idProveedor"];
                    this.Nombre = reader["nombreFantasia"].ToString();
                    this.email = reader["email"].ToString();
                    this.telefono = reader["telefono"].ToString();
                    this.FechaIni = reader.GetDateTime(reader.GetOrdinal("fechaReg"));
                    this.VIP = reader.GetBoolean(reader.GetOrdinal("VIP"));
                    
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, "Error: " + ex.Message); ;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();
                if (reader != null) reader.Close();
            }

            return retorno;
        }

        public static Proveedor BuscarProveeodr(string rut)
        {
            Proveedor p = new Proveedor();

            Proveedor ret = null;

            p.RUT = rut;

            if (p.Leer())
            {
                ret = p;
            }

            return ret;
        }

        public override List<Proveedor> ListarTodos()
        {
            List<Proveedor> lista = new List<Proveedor>();

            SqlConnection con = null;
            SqlDataReader reader = null;

            try
            {

                string cadenaConexion = ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString;

                con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Proveedor", con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Proveedor prov = new Proveedor();
                    
                    prov.RUT = reader["RUT"].ToString();
                    prov.Leer();
                    lista.Add(prov);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.
                    Debug.Assert(false, "Error: " + ex.Message);
                
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();
                if (reader != null) reader.Close();
            }

            return lista;
        }

    }
}
