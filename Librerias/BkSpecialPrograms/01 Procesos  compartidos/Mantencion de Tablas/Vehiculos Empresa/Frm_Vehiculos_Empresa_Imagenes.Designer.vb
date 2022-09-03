<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Vehiculos_Empresa_Imagenes
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Vehiculos_Empresa_Imagenes))
        Me.Sld_Zoom = New DevComponents.DotNetBar.Controls.Slider()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Pbx_Imagen = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Grilla_Imagenes = New System.Windows.Forms.DataGridView()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnMantencImagenes = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnSolicitarProductoBodega = New DevComponents.DotNetBar.ButtonItem()
        Me.Panel1.SuspendLayout()
        CType(Me.Pbx_Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Grilla_Imagenes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Sld_Zoom
        '
        Me.Sld_Zoom.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Sld_Zoom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Sld_Zoom.ForeColor = System.Drawing.Color.Black
        Me.Sld_Zoom.Location = New System.Drawing.Point(535, 474)
        Me.Sld_Zoom.Name = "Sld_Zoom"
        Me.Sld_Zoom.Size = New System.Drawing.Size(221, 23)
        Me.Sld_Zoom.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Sld_Zoom.TabIndex = 35
        Me.Sld_Zoom.Text = "Zoom"
        Me.Sld_Zoom.Value = 0
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Pbx_Imagen)
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(159, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(597, 456)
        Me.Panel1.TabIndex = 34
        '
        'Pbx_Imagen
        '
        Me.Pbx_Imagen.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Pbx_Imagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pbx_Imagen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pbx_Imagen.ForeColor = System.Drawing.Color.Black
        Me.Pbx_Imagen.Location = New System.Drawing.Point(0, 0)
        Me.Pbx_Imagen.Margin = New System.Windows.Forms.Padding(0)
        Me.Pbx_Imagen.Name = "Pbx_Imagen"
        Me.Pbx_Imagen.Size = New System.Drawing.Size(597, 456)
        Me.Pbx_Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Pbx_Imagen.TabIndex = 0
        Me.Pbx_Imagen.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.Grilla_Imagenes)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(7, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(146, 466)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        '
        'Grilla_Imagenes
        '
        Me.Grilla_Imagenes.AllowUserToAddRows = False
        Me.Grilla_Imagenes.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.PeachPuff
        Me.Grilla_Imagenes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Imagenes.BackgroundColor = System.Drawing.Color.White
        Me.Grilla_Imagenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Imagenes.DefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Imagenes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Imagenes.Location = New System.Drawing.Point(3, 18)
        Me.Grilla_Imagenes.Name = "Grilla_Imagenes"
        Me.Grilla_Imagenes.ReadOnly = True
        Me.Grilla_Imagenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla_Imagenes.Size = New System.Drawing.Size(140, 445)
        Me.Grilla_Imagenes.TabIndex = 27
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnMantencImagenes, Me.BtnSolicitarProductoBodega})
        Me.Bar1.Location = New System.Drawing.Point(0, 510)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(772, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 32
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnMantencImagenes
        '
        Me.BtnMantencImagenes.Image = CType(resources.GetObject("BtnMantencImagenes.Image"), System.Drawing.Image)
        Me.BtnMantencImagenes.Name = "BtnMantencImagenes"
        '
        'BtnSolicitarProductoBodega
        '
        Me.BtnSolicitarProductoBodega.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSolicitarProductoBodega.ForeColor = System.Drawing.Color.Black
        Me.BtnSolicitarProductoBodega.Image = CType(resources.GetObject("BtnSolicitarProductoBodega.Image"), System.Drawing.Image)
        Me.BtnSolicitarProductoBodega.Name = "BtnSolicitarProductoBodega"
        Me.BtnSolicitarProductoBodega.Text = "Solicitar producto a bodega"
        Me.BtnSolicitarProductoBodega.Visible = False
        '
        'Frm_Vehiculos_Empresa_Imagenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 551)
        Me.Controls.Add(Me.Sld_Zoom)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Vehiculos_Empresa_Imagenes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Pbx_Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Grilla_Imagenes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Sld_Zoom As DevComponents.DotNetBar.Controls.Slider
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Pbx_Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Grilla_Imagenes As System.Windows.Forms.DataGridView
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnMantencImagenes As DevComponents.DotNetBar.ButtonItem
    Public WithEvents BtnSolicitarProductoBodega As DevComponents.DotNetBar.ButtonItem
End Class
