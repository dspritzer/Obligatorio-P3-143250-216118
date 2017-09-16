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

        public static DataSet ListarProveedores()
        {
            SqlConnection cn = null;
            DataSet ret = new DataSet();
            string cadenaConexion = ConfigurationManager.ConnectionStrings["MiCon"].ConnectionString;
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

        public static DataSet UltimoProv()
        {
            SqlConnection cn = null;
            DataSet ret = new DataSet();
            string cadenaConexion = ConfigurationManager.ConnectionStrings["MiCon"].ConnectionString;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                SqlCommand cmd = new SqlCommand("Select * from Proveedor where idUsuario = (select max(idUsuario) from Proveedor)", cn);
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

        public override bool Insertar()
        {
            SqlConnection cn = null;
            
            string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConDaniel"].ConnectionString;
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
                par.ParameterName = "@provid";
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
                string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConDaniel"].ConnectionString;
                con = new SqlConnection(cadenaConexion);
                SqlCommand cmd = new SqlCommand("ProveedorPorId", con);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    this.Nombre = reader["Nombre"].ToString();
                    this.Precio = reader.GetDecimal(2);
                    retorno = true;
                }
            }
            catch
            {
                throw;
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

            p.Id = id;

            if (p.Leer())
            {
                ret = p;
            }

            return ret;
        }

    }
}
