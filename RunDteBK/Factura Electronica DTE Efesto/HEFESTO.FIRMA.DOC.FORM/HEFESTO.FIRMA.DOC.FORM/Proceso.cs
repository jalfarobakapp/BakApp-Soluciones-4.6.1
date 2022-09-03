using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
//using HEFESTO.FIRMA.DOC;
using HEFESTO.FIRMA.DOCUMENTO;
//using HEFESTO.ENTIDADES;

namespace HEFESTO.FIRMA.DOC.FORM
{
    public partial class Proceso : Form
    {

        /// <summary>
        /// indica cual es la ruta del archivo caf
        /// </summary>
        public string uriCaf { get; set; }

        /// <summary>
        /// Indica cual es la ruta del archivo Xml
        /// </summary>
        public string uriDte { get; set; }

        /// <summary>
        /// Indica cual es la ruta del archivo Xml EnvioDte
        /// </summary>
        public string uriEnvioDte { get; set; }

        /// <summary>
        /// Nombe Comun del certificado
        /// </summary>
        public string CN { get; set; }

        /// <summary>
        /// Tipo de documento
        /// </summary>
        public string Tido { get; set; }

        /// <summary>
        /// Ruta para guardar CAF
        /// </summary>
        public string RutaCAF { get; set; }

        public Proceso()
        {
            InitializeComponent();

            ////
            //// Recupere la lista de certificados disponibles
            cmbCertificados.DataSource = Negocio.ListaDeCertificados();

        }

        /// <summary>
        /// Cuando el formulario inicia
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {

            //////
            ////// Recupere la lista de certificados disponibles
            //cmbCertificados.DataSource = Negocio.ListaDeCertificados();

            if (!string.IsNullOrEmpty(RutaCAF))
            {
                Sb_CargarRuta(RutaCAF);
            }

        }

        /// <summary>
        /// Seleccion de archivo CAF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCafSelection_Click(object sender, EventArgs e)
        {

            ////
            //// Inicie la seleccion del archivo CAF
            openFile.FileName = "";
            openFile.Filter = "Archivo CAF|*xml";


            ////
            //// Abra el archivo para su proceso
            if (openFile.ShowDialog() == DialogResult.OK)
            {

                ////
                //// compruebe que exista un valor
                if (!string.IsNullOrEmpty(openFile.FileName))
                {

                    string CafName = Path.GetFileName(openFile.FileName);

                    try
                    {

                        ////
                        //// Abrir un archivo para evitar caracteres latinos erroneos
                        string sCaf = string.Empty;
                        using (StreamReader sr = new StreamReader(openFile.FileName, Encoding.GetEncoding("ISO-8859-1")))
                        {
                            sCaf = sr.ReadToEnd();
                        }


                        ////
                        //// Abra el documento xml
                        XmlDocument xmlCaf = new XmlDocument();
                        xmlCaf.PreserveWhitespace = true;
                        //// xmlCaf.Load(openFile.FileName);
                        xmlCaf.LoadXml(sCaf);


                        ////
                        //// Recupere el primer nodo para establecer si este
                        //// documento es un caf o no
                        string root = xmlCaf.DocumentElement.Name;
                        if (root != "AUTORIZACION")
                            throw new Exception("El documento que intenta cargar no es un archivo CAF.");



                        ////
                        //// Recupere los datos del documento
                        cmpCafName.Text = CafName;
                        cmpCafRut.Text = xmlCaf.SelectSingleNode("AUTORIZACION/CAF/DA/RE").InnerText;
                        cmpCafEmpresa.Text = xmlCaf.SelectSingleNode("AUTORIZACION/CAF/DA/RS").InnerText;
                        cmpCafTipo.Text = xmlCaf.SelectSingleNode("AUTORIZACION/CAF/DA/TD").InnerText;
                        cmpCafMin.Text = xmlCaf.SelectSingleNode("AUTORIZACION/CAF/DA/RNG/D").InnerText;
                        cmpCafMax.Text = xmlCaf.SelectSingleNode("AUTORIZACION/CAF/DA/RNG/H").InnerText;

                        ////
                        //// recupere la uri del archivo
                        this.uriCaf = openFile.FileName;

                    }
                    catch (Exception exp)
                    {

                        MessageBox.Show(exp.Message, "Validación Documento",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);

                        cmpXmlName.Text = string.Empty;
                        cmpXmlRut.Text = string.Empty;
                        cmpXmlEmisor.Text = string.Empty;
                        cmpXmlTipo.Text = string.Empty;
                        cmpXmlFolio.Text = string.Empty;

                        ////
                        //// recupere la uri del archivo
                        this.uriCaf = string.Empty;

                    }



                }



            }




        }

