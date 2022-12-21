using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using HEFESTO.DTE.AUTENTICACION;
using HEFESTO.DTE.AUTENTICACION.ENT;
using System.Diagnostics;

namespace HEFESTO.ENVIO.SETDTE.FORM
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

 


        /// <summary>
        /// Cuando inicia el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmInicio_Load(object sender, EventArgs e)
        {

            cmbCertificados.DataSource = Negocio.ListaDeCertificados();


        }

        /// <summary>
        /// Permite seleccionar un archivo xml para ser enviado al SII
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {


            ////
            //// Limpie los campos del formulario
            cmpNombreArchivo.Text = string.Empty;
            cmpRutEmisor.Text = string.Empty;
            cmpRutEnvia.Text = string.Empty;
            cmpTrackID.Text = string.Empty;
            radioButton1.Checked = true;
            radioButton2.Checked = false;

            ////
            //// Inicie la seleccion del archivo
            openFile.Title = "Seleccione el archivo xml a enviar al SII.";
            openFile.FileName = string.Empty;
            openFile.Filter = "Documentos xml|*xml";

            ////
            //// Procese el archivo
            try
            {

                ////
                //// Si el usuario realizo una seleccion
                if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ////
                    //// Recupere el fullpath del archivo
                    string fileName = openFile.FileName;
                    if (!string.IsNullOrEmpty(fileName))
                    {

                        ////
                        //// Muestre informacion del nombre del archivo
                        cmpNombreArchivo.Text = fileName;
 
                        ////
                        //// Abra el archivo xml para extraer los datos necesarios
                        XmlDocument xmlDocumento = new XmlDocument();
                        xmlDocumento.PreserveWhitespace = true;
                        xmlDocumento.Load(fileName);

                        ////
                        //// Recupere el rut del enviador del documento.
                        //// Revisar los siguientes tag
                        //// - RutEnvia
                        //// - RutEmisorLibro
                        List<string> lRutEmisor = new List<string>();
                        XmlNodeList XmlRutEmisor = xmlDocumento.GetElementsByTagName("RutEmisor", xmlDocumento.DocumentElement.NamespaceURI);
                        XmlNodeList XmlRutEmisorLibro = xmlDocumento.GetElementsByTagName("RutEmisorLibro", xmlDocumento.DocumentElement.NamespaceURI);

                        if (XmlRutEmisor != null && XmlRutEmisor.Count > 0)
                            lRutEmisor.Add(XmlRutEmisor[0].InnerText);  
                        if (XmlRutEmisorLibro != null && XmlRutEmisorLibro.Count > 0)
                            lRutEmisor.Add(XmlRutEmisorLibro[0].InnerText);
                        
                        ////
                        //// Recupere el rut emisor del documento.
                        XmlNodeList XmlRutEnvia = xmlDocumento.GetElementsByTagName("RutEnvia", xmlDocumento.DocumentElement.NamespaceURI);
                        
                        ////
                        //// Encontró información.
                        bool error = false;
                        string MensajeError = "No pudimos encontrar la siguiente información:\r\n";
                        if (lRutEmisor == null || lRutEmisor.Count == 0)
                        {
                            MensajeError += "- Rut de la empresa emisora del documento.\r\n";
                            error = true;
                        }

                        if (XmlRutEnvia == null || XmlRutEnvia.Count == 0)
                        {
                            MensajeError += "- Rut del certificado digital.\r\n";
                            error = true;
                        }
                        
                        ////
                        //// Complete el mensaje de error
                        MensajeError += "Favor verificar su archivo xml.";

                        ////
                        //// Muestre el error si es necesario
                        if (error)
                            throw new Exception(MensajeError);


                        ////
                        //// Valide los datos.
                        if (lRutEmisor.Count > 0)
                            cmpRutEmisor.Text = lRutEmisor[0].ToString();

                        ////
                        //// Valide los datos.
                        if (XmlRutEnvia.Count > 0)
                            cmpRutEnvia.Text = XmlRutEnvia[0].InnerText;

                    }
                
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error del proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Salir de la app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        /// <summary>
        /// Inicie el procesamiento del envio
        /// </summary>
        private void btnEnviarSII_Click(object sender, EventArgs e)
        {

            #region VALIDA EL FORMULARIO

            ////
            //// Valide que existan todos los elementos necesarios
            if (cmbCertificados.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un certificado.",
                    "Validacion certificado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;

            }

            ////
            //// Valide el nombre del archivo
            if (string.IsNullOrEmpty(cmpNombreArchivo.Text))
            {
                MessageBox.Show("Debe Seleccionar un archivo XML.",
                    "Validacion archivo XML",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;

            }

            ////
            //// Valide el nombre del archivo
            if (string.IsNullOrEmpty(cmpRutEmisor.Text))
            {
                MessageBox.Show("Debe Seleccionar un rut emisor.",
                    "Validacion rut emisor",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;

            }

            ////
            //// Valide el nombre del archivo
            if (string.IsNullOrEmpty(cmpRutEnvia.Text))
            {
                MessageBox.Show("Debe Seleccionar un rut enviador.",
                    "Validacion rut enviador",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;

            }

            #endregion

            #region RECUPERACION DE PARAMETROS NECESARIOS PARA EL ENVIO

            ////
            //// Recupere el nombre del dueño del certificado
            string paramCN = cmbCertificados.SelectedValue.ToString();

            ////
            //// En que ambiente procesar
            SIIAmbiente paramAmbiente = SIIAmbiente.Certificacion;
            if (radioButton1.Checked)
                paramAmbiente = SIIAmbiente.Certificacion;
            if (radioButton2.Checked)
                paramAmbiente = SIIAmbiente.Produccion;

            ////
            //// Defina el fullpath del archivo a enviar
            string paramArchivo = cmpNombreArchivo.Text;

            ////
            //// Datos del emisor del documento
            string paramRutEmisorB = cmpRutEmisor.Text.Split('-')[0];
            string paramRutEmisorD = cmpRutEmisor.Text.Split('-')[1];
            string paramRutEnviaB = cmpRutEnvia.Text.Split('-')[0];
            string paramRutEnviaD = cmpRutEnvia.Text.Split('-')[1];
            
            #endregion

            

            ////
            //// AUTENTICACION
            //// Necesita Nombre del certificado y ambiente a donde consultar
            Respuesta respuesta = LOGIN.Conectar(paramCN, paramAmbiente);
            if (respuesta.correcto)
            {

                ////
                //// Recupere el TOKEN del proceo anterior
                string paramToken = (string)respuesta.Resultado;

                ////
                //// Envie los documentos
                Respuesta respuestaEnvio = HEFESTO.DTE.AUTENTICACION.ENVIO.EnviarArchivoSII(
                    paramArchivo,
                    paramToken,
                    paramRutEnviaB,
                    paramRutEnviaD,
                    paramRutEmisorB,
                    paramRutEmisorD,
                    paramAmbiente
                    );
                

                ////
                //// Inicie la respuesta del proceso
                if (respuestaEnvio.correcto)
                { 
                
                    ////
                    //// Recupere el valor del Token y muestrelo al usuario
                    cmpTrackID.Text = respuestaEnvio.Resultado.ToString();
                
                }
                                
            }

        }

        /// <summary>
        /// Redirigir a blog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://lenguajedemaquinas.blogspot.com/2013/05/ejemplo-timbre-electronico-del-dte.html");
            Process.Start(sInfo);
        }

    }

}
