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

        public bool Insertar()
        {
            SqlConnection cn = null;
            
            string cadenaConexion = ConfigurationManager.ConnectionStrings["MiCon"].ConnectionString;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertarProveedor";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue
                    ("@RUT", this.RUT);
                cmd.Parameters.AddWithValue
                    ("@pass", this.pass);
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
                cn.Open();
                cmd.ExecuteNonQuery();
                //    trn = cn.BeginTransaction();
                //       cmd.Transaction = trn;
                
                
                //      trn.Commit();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.
                    Debug.Assert(false, "Error: " + ex.Message);
                //      trn.Rollback();
                return false;
            }
            finally { cn.Close(); cn.Dispose(); }
        }

        public bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public bool Modificar()
        {
            throw new NotImplementedException();
        }


    }
}
