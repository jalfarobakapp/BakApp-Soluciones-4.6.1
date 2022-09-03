using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using HEFESTO.DTE.SERIALIZATION.ENTIDADES;
using System.Xml;
using System.IO;

namespace HEFESTO.DTE.SERIALIZATION.EXPORTACION
{


    /// <summary>
    /// Representa el documento DTE actual
    /// </summary>
    [XmlRoot(ElementName = "DTE")]
    public class HEFDTEExpotaciones
    {

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public HEFDTEExpotaciones()
        {
            DateTime dt = new DateTime(2020, 12, 12);
            if (DateTime.Now >= dt)
                throw new Exception("Clase Demo expirada.");
        
        }


        /// <summary>
        /// Representa la zona Documento
        /// </summary>
        HEFExportacion _Exportaciones = new HEFExportacion();
        public HEFExportacion Exportaciones
        {
            get { return _Exportaciones; }
            set { _Exportaciones = value; }
        }


        /// <summary>
        /// Representa el atributo version del documento DTE
        /// </summary>
        [XmlAttribute("version")]
        public string version { get; set; }

        /// <summary>
        /// Serializa la clase para obtener el documento xml de resultado
        /// </summary>
        /// <returns>Documento XML que representa el DTE del SII(basico)</returns>
        public Respuesta RecuperarDte()
        {

            ////
            //// Inicie la respuesta del proceso
            Respuesta respuesta = new Respuesta();
            XmlWriter xmlwriter;

            ////
            //// Inicie la serializacion del documento
            try
            {

                ////
                //// Crear el Id del documento
                this.Exportaciones.ID = string.Format("HEF_EXP_R{0}T{1}F{2}",
                this.Exportaciones.Encabezado.Emisor.RUTEmisor,
                this.Exportaciones.Encabezado.IdDoc.TipoDTE.ToString(),
                this.Exportaciones.Encabezado.IdDoc.Folio.ToString());

                ////
                //// Cree el TmstFirma
                this.Exportaciones.TmstFirma = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

                #region SERIALIZA EL OBJETO ACTUAL EN UN DOCUMENTO XML DTE

                ////
                //// Prepare el espacio de nombres a utilizar para la serializacion
                var xns = new XmlSerializerNamespaces();
                xns.Add(string.Empty, string.Empty);


                ////
                //// Setee el resultado de la declaracion del documento xml
                XmlWriterSettings xws = new XmlWriterSettings();
                xws.Encoding = Encoding.GetEncoding("ISO-8859-1");
                xws.Indent = true;

                ////
                //// Serialice la clase DTE
                XmlSerializer x = new XmlSerializer(this.GetType());

                ////
                //// Cree temporalmente un archivo xml para guardar el resultado
                string rutaResultadoDte = Path.GetTempFileName();
                using (XmlWriter xw = XmlWriter.Create(rutaResultadoDte, xws))
                {
                    xw.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"ISO-8859-1\" ");
                    x.Serialize(xw, this, xns);
                    xmlwriter = xw;
                }

                #endregion

                ////
                //// Recupere el documento xml
                XmlDocument xExp = new XmlDocument();
                xExp.PreserveWhitespace = true;
                xExp.Load(rutaResultadoDte);

                ////
                //// Agregar namespace si corresponde.
                if (this.AgregarNameSpace)
                {
                    XmlAttribute attr = xExp.CreateAttribute("xmlns");
                    attr.InnerText = "http://www.sii.cl/SiiDte";
                    xExp.DocumentElement.Attributes.Append(attr);
                }
                
                ////
                //// Guarde el documento
                xExp.Save(rutaResultadoDte);
                
                ////
                //// Indique al usuario que el proceso es correcto
                respuesta.Correcto = true;
                respuesta.Mensaje = "Fin del proceso de serializaciond el objeto actual OK";
                respuesta.Detalle = string.Empty;

                ////
                //// Regrese la respuesta
                respuesta.Resultado = xExp;

                ////
                //// Borrar archivo temporal
                File.Delete(rutaResultadoDte);


            }
            catch (Exception excep)
            {
                ////
                //// Indique el error al codigo cliente
                respuesta.Correcto = false;
                respuesta.Mensaje = "No fue posible serializar el objeto DTE actual.";
                respuesta.Detalle = excep.Message;
                respuesta.Resultado = null;

            }


            ////
            //// Regrese el valor de retorno del metodo
            return respuesta;


        }