        /// <summary>
        /// Pwrmite seleccionar el archivo xml a firmar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXmlSeleccion_Click(object sender, EventArgs e)
        {

            ////
            //// Recupere el diccionario de datos
            Dictionary<string, string> Diccionario = CargarDocumentosSII();

            ////
            //// Inicie la seleccion del archivo CAF
            openFile.FileName = "";
            openFile.Filter = "Archivo DTE|*xml";


            ////
            //// Abra el archivo para su proceso
            if (openFile.ShowDialog() == DialogResult.OK)
            {

                ////
                //// compruebe que exista un valor
                if (!string.IsNullOrEmpty(openFile.FileName))
                {

                    ////
                    //// Recupere el fullpath del archivo
                    string XmlName = Path.GetFileName(openFile.FileName);

                    try
                    {


                        ////
                        //// Abra el documento xml
                        XmlDocument xmlDte = new XmlDocument();
                        xmlDte.PreserveWhitespace = true;
                        xmlDte.Load(openFile.FileName);

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
                        cmpXmlName.Text = XmlName;
                        cmpXmlRut.Text = xmlDte.SelectSingleNode("sii:DTE//sii:Encabezado/sii:Emisor/sii:RUTEmisor", ns).InnerText;
                        cmpXmlEmisor.Text = xmlDte.SelectSingleNode("sii:DTE//sii:Encabezado/sii:Emisor/sii:RznSoc", ns).InnerText;
                        cmpXmlTipo.Text = xmlDte.SelectSingleNode("sii:DTE//sii:Encabezado/sii:IdDoc/sii:TipoDTE", ns).InnerText;
                        cmpXmlFolio.Text = xmlDte.SelectSingleNode("sii:DTE//sii:Encabezado/sii:IdDoc/sii:Folio", ns).InnerText;

                        ////
                        //// Cree el xpath del documento
                        string sRoot = xmlDte.DocumentElement.Name;
                        string sFirstChild = xmlDte.DocumentElement.SelectNodes("*", ns)[0].Name;
                        string sXpath = string.Format("{0}\\{1}", sRoot, sFirstChild);

                        ////
                        //// Recupere el name space del documento
                        string nameSpace = xmlDte.DocumentElement.NamespaceURI;
                        string sNameSpace = string.IsNullOrEmpty(nameSpace) ? "Sin Name Space" : nameSpace;

                        ////
                        //// Recupere el nodo root del documento
                        cmpXmlRoot.Text = sXpath;
                        cmpXmlNs.Text = sNameSpace;

                        ////
                        //// Muestre el nombre del documento
                        cmpNombreDoc.Text = Diccionario[cmpXmlTipo.Text];


                        ////
                        //// Recupere la uri del archivo
                        this.uriDte = openFile.FileName;

                        ////
                        //// Complete los datos auxiliares del envio dte
                        cmpEnvRe.Text = cmpXmlRut.Text;



                    }
                    catch (Exception exp)
                    {
                        ////
                        //// Notifique al usuario
                        MessageBox.Show(exp.Message, "Validación Documento",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ////
                        //// limpie el formulario
                        cmpXmlName.Text = string.Empty;
                        cmpXmlRut.Text = string.Empty;
                        cmpXmlEmisor.Text = string.Empty;
                        cmpXmlTipo.Text = string.Empty;
                        cmpXmlFolio.Text = string.Empty;

                        ////
                        //// recupere la uri del archivo
                        this.uriDte = string.Empty;

                    }

                }

            }

        }

        /// <summary>
        /// Cuando el usuario sale del programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Inicio del procesamiento de los archivos
        /// </summary>
        private void btnProcesar_Click(object sender, EventArgs e)
        {

            ////
            //// Valide el formulario
            if (!ValidaFormulario())
                return;

            ////
            //// Continue con el procesamiento
            if (!CrearEnvioDte())
                return;

            ////
            //// Inicie el proceso de timbraje y firma de documentos
            HEFFirmarDocumento clsFirmarDocumento = new HEFFirmarDocumento();
            clsFirmarDocumento.CN = this.CN;
            clsFirmarDocumento.uriCaf = this.uriCaf;
            clsFirmarDocumento.uriDte = this.uriDte;
            clsFirmarDocumento.uriEnvioDte = this.uriEnvioDte;
            clsFirmarDocumento.uriSchemaDte = "Schemas\\DTE_v10.xsd";
            clsFirmarDocumento.uriSchemaDteSf = "Schemas\\DTE_v10_Sf.xsd";
            clsFirmarDocumento.uriSchemaEnvioDteSf = "Schemas\\EnvioDTE_v10_Sf.xsd";
            clsFirmarDocumento.uriSchemaEnvioDte = "Schemas\\EnvioDTE_v10.xsd";

            ////
            //// Cree el nombre de salida del documento Firmado
            string ArchivoFirmado = Path.GetFileName(Path.ChangeExtension(this.uriDte, ".Firmado.xml"));

            ////
            //// Ejecute el proceso de firma
            HEFRespuesta Respuesta = clsFirmarDocumento.FirmarArchivo();
            if (!Respuesta.esCorrecto)
            {
                Validacion val = new Validacion();
                val.errores = Respuesta.Mensaje;
                val.ShowDialog();
                return;
            }

            ////
            //// Recupere el valor del archivo
            string uriDocumentoFirmado = Respuesta.Resultado.ToString();
            saveFile.FileName = ArchivoFirmado;
            saveFile.Filter = "Documentos xml|*.xml";
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string name = saveFile.FileName;
                if (File.Exists(name))
                    File.Delete(name);
                File.Copy(uriDocumentoFirmado, name);
            }

            ////
            //// Si el usuario necesita separar el documento DTE de su envio
            if (chkSeparar.Checked)
            {
                ////
                //// Separe el documento DTE del envioDTE
                XmlDocument xSetDTE = new XmlDocument();
                xSetDTE.PreserveWhitespace = true;
                xSetDTE.Load(uriDocumentoFirmado);

                ////
                //// Cree el ns del documento
                XmlNamespaceManager ns = new XmlNamespaceManager(xSetDTE.NameTable);
                ns.AddNamespace("sii", xSetDTE.DocumentElement.NamespaceURI);

                ////
                //// Extraiga el DTE subyacente
                XmlElement xElemento = (XmlElement)xSetDTE.SelectSingleNode("sii:EnvioDTE/sii:SetDTE/sii:DTE", ns);
                if (xElemento != null)
                {
                    ////
                    //// Cree el objeto
                    XmlDocument xDTE = new XmlDocument();
                    xDTE.PreserveWhitespace = true;
                    xDTE.LoadXml(xElemento.OuterXml);

                    ////
                    //// Guarde el documento DTE
                    saveFile.FileName = "DocumentoFirmadoDTE.XML";
                    saveFile.Filter = "Documentos xml|*.xml";
                    if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string name = saveFile.FileName;
                        if (File.Exists(name))
                            File.Delete(name);
                        xDTE.Save(name);

                    }

                }

            }

