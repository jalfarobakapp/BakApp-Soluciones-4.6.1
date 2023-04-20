using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HEFESTO.FIRMA.DOC.FORM
{
    public partial class Validacion : Form
    {

        /// <summary>
        /// Lista de errores encontrados
        /// </summary>
        public List<Respuesta> respuestas { get; set; }

        /// <summary>
        /// lista de errores
        /// </summary>
        public string errores { get; set; }


        public Validacion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cuando se cargue el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Validacion_Load(object sender, EventArgs e)
        {

            ////
            //// Cree las columnas de la grilla
            listView1.Columns.Add("Est", 30   , HorizontalAlignment.Center);
            listView1.Columns.Add("Mensaje",380 , HorizontalAlignment.Left);

            ////
            //// Cargue el formulario
            if (this.respuestas != null)
            {
                foreach (Respuesta resp in this.respuestas)
                {
                    ListViewItem item = new ListViewItem("");
                    item.ImageIndex = 0;
                    item.SubItems.Add(resp.Mensaje);
                    listView1.Items.Add(item);
                    item.Tag = resp.Mensaje + "\r\n" + resp.Detalle;
                }
            }
            

            ////
            //// Cargue el formulario
            if ( !string.IsNullOrEmpty( this.errores ) )
            {
                foreach (string err in this.errores.Split(';'))
                {
                    if (!string.IsNullOrEmpty(err))
                    {
                        ListViewItem item = new ListViewItem("");
                        item.ImageIndex = 0;
                        item.SubItems.Add(err);
                        listView1.Items.Add(item);

                        item.Tag = err;
                    }
                    
                }
            }
            

        }

        /// <summary>
        /// Cierre el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Muestre el detalle del error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                cmpDetalle.Text = listView1.Items[listView1.FocusedItem.Index].Tag.ToString();
            }

        }

       
    }
}
