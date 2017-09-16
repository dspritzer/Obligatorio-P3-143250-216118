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
   
    public class ServiceWCFProveedores : IServiceWCFProveedores
    {
        

        public DataSet ObtenerTodos()
        {
            DataSet lista = Proveedor.ListarProveedores();
            return lista;
        }
    }
}
