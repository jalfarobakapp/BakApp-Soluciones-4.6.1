using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace HEFESTO.CONSULTA.TRACKID
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

            ////
            //// Recupere la lista de certificados disponobles
            List<string> cns = Negocio.Certificados.RecuperarCNs();
            listCNS.DataSource = cns;


        }


        /// <summary>
        /// Recupera el resultado del trackid suministrado por el SII
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            ////
            //// Limpie el campo de resultado
            cmpResultado.Text = string.Empty;

            ////
            //// Recupere el ambiente dondeconsultar
            SIIAmbiente ambiente = SIIAmbiente.Certificacion;
            if (chkAmbiente.Checked)
                ambiente = SIIAmbiente.Produccion;


            ////
            //// Recupere el cn seleccionado por el usuario
            string sCN = listCNS.SelectedItem.ToString();
            if (listCNS.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar un certificado", "Velidacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            ////
            //// Recuupere el certificado utilizando la informacion de la empresa
            X509Certificate2 certificado= Negocio.Certificados.RecuperarCertificado(sCN);
            if (certificado==null)
            {
                MessageBox.Show("No se encuentra el certificado","Velidacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ////
            //// Cree la consulta del trackid
            //// Ojo:SIIAmbiente.Certificacion
            //// Ojo:SIIAmbiente.Produccion     Cambiar segun sea el caso. Parametro de la funcion.
            Respuesta resp = Negocio.EnvioSII.ConsultarTrackId(cmpRut.Text, certificado, cmpTrackID.Text, ambiente);
            if (resp.EsCorrecto)
                cmpResultado.Text = ((entRespuestaDTE)resp.Resultado).Glosa;
            else
                MessageBox.Show(resp.Mensaje, "Error captura de respuesta del SII.", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


    }


}