            MessageBox.Show("Fin del proceso");

        }

        /// <summary>
        /// Valida el formulario antes del proceso
        /// </summary>
        private bool ValidaFormulario()
        {

            ////
            //// Inicie la validacion
            List<Respuesta> Respuestas = new List<Respuesta>();

            ////
            //// Validar los certificados
            if (cmbCertificados.SelectedIndex == 0)
            {
                Respuesta resp = new Respuesta();
                resp.esCorrecto = false;
                resp.Mensaje = "Debe seleccionar un certificado.";
                resp.Detalle = "Para poder iniciar el proceso de timbrado y firmado se debe seleccionar el certificado correspondiente a la ";
                resp.Detalle += "persona encargada de firmar los documentos.";
                Respuestas.Add(resp);
            }
            else
            {
                this.CN = cmbCertificados.SelectedValue.ToString();

            }


            ////
            //// Validar archivo caf
            if (string.IsNullOrEmpty(this.uriCaf))
            {
                Respuesta resp = new Respuesta();
                resp.esCorrecto = false;
                resp.Mensaje = "Debe cargar un archivo CAF.";
                resp.Detalle = "El archivo CAF contiene la información de los folios disponibles ";
                resp.Detalle += "para poder firmar los documentos DTE. Indica el rut de la empresa, ";
                resp.Detalle += "el nombre de la empresa y el rango de folios a utilizar. ";

                Respuestas.Add(resp);
            }

            ////
            //// Validar archivo xml
            if (string.IsNullOrEmpty(this.uriDte))
            {
                Respuesta resp = new Respuesta();
                resp.esCorrecto = false;
                resp.Mensaje = "Debe cargar un archivo Dte.";
                resp.Detalle += "El archivo DTE corresponde al documento tributario electrónico solicitado por el SII. ";

                Respuestas.Add(resp);
            }


            ////
            //// Validar datos del archivo envioDte
            if (string.IsNullOrEmpty(cmpEnvRen.Text))
            {
                Respuesta resp = new Respuesta();
                resp.esCorrecto = false;
                resp.Mensaje = "Debe agregar un rut de emisor de Envio DTE.";
                resp.Detalle += "El rut del emisor del envio DTE es para poder indicar quien envia el EnvioDTE. \r\n";
                resp.Detalle += "Formato: 99999999-K ";
                Respuestas.Add(resp);
            }

            ////
            //// Validar Fecha de resolucion
            if (string.IsNullOrEmpty(cmpEnvFch.Text))
            {
                Respuesta resp = new Respuesta();
                resp.esCorrecto = false;
                resp.Mensaje = "Debe agregar una fecha de resolución de Envio DTE.";
                resp.Detalle += "Fecha de resolución de certificación o producción suministrada por el SII. \r\n";
                resp.Detalle += "Formato: yyyy-mm-dd ";
                Respuestas.Add(resp);
            }

            ////
            //// Validar numero de resolucion
            if (string.IsNullOrEmpty(cmpEnvNro.Text))
            {
                Respuesta resp = new Respuesta();
                resp.esCorrecto = false;
                resp.Mensaje = "Debe agregar un numero de resolución de Envio DTE.";
                resp.Detalle += "Numero de resolución de certificación o producción suministrada por el SII. ";

                Respuestas.Add(resp);
            }


            ////
            //// Validacion entre caf y dte
            if (cmpCafRut.Text != cmpXmlRut.Text)
            {
                Respuesta resp = new Respuesta();
                resp.esCorrecto = false;
                resp.Mensaje = "El rut del archivo CAF no es el mismo que el archivo DTE.";
                resp.Detalle += string.Format("Rut CAF {0} no es igual a rut XML {1} \r\n", cmpCafRut.Text, cmpXmlRut.Text);
                resp.Detalle += "Formato: 99999999-K ";
                Respuestas.Add(resp);
            }

            ////
            //// Validacion entre caf y dte
            if (cmpCafTipo.Text != cmpXmlTipo.Text)
            {
                Respuesta resp = new Respuesta();
                resp.esCorrecto = false;
                resp.Mensaje = "El tipo de documento del archivo caf no es el mismo del archivo Dte.";
                resp.Detalle += string.Format("Tipo Doc. CAF {0} no es igual a tipo doc. XML {1}", cmpCafTipo.Text, cmpXmlTipo.Text);
                Respuestas.Add(resp);
            }

            ////
            //// Validacion entre caf y dte
            if (cmpCafTipo.Text != cmpXmlTipo.Text)
            {
                Respuesta resp = new Respuesta();
                resp.esCorrecto = false;
                resp.Mensaje = "El tipo de documento del archivo caf no es el mismo del archivo Dte.";
                resp.Detalle += string.Format("Tipo Doc. CAF {0} no es igual a tipo doc. XML {1}", cmpCafTipo.Text, cmpXmlTipo.Text);
                Respuestas.Add(resp);
            }

            ////
            //// Validacion rango minimo
            if (string.IsNullOrEmpty(cmpCafMin.Text))
            {
                Respuesta resp = new Respuesta();
                resp.esCorrecto = false;
                resp.Mensaje = "El rango minimo de folio no tiene valor.";
                Respuestas.Add(resp);

            }

            ////
            //// Validacion rango maximo
            if (string.IsNullOrEmpty(cmpCafMax.Text))
            {
                Respuesta resp = new Respuesta();
                resp.esCorrecto = false;
                resp.Mensaje = "El rango maximo de folio no tiene valor.";
                Respuestas.Add(resp);

            }

            ////
            //// Validacion folio actual
            if (string.IsNullOrEmpty(cmpXmlFolio.Text))
            {
                Respuesta resp = new Respuesta();
                resp.esCorrecto = false;
                resp.Mensaje = "El folio actual del documento no existe.";
                Respuestas.Add(resp);

            }


            ////
            //// Valide el rango de folios
            if (!string.IsNullOrEmpty(cmpCafMin.Text) && !string.IsNullOrEmpty(cmpCafMax.Text) && !string.IsNullOrEmpty(cmpXmlFolio.Text))
            {

                long lMin = long.Parse(cmpCafMin.Text);
                long lMax = long.Parse(cmpCafMax.Text);
                long lCur = long.Parse(cmpXmlFolio.Text);

                if (!(lCur >= lMin && lCur <= lMax))
                {
                    Respuesta resp = new Respuesta();
                    resp.esCorrecto = false;
                    resp.Mensaje = "El folio del documento Dte no corresponde al rango del archivo caf";
                    resp.Detalle += string.Format("Folio actual {0} no esta dentro del rango {1} - {2}", lCur, lMin, lMax);

                    Respuestas.Add(resp);

                }

            }

            ////
            //// Llame al formulario de errores
            //// solo si hay errores
            if (Respuestas.Count > 0)
            {
                Validacion val = new Validacion();
                val.respuestas = Respuestas;
                val.ShowDialog();

                return false;

            }


            ////
            //// Si no hay errores continue con el proceso.
            return Respuestas.Count > 0 ? false : true;

        }

