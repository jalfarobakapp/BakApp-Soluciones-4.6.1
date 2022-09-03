using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HEFESTO.CONSULTA.ESTADO.DTE.AUTENTICACION;

namespace HEFESTO.CONSULTA.ESTADO.DTE
{
    public partial class Consulta : Form
    {
        public Consulta()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Cuando Inicie el formulario
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
          
            

            ////
            //// Inicie la barra de progreso
            barrProgres.Minimum = 0;
            barrProgres.Maximum = 0;
            barrProgres.Value = 0;

            ////
            //// Cargue los certificados disponibles 
            cmbCertificados.DataSource = Negocio.Certificados.RecuperarCNs();

            ////
            //// Cree las columnas de la grilla
            listView1.Columns.Add("Nro", 30, HorizontalAlignment.Left);
            listView1.Columns.Add("Rut Rtr", 80, HorizontalAlignment.Right);
            listView1.Columns.Add("Tipo", 40, HorizontalAlignment.Center);
            listView1.Columns.Add("Folio", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Fecha", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Monto", 60, HorizontalAlignment.Right);
            listView1.Columns.Add("Estado", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("Desc.", 80, HorizontalAlignment.Left);
        }

        /// <summary>
        /// Cuando el usuario necesite cargar el archivo csv.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {

            ////
            //// Recuerde que el archivo csv continene la data necesaria para el proceso
            ////

            ////
            //// Cree la lista de entidades
            List<entDatos> lstDatos = new List<entDatos>();

            ////
            //// limpie la grilla
            listView1.Items.Clear();
            
            ////
            //// Solicite el archivo
            openFile.FileName = "";
            openFile.Filter = "Archivo Carga CSV|*.csv";

            ////
            //// Cargue el archivo
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            
                ////
                //// Recupere la fullpath del archivo a cargar
                string csvArchivo = openFile.FileName;
                if (!string.IsNullOrEmpty(csvArchivo))
                {

                    ////
                    //// Muestre nombre del archivo
                    cmpNombre.Text = Path.GetFileName(csvArchivo);

                    ////
                    //// Abra el archivo csv plano para su lectura
                    try
                    {
                        ////
                        //// Lea el archivo 
                        int indice = 0;
                        string linea = string.Empty;
                        using (StreamReader sr = new StreamReader(csvArchivo,Encoding.GetEncoding("ISO-8859-1")))
                        {
                            
                            ////
                            //// Recorra todo el archivo 
                            while (sr.Peek() != -1)
                            {
                                
                                ////
                                //// Recupere la linea
                                linea = sr.ReadLine();

                                ////
                                //// No procese la primera linea
                                if (indice > 0)
                                { 
                                    ////
                                    //// Descomponga la linea
                                    if (!string.IsNullOrEmpty(linea))
                                    {
                                        ////
                                        //// Construya los datos
                                        string[] arr = linea.Split(';');
                                        if (arr.Count() == 6)
                                        { 
                                            
                                            ////
                                            //// Recupere los datos
                                            entDatos d = new entDatos();
                                            d.indice = indice;
                                            d.RutCompania = arr[0];
                                            d.RutReceptor = arr[1].Trim();
                                            d.TipoDte = arr[2];
                                            d.Folio = arr[3];
                                            d.FechaEmisionDte = arr[4];
                                            d.MontoDte = arr[5];

                                            ////
                                            //// Normalice los datos
                                            d.FechaEmisionDte = d.FechaEmisionDte.Substring(0, 10);

                                            ////
                                            //// Parsee el rut receptor
                                            d.RutReceptor = d.RutReceptor.Replace(".", "");

                                            ////
                                            //// Cree los datos adicionales para la consulta al SII
                                            d.QueryRutConsultante = cmpRutCert.Text.Substring(0, (cmpRutCert.Text.Length) - 2);
                                            d.QueryDvConsultante = cmpRutCert.Text.Substring((cmpRutCert.Text.Length) - 1, 1);
                                            d.QueryRutCompania = d.RutCompania.Substring(0, (d.RutCompania.Length) - 2);
                                            d.QueryDvCompania = d.RutCompania.Substring((d.RutCompania.Length) - 1, 1);
                                            d.QueryRutReceptor = d.RutReceptor.Substring(0, (d.RutReceptor.Length) - 2);
                                            d.QueryDvReceptor = d.RutReceptor.Substring((d.RutReceptor.Length) - 1, 1);
                                            d.QueryFecha = d.FechaEmisionDte.Substring(8, 2) + d.FechaEmisionDte.Substring(5, 2) + d.FechaEmisionDte.Substring(0, 4);
                                            
                                            ////
                                            //// Indique el estado
                                            d.Estado = "Sin Estado";
                                            d.GlosaEstado = "Sin Desc.";

                                            ////
                                            //// Almacene el dato
                                            lstDatos.Add(d);

                                        }


                                    }
                                    
                                }

                                ////
                                //// Incremente el indice
                                indice++;
                                                            
                            }
                        

                        } //// Fin de la lectura del archivo


                        



                    }
                    catch (Exception ex)
                    {
                       
                    }

                
                }
            
            }


