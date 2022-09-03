using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace HEFESTO.DTE.SERIALIZATION.CLASSES
{
    /// <summary>
    /// Representa el Documento DTE que se firmará
    /// </summary>
    public class HEFDocumento
    {
        /// <summary>
        /// Variables privadas de la clase HEFDocumento
        /// </summary>
        List<HEFDetalle> _Detalles = new List<HEFDetalle>();
        HEFEncabezado _Encabezado = new HEFEncabezado();
        HEFTed _TED = new HEFTed();


        /// <summary>
        /// Representa el attributo ID del documento, si no se asigna un valor la clase calculara uno.
        /// </summary>
        /// <remarks>
        /// El atributo ID es utilizado posteriormente para firmar el documento DTE.
        /// </remarks>
        [XmlAttribute("ID")]
        public string ID { get; set; }

        /// <summary>
        /// Representa el Encabezado del documento
        /// </summary>
        [XmlElement(ElementName = "Encabezado")]
        public HEFEncabezado Encabezado
        {
            get { return _Encabezado; }
            set { _Encabezado = value; }
        }


        /// <summary>
        /// Lista de Detalles disponibles del documento dte actual.
        /// </summary>
        /// <remarks>
        /// Coleccion de elementos detalle del documento dte actual. En el futuro 
        /// se debe validar la cantidad de elementos no mayor a 60 detalles.
        /// </remarks>
        [XmlIgnore]
        public HEFDetalle AddDetalle
        {
            set { _Detalles.Add(value); }
        }
        [XmlElement("Detalle")]
        public List<HEFDetalle> Detalles { get{ return _Detalles; } }   





        /// <summary>
        /// Representa los descuentos o recargos globales
        /// </summary>
        [XmlElement(ElementName = "DscRcgGlobal")]
        public List<HEFDscRcgGlobal> DscRcgGlobals { get; set; }

        /// <summary>
        /// Representa la lista de referencias a otros documentos
        /// en el caso de utilizar notas de debito o credito
        /// </summary>
        /// [XmlElement("Referencia")]
        [XmlElement(ElementName = "Referencia")]
        public List<HEFReferencia> Referencias { get; set; }

        /// <summary>
        /// Representa la fecha y hora al firmar el documento
        /// </summary>
        [XmlElement("TmstFirma")]
        public string TmstFirma { get; set; }



    }

}
