<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Sol_Recom_Respuesta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Sol_Recom_Respuesta))
        Me.Grupo_Respuesta = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Panel_Agotado = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Agotado_NO = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Agotado_SI = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel_Pedido = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Pedido_NO = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Pedido_SI = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Quitar_Reemplazo = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_Producto_Reemplazo = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Reemplazar_Por = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Respuesta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Enviar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Solicitud = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Mnu_Pr_Estadistica_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Respuesta.SuspendLayout()
        Me.Panel_Agotado.SuspendLayout()
        Me.Panel_Pedido.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grupo_Respuesta
        '
        Me.Grupo_Respuesta.BackColor = System.Drawing.Color.White
        Me.Grupo_Respuesta.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Respuesta.Controls.Add(Me.LabelX3)
        Me.Grupo_Respuesta.Controls.Add(Me.Panel_Agotado)
        Me.Grupo_Respuesta.Controls.Add(Me.Panel_Pedido)
        Me.Grupo_Respuesta.Controls.Add(Me.Btn_Quitar_Reemplazo)
        Me.Grupo_Respuesta.Controls.Add(Me.Lbl_Producto_Reemplazo)
        Me.Grupo_Respuesta.Controls.Add(Me.Btn_Reemplazar_Por)
        Me.Grupo_Respuesta.Controls.Add(Me.Txt_Respuesta)
        Me.Grupo_Respuesta.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Respuesta.Location = New System.Drawing.Point(12, 176)
        Me.Grupo_Respuesta.Name = "Grupo_Respuesta"
        Me.Grupo_Respuesta.Size = New System.Drawing.Size(602, 213)
        '
        '
        '
        Me.Grupo_Respuesta.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Respuesta.Style.BackColorGradientAngle = 90
        Me.Grupo_Respuesta.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Respuesta.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Respuesta.Style.BorderBottomWidth = 1
        Me.Grupo_Respuesta.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Respuesta.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Respuesta.Style.BorderLeftWidth = 1
        Me.Grupo_Respuesta.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Respuesta.Style.BorderRightWidth = 1
        Me.Grupo_Respuesta.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Respuesta.Style.BorderTopWidth = 1
        Me.Grupo_Respuesta.Style.CornerDiameter = 4
        Me.Grupo_Respuesta.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Respuesta.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Respuesta.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Respuesta.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Respuesta.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Respuesta.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Respuesta.TabIndex = 146
        Me.Grupo_Respuesta.Text = "Respuesta"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(9, 101)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(271, 23)
        Me.LabelX3.TabIndex = 151
        Me.LabelX3.Text = "Gestión con el proveedor"
        '
        'Panel_Agotado
        '
        Me.Panel_Agotado.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Agotado.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Panel_Agotado.ColumnCount = 3
        Me.Panel_Agotado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.17558!))
        Me.Panel_Agotado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.82443!))
        Me.Panel_Agotado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.Panel_Agotado.Controls.Add(Me.LabelX2, 0, 0)
        Me.Panel_Agotado.Controls.Add(Me.Rdb_Agotado_NO, 2, 0)
        Me.Panel_Agotado.Controls.Add(Me.Rdb_Agotado_SI, 1, 0)
        Me.Panel_Agotado.ForeColor = System.Drawing.Color.Black
        Me.Panel_Agotado.Location = New System.Drawing.Point(216, 127)
        Me.Panel_Agotado.Name = "Panel_Agotado"
        Me.Panel_Agotado.RowCount = 1
        Me.Panel_Agotado.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Panel_Agotado.Size = New System.Drawing.Size(182, 31)
        Me.Panel_Agotado.TabIndex = 150
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(4, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(58, 23)
        Me.LabelX2.TabIndex = 150
        Me.LabelX2.Text = "Agotado"
        '
        'Rdb_Agotado_NO
        '
        Me.Rdb_Agotado_NO.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Agotado_NO.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Agotado_NO.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Agotado_NO.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Agotado_NO.Location = New System.Drawing.Point(139, 4)
        Me.Rdb_Agotado_NO.Name = "Rdb_Agotado_NO"
        Me.Rdb_Agotado_NO.Size = New System.Drawing.Size(39, 23)
        Me.Rdb_Agotado_NO.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Agotado_NO.TabIndex = 147
        Me.Rdb_Agotado_NO.Text = "NO"
        '
        'Rdb_Agotado_SI
        '
        Me.Rdb_Agotado_SI.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Agotado_SI.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Agotado_SI.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Agotado_SI.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Agotado_SI.Location = New System.Drawing.Point(95, 4)
        Me.Rdb_Agotado_SI.Name = "Rdb_Agotado_SI"
        Me.Rdb_Agotado_SI.Size = New System.Drawing.Size(28, 23)
        Me.Rdb_Agotado_SI.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Agotado_SI.TabIndex = 146
        Me.Rdb_Agotado_SI.Text = "SI"
        '
        'Panel_Pedido
        '
        Me.Panel_Pedido.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Pedido.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Panel_Pedido.ColumnCount = 3
        Me.Panel_Pedido.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.29032!))
        Me.Panel_Pedido.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.70968!))
        Me.Panel_Pedido.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.Panel_Pedido.Controls.Add(Me.LabelX1, 0, 0)
        Me.Panel_Pedido.Controls.Add(Me.Rdb_Pedido_NO, 2, 0)
        Me.Panel_Pedido.Controls.Add(Me.Rdb_Pedido_SI, 1, 0)
        Me.Panel_Pedido.ForeColor = System.Drawing.Color.Black
        Me.Panel_Pedido.Location = New System.Drawing.Point(9, 127)
        Me.Panel_Pedido.Name = "Panel_Pedido"
        Me.Panel_Pedido.RowCount = 1
        Me.Panel_Pedido.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Panel_Pedido.Size = New System.Drawing.Size(175, 31)
        Me.Panel_Pedido.TabIndex = 149
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(4, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(36, 23)
        Me.LabelX1.TabIndex = 150
        Me.LabelX1.Text = "Pedido"
        '
        'Rdb_Pedido_NO
        '
        Me.Rdb_Pedido_NO.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Pedido_NO.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Pedido_NO.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Pedido_NO.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Pedido_NO.Location = New System.Drawing.Point(129, 4)
        Me.Rdb_Pedido_NO.Name = "Rdb_Pedido_NO"
        Me.Rdb_Pedido_NO.Size = New System.Drawing.Size(41, 23)
        Me.Rdb_Pedido_NO.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Pedido_NO.TabIndex = 147
        Me.Rdb_Pedido_NO.Text = "NO"
        '
        'Rdb_Pedido_SI
        '
        Me.Rdb_Pedido_SI.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Pedido_SI.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Pedido_SI.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Pedido_SI.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Pedido_SI.Location = New System.Drawing.Point(80, 4)
        Me.Rdb_Pedido_SI.Name = "Rdb_Pedido_SI"
        Me.Rdb_Pedido_SI.Size = New System.Drawing.Size(42, 23)
        Me.Rdb_Pedido_SI.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Pedido_SI.TabIndex = 146
        Me.Rdb_Pedido_SI.Text = "SI"
        '
        'Btn_Quitar_Reemplazo
        '
        Me.Btn_Quitar_Reemplazo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Quitar_Reemplazo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Quitar_Reemplazo.Enabled = False
        Me.Btn_Quitar_Reemplazo.Image = CType(resources.GetObject("Btn_Quitar_Reemplazo.Image"), System.Drawing.Image)
        Me.Btn_Quitar_Reemplazo.Location = New System.Drawing.Point(562, 164)
        Me.Btn_Quitar_Reemplazo.Name = "Btn_Quitar_Reemplazo"
        Me.Btn_Quitar_Reemplazo.Size = New System.Drawing.Size(31, 23)
        Me.Btn_Quitar_Reemplazo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Quitar_Reemplazo.TabIndex = 145
        '
        'Lbl_Producto_Reemplazo
        '
        Me.Lbl_Producto_Reemplazo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Producto_Reemplazo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Producto_Reemplazo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Producto_Reemplazo.Location = New System.Drawing.Point(49, 164)
        Me.Lbl_Producto_Reemplazo.Name = "Lbl_Producto_Reemplazo"
        Me.Lbl_Producto_Reemplazo.Size = New System.Drawing.Size(507, 23)
        Me.Lbl_Producto_Reemplazo.TabIndex = 144
        Me.Lbl_Producto_Reemplazo.Text = "."
        '
        'Btn_Reemplazar_Por
        '
        Me.Btn_Reemplazar_Por.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Reemplazar_Por.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Reemplazar_Por.Location = New System.Drawing.Point(9, 164)
        Me.Btn_Reemplazar_Por.Name = "Btn_Reemplazar_Por"
        Me.Btn_Reemplazar_Por.Size = New System.Drawing.Size(34, 23)
        Me.Btn_Reemplazar_Por.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Reemplazar_Por.TabIndex = 143
        Me.Btn_Reemplazar_Por.Text = "..."
        Me.Btn_Reemplazar_Por.Tooltip = "Reemplazar producto por otro..."
        '
        'Txt_Respuesta
        '
        Me.Txt_Respuesta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Respuesta.Border.Class = "TextBoxBorder"
        Me.Txt_Respuesta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Respuesta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Respuesta.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Respuesta.FocusHighlightEnabled = True
        Me.Txt_Respuesta.Font = New System.Drawing.Font("Courier New", 9.75!)
        Me.Txt_Respuesta.ForeColor = System.Drawing.Color.Black
        Me.Txt_Respuesta.Location = New System.Drawing.Point(9, 3)
        Me.Txt_Respuesta.Multiline = True
        Me.Txt_Respuesta.Name = "Txt_Respuesta"
        Me.Txt_Respuesta.PreventEnterBeep = True
        Me.Txt_Respuesta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Respuesta.Size = New System.Drawing.Size(584, 92)
        Me.Txt_Respuesta.TabIndex = 142
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Enviar, Me.Btn_Mnu_Pr_Estadistica_Producto})
        Me.Bar1.Location = New System.Drawing.Point(0, 395)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(624, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 145
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Enviar
        '
        Me.Btn_Enviar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Enviar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Enviar.Image = CType(resources.GetObject("Btn_Enviar.Image"), System.Drawing.Image)
        Me.Btn_Enviar.Name = "Btn_Enviar"
        Me.Btn_Enviar.Text = "Enviar respuesta"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Lbl_Solicitud)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 2)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(602, 168)
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
        Me.GroupPanel1.TabIndex = 147
        Me.GroupPanel1.Text = "Solicitud de compra  de producto"
        '
        'Lbl_Solicitud
        '
        Me.Lbl_Solicitud.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Solicitud.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Solicitud.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Solicitud.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Solicitud.Location = New System.Drawing.Point(9, 13)
        Me.Lbl_Solicitud.Name = "Lbl_Solicitud"
        Me.Lbl_Solicitud.Size = New System.Drawing.Size(584, 129)
        Me.Lbl_Solicitud.TabIndex = 0
        Me.Lbl_Solicitud.Text = "<b>PRODUCTO A COMPRAR</b>: _CODIGO_DESCRIPCION<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<b>TIPO DE COMPRA:</b>TIPO_C" &
    "OMPRA<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<b>CLIENTE: </b>_CLIENTE<br/>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<b>OBS: </b>_OBSERVACIONES"
        Me.Lbl_Solicitud.TextLineAlignment = System.Drawing.StringAlignment.Near
        '
        'Btn_Mnu_Pr_Estadistica_Producto
        '
        Me.Btn_Mnu_Pr_Estadistica_Producto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Mnu_Pr_Estadistica_Producto.ForeColor = System.Drawing.Color.Black
        Me.Btn_Mnu_Pr_Estadistica_Producto.Image = CType(resources.GetObject("Btn_Mnu_Pr_Estadistica_Producto.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Pr_Estadistica_Producto.Name = "Btn_Mnu_Pr_Estadistica_Producto"
        Me.Btn_Mnu_Pr_Estadistica_Producto.Tooltip = "Ver estadísticas del producto/información adicional"
        Me.Btn_Mnu_Pr_Estadistica_Producto.Visible = False
        '
        'Frm_Sol_Recom_Respuesta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 436)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Grupo_Respuesta)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Sol_Recom_Respuesta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RESPUESTA POR SOLICITUD DE PRODUCTO"
        Me.Grupo_Respuesta.ResumeLayout(False)
        Me.Panel_Agotado.ResumeLayout(False)
        Me.Panel_Pedido.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grupo_Respuesta As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Respuesta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Enviar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Reemplazar_Por As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Solicitud As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Quitar_Reemplazo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Lbl_Producto_Reemplazo As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel_Agotado As TableLayoutPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Agotado_NO As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Agotado_SI As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel_Pedido As TableLayoutPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Pedido_NO As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Pedido_SI As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Btn_Mnu_Pr_Estadistica_Producto As DevComponents.DotNetBar.ButtonItem
End Class
