<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Patentes_rvm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Patentes_rvm))
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Input_AFabricacion = New DevComponents.Editors.IntegerInput()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Patente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Modelo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Marca = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_ModeloBusqueda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Input_AFabricacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Input_AFabricacion)
        Me.GroupPanel2.Controls.Add(Me.LabelX4)
        Me.GroupPanel2.Controls.Add(Me.Txt_Patente)
        Me.GroupPanel2.Controls.Add(Me.Txt_Modelo)
        Me.GroupPanel2.Controls.Add(Me.Txt_Marca)
        Me.GroupPanel2.Controls.Add(Me.Txt_ModeloBusqueda)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.LabelX3)
        Me.GroupPanel2.Controls.Add(Me.LabelX5)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 3)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(431, 183)
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
        Me.GroupPanel2.TabIndex = 165
        Me.GroupPanel2.Text = "Datos del funcionario"
        '
        'Input_AFabricacion
        '
        Me.Input_AFabricacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_AFabricacion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_AFabricacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_AFabricacion.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_AFabricacion.ForeColor = System.Drawing.Color.Black
        Me.Input_AFabricacion.Location = New System.Drawing.Point(107, 127)
        Me.Input_AFabricacion.MaxValue = 2023
        Me.Input_AFabricacion.MinValue = 1960
        Me.Input_AFabricacion.Name = "Input_AFabricacion"
        Me.Input_AFabricacion.ShowUpDown = True
        Me.Input_AFabricacion.Size = New System.Drawing.Size(88, 22)
        Me.Input_AFabricacion.TabIndex = 4
        Me.Input_AFabricacion.Value = 1960
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 9)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(67, 23)
        Me.LabelX4.TabIndex = 61
        Me.LabelX4.Text = "PATENTE"
        '
        'Txt_Patente
        '
        Me.Txt_Patente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Patente.Border.Class = "TextBoxBorder"
        Me.Txt_Patente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Patente.ButtonCustom.Image = CType(resources.GetObject("Txt_Patente.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Patente.ButtonCustom2.Image = CType(resources.GetObject("Txt_Patente.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Patente.ButtonCustom2.Visible = True
        Me.Txt_Patente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Patente.FocusHighlightColor = System.Drawing.Color.PaleTurquoise
        Me.Txt_Patente.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Txt_Patente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Patente.Location = New System.Drawing.Point(107, 12)
        Me.Txt_Patente.MaxLength = 6
        Me.Txt_Patente.Name = "Txt_Patente"
        Me.Txt_Patente.PreventEnterBeep = True
        Me.Txt_Patente.Size = New System.Drawing.Size(88, 22)
        Me.Txt_Patente.TabIndex = 0
        Me.Txt_Patente.Text = "WWWW99"
        Me.Txt_Patente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_Patente.WatermarkText = "Ingrese parte del código, descripción, familia, etc.. del producto a buscar"
        '
        'Txt_Modelo
        '
        Me.Txt_Modelo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Modelo.Border.Class = "TextBoxBorder"
        Me.Txt_Modelo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Modelo.ButtonCustom.Image = CType(resources.GetObject("Txt_Modelo.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Modelo.ButtonCustom2.Image = CType(resources.GetObject("Txt_Modelo.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Modelo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Modelo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Modelo.Location = New System.Drawing.Point(107, 70)
        Me.Txt_Modelo.Name = "Txt_Modelo"
        Me.Txt_Modelo.PreventEnterBeep = True
        Me.Txt_Modelo.Size = New System.Drawing.Size(304, 22)
        Me.Txt_Modelo.TabIndex = 2
        '
        'Txt_Marca
        '
        Me.Txt_Marca.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Marca.Border.Class = "TextBoxBorder"
        Me.Txt_Marca.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Marca.ButtonCustom.Image = CType(resources.GetObject("Txt_Marca.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Marca.ButtonCustom2.Image = CType(resources.GetObject("Txt_Marca.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Marca.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Marca.ForeColor = System.Drawing.Color.Black
        Me.Txt_Marca.Location = New System.Drawing.Point(107, 41)
        Me.Txt_Marca.Name = "Txt_Marca"
        Me.Txt_Marca.PreventEnterBeep = True
        Me.Txt_Marca.Size = New System.Drawing.Size(304, 22)
        Me.Txt_Marca.TabIndex = 1
        '
        'Txt_ModeloBusqueda
        '
        Me.Txt_ModeloBusqueda.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_ModeloBusqueda.Border.Class = "TextBoxBorder"
        Me.Txt_ModeloBusqueda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_ModeloBusqueda.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_ModeloBusqueda.ForeColor = System.Drawing.Color.Black
        Me.Txt_ModeloBusqueda.Location = New System.Drawing.Point(107, 99)
        Me.Txt_ModeloBusqueda.MaxLength = 30
        Me.Txt_ModeloBusqueda.Name = "Txt_ModeloBusqueda"
        Me.Txt_ModeloBusqueda.PreventEnterBeep = True
        Me.Txt_ModeloBusqueda.Size = New System.Drawing.Size(304, 22)
        Me.Txt_ModeloBusqueda.TabIndex = 3
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 96)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(106, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "MODELO SIMPLE"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 38)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(106, 23)
        Me.LabelX2.TabIndex = 63
        Me.LabelX2.Text = "MARCA"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 67)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(106, 23)
        Me.LabelX3.TabIndex = 64
        Me.LabelX3.Text = "MODELO"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 125)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(106, 23)
        Me.LabelX5.TabIndex = 66
        Me.LabelX5.Text = "AÑO"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar})
        Me.Bar2.Location = New System.Drawing.Point(0, 201)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(456, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 164
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
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
        Me.Btn_Eliminar.Tooltip = "Configuración de asistente de compra"
        '
        'Frm_Patentes_rvm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 242)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Patentes_rvm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENCION DE PATENTE RVM"
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Input_AFabricacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_PorcComision As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Chk_TieneSC As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_QuitarEntExcluidas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_Modelo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Marca As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Rdb_VentasXVendedores As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_VentasXSucursal As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_VentasXEmpresa As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_MisVentas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_ModeloBusqueda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Patente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_AFabricacion As DevComponents.Editors.IntegerInput
End Class
