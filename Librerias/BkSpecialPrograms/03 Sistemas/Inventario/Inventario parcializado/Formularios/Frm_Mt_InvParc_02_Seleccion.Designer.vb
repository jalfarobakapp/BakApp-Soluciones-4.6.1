<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Mt_InvParc_02_Seleccion
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Mt_InvParc_02_Seleccion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnProcesar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnAgregarCodigo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Importar_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnMaestroProductos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Consolidar_Stock = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Codigos_de_Barra = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Foto_Stock = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtFechaInv = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Guias_Ajuste = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Ver_GDI_Deja_Stock_En_Cero = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Ver_GRI_Deja_Stock_En_Cero = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Ver_GRI_Definitiva_Ajuste = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Estadisticas_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Editar_Descripcion_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Quitar_Producto_De_La_Lista = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Ocultar_Desocultar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Arbol_Clasificaciones = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Codigo_Alternativo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Kardex = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Ubicaciones_Del_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Ubicacion = New DevComponents.DotNetBar.ButtonItem()
        Me.RadialMenuItem6 = New DevComponents.DotNetBar.RadialMenuItem()
        Me.RadialMenuItem7 = New DevComponents.DotNetBar.RadialMenuItem()
        Me.Super_Tab = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Grilla_Levantados = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.Img_Imagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.Chk_Dejar_Doc_Final_Del_Dia = New System.Windows.Forms.CheckBox()
        Me.Progreso_Cont = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Lbl_Actualizar_Stock = New DevComponents.DotNetBar.LabelX()
        Me.Progreso_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Lbl_Nombre_Producto_Linea_Activa_Grilla = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtFechaInv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Super_Tab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Super_Tab.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.Grilla_Levantados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnProcesar, Me.BtnAgregarCodigo, Me.Btn_Importar_Productos, Me.BtnMaestroProductos, Me.Btn_Consolidar_Stock, Me.Btn_Imprimir_Codigos_de_Barra, Me.Btn_Foto_Stock, Me.Btn_Exportar_Excel})
        Me.Bar1.Location = New System.Drawing.Point(0, 581)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1113, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 11
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnProcesar
        '
        Me.BtnProcesar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnProcesar.ForeColor = System.Drawing.Color.Black
        Me.BtnProcesar.Image = CType(resources.GetObject("BtnProcesar.Image"), System.Drawing.Image)
        Me.BtnProcesar.Name = "BtnProcesar"
        Me.BtnProcesar.Text = "Procesar..."
        '
        'BtnAgregarCodigo
        '
        Me.BtnAgregarCodigo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAgregarCodigo.ForeColor = System.Drawing.Color.Black
        Me.BtnAgregarCodigo.Image = CType(resources.GetObject("BtnAgregarCodigo.Image"), System.Drawing.Image)
        Me.BtnAgregarCodigo.Name = "BtnAgregarCodigo"
        Me.BtnAgregarCodigo.Tooltip = "Agregar código a la lista"
        Me.BtnAgregarCodigo.Visible = False
        '
        'Btn_Importar_Productos
        '
        Me.Btn_Importar_Productos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Importar_Productos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Importar_Productos.Image = CType(resources.GetObject("Btn_Importar_Productos.Image"), System.Drawing.Image)
        Me.Btn_Importar_Productos.Name = "Btn_Importar_Productos"
        Me.Btn_Importar_Productos.Tooltip = "Importar productos masivamente"
        '
        'BtnMaestroProductos
        '
        Me.BtnMaestroProductos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnMaestroProductos.ForeColor = System.Drawing.Color.Black
        Me.BtnMaestroProductos.Image = CType(resources.GetObject("BtnMaestroProductos.Image"), System.Drawing.Image)
        Me.BtnMaestroProductos.Name = "BtnMaestroProductos"
        Me.BtnMaestroProductos.Tooltip = "Ver maestra de productos"
        Me.BtnMaestroProductos.Visible = False
        '
        'Btn_Consolidar_Stock
        '
        Me.Btn_Consolidar_Stock.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Consolidar_Stock.ForeColor = System.Drawing.Color.Black
        Me.Btn_Consolidar_Stock.Image = CType(resources.GetObject("Btn_Consolidar_Stock.Image"), System.Drawing.Image)
        Me.Btn_Consolidar_Stock.Name = "Btn_Consolidar_Stock"
        Me.Btn_Consolidar_Stock.Text = "Consolidar Stock"
        Me.Btn_Consolidar_Stock.Tooltip = "Consolidar stock por producto de la grilla activa"
        '
        'Btn_Imprimir_Codigos_de_Barra
        '
        Me.Btn_Imprimir_Codigos_de_Barra.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Imprimir_Codigos_de_Barra.ForeColor = System.Drawing.Color.Black
        Me.Btn_Imprimir_Codigos_de_Barra.Image = CType(resources.GetObject("Btn_Imprimir_Codigos_de_Barra.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Codigos_de_Barra.Name = "Btn_Imprimir_Codigos_de_Barra"
        Me.Btn_Imprimir_Codigos_de_Barra.Tooltip = "Imprimir etiquetas"
        '
        'Btn_Foto_Stock
        '
        Me.Btn_Foto_Stock.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Foto_Stock.ForeColor = System.Drawing.Color.Black
        Me.Btn_Foto_Stock.Image = CType(resources.GetObject("Btn_Foto_Stock.Image"), System.Drawing.Image)
        Me.Btn_Foto_Stock.Name = "Btn_Foto_Stock"
        Me.Btn_Foto_Stock.Tooltip = "Actualizar foto stock inventario actual"
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar a Excel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(849, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "FECHA"
        '
        'DtFechaInv
        '
        Me.DtFechaInv.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.DtFechaInv.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DtFechaInv.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtFechaInv.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DtFechaInv.ButtonDropDown.Visible = True
        Me.DtFechaInv.Enabled = False
        Me.DtFechaInv.ForeColor = System.Drawing.Color.Black
        Me.DtFechaInv.Format = DevComponents.Editors.eDateTimePickerFormat.[Long]
        Me.DtFechaInv.IsPopupCalendarOpen = False
        Me.DtFechaInv.Location = New System.Drawing.Point(896, 9)
        '
        '
        '
        Me.DtFechaInv.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DtFechaInv.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtFechaInv.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DtFechaInv.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DtFechaInv.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DtFechaInv.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DtFechaInv.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DtFechaInv.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DtFechaInv.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DtFechaInv.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DtFechaInv.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtFechaInv.MonthCalendar.DisplayMonth = New Date(2014, 10, 1, 0, 0, 0, 0)
        Me.DtFechaInv.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DtFechaInv.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DtFechaInv.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DtFechaInv.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DtFechaInv.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DtFechaInv.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DtFechaInv.MonthCalendar.TodayButtonVisible = True
        Me.DtFechaInv.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DtFechaInv.Name = "DtFechaInv"
        Me.DtFechaInv.Size = New System.Drawing.Size(205, 22)
        Me.DtFechaInv.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DtFechaInv.TabIndex = 14
        Me.DtFechaInv.Value = New Date(2014, 10, 2, 11, 14, 2, 0)
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Guias_Ajuste, Me.Menu_Contextual_Productos})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(12, 9)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(376, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 83
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Guias_Ajuste
        '
        Me.Menu_Contextual_Guias_Ajuste.AutoExpandOnClick = True
        Me.Menu_Contextual_Guias_Ajuste.Name = "Menu_Contextual_Guias_Ajuste"
        Me.Menu_Contextual_Guias_Ajuste.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.Btn_Mnu_Ver_GDI_Deja_Stock_En_Cero, Me.Btn_Mnu_Ver_GRI_Deja_Stock_En_Cero, Me.LabelItem3, Me.Btn_Mnu_Ver_GRI_Definitiva_Ajuste})
        Me.Menu_Contextual_Guias_Ajuste.Text = "Opciones Guias Ajuste"
        '
        'LabelItem2
        '
        Me.LabelItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem2.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingBottom = 1
        Me.LabelItem2.PaddingLeft = 10
        Me.LabelItem2.PaddingTop = 1
        Me.LabelItem2.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem2.Text = "Documentos que dejan el stock en cero"
        '
        'Btn_Mnu_Ver_GDI_Deja_Stock_En_Cero
        '
        Me.Btn_Mnu_Ver_GDI_Deja_Stock_En_Cero.Image = CType(resources.GetObject("Btn_Mnu_Ver_GDI_Deja_Stock_En_Cero.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Ver_GDI_Deja_Stock_En_Cero.Name = "Btn_Mnu_Ver_GDI_Deja_Stock_En_Cero"
        Me.Btn_Mnu_Ver_GDI_Deja_Stock_En_Cero.Text = "Ver GDI deja stock en cero"
        '
        'Btn_Mnu_Ver_GRI_Deja_Stock_En_Cero
        '
        Me.Btn_Mnu_Ver_GRI_Deja_Stock_En_Cero.Image = CType(resources.GetObject("Btn_Mnu_Ver_GRI_Deja_Stock_En_Cero.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Ver_GRI_Deja_Stock_En_Cero.Name = "Btn_Mnu_Ver_GRI_Deja_Stock_En_Cero"
        Me.Btn_Mnu_Ver_GRI_Deja_Stock_En_Cero.Text = "Ver GRI deja stock en cero"
        '
        'LabelItem3
        '
        Me.LabelItem3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem3.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem3.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingBottom = 1
        Me.LabelItem3.PaddingLeft = 10
        Me.LabelItem3.PaddingTop = 1
        Me.LabelItem3.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem3.Text = "Guia de ajuste definitiva"
        '
        'Btn_Mnu_Ver_GRI_Definitiva_Ajuste
        '
        Me.Btn_Mnu_Ver_GRI_Definitiva_Ajuste.Image = CType(resources.GetObject("Btn_Mnu_Ver_GRI_Definitiva_Ajuste.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Ver_GRI_Definitiva_Ajuste.Name = "Btn_Mnu_Ver_GRI_Definitiva_Ajuste"
        Me.Btn_Mnu_Ver_GRI_Definitiva_Ajuste.Text = "Ver GRI de ajuste de Stock"
        '
        'Menu_Contextual_Productos
        '
        Me.Menu_Contextual_Productos.AutoExpandOnClick = True
        Me.Menu_Contextual_Productos.Name = "Menu_Contextual_Productos"
        Me.Menu_Contextual_Productos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Mnu_Estadisticas_Producto, Me.Btn_Mnu_Editar_Descripcion_Producto, Me.Btn_Mnu_Quitar_Producto_De_La_Lista, Me.Btn_Mnu_Ocultar_Desocultar, Me.Btn_Mnu_Arbol_Clasificaciones, Me.Btn_Mnu_Codigo_Alternativo, Me.Btn_Mnu_Kardex, Me.Btn_Mnu_Ubicaciones_Del_Producto, Me.Btn_Imprimir_Ubicacion})
        Me.Menu_Contextual_Productos.Text = "Opciones productos"
        '
        'LabelItem1
        '
        Me.LabelItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.PaddingBottom = 1
        Me.LabelItem1.PaddingLeft = 10
        Me.LabelItem1.PaddingTop = 1
        Me.LabelItem1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem1.Text = "Opciones del producto"
        '
        'Btn_Mnu_Estadisticas_Producto
        '
        Me.Btn_Mnu_Estadisticas_Producto.Image = CType(resources.GetObject("Btn_Mnu_Estadisticas_Producto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Estadisticas_Producto.Name = "Btn_Mnu_Estadisticas_Producto"
        Me.Btn_Mnu_Estadisticas_Producto.Text = "Ver estadísticas del producto/información adicional"
        '
        'Btn_Mnu_Editar_Descripcion_Producto
        '
        Me.Btn_Mnu_Editar_Descripcion_Producto.Image = CType(resources.GetObject("Btn_Mnu_Editar_Descripcion_Producto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Editar_Descripcion_Producto.Name = "Btn_Mnu_Editar_Descripcion_Producto"
        Me.Btn_Mnu_Editar_Descripcion_Producto.Text = "Editar descripción del producto"
        '
        'Btn_Mnu_Quitar_Producto_De_La_Lista
        '
        Me.Btn_Mnu_Quitar_Producto_De_La_Lista.Image = CType(resources.GetObject("Btn_Mnu_Quitar_Producto_De_La_Lista.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Quitar_Producto_De_La_Lista.Name = "Btn_Mnu_Quitar_Producto_De_La_Lista"
        Me.Btn_Mnu_Quitar_Producto_De_La_Lista.Text = "Quitar producto del listado"
        '
        'Btn_Mnu_Ocultar_Desocultar
        '
        Me.Btn_Mnu_Ocultar_Desocultar.Image = CType(resources.GetObject("Btn_Mnu_Ocultar_Desocultar.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Ocultar_Desocultar.Name = "Btn_Mnu_Ocultar_Desocultar"
        Me.Btn_Mnu_Ocultar_Desocultar.Text = "Ocultar/Desocultar"
        '
        'Btn_Mnu_Arbol_Clasificaciones
        '
        Me.Btn_Mnu_Arbol_Clasificaciones.Image = CType(resources.GetObject("Btn_Mnu_Arbol_Clasificaciones.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Arbol_Clasificaciones.Name = "Btn_Mnu_Arbol_Clasificaciones"
        Me.Btn_Mnu_Arbol_Clasificaciones.Text = "Ver arbol de clasificaciones del producto"
        '
        'Btn_Mnu_Codigo_Alternativo
        '
        Me.Btn_Mnu_Codigo_Alternativo.Image = CType(resources.GetObject("Btn_Mnu_Codigo_Alternativo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Codigo_Alternativo.Name = "Btn_Mnu_Codigo_Alternativo"
        Me.Btn_Mnu_Codigo_Alternativo.Text = "Códigos alternativos del producto"
        '
        'Btn_Mnu_Kardex
        '
        Me.Btn_Mnu_Kardex.Image = CType(resources.GetObject("Btn_Mnu_Kardex.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Kardex.Name = "Btn_Mnu_Kardex"
        Me.Btn_Mnu_Kardex.Text = "Kardex de inventario"
        '
        'Btn_Mnu_Ubicaciones_Del_Producto
        '
        Me.Btn_Mnu_Ubicaciones_Del_Producto.Image = CType(resources.GetObject("Btn_Mnu_Ubicaciones_Del_Producto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Ubicaciones_Del_Producto.Name = "Btn_Mnu_Ubicaciones_Del_Producto"
        Me.Btn_Mnu_Ubicaciones_Del_Producto.Text = "Ubicación del producto"
        '
        'Btn_Imprimir_Ubicacion
        '
        Me.Btn_Imprimir_Ubicacion.Image = CType(resources.GetObject("Btn_Imprimir_Ubicacion.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Ubicacion.Name = "Btn_Imprimir_Ubicacion"
        Me.Btn_Imprimir_Ubicacion.Text = "Imprimir etiqueta"
        '
        'RadialMenuItem6
        '
        Me.RadialMenuItem6.Name = "RadialMenuItem6"
        Me.RadialMenuItem6.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.RadialMenuItem7})
        Me.RadialMenuItem6.Text = "Item 6"
        '
        'RadialMenuItem7
        '
        Me.RadialMenuItem7.Name = "RadialMenuItem7"
        Me.RadialMenuItem7.Text = "Item 6"
        '
        'Super_Tab
        '
        Me.Super_Tab.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.Super_Tab.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.Super_Tab.ControlBox.MenuBox.Name = ""
        Me.Super_Tab.ControlBox.Name = ""
        Me.Super_Tab.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Super_Tab.ControlBox.MenuBox, Me.Super_Tab.ControlBox.CloseBox})
        Me.Super_Tab.Controls.Add(Me.SuperTabControlPanel1)
        Me.Super_Tab.Controls.Add(Me.SuperTabControlPanel2)
        Me.Super_Tab.ForeColor = System.Drawing.Color.Black
        Me.Super_Tab.Location = New System.Drawing.Point(12, 37)
        Me.Super_Tab.Name = "Super_Tab"
        Me.Super_Tab.ReorderTabsEnabled = True
        Me.Super_Tab.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Super_Tab.SelectedTabIndex = 0
        Me.Super_Tab.Size = New System.Drawing.Size(1089, 457)
        Me.Super_Tab.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Super_Tab.TabIndex = 84
        Me.Super_Tab.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2})
        Me.Super_Tab.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.Grilla)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(1089, 430)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
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
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(1089, 430)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 53
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Productos en tratamiento de inventario actual"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.Grilla_Levantados)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(1013, 430)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'Grilla_Levantados
        '
        Me.Grilla_Levantados.AllowUserToAddRows = False
        Me.Grilla_Levantados.AllowUserToDeleteRows = False
        Me.Grilla_Levantados.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Levantados.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Levantados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Levantados.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla_Levantados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Levantados.EnableHeadersVisualStyles = False
        Me.Grilla_Levantados.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Levantados.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Levantados.Name = "Grilla_Levantados"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Levantados.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla_Levantados.Size = New System.Drawing.Size(1013, 430)
        Me.Grilla_Levantados.StandardTab = True
        Me.Grilla_Levantados.TabIndex = 54
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Productos inventariados procesados"
        '
        'Img_Imagenes
        '
        Me.Img_Imagenes.ImageStream = CType(resources.GetObject("Img_Imagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Img_Imagenes.TransparentColor = System.Drawing.Color.Transparent
        Me.Img_Imagenes.Images.SetKeyName(0, "GDI_Cero_True")
        Me.Img_Imagenes.Images.SetKeyName(1, "GDI_Cero_False")
        Me.Img_Imagenes.Images.SetKeyName(2, "GRI_Cero_True")
        Me.Img_Imagenes.Images.SetKeyName(3, "GRI_Cero_False")
        Me.Img_Imagenes.Images.SetKeyName(4, "GRI_Ajuste_True")
        Me.Img_Imagenes.Images.SetKeyName(5, "GRI_Ajuste_False")
        '
        'Chk_Dejar_Doc_Final_Del_Dia
        '
        Me.Chk_Dejar_Doc_Final_Del_Dia.AutoSize = True
        Me.Chk_Dejar_Doc_Final_Del_Dia.BackColor = System.Drawing.Color.White
        Me.Chk_Dejar_Doc_Final_Del_Dia.Enabled = False
        Me.Chk_Dejar_Doc_Final_Del_Dia.ForeColor = System.Drawing.Color.Black
        Me.Chk_Dejar_Doc_Final_Del_Dia.Location = New System.Drawing.Point(12, 539)
        Me.Chk_Dejar_Doc_Final_Del_Dia.Name = "Chk_Dejar_Doc_Final_Del_Dia"
        Me.Chk_Dejar_Doc_Final_Del_Dia.Size = New System.Drawing.Size(198, 17)
        Me.Chk_Dejar_Doc_Final_Del_Dia.TabIndex = 85
        Me.Chk_Dejar_Doc_Final_Del_Dia.Text = "Hora de grabación al final del día"
        Me.Chk_Dejar_Doc_Final_Del_Dia.UseVisualStyleBackColor = False
        '
        'Progreso_Cont
        '
        Me.Progreso_Cont.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Cont.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Cont.Location = New System.Drawing.Point(495, 528)
        Me.Progreso_Cont.Name = "Progreso_Cont"
        Me.Progreso_Cont.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Cont.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Cont.ProgressTextFormat = "{0}"
        Me.Progreso_Cont.ProgressTextVisible = True
        Me.Progreso_Cont.Size = New System.Drawing.Size(44, 33)
        Me.Progreso_Cont.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Cont.TabIndex = 86
        Me.Progreso_Cont.Visible = False
        '
        'Lbl_Actualizar_Stock
        '
        Me.Lbl_Actualizar_Stock.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Actualizar_Stock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Actualizar_Stock.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Actualizar_Stock.Location = New System.Drawing.Point(586, 535)
        Me.Lbl_Actualizar_Stock.Name = "Lbl_Actualizar_Stock"
        Me.Lbl_Actualizar_Stock.Size = New System.Drawing.Size(153, 23)
        Me.Lbl_Actualizar_Stock.TabIndex = 87
        Me.Lbl_Actualizar_Stock.Text = "Actualizando foto Stock"
        Me.Lbl_Actualizar_Stock.Visible = False
        '
        'Progreso_Porc
        '
        Me.Progreso_Porc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Porc.Location = New System.Drawing.Point(536, 527)
        Me.Progreso_Porc.Name = "Progreso_Porc"
        Me.Progreso_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Porc.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Porc.ProgressTextVisible = True
        Me.Progreso_Porc.Size = New System.Drawing.Size(44, 34)
        Me.Progreso_Porc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Porc.TabIndex = 88
        '
        'Lbl_Nombre_Producto_Linea_Activa_Grilla
        '
        Me.Lbl_Nombre_Producto_Linea_Activa_Grilla.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Nombre_Producto_Linea_Activa_Grilla.BackgroundStyle.Class = "RibbonGalleryContainer"
        Me.Lbl_Nombre_Producto_Linea_Activa_Grilla.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nombre_Producto_Linea_Activa_Grilla.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nombre_Producto_Linea_Activa_Grilla.Location = New System.Drawing.Point(12, 500)
        Me.Lbl_Nombre_Producto_Linea_Activa_Grilla.Name = "Lbl_Nombre_Producto_Linea_Activa_Grilla"
        Me.Lbl_Nombre_Producto_Linea_Activa_Grilla.Size = New System.Drawing.Size(1182, 22)
        Me.Lbl_Nombre_Producto_Linea_Activa_Grilla.TabIndex = 91
        '
        'Frm_Mt_InvParc_02_Seleccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1113, 622)
        Me.Controls.Add(Me.Lbl_Nombre_Producto_Linea_Activa_Grilla)
        Me.Controls.Add(Me.Progreso_Porc)
        Me.Controls.Add(Me.Lbl_Actualizar_Stock)
        Me.Controls.Add(Me.Progreso_Cont)
        Me.Controls.Add(Me.Chk_Dejar_Doc_Final_Del_Dia)
        Me.Controls.Add(Me.ContextMenuBar1)
        Me.Controls.Add(Me.Super_Tab)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.DtFechaInv)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Mt_InvParc_02_Seleccion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AJUSTE DE INVENTARIO"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtFechaInv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Super_Tab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Super_Tab.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.Grilla_Levantados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnProcesar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnAgregarCodigo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnMaestroProductos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents DtFechaInv As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Btn_Importar_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Consolidar_Stock As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RadialMenuItem6 As DevComponents.DotNetBar.RadialMenuItem
    Friend WithEvents RadialMenuItem7 As DevComponents.DotNetBar.RadialMenuItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Estadisticas_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Editar_Descripcion_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Guias_Ajuste As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Ver_GDI_Deja_Stock_En_Cero As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Ver_GRI_Deja_Stock_En_Cero As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Ver_GRI_Definitiva_Ajuste As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Quitar_Producto_De_La_Lista As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Ocultar_Desocultar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Arbol_Clasificaciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Codigo_Alternativo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Kardex As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Ubicaciones_Del_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Super_Tab As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Img_Imagenes As System.Windows.Forms.ImageList
    Friend WithEvents Btn_Imprimir_Codigos_de_Barra As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir_Ubicacion As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Chk_Dejar_Doc_Final_Del_Dia As System.Windows.Forms.CheckBox
    Friend WithEvents Progreso_Cont As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Lbl_Actualizar_Stock As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Foto_Stock As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Grilla_Levantados As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Lbl_Nombre_Producto_Linea_Activa_Grilla As DevComponents.DotNetBar.LabelX
End Class
