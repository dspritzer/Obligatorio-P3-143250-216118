using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosWCF
{
    public class ProveedorDTO
    {

        public int Id { get; set; }
        public string RUT { get; set; }

        public string pass { get; set; }
        public string Nombre { get; set; }

        public string email { get; set; }

        public string telefono { get; set; }

        public DateTime FechaIni { get; set; }

        public bool VIP { get; set; }

        public static double Arancel { get; set; }

        public static double ArancelVIP { get; set; }

        public ProveedorDTO(string RUT, string Nombre, string email, string Telefono, DateTime FechaIni, bool VIP, string pass)
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