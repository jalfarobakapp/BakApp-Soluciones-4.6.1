using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Security.Permissions;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Security.Cryptography.Xml;
using HEFESTO.DTE.AUTENTICACION.ENT;



namespace HEFESTO.DTE.AUTENTICACION
{
    public class FuncionesComunes
    {
        #region NAMESPACES

        /// <summary>
        /// Elimina los xmlns del documento
        /// </summary>
        public static void eliminarNameSpace(XDocument xdocument)
        {
            ////
            //// Elimine todos los namespace del documento
            xdocument.Descendants().Attributes().Where(y => y.IsNamespaceDeclaration).Remove();
            foreach (var elem in xdocument.Descendants())
                elem.Name = elem.Name.LocalName;

        }

        /// <summary>
        /// Asigna un determinado ns al documento completo
        /// </summary>
        public static void asignarNameSpace(XNamespace xmlns, XDocument xdocument)
        {
            foreach (var elem in xdocument.Descendants())
            {
                if (elem.Name.Namespace == string.Empty)
                {
                    elem.Name = xmlns + elem.Name.LocalName;
                }
            }
        }


        #endregion

        ////
        //// Definicion de constantes de las funciones
        const string SII_ESTADO = "RESPUESTA/RESP_HDR/ESTADO";
        const string SII_GLOSA = "RESPUESTA/RESP_HDR/GLOSA";
        const string SII_SEMILLA = "RESPUESTA/RESP_BODY/SEMILLA";
        const string SII_TOKEN = "RESPUESTA/RESP_BODY/TOKEN";


        /// <summary>
        /// Recupera la respuesta del seed ( semilla del SII )
        /// para su procesamiento.
        /// </summary>
        public static string leerRespuestaSeed(string SIIRespuesta)
        {

            ////
            //// Inicie el valor de resultado.
            string resultado = string.Empty;

            try
            {

                ////
                //// Limpie el documento de los espacios de nombres
                SIIRespuesta = SIIRespuesta.Replace("xmlns:SII=\"http://www.sii.cl/XMLSchema\"", string.Empty);
                SIIRespuesta = SIIRespuesta.Replace("SII:", string.Empty);

                ////
                //// Abra el documento del SII
                XDocument xdocument = XDocument.Parse(SIIRespuesta);

                ////
                //// Recupere el estado de la solicitud
                //// y el valor de resultado
                XElement xEstado = xdocument.XPathSelectElement(SII_ESTADO);
                XElement xSemilla = xdocument.XPathSelectElement(SII_SEMILLA);
                switch (xEstado.Value)
                {

                    case "00":
                        resultado = xSemilla.Value;
                        break;
                    default:


                        break;
                }


            }
            catch
            {


            }

            ////
            //// Regrese el valor de retorno de la funcion
            return resultado;


        }

        /// <summary>
        /// Lee la respuesta del SII cuando se solicita token
        /// </summary>
        public static Respuesta leerRespuestaToken(string SIIRespuesta)
        {

            ////
            //// Inicie el valor de resultado.
            Respuesta r = new Respuesta();

            try
            {

                ////
                //// Limpie el documento de los espacios de nombres
                SIIRespuesta = SIIRespuesta.Replace("xmlns:SII=\"http://www.sii.cl/XMLSchema\"", string.Empty);
                SIIRespuesta = SIIRespuesta.Replace("SII:", string.Empty);

                ////
                //// Abra el documento del SII
                XDocument xdocument = XDocument.Parse(SIIRespuesta);

                ////
                //// Recupere el estado de la solicitud
                //// y el valor de resultado
                XElement xEstado = xdocument.XPathSelectElement(SII_ESTADO);
                XElement xToken = xdocument.XPathSelectElement(SII_TOKEN);
                switch (xEstado.Value)
                {

                    case "00":
                        r.correcto = true;
                        r.mensaje = "Se recupero correctamente el Token del sii";
                        r.detalle = "Se recupero correctamente el Token del sii";
                        r.Resultado = xToken.Value;
                        break;



                    default:
                        ////
                        //// Cualquier otro codigo corresponde a un error
                        r.correcto = false;
                        r.mensaje = string.Format("No se recupero el Token del sii {0}", xEstado);
                        r.detalle = xdocument.XPathSelectElement(SII_GLOSA).Value;
                        r.Resultado = null;
                        break;
                }


            }
            catch (Exception ex)
            {
                r.correcto = false;
                r.mensaje = "Error al intentar recuperar Token del SII";
                r.detalle = ex.Message;
                r.Resultado = null;

            }

            ////
            //// Regrese el valor de retorno de la funcion
            return r;

        }

