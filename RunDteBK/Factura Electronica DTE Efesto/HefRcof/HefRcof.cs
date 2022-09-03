using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using HEFESTO.DTE.AUTENTICACION;
using HEFESTO.DTE.AUTENTICACION.ENT;

namespace HefRcof
{

    public class HefRangoUtilizados
    {
        public int Inicial { get; set; }
        public int Final { get; set; }
    }

    public class HefRangoAnulados
    {
        public int Inicial { get; set; }
        public int Final { get; set; }
    }

    /// <summary>
    /// Representa el resumen del documento
    /// </summary>
    public class HefResumen
    {

        public int TipoDocumento { get; set; }
        public long MntNeto { get; set; }
        public long MntIva { get; set; }
        public long MntExento { get; set; }
        public long MntTotal { get; set; }
        public int FoliosEmitidos { get; set; }
        public int FoliosAnulados { get; set; }
        public int FoliosUtilizados { get; set; }

                
        List<HefRangoUtilizados> _RangoUtilizados = new List<HefRangoUtilizados>();
        [XmlElement]
        public List<HefRangoUtilizados> RangoUtilizados
        {

            get { return _RangoUtilizados; }
            set { _RangoUtilizados = value; }
        }
        public bool ShouldSerializeRangoUtilidados() { return (RangoUtilizados.Count == 0) ? false : true; }

       
        
        List<HefRangoAnulados> _RangoAnulados = new List<HefRangoAnulados>();
        [XmlElement]
        public List<HefRangoAnulados> RangoAnulados
        {

            get { return _RangoAnulados; }
            set { _RangoAnulados = value; }
        }
        public bool ShouldSerializeRangoAnulados() { return (RangoAnulados.Count == 0) ? false : true; }


    }
    
    /// <summary>
    /// Representa la caratula del documento
    /// </summary>
    public class HEfCaratula
    {
        

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public HEfCaratula()
        {
            this.TmstFirmaEnv = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            this.Version = "1.0";

        }

        [XmlAttribute("version")]
        public string Version { get; set; }
        
        public string RutEmisor { get; set; }
        public string RutEnvia { get; set; }

        public string FchResol { get; set; }
        public string NroResol { get; set; }

        public string FchInicio { get; set; }

        public string FchFinal { get; set; }

        public string Correlativo { get; set; }

        public string SecEnvio { get; set; }

        public string TmstFirmaEnv { get; set; }
               

    }
    
    /// <summary>
    /// Documento 
    /// </summary>
    public class HefDocumentoConsumoFolios
    {


        public HefDocumentoConsumoFolios()
        {

            this.ID = string.Format("IDConsumo_Folio");

        }

        [XmlAttribute("ID")]
        public string ID { get; set; }


        HEfCaratula _caratula = new HEfCaratula();
        public HEfCaratula Caratula {
            get { return _caratula; }
            set { _caratula = value; }

        }


        List<HefResumen> _resumenes = new List<HefResumen>();
        [XmlElement("Resumen")]
        public List<HefResumen> Resumenes {
            get { return _resumenes;  }
            set { _resumenes = value;  }
        }


    }




    /// <summary>
    /// Representa el documento Rcof para envio de resumenes de Boletas Electrónicas
    /// </summary>
    [XmlRoot("ConsumoFolios")]
    public class HefConsumoFolios
    {

        #region ELEMENTOS DEL DOCUMENTO

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public HefConsumoFolios()
        {
            this.Version = "1.0";
        }

        /// <summary>
        /// Representa la version del documento
        /// </summary>
        [XmlAttribute("version")]
        public string Version { get; set; }
        #endregion

        #region CERTIFICADO

        /// <summary>
        /// Indica el nombre del certificado para poder firmar el documento
        /// </summary>
        [XmlIgnore]
        public string Certificado { get; set; }

        /// <summary>
        /// Indica cual es el schema a utilizar para validar el documento resultante
        /// </summary>
        [XmlIgnore]
        public string Schema { get; set; }

        /// <summary>
        /// Indica cual es el trackid de la operación
        /// </summary>
        [XmlIgnore]
        public string Trackid { get; set; }

        #endregion

        #region DOCUMENTO CONSUMO DE FOLIOS

