<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Rc_04_Resolucion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Rc_04_Resolucion))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_Visita_Cliente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Stab_Control = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Txt_Resolucion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.St_Resolucion = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel9 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Txt_Detalle_Visita = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.St_Detalle_Visita = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Txt_Medidas_Preventivas = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.St_Medidas_Preventivas = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel7 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Txt_Respuesta_Cliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.St_Respuesta_Cliente = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel6 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Txt_Acciones_Preventivas = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.St_Acciones_Preventivas = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Txt_Acciones_Correctivas = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.St_Acciones_Correctivas = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel5 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Txt_Conclusion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.St_Conclusion = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel8 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Txt_Causa_Raiz = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.St_Causa_Raiz = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Txt_Metod_Utilizar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.St_Metod_Utilizar = New DevComponents.DotNetBar.SuperTabItem()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Aprobar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Rechazar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Reenviar_A_Validacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Motivo_Rechazo = New DevComponents.DotNetBar.ButtonItem()
        Me.Imagenes_32x32 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Stab_Control, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Stab_Control.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.SuperTabControlPanel9.SuspendLayout()
        Me.SuperTabControlPanel4.SuspendLayout()
        Me.SuperTabControlPanel7.SuspendLayout()
        Me.SuperTabControlPanel6.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        Me.SuperTabControlPanel5.SuspendLayout()
        Me.SuperTabControlPanel8.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Chk_Visita_Cliente)
        Me.GroupPanel1.Controls.Add(Me.Stab_Control)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 3)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(760, 389)
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
        Me.GroupPanel1.TabIndex = 12
        Me.GroupPanel1.Text = "Informe"
        '
        'Chk_Visita_Cliente
        '
        Me.Chk_Visita_Cliente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Visita_Cliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Visita_Cliente.Location = New System.Drawing.Point(3, 339)
        Me.Chk_Visita_Cliente.Name = "Chk_Visita_Cliente"
        Me.Chk_Visita_Cliente.Size = New System.Drawing.Size(100, 23)
        Me.Chk_Visita_Cliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Visita_Cliente.TabIndex = 90
        Me.Chk_Visita_Cliente.Text = "Visita cliente"
        '
        'Stab_Control
        '
        Me.Stab_Control.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        '
        '
        '
        Me.Stab_Control.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.Stab_Control.ControlBox.MenuBox.Name = ""
        Me.Stab_Control.ControlBox.Name = ""
        Me.Stab_Control.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Stab_Control.ControlBox.MenuBox, Me.Stab_Control.ControlBox.CloseBox})
        Me.Stab_Control.Controls.Add(Me.SuperTabControlPanel1)
        Me.Stab_Control.Controls.Add(Me.SuperTabControlPanel7)
        Me.Stab_Control.Controls.Add(Me.SuperTabControlPanel6)
        Me.Stab_Control.Controls.Add(Me.SuperTabControlPanel3)
        Me.Stab_Control.Controls.Add(Me.SuperTabControlPanel5)
        Me.Stab_Control.Controls.Add(Me.SuperTabControlPanel8)
        Me.Stab_Control.Controls.Add(Me.SuperTabControlPanel2)
        Me.Stab_Control.Controls.Add(Me.SuperTabControlPanel9)
        Me.Stab_Control.Controls.Add(Me.SuperTabControlPanel4)
        Me.Stab_Control.ForeColor = System.Drawing.Color.Black
        Me.Stab_Control.Location = New System.Drawing.Point(3, 3)
        Me.Stab_Control.Name = "Stab_Control"
        Me.Stab_Control.ReorderTabsEnabled = True
        Me.Stab_Control.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Stab_Control.SelectedTabIndex = 0
        Me.Stab_Control.Size = New System.Drawing.Size(748, 330)
        Me.Stab_Control.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Left
        Me.Stab_Control.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Stab_Control.TabIndex = 89
        Me.Stab_Control.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.St_Resolucion, Me.St_Metod_Utilizar, Me.St_Causa_Raiz, Me.St_Conclusion, Me.St_Acciones_Correctivas, Me.St_Acciones_Preventivas, Me.St_Respuesta_Cliente, Me.St_Medidas_Preventivas, Me.St_Detalle_Visita})
        Me.Stab_Control.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.Txt_Resolucion)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(173, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(575, 330)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.St_Resolucion
        '
        'Txt_Resolucion
        '
        Me.Txt_Resolucion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Resolucion.Border.Class = "TextBoxBorder"
        Me.Txt_Resolucion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Resolucion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Resolucion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Resolucion.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Resolucion.Multiline = True
        Me.Txt_Resolucion.Name = "Txt_Resolucion"
        Me.Txt_Resolucion.PreventEnterBeep = True
        Me.Txt_Resolucion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Resolucion.Size = New System.Drawing.Size(568, 324)
        Me.Txt_Resolucion.TabIndex = 2
        '
        'St_Resolucion
        '
        Me.St_Resolucion.AttachedControl = Me.SuperTabControlPanel1
        Me.St_Resolucion.GlobalItem = False
        Me.St_Resolucion.Name = "St_Resolucion"
        Me.St_Resolucion.Text = "Informe investigación interna"
        '
        'SuperTabControlPanel9
        '
        Me.SuperTabControlPanel9.Controls.Add(Me.Txt_Detalle_Visita)
        Me.SuperTabControlPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel9.Location = New System.Drawing.Point(173, 0)
        Me.SuperTabControlPanel9.Name = "SuperTabControlPanel9"
        Me.SuperTabControlPanel9.Size = New System.Drawing.Size(575, 330)
        Me.SuperTabControlPanel9.TabIndex = 0
        Me.SuperTabControlPanel9.TabItem = Me.St_Detalle_Visita
        '
        'Txt_Detalle_Visita
        '
        Me.Txt_Detalle_Visita.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Detalle_Visita.Border.Class = "TextBoxBorder"
        Me.Txt_Detalle_Visita.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Detalle_Visita.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Detalle_Visita.ForeColor = System.Drawing.Color.Black
        Me.Txt_Detalle_Visita.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Detalle_Visita.Multiline = True
        Me.Txt_Detalle_Visita.Name = "Txt_Detalle_Visita"
        Me.Txt_Detalle_Visita.PreventEnterBeep = True
        Me.Txt_Detalle_Visita.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Detalle_Visita.Size = New System.Drawing.Size(580, 324)
        Me.Txt_Detalle_Visita.TabIndex = 135
        '
        'St_Detalle_Visita
        '
        Me.St_Detalle_Visita.AttachedControl = Me.SuperTabControlPanel9
        Me.St_Detalle_Visita.GlobalItem = False
        Me.St_Detalle_Visita.Name = "St_Detalle_Visita"
        Me.St_Detalle_Visita.Text = "Detalle visita"
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(Me.Txt_Medidas_Preventivas)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(173, 0)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(575, 330)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.TabItem = Me.St_Medidas_Preventivas
        '
        'Txt_Medidas_Preventivas
        '
        Me.Txt_Medidas_Preventivas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Medidas_Preventivas.Border.Class = "TextBoxBorder"
        Me.Txt_Medidas_Preventivas.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Medidas_Preventivas.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Medidas_Preventivas.ForeColor = System.Drawing.Color.Black
        Me.Txt_Medidas_Preventivas.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Medidas_Preventivas.Multiline = True
        Me.Txt_Medidas_Preventivas.Name = "Txt_Medidas_Preventivas"
        Me.Txt_Medidas_Preventivas.PreventEnterBeep = True
        Me.Txt_Medidas_Preventivas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Medidas_Preventivas.Size = New System.Drawing.Size(580, 324)
        Me.Txt_Medidas_Preventivas.TabIndex = 134
        '
        'St_Medidas_Preventivas
        '
        Me.St_Medidas_Preventivas.AttachedControl = Me.SuperTabControlPanel4
        Me.St_Medidas_Preventivas.GlobalItem = False
        Me.St_Medidas_Preventivas.Name = "St_Medidas_Preventivas"
        Me.St_Medidas_Preventivas.Text = "Medidas preventivas"
        '
        'SuperTabControlPanel7
        '
        Me.SuperTabControlPanel7.Controls.Add(Me.Txt_Respuesta_Cliente)
        Me.SuperTabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel7.Location = New System.Drawing.Point(162, 0)
        Me.SuperTabControlPanel7.Name = "SuperTabControlPanel7"
        Me.SuperTabControlPanel7.Size = New System.Drawing.Size(586, 330)
        Me.SuperTabControlPanel7.TabIndex = 0
        Me.SuperTabControlPanel7.TabItem = Me.St_Respuesta_Cliente
        '
        'Txt_Respuesta_Cliente
        '
        Me.Txt_Respuesta_Cliente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Respuesta_Cliente.Border.Class = "TextBoxBorder"
        Me.Txt_Respuesta_Cliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Respuesta_Cliente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Respuesta_Cliente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Respuesta_Cliente.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Respuesta_Cliente.Multiline = True
        Me.Txt_Respuesta_Cliente.Name = "Txt_Respuesta_Cliente"
        Me.Txt_Respuesta_Cliente.PreventEnterBeep = True
        Me.Txt_Respuesta_Cliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Respuesta_Cliente.Size = New System.Drawing.Size(580, 324)
        Me.Txt_Respuesta_Cliente.TabIndex = 133
        '
        'St_Respuesta_Cliente
        '
        Me.St_Respuesta_Cliente.AttachedControl = Me.SuperTabControlPanel7
        Me.St_Respuesta_Cliente.GlobalItem = False
        Me.St_Respuesta_Cliente.Name = "St_Respuesta_Cliente"
        Me.St_Respuesta_Cliente.Text = "Respuesta cliente"
        '
        'SuperTabControlPanel6
        '
        Me.SuperTabControlPanel6.Controls.Add(Me.Txt_Acciones_Preventivas)
        Me.SuperTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel6.Location = New System.Drawing.Point(162, 0)
        Me.SuperTabControlPanel6.Name = "SuperTabControlPanel6"
        Me.SuperTabControlPanel6.Size = New System.Drawing.Size(586, 330)
        Me.SuperTabControlPanel6.TabIndex = 0
        Me.SuperTabControlPanel6.TabItem = Me.St_Acciones_Preventivas
        '
        'Txt_Acciones_Preventivas
        '
        Me.Txt_Acciones_Preventivas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Acciones_Preventivas.Border.Class = "TextBoxBorder"
        Me.Txt_Acciones_Preventivas.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Acciones_Preventivas.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Acciones_Preventivas.ForeColor = System.Drawing.Color.Black
        Me.Txt_Acciones_Preventivas.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Acciones_Preventivas.Multiline = True
        Me.Txt_Acciones_Preventivas.Name = "Txt_Acciones_Preventivas"
        Me.Txt_Acciones_Preventivas.PreventEnterBeep = True
        Me.Txt_Acciones_Preventivas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Acciones_Preventivas.Size = New System.Drawing.Size(580, 324)
        Me.Txt_Acciones_Preventivas.TabIndex = 132
        '
        'St_Acciones_Preventivas
        '
        Me.St_Acciones_Preventivas.AttachedControl = Me.SuperTabControlPanel6
        Me.St_Acciones_Preventivas.GlobalItem = False
        Me.St_Acciones_Preventivas.Name = "St_Acciones_Preventivas"
        Me.St_Acciones_Preventivas.Text = "Acciones preventivas"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.Txt_Acciones_Correctivas)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(162, 0)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(586, 330)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.TabItem = Me.St_Acciones_Correctivas
        '
        'Txt_Acciones_Correctivas
        '
        Me.Txt_Acciones_Correctivas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Acciones_Correctivas.Border.Class = "TextBoxBorder"
        Me.Txt_Acciones_Correctivas.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Acciones_Correctivas.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Acciones_Correctivas.ForeColor = System.Drawing.Color.Black
        Me.Txt_Acciones_Correctivas.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Acciones_Correctivas.Multiline = True
        Me.Txt_Acciones_Correctivas.Name = "Txt_Acciones_Correctivas"
        Me.Txt_Acciones_Correctivas.PreventEnterBeep = True
        Me.Txt_Acciones_Correctivas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Acciones_Correctivas.Size = New System.Drawing.Size(580, 324)
        Me.Txt_Acciones_Correctivas.TabIndex = 131
        '
        'St_Acciones_Correctivas
        '
        Me.St_Acciones_Correctivas.AttachedControl = Me.SuperTabControlPanel3
        Me.St_Acciones_Correctivas.GlobalItem = False
        Me.St_Acciones_Correctivas.Name = "St_Acciones_Correctivas"
        Me.St_Acciones_Correctivas.Text = "Acciones correctivas"
        '
        'SuperTabControlPanel5
        '
        Me.SuperTabControlPanel5.Controls.Add(Me.Txt_Conclusion)
        Me.SuperTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel5.Location = New System.Drawing.Point(162, 0)
        Me.SuperTabControlPanel5.Name = "SuperTabControlPanel5"
        Me.SuperTabControlPanel5.Size = New System.Drawing.Size(586, 330)
        Me.SuperTabControlPanel5.TabIndex = 0
        Me.SuperTabControlPanel5.TabItem = Me.St_Conclusion
        '
        'Txt_Conclusion
        '
        Me.Txt_Conclusion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Conclusion.Border.Class = "TextBoxBorder"
        Me.Txt_Conclusion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Conclusion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Conclusion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Conclusion.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Conclusion.Multiline = True
        Me.Txt_Conclusion.Name = "Txt_Conclusion"
        Me.Txt_Conclusion.PreventEnterBeep = True
        Me.Txt_Conclusion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Conclusion.Size = New System.Drawing.Size(580, 324)
        Me.Txt_Conclusion.TabIndex = 130
        '
        'St_Conclusion
        '
        Me.St_Conclusion.AttachedControl = Me.SuperTabControlPanel5
        Me.St_Conclusion.GlobalItem = False
        Me.St_Conclusion.Name = "St_Conclusion"
        Me.St_Conclusion.Text = "Conclusión"
        '
        'SuperTabControlPanel8
        '
        Me.SuperTabControlPanel8.Controls.Add(Me.Txt_Causa_Raiz)
        Me.SuperTabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel8.Location = New System.Drawing.Point(162, 0)
        Me.SuperTabControlPanel8.Name = "SuperTabControlPanel8"
        Me.SuperTabControlPanel8.Size = New System.Drawing.Size(586, 330)
        Me.SuperTabControlPanel8.TabIndex = 0
        Me.SuperTabControlPanel8.TabItem = Me.St_Causa_Raiz
        '
        'Txt_Causa_Raiz
        '
        Me.Txt_Causa_Raiz.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Causa_Raiz.Border.Class = "TextBoxBorder"
        Me.Txt_Causa_Raiz.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Causa_Raiz.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Causa_Raiz.ForeColor = System.Drawing.Color.Black
        Me.Txt_Causa_Raiz.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Causa_Raiz.Multiline = True
        Me.Txt_Causa_Raiz.Name = "Txt_Causa_Raiz"
        Me.Txt_Causa_Raiz.PreventEnterBeep = True
        Me.Txt_Causa_Raiz.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Causa_Raiz.Size = New System.Drawing.Size(580, 324)
        Me.Txt_Causa_Raiz.TabIndex = 129
        '
        'St_Causa_Raiz
        '
        Me.St_Causa_Raiz.AttachedControl = Me.SuperTabControlPanel8
        Me.St_Causa_Raiz.GlobalItem = False
        Me.St_Causa_Raiz.Name = "St_Causa_Raiz"
        Me.St_Causa_Raiz.Text = "Cauza raíz"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.Txt_Metod_Utilizar)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(162, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(586, 330)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.St_Metod_Utilizar
        '
        'Txt_Metod_Utilizar
        '
        Me.Txt_Metod_Utilizar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Metod_Utilizar.Border.Class = "TextBoxBorder"
        Me.Txt_Metod_Utilizar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Metod_Utilizar.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Metod_Utilizar.ForeColor = System.Drawing.Color.Black
        Me.Txt_Metod_Utilizar.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Metod_Utilizar.Multiline = True
        Me.Txt_Metod_Utilizar.Name = "Txt_Metod_Utilizar"
        Me.Txt_Metod_Utilizar.PreventEnterBeep = True
        Me.Txt_Metod_Utilizar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Metod_Utilizar.Size = New System.Drawing.Size(580, 324)
        Me.Txt_Metod_Utilizar.TabIndex = 3
        '
        'St_Metod_Utilizar
        '
        Me.St_Metod_Utilizar.AttachedControl = Me.SuperTabControlPanel2
        Me.St_Metod_Utilizar.GlobalItem = False
        Me.St_Metod_Utilizar.Name = "St_Metod_Utilizar"
        Me.St_Metod_Utilizar.Text = "Metodología a utilizar"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Aprobar, Me.Btn_Rechazar, Me.Btn_Reenviar_A_Validacion, Me.Btn_Grabar, Me.Btn_Editar, Me.Btn_Cancelar, Me.Btn_Ver_Motivo_Rechazo})
        Me.Bar2.Location = New System.Drawing.Point(0, 409)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(771, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 87
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Aprobar
        '
        Me.Btn_Aprobar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Aprobar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Aprobar.Image = CType(resources.GetObject("Btn_Aprobar.Image"), System.Drawing.Image)
        Me.Btn_Aprobar.Name = "Btn_Aprobar"
        Me.Btn_Aprobar.Text = "Aprobar"
        '
        'Btn_Rechazar
        '
        Me.Btn_Rechazar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Rechazar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Rechazar.Image = CType(resources.GetObject("Btn_Rechazar.Image"), System.Drawing.Image)
        Me.Btn_Rechazar.Name = "Btn_Rechazar"
        Me.Btn_Rechazar.Text = "Rechazar"
        Me.Btn_Rechazar.Tooltip = "Rechazar la resolución."
        '
        'Btn_Reenviar_A_Validacion
        '
        Me.Btn_Reenviar_A_Validacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Reenviar_A_Validacion.FontBold = True
        Me.Btn_Reenviar_A_Validacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Reenviar_A_Validacion.Image = CType(resources.GetObject("Btn_Reenviar_A_Validacion.Image"), System.Drawing.Image)
        Me.Btn_Reenviar_A_Validacion.Name = "Btn_Reenviar_A_Validacion"
        Me.Btn_Reenviar_A_Validacion.Text = "Enviar a validación"
        Me.Btn_Reenviar_A_Validacion.Visible = False
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar [F4]"
        '
        'Btn_Editar
        '
        Me.Btn_Editar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar.FontBold = True
        Me.Btn_Editar.ForeColor = System.Drawing.Color.Red
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Tooltip = "Editar"
        Me.Btn_Editar.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.FontBold = True
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar edición"
        Me.Btn_Cancelar.Visible = False
        '
        'Btn_Ver_Motivo_Rechazo
        '
        Me.Btn_Ver_Motivo_Rechazo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ver_Motivo_Rechazo.FontBold = True
        Me.Btn_Ver_Motivo_Rechazo.ForeColor = System.Drawing.Color.Black
        Me.Btn_Ver_Motivo_Rechazo.Image = CType(resources.GetObject("Btn_Ver_Motivo_Rechazo.Image"), System.Drawing.Image)
        Me.Btn_Ver_Motivo_Rechazo.Name = "Btn_Ver_Motivo_Rechazo"
        Me.Btn_Ver_Motivo_Rechazo.Text = "Ver motivo del rechazo"
        Me.Btn_Ver_Motivo_Rechazo.Visible = False
        '
        'Imagenes_32x32
        '
        Me.Imagenes_32x32.ImageStream = CType(resources.GetObject("Imagenes_32x32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_32x32.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_32x32.Images.SetKeyName(0, "warning.png")
        Me.Imagenes_32x32.Images.SetKeyName(1, "Warning 32.png")
        '
        'Frm_Rc_04_Resolucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 450)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Rc_04_Resolucion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RESOLUCION"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Stab_Control, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Stab_Control.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel9.ResumeLayout(False)
        Me.SuperTabControlPanel4.ResumeLayout(False)
        Me.SuperTabControlPanel7.ResumeLayout(False)
        Me.SuperTabControlPanel6.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        Me.SuperTabControlPanel5.ResumeLayout(False)
        Me.SuperTabControlPanel8.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Aprobar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Rechazar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Ver_Motivo_Rechazo As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Reenviar_A_Validacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Imagenes_32x32 As ImageList
    Friend WithEvents Chk_Visita_Cliente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Stab_Control As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel9 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents St_Detalle_Visita As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel8 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents St_Causa_Raiz As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel7 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents St_Respuesta_Cliente As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel6 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents St_Acciones_Preventivas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents St_Acciones_Correctivas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents St_Medidas_Preventivas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel5 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents St_Conclusion As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents St_Metod_Utilizar As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents St_Resolucion As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Txt_Resolucion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Medidas_Preventivas As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Respuesta_Cliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Acciones_Preventivas As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Acciones_Correctivas As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Conclusion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Causa_Raiz As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Metod_Utilizar As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Detalle_Visita As DevComponents.DotNetBar.Controls.TextBoxX
End Class
