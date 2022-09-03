using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HEFESTO.DTE.SERIALIZATION.CLASSES
{

    /// <summary>
    /// Representa la zona del emisor del documento
    /// </summary>
    public class HEFEmisor
    {

        /// <summary>
        /// Coleccion de codigos de actividad economica
        /// </summary>
        List<int> _Acteco = new List<int>();


        /// <summary>
        /// #29 - Rut del emisor del documento
        /// </summary>
        public string RUTEmisor { get; set; }

        /// <summary>
        /// #30 - Razon social del emisor del documento
        /// </summary>
        public string RznSoc { get; set; }

        /// <summary>
        /// #31 - Giro del emisor del documento
        /// </summary>
        public string GiroEmis { get; set; }

        /// <summary>
        /// #32 - Telefono emisor
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// #33 - Correo emisor
        /// </summary>
        public string CorreoEmisor { get; set; }

        /// <summary>
        /// #34 - Codigo de actividad economica
        /// </summary>
        /// public int Acteco { get; set; }
        [XmlElement("Acteco")]
        public List<int> Acteco 
        {
            get { return _Acteco ; }
            set { _Acteco = value; }
        
        }
        
        

        /// <summary>
        /// #35 - Código Emisor Traslado Excepcional
        /// </summary>
        /// <remarks>
        /// Sólo para Guía de Despacho: 
        /// 1: Exportador 
        /// 2: Agente de Aduana (En la devolución de mercaderías de  Aduanas. 
        /// 3: Vendedor (Entre otros, se refiere a aquel Productor que vende  mercadería con entrega en Zona  Primaria). 
        /// 4: Contribuyente autorizado expresamente por el SII.         /// </remarks>
        public int CdgTraslado { get; set; }
        public bool ShouldSerializeCdgTraslado() { return (CdgTraslado == 0) ? false : true; }


        /// <summary>
        /// #36 - Folio Autorizacion
        /// </summary>
        /// <remarks>
        /// Sólo para Guía de Despacho: 
        /// Corresponde al N° de Resolución del 
        /// SII donde en casos especiales se 
        /// autoriza al contribuyente a emitir 
        /// guías de despacho.         /// </remarks>
        public int FolioAut { get; set; }
        public bool ShouldSerializeFolioAut() { return (FolioAut == 0) ? false : true; }


        /// <summary>
        /// #37 - Fecha de autorizacion
        /// </summary>
        /// <remarks>
        /// Sólo para Guía de Despacho: 
        /// Fecha de emisión de la Resolución de 
        /// autorización (AAAA-MM-DD)
        /// </remarks>
        public string FchAut { get; set; }

        /// <summary>
        /// #38 - Sucursal
        /// </summary>
        /// <remarks>
        /// Indica nombre de la sucursal que 
        /// emite el Documento. Corresponde a 
        /// un dato administrado por el emisor 
        /// que puede ser un texto o un número. 
        /// </remarks>
        public string Sucursal { get; set; }

        /// <summary>
        /// #39 - CdgSIISucur
        /// </summary>
        /// <remarks>
        /// Código numérico entregado por el SII, 
        /// que identifica a cada sucursal que 
        /// está identificada en el Servicio de 
        /// Impuestos Internos. Si no hay 
        /// sucursales se puede omitir.         /// </remarks>
        public int CdgSIISucur { get; set; }
        public bool ShouldSerializeCdgSIISucur() { return (CdgSIISucur == 0) ? false : true; }

        /// <summary>
        /// #40 - CodAdicSucur
        /// </summary>
        /// <remarks>
        /// Código de identificación adicional 
        /// para uso libre
        /// </remarks>
        public int CodAdicSucur { get; set; }
        public bool ShouldSerializeCodAdicSucur() { return (CodAdicSucur == 0) ? false : true; }

        /// <summary>
        /// #41 - Direccion de origen del emisor
        /// </summary>
        public string DirOrigen { get; set; }

        /// <summary>
        /// #42 - Comuna de origen del emisor del documento
        /// </summary>
        public string CmnaOrigen { get; set; }

        /// <summary>
        /// #43 - Ciudad de origen del emisor del documento
        /// </summary>
        public string CiudadOrigen { get; set; }

        /// <summary>
        /// #44 - Codigo del vendedor
        /// </summary>
        /// <remarks>
        /// Glosa con identificador del vendedor
        /// </remarks>
        public string CdgVendedor { get; set; }

        /// <summary>
        /// #45 - Identificador Adicional del Emisor
        /// </summary>
        /// <remarks>
        /// Para documentos utilizados en exportaciones. Código de 
        /// identificación adicional para uso libre.
        /// </remarks>
        public string IdAdicEmisor { get; set; }


        /// <summary>
        /// #46 - Rut Mandante
        /// </summary>
        /// <remarks>
        /// Corresponde al RUT del mandante si el total de la venta o servicio es por 
        /// cuenta de otro el cual es responsable del IVA devengado en el período 
        /// Con guión y dígito verificador
        /// </remarks>
        public string RUTMandante { get; set; }

    }

}
