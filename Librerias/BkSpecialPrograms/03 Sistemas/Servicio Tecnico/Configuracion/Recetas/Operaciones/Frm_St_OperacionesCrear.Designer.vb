<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_St_OperacionesCrear
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_St_OperacionesCrear))
        Me.Grupo_Presupuesto = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_CantMayor1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_CantUno = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Externa = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Interna = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Precio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX32 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Operacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_TienePrecio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Presupuesto.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grupo_Presupuesto
        '
        Me.Grupo_Presupuesto.BackColor = System.Drawing.Color.White
        Me.Grupo_Presupuesto.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Presupuesto.Controls.Add(Me.Chk_TienePrecio)
        Me.Grupo_Presupuesto.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Presupuesto.Controls.Add(Me.TableLayoutPanel6)
        Me.Grupo_Presupuesto.Controls.Add(Me.Txt_Precio)
        Me.Grupo_Presupuesto.Controls.Add(Me.LabelX32)
        Me.Grupo_Presupuesto.Controls.Add(Me.Txt_Operacion)
        Me.Grupo_Presupuesto.Controls.Add(Me.Txt_Descripcion)
        Me.Grupo_Presupuesto.Controls.Add(Me.LabelX1)
        Me.Grupo_Presupuesto.Controls.Add(Me.LabelX2)
        Me.Grupo_Presupuesto.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Presupuesto.Location = New System.Drawing.Point(12, 12)
        Me.Grupo_Presupuesto.Name = "Grupo_Presupuesto"
        Me.Grupo_Presupuesto.Size = New System.Drawing.Size(594, 153)
        '
        '
        '
        Me.Grupo_Presupuesto.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Presupuesto.Style.BackColorGradientAngle = 90
        Me.Grupo_Presupuesto.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Presupuesto.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderBottomWidth = 1
        Me.Grupo_Presupuesto.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Presupuesto.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderLeftWidth = 1
        Me.Grupo_Presupuesto.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderRightWidth = 1
        Me.Grupo_Presupuesto.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderTopWidth = 1
        Me.Grupo_Presupuesto.Style.CornerDiameter = 4
        Me.Grupo_Presupuesto.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Presupuesto.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Presupuesto.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Presupuesto.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Presupuesto.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Presupuesto.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Presupuesto.TabIndex = 100
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_CantMayor1, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_CantUno, 1, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 89)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(354, 25)
        Me.TableLayoutPanel1.TabIndex = 76
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 3)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(100, 19)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Cantidad reparar"
        '
        'Rdb_CantMayor1
        '
        Me.Rdb_CantMayor1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_CantMayor1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_CantMayor1.CheckBoxImageChecked = CType(resources.GetObject("Rdb_CantMayor1.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_CantMayor1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_CantMayor1.FocusCuesEnabled = False
        Me.Rdb_CantMayor1.ForeColor = System.Drawing.Color.Black
        Me.Rdb_CantMayor1.Location = New System.Drawing.Point(183, 3)
        Me.Rdb_CantMayor1.Name = "Rdb_CantMayor1"
        Me.Rdb_CantMayor1.Size = New System.Drawing.Size(168, 19)
        Me.Rdb_CantMayor1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_CantMayor1.TabIndex = 4
        Me.Rdb_CantMayor1.Text = "Varios (El operador decide)"
        '
        'Rdb_CantUno
        '
        Me.Rdb_CantUno.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_CantUno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_CantUno.CheckBoxImageChecked = CType(resources.GetObject("Rdb_CantUno.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_CantUno.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_CantUno.Checked = True
        Me.Rdb_CantUno.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_CantUno.CheckValue = "Y"
        Me.Rdb_CantUno.FocusCuesEnabled = False
        Me.Rdb_CantUno.ForeColor = System.Drawing.Color.Black
        Me.Rdb_CantUno.Location = New System.Drawing.Point(114, 3)
        Me.Rdb_CantUno.Name = "Rdb_CantUno"
        Me.Rdb_CantUno.Size = New System.Drawing.Size(63, 19)
        Me.Rdb_CantUno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_CantUno.TabIndex = 3
        Me.Rdb_CantUno.Text = "Uno"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel6.ColumnCount = 3
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.LabelX7, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Externa, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Rdb_Interna, 1, 0)
        Me.TableLayoutPanel6.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 117)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(354, 25)
        Me.TableLayoutPanel6.TabIndex = 75
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 3)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(100, 19)
        Me.LabelX7.TabIndex = 4
        Me.LabelX7.Text = "Tipo operación"
        '
        'Rdb_Externa
        '
        Me.Rdb_Externa.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Externa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Externa.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Externa.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Externa.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Externa.FocusCuesEnabled = False
        Me.Rdb_Externa.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Externa.Location = New System.Drawing.Point(183, 3)
        Me.Rdb_Externa.Name = "Rdb_Externa"
        Me.Rdb_Externa.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_Externa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Externa.TabIndex = 6
        Me.Rdb_Externa.Text = "Externa"
        '
        'Rdb_Interna
        '
        Me.Rdb_Interna.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Interna.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Interna.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Interna.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Interna.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Interna.Checked = True
        Me.Rdb_Interna.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Interna.CheckValue = "Y"
        Me.Rdb_Interna.FocusCuesEnabled = False
        Me.Rdb_Interna.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Interna.Location = New System.Drawing.Point(114, 3)
        Me.Rdb_Interna.Name = "Rdb_Interna"
        Me.Rdb_Interna.Size = New System.Drawing.Size(63, 19)
        Me.Rdb_Interna.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Interna.TabIndex = 5
        Me.Rdb_Interna.Text = "Interna"
        '
        'Txt_Precio
        '
        Me.Txt_Precio.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Precio.Border.Class = "TextBoxBorder"
        Me.Txt_Precio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Precio.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Precio.Enabled = False
        Me.Txt_Precio.ForeColor = System.Drawing.Color.Black
        Me.Txt_Precio.Location = New System.Drawing.Point(82, 61)
        Me.Txt_Precio.Name = "Txt_Precio"
        Me.Txt_Precio.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Precio.TabIndex = 2
        Me.Txt_Precio.Text = "0"
        Me.Txt_Precio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX32
        '
        Me.LabelX32.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX32.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX32.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX32.ForeColor = System.Drawing.Color.Black
        Me.LabelX32.Location = New System.Drawing.Point(3, 60)
        Me.LabelX32.Name = "LabelX32"
        Me.LabelX32.Size = New System.Drawing.Size(89, 23)
        Me.LabelX32.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX32.TabIndex = 74
        Me.LabelX32.Text = "Precio"
        '
        'Txt_Operacion
        '
        Me.Txt_Operacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Operacion.Border.Class = "TextBoxBorder"
        Me.Txt_Operacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Operacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Operacion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Operacion.Enabled = False
        Me.Txt_Operacion.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Operacion.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Operacion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Operacion.Location = New System.Drawing.Point(82, 3)
        Me.Txt_Operacion.MaxLength = 5
        Me.Txt_Operacion.Name = "Txt_Operacion"
        Me.Txt_Operacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Operacion.Size = New System.Drawing.Size(51, 22)
        Me.Txt_Operacion.TabIndex = 0
        Me.Txt_Operacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_Descripcion
        '
        Me.Txt_Descripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Descripcion.Border.Class = "TextBoxBorder"
        Me.Txt_Descripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Descripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Descripcion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Descripcion.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Descripcion.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Descripcion.Location = New System.Drawing.Point(82, 33)
        Me.Txt_Descripcion.MaxLength = 50
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Descripcion.Size = New System.Drawing.Size(503, 22)
        Me.Txt_Descripcion.TabIndex = 1
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 32)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(79, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 69
        Me.LabelX1.Text = "Descripción"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(51, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 64
        Me.LabelX2.Text = "Código"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar})
        Me.Bar2.Location = New System.Drawing.Point(0, 176)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(616, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 101
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar "
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Eliminar"
        Me.Btn_Eliminar.Visible = False
        '
        'Chk_TienePrecio
        '
        Me.Chk_TienePrecio.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_TienePrecio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_TienePrecio.CheckBoxImageChecked = CType(resources.GetObject("Chk_TienePrecio.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_TienePrecio.FocusCuesEnabled = False
        Me.Chk_TienePrecio.ForeColor = System.Drawing.Color.Black
        Me.Chk_TienePrecio.Location = New System.Drawing.Point(190, 61)
        Me.Chk_TienePrecio.Name = "Chk_TienePrecio"
        Me.Chk_TienePrecio.Size = New System.Drawing.Size(90, 22)
        Me.Chk_TienePrecio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_TienePrecio.TabIndex = 77
        Me.Chk_TienePrecio.TabStop = False
        Me.Chk_TienePrecio.Text = "Tiene precio"
        '
        'Frm_St_OperacionesCrear
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 217)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Grupo_Presupuesto)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_St_OperacionesCrear"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENCION DE OPERACION"
        Me.Grupo_Presupuesto.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grupo_Presupuesto As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Operacion As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Precio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX32 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Externa As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Interna As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_CantMayor1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_CantUno As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_TienePrecio As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
