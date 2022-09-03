<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CreaProductos_03_CrearEditar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CreaProductos_03_CrearEditar))
        Me.TxtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.TxtDescripcionBusqueda = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.TxtDescripcionAlternativa = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.ChkColor = New System.Windows.Forms.CheckBox
        Me.ChkModelo = New System.Windows.Forms.CheckBox
        Me.ChkMedida = New System.Windows.Forms.CheckBox
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtCodigo
        '
        Me.TxtCodigo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtCodigo.Border.Class = "TextBoxBorder"
        Me.TxtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCodigo.DisabledBackColor = System.Drawing.Color.White
        Me.TxtCodigo.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtCodigo, True)
        Me.TxtCodigo.Location = New System.Drawing.Point(142, 13)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.PreventEnterBeep = True
        Me.TxtCodigo.ReadOnly = True
        Me.TxtCodigo.Size = New System.Drawing.Size(105, 22)
        Me.TxtCodigo.TabIndex = 0
        Me.TxtCodigo.TabStop = False
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(60, 23)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Código"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 40)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(137, 23)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Descripción de busqueda"
        '
        'TxtDescripcionBusqueda
        '
        Me.TxtDescripcionBusqueda.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtDescripcionBusqueda.Border.Class = "TextBoxBorder"
        Me.TxtDescripcionBusqueda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDescripcionBusqueda.DisabledBackColor = System.Drawing.Color.White
        Me.TxtDescripcionBusqueda.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtDescripcionBusqueda, True)
        Me.TxtDescripcionBusqueda.Location = New System.Drawing.Point(142, 40)
        Me.TxtDescripcionBusqueda.Name = "TxtDescripcionBusqueda"
        Me.TxtDescripcionBusqueda.PreventEnterBeep = True
        Me.TxtDescripcionBusqueda.Size = New System.Drawing.Size(409, 22)
        Me.TxtDescripcionBusqueda.TabIndex = 0
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(12, 68)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(124, 23)
        Me.LabelX3.TabIndex = 5
        Me.LabelX3.Text = "Descripción alternativa"
        '
        'TxtDescripcionAlternativa
        '
        Me.TxtDescripcionAlternativa.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtDescripcionAlternativa.Border.Class = "TextBoxBorder"
        Me.TxtDescripcionAlternativa.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDescripcionAlternativa.DisabledBackColor = System.Drawing.Color.White
        Me.TxtDescripcionAlternativa.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtDescripcionAlternativa, True)
        Me.TxtDescripcionAlternativa.Location = New System.Drawing.Point(142, 68)
        Me.TxtDescripcionAlternativa.Name = "TxtDescripcionAlternativa"
        Me.TxtDescripcionAlternativa.PreventEnterBeep = True
        Me.TxtDescripcionAlternativa.Size = New System.Drawing.Size(409, 22)
        Me.TxtDescripcionAlternativa.TabIndex = 1
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar, Me.BtnSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 135)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(563, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 6
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Tooltip = "Grabar"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Tooltip = "Salir"
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer)))
        '
        'ChkColor
        '
        Me.ChkColor.AutoSize = True
        Me.ChkColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ChkColor.Checked = True
        Me.ChkColor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkColor.ForeColor = System.Drawing.Color.Black
        Me.ChkColor.Location = New System.Drawing.Point(142, 107)
        Me.ChkColor.Name = "ChkColor"
        Me.ChkColor.Size = New System.Drawing.Size(88, 17)
        Me.ChkColor.TabIndex = 7
        Me.ChkColor.Text = "Aplica Color"
        Me.ChkColor.UseVisualStyleBackColor = False
        '
        'ChkModelo
        '
        Me.ChkModelo.AutoSize = True
        Me.ChkModelo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ChkModelo.Checked = True
        Me.ChkModelo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkModelo.ForeColor = System.Drawing.Color.Black
        Me.ChkModelo.Location = New System.Drawing.Point(230, 107)
        Me.ChkModelo.Name = "ChkModelo"
        Me.ChkModelo.Size = New System.Drawing.Size(100, 17)
        Me.ChkModelo.TabIndex = 8
        Me.ChkModelo.Text = "Aplica Modelo"
        Me.ChkModelo.UseVisualStyleBackColor = False
        '
        'ChkMedida
        '
        Me.ChkMedida.AutoSize = True
        Me.ChkMedida.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ChkMedida.Checked = True
        Me.ChkMedida.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkMedida.ForeColor = System.Drawing.Color.Black
        Me.ChkMedida.Location = New System.Drawing.Point(336, 107)
        Me.ChkMedida.Name = "ChkMedida"
        Me.ChkMedida.Size = New System.Drawing.Size(99, 17)
        Me.ChkMedida.TabIndex = 9
        Me.ChkMedida.Text = "Aplica Medida"
        Me.ChkMedida.UseVisualStyleBackColor = False
        '
        'Frm_CreaProductos_03_CrearEditar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 176)
        Me.ControlBox = False
        Me.Controls.Add(Me.ChkMedida)
        Me.Controls.Add(Me.ChkModelo)
        Me.Controls.Add(Me.ChkColor)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.TxtDescripcionAlternativa)
        Me.Controls.Add(Me.TxtDescripcionBusqueda)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.TxtCodigo)
        Me.Controls.Add(Me.LabelX2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_CreaProductos_03_CrearEditar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Public WithEvents TxtDescripcionBusqueda As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents TxtDescripcionAlternativa As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ChkMedida As System.Windows.Forms.CheckBox
    Friend WithEvents ChkModelo As System.Windows.Forms.CheckBox
    Friend WithEvents ChkColor As System.Windows.Forms.CheckBox
End Class
