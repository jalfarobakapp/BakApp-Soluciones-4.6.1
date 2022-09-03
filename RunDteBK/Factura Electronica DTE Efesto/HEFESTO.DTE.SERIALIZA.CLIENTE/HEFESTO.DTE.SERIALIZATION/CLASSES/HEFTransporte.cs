using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HEFESTO.DTE.SERIALIZATION.CLASSES
{
    /// <summary>
    /// Esta información se debe registrar sólo si se dispone de la información al momento de confeccionar el documento electrónico. En caso contrario, bastará que vaya escrita en la representación 
    /// impresa que acompaña el traslado de bienes 
    /// </summary>
    public class HEFTransporte
    {
        /// <summary>
        /// #63 - Información Transporte 
        /// </summary>
        public string Patente { get; set; }

        /// <summary>
        /// #64 - Rut transportista  
        /// </summary>
        /// <remarks>
        /// Con guión y dígito verificador 
        /// Indicador Tipo de Despacho es 2 o 3
        /// </remarks>
        public string RUTTrans { get; set; }

        /// <summary>
        /// #65 - RUT Chofer
        /// </summary>
        /// <remarks>
        /// Rut Chofer que realiza el transporte 
        /// de mercaderías. 
        /// Con guión y dígito verificador
        /// </remarks>
        public string RUTChofer { get; set; }

        /// <summary>
        /// #66 - Nombre del chofer
        /// </summary>
        public string NombreChofer { get; set; }

        /// <summary>
        /// #67 - Dirección Destino 
        /// </summary>
        /// <remarks>
        /// Datos correspondientes a Dirección 
        /// destino en documento que acompaña 
        /// productos o a la Dirección en que se 
        /// otorga el servicio en caso de Servicios 
        /// periódicos.
        /// </remarks>
        public string DirDest { get; set; }

        /// <summary>
        /// #68 - Comuna Destino 
        /// </summary>
        /// <remarks>
        /// Análogo Dirección Destino
        /// </remarks>
        public string CmnaDest { get; set; }

        /// <summary>
        /// #69 - Ciudad Destino 
        /// </summary>
        /// <remarks>
        /// Análogo Dirección Destino
        /// </remarks>
        public string CiudadDest { get; set; }



    }
}
