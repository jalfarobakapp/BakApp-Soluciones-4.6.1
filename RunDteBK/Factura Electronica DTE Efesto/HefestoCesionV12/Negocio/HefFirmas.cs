using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace HefestoCesionV12.Negocio
{
    /// <summary>
    /// Metodos relacionados con las firmas
    /// </summary>
    internal class HefFirmas
    {

        /// <summary>
        /// Firma todo el documento AEC
        /// </summary>
        /// <returns></returns>
        internal static HefRespuesta FirmarDocumentoAEC(X509Certificate2 _certificado, string sDocument )
        {

            ////
            //// Inicie la respuesta
            HefRespuesta resp = new HefRespuesta();
            resp.EsCorrecto = false;
            resp.Mensaje = "FirmarDocumentoAEC";

            ////
            //// Inicie
            try
            {
                ////
                //// Agregar los namespaces del documento antes de ser envisdo al SII
                sDocument = Regex.Replace(
                    sDocument,
                        "<AEC version=\"1.0\" xmlns=\"http://www.sii.cl/SiiDte\">",
                            "<AEC version=\"1.0\" xmlns=\"http://www.sii.cl/SiiDte\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.sii.cl/SiiDte AEC_v10.xsd\">",
                                RegexOptions.Singleline);


                ////
                //// Normalice el documento con los namespace que correspondan
                sDocument = Regex.Replace(sDocument, "<DTECedido version=\"1.0\">", "<DTECedido version=\"1.0\" xmlns=\"http://www.sii.cl/SiiDte\">", RegexOptions.Singleline);
                sDocument = Regex.Replace(sDocument, "<Cesion version=\"1.0\">", "<Cesion version=\"1.0\" xmlns=\"http://www.sii.cl/SiiDte\">", RegexOptions.Singleline);

                ////
                //// Cargue el documento xml
                XmlDocument xDoc = new XmlDocument();
                xDoc.PreserveWhitespace = true;
                xDoc.LoadXml(sDocument);

                ////
                //// Recupere los cuerpos del documento
                string content = xDoc.OuterXml;

                #region Procesar DTECedido

                ////
                //// Recupere el contenido de DTECedido
                string _DTECedido = Regex.Match(content, "<DTECedido.*?<\\/DTECedido>", RegexOptions.Singleline).Value;

                ////
                //// Recupere el ID del nodo
                string Reference = "#" + Regex.Match(_DTECedido, "ID=\"(.*?)\"", RegexOptions.Singleline).Groups[1].Value;

                ////
                //// Cree el objeto xml
                XmlDocument xDTECedido = new XmlDocument();
                xDTECedido.PreserveWhitespace = true;
                xDTECedido.LoadXml(_DTECedido);

                ////
                //// Firme este fragmento
                firmarDocumentoXml(ref xDTECedido, _certificado, Reference);

                ////
                //// Inserte la firma en el lugar que le corresponde
                //// _DTECedido = Regex.Replace(_DTECedido, "</DocumentoDTECedido>", "</DocumentoDTECedido>" + firma, RegexOptions.Singleline);

                ////
                //// Actualice el documento original
                content = Regex.Replace(content, "<DTECedido.*?<\\/DTECedido>", xDTECedido.OuterXml, RegexOptions.Singleline);


                #endregion

                #region Procesar Cesion

                ////
                //// Recupere el contenido de DTECedido
                string _Cesion = Regex.Match(content, "<Cesion\\s.*?<\\/Cesion>", RegexOptions.Singleline).Value;

                ////
                //// Recupere el ID del nodo
                Reference = "#" + Regex.Match(_Cesion, "ID=\"(.*?)\"", RegexOptions.Singleline).Groups[1].Value;

                ////
                //// Cree el objeto xml
                XmlDocument xCesion = new XmlDocument();
                xCesion.PreserveWhitespace = true;
                xCesion.LoadXml(_Cesion);

                ////
                //// Firme este fragmento
                firmarDocumentoXml(ref xCesion, _certificado, Reference);

                ////
                //// Inserte la firma en el lugar que le corresponde
                //// _Cesion = Regex.Replace(_Cesion, "</DocumentoCesion>", "</DocumentoCesion>"+ firma, RegexOptions.Singleline);

                ////
                //// Actualice el documento original
                content = Regex.Replace(content, "<Cesion\\s.*?<\\/Cesion>", xCesion.OuterXml, RegexOptions.Singleline);


                #endregion


                #region Procesar AEC

                ////
                //// Recupere el ID del nodo
                Reference = "#" + Regex.Match(content, "ID=\"(.*?)\"", RegexOptions.Singleline).Groups[1].Value;

                ////
                //// Cree el objeto xml
                XmlDocument xAec = new XmlDocument();
                xAec.PreserveWhitespace = true;
                xAec.LoadXml(content);

                ////
                //// Firme este fragmento
                firmarDocumentoXml(ref xAec, _certificado, Reference);

                ////
                //// Inserte la firma en el lugar que le corresponde
                content = xAec.OuterXml;

                #endregion


                ////
                //// Construír respuesta
                resp.EsCorrecto = true;
                resp.Detalle = "Documento firmado OK";
                resp.Resultado = content;

            }
            catch (Exception det)
            {
                ////
                //// Notifique el error
                resp.EsCorrecto = false;
                resp.Detalle = det.Message;
                resp.Resultado = null;
                
            }

            ////
            //// Regrese el valor de retorno
            return resp;
        
        }

        /// <summary>
        /// Firma del documento
        /// </summary>
        /// <param name="xmldocument"></param>
        /// <param name="certificado"></param>
        /// <param name="referenciaUri"></param>
        internal static void firmarDocumentoXml(ref XmlDocument xmldocument, X509Certificate2 certificado, string referenciaUri)
        {
            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(xmldocument);

            // Add the key to the SignedXml document.  'key'
            signedXml.SigningKey = certificado.PrivateKey;

            // Get the signature object from the SignedXml object.
            Signature XMLSignature = signedXml.Signature;

            // Create a reference to be signed.  Pass "" 
            // to specify that all of the current XML
            // document should be signed.
            Reference reference = new Reference();
            reference.Uri = referenciaUri;

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
            xmldocument.DocumentElement.AppendChild(xmldocument.ImportNode(xmlDigitalSignature, true));
           
        }


        



    }

}
