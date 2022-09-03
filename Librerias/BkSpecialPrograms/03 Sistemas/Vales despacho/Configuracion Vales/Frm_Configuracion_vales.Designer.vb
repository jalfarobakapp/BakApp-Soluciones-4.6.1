<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Configuracion_vales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Configuracion_vales))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.Cmb_Segundos_Act = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Grupo_Estado = New System.Windows.Forms.GroupBox
        Me.ItemPanel1 = New DevComponents.DotNetBar.ItemPanel
        Me.Rdb_Retira_Cliente = New DevComponents.DotNetBar.CheckBoxItem
        Me.Rdb_Despacho_Domicilio = New DevComponents.DotNetBar.CheckBoxItem
        Me.Rdb_Ambos = New DevComponents.DotNetBar.CheckBoxItem
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ItemPanel2 = New DevComponents.DotNetBar.ItemPanel
        Me.Chk_VerMarcadas = New DevComponents.DotNetBar.CheckBoxItem
        Me.Chk_VerActivas = New DevComponents.DotNetBar.CheckBoxItem
        Me.Chk_VerCerradas = New DevComponents.DotNetBar.CheckBoxItem
        Me.Chk_VerNulas = New DevComponents.DotNetBar.CheckBoxItem
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Btn_Impresora = New DevComponents.DotNetBar.ButtonX
        Me.Txt_Impresora = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Btn_RutaImagen = New DevComponents.DotNetBar.ButtonX
        Me.Txt_RutaImagen = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.GroupBox1.SuspendLayout()
        Me.Grupo_Estado.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        Me.LabelX1.Location = New System.Drawing.Point(6, 34)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(26, 23)
        Me.LabelX1.TabIndex = 103
        Me.LabelX1.Text = "Cada"
        '
        'Cmb_Segundos_Act
        '
        Me.Cmb_Segundos_Act.DisplayMember = "Text"
        Me.Cmb_Segundos_Act.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Segundos_Act.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Segundos_Act.FormattingEnabled = True
        Me.Cmb_Segundos_Act.ItemHeight = 16
        Me.Cmb_Segundos_Act.Location = New System.Drawing.Point(38, 35)
        Me.Cmb_Segundos_Act.Name = "Cmb_Segundos_Act"
        Me.Cmb_Segundos_Act.Size = New System.Drawing.Size(116, 22)
        Me.Cmb_Segundos_Act.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Segundos_Act.TabIndex = 104
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Cmb_Segundos_Act)
        Me.GroupBox1.Controls.Add(Me.LabelX1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(178, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(159, 67)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tiempo de actualizacion"
        '
        'Grupo_Estado
        '
        Me.Grupo_Estado.BackColor = System.Drawing.Color.Transparent
        Me.Grupo_Estado.Controls.Add(Me.ItemPanel1)
        Me.Grupo_Estado.ForeColor = System.Drawing.Color.Black
        Me.Grupo_Estado.Location = New System.Drawing.Point(12, 12)
        Me.Grupo_Estado.Name = "Grupo_Estado"
        Me.Grupo_Estado.Size = New System.Drawing.Size(159, 101)
        Me.Grupo_Estado.TabIndex = 106
        Me.Grupo_Estado.TabStop = False
        Me.Grupo_Estado.Text = "Tipo entrega"
        '
        'ItemPanel1
        '
        '
        '
        '
        Me.ItemPanel1.BackgroundStyle.BackColor = System.Drawing.Color.White
        Me.ItemPanel1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel1.BackgroundStyle.BorderBottomWidth = 1
        Me.ItemPanel1.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ItemPanel1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel1.BackgroundStyle.BorderLeftWidth = 1
        Me.ItemPanel1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel1.BackgroundStyle.BorderRightWidth = 1
        Me.ItemPanel1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel1.BackgroundStyle.BorderTopWidth = 1
        Me.ItemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanel1.ContainerControlProcessDialogKey = True
        Me.ItemPanel1.DragDropSupport = True
        Me.ItemPanel1.ForeColor = System.Drawing.Color.Black
        Me.ItemPanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Rdb_Retira_Cliente, Me.Rdb_Despacho_Domicilio, Me.Rdb_Ambos})
        Me.ItemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemPanel1.Location = New System.Drawing.Point(6, 21)
        Me.ItemPanel1.Name = "ItemPanel1"
        Me.ItemPanel1.Size = New System.Drawing.Size(148, 71)
        Me.ItemPanel1.TabIndex = 1
        Me.ItemPanel1.Text = "ItemPanel1"
        '
        'Rdb_Retira_Cliente
        '
        Me.Rdb_Retira_Cliente.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Retira_Cliente.Name = "Rdb_Retira_Cliente"
        Me.Rdb_Retira_Cliente.Text = "RETIRA CLIENTE"
        '
        'Rdb_Despacho_Domicilio
        '
        Me.Rdb_Despacho_Domicilio.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Despacho_Domicilio.Name = "Rdb_Despacho_Domicilio"
        Me.Rdb_Despacho_Domicilio.Text = "DESPACHO A DOMICILIO"
        '
        'Rdb_Ambos
        '
        Me.Rdb_Ambos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ambos.Checked = True
        Me.Rdb_Ambos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Ambos.Name = "Rdb_Ambos"
        Me.Rdb_Ambos.Text = "AMBOS"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar, Me.BtnCancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 263)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(640, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 107
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
        'BtnCancelar
        '
        Me.BtnCancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancelar.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Tooltip = "Cancelar"
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.Location = New System.Drawing.Point(358, 12)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(128, 128)
        Me.ReflectionImage1.TabIndex = 108
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.ItemPanel2)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(12, 122)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(159, 120)
        Me.GroupBox2.TabIndex = 109
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Estados"
        '
        'ItemPanel2
        '
        '
        '
        '
        Me.ItemPanel2.BackgroundStyle.BackColor = System.Drawing.Color.White
        Me.ItemPanel2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel2.BackgroundStyle.BorderBottomWidth = 1
        Me.ItemPanel2.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ItemPanel2.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel2.BackgroundStyle.BorderLeftWidth = 1
        Me.ItemPanel2.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel2.BackgroundStyle.BorderRightWidth = 1
        Me.ItemPanel2.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemPanel2.BackgroundStyle.BorderTopWidth = 1
        Me.ItemPanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanel2.ContainerControlProcessDialogKey = True
        Me.ItemPanel2.DragDropSupport = True
        Me.ItemPanel2.ForeColor = System.Drawing.Color.Black
        Me.ItemPanel2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Chk_VerMarcadas, Me.Chk_VerActivas, Me.Chk_VerCerradas, Me.Chk_VerNulas})
        Me.ItemPanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemPanel2.Location = New System.Drawing.Point(6, 21)
        Me.ItemPanel2.Name = "ItemPanel2"
        Me.ItemPanel2.Size = New System.Drawing.Size(148, 90)
        Me.ItemPanel2.TabIndex = 1
        Me.ItemPanel2.Text = "ItemPanel2"
        '
        'Chk_VerMarcadas
        '
        Me.Chk_VerMarcadas.Name = "Chk_VerMarcadas"
        Me.Chk_VerMarcadas.Text = "MARCARDAS"
        '
        'Chk_VerActivas
        '
        Me.Chk_VerActivas.Name = "Chk_VerActivas"
        Me.Chk_VerActivas.Text = "ACTIVAS"
        '
        'Chk_VerCerradas
        '
        Me.Chk_VerCerradas.Name = "Chk_VerCerradas"
        Me.Chk_VerCerradas.Text = "CERRADAS"
        '
        'Chk_VerNulas
        '
        Me.Chk_VerNulas.Name = "Chk_VerNulas"
        Me.Chk_VerNulas.Text = "NULAS"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.Btn_Impresora)
        Me.GroupBox3.Controls.Add(Me.Txt_Impresora)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(184, 122)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(444, 49)
        Me.GroupBox3.TabIndex = 110
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Impresora vales"
        '
        'Btn_Impresora
        '
        Me.Btn_Impresora.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Impresora.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Impresora.Image = CType(resources.GetObject("Btn_Impresora.Image"), System.Drawing.Image)
        Me.Btn_Impresora.Location = New System.Drawing.Point(401, 20)
        Me.Btn_Impresora.Name = "Btn_Impresora"
        Me.Btn_Impresora.Size = New System.Drawing.Size(37, 23)
        Me.Btn_Impresora.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Impresora.TabIndex = 51
        Me.Btn_Impresora.Text = "..."
        Me.Btn_Impresora.Tooltip = "Buscar ruta de archivos DBF"
        '
        'Txt_Impresora
        '
        Me.Txt_Impresora.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Impresora.Border.Class = "TextBoxBorder"
        Me.Txt_Impresora.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Impresora.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Impresora.ForeColor = System.Drawing.Color.Black
        Me.Txt_Impresora.Location = New System.Drawing.Point(6, 21)
        Me.Txt_Impresora.Name = "Txt_Impresora"
        Me.Txt_Impresora.PreventEnterBeep = True
        Me.Txt_Impresora.ReadOnly = True
        Me.Txt_Impresora.Size = New System.Drawing.Size(390, 22)
        Me.Txt_Impresora.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.Btn_RutaImagen)
        Me.GroupBox4.Controls.Add(Me.Txt_RutaImagen)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(184, 193)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(444, 49)
        Me.GroupBox4.TabIndex = 111
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Ruta imagen"
        '
        'Btn_RutaImagen
        '
        Me.Btn_RutaImagen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_RutaImagen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_RutaImagen.Image = Global.BkSpecialPrograms.My.Resources.Resources.folder_open1
        Me.Btn_RutaImagen.Location = New System.Drawing.Point(401, 21)
        Me.Btn_RutaImagen.Name = "Btn_RutaImagen"
        Me.Btn_RutaImagen.Size = New System.Drawing.Size(37, 23)
        Me.Btn_RutaImagen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_RutaImagen.TabIndex = 51
        Me.Btn_RutaImagen.Text = "..."
        Me.Btn_RutaImagen.Tooltip = "Buscar ruta de archivos DBF"
        '
        'Txt_RutaImagen
        '
        Me.Txt_RutaImagen.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_RutaImagen.Border.Class = "TextBoxBorder"
        Me.Txt_RutaImagen.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_RutaImagen.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_RutaImagen.ForeColor = System.Drawing.Color.Black
        Me.Txt_RutaImagen.Location = New System.Drawing.Point(6, 21)
        Me.Txt_RutaImagen.Name = "Txt_RutaImagen"
        Me.Txt_RutaImagen.PreventEnterBeep = True
        Me.Txt_RutaImagen.ReadOnly = True
        Me.Txt_RutaImagen.Size = New System.Drawing.Size(390, 22)
        Me.Txt_RutaImagen.TabIndex = 1
        '
        'Frm_Configuracion_vales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 304)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Grupo_Estado)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Configuracion_vales"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de estación"
        Me.GroupBox1.ResumeLayout(False)
        Me.Grupo_Estado.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Segundos_Act As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Grupo_Estado As System.Windows.Forms.GroupBox
    Friend WithEvents ItemPanel1 As DevComponents.DotNetBar.ItemPanel
    Public WithEvents Rdb_Retira_Cliente As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Rdb_Despacho_Domicilio As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Rdb_Ambos As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ItemPanel2 As DevComponents.DotNetBar.ItemPanel
    Public WithEvents Chk_VerMarcadas As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_VerActivas As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_VerCerradas As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Chk_VerNulas As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_Impresora As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_RutaImagen As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Impresora As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_RutaImagen As DevComponents.DotNetBar.ButtonX
End Class
