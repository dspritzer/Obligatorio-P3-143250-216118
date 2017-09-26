using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Presentacion.ServiceReference1;


namespace Presentacion
{
    public partial class ListadoProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMostrarProv_Click(object sender, EventArgs e)
        {
            ServiceWCFProveedoresClient prox = new ServiceWCFProveedoresClient();
            prox.Open();
            List<DTOProveedor> lista = prox.devolverProveedores().ToList();
            List<Proveedor> lp = new List<Proveedor>();
            foreach(DTOProveedor dp in lista)
            {
                Proveedor p = new Proveedor();
                p.Id = dp.Id;
                p.Nombre = dp.Nombre;
                p.email = dp.email;
                p.telefono = dp.telefono;
                p.FechaIni = dp.FechaIni;
                p.VIP = dp.VIP;
                lp.Add(p);
            }

            grvMostrarProv.DataSource = lp;
            grvMostrarProv.DataBind();
            grvMostrarProv.Visible = true;

        }
    }
}