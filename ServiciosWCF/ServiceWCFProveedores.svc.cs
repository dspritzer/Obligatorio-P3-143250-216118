using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiciosWCF
{
   [DataContract]
    public class ServiceWCFProveedores : IServiceWCFProveedores
    {
        [DataMember]
        DataSet lista;

        [DataMember]
        Proveedor res;

        
        public DataSet ObtenerTodos()
        {
            lista = Proveedor.ListarProveedores();
            return lista;
        }

        public Proveedor ObtenerPorRut(string rut)
        {
            res = Proveedor.BuscarProveeodr(rut);
            return res;
        }

        public bool AltaProveedor(string RUT, string Nombre, string email, string Telefono, bool VIP, string pass)
        {
            bool ok = false;
            Proveedor nuevo = ObtenerPorRut(RUT);

            if (nuevo == null && Nombre !="" && email!="" && Telefono!="" && pass !="")
            {
                DateTime FechaIni = DateTime.Now;
               nuevo = new Proveedor(RUT, Nombre, email, Telefono, FechaIni, VIP, pass);
                nuevo.Insertar();
            }

            return ok;
        }
    }
}
