<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MediaYPromedioXProd_Estudio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MediaYPromedioXProd_Estudio))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Productos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_InformeDeComprasAgrupadoporAsociacion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Input_Productos_Ranking = New DevComponents.Editors.IntegerInput()
        Me.BtnSeleccionarProductos = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD = New DevComponents.DotNetBar.ButtonX()
        Me.Dtp_Fecha_Movimientos_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Txt_Padre_Asociacion_Productos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_Hasta = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Desde = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Filtrar_ProdProveedor = New DevComponents.DotNetBar.ButtonX()
        Me.Dtp_Fecha_Movimientos_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Chk_Solo_Proveedores_CodAlternativo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Proveedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Cantidad_Dias_Ultima_Venta = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Productos_Clasificacion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Todos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Seleccionar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Con_Movimientos_De_Venta = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Proveedor = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Ranking = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Productos_Familias_Marcas_Etc = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Buscar_Proveedor = New DevComponents.DotNetBar.ButtonX()
        Me.Chk_Traer_Productos_De_Reemplazo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Ent_Fisica = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Dtp_Fecha_Vta_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Input_Ultimos_Meses_Vta_Promedio = New DevComponents.Editors.IntegerInput()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Rango_Fechas_Vta_Promedio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Rango_Meses_Vta_Promedio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chk_Incluir_Salidas_GDI_OT = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Rotacion_Con_Ent_Excluidas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Sumar_Rotacion_Hermanos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Dtp_Fecha_Vta_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Btn_Bodega_Vta_Estudio = New DevComponents.DotNetBar.ButtonX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Productos.SuspendLayout()
        CType(Me.Input_Productos_Ranking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Movimientos_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Movimientos_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Dtp_Fecha_Vta_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Ultimos_Meses_Vta_Promedio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Dtp_Fecha_Vta_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar})
        Me.Bar2.Location = New System.Drawing.Point(0, 620)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(571, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 104
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
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
        Me.Btn_Eliminar.Tooltip = "Eliminar"
        '
        'Grupo_Productos
        '
        Me.Grupo_Productos.BackColor = System.Drawing.Color.White
        Me.Grupo_Productos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Productos.Controls.Add(Me.Chk_InformeDeComprasAgrupadoporAsociacion)
        Me.Grupo_Productos.Controls.Add(Me.Input_Productos_Ranking)
        Me.Grupo_Productos.Controls.Add(Me.BtnSeleccionarProductos)
        Me.Grupo_Productos.Controls.Add(Me.Btn_Seleccionar_Productos_X_Clasificacion_RD)
        Me.Grupo_Productos.Controls.Add(Me.Dtp_Fecha_Movimientos_Hasta)
        Me.Grupo_Productos.Controls.Add(Me.Txt_Padre_Asociacion_Productos)
        Me.Grupo_Productos.Controls.Add(Me.Lbl_Hasta)
        Me.Grupo_Productos.Controls.Add(Me.Lbl_Desde)
        Me.Grupo_Productos.Controls.Add(Me.Btn_Filtrar_ProdProveedor)
        Me.Grupo_Productos.Controls.Add(Me.Dtp_Fecha_Movimientos_Desde)
        Me.Grupo_Productos.Controls.Add(Me.Chk_Solo_Proveedores_CodAlternativo)
        Me.Grupo_Productos.Controls.Add(Me.Txt_Proveedor)
        Me.Grupo_Productos.Controls.Add(Me.LabelX5)
        Me.Grupo_Productos.Controls.Add(Me.Cmb_Cantidad_Dias_Ultima_Venta)
        Me.Grupo_Productos.Controls.Add(Me.TableLayoutPanel6)
        Me.Grupo_Productos.Controls.Add(Me.Btn_Buscar_Proveedor)
        Me.Grupo_Productos.Controls.Add(Me.Chk_Traer_Productos_De_Reemplazo)
        Me.Grupo_Productos.Controls.Add(Me.Chk_Ent_Fisica)
        Me.Grupo_Productos.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Productos.Location = New System.Drawing.Point(12, 12)
        Me.Grupo_Productos.Name = "Grupo_Productos"
        Me.Grupo_Productos.Size = New System.Drawing.Size(545, 310)
        '
        '
        '
        Me.Grupo_Productos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Productos.Style.BackColorGradientAngle = 90
        Me.Grupo_Productos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Productos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Productos.Style.BorderBottomWidth = 1
        Me.Grupo_Productos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Productos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Productos.Style.BorderLeftWidth = 1
        Me.Grupo_Productos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Productos.Style.BorderRightWidth = 1
        Me.Grupo_Productos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Productos.Style.BorderTopWidth = 1
        Me.Grupo_Productos.Style.CornerDiameter = 4
        Me.Grupo_Productos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Productos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Productos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Productos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Productos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Productos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Productos.TabIndex = 105
        Me.Grupo_Productos.Text = "Selección de productos"
        '
        'Chk_InformeDeComprasAgrupadoporAsociacion
        '
        Me.Chk_InformeDeComprasAgrupadoporAsociacion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_InformeDeComprasAgrupadoporAsociacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_InformeDeComprasAgrupadoporAsociacion.CheckBoxImageChecked = CType(resources.GetObject("Chk_InformeDeComprasAgrupadoporAsociacion.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_InformeDeComprasAgrupadoporAsociacion.FocusCuesEnabled = False
        Me.Chk_InformeDeComprasAgrupadoporAsociacion.ForeColor = System.Drawing.Color.Black
        Me.Chk_InformeDeComprasAgrupadoporAsociacion.Location = New System.Drawing.Point(395, 102)
        Me.Chk_InformeDeComprasAgrupadoporAsociacion.Name = "Chk_InformeDeComprasAgrupadoporAsociacion"
        Me.Chk_InformeDeComprasAgrupadoporAsociacion.Size = New System.Drawing.Size(192, 23)
        Me.Chk_InformeDeComprasAgrupadoporAsociacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_InformeDeComprasAgrupadoporAsociacion.TabIndex = 10015
        Me.Chk_InformeDeComprasAgrupadoporAsociacion.Text = "Ejec comprar proyec."
        '
        'Input_Productos_Ranking
        '
        Me.Input_Productos_Ranking.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Productos_Ranking.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Productos_Ranking.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Productos_Ranking.ButtonClear.Visible = True
        Me.Input_Productos_Ranking.FocusHighlightEnabled = True
        Me.Input_Productos_Ranking.ForeColor = System.Drawing.Color.Black
        Me.Input_Productos_Ranking.Location = New System.Drawing.Point(215, 150)
        Me.Input_Productos_Ranking.Name = "Input_Productos_Ranking"
        Me.Input_Productos_Ranking.ShowUpDown = True
        Me.Input_Productos_Ranking.Size = New System.Drawing.Size(98, 22)
        Me.Input_Productos_Ranking.TabIndex = 102
        Me.Input_Productos_Ranking.Value = 100
        '
        'BtnSeleccionarProductos
        '
        Me.BtnSeleccionarProductos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnSeleccionarProductos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnSeleccionarProductos.FocusCuesEnabled = False
        Me.BtnSeleccionarProductos.Image = CType(resources.GetObject("BtnSeleccionarProductos.Image"), System.Drawing.Image)
        Me.BtnSeleccionarProductos.ImageAlt = CType(resources.GetObject("BtnSeleccionarProductos.ImageAlt"), System.Drawing.Image)
        Me.BtnSeleccionarProductos.Location = New System.Drawing.Point(215, 82)
        Me.BtnSeleccionarProductos.Name = "BtnSeleccionarProductos"
        Me.BtnSeleccionarProductos.Size = New System.Drawing.Size(98, 18)
        Me.BtnSeleccionarProductos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnSeleccionarProductos.TabIndex = 13
        Me.BtnSeleccionarProductos.Text = "Buscar prod."
        Me.BtnSeleccionarProductos.Tooltip = "Buscar productos"
        '
        'Btn_Seleccionar_Productos_X_Clasificacion_RD
        '
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.FocusCuesEnabled = False
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.Image = CType(resources.GetObject("Btn_Seleccionar_Productos_X_Clasificacion_RD.Image"), System.Drawing.Image)
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.Location = New System.Drawing.Point(215, 126)
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.Name = "Btn_Seleccionar_Productos_X_Clasificacion_RD"
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.Size = New System.Drawing.Size(98, 18)
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.TabIndex = 52
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.Text = "Familias, etc..."
        Me.Btn_Seleccionar_Productos_X_Clasificacion_RD.Tooltip = "Buscar productos"
        '
        'Dtp_Fecha_Movimientos_Hasta
        '
        Me.Dtp_Fecha_Movimientos_Hasta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Movimientos_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Movimientos_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Movimientos_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Movimientos_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Movimientos_Hasta.Location = New System.Drawing.Point(395, 54)
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.DisplayMonth = New Date(2018, 10, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Movimientos_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Movimientos_Hasta.Name = "Dtp_Fecha_Movimientos_Hasta"
        Me.Dtp_Fecha_Movimientos_Hasta.Size = New System.Drawing.Size(90, 22)
        Me.Dtp_Fecha_Movimientos_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Movimientos_Hasta.TabIndex = 66
        Me.Dtp_Fecha_Movimientos_Hasta.Value = New Date(2018, 10, 19, 11, 12, 43, 0)
        '
        'Txt_Padre_Asociacion_Productos
        '
        Me.Txt_Padre_Asociacion_Productos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Padre_Asociacion_Productos.Border.Class = "TextBoxBorder"
        Me.Txt_Padre_Asociacion_Productos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Padre_Asociacion_Productos.ButtonCustom.Visible = True
        Me.Txt_Padre_Asociacion_Productos.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Padre_Asociacion_Productos.ForeColor = System.Drawing.Color.Black
        Me.Txt_Padre_Asociacion_Productos.Location = New System.Drawing.Point(215, 102)
        Me.Txt_Padre_Asociacion_Productos.Name = "Txt_Padre_Asociacion_Productos"
        Me.Txt_Padre_Asociacion_Productos.PreventEnterBeep = True
        Me.Txt_Padre_Asociacion_Productos.ReadOnly = True
        Me.Txt_Padre_Asociacion_Productos.Size = New System.Drawing.Size(174, 22)
        Me.Txt_Padre_Asociacion_Productos.TabIndex = 131
        '
        'Lbl_Hasta
        '
        Me.Lbl_Hasta.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Hasta.Location = New System.Drawing.Point(358, 54)
        Me.Lbl_Hasta.Name = "Lbl_Hasta"
        Me.Lbl_Hasta.Size = New System.Drawing.Size(31, 18)
        Me.Lbl_Hasta.TabIndex = 116
        Me.Lbl_Hasta.Text = "Hasta"
        Me.Lbl_Hasta.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Lbl_Desde
        '
        Me.Lbl_Desde.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Desde.Location = New System.Drawing.Point(215, 54)
        Me.Lbl_Desde.Name = "Lbl_Desde"
        Me.Lbl_Desde.Size = New System.Drawing.Size(33, 18)
        Me.Lbl_Desde.TabIndex = 115
        Me.Lbl_Desde.Text = "Desde"
        Me.Lbl_Desde.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Btn_Filtrar_ProdProveedor
        '
        Me.Btn_Filtrar_ProdProveedor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Filtrar_ProdProveedor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Filtrar_ProdProveedor.FocusCuesEnabled = False
        Me.Btn_Filtrar_ProdProveedor.Image = CType(resources.GetObject("Btn_Filtrar_ProdProveedor.Image"), System.Drawing.Image)
        Me.Btn_Filtrar_ProdProveedor.ImageAlt = CType(resources.GetObject("Btn_Filtrar_ProdProveedor.ImageAlt"), System.Drawing.Image)
        Me.Btn_Filtrar_ProdProveedor.Location = New System.Drawing.Point(420, 232)
        Me.Btn_Filtrar_ProdProveedor.Name = "Btn_Filtrar_ProdProveedor"
        Me.Btn_Filtrar_ProdProveedor.Size = New System.Drawing.Size(96, 22)
        Me.Btn_Filtrar_ProdProveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Filtrar_ProdProveedor.TabIndex = 10014
        Me.Btn_Filtrar_ProdProveedor.Text = "Buscar prod."
        Me.Btn_Filtrar_ProdProveedor.Tooltip = "Filtrar solo algunos productos del proveedor"
        '
        'Dtp_Fecha_Movimientos_Desde
        '
        Me.Dtp_Fecha_Movimientos_Desde.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Movimientos_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Movimientos_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Movimientos_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Movimientos_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Movimientos_Desde.Location = New System.Drawing.Point(254, 54)
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.DisplayMonth = New Date(2018, 10, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Movimientos_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Movimientos_Desde.Name = "Dtp_Fecha_Movimientos_Desde"
        Me.Dtp_Fecha_Movimientos_Desde.Size = New System.Drawing.Size(98, 22)
        Me.Dtp_Fecha_Movimientos_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Movimientos_Desde.TabIndex = 65
        Me.Dtp_Fecha_Movimientos_Desde.Value = New Date(2018, 10, 19, 11, 12, 43, 0)
        '
        'Chk_Solo_Proveedores_CodAlternativo
        '
        Me.Chk_Solo_Proveedores_CodAlternativo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Solo_Proveedores_CodAlternativo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Solo_Proveedores_CodAlternativo.CheckBoxImageChecked = CType(resources.GetObject("Chk_Solo_Proveedores_CodAlternativo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Solo_Proveedores_CodAlternativo.FocusCuesEnabled = False
        Me.Chk_Solo_Proveedores_CodAlternativo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Solo_Proveedores_CodAlternativo.Location = New System.Drawing.Point(277, 204)
        Me.Chk_Solo_Proveedores_CodAlternativo.Name = "Chk_Solo_Proveedores_CodAlternativo"
        Me.Chk_Solo_Proveedores_CodAlternativo.Size = New System.Drawing.Size(241, 23)
        Me.Chk_Solo_Proveedores_CodAlternativo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Solo_Proveedores_CodAlternativo.TabIndex = 10013
        Me.Chk_Solo_Proveedores_CodAlternativo.Text = "Traer solo proveedores con código alternativo"
        '
        'Txt_Proveedor
        '
        Me.Txt_Proveedor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Proveedor.Border.Class = "TextBoxBorder"
        Me.Txt_Proveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Proveedor.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Proveedor.ForeColor = System.Drawing.Color.Black
        Me.Txt_Proveedor.Location = New System.Drawing.Point(59, 232)
        Me.Txt_Proveedor.Name = "Txt_Proveedor"
        Me.Txt_Proveedor.PreventEnterBeep = True
        Me.Txt_Proveedor.ReadOnly = True
        Me.Txt_Proveedor.Size = New System.Drawing.Size(355, 22)
        Me.Txt_Proveedor.TabIndex = 10
        '
        'LabelX5
        '
        Me.LabelX5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(-241, 260)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX5.Size = New System.Drawing.Size(87, 23)
        Me.LabelX5.TabIndex = 10011
        Me.LabelX5.Text = "Tipo de compra"
        '
        'Cmb_Cantidad_Dias_Ultima_Venta
        '
        Me.Cmb_Cantidad_Dias_Ultima_Venta.DisplayMember = "Text"
        Me.Cmb_Cantidad_Dias_Ultima_Venta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Cantidad_Dias_Ultima_Venta.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Cantidad_Dias_Ultima_Venta.FormattingEnabled = True
        Me.Cmb_Cantidad_Dias_Ultima_Venta.ItemHeight = 16
        Me.Cmb_Cantidad_Dias_Ultima_Venta.Location = New System.Drawing.Point(215, 30)
        Me.Cmb_Cantidad_Dias_Ultima_Venta.Name = "Cmb_Cantidad_Dias_Ultima_Venta"
        Me.Cmb_Cantidad_Dias_Ultima_Venta.Size = New System.Drawing.Size(137, 22)
        Me.Cmb_Cantidad_Dias_Ultima_Venta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Cantidad_Dias_Ultima_Venta.TabIndex = 10
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Clasificacion, 0, 4)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Todos, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Seleccionar, 0, 3)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Con_Movimientos_De_Venta, 0, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Proveedor, 0, 7)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Ranking, 0, 6)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Productos_Familias_Marcas_Etc, 0, 5)
        Me.TableLayoutPanel6.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 8
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(206, 195)
        Me.TableLayoutPanel6.TabIndex = 50
        '
        'Rdb_Productos_Clasificacion
        '
        '
        '
        '
        Me.Rdb_Productos_Clasificacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Clasificacion.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Clasificacion.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Clasificacion.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Clasificacion.FocusCuesEnabled = False
        Me.Rdb_Productos_Clasificacion.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Clasificacion.Location = New System.Drawing.Point(3, 99)
        Me.Rdb_Productos_Clasificacion.Name = "Rdb_Productos_Clasificacion"
        Me.Rdb_Productos_Clasificacion.Size = New System.Drawing.Size(200, 18)
        Me.Rdb_Productos_Clasificacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Clasificacion.TabIndex = 116
        Me.Rdb_Productos_Clasificacion.Text = "Clasificación especial Bakapp..."
        '
        'Rdb_Productos_Todos
        '
        '
        '
        '
        Me.Rdb_Productos_Todos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Todos.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Todos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Todos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Todos.Checked = True
        Me.Rdb_Productos_Todos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Productos_Todos.CheckValue = "Y"
        Me.Rdb_Productos_Todos.FocusCuesEnabled = False
        Me.Rdb_Productos_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Todos.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Productos_Todos.Name = "Rdb_Productos_Todos"
        Me.Rdb_Productos_Todos.Size = New System.Drawing.Size(92, 18)
        Me.Rdb_Productos_Todos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Todos.TabIndex = 53
        Me.Rdb_Productos_Todos.Text = "Todos"
        '
        'Rdb_Productos_Seleccionar
        '
        '
        '
        '
        Me.Rdb_Productos_Seleccionar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Seleccionar.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Seleccionar.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Seleccionar.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Seleccionar.FocusCuesEnabled = False
        Me.Rdb_Productos_Seleccionar.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Seleccionar.Location = New System.Drawing.Point(3, 75)
        Me.Rdb_Productos_Seleccionar.Name = "Rdb_Productos_Seleccionar"
        Me.Rdb_Productos_Seleccionar.Size = New System.Drawing.Size(167, 18)
        Me.Rdb_Productos_Seleccionar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Seleccionar.TabIndex = 56
        Me.Rdb_Productos_Seleccionar.Text = "Seleccionar productos"
        '
        'Rdb_Productos_Con_Movimientos_De_Venta
        '
        '
        '
        '
        Me.Rdb_Productos_Con_Movimientos_De_Venta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Con_Movimientos_De_Venta.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Con_Movimientos_De_Venta.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Con_Movimientos_De_Venta.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Con_Movimientos_De_Venta.FocusCuesEnabled = False
        Me.Rdb_Productos_Con_Movimientos_De_Venta.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Con_Movimientos_De_Venta.Location = New System.Drawing.Point(3, 51)
        Me.Rdb_Productos_Con_Movimientos_De_Venta.Name = "Rdb_Productos_Con_Movimientos_De_Venta"
        Me.Rdb_Productos_Con_Movimientos_De_Venta.Size = New System.Drawing.Size(167, 18)
        Me.Rdb_Productos_Con_Movimientos_De_Venta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Con_Movimientos_De_Venta.TabIndex = 55
        Me.Rdb_Productos_Con_Movimientos_De_Venta.Text = "Con movimientos de venta"
        '
        'Rdb_Productos_Vendidos_Los_Ultimos_Dias
        '
        '
        '
        '
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Vendidos_Los_Ultimos_Dias.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.FocusCuesEnabled = False
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.Location = New System.Drawing.Point(3, 27)
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.Name = "Rdb_Productos_Vendidos_Los_Ultimos_Dias"
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.Size = New System.Drawing.Size(167, 18)
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.TabIndex = 54
        Me.Rdb_Productos_Vendidos_Los_Ultimos_Dias.Text = "Vendidos los últimos"
        '
        'Rdb_Productos_Proveedor
        '
        '
        '
        '
        Me.Rdb_Productos_Proveedor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Proveedor.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Proveedor.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Proveedor.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Proveedor.FocusCuesEnabled = False
        Me.Rdb_Productos_Proveedor.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Proveedor.Location = New System.Drawing.Point(3, 171)
        Me.Rdb_Productos_Proveedor.Name = "Rdb_Productos_Proveedor"
        Me.Rdb_Productos_Proveedor.Size = New System.Drawing.Size(200, 21)
        Me.Rdb_Productos_Proveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Proveedor.TabIndex = 59
        Me.Rdb_Productos_Proveedor.Text = "Comprados a un proveedor"
        '
        'Rdb_Productos_Ranking
        '
        '
        '
        '
        Me.Rdb_Productos_Ranking.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Ranking.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Ranking.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Ranking.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Ranking.FocusCuesEnabled = False
        Me.Rdb_Productos_Ranking.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Ranking.Location = New System.Drawing.Point(3, 147)
        Me.Rdb_Productos_Ranking.Name = "Rdb_Productos_Ranking"
        Me.Rdb_Productos_Ranking.Size = New System.Drawing.Size(200, 18)
        Me.Rdb_Productos_Ranking.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Ranking.TabIndex = 58
        Me.Rdb_Productos_Ranking.Text = "Los mejores del Ranking"
        '
        'Rdb_Productos_Familias_Marcas_Etc
        '
        '
        '
        '
        Me.Rdb_Productos_Familias_Marcas_Etc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Productos_Familias_Marcas_Etc.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Productos_Familias_Marcas_Etc.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Productos_Familias_Marcas_Etc.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Productos_Familias_Marcas_Etc.FocusCuesEnabled = False
        Me.Rdb_Productos_Familias_Marcas_Etc.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Familias_Marcas_Etc.Location = New System.Drawing.Point(3, 123)
        Me.Rdb_Productos_Familias_Marcas_Etc.Name = "Rdb_Productos_Familias_Marcas_Etc"
        Me.Rdb_Productos_Familias_Marcas_Etc.Size = New System.Drawing.Size(200, 18)
        Me.Rdb_Productos_Familias_Marcas_Etc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Productos_Familias_Marcas_Etc.TabIndex = 57
        Me.Rdb_Productos_Familias_Marcas_Etc.Text = "Seleccionar productos Familias, marcas, etc..."
        '
        'Btn_Buscar_Proveedor
        '
        Me.Btn_Buscar_Proveedor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Proveedor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Proveedor.Image = CType(resources.GetObject("Btn_Buscar_Proveedor.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Proveedor.ImageAlt = CType(resources.GetObject("Btn_Buscar_Proveedor.ImageAlt"), System.Drawing.Image)
        Me.Btn_Buscar_Proveedor.Location = New System.Drawing.Point(6, 233)
        Me.Btn_Buscar_Proveedor.Name = "Btn_Buscar_Proveedor"
        Me.Btn_Buscar_Proveedor.Size = New System.Drawing.Size(46, 21)
        Me.Btn_Buscar_Proveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Proveedor.TabIndex = 9
        Me.Btn_Buscar_Proveedor.Tooltip = "Buscar proveedor"
        '
        'Chk_Traer_Productos_De_Reemplazo
        '
        Me.Chk_Traer_Productos_De_Reemplazo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Traer_Productos_De_Reemplazo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Traer_Productos_De_Reemplazo.CheckBoxImageChecked = CType(resources.GetObject("Chk_Traer_Productos_De_Reemplazo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Traer_Productos_De_Reemplazo.Checked = True
        Me.Chk_Traer_Productos_De_Reemplazo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Traer_Productos_De_Reemplazo.CheckValue = "Y"
        Me.Chk_Traer_Productos_De_Reemplazo.FocusCuesEnabled = False
        Me.Chk_Traer_Productos_De_Reemplazo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Traer_Productos_De_Reemplazo.Location = New System.Drawing.Point(6, 204)
        Me.Chk_Traer_Productos_De_Reemplazo.Name = "Chk_Traer_Productos_De_Reemplazo"
        Me.Chk_Traer_Productos_De_Reemplazo.Size = New System.Drawing.Size(170, 23)
        Me.Chk_Traer_Productos_De_Reemplazo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Traer_Productos_De_Reemplazo.TabIndex = 24
        Me.Chk_Traer_Productos_De_Reemplazo.Text = "Traer productos de reemplazo"
        '
        'Chk_Ent_Fisica
        '
        Me.Chk_Ent_Fisica.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Ent_Fisica.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Ent_Fisica.CheckBoxImageChecked = CType(resources.GetObject("Chk_Ent_Fisica.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Ent_Fisica.FocusCuesEnabled = False
        Me.Chk_Ent_Fisica.ForeColor = System.Drawing.Color.Black
        Me.Chk_Ent_Fisica.Location = New System.Drawing.Point(275, 260)
        Me.Chk_Ent_Fisica.Name = "Chk_Ent_Fisica"
        Me.Chk_Ent_Fisica.Size = New System.Drawing.Size(241, 23)
        Me.Chk_Ent_Fisica.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Ent_Fisica.TabIndex = 50
        Me.Chk_Ent_Fisica.Text = "considerar proveedor(es) como entidad física"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Dtp_Fecha_Vta_Desde)
        Me.GroupPanel1.Controls.Add(Me.Input_Ultimos_Meses_Vta_Promedio)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel1.Controls.Add(Me.Dtp_Fecha_Vta_Hasta)
        Me.GroupPanel1.Controls.Add(Me.Btn_Bodega_Vta_Estudio)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 328)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(545, 270)
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
        Me.GroupPanel1.TabIndex = 106
        Me.GroupPanel1.Text = "GroupPanel1"
        '
        'Dtp_Fecha_Vta_Desde
        '
        Me.Dtp_Fecha_Vta_Desde.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Vta_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Vta_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Vta_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Vta_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Vta_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Vta_Desde.Location = New System.Drawing.Point(299, 39)
        '
        '
        '
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.DisplayMonth = New Date(2018, 10, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Vta_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Vta_Desde.Name = "Dtp_Fecha_Vta_Desde"
        Me.Dtp_Fecha_Vta_Desde.Size = New System.Drawing.Size(81, 22)
        Me.Dtp_Fecha_Vta_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Vta_Desde.TabIndex = 10015
        Me.Dtp_Fecha_Vta_Desde.Value = New Date(2018, 10, 19, 11, 12, 43, 0)
        '
        'Input_Ultimos_Meses_Vta_Promedio
        '
        Me.Input_Ultimos_Meses_Vta_Promedio.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Ultimos_Meses_Vta_Promedio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Ultimos_Meses_Vta_Promedio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Ultimos_Meses_Vta_Promedio.ButtonClear.Visible = True
        Me.Input_Ultimos_Meses_Vta_Promedio.FocusHighlightEnabled = True
        Me.Input_Ultimos_Meses_Vta_Promedio.ForeColor = System.Drawing.Color.Black
        Me.Input_Ultimos_Meses_Vta_Promedio.Location = New System.Drawing.Point(245, 68)
        Me.Input_Ultimos_Meses_Vta_Promedio.MaxValue = 24
        Me.Input_Ultimos_Meses_Vta_Promedio.MinValue = 1
        Me.Input_Ultimos_Meses_Vta_Promedio.Name = "Input_Ultimos_Meses_Vta_Promedio"
        Me.Input_Ultimos_Meses_Vta_Promedio.ShowUpDown = True
        Me.Input_Ultimos_Meses_Vta_Promedio.Size = New System.Drawing.Size(47, 22)
        Me.Input_Ultimos_Meses_Vta_Promedio.TabIndex = 10017
        Me.Input_Ultimos_Meses_Vta_Promedio.Value = 12
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(245, 42)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(47, 19)
        Me.LabelX2.TabIndex = 10020
        Me.LabelX2.Text = "Desde"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.47762!))
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Rango_Fechas_Vta_Promedio, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Rango_Meses_Vta_Promedio, 0, 1)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(6, 39)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.9434!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.0566!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(220, 51)
        Me.TableLayoutPanel2.TabIndex = 10013
        '
        'Rdb_Rango_Fechas_Vta_Promedio
        '
        '
        '
        '
        Me.Rdb_Rango_Fechas_Vta_Promedio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Rango_Fechas_Vta_Promedio.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Rango_Fechas_Vta_Promedio.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Rango_Fechas_Vta_Promedio.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Rango_Fechas_Vta_Promedio.FocusCuesEnabled = False
        Me.Rdb_Rango_Fechas_Vta_Promedio.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Rango_Fechas_Vta_Promedio.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Rango_Fechas_Vta_Promedio.Name = "Rdb_Rango_Fechas_Vta_Promedio"
        Me.Rdb_Rango_Fechas_Vta_Promedio.Size = New System.Drawing.Size(214, 19)
        Me.Rdb_Rango_Fechas_Vta_Promedio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Rango_Fechas_Vta_Promedio.TabIndex = 53
        Me.Rdb_Rango_Fechas_Vta_Promedio.Text = "Ventas generadas entre un periodo"
        '
        'Rdb_Rango_Meses_Vta_Promedio
        '
        '
        '
        '
        Me.Rdb_Rango_Meses_Vta_Promedio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Rango_Meses_Vta_Promedio.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Rango_Meses_Vta_Promedio.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Rango_Meses_Vta_Promedio.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Rango_Meses_Vta_Promedio.Checked = True
        Me.Rdb_Rango_Meses_Vta_Promedio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Rango_Meses_Vta_Promedio.CheckValue = "Y"
        Me.Rdb_Rango_Meses_Vta_Promedio.FocusCuesEnabled = False
        Me.Rdb_Rango_Meses_Vta_Promedio.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Rango_Meses_Vta_Promedio.Location = New System.Drawing.Point(3, 28)
        Me.Rdb_Rango_Meses_Vta_Promedio.Name = "Rdb_Rango_Meses_Vta_Promedio"
        Me.Rdb_Rango_Meses_Vta_Promedio.Size = New System.Drawing.Size(214, 20)
        Me.Rdb_Rango_Meses_Vta_Promedio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Rango_Meses_Vta_Promedio.TabIndex = 52
        Me.Rdb_Rango_Meses_Vta_Promedio.Text = "Ventas generadas en los últimos meses"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(386, 42)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(39, 19)
        Me.LabelX1.TabIndex = 10019
        Me.LabelX1.Text = "Hasta"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Incluir_Salidas_GDI_OT, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Rotacion_Con_Ent_Excluidas, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Sumar_Rotacion_Hermanos, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 96)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(501, 64)
        Me.TableLayoutPanel1.TabIndex = 10014
        '
        'Chk_Incluir_Salidas_GDI_OT
        '
        Me.Chk_Incluir_Salidas_GDI_OT.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Incluir_Salidas_GDI_OT.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Incluir_Salidas_GDI_OT.CheckBoxImageChecked = CType(resources.GetObject("Chk_Incluir_Salidas_GDI_OT.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Incluir_Salidas_GDI_OT.FocusCuesEnabled = False
        Me.Chk_Incluir_Salidas_GDI_OT.ForeColor = System.Drawing.Color.Black
        Me.Chk_Incluir_Salidas_GDI_OT.Location = New System.Drawing.Point(3, 45)
        Me.Chk_Incluir_Salidas_GDI_OT.Name = "Chk_Incluir_Salidas_GDI_OT"
        Me.Chk_Incluir_Salidas_GDI_OT.Size = New System.Drawing.Size(495, 15)
        Me.Chk_Incluir_Salidas_GDI_OT.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Incluir_Salidas_GDI_OT.TabIndex = 10013
        Me.Chk_Incluir_Salidas_GDI_OT.Text = "Incluir salidas hacia producción para el estudio (GDI hacia ODT)"
        '
        'Chk_Rotacion_Con_Ent_Excluidas
        '
        Me.Chk_Rotacion_Con_Ent_Excluidas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Rotacion_Con_Ent_Excluidas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Rotacion_Con_Ent_Excluidas.CheckBoxImageChecked = CType(resources.GetObject("Chk_Rotacion_Con_Ent_Excluidas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Rotacion_Con_Ent_Excluidas.FocusCuesEnabled = False
        Me.Chk_Rotacion_Con_Ent_Excluidas.ForeColor = System.Drawing.Color.Black
        Me.Chk_Rotacion_Con_Ent_Excluidas.Location = New System.Drawing.Point(3, 24)
        Me.Chk_Rotacion_Con_Ent_Excluidas.Name = "Chk_Rotacion_Con_Ent_Excluidas"
        Me.Chk_Rotacion_Con_Ent_Excluidas.Size = New System.Drawing.Size(495, 15)
        Me.Chk_Rotacion_Con_Ent_Excluidas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Rotacion_Con_Ent_Excluidas.TabIndex = 53
        Me.Chk_Rotacion_Con_Ent_Excluidas.Text = "Rotación incluye ventas a Entidades Excluidas (recomendado solo para importacione" &
    "s)"
        '
        'Chk_Sumar_Rotacion_Hermanos
        '
        Me.Chk_Sumar_Rotacion_Hermanos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Sumar_Rotacion_Hermanos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Sumar_Rotacion_Hermanos.CheckBoxImageChecked = CType(resources.GetObject("Chk_Sumar_Rotacion_Hermanos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Sumar_Rotacion_Hermanos.FocusCuesEnabled = False
        Me.Chk_Sumar_Rotacion_Hermanos.ForeColor = System.Drawing.Color.Black
        Me.Chk_Sumar_Rotacion_Hermanos.Location = New System.Drawing.Point(3, 3)
        Me.Chk_Sumar_Rotacion_Hermanos.Name = "Chk_Sumar_Rotacion_Hermanos"
        Me.Chk_Sumar_Rotacion_Hermanos.Size = New System.Drawing.Size(495, 15)
        Me.Chk_Sumar_Rotacion_Hermanos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Sumar_Rotacion_Hermanos.TabIndex = 53
        Me.Chk_Sumar_Rotacion_Hermanos.Text = "Sumar rotación de hermanos (agrupar en un solo producto)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Dtp_Fecha_Vta_Hasta
        '
        Me.Dtp_Fecha_Vta_Hasta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_Fecha_Vta_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Vta_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Vta_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Vta_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Vta_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Vta_Hasta.Location = New System.Drawing.Point(431, 39)
        '
        '
        '
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.DisplayMonth = New Date(2018, 10, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Vta_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Vta_Hasta.Name = "Dtp_Fecha_Vta_Hasta"
        Me.Dtp_Fecha_Vta_Hasta.Size = New System.Drawing.Size(80, 22)
        Me.Dtp_Fecha_Vta_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Vta_Hasta.TabIndex = 10016
        Me.Dtp_Fecha_Vta_Hasta.Value = New Date(2018, 10, 19, 11, 12, 43, 0)
        '
        'Btn_Bodega_Vta_Estudio
        '
        Me.Btn_Bodega_Vta_Estudio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Bodega_Vta_Estudio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Bodega_Vta_Estudio.FocusCuesEnabled = False
        Me.Btn_Bodega_Vta_Estudio.Image = CType(resources.GetObject("Btn_Bodega_Vta_Estudio.Image"), System.Drawing.Image)
        Me.Btn_Bodega_Vta_Estudio.ImageAlt = CType(resources.GetObject("Btn_Bodega_Vta_Estudio.ImageAlt"), System.Drawing.Image)
        Me.Btn_Bodega_Vta_Estudio.Location = New System.Drawing.Point(6, 3)
        Me.Btn_Bodega_Vta_Estudio.Name = "Btn_Bodega_Vta_Estudio"
        Me.Btn_Bodega_Vta_Estudio.Size = New System.Drawing.Size(181, 30)
        Me.Btn_Bodega_Vta_Estudio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Bodega_Vta_Estudio.TabIndex = 10018
        Me.Btn_Bodega_Vta_Estudio.Text = "Bodegas de estudio VENTA"
        '
        'Frm_MediaYPromedioXProd_Estudio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 661)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Grupo_Productos)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_MediaYPromedioXProd_Estudio"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Productos.ResumeLayout(False)
        CType(Me.Input_Productos_Ranking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Movimientos_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Movimientos_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Vta_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Ultimos_Meses_Vta_Promedio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Vta_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Productos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_InformeDeComprasAgrupadoporAsociacion As DevComponents.DotNetBar.Controls.CheckBoxX
    Private WithEvents Input_Productos_Ranking As DevComponents.Editors.IntegerInput
    Friend WithEvents BtnSeleccionarProductos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Seleccionar_Productos_X_Clasificacion_RD As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Dtp_Fecha_Movimientos_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Txt_Padre_Asociacion_Productos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Filtrar_ProdProveedor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Dtp_Fecha_Movimientos_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Chk_Solo_Proveedores_CodAlternativo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_Proveedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Cantidad_Dias_Ultima_Venta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents Rdb_Productos_Clasificacion As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Todos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Seleccionar As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Con_Movimientos_De_Venta As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Vendidos_Los_Ultimos_Dias As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Proveedor As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Ranking As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Productos_Familias_Marcas_Etc As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Buscar_Proveedor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Chk_Traer_Productos_De_Reemplazo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Ent_Fisica As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Dtp_Fecha_Vta_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Private WithEvents Input_Ultimos_Meses_Vta_Promedio As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Rdb_Rango_Fechas_Vta_Promedio As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Rango_Meses_Vta_Promedio As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Chk_Incluir_Salidas_GDI_OT As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Rotacion_Con_Ent_Excluidas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Sumar_Rotacion_Hermanos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Dtp_Fecha_Vta_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Btn_Bodega_Vta_Estudio As DevComponents.DotNetBar.ButtonX
End Class
