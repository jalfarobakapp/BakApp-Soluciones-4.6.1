<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Entidad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Entidad))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Guardar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Txt_ModFCC = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_ModNVV = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_ModOCC = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_ModFCV = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Txt_EntidadCompra = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_EntidadVenta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Guardar})
        Me.Bar1.Location = New System.Drawing.Point(0, 492)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(652, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 92
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Guardar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Guardar.Image = CType(resources.GetObject("Btn_Guardar.Image"), System.Drawing.Image)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Text = "Guardar"
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(28, 181)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(612, 295)
        '
        '
        '
        Me.GroupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel4.Style.BackColorGradientAngle = 90
        Me.GroupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderBottomWidth = 1
        Me.GroupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderLeftWidth = 1
        Me.GroupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderRightWidth = 1
        Me.GroupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderTopWidth = 1
        Me.GroupPanel4.Style.CornerDiameter = 4
        Me.GroupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel4.TabIndex = 101
        Me.GroupPanel4.Text = "Modalidades"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 457.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Txt_ModFCC, 1, 4)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX10, 0, 4)
        Me.TableLayoutPanel4.Controls.Add(Me.Txt_ModNVV, 1, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX9, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Txt_ModOCC, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Txt_ModFCV, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX4, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX6, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX7, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX8, 0, 0)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 5
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(600, 160)
        Me.TableLayoutPanel4.TabIndex = 6
        '
        'Txt_ModFCC
        '
        Me.Txt_ModFCC.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_ModFCC.Border.Class = "TextBoxBorder"
        Me.Txt_ModFCC.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_ModFCC.ButtonCustom.Image = Global.Sincroniza.Stock.Bakapp.My.Resources.Resources.button_filledcircle_find
        Me.Txt_ModFCC.ButtonCustom.Visible = True
        Me.Txt_ModFCC.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_ModFCC.ForeColor = System.Drawing.Color.Black
        Me.Txt_ModFCC.Location = New System.Drawing.Point(146, 128)
        Me.Txt_ModFCC.Name = "Txt_ModFCC"
        Me.Txt_ModFCC.PreventEnterBeep = True
        Me.Txt_ModFCC.Size = New System.Drawing.Size(451, 26)
        Me.Txt_ModFCC.TabIndex = 18
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(3, 128)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(137, 23)
        Me.LabelX10.TabIndex = 17
        Me.LabelX10.Text = "Modalidad FCC"
        '
        'Txt_ModNVV
        '
        Me.Txt_ModNVV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_ModNVV.Border.Class = "TextBoxBorder"
        Me.Txt_ModNVV.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_ModNVV.ButtonCustom.Image = Global.Sincroniza.Stock.Bakapp.My.Resources.Resources.button_filledcircle_find
        Me.Txt_ModNVV.ButtonCustom.Visible = True
        Me.Txt_ModNVV.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_ModNVV.ForeColor = System.Drawing.Color.Black
        Me.Txt_ModNVV.Location = New System.Drawing.Point(146, 96)
        Me.Txt_ModNVV.Name = "Txt_ModNVV"
        Me.Txt_ModNVV.PreventEnterBeep = True
        Me.Txt_ModNVV.Size = New System.Drawing.Size(451, 26)
        Me.Txt_ModNVV.TabIndex = 16
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(3, 96)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(137, 23)
        Me.LabelX9.TabIndex = 15
        Me.LabelX9.Text = "Modalidad NVV"
        '
        'Txt_ModOCC
        '
        Me.Txt_ModOCC.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_ModOCC.Border.Class = "TextBoxBorder"
        Me.Txt_ModOCC.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_ModOCC.ButtonCustom.Image = Global.Sincroniza.Stock.Bakapp.My.Resources.Resources.button_filledcircle_find
        Me.Txt_ModOCC.ButtonCustom.Visible = True
        Me.Txt_ModOCC.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_ModOCC.ForeColor = System.Drawing.Color.Black
        Me.Txt_ModOCC.Location = New System.Drawing.Point(146, 32)
        Me.Txt_ModOCC.Name = "Txt_ModOCC"
        Me.Txt_ModOCC.PreventEnterBeep = True
        Me.Txt_ModOCC.Size = New System.Drawing.Size(451, 26)
        Me.Txt_ModOCC.TabIndex = 14
        '
        'Txt_ModFCV
        '
        Me.Txt_ModFCV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_ModFCV.Border.Class = "TextBoxBorder"
        Me.Txt_ModFCV.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_ModFCV.ButtonCustom.Image = Global.Sincroniza.Stock.Bakapp.My.Resources.Resources.button_filledcircle_find
        Me.Txt_ModFCV.ButtonCustom.Visible = True
        Me.Txt_ModFCV.ButtonCustom2.Image = CType(resources.GetObject("Txt_ModFCV.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_ModFCV.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_ModFCV.ForeColor = System.Drawing.Color.Black
        Me.Txt_ModFCV.Location = New System.Drawing.Point(146, 64)
        Me.Txt_ModFCV.Name = "Txt_ModFCV"
        Me.Txt_ModFCV.PreventEnterBeep = True
        Me.Txt_ModFCV.Size = New System.Drawing.Size(451, 26)
        Me.Txt_ModFCV.TabIndex = 13
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 64)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(137, 23)
        Me.LabelX4.TabIndex = 6
        Me.LabelX4.Text = "Modalidad FCV"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 32)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(137, 23)
        Me.LabelX6.TabIndex = 4
        Me.LabelX6.Text = "Modalidad OCC"
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(146, 3)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(451, 23)
        Me.LabelX7.TabIndex = 2
        Me.LabelX7.Text = "Nombre"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(3, 3)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(137, 23)
        Me.LabelX8.TabIndex = 1
        Me.LabelX8.Text = "Modalidad"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(652, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 103
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(28, 31)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(612, 144)
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
        Me.GroupPanel3.TabIndex = 104
        Me.GroupPanel3.Text = "Entidades"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 457.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Txt_EntidadCompra, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Txt_EntidadVenta, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX5, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX3, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX2, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(600, 95)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'Txt_EntidadCompra
        '
        Me.Txt_EntidadCompra.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_EntidadCompra.Border.Class = "TextBoxBorder"
        Me.Txt_EntidadCompra.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_EntidadCompra.ButtonCustom.Image = Global.Sincroniza.Stock.Bakapp.My.Resources.Resources.button_filledcircle_find
        Me.Txt_EntidadCompra.ButtonCustom.Visible = True
        Me.Txt_EntidadCompra.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_EntidadCompra.ForeColor = System.Drawing.Color.Black
        Me.Txt_EntidadCompra.Location = New System.Drawing.Point(146, 32)
        Me.Txt_EntidadCompra.Name = "Txt_EntidadCompra"
        Me.Txt_EntidadCompra.PreventEnterBeep = True
        Me.Txt_EntidadCompra.Size = New System.Drawing.Size(451, 26)
        Me.Txt_EntidadCompra.TabIndex = 14
        '
        'Txt_EntidadVenta
        '
        Me.Txt_EntidadVenta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_EntidadVenta.Border.Class = "TextBoxBorder"
        Me.Txt_EntidadVenta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_EntidadVenta.ButtonCustom.Image = Global.Sincroniza.Stock.Bakapp.My.Resources.Resources.button_filledcircle_find
        Me.Txt_EntidadVenta.ButtonCustom.Visible = True
        Me.Txt_EntidadVenta.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_EntidadVenta.ForeColor = System.Drawing.Color.Black
        Me.Txt_EntidadVenta.Location = New System.Drawing.Point(146, 64)
        Me.Txt_EntidadVenta.Name = "Txt_EntidadVenta"
        Me.Txt_EntidadVenta.PreventEnterBeep = True
        Me.Txt_EntidadVenta.Size = New System.Drawing.Size(451, 26)
        Me.Txt_EntidadVenta.TabIndex = 13
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 64)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(137, 23)
        Me.LabelX5.TabIndex = 6
        Me.LabelX5.Text = "Entidad de Venta"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 32)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(137, 23)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Entidad de compra"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(146, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(451, 23)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "Nombre"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(137, 23)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Tipo Entidad"
        '
        'Btn_Editar
        '
        Me.Btn_Editar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar.FontBold = True
        Me.Btn_Editar.ForeColor = System.Drawing.Color.Red
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.ImageAlt = CType(resources.GetObject("Btn_Editar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Tooltip = "Editar OT"
        Me.Btn_Editar.Visible = False
        '
        'ButtonItem2
        '
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.FontBold = True
        Me.ButtonItem2.ForeColor = System.Drawing.Color.Red
        Me.ButtonItem2.Image = CType(resources.GetObject("ButtonItem2.Image"), System.Drawing.Image)
        Me.ButtonItem2.ImageAlt = CType(resources.GetObject("ButtonItem2.ImageAlt"), System.Drawing.Image)
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Tooltip = "Editar OT"
        Me.ButtonItem2.Visible = False
        '
        'ButtonItem3
        '
        Me.ButtonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem3.FontBold = True
        Me.ButtonItem3.ForeColor = System.Drawing.Color.Red
        Me.ButtonItem3.Image = CType(resources.GetObject("ButtonItem3.Image"), System.Drawing.Image)
        Me.ButtonItem3.ImageAlt = CType(resources.GetObject("ButtonItem3.ImageAlt"), System.Drawing.Image)
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Tooltip = "Editar OT"
        Me.ButtonItem3.Visible = False
        '
        'ButtonItem4
        '
        Me.ButtonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem4.FontBold = True
        Me.ButtonItem4.ForeColor = System.Drawing.Color.Red
        Me.ButtonItem4.Image = CType(resources.GetObject("ButtonItem4.Image"), System.Drawing.Image)
        Me.ButtonItem4.ImageAlt = CType(resources.GetObject("ButtonItem4.ImageAlt"), System.Drawing.Image)
        Me.ButtonItem4.Name = "ButtonItem4"
        Me.ButtonItem4.Tooltip = "Editar OT"
        Me.ButtonItem4.Visible = False
        '
        'Frm_Entidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 533)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Entidad"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informacion de la empresa"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Guardar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Excluye_SSN As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Excluye_FLN As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_No_Bloqueados As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_Stock_Devengado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Stock_Comprometido As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Rdb_Stock_Pedido As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Stock_Compras_No_Recibidas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Stock_Fisico As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Rdb_Saldo_Distinto_de_cero As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Saldo_Con_saldo_Positivo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Saldo_Con_y_sin_saldo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBoxX1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Filtros_Bodega As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Clasificacion_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Public WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Public WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Txt_ModOCC As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_ModFCV As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_EntidadCompra As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_EntidadVenta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_ModNVV As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_ModFCC As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
End Class
