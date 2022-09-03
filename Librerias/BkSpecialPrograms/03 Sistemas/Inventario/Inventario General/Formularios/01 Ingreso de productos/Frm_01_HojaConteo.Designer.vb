<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_01_HojaConteo
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_01_HojaConteo))
        Me.GrupoDet = New System.Windows.Forms.GroupBox
        Me.CirculoProgreso = New DevComponents.DotNetBar.Controls.CircularProgress
        Me.Grilla_Inv = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BtnMnuBuscarProducto = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BtnMnuIncorpProductoDesconocido = New System.Windows.Forms.ToolStripMenuItem
        Me.BtnMnuCambiarDescProductoDesconocido = New System.Windows.Forms.ToolStripMenuItem
        Me.GrupoEnc = New System.Windows.Forms.GroupBox
        Me.Grilla_Enc = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnLimpiar = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem
        Me.BtnImportarDatos = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCancelarImp = New DevComponents.DotNetBar.ButtonItem
        Me.Lblestado = New DevComponents.DotNetBar.LabelItem
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.OFile_BuscarArchivo = New System.Windows.Forms.OpenFileDialog
        Me.GrupoDet.SuspendLayout()
        CType(Me.Grilla_Inv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GrupoEnc.SuspendLayout()
        CType(Me.Grilla_Enc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrupoDet
        '
        Me.GrupoDet.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GrupoDet.Controls.Add(Me.CirculoProgreso)
        Me.GrupoDet.Controls.Add(Me.Grilla_Inv)
        Me.GrupoDet.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GrupoDet.ForeColor = System.Drawing.Color.Black
        Me.GrupoDet.Location = New System.Drawing.Point(6, 108)
        Me.GrupoDet.Name = "GrupoDet"
        Me.GrupoDet.Size = New System.Drawing.Size(805, 409)
        Me.GrupoDet.TabIndex = 7
        Me.GrupoDet.TabStop = False
        Me.GrupoDet.Text = "Detalle del documento"
        '
        'CirculoProgreso
        '
        Me.CirculoProgreso.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CirculoProgreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CirculoProgreso.Location = New System.Drawing.Point(323, 126)
        Me.CirculoProgreso.Name = "CirculoProgreso"
        Me.CirculoProgreso.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.CirculoProgreso.ProgressColor = System.Drawing.Color.SteelBlue
        Me.CirculoProgreso.ProgressTextVisible = True
        Me.CirculoProgreso.Size = New System.Drawing.Size(177, 125)
        Me.CirculoProgreso.SpokeBorderLight = System.Drawing.Color.Transparent
        Me.CirculoProgreso.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CirculoProgreso.TabIndex = 46
        Me.CirculoProgreso.Visible = False
        '
        'Grilla_Inv
        '
        Me.Grilla_Inv.AllowUserToAddRows = False
        Me.Grilla_Inv.AllowUserToDeleteRows = False
        Me.Grilla_Inv.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Inv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Inv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla_Inv.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Inv.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Inv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Inv.EnableHeadersVisualStyles = False
        Me.Grilla_Inv.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Inv.Location = New System.Drawing.Point(3, 23)
        Me.Grilla_Inv.Name = "Grilla_Inv"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Inv.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Inv.Size = New System.Drawing.Size(799, 383)
        Me.Grilla_Inv.StandardTab = True
        Me.Grilla_Inv.TabIndex = 27
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnMnuBuscarProducto, Me.ToolStripSeparator1, Me.BtnMnuIncorpProductoDesconocido, Me.BtnMnuCambiarDescProductoDesconocido})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(365, 76)
        '
        'BtnMnuBuscarProducto
        '
        Me.BtnMnuBuscarProducto.Name = "BtnMnuBuscarProducto"
        Me.BtnMnuBuscarProducto.Size = New System.Drawing.Size(364, 22)
        Me.BtnMnuBuscarProducto.Text = "Buscar producto"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(361, 6)
        '
        'BtnMnuIncorpProductoDesconocido
        '
        Me.BtnMnuIncorpProductoDesconocido.Name = "BtnMnuIncorpProductoDesconocido"
        Me.BtnMnuIncorpProductoDesconocido.Size = New System.Drawing.Size(364, 22)
        Me.BtnMnuIncorpProductoDesconocido.Text = "Incorporar producto desconocido"
        '
        'BtnMnuCambiarDescProductoDesconocido
        '
        Me.BtnMnuCambiarDescProductoDesconocido.Name = "BtnMnuCambiarDescProductoDesconocido"
        Me.BtnMnuCambiarDescProductoDesconocido.Size = New System.Drawing.Size(364, 22)
        Me.BtnMnuCambiarDescProductoDesconocido.Text = "Cambiar descripción del producto (Solo desconocidos)"
        '
        'GrupoEnc
        '
        Me.GrupoEnc.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GrupoEnc.Controls.Add(Me.Grilla_Enc)
        Me.GrupoEnc.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrupoEnc.ForeColor = System.Drawing.Color.Black
        Me.GrupoEnc.Location = New System.Drawing.Point(6, 7)
        Me.GrupoEnc.Name = "GrupoEnc"
        Me.GrupoEnc.Size = New System.Drawing.Size(805, 95)
        Me.GrupoEnc.TabIndex = 43
        Me.GrupoEnc.TabStop = False
        Me.GrupoEnc.Text = "Encabezado de documento"
        '
        'Grilla_Enc
        '
        Me.Grilla_Enc.AllowUserToAddRows = False
        Me.Grilla_Enc.AllowUserToDeleteRows = False
        Me.Grilla_Enc.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Enc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Enc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Enc.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Enc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Enc.EnableHeadersVisualStyles = False
        Me.Grilla_Enc.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Enc.Location = New System.Drawing.Point(3, 23)
        Me.Grilla_Enc.Name = "Grilla_Enc"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Enc.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Enc.Size = New System.Drawing.Size(799, 69)
        Me.Grilla_Enc.StandardTab = True
        Me.Grilla_Enc.TabIndex = 28
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar, Me.BtnLimpiar, Me.ButtonItem1, Me.BtnImportarDatos, Me.BtnCancelarImp, Me.Lblestado, Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 539)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(815, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 44
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = Global.BkSpecialPrograms.My.Resources.Resources.save
        Me.BtnGrabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Tooltip = "Grabar"
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnLimpiar.ForeColor = System.Drawing.Color.Black
        Me.BtnLimpiar.Image = Global.BkSpecialPrograms.My.Resources.Resources.document
        Me.BtnLimpiar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Tooltip = "Grabar"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.ForeColor = System.Drawing.Color.Black
        Me.ButtonItem1.Image = Global.BkSpecialPrograms.My.Resources.Resources.document
        Me.ButtonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Tooltip = "BUSCAR DOC..."
        Me.ButtonItem1.Visible = False
        '
        'BtnImportarDatos
        '
        Me.BtnImportarDatos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnImportarDatos.ForeColor = System.Drawing.Color.Black
        Me.BtnImportarDatos.Image = Global.BkSpecialPrograms.My.Resources.Resources.import_from_excel1
        Me.BtnImportarDatos.Name = "BtnImportarDatos"
        Me.BtnImportarDatos.Text = "Importar datos desde archivo Excel"
        '
        'BtnCancelarImp
        '
        Me.BtnCancelarImp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancelarImp.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelarImp.Image = Global.BkSpecialPrograms.My.Resources.Resources.cancel1
        Me.BtnCancelarImp.Name = "BtnCancelarImp"
        Me.BtnCancelarImp.Text = "Cancelar"
        Me.BtnCancelarImp.Tooltip = "Importar productos desde archivo Excel"
        Me.BtnCancelarImp.Visible = False
        '
        'Lblestado
        '
        Me.Lblestado.ForeColor = System.Drawing.Color.Navy
        Me.Lblestado.Name = "Lblestado"
        Me.Lblestado.Text = "LabelItem1"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = Global.BkSpecialPrograms.My.Resources.Resources.button_rounded_red_delete
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        '
        'OFile_BuscarArchivo
        '
        Me.OFile_BuscarArchivo.FileName = "OpenFileDialog1"
        '
        'Frm_01_HojaConteo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 580)
        Me.ControlBox = False
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GrupoEnc)
        Me.Controls.Add(Me.GrupoDet)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_01_HojaConteo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INGRESO DE HOJA PARA TOMA DE INVENTARIO"
        Me.GrupoDet.ResumeLayout(False)
        CType(Me.Grilla_Inv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GrupoEnc.ResumeLayout(False)
        CType(Me.Grilla_Enc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrupoDet As System.Windows.Forms.GroupBox
    Friend WithEvents Grilla_Inv As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GrupoEnc As System.Windows.Forms.GroupBox
    Friend WithEvents Grilla_Enc As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnLimpiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnImportarDatos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents OFile_BuscarArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCancelarImp As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents CirculoProgreso As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BtnMnuIncorpProductoDesconocido As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnMnuCambiarDescProductoDesconocido As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnMnuBuscarProducto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Lblestado As DevComponents.DotNetBar.LabelItem
End Class
