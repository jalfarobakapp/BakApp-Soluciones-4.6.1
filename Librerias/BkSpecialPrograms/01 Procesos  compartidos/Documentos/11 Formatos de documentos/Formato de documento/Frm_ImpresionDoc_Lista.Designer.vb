<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_ImpresionDoc_Lista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ImpresionDoc_Lista))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Menu = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Opciones_Formato = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Configurar_Formato = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Tamano = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Copiar_Formato = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar_Formato = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Opciones_Crear_Funciones = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Crear_Funcion_Documentos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Crear_Funcion_Cheques = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Crear_Funciones_Sol_Prod_Bodega = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Actualizar_Grilla = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Crear_Funciones = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Imprimir_Regleta = New DevComponents.DotNetBar.ButtonItem()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.ComboItem6 = New DevComponents.Editors.ComboItem()
        Me.ComboItem7 = New DevComponents.Editors.ComboItem()
        Me.ComboItem8 = New DevComponents.Editors.ComboItem()
        Me.ComboItem9 = New DevComponents.Editors.ComboItem()
        Me.ComboItem10 = New DevComponents.Editors.ComboItem()
        Me.ComboItem11 = New DevComponents.Editors.ComboItem()
        Me.ComboItem12 = New DevComponents.Editors.ComboItem()
        Me.ComboItem13 = New DevComponents.Editors.ComboItem()
        Me.ComboItem14 = New DevComponents.Editors.ComboItem()
        Me.ComboItem15 = New DevComponents.Editors.ComboItem()
        Me.ComboItem16 = New DevComponents.Editors.ComboItem()
        Me.ComboItem17 = New DevComponents.Editors.ComboItem()
        Me.ComboItem18 = New DevComponents.Editors.ComboItem()
        Me.ComboItem19 = New DevComponents.Editors.ComboItem()
        Me.ComboItem20 = New DevComponents.Editors.ComboItem()
        Me.ComboItem21 = New DevComponents.Editors.ComboItem()
        Me.Txt_Buscar_Formato = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        CType(Me.Menu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Menu
        '
        Me.Menu.AntiAlias = True
        Me.Menu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Menu.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Opciones_Formato, Me.Menu_Contextual_Opciones_Crear_Funciones})
        Me.Menu.Location = New System.Drawing.Point(126, 85)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(249, 25)
        Me.Menu.Stretch = True
        Me.Menu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Menu.TabIndex = 85
        Me.Menu.TabStop = False
        Me.Menu.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Opciones_Formato
        '
        Me.Menu_Contextual_Opciones_Formato.AutoExpandOnClick = True
        Me.Menu_Contextual_Opciones_Formato.Name = "Menu_Contextual_Opciones_Formato"
        Me.Menu_Contextual_Opciones_Formato.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Configurar_Formato, Me.Btn_Tamano, Me.LabelItem2, Me.Btn_Copiar_Formato, Me.Btn_Eliminar_Formato})
        Me.Menu_Contextual_Opciones_Formato.Text = "Opciones"
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
        Me.LabelItem1.Text = "Formato"
        '
        'Btn_Configurar_Formato
        '
        Me.Btn_Configurar_Formato.Image = CType(resources.GetObject("Btn_Configurar_Formato.Image"), System.Drawing.Image)
        Me.Btn_Configurar_Formato.Name = "Btn_Configurar_Formato"
        Me.Btn_Configurar_Formato.Text = "Configurar formato"
        '
        'Btn_Tamano
        '
        Me.Btn_Tamano.Image = CType(resources.GetObject("Btn_Tamano.Image"), System.Drawing.Image)
        Me.Btn_Tamano.Name = "Btn_Tamano"
        Me.Btn_Tamano.Text = "Tamaño de hoja"
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
        Me.LabelItem2.Text = "Otras opciones"
        '
        'Btn_Copiar_Formato
        '
        Me.Btn_Copiar_Formato.Image = CType(resources.GetObject("Btn_Copiar_Formato.Image"), System.Drawing.Image)
        Me.Btn_Copiar_Formato.Name = "Btn_Copiar_Formato"
        Me.Btn_Copiar_Formato.Text = "Copiar formato"
        '
        'Btn_Eliminar_Formato
        '
        Me.Btn_Eliminar_Formato.Image = CType(resources.GetObject("Btn_Eliminar_Formato.Image"), System.Drawing.Image)
        Me.Btn_Eliminar_Formato.Name = "Btn_Eliminar_Formato"
        Me.Btn_Eliminar_Formato.Text = "Eliminar formato"
        '
        'Menu_Contextual_Opciones_Crear_Funciones
        '
        Me.Menu_Contextual_Opciones_Crear_Funciones.AutoExpandOnClick = True
        Me.Menu_Contextual_Opciones_Crear_Funciones.Name = "Menu_Contextual_Opciones_Crear_Funciones"
        Me.Menu_Contextual_Opciones_Crear_Funciones.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.Btn_Crear_Funcion_Documentos, Me.Btn_Crear_Funcion_Cheques, Me.Btn_Crear_Funciones_Sol_Prod_Bodega})
        Me.Menu_Contextual_Opciones_Crear_Funciones.Text = "Crear Funcion"
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
        Me.LabelItem3.Text = "Formato"
        '
        'Btn_Crear_Funcion_Documentos
        '
        Me.Btn_Crear_Funcion_Documentos.Image = CType(resources.GetObject("Btn_Crear_Funcion_Documentos.Image"), System.Drawing.Image)
        Me.Btn_Crear_Funcion_Documentos.Name = "Btn_Crear_Funcion_Documentos"
        Me.Btn_Crear_Funcion_Documentos.Text = "Crear/Modificar funciones para documentos de venta o compra"
        '
        'Btn_Crear_Funcion_Cheques
        '
        Me.Btn_Crear_Funcion_Cheques.Image = CType(resources.GetObject("Btn_Crear_Funcion_Cheques.Image"), System.Drawing.Image)
        Me.Btn_Crear_Funcion_Cheques.Name = "Btn_Crear_Funcion_Cheques"
        Me.Btn_Crear_Funcion_Cheques.Text = "Crear/Modificar funciones para cheques"
        '
        'Btn_Crear_Funciones_Sol_Prod_Bodega
        '
        Me.Btn_Crear_Funciones_Sol_Prod_Bodega.Image = CType(resources.GetObject("Btn_Crear_Funciones_Sol_Prod_Bodega.Image"), System.Drawing.Image)
        Me.Btn_Crear_Funciones_Sol_Prod_Bodega.Name = "Btn_Crear_Funciones_Sol_Prod_Bodega"
        Me.Btn_Crear_Funciones_Sol_Prod_Bodega.Text = "Crear/Modificar funciones para solicitud de productos a bodega"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle8
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(685, 402)
        Me.Grilla.TabIndex = 84
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Actualizar_Grilla, Me.Btn_Crear_Funciones, Me.Btn_Imprimir_Regleta})
        Me.Bar1.Location = New System.Drawing.Point(0, 506)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(714, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 86
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Actualizar_Grilla
        '
        Me.Btn_Actualizar_Grilla.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar_Grilla.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar_Grilla.Image = CType(resources.GetObject("Btn_Actualizar_Grilla.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Grilla.Name = "Btn_Actualizar_Grilla"
        Me.Btn_Actualizar_Grilla.Tooltip = "Actualizar"
        '
        'Btn_Crear_Funciones
        '
        Me.Btn_Crear_Funciones.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_Funciones.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_Funciones.Image = CType(resources.GetObject("Btn_Crear_Funciones.Image"), System.Drawing.Image)
        Me.Btn_Crear_Funciones.Name = "Btn_Crear_Funciones"
        Me.Btn_Crear_Funciones.Tooltip = "Crear funciones"
        '
        'Btn_Imprimir_Regleta
        '
        Me.Btn_Imprimir_Regleta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Imprimir_Regleta.ForeColor = System.Drawing.Color.Black
        Me.Btn_Imprimir_Regleta.Image = CType(resources.GetObject("Btn_Imprimir_Regleta.Image"), System.Drawing.Image)
        Me.Btn_Imprimir_Regleta.Name = "Btn_Imprimir_Regleta"
        Me.Btn_Imprimir_Regleta.Tooltip = "Imprimir regleta"
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "0.5"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "1"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "2"
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "3"
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "4"
        '
        'ComboItem6
        '
        Me.ComboItem6.Text = "5"
        '
        'ComboItem7
        '
        Me.ComboItem7.Text = "6"
        '
        'ComboItem8
        '
        Me.ComboItem8.Text = "7"
        '
        'ComboItem9
        '
        Me.ComboItem9.Text = "8"
        '
        'ComboItem10
        '
        Me.ComboItem10.Text = "9"
        '
        'ComboItem11
        '
        Me.ComboItem11.Text = "10"
        '
        'ComboItem12
        '
        Me.ComboItem12.Text = "11"
        '
        'ComboItem13
        '
        Me.ComboItem13.Text = "12"
        '
        'ComboItem14
        '
        Me.ComboItem14.Text = "13"
        '
        'ComboItem15
        '
        Me.ComboItem15.Text = "14"
        '
        'ComboItem16
        '
        Me.ComboItem16.Text = "15"
        '
        'ComboItem17
        '
        Me.ComboItem17.Text = "16"
        '
        'ComboItem18
        '
        Me.ComboItem18.Text = "17"
        '
        'ComboItem19
        '
        Me.ComboItem19.Text = "18"
        '
        'ComboItem20
        '
        Me.ComboItem20.Text = "19"
        '
        'ComboItem21
        '
        Me.ComboItem21.Text = "20"
        '
        'Txt_Buscar_Formato
        '
        Me.Txt_Buscar_Formato.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Buscar_Formato.Border.Class = "TextBoxBorder"
        Me.Txt_Buscar_Formato.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Buscar_Formato.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Buscar_Formato.FocusHighlightEnabled = True
        Me.Txt_Buscar_Formato.ForeColor = System.Drawing.Color.Black
        Me.Txt_Buscar_Formato.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Buscar_Formato.Name = "Txt_Buscar_Formato"
        Me.Txt_Buscar_Formato.PreventEnterBeep = True
        Me.Txt_Buscar_Formato.Size = New System.Drawing.Size(680, 22)
        Me.Txt_Buscar_Formato.TabIndex = 2
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Menu)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 75)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(691, 425)
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
        Me.GroupPanel1.TabIndex = 86
        Me.GroupPanel1.Text = "Lista de documentos"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Txt_Buscar_Formato)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(691, 52)
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
        Me.GroupPanel2.TabIndex = 89
        Me.GroupPanel2.Text = "Buscar formato"
        '
        'Frm_ImpresionDoc_Lista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 547)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ImpresionDoc_Lista"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantención de formatos de documentos"
        CType(Me.Menu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Menu As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Opciones_Formato As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Copiar_Formato As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar_Formato As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Configurar_Formato As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem8 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem9 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem10 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem11 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem12 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem13 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem14 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem15 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem16 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem17 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem18 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem19 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem20 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem21 As DevComponents.Editors.ComboItem
    Public WithEvents Txt_Buscar_Formato As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Crear_Funciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Actualizar_Grilla As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Tamano As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Menu_Contextual_Opciones_Crear_Funciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Crear_Funcion_Documentos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Crear_Funcion_Cheques As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Imprimir_Regleta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Crear_Funciones_Sol_Prod_Bodega As DevComponents.DotNetBar.ButtonItem
End Class
