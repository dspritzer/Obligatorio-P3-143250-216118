using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;


namespace Presentacion
{
    public partial class ListadoProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMostrarProv_Click(object sender, EventArgs e)
        {/*
            grvMostrarProv.Visible = true;
            Proveedor p = new Proveedor();
            grvMostrarProv.DataSource = p.ListarTodos();
            grvMostrarProv.DataBind();*/

            Services.ServiceWCFProveedoresClient cliente = new Services.ServiceWCFProveedoresClient();
            cliente.Open();
            grvMostrarProv.DataSource = cliente.ObtenerTodos();
            grvMostrarProv.DataBind();

        }
    }
}