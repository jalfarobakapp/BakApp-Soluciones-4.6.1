<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MTS_Actualizar_Lista_Parametros
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MTS_Actualizar_Lista_Parametros))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.BtnRutaDirectorio = New DevComponents.DotNetBar.ButtonX
        Me.TxtRutaArchivosDBF = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.TxtArchivoDescuentos = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Dir_Buscar = New System.Windows.Forms.FolderBrowserDialog
        Me.TxtCodLista = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.BtnListaCostos = New DevComponents.DotNetBar.ButtonX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.TxtNomLista = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Chk_GuardarConDsctos = New DevComponents.DotNetBar.Controls.CheckBoxX
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 217)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(162, 20)
        Me.LabelX1.TabIndex = 47
        Me.LabelX1.Text = "Nombre archivo DBF descuentos"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar, Me.BtnSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 363)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(645, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 43
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = Global.BkSpecialPrograms.My.Resources.Resources.save
        Me.BtnGrabar.Name = "BtnGrabar"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = Global.BkSpecialPrograms.My.Resources.Resources.button_rounded_red_delete
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Grilla)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(629, 205)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Horas de ejecución del proceso"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(3, 18)
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(623, 184)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 29
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 262)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(98, 20)
        Me.LabelX2.TabIndex = 49
        Me.LabelX2.Text = "Ruta archivos DBF"
        '
        'BtnRutaDirectorio
        '
        Me.BtnRutaDirectorio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnRutaDirectorio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnRutaDirectorio.Image = Global.BkSpecialPrograms.My.Resources.Resources.folder_open1
        Me.BtnRutaDirectorio.Location = New System.Drawing.Point(601, 278)
        Me.BtnRutaDirectorio.Name = "BtnRutaDirectorio"
        Me.BtnRutaDirectorio.Size = New System.Drawing.Size(37, 23)
        Me.BtnRutaDirectorio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnRutaDirectorio.TabIndex = 50
        Me.BtnRutaDirectorio.Text = "..."
        Me.BtnRutaDirectorio.Tooltip = "Buscar ruta de archivos DBF"
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
        Me.TxtRutaArchivosDBF.Location = New System.Drawing.Point(12, 278)
        Me.TxtRutaArchivosDBF.Name = "TxtRutaArchivosDBF"
        Me.TxtRutaArchivosDBF.PreventEnterBeep = True
        Me.TxtRutaArchivosDBF.ReadOnly = True
        Me.TxtRutaArchivosDBF.Size = New System.Drawing.Size(583, 22)
        Me.TxtRutaArchivosDBF.TabIndex = 51
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
        Me.TxtArchivoDescuentos.Location = New System.Drawing.Point(12, 234)
        Me.TxtArchivoDescuentos.Name = "TxtArchivoDescuentos"
        Me.TxtArchivoDescuentos.PreventEnterBeep = True
        Me.TxtArchivoDescuentos.Size = New System.Drawing.Size(583, 22)
        Me.TxtArchivoDescuentos.TabIndex = 52
        '
        'Dir_Buscar
        '
        Me.Dir_Buscar.RootFolder = System.Environment.SpecialFolder.MyComputer
        Me.Dir_Buscar.SelectedPath = "X:\winmts"
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
        Me.TxtCodLista.Location = New System.Drawing.Point(96, 306)
        Me.TxtCodLista.Name = "TxtCodLista"
        Me.TxtCodLista.PreventEnterBeep = True
        Me.TxtCodLista.ReadOnly = True
        Me.TxtCodLista.Size = New System.Drawing.Size(95, 22)
        Me.TxtCodLista.TabIndex = 55
        Me.TxtCodLista.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnListaCostos
        '
        Me.BtnListaCostos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnListaCostos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnListaCostos.Image = Global.BkSpecialPrograms.My.Resources.Resources.folder_open1
        Me.BtnListaCostos.Location = New System.Drawing.Point(601, 307)
        Me.BtnListaCostos.Name = "BtnListaCostos"
        Me.BtnListaCostos.Size = New System.Drawing.Size(37, 23)
        Me.BtnListaCostos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnListaCostos.TabIndex = 56
        Me.BtnListaCostos.Text = "..."
        Me.BtnListaCostos.Tooltip = "Seleccionar lista de costos por defecto"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(12, 305)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(78, 20)
        Me.LabelX3.TabIndex = 57
        Me.LabelX3.Text = "Lista de costo"
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
        Me.TxtNomLista.Location = New System.Drawing.Point(197, 306)
        Me.TxtNomLista.Name = "TxtNomLista"
        Me.TxtNomLista.PreventEnterBeep = True
        Me.TxtNomLista.ReadOnly = True
        Me.TxtNomLista.Size = New System.Drawing.Size(398, 22)
        Me.TxtNomLista.TabIndex = 58
        '
        'Chk_GuardarConDsctos
        '
        '
        '
        '
        Me.Chk_GuardarConDsctos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_GuardarConDsctos.Location = New System.Drawing.Point(10, 334)
        Me.Chk_GuardarConDsctos.Name = "Chk_GuardarConDsctos"
        Me.Chk_GuardarConDsctos.Size = New System.Drawing.Size(275, 23)
        Me.Chk_GuardarConDsctos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_GuardarConDsctos.TabIndex = 59
        Me.Chk_GuardarConDsctos.Text = "Guardar con descuento calculado"
        '
        'Frm_MTS_Actualizar_Lista_Parametros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 404)
        Me.ControlBox = False
        Me.Controls.Add(Me.Chk_GuardarConDsctos)
        Me.Controls.Add(Me.TxtNomLista)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.BtnListaCostos)
        Me.Controls.Add(Me.TxtCodLista)
        Me.Controls.Add(Me.TxtArchivoDescuentos)
        Me.Controls.Add(Me.TxtRutaArchivosDBF)
        Me.Controls.Add(Me.BtnRutaDirectorio)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_MTS_Actualizar_Lista_Parametros"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantención de "
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnRutaDirectorio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Dir_Buscar As System.Windows.Forms.FolderBrowserDialog
    Public WithEvents TxtRutaArchivosDBF As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents TxtArchivoDescuentos As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents TxtCodLista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents BtnListaCostos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Public WithEvents TxtNomLista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Chk_GuardarConDsctos As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
