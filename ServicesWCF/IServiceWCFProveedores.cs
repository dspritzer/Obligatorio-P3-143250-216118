using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace ServicesWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceWCFProveedores
    {

        

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
        [OperationContract]
        bool modificarArancel(decimal valor);
        [OperationContract]
        bool modificarPorcentajeVIP(decimal porcentaje);
        [OperationContract]
        DTOProveedor leerProveedor(int id);
        [OperationContract]
        List<DTOProveedor> devolverProveedores();
        [OperationContract]
        DataTable buscarUsuario(string name, string pass);
        [OperationContract]
        string Decryptdata(string encryptpwd);
        [OperationContract]
        string Encryptdata(string password);
    }



    
}