        /// <summary>
        /// Recupera un determinado certificado para poder firmar un documento
        /// </summary>
        /// <param name="CN">Nombre del certificado que se busca</param>
        /// <returns>X509Certificate2</returns>
        public static X509Certificate2 obtenerCertificado(string CN)
        {

            ////
            //// Respuesta
            X509Certificate2 certificado = null;

            ////
            //// Certificado que se esta buscando
            if (string.IsNullOrEmpty(CN) || CN.Length == 0)
                return certificado;

            ////
            //// Inicie la busqueda del certificado
            try
            {

                ////
                //// Abra el repositorio de certificados para buscar el indicado
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection Certificados1 = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection Certificados2 = Certificados1.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                X509Certificate2Collection Certificados3 = Certificados2.Find(X509FindType.FindBySubjectName, CN, false);

                ////
                //// Si hay certificado disponible envíe el primero
                if (Certificados3 != null && Certificados3.Count != 0)
                    certificado = Certificados3[0];

                ////
                //// Cierre el almacen de sertificados
                store.Close();


            }
            catch (Exception)
            {
                certificado = null;
            }


            ////
            //// Regrese el valor de retorno 
            return certificado;

        }

        /// <summary>
        /// Prepara el documento IECV para poder firmarlo
        /// </summary>
        public static Respuesta prepararDocumentoIECV(string uri)
        {
            ////
            //// Inicie el objeto respuesta
            Respuesta r = new Respuesta();

            ////
            //// begin
            try
            {

                ////
                //// Defina la declaracion del documento
                string referencia = string.Empty;

                ////
                //// Recupere el documento xml para su normalizacion
                XDocument xdocument = XDocument.Load(uri, LoadOptions.PreserveWhitespace);

                ////
                //// elimine los xmlns del documento
                eliminarNameSpace(xdocument);


                ////
                //// Elimine todos los attributos del nodo padre,
                //// Esto eliminara los namespace de los esquemas.
                //// solo deje la version del documento.
                xdocument.Root.RemoveAttributes();
                xdocument.Root.SetAttributeValue("version", "1.0");

                ////
                //// Si existe el nodo Signature eliminelo para destartar la firma anterior
                string sTmstFirma = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                XElement TmstFirma = xdocument.XPathSelectElement("LibroCompraVenta/EnvioLibro/TmstFirma");
                if (TmstFirma != null)
                    TmstFirma.Value = sTmstFirma;
                else
                {
                    TmstFirma = new XElement("TmstFirma", sTmstFirma);
                    xdocument.XPathSelectElement("LibroCompraVenta/EnvioLibro)").Add(TmstFirma);
                }


                XElement Signature = xdocument.XPathSelectElement("LibroCompraVenta/Signature");
                if (Signature != null)
                    Signature.Remove();

                ////
                //// Recupere el ID del documento
                XElement ID = xdocument.XPathSelectElement("LibroCompraVenta/EnvioLibro");
                if (ID != null)
                {
                    XAttribute att = ID.Attribute("ID");
                    if (att != null)
                        referencia = "#" + att.Value;

                }


                ////
                //// Asigne los xmlns del documento
                XNamespace xmlns = "http://www.sii.cl/SiiDte";
                asignarNameSpace(xmlns, xdocument);

                ////
                //// Asigne el xmlns:xsi al documento
                XNamespace xsi = XNamespace.Get(@"http://www.w3.org/2001/XMLSchema-instance");
                xdocument.Root.Add(new XAttribute(XNamespace.Xmlns + "xsi", xsi));

                ////
                //// Asigne el xmlns:xsi al documento
                XNamespace schemaLocation = XNamespace.Get(@"http://www.sii.cl/SiiDte LibroCV_v10.xsd");
                xdocument.Root.Add(new XAttribute(xsi + "schemaLocation", schemaLocation));

                ////
                //// Guarde el documento en disco
                xdocument.Save(uri);

                ////
                //// Regrese el resultado
                r.correcto = true;
                r.mensaje = "Documento fue preparado con existo";
                r.detalle = referencia;
                r.Resultado = null;

            }
            catch (Exception ex)
            {
                r.correcto = false;
                r.mensaje = "Documento no pudo ser preparado para firma.";
                r.detalle = ex.Message;
                r.Resultado = null;
            }

            ////
            //// Regrese el valor de retorno
            return r;

        }