        /// <summary>
        /// Agregar name space
        /// </summary>
        [XmlIgnore]
        public bool AgregarNameSpace { get; set; }

        
    }

    /// <summary>
    /// Nodo Expotaciones
    /// </summary>
    public class HEFExportacion
    {

        /// <summary>
        /// Identificacion y Totales del Documento
        /// </summary>
        HEFEncabezado _Encabezado = new HEFEncabezado();
        public HEFEncabezado Encabezado
        {
            get { return _Encabezado; }
            set { _Encabezado = value; }
        }

        /// <summary>
        /// Detalles del documento
        /// </summary>
        //// List<HEFDetalle> _Detalle = new List<HEFDetalle>();
        [XmlElement]
        public List<HEFDetalle> Detalle { get; set; }
    
        /// <summary>
        /// SubTotInfo
        /// </summary>
        [XmlElement]
        public List<HEFSubTotInfo> SubTotInfo { get; set; }

        /// <summary>
        /// Descuentos y/o Recargos que afectan al total del Documento
        /// </summary>
        [XmlElement("DscRcgGlobal")]
        public List<HEFDscRcgGlobal> DscRcgGlobal { get; set; }

        /// <summary>
        /// Referencias del documento
        /// </summary>
        [XmlElement]
        public List<HEFReferencia> Referencia { get; set; }

        /// <summary>
        /// Representa la fecha y hora al firmar el documento
        /// </summary>
        [XmlElement("TmstFirma")]
        public string TmstFirma { get; set; }

        /// <summary>
        /// Representa el attributo ID del documento, si no se asigna un valor la clase calculara uno.
        /// </summary>
        /// <remarks>
        /// El atributo ID es utilizado posteriormente para firmar el documento DTE.
        /// </remarks>
        [XmlAttribute("ID")]
        public string ID { get; set; }
        
    }

    /// <summary>
    /// Identificacion y Totales del Documento
    /// </summary>
    public class HEFEncabezado
    {
        /// <summary>
        /// Identificacion y Totales del Documento
        /// </summary>
        HEFIdDoc _IdDoc = new HEFIdDoc();
        public HEFIdDoc IdDoc
        {
            get { return _IdDoc; }
            set { _IdDoc = value; }
        }

        /// <summary>
        /// Identificacion Emisor
        /// </summary>
        HEFEmisor _Emisor = new HEFEmisor();
        public HEFEmisor Emisor
        {
            get { return _Emisor; }
            set { _Emisor = value; }
        }

        /// <summary>
        /// Identificacion Receptor
        /// </summary>
        HEFReceptor _Receptor = new HEFReceptor();
        public HEFReceptor Receptor
        {
            get { return _Receptor; }
            set { _Receptor = value; }
        }


        /// <summary>
        /// Identificacion HEFTransporte
        /// </summary>
        HEFTransporte _Transporte = new HEFTransporte();
        public HEFTransporte Transporte { get; set; }
        

        /// <summary>
        /// Totales del documento
        /// </summary>
        HEFTotales _Totales = new HEFTotales();
        public HEFTotales Totales {
            get { return _Totales; }
            set { _Totales = value; }
        }

        /// <summary>
        /// Otra moneda
        /// </summary>
        public HEFOtraMoneda OtraMoneda {get;set;}

    }

    /// <summary>
    /// Identificacion del DTE
    /// </summary>
    public class HEFIdDoc
    {
        /// <summary>
        /// Tipo de DTE
        /// </summary>
        public int TipoDTE { get; set; }

        /// <summary>
        /// Folio del Documento Electronico
        /// </summary>
        public long Folio { get; set; }

        /// <summary>
        /// Fecha Emision Contable del DTE (AAAA-MM-DD)
        /// </summary>
        public string FchEmis { get; set; }

        /// <summary>
        /// Indica Modo de Despacho de los Bienes que Acompanan al DTE
        /// 1: Despacho por Cuenta del Comprador
        /// 2: Despacho por Cuenta del Emisor a Instalaciones del Comprador
        /// 3: Despacho por Cuenta del Emisor a Otras Instalaciones
        /// </summary>
        public int TipoDespacho { get; set; }
        public bool ShouldSerializeTipoDespacho() { return (TipoDespacho == 0) ? false : true; }

        /// <summary>
        /// Indica si Transaccion Corresponde a la Prestacion de un Servicio
        /// 3: Factura de servicio
        /// 4:??
        /// 5:??
        /// </summary>
        public int IndServicio { get; set; }
        public bool ShouldSerializeIndServicio() { return (IndServicio == 0) ? false : true; }

        /// <summary>
        /// Forma de Pago del DTE
        /// 1: Pago Contado
        /// 2: Pago credito
        /// 3: Sin Costo
        /// </summary>
        public int FmaPago { get; set; }
        public bool ShouldSerializeFmaPago() { return (FmaPago == 0) ? false : true; }

        /// <summary>
        /// Forma de Pago Exportación Tabla Formas de Pago de Aduanas
        /// Opcional
        /// </summary>
        public int FmaPagExp { get; set; }
        public bool ShouldSerializeFmaPagExp() { return (FmaPagExp == 0) ? false : true; }

        /// <summary>
        /// Fecha de Cancelacion del DTE (AAAA-MM-DD)
        /// </summary>
        public string FchCancel { get; set; }
       

        /// <summary>
        /// Monto Cancelado al emitirse el documento
        /// </summary>
        public long MntCancel { get; set; }
        public bool ShouldSerializeMntCancel() { return (MntCancel == 0) ? false : true; }

        /// <summary>
        /// Saldo Insoluto al emitirse el documento
        /// </summary>
        public long SaldoInsol { get; set; }
        public bool ShouldSerializeSaldoInsol() { return (SaldoInsol == 0) ? false : true; }

        
        /// <summary>
        /// Tabla de Montos de Pago - MntPagos
        /// </summary>
        List<HEFMntPagos> _MntPagos = new List<HEFMntPagos>();
        [XmlElement]
        public List<HEFMntPagos> MntPagos
        {
            get { return _MntPagos; }
            set { _MntPagos = value; }
        }
        public bool ShouldSerializeMntPagos() { return (MntPagos.Count == 0) ? false : true; }

        /// <summary>
        /// Periodo de Facturacion - Desde (AAAA-MM-DD)
        /// </summary>
        public string PeriodoDesde { get; set; }

        /// <summary>
        /// Periodo Facturacion - Hasta (AAAA-MM-DD)
        /// </summary>
        public string PeriodoHasta { get; set; }

        /// <summary>
        /// - CH CHEQUE
        /// - LT LETRA
        /// - EF EFECTIVO
        /// - PE PAGO A CUENTA CORRIENTE
        /// - TC TARJETA DE CREDITO
        /// - CF CHEQUE A FECHA
        /// - OT OTRO
        /// </summary>
        public string MedioPago { get; set; }

        /// <summary>
        /// Tipo Cuenta de Pago
        /// - AHORRO
        /// - CORRIENTE
        /// - VISTA
        /// </summary>
        public string TpoCtaPago { get; set; }

        /// <summary>
        /// Banco donde se realiza el pago
        /// </summary>
        public string BcoPago { get; set; }

        /// <summary>
        /// Codigo del Termino de Pago Acordado
        /// </summary>
        public string TermPagoCdg { get; set; }

        /// <summary>
        /// Términos del Pago - glosa
        /// </summary>
        public string TermPagoGlosa { get; set; }

        /// <summary>
        /// Dias de Acuerdo al Codigo de Termino de Pago
        /// </summary>
        public int TermPagoDias { get; set; }
        public bool ShouldSerializeTermPagoDias() { return (TermPagoDias == 0) ? false : true; }

        /// <summary>
        /// Fecha de Vencimiento del Pago (AAAA-MM-DD)
        /// </summary>
        public string FchVenc { get; set; }
        

    }

    /// <summary>
    /// Tabla de Montos de Pago
    /// </summary>
    public class HEFMntPagos
    {
        /// <summary>
        /// Fecha de Pago (AAAA-MM-DD)
        /// </summary>
        public string FchPago { get; set; }

        /// <summary>
        /// Monto de Pago
        /// </summary>
        public long MntPago { get; set; }

        /// <summary>
        /// Glosa pago
        /// </summary>
        public string GlosaPagos { get; set; }
    
    }

    /// <summary>
    /// Datos del emisor
    /// </summary>
    public class HEFEmisor
    {
        /// <summary>
        /// Nombre o Razon Social del Emisor
        /// </summary>
        public string RUTEmisor { get; set; }

        /// <summary>
        /// Nombre o Razon Social del Emisor
        /// </summary>
        public string RznSoc { get; set; }

        /// <summary>
        /// Giro Comercial del Emisor Relevante para el DTE
        /// </summary>
        public string GiroEmis { get; set; }

        /// <summary>
        /// Telefono Emisor
        /// </summary>
        List<string> _telefono = new List<string>();
        [XmlElement]
        public List<string> Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        public bool ShouldSerializeTelefono() { return (Telefono.Count == 0) ? false : true; }

        /// <summary>
        /// Correo Elect. de contacto en empresa del  receptor 
        /// </summary>
        public string CorreoEmisor { get; set; }

        /// <summary>
        /// Codigo de Actividad Economica del Emisor Relevante para el DTE
        /// </summary>
        List<int> _Acteco = new List<int>();
        [XmlElement]
        public List<int> Acteco
        {
            get { return _Acteco; }
            set { _Acteco = value; }
        }
        public bool ShouldSerializeActeco() { return (Acteco.Count == 0) ? false : true; }

        /// <summary>
        /// Sucursal que Emite el DTE
        /// </summary>
        public string Sucursal { get; set; }

        /// <summary>
        /// Codigo de Sucursal Entregado por el SII
        /// </summary>
        public int CdgSIISucur { get; set; }
        public bool ShouldSerializeCdgSIISucur() { return (CdgSIISucur == 0) ? false : true; }

        /// <summary>
        /// Sucursal que Emite el DTE
        /// </summary>
        public string CodAdicSucur { get; set; }
        
        /// <summary>
        /// Direccion de Origen
        /// </summary>
        public string DirOrigen { get; set; }

        /// <summary>
        /// Comuna de Origen
        /// </summary>
        public string CmnaOrigen { get; set; }

        /// <summary>
        /// Ciudad de Origen
        /// </summary>
        public string CiudadOrigen { get; set; }

        /// <summary>
        /// Codigo del Vendedor
        /// </summary>
        public string CdgVendedor { get; set; }
        
        /// <summary>
        /// Identificador Adicional del Emisor
        /// </summary>
        public string IdAdicEmisor { get; set; }


    }

    /// <summary>
    /// Datos del Receptor
    /// </summary>
    public class HEFReceptor
    {
        /// <summary>
        /// RUT del Receptor del DTE
        /// </summary>
        public string RUTRecep { get; set; }

        /// <summary>
        /// Codigo Interno del Receptor
        /// </summary>
        public string CdgIntRecep { get; set; }

        /// <summary>
        /// Nombre o Razon Social del Receptor
        /// </summary>
        public string RznSocRecep { get; set; }

        ////
        //// Extranjero
        HEFExtranjero _Extranjero = new HEFExtranjero();
        public HEFExtranjero Extranjero
        {
            get { return _Extranjero; }
            set { _Extranjero = value; }
        }
        public bool ShouldSerializeExtranjero() { return (string.IsNullOrEmpty(Extranjero.NumId)) ? false : true; }

        /// <summary>
        /// Giro Comercial del Receptor
        /// </summary>
        public string GiroRecep { get; set; }

        /// <summary>
        /// Glosa con nombre o teléfono de contacto en empresa del  receptor
        /// </summary>
        public string Contacto { get; set; }

        /// <summary>
        /// Correo Elect. de contacto en empresa del receptor 
        /// </summary>
        public string CorreoRecep { get; set; }

        /// <summary>
        /// Direccion en la Cual se Envian los Productos o se Prestan los Servicios
        /// </summary>
        public string DirRecep { get; set; }

        /// <summary>
        /// Comuna de Recepcion
        /// </summary>
        public string CmnaRecep { get; set; }

        /// <summary>
        /// Ciudad de Recepcion
        /// </summary>
        public string CiudadRecep { get; set; }

        /// <summary>
        /// Direccion Postal
        /// </summary>
        public string DirPostal { get; set; }

        /// <summary>
        /// Comuna Postal
        /// </summary>
        public string CmnaPostal { get; set; }

        /// <summary>
        /// Ciudad Postal
        /// </summary>
        public string CiudadPostal { get; set; }
        
    }

    /// <summary>
    /// Receptor Extranjero
    /// </summary>
    public class HEFExtranjero
    {

        /// <summary>
        /// Num. Identif. Receptor Extranjero
        /// </summary>
        public string NumId { get; set; }

        /// <summary>
        /// Nacionalidad Receptor Extranjero
        /// </summary>
        public string Nacionalidad { get; set; }

        /// <summary>
        /// Identificador Adicional del Receptor  extranjero
        /// </summary>
        public string IdAdicRecep { get; set; }

    
    }

    /// <summary>
    /// Chofer
    /// </summary>
    public class HEFChofer
    {
        /// <summary>
        /// RUT del Chofer
        /// </summary>
        public string RUTChofer { get; set; }

        /// <summary>
        /// Nombre del Chofer
        /// </summary>
        public string NombreChofer { get; set; }

    }

    /// <summary>
    /// Tabla de descripción de los distintos tipos de bultos
    /// </summary>
    public class HEFTipoBulto
    {
        public int CodTpoBultos { get; set; }
        public bool ShouldSerializeCodTpoBultos() { return (CodTpoBultos == 0) ? false : true; }
        public int CantBultos { get; set; }
        public bool ShouldSerializeCantBultos() { return (CantBultos == 0) ? false : true; }
        public string Marcas { get; set; }
        public string IdContainer { get; set; }
        public string Sello { get; set; }
        public string EmisorSello { get; set; }
    }

    /// <summary>
    /// documentos de Exportación y guías de despacho 
    /// </summary>
    public class HEFAduana
    {
        /// <summary>
        /// Código según  tabla "Modalidad de Venta" de aduana
        /// </summary>
        public int CodModVenta { get; set; }
        public bool ShouldSerializeCodModVenta() { return (CodModVenta == 0) ? false : true; }

        /// <summary>
        /// Código según  Tabla "Cláusula compra-venta" de  Aduana
        /// </summary>
        public int CodClauVenta { get; set; }
        public bool ShouldSerializeCodClauVenta() { return (CodClauVenta == 0) ? false : true; }

        /// <summary>
        /// Total  Cláusula de venta
        /// </summary>
        public decimal TotClauVenta { get; set; }
        public bool ShouldSerializeTotClauVenta() { return (TotClauVenta == 0) ? false : true; }
        
        /// <summary>
        /// Indicar el Código de la vía de transporte utilizada para transportar la mercadería, según tabla Vías de Transporte de Aduana
        /// </summary>
        public int CodViaTransp { get; set; }
        public bool ShouldSerializeCodViaTransp() { return (CodViaTransp == 0) ? false : true; }

        /// <summary>
        /// Nombre o Identificación del Medio de Transporte
        /// </summary>
        public string NombreTransp { get; set; }
        
        /// <summary>
        /// Rut Cía. Transportadora
        /// </summary>
        public string RUTCiaTransp { get; set; }

        /// <summary>
        /// Nombre Cía. Transportadora
        /// </summary>
        public string NomCiaTransp { get; set; }

        /// <summary>
        /// Identificador Adicional Cía. Transportadora
        /// </summary>
        public string IdAdicTransp { get; set; }

        /// <summary>
        /// Numero de reserva del Operador
        /// </summary>
        public string Booking { get; set; }

        /// <summary>
        /// Código del Operador
        /// </summary>
        public string Operador { get; set; }

        /// <summary>
        /// Código del puerto de embarque según tabla de Aduana
        /// </summary>
        public int CodPtoEmbarque { get; set; }
        public bool ShouldSerializeCodPtoEmbarque() { return (CodPtoEmbarque == 0) ? false : true; }

        /// <summary>
        /// Identificador Adicional Puerto de Embarque
        /// </summary>
        public string IdAdicPtoEmb { get; set; }

        /// <summary>
        /// Código del puerto de desembarque según tabla de Aduana
        /// </summary>
        public int CodPtoDesemb { get; set; }
        public bool ShouldSerializeCodPtoDesemb() { return (CodPtoDesemb == 0) ? false : true; }

        /// <summary>
        /// Identificador Adicional Puerto de Desembarque
        /// </summary>
        public string IdAdicPtoDesemb { get; set; }

        /// <summary>
        /// Tara 7 digitos maximo
        /// </summary>
        public int Tara { get; set; }
        public bool ShouldSerializeTara() { return (Tara == 0) ? false : true; }

        /// <summary>
        /// Código de la unidad de medida  según tabla de Aduana
        /// </summary>
        public int CodUnidMedTara { get; set; }
        public bool ShouldSerializeCodUnidMedTara() { return (CodUnidMedTara == 0) ? false : true; }

        /// <summary>
        /// Sumatoria de los pesos brutos de todos los ítems del documento
        /// 0000000000.00
        /// </summary>
        public decimal PesoBruto { get; set; }
        public bool ShouldSerializePesoBruto() { return (PesoBruto == 0) ? false : true; }

        /// <summary>
        /// Código de la unidad de medida  según tabla de Aduana
        /// </summary>
        public int CodUnidPesoBruto { get; set; }
        public bool ShouldSerializeCodUnidPesoBruto() { return (CodUnidPesoBruto == 0) ? false : true; }

        /// <summary>
        /// Sumatoria de los pesos netos de todos los ítems del documento
        /// </summary>
        public decimal PesoNeto { get; set; }
        public bool ShouldSerializePesoNeto() { return (PesoNeto == 0) ? false : true; }

        /// <summary>
        /// Código de la unidad de medida  según tabla de Aduana
        /// </summary>
        public int CodUnidPesoNeto { get; set; }
        public bool ShouldSerializeCodUnidPesoNeto() { return (CodUnidPesoNeto == 0) ? false : true; }

        /// <summary>
        /// Indique el total de items del documento
        /// </summary>
        public int TotItems { get; set; }
        public bool ShouldSerializeTotItems() { return (TotItems == 0) ? false : true; }

        /// <summary>
        /// Cantidad total de bultos que ampara el documento.
        /// </summary>
        public int TotBultos { get; set; }
        public bool ShouldSerializeTotBultos() { return (TotBultos == 0) ? false : true; }

        ////
        //// TipoBultos
        List<HEFTipoBulto> _Bultos = new List<HEFTipoBulto>();
        [XmlElement]
        public List<HEFTipoBulto> TipoBultos
        {
            get { return _Bultos; }
            set { _Bultos = value; }
        }
        public bool ShouldSerializeTipoBultos() { return (TipoBultos.Count == 0) ? false : true; }

        /// <summary>
        /// Monto del flete según moneda de venta
        /// </summary>
        public decimal MntFlete { get; set; }
        public bool ShouldSerializeMntFlete() { return (MntFlete == 0) ? false : true; }

        /// <summary>
        /// Monto del seguro , según moneda de venta
        /// </summary>
        public decimal MntSeguro { get; set; }
        public bool ShouldSerializeMntSeguro() { return (MntSeguro == 0) ? false : true; }

        /// <summary>
        /// Código del país del receptor extranjero de la mercadería, según tabla Países aduana
        /// </summary>
        public int CodPaisRecep { get; set; }
        public bool ShouldSerializeCodPaisRecep() { return (CodPaisRecep == 0) ? false : true; }

        /// <summary>
        /// Código del país de destino extranjero de la mercadería, según tabla Países aduana</xs:documentation>
        /// </summary>
        public int CodPaisDestin { get; set; }
        public bool ShouldSerializeCodPaisDestin() { return (CodPaisDestin == 0) ? false : true; }
    
    }

    /// <summary>
    /// Informacion de Transporte de Mercaderias
    /// </summary>
    public class HEFTransporte
    {

        /// <summary>
        /// Patente del Vehiculo que Transporta los Bienes
        /// </summary>
        public string Patente { get; set; }

        /// <summary>
        /// RUT del Transportista
        /// </summary>
        public string RUTTrans { get; set; }

        /// <summary>
        ///Datos del chofer
        /// </summary>
        HEFChofer _Chofer = new HEFChofer();
        public HEFChofer Chofer
        {
            get { return _Chofer; }
            set { _Chofer = value; }
        }
        public bool ShouldSerializeChofer() { return (string.IsNullOrEmpty(Chofer.RUTChofer)) ? false : true; }

        /// <summary>
        /// Direccion de Destino
        /// </summary>
        public string DirDest { get; set; }

        /// <summary>
        /// Comuna de Destino
        /// </summary>
        public string CmnaDest { get; set; }

        /// <summary>
        /// Ciudad de Destino
        /// </summary>
        public string CiudadDest { get; set; }

        ////
        //// Aduana
        ///HEFAduana _Aduana = new HEFAduana();
        public HEFAduana Aduana {get;set;}
        public bool ShouldSerializeAduana() { return (Aduana == null) ? false : true; }
            
    }

    /// <summary>
    /// Montos totales del DTE
    /// </summary>
    public class HEFTotales
    {
        /// <summary>
        /// Tipo de Moneda en que se regisrtra la transacción.  Tabla de Monedas  de Aduanas
        /// </summary>
        public string TpoMoneda { get; set; }

        /// <summary>
        /// Monto Exento del DTE
        /// </summary>
        public decimal MntExe { get; set; }

        /// <summary>
        /// Monto Total del DTE
        /// </summary>
        public decimal MntTotal { get; set; }

    }

    /// <summary>
    /// Otra Moneda
    /// </summary>
    public class HEFOtraMoneda
    {
        /// <summary>
        /// Tipo Otra moneda Tabla de Monedas  de Aduanas
        /// </summary>
        public string TpoMoneda { get; set; }

        /// <summary>
        /// Tipo de Cambio fijado por el Banco Central de Chile
        /// </summary>
        public decimal TpoCambio { get; set; }
        public bool ShouldSerializeTpoCambio() { return (TpoCambio == 0) ? false : true; }

        /// <summary>
        /// Monto Exento del DTE en Otra Moneda
        /// </summary>
        public decimal MntExeOtrMnda { get; set; }
        public bool ShouldSerializeMntExeOtrMnda() { return (MntExeOtrMnda == 0) ? false : true; }

        /// <summary>
        /// Monto Total Otra Moneda
        /// </summary>
        public decimal MntTotOtrMnda { get; set; }
        public bool ShouldSerializeMntTotOtrMnda() { return (MntTotOtrMnda == 0) ? false : true; }
    }

    /// <summary>
    /// Detalle de Itemes del Documento
    /// </summary>
    public class HEFDetalle
    {
        /// <summary>
        /// Numero Secuencial de Linea
        /// </summary>
        public int  NroLinDet { get; set; }
        public bool ShouldSerializeNroLinDet() { return (NroLinDet == 0) ? false : true; }


        /// <summary>
        /// Codificacion del Item
        /// </summary>
        List<HEFCdgItem> _CdgItem = new List<HEFCdgItem>();
        [XmlElement]
        public List<HEFCdgItem> CdgItem {

            get {return _CdgItem ;}
            set { _CdgItem = value; }
        }
        public bool ShouldSerializeCdgItem() { return (CdgItem.Count == 0) ? false : true; }

        /// <summary>
        /// Tipo de Documento que se Liquida
        /// </summary>
        public string TpoDocLiq { get; set; }


        /// <summary>
        /// Indicador de Exencion/Facturacion
        /// 1: El Producto o Servicio NO ESTA Afecto a IVA
        /// 2: El Producto o Servicio NO ES Facturable
        /// 3: Garantia por Deposito/Envase
        /// 4: El producto No Constituye Venta
        /// 5: Item a Rebajar
        /// 6: No facturables negativos
        /// </summary>
        public int IndExe { get; set; }
        public bool ShouldSerializeIndExe() { return (IndExe == 0) ? false : true; }

        /// <summary>
        /// Nombre del Item
        /// </summary>
        public string NmbItem { get; set; }

        /// <summary>
        /// Descripcion del Item
        /// </summary>
        public string DscItem { get; set; }

        /// <summary>
        /// Cantidad para la Unidad de Medida de Referencia
        /// </summary>
        public decimal QtyRef { get; set; }
        public bool ShouldSerializeQtyRef() { return (QtyRef == 0) ? false : true; }

        /// <summary>
        /// Unidad de Medida de Referencia
        /// </summary>
        public string UnmdRef { get; set; }
        

        /// <summary>
        /// Precio Unitario de Referencia para Unidad de Referencia
        /// </summary>
        public decimal PrcRef { get; set; }
        public bool ShouldSerializePrcRef() { return (PrcRef == 0) ? false : true; }

        /// <summary>
        /// Cantidad del Item
        /// </summary>
        public decimal QtyItem { get; set; }
        public bool ShouldSerializeQtyItem() { return (QtyItem == 0) ? false : true; }

        /// <summary>
        /// Distribucion de la Cantidad
        /// </summary>
        List<HEFSubcantidad> _Subcantidad = new List<HEFSubcantidad>();
        public List<HEFSubcantidad> Subcantidad { 
        
            get { return _Subcantidad; }
            set { _Subcantidad = value; }
        
        }
        public bool ShouldSerializeSubcantidad() { return (Subcantidad.Count == 0) ? false : true; }


        /// <summary>
        /// Fecha Elaboracion del Item
        /// </summary>
        public string FchElabor { get; set; }

        /// <summary>
        /// Fecha Vencimiento del Item
        /// </summary>
        public string FchVencim { get; set; }

        /// <summary>
        /// Unidad de Medida
        /// </summary>
        public string UnmdItem { get; set; }

        /// <summary>
        /// Precio Unitario del Item en Pesos
        /// </summary>
        public decimal PrcItem { get; set; }
        public bool ShouldSerializePrcItem() { return (PrcItem == 0) ? false : true; }

        /// <summary>
        /// Codigo de Impuesto Adicional o Retencion
        /// </summary>
        //List<int> _CodImpAdic = new List<int>();
        //public List<int> CodImpAdic
        //{
        //    get { return _CodImpAdic; }
        //    set { _CodImpAdic = value; }

        //}

        ////
        //// OtrMnda Precio del Item en Otra Moneda
        HEFOtrMnda _OtrMnda = new HEFOtrMnda();
        public HEFOtrMnda OtrMnda {
            get { return _OtrMnda; }
            set { _OtrMnda = value; }
        
        }
        public bool ShouldSerializeOtrMnda() { return (OtrMnda.PrcOtrMon == 0) ? false : true; }

        /// <summary>
        /// Porcentaje de Descuento
        /// </summary>
        public decimal DescuentoPct { get; set; }
        public bool ShouldSerializeDescuentoPct() { return (DescuentoPct == 0) ? false : true; }

        /// <summary>
        /// Monto de Descuento
        /// </summary>
        public long DescuentoMonto { get; set; }
        public bool ShouldSerializeDescuentoMonto() { return (DescuentoMonto == 0) ? false : true; }

        /// <summary>
        /// Valor del SubDescuento
        /// </summary>
        List<HEFSubDscto> _SubDscto = new List<HEFSubDscto>();
        public List<HEFSubDscto> SubDscto {
            get { return _SubDscto; }
            set { _SubDscto = value; }
             }
        public bool ShouldSerializeSubDscto() { return (SubDscto.Count == 0) ? false : true; }

        /// <summary>
        /// Porcentaje de Recargo
        /// </summary>
        public decimal RecargoPct { get; set; }
        public bool ShouldSerializeRecargoPct() { return (RecargoPct == 0) ? false : true; }

        /// <summary>
        /// Monto de Recargo
        /// </summary>
        public long RecargoMonto { get; set; }
        public bool ShouldSerializeRecargoMonto() { return (RecargoMonto == 0) ? false : true; }

        /// <summary>
        /// Monto por Linea de Detalle. Corresponde al Monto Neto, a menos que MntBruto Indique lo Contrario
        /// </summary>
        public decimal MontoItem { get; set; }


    }

    /// <summary>
    /// Precio del Item en Otra Moneda
    /// </summary>
    public class HEFOtrMnda
    {
        public decimal PrcOtrMon { get; set; }
        public string Moneda { get; set; }
        
        public decimal FctConv { get; set; }
        public bool ShouldSerializeFctConv() { return (FctConv == 0) ? false : true; }

        public decimal DctoOtrMnda { get; set; }
        public bool ShouldSerializeDctoOtrMnda() { return (DctoOtrMnda == 0) ? false : true; }

        public decimal RecargoOtrMnda { get; set; }
        public bool ShouldSerializeRecargoOtrMnda() { return (RecargoOtrMnda == 0) ? false : true; }

        public decimal MontoItemOtrMnda { get; set; }
        public bool ShouldSerializeMontoItemOtrMnda() { return (MontoItemOtrMnda == 0) ? false : true; }
    }

    /// <summary>
    /// Desglose del Descuento
    /// </summary>
    public class HEFSubDscto
    {
        public string TipoDscto { get; set; }
        public decimal ValorDscto { get; set; }
    }

    /// <summary>
    /// Distribucion de la Cantidad
    /// </summary>
    public class HEFSubcantidad
    {

        /// <summary>
        /// Cantidad  Distribuida
        /// </summary>
        public decimal SubQty { get; set; }

        /// <summary>
        /// Codigo Descriptivo de la Subcantidad
        /// </summary>
        public string SubCod { get; set; }
    
    }

    /// <summary>
    /// Codificacion del Item
    /// </summary>
    public class HEFCdgItem
    {
        /// <summary>
        /// Tipo de Codificacion
        /// </summary>
        public string TpoCodigo { get; set; }

        /// <summary>
        /// Valor del Codigo de Item, para la Codificacion Particular
        /// </summary>
        public string VlrCodigo { get; set; }
    
    }

    /// <summary>
    /// Subtotales Informativos
    /// </summary>
    public class HEFSubTotInfo
    {
        /// <summary>
        /// Número de Subtotal 
        /// </summary>
        public int NroSTI { get; set; }

        /// <summary>
        /// Glosa
        /// </summary>
        public string GlosaSTI { get; set; }

        /// <summary>
        /// Ubicación para Impresión
        /// </summary>
        public int OrdenSTI { get; set; }
        public bool ShouldSerializeOrdenSTI() { return (OrdenSTI == 0) ? false : true; }

        /// <summary>
        /// Valor Neto del Subtotal
        /// </summary>
        public decimal SubTotNetoSTI { get; set; }
        public bool ShouldSerializeSubTotNetoSTI() { return (SubTotNetoSTI == 0) ? false : true; }

        /// <summary>
        /// Valor del IVA del Subtotal
        /// </summary>
        public decimal SubTotIVASTI { get; set; }
        public bool ShouldSerializeSubTotIVASTI() { return (SubTotIVASTI == 0) ? false : true; }

        /// <summary>
        /// Valor de los Impuestos adicionales o específicos del Subtotal
        /// </summary>
        public decimal SubTotAdicSTI { get; set; }
        public bool ShouldSerializeSubTotAdicSTI() { return (SubTotAdicSTI == 0) ? false : true; }

        /// <summary>
        /// Valor no Afecto o Exento del Subtotal
        /// </summary>
        public decimal SubTotExeSTI { get; set; }
        public bool ShouldSerializeSubTotExeSTI() { return (SubTotExeSTI == 0) ? false : true; }

        /// <summary>
        /// Valor de la línea de subtotal
        /// </summary>
        public decimal ValSubtotSTI { get; set; }
        public bool ShouldSerializeValSubtotSTI() { return (ValSubtotSTI == 0) ? false : true; }

        ////
        //// Lineas de detalle
        List<int> _LineasDeta = new List<int>();
        public List<int> LienasDeta
        {
            get { return _LineasDeta; }
            set { _LineasDeta = value; }
        
        }
        public bool ShouldSerializeLienasDeta() { return (LienasDeta.Count == 0) ? false : true; }
    
    }

    /// <summary>
    /// Identificacion de otros documentos Referenciados por Documento
    /// </summary>
    public class HEFReferencia
    {

        /// <summary>
        /// Numero Secuencial de Linea de Referencia
        /// </summary>
        public int NroLinRef { get; set; }

        /// <summary>
        /// Tipo de Documento de Referencia
        /// </summary>
        public string TpoDocRef { get; set; }

        /// <summary>
        /// Indica que se esta Referenciando un Conjunto de Documentos
        /// </summary>
        public int IndGlobal { get; set; }
        public bool ShouldSerializeIndGlobal() { return (IndGlobal == 0) ? false : true; }

        /// <summary>
        /// Folio del Documento de Referencia
        /// </summary>
        public long FolioRef { get; set; }

        /// <summary>
        /// RUT Otro Contribuyente
        /// </summary>
        public string RUTOtr { get; set; }

        /// <summary>
        /// Identificador Adicional del otro contribuyente
        /// </summary>
        public string IdAdicOtr { get; set; }

        /// <summary>
        /// Fecha de la Referencia
        /// </summary>
        public string FchRef { get; set; }

        /// <summary>
        /// Tipo de Uso de la Referencia
        /// 1: Anula Documento de Referencia
        /// 2: Corrige Texto del Documento de Referencia
        /// 3: Corrige Montos
        /// </summary>
        public int CodRef { get; set; }
        public bool ShouldSerializeCodRef() { return (CodRef == 0) ? false : true; }

        /// <summary>
        /// Razon Explicita por la que se Referencia el Documento
        /// </summary>
        public string RazonRef { get; set; }
            
    }

    /// <summary>
    /// INFORMACIÓN DE DESCUENTOS O RECARGOS 
    /// </summary>
    public class HEFDscRcgGlobal
    {

        /// <summary>
        /// Número de descuento o recargo. De 1 a 20.
        /// </summary>
        public int NroLinDR { get; set; }

        /// <summary>
        /// D(descuento) o R(recargo) 
        /// </summary>
        public string TpoMov { get; set; }

        /// <summary>
        /// Especificación de descuento o recargo 
        /// </summary>
        public string GlosaDR { get; set; }

        /// <summary>
        /// Indica si es Porcentaje o Monto 
        /// </summary>
        public string TpoValor { get; set; }

        /// <summary>
        /// Valor del descuento o recargo en 16  enteros y 2 decimales 
        /// </summary>
        public decimal ValorDR { get; set; }

        /// <summary>
        /// Indica si el descuento o recargo afecta a ítems exentos o no afectos a IVA. 
        /// </summary>
        [XmlElement]
        public int IndExeDR { get; set; }
        public bool ShouldSerializeIndExeDR()
        {
            return (IndExeDR == 0) ? false : true;
        }
    }

}
