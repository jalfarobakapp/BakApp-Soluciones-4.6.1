<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Pagos_Generales_Saldo_NoAsig
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Pagos_Generales_Saldo_NoAsig))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Doc_Asociado_Incorporar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_Anticipo = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Labelx5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Saldo = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Tidp = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Vavudp = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_Vadp = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Nucudp = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Refanti = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.BtnActualizarLista = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Doc_Anticipo = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Ver_Documento = New DevComponents.DotNetBar.ButtonX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar, Me.Btn_Doc_Asociado_Incorporar})
        Me.Bar1.Location = New System.Drawing.Point(0, 228)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(637, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 36
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Tooltip = "Grabar [F4]"
        '
        'Btn_Doc_Asociado_Incorporar
        '
        Me.Btn_Doc_Asociado_Incorporar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Doc_Asociado_Incorporar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Doc_Asociado_Incorporar.Image = CType(resources.GetObject("Btn_Doc_Asociado_Incorporar.Image"), System.Drawing.Image)
        Me.Btn_Doc_Asociado_Incorporar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Doc_Asociado_Incorporar.Name = "Btn_Doc_Asociado_Incorporar"
        Me.Btn_Doc_Asociado_Incorporar.Tooltip = "Ingresar documento ('NVV','RES','PRO') al anticipo"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Btn_Ver_Documento)
        Me.GroupPanel3.Controls.Add(Me.Lbl_Doc_Anticipo)
        Me.GroupPanel3.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupPanel3.Controls.Add(Me.LabelX8)
        Me.GroupPanel3.Controls.Add(Me.Txt_Refanti)
        Me.GroupPanel3.Controls.Add(Me.LabelX7)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(614, 210)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 50
        Me.GroupPanel3.Text = "Información para el saldo no asignado (anticipo) del documento de pago"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Anticipo, 5, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX9, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX2, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX3, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Labelx5, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX4, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX6, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Saldo, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Tidp, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Txt_Vavudp, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Vadp, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Nucudp, 1, 1)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 12)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(599, 61)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'Lbl_Anticipo
        '
        Me.Lbl_Anticipo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Anticipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Anticipo.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Anticipo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Anticipo.Location = New System.Drawing.Point(499, 34)
        Me.Lbl_Anticipo.Name = "Lbl_Anticipo"
        Me.Lbl_Anticipo.Size = New System.Drawing.Size(96, 21)
        Me.Lbl_Anticipo.TabIndex = 9
        Me.Lbl_Anticipo.Text = "..."
        Me.Lbl_Anticipo.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(4, 4)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(92, 23)
        Me.LabelX9.TabIndex = 5
        Me.LabelX9.Text = "TDP"
        Me.LabelX9.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(103, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(92, 23)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Número"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(202, 4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(91, 23)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Valor"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Labelx5
        '
        Me.Labelx5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Labelx5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Labelx5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelx5.ForeColor = System.Drawing.Color.Black
        Me.Labelx5.Location = New System.Drawing.Point(301, 4)
        Me.Labelx5.Name = "Labelx5"
        Me.Labelx5.Size = New System.Drawing.Size(91, 23)
        Me.Labelx5.TabIndex = 5
        Me.Labelx5.Text = "Saldo"
        Me.Labelx5.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(400, 4)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(91, 23)
        Me.LabelX4.TabIndex = 6
        Me.LabelX4.Text = "Como vuelto"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(499, 4)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(91, 23)
        Me.LabelX6.TabIndex = 6
        Me.LabelX6.Text = "Como anticipo"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Lbl_Saldo
        '
        Me.Lbl_Saldo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Saldo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Saldo.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Saldo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Saldo.Location = New System.Drawing.Point(301, 34)
        Me.Lbl_Saldo.Name = "Lbl_Saldo"
        Me.Lbl_Saldo.Size = New System.Drawing.Size(92, 21)
        Me.Lbl_Saldo.TabIndex = 6
        Me.Lbl_Saldo.Text = "..."
        Me.Lbl_Saldo.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Lbl_Tidp
        '
        Me.Lbl_Tidp.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Tidp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Tidp.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Tidp.Location = New System.Drawing.Point(4, 34)
        Me.Lbl_Tidp.Name = "Lbl_Tidp"
        Me.Lbl_Tidp.Size = New System.Drawing.Size(92, 21)
        Me.Lbl_Tidp.TabIndex = 6
        Me.Lbl_Tidp.Text = "..."
        Me.Lbl_Tidp.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Txt_Vavudp
        '
        Me.Txt_Vavudp.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Vavudp.Border.Class = "TextBoxBorder"
        Me.Txt_Vavudp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Vavudp.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Vavudp.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Vavudp.ForeColor = System.Drawing.Color.Black
        Me.Txt_Vavudp.Location = New System.Drawing.Point(400, 34)
        Me.Txt_Vavudp.Name = "Txt_Vavudp"
        Me.Txt_Vavudp.PreventEnterBeep = True
        Me.Txt_Vavudp.Size = New System.Drawing.Size(92, 21)
        Me.Txt_Vavudp.TabIndex = 0
        Me.Txt_Vavudp.Text = "99.999.999"
        Me.Txt_Vavudp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Lbl_Vadp
        '
        Me.Lbl_Vadp.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Vadp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Vadp.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Vadp.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Vadp.Location = New System.Drawing.Point(202, 34)
        Me.Lbl_Vadp.Name = "Lbl_Vadp"
        Me.Lbl_Vadp.Size = New System.Drawing.Size(92, 21)
        Me.Lbl_Vadp.TabIndex = 6
        Me.Lbl_Vadp.Text = "..."
        Me.Lbl_Vadp.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Lbl_Nucudp
        '
        Me.Lbl_Nucudp.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Nucudp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nucudp.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nucudp.Location = New System.Drawing.Point(103, 34)
        Me.Lbl_Nucudp.Name = "Lbl_Nucudp"
        Me.Lbl_Nucudp.Size = New System.Drawing.Size(92, 21)
        Me.Lbl_Nucudp.TabIndex = 5
        Me.Lbl_Nucudp.Text = "..."
        Me.Lbl_Nucudp.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(7, 126)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(516, 29)
        Me.LabelX8.TabIndex = 8
        Me.LabelX8.Text = "Documento de compromiso relacionado al anticipo. (Antecedente complementario)"
        '
        'Txt_Refanti
        '
        Me.Txt_Refanti.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Refanti.Border.Class = "TextBoxBorder"
        Me.Txt_Refanti.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Refanti.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Refanti.ForeColor = System.Drawing.Color.Black
        Me.Txt_Refanti.Location = New System.Drawing.Point(6, 98)
        Me.Txt_Refanti.Name = "Txt_Refanti"
        Me.Txt_Refanti.PreventEnterBeep = True
        Me.Txt_Refanti.Size = New System.Drawing.Size(595, 22)
        Me.Txt_Refanti.TabIndex = 3
        Me.Txt_Refanti.Text = "REFERENCIA"
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(6, 79)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(291, 19)
        Me.LabelX7.TabIndex = 7
        Me.LabelX7.Text = "Indique una referencia para el anticipo."
        '
        'BtnActualizarLista
        '
        Me.BtnActualizarLista.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnActualizarLista.ForeColor = System.Drawing.Color.Black
        Me.BtnActualizarLista.Image = CType(resources.GetObject("BtnActualizarLista.Image"), System.Drawing.Image)
        Me.BtnActualizarLista.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnActualizarLista.Name = "BtnActualizarLista"
        Me.BtnActualizarLista.Tooltip = "Actualizar precios"
        '
        'Lbl_Doc_Anticipo
        '
        Me.Lbl_Doc_Anticipo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Doc_Anticipo.BackgroundStyle.Class = "RibbonGalleryContainer"
        Me.Lbl_Doc_Anticipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Doc_Anticipo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Doc_Anticipo.Location = New System.Drawing.Point(6, 151)
        Me.Lbl_Doc_Anticipo.Name = "Lbl_Doc_Anticipo"
        Me.Lbl_Doc_Anticipo.Size = New System.Drawing.Size(477, 22)
        Me.Lbl_Doc_Anticipo.TabIndex = 91
        '
        'Btn_Ver_Documento
        '
        Me.Btn_Ver_Documento.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Ver_Documento.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Ver_Documento.Location = New System.Drawing.Point(489, 150)
        Me.Btn_Ver_Documento.Name = "Btn_Ver_Documento"
        Me.Btn_Ver_Documento.Size = New System.Drawing.Size(112, 23)
        Me.Btn_Ver_Documento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Ver_Documento.TabIndex = 92
        Me.Btn_Ver_Documento.Text = "Ver documento"
        '
        'Frm_Pagos_Generales_Saldo_NoAsig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 269)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Pagos_Generales_Saldo_NoAsig"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SALDO, ANTICIPOS"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Anticipo As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Refanti As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Saldo As DevComponents.DotNetBar.LabelX
    Friend WithEvents Labelx5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Vadp As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Tidp As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Nucudp As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Vavudp As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Doc_Asociado_Incorporar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnActualizarLista As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Doc_Anticipo As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Ver_Documento As DevComponents.DotNetBar.ButtonX
End Class
