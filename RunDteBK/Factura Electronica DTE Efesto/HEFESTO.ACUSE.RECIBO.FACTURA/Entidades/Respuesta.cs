using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hefesto.Acuse.Recibo.Factura
{
    /// <summary>
    /// Entidad respuesta
    /// </summary>
    public class Respuesta
    {
        public bool EsCorrecto { get; set; }
        public string Mensaje { get; set; }
        public string Detalle { get; set; }
        public object Resultado { get; set; }

    }
}
