using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Dominio;

namespace ServiciosWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceWCFServicios" in both code and config file together.
    [ServiceContract]
    public interface IServiceWCFServicios
    {
        [OperationContract]
        DataSet ObtenerCatalogo();
    }
}
