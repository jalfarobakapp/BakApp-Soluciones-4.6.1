using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;


namespace HEFESTO.CONSULTA.ESTADO.DTE.AUTENTICACION
{
    public class FuncionesComunes
    {

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
                //// Recupere el valor de retorno
                XmlDocument resp = new XmlDocument();
                resp.PreserveWhitespace = true;
                resp.LoadXml(SIIRespuesta);


                ////
                //// Cree el namespace manager del documento
                XmlNamespaceManager ns = new XmlNamespaceManager(resp.NameTable);
                ns.AddNamespace("sii", resp.DocumentElement.NamespaceURI);


                ////
                //// Recupere los valores
                XmlElement xmlEstado = (XmlElement)resp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/ESTADO", ns);
                if (xmlEstado.InnerText == "00")
                { 
                    ////
                    //// Recupere la semilla
                    resultado = resp.SelectSingleNode("sii:RESPUESTA/sii:RESP_BODY/SEMILLA",ns).InnerText;
                
                }
                
            }
            catch
            {
                ////
                //// Indique un error
                resultado = string.Empty;
            }

            ////
            //// Regrese el valor de retorno de la funcion
            return resultado;


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
                        r.EsCorrecto = true;
                        r.Mensaje = "Se recupero correctamente el Token del sii";
                        r.Detalle = "Se recupero correctamente el Token del sii";
                        r.Resultado = xToken.Value;
                        break;



                    default:
                        ////
                        //// Cualquier otro codigo corresponde a un error
                        r.EsCorrecto = false;
                        r.Mensaje = string.Format("No se recupero el Token del sii {0}", xEstado);
                        r.Detalle = xdocument.XPathSelectElement(SII_GLOSA).Value;
                        r.Resultado = null;
                        break;
                }


            }
            catch (Exception ex)
            {
                r.EsCorrecto = false;
                r.Mensaje = "Error al intentar recuperar Token del SII";
                r.Detalle = ex.Message;
                r.Resultado = null;

            }

            ////
            //// Regrese el valor de retorno de la funcion
            return r;

        }

        /// <summary>
        /// Lee la respuesta de la consulta del estado del documento DTE
        /// </summary>
        /// <param name="SIIRespuesta"></param>
        /// <returns></returns>
        public static RespuestaQuery leerRespuestaEstadoDte(string SIIRespuesta)
        {

            ////
            //// Cree la respuesta
            RespuestaQuery resp = new RespuestaQuery();

            ////
            //// Lea la respuesta
            try
            {
                ////
                //// Cargue el Documento xml
                XmlDocument xmlResp = new XmlDocument();
                xmlResp.PreserveWhitespace = true;
                xmlResp.LoadXml(SIIRespuesta);

                ////
                //// Cree el name space manager
                XmlNamespaceManager ns = new XmlNamespaceManager(xmlResp.NameTable);
                ns.AddNamespace("sii", xmlResp.DocumentElement.NamespaceURI);

                ////
                //// Inicie el rescate de los datos
                XmlElement xmlEstado = (XmlElement)xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/ESTADO",ns);
                if (xmlEstado != null)
                { 
                
                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "DOK")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "DOK";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ESTADO",ns).InnerText;
                        resp.GlosaError = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ERR", ns).InnerText; 
                    }

                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "DNK")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "DNK";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ESTADO", ns).InnerText;
                        resp.GlosaError = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ERR", ns).InnerText;
                    }

                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "FAU")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "FAU";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ESTADO", ns).InnerText;
                        resp.GlosaError = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ERR", ns).InnerText;
                    }

                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "FNA")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "FNA";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ESTADO", ns).InnerText;
                        resp.GlosaError = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ERR", ns).InnerText;
                    }

                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "FAN")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "FAN";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ESTADO", ns).InnerText;
                        resp.GlosaError = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ERR", ns).InnerText;
                    }

                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "EMP")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "EMP";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ESTADO", ns).InnerText;
                        resp.GlosaError = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ERR", ns).InnerText;
                    }

                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "TMD")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "TMD";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ESTADO", ns).InnerText;
                        resp.GlosaError = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ERR", ns).InnerText;
                    }

                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "TMC")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "TMC";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ESTADO", ns).InnerText;
                        resp.GlosaError = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ERR", ns).InnerText;
                    }

                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "MMD")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "MMD";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ESTADO", ns).InnerText;
                        resp.GlosaError = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ERR", ns).InnerText;
                    }

                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "MMC")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "MMC";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ESTADO", ns).InnerText;
                        resp.GlosaError = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ERR", ns).InnerText;
                    }


                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "AND")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "AND";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ESTADO", ns).InnerText;
                        resp.GlosaError = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ERR", ns).InnerText;
                    }


                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "ANC")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "ANC";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ESTADO", ns).InnerText;
                        resp.GlosaError = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA_ERR", ns).InnerText;
                    }

                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "002")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "002";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA", ns).InnerText;
                        
                    }

                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "003")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "002";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA", ns).InnerText;
                    }

                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "001")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "001";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA", ns).InnerText;
                    }

                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "-1")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "-1";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA", ns).InnerText;
                    }

                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "-2")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "-2";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA", ns).InnerText;
                    }

                    ////
                    //// Cual es el estado
                    if (xmlEstado.InnerText == "-3")
                    {
                        resp.EsCorrecto = true;
                        resp.Estado = "-3";
                        resp.GlosaEstado = xmlResp.SelectSingleNode("sii:RESPUESTA/sii:RESP_HDR/GLOSA", ns).InnerText;
                    }

                }
                
            }
            catch (Exception e)
            {

                resp.EsCorrecto = false;
                resp.Mensaje = "No es posible consultar el estado del DTE.";
            }


            ////
            //// Parsee la glosa error
            string GlosaError = resp.GlosaError.Replace("\t", string.Empty);
            GlosaError = GlosaError.Replace("\r\n", " ");
            resp.GlosaError = GlosaError;


            ////
            //// Regrese el valor de retorno
            return resp;
        
        }

    }
}
