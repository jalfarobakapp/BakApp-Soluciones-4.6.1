<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MTS_Actualizar_Lista_Proceso_Manual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MTS_Actualizar_Lista_Proceso_Manual))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Fecha_desde = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Fecha_hasta = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnActualizarInformacion = New DevComponents.DotNetBar.ButtonItem
        Me.BtnBuscarEntidad = New DevComponents.DotNetBar.ButtonItem
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.TxtNomLista = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.BtnListaCostos = New DevComponents.DotNetBar.ButtonX
        Me.TxtCodLista = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.TxtArchivoDescuentos = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.TxtRutaArchivosDBF = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.BtnRutaDirectorio = New DevComponents.DotNetBar.ButtonX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.Dir_Buscar = New System.Windows.Forms.FolderBrowserDialog
        Me.Chk_Fecha = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Chk_Proveedor = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.TxtProveedor = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.Chk_GuardarConDsctos = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.GroupBox1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Fecha_desde)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Fecha_hasta)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(304, 55)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rango de fechas a estudiar"
        '
        'Fecha_desde
        '
        Me.Fecha_desde.BackColor = System.Drawing.Color.White
        Me.Fecha_desde.ForeColor = System.Drawing.Color.Black
        Me.Fecha_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fecha_desde.Location = New System.Drawing.Point(55, 21)
        Me.Fecha_desde.Name = "Fecha_desde"
        Me.Fecha_desde.Size = New System.Drawing.Size(82, 22)
        Me.Fecha_desde.TabIndex = 0
        Me.Fecha_desde.Value = New Date(2015, 1, 30, 15, 42, 46, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(167, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Hasta"
        '
        'Fecha_hasta
        '
        Me.Fecha_hasta.BackColor = System.Drawing.Color.White
        Me.Fecha_hasta.ForeColor = System.Drawing.Color.Black
        Me.Fecha_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fecha_hasta.Location = New System.Drawing.Point(209, 21)
        Me.Fecha_hasta.Name = "Fecha_hasta"
        Me.Fecha_hasta.Size = New System.Drawing.Size(82, 22)
        Me.Fecha_hasta.TabIndex = 1
        Me.Fecha_hasta.Value = New Date(2015, 1, 30, 15, 42, 52, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(10, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Desde"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnActualizarInformacion, Me.BtnBuscarEntidad, Me.BtnSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 319)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(600, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 44
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnActualizarInformacion
        '
        Me.BtnActualizarInformacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnActualizarInformacion.ForeColor = System.Drawing.Color.Black
        Me.BtnActualizarInformacion.Image = CType(resources.GetObject("BtnActualizarInformacion.Image"), System.Drawing.Image)
        Me.BtnActualizarInformacion.Name = "BtnActualizarInformacion"
        Me.BtnActualizarInformacion.Text = "Ejecutar proceso"
        '
        'BtnBuscarEntidad
        '
        Me.BtnBuscarEntidad.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnBuscarEntidad.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarEntidad.Image = CType(resources.GetObject("BtnBuscarEntidad.Image"), System.Drawing.Image)
        Me.BtnBuscarEntidad.Name = "BtnBuscarEntidad"
        Me.BtnBuscarEntidad.Text = "Buscar proveedor"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        '
        'TxtNomLista
        '
        Me.TxtNomLista.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtNomLista.Border.Class = "TextBoxBorder"
        Me.TxtNomLista.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNomLista.DisabledBackColor = System.Drawing.Color.White
        Me.TxtNomLista.FocusHighlightEnabled = True
        Me.TxtNomLista.ForeColor = System.Drawing.Color.Black
        Me.TxtNomLista.Location = New System.Drawing.Point(197, 254)
        Me.TxtNomLista.Name = "TxtNomLista"
        Me.TxtNomLista.PreventEnterBeep = True
        Me.TxtNomLista.ReadOnly = True
        Me.TxtNomLista.Size = New System.Drawing.Size(344, 22)
        Me.TxtNomLista.TabIndex = 67
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(12, 253)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(78, 20)
        Me.LabelX3.TabIndex = 66
        Me.LabelX3.Text = "Lista de costo"
        '
        'BtnListaCostos
        '
        Me.BtnListaCostos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnListaCostos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnListaCostos.Image = CType(resources.GetObject("BtnListaCostos.Image"), System.Drawing.Image)
        Me.BtnListaCostos.Location = New System.Drawing.Point(558, 255)
        Me.BtnListaCostos.Name = "BtnListaCostos"
        Me.BtnListaCostos.Size = New System.Drawing.Size(37, 23)
        Me.BtnListaCostos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnListaCostos.TabIndex = 65
        Me.BtnListaCostos.Text = "..."
        Me.BtnListaCostos.Tooltip = "Seleccionar lista de costos por defecto"
        '
        'TxtCodLista
        '
        Me.TxtCodLista.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtCodLista.Border.Class = "TextBoxBorder"
        Me.TxtCodLista.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCodLista.DisabledBackColor = System.Drawing.Color.White
        Me.TxtCodLista.FocusHighlightEnabled = True
        Me.TxtCodLista.ForeColor = System.Drawing.Color.Black
        Me.TxtCodLista.Location = New System.Drawing.Point(96, 254)
        Me.TxtCodLista.Name = "TxtCodLista"
        Me.TxtCodLista.PreventEnterBeep = True
        Me.TxtCodLista.ReadOnly = True
        Me.TxtCodLista.Size = New System.Drawing.Size(95, 22)
        Me.TxtCodLista.TabIndex = 64
        Me.TxtCodLista.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtArchivoDescuentos
        '
        Me.TxtArchivoDescuentos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtArchivoDescuentos.Border.Class = "TextBoxBorder"
        Me.TxtArchivoDescuentos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtArchivoDescuentos.DisabledBackColor = System.Drawing.Color.White
        Me.TxtArchivoDescuentos.FocusHighlightEnabled = True
        Me.TxtArchivoDescuentos.ForeColor = System.Drawing.Color.Black
        Me.TxtArchivoDescuentos.Location = New System.Drawing.Point(12, 182)
        Me.TxtArchivoDescuentos.Name = "TxtArchivoDescuentos"
        Me.TxtArchivoDescuentos.PreventEnterBeep = True
        Me.TxtArchivoDescuentos.Size = New System.Drawing.Size(583, 22)
        Me.TxtArchivoDescuentos.TabIndex = 63
        '
        'TxtRutaArchivosDBF
        '
        Me.TxtRutaArchivosDBF.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtRutaArchivosDBF.Border.Class = "TextBoxBorder"
        Me.TxtRutaArchivosDBF.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRutaArchivosDBF.DisabledBackColor = System.Drawing.Color.White
        Me.TxtRutaArchivosDBF.FocusHighlightEnabled = True
        Me.TxtRutaArchivosDBF.ForeColor = System.Drawing.Color.Black
        Me.TxtRutaArchivosDBF.Location = New System.Drawing.Point(12, 226)
        Me.TxtRutaArchivosDBF.Name = "TxtRutaArchivosDBF"
        Me.TxtRutaArchivosDBF.PreventEnterBeep = True
        Me.TxtRutaArchivosDBF.ReadOnly = True
        Me.TxtRutaArchivosDBF.Size = New System.Drawing.Size(529, 22)
        Me.TxtRutaArchivosDBF.TabIndex = 62
        '
        'BtnRutaDirectorio
        '
        Me.BtnRutaDirectorio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnRutaDirectorio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnRutaDirectorio.Image = CType(resources.GetObject("BtnRutaDirectorio.Image"), System.Drawing.Image)
        Me.BtnRutaDirectorio.Location = New System.Drawing.Point(558, 226)
        Me.BtnRutaDirectorio.Name = "BtnRutaDirectorio"
        Me.BtnRutaDirectorio.Size = New System.Drawing.Size(37, 23)
        Me.BtnRutaDirectorio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnRutaDirectorio.TabIndex = 61
        Me.BtnRutaDirectorio.Text = "..."
        Me.BtnRutaDirectorio.Tooltip = "Buscar ruta de archivos DBF"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 210)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(98, 20)
        Me.LabelX2.TabIndex = 60
        Me.LabelX2.Text = "Ruta archivos DBF"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 165)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(162, 20)
        Me.LabelX1.TabIndex = 59
        Me.LabelX1.Text = "Nombre archivo DBF descuentos"
        '
        'Dir_Buscar
        '
        Me.Dir_Buscar.RootFolder = System.Environment.SpecialFolder.MyComputer
        Me.Dir_Buscar.SelectedPath = "X:\winmts"
        '
        'Chk_Fecha
        '
        Me.Chk_Fecha.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Fecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Fecha.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Chk_Fecha.Checked = True
        Me.Chk_Fecha.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Fecha.CheckValue = "Y"
        Me.Chk_Fecha.ForeColor = System.Drawing.Color.Black
        Me.Chk_Fecha.Location = New System.Drawing.Point(12, 7)
        Me.Chk_Fecha.Name = "Chk_Fecha"
        Me.Chk_Fecha.Size = New System.Drawing.Size(100, 23)
        Me.Chk_Fecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Fecha.TabIndex = 68
        Me.Chk_Fecha.Text = "Filtrar por fecha"
        '
        'Chk_Proveedor
        '
        Me.Chk_Proveedor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Proveedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Proveedor.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Chk_Proveedor.ForeColor = System.Drawing.Color.Black
        Me.Chk_Proveedor.Location = New System.Drawing.Point(12, 97)
        Me.Chk_Proveedor.Name = "Chk_Proveedor"
        Me.Chk_Proveedor.Size = New System.Drawing.Size(356, 23)
        Me.Chk_Proveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Proveedor.TabIndex = 69
        Me.Chk_Proveedor.Text = "Filtrar por proveedor especifico"
        '
        'TxtProveedor
        '
        Me.TxtProveedor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtProveedor.Border.Class = "TextBoxBorder"
        Me.TxtProveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtProveedor.DisabledBackColor = System.Drawing.Color.White
        Me.TxtProveedor.FocusHighlightEnabled = True
        Me.TxtProveedor.ForeColor = System.Drawing.Color.Black
        Me.TxtProveedor.Location = New System.Drawing.Point(12, 143)
        Me.TxtProveedor.Name = "TxtProveedor"
        Me.TxtProveedor.PreventEnterBeep = True
        Me.TxtProveedor.Size = New System.Drawing.Size(583, 22)
        Me.TxtProveedor.TabIndex = 71
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(12, 126)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(162, 20)
        Me.LabelX4.TabIndex = 70
        Me.LabelX4.Text = "Proveedor seleccionado"
        '
        'Chk_GuardarConDsctos
        '
        '
        '
        '
        Me.Chk_GuardarConDsctos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_GuardarConDsctos.Location = New System.Drawing.Point(12, 282)
        Me.Chk_GuardarConDsctos.Name = "Chk_GuardarConDsctos"
        Me.Chk_GuardarConDsctos.Size = New System.Drawing.Size(275, 23)
        Me.Chk_GuardarConDsctos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_GuardarConDsctos.TabIndex = 72
        Me.Chk_GuardarConDsctos.Text = "Guardar con descuento calculado"
        '
        'Frm_MTS_Actualizar_Lista_Proceso_Manual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 360)
        Me.ControlBox = False
        Me.Controls.Add(Me.Chk_GuardarConDsctos)
        Me.Controls.Add(Me.TxtProveedor)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Chk_Proveedor)
        Me.Controls.Add(Me.Chk_Fecha)
        Me.Controls.Add(Me.TxtNomLista)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.BtnListaCostos)
        Me.Controls.Add(Me.TxtCodLista)
        Me.Controls.Add(Me.TxtArchivoDescuentos)
        Me.Controls.Add(Me.TxtRutaArchivosDBF)
        Me.Controls.Add(Me.BtnRutaDirectorio)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_MTS_Actualizar_Lista_Proceso_Manual"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ejecución manual"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnActualizarInformacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Fecha_desde As System.Windows.Forms.DateTimePicker
    Public WithEvents Fecha_hasta As System.Windows.Forms.DateTimePicker
    Public WithEvents TxtNomLista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnListaCostos As DevComponents.DotNetBar.ButtonX
    Public WithEvents TxtCodLista As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents TxtArchivoDescuentos As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents TxtRutaArchivosDBF As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents BtnRutaDirectorio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dir_Buscar As System.Windows.Forms.FolderBrowserDialog
    Public WithEvents TxtProveedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnBuscarEntidad As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Chk_Fecha As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Chk_Proveedor As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_GuardarConDsctos As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
