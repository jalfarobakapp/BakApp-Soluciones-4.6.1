<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Inf_Ventas_X_Periodo_Sub_Informe_SuperGrid
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inf_Ventas_X_Periodo_Sub_Informe_SuperGrid))
        Me.Super_Grilla = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Mnu_1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Estadisticas_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Ver_Documento = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Informeacion_Credito_Cliente = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Documentos_Entidades = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_contextual_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem8 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Exportar_Vista_Actual = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Detalle = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Ventas = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem6 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Cotizacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Nota_de_venta = New DevComponents.DotNetBar.ButtonItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Crear_Venta = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Filtro_Abanzado = New DevComponents.DotNetBar.Controls.TextBoxX()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Super_Grilla.Location = New System.Drawing.Point(12, 38)
        Me.Super_Grilla.Name = "Super_Grilla"
        Me.Super_Grilla.PrimaryGrid.Filter.ShowPanelFilterExpr = True
        Me.Super_Grilla.PrimaryGrid.GroupByRow.Visible = True
        Me.Super_Grilla.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled
        Me.Super_Grilla.Size = New System.Drawing.Size(795, 486)
        Me.Super_Grilla.TabIndex = 1
        Me.Super_Grilla.Text = "SuperGridControl2"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual, Me.Menu_contextual_Exportar_Excel, Me.Menu_Contextual_Ventas})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(157, 180)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(356, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 52
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual
        '
        Me.Menu_Contextual.AutoExpandOnClick = True
        Me.Menu_Contextual.Name = "Menu_Contextual"
        Me.Menu_Contextual.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Mnu_1, Me.Btn_Mnu_Estadisticas_Producto, Me.Btn_Mnu_Ver_Documento, Me.Btn_Mnu_Informeacion_Credito_Cliente, Me.Btn_Informe_X_Documentos_Entidades, Me.Btn_Informe_X_Productos, Me.Btn_Copiar})
        Me.Menu_Contextual.Text = "Opciones"
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
        Me.Lbl_Mnu_1.Text = "Opciones"
        '
        'Btn_Mnu_Estadisticas_Producto
        '
        Me.Btn_Mnu_Estadisticas_Producto.Image = CType(resources.GetObject("Btn_Mnu_Estadisticas_Producto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Estadisticas_Producto.ImageAlt = CType(resources.GetObject("Btn_Mnu_Estadisticas_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Estadisticas_Producto.Name = "Btn_Mnu_Estadisticas_Producto"
        Me.Btn_Mnu_Estadisticas_Producto.Text = "Ver estadísticas del producto/información adicional"
        '
        'Btn_Mnu_Ver_Documento
        '
        Me.Btn_Mnu_Ver_Documento.Image = CType(resources.GetObject("Btn_Mnu_Ver_Documento.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Ver_Documento.ImageAlt = CType(resources.GetObject("Btn_Mnu_Ver_Documento.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Ver_Documento.Name = "Btn_Mnu_Ver_Documento"
        Me.Btn_Mnu_Ver_Documento.Text = "Ver documento"
        '
        'Btn_Mnu_Informeacion_Credito_Cliente
        '
        Me.Btn_Mnu_Informeacion_Credito_Cliente.Image = CType(resources.GetObject("Btn_Mnu_Informeacion_Credito_Cliente.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Informeacion_Credito_Cliente.ImageAlt = CType(resources.GetObject("Btn_Mnu_Informeacion_Credito_Cliente.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_Informeacion_Credito_Cliente.Name = "Btn_Mnu_Informeacion_Credito_Cliente"
        Me.Btn_Mnu_Informeacion_Credito_Cliente.Text = "Ver información de créditos vigentes del cliente"
        '
        'Btn_Informe_X_Documentos_Entidades
        '
        Me.Btn_Informe_X_Documentos_Entidades.Image = CType(resources.GetObject("Btn_Informe_X_Documentos_Entidades.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Documentos_Entidades.ImageAlt = CType(resources.GetObject("Btn_Informe_X_Documentos_Entidades.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_X_Documentos_Entidades.Name = "Btn_Informe_X_Documentos_Entidades"
        Me.Btn_Informe_X_Documentos_Entidades.Text = "Ver detalle de las <b><font color=""#22B14C"">Documentos -> Clientes</font></b>"
        '
        'Btn_Informe_X_Productos
        '
        Me.Btn_Informe_X_Productos.Image = CType(resources.GetObject("Btn_Informe_X_Productos.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Productos.ImageAlt = CType(resources.GetObject("Btn_Informe_X_Productos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Informe_X_Productos.Name = "Btn_Informe_X_Productos"
        Me.Btn_Informe_X_Productos.Text = "Ver detalle de los <b><font color=""#22B14C"">Productos->Detalle</font></b>"
        '
        'Btn_Copiar
        '
        Me.Btn_Copiar.Image = CType(resources.GetObject("Btn_Copiar.Image"), System.Drawing.Image)
        Me.Btn_Copiar.ImageAlt = CType(resources.GetObject("Btn_Copiar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Copiar.Name = "Btn_Copiar"
        Me.Btn_Copiar.Text = "Copiar código (portapapeles)"
        '
        'Menu_contextual_Exportar_Excel
        '
        Me.Menu_contextual_Exportar_Excel.AutoExpandOnClick = True
        Me.Menu_contextual_Exportar_Excel.Name = "Menu_contextual_Exportar_Excel"
        Me.Menu_contextual_Exportar_Excel.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem8, Me.Btn_Exportar_Vista_Actual, Me.Btn_Exportar_Detalle})
        Me.Menu_contextual_Exportar_Excel.Text = "Exportar Excel"
        '
        'LabelItem8
        '
        Me.LabelItem8.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem8.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem8.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem8.Name = "LabelItem8"
        Me.LabelItem8.PaddingBottom = 1
        Me.LabelItem8.PaddingLeft = 10
        Me.LabelItem8.PaddingTop = 1
        Me.LabelItem8.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem8.Text = "Exportar datos a Excel"
        '
        'Btn_Exportar_Vista_Actual
        '
        Me.Btn_Exportar_Vista_Actual.Image = CType(resources.GetObject("Btn_Exportar_Vista_Actual.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Vista_Actual.ImageAlt = CType(resources.GetObject("Btn_Exportar_Vista_Actual.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Vista_Actual.Name = "Btn_Exportar_Vista_Actual"
        Me.Btn_Exportar_Vista_Actual.Text = "Exportar vista actual"
        '
        'Btn_Exportar_Detalle
        '
        Me.Btn_Exportar_Detalle.Image = CType(resources.GetObject("Btn_Exportar_Detalle.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Detalle.ImageAlt = CType(resources.GetObject("Btn_Exportar_Detalle.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Detalle.Name = "Btn_Exportar_Detalle"
        Me.Btn_Exportar_Detalle.Text = "Exportar detalle"
        '
        'Menu_Contextual_Ventas
        '
        Me.Menu_Contextual_Ventas.AutoExpandOnClick = True
        Me.Menu_Contextual_Ventas.Name = "Menu_Contextual_Ventas"
        Me.Menu_Contextual_Ventas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem6, Me.Btn_Cotizacion, Me.Btn_Nota_de_venta})
        Me.Menu_Contextual_Ventas.Text = "Ventas..."
        '
        'LabelItem6
        '
        Me.LabelItem6.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem6.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem6.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem6.Name = "LabelItem6"
        Me.LabelItem6.PaddingBottom = 1
        Me.LabelItem6.PaddingLeft = 10
        Me.LabelItem6.PaddingTop = 1
        Me.LabelItem6.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem6.Text = "Documentos de venta"
        '
        'Btn_Cotizacion
        '
        Me.Btn_Cotizacion.Enabled = False
        Me.Btn_Cotizacion.Image = CType(resources.GetObject("Btn_Cotizacion.Image"), System.Drawing.Image)
        Me.Btn_Cotizacion.ImageAlt = CType(resources.GetObject("Btn_Cotizacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cotizacion.Name = "Btn_Cotizacion"
        Me.Btn_Cotizacion.Text = "COTIZACION"
        '
        'Btn_Nota_de_venta
        '
        Me.Btn_Nota_de_venta.Image = CType(resources.GetObject("Btn_Nota_de_venta.Image"), System.Drawing.Image)
        Me.Btn_Nota_de_venta.ImageAlt = CType(resources.GetObject("Btn_Nota_de_venta.ImageAlt"), System.Drawing.Image)
        Me.Btn_Nota_de_venta.Name = "Btn_Nota_de_venta"
        Me.Btn_Nota_de_venta.Text = "NOTA DE VENTA"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Excel, Me.Btn_Crear_Venta})
        Me.Bar1.Location = New System.Drawing.Point(0, 530)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(819, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 116
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Excel
        '
        Me.Btn_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Excel.Image = CType(resources.GetObject("Btn_Excel.Image"), System.Drawing.Image)
        Me.Btn_Excel.ImageAlt = CType(resources.GetObject("Btn_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Tooltip = "Exportar a Excel"
        '
        'Btn_Crear_Venta
        '
        Me.Btn_Crear_Venta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_Venta.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_Venta.Image = CType(resources.GetObject("Btn_Crear_Venta.Image"), System.Drawing.Image)
        Me.Btn_Crear_Venta.ImageAlt = CType(resources.GetObject("Btn_Crear_Venta.ImageAlt"), System.Drawing.Image)
        Me.Btn_Crear_Venta.Name = "Btn_Crear_Venta"
        Me.Btn_Crear_Venta.Text = "CREAR VENTA"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(11, 9)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(90, 23)
        Me.LabelX1.TabIndex = 123
        Me.LabelX1.Text = "Filtro avanzado"
        '
        'Txt_Filtro_Abanzado
        '
        Me.Txt_Filtro_Abanzado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Filtro_Abanzado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Filtro_Abanzado.Border.Class = "TextBoxBorder"
        Me.Txt_Filtro_Abanzado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Filtro_Abanzado.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Filtro_Abanzado.ForeColor = System.Drawing.Color.Black
        Me.Txt_Filtro_Abanzado.Location = New System.Drawing.Point(107, 9)
        Me.Txt_Filtro_Abanzado.Name = "Txt_Filtro_Abanzado"
        Me.Txt_Filtro_Abanzado.PreventEnterBeep = True
        Me.Txt_Filtro_Abanzado.Size = New System.Drawing.Size(700, 22)
        Me.Txt_Filtro_Abanzado.TabIndex = 122
        '
        'Frm_Inf_Ventas_X_Periodo_Sub_Informe_SuperGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 571)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Txt_Filtro_Abanzado)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.ContextMenuBar1)
        Me.Controls.Add(Me.Super_Grilla)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "Frm_Inf_Ventas_X_Periodo_Sub_Informe_SuperGrid"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DETALLE DE INFORME DE VENTAS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents Super_Grilla As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Mnu_1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Estadisticas_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Ver_Documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Informeacion_Credito_Cliente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Filtro_Abanzado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Informe_X_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Informe_X_Documentos_Entidades As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_contextual_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem8 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Exportar_Vista_Actual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_Detalle As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Crear_Venta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Ventas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem6 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Cotizacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Nota_de_venta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Copiar As DevComponents.DotNetBar.ButtonItem
End Class
