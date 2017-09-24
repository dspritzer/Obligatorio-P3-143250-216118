using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
