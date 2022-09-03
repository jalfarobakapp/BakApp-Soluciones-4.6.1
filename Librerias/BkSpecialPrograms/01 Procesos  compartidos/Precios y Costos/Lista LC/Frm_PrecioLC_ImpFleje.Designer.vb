<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PrecioLC_ImpFleje
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PrecioLC_ImpFleje))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbLista = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtPrecioUd1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtPrecioUd2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnxBuscarProducto = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cmbetiquetas = New System.Windows.Forms.ComboBox()
        Me.TxtRtu = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(18, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.BackColor = System.Drawing.Color.White
        Me.TxtCodigo.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtCodigo, True)
        Me.TxtCodigo.Location = New System.Drawing.Point(91, 12)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(187, 22)
        Me.TxtCodigo.TabIndex = 1
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.BackColor = System.Drawing.Color.White
        Me.TxtDescripcion.ForeColor = System.Drawing.Color.Black
        Me.TxtDescripcion.Location = New System.Drawing.Point(91, 40)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(396, 22)
        Me.TxtDescripcion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(18, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción"
        '
        'CmbLista
        '
        Me.CmbLista.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmbLista.ForeColor = System.Drawing.Color.Black
        Me.CmbLista.FormattingEnabled = True
        Me.CmbLista.Location = New System.Drawing.Point(91, 79)
        Me.CmbLista.Name = "CmbLista"
        Me.CmbLista.Size = New System.Drawing.Size(271, 21)
        Me.CmbLista.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(18, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Lista $"
        '
        'TxtPrecioUd1
        '
        Me.TxtPrecioUd1.BackColor = System.Drawing.Color.White
        Me.TxtPrecioUd1.ForeColor = System.Drawing.Color.Black
        Me.TxtPrecioUd1.Location = New System.Drawing.Point(91, 124)
        Me.TxtPrecioUd1.Name = "TxtPrecioUd1"
        Me.TxtPrecioUd1.ReadOnly = True
        Me.TxtPrecioUd1.Size = New System.Drawing.Size(187, 22)
        Me.TxtPrecioUd1.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(18, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Precio Ud1"
        '
        'TxtPrecioUd2
        '
        Me.TxtPrecioUd2.BackColor = System.Drawing.Color.White
        Me.TxtPrecioUd2.ForeColor = System.Drawing.Color.Black
        Me.TxtPrecioUd2.Location = New System.Drawing.Point(398, 127)
        Me.TxtPrecioUd2.Name = "TxtPrecioUd2"
        Me.TxtPrecioUd2.ReadOnly = True
        Me.TxtPrecioUd2.Size = New System.Drawing.Size(187, 22)
        Me.TxtPrecioUd2.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(325, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Precio Ud2"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar, Me.BtnxBuscarProducto, Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 239)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(593, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 50
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Text = "Imprimir"
        '
        'BtnxBuscarProducto
        '
        Me.BtnxBuscarProducto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnxBuscarProducto.ForeColor = System.Drawing.Color.Black
        Me.BtnxBuscarProducto.Name = "BtnxBuscarProducto"
        Me.BtnxBuscarProducto.Text = "Buscar productos"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.Tooltip = "Salir"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(18, 177)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Etiquetas"
        '
        'Cmbetiquetas
        '
        Me.Cmbetiquetas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Cmbetiquetas.ForeColor = System.Drawing.Color.Black
        Me.Cmbetiquetas.FormattingEnabled = True
        Me.Cmbetiquetas.Location = New System.Drawing.Point(91, 174)
        Me.Cmbetiquetas.Name = "Cmbetiquetas"
        Me.Cmbetiquetas.Size = New System.Drawing.Size(271, 21)
        Me.Cmbetiquetas.TabIndex = 51
        '
        'TxtRtu
        '
        Me.TxtRtu.BackColor = System.Drawing.Color.White
        Me.TxtRtu.ForeColor = System.Drawing.Color.Black
        Me.TxtRtu.Location = New System.Drawing.Point(539, 40)
        Me.TxtRtu.Name = "TxtRtu"
        Me.TxtRtu.ReadOnly = True
        Me.TxtRtu.Size = New System.Drawing.Size(46, 22)
        Me.TxtRtu.TabIndex = 54
        Me.TxtRtu.TabStop = False
        Me.TxtRtu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(493, 43)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 13)
        Me.Label14.TabIndex = 53
        Me.Label14.Text = "R.T.U."
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer)))
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Frm_PrecioLC_ImpFleje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 264)
        Me.ControlBox = False
        Me.Controls.Add(Me.TxtRtu)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Cmbetiquetas)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.TxtPrecioUd2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtPrecioUd1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmbLista)
        Me.Controls.Add(Me.TxtDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_PrecioLC_ImpFleje"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir Fleje"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbLista As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioUd1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioUd2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cmbetiquetas As System.Windows.Forms.ComboBox
    Friend WithEvents BtnxBuscarProducto As DevComponents.DotNetBar.ButtonItem
    Public WithEvents TxtRtu As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
End Class
