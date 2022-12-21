using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HefestoCesionV12
{
    #region CLASE PARA CONFIGURAR EL AEC

    /// <summary>
    /// Opciones del procesamiento
    /// </summary>
    public enum HefAmbienteProcesamiento
    { 
        Certificacion = 0,
        Produccion = 1
    }


    public class HefAmbiente
    {
        /// <summary>
        /// Indica el ambiente donde procesar
        /// </summary>
        public HefAmbienteProcesamiento Procesamiento { get; set; }

    }


    /// <summary>
    /// Datos del certificado
    /// </summary>
    public class HefCertificado
    {
        /// <summary>
        /// Fullpath del certificado pfx
        /// </summary>
        public string Path_certificado { get; set; }

        /// <summary>
        /// Password del certificado pfx
        /// </summary>
        public string Pass_certificado { get; set; }

        /// <summary>
        /// Nombre comun del certificado
        /// </summary>
        public string Cn { get; set; }

        /// <summary>
        /// Rut del dueño del certificado
        /// </summary>
        public string Rut { get; set; }

    }

    /// <summary>
    /// Schema de validacion del documento AEC
    /// </summary>
    public class HefArchivoSchema
    {
        /// <summary>
        /// Fullpath del documento schema
        /// </summary>
        public string FullPath { get; set; }

    }

    /// <summary>
    /// Representa los datos del documento DTE
    /// </summary>
    public class HefArchivoDte
    {
        /// <summary>
        /// Fullpath del documento DTE
        /// </summary>
        public string FullPath { get; set; }

    }

    
    public class HefConfiguracion
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public HefConfiguracion()
        {
           
        }

        /// <summary>
        /// Representa los datos del archivo AEC
        /// </summary>
        HefArchivoDte _HefArchivoDte = new HefArchivoDte();
        public HefArchivoDte ArchivoDte {
            get { return _HefArchivoDte; }
            set { _HefArchivoDte = value; }
        }

        /// <summary>
        /// Representa los datos del schema
        /// </summary>
        HefArchivoSchema _HefArchivoSchema = new HefArchivoSchema();
        public HefArchivoSchema ArchivoSchema {
            get { return _HefArchivoSchema; }
            set { _HefArchivoSchema = value; }
        }

        /// <summary>
        /// Representa los datos del certificado digital
        /// </summary>
        HefCertificado _HefCertificado = new HefCertificado();
        public HefCertificado Certificado {
            get { return _HefCertificado; }
            set { _HefCertificado = value; }
        }

        /// <summary>
        /// Cual es el ambiente de procesamiento
        /// </summary>
        HefAmbiente _HefAmbiente = new HefAmbiente();
        public HefAmbiente Ambiente {
            get { return _HefAmbiente; }
            set { _HefAmbiente = value; }
        }


    }


    #endregion

    #region CLASES PARA CREAR DOCUMENTO AEC

    /// <summary>
    /// Envio de Informacion de Transferencias  Electronicas
    /// </summary>
    public class HefCesion
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public HefCesion()
        {
            this.Version = "1.0";
        }

        /// <summary>
        /// Representa el documento cesion
        /// </summary>
        HefDocumentoCesion _HefDocumentoCesion = new HefDocumentoCesion();
        public HefDocumentoCesion DocumentoCesion {
            get { return _HefDocumentoCesion; }
            set { _HefDocumentoCesion = value; }
        }

        /// <summary>
        /// Version de AEC
        /// </summary>
        [XmlAttribute("version")]
        public string Version { get; set; }

    }


    /// <summary>
    /// Representa el documento DTE que se va a ceder
    /// </summary>
    public class HefDocumentoDTECedido
    {

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public HefDocumentoDTECedido()
        {
            this.Id = "IdDTECedido";
            this.DTE = "DTE";
            this.TmstFirma = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            ////this.Banner_Superior = Negocio.HefSerializacion.CrearComentario("Inicio Documento DTE Original");
            ////this.Banner_Inferior = Negocio.HefSerializacion.CrearComentario("Fin Documento DTE Original");
        }

        /// <summary>
        /// Comenarios
        /// </summary>
        [XmlAnyElement("banner_superior_DTE")]
        public XmlComment Banner_Superior { get; set; }

        /// <summary>
        /// Representa el DTE a Ceder
        /// </summary>
        public string DTE { get; set; }

        /// <summary>
        /// Comenarios
        /// </summary>
        [XmlAnyElement("banner_Inferior_DTE")]
        public XmlComment Banner_Inferior{ get; set; }

        /// <summary>
        /// Fecha y Hora en que se Firmo Digitalmente el Documento Cedido AAAA-MM-DDTHH:MI:SS
        /// </summary>
        public string TmstFirma { get; set; }

        /// <summary>
        /// Version de AEC
        /// </summary>
        [XmlAttribute("ID")]
        public string Id { get; set; }
    }


    /// <summary>
    /// Representa los datos del dte cedido ( DTE con Imagen y Recibos ).
    /// </summary>
    public class HefDTECedido
    {

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public HefDTECedido()
        {
            this.Version = "1.0";
           
        }

        /// <summary>
        /// Documento DTE Cedido
        /// </summary>
        HefDocumentoDTECedido _HefDocumentoDTECedido = new HefDocumentoDTECedido();
        public HefDocumentoDTECedido DocumentoDTECedido {
            get { return _HefDocumentoDTECedido; }
            set { _HefDocumentoDTECedido = value; }
        }


        /// <summary>
        /// Version de AEC
        /// </summary>
        [XmlAttribute("version")]
        public string Version { get; set; }
    }

    /// <summary>
    /// Identificacion del DTE Cedido
    /// </summary>
    public class HefIdDTE
    {
        /// <summary>
        /// Tipo de DTE
        /// </summary>
        public int TipoDTE { get; set; }

        /// <summary>
        /// Rut del emisor documento DTE
        /// </summary>
        public string RUTEmisor { get; set; }

        /// <summary>
        /// Rut del receptor del documento
        /// </summary>
        public string RUTReceptor { get; set; }

        /// <summary>
        /// Folio del DTE
        /// </summary>
        public long Folio { get; set; }

        /// <summary>
        /// Fecha Emision Contable del DTE (AAAA-MM-DD)
        /// </summary>
        public string FchEmis { get; set; }

        /// <summary>
        /// Monto Total del DTE
        /// </summary>
        public long MntTotal { get; set; }

    }

    /// <summary>
    /// Lista de Personas Autorizadas por el Cedente a Firmar la Transferencia
    /// </summary>
    public class HefRUTAutorizado
    {
        /// <summary>
        /// RUT de Persona Autorizada
        /// </summary>
        public string RUT { get; set; }

        /// <summary>
        /// Nombre de Persona Autorizada
        /// </summary>
        public string Nombre { get; set; }
        
    }

    /// <summary>
    /// Identificacion del Cedente
    /// </summary>
    public class HefCedente
    {
        /// <summary>
        /// RUT del Cedente del DTE
        /// </summary>
        public string RUT { get; set; }

        /// <summary>
        /// Razon Social o Nombre del Cedente
        /// </summary>
        public string RazonSocial { get; set; }

        /// <summary>
        /// Direccion del Cedente
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Correo Electronico del Cedente
        /// </summary>
        public string eMail { get; set; }

        /// <summary>
        /// Datos del rut autorizado a firmar la cesion electrónica
        /// </summary>
        HefRUTAutorizado _HefRUTAutorizado = new HefRUTAutorizado();
        public HefRUTAutorizado RUTAutorizado {
            get { return _HefRUTAutorizado; }
            set { _HefRUTAutorizado = value; }
        }

        /// <summary>
        /// Declaracion Jurada de Disponibilidad de Documentacion No Electronica
        /// </summary>
        public string DeclaracionJurada { get; set; }

    }

    /// <summary>
    /// Representa los datos del cesionario del documeto
    /// </summary>
    public class HefCesionario
    {
        /// <summary>
        /// RUT del cesionario del DTE
        /// </summary>
        public string RUT { get; set; }

        /// <summary>
        /// Razon Social o Nombre del cesionario
        /// </summary>
        public string RazonSocial { get; set; }

        /// <summary>
        /// Direccion del cesionario
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Correo Electronico del cesionario
        /// </summary>
        public string eMail { get; set; }

    }

    /// <summary>
    /// Represneta el documento cesion
    /// </summary>
    public class HefDocumentoCesion
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public HefDocumentoCesion()
        {
            this.Id = "DocumentoCesion";
            this.SeqCesion = 1;
            this.TmstCesion = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
        }


        /// <summary>
        /// Secuencia de Cesiones (1, 2, 3, ... )
        /// </summary>
        public int SeqCesion { get; set; }


        /// <summary>
        /// Representa los datos de identificación del documento DTE
        /// </summary>
        HefIdDTE _HefIdDTE = new HefIdDTE();
        public HefIdDTE IdDTE {
            get { return _HefIdDTE; }
            set { _HefIdDTE = value; }
        }

        /// <summary>
        /// Representa los datos del cedente
        /// </summary>
        HefCedente _HefCedente = new HefCedente();
        public HefCedente Cedente {
            get { return _HefCedente; }
            set { _HefCedente = value; }
        }

        /// <summary>
        /// Representa los datos del cesionario
        /// </summary>
        HefCesionario _HefCesionario = new HefCesionario();
        public HefCesionario Cesionario
        {
            get { return _HefCesionario; }
            set { _HefCesionario = value; }
        }

        /// <summary>
        /// monto de la cesion actual
        /// </summary>
        public long MontoCesion { get; set; }

        /// <summary>
        /// Fecha del ultimo vencimiento indicado por el cedente
        /// </summary>
        public string UltimoVencimiento { get; set; }

        /// <summary>
        /// TmstCesion de la cesion actual
        /// </summary>
        public string TmstCesion { get; set; }


        /// <summary>
        /// ID de Documento AEC
        /// </summary>
        [XmlAttribute("ID")]
        public string Id { get; set; }


    }

    /// <summary>
    /// Representa las cesiones del documento actual
    /// </summary>
    public class HefCesiones
    {
        /// <summary>
        /// Representa el dte cedido
        /// </summary>
        HefDTECedido _HefDTECedido = new HefDTECedido();
        public HefDTECedido DTECedido {
            get { return _HefDTECedido; }
            set { _HefDTECedido = value; }
        }

        /// <summary>
        /// Representa 
        /// </summary>
        HefCesion _hefCesion = new HefCesion();
        public HefCesion Cesion {
            get { return _hefCesion; }
            set { _hefCesion = value; }
        }

    }

    /// <summary>
    /// Informacion de AEC
    /// </summary>
    public class HefCaratula
    {

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public HefCaratula()
        {
            this.Version = "1.0";
            this.TmstFirmaEnvio = DateTime.Now.ToString("yyyy-MM-ddTH:mm:ss");
        }

        /// <summary>
        /// RUT que Genera el Archivo de Transferencias
        /// </summary>
        public string RutCedente { get; set; }

        /// <summary>
        /// RUT a Quien Va Dirigido el Archivo de Transferencias
        /// </summary>
        public string RutCesionario { get; set; }

        /// <summary>
        /// Persona de Contacto para aclarar dudas
        /// </summary>
        public string NmbContacto { get; set; }

        /// <summary>
        /// Telefono de Contacto
        /// </summary>
        public string FonoContacto { get; set; }

        /// <summary>
        /// Correo Electronico de Contacto
        /// </summary>
        public string MailContacto { get; set; }

        /// <summary>
        /// Fecha y Hora de la Firma del Archivo de Transferencias
        /// </summary>
        public string TmstFirmaEnvio { get; set; }

        /// <summary>
        /// Version de AEC aratula
        /// </summary>
        [XmlAttribute("version")]
        public string Version { get; set; }

    }

    /// <summary>
    /// Nodo Documento AEC
    /// </summary>
    [XmlRoot("DocumentoAEC")]
    public class HefDocumentoAEC
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public HefDocumentoAEC()
        {
            this.Id = "ID_AEC";
        }

        /// <summary>
        /// ID de Documento AEC
        /// </summary>
        [XmlAttribute("ID")]
        public string Id { get; set; }

        /// <summary>
        /// Caratula del documento
        /// </summary>
        HefCaratula _HefCaratula = new HefCaratula();
        public HefCaratula Caratula
        {
            get { return _HefCaratula; }
            set { _HefCaratula = value; }
        }

        /// <summary>
        /// Representa las cesiones del documento AEC
        /// </summary>
        HefCesiones _HefCesiones = new HefCesiones();
        public HefCesiones Cesiones {
            get { return _HefCesiones; }
            set { _HefCesiones = value; }
        }



    }

    #endregion


    /// <summary>
    /// representa la clase session
    /// </summary>
    [XmlRoot("AEC")]
    public class HefAec
    {

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public HefAec()
        {
            this.Version = "1.0";
            this.Banner = Negocio.HefSerializacion.CrearComentario("Hefesto  v.10 - Generacion archivo AEC ( Cesión Electrónica )");
            
        }

        /// <summary>
        /// Constructor de la clase con parametro fullpath Xml DTE
        /// </summary>
        public HefAec(string fullpathDTE)
        {
            this.Version = "1.0";
            this.Banner = Negocio.HefSerializacion.CrearComentario("Hefesto  v.10 - Generacion archivo AEC ( Cesión Electrónica )");
            
            ////
            //// Iniciar el proceso
            try
            {
                ////
                //// Validación
                if (!File.Exists(fullpathDTE))
                    throw new Exception("No existe o no se tiene acceso al documento DTE.");

                ////
                //// Recupere los datos del documento
                this.Configuracion.ArchivoDte.FullPath = fullpathDTE;

                ////
                //// Recupere el contenido del archivo
                string _content = File.ReadAllText(fullpathDTE, Encoding.GetEncoding("ISO-8859-1"));

                ////
                //// Recupere los datos necesarios
                Match _TipoDTE = Regex.Match(_content, "<TipoDTE>(.*?)<\\/TipoDTE>", RegexOptions.Singleline);
                Match _RUTEmisor = Regex.Match(_content, "<RUTEmisor>(.*?)<\\/RUTEmisor>", RegexOptions.Singleline);
                Match _RUTReceptor = Regex.Match(_content, "<RUTRecep>(.*?)<\\/RUTRecep>", RegexOptions.Singleline);
                Match _Folio = Regex.Match(_content, "<Folio>(.*?)<\\/Folio>", RegexOptions.Singleline);
                Match _FchEmis = Regex.Match(_content, "<FchEmis>(.*?)<\\/FchEmis>", RegexOptions.Singleline);
                Match _MntTotal = Regex.Match(_content, "<MntTotal>(.*?)<\\/MntTotal>", RegexOptions.Singleline);

                ////
                //// Compruebe que existan los datos
                if (!_TipoDTE.Success)
                    throw new Exception("No se encuentra el nodo TipoDTE");
                if (!_RUTEmisor.Success)
                    throw new Exception("No se encuentra el nodo RUTEmisor");
                if (!_RUTReceptor.Success)
                    throw new Exception("No se encuentra el nodo RUTReceptor");
                if (!_Folio.Success)
                    throw new Exception("No se encuentra el nodo Folio");
                if (!_FchEmis.Success)
                    throw new Exception("No se encuentra el nodo FchEmis");
                if (!_MntTotal.Success)
                    throw new Exception("No se encuentra el nodo MntTotal");

                ////
                //// Complete los datos de Dte Cedido
                this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.IdDTE.TipoDTE = Convert.ToInt32( _TipoDTE.Groups[1].Value);
                this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.IdDTE.RUTEmisor = _RUTEmisor.Groups[1].Value;
                this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.IdDTE.RUTReceptor = _RUTReceptor.Groups[1].Value;
                this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.IdDTE.Folio = Convert.ToInt64( _Folio.Groups[1].Value);
                this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.IdDTE.FchEmis = _FchEmis.Groups[1].Value;
                this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.IdDTE.MntTotal = Convert.ToInt64( _MntTotal.Groups[1].Value);

                ////
                //// Complete los valores de la cesion actual
                this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.MontoCesion = Convert.ToInt64(_MntTotal.Groups[1].Value);
                this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.UltimoVencimiento = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
                this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.TmstCesion = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
                    
        
        }



        /// <summary>
        /// Comenarios
        /// </summary>
        [XmlAnyElement("banner")]
        public XmlComment Banner { get; set; }

        /// <summary>
        /// Datos de la configuracion del proceso
        /// </summary>
        HefConfiguracion _HefConfiguracion = new HefConfiguracion();
        [XmlIgnore]
        public HefConfiguracion Configuracion {
            get { return _HefConfiguracion; }
            set { _HefConfiguracion = value; }
        }

        /// <summary>
        /// Documento AEC ( cuerpo del documento )
        /// </summary>
        HefDocumentoAEC _HefDocumentoAEC = new HefDocumentoAEC();
        public HefDocumentoAEC DocumentoAEC {
            get { return _HefDocumentoAEC; }
            set { _HefDocumentoAEC = value; }
        }

        /// <summary>
        /// Version de AEC
        /// </summary>
        [XmlAttribute("version")]
        public string Version { get; set; }

        


        /// <summary>
        /// Recupera el documento Xml
        /// </summary>
        /// <returns></returns>
        public string RecuperarDocumentoXml()
        {
            return Negocio.HefSerializacion.RecuperarDocumentoXml(this);
        
        
        }

        /// <summary>
        /// Permite publicar el docuento aec atual.
        /// </summary>
        public  HefRespuesta PublicarDocumento()
        {
            ////
            //// Inicie la respuesta del proceso
            HefRespuesta resp = new HefRespuesta();
            resp.EsCorrecto = false;
            resp.Mensaje = "PublicarDocumento";

            ////
            //// Iniciar
            try
            {

                #region VALIDACIONES

                ////
                //// Validacion de ruts del documento
                if (string.IsNullOrEmpty(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.UltimoVencimiento))
                    this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.UltimoVencimiento = DateTime.Now.AddMonths(3).ToString("yyyy-MM-dd");
                
                ////
                //// Valide el formato de la fecha del ultimo vencimiento
                if ( !Regex.IsMatch(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.UltimoVencimiento, "[0-9]{4}-[0-9]{2}-[0-9]{2}", RegexOptions.Singleline) )
                    throw new Exception("Ultimo vencimiento no tiene el formato correcto (yyyy-mm-dd)");

                ////
                //// Valide el valor de la fecha
                DateTime dt;
                if ( !DateTime.TryParse(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.UltimoVencimiento,out dt))
                    throw new Exception("Ultimo vencimiento es una fecha no valida");

                ////
                //// Si la fecha ultimo vencimiento es correcta consulte si esta fecha es mayor que hoy
                if ( dt <= DateTime.Now )
                    throw new Exception("Ultimo vencimiento debe ser mayor que la fecha actual.");

                ////
                //// Validacion de ruts del documento
                if (string.IsNullOrEmpty(this.Configuracion.Certificado.Rut))
                    throw new Exception("Debe ingresar el parametro rut del certificado.");
                if ( !Negocio.HefRuts.ValidaRut(this.Configuracion.Certificado.Rut) )
                    throw new Exception("El rut del certificado no es valido.");

                ////
                //// Validacion de ruts del documento
                if (string.IsNullOrEmpty(this.DocumentoAEC.Caratula.RutCedente))
                    throw new Exception("Debe ingresar el parametro rut del cedente.");
                if (!Negocio.HefRuts.ValidaRut(this.DocumentoAEC.Caratula.RutCedente))
                    throw new Exception("El rut del cedente no es valido.");

                ////
                //// Validacion de ruts del documento
                if (string.IsNullOrEmpty(this.DocumentoAEC.Caratula.RutCesionario))
                    throw new Exception("Debe ingresar el parametro rut del cesionario.");
                if (!Negocio.HefRuts.ValidaRut(this.DocumentoAEC.Caratula.RutCesionario))
                    throw new Exception("El rut del cesionario no es valido.");

                ////
                //// Validacion de ruts del documento
                if (string.IsNullOrEmpty(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.IdDTE.RUTEmisor))
                    throw new Exception("Debe ingresar el parametro rut del emisor.");
                if (!Negocio.HefRuts.ValidaRut(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.IdDTE.RUTEmisor))
                    throw new Exception("El rut del emisor no es valido.");

                ////
                //// Validacion de ruts del documento
                if (string.IsNullOrEmpty(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.IdDTE.RUTReceptor))
                    throw new Exception("Debe ingresar el parametro rut del receptor.");
                if (!Negocio.HefRuts.ValidaRut(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.IdDTE.RUTReceptor))
                    throw new Exception("El rut del receptor no es valido.");

                ////
                //// Validacion de ruts del documento
                if (string.IsNullOrEmpty(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cedente.RUT))
                    throw new Exception("Debe ingresar el parametro rut del cedente.");
                if (!Negocio.HefRuts.ValidaRut(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cedente.RUT))
                    throw new Exception("El rut del cedente no es valido.");

                ////
                //// Validacion de ruts del documento
                if (string.IsNullOrEmpty(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cesionario.RUT))
                    throw new Exception("Debe ingresar el parametro rut del cesionario.");
                if (!Negocio.HefRuts.ValidaRut(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cesionario.RUT))
                    throw new Exception("El rut del cesionario no es valido.");

                ////
                //// Validacion de ruts del documento
                if (string.IsNullOrEmpty(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cedente.RUTAutorizado.RUT))
                    throw new Exception("Debe ingresar el parametro rut autorizado.");
                if (!Negocio.HefRuts.ValidaRut(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cedente.RUTAutorizado.RUT))
                    throw new Exception("El rut autorizado no es valido.");

                ////
                //// Inicie la validación de el nombre del titular del certificado
                if (string.IsNullOrEmpty(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cedente.RUTAutorizado.Nombre))
                    throw new Exception("Debe ingresar el parametro nombre autorizado.");

                ////
                //// Inicie el proceso de firma del documento aec.
                //// El certificado es valido?
                X509Certificate2 certificado = null;
                if (!string.IsNullOrEmpty(this.Configuracion.Certificado.Cn))
                {
                    ////
                    //// Recuperar el certificado para procesar el documento
                    certificado = Negocio.HefCertificados.obtenerCertificado(this.Configuracion.Certificado.Cn);

                }

                ////
                //// En el caso de utilizar parametros de entrada para el certificado
                if (certificado == null)
                {
                    if (!string.IsNullOrEmpty(this.Configuracion.Certificado.Path_certificado))
                    {
                        if (!string.IsNullOrEmpty(this.Configuracion.Certificado.Pass_certificado))
                        {

                            ////
                            //// Compruebe que el archivo existe
                            if (!File.Exists(this.Configuracion.Certificado.Path_certificado))
                                throw new Exception($"No se encuentra o no se tiene acceso al certificado: " +
                                    $"'{this.Configuracion.Certificado.Path_certificado}'");

                            ////
                            //// Reconstruya el certificado
                            certificado = new X509Certificate2(this.Configuracion.Certificado.Path_certificado,
                                this.Configuracion.Certificado.Pass_certificado
                                    );

                        }

                    }
                }

                ////
                //// Tenemos un certificado?
                if (certificado == null)
                    throw new Exception($"No existe o no se tiene acceso al certificado '{this.Configuracion.Certificado.Cn}'.");

                ////
                //// El certificado tiene private key?
                if ( !certificado.HasPrivateKey )
                    throw new Exception($"El certificado no tiene private key. '{this.Configuracion.Certificado.Cn}'.");

                ////
                //// El certificado esta expirado?
                DateTime dtt;
                if (DateTime.TryParse(certificado.GetExpirationDateString(), out dtt))
                    if (dtt < DateTime.Now)
                        throw new Exception($"El certificado está expirado. '{this.Configuracion.Certificado.Cn}'.");

                ////
                //// Valide los datos de la declaracion jurada
                if (string.IsNullOrEmpty(this.Configuracion.Certificado.Rut))
                    throw new Exception("Debe ingresar el rut del certificado para continuar con el procesamiento.");
                if (string.IsNullOrEmpty(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cedente.RUT))
                    throw new Exception("Debe ingresar el rut cedente del documento.");
                if (string.IsNullOrEmpty(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cesionario.RazonSocial))
                    throw new Exception("Debe ingresar el razón social del cesionario del documento.");

                ////
                //// Inicie la validación de los elementos necesarios del documento.
                if (!File.Exists(this.Configuracion.ArchivoDte.FullPath))
                    throw new Exception("El archivo DTE no existe o no se tiene acceso a el.");
                if (Path.GetExtension(this.Configuracion.ArchivoDte.FullPath).ToString().ToUpper() != ".XML")
                    throw new Exception("El archivo DTE no tiene una extension XML.");

                ////
                //// Evalue si el documento DTE es valido
                string content = File.ReadAllText(this.Configuracion.ArchivoDte.FullPath, Encoding.GetEncoding("ISO-8859-1"));
                if (!Regex.IsMatch(content, "<DTE.*?>.*?<\\/DTE>", RegexOptions.Singleline))
                    throw new Exception("El archivo DTE no contiene un elemento DTE para ser procesado.");
                if (!Regex.IsMatch(content, "xmlns=\"http://www.sii.cl/SiiDte\"", RegexOptions.Singleline))
                    throw new Exception("El archivo DTE no contiene el espacio de nombre del SII.");

                ////
                //// Recupere el nombre del titular del certificado.
                Match _nombre_titular = Regex.Match(certificado.Subject, "CN=(.*?),", RegexOptions.Singleline);
                if (!_nombre_titular.Success)
                    throw new Exception($"No se encuentra o no se tiene acceso al nombre del titular del certificado.'{certificado.Subject}'");

                ////
                //// Normalice los datos
                string _nombre_titular_certificado = _nombre_titular.Groups[1].Value.Trim().ToUpper();
                if (!string.IsNullOrEmpty(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cedente.RUTAutorizado.Nombre))
                    _nombre_titular_certificado = this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cedente.RUTAutorizado.Nombre;

                if (_nombre_titular_certificado.Length > 30)
                    _nombre_titular_certificado = _nombre_titular_certificado.Substring(0, 30);

                ////
                //// Normalice el nombre del titular del certificado
                string Nombre_cn = _nombre_titular_certificado.ToUpper().Trim();
                
                ////
                //// Normalice los datos
                string Nombre_cesionario = "";
                if (string.IsNullOrEmpty(this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cesionario.RazonSocial))
                    throw new Exception("Debe agregar el nombre del cesionario.");
                else
                {
                    Nombre_cesionario = this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cesionario.RazonSocial;
                    if (this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cesionario.RazonSocial.Length > 30)
                        Nombre_cesionario = this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cesionario.RazonSocial.Substring(0, 30);
                }

                ////
                //// Normalice el documento DTE
                content = Regex.Match(content, "<DTE\\s.*?<\\/DTE>", RegexOptions.Singleline).Value;

                #endregion

                #region AGREGAR LOS DATOS DE DECLARACION JURADA

                ////
                //// Recuperar el rut receptor
                string rut_receptor = this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.IdDTE.RUTReceptor;

                ////
                //// Normalice la declaracion jurada 
                string Declaracion_Jurada = "";
                Declaracion_Jurada += "Yo " + Nombre_cn + ", RUT " + this.Configuracion.Certificado.Rut + ", en representacion de , ";
                Declaracion_Jurada += "RUT " + this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cedente.RUT + ", declaro bajo juramento que se ha puesto a disposicion del ";
                Declaracion_Jurada += "cesionario " + Nombre_cesionario + ", RUT " + this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cesionario.RUT + ", el (los) documento(s) donde ";
                Declaracion_Jurada += "constan los recibos de la recepcion de las mercaderias entregadas o servicios prestados, ";
                Declaracion_Jurada += "entregados por parte del deudor de la factura " + rut_receptor + ", Rut " + rut_receptor + ", ";
                Declaracion_Jurada += "de acuerdo a lo establecido en la Ley N 19.983";

                ////
                //// Agregar la declaracion jurada
                this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cedente.DeclaracionJurada = Declaracion_Jurada;

                #endregion


                #region NORMALIZACION GENERAL DE DATOS ANTES DE PROCESAR EL DOCUMENTO

                ////
                //// Inicie la recuperación del documento AEC subyacente.
                string content_aec = Negocio.HefSerializacion.RecuperarDocumentoXml(this);


                ////
                //// Normalice el documento AEC 
                content_aec = Regex.Replace(content_aec, "\r\n\\s+<!--Inicio Documento DTE Original-->", "\r\n<!--Inicio Documento DTE Original-->", RegexOptions.Singleline);
                content_aec = Regex.Replace(content_aec, "\r\n\\s+<DTE>", "\r\n<DTE>", RegexOptions.Singleline);
                content_aec = Regex.Replace(content_aec, "\r\n\\s+<!--Fin Documento DTE Original-->", "\r\n<!--Fin Documento DTE Original-->", RegexOptions.Singleline);

                ////
                //// Agregar el documento DTE al AEC
                content_aec = Regex.Replace(content_aec, "<DTE>.*?<\\/DTE>", content, RegexOptions.Singleline);

                ////
                //// Agregar el namespace al documento AEC
                content_aec = Regex.Replace(content_aec, "<AEC version=\"1.0\">", "<AEC version=\"1.0\" xmlns=\"http://www.sii.cl/SiiDte\">", RegexOptions.Singleline);

                #endregion

               

                #region EVALUE LOS DATOS DE CESION FECHA VENCIMIENTO Y MONTO CESION

                ////
                //// indicar que el monto de la cesion es por el mismo valor que el documento original
                if (this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.MontoCesion == 0)
                    this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.MontoCesion = this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.IdDTE.MntTotal;

                ////
                //// Validar que el monto de la cesion no se mayor que el maximo o menor que cero
                if (this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.MontoCesion <= 0)
                    throw new Exception("El monto de la cesion no puede ser igual o menor que 0.");
                if (this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.MontoCesion > this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.IdDTE.MntTotal)
                    throw new Exception("El monto de la cesion no puede ser mayor que el monto original del DTE.");

                


                #endregion

                #region PUBLICACION DE DOCUMENTO AEC

                ////
                //// Inicie la firma del documento
                HefRespuesta resp_firmas = Negocio.HefFirmas.FirmarDocumentoAEC(certificado, content_aec);
                if (!resp_firmas.EsCorrecto)
                    return resp_firmas;

                ////
                //// Recuperar el documento Firmado
                content_aec = resp_firmas.Resultado.ToString();

                //////
                ////// Agregar los namespaces del documento antes de ser envisdo al SII
                //content_aec = Regex.Replace(
                //    content_aec,
                //        "<AEC version=\"1.0\" xmlns=\"http://www.sii.cl/SiiDte\">",
                //            "<AEC version=\"1.0\" xmlns=\"http://www.sii.cl/SiiDte\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.sii.cl/SiiDte AEC_v10.xsd\">", 
                //                RegexOptions.Singleline);


                ////
                //// Inicie la validación del documento AEC utilizando el schema del SII.
                string _errores = "";
                if (!Negocio.HefSchema.EsValidoElSchemaDelSII(content_aec, this.Configuracion.ArchivoSchema.FullPath, out _errores))
                    throw new Exception("El documento AEC tiene errores de schema: " + _errores);

                ////
                //// iniciar el envio al SII
                if ( this.Configuracion.Ambiente.Procesamiento == HefAmbienteProcesamiento.Certificacion )
                    resp = Negocio.HefPublicacion.PublicarDocumentoCertificacion(content_aec, certificado);
                else
                    resp = Negocio.HefPublicacion.PublicarDocumentoProduccion(content_aec, certificado);


                ////
                //// Agregar datos adicionales
                if (resp.EsCorrecto)
                    resp.NombreArchivoAec = $"AEC_TK{resp.Trackid}" +
                                                $"_R{this.DocumentoAEC.Caratula.RutCedente}" +
                                                    $"_T{this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.IdDTE.TipoDTE}" +
                                                        $"_F{this.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.IdDTE.Folio}.xml";
 

                #endregion
            }
            catch (Exception det)
            {
                ////
                //// Notificar el error
                resp.EsCorrecto = false;
                resp.Detalle = det.Message;
                resp.Resultado = null;
            }

            ////
            //// Regrese el valor de retorno
            return resp;


        }

    }

}
