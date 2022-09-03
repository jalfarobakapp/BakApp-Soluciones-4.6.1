using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HEFESTO.DTE.SERIALIZATION.CLASSES
{

    /// <summary>
    /// Representa las referencias de notas de credito o debito
    /// </summary>
    public class HEFReferencia
    {

        /// <summary>
        /// Representa el numero de linea del documento referenciado
        /// </summary>
        public int NroLinRef { get; set; }

        /// <summary>
        /// Representa el tipo de documento referenciado
        /// </summary>
        public string TpoDocRef { get; set; }

        /// <summary>
        /// Representa el folio del documento referenciado
        /// </summary>
        public long FolioRef { get; set; }

        /// <summary>
        /// Representa la fecha de emision del documento referenciado
        /// </summary>
        public string FchRef { get; set; }

        /// <summary>
        /// Representa el codigo de la referencia
        /// </summary>
        /// <remarks>
        /// 1- Anula documento
        /// 2- Corrige texto del documento referenciado
        /// 3- Corrige montos
        /// </remarks>
        public int CodRef { get; set; }
        public bool ShouldSerializeCodRef() { return (CodRef == 0) ? false : true; }

        /// <summary>
        /// Representa la razon de la referencia
        /// </summary>
        public string RazonRef { get; set; }



    }

}