        /// <summary>
        /// Recupera el formato string para ser enviado al SII
        /// </summary>
        public static Respuesta obtenerCadenaEnvioLibros(string rutEmisor, string rutEmpresa, string nombreArchivo, string uri)
        {

            ////
            //// Construya la respuesta del proceso
            Respuesta respuesta = new Respuesta();


            ////
            //// Cree los parametros necesarios para la secuencia.
            rutEmisor = rutEmisor.Replace("-", string.Empty);
            rutEmpresa = rutEmpresa.Replace("-", string.Empty);
            string pRutEmisor = rutEmisor.Substring(0, (rutEmisor.Length - 1));
            string pDigEmisor = rutEmisor.Substring(rutEmisor.Length - 1);
            string pRutEmpresa = rutEmpresa.Substring(0, (rutEmpresa.Length - 1));
            string pDigEmpresa = rutEmpresa.Substring(rutEmpresa.Length - 1);

            ////
            //// Escriba la secuencia a enviar al sii
            StringBuilder secuencia = new StringBuilder();
            try
            {

                ////
                //// Cree el cuerpo del request
                secuencia.Append("--7d23e2a11301c4\r\n");
                secuencia.Append("Content-Disposition: form-data; name=\"emailNotif\"\r\n");
                secuencia.Append("\r\n");
                secuencia.Append("abaddon.1974@gmail.com\r\n");
                secuencia.Append("--7d23e2a11301c4\r\n");
                secuencia.Append("Content-Disposition: form-data; name=\"rutSender\"\r\n");
                secuencia.Append("\r\n");
                secuencia.Append(pRutEmisor + "\r\n");
                secuencia.Append("--7d23e2a11301c4\r\n");
                secuencia.Append("Content-Disposition: form-data; name=\"dvSender\"\r\n");
                secuencia.Append("\r\n");
                secuencia.Append(pDigEmisor + "\r\n");
                secuencia.Append("--7d23e2a11301c4\r\n");
                secuencia.Append("Content-Disposition: form-data; name=\"rutCompany\"\r\n");
                secuencia.Append("\r\n");
                secuencia.Append(pRutEmpresa + "\r\n");
                secuencia.Append("--7d23e2a11301c4\r\n");
                secuencia.Append("Content-Disposition: form-data; name=\"dvCompany\"\r\n");
                secuencia.Append("\r\n");
                secuencia.Append(pDigEmpresa + "\r\n");
                secuencia.Append("--7d23e2a11301c4\r\n");
                secuencia.Append("Content-Disposition: form-data; name=\"archivo\"; filename=\"" + nombreArchivo + "\"\r\n");
                secuencia.Append("Content-Type: text/xml\r\n");
                secuencia.Append("\r\n");


                ////
                //// Asigne el envio en formato xml
                Respuesta resul = FuncionesComunes.obtenerFormatoEnvioLibro(uri);
                if (resul.correcto)
                    secuencia.Append(((StringBuilder)resul.Resultado).ToString());

                ////
                //// Salto de carro 
                secuencia.Append("\r\n");

                ////
                //// Cierre de la secuencia
                secuencia.Append("--7d23e2a11301c4--\r\n");


                ////
                //// Completa la respuesta
                respuesta.correcto = true;
                respuesta.Resultado = secuencia;

            }
            catch (Exception ex)
            {
                respuesta.correcto = false;
                respuesta.mensaje = "No fue posible crear CadenaEnvioLibros";
                respuesta.detalle = ex.Message;
                respuesta.Resultado = null;
            }


            ////
            //// Regrese el valor de retorno
            return respuesta;

        }

