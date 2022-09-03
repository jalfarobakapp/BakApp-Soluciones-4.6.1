using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HEFESTO.DTE.AUTENTICACION.ENT
{
    public class Respuesta
    {
        /// <summary>
        /// Indica si el proceso se ejecuto correctamente o no
        /// </summary>
        public bool correcto { get; set; }
        /// <summary>
        /// Mensaje dirigido al usuario indicado el estado del proceso
        /// </summary>
        public string mensaje { get; set; }
        /// <summary>
        /// Detalle del proceso 
        /// </summary>
        public string detalle { get; set; }
        /// <summary>
        /// Resultado del proceso
        /// </summary>
        public object Resultado { get; set; }
    }
}
