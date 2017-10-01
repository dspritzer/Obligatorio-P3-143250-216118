using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class PagMaestra : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MenuAdministrador.Visible = false;
                MenuProveedor.Visible = false;
                MenuOrganizador.Visible = false;




                string nombre = (string)Session["usuario"];
                lblBienvenida.Text = "Bienvenido " + nombre;

                
                if ("" != Session["tipoUser"])
                {



                    if (1 == (int)Session["tipoUser"])
                    {
                        MenuAdministrador.Visible = true;
                    }
                    else if (2 == (int)Session["tipoUser"])
                    {
                        MenuProveedor.Visible = true;
                    }
                    else if (3 == (int)Session["tipoUser"])
                    {
                        MenuOrganizador.Visible = true;
                    }
                }
            }



        }
    }
}