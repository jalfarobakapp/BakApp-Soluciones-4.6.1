using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;

namespace HEFESTO.FIRMA.DOC.FORM.Core
{
    public class Signed
    {
        /// <summary>
        /// Permite timbrar y firmar el documento
        /// </summary>
        /// <param name="CN">Nombre canonico certificado</param>
        /// <param name="uriCaf">full path archivo Caf</param>
        /// <param name="uriDte">full path archivo Dte</param>
        /// <param name="uriSetDte">full path archivo envioDte</param>
        public static void FirmarDocumento(string CN, string uriCaf, string uriDte, string uriSetDte)
        {


            #region IDENTIFICACION DE LOS DOCUMENTOS A UTILIZAR


            ////
            //// Variables guardan nombres de referencias de archivos
            string strReferenciaDte = string.Empty;
            string strReferenciaSetDte = "SetDoc";

            ////
            //// Elementos internos de la clase
            string uriSetDteResultado = "Documentos\\SETDTEResultado.XML";
            string uriDteResultado = "Documentos\\DTEResultado.XML";

            ////
            //// Elemetos de schemas
            string uriSchemaDteSf = "Schemas\\DTE_v10_Sf.xsd";
            string uriSchemaDte = "Schemas\\DTE_v10.xsd";
            string uriSchemaSetDte = "Schemas\\EnvioDTE_v10.xsd";

            ////
            //// Lista de erorres del schema
            List<string> errores = FuncionesComunes.ValidarSchema(uriDte, uriSchemaDteSf);



            #endregion

            #region VALIDAR DOCUMENTO XML DTE ORIGINAL CONTRA SCHEMA SIN FIRMA, ESTO ES ANTES DE INICIAR EL PROCESAMIENTO


            ////
            //// Validar el documento xml (DTE) generado por el ciente para saber si tiene 
            //// errores de forma. El documento xml (dte) debe tener un espacio de nombres 
            //// asociado, de lo contrario no hay validación correcta.

            if (errores.Count > 0)
            {
                Console.WriteLine("Error en validacion de schema del SII sobre documento xml (DTE)");
                errores.ForEach(delegate(string e)
                {
                    Console.WriteLine("{0}", e);
                });

                throw new Exception("Antes de continuar debe solucionar los problemas del documento xml.");
            }


            #endregion

            #region PREPARAR DOCUMENTO XML PARA SU FIRMA


            ////
            //// Limpie el documento xml de elementos no necesarios
            //// y aplicar formato limpio.
            Console.WriteLine("Preparando documento xml (DTE) para la firma.");
            try
            {

                ////
                //// Cargue el documento DTE a firmar
                //// Cargue el documento CAF que contiene los folios
                XDocument DTE = XDocument.Load(uriDte, LoadOptions.PreserveWhitespace);
                XDocument CAF = XDocument.Load(uriCaf, LoadOptions.PreserveWhitespace);

                #region RECUPERAR EL CERTIFICADO CON EL CUAL SE FIRMA Y ENVIA EL DOCUMENTO

                ////
                //// Seleccione el certificado desde el repositorio
                X509Certificate2 certificado = FuncionesComunes.RecuperarCertificado(CN);
                if (certificado == null)
                    throw new Exception("No se encuentra el certificado para poder firmar ls documentos");


                #endregion

                #region NORMALIZAR EL DOCUMENTO XML (DTE)


                ///////////////////////////////////////////////////////////////
                //// Quite los atributos del primer elemento del DTE, incluyend
                //// o los name spaces del documento.
                ///////////////////////////////////////////////////////////////
                DTE.Root.Attributes().Where(y => y.IsNamespaceDeclaration).Remove();
                DTE.Root.Attributes().Remove();
                foreach (var elem in DTE.Descendants())
                    elem.Name = elem.Name.LocalName;

                //// Agregue la version al nodo DTE pues este fue eliminado en 
                //// la paso anterior y debe ser agregado manualmente para resp
                //// etar el schema.
                DTE.Root.Add(new XAttribute("version", "1.0"));

                ///////////////////////////////////////////////////////////////
                //// Recupere los datos necesarios para normalizar el documento
                //// actual
                ///////////////////////////////////////////////////////////////
                string strTipoDTE = string.Empty;
                string strFolio = string.Empty;
                string strRutEmisor = string.Empty;
                string strRUTRecep = string.Empty;
                string strFchEmis = string.Empty;
                string strRznSocRecep = string.Empty;
                string strMntTotal = string.Empty;
                string strDscItem = string.Empty;

                ////
                //// Recupere el tipo DTE
                strTipoDTE = DTE.XPathSelectElement("DTE/Documento/Encabezado/IdDoc/TipoDTE").Value;

                ////
                //// Rescate el Folio  
                strFolio = DTE.XPathSelectElement("DTE/Documento/Encabezado/IdDoc/Folio").Value;

                ////
                //// Rescate la fecha de emision del documento
                strFchEmis = DTE.XPathSelectElement("DTE/Documento/Encabezado/IdDoc/FchEmis").Value;

                ////
                //// Rescate el rut del emisor del documento
                strRutEmisor = DTE.XPathSelectElement("DTE/Documento/Encabezado/Emisor/RUTEmisor").Value;

                ////
                //// Rescate el rut del receptor del documento
                strRUTRecep = DTE.XPathSelectElement("DTE/Documento/Encabezado/Receptor/RUTRecep").Value;

                ////
                //// Rescate la razon social del receptor
                strRznSocRecep = DTE.XPathSelectElement("DTE/Documento/Encabezado/Receptor/RznSocRecep").Value;

                ////
                //// Rescate el MntTotal
                strMntTotal = DTE.XPathSelectElement("DTE/Documento/Encabezado/Totales/MntTotal").Value;

                ////
                //// Rescate el DscItem del primer detalle
                //// Reccuerde que cuando son notas de debito o credito 
                //// El detalle puede venir vacio.
                strDscItem = string.Empty;
                XElement nodeNmbItem = DTE.XPathSelectElement("DTE/Documento/Detalle/NmbItem[1]");
                if (nodeNmbItem != null)
                    strDscItem = nodeNmbItem.Value;


                ///////////////////////////////////////////////////////////////
                //// En el caso que el documento dte actual no tiene el nodo
                //// TED agreguelo manualmente
                ///////////////////////////////////////////////////////////////
                XElement nodeTed = DTE.XPathSelectElement("DTE/Documento/TED");
                if (nodeTed == null)
                {
                    XElement newTed = new XElement("TED",
                        new XAttribute("version", "1.0"),
                        new XElement("DD",

                            new XElement("RE", ""),
                            new XElement("TD", ""),
                            new XElement("F", ""),
                            new XElement("FE", ""),
                            new XElement("RR", ""),
                            new XElement("RSR", ""),
                            new XElement("MNT", ""),
                            new XElement("IT1", ""),
                            new XElement("TSTED", "")
                            ),
                            new XElement("FRMT", "")

                        );

                    ////
                    //// Inserte el ted debajo de TmstFirma
                    XElement nodeTmstFirma = DTE.XPathSelectElement("DTE/Documento/TmstFirma");
                    if (nodeTmstFirma != null)
                        nodeTmstFirma.AddBeforeSelf(newTed);
                    else
                        DTE.XPathSelectElement("DTE/Documento").Add(newTed);




                }



                ///////////////////////////////////////////////////////////////
                //// Si existe el nodo CAF eliminelo del documento
                //// Para agragar el nuevo nodo CAF extraído desde el archivo
                //// enviado por el SII
                ///////////////////////////////////////////////////////////////
                XElement node = DTE.XPathSelectElement("DTE/Documento/TED/DD/CAF");
                if (node != null)
                    node.Remove();

                ///////////////////////////////////////////////////////////////
                //// Reasignacion de data
                //// Asigna los datos del documento DTE al nodo TED para evitar
                //// que se genere algun error si este proceso se efectua manua
                //// lmente.
                ///////////////////////////////////////////////////////////////

                ////
                //// Construya la referencia del documento DTE y asigne
                //// al nodo Documento como Atributo ID
                strReferenciaDte = string.Format("R{0}F{1}T{2}", strRutEmisor.Replace("-", string.Empty), strFolio, strTipoDTE);
                DTE.XPathSelectElement("DTE/Documento").SetAttributeValue("ID", strReferenciaDte);

                ////
                //// Reasigne la fecha TSTED de nodo TED
                node = DTE.XPathSelectElement("DTE/Documento/TED/DD/TSTED");
                if (node != null)
                    node.Value = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

                ////
                //// Reasigne la fecha TmstFirma de nodo Documento
                node = DTE.XPathSelectElement("DTE/Documento/TmstFirma");
                if (node != null)
                    node.Value = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

                ////
                //// Retire la firma del nodo FRMT
                node = DTE.XPathSelectElement("DTE/Documento/TED/FRMT");
                if (node != null)
                {
                    node.Value = string.Empty;
                    node.SetAttributeValue("algoritmo", "SHA1withRSA");
                }

                ///////////////////////////////////////////////////////////////
                //// Reasignacion de data a elementos del TED
                //// RE, TD, F, FE, RR, RSR, MNT, IT1
                ///////////////////////////////////////////////////////////////
                node = DTE.XPathSelectElement("DTE/Documento/TED/DD/RE");
                if (node != null)
                    node.Value = strRutEmisor;
                node = DTE.XPathSelectElement("DTE/Documento/TED/DD/TD");
                if (node != null)
                    node.Value = strTipoDTE;
                node = DTE.XPathSelectElement("DTE/Documento/TED/DD/F");
                if (node != null)
                    node.Value = strFolio;
                node = DTE.XPathSelectElement("DTE/Documento/TED/DD/FE");
                if (node != null)
                    node.Value = strFchEmis;
                node = DTE.XPathSelectElement("DTE/Documento/TED/DD/RR");
                if (node != null)
                    node.Value = strRUTRecep;
                node = DTE.XPathSelectElement("DTE/Documento/TED/DD/RSR");
                if (node != null)
                    node.Value = strRznSocRecep;
                node = DTE.XPathSelectElement("DTE/Documento/TED/DD/MNT");
                if (node != null)
                    node.Value = strMntTotal;
                node = DTE.XPathSelectElement("DTE/Documento/TED/DD/IT1");
                if (node != null)
                {

                    if (strDscItem.Length > 40)
                    {
                        node.Value = strDscItem.Substring(0, 39);
                    }
                    else
                    {
                        node.Value = strDscItem;
                    }

                }


                #endregion

                #region QUITAR IDENTACION DEL DOCUMENTO ANTES DE GUARDARLO TEMPORALMENTE

                ////
                //// Quite la identacion del documento
                string[] strLineasDte = DTE.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i <= strLineasDte.Length - 1; i++)
                    strLineasDte[i] = strLineasDte[i].TrimStart();

                ////
                //// Recargue el documento xml sin identación
                //// utilizando el objeto xmlDocument
                string p = string.Join("\r\n", strLineasDte);
                DTE = XDocument.Parse(p, LoadOptions.PreserveWhitespace);
                DTE.Declaration = new XDeclaration("1.0", "ISO-8859-1", null);

                ////
                //// Guarde el documento
                DTE.Save(uriDteResultado);

                #endregion

                #region CALCULO DEL TIMBRE DEL DOCUMENTO DTE

                ///////////////////////////////////////////////////////////////
                //// Recupere la clave privada del SII, con la cual firma el ar
                //// chivo CAF
                ///////////////////////////////////////////////////////////////
                string pk = CAF.XPathSelectElement("AUTORIZACION/RSASK").Value;

                ///////////////////////////////////////////////////////////////
                //// Extraiga desde el archivo CAF el nodo CAF, sin realizar ni
                //// nguna modificacion sobre el. Luego intercambielo por el ex
                //// istente en El documento DTE, si no existe insertelo donde 
                //// corresponde.
                ///////////////////////////////////////////////////////////////
                XElement nodeCaf = CAF.XPathSelectElement("AUTORIZACION/CAF");
                XElement nodeCafDte = DTE.XPathSelectElement("DTE/Documento/TED/DD/CAF");
                if (nodeCafDte == null)
                {
                    DTE.XPathSelectElement("DTE/Documento/TED/DD/IT1").AddAfterSelf(nodeCaf);
                }
                else
                {
                    nodeCafDte.ReplaceWith(nodeCaf);
                }

                ////
                //// Guarde el documento
                DTE.Save(uriDteResultado);

                ///////////////////////////////////////////////////////////////
                //// Inicie el calculo del timbre del documento
                ///////////////////////////////////////////////////////////////
                DTE = null;

                ////
                //// Cargue el documento DTE preparado anteriormente
                XmlDocument xmlDTE = new XmlDocument();
                xmlDTE.PreserveWhitespace = true;
                xmlDTE.Load(uriDteResultado);


                ////
                //// Recupere el valor del nodo TED y preparelo para ser timbrado
                XmlElement DD = (XmlElement)xmlDTE.SelectSingleNode("DTE/Documento/TED/DD");
                if (DD == null)
                    throw new Exception("No se encuentra el nodo DD");

                string strDD = DD.OuterXml;
                strDD = strDD.Replace("\t", string.Empty);
                strDD = strDD.Replace("\r\n", string.Empty);
                strDD = strDD.Replace("\n", string.Empty);

                ////
                //// Calcule el hash de los datos a firmar DD
                //// transformando la cadena DD a arreglo de bytes, luego con
                //// el objeto 'SHA1CryptoServiceProvider' creamos el Hash del
                //// arreglo de bytes que representa los datos del DD
                Encoding encode = Encoding.GetEncoding("ISO-8859-1");
                byte[] bytesStrDD = encode.GetBytes(strDD);
                byte[] HashValue = new SHA1CryptoServiceProvider().ComputeHash(bytesStrDD);

                ////
                //// Cree el objeto Rsa para poder firmar el hashValue creado
                //// en el punto anterior. La clase FuncionesComunes.crearRsaDesdePEM()
                //// Transforma la llave rivada del CAF en formato PEM a el objeto
                //// Rsa necesario para la firma.
                RSACryptoServiceProvider rsa = FuncionesComunes.crearRsaDesdePEM(pk);

                ////
                //// Firme el HashValue ( arreglo de bytes representativo de DD )
                //// utilizando el formato de firma SHA1, lo cual regresará un nuevo 
                //// arreglo de bytes.
                byte[] bytesSing = rsa.SignHash(HashValue, "SHA1");

                ////
                //// Recupere la representación en base 64 de la firma, es decir de
                //// el arreglo de bytes 
                string strFRMTSHA1withRSA = Convert.ToBase64String(bytesSing);

                ////
                //// Inserte en el documento DTE el valor del timbre generado 
                //// por nuestra rutina de timbrado.
                XmlElement FRMTSHA1withRSA = (XmlElement)xmlDTE.SelectSingleNode("DTE/Documento/TED/FRMT");
                FRMTSHA1withRSA.InnerText = strFRMTSHA1withRSA;

                ////
                //// Guarde el documento DTE
                xmlDTE.Save(uriDteResultado);

                #endregion

                #region FIRMAR EL DOCUMENTO DTE

                ////
                //// Agregue el ns del SII, luego guarde el documento para que la asigna
                //// cion quede reflejada en el documento
                xmlDTE.DocumentElement.SetAttribute("xmlns", "http://www.sii.cl/SiiDte");
                xmlDTE.Save(uriDteResultado);

                ////
                //// Abra nuevamente el archivo, esto asigna el nuevo name space
                //// al documento xml (DTE)
                xmlDTE = new XmlDocument();
                xmlDTE.PreserveWhitespace = true;
                xmlDTE.Load(uriDteResultado);


                ////
                //// Firme el documento xml (DTE)
                strReferenciaDte = string.Format("#{0}", strReferenciaDte);

                FuncionesComunes.firmarDocumentoXml(ref xmlDTE, certificado, strReferenciaDte);

                ////
                //// Guarde el documento firmado
                xmlDTE.Save(uriDteResultado);


                #endregion

                #region VALIDAR DOCUMENTO XML DTE FIRMADO CONTRA EL SCHEMA DEL SII


                ////
                //// Validar el documento xml (DTE) generado por el ciente para saber si tiene 
                //// errores de forma. El documento xml (dte) debe tener un espacio de nombres 
                //// asociado, de lo contrario no hay validación correcta.
                errores.Clear();
                errores = FuncionesComunes.ValidarSchema(uriDteResultado, uriSchemaDte);
                if (errores.Count > 0)
                {
                    Console.WriteLine("Error en validacion de schema del SII sobre documento xml (DTE)");
                    errores.ForEach(delegate(string e)
                    {
                        Console.WriteLine("{0}", e);
                    });

                    throw new Exception("Antes de continuar debe solucionar los problemas del documento xml.");
                }

                #endregion

                #region INSERTA EL DOCUMENTO DTE EN EL SETDTE Y FIRMA EL SETDTE

                //// ////////////////////////////////////////////////////////////////////
                //// Prepare el Set dte para su firma
                //// 1.- Inserte el DTE firmado al SetDTE
                //// ////////////////////////////////////////////////////////////////////
                XmlDocument SETDTE = new XmlDocument();
                SETDTE.PreserveWhitespace = true;
                SETDTE.Load(uriSetDte);

                ////
                //// Calcule el nuevo tmst de la firma del SETDTE
                XmlElement TmstFirmaEnv = (XmlElement)SETDTE.SelectSingleNode("EnvioDTE/SetDTE/Caratula/TmstFirmaEnv");
                if (TmstFirmaEnv == null)
                    throw new Exception("No se encuentra el nodo Folio");
                TmstFirmaEnv.InnerText = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");


                ////
                //// Inserte en el documento DTE
                SETDTE.SelectSingleNode("EnvioDTE/SetDTE").AppendChild(SETDTE.ImportNode(xmlDTE.DocumentElement, true));
                SETDTE.Save(uriSetDteResultado);

                ////
                //// Antes de firmar el documento asigne el namespace y schemas necesarios
                SETDTE.DocumentElement.SetAttribute("xmlns", "http://www.sii.cl/SiiDte");
                SETDTE.DocumentElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                SETDTE.DocumentElement.SetAttribute("schemaLocation", "http://www.w3.org/2001/XMLSchema-instance", "http://www.sii.cl/SiiDte EnvioDTE_v10.xsd");

                ////
                //// Guarde el documento para aplicar los cambios de namespace
                SETDTE.Save(uriSetDteResultado);
                SETDTE.PreserveWhitespace = true;
                SETDTE.Load(uriSetDteResultado);

                ////
                //// Firme el documento SetDTE
                strReferenciaSetDte = string.Format("#{0}", strReferenciaSetDte);
                FuncionesComunes.firmarDocumentoXml(ref SETDTE, certificado, strReferenciaSetDte);

                ////
                //// Guarde el documento firmado.
                SETDTE.Save(uriSetDteResultado);


                #endregion

                #region VALIDAR DOCUMENTO SETDTE FIRMADO CONTRA EL SCHEMA DEL SII

                ////
                //// Validar el documento xml (SETDTE) 
                errores.Clear();
                errores = FuncionesComunes.ValidarSchema(uriSetDteResultado, uriSchemaSetDte);
                if (errores.Count > 0)
                {
                    Console.WriteLine("Error en validacion de schema del SII sobre documento xml (DTE)");
                    errores.ForEach(delegate(string e)
                    {
                        Console.WriteLine("{0}", e);
                    });

                    throw new Exception("Antes de continuar debe solucionar los problemas del documento xml.");
                }

                #endregion

            }
            catch
            {


            }


            #endregion



        }

    }
}
   