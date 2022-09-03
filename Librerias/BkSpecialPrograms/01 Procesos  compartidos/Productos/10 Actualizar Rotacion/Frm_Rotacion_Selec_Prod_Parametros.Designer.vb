<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Rotacion_Selec_Prod_Parametros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Rotacion_Selec_Prod_Parametros))
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Rdb_Rango_Meses = New System.Windows.Forms.RadioButton()
        Me.Rdb_Rango_Fechas = New System.Windows.Forms.RadioButton()
        Me.Input_Ultimos_Meses = New DevComponents.Editors.IntegerInput()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Dtp_Fecha_Estudio_Desde = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_Fecha_Estudio_Hasta = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Grupo_Seleccion = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Dias = New DevComponents.DotNetBar.LabelX()
        Me.Input_Dias_Advertencia_Rotacion = New DevComponents.Editors.IntegerInput()
        Me.Chk_Traer_Productos_Asociados = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Lbl_Desde = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Traer_Prod_Rotacion_Desactualizada = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Dtp_Fecha_Movimientos_Desde = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_Fecha_Movimientos_Hasta = New System.Windows.Forms.DateTimePicker()
        Me.Rdb_Productos_Seleccionados = New System.Windows.Forms.RadioButton()
        Me.Rdb_Productos_Todos = New System.Windows.Forms.RadioButton()
        Me.BtnSeleccionarProductos = New DevComponents.DotNetBar.ButtonX()
        Me.Rdb_Productos_Con_Movimineto_Desde_Hasta = New System.Windows.Forms.RadioButton()
        Me.Lbl_Hasta = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Procesar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnEntidadesExcluidas = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Incluir_Ventas_Entidades_Excluidas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.Input_Ultimos_Meses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Seleccion.SuspendLayout()
        CType(Me.Input_Dias_Advertencia_Rotacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Rdb_Rango_Meses)
        Me.GroupPanel3.Controls.Add(Me.Rdb_Rango_Fechas)
        Me.GroupPanel3.Controls.Add(Me.Input_Ultimos_Meses)
        Me.GroupPanel3.Controls.Add(Me.Label5)
        Me.GroupPanel3.Controls.Add(Me.Dtp_Fecha_Estudio_Desde)
        Me.GroupPanel3.Controls.Add(Me.Dtp_Fecha_Estudio_Hasta)
        Me.GroupPanel3.Controls.Add(Me.Label4)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 212)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(417, 120)
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
        Me.GroupPanel3.TabIndex = 44
        Me.GroupPanel3.Text = "Rango de fechas a estudiar para rotación"
        '
        'Rdb_Rango_Meses
        '
        Me.Rdb_Rango_Meses.AutoSize = True
        Me.Rdb_Rango_Meses.BackColor = System.Drawing.Color.Transparent
        Me.Rdb_Rango_Meses.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Rango_Meses.Location = New System.Drawing.Point(9, 69)
        Me.Rdb_Rango_Meses.Name = "Rdb_Rango_Meses"
        Me.Rdb_Rango_Meses.Size = New System.Drawing.Size(237, 17)
        Me.Rdb_Rango_Meses.TabIndex = 108
        Me.Rdb_Rango_Meses.Text = "Seleccionar ventas en los ultimos meses..."
        Me.Rdb_Rango_Meses.UseVisualStyleBackColor = False
        '
        'Rdb_Rango_Fechas
        '
        Me.Rdb_Rango_Fechas.AutoSize = True
        Me.Rdb_Rango_Fechas.BackColor = System.Drawing.Color.Transparent
        Me.Rdb_Rango_Fechas.Checked = True
        Me.Rdb_Rango_Fechas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Rango_Fechas.Location = New System.Drawing.Point(9, 25)
        Me.Rdb_Rango_Fechas.Name = "Rdb_Rango_Fechas"
        Me.Rdb_Rango_Fechas.Size = New System.Drawing.Size(114, 17)
        Me.Rdb_Rango_Fechas.TabIndex = 107
        Me.Rdb_Rango_Fechas.TabStop = True
        Me.Rdb_Rango_Fechas.Text = " Rango de fechas"
        Me.Rdb_Rango_Fechas.UseVisualStyleBackColor = False
        '
        'Input_Ultimos_Meses
        '
        Me.Input_Ultimos_Meses.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Ultimos_Meses.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Ultimos_Meses.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Ultimos_Meses.ButtonClear.Visible = True
        Me.Input_Ultimos_Meses.FocusHighlightEnabled = True
        Me.Input_Ultimos_Meses.ForeColor = System.Drawing.Color.Black
        Me.Input_Ultimos_Meses.Location = New System.Drawing.Point(316, 64)
        Me.Input_Ultimos_Meses.MaxValue = 24
        Me.Input_Ultimos_Meses.MinValue = 1
        Me.Input_Ultimos_Meses.Name = "Input_Ultimos_Meses"
        Me.Input_Ultimos_Meses.ShowUpDown = True
        Me.Input_Ultimos_Meses.Size = New System.Drawing.Size(67, 22)
        Me.Input_Ultimos_Meses.TabIndex = 106
        Me.Input_Ultimos_Meses.Value = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(168, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Desde"
        '
        'Dtp_Fecha_Estudio_Desde
        '
        Me.Dtp_Fecha_Estudio_Desde.BackColor = System.Drawing.Color.White
        Me.Dtp_Fecha_Estudio_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Estudio_Desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha_Estudio_Desde.Location = New System.Drawing.Point(211, 20)
        Me.Dtp_Fecha_Estudio_Desde.Name = "Dtp_Fecha_Estudio_Desde"
        Me.Dtp_Fecha_Estudio_Desde.Size = New System.Drawing.Size(77, 22)
        Me.Dtp_Fecha_Estudio_Desde.TabIndex = 0
        '
        'Dtp_Fecha_Estudio_Hasta
        '
        Me.Dtp_Fecha_Estudio_Hasta.BackColor = System.Drawing.Color.White
        Me.Dtp_Fecha_Estudio_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Estudio_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha_Estudio_Hasta.Location = New System.Drawing.Point(331, 20)
        Me.Dtp_Fecha_Estudio_Hasta.Name = "Dtp_Fecha_Estudio_Hasta"
        Me.Dtp_Fecha_Estudio_Hasta.Size = New System.Drawing.Size(77, 22)
        Me.Dtp_Fecha_Estudio_Hasta.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(291, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Hasta"
        '
        'Grupo_Seleccion
        '
        Me.Grupo_Seleccion.BackColor = System.Drawing.Color.White
        Me.Grupo_Seleccion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Seleccion.Controls.Add(Me.Lbl_Dias)
        Me.Grupo_Seleccion.Controls.Add(Me.Input_Dias_Advertencia_Rotacion)
        Me.Grupo_Seleccion.Controls.Add(Me.Chk_Traer_Productos_Asociados)
        Me.Grupo_Seleccion.Controls.Add(Me.Lbl_Desde)
        Me.Grupo_Seleccion.Controls.Add(Me.Chk_Traer_Prod_Rotacion_Desactualizada)
        Me.Grupo_Seleccion.Controls.Add(Me.Dtp_Fecha_Movimientos_Desde)
        Me.Grupo_Seleccion.Controls.Add(Me.Dtp_Fecha_Movimientos_Hasta)
        Me.Grupo_Seleccion.Controls.Add(Me.Rdb_Productos_Seleccionados)
        Me.Grupo_Seleccion.Controls.Add(Me.Rdb_Productos_Todos)
        Me.Grupo_Seleccion.Controls.Add(Me.BtnSeleccionarProductos)
        Me.Grupo_Seleccion.Controls.Add(Me.Rdb_Productos_Con_Movimineto_Desde_Hasta)
        Me.Grupo_Seleccion.Controls.Add(Me.Lbl_Hasta)
        Me.Grupo_Seleccion.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Seleccion.Location = New System.Drawing.Point(12, 12)
        Me.Grupo_Seleccion.Name = "Grupo_Seleccion"
        Me.Grupo_Seleccion.Size = New System.Drawing.Size(417, 194)
        '
        '
        '
        Me.Grupo_Seleccion.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Seleccion.Style.BackColorGradientAngle = 90
        Me.Grupo_Seleccion.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Seleccion.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Seleccion.Style.BorderBottomWidth = 1
        Me.Grupo_Seleccion.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Seleccion.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Seleccion.Style.BorderLeftWidth = 1
        Me.Grupo_Seleccion.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Seleccion.Style.BorderRightWidth = 1
        Me.Grupo_Seleccion.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Seleccion.Style.BorderTopWidth = 1
        Me.Grupo_Seleccion.Style.CornerDiameter = 4
        Me.Grupo_Seleccion.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Seleccion.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Seleccion.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Seleccion.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Seleccion.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Seleccion.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Seleccion.TabIndex = 43
        Me.Grupo_Seleccion.Text = "Selección de productos"
        '
        'Lbl_Dias
        '
        Me.Lbl_Dias.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Dias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Dias.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Dias.Location = New System.Drawing.Point(389, 107)
        Me.Lbl_Dias.Name = "Lbl_Dias"
        Me.Lbl_Dias.Size = New System.Drawing.Size(28, 23)
        Me.Lbl_Dias.TabIndex = 113
        Me.Lbl_Dias.Text = "dias"
        '
        'Input_Dias_Advertencia_Rotacion
        '
        Me.Input_Dias_Advertencia_Rotacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Dias_Advertencia_Rotacion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Dias_Advertencia_Rotacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Dias_Advertencia_Rotacion.ButtonClear.Visible = True
        Me.Input_Dias_Advertencia_Rotacion.FocusHighlightEnabled = True
        Me.Input_Dias_Advertencia_Rotacion.ForeColor = System.Drawing.Color.Black
        Me.Input_Dias_Advertencia_Rotacion.Location = New System.Drawing.Point(316, 106)
        Me.Input_Dias_Advertencia_Rotacion.MaxValue = 365
        Me.Input_Dias_Advertencia_Rotacion.MinValue = 1
        Me.Input_Dias_Advertencia_Rotacion.Name = "Input_Dias_Advertencia_Rotacion"
        Me.Input_Dias_Advertencia_Rotacion.ShowUpDown = True
        Me.Input_Dias_Advertencia_Rotacion.Size = New System.Drawing.Size(67, 22)
        Me.Input_Dias_Advertencia_Rotacion.TabIndex = 105
        Me.Input_Dias_Advertencia_Rotacion.Value = 7
        '
        'Chk_Traer_Productos_Asociados
        '
        Me.Chk_Traer_Productos_Asociados.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.Chk_Traer_Productos_Asociados.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Traer_Productos_Asociados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Traer_Productos_Asociados.Checked = True
        Me.Chk_Traer_Productos_Asociados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Traer_Productos_Asociados.CheckValue = "Y"
        Me.Chk_Traer_Productos_Asociados.ForeColor = System.Drawing.Color.Black
        Me.Chk_Traer_Productos_Asociados.Location = New System.Drawing.Point(9, 136)
        Me.Chk_Traer_Productos_Asociados.Name = "Chk_Traer_Productos_Asociados"
        Me.Chk_Traer_Productos_Asociados.Size = New System.Drawing.Size(279, 23)
        Me.Chk_Traer_Productos_Asociados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Traer_Productos_Asociados.TabIndex = 23
        Me.Chk_Traer_Productos_Asociados.Text = "Traer productos asociados (productos hermanos)"
        '
        'Lbl_Desde
        '
        Me.Lbl_Desde.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Desde.Location = New System.Drawing.Point(171, 47)
        Me.Lbl_Desde.Name = "Lbl_Desde"
        Me.Lbl_Desde.Size = New System.Drawing.Size(34, 23)
        Me.Lbl_Desde.TabIndex = 17
        Me.Lbl_Desde.Text = "Desde"
        '
        'Chk_Traer_Prod_Rotacion_Desactualizada
        '
        Me.Chk_Traer_Prod_Rotacion_Desactualizada.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Traer_Prod_Rotacion_Desactualizada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Traer_Prod_Rotacion_Desactualizada.ForeColor = System.Drawing.Color.Black
        Me.Chk_Traer_Prod_Rotacion_Desactualizada.Location = New System.Drawing.Point(8, 107)
        Me.Chk_Traer_Prod_Rotacion_Desactualizada.Name = "Chk_Traer_Prod_Rotacion_Desactualizada"
        Me.Chk_Traer_Prod_Rotacion_Desactualizada.Size = New System.Drawing.Size(302, 23)
        Me.Chk_Traer_Prod_Rotacion_Desactualizada.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Traer_Prod_Rotacion_Desactualizada.TabIndex = 22
        Me.Chk_Traer_Prod_Rotacion_Desactualizada.Text = "Traer solo productos con estudio de rotación de menos de"
        '
        'Dtp_Fecha_Movimientos_Desde
        '
        Me.Dtp_Fecha_Movimientos_Desde.BackColor = System.Drawing.Color.White
        Me.Dtp_Fecha_Movimientos_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Movimientos_Desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha_Movimientos_Desde.Location = New System.Drawing.Point(211, 47)
        Me.Dtp_Fecha_Movimientos_Desde.Name = "Dtp_Fecha_Movimientos_Desde"
        Me.Dtp_Fecha_Movimientos_Desde.Size = New System.Drawing.Size(77, 22)
        Me.Dtp_Fecha_Movimientos_Desde.TabIndex = 8
        '
        'Dtp_Fecha_Movimientos_Hasta
        '
        Me.Dtp_Fecha_Movimientos_Hasta.BackColor = System.Drawing.Color.White
        Me.Dtp_Fecha_Movimientos_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Movimientos_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_Fecha_Movimientos_Hasta.Location = New System.Drawing.Point(331, 47)
        Me.Dtp_Fecha_Movimientos_Hasta.Name = "Dtp_Fecha_Movimientos_Hasta"
        Me.Dtp_Fecha_Movimientos_Hasta.Size = New System.Drawing.Size(77, 22)
        Me.Dtp_Fecha_Movimientos_Hasta.TabIndex = 15
        '
        'Rdb_Productos_Seleccionados
        '
        Me.Rdb_Productos_Seleccionados.AutoSize = True
        Me.Rdb_Productos_Seleccionados.BackColor = System.Drawing.Color.Transparent
        Me.Rdb_Productos_Seleccionados.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Seleccionados.Location = New System.Drawing.Point(8, 26)
        Me.Rdb_Productos_Seleccionados.Name = "Rdb_Productos_Seleccionados"
        Me.Rdb_Productos_Seleccionados.Size = New System.Drawing.Size(139, 17)
        Me.Rdb_Productos_Seleccionados.TabIndex = 14
        Me.Rdb_Productos_Seleccionados.Text = "Seleccionar productos"
        Me.Rdb_Productos_Seleccionados.UseVisualStyleBackColor = False
        '
        'Rdb_Productos_Todos
        '
        Me.Rdb_Productos_Todos.AutoSize = True
        Me.Rdb_Productos_Todos.BackColor = System.Drawing.Color.Transparent
        Me.Rdb_Productos_Todos.Checked = True
        Me.Rdb_Productos_Todos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Todos.Location = New System.Drawing.Point(8, 3)
        Me.Rdb_Productos_Todos.Name = "Rdb_Productos_Todos"
        Me.Rdb_Productos_Todos.Size = New System.Drawing.Size(55, 17)
        Me.Rdb_Productos_Todos.TabIndex = 0
        Me.Rdb_Productos_Todos.TabStop = True
        Me.Rdb_Productos_Todos.Text = "Todos"
        Me.Rdb_Productos_Todos.UseVisualStyleBackColor = False
        '
        'BtnSeleccionarProductos
        '
        Me.BtnSeleccionarProductos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnSeleccionarProductos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnSeleccionarProductos.Image = CType(resources.GetObject("BtnSeleccionarProductos.Image"), System.Drawing.Image)
        Me.BtnSeleccionarProductos.Location = New System.Drawing.Point(211, 21)
        Me.BtnSeleccionarProductos.Name = "BtnSeleccionarProductos"
        Me.BtnSeleccionarProductos.Size = New System.Drawing.Size(77, 22)
        Me.BtnSeleccionarProductos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnSeleccionarProductos.TabIndex = 13
        Me.BtnSeleccionarProductos.Tooltip = "Buscar productos"
        '
        'Rdb_Productos_Con_Movimineto_Desde_Hasta
        '
        Me.Rdb_Productos_Con_Movimineto_Desde_Hasta.AutoSize = True
        Me.Rdb_Productos_Con_Movimineto_Desde_Hasta.BackColor = System.Drawing.Color.Transparent
        Me.Rdb_Productos_Con_Movimineto_Desde_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Productos_Con_Movimineto_Desde_Hasta.Location = New System.Drawing.Point(9, 49)
        Me.Rdb_Productos_Con_Movimineto_Desde_Hasta.Name = "Rdb_Productos_Con_Movimineto_Desde_Hasta"
        Me.Rdb_Productos_Con_Movimineto_Desde_Hasta.Size = New System.Drawing.Size(156, 17)
        Me.Rdb_Productos_Con_Movimineto_Desde_Hasta.TabIndex = 1
        Me.Rdb_Productos_Con_Movimineto_Desde_Hasta.Text = "Con movimientos (ventas)"
        Me.Rdb_Productos_Con_Movimineto_Desde_Hasta.UseVisualStyleBackColor = False
        '
        'Lbl_Hasta
        '
        Me.Lbl_Hasta.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Hasta.Location = New System.Drawing.Point(294, 46)
        Me.Lbl_Hasta.Name = "Lbl_Hasta"
        Me.Lbl_Hasta.Size = New System.Drawing.Size(31, 23)
        Me.Lbl_Hasta.TabIndex = 16
        Me.Lbl_Hasta.Text = "Hasta"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Procesar, Me.BtnEntidadesExcluidas})
        Me.Bar1.Location = New System.Drawing.Point(0, 371)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(442, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 47
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Procesar
        '
        Me.Btn_Procesar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Procesar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Procesar.Image = CType(resources.GetObject("Btn_Procesar.Image"), System.Drawing.Image)
        Me.Btn_Procesar.Name = "Btn_Procesar"
        Me.Btn_Procesar.Text = "Procesar Informe"
        '
        'BtnEntidadesExcluidas
        '
        Me.BtnEntidadesExcluidas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnEntidadesExcluidas.ForeColor = System.Drawing.Color.Black
        Me.BtnEntidadesExcluidas.Image = CType(resources.GetObject("BtnEntidadesExcluidas.Image"), System.Drawing.Image)
        Me.BtnEntidadesExcluidas.Name = "BtnEntidadesExcluidas"
        Me.BtnEntidadesExcluidas.Text = "Entidades excluidas"
        '
        'Chk_Incluir_Ventas_Entidades_Excluidas
        '
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.ForeColor = System.Drawing.Color.Black
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.Location = New System.Drawing.Point(11, 338)
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.Name = "Chk_Incluir_Ventas_Entidades_Excluidas"
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.Size = New System.Drawing.Size(412, 23)
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.TabIndex = 48
        Me.Chk_Incluir_Ventas_Entidades_Excluidas.Text = "Incluir ventas de Entidades Excluidas"
        '
        'Frm_Rotacion_Selec_Prod_Parametros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 412)
        Me.Controls.Add(Me.Chk_Incluir_Ventas_Entidades_Excluidas)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Grupo_Seleccion)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Rotacion_Selec_Prod_Parametros"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cargar velocidad de salida de venta promedio por productos"
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel3.PerformLayout()
        CType(Me.Input_Ultimos_Meses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Seleccion.ResumeLayout(False)
        Me.Grupo_Seleccion.PerformLayout()
        CType(Me.Input_Dias_Advertencia_Rotacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Dtp_Fecha_Estudio_Desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtp_Fecha_Estudio_Hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Grupo_Seleccion As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_Productos_Seleccionados As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb_Productos_Todos As System.Windows.Forms.RadioButton
    Friend WithEvents BtnSeleccionarProductos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Dtp_Fecha_Movimientos_Desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Dtp_Fecha_Movimientos_Hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Rdb_Productos_Con_Movimineto_Desde_Hasta As System.Windows.Forms.RadioButton
    Friend WithEvents Lbl_Hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Procesar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Traer_Productos_Asociados As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents BtnEntidadesExcluidas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Traer_Prod_Rotacion_Desactualizada As DevComponents.DotNetBar.Controls.CheckBoxX
    Private WithEvents Input_Dias_Advertencia_Rotacion As DevComponents.Editors.IntegerInput
    Friend WithEvents Lbl_Dias As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Incluir_Ventas_Entidades_Excluidas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Rango_Meses As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb_Rango_Fechas As System.Windows.Forms.RadioButton
    Private WithEvents Input_Ultimos_Meses As DevComponents.Editors.IntegerInput
End Class
