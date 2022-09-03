using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
//using HEFESTO.ENTIDADES;

namespace HEFESTO.FIRMA.DOCUMENTO
{
    /// <summary>
    /// Permite firmar un documento DTE
    /// </summary>
    /// 

    public class HEFFirmarDocumento
    {

        #region PROPIEDADES DE LA CLASE

        public string CN { get; set; }

        /// <summary>
        /// Dirección donde se encuentra el certificado digital
        /// </summary>
        public string uriCaf { get; set; }
        public string uriDte { get; set; }
        public string uriEnvioDte { get; set; }
        public string Error { get; set; }


        /// <summary>
        /// Schema de Dte con firma
        /// </summary>
        public string uriSchemaDte { get; set; }

        /// <summary>
        /// Schema de Dte sin firma
        /// </summary>
        public string uriSchemaDteSf { get; set; }

        /// <summary>
        /// Schema de EnvioDte sin firma
        /// </summary>
        public string uriSchemaEnvioDteSf { get; set; }

        /// <summary>
        /// Schema de envio DTE
        /// </summary>
        public string uriSchemaEnvioDte { get; set; }
        public string XmlName { get; set; }
        public string RUTEmisor { get; set; }
        public string RznSoc { get; set; }
        public string TipoDTE { get; set; }
        public string Folio { get; set; }
        public string Fullpath { get; set; }
        public string FirmaStr { get; set; }


        #endregion

        #region FUNCIONES PRIVADAS

        /// <summary>
        /// Valida que todos los elementos sean correctos
        /// </summary>
        /// <returns></returns>
        private HEFRespuesta validaElementos()
        {

            ////
            //// inicie la respuesta de la validacion
            HEFRespuesta resp = new HEFRespuesta();

            ////
            //// listado de errores
            string errores = string.Empty;

            ////
            //// Valide los archivos
            if (string.IsNullOrEmpty(this.CN))
                errores += "No existe un nombre de certificado.;";


            ////
            //// Valide los archivos
            if (!File.Exists(this.uriCaf))
                errores += "Archivo uriCaf no existe o no se tiene acceso a el.;";

            ////
            //// Valide los archivos
            if (!File.Exists(this.uriDte))
                errores += "Archivo uriDte no existe o no se tiene acceso a el.;";

            ////
            //// Valide los archivos
            if (!File.Exists(this.uriEnvioDte))
                errores += "Archivo uriEnvioDte no existe o no se tiene acceso a el.;";

            ////
            //// Valide los archivos
            if (!File.Exists(this.uriSchemaDteSf))
                errores += "Archivo schema Dte sin firma, no existe o no se tiene acceso a el.;";

            ////
            //// Valide los archivos
            if (!File.Exists(this.uriSchemaEnvioDteSf))
                errores += "Archivo schema Envio Dte sin firma, no existe o no se tiene acceso a el.;";

            ////
            //// Compruebe que el schema del dte sea valido
            if (File.Exists(this.uriDte) && File.Exists(this.uriSchemaDteSf))
            {
                ////
                //// Valide el schema del DTE
                List<string> sErros = FuncionesComunes.ValidarSchema(this.uriDte, this.uriSchemaDteSf);
                foreach (string sErr in sErros)
                    errores += sErr + ";";

            }

            ////
            //// Compruebe que el schema del envio dte sea valido
            if (File.Exists(this.uriEnvioDte) && File.Exists(this.uriSchemaEnvioDteSf))
            {
                ////
                //// Valide el schema del DTE
                List<string> sErros = FuncionesComunes.ValidarSchema(this.uriEnvioDte, this.uriSchemaEnvioDteSf);
                foreach (string sErr in sErros)
                    errores += sErr + ";";

            }

            ////
            //// Cree la respuesta de salida
            resp.esCorrecto = string.IsNullOrEmpty(errores) ? true : false;
            resp.Mensaje = errores;



            ////
            //// Regrese el valor de retorno
            return resp;

        }


        #endregion


