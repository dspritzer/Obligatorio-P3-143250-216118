using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentacion.refProv;

namespace Presentacion
{
    public partial class DesactivarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            refProv.ServiceWCFProveedoresClient prox = new refProv.ServiceWCFProveedoresClient();
            int id = Convert.ToInt32(txtidprov.Text);
            prox.desactivarProveedor(id);
        }
    }
}