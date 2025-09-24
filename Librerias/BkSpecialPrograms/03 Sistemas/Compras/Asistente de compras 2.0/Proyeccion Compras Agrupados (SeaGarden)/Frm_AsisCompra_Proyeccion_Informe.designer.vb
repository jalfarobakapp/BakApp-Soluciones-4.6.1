<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AsisCompra_Proyeccion_Informe
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_AsisCompra_Proyeccion_Informe))
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Estadisticas_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar_Rotacion_Producto_Actual = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Infor_Rotacion = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Ver_documento_origen = New DevComponents.DotNetBar.ButtonItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_Proximas_Recepciones = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Colapsar_Filas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_SugCambioPrecio = New DevComponents.DotNetBar.ButtonItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Input_Redondeo = New DevComponents.Editors.IntegerInput()
        Me.Panel_Ayuda = New DevComponents.DotNetBar.ExpandablePanel()
        Me.Lbl_Rosado = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Blanco = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Amarillo = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_VerdeOscuro = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_VerdeClaro = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
        Me.Super_Grilla = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_MostrarSugCambioPrecio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Proyeccion_Rotacion_Diaria = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Proyeccion_Promedio_Diario = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Proyeccion_Promedio_Ult3Meses = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Redondeo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Ayuda.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Productos})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(333, 125)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(370, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 46
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Productos
        '
        Me.Menu_Contextual_Productos.AutoExpandOnClick = True
        Me.Menu_Contextual_Productos.Name = "Menu_Contextual_Productos"
        Me.Menu_Contextual_Productos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.Btn_Estadisticas_Producto, Me.Btn_Actualizar_Rotacion_Producto_Actual, Me.Btn_Infor_Rotacion, Me.LabelItem5, Me.Btn_Ver_documento_origen})
        Me.Menu_Contextual_Productos.Text = "Opciones productos"
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
        Me.LabelItem3.Text = "Opciones del producto"
        '
        'Btn_Estadisticas_Producto
        '
        Me.Btn_Estadisticas_Producto.Image = CType(resources.GetObject("Btn_Estadisticas_Producto.Image"), System.Drawing.Image)
        Me.Btn_Estadisticas_Producto.Name = "Btn_Estadisticas_Producto"
        Me.Btn_Estadisticas_Producto.Text = "Ver estadísticas del producto/información adicional"
        '
        'Btn_Actualizar_Rotacion_Producto_Actual
        '
        Me.Btn_Actualizar_Rotacion_Producto_Actual.Image = CType(resources.GetObject("Btn_Actualizar_Rotacion_Producto_Actual.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Rotacion_Producto_Actual.Name = "Btn_Actualizar_Rotacion_Producto_Actual"
        Me.Btn_Actualizar_Rotacion_Producto_Actual.Text = "Actualizar rotación del producto"
        Me.Btn_Actualizar_Rotacion_Producto_Actual.Visible = False
        '
        'Btn_Infor_Rotacion
        '
        Me.Btn_Infor_Rotacion.Image = CType(resources.GetObject("Btn_Infor_Rotacion.Image"), System.Drawing.Image)
        Me.Btn_Infor_Rotacion.Name = "Btn_Infor_Rotacion"
        Me.Btn_Infor_Rotacion.Text = "Información de rotación según estudio"
        '
        'LabelItem5
        '
        Me.LabelItem5.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem5.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem5.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem5.Name = "LabelItem5"
        Me.LabelItem5.PaddingBottom = 1
        Me.LabelItem5.PaddingLeft = 10
        Me.LabelItem5.PaddingTop = 1
        Me.LabelItem5.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem5.Text = "Edicion"
        '
        'Btn_Ver_documento_origen
        '
        Me.Btn_Ver_documento_origen.Image = CType(resources.GetObject("Btn_Ver_documento_origen.Image"), System.Drawing.Image)
        Me.Btn_Ver_documento_origen.Name = "Btn_Ver_documento_origen"
        Me.Btn_Ver_documento_origen.Text = "Copiar"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Actualizar, Me.Btn_Exportar_Excel, Me.Btn_Informe_Proximas_Recepciones, Me.Btn_Colapsar_Filas, Me.Btn_SugCambioPrecio})
        Me.Bar1.Location = New System.Drawing.Point(0, 535)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1314, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 111
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Actualizar
        '
        Me.Btn_Actualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar.Image = CType(resources.GetObject("Btn_Actualizar.Image"), System.Drawing.Image)
        Me.Btn_Actualizar.ImageAlt = CType(resources.GetObject("Btn_Actualizar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar.Name = "Btn_Actualizar"
        Me.Btn_Actualizar.Tooltip = "Actualizar informe"
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.ImageAlt = CType(resources.GetObject("Btn_Exportar_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar a Excel"
        '
        'Btn_Informe_Proximas_Recepciones
        '
        Me.Btn_Informe_Proximas_Recepciones.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Informe_Proximas_Recepciones.ForeColor = System.Drawing.Color.Black
        Me.Btn_Informe_Proximas_Recepciones.Image = CType(resources.GetObject("Btn_Informe_Proximas_Recepciones.Image"), System.Drawing.Image)
        Me.Btn_Informe_Proximas_Recepciones.ImageAlt = CType(resources.GetObject("Btn_Informe_Proximas_Recepciones.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_Proximas_Recepciones.Name = "Btn_Informe_Proximas_Recepciones"
        Me.Btn_Informe_Proximas_Recepciones.Tooltip = "Informe próximas recepciones"
        '
        'Btn_Colapsar_Filas
        '
        Me.Btn_Colapsar_Filas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Colapsar_Filas.ForeColor = System.Drawing.Color.Black
        Me.Btn_Colapsar_Filas.Image = CType(resources.GetObject("Btn_Colapsar_Filas.Image"), System.Drawing.Image)
        Me.Btn_Colapsar_Filas.ImageAlt = CType(resources.GetObject("Btn_Colapsar_Filas.ImageAlt"), System.Drawing.Image)
        Me.Btn_Colapsar_Filas.Name = "Btn_Colapsar_Filas"
        Me.Btn_Colapsar_Filas.Tooltip = "Colapsar todas las filas"
        '
        'Btn_SugCambioPrecio
        '
        Me.Btn_SugCambioPrecio.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_SugCambioPrecio.ForeColor = System.Drawing.Color.Black
        Me.Btn_SugCambioPrecio.Image = CType(resources.GetObject("Btn_SugCambioPrecio.Image"), System.Drawing.Image)
        Me.Btn_SugCambioPrecio.ImageAlt = CType(resources.GetObject("Btn_SugCambioPrecio.ImageAlt"), System.Drawing.Image)
        Me.Btn_SugCambioPrecio.Name = "Btn_SugCambioPrecio"
        Me.Btn_SugCambioPrecio.Tooltip = "Colapsar todas las filas"
        Me.Btn_SugCambioPrecio.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(290, 519)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 126
        Me.Label1.Text = "Múltiplos de :"
        '
        'Input_Redondeo
        '
        Me.Input_Redondeo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Redondeo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Redondeo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Redondeo.ButtonClear.Visible = True
        Me.Input_Redondeo.FocusHighlightEnabled = True
        Me.Input_Redondeo.ForeColor = System.Drawing.Color.Black
        Me.Input_Redondeo.Location = New System.Drawing.Point(374, 516)
        Me.Input_Redondeo.MaxValue = 10000
        Me.Input_Redondeo.MinValue = 1
        Me.Input_Redondeo.Name = "Input_Redondeo"
        Me.Input_Redondeo.ShowUpDown = True
        Me.Input_Redondeo.Size = New System.Drawing.Size(61, 22)
        Me.Input_Redondeo.TabIndex = 125
        Me.Input_Redondeo.Value = 1
        '
        'Panel_Ayuda
        '
        Me.Panel_Ayuda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Ayuda.CanvasColor = System.Drawing.SystemColors.Control
        Me.Panel_Ayuda.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Panel_Ayuda.Controls.Add(Me.Lbl_Rosado)
        Me.Panel_Ayuda.Controls.Add(Me.Lbl_Blanco)
        Me.Panel_Ayuda.Controls.Add(Me.Lbl_Amarillo)
        Me.Panel_Ayuda.Controls.Add(Me.Lbl_VerdeOscuro)
        Me.Panel_Ayuda.Controls.Add(Me.Lbl_VerdeClaro)
        Me.Panel_Ayuda.Controls.Add(Me.LabelX10)
        Me.Panel_Ayuda.Controls.Add(Me.LabelX8)
        Me.Panel_Ayuda.Controls.Add(Me.LabelX6)
        Me.Panel_Ayuda.Controls.Add(Me.LabelX4)
        Me.Panel_Ayuda.Controls.Add(Me.LabelX2)
        Me.Panel_Ayuda.DisabledBackColor = System.Drawing.Color.Empty
        Me.Panel_Ayuda.Expanded = False
        Me.Panel_Ayuda.ExpandedBounds = New System.Drawing.Rectangle(789, 12, 513, 197)
        Me.Panel_Ayuda.HideControlsWhenCollapsed = True
        Me.Panel_Ayuda.Location = New System.Drawing.Point(789, 12)
        Me.Panel_Ayuda.Name = "Panel_Ayuda"
        Me.Panel_Ayuda.Size = New System.Drawing.Size(513, 26)
        Me.Panel_Ayuda.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.Panel_Ayuda.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Panel_Ayuda.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Panel_Ayuda.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.Panel_Ayuda.Style.GradientAngle = 90
        Me.Panel_Ayuda.TabIndex = 127
        Me.Panel_Ayuda.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.Panel_Ayuda.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Panel_Ayuda.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.Panel_Ayuda.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Panel_Ayuda.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Panel_Ayuda.TitleStyle.GradientAngle = 90
        Me.Panel_Ayuda.TitleText = "Grafica de Ayuda"
        '
        'Lbl_Rosado
        '
        Me.Lbl_Rosado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Rosado.BackgroundStyle.BorderBottomWidth = 1
        Me.Lbl_Rosado.BackgroundStyle.BorderColor = System.Drawing.Color.Black
        Me.Lbl_Rosado.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black
        Me.Lbl_Rosado.BackgroundStyle.BorderColorLight = System.Drawing.Color.Black
        Me.Lbl_Rosado.BackgroundStyle.BorderColorLight2 = System.Drawing.Color.Black
        Me.Lbl_Rosado.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black
        Me.Lbl_Rosado.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black
        Me.Lbl_Rosado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Rosado.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Rosado.Location = New System.Drawing.Point(15, 150)
        Me.Lbl_Rosado.Name = "Lbl_Rosado"
        Me.Lbl_Rosado.Size = New System.Drawing.Size(16, 23)
        Me.Lbl_Rosado.TabIndex = 10
        '
        'Lbl_Blanco
        '
        Me.Lbl_Blanco.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Blanco.BackgroundStyle.BorderBottomWidth = 1
        Me.Lbl_Blanco.BackgroundStyle.BorderColor = System.Drawing.Color.Black
        Me.Lbl_Blanco.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black
        Me.Lbl_Blanco.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Blanco.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Blanco.Location = New System.Drawing.Point(15, 121)
        Me.Lbl_Blanco.Name = "Lbl_Blanco"
        Me.Lbl_Blanco.Size = New System.Drawing.Size(16, 23)
        Me.Lbl_Blanco.TabIndex = 8
        '
        'Lbl_Amarillo
        '
        Me.Lbl_Amarillo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Amarillo.BackgroundStyle.BorderBottomWidth = 1
        Me.Lbl_Amarillo.BackgroundStyle.BorderColor = System.Drawing.Color.Black
        Me.Lbl_Amarillo.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black
        Me.Lbl_Amarillo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Amarillo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Amarillo.Location = New System.Drawing.Point(15, 92)
        Me.Lbl_Amarillo.Name = "Lbl_Amarillo"
        Me.Lbl_Amarillo.Size = New System.Drawing.Size(16, 23)
        Me.Lbl_Amarillo.TabIndex = 6
        '
        'Lbl_VerdeOscuro
        '
        Me.Lbl_VerdeOscuro.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_VerdeOscuro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_VerdeOscuro.ForeColor = System.Drawing.Color.Black
        Me.Lbl_VerdeOscuro.Location = New System.Drawing.Point(15, 63)
        Me.Lbl_VerdeOscuro.Name = "Lbl_VerdeOscuro"
        Me.Lbl_VerdeOscuro.Size = New System.Drawing.Size(16, 23)
        Me.Lbl_VerdeOscuro.TabIndex = 4
        '
        'Lbl_VerdeClaro
        '
        Me.Lbl_VerdeClaro.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_VerdeClaro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_VerdeClaro.ForeColor = System.Drawing.Color.Black
        Me.Lbl_VerdeClaro.Location = New System.Drawing.Point(15, 34)
        Me.Lbl_VerdeClaro.Name = "Lbl_VerdeClaro"
        Me.Lbl_VerdeClaro.Size = New System.Drawing.Size(16, 23)
        Me.Lbl_VerdeClaro.TabIndex = 2
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(37, 150)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(472, 23)
        Me.LabelX10.TabIndex = 9
        Me.LabelX10.Text = "DOCUMENTOS SIN RECEPCION DENTRO DE FECHA INDICADA (Revisar detalle de documentos)" &
    ""
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(37, 121)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(357, 23)
        Me.LabelX8.TabIndex = 7
        Me.LabelX8.Text = "TIEMPO CON STOCK POR RECEPCIONAR"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(37, 92)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(357, 23)
        Me.LabelX6.TabIndex = 5
        Me.LabelX6.Text = "TIEMPO SIN STOCK ASEGURADO (dentro del periodo de proyección)"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(37, 63)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(357, 23)
        Me.LabelX4.TabIndex = 3
        Me.LabelX4.Text = "TIEMPO CON STOCK FISICO ASEGURADO"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(37, 34)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(357, 23)
        Me.LabelX2.TabIndex = 1
        Me.LabelX2.Text = "TIEMPO CON STOCK POR RECEPCIONAR"
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
        'ButtonItem2
        '
        Me.ButtonItem2.Image = CType(resources.GetObject("ButtonItem2.Image"), System.Drawing.Image)
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "Ver estadísticas del producto/información adicional"
        Me.ButtonItem2.Visible = False
        '
        'ButtonItem3
        '
        Me.ButtonItem3.Image = CType(resources.GetObject("ButtonItem3.Image"), System.Drawing.Image)
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "Actualizar rotación del producto"
        '
        'ButtonItem4
        '
        Me.ButtonItem4.Image = CType(resources.GetObject("ButtonItem4.Image"), System.Drawing.Image)
        Me.ButtonItem4.Name = "ButtonItem4"
        Me.ButtonItem4.Text = "Información de rotación según estudio"
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
        Me.LabelItem2.Text = "Edicion"
        '
        'ButtonItem5
        '
        Me.ButtonItem5.Image = CType(resources.GetObject("ButtonItem5.Image"), System.Drawing.Image)
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.Text = "Copiar"
        '
        'Super_Grilla
        '
        Me.Super_Grilla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Super_Grilla.BackColor = System.Drawing.Color.White
        Me.Super_Grilla.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.Super_Grilla.ForeColor = System.Drawing.Color.Black
        Me.Super_Grilla.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Super_Grilla.Location = New System.Drawing.Point(12, 55)
        Me.Super_Grilla.Name = "Super_Grilla"
        Me.Super_Grilla.PrimaryGrid.Caption.Text = "(Detallede busqueda)<div align=""vcenter"">Información detallada de los productos d" &
    "e la empresa</div>"
        Me.Super_Grilla.PrimaryGrid.Filter.ShowPanelFilterExpr = True
        Me.Super_Grilla.PrimaryGrid.MultiSelect = False
        Me.Super_Grilla.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled
        Me.Super_Grilla.Size = New System.Drawing.Size(1290, 451)
        Me.Super_Grilla.TabIndex = 2
        Me.Super_Grilla.Text = "SuperGridControl2"
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
        Me.LabelX1.Size = New System.Drawing.Size(206, 23)
        Me.LabelX1.TabIndex = 131
        Me.LabelX1.Text = "Variable de estudio de rotación de venta:"
        '
        'Chk_MostrarSugCambioPrecio
        '
        Me.Chk_MostrarSugCambioPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Chk_MostrarSugCambioPrecio.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_MostrarSugCambioPrecio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_MostrarSugCambioPrecio.CheckBoxImageChecked = CType(resources.GetObject("Chk_MostrarSugCambioPrecio.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_MostrarSugCambioPrecio.FocusCuesEnabled = False
        Me.Chk_MostrarSugCambioPrecio.ForeColor = System.Drawing.Color.Black
        Me.Chk_MostrarSugCambioPrecio.Location = New System.Drawing.Point(12, 516)
        Me.Chk_MostrarSugCambioPrecio.Name = "Chk_MostrarSugCambioPrecio"
        Me.Chk_MostrarSugCambioPrecio.Size = New System.Drawing.Size(249, 13)
        Me.Chk_MostrarSugCambioPrecio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_MostrarSugCambioPrecio.TabIndex = 132
        Me.Chk_MostrarSugCambioPrecio.Text = "Mostrar sugerencia de cambio de precio"
        '
        'Rdb_Proyeccion_Rotacion_Diaria
        '
        Me.Rdb_Proyeccion_Rotacion_Diaria.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Proyeccion_Rotacion_Diaria.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Proyeccion_Rotacion_Diaria.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Proyeccion_Rotacion_Diaria.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Proyeccion_Rotacion_Diaria.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Proyeccion_Rotacion_Diaria.FocusCuesEnabled = False
        Me.Rdb_Proyeccion_Rotacion_Diaria.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Proyeccion_Rotacion_Diaria.Location = New System.Drawing.Point(224, 12)
        Me.Rdb_Proyeccion_Rotacion_Diaria.Name = "Rdb_Proyeccion_Rotacion_Diaria"
        Me.Rdb_Proyeccion_Rotacion_Diaria.Size = New System.Drawing.Size(68, 23)
        Me.Rdb_Proyeccion_Rotacion_Diaria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Proyeccion_Rotacion_Diaria.TabIndex = 133
        Me.Rdb_Proyeccion_Rotacion_Diaria.Text = "Mediana"
        '
        'Rdb_Proyeccion_Promedio_Diario
        '
        Me.Rdb_Proyeccion_Promedio_Diario.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Proyeccion_Promedio_Diario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Proyeccion_Promedio_Diario.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Proyeccion_Promedio_Diario.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Proyeccion_Promedio_Diario.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Proyeccion_Promedio_Diario.FocusCuesEnabled = False
        Me.Rdb_Proyeccion_Promedio_Diario.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Proyeccion_Promedio_Diario.Location = New System.Drawing.Point(298, 12)
        Me.Rdb_Proyeccion_Promedio_Diario.Name = "Rdb_Proyeccion_Promedio_Diario"
        Me.Rdb_Proyeccion_Promedio_Diario.Size = New System.Drawing.Size(118, 23)
        Me.Rdb_Proyeccion_Promedio_Diario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Proyeccion_Promedio_Diario.TabIndex = 134
        Me.Rdb_Proyeccion_Promedio_Diario.Text = "Promedio mensual"
        '
        'Rdb_Proyeccion_Promedio_Ult3Meses
        '
        Me.Rdb_Proyeccion_Promedio_Ult3Meses.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Proyeccion_Promedio_Ult3Meses.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Proyeccion_Promedio_Ult3Meses.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Proyeccion_Promedio_Ult3Meses.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Proyeccion_Promedio_Ult3Meses.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Proyeccion_Promedio_Ult3Meses.FocusCuesEnabled = False
        Me.Rdb_Proyeccion_Promedio_Ult3Meses.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Proyeccion_Promedio_Ult3Meses.Location = New System.Drawing.Point(422, 12)
        Me.Rdb_Proyeccion_Promedio_Ult3Meses.Name = "Rdb_Proyeccion_Promedio_Ult3Meses"
        Me.Rdb_Proyeccion_Promedio_Ult3Meses.Size = New System.Drawing.Size(126, 23)
        Me.Rdb_Proyeccion_Promedio_Ult3Meses.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Proyeccion_Promedio_Ult3Meses.TabIndex = 135
        Me.Rdb_Proyeccion_Promedio_Ult3Meses.Text = "Promedio Ult. 3 meses"
        '
        'Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes
        '
        Me.Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes.FocusCuesEnabled = False
        Me.Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes.Location = New System.Drawing.Point(554, 12)
        Me.Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes.Name = "Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes"
        Me.Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes.Size = New System.Drawing.Size(235, 23)
        Me.Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes.TabIndex = 136
        Me.Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes.Text = "Promedio Ult. 3 meses mas ventas ult. mes"
        '
        'Frm_AsisCompra_Proyeccion_Informe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1314, 576)
        Me.Controls.Add(Me.Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes)
        Me.Controls.Add(Me.Rdb_Proyeccion_Promedio_Ult3Meses)
        Me.Controls.Add(Me.Rdb_Proyeccion_Promedio_Diario)
        Me.Controls.Add(Me.Rdb_Proyeccion_Rotacion_Diaria)
        Me.Controls.Add(Me.Chk_MostrarSugCambioPrecio)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Panel_Ayuda)
        Me.Controls.Add(Me.ContextMenuBar1)
        Me.Controls.Add(Me.Super_Grilla)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Input_Redondeo)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Frm_AsisCompra_Proyeccion_Informe"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de proyeccion de compras"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Redondeo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Ayuda.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Estadisticas_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Actualizar_Rotacion_Producto_Actual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Ver_documento_origen As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Input_Redondeo As DevComponents.Editors.IntegerInput
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Panel_Ayuda As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents Btn_Informe_Proximas_Recepciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Infor_Rotacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Super_Grilla As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents Btn_Colapsar_Filas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_VerdeClaro As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Blanco As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Amarillo As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_VerdeOscuro As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Rosado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_SugCambioPrecio As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Chk_MostrarSugCambioPrecio As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Proyeccion_Rotacion_Diaria As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Proyeccion_Promedio_Diario As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Proyeccion_Promedio_Ult3Meses As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Proyeccion_Promedio_Ult3MesesMasUltMes As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