        /// <summary>
        /// Crea el xml Envio DTE, este es el sobre con el cual 
        /// se envian los documentos al SII
        /// </summary>
        private bool CrearEnvioDte()
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
                node.InnerText = this.cmpEnvRe.Text;
                nodeCaratula.AppendChild(node);

                ////
                //// Rut envia documento
                node = xmlEnvioDTE.CreateElement("RutEnvia");
                node.InnerText = this.cmpEnvRen.Text;
                nodeCaratula.AppendChild(node);

                ////
                //// Rut Receptor
                node = xmlEnvioDTE.CreateElement("RutReceptor");
                node.InnerText = this.cmpEnvRecp.Text;
                nodeCaratula.AppendChild(node);

                ////
                //// Fecha de resolucion
                node = xmlEnvioDTE.CreateElement("FchResol");
                node.InnerText = this.cmpEnvFch.Text;
                nodeCaratula.AppendChild(node);

                ////
                //// Nro Resolucion
                node = xmlEnvioDTE.CreateElement("NroResol");
                node.InnerText = this.cmpEnvNro.Text;
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
                subNodeElement.InnerText = this.cmpXmlTipo.Text;
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
                string fullpath = "Documentos\\EnvioDte.Xml";
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
                MessageBox.Show("No fue posible construir el documento EnvioDTE", "validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                ////
                //// Regrese la valor de retorno
                return false;

            }

