
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace ServicesWCF
{
    [DataContract]
    public class ServiceWCFProveedores : IServiceWCFProveedores
    {


        

        public bool insertar(string rut, string nombre, string mail, string tel, DateTime fecha, bool vip, string passw, string nomserv, string descserv, int tiposerv, string fotoserv)
        {


            DTOProveedor p = new DTOProveedor(rut, nombre, mail, tel, fecha, vip, Encryptdata(passw));
            DTOServicio s = new DTOServicio(nomserv, descserv, tiposerv, fotoserv);

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
                    ("@RUT", p.RUT);
                cmnd.Parameters.AddWithValue
                    ("@pass", p.pass);
                cmnd.Parameters.AddWithValue
                    ("@TipoUser", 2);
                cmnd.Transaction = tran;
                cmnd.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertarProveedor";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue
                    ("@RUT", p.RUT);
                cmd.Parameters.AddWithValue
                    ("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue
                    ("@email", p.email);
                cmd.Parameters.AddWithValue
                    ("@telefono", p.telefono);
                cmd.Parameters.AddWithValue
                    ("@FechaIni", p.FechaIni);
                cmd.Parameters.AddWithValue
                    ("@VIP", p.VIP);
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@idprov";
                par.SqlDbType = SqlDbType.Int;
                par.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(par);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                SqlCommand cmm = new SqlCommand("InsertarServicio", cn);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.AddWithValue("@Nombre", s.Nombre);
                cmm.Parameters.AddWithValue("@TipoServ", leerTipoServicio(tiposerv).Id);
                cmm.Parameters.AddWithValue("@Desc", s.Descripcion);
                cmm.Parameters.AddWithValue("@foto", s.foto);
                cmm.Parameters.AddWithValue("@idprov", par.Value);
                cmm.Transaction = tran;
                cmm.ExecuteNonQuery();
                tran.Commit();
                p.Id = (int)par.Value;
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.
                    Debug.Assert(false, "Error: " + ex.Message);
                tran.Rollback();
                return false;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

        }

        public List<DTOTipoServicio> listarTiposServ()
        {
            List<DTOTipoServicio> lista = new List<DTOTipoServicio>();

            SqlConnection con = null;
            SqlDataReader reader = null;

            try
            {

                string cadenaConexion = ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString;
                con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from TipoServicio", con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DTOTipoServicio ts = new DTOTipoServicio();

                    int id = Convert.ToInt32(reader["idTipoServicio"].ToString());
                    ts = leerTipoServicio(id);
                    lista.Add(ts);
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

        public List<DTOTipoEvento> listarTiposEvPorServ(int id)
        {
            List<DTOTipoEvento> lista = new List<DTOTipoEvento>();
            SqlConnection con = null;
            SqlDataReader reader = null;
            try
            {
                string cadenaConexion = ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString;
                con = new SqlConnection(cadenaConexion);
                SqlCommand cmd = new SqlCommand("Select * from TipoServicio_Eventos where idTipoServicio = " + id, con);
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DTOTipoEvento te = new DTOTipoEvento();
                    te = leerTipoEvento((int)reader["idTipoEvento"]);
                    lista.Add(te);
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

            return lista;
        }


        public DTOServicio leerServicio(int id)
        {
            DTOServicio s = new DTOServicio();
            s.Id = id;


            SqlConnection con = null;
            SqlDataReader reader = null;
            try
            {
                string cadenaConexion = ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString;
                con = new SqlConnection(cadenaConexion);
                SqlCommand cmd = new SqlCommand("ServicioPorId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", s.Id);
                con.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    s.Id = (int)reader["idServicio"];
                    s.Nombre = reader["nombre"].ToString();
                    s.foto = reader["foto"].ToString();
                    s.Descripcion = reader["descripcion"].ToString();
                    s.tipoServ = leerTipoServicio((int)reader["idTipoServ"]);
                    s.prov = leerProveedor((int)reader["idprov"]);


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

            return s;
        }
        public DTOProveedor leerProveedor(int id)
        {
            DTOProveedor s = new DTOProveedor();
            s.Id = id;


            SqlConnection con = null;
            SqlDataReader reader = null;
            try
            {
                string cadenaConexion = ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString;
                con = new SqlConnection(cadenaConexion);
                SqlCommand cmd = new SqlCommand("ProveedorPorId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", s.Id);
                con.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    s.Id = (int)reader["idProveedor"];
                    s.RUT = reader["RUT"].ToString();
                    s.Nombre = reader["nombreFantasia"].ToString();
                    s.email = reader["email"].ToString();
                    s.telefono = reader["telefono"].ToString();
                    s.FechaIni = reader.GetDateTime(reader.GetOrdinal("fechaReg"));
                    s.VIP = reader.GetBoolean(reader.GetOrdinal("VIP"));


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

            return s;
        }
        public DTOTipoServicio leerTipoServicio(int id)
        {
            DTOTipoServicio ts = new DTOTipoServicio();
            ts.Id = id;


            SqlConnection con = null;
            SqlDataReader reader = null;
            try
            {
                string cadenaConexion = ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString;
                con = new SqlConnection(cadenaConexion);
                SqlCommand cmd = new SqlCommand("TipoServPorId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ts.Id);
                con.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    ts.Id = (int)reader["idTipoServicio"];
                    ts.Nombre = reader["nombre"].ToString();
                    ts.listaEventos = listarTiposEvPorServ(ts.Id);
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

            return ts;
        }
        public DTOTipoEvento leerTipoEvento(int id)
        {
            DTOTipoEvento te = new DTOTipoEvento();
            te.Id = id;


            SqlConnection con = null;
            SqlDataReader reader = null;
            try
            {
                string cadenaConexion = ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString;
                con = new SqlConnection(cadenaConexion);
                SqlCommand cmd = new SqlCommand("TipoEventoPorId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", te.Id);
                con.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    te.Id = (int)reader["idTipoEvento"];
                    te.Nombre = reader["nombre"].ToString();
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

            return te;
        }

        public bool desactivarProveedor(int id)
        {
            bool ret = false;

            SqlConnection con = null;
            SqlDataReader reader = null;
            try
            {
                string cadenaConexion = ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString;
                con = new SqlConnection(cadenaConexion);
                SqlCommand cmd = new SqlCommand("DesactivarProveedor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
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

            return ret;
        }

        public bool modificarArancel(decimal valor)
        {
            bool ret = false;

            SqlConnection con = null;
            SqlDataReader reader = null;
            try
            {
                string cadenaConexion = ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString;
                con = new SqlConnection(cadenaConexion);
                SqlCommand cmd = new SqlCommand("ModificarArancel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@valor", valor);
                con.Open();
                cmd.ExecuteNonQuery();
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

            return ret;
        }


        public bool modificarPorcentajeVIP(decimal porcentaje)
        {
            bool ret = false;

            SqlConnection con = null;
            SqlDataReader reader = null;
            try
            {
                string cadenaConexion = ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString;
                con = new SqlConnection(cadenaConexion);
                SqlCommand cmd = new SqlCommand("ModificarPorcentajeVIP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@valor", porcentaje);
                con.Open();
                cmd.ExecuteNonQuery();
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

            return ret;
        }

        public List<DTOProveedor> devolverProveedores()
        {
            List<DTOProveedor> lista = new List<DTOProveedor>();

            
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
                    DTOProveedor ts = new DTOProveedor();

                    int Id = Convert.ToInt32(reader["idProveedor"].ToString());
                    ts = leerProveedor(Id);
                    lista.Add(ts);
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


        public DataTable buscarUsuario(string name, string pass)
        {
            DataTable dt_SignUp = new DataTable();
            if (pass == "admin")
            {
                SqlDataAdapter c1 = new SqlDataAdapter("select * from Usuario where username = '" + name + "' and pass = '" + pass + "'", ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString);
                c1.Fill(dt_SignUp);
            }
            else
            {

                SqlDataAdapter c1 = new SqlDataAdapter("select * from Usuario where username = '" + name + "' and pass = '" + Encryptdata(pass), ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString);
                c1.Fill(dt_SignUp);
            }
            
            return dt_SignUp;
        }

        public string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
        public string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }
    }
}
