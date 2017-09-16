using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Presentacion
{
    public partial class RegistroProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Registrar_Click(object sender, EventArgs e)
        {
            string rut = txtRUT.Text;
            string nombre = txtNombreFantasia.Text;
            string passw = txtPass.Text;
            string mail = txtEmail.Text;
            string tel = txtTelefono.Text;
            DateTime fecha = new DateTime();
            fecha = DateTime.Today;
            bool vip = false;
            int a = Convert.ToInt32(ddlVIP.SelectedValue);
            if(a== 1)
            {
                vip = true;
            }

            Proveedor p = new Proveedor(rut, nombre, mail, tel, fecha, vip,passw);

            if (p.Insertar())
            {
                lblMensajeIngresoProv.Text = "Registro exitoso";

                grvNuevoProv.Visible = true;

                grvNuevoProv.DataSource = Proveedor.UltimoProv(rut);
                grvNuevoProv.DataBind();

            }else
            {
                lblMensajeIngresoProv.Text = "Error en el ingreso.";
            }
        }
    }
}