using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HEFESTO.DTE.SERIALIZATION.CLASSES
{
    /// <summary>
    /// Datos del Receptor del documento
    /// </summary>
    public class HEFReceptor
    {

        /// <summary>
        /// #47 - Rut del receptor del documento DTE
        /// </summary>
        public string RUTRecep { get; set; }

        /// <summary>
        /// #48 - Código interno del receptor
        /// </summary>
        /// <remarks>
        /// Para identificación interna del Receptor, por ejemplo código del 
        /// cliente, número de medidor, etc.         /// </remarks>
        public string CdgIntRecep { get; set; }

        /// <summary>
        /// #49 - Nombre o Razón social del receptor del documento
        /// </summary>
        public string RznSocRecep { get; set; }
        
        ////
        //// Receptor Extranjero
        HEFExtranjero _extrajero = new HEFExtranjero();
        public HEFExtranjero Extrajero
        {
            get { return _extrajero; }
            set { _extrajero = value; }
        }
        public bool ShouldSerializeExtrajero() { return (
            string.IsNullOrEmpty(Extrajero.Nacionalidad) &&
            string.IsNullOrEmpty(Extrajero.NumId) &&
            string.IsNullOrEmpty(Extrajero.TipoDocID)
            ) ? false : true; }
        
        /// <summary>
        /// #53 - Giro del negocio del Receptor
        /// </summary>
        /// <remarks>
        /// Glosa impresa indicando giro del receptor
        /// </remarks>
        public string GiroRecep { get; set; }

        /// <summary>
        /// #54 - Contacto receptor
        /// </summary>
        /// <remarks>
        /// Glosa con nombre y teléfono de contacto en empresa del receptor 
        /// (para registrar el “Atención A:” )         /// </remarks>
        public string Contacto { get; set; }

        /// <summary>
        /// #55 - Correo Contacto receptor
        /// </summary>
        /// <remarks>
        /// e-mail de contacto en empresa del 
        /// receptor (para registrar el “Atención A:” )         /// </remarks>
        public string CorreoRecep { get; set; }

        /// <summary>
        /// #56 - Direccion del receptor
        /// </summary>
        /// <remarks>
        /// Dirección Legal del Receptor 
        /// (registrada en el SII) 
        /// En caso de documentos de 
        /// exportación, corresponde a la 
        /// dirección en el extranjero del 
        /// Receptor
        /// </remarks>
        public string DirRecep { get; set; }

        /// <summary>
        /// #57 - Comuna del receptor
        /// </summary>
        public string CmnaRecep { get; set; }

        /// <summary>
        /// #58 - Ciudad del receptor
        /// </summary>
        public string CiudadRecep { get; set; }

        /// <summary>
        /// #59 - Dirección Postal Receptor         /// </summary>
        public string DirPostal { get; set; }

        /// <summary>
        /// #60 - Comuna Postal
        /// </summary>
        public string CmnaPostal { get; set; }

        /// <summary>
        /// #61 - Ciudad postal
        /// </summary>
        public string CiudadPostal { get; set; }

        /// <summary>
        /// #62 - Rut de Solicitante de factura
        /// </summary>
        public string RUTSolicita { get; set; }

    }
}
