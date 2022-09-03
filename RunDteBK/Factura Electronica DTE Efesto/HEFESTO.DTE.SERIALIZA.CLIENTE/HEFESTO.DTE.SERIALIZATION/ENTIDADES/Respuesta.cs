using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HEFESTO.DTE.SERIALIZATION.ENTIDADES
{
    /// <summary>
    /// Regresa el resultado de las operaciones internas
    /// </summary>
    public class Respuesta
    {
        /// <summary>
        /// Indica si el proceso actual se ejecuto correctamente
        /// </summary>
        public bool Correcto { get; set; }

        /// <summary>
        /// Mensaje destinado al entendimiento del usuario
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Mensaje tecnico.
        /// </summary>
        public string Detalle { get; set; }

        /// <summary>
        /// Valor de respuesta del proceso
        /// </summary>
        public object Resultado { get; set; }



    }

}