        /// <summary>
        /// Inicia el proceso de firma selecciionando la funcion adecuada
        /// para la firma del documento actual.
        /// </summary>
        /// <returns></returns>
        public HEFRespuesta FirmarArchivo()
        {

            ////
            //// Inicie la respuesta
            HEFRespuesta resp = new HEFRespuesta();

            ////
            //// inicie el proceso
            try
            {
                ////
                //// Determine el tipo de documento a firmar
                XmlDocument xDoc = new XmlDocument();
                xDoc.PreserveWhitespace = true;
                xDoc.Load(this.uriDte);

                ////
                //// Cree el name space manager del documento
                XmlNamespaceManager ns = new XmlNamespaceManager(xDoc.NameTable);
                ns.AddNamespace("sii", xDoc.DocumentElement.NamespaceURI);

                ////
                //// Recupere el primer nodo hijo del documento
                XmlElement node = (XmlElement)xDoc.DocumentElement.SelectNodes("sii:*", ns)[0];
                if (node != null)
                {
                    ////
                    //// Seleccione la funcion
                    switch (node.Name)
                    {
                        case "Documento":
                            resp = FirmarDocumento();
                            break;

                        case "Exportaciones":
                            resp = FirmarExportaciones();
                            break;

                        default:
                            break;
                    }

                }


            }
            catch (Exception)
            {

                ////
                //// TODO: Notifique el error al usuario

            }

            ////
            //// Regrese el valor de retorno 
            return resp;

        }

