<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AsisCompra_Proyeccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_AsisCompra_Proyeccion))
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Input_Dias_a_Abastecer = New DevComponents.Editors.IntegerInput()
        Me.Input_Tiempo_Reposicion = New DevComponents.Editors.IntegerInput()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel7 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Rdb_Ud2_Compra = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Ud1_Compra = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.BtnProcesarInf = New DevComponents.DotNetBar.ButtonItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Arbol_Asociaciones = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_VerMaestroProductos = New DevComponents.DotNetBar.ButtonItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupPanel5 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Cmb_Tiempo_Reposicion_Dias_Meses = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Cmb_Metodo_Abastecer_Dias_Meses = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Input_Porc_Crecimiento = New DevComponents.Editors.IntegerInput()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Chk_Mostrar_Solo_Stock_Critico = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_Domingo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Padre_Asociacion_Productos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_Sabado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Cmb_Padre_Asociacion_Productos = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Cmb_Proyeccion = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Input_Cant_Campos = New DevComponents.Editors.IntegerInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Rdb_Proyeccion_Rotacion_Efectiva = New System.Windows.Forms.RadioButton()
        Me.Input_Proyeccion_Redondeo = New DevComponents.Editors.IntegerInput()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Chk_MostrarSugCambioPrecio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Rot_Mediana = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Rot_Promedio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Input_Dias_a_Abastecer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Tiempo_Reposicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel7.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel5.SuspendLayout()
        CType(Me.Input_Porc_Crecimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Input_Cant_Campos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.Input_Proyeccion_Redondeo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelX6
        '
        Me.LabelX6.AutoSize = True
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(6, 15)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(99, 17)
        Me.LabelX6.TabIndex = 105
        Me.LabelX6.Text = "Metodo a abastecer"
        '
        'Input_Dias_a_Abastecer
        '
        Me.Input_Dias_a_Abastecer.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Dias_a_Abastecer.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Dias_a_Abastecer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Dias_a_Abastecer.ButtonClear.Visible = True
        Me.Input_Dias_a_Abastecer.FocusHighlightEnabled = True
        Me.Input_Dias_a_Abastecer.ForeColor = System.Drawing.Color.Black
        Me.Input_Dias_a_Abastecer.Location = New System.Drawing.Point(124, 37)
        Me.Input_Dias_a_Abastecer.MaxValue = 2000
        Me.Input_Dias_a_Abastecer.MinValue = 1
        Me.Input_Dias_a_Abastecer.Name = "Input_Dias_a_Abastecer"
        Me.Input_Dias_a_Abastecer.ShowUpDown = True
        Me.Input_Dias_a_Abastecer.Size = New System.Drawing.Size(61, 22)
        Me.Input_Dias_a_Abastecer.TabIndex = 108
        Me.Input_Dias_a_Abastecer.Value = 100
        '
        'Input_Tiempo_Reposicion
        '
        Me.Input_Tiempo_Reposicion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Tiempo_Reposicion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Tiempo_Reposicion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Tiempo_Reposicion.ButtonClear.Visible = True
        Me.Input_Tiempo_Reposicion.FocusHighlightEnabled = True
        Me.Input_Tiempo_Reposicion.ForeColor = System.Drawing.Color.Black
        Me.Input_Tiempo_Reposicion.Location = New System.Drawing.Point(300, 37)
        Me.Input_Tiempo_Reposicion.MaxValue = 365
        Me.Input_Tiempo_Reposicion.MinValue = 0
        Me.Input_Tiempo_Reposicion.Name = "Input_Tiempo_Reposicion"
        Me.Input_Tiempo_Reposicion.ShowUpDown = True
        Me.Input_Tiempo_Reposicion.Size = New System.Drawing.Size(61, 22)
        Me.Input_Tiempo_Reposicion.TabIndex = 107
        Me.Input_Tiempo_Reposicion.Value = 7
        '
        'LabelX7
        '
        Me.LabelX7.AutoSize = True
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(201, 14)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(95, 17)
        Me.LabelX7.TabIndex = 106
        Me.LabelX7.Text = "Tiempo Reposición"
        '
        'GroupPanel7
        '
        Me.GroupPanel7.BackColor = System.Drawing.Color.White
        Me.GroupPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel7.Controls.Add(Me.Rdb_Ud2_Compra)
        Me.GroupPanel7.Controls.Add(Me.Rdb_Ud1_Compra)
        Me.GroupPanel7.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel7.Location = New System.Drawing.Point(252, 12)
        Me.GroupPanel7.Name = "GroupPanel7"
        Me.GroupPanel7.Size = New System.Drawing.Size(133, 102)
        '
        '
        '
        Me.GroupPanel7.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel7.Style.BackColorGradientAngle = 90
        Me.GroupPanel7.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel7.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel7.Style.BorderBottomWidth = 1
        Me.GroupPanel7.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel7.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel7.Style.BorderLeftWidth = 1
        Me.GroupPanel7.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel7.Style.BorderRightWidth = 1
        Me.GroupPanel7.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel7.Style.BorderTopWidth = 1
        Me.GroupPanel7.Style.CornerDiameter = 4
        Me.GroupPanel7.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel7.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel7.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel7.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel7.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel7.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel7.TabIndex = 117
        Me.GroupPanel7.Text = "Unidades de compra"
        '
        'Rdb_Ud2_Compra
        '
        Me.Rdb_Ud2_Compra.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Ud2_Compra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Ud2_Compra.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Ud2_Compra.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Ud2_Compra.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ud2_Compra.Checked = True
        Me.Rdb_Ud2_Compra.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Ud2_Compra.CheckValue = "Y"
        Me.Rdb_Ud2_Compra.FocusCuesEnabled = False
        Me.Rdb_Ud2_Compra.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Ud2_Compra.Location = New System.Drawing.Point(2, 36)
        Me.Rdb_Ud2_Compra.Name = "Rdb_Ud2_Compra"
        Me.Rdb_Ud2_Compra.Size = New System.Drawing.Size(122, 23)
        Me.Rdb_Ud2_Compra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Ud2_Compra.TabIndex = 132
        Me.Rdb_Ud2_Compra.Text = "2 [Segunda Unidad]"
        '
        'Rdb_Ud1_Compra
        '
        Me.Rdb_Ud1_Compra.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Ud1_Compra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Ud1_Compra.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Ud1_Compra.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Ud1_Compra.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ud1_Compra.Checked = True
        Me.Rdb_Ud1_Compra.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Ud1_Compra.CheckValue = "Y"
        Me.Rdb_Ud1_Compra.FocusCuesEnabled = False
        Me.Rdb_Ud1_Compra.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Ud1_Compra.Location = New System.Drawing.Point(2, 16)
        Me.Rdb_Ud1_Compra.Name = "Rdb_Ud1_Compra"
        Me.Rdb_Ud1_Compra.Size = New System.Drawing.Size(122, 23)
        Me.Rdb_Ud1_Compra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Ud1_Compra.TabIndex = 131
        Me.Rdb_Ud1_Compra.Text = "1 [Primera Unidad]"
        '
        'BtnProcesarInf
        '
        Me.BtnProcesarInf.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnProcesarInf.ForeColor = System.Drawing.Color.Black
        Me.BtnProcesarInf.Image = CType(resources.GetObject("BtnProcesarInf.Image"), System.Drawing.Image)
        Me.BtnProcesarInf.ImageAlt = CType(resources.GetObject("BtnProcesarInf.ImageAlt"), System.Drawing.Image)
        Me.BtnProcesarInf.Name = "BtnProcesarInf"
        Me.BtnProcesarInf.Text = "Procesar"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnProcesarInf, Me.Btn_Arbol_Asociaciones, Me.Btn_VerMaestroProductos})
        Me.Bar1.Location = New System.Drawing.Point(0, 402)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(399, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 110
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Arbol_Asociaciones
        '
        Me.Btn_Arbol_Asociaciones.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Arbol_Asociaciones.ForeColor = System.Drawing.Color.Black
        Me.Btn_Arbol_Asociaciones.Image = CType(resources.GetObject("Btn_Arbol_Asociaciones.Image"), System.Drawing.Image)
        Me.Btn_Arbol_Asociaciones.ImageAlt = CType(resources.GetObject("Btn_Arbol_Asociaciones.ImageAlt"), System.Drawing.Image)
        Me.Btn_Arbol_Asociaciones.Name = "Btn_Arbol_Asociaciones"
        Me.Btn_Arbol_Asociaciones.Tooltip = "Mantención de arbol de asociaciones"
        '
        'Btn_VerMaestroProductos
        '
        Me.Btn_VerMaestroProductos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_VerMaestroProductos.ForeColor = System.Drawing.Color.Black
        Me.Btn_VerMaestroProductos.Image = CType(resources.GetObject("Btn_VerMaestroProductos.Image"), System.Drawing.Image)
        Me.Btn_VerMaestroProductos.ImageAlt = CType(resources.GetObject("Btn_VerMaestroProductos.ImageAlt"), System.Drawing.Image)
        Me.Btn_VerMaestroProductos.Name = "Btn_VerMaestroProductos"
        Me.Btn_VerMaestroProductos.Tooltip = "Ver Maestro de productos"
        '
        'GroupPanel5
        '
        Me.GroupPanel5.BackColor = System.Drawing.Color.White
        Me.GroupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel5.Controls.Add(Me.Cmb_Tiempo_Reposicion_Dias_Meses)
        Me.GroupPanel5.Controls.Add(Me.Cmb_Metodo_Abastecer_Dias_Meses)
        Me.GroupPanel5.Controls.Add(Me.Input_Porc_Crecimiento)
        Me.GroupPanel5.Controls.Add(Me.Label5)
        Me.GroupPanel5.Controls.Add(Me.LabelX6)
        Me.GroupPanel5.Controls.Add(Me.Input_Dias_a_Abastecer)
        Me.GroupPanel5.Controls.Add(Me.Input_Tiempo_Reposicion)
        Me.GroupPanel5.Controls.Add(Me.LabelX7)
        Me.GroupPanel5.Controls.Add(Me.Chk_Mostrar_Solo_Stock_Critico)
        Me.GroupPanel5.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel5.Location = New System.Drawing.Point(12, 122)
        Me.GroupPanel5.Name = "GroupPanel5"
        Me.GroupPanel5.Size = New System.Drawing.Size(373, 125)
        '
        '
        '
        Me.GroupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel5.Style.BackColorGradientAngle = 90
        Me.GroupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderBottomWidth = 1
        Me.GroupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderLeftWidth = 1
        Me.GroupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderRightWidth = 1
        Me.GroupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderTopWidth = 1
        Me.GroupPanel5.Style.CornerDiameter = 4
        Me.GroupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel5.TabIndex = 118
        Me.GroupPanel5.Text = "Tiempos para el calculo de la proyección"
        '
        'Cmb_Tiempo_Reposicion_Dias_Meses
        '
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.DisplayMember = "Text"
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.FormattingEnabled = True
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.ItemHeight = 16
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.Location = New System.Drawing.Point(201, 37)
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.Name = "Cmb_Tiempo_Reposicion_Dias_Meses"
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.Size = New System.Drawing.Size(93, 22)
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Tiempo_Reposicion_Dias_Meses.TabIndex = 122
        '
        'Cmb_Metodo_Abastecer_Dias_Meses
        '
        Me.Cmb_Metodo_Abastecer_Dias_Meses.DisplayMember = "Text"
        Me.Cmb_Metodo_Abastecer_Dias_Meses.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Metodo_Abastecer_Dias_Meses.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Metodo_Abastecer_Dias_Meses.FormattingEnabled = True
        Me.Cmb_Metodo_Abastecer_Dias_Meses.ItemHeight = 16
        Me.Cmb_Metodo_Abastecer_Dias_Meses.Location = New System.Drawing.Point(6, 37)
        Me.Cmb_Metodo_Abastecer_Dias_Meses.Name = "Cmb_Metodo_Abastecer_Dias_Meses"
        Me.Cmb_Metodo_Abastecer_Dias_Meses.Size = New System.Drawing.Size(112, 22)
        Me.Cmb_Metodo_Abastecer_Dias_Meses.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Metodo_Abastecer_Dias_Meses.TabIndex = 121
        '
        'Input_Porc_Crecimiento
        '
        Me.Input_Porc_Crecimiento.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Porc_Crecimiento.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Porc_Crecimiento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Porc_Crecimiento.ButtonClear.Visible = True
        Me.Input_Porc_Crecimiento.FocusHighlightEnabled = True
        Me.Input_Porc_Crecimiento.ForeColor = System.Drawing.Color.Black
        Me.Input_Porc_Crecimiento.Location = New System.Drawing.Point(124, 71)
        Me.Input_Porc_Crecimiento.MaxValue = 100
        Me.Input_Porc_Crecimiento.MinValue = 0
        Me.Input_Porc_Crecimiento.Name = "Input_Porc_Crecimiento"
        Me.Input_Porc_Crecimiento.ShowUpDown = True
        Me.Input_Porc_Crecimiento.Size = New System.Drawing.Size(61, 22)
        Me.Input_Porc_Crecimiento.TabIndex = 110
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(3, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "% de Crecimiento"
        '
        'Chk_Mostrar_Solo_Stock_Critico
        '
        Me.Chk_Mostrar_Solo_Stock_Critico.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Mostrar_Solo_Stock_Critico.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Mostrar_Solo_Stock_Critico.CheckBoxImageChecked = CType(resources.GetObject("Chk_Mostrar_Solo_Stock_Critico.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Mostrar_Solo_Stock_Critico.Checked = True
        Me.Chk_Mostrar_Solo_Stock_Critico.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Mostrar_Solo_Stock_Critico.CheckValue = "Y"
        Me.Chk_Mostrar_Solo_Stock_Critico.Enabled = False
        Me.Chk_Mostrar_Solo_Stock_Critico.FocusCuesEnabled = False
        Me.Chk_Mostrar_Solo_Stock_Critico.ForeColor = System.Drawing.Color.Black
        Me.Chk_Mostrar_Solo_Stock_Critico.Location = New System.Drawing.Point(201, 76)
        Me.Chk_Mostrar_Solo_Stock_Critico.Name = "Chk_Mostrar_Solo_Stock_Critico"
        Me.Chk_Mostrar_Solo_Stock_Critico.Size = New System.Drawing.Size(147, 16)
        Me.Chk_Mostrar_Solo_Stock_Critico.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Mostrar_Solo_Stock_Critico.TabIndex = 17
        Me.Chk_Mostrar_Solo_Stock_Critico.Text = "Mostrar solo Stock critico"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Chk_Domingo)
        Me.GroupPanel1.Controls.Add(Me.Txt_Padre_Asociacion_Productos)
        Me.GroupPanel1.Controls.Add(Me.Chk_Sabado)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(234, 104)
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
        Me.GroupPanel1.TabIndex = 119
        Me.GroupPanel1.Text = "Padre asociador de productos"
        '
        'Chk_Domingo
        '
        Me.Chk_Domingo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Domingo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Domingo.CheckBoxImageChecked = CType(resources.GetObject("Chk_Domingo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Domingo.FocusCuesEnabled = False
        Me.Chk_Domingo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Domingo.Location = New System.Drawing.Point(6, 57)
        Me.Chk_Domingo.Name = "Chk_Domingo"
        Me.Chk_Domingo.Size = New System.Drawing.Size(147, 17)
        Me.Chk_Domingo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Domingo.TabIndex = 24
        Me.Chk_Domingo.Text = "Considerar día Domingo"
        '
        'Txt_Padre_Asociacion_Productos
        '
        Me.Txt_Padre_Asociacion_Productos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Padre_Asociacion_Productos.Border.Class = "TextBoxBorder"
        Me.Txt_Padre_Asociacion_Productos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Padre_Asociacion_Productos.ButtonCustom.Image = CType(resources.GetObject("Txt_Padre_Asociacion_Productos.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Padre_Asociacion_Productos.ButtonCustom.Visible = True
        Me.Txt_Padre_Asociacion_Productos.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Padre_Asociacion_Productos.ForeColor = System.Drawing.Color.Black
        Me.Txt_Padre_Asociacion_Productos.Location = New System.Drawing.Point(6, 7)
        Me.Txt_Padre_Asociacion_Productos.Name = "Txt_Padre_Asociacion_Productos"
        Me.Txt_Padre_Asociacion_Productos.PreventEnterBeep = True
        Me.Txt_Padre_Asociacion_Productos.ReadOnly = True
        Me.Txt_Padre_Asociacion_Productos.Size = New System.Drawing.Size(213, 22)
        Me.Txt_Padre_Asociacion_Productos.TabIndex = 130
        '
        'Chk_Sabado
        '
        Me.Chk_Sabado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Sabado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Sabado.CheckBoxImageChecked = CType(resources.GetObject("Chk_Sabado.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Sabado.FocusCuesEnabled = False
        Me.Chk_Sabado.ForeColor = System.Drawing.Color.Black
        Me.Chk_Sabado.Location = New System.Drawing.Point(6, 35)
        Me.Chk_Sabado.Name = "Chk_Sabado"
        Me.Chk_Sabado.Size = New System.Drawing.Size(138, 17)
        Me.Chk_Sabado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Sabado.TabIndex = 23
        Me.Chk_Sabado.Text = "Considerar día Sábado"
        '
        'Cmb_Padre_Asociacion_Productos
        '
        Me.Cmb_Padre_Asociacion_Productos.DisplayMember = "Text"
        Me.Cmb_Padre_Asociacion_Productos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Padre_Asociacion_Productos.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Padre_Asociacion_Productos.FormattingEnabled = True
        Me.Cmb_Padre_Asociacion_Productos.ItemHeight = 16
        Me.Cmb_Padre_Asociacion_Productos.Location = New System.Drawing.Point(415, 39)
        Me.Cmb_Padre_Asociacion_Productos.Name = "Cmb_Padre_Asociacion_Productos"
        Me.Cmb_Padre_Asociacion_Productos.Size = New System.Drawing.Size(215, 22)
        Me.Cmb_Padre_Asociacion_Productos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Padre_Asociacion_Productos.TabIndex = 0
        '
        'Cmb_Proyeccion
        '
        Me.Cmb_Proyeccion.DisplayMember = "Text"
        Me.Cmb_Proyeccion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Proyeccion.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Proyeccion.FormattingEnabled = True
        Me.Cmb_Proyeccion.ItemHeight = 16
        Me.Cmb_Proyeccion.Location = New System.Drawing.Point(6, 20)
        Me.Cmb_Proyeccion.Name = "Cmb_Proyeccion"
        Me.Cmb_Proyeccion.Size = New System.Drawing.Size(159, 22)
        Me.Cmb_Proyeccion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Proyeccion.TabIndex = 120
        '
        'Input_Cant_Campos
        '
        Me.Input_Cant_Campos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Cant_Campos.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Cant_Campos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Cant_Campos.ButtonClear.Visible = True
        Me.Input_Cant_Campos.FocusHighlightEnabled = True
        Me.Input_Cant_Campos.ForeColor = System.Drawing.Color.Black
        Me.Input_Cant_Campos.Location = New System.Drawing.Point(300, 20)
        Me.Input_Cant_Campos.MaxValue = 365
        Me.Input_Cant_Campos.MinValue = 0
        Me.Input_Cant_Campos.Name = "Input_Cant_Campos"
        Me.Input_Cant_Campos.ShowUpDown = True
        Me.Input_Cant_Campos.Size = New System.Drawing.Size(61, 22)
        Me.Input_Cant_Campos.TabIndex = 122
        Me.Input_Cant_Campos.Value = 12
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(186, 25)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(104, 17)
        Me.LabelX1.TabIndex = 121
        Me.LabelX1.Text = "Cantidad de Campos"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Cmb_Proyeccion)
        Me.GroupPanel2.Controls.Add(Me.Input_Cant_Campos)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(415, 179)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(373, 86)
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
        Me.GroupPanel2.TabIndex = 123
        Me.GroupPanel2.Text = "Proyección"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Rdb_Rot_Promedio)
        Me.GroupPanel3.Controls.Add(Me.Rdb_Rot_Mediana)
        Me.GroupPanel3.Controls.Add(Me.Rdb_Proyeccion_Rotacion_Efectiva)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 314)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(373, 57)
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
        Me.GroupPanel3.TabIndex = 124
        Me.GroupPanel3.Text = "Velociada de salidad para el calculo de proyección"
        '
        'Rdb_Proyeccion_Rotacion_Efectiva
        '
        Me.Rdb_Proyeccion_Rotacion_Efectiva.AutoSize = True
        Me.Rdb_Proyeccion_Rotacion_Efectiva.BackColor = System.Drawing.Color.Transparent
        Me.Rdb_Proyeccion_Rotacion_Efectiva.Enabled = False
        Me.Rdb_Proyeccion_Rotacion_Efectiva.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Proyeccion_Rotacion_Efectiva.Location = New System.Drawing.Point(3, 44)
        Me.Rdb_Proyeccion_Rotacion_Efectiva.Name = "Rdb_Proyeccion_Rotacion_Efectiva"
        Me.Rdb_Proyeccion_Rotacion_Efectiva.Size = New System.Drawing.Size(216, 17)
        Me.Rdb_Proyeccion_Rotacion_Efectiva.TabIndex = 1
        Me.Rdb_Proyeccion_Rotacion_Efectiva.Text = "Rotación Efectiva (Solo días de venta)"
        Me.Rdb_Proyeccion_Rotacion_Efectiva.UseVisualStyleBackColor = False
        '
        'Input_Proyeccion_Redondeo
        '
        Me.Input_Proyeccion_Redondeo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Proyeccion_Redondeo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Proyeccion_Redondeo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Proyeccion_Redondeo.ButtonClear.Visible = True
        Me.Input_Proyeccion_Redondeo.FocusHighlightEnabled = True
        Me.Input_Proyeccion_Redondeo.ForeColor = System.Drawing.Color.Black
        Me.Input_Proyeccion_Redondeo.Location = New System.Drawing.Point(87, 5)
        Me.Input_Proyeccion_Redondeo.MaxValue = 10000
        Me.Input_Proyeccion_Redondeo.MinValue = 1
        Me.Input_Proyeccion_Redondeo.Name = "Input_Proyeccion_Redondeo"
        Me.Input_Proyeccion_Redondeo.ShowUpDown = True
        Me.Input_Proyeccion_Redondeo.Size = New System.Drawing.Size(61, 22)
        Me.Input_Proyeccion_Redondeo.TabIndex = 127
        Me.Input_Proyeccion_Redondeo.Value = 1
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Label1)
        Me.GroupPanel4.Controls.Add(Me.Input_Proyeccion_Redondeo)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(12, 253)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(373, 55)
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
        Me.GroupPanel4.TabIndex = 129
        Me.GroupPanel4.Text = "Múltiplos de compra"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "Múltiplos de :"
        '
        'Chk_MostrarSugCambioPrecio
        '
        Me.Chk_MostrarSugCambioPrecio.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_MostrarSugCambioPrecio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_MostrarSugCambioPrecio.CheckBoxImageChecked = CType(resources.GetObject("Chk_MostrarSugCambioPrecio.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_MostrarSugCambioPrecio.FocusCuesEnabled = False
        Me.Chk_MostrarSugCambioPrecio.ForeColor = System.Drawing.Color.Black
        Me.Chk_MostrarSugCambioPrecio.Location = New System.Drawing.Point(12, 378)
        Me.Chk_MostrarSugCambioPrecio.Name = "Chk_MostrarSugCambioPrecio"
        Me.Chk_MostrarSugCambioPrecio.Size = New System.Drawing.Size(365, 17)
        Me.Chk_MostrarSugCambioPrecio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_MostrarSugCambioPrecio.TabIndex = 130
        Me.Chk_MostrarSugCambioPrecio.Text = "Mostrar sugerencia de cambio de precio"
        '
        'Rdb_Rot_Mediana
        '
        Me.Rdb_Rot_Mediana.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Rot_Mediana.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Rot_Mediana.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Rot_Mediana.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Rot_Mediana.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Rot_Mediana.Checked = True
        Me.Rdb_Rot_Mediana.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Rot_Mediana.CheckValue = "Y"
        Me.Rdb_Rot_Mediana.FocusCuesEnabled = False
        Me.Rdb_Rot_Mediana.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Rot_Mediana.Location = New System.Drawing.Point(6, 8)
        Me.Rdb_Rot_Mediana.Name = "Rdb_Rot_Mediana"
        Me.Rdb_Rot_Mediana.Size = New System.Drawing.Size(122, 23)
        Me.Rdb_Rot_Mediana.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Rot_Mediana.TabIndex = 133
        Me.Rdb_Rot_Mediana.Text = "Rotación (Mediana)"
        '
        'Rdb_Rot_Promedio
        '
        Me.Rdb_Rot_Promedio.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Rot_Promedio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Rot_Promedio.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Rot_Promedio.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Rot_Promedio.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Rot_Promedio.Checked = True
        Me.Rdb_Rot_Promedio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Rot_Promedio.CheckValue = "Y"
        Me.Rdb_Rot_Promedio.FocusCuesEnabled = False
        Me.Rdb_Rot_Promedio.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Rot_Promedio.Location = New System.Drawing.Point(201, 8)
        Me.Rdb_Rot_Promedio.Name = "Rdb_Rot_Promedio"
        Me.Rdb_Rot_Promedio.Size = New System.Drawing.Size(122, 23)
        Me.Rdb_Rot_Promedio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Rot_Promedio.TabIndex = 134
        Me.Rdb_Rot_Promedio.Text = "Promedio"
        '
        'Frm_AsisCompra_Proyeccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 443)
        Me.Controls.Add(Me.Chk_MostrarSugCambioPrecio)
        Me.Controls.Add(Me.Cmb_Padre_Asociacion_Productos)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupPanel7)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel5)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_AsisCompra_Proyeccion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proyección de compras"
        CType(Me.Input_Dias_a_Abastecer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Tiempo_Reposicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel7.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel5.ResumeLayout(False)
        Me.GroupPanel5.PerformLayout()
        CType(Me.Input_Porc_Crecimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Input_Cant_Campos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel3.PerformLayout()
        CType(Me.Input_Proyeccion_Redondeo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        Me.GroupPanel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel7 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents BtnProcesarInf As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupPanel5 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Chk_Mostrar_Solo_Stock_Critico As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Input_Dias_a_Abastecer As DevComponents.Editors.IntegerInput
    Public WithEvents Input_Tiempo_Reposicion As DevComponents.Editors.IntegerInput
    Public WithEvents Cmb_Padre_Asociacion_Productos As DevComponents.DotNetBar.Controls.ComboBoxEx
    Public WithEvents Input_Porc_Crecimiento As DevComponents.Editors.IntegerInput
    Public WithEvents Chk_Domingo As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Chk_Sabado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Arbol_Asociaciones As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Cmb_Proyeccion As DevComponents.DotNetBar.Controls.ComboBoxEx
    Public WithEvents Input_Cant_Campos As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Cmb_Tiempo_Reposicion_Dias_Meses As DevComponents.DotNetBar.Controls.ComboBoxEx
    Public WithEvents Cmb_Metodo_Abastecer_Dias_Meses As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Rdb_Proyeccion_Rotacion_Efectiva As System.Windows.Forms.RadioButton
    Public WithEvents Input_Proyeccion_Redondeo As DevComponents.Editors.IntegerInput
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_Padre_Asociacion_Productos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_VerMaestroProductos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Chk_MostrarSugCambioPrecio As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Ud2_Compra As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Rot_Mediana As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Ud1_Compra As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_Rot_Promedio As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
