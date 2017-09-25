using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Presentacion.refProv;

namespace Presentacion
{
    public partial class RegistroProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ddlTipoServ.DataSource = listserv();
        }

        protected void Registrar_Click(object sender, EventArgs e)
        {
            refProv.ServiceWCFProveedoresClient client = new refProv.ServiceWCFProveedoresClient();
            client.Open();
            string rut = txtRUT.Text;
            string nombre = txtNombreFantasia.Text;
            string passw = txtPass.Text;
            string mail = txtEmail.Text;
            string tel = txtTelefono.Text;
            string nomserv = txtNomServ.Text;
            string descserv = txtDescServ.Text;
            int tiposerv = Convert.ToInt32(ddlTipoServ.SelectedValue);
            DateTime fecha = new DateTime();
            fecha = DateTime.Today;
            bool vip = false;
            int a = Convert.ToInt32(ddlVIP.SelectedValue);
            if(a== 1)
            {
                vip = true;
            }

            

            client.Open();

            //DS: una vez llenados todos los datos. comenzamos con el alta.
            //DS: creamos la variable que verifique que el archivo es una foto.
            bool archivoOK = false;
            //DS: creamos el path donde guardar las fotos.
            string path = Server.MapPath("fotosServicios");
            //DS: cuando hay una foto seleccionada con el browse
            if (fuFotoServicio.HasFile)
            {
                //DS: obtenemos la extension del archivo. con eso verificamos si es valido
                string extension = System.IO.Path.GetExtension(fuFotoServicio.FileName).ToLower();
                //DS: creamos una pequena lista de string y validamos que las extensiones esten en la lista.
                string[] extensionesPermitidas = { ".gif", ".png", ".jpeg", ".jpg" };
                //DS: recorremos la lista
                for (int i = 0; i < extensionesPermitidas.Length; i++)
                {
                    if (extension == extensionesPermitidas[i])
                    {
                        //DS: si la extension coincide con alguna de la lista. el archivo esta OK.
                        archivoOK = true;
                    }
                }
            }



            if (archivoOK && client.insertar(rut, nombre, mail, tel, fecha, vip, passw,nomserv,descserv,tiposerv, fuFotoServicio.FileName))
            {
                lblMensajeIngresoProv.Text = "Registro exitoso";

                //DS: si todo esta OK guaramos la imagen
                string nombreImagen = fuFotoServicio.FileName;
                fuFotoServicio.SaveAs(path + "\\" + nombreImagen);


                grvNuevoProv.Visible = true;

                grvNuevoProv.DataSource = Proveedor.UltimoProv(rut);
                grvNuevoProv.DataBind();

            }else
            {
                lblMensajeIngresoProv.Text = "Error en el ingreso.";
            }
        }

        public List<TipoServicio> listserv()
        {
            refProv.ServiceWCFProveedoresClient client = new refProv.ServiceWCFProveedoresClient();
            client.Open();

            List<TipoServicio> listserv = new List<TipoServicio>();
            
            //List<DTOTipoServicio> ls = client.listarTiposServ();
            

            return listserv;
        }
    }
}