using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HEFESTO.DTE.SERIALIZATION.CLASSES
{
    public class HEFTed
    {

        /// <summary>
        /// Representa el rut del emisor del documento
        /// </summary>
        public string RE { get; set; }

        /// <summary>
        /// Representa el tipo de documento actual del documento
        /// </summary>
        public string TD { get; set; }

        /// <summary>
        /// Representa el folio del documento actual
        /// </summary>
        public string F { get; set; }

        /// <summary>
        /// Representa la fecha de emision del documento actual
        /// </summary>
        public string FE { get; set; }

        /// <summary>
        /// Representa el rut del receptor del documento actual
        /// </summary>
        public string RR { get; set; }

        /// <summary>
        /// Representa razon social del documento actual
        /// </summary>
        public string RSR { get; set; }

        /// <summary>
        /// Representa el monto total del documento actual
        /// </summary>
        public string MNT { get; set; }

        /// <summary>
        /// Representa el nombre del primer item del documento
        /// </summary>
        public string IT1 { get; set; }

        /// <summary>
        /// Representa el nodo caf temporal
        /// </summary>
        public string CAF { get; set; }

        /// <summary>
        /// Representa el nodo TSTED
        /// </summary>
        public string TSTED { get; set; }

    }

}
