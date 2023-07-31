<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cms_AgregarTipos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cms_AgregarTipos))
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Ent_Excluidas = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_ProductosExcluidos = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_PorcComision = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_TieneSC = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_QuitarEntExcluidas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Vendedores = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Sucursales = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rdb_VentasXVendedores = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_VentasXSucursal = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_VentasXEmpresa = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_MisVentas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_AgregarComision = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_Bodegas = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rdb_VentasXBodega = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Txt_Bodegas)
        Me.GroupPanel2.Controls.Add(Me.Rdb_VentasXBodega)
        Me.GroupPanel2.Controls.Add(Me.Btn_Ent_Excluidas)
        Me.GroupPanel2.Controls.Add(Me.Btn_ProductosExcluidos)
        Me.GroupPanel2.Controls.Add(Me.Txt_PorcComision)
        Me.GroupPanel2.Controls.Add(Me.Chk_TieneSC)
        Me.GroupPanel2.Controls.Add(Me.Chk_QuitarEntExcluidas)
        Me.GroupPanel2.Controls.Add(Me.Txt_Vendedores)
        Me.GroupPanel2.Controls.Add(Me.Txt_Sucursales)
        Me.GroupPanel2.Controls.Add(Me.Rdb_VentasXVendedores)
        Me.GroupPanel2.Controls.Add(Me.Rdb_VentasXSucursal)
        Me.GroupPanel2.Controls.Add(Me.Rdb_VentasXEmpresa)
        Me.GroupPanel2.Controls.Add(Me.Rdb_MisVentas)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.Txt_Descripcion)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 6)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(560, 374)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 163
        Me.GroupPanel2.Text = "Datos del funcionario"
        '
        'Btn_Ent_Excluidas
        '
        Me.Btn_Ent_Excluidas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Ent_Excluidas.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Ent_Excluidas.FocusCuesEnabled = False
        Me.Btn_Ent_Excluidas.Image = CType(resources.GetObject("Btn_Ent_Excluidas.Image"), System.Drawing.Image)
        Me.Btn_Ent_Excluidas.ImageAlt = CType(resources.GetObject("Btn_Ent_Excluidas.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ent_Excluidas.Location = New System.Drawing.Point(3, 311)
        Me.Btn_Ent_Excluidas.Name = "Btn_Ent_Excluidas"
        Me.Btn_Ent_Excluidas.Size = New System.Drawing.Size(180, 30)
        Me.Btn_Ent_Excluidas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Ent_Excluidas.TabIndex = 117
        Me.Btn_Ent_Excluidas.Text = "Entidades excluidas"
        '
        'Btn_ProductosExcluidos
        '
        Me.Btn_ProductosExcluidos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_ProductosExcluidos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_ProductosExcluidos.FocusCuesEnabled = False
        Me.Btn_ProductosExcluidos.Image = CType(resources.GetObject("Btn_ProductosExcluidos.Image"), System.Drawing.Image)
        Me.Btn_ProductosExcluidos.ImageAlt = CType(resources.GetObject("Btn_ProductosExcluidos.ImageAlt"), System.Drawing.Image)
        Me.Btn_ProductosExcluidos.Location = New System.Drawing.Point(3, 274)
        Me.Btn_ProductosExcluidos.Name = "Btn_ProductosExcluidos"
        Me.Btn_ProductosExcluidos.Size = New System.Drawing.Size(180, 29)
        Me.Btn_ProductosExcluidos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_ProductosExcluidos.TabIndex = 118
        Me.Btn_ProductosExcluidos.Text = "Productos excluidos"
        '
        'Txt_PorcComision
        '
        Me.Txt_PorcComision.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_PorcComision.Border.Class = "TextBoxBorder"
        Me.Txt_PorcComision.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_PorcComision.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_PorcComision.ForeColor = System.Drawing.Color.Black
        Me.Txt_PorcComision.Location = New System.Drawing.Point(151, 35)
        Me.Txt_PorcComision.Name = "Txt_PorcComision"
        Me.Txt_PorcComision.Size = New System.Drawing.Size(54, 22)
        Me.Txt_PorcComision.TabIndex = 42
        Me.Txt_PorcComision.Text = "0"
        Me.Txt_PorcComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Chk_TieneSC
        '
        Me.Chk_TieneSC.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_TieneSC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_TieneSC.CheckBoxImageChecked = CType(resources.GetObject("Chk_TieneSC.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_TieneSC.FocusCuesEnabled = False
        Me.Chk_TieneSC.ForeColor = System.Drawing.Color.Black
        Me.Chk_TieneSC.Location = New System.Drawing.Point(3, 214)
        Me.Chk_TieneSC.Name = "Chk_TieneSC"
        Me.Chk_TieneSC.Size = New System.Drawing.Size(242, 23)
        Me.Chk_TieneSC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_TieneSC.TabIndex = 41
        Me.Chk_TieneSC.Text = "Tiene comisión bruta sujeta a semana corrida"
        '
        'Chk_QuitarEntExcluidas
        '
        Me.Chk_QuitarEntExcluidas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_QuitarEntExcluidas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_QuitarEntExcluidas.CheckBoxImageChecked = CType(resources.GetObject("Chk_QuitarEntExcluidas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_QuitarEntExcluidas.FocusCuesEnabled = False
        Me.Chk_QuitarEntExcluidas.ForeColor = System.Drawing.Color.Black
        Me.Chk_QuitarEntExcluidas.Location = New System.Drawing.Point(3, 240)
        Me.Chk_QuitarEntExcluidas.Name = "Chk_QuitarEntExcluidas"
        Me.Chk_QuitarEntExcluidas.Size = New System.Drawing.Size(212, 23)
        Me.Chk_QuitarEntExcluidas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_QuitarEntExcluidas.TabIndex = 40
        Me.Chk_QuitarEntExcluidas.Text = "No incluir venta de entidades excluidas"
        '
        'Txt_Vendedores
        '
        Me.Txt_Vendedores.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Vendedores.Border.Class = "TextBoxBorder"
        Me.Txt_Vendedores.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Vendedores.ButtonCustom.Image = CType(resources.GetObject("Txt_Vendedores.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Vendedores.ButtonCustom.Visible = True
        Me.Txt_Vendedores.ButtonCustom2.Image = CType(resources.GetObject("Txt_Vendedores.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Vendedores.ButtonCustom2.Visible = True
        Me.Txt_Vendedores.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Vendedores.ForeColor = System.Drawing.Color.Black
        Me.Txt_Vendedores.Location = New System.Drawing.Point(151, 179)
        Me.Txt_Vendedores.Name = "Txt_Vendedores"
        Me.Txt_Vendedores.PreventEnterBeep = True
        Me.Txt_Vendedores.Size = New System.Drawing.Size(392, 22)
        Me.Txt_Vendedores.TabIndex = 39
        '
        'Txt_Sucursales
        '
        Me.Txt_Sucursales.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Sucursales.Border.Class = "TextBoxBorder"
        Me.Txt_Sucursales.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Sucursales.ButtonCustom.Image = CType(resources.GetObject("Txt_Sucursales.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Sucursales.ButtonCustom.Visible = True
        Me.Txt_Sucursales.ButtonCustom2.Image = CType(resources.GetObject("Txt_Sucursales.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Sucursales.ButtonCustom2.Visible = True
        Me.Txt_Sucursales.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Sucursales.ForeColor = System.Drawing.Color.Black
        Me.Txt_Sucursales.Location = New System.Drawing.Point(151, 123)
        Me.Txt_Sucursales.Name = "Txt_Sucursales"
        Me.Txt_Sucursales.PreventEnterBeep = True
        Me.Txt_Sucursales.Size = New System.Drawing.Size(392, 22)
        Me.Txt_Sucursales.TabIndex = 38
        '
        'Rdb_VentasXVendedores
        '
        Me.Rdb_VentasXVendedores.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_VentasXVendedores.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_VentasXVendedores.CheckBoxImageChecked = CType(resources.GetObject("Rdb_VentasXVendedores.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_VentasXVendedores.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_VentasXVendedores.FocusCuesEnabled = False
        Me.Rdb_VentasXVendedores.ForeColor = System.Drawing.Color.Black
        Me.Rdb_VentasXVendedores.Location = New System.Drawing.Point(3, 184)
        Me.Rdb_VentasXVendedores.Name = "Rdb_VentasXVendedores"
        Me.Rdb_VentasXVendedores.Size = New System.Drawing.Size(133, 17)
        Me.Rdb_VentasXVendedores.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_VentasXVendedores.TabIndex = 37
        Me.Rdb_VentasXVendedores.Text = "Ventas por vendedores"
        '
        'Rdb_VentasXSucursal
        '
        Me.Rdb_VentasXSucursal.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_VentasXSucursal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_VentasXSucursal.CheckBoxImageChecked = CType(resources.GetObject("Rdb_VentasXSucursal.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_VentasXSucursal.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_VentasXSucursal.FocusCuesEnabled = False
        Me.Rdb_VentasXSucursal.ForeColor = System.Drawing.Color.Black
        Me.Rdb_VentasXSucursal.Location = New System.Drawing.Point(3, 128)
        Me.Rdb_VentasXSucursal.Name = "Rdb_VentasXSucursal"
        Me.Rdb_VentasXSucursal.Size = New System.Drawing.Size(119, 17)
        Me.Rdb_VentasXSucursal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_VentasXSucursal.TabIndex = 36
        Me.Rdb_VentasXSucursal.Text = "Ventas por sucursal"
        '
        'Rdb_VentasXEmpresa
        '
        Me.Rdb_VentasXEmpresa.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_VentasXEmpresa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_VentasXEmpresa.CheckBoxImageChecked = CType(resources.GetObject("Rdb_VentasXEmpresa.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_VentasXEmpresa.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_VentasXEmpresa.FocusCuesEnabled = False
        Me.Rdb_VentasXEmpresa.ForeColor = System.Drawing.Color.Black
        Me.Rdb_VentasXEmpresa.Location = New System.Drawing.Point(3, 99)
        Me.Rdb_VentasXEmpresa.Name = "Rdb_VentasXEmpresa"
        Me.Rdb_VentasXEmpresa.Size = New System.Drawing.Size(157, 18)
        Me.Rdb_VentasXEmpresa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_VentasXEmpresa.TabIndex = 35
        Me.Rdb_VentasXEmpresa.Text = "Ventas por empresa global"
        '
        'Rdb_MisVentas
        '
        Me.Rdb_MisVentas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_MisVentas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_MisVentas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_MisVentas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_MisVentas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_MisVentas.Checked = True
        Me.Rdb_MisVentas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_MisVentas.CheckValue = "Y"
        Me.Rdb_MisVentas.FocusCuesEnabled = False
        Me.Rdb_MisVentas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_MisVentas.Location = New System.Drawing.Point(3, 73)
        Me.Rdb_MisVentas.Name = "Rdb_MisVentas"
        Me.Rdb_MisVentas.Size = New System.Drawing.Size(75, 20)
        Me.Rdb_MisVentas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_MisVentas.TabIndex = 34
        Me.Rdb_MisVentas.Text = "Mis ventas"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 32)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "% Comisión"
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
        Me.Txt_Descripcion.Location = New System.Drawing.Point(151, 4)
        Me.Txt_Descripcion.MaxLength = 30
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.Size = New System.Drawing.Size(392, 22)
        Me.Txt_Descripcion.TabIndex = 1
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
        Me.LabelX1.Size = New System.Drawing.Size(142, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Nombre comisión"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar, Me.Btn_AgregarComision})
        Me.Bar2.Location = New System.Drawing.Point(0, 406)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(583, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 162
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
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
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Configuración de asistente de compra"
        '
        'Btn_AgregarComision
        '
        Me.Btn_AgregarComision.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_AgregarComision.ForeColor = System.Drawing.Color.Black
        Me.Btn_AgregarComision.Image = CType(resources.GetObject("Btn_AgregarComision.Image"), System.Drawing.Image)
        Me.Btn_AgregarComision.ImageAlt = CType(resources.GetObject("Btn_AgregarComision.ImageAlt"), System.Drawing.Image)
        Me.Btn_AgregarComision.Name = "Btn_AgregarComision"
        Me.Btn_AgregarComision.Tooltip = "Configuración de asistente de compra"
        '
        'Txt_Bodegas
        '
        Me.Txt_Bodegas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Bodegas.Border.Class = "TextBoxBorder"
        Me.Txt_Bodegas.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Bodegas.ButtonCustom.Image = CType(resources.GetObject("TextBoxX1.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Bodegas.ButtonCustom.Visible = True
        Me.Txt_Bodegas.ButtonCustom2.Image = CType(resources.GetObject("TextBoxX1.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Bodegas.ButtonCustom2.Visible = True
        Me.Txt_Bodegas.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Bodegas.ForeColor = System.Drawing.Color.Black
        Me.Txt_Bodegas.Location = New System.Drawing.Point(151, 151)
        Me.Txt_Bodegas.Name = "Txt_Bodegas"
        Me.Txt_Bodegas.PreventEnterBeep = True
        Me.Txt_Bodegas.Size = New System.Drawing.Size(392, 22)
        Me.Txt_Bodegas.TabIndex = 120
        '
        'Rdb_VentasXBodega
        '
        Me.Rdb_VentasXBodega.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_VentasXBodega.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_VentasXBodega.CheckBoxImageChecked = CType(resources.GetObject("Rdb_VentasXBodega.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_VentasXBodega.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_VentasXBodega.FocusCuesEnabled = False
        Me.Rdb_VentasXBodega.ForeColor = System.Drawing.Color.Black
        Me.Rdb_VentasXBodega.Location = New System.Drawing.Point(3, 156)
        Me.Rdb_VentasXBodega.Name = "Rdb_VentasXBodega"
        Me.Rdb_VentasXBodega.Size = New System.Drawing.Size(119, 17)
        Me.Rdb_VentasXBodega.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_VentasXBodega.TabIndex = 119
        Me.Rdb_VentasXBodega.Text = "Ventas por bodega"
        '
        'Frm_Cms_AgregarTipos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(583, 447)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cms_AgregarTipos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_MisVentas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_AgregarComision As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Sucursales As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Rdb_VentasXVendedores As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_VentasXSucursal As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_VentasXEmpresa As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_Vendedores As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Chk_QuitarEntExcluidas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_TieneSC As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_PorcComision As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Ent_Excluidas As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_ProductosExcluidos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Bodegas As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Rdb_VentasXBodega As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
