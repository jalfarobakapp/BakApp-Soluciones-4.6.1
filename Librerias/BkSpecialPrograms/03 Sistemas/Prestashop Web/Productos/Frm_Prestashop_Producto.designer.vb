<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Prestashop_Producto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Prestashop_Producto))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Txt_FH_Revision = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_FH_Actualizacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Hijos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Active = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Precio_Rd = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Stock_Rd = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Codigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Id_product = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Primario = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Hijos = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Padre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LayoutSpacerItem1 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.LayoutSpacerItem2 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.LayoutSpacerItem3 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.LayoutSpacerItem4 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.LayoutSpacerItem5 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.LayoutSpacerItem6 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.LayoutSpacerItem7 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.LayoutSpacerItem8 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.LayoutSpacerItem9 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.LayoutSpacerItem10 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.LayoutSpacerItem11 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.LayoutGroup1 = New DevComponents.DotNetBar.Layout.LayoutGroup()
        Me.LayoutSpacerItem12 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 342)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(653, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 32
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(629, 320)
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
        Me.GroupPanel1.TabIndex = 33
        Me.GroupPanel1.Text = "Información del producto"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.59864!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.40136!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_FH_Revision, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_FH_Actualizacion, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Hijos, 1, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX11, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX8, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX7, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Active, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX9, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Precio_Rd, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Stock_Rd, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX6, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Descripcion, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Codigo, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Id_product, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Primario, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX10, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Hijos, 2, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Padre, 1, 9)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 11
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(617, 288)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Txt_FH_Revision
        '
        Me.Txt_FH_Revision.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_FH_Revision.Border.Class = "TextBoxBorder"
        Me.Txt_FH_Revision.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_FH_Revision.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_FH_Revision.ForeColor = System.Drawing.Color.Black
        Me.Txt_FH_Revision.Location = New System.Drawing.Point(130, 211)
        Me.Txt_FH_Revision.Name = "Txt_FH_Revision"
        Me.Txt_FH_Revision.PreventEnterBeep = True
        Me.Txt_FH_Revision.ReadOnly = True
        Me.Txt_FH_Revision.Size = New System.Drawing.Size(108, 22)
        Me.Txt_FH_Revision.TabIndex = 35
        '
        'Txt_FH_Actualizacion
        '
        Me.Txt_FH_Actualizacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_FH_Actualizacion.Border.Class = "TextBoxBorder"
        Me.Txt_FH_Actualizacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_FH_Actualizacion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_FH_Actualizacion.ForeColor = System.Drawing.Color.Black
        Me.Txt_FH_Actualizacion.Location = New System.Drawing.Point(130, 185)
        Me.Txt_FH_Actualizacion.Name = "Txt_FH_Actualizacion"
        Me.Txt_FH_Actualizacion.PreventEnterBeep = True
        Me.Txt_FH_Actualizacion.ReadOnly = True
        Me.Txt_FH_Actualizacion.Size = New System.Drawing.Size(108, 22)
        Me.Txt_FH_Actualizacion.TabIndex = 34
        '
        'Txt_Hijos
        '
        Me.Txt_Hijos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Hijos.Border.Class = "TextBoxBorder"
        Me.Txt_Hijos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Hijos.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Hijos.ForeColor = System.Drawing.Color.Black
        Me.Txt_Hijos.Location = New System.Drawing.Point(130, 263)
        Me.Txt_Hijos.Name = "Txt_Hijos"
        Me.Txt_Hijos.PreventEnterBeep = True
        Me.Txt_Hijos.ReadOnly = True
        Me.Txt_Hijos.Size = New System.Drawing.Size(455, 22)
        Me.Txt_Hijos.TabIndex = 34
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(3, 237)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(121, 20)
        Me.LabelX11.TabIndex = 8
        Me.LabelX11.Text = "Padre"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(3, 211)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(121, 20)
        Me.LabelX8.TabIndex = 6
        Me.LabelX8.Text = "Fecha ult. revisión"
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 185)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(121, 20)
        Me.LabelX7.TabIndex = 5
        Me.LabelX7.Text = "Fecha ult. actualización"
        '
        'Chk_Active
        '
        Me.Chk_Active.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Active.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Active.ForeColor = System.Drawing.Color.Black
        Me.Chk_Active.Location = New System.Drawing.Point(130, 133)
        Me.Chk_Active.Name = "Chk_Active"
        Me.Chk_Active.Size = New System.Drawing.Size(233, 20)
        Me.Chk_Active.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Active.TabIndex = 6
        Me.Chk_Active.Text = "Activo"
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(3, 159)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(121, 20)
        Me.LabelX9.TabIndex = 4
        Me.LabelX9.Text = "Tipo de producto"
        '
        'Lbl_Precio_Rd
        '
        Me.Lbl_Precio_Rd.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Precio_Rd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Precio_Rd.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Precio_Rd.Location = New System.Drawing.Point(130, 107)
        Me.Lbl_Precio_Rd.Name = "Lbl_Precio_Rd"
        Me.Lbl_Precio_Rd.Size = New System.Drawing.Size(130, 20)
        Me.Lbl_Precio_Rd.TabIndex = 4
        Me.Lbl_Precio_Rd.Text = "Stock consolidado"
        '
        'Lbl_Stock_Rd
        '
        Me.Lbl_Stock_Rd.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Stock_Rd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Stock_Rd.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Stock_Rd.Location = New System.Drawing.Point(130, 81)
        Me.Lbl_Stock_Rd.Name = "Lbl_Stock_Rd"
        Me.Lbl_Stock_Rd.Size = New System.Drawing.Size(130, 20)
        Me.Lbl_Stock_Rd.TabIndex = 4
        Me.Lbl_Stock_Rd.Text = "Stock consolidado"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 133)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(121, 20)
        Me.LabelX6.TabIndex = 3
        Me.LabelX6.Text = "Estado"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 107)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(121, 20)
        Me.LabelX5.TabIndex = 3
        Me.LabelX5.Text = "Precio"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 81)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(121, 20)
        Me.LabelX4.TabIndex = 3
        Me.LabelX4.Text = "Stock consolidado"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 55)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 20)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "Descripción"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 29)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 20)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "Código"
        '
        'Txt_Descripcion
        '
        Me.Txt_Descripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Descripcion.Border.Class = "TextBoxBorder"
        Me.Txt_Descripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Descripcion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Descripcion.Location = New System.Drawing.Point(130, 55)
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.ReadOnly = True
        Me.Txt_Descripcion.Size = New System.Drawing.Size(455, 22)
        Me.Txt_Descripcion.TabIndex = 2
        '
        'Txt_Codigo
        '
        Me.Txt_Codigo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Codigo.Border.Class = "TextBoxBorder"
        Me.Txt_Codigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Codigo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Codigo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Codigo.Location = New System.Drawing.Point(130, 29)
        Me.Txt_Codigo.Name = "Txt_Codigo"
        Me.Txt_Codigo.PreventEnterBeep = True
        Me.Txt_Codigo.ReadOnly = True
        Me.Txt_Codigo.Size = New System.Drawing.Size(141, 22)
        Me.Txt_Codigo.TabIndex = 2
        '
        'Txt_Id_product
        '
        Me.Txt_Id_product.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Id_product.Border.Class = "TextBoxBorder"
        Me.Txt_Id_product.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Id_product.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Id_product.ForeColor = System.Drawing.Color.Black
        Me.Txt_Id_product.Location = New System.Drawing.Point(130, 3)
        Me.Txt_Id_product.Name = "Txt_Id_product"
        Me.Txt_Id_product.PreventEnterBeep = True
        Me.Txt_Id_product.ReadOnly = True
        Me.Txt_Id_product.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Id_product.TabIndex = 1
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 20)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Id Producto"
        '
        'Chk_Primario
        '
        Me.Chk_Primario.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Primario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Primario.ForeColor = System.Drawing.Color.Black
        Me.Chk_Primario.Location = New System.Drawing.Point(130, 159)
        Me.Chk_Primario.Name = "Chk_Primario"
        Me.Chk_Primario.Size = New System.Drawing.Size(233, 20)
        Me.Chk_Primario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Primario.TabIndex = 5
        Me.Chk_Primario.Text = "Es primario o importado"
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(3, 263)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(121, 20)
        Me.LabelX10.TabIndex = 7
        Me.LabelX10.Text = "Hijos"
        '
        'Btn_Hijos
        '
        Me.Btn_Hijos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Hijos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Hijos.Image = CType(resources.GetObject("Btn_Hijos.Image"), System.Drawing.Image)
        Me.Btn_Hijos.ImageAlt = CType(resources.GetObject("Btn_Hijos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Hijos.Location = New System.Drawing.Point(591, 263)
        Me.Btn_Hijos.Name = "Btn_Hijos"
        Me.Btn_Hijos.Size = New System.Drawing.Size(23, 22)
        Me.Btn_Hijos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Hijos.TabIndex = 35
        Me.Btn_Hijos.Tooltip = "Hijos"
        '
        'Txt_Padre
        '
        Me.Txt_Padre.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Padre.Border.Class = "TextBoxBorder"
        Me.Txt_Padre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Padre.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Padre.ForeColor = System.Drawing.Color.Black
        Me.Txt_Padre.Location = New System.Drawing.Point(130, 237)
        Me.Txt_Padre.Name = "Txt_Padre"
        Me.Txt_Padre.PreventEnterBeep = True
        Me.Txt_Padre.ReadOnly = True
        Me.Txt_Padre.Size = New System.Drawing.Size(455, 22)
        Me.Txt_Padre.TabIndex = 36
        '
        'LayoutSpacerItem1
        '
        Me.LayoutSpacerItem1.Height = 32
        Me.LayoutSpacerItem1.Name = "LayoutSpacerItem1"
        Me.LayoutSpacerItem1.Width = 32
        '
        'LayoutSpacerItem2
        '
        Me.LayoutSpacerItem2.Height = 32
        Me.LayoutSpacerItem2.Name = "LayoutSpacerItem2"
        Me.LayoutSpacerItem2.Width = 32
        '
        'LayoutSpacerItem3
        '
        Me.LayoutSpacerItem3.Height = 32
        Me.LayoutSpacerItem3.Name = "LayoutSpacerItem3"
        Me.LayoutSpacerItem3.Width = 32
        '
        'LayoutSpacerItem4
        '
        Me.LayoutSpacerItem4.Height = 32
        Me.LayoutSpacerItem4.Name = "LayoutSpacerItem4"
        Me.LayoutSpacerItem4.Width = 32
        '
        'LayoutSpacerItem5
        '
        Me.LayoutSpacerItem5.Height = 32
        Me.LayoutSpacerItem5.Name = "LayoutSpacerItem5"
        Me.LayoutSpacerItem5.Width = 32
        '
        'LayoutSpacerItem6
        '
        Me.LayoutSpacerItem6.Height = 32
        Me.LayoutSpacerItem6.Name = "LayoutSpacerItem6"
        Me.LayoutSpacerItem6.Width = 32
        '
        'LayoutSpacerItem7
        '
        Me.LayoutSpacerItem7.Height = 32
        Me.LayoutSpacerItem7.Name = "LayoutSpacerItem7"
        Me.LayoutSpacerItem7.Width = 32
        '
        'LayoutSpacerItem8
        '
        Me.LayoutSpacerItem8.Height = 32
        Me.LayoutSpacerItem8.Name = "LayoutSpacerItem8"
        Me.LayoutSpacerItem8.Width = 32
        '
        'LayoutSpacerItem9
        '
        Me.LayoutSpacerItem9.Height = 32
        Me.LayoutSpacerItem9.Name = "LayoutSpacerItem9"
        Me.LayoutSpacerItem9.Width = 32
        '
        'LayoutSpacerItem10
        '
        Me.LayoutSpacerItem10.Height = 32
        Me.LayoutSpacerItem10.Name = "LayoutSpacerItem10"
        Me.LayoutSpacerItem10.Width = 32
        '
        'LayoutSpacerItem11
        '
        Me.LayoutSpacerItem11.Height = 32
        Me.LayoutSpacerItem11.Name = "LayoutSpacerItem11"
        Me.LayoutSpacerItem11.Width = 32
        '
        'LayoutGroup1
        '
        Me.LayoutGroup1.Height = 100
        Me.LayoutGroup1.MinSize = New System.Drawing.Size(120, 32)
        Me.LayoutGroup1.Name = "LayoutGroup1"
        Me.LayoutGroup1.TextPosition = DevComponents.DotNetBar.Layout.eLayoutPosition.Top
        Me.LayoutGroup1.Width = 200
        '
        'LayoutSpacerItem12
        '
        Me.LayoutSpacerItem12.Height = 32
        Me.LayoutSpacerItem12.Name = "LayoutSpacerItem12"
        Me.LayoutSpacerItem12.Width = 32
        '
        'Frm_Prestashop_Producto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 383)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Prestashop_Producto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PRODUCTO PRESTASHOP"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LayoutSpacerItem1 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutSpacerItem2 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutSpacerItem3 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutSpacerItem4 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutSpacerItem5 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutSpacerItem6 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutSpacerItem7 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutSpacerItem8 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutSpacerItem9 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutSpacerItem10 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutSpacerItem11 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutGroup1 As DevComponents.DotNetBar.Layout.LayoutGroup
    Friend WithEvents LayoutSpacerItem12 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Active As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Precio_Rd As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Stock_Rd As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Primario As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Hijos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Id_product As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_FH_Revision As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_FH_Actualizacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Hijos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Padre As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Codigo As DevComponents.DotNetBar.Controls.TextBoxX
End Class
