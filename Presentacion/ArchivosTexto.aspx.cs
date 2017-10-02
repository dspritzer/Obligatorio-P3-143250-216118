using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentacion.ServiceReference1;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Presentacion
{
    public partial class ArchivosTexto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProvTexto_Click(object sender, EventArgs e)
        {
            ServiceWCFProveedoresClient prox = new ServiceWCFProveedoresClient();
            prox.Open();
            if (prox.provATexto())
            {
                lblMensajeArchivos.Text = "proveedores guardados correctamente";
            }
            else
            {
                lblMensajeArchivos.Text = "error";
            }
        }

        protected void btnServTexto_Click(object sender, EventArgs e)
        {
            //SqlConnection con = null;
            //SqlDataReader reader = null;
            //try
            //{

            //    string cadenaConexion = ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString;
            //    con = new SqlConnection(cadenaConexion);
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("TextoServicios", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    reader = cmd.ExecuteReader();

            //    GridView1.DataSource = reader;
            //    GridView1.DataBind();
            //    GridView1.Visible = true;
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.
            //        Debug.Assert(false, "Error: " + ex.Message);

            //}
            //finally
            //{
            //    if (con != null && con.State == ConnectionState.Open) con.Close();
            //    if (reader != null) reader.Close();

            //}
            ServiceWCFProveedoresClient prox = new ServiceWCFProveedoresClient();
            prox.Open();
            if (prox.servATexto())
            {
                lblMensajeArchivos.Text = "servicios guardados correctamente";



            }
            else
            {
                lblMensajeArchivos.Text = "error";
            }
        }
    }
}