<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Inf_Vencimientos_Mes_Detalle_Diario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inf_Vencimientos_Mes_Detalle_Diario))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Actualizar_Informacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Quitar_Celdas_En_Cero = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cambiar_Fechas_Vencimiento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Buscar_Entidad = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Mnu_1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Ficha_Entidad = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Mostrar_deuda_actual = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Mostrar_deuda_completa = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Enviar_Correo_Cobranza = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa = New DevComponents.DotNetBar.ButtonItem()
        Me.Radio1 = New DevComponents.DotNetBar.Command(Me.components)
        Me.Radio2 = New DevComponents.DotNetBar.Command(Me.components)
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Actualizar_Informacion, Me.Btn_Quitar_Celdas_En_Cero, Me.Btn_Cambiar_Fechas_Vencimiento, Me.Btn_Buscar_Entidad, Me.Btn_Exportar_Excel})
        Me.Bar1.Location = New System.Drawing.Point(0, 520)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(954, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 21
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Actualizar_Informacion
        '
        Me.Btn_Actualizar_Informacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar_Informacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar_Informacion.Image = CType(resources.GetObject("Btn_Actualizar_Informacion.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Informacion.Name = "Btn_Actualizar_Informacion"
        '
        'Btn_Quitar_Celdas_En_Cero
        '
        Me.Btn_Quitar_Celdas_En_Cero.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Quitar_Celdas_En_Cero.ForeColor = System.Drawing.Color.Black
        Me.Btn_Quitar_Celdas_En_Cero.Image = CType(resources.GetObject("Btn_Quitar_Celdas_En_Cero.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Celdas_En_Cero.Name = "Btn_Quitar_Celdas_En_Cero"
        Me.Btn_Quitar_Celdas_En_Cero.Tooltip = "Quitar columnas con totales en cero"
        '
        'Btn_Cambiar_Fechas_Vencimiento
        '
        Me.Btn_Cambiar_Fechas_Vencimiento.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cambiar_Fechas_Vencimiento.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cambiar_Fechas_Vencimiento.Image = CType(resources.GetObject("Btn_Cambiar_Fechas_Vencimiento.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_Fechas_Vencimiento.Name = "Btn_Cambiar_Fechas_Vencimiento"
        Me.Btn_Cambiar_Fechas_Vencimiento.Tooltip = "Cambiar fechas de vencimiento"
        '
        'Btn_Buscar_Entidad
        '
        Me.Btn_Buscar_Entidad.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Buscar_Entidad.ForeColor = System.Drawing.Color.Black
        Me.Btn_Buscar_Entidad.Image = CType(resources.GetObject("Btn_Buscar_Entidad.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Entidad.Name = "Btn_Buscar_Entidad"
        Me.Btn_Buscar_Entidad.Tooltip = "Buscar entidad"
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar a Excel"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(930, 502)
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
        Me.GroupPanel1.TabIndex = 36
        Me.GroupPanel1.Text = "Detalle"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(289, 230)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(153, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 47
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Mnu_1, Me.Btn_Mnu_Ficha_Entidad, Me.LabelItem2, Me.Btn_Mnu_Mostrar_deuda_actual, Me.Btn_Mnu_Mostrar_deuda_completa, Me.Btn_Mnu_Enviar_Correo_Cobranza, Me.Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Lbl_Mnu_1
        '
        Me.Lbl_Mnu_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Lbl_Mnu_1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.Lbl_Mnu_1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Lbl_Mnu_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.Lbl_Mnu_1.Name = "Lbl_Mnu_1"
        Me.Lbl_Mnu_1.PaddingBottom = 1
        Me.Lbl_Mnu_1.PaddingLeft = 10
        Me.Lbl_Mnu_1.PaddingTop = 1
        Me.Lbl_Mnu_1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Lbl_Mnu_1.Text = "Información del cliente"
        '
        'Btn_Mnu_Ficha_Entidad
        '
        Me.Btn_Mnu_Ficha_Entidad.Image = CType(resources.GetObject("Btn_Mnu_Ficha_Entidad.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Ficha_Entidad.Name = "Btn_Mnu_Ficha_Entidad"
        Me.Btn_Mnu_Ficha_Entidad.Text = "Ver ficha de entidad"
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
        Me.LabelItem2.Text = "Opciones del repote"
        '
        'Btn_Mnu_Mostrar_deuda_actual
        '
        Me.Btn_Mnu_Mostrar_deuda_actual.Image = CType(resources.GetObject("Btn_Mnu_Mostrar_deuda_actual.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Mostrar_deuda_actual.Name = "Btn_Mnu_Mostrar_deuda_actual"
        Me.Btn_Mnu_Mostrar_deuda_actual.Text = "Mostrar detalle actual"
        '
        'Btn_Mnu_Mostrar_deuda_completa
        '
        Me.Btn_Mnu_Mostrar_deuda_completa.Image = CType(resources.GetObject("Btn_Mnu_Mostrar_deuda_completa.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Mostrar_deuda_completa.Name = "Btn_Mnu_Mostrar_deuda_completa"
        Me.Btn_Mnu_Mostrar_deuda_completa.Text = "Mostrar detalle deuda completa"
        '
        'Btn_Mnu_Enviar_Correo_Cobranza
        '
        Me.Btn_Mnu_Enviar_Correo_Cobranza.Image = CType(resources.GetObject("Btn_Mnu_Enviar_Correo_Cobranza.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Enviar_Correo_Cobranza.Name = "Btn_Mnu_Enviar_Correo_Cobranza"
        Me.Btn_Mnu_Enviar_Correo_Cobranza.Text = "Enviar correo de cobranza (detalle actual)"
        '
        'Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa
        '
        Me.Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa.Image = CType(resources.GetObject("Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa.Name = "Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa"
        Me.Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa.Text = "Enviar correo de cobranza (deuda completa)"
        '
        'Radio1
        '
        Me.Radio1.Checked = True
        Me.Radio1.Name = "Radio1"
        Me.Radio1.Text = "Mover todos"
        '
        'Radio2
        '
        Me.Radio2.Name = "Radio2"
        Me.Radio2.Text = "Seleccionar"
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
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.Size = New System.Drawing.Size(924, 479)
        Me.Grilla.TabIndex = 48
        '
        'Frm_Inf_Vencimientos_Mes_Detalle_Diario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 561)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Inf_Vencimientos_Mes_Detalle_Diario"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Actualizar_Informacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_Quitar_Celdas_En_Cero As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Radio1 As DevComponents.DotNetBar.Command
    Friend WithEvents Radio2 As DevComponents.DotNetBar.Command
    Friend WithEvents Btn_Cambiar_Fechas_Vencimiento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Mnu_1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Enviar_Correo_Cobranza As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Mostrar_deuda_actual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Mostrar_deuda_completa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Buscar_Entidad As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Ficha_Entidad As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
