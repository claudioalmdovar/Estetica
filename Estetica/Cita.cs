using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estetica
{
    public class Cita : Cliente
    {
        public int IdCitas { get; set; }
        public DateTime Fecha { get; set; }
        public string Observacion { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
    }
}
