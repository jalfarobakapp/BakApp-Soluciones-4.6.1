<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ConexionBD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ConexionBD))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnAgregar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnGenerateKey = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnxSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.TxtRazon = New System.Windows.Forms.TextBox()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnAgregar, Me.BtnGenerateKey, Me.BtnxSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 259)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(536, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 24
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAgregar.ForeColor = System.Drawing.Color.Black
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Text = "Agregar Empresa"
        '
        'BtnGenerateKey
        '
        Me.BtnGenerateKey.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGenerateKey.ForeColor = System.Drawing.Color.Black
        Me.BtnGenerateKey.Image = CType(resources.GetObject("BtnGenerateKey.Image"), System.Drawing.Image)
        Me.BtnGenerateKey.Name = "BtnGenerateKey"
        Me.BtnGenerateKey.Text = "Generar Llave de acceso BakApp"
        '
        'BtnxSalir
        '
        Me.BtnxSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnxSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnxSalir.Image = CType(resources.GetObject("BtnxSalir.Image"), System.Drawing.Image)
        Me.BtnxSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnxSalir.Name = "BtnxSalir"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Grilla)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(4, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(523, 205)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Haga doble clic  sobre la EMPRESA"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PeachPuff
        Me.Grilla.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.Location = New System.Drawing.Point(3, 18)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla.Size = New System.Drawing.Size(517, 184)
        Me.Grilla.TabIndex = 0
        Me.Grilla.TabStop = False
        '
        'TxtRazon
        '
        Me.TxtRazon.BackColor = System.Drawing.Color.White
        Me.TxtRazon.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightColor(Me.TxtRazon, DevComponents.DotNetBar.Validator.eHighlightColor.Red)
        Me.TxtRazon.Location = New System.Drawing.Point(4, 223)
        Me.TxtRazon.Name = "TxtRazon"
        Me.TxtRazon.Size = New System.Drawing.Size(523, 22)
        Me.TxtRazon.TabIndex = 0
        Me.TxtRazon.TabStop = False
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Frm_ConexionBD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 300)
        Me.ControlBox = False
        Me.Controls.Add(Me.TxtRazon)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ConexionBD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Empresas asignadas al sistema BAKAPP"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnxSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Grilla As System.Windows.Forms.DataGridView
    Friend WithEvents TxtRazon As System.Windows.Forms.TextBox
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Public WithEvents BtnAgregar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents BtnGenerateKey As DevComponents.DotNetBar.ButtonItem
End Class
