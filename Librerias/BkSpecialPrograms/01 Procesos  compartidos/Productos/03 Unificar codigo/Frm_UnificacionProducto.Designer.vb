<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_UnificacionProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_UnificacionProducto))
        Me.TxtDescripcionDestino = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCodigoDestino = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrupoDestino = New System.Windows.Forms.GroupBox()
        Me.TxtUd1Destino = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtUd2Destino = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtRtuDestino = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Unificar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnLimpiarCodigo = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnAgregarCodigo = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnLimpiarGrilla = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnImportarProductos = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCancelarImp = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCrearProductos = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCreaProducClassic = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCreaProducMatriz = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GrillaProductosCambiar = New System.Windows.Forms.DataGridView()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.ChkPasarDifRTU = New System.Windows.Forms.CheckBox()
        Me.ChkNoPreguntar = New System.Windows.Forms.CheckBox()
        Me.OFile_BuscarArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.LblEstadoImp = New System.Windows.Forms.Label()
        Me.Progreso_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.GrupoDestino.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GrillaProductosCambiar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtDescripcionDestino
        '
        Me.TxtDescripcionDestino.BackColor = System.Drawing.Color.White
        Me.TxtDescripcionDestino.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtDescripcionDestino, True)
        Me.TxtDescripcionDestino.Location = New System.Drawing.Point(139, 34)
        Me.TxtDescripcionDestino.Name = "TxtDescripcionDestino"
        Me.TxtDescripcionDestino.Size = New System.Drawing.Size(429, 22)
        Me.TxtDescripcionDestino.TabIndex = 7
        Me.TxtDescripcionDestino.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(136, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Descripción"
        '
        'TxtCodigoDestino
        '
        Me.TxtCodigoDestino.BackColor = System.Drawing.Color.White
        Me.TxtCodigoDestino.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtCodigoDestino, True)
        Me.TxtCodigoDestino.Location = New System.Drawing.Point(10, 34)
        Me.TxtCodigoDestino.Name = "TxtCodigoDestino"
        Me.TxtCodigoDestino.Size = New System.Drawing.Size(125, 22)
        Me.TxtCodigoDestino.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Código"
        '
        'GrupoDestino
        '
        Me.GrupoDestino.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GrupoDestino.Controls.Add(Me.TxtUd1Destino)
        Me.GrupoDestino.Controls.Add(Me.Label7)
        Me.GrupoDestino.Controls.Add(Me.TxtUd2Destino)
        Me.GrupoDestino.Controls.Add(Me.Label6)
        Me.GrupoDestino.Controls.Add(Me.TxtRtuDestino)
        Me.GrupoDestino.Controls.Add(Me.Label14)
        Me.GrupoDestino.Controls.Add(Me.Label1)
        Me.GrupoDestino.Controls.Add(Me.TxtDescripcionDestino)
        Me.GrupoDestino.Controls.Add(Me.TxtCodigoDestino)
        Me.GrupoDestino.Controls.Add(Me.Label2)
        Me.GrupoDestino.ForeColor = System.Drawing.Color.Black
        Me.GrupoDestino.Location = New System.Drawing.Point(3, 12)
        Me.GrupoDestino.Name = "GrupoDestino"
        Me.GrupoDestino.Size = New System.Drawing.Size(729, 67)
        Me.GrupoDestino.TabIndex = 8
        Me.GrupoDestino.TabStop = False
        Me.GrupoDestino.Text = "Código de destino"
        '
        'TxtUd1Destino
        '
        Me.TxtUd1Destino.BackColor = System.Drawing.Color.White
        Me.TxtUd1Destino.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtUd1Destino, True)
        Me.TxtUd1Destino.Location = New System.Drawing.Point(571, 34)
        Me.TxtUd1Destino.Name = "TxtUd1Destino"
        Me.TxtUd1Destino.Size = New System.Drawing.Size(46, 22)
        Me.TxtUd1Destino.TabIndex = 36
        Me.TxtUd1Destino.TabStop = False
        Me.TxtUd1Destino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(568, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "UD1"
        '
        'TxtUd2Destino
        '
        Me.TxtUd2Destino.BackColor = System.Drawing.Color.White
        Me.TxtUd2Destino.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtUd2Destino, True)
        Me.TxtUd2Destino.Location = New System.Drawing.Point(623, 34)
        Me.TxtUd2Destino.Name = "TxtUd2Destino"
        Me.TxtUd2Destino.Size = New System.Drawing.Size(46, 22)
        Me.TxtUd2Destino.TabIndex = 34
        Me.TxtUd2Destino.TabStop = False
        Me.TxtUd2Destino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(620, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "UD2"
        '
        'TxtRtuDestino
        '
        Me.TxtRtuDestino.BackColor = System.Drawing.Color.White
        Me.TxtRtuDestino.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtRtuDestino, True)
        Me.TxtRtuDestino.Location = New System.Drawing.Point(675, 34)
        Me.TxtRtuDestino.Name = "TxtRtuDestino"
        Me.TxtRtuDestino.Size = New System.Drawing.Size(46, 22)
        Me.TxtRtuDestino.TabIndex = 32
        Me.TxtRtuDestino.TabStop = False
        Me.TxtRtuDestino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(672, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 13)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "R.T.U."
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Unificar, Me.BtnLimpiarCodigo, Me.BtnAgregarCodigo, Me.BtnLimpiarGrilla, Me.BtnImportarProductos, Me.BtnCancelarImp, Me.BtnCrearProductos})
        Me.Bar1.Location = New System.Drawing.Point(0, 354)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(738, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 10
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Unificar
        '
        Me.Unificar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Unificar.ForeColor = System.Drawing.Color.Black
        Me.Unificar.Image = CType(resources.GetObject("Unificar.Image"), System.Drawing.Image)
        Me.Unificar.Name = "Unificar"
        Me.Unificar.Text = "Procesar..."
        '
        'BtnLimpiarCodigo
        '
        Me.BtnLimpiarCodigo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnLimpiarCodigo.ForeColor = System.Drawing.Color.Black
        Me.BtnLimpiarCodigo.Image = CType(resources.GetObject("BtnLimpiarCodigo.Image"), System.Drawing.Image)
        Me.BtnLimpiarCodigo.Name = "BtnLimpiarCodigo"
        Me.BtnLimpiarCodigo.Tooltip = "Limpiar todo"
        '
        'BtnAgregarCodigo
        '
        Me.BtnAgregarCodigo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAgregarCodigo.ForeColor = System.Drawing.Color.Black
        Me.BtnAgregarCodigo.Image = CType(resources.GetObject("BtnAgregarCodigo.Image"), System.Drawing.Image)
        Me.BtnAgregarCodigo.Name = "BtnAgregarCodigo"
        Me.BtnAgregarCodigo.Tooltip = "Agregar código a la lista"
        '
        'BtnLimpiarGrilla
        '
        Me.BtnLimpiarGrilla.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnLimpiarGrilla.ForeColor = System.Drawing.Color.Black
        Me.BtnLimpiarGrilla.Image = CType(resources.GetObject("BtnLimpiarGrilla.Image"), System.Drawing.Image)
        Me.BtnLimpiarGrilla.Name = "BtnLimpiarGrilla"
        Me.BtnLimpiarGrilla.Tooltip = "Limpiar grilla"
        '
        'BtnImportarProductos
        '
        Me.BtnImportarProductos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnImportarProductos.ForeColor = System.Drawing.Color.Black
        Me.BtnImportarProductos.Image = CType(resources.GetObject("BtnImportarProductos.Image"), System.Drawing.Image)
        Me.BtnImportarProductos.Name = "BtnImportarProductos"
        Me.BtnImportarProductos.Tooltip = "Importar productos desde archivo Excel"
        '
        'BtnCancelarImp
        '
        Me.BtnCancelarImp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancelarImp.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelarImp.Image = CType(resources.GetObject("BtnCancelarImp.Image"), System.Drawing.Image)
        Me.BtnCancelarImp.Name = "BtnCancelarImp"
        Me.BtnCancelarImp.Text = "Cancelar"
        Me.BtnCancelarImp.Tooltip = "Importar productos desde archivo Excel"
        Me.BtnCancelarImp.Visible = False
        '
        'BtnCrearProductos
        '
        Me.BtnCrearProductos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCrearProductos.ForeColor = System.Drawing.Color.Black
        Me.BtnCrearProductos.Image = CType(resources.GetObject("BtnCrearProductos.Image"), System.Drawing.Image)
        Me.BtnCrearProductos.Name = "BtnCrearProductos"
        Me.BtnCrearProductos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnCreaProducClassic, Me.BtnCreaProducMatriz})
        Me.BtnCrearProductos.Text = "Crear producto..."
        Me.BtnCrearProductos.Tooltip = "Limpiar grilla"
        '
        'BtnCreaProducClassic
        '
        Me.BtnCreaProducClassic.Name = "BtnCreaProducClassic"
        Me.BtnCreaProducClassic.Text = "Asistente clásico"
        '
        'BtnCreaProducMatriz
        '
        Me.BtnCreaProducMatriz.Name = "BtnCreaProducMatriz"
        Me.BtnCreaProducMatriz.Text = "Desde Matriz"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.GrillaProductosCambiar)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(3, 121)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(729, 224)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Productos de origen"
        '
        'GrillaProductosCambiar
        '
        Me.GrillaProductosCambiar.AllowUserToAddRows = False
        Me.GrillaProductosCambiar.AllowUserToDeleteRows = False
        Me.GrillaProductosCambiar.BackgroundColor = System.Drawing.Color.White
        Me.GrillaProductosCambiar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaProductosCambiar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrillaProductosCambiar.Location = New System.Drawing.Point(3, 18)
        Me.GrillaProductosCambiar.Name = "GrillaProductosCambiar"
        Me.GrillaProductosCambiar.ReadOnly = True
        Me.GrillaProductosCambiar.Size = New System.Drawing.Size(723, 203)
        Me.GrillaProductosCambiar.TabIndex = 0
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'ChkPasarDifRTU
        '
        Me.ChkPasarDifRTU.AutoSize = True
        Me.ChkPasarDifRTU.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ChkPasarDifRTU.ForeColor = System.Drawing.Color.Black
        Me.ChkPasarDifRTU.Location = New System.Drawing.Point(6, 98)
        Me.ChkPasarDifRTU.Name = "ChkPasarDifRTU"
        Me.ChkPasarDifRTU.Size = New System.Drawing.Size(207, 17)
        Me.ChkPasarDifRTU.TabIndex = 37
        Me.ChkPasarDifRTU.Text = "Desactivar razón de transformación"
        Me.ChkPasarDifRTU.UseVisualStyleBackColor = False
        '
        'ChkNoPreguntar
        '
        Me.ChkNoPreguntar.AutoSize = True
        Me.ChkNoPreguntar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ChkNoPreguntar.ForeColor = System.Drawing.Color.Black
        Me.ChkNoPreguntar.Location = New System.Drawing.Point(219, 98)
        Me.ChkNoPreguntar.Name = "ChkNoPreguntar"
        Me.ChkNoPreguntar.Size = New System.Drawing.Size(198, 17)
        Me.ChkNoPreguntar.TabIndex = 38
        Me.ChkNoPreguntar.Text = "Reemplazar todo, sin preguntar..."
        Me.ChkNoPreguntar.UseVisualStyleBackColor = False
        '
        'OFile_BuscarArchivo
        '
        Me.OFile_BuscarArchivo.FileName = "OpenFileDialog1"
        '
        'LblEstadoImp
        '
        Me.LblEstadoImp.AutoSize = True
        Me.LblEstadoImp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblEstadoImp.ForeColor = System.Drawing.Color.Black
        Me.LblEstadoImp.Location = New System.Drawing.Point(502, 102)
        Me.LblEstadoImp.Name = "LblEstadoImp"
        Me.LblEstadoImp.Size = New System.Drawing.Size(40, 13)
        Me.LblEstadoImp.TabIndex = 40
        Me.LblEstadoImp.Text = "Label3"
        Me.LblEstadoImp.Visible = False
        '
        'Progreso_Porc
        '
        Me.Progreso_Porc.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Progreso_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Porc.Location = New System.Drawing.Point(423, 85)
        Me.Progreso_Porc.Name = "Progreso_Porc"
        Me.Progreso_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Porc.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Porc.ProgressTextVisible = True
        Me.Progreso_Porc.Size = New System.Drawing.Size(73, 41)
        Me.Progreso_Porc.SpokeBorderLight = System.Drawing.Color.Transparent
        Me.Progreso_Porc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Porc.TabIndex = 41
        Me.Progreso_Porc.Visible = False
        '
        'Frm_UnificacionProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 395)
        Me.Controls.Add(Me.Progreso_Porc)
        Me.Controls.Add(Me.LblEstadoImp)
        Me.Controls.Add(Me.ChkNoPreguntar)
        Me.Controls.Add(Me.ChkPasarDifRTU)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GrupoDestino)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_UnificacionProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ASISTENTE DE UNIFICACION DE CODIGOS"
        Me.GrupoDestino.ResumeLayout(False)
        Me.GrupoDestino.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GrillaProductosCambiar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TxtDescripcionDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents TxtCodigoDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrupoDestino As System.Windows.Forms.GroupBox
    Public WithEvents TxtRtuDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents TxtUd1Destino As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents TxtUd2Destino As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Unificar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnAgregarCodigo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GrillaProductosCambiar As System.Windows.Forms.DataGridView
    Friend WithEvents BtnLimpiarCodigo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnLimpiarGrilla As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents BtnCrearProductos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCreaProducClassic As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCreaProducMatriz As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ChkPasarDifRTU As System.Windows.Forms.CheckBox
    Friend WithEvents ChkNoPreguntar As System.Windows.Forms.CheckBox
    Friend WithEvents BtnImportarProductos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents OFile_BuscarArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents LblEstadoImp As System.Windows.Forms.Label
    Friend WithEvents BtnCancelarImp As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.Controls.CircularProgress
End Class
