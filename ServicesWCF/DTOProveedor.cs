using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ServicesWCF
{
    [DataContract]
    public class DTOProveedor
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string RUT { get; set; }
        [DataMember]
        public string pass { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string telefono { get; set; }
        [DataMember]
        public DateTime FechaIni { get; set; }
        [DataMember]
        public bool VIP { get; set; }

        public DTOProveedor()
        {

        }

        public DTOProveedor(string RUT, string Nombre, string email, string Telefono, DateTime FechaIni, bool VIP, string pass)
        {
            this.RUT = RUT;
            this.Nombre = Nombre;
            this.email = email;
            this.telefono = Telefono;
            this.FechaIni = FechaIni;
            this.VIP = VIP;
            this.pass = pass;

        }

        
    }
}