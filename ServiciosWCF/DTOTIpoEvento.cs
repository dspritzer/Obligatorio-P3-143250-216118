using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ServiciosWCF
{
    [DataContract]
    public class DTOTipoEvento
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        
    }
}