        /// <summary>
        /// Lee la respuesta del sii
        /// </summary>
        public static Respuesta leerRespuestaEnvioLibro(string respuestaSII)
        {
            ////
            //// Inicie la respuesta 
            string mensaje = string.Empty;
            Respuesta respuesta = new Respuesta();

            ////
            //// interprete el resultado regresado por el SII
            XDocument xdoc = XDocument.Parse(respuestaSII);

            ////
            //// Recupere los nodos significativos
            XElement status = xdoc.XPathSelectElement("RECEPCIONDTE/STATUS");
            XElement trackid = xdoc.XPathSelectElement("RECEPCIONDTE/TRACKID");
            if (status != null)
            {
                switch (status.Value)
                {
                    case "0":
                        respuesta.correcto = true;
                        respuesta.mensaje = "Upload Realizado con existo.";
                        respuesta.Resultado = trackid.Value;
                        break;
                    case "1":
                        respuesta.correcto = false;
                        respuesta.mensaje = "El Sender no tiene permiso para enviar.\r\n";
                        respuesta.Resultado = xdoc.ToString();
                        break;
                    case "2":
                        respuesta.correcto = false;
                        respuesta.mensaje = "Error en tamaño del archivo (muy grande o muy chico).\r\n";
                        respuesta.Resultado = xdoc.ToString();
                        break;
                    case "3":
                        respuesta.correcto = false;
                        respuesta.mensaje = "Archivo cortado (tamaño <> al parámetro size).\r\n";
                        respuesta.Resultado = xdoc.ToString();
                        break;
                    case "4":
                        respuesta.correcto = false;
                        respuesta.mensaje = "No definido.\r\n";
                        respuesta.Resultado = xdoc.ToString();
                        break;
                    case "5":
                        respuesta.correcto = false;
                        respuesta.mensaje = "No está autenticado.\r\n";
                        respuesta.Resultado = xdoc.ToString();
                        break;
                    case "6":
                        respuesta.correcto = false;
                        respuesta.mensaje = "Empresa no autorizada a enviar archivos.\r\n";
                        respuesta.Resultado = xdoc.ToString();
                        break;
                    case "7":
                        respuesta.correcto = false;
                        respuesta.mensaje = "Esquema Invalido.\r\n";
                        respuesta.Resultado = xdoc.ToString();
                        break;
                    case "8":
                        respuesta.correcto = false;
                        respuesta.mensaje = "Firma del Documento.\r\n";
                        respuesta.Resultado = xdoc.ToString();
                        break;
                    case "9":
                        respuesta.correcto = false;
                        respuesta.mensaje = "Sistema Bloqueado.\r\n";
                        respuesta.Resultado = xdoc.ToString();
                        break;
                    default:
                        respuesta.correcto = false;
                        respuesta.mensaje = "Error Interno.\r\n";
                        respuesta.Resultado = xdoc.ToString();
                        break;
                }


            }
            else
            {
                respuesta.correcto = false;
                respuesta.mensaje = "No se encontró el estado en el documento xml de respuesta del sii.";
                respuesta.Resultado = xdoc.ToString();
            }


            ////
            //// Regrese el valor de retorno.
            return respuesta;

        }

        /// <summary>
        /// Regresa el documento xml con formato de envio al sii
        /// </summary>
        /// <returns></returns>
        public static Respuesta obtenerFormatoEnvioLibro(string uri)
        {
            ////
            //// Rescate el libro señalado por el usuario.
            Respuesta r = new Respuesta();
            try
            {

                ////
                //// Lea el libro
                XDocument xdocument = XDocument.Load(uri, LoadOptions.PreserveWhitespace);


                StringBuilder resultado = new StringBuilder();
                resultado.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\r");
                resultado.Append(xdocument.ToString(SaveOptions.DisableFormatting));
                resultado.Append("\r\n");

                ////
                //// Asigne el resultado.
                r.correcto = true;
                r.Resultado = resultado;


            }
            catch (Exception ex)
            {
                r.correcto = false;
                r.mensaje = "No fue posible crear el sobre de envio";
                r.Resultado = null;

            }

            ////
            //// Regrese el valor de retorno
            return r;

        }

        /// <summary>
        /// Lee la respuesta del sii del estado del libro
        /// </summary>
        /// <param name="SIIRespuesta"></param>
        /// <returns></returns>
        public static Respuesta leerRespuestaEstado(string SIIRespuesta)
        {

            ////
            //// Inicie el valor de resultado.
            Respuesta r = new Respuesta();

            try
            {

                ////
                //// Limpie el documento de los espacios de nombres
                SIIRespuesta = SIIRespuesta.Replace("xmlns:SII=\"http://www.sii.cl/XMLSchema\"", string.Empty);
                SIIRespuesta = SIIRespuesta.Replace("SII:", string.Empty);

                ////
                //// Abra el documento del SII
                XDocument xdocument = XDocument.Parse(SIIRespuesta);

                ////
                //// Recupere el estado de la solicitud
                //// y el valor de resultado
                XElement xEstado = xdocument.XPathSelectElement(SII_ESTADO);
                XElement xToken = xdocument.XPathSelectElement(SII_TOKEN);
                switch (xEstado.Value)
                {

                    case "EPR":
                        r.correcto = true;
                        r.mensaje = xdocument.XPathSelectElement("RESPUESTA/RESP_HDR/GLOSA").Value;
                        r.detalle = xdocument.XPathSelectElement("RESPUESTA/RESP_HDR/NUM_ATENCION").Value;
                        r.Resultado = SIIRespuesta;
                        break;
                    case "LSO":
                        r.correcto = true;
                        r.mensaje = xdocument.XPathSelectElement("RESPUESTA/RESP_HDR/GLOSA").Value;
                        r.detalle = xdocument.XPathSelectElement("RESPUESTA/RESP_HDR/NUM_ATENCION").Value;
                        r.Resultado = SIIRespuesta;
                        break;
                    case "-11":
                        r.correcto = false;
                        r.mensaje = "ERROR: De proceso";
                        r.detalle = xdocument.XPathSelectElement("RESPUESTA/RESP_HDR/NUM_ATENCION").Value;
                        r.Resultado = SIIRespuesta;
                        break;
                    default:
                        r.correcto = false;
                        r.mensaje = xdocument.XPathSelectElement("RESPUESTA/RESP_HDR/GLOSA").Value;
                        r.detalle = xdocument.XPathSelectElement("RESPUESTA/RESP_HDR/NUM_ATENCION").Value;
                        r.Resultado = SIIRespuesta;
                        break;

                }


            }
            catch (Exception ex)
            {
                r.correcto = false;
                r.mensaje = "Error al intentar recuperar estado de libro del SII";
                r.detalle = ex.Message;
                r.Resultado = null;

            }

            ////
            //// Regrese el valor de retorno de la funcion
            return r;
        }

        public static Boolean periodoPruebas()
        {

            DateTime limite = new DateTime(2013, 12, 31);
            if (DateTime.Now <= limite)
                return true;
            else
                return false;


        }

        /// <summary>
        /// Firma la semilla para ser enviada al SII
        /// </summary>
        /// <param name="documento"></param>
        /// <param name="certificado"></param>
        /// <returns></returns>
        public static string firmarDocumentoSemilla(string documento, X509Certificate2 certificado)
        {

            ////
            //// Cree un nuevo documento xml y defina sus caracteristicas
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = false;
            doc.LoadXml(documento);

            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(doc);

            // Add the key to the SignedXml document.  'key'
            signedXml.SigningKey = certificado.PrivateKey;

            // Get the signature object from the SignedXml object.
            Signature XMLSignature = signedXml.Signature;

            // Create a reference to be signed.  Pass "" 
            // to specify that all of the current XML
            // document should be signed.
            Reference reference = new Reference("");

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the Reference object to the Signature object.
            XMLSignature.SignedInfo.AddReference(reference);

            // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new RSAKeyValue((RSA)certificado.PrivateKey));


            ////
            //// Agregar información del certificado x509
            //// X509Certificate MSCert = X509Certificate.CreateFromCertFile(Certificate);
            keyInfo.AddClause(new KeyInfoX509Data(certificado));


            // Add the KeyInfo object to the Reference object.
            XMLSignature.KeyInfo = keyInfo;

            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Append the element to the XML document.
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));


            if (doc.FirstChild is XmlDeclaration)
            {
                doc.RemoveChild(doc.FirstChild);
            }

            // Save the signed XML document to a file specified
            // using the passed string.
            //XmlTextWriter xmltw = new XmlTextWriter(@"d:\ResultadoFirma.xml", new UTF8Encoding(false));
            //doc.WriteTo(xmltw);
            //xmltw.Close();
            return doc.InnerXml;

        }

        /// <summary>
        /// Detecta el ambiente a donde procesar
        /// SII - Certificacion
        /// SII - Produccion
        /// </summary>
        public static SIIAmbiente detectarAmbiente(string uriXml)
        {

            ////
            //// Inicie la respuesta 
            SIIAmbiente amb = SIIAmbiente.Certificacion;


            ////
            //// Detecte el ambiente de procesamiento 
            try
            {

                ////
                //// Cargue el documento xml
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load(uriXml);

                ////
                //// Recupere el indicador del ambiente 'NroResol'
                //// este indicador es para envio de Dtes y Libros
                XmlNodeList nodes = xmlDoc.GetElementsByTagName("NroResol", xmlDoc.DocumentElement.NamespaceURI);

                ////
                //// Compruebe que hay un valor valido
                if (nodes == null || nodes.Count == 0)
                    throw new Exception("No se encontro el nodo indicador del ambiente de procesamiento.");

                ////
                //// Determine el ambiente utilizando el indicador.
                string sIndicador = nodes[0].InnerText;

                ////
                //// Recupere el valor del indicador.
                int nIndicador = 0;
                if ( !int.TryParse(sIndicador,out nIndicador) )
                    throw new Exception(  string.Format("el valor del indicador no es valido '{0}'.",sIndicador) );

                ////
                //// Determine el ambiente utilizando el indicador.
                if (nIndicador > 0)
                    amb = SIIAmbiente.Produccion;


            }
            catch (Exception)
            {
                amb = SIIAmbiente.Certificacion;
            }


            ////
            //// Regrese el valor de retorno
            return amb;
        
        
        }







    }
}
