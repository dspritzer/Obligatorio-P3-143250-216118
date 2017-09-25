using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoServicio
    {
        public int Id { set; get; }
        public string Nombre { get; set; }
        
        public List<TipoEvento> listaEventos { get; set; }
    }
}
