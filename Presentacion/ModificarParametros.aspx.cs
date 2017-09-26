using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentacion.ServiceReference1;

namespace Presentacion
{
    public partial class ModificarParametros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnModifArancel_Click(object sender, EventArgs e)
        {
            decimal nuevoarancel = Convert.ToDecimal(txtModArancel.Text);

            ServiceWCFProveedoresClient prox = new ServiceWCFProveedoresClient();

            if (prox.modificarArancel(nuevoarancel))
            {
                lblMensajeModif.Text = "Arancel Modificado Correctamente";
            }else
            {
                lblMensajeModif.Text = "Error";
            }

        }

        protected void btnModifPorcVIP_Click(object sender, EventArgs e)
        {
            decimal nuevoPorcVIP = Convert.ToDecimal(txtModArancel.Text);

            ServiceWCFProveedoresClient prox = new ServiceWCFProveedoresClient();

            if (prox.modificarArancel(nuevoPorcVIP))
            {
                lblMensajeModif.Text = "Porcentaje VIP Modificado Correctamente";
            }
            else
            {
                lblMensajeModif.Text = "Error";
            }
        }
        
    }
}