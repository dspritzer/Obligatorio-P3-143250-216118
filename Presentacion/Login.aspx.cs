using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using System.Data;
using System.Data.SqlClient;
using Presentacion.ServiceReference1;

namespace Presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["usuario"] = "";
                Session["tipoUser"] = "";
            }
        }

        protected void Login1_Authenticate1(object sender, AuthenticateEventArgs e)
        {
            ServiceWCFProveedoresClient client = new ServiceWCFProveedoresClient();
            client.Open();
            DataTable dt = client.buscarUsuario(Login1.UserName, Login1.Password);

            if (dt.Rows.Count > 0)
            {
                Session["usuario"] = dt.Rows[0]["username"].ToString();
                Session["tipoUser"] = Convert.ToInt32(dt.Rows[0]["idTipoUser"].ToString());
                Response.Redirect("~/Principal.aspx");
            }

            else
            {
                //DS: si no se muestra el mensaje predefinido en el loginbox.
                e.Authenticated = false;
            }
        }
    }
}