        HefDocumentoConsumoFolios _DocumentoConsumoFolios = new HefDocumentoConsumoFolios();
        public HefDocumentoConsumoFolios DocumentoConsumoFolios
        {
            get { return _DocumentoConsumoFolios; }
            set { _DocumentoConsumoFolios = value; }

        }

       




        #endregion

        /// <summary>
        /// Inicia la publicación del documento
        /// </summary>
        /// <returns></returns>
        public bool Publicar()
        {

            ////
            //// Iniciar la publicación del documento actual
            bool resp = false;

            ////
            //// Cree un archivo temporal para guardar el XML
            string temp_archivo = Path.ChangeExtension(Path.GetTempFileName(),".Xml");

            ////
            //// Iniciar el proceso de publicación
            try
            {
                ////
                //// Recupere el certificado desde el repositorio de windows
                X509Certificate2 Certificado = Negocio.Certificados.RecuperarCertificado(this.Certificado);
                if (Certificado == null)
                    throw new Exception("No fue posible recuperar el certificado indicado.");
                if (!Certificado.HasPrivateKey)
                    throw new Exception("Certificado no tiene clave privada.");

                ////
                //// Recupere el documento en formato xml string
                XmlDocument xCf = new XmlDocument();
                xCf.PreserveWhitespace = true;
                xCf.LoadXml(Negocio.Serializar.RecuperarXml(this));

                ////
                //// Agregar los namespaces necesarios.
                xCf.DocumentElement.SetAttribute("xmlns", "http://www.sii.cl/SiiDte");
                xCf.DocumentElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                xCf.DocumentElement.SetAttribute("schemaLocation", "http://www.w3.org/2001/XMLSchema-instance", "http://www.sii.cl/SiiDte ConsumoFolio_v10.xsd");

                ////
                //// Aplicar los cambios al documento
                string temp = xCf.OuterXml;
                
                ////
                //// Aplicar los cambios cargando nuevamente el documento
                xCf = new XmlDocument();
                xCf.PreserveWhitespace = true;
                xCf.LoadXml(temp);

                ////
                //// Iniciar el proceso de firma
                Negocio.Firma.firmarDocumentoXml(ref xCf, Certificado, "#IDConsumo_Folio");

                ////
                //// Aplicar los cambios al documento despues de firmalo
                temp = xCf.OuterXml;

                ////
                //// Agregar la instrucción de procesamiento del archivo
                temp = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\" ?>\r\n" + temp;
                File.WriteAllText(temp_archivo, temp, Encoding.GetEncoding("ISO-8859-1"));

                ////
                //// Firmado el documento Verificar el schema del documento antes de ser enviado al SII.
                List<string> mis_errores = Negocio.Schemas.ValidarSchema(temp_archivo, this.Schema);
                if (mis_errores.Count > 0)
                    throw new Exception(string.Join(", ", mis_errores));

                ////
                //// Recuperar el token
                Respuesta respSend = LOGIN.Conectar(this.Certificado, SIIAmbiente.Produccion); ////
                if (!respSend.correcto)
                    throw new Exception(respSend.mensaje + " " + respSend.detalle);

                string token = respSend.Resultado.ToString();

                ////
                //// Iniciar el envío del documento al SII
                Respuesta respEnvio = ENVIO.EnviarArchivoSII(
                    temp_archivo,
                    token,
                    this.DocumentoConsumoFolios.Caratula.RutEnvia.Split('-')[0],
                    this.DocumentoConsumoFolios.Caratula.RutEnvia.Split('-')[1],
                    this.DocumentoConsumoFolios.Caratula.RutEmisor.Split('-')[0],
                    this.DocumentoConsumoFolios.Caratula.RutEmisor.Split('-')[1],
                    SIIAmbiente.Produccion ////
                    );

                if (!respEnvio.correcto)
                    throw new Exception(respEnvio.mensaje + " " + respEnvio.detalle);

                ////
                //// Recuperar el trackid del envío
                this.Trackid = respEnvio.Resultado.ToString();
                resp = true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
            finally
            {
                ////
                //// Eliminar el archivo temporal
                File.Delete(temp_archivo);

            }


            //// return 
            ///
            return resp;

        }


    }
}
