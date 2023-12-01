<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Tickets_TiposCrear
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Tickets_TiposCrear))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Area = New DevComponents.DotNetBar.LabelX()
        Me.Panel_Productos = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_RevInventario = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_AjusInventario = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_SobreStock = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_ExigeProducto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Tipo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Crear_Agente = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_Agente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Grupo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Rdb_AsignadoGrupo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_AsignadoAgente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Asignado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel1.SuspendLayout()
        Me.Panel_Productos.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_Agente)
        Me.GroupPanel1.Controls.Add(Me.Txt_Grupo)
        Me.GroupPanel1.Controls.Add(Me.Line1)
        Me.GroupPanel1.Controls.Add(Me.Rdb_AsignadoGrupo)
        Me.GroupPanel1.Controls.Add(Me.Rdb_AsignadoAgente)
        Me.GroupPanel1.Controls.Add(Me.Chk_Asignado)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Area)
        Me.GroupPanel1.Controls.Add(Me.Panel_Productos)
        Me.GroupPanel1.Controls.Add(Me.Chk_ExigeProducto)
        Me.GroupPanel1.Controls.Add(Me.Txt_Tipo)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(629, 267)
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
        Me.GroupPanel1.Text = "Ficha tipo"
        '
        'Lbl_Area
        '
        Me.Lbl_Area.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Area.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Area.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Area.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Area.Location = New System.Drawing.Point(19, 17)
        Me.Lbl_Area.Name = "Lbl_Area"
        Me.Lbl_Area.Size = New System.Drawing.Size(516, 23)
        Me.Lbl_Area.TabIndex = 121
        Me.Lbl_Area.Text = "AREA: XXXXXXXXXXWWWWWWWWWYYYYYYYYSSSSSSSS"
        '
        'Panel_Productos
        '
        Me.Panel_Productos.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Productos.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.Panel_Productos.ColumnCount = 3
        Me.Panel_Productos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Panel_Productos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Panel_Productos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.Panel_Productos.Controls.Add(Me.Rdb_RevInventario, 0, 0)
        Me.Panel_Productos.Controls.Add(Me.Rdb_AjusInventario, 1, 0)
        Me.Panel_Productos.Controls.Add(Me.Rdb_SobreStock, 2, 0)
        Me.Panel_Productos.Enabled = False
        Me.Panel_Productos.ForeColor = System.Drawing.Color.Black
        Me.Panel_Productos.Location = New System.Drawing.Point(19, 103)
        Me.Panel_Productos.Name = "Panel_Productos"
        Me.Panel_Productos.RowCount = 1
        Me.Panel_Productos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Panel_Productos.Size = New System.Drawing.Size(450, 25)
        Me.Panel_Productos.TabIndex = 59
        '
        'Rdb_RevInventario
        '
        Me.Rdb_RevInventario.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_RevInventario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_RevInventario.CheckBoxImageChecked = CType(resources.GetObject("Rdb_RevInventario.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_RevInventario.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_RevInventario.FocusCuesEnabled = False
        Me.Rdb_RevInventario.ForeColor = System.Drawing.Color.Black
        Me.Rdb_RevInventario.Location = New System.Drawing.Point(4, 4)
        Me.Rdb_RevInventario.Name = "Rdb_RevInventario"
        Me.Rdb_RevInventario.Size = New System.Drawing.Size(131, 17)
        Me.Rdb_RevInventario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_RevInventario.TabIndex = 23
        Me.Rdb_RevInventario.Text = "Revisión de inventario"
        '
        'Rdb_AjusInventario
        '
        Me.Rdb_AjusInventario.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_AjusInventario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_AjusInventario.CheckBoxImageChecked = CType(resources.GetObject("Rdb_AjusInventario.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_AjusInventario.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_AjusInventario.FocusCuesEnabled = False
        Me.Rdb_AjusInventario.ForeColor = System.Drawing.Color.Black
        Me.Rdb_AjusInventario.Location = New System.Drawing.Point(153, 4)
        Me.Rdb_AjusInventario.Name = "Rdb_AjusInventario"
        Me.Rdb_AjusInventario.Size = New System.Drawing.Size(119, 17)
        Me.Rdb_AjusInventario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_AjusInventario.TabIndex = 22
        Me.Rdb_AjusInventario.Text = "Ajuste de inventario"
        '
        'Rdb_SobreStock
        '
        Me.Rdb_SobreStock.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_SobreStock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_SobreStock.CheckBoxImageChecked = CType(resources.GetObject("Rdb_SobreStock.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_SobreStock.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_SobreStock.FocusCuesEnabled = False
        Me.Rdb_SobreStock.ForeColor = System.Drawing.Color.Black
        Me.Rdb_SobreStock.Location = New System.Drawing.Point(302, 4)
        Me.Rdb_SobreStock.Name = "Rdb_SobreStock"
        Me.Rdb_SobreStock.Size = New System.Drawing.Size(80, 17)
        Me.Rdb_SobreStock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_SobreStock.TabIndex = 21
        Me.Rdb_SobreStock.Text = "Sobre stock"
        '
        'Chk_ExigeProducto
        '
        Me.Chk_ExigeProducto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_ExigeProducto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ExigeProducto.CheckBoxImageChecked = CType(resources.GetObject("Chk_ExigeProducto.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_ExigeProducto.FocusCuesEnabled = False
        Me.Chk_ExigeProducto.ForeColor = System.Drawing.Color.Black
        Me.Chk_ExigeProducto.Location = New System.Drawing.Point(19, 75)
        Me.Chk_ExigeProducto.Name = "Chk_ExigeProducto"
        Me.Chk_ExigeProducto.Size = New System.Drawing.Size(91, 22)
        Me.Chk_ExigeProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ExigeProducto.TabIndex = 58
        Me.Chk_ExigeProducto.TabStop = False
        Me.Chk_ExigeProducto.Text = "Exige producto"
        '
        'Txt_Tipo
        '
        Me.Txt_Tipo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Tipo.Border.Class = "TextBoxBorder"
        Me.Txt_Tipo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Tipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Tipo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Tipo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Tipo.Location = New System.Drawing.Point(127, 47)
        Me.Txt_Tipo.MaxLength = 50
        Me.Txt_Tipo.Name = "Txt_Tipo"
        Me.Txt_Tipo.PreventEnterBeep = True
        Me.Txt_Tipo.Size = New System.Drawing.Size(493, 22)
        Me.Txt_Tipo.TabIndex = 48
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(19, 46)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(102, 23)
        Me.LabelX3.TabIndex = 49
        Me.LabelX3.Text = "Tipo requerimiento"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Crear_Agente})
        Me.Bar2.Location = New System.Drawing.Point(0, 292)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(653, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 115
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Crear_Agente
        '
        Me.Btn_Crear_Agente.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_Agente.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_Agente.Image = CType(resources.GetObject("Btn_Crear_Agente.Image"), System.Drawing.Image)
        Me.Btn_Crear_Agente.ImageAlt = CType(resources.GetObject("Btn_Crear_Agente.ImageAlt"), System.Drawing.Image)
        Me.Btn_Crear_Agente.Name = "Btn_Crear_Agente"
        Me.Btn_Crear_Agente.Tooltip = "Grabar"
        '
        'Txt_Agente
        '
        Me.Txt_Agente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Agente.Border.Class = "TextBoxBorder"
        Me.Txt_Agente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Agente.ButtonCustom.Image = CType(resources.GetObject("Txt_Agente.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Agente.ButtonCustom.Visible = True
        Me.Txt_Agente.ButtonCustom2.Image = CType(resources.GetObject("Txt_Agente.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Agente.ButtonCustom2.Visible = True
        Me.Txt_Agente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Agente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Agente.Location = New System.Drawing.Point(162, 215)
        Me.Txt_Agente.Name = "Txt_Agente"
        Me.Txt_Agente.PreventEnterBeep = True
        Me.Txt_Agente.ReadOnly = True
        Me.Txt_Agente.Size = New System.Drawing.Size(291, 22)
        Me.Txt_Agente.TabIndex = 126
        Me.Txt_Agente.TabStop = False
        '
        'Txt_Grupo
        '
        Me.Txt_Grupo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Grupo.Border.Class = "TextBoxBorder"
        Me.Txt_Grupo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Grupo.ButtonCustom.Image = CType(resources.GetObject("Txt_Grupo.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Grupo.ButtonCustom.Visible = True
        Me.Txt_Grupo.ButtonCustom2.Image = CType(resources.GetObject("Txt_Grupo.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Grupo.ButtonCustom2.Visible = True
        Me.Txt_Grupo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Grupo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Grupo.Location = New System.Drawing.Point(162, 186)
        Me.Txt_Grupo.Name = "Txt_Grupo"
        Me.Txt_Grupo.PreventEnterBeep = True
        Me.Txt_Grupo.ReadOnly = True
        Me.Txt_Grupo.Size = New System.Drawing.Size(291, 22)
        Me.Txt_Grupo.TabIndex = 124
        Me.Txt_Grupo.TabStop = False
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.Transparent
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(19, 140)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(377, 23)
        Me.Line1.TabIndex = 127
        Me.Line1.Text = "Line1"
        '
        'Rdb_AsignadoGrupo
        '
        Me.Rdb_AsignadoGrupo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_AsignadoGrupo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_AsignadoGrupo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_AsignadoGrupo.FocusCuesEnabled = False
        Me.Rdb_AsignadoGrupo.ForeColor = System.Drawing.Color.Black
        Me.Rdb_AsignadoGrupo.Location = New System.Drawing.Point(19, 186)
        Me.Rdb_AsignadoGrupo.Name = "Rdb_AsignadoGrupo"
        Me.Rdb_AsignadoGrupo.Size = New System.Drawing.Size(125, 23)
        Me.Rdb_AsignadoGrupo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_AsignadoGrupo.TabIndex = 123
        Me.Rdb_AsignadoGrupo.TabStop = False
        Me.Rdb_AsignadoGrupo.Text = "Asignar a un grupo"
        '
        'Rdb_AsignadoAgente
        '
        Me.Rdb_AsignadoAgente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_AsignadoAgente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_AsignadoAgente.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_AsignadoAgente.FocusCuesEnabled = False
        Me.Rdb_AsignadoAgente.ForeColor = System.Drawing.Color.Black
        Me.Rdb_AsignadoAgente.Location = New System.Drawing.Point(19, 214)
        Me.Rdb_AsignadoAgente.Name = "Rdb_AsignadoAgente"
        Me.Rdb_AsignadoAgente.Size = New System.Drawing.Size(137, 23)
        Me.Rdb_AsignadoAgente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_AsignadoAgente.TabIndex = 125
        Me.Rdb_AsignadoAgente.TabStop = False
        Me.Rdb_AsignadoAgente.Text = "Asignar a un agente"
        '
        'Chk_Asignado
        '
        Me.Chk_Asignado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Asignado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Asignado.CheckBoxImageChecked = CType(resources.GetObject("Chk_Asignado.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Asignado.FocusCuesEnabled = False
        Me.Chk_Asignado.ForeColor = System.Drawing.Color.Black
        Me.Chk_Asignado.Location = New System.Drawing.Point(19, 158)
        Me.Chk_Asignado.Name = "Chk_Asignado"
        Me.Chk_Asignado.Size = New System.Drawing.Size(187, 22)
        Me.Chk_Asignado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Asignado.TabIndex = 122
        Me.Chk_Asignado.TabStop = False
        Me.Chk_Asignado.Text = "ASIGNAR EL REQUERIMINETO A:"
        '
        'Frm_Tickets_TiposCrear
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 333)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Tickets_TiposCrear"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TIPO DE REQUERIMIENTO"
        Me.GroupPanel1.ResumeLayout(False)
        Me.Panel_Productos.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Tipo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_ExigeProducto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel_Productos As TableLayoutPanel
    Public WithEvents Rdb_RevInventario As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_AjusInventario As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_SobreStock As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Crear_Agente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Area As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Agente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Grupo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Rdb_AsignadoGrupo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_AsignadoAgente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Asignado As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