        /// <summary>
        /// Timbra y firma un documento Xml
        /// </summary>
        /// <returns></returns>
        private HEFRespuesta FirmarDocumento()
        {
            ////
            //// Cree la respuesta del proceso
            HEFRespuesta resp = new HEFRespuesta();


            ////
            //// Continue el proceso
            try
            {

                ////
                //// Inicie la lista de errores
                List<string> errores = new List<string>();


                ////
                //// Variables guardan nombres de referencias de archivos
                string strReferenciaDte = string.Empty;
                string strReferenciaSetDte = "SetDoc";

                ////
                //// Elementos internos de la clase
                string uriSetDteResultado = Fullpath + "\\SETDTEResultado.XML";
                string uriDteResultado = Fullpath + "\\DTEResultado.XML";

                ////
                //// Cargue el documento DTE a firmar
                //// Cargue el documento CAF que contiene los folios
                XDocument DTE = XDocument.Load(this.uriDte, LoadOptions.PreserveWhitespace);
                XDocument CAF = XDocument.Load(this.uriCaf, LoadOptions.PreserveWhitespace);

                ////
                //// Recupere el certificado para firmar utilizando el CN
                X509Certificate2 certificado = FuncionesComunes.RecuperarCertificado(CN);
                if (certificado == null)
                {
                    throw new Exception("No se encuentra el certificado para poder firmar los documentos");
                }

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
                {
                    if (strRznSocRecep.Length > 40)
                        node.Value = strRznSocRecep.Substring(0, 40);
                    else
                        node.Value = strRznSocRecep;
                }
                node = DTE.XPathSelectElement("DTE/Documento/TED/DD/MNT");
                if (node != null)
                    node.Value = strMntTotal;
                node = DTE.XPathSelectElement("DTE/Documento/TED/DD/IT1");
                if (node != null)
                {
                    if (strDscItem.Length > 40)
                        node.Value = strDscItem.Substring(0, 40);
                    else
                        node.Value = strDscItem;
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

                //////
                ////// Recupere el valor del nodo TED y preparelo para ser timbrado
                XmlElement TED = (XmlElement)xmlDTE.SelectSingleNode("DTE/Documento/TED");
                if (TED == null)
                    throw new Exception("No se encuentra el nodo DD");

                #endregion

                #region FIRMAR EL DOCUMENTO DTE

                ////
                //// Agregue el ns del SII, luego guarde el documento para que la asigna
                //// cion quede reflejada en el documento

                if (TipoDTE != "39")
                {
                    xmlDTE.DocumentElement.SetAttribute("xmlns", "http://www.sii.cl/SiiDte");
                    xmlDTE.Save(uriDteResultado);
                }


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
                errores = FuncionesComunes.ValidarSchema(uriDteResultado, this.uriSchemaDte);
                if (errores.Count > 0)
                {
                    string err = string.Empty;
                    errores.ForEach(delegate (string e)
                    {
                        err += e + ";";

                    });

                    resp.esCorrecto = false;
                    resp.Mensaje = err;
                    return resp;

                }

                #endregion

                #region INSERTA EL DOCUMENTO DTE EN EL SETDTE Y FIRMA EL SETDTE

                //// ////////////////////////////////////////////////////////////////////
                //// Prepare el Set dte para su firma
                //// 1.- Inserte el DTE firmado al SetDTE
                //// ////////////////////////////////////////////////////////////////////
                XmlDocument SETDTE = new XmlDocument();
                SETDTE.PreserveWhitespace = true;
                SETDTE.Load(this.uriEnvioDte);

                ////
                //// Calcule el nuevo tmst de la firma del SETDTE
                XmlElement TmstFirmaEnv = (XmlElement)SETDTE.SelectSingleNode("EnvioDTE/SetDTE/Caratula/TmstFirmaEnv");
                if (TmstFirmaEnv == null)
                    throw new Exception("No se encuentra el nodo TmstFirmaEnv");
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

                if (TipoDTE != "39")
                {

                    #region VALIDAR DOCUMENTO SETDTE FIRMADO CONTRA EL SCHEMA DEL SII

                    ////
                    //// Validar el documento xml (SETDTE) 
                    errores.Clear();
                    errores = FuncionesComunes.ValidarSchema(uriSetDteResultado, this.uriSchemaEnvioDte);
                    if (errores.Count > 0)
                    {
                        string err = string.Empty;
                        errores.ForEach(delegate (string e)
                        {
                            err += e + ";";

                        });

                        resp.esCorrecto = false;
                        resp.Mensaje = err;
                        return resp;

                    }
                }

                #endregion


                ////
                //// Regrese el resultado de la operacion
                resp.esCorrecto = true;
                resp.Resultado = uriSetDteResultado;

            }
            catch (Exception ex)
            {
                ////
                //// Indique que existe un error
                resp.esCorrecto = false;
                resp.Mensaje = ex.Message;

            }


            ////
            //// Regrese el valor de retorno
            return resp;

        }

        /// <summary>
        /// Timbra y firma un documento Xml
        /// </summary>
        /// <returns></returns>
        private HEFRespuesta FirmarExportaciones()
        {
            ////
            //// Cree la respuesta del proceso
            HEFRespuesta resp = new HEFRespuesta();

            ////
            //// Valide los elementos del proceso
            HEFRespuesta respVal = validaElementos();
            if (!respVal.esCorrecto)
                return respVal;


            ////
            //// Continue el proceso
            try
            {

                ////
                //// Inicie la lista de errores
                List<string> errores = new List<string>();


                ////
                //// Variables guardan nombres de referencias de archivos
                string strReferenciaDte = string.Empty;
                string strReferenciaSetDte = "SetDoc";

                ////
                //// Elementos internos de la clase
                string uriSetDteResultado = "Documentos\\SETDTEResultado.XML";
                string uriDteResultado = "Documentos\\DTEResultado.XML";


                ////
                //// Cargue el documento DTE a firmar
                //// Cargue el documento CAF que contiene los folios
                XDocument DTE = XDocument.Load(this.uriDte, LoadOptions.PreserveWhitespace);
                XDocument CAF = XDocument.Load(this.uriCaf, LoadOptions.PreserveWhitespace);

                ////
                //// Recupere el certificado para firmar utilizando el CN
                X509Certificate2 certificado = FuncionesComunes.RecuperarCertificado(CN);
                if (certificado == null)
                {
                    throw new Exception("No se encuentra el certificado para poder firmar ls documentos");
                }

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
                strTipoDTE = DTE.XPathSelectElement("DTE/Exportaciones/Encabezado/IdDoc/TipoDTE").Value;

                ////
                //// Rescate el Folio  
                strFolio = DTE.XPathSelectElement("DTE/Exportaciones/Encabezado/IdDoc/Folio").Value;

                ////
                //// Rescate la fecha de emision del documento
                strFchEmis = DTE.XPathSelectElement("DTE/Exportaciones/Encabezado/IdDoc/FchEmis").Value;

                ////
                //// Rescate el rut del emisor del documento
                strRutEmisor = DTE.XPathSelectElement("DTE/Exportaciones/Encabezado/Emisor/RUTEmisor").Value;

                ////
                //// Rescate el rut del receptor del documento
                strRUTRecep = DTE.XPathSelectElement("DTE/Exportaciones/Encabezado/Receptor/RUTRecep").Value;

                ////
                //// Rescate la razon social del receptor
                strRznSocRecep = DTE.XPathSelectElement("DTE/Exportaciones/Encabezado/Receptor/RznSocRecep").Value;

                ////
                //// Rescate el MntTotal
                strMntTotal = DTE.XPathSelectElement("DTE/Exportaciones/Encabezado/Totales/MntTotal").Value;

                ////
                //// Rescate el DscItem del primer detalle
                //// Reccuerde que cuando son notas de debito o credito 
                //// El detalle puede venir vacio.
                strDscItem = string.Empty;
                XElement nodeNmbItem = DTE.XPathSelectElement("DTE/Exportaciones/Detalle/NmbItem[1]");
                if (nodeNmbItem != null)
                    strDscItem = nodeNmbItem.Value;


                ///////////////////////////////////////////////////////////////
                //// En el caso que el documento dte actual no tiene el nodo
                //// TED agreguelo manualmente
                ///////////////////////////////////////////////////////////////
                XElement nodeTed = DTE.XPathSelectElement("DTE/Exportaciones/TED");
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
                    XElement nodeTmstFirma = DTE.XPathSelectElement("DTE/Exportaciones/TmstFirma");
                    if (nodeTmstFirma != null)
                        nodeTmstFirma.AddBeforeSelf(newTed);
                    else
                        DTE.XPathSelectElement("DTE/Exportaciones").Add(newTed);




                }



                ///////////////////////////////////////////////////////////////
                //// Si existe el nodo CAF eliminelo del documento
                //// Para agragar el nuevo nodo CAF extraído desde el archivo
                //// enviado por el SII
                ///////////////////////////////////////////////////////////////
                XElement node = DTE.XPathSelectElement("DTE/Exportaciones/TED/DD/CAF");
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
                DTE.XPathSelectElement("DTE/Exportaciones").SetAttributeValue("ID", strReferenciaDte);

                ////
                //// Reasigne la fecha TSTED de nodo TED
                node = DTE.XPathSelectElement("DTE/Exportaciones/TED/DD/TSTED");
                if (node != null)
                    node.Value = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

                ////
                //// Reasigne la fecha TmstFirma de nodo Documento
                node = DTE.XPathSelectElement("DTE/Exportaciones/TmstFirma");
                if (node != null)
                    node.Value = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

                ////
                //// Retire la firma del nodo FRMT
                node = DTE.XPathSelectElement("DTE/Exportaciones/TED/FRMT");
                if (node != null)
                {
                    node.Value = string.Empty;
                    node.SetAttributeValue("algoritmo", "SHA1withRSA");
                }

                ///////////////////////////////////////////////////////////////
                //// Reasignacion de data a elementos del TED
                //// RE, TD, F, FE, RR, RSR, MNT, IT1
                ///////////////////////////////////////////////////////////////
                node = DTE.XPathSelectElement("DTE/Exportaciones/TED/DD/RE");
                if (node != null)
                    node.Value = strRutEmisor;
                node = DTE.XPathSelectElement("DTE/Exportaciones/TED/DD/TD");
                if (node != null)
                    node.Value = strTipoDTE;
                node = DTE.XPathSelectElement("DTE/Exportaciones/TED/DD/F");
                if (node != null)
                    node.Value = strFolio;
                node = DTE.XPathSelectElement("DTE/Exportaciones/TED/DD/FE");
                if (node != null)
                    node.Value = strFchEmis;
                node = DTE.XPathSelectElement("DTE/Exportaciones/TED/DD/RR");
                if (node != null)
                    node.Value = strRUTRecep;
                node = DTE.XPathSelectElement("DTE/Exportaciones/TED/DD/RSR");
                if (node != null)
                    node.Value = strRznSocRecep;
                node = DTE.XPathSelectElement("DTE/Exportaciones/TED/DD/MNT");
                if (node != null)
                    node.Value = strMntTotal;
                node = DTE.XPathSelectElement("DTE/Exportaciones/TED/DD/IT1");
                if (node != null)
                {
                    if (strDscItem.Length > 40)
                        node.Value = strDscItem.Substring(0, 40);
                    else
                        node.Value = strDscItem;
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
                XElement nodeCafDte = DTE.XPathSelectElement("DTE/Exportaciones/TED/DD/CAF");
                if (nodeCafDte == null)
                {
                    DTE.XPathSelectElement("DTE/Exportaciones/TED/DD/IT1").AddAfterSelf(nodeCaf);
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
                XmlElement DD = (XmlElement)xmlDTE.SelectSingleNode("DTE/Exportaciones/TED/DD");
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
                XmlElement FRMTSHA1withRSA = (XmlElement)xmlDTE.SelectSingleNode("DTE/Exportaciones/TED/FRMT");
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
                errores = FuncionesComunes.ValidarSchema(uriDteResultado, this.uriSchemaDte);
                if (errores.Count > 0)
                {
                    string err = string.Empty;
                    errores.ForEach(delegate (string e)
                    {
                        err += e + ";";

                    });

                    resp.esCorrecto = false;
                    resp.Mensaje = err;
                    return resp;

                }

                #endregion

                #region INSERTA EL DOCUMENTO DTE EN EL SETDTE Y FIRMA EL SETDTE

                //// ////////////////////////////////////////////////////////////////////
                //// Prepare el Set dte para su firma
                //// 1.- Inserte el DTE firmado al SetDTE
                //// ////////////////////////////////////////////////////////////////////
                XmlDocument SETDTE = new XmlDocument();
                SETDTE.PreserveWhitespace = true;
                SETDTE.Load(this.uriEnvioDte);

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
                errores = FuncionesComunes.ValidarSchema(uriSetDteResultado, this.uriSchemaEnvioDte);
                if (errores.Count > 0)
                {
                    string err = string.Empty;
                    errores.ForEach(delegate (string e)
                    {
                        err += e + ";";

                    });

                    resp.esCorrecto = false;
                    resp.Mensaje = err;
                    return resp;

                }

                #endregion


                ////
                //// Regrese el resultado de la operacion
                resp.esCorrecto = true;
                resp.Resultado = uriSetDteResultado;

            }
            catch (Exception ex)
            {
                ////
                //// Indique que existe un error
                resp.esCorrecto = false;
                resp.Mensaje = ex.Message;

            }


            ////
            //// Regrese el valor de retorno
            return resp;

        }

        public bool CrearEnvioDte(string RutEmisor, string RutEnvia, string RutReceptor, string FchResol, string NroResol, string TpoDTE)
        {

            try
            {
                ////
                //// inicie el documento
                XmlDocument xmlEnvioDTE = new XmlDocument();

                ////
                //// Cree declaracion del documento xml
                XmlNode docNode = xmlEnvioDTE.CreateXmlDeclaration("1.0", "ISO-8859-1", null);
                xmlEnvioDTE.AppendChild(docNode);

                ////
                //// Cree el nodo root
                XmlElement nodeEnvioDTE = xmlEnvioDTE.CreateElement("EnvioDTE");

                ////
                //// Cree el atributo version
                XmlAttribute attr = xmlEnvioDTE.CreateAttribute("version");
                attr.Value = "1.0";
                nodeEnvioDTE.Attributes.Append(attr);

                ////
                //// cree el nodo SetDTE
                XmlElement nodeSetDTE = xmlEnvioDTE.CreateElement("SetDTE");

                ////
                //// Cree el atributo ID
                attr = xmlEnvioDTE.CreateAttribute("ID");
                attr.Value = "SetDoc";
                nodeSetDTE.Attributes.Append(attr);

                ////
                //// cree el nodo Caratula
                XmlElement nodeCaratula = xmlEnvioDTE.CreateElement("Caratula");

                ////
                //// Cree el atributo version de caratula
                attr = xmlEnvioDTE.CreateAttribute("version");
                attr.Value = "1.0";
                nodeCaratula.Attributes.Append(attr);

                ////
                //// Rut Emisor
                XmlElement node = xmlEnvioDTE.CreateElement("RutEmisor");
                node.InnerText = RutEmisor;
                nodeCaratula.AppendChild(node);

                ////
                //// Rut envia documento
                node = xmlEnvioDTE.CreateElement("RutEnvia");
                node.InnerText = RutEnvia;
                nodeCaratula.AppendChild(node);

                ////
                //// Rut Receptor
                node = xmlEnvioDTE.CreateElement("RutReceptor");
                node.InnerText = RutReceptor;
                nodeCaratula.AppendChild(node);

                ////
                //// Fecha de resolucion
                node = xmlEnvioDTE.CreateElement("FchResol");
                node.InnerText = FchResol;
                nodeCaratula.AppendChild(node);

                ////
                //// Nro Resolucion
                node = xmlEnvioDTE.CreateElement("NroResol");
                node.InnerText = NroResol;
                nodeCaratula.AppendChild(node);

                ////
                //// Tmst firma del envio
                node = xmlEnvioDTE.CreateElement("TmstFirmaEnv");
                node.InnerText = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                nodeCaratula.AppendChild(node);

                ////
                //// Cree subnodo
                XmlElement subNode = xmlEnvioDTE.CreateElement("SubTotDTE");

                ////
                //// Sub elemento
                XmlElement subNodeElement = xmlEnvioDTE.CreateElement("TpoDTE");
                subNodeElement.InnerText = TpoDTE;
                subNode.AppendChild(subNodeElement);

                ////
                //// Sub elemento
                subNodeElement = xmlEnvioDTE.CreateElement("NroDTE");
                subNodeElement.InnerText = "1";
                subNode.AppendChild(subNodeElement);

                ////
                //// Agregue el subnode a la caratula
                nodeCaratula.AppendChild(subNode);

                ////
                //// Guarde la caratula en SetDTE
                nodeSetDTE.AppendChild(nodeCaratula);

                ////
                //// Agregar nodo 
                nodeEnvioDTE.AppendChild(nodeSetDTE);

                ////
                //// Guarde el nodo root
                xmlEnvioDTE.AppendChild(nodeEnvioDTE);

                ////
                //// Guarde el documento
                //// string fullpath = Path.ChangeExtension(Path.GetTempFileName(), ".XML");
                string fullpath = Fullpath + "\\EnvioDte.Xml";

                if (File.Exists(fullpath))
                    File.Delete(fullpath);
                xmlEnvioDTE.Save(fullpath);

                ////
                //// Quite la identacion original del documento
                Negocio.QuitarIdentacionXml(fullpath);

                ////
                //// Transforme "iso-8859-1" a "ISO-8859-1"
                string contenido = File.ReadAllText(fullpath, Encoding.GetEncoding("ISO-8859-1"));
                contenido = contenido.Replace("iso-8859-1", "ISO-8859-1");
                File.WriteAllText(fullpath, contenido, Encoding.GetEncoding("ISO-8859-1"));

                ////
                //// Indique la fullpath
                this.uriEnvioDte = fullpath;

            }
            catch (Exception)
            {

                ////
                //// Notifique al usuario
                //MessageBox.Show("No fue posible construir el documento EnvioDTE", "validación",
                //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Error = "No fue posible construir el documento EnvioDTE";
                ////
                //// Regrese la valor de retorno
                return false;

            }

            ////
            //// Regrese la valor de retorno
            return true;

        }

        public bool CargarDocumento(string _Ruta_Documento)
        {

            {

                ////
                //// Recupere el diccionario de datos
                Dictionary<string, string> Diccionario = CargarDocumentosSII();

                ////
                //// Abra el archivo para su proceso


                ////
                //// compruebe que exista un valor
                if (!string.IsNullOrEmpty(_Ruta_Documento))
                {

                    ////
                    //// Recupere el fullpath del archivo
                    string XmlName = Path.GetFileName(_Ruta_Documento);

                    try
                    {


                        ////
                        //// Abra el documento xml
                        XmlDocument xmlDte = new XmlDocument();
                        xmlDte.PreserveWhitespace = true;
                        xmlDte.Load(_Ruta_Documento);

                        ////
                        //// Recupere el primer nodo para establecer si este
                        //// documento es un caf o no
                        string root = xmlDte.DocumentElement.Name;
                        if (root != "DTE")
                            throw new Exception("El documento que intenta cargar no es un archivo DTE.");


                        ////
                        //// Cree el name space manager del documento
                        XmlNamespaceManager ns = new XmlNamespaceManager(xmlDte.NameTable);
                        ns.AddNamespace("sii", xmlDte.DocumentElement.NamespaceURI);

                        ////
                        //// Recupere los datos del documento.



                        this.XmlName = XmlName;
                        RUTEmisor = xmlDte.SelectSingleNode("sii:DTE//sii:Encabezado/sii:Emisor/sii:RUTEmisor", ns).InnerText;

                        if (TipoDTE == "39")
                        {
                            RznSoc = xmlDte.SelectSingleNode("sii:DTE//sii:Encabezado/sii:Emisor/sii:RznSocEmisor", ns).InnerText;
                        }
                        else
                        {
                            RznSoc = xmlDte.SelectSingleNode("sii:DTE//sii:Encabezado/sii:Emisor/sii:RznSoc", ns).InnerText;
                        }

                        
                        
                        TipoDTE = xmlDte.SelectSingleNode("sii:DTE//sii:Encabezado/sii:IdDoc/sii:TipoDTE", ns).InnerText;
                        Folio = xmlDte.SelectSingleNode("sii:DTE//sii:Encabezado/sii:IdDoc/sii:Folio", ns).InnerText;

                        ////
                        //// Cree el xpath del documento
                        string sRoot = xmlDte.DocumentElement.Name;
                        string sFirstChild = xmlDte.DocumentElement.SelectNodes("*", ns)[0].Name;
                        string sXpath = string.Format("{0}\\{1}", sRoot, sFirstChild);

                        ////
                        //// Recupere el name space del documento
                        string nameSpace = xmlDte.DocumentElement.NamespaceURI;
                        string sNameSpace = string.IsNullOrEmpty(nameSpace) ? "Sin Name Space" : nameSpace;

                        string _Root, _XmlNs;

                        ////
                        //// Recupere el nodo root del documento
                        _Root = sXpath;
                        _XmlNs = sNameSpace;

                        ////
                        //// Muestre el nombre del documento
                        string _NombreDoc = Diccionario[TipoDTE];


                        ////
                        //// Recupere la uri del archivo
                        this.uriDte = _Ruta_Documento;

                        ////
                        //// Complete los datos auxiliares del envio dte
                        //cmpEnvRe.Text = cmpXmlRut.Text;



                    }
                    catch (Exception exp)
                    {
                        ////
                        //// Notifique al usuario
                        //MessageBox.Show(exp.Message, "Validación Documento",
                        //    MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ////
                        //// limpie el formulario
                        XmlName = XmlName;
                        RUTEmisor = string.Empty;
                        RznSoc = string.Empty;
                        TipoDTE = string.Empty;
                        Folio = string.Empty;

                        ////
                        //// recupere la uri del archivo
                        this.uriDte = string.Empty;
                        return false;
                    }

                }

            }

            return true;
        }

        private Dictionary<string, string> CargarDocumentosSII()
        {

            ////
            //// Cree el diccionario
            Dictionary<string, string> SiiTipos = new Dictionary<string, string>();

            ////
            //// Inicie el proceso
            try
            {

                ////
                //// Ruta del documento xml
                string uriTiposSII = "DocumentosSII\\DocumentosSII.xml";

                ////
                //// Variable global de tipo de documentos
                XmlDocument XmlTipos = new XmlDocument();
                XmlTipos.PreserveWhitespace = true;
                XmlTipos.Load(uriTiposSII);

                ////
                //// Recupere los tipos
                XmlNodeList nodos = XmlTipos.SelectNodes("SII/DOCUMENTOS/DOCUMENTO");
                if (nodos != null)
                {
                    ////
                    //// Recorra los nodos
                    foreach (XmlElement nodo in nodos)
                    {
                        string sKey = nodo.Attributes["ID"].InnerText;
                        string sVal = nodo.InnerText;
                        SiiTipos.Add(sKey, sVal);
                    }

                }


            }
            catch (Exception)
            {

                //// TODO: Indicar error
            }


            ////
            //// Regrese el valor de retorno
            return SiiTipos;

        }

        //Fin de la Clase principal
    }

}
