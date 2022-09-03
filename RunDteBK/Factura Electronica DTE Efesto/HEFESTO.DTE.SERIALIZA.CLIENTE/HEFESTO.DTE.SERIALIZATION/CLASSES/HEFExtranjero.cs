using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HEFESTO.DTE.SERIALIZATION.CLASSES
{
    /// <summary>
    /// Representa los datos del contribuyente extrangero
    /// </summary>
    public class HEFExtranjero
    {
        /// <summary>
        /// #50 - Número identificador del Receptor extranjero
        /// </summary>
        /// <remarks>
        /// Corresponde al número o código de 
        /// identificación personal del receptor 
        /// extranjero, otorgado por la 
        /// Administración tributaria extranjera u 
        /// organismo Gubernamental 
        /// competente. Se deben incluir guiones 
        /// y dígitos verificadores. 
        /// </remarks>
        public string NumId { get; set; }

        /// <summary>
        /// #51 - Nacionalidad del Receptor Extranjero 
        /// </summary>
        /// <remarks>
        /// Corresponde a la nacionalidad del 
        /// extranjero, según tabla de países de aduana 
        /// </remarks>
        public string Nacionalidad { get; set; }

        /// <summary>
        /// #52 - Tipo de Documento del Turista
        /// </summary>
        public string TipoDocID { get; set; }
 
    }
}