            ////
            //// Regrese la valor de retorno
            return true;

        }

        /// <summary>
        /// Carga los documentos del SII
        /// </summary>
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


        void Sb_CargarRuta(string RutaCAF)
        {

            ////
            //// compruebe que exista un valor
            
            if (!string.IsNullOrEmpty(RutaCAF))
            {

                string CafName = Path.GetFileName(RutaCAF);

                try
                {

                    ////
                    //// Abrir un archivo para evitar caracteres latinos erroneos
                    string sCaf = string.Empty;
                    using (StreamReader sr = new StreamReader(RutaCAF, Encoding.GetEncoding("ISO-8859-1")))
                    {
                        sCaf = sr.ReadToEnd();
                    }


                    ////
                    //// Abra el documento xml
                    XmlDocument xmlCaf = new XmlDocument();
                    xmlCaf.PreserveWhitespace = true;
                    //// xmlCaf.Load(RutaCAF);
                    xmlCaf.LoadXml(sCaf);


                    ////
                    //// Recupere el primer nodo para establecer si este
                    //// documento es un caf o no
                    string root = xmlCaf.DocumentElement.Name;
                    if (root != "AUTORIZACION")
                        throw new Exception("El documento que intenta cargar no es un archivo CAF.");



                    ////
                    //// Recupere los datos del documento
                    cmpCafName.Text = CafName;
                    cmpCafRut.Text = xmlCaf.SelectSingleNode("AUTORIZACION/CAF/DA/RE").InnerText;
                    cmpCafEmpresa.Text = xmlCaf.SelectSingleNode("AUTORIZACION/CAF/DA/RS").InnerText;
                    cmpCafTipo.Text = xmlCaf.SelectSingleNode("AUTORIZACION/CAF/DA/TD").InnerText;
                    cmpCafMin.Text = xmlCaf.SelectSingleNode("AUTORIZACION/CAF/DA/RNG/D").InnerText;
                    cmpCafMax.Text = xmlCaf.SelectSingleNode("AUTORIZACION/CAF/DA/RNG/H").InnerText;

                    ////
                    //// recupere la uri del archivo
                    this.uriCaf = RutaCAF;

                }
                catch (Exception exp)
                {

                    MessageBox.Show(exp.Message, "Validación Documento",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);

                    cmpXmlName.Text = string.Empty;
                    cmpXmlRut.Text = string.Empty;
                    cmpXmlEmisor.Text = string.Empty;
                    cmpXmlTipo.Text = string.Empty;
                    cmpXmlFolio.Text = string.Empty;

                    ////
                    //// recupere la uri del archivo
                    this.uriCaf = string.Empty;

                }



            }

        }

    }
}
