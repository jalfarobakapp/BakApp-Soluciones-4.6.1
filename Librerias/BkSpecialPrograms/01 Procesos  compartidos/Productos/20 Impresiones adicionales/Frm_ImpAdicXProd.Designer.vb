<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ImpAdicXProd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ImpAdicXProd))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Producto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_FormatoDestino = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_FormatoOrigen = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_TipoDoc = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rdb_ImpFormDestinoyOrigen = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Reemplazar_Formato_Origen = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_Producto)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(629, 52)
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
        Me.GroupPanel1.TabIndex = 0
        Me.GroupPanel1.Text = "Producto"
        '
        'Txt_Producto
        '
        Me.Txt_Producto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Producto.Border.Class = "TextBoxBorder"
        Me.Txt_Producto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Producto.ButtonCustom.Image = CType(resources.GetObject("Txt_Producto.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Producto.ButtonCustom.Visible = True
        Me.Txt_Producto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Producto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Producto.Location = New System.Drawing.Point(3, 3)
        Me.Txt_Producto.Name = "Txt_Producto"
        Me.Txt_Producto.PreventEnterBeep = True
        Me.Txt_Producto.ReadOnly = True
        Me.Txt_Producto.Size = New System.Drawing.Size(617, 22)
        Me.Txt_Producto.TabIndex = 13
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar})
        Me.Bar2.Location = New System.Drawing.Point(0, 270)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(653, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 12
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = Global.BkSpecialPrograms.My.Resources.Resources.save
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Eliminar programación"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.LabelX4)
        Me.GroupPanel2.Controls.Add(Me.Rdb_ImpFormDestinoyOrigen)
        Me.GroupPanel2.Controls.Add(Me.LabelX3)
        Me.GroupPanel2.Controls.Add(Me.Txt_FormatoDestino)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.Txt_FormatoOrigen)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.Txt_TipoDoc)
        Me.GroupPanel2.Controls.Add(Me.Rdb_Reemplazar_Formato_Origen)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 70)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(629, 194)
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
        Me.GroupPanel2.TabIndex = 13
        Me.GroupPanel2.Text = "Detalle de activación de impresión de formato"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 70)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(102, 23)
        Me.LabelX3.TabIndex = 19
        Me.LabelX3.Text = "Formato Destino"
        '
        'Txt_FormatoDestino
        '
        Me.Txt_FormatoDestino.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_FormatoDestino.Border.Class = "TextBoxBorder"
        Me.Txt_FormatoDestino.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_FormatoDestino.ButtonCustom.Image = CType(resources.GetObject("Txt_FormatoDestino.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_FormatoDestino.ButtonCustom.Visible = True
        Me.Txt_FormatoDestino.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_FormatoDestino.ForeColor = System.Drawing.Color.Black
        Me.Txt_FormatoDestino.Location = New System.Drawing.Point(109, 70)
        Me.Txt_FormatoDestino.Name = "Txt_FormatoDestino"
        Me.Txt_FormatoDestino.PreventEnterBeep = True
        Me.Txt_FormatoDestino.ReadOnly = True
        Me.Txt_FormatoDestino.Size = New System.Drawing.Size(240, 22)
        Me.Txt_FormatoDestino.TabIndex = 18
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 41)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(102, 23)
        Me.LabelX2.TabIndex = 17
        Me.LabelX2.Text = "Formato Origen"
        '
        'Txt_FormatoOrigen
        '
        Me.Txt_FormatoOrigen.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_FormatoOrigen.Border.Class = "TextBoxBorder"
        Me.Txt_FormatoOrigen.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_FormatoOrigen.ButtonCustom.Image = CType(resources.GetObject("Txt_FormatoOrigen.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_FormatoOrigen.ButtonCustom.Visible = True
        Me.Txt_FormatoOrigen.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_FormatoOrigen.ForeColor = System.Drawing.Color.Black
        Me.Txt_FormatoOrigen.Location = New System.Drawing.Point(109, 41)
        Me.Txt_FormatoOrigen.Name = "Txt_FormatoOrigen"
        Me.Txt_FormatoOrigen.PreventEnterBeep = True
        Me.Txt_FormatoOrigen.ReadOnly = True
        Me.Txt_FormatoOrigen.Size = New System.Drawing.Size(240, 22)
        Me.Txt_FormatoOrigen.TabIndex = 16
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 13)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 15
        Me.LabelX1.Text = "Tipo doc."
        '
        'Txt_TipoDoc
        '
        Me.Txt_TipoDoc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_TipoDoc.Border.Class = "TextBoxBorder"
        Me.Txt_TipoDoc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_TipoDoc.ButtonCustom.Image = CType(resources.GetObject("Txt_TipoDoc.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_TipoDoc.ButtonCustom.Visible = True
        Me.Txt_TipoDoc.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_TipoDoc.ForeColor = System.Drawing.Color.Black
        Me.Txt_TipoDoc.Location = New System.Drawing.Point(109, 13)
        Me.Txt_TipoDoc.Name = "Txt_TipoDoc"
        Me.Txt_TipoDoc.PreventEnterBeep = True
        Me.Txt_TipoDoc.ReadOnly = True
        Me.Txt_TipoDoc.Size = New System.Drawing.Size(240, 22)
        Me.Txt_TipoDoc.TabIndex = 14
        '
        'Rdb_ImpFormDestinoyOrigen
        '
        Me.Rdb_ImpFormDestinoyOrigen.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_ImpFormDestinoyOrigen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_ImpFormDestinoyOrigen.CheckBoxImageChecked = CType(resources.GetObject("Rdb_ImpFormDestinoyOrigen.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_ImpFormDestinoyOrigen.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_ImpFormDestinoyOrigen.Checked = True
        Me.Rdb_ImpFormDestinoyOrigen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_ImpFormDestinoyOrigen.CheckValue = "Y"
        Me.Rdb_ImpFormDestinoyOrigen.Location = New System.Drawing.Point(3, 126)
        Me.Rdb_ImpFormDestinoyOrigen.Name = "Rdb_ImpFormDestinoyOrigen"
        Me.Rdb_ImpFormDestinoyOrigen.Size = New System.Drawing.Size(443, 22)
        Me.Rdb_ImpFormDestinoyOrigen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_ImpFormDestinoyOrigen.TabIndex = 20
        Me.Rdb_ImpFormDestinoyOrigen.Text = "Imprmir formato de destino despues de impirmir el formato de origen."
        '
        'Rdb_Reemplazar_Formato_Origen
        '
        Me.Rdb_Reemplazar_Formato_Origen.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Reemplazar_Formato_Origen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Reemplazar_Formato_Origen.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Reemplazar_Formato_Origen.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Reemplazar_Formato_Origen.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Reemplazar_Formato_Origen.Location = New System.Drawing.Point(3, 146)
        Me.Rdb_Reemplazar_Formato_Origen.Name = "Rdb_Reemplazar_Formato_Origen"
        Me.Rdb_Reemplazar_Formato_Origen.Size = New System.Drawing.Size(408, 22)
        Me.Rdb_Reemplazar_Formato_Origen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Reemplazar_Formato_Origen.TabIndex = 21
        Me.Rdb_Reemplazar_Formato_Origen.Text = "Imprmir el formato de destino por sobre el formato de origen."
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 99)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(192, 23)
        Me.LabelX4.TabIndex = 22
        Me.LabelX4.Text = "Forma de impresión"
        '
        'Frm_ImpAdicXProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 311)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ImpAdicXProd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONFIGURACION DE ACTIVACION DE FORMATO DE IMPRESION ESPECIAL POR PRODUCTO"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Producto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_FormatoDestino As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_FormatoOrigen As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_TipoDoc As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_ImpFormDestinoyOrigen As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Reemplazar_Formato_Origen As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
