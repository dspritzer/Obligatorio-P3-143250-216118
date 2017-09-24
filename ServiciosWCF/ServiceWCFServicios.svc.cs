using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceWCFServicios" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceWCFServicios.svc or ServiceWCFServicios.svc.cs at the Solution Explorer and start debugging.
    [DataContract]
    public class ServiceWCFServicios : IServiceWCFServicios
    {
        [DataMember]
        DataSet lista;

        public DataSet ObtenerCatalogo()
        {
            lista = Servicio.ListarCatalogo();
            return lista;
        }
    }
}
