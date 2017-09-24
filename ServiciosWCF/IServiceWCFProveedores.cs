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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceWCFProveedores
    {

        [OperationContract]
        DataSet ObtenerTodos();

        [OperationContract]
        Proveedor ObtenerPorRut(string rut);

        [OperationContract]
        bool AltaProveedor(string RUT, string Nombre, string email, string Telefono, DateTime FechaIni, bool VIP, string pass);
    }
}
