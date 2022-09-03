<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_TrabMaq_Sin_Cerrar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_TrabMaq_Sin_Cerrar))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Imagen_Barra = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Finalizar_Trabajo = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Stx_Etx = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_Fin_Trabajos = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Impirmir_ProdMeson = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Meson = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Agregar_Producto_Maquina = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ingresar_DFA_Manualmente = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ingresar_DFA_Manualmente_Porcentaje = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Enviar_Meson_Siguiente = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Agregar_Observaciones = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Info_Comercial = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Maquina = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Trabajo_Terminado = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Dejar_Pendiente_Avence_Porcentaje = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Continuar_Trabajo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Solo_Quitar_Prod_Maquina = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cambiar_Hora_Ingreso = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Maquinas_Meson = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Lbl_Productos_En_Meson = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Mesones = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Maquinas_Meson, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Imagen_Barra
        '
        Me.Imagen_Barra.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Imagen_Barra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Imagen_Barra.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Imagen_Barra.ForeColor = System.Drawing.Color.Black
        Me.Imagen_Barra.Image = CType(resources.GetObject("Imagen_Barra.Image"), System.Drawing.Image)
        Me.Imagen_Barra.Location = New System.Drawing.Point(626, 332)
        Me.Imagen_Barra.Name = "Imagen_Barra"
        Me.Imagen_Barra.ReflectionEnabled = False
        Me.Imagen_Barra.Size = New System.Drawing.Size(43, 29)
        Me.Imagen_Barra.TabIndex = 123
        Me.Imagen_Barra.Visible = False
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(69, 337)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(238, 23)
        Me.LabelX2.TabIndex = 122
        Me.LabelX2.Text = "Finalizar trabajo, solo productos seleccionados"
        Me.LabelX2.Visible = False
        '
        'Btn_Finalizar_Trabajo
        '
        Me.Btn_Finalizar_Trabajo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Finalizar_Trabajo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Finalizar_Trabajo.Image = CType(resources.GetObject("Btn_Finalizar_Trabajo.Image"), System.Drawing.Image)
        Me.Btn_Finalizar_Trabajo.Location = New System.Drawing.Point(12, 322)
        Me.Btn_Finalizar_Trabajo.Name = "Btn_Finalizar_Trabajo"
        Me.Btn_Finalizar_Trabajo.Size = New System.Drawing.Size(48, 38)
        Me.Btn_Finalizar_Trabajo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Finalizar_Trabajo.TabIndex = 121
        Me.Btn_Finalizar_Trabajo.Tooltip = "Enviar productos seleccionados a la maquina"
        Me.Btn_Finalizar_Trabajo.Visible = False
        '
        'Txt_Stx_Etx
        '
        Me.Txt_Stx_Etx.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Stx_Etx.Border.Class = "TextBoxBorder"
        Me.Txt_Stx_Etx.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Stx_Etx.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Stx_Etx.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Stx_Etx.FocusHighlightEnabled = True
        Me.Txt_Stx_Etx.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Stx_Etx.ForeColor = System.Drawing.Color.Black
        Me.Txt_Stx_Etx.Location = New System.Drawing.Point(510, 334)
        Me.Txt_Stx_Etx.MaxLength = 50
        Me.Txt_Stx_Etx.Name = "Txt_Stx_Etx"
        Me.Txt_Stx_Etx.Size = New System.Drawing.Size(115, 26)
        Me.Txt_Stx_Etx.TabIndex = 120
        Me.Txt_Stx_Etx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_Stx_Etx.Visible = False
        '
        'Lbl_Fin_Trabajos
        '
        Me.Lbl_Fin_Trabajos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Fin_Trabajos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Fin_Trabajos.Font = New System.Drawing.Font("Courier New", 9.75!)
        Me.Lbl_Fin_Trabajos.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Fin_Trabajos.Location = New System.Drawing.Point(345, 337)
        Me.Lbl_Fin_Trabajos.Name = "Lbl_Fin_Trabajos"
        Me.Lbl_Fin_Trabajos.Size = New System.Drawing.Size(159, 23)
        Me.Lbl_Fin_Trabajos.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Fin_Trabajos.TabIndex = 119
        Me.Lbl_Fin_Trabajos.Text = "INICIO / FIN Trabajo"
        Me.Lbl_Fin_Trabajos.Visible = False
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Actualizar, Me.Btn_Impirmir_ProdMeson})
        Me.Bar1.Location = New System.Drawing.Point(0, 366)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1238, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 117
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Actualizar
        '
        Me.Btn_Actualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar.Image = CType(resources.GetObject("Btn_Actualizar.Image"), System.Drawing.Image)
        Me.Btn_Actualizar.Name = "Btn_Actualizar"
        Me.Btn_Actualizar.Tooltip = "Grabar"
        '
        'Btn_Impirmir_ProdMeson
        '
        Me.Btn_Impirmir_ProdMeson.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Impirmir_ProdMeson.ForeColor = System.Drawing.Color.Black
        Me.Btn_Impirmir_ProdMeson.Image = CType(resources.GetObject("Btn_Impirmir_ProdMeson.Image"), System.Drawing.Image)
        Me.Btn_Impirmir_ProdMeson.Name = "Btn_Impirmir_ProdMeson"
        Me.Btn_Impirmir_ProdMeson.Tooltip = "Imprimir productos en el mesón"
        Me.Btn_Impirmir_ProdMeson.Visible = False
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel3.Controls.Add(Me.Grilla_Maquinas_Meson)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 48)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(1212, 268)
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
        Me.GroupPanel3.Text = "TRABAJOS EN LAS MAQUINAS DEL MESON"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Meson, Me.Menu_Contextual_Maquina})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(413, 101)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(380, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 50
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Meson
        '
        Me.Menu_Contextual_Meson.AutoExpandOnClick = True
        Me.Menu_Contextual_Meson.Name = "Menu_Contextual_Meson"
        Me.Menu_Contextual_Meson.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Mnu_Agregar_Producto_Maquina, Me.Btn_Ingresar_DFA_Manualmente, Me.Btn_Ingresar_DFA_Manualmente_Porcentaje, Me.Btn_Enviar_Meson_Siguiente, Me.Btn_Agregar_Observaciones, Me.Btn_Info_Comercial})
        Me.Menu_Contextual_Meson.Text = "Meson"
        '
        'Btn_Mnu_Agregar_Producto_Maquina
        '
        Me.Btn_Mnu_Agregar_Producto_Maquina.Image = CType(resources.GetObject("Btn_Mnu_Agregar_Producto_Maquina.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Agregar_Producto_Maquina.Name = "Btn_Mnu_Agregar_Producto_Maquina"
        Me.Btn_Mnu_Agregar_Producto_Maquina.Text = "Enviar producto a la maquina"
        Me.Btn_Mnu_Agregar_Producto_Maquina.Visible = False
        '
        'Btn_Ingresar_DFA_Manualmente
        '
        Me.Btn_Ingresar_DFA_Manualmente.Image = CType(resources.GetObject("Btn_Ingresar_DFA_Manualmente.Image"), System.Drawing.Image)
        Me.Btn_Ingresar_DFA_Manualmente.Name = "Btn_Ingresar_DFA_Manualmente"
        Me.Btn_Ingresar_DFA_Manualmente.Text = "Ingresar datos de fabricación en forma manual para líneas tickeadas (productos te" &
    "rminados completamente)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Btn_Ingresar_DFA_Manualmente_Porcentaje
        '
        Me.Btn_Ingresar_DFA_Manualmente_Porcentaje.Image = CType(resources.GetObject("Btn_Ingresar_DFA_Manualmente_Porcentaje.Image"), System.Drawing.Image)
        Me.Btn_Ingresar_DFA_Manualmente_Porcentaje.Name = "Btn_Ingresar_DFA_Manualmente_Porcentaje"
        Me.Btn_Ingresar_DFA_Manualmente_Porcentaje.Text = "Ingresar datos de fabricación en forma manual para la líneas tickeadas (solo avan" &
    "ce en %)"
        '
        'Btn_Enviar_Meson_Siguiente
        '
        Me.Btn_Enviar_Meson_Siguiente.Image = CType(resources.GetObject("Btn_Enviar_Meson_Siguiente.Image"), System.Drawing.Image)
        Me.Btn_Enviar_Meson_Siguiente.Name = "Btn_Enviar_Meson_Siguiente"
        Me.Btn_Enviar_Meson_Siguiente.Text = "Enviar producto al mesón siguiente"
        Me.Btn_Enviar_Meson_Siguiente.Visible = False
        '
        'Btn_Agregar_Observaciones
        '
        Me.Btn_Agregar_Observaciones.Image = CType(resources.GetObject("Btn_Agregar_Observaciones.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Observaciones.Name = "Btn_Agregar_Observaciones"
        Me.Btn_Agregar_Observaciones.Text = "Agregar observaciones"
        '
        'Btn_Info_Comercial
        '
        Me.Btn_Info_Comercial.Image = CType(resources.GetObject("Btn_Info_Comercial.Image"), System.Drawing.Image)
        Me.Btn_Info_Comercial.Name = "Btn_Info_Comercial"
        Me.Btn_Info_Comercial.Text = "Informacion comercial"
        '
        'Menu_Contextual_Maquina
        '
        Me.Menu_Contextual_Maquina.AutoExpandOnClick = True
        Me.Menu_Contextual_Maquina.Name = "Menu_Contextual_Maquina"
        Me.Menu_Contextual_Maquina.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Trabajo_Terminado, Me.LabelItem2, Me.Btn_Dejar_Pendiente_Avence_Porcentaje, Me.LabelItem3, Me.Btn_Continuar_Trabajo, Me.Btn_Solo_Quitar_Prod_Maquina, Me.ButtonItem1, Me.Btn_Cambiar_Hora_Ingreso})
        Me.Menu_Contextual_Maquina.Text = "Maquinas"
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
        Me.LabelItem1.Text = "Opcion 1"
        '
        'Btn_Trabajo_Terminado
        '
        Me.Btn_Trabajo_Terminado.Image = CType(resources.GetObject("Btn_Trabajo_Terminado.Image"), System.Drawing.Image)
        Me.Btn_Trabajo_Terminado.Name = "Btn_Trabajo_Terminado"
        Me.Btn_Trabajo_Terminado.Text = "<font size=""+6""><b>TRABAJO TERMINADO</b></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<br/><font size=""+6"">Enviar al s" &
    "iguiente mesón</font>"
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
        Me.LabelItem2.Text = "Opcion 2"
        '
        'Btn_Dejar_Pendiente_Avence_Porcentaje
        '
        Me.Btn_Dejar_Pendiente_Avence_Porcentaje.Image = CType(resources.GetObject("Btn_Dejar_Pendiente_Avence_Porcentaje.Image"), System.Drawing.Image)
        Me.Btn_Dejar_Pendiente_Avence_Porcentaje.Name = "Btn_Dejar_Pendiente_Avence_Porcentaje"
        Me.Btn_Dejar_Pendiente_Avence_Porcentaje.Text = "<font size=""+6""><b>DEJAR PENDIENTE EN MI MESON</b></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<br/><font size=""+6"">A" &
    "vance en %</font>"
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
        Me.LabelItem3.Text = "Opcion 3"
        '
        'Btn_Continuar_Trabajo
        '
        Me.Btn_Continuar_Trabajo.Image = CType(resources.GetObject("Btn_Continuar_Trabajo.Image"), System.Drawing.Image)
        Me.Btn_Continuar_Trabajo.Name = "Btn_Continuar_Trabajo"
        Me.Btn_Continuar_Trabajo.Text = "<font size=""+6""><b>CONTINUAR CON EL TRABAJO</b></font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<br/><font size=""+6"">El p" &
    "roducto sigue en la máquina</font>"
        '
        'Btn_Solo_Quitar_Prod_Maquina
        '
        Me.Btn_Solo_Quitar_Prod_Maquina.Image = CType(resources.GetObject("Btn_Solo_Quitar_Prod_Maquina.Image"), System.Drawing.Image)
        Me.Btn_Solo_Quitar_Prod_Maquina.Name = "Btn_Solo_Quitar_Prod_Maquina"
        Me.Btn_Solo_Quitar_Prod_Maquina.Text = "Quitar producto de la maquina (asignado por error)"
        Me.Btn_Solo_Quitar_Prod_Maquina.Visible = False
        '
        'ButtonItem1
        '
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "Agregar observaciones"
        Me.ButtonItem1.Visible = False
        '
        'Btn_Cambiar_Hora_Ingreso
        '
        Me.Btn_Cambiar_Hora_Ingreso.Image = CType(resources.GetObject("Btn_Cambiar_Hora_Ingreso.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_Hora_Ingreso.Name = "Btn_Cambiar_Hora_Ingreso"
        Me.Btn_Cambiar_Hora_Ingreso.Text = "Cambiar hora de ingreso"
        Me.Btn_Cambiar_Hora_Ingreso.Visible = False
        '
        'Grilla_Maquinas_Meson
        '
        Me.Grilla_Maquinas_Meson.AllowUserToAddRows = False
        Me.Grilla_Maquinas_Meson.AllowUserToDeleteRows = False
        Me.Grilla_Maquinas_Meson.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Maquinas_Meson.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Maquinas_Meson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Maquinas_Meson.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Maquinas_Meson.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Maquinas_Meson.EnableHeadersVisualStyles = False
        Me.Grilla_Maquinas_Meson.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Maquinas_Meson.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Maquinas_Meson.MultiSelect = False
        Me.Grilla_Maquinas_Meson.Name = "Grilla_Maquinas_Meson"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Maquinas_Meson.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Maquinas_Meson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla_Maquinas_Meson.Size = New System.Drawing.Size(1206, 245)
        Me.Grilla_Maquinas_Meson.TabIndex = 1
        '
        'Lbl_Productos_En_Meson
        '
        Me.Lbl_Productos_En_Meson.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Productos_En_Meson.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Productos_En_Meson.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Productos_En_Meson.Location = New System.Drawing.Point(427, 11)
        Me.Lbl_Productos_En_Meson.Name = "Lbl_Productos_En_Meson"
        Me.Lbl_Productos_En_Meson.Size = New System.Drawing.Size(409, 23)
        Me.Lbl_Productos_En_Meson.TabIndex = 127
        Me.Lbl_Productos_En_Meson.Text = "MESON"
        '
        'Cmb_Mesones
        '
        Me.Cmb_Mesones.DisplayMember = "Text"
        Me.Cmb_Mesones.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Mesones.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Mesones.FormattingEnabled = True
        Me.Cmb_Mesones.ItemHeight = 16
        Me.Cmb_Mesones.Location = New System.Drawing.Point(69, 12)
        Me.Cmb_Mesones.Name = "Cmb_Mesones"
        Me.Cmb_Mesones.Size = New System.Drawing.Size(352, 22)
        Me.Cmb_Mesones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Mesones.TabIndex = 126
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(12, 12)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(40, 23)
        Me.LabelX3.TabIndex = 125
        Me.LabelX3.Text = "MESON"
        '
        'Frm_TrabMaq_Sin_Cerrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1238, 407)
        Me.Controls.Add(Me.Lbl_Productos_En_Meson)
        Me.Controls.Add(Me.Cmb_Mesones)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Imagen_Barra)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Btn_Finalizar_Trabajo)
        Me.Controls.Add(Me.Txt_Stx_Etx)
        Me.Controls.Add(Me.Lbl_Fin_Trabajos)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_TrabMaq_Sin_Cerrar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Maquinas_Meson, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Imagen_Barra As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Finalizar_Trabajo As DevComponents.DotNetBar.ButtonX
    Public WithEvents Txt_Stx_Etx As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Fin_Trabajos As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Impirmir_ProdMeson As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Maquinas_Meson As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Meson As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Agregar_Producto_Maquina As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ingresar_DFA_Manualmente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ingresar_DFA_Manualmente_Porcentaje As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Enviar_Meson_Siguiente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Agregar_Observaciones As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Info_Comercial As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Maquina As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Trabajo_Terminado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Dejar_Pendiente_Avence_Porcentaje As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Continuar_Trabajo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Solo_Quitar_Prod_Maquina As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cambiar_Hora_Ingreso As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Productos_En_Meson As DevComponents.DotNetBar.LabelX
    Public WithEvents Cmb_Mesones As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
End Class
