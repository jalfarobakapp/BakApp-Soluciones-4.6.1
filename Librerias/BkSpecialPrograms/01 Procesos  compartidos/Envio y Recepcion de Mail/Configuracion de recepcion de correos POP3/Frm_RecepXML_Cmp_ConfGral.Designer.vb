<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RecepXML_Cmp_ConfGral
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RecepXML_Cmp_ConfGral))
        Me.Grupo_RecepXMLComp = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Line2 = New DevComponents.DotNetBar.Controls.Line()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Rdb_IMAP_DescHoy = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_IMAP_DescNoLeidos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_IMAP_CarpetaLectura = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_CarpetaDestino = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_CarpetaLectura = New DevComponents.DotNetBar.LabelX()
        Me.Txt_IMAP_CarpetaDestino = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rdb_IMAP = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_POP3 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_RecepXMLCmp_MarcaAgua = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_RecepXMLCmp_ElimiCorreosPOP3 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_BuscarSMTPRecepXMLComp = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_CuentaSMTP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Grupo_RecepXMLComp.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grupo_RecepXMLComp
        '
        Me.Grupo_RecepXMLComp.BackColor = System.Drawing.Color.White
        Me.Grupo_RecepXMLComp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_RecepXMLComp.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_RecepXMLComp.Controls.Add(Me.Line2)
        Me.Grupo_RecepXMLComp.Controls.Add(Me.Line1)
        Me.Grupo_RecepXMLComp.Controls.Add(Me.Txt_IMAP_CarpetaLectura)
        Me.Grupo_RecepXMLComp.Controls.Add(Me.Lbl_CarpetaDestino)
        Me.Grupo_RecepXMLComp.Controls.Add(Me.Lbl_CarpetaLectura)
        Me.Grupo_RecepXMLComp.Controls.Add(Me.Txt_IMAP_CarpetaDestino)
        Me.Grupo_RecepXMLComp.Controls.Add(Me.Rdb_IMAP)
        Me.Grupo_RecepXMLComp.Controls.Add(Me.Rdb_POP3)
        Me.Grupo_RecepXMLComp.Controls.Add(Me.Txt_RecepXMLCmp_MarcaAgua)
        Me.Grupo_RecepXMLComp.Controls.Add(Me.LabelX18)
        Me.Grupo_RecepXMLComp.Controls.Add(Me.Chk_RecepXMLCmp_ElimiCorreosPOP3)
        Me.Grupo_RecepXMLComp.Controls.Add(Me.Btn_BuscarSMTPRecepXMLComp)
        Me.Grupo_RecepXMLComp.Controls.Add(Me.Txt_CuentaSMTP)
        Me.Grupo_RecepXMLComp.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_RecepXMLComp.Location = New System.Drawing.Point(4, 12)
        Me.Grupo_RecepXMLComp.Name = "Grupo_RecepXMLComp"
        Me.Grupo_RecepXMLComp.Size = New System.Drawing.Size(591, 311)
        '
        '
        '
        Me.Grupo_RecepXMLComp.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_RecepXMLComp.Style.BackColorGradientAngle = 90
        Me.Grupo_RecepXMLComp.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_RecepXMLComp.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_RecepXMLComp.Style.BorderBottomWidth = 1
        Me.Grupo_RecepXMLComp.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_RecepXMLComp.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_RecepXMLComp.Style.BorderLeftWidth = 1
        Me.Grupo_RecepXMLComp.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_RecepXMLComp.Style.BorderRightWidth = 1
        Me.Grupo_RecepXMLComp.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_RecepXMLComp.Style.BorderTopWidth = 1
        Me.Grupo_RecepXMLComp.Style.CornerDiameter = 4
        Me.Grupo_RecepXMLComp.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_RecepXMLComp.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_RecepXMLComp.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_RecepXMLComp.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_RecepXMLComp.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_RecepXMLComp.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_RecepXMLComp.TabIndex = 89
        Me.Grupo_RecepXMLComp.Text = "Configuración de recepción de archivos XML de compras electronicas de los proveed" &
    "ores"
        '
        'Line2
        '
        Me.Line2.BackColor = System.Drawing.Color.Transparent
        Me.Line2.ForeColor = System.Drawing.Color.Black
        Me.Line2.Location = New System.Drawing.Point(6, 40)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(565, 23)
        Me.Line2.TabIndex = 132
        Me.Line2.Text = "Line2"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.Transparent
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(6, 225)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(565, 23)
        Me.Line1.TabIndex = 131
        Me.Line1.Text = "Line1"
        '
        'Rdb_IMAP_DescHoy
        '
        Me.Rdb_IMAP_DescHoy.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_IMAP_DescHoy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_IMAP_DescHoy.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_IMAP_DescHoy.Checked = True
        Me.Rdb_IMAP_DescHoy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_IMAP_DescHoy.CheckValue = "Y"
        Me.Rdb_IMAP_DescHoy.FocusCuesEnabled = False
        Me.Rdb_IMAP_DescHoy.ForeColor = System.Drawing.Color.Black
        Me.Rdb_IMAP_DescHoy.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_IMAP_DescHoy.Name = "Rdb_IMAP_DescHoy"
        Me.Rdb_IMAP_DescHoy.Size = New System.Drawing.Size(271, 17)
        Me.Rdb_IMAP_DescHoy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_IMAP_DescHoy.TabIndex = 130
        Me.Rdb_IMAP_DescHoy.Text = "Descargar todos los correos del día (recomendado)"
        '
        'Rdb_IMAP_DescNoLeidos
        '
        Me.Rdb_IMAP_DescNoLeidos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_IMAP_DescNoLeidos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_IMAP_DescNoLeidos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_IMAP_DescNoLeidos.FocusCuesEnabled = False
        Me.Rdb_IMAP_DescNoLeidos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_IMAP_DescNoLeidos.Location = New System.Drawing.Point(280, 3)
        Me.Rdb_IMAP_DescNoLeidos.Name = "Rdb_IMAP_DescNoLeidos"
        Me.Rdb_IMAP_DescNoLeidos.Size = New System.Drawing.Size(152, 17)
        Me.Rdb_IMAP_DescNoLeidos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_IMAP_DescNoLeidos.TabIndex = 129
        Me.Rdb_IMAP_DescNoLeidos.Text = "Descargar correos no leidos"
        '
        'Txt_IMAP_CarpetaLectura
        '
        Me.Txt_IMAP_CarpetaLectura.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_IMAP_CarpetaLectura.Border.Class = "TextBoxBorder"
        Me.Txt_IMAP_CarpetaLectura.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_IMAP_CarpetaLectura.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_IMAP_CarpetaLectura.ForeColor = System.Drawing.Color.Black
        Me.Txt_IMAP_CarpetaLectura.Location = New System.Drawing.Point(122, 141)
        Me.Txt_IMAP_CarpetaLectura.Name = "Txt_IMAP_CarpetaLectura"
        Me.Txt_IMAP_CarpetaLectura.PreventEnterBeep = True
        Me.Txt_IMAP_CarpetaLectura.ReadOnly = True
        Me.Txt_IMAP_CarpetaLectura.Size = New System.Drawing.Size(449, 22)
        Me.Txt_IMAP_CarpetaLectura.TabIndex = 126
        '
        'Lbl_CarpetaDestino
        '
        Me.Lbl_CarpetaDestino.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_CarpetaDestino.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_CarpetaDestino.ForeColor = System.Drawing.Color.Black
        Me.Lbl_CarpetaDestino.Location = New System.Drawing.Point(25, 169)
        Me.Lbl_CarpetaDestino.Name = "Lbl_CarpetaDestino"
        Me.Lbl_CarpetaDestino.Size = New System.Drawing.Size(91, 20)
        Me.Lbl_CarpetaDestino.TabIndex = 127
        Me.Lbl_CarpetaDestino.Text = "Carpeta destino"
        '
        'Lbl_CarpetaLectura
        '
        Me.Lbl_CarpetaLectura.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_CarpetaLectura.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_CarpetaLectura.ForeColor = System.Drawing.Color.Black
        Me.Lbl_CarpetaLectura.Location = New System.Drawing.Point(25, 141)
        Me.Lbl_CarpetaLectura.Name = "Lbl_CarpetaLectura"
        Me.Lbl_CarpetaLectura.Size = New System.Drawing.Size(75, 20)
        Me.Lbl_CarpetaLectura.TabIndex = 125
        Me.Lbl_CarpetaLectura.Text = "Carpeta lectura"
        '
        'Txt_IMAP_CarpetaDestino
        '
        Me.Txt_IMAP_CarpetaDestino.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_IMAP_CarpetaDestino.Border.Class = "TextBoxBorder"
        Me.Txt_IMAP_CarpetaDestino.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_IMAP_CarpetaDestino.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_IMAP_CarpetaDestino.ForeColor = System.Drawing.Color.Black
        Me.Txt_IMAP_CarpetaDestino.Location = New System.Drawing.Point(122, 169)
        Me.Txt_IMAP_CarpetaDestino.Name = "Txt_IMAP_CarpetaDestino"
        Me.Txt_IMAP_CarpetaDestino.PreventEnterBeep = True
        Me.Txt_IMAP_CarpetaDestino.ReadOnly = True
        Me.Txt_IMAP_CarpetaDestino.Size = New System.Drawing.Size(449, 22)
        Me.Txt_IMAP_CarpetaDestino.TabIndex = 128
        '
        'Rdb_IMAP
        '
        Me.Rdb_IMAP.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_IMAP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_IMAP.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_IMAP.FocusCuesEnabled = False
        Me.Rdb_IMAP.ForeColor = System.Drawing.Color.Black
        Me.Rdb_IMAP.Location = New System.Drawing.Point(6, 113)
        Me.Rdb_IMAP.Name = "Rdb_IMAP"
        Me.Rdb_IMAP.Size = New System.Drawing.Size(56, 22)
        Me.Rdb_IMAP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_IMAP.TabIndex = 124
        Me.Rdb_IMAP.Text = "IMAP"
        '
        'Rdb_POP3
        '
        Me.Rdb_POP3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_POP3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_POP3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_POP3.Checked = True
        Me.Rdb_POP3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_POP3.CheckValue = "Y"
        Me.Rdb_POP3.FocusCuesEnabled = False
        Me.Rdb_POP3.ForeColor = System.Drawing.Color.Black
        Me.Rdb_POP3.Location = New System.Drawing.Point(6, 64)
        Me.Rdb_POP3.Name = "Rdb_POP3"
        Me.Rdb_POP3.Size = New System.Drawing.Size(56, 22)
        Me.Rdb_POP3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_POP3.TabIndex = 123
        Me.Rdb_POP3.Text = "POP3"
        '
        'Txt_RecepXMLCmp_MarcaAgua
        '
        Me.Txt_RecepXMLCmp_MarcaAgua.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_RecepXMLCmp_MarcaAgua.Border.Class = "TextBoxBorder"
        Me.Txt_RecepXMLCmp_MarcaAgua.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_RecepXMLCmp_MarcaAgua.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_RecepXMLCmp_MarcaAgua.ForeColor = System.Drawing.Color.Black
        Me.Txt_RecepXMLCmp_MarcaAgua.Location = New System.Drawing.Point(171, 253)
        Me.Txt_RecepXMLCmp_MarcaAgua.MaxLength = 20
        Me.Txt_RecepXMLCmp_MarcaAgua.Name = "Txt_RecepXMLCmp_MarcaAgua"
        Me.Txt_RecepXMLCmp_MarcaAgua.PreventEnterBeep = True
        Me.Txt_RecepXMLCmp_MarcaAgua.Size = New System.Drawing.Size(400, 22)
        Me.Txt_RecepXMLCmp_MarcaAgua.TabIndex = 120
        Me.Txt_RecepXMLCmp_MarcaAgua.WatermarkText = "Ingrese la marca de agua, si esta vacío no se imprime, Max. 20 caracteres"
        '
        'LabelX18
        '
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.ForeColor = System.Drawing.Color.Black
        Me.LabelX18.Location = New System.Drawing.Point(6, 245)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(126, 34)
        Me.LabelX18.TabIndex = 121
        Me.LabelX18.Text = "Marca de agua en PDF " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de proveedor"
        Me.LabelX18.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Chk_RecepXMLCmp_ElimiCorreosPOP3
        '
        Me.Chk_RecepXMLCmp_ElimiCorreosPOP3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_RecepXMLCmp_ElimiCorreosPOP3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_RecepXMLCmp_ElimiCorreosPOP3.CheckBoxImageChecked = CType(resources.GetObject("Chk_RecepXMLCmp_ElimiCorreosPOP3.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_RecepXMLCmp_ElimiCorreosPOP3.FocusCuesEnabled = False
        Me.Chk_RecepXMLCmp_ElimiCorreosPOP3.ForeColor = System.Drawing.Color.Black
        Me.Chk_RecepXMLCmp_ElimiCorreosPOP3.Location = New System.Drawing.Point(25, 87)
        Me.Chk_RecepXMLCmp_ElimiCorreosPOP3.Name = "Chk_RecepXMLCmp_ElimiCorreosPOP3"
        Me.Chk_RecepXMLCmp_ElimiCorreosPOP3.Size = New System.Drawing.Size(369, 20)
        Me.Chk_RecepXMLCmp_ElimiCorreosPOP3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_RecepXMLCmp_ElimiCorreosPOP3.TabIndex = 118
        Me.Chk_RecepXMLCmp_ElimiCorreosPOP3.Text = "Eliminar correos después de descargar (elimina todos los correos leídos)"
        '
        'Btn_BuscarSMTPRecepXMLComp
        '
        Me.Btn_BuscarSMTPRecepXMLComp.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText
        Me.Btn_BuscarSMTPRecepXMLComp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_BuscarSMTPRecepXMLComp.Image = CType(resources.GetObject("Btn_BuscarSMTPRecepXMLComp.Image"), System.Drawing.Image)
        Me.Btn_BuscarSMTPRecepXMLComp.Location = New System.Drawing.Point(6, 12)
        Me.Btn_BuscarSMTPRecepXMLComp.Name = "Btn_BuscarSMTPRecepXMLComp"
        Me.Btn_BuscarSMTPRecepXMLComp.Size = New System.Drawing.Size(159, 22)
        Me.Btn_BuscarSMTPRecepXMLComp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_BuscarSMTPRecepXMLComp.TabIndex = 89
        Me.Btn_BuscarSMTPRecepXMLComp.Text = "Seleccionar cuenta (SMTP)"
        '
        'Txt_CuentaSMTP
        '
        Me.Txt_CuentaSMTP.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CuentaSMTP.Border.Class = "TextBoxBorder"
        Me.Txt_CuentaSMTP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CuentaSMTP.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CuentaSMTP.ForeColor = System.Drawing.Color.Black
        Me.Txt_CuentaSMTP.Location = New System.Drawing.Point(171, 12)
        Me.Txt_CuentaSMTP.Name = "Txt_CuentaSMTP"
        Me.Txt_CuentaSMTP.PreventEnterBeep = True
        Me.Txt_CuentaSMTP.Size = New System.Drawing.Size(400, 22)
        Me.Txt_CuentaSMTP.TabIndex = 88
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 334)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(600, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 90
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.69828!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.30172!))
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_IMAP_DescHoy, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_IMAP_DescNoLeidos, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(25, 197)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(464, 23)
        Me.TableLayoutPanel1.TabIndex = 91
        '
        'Frm_RecepXML_Cmp_ConfGral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 375)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Grupo_RecepXMLComp)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_RecepXML_Cmp_ConfGral"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONFIGURACION DE RECEPCION DE CORREOS DE PROVEEDORES"
        Me.Grupo_RecepXMLComp.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grupo_RecepXMLComp As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Rdb_IMAP_DescHoy As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_IMAP_DescNoLeidos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_IMAP_CarpetaLectura As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_CarpetaDestino As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_CarpetaLectura As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_IMAP_CarpetaDestino As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Rdb_IMAP As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_POP3 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_RecepXMLCmp_MarcaAgua As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_RecepXMLCmp_ElimiCorreosPOP3 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_BuscarSMTPRecepXMLComp As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_CuentaSMTP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Line2 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