            ////
            //// Cargue la grilla con la informacion rescatada anteriormene
            if (lstDatos.Count > 0)
            {
                ////
                //// Cargue los datos
                foreach (entDatos dato in lstDatos)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = dato.indice.ToString();
                    lvi.SubItems.Add(dato.RutReceptor);
                    lvi.SubItems.Add(dato.TipoDte);
                    lvi.SubItems.Add(dato.Folio);
                    lvi.SubItems.Add(dato.FechaEmisionDte);
                    lvi.SubItems.Add(dato.MontoDte);
                    lvi.SubItems.Add(dato.Estado);
                    lvi.SubItems.Add(dato.GlosaEstado);
                    lvi.Tag = dato;

                    listView1.Items.Add(lvi);

                
                }
            
            }
            
        }

        /// <summary>
        /// Inicie consultas al SII
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcesar_Click(object sender, EventArgs e)
        {

            ////
            //// Valie los elementos
            if (cmbCertificados.SelectedIndex == 0 )
            {
                MessageBox.Show("Debe seleccionar un Certificado de la lista", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ////
            //// Valide los registros cargados
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("No hay registros cargados.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            ////
            //// Inicie el proceso
            try
            {

                ////
                //// Recupere el CN del Certificado
                string CN = cmbCertificados.SelectedValue.ToString();

                ////
                //// Inicie la barra de progreso
                barrProgres.Minimum = 0;
                barrProgres.Maximum = listView1.Items.Count;
                barrProgres.Value = 0;


                ////
                //// Inicie la lectura de los datos a procesar
                int valorProgreso = 1;
                foreach (ListViewItem item in listView1.Items)
                {
 
                    ////
                    //// 
                    item.SubItems[7].Text = "Procesando..";
                    listView1.Refresh();

                    ////
                    //// Ejecute la consulta contra el SII
                    ConsultarDatos(item);
                    
                    ////
                    //// Refresque la grilla
                    listView1.Refresh();
                
                    ////
                    //// Incremente valor Progreso
                    valorProgreso++;
                    barrProgres.Value = valorProgreso;


                }

            }
            catch 
            {
                
                
            }

            ////
            //// Inicie la barra de progreso
            barrProgres.Minimum = 0;
            barrProgres.Maximum = 0;
            barrProgres.Value = 0;


            ////
            //// fin del proceso
            MessageBox.Show("Fin del proceso..","Fin Proceso",MessageBoxButtons.OK,MessageBoxIcon.Error);


        }

        /// <summary>
        /// Cuando el usuario quiera ver el detalle de la operacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DoubleClick(object sender, EventArgs e)
        {

            entDatos d = (entDatos)listView1.Items[listView1.SelectedIndices[0]].Tag;
            cmpDetalle.Text = string.Format("{0}\r\n{1}\r\n{2}", d.Estado, d.GlosaEstado, d.GlosaError);


        }

        /// <summary>
        /// Cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Realiza la consulta unitaria de los documentos
        /// </summary>
        private void ConsultarDatos(ListViewItem item)
        {

            ////
            //// Valie los elementos
            if (cmbCertificados.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar un Certificado de la lista",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ////
            //// Recupere el CN del Certificado
            string CN = cmbCertificados.SelectedValue.ToString();

            ////
            //// Recupere el token
            entDatos datos = (entDatos)item.Tag;

            ////
            //// Inicie el proceso de recuperar token contra el SII.
            ConectarseSII cSii = new ConectarseSII();
            cSii.CN = CN;
            cSii.Ambiente = SIIAmbiente.Produccion;

            Respuesta resp = cSii.Login();
            if (!resp.EsCorrecto)
            {
                item.SubItems[7].Text = resp.Mensaje;
                listView1.Refresh();
                return;
            }

            ////
            //// Actualice el valor
            item.SubItems[7].Text = resp.Resultado.ToString();
            datos.Token = resp.Resultado.ToString();

            ////
            //// Consulte el estado del Dte
            RespuestaQuery rq = ConsultaEstado.ConsultaEstadoDte(datos);
            item.SubItems[6].Text = rq.Estado;
            item.SubItems[7].Text = rq.GlosaEstado;

            ////
            //// Actualice los datos de la entidad Datos
            datos.Estado = rq.Estado;
            datos.GlosaEstado = rq.GlosaEstado;
            datos.GlosaError = rq.GlosaError;

            ////
            //// Acutualice la entidad con los nuevos datos
            item.Tag = datos;
        
        }


        /// <summary>
        /// Consulta el estado del documento unitariamente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ////
            //// Inicie el procesamiento solo si existe una seleccion
            if (listView1.SelectedIndices.Count == 1 )
            {
                ////
                //// Recupere el item seleccionado
                ListViewItem lvi = listView1.Items[listView1.SelectedIndices[0]];
            
                ////
                //// Consulte el dato
                ConsultarDatos(lvi);

            }

        }

       
    }
}
