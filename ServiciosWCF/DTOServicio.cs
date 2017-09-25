using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ServiciosWCF
{
    [DataContract]
    public class DTOServicio
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string foto { get; set; }
        [DataMember]
        public DTOTipoServicio tipoServ { get; set; }
        [DataMember]
        public DTOProveedor prov { get; set; }

        public DTOServicio(string nomserv, string descserv, int tiposerv, string fotoserv)
        {
            this.Nombre = nomserv;
            this.Descripcion = descserv;
            this.foto = fotoserv;
            
        }

        public DTOServicio()
        {

        }
        
    }
}