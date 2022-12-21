using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HEFSIIREGCOMPRAVENTAS.LIB
{
    /// <summary>
    /// Respuesta de los procesos generados
    /// </summary>
    public class HefRespuesta
    {
        public bool EsCorrecto { get; set; }
        public string Mensaje { get; set; }
        public string Detalle { get; set; }
        public string Resultado { get; set; }
        public string Directorio { get; set; }
    }
}
