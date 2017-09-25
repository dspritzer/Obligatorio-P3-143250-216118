using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Dominio;

namespace ServiciosWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceWCFProveedores
    {

        [OperationContract]
        List<Proveedor> ObtenerTodos();

        [OperationContract]
        bool insertar(string rut, string nombre, string mail, string tel, DateTime fecha, bool vip, string passw, string nomserv, string descserv, int tiposerv, string fotoserv);
        [OperationContract]
        List<DTOTipoServicio> listarTiposServ();
        [OperationContract]
        List<DTOTipoEvento> listarTiposEvPorServ(int id);
        [OperationContract]
        DTOServicio leerServicio(int id);
        [OperationContract]
        DTOTipoServicio leerTipoServicio(int id);
        [OperationContract]
        DTOTipoEvento leerTipoEvento(int id);
        [OperationContract]
        bool desactivarProveedor(int id);
    }
}
