﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Formulario_Lector_Barra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Formulario_Lector_Barra))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Autorizar_Permiso = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_VerCodigosLeidos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Limpiar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Image_Barcode = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Codigo_Barras = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_Teclear = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Image_QRCode = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Chk_LeerSoloUnaVezCodBarra = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_LeerNormal = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_LeerMayusculas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_LeerMinusculas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Aceptar, Me.Btn_Autorizar_Permiso, Me.Btn_VerCodigosLeidos, Me.Btn_Limpiar})
        Me.Bar1.Location = New System.Drawing.Point(0, 450)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(648, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 126
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.ImageAlt = CType(resources.GetObject("Btn_Aceptar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Text = "Aceptar"
        '
        'Btn_Autorizar_Permiso
        '
        Me.Btn_Autorizar_Permiso.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Autorizar_Permiso.ForeColor = System.Drawing.Color.Black
        Me.Btn_Autorizar_Permiso.Image = CType(resources.GetObject("Btn_Autorizar_Permiso.Image"), System.Drawing.Image)
        Me.Btn_Autorizar_Permiso.ImageAlt = CType(resources.GetObject("Btn_Autorizar_Permiso.ImageAlt"), System.Drawing.Image)
        Me.Btn_Autorizar_Permiso.Name = "Btn_Autorizar_Permiso"
        Me.Btn_Autorizar_Permiso.Tooltip = "Permitir el movimiento de productos sin validar"
        '
        'Btn_VerCodigosLeidos
        '
        Me.Btn_VerCodigosLeidos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_VerCodigosLeidos.ForeColor = System.Drawing.Color.Black
        Me.Btn_VerCodigosLeidos.Image = CType(resources.GetObject("Btn_VerCodigosLeidos.Image"), System.Drawing.Image)
        Me.Btn_VerCodigosLeidos.ImageAlt = CType(resources.GetObject("Btn_VerCodigosLeidos.ImageAlt"), System.Drawing.Image)
        Me.Btn_VerCodigosLeidos.Name = "Btn_VerCodigosLeidos"
        Me.Btn_VerCodigosLeidos.Tooltip = "Permitir el movimiento de productos sin validar"
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Limpiar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Limpiar.Image = CType(resources.GetObject("Btn_Limpiar.Image"), System.Drawing.Image)
        Me.Btn_Limpiar.ImageAlt = CType(resources.GetObject("Btn_Limpiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Limpiar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Tooltip = "Nuevo, limpiar documento [F5]"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 74)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(632, 337)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 125
        Me.GroupPanel1.Text = "Productos marcados"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
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
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.MultiSelect = False
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(626, 314)
        Me.Grilla.TabIndex = 1
        '
        'Image_Barcode
        '
        Me.Image_Barcode.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Image_Barcode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Image_Barcode.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Image_Barcode.ForeColor = System.Drawing.Color.Black
        Me.Image_Barcode.Image = CType(resources.GetObject("Image_Barcode.Image"), System.Drawing.Image)
        Me.Image_Barcode.Location = New System.Drawing.Point(559, 10)
        Me.Image_Barcode.Name = "Image_Barcode"
        Me.Image_Barcode.ReflectionEnabled = False
        Me.Image_Barcode.Size = New System.Drawing.Size(40, 30)
        Me.Image_Barcode.TabIndex = 129
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(93, 23)
        Me.LabelX1.TabIndex = 128
        Me.LabelX1.Text = "Lector de códigos"
        '
        'Txt_Codigo_Barras
        '
        Me.Txt_Codigo_Barras.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Codigo_Barras.Border.Class = "TextBoxBorder"
        Me.Txt_Codigo_Barras.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Codigo_Barras.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Codigo_Barras.FocusHighlightEnabled = True
        Me.Txt_Codigo_Barras.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Codigo_Barras.ForeColor = System.Drawing.Color.Black
        Me.Txt_Codigo_Barras.Location = New System.Drawing.Point(111, 10)
        Me.Txt_Codigo_Barras.MaxLength = 21
        Me.Txt_Codigo_Barras.Name = "Txt_Codigo_Barras"
        Me.Txt_Codigo_Barras.PreventEnterBeep = True
        Me.Txt_Codigo_Barras.Size = New System.Drawing.Size(442, 29)
        Me.Txt_Codigo_Barras.TabIndex = 127
        Me.Txt_Codigo_Barras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Chk_Teclear
        '
        Me.Chk_Teclear.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Teclear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Teclear.CheckBoxImageChecked = CType(resources.GetObject("Chk_Teclear.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Teclear.FocusCuesEnabled = False
        Me.Chk_Teclear.ForeColor = System.Drawing.Color.Black
        Me.Chk_Teclear.Location = New System.Drawing.Point(12, 45)
        Me.Chk_Teclear.Name = "Chk_Teclear"
        Me.Chk_Teclear.Size = New System.Drawing.Size(204, 23)
        Me.Chk_Teclear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Teclear.TabIndex = 130
        Me.Chk_Teclear.Text = "Ingresar código con el TECLEANDO"
        '
        'Image_QRCode
        '
        Me.Image_QRCode.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Image_QRCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Image_QRCode.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Image_QRCode.ForeColor = System.Drawing.Color.Black
        Me.Image_QRCode.Image = CType(resources.GetObject("Image_QRCode.Image"), System.Drawing.Image)
        Me.Image_QRCode.Location = New System.Drawing.Point(605, 10)
        Me.Image_QRCode.Name = "Image_QRCode"
        Me.Image_QRCode.ReflectionEnabled = False
        Me.Image_QRCode.Size = New System.Drawing.Size(36, 32)
        Me.Image_QRCode.TabIndex = 131
        Me.Image_QRCode.Visible = False
        '
        'Chk_LeerSoloUnaVezCodBarra
        '
        Me.Chk_LeerSoloUnaVezCodBarra.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_LeerSoloUnaVezCodBarra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_LeerSoloUnaVezCodBarra.CheckBoxImageChecked = CType(resources.GetObject("Chk_LeerSoloUnaVezCodBarra.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_LeerSoloUnaVezCodBarra.FocusCuesEnabled = False
        Me.Chk_LeerSoloUnaVezCodBarra.ForeColor = System.Drawing.Color.Black
        Me.Chk_LeerSoloUnaVezCodBarra.Location = New System.Drawing.Point(9, 417)
        Me.Chk_LeerSoloUnaVezCodBarra.Name = "Chk_LeerSoloUnaVezCodBarra"
        Me.Chk_LeerSoloUnaVezCodBarra.Size = New System.Drawing.Size(204, 23)
        Me.Chk_LeerSoloUnaVezCodBarra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_LeerSoloUnaVezCodBarra.TabIndex = 132
        Me.Chk_LeerSoloUnaVezCodBarra.Text = "Solo leer una vez el código de barras"
        '
        'Rdb_LeerNormal
        '
        Me.Rdb_LeerNormal.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_LeerNormal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_LeerNormal.CheckBoxImageChecked = CType(resources.GetObject("Rdb_LeerNormal.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_LeerNormal.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_LeerNormal.Checked = True
        Me.Rdb_LeerNormal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_LeerNormal.CheckValue = "Y"
        Me.Rdb_LeerNormal.FocusCuesEnabled = False
        Me.Rdb_LeerNormal.ForeColor = System.Drawing.Color.Black
        Me.Rdb_LeerNormal.Location = New System.Drawing.Point(4, 4)
        Me.Rdb_LeerNormal.Name = "Rdb_LeerNormal"
        Me.Rdb_LeerNormal.Size = New System.Drawing.Size(60, 20)
        Me.Rdb_LeerNormal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_LeerNormal.TabIndex = 134
        Me.Rdb_LeerNormal.TabStop = False
        Me.Rdb_LeerNormal.Text = "Normal"
        '
        'Rdb_LeerMayusculas
        '
        Me.Rdb_LeerMayusculas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_LeerMayusculas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_LeerMayusculas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_LeerMayusculas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_LeerMayusculas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_LeerMayusculas.FocusCuesEnabled = False
        Me.Rdb_LeerMayusculas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_LeerMayusculas.Location = New System.Drawing.Point(83, 4)
        Me.Rdb_LeerMayusculas.Name = "Rdb_LeerMayusculas"
        Me.Rdb_LeerMayusculas.Size = New System.Drawing.Size(71, 19)
        Me.Rdb_LeerMayusculas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_LeerMayusculas.TabIndex = 135
        Me.Rdb_LeerMayusculas.TabStop = False
        Me.Rdb_LeerMayusculas.Text = "Mayúsculas"
        '
        'Rdb_LeerMinusculas
        '
        Me.Rdb_LeerMinusculas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_LeerMinusculas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_LeerMinusculas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_LeerMinusculas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_LeerMinusculas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_LeerMinusculas.FocusCuesEnabled = False
        Me.Rdb_LeerMinusculas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_LeerMinusculas.Location = New System.Drawing.Point(162, 4)
        Me.Rdb_LeerMinusculas.Name = "Rdb_LeerMinusculas"
        Me.Rdb_LeerMinusculas.Size = New System.Drawing.Size(72, 19)
        Me.Rdb_LeerMinusculas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_LeerMinusculas.TabIndex = 136
        Me.Rdb_LeerMinusculas.TabStop = False
        Me.Rdb_LeerMinusculas.Text = "Minúsculas"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(277, 417)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(102, 23)
        Me.LabelX2.TabIndex = 137
        Me.LabelX2.Text = "Leer códigos como: "
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_LeerNormal, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_LeerMayusculas, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_LeerMinusculas, 2, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(385, 417)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(238, 28)
        Me.TableLayoutPanel1.TabIndex = 138
        '
        'Frm_Formulario_Lector_Barra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 491)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Chk_LeerSoloUnaVezCodBarra)
        Me.Controls.Add(Me.Image_QRCode)
        Me.Controls.Add(Me.Chk_Teclear)
        Me.Controls.Add(Me.Image_Barcode)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Txt_Codigo_Barras)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Formulario_Lector_Barra"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VALIDACION POR CODIGO DE BARRAS"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Image_Barcode As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Codigo_Barras As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Autorizar_Permiso As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Teclear As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Image_QRCode As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Chk_LeerSoloUnaVezCodBarra As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_VerCodigosLeidos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Limpiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Rdb_LeerNormal As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_LeerMayusculas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_LeerMinusculas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
