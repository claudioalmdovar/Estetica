using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estetica
{
    public class Servicio : Cliente
    {
        public int IdServicios { get; set; }
        public int IdCitas { get; set; }
        public string Descripcion { get; set; }
        public string Observacion { get; set; }
        public decimal Importe { get; set; }
        public DateTime Fecha { get; set; }
    }
}
