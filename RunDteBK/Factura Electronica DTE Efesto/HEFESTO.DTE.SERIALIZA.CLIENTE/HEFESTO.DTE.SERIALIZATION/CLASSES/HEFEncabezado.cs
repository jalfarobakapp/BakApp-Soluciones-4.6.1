using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HEFESTO.DTE.SERIALIZATION.CLASSES
{
    /// <summary>
    /// Representa el encabezado del documento DTE
    /// </summary>
    public class HEFEncabezado
    {
        /// <summary>
        /// Variables privadas de la clase
        /// </summary>
        private HEFIdDoc _idDoc = new HEFIdDoc();
        private HEFTransporte _transporte;
        private HEFEmisor _Emisor = new HEFEmisor();
        private HEFReceptor _Receptor = new HEFReceptor();
        private HEFTotales _Totales = new HEFTotales();

        /// <summary>
        /// Representa la zona de descripcion del DTE actual
        /// </summary>
        public HEFIdDoc IdDoc
        {
            get { return _idDoc; }
            set { _idDoc = value; }
        }

        /// <summary>
        /// Representa la zona del emisor del DTE actual
        /// </summary>
        public HEFEmisor Emisor
        {
            get { return _Emisor; }
            set { _Emisor = value; }
        }

        /// <summary>
        /// Representa la zona del Receptor del DTE actual
        /// </summary>
        public HEFReceptor Receptor
        {
            get { return _Receptor; }
            set { _Receptor = value; }
        }

        /// <summary>
        /// Representa la zona del transporte
        /// </summary>
        public HEFTransporte Transporte
        {
            get { return _transporte; }
            set { _transporte = value; }
        }
        public bool ShouldSerializeTransporte() { return (Transporte == null || Transporte.Equals(null)) ? false : true; }


        /// <summary>
        /// Representa la zona totales del DTE actual
        /// </summary>
        public HEFTotales Totales
        {
            get { return _Totales; }
            set { _Totales = value; }
        }



    }
}
