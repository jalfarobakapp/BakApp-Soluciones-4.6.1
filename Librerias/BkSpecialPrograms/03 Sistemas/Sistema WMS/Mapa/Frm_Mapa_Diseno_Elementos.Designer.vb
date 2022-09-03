<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Mapa_Diseno_Elementos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Mapa_Diseno_Elementos))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.SL_h = New DevComponents.DotNetBar.Controls.Slider()
        Me.SL_w = New DevComponents.DotNetBar.Controls.Slider()
        Me.Input_Alto_Y = New DevComponents.Editors.IntegerInput()
        Me.Input_Ancho_X = New DevComponents.Editors.IntegerInput()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.BtnRotar = New DevComponents.DotNetBar.ButtonX()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.buttonStyleCustom = New DevComponents.DotNetBar.ColorPickerDropDown()
        Me.Panel_Propiedades = New DevComponents.DotNetBar.AdvPropertyGrid()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.SL_y = New DevComponents.DotNetBar.Controls.Slider()
        Me.SL_x = New DevComponents.DotNetBar.Controls.Slider()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Input_Alto_Y, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Ancho_X, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Panel_Propiedades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnAceptar})
        Me.Bar1.Location = New System.Drawing.Point(0, 530)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(491, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 89
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAceptar.ForeColor = System.Drawing.Color.Black
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.Tooltip = "Exportar a excel"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.SL_h)
        Me.GroupPanel2.Controls.Add(Me.SL_w)
        Me.GroupPanel2.Controls.Add(Me.Input_Alto_Y)
        Me.GroupPanel2.Controls.Add(Me.Input_Ancho_X)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(195, 214)
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
        Me.GroupPanel2.TabIndex = 91
        Me.GroupPanel2.Text = "Medidas en Centimetros"
        '
        'SL_h
        '
        Me.SL_h.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.SL_h.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SL_h.ForeColor = System.Drawing.Color.Black
        Me.SL_h.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.SL_h.LabelWidth = 10
        Me.SL_h.Location = New System.Drawing.Point(42, 155)
        Me.SL_h.Name = "SL_h"
        Me.SL_h.Size = New System.Drawing.Size(144, 23)
        Me.SL_h.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.SL_h.TabIndex = 2
        Me.SL_h.Text = "X"
        Me.SL_h.TrackMarker = False
        Me.SL_h.Value = 0
        '
        'SL_w
        '
        Me.SL_w.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.SL_w.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SL_w.ForeColor = System.Drawing.Color.Black
        Me.SL_w.LabelWidth = 10
        Me.SL_w.Location = New System.Drawing.Point(3, 61)
        Me.SL_w.Name = "SL_w"
        Me.SL_w.Size = New System.Drawing.Size(42, 127)
        Me.SL_w.SliderOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.SL_w.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.SL_w.TabIndex = 3
        Me.SL_w.Text = "Y"
        Me.SL_w.Value = 0
        '
        'Input_Alto_Y
        '
        Me.Input_Alto_Y.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Alto_Y.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Alto_Y.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Alto_Y.ButtonClear.Visible = True
        Me.Input_Alto_Y.FocusHighlightEnabled = True
        Me.Input_Alto_Y.ForeColor = System.Drawing.Color.Black
        Me.Input_Alto_Y.Location = New System.Drawing.Point(83, 33)
        Me.Input_Alto_Y.Name = "Input_Alto_Y"
        Me.Input_Alto_Y.ShowUpDown = True
        Me.Input_Alto_Y.Size = New System.Drawing.Size(100, 22)
        Me.Input_Alto_Y.TabIndex = 101
        Me.Input_Alto_Y.Value = 7
        '
        'Input_Ancho_X
        '
        Me.Input_Ancho_X.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Ancho_X.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Ancho_X.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Ancho_X.ButtonClear.Visible = True
        Me.Input_Ancho_X.FocusHighlightEnabled = True
        Me.Input_Ancho_X.ForeColor = System.Drawing.Color.Black
        Me.Input_Ancho_X.Location = New System.Drawing.Point(83, 7)
        Me.Input_Ancho_X.Name = "Input_Ancho_X"
        Me.Input_Ancho_X.ShowUpDown = True
        Me.Input_Ancho_X.Size = New System.Drawing.Size(100, 22)
        Me.Input_Ancho_X.TabIndex = 100
        Me.Input_Ancho_X.Value = 120
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 31)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(74, 24)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Alto (Y)"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 7)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(74, 24)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Ancho (X)"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.BtnRotar)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 232)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(195, 90)
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
        Me.GroupPanel1.TabIndex = 92
        Me.GroupPanel1.Text = "Horientación"
        '
        'BtnRotar
        '
        Me.BtnRotar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnRotar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnRotar.Image = CType(resources.GetObject("BtnRotar.Image"), System.Drawing.Image)
        Me.BtnRotar.Location = New System.Drawing.Point(12, 15)
        Me.BtnRotar.Name = "BtnRotar"
        Me.BtnRotar.Size = New System.Drawing.Size(171, 46)
        Me.BtnRotar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnRotar.TabIndex = 98
        Me.BtnRotar.Text = "Rotar"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "document_lanscape.png")
        Me.ImageList1.Images.SetKeyName(1, "document.png")
        '
        'buttonStyleCustom
        '
        Me.buttonStyleCustom.BeginGroup = True
        Me.buttonStyleCustom.Name = "buttonStyleCustom"
        Me.buttonStyleCustom.Text = "Colores personalizados"
        Me.buttonStyleCustom.Tooltip = "Custom color scheme is created based on currently selected color table. Try selec" &
    "ting Silver or Blue color table and then creating custom color scheme."
        '
        'Panel_Propiedades
        '
        Me.Panel_Propiedades.BackColor = System.Drawing.Color.White
        Me.Panel_Propiedades.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel_Propiedades.ForeColor = System.Drawing.Color.Black
        Me.Panel_Propiedades.GridLinesColor = System.Drawing.Color.WhiteSmoke
        Me.Panel_Propiedades.Location = New System.Drawing.Point(220, 0)
        Me.Panel_Propiedades.Name = "Panel_Propiedades"
        Me.Panel_Propiedades.Size = New System.Drawing.Size(271, 530)
        Me.Panel_Propiedades.TabIndex = 97
        Me.Panel_Propiedades.Text = "advPropertyGrid1"
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.SL_y)
        Me.GroupPanel4.Controls.Add(Me.SL_x)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(12, 328)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(195, 185)
        '
        '
        '
        Me.GroupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel4.Style.BackColorGradientAngle = 90
        Me.GroupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderBottomWidth = 1
        Me.GroupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderLeftWidth = 1
        Me.GroupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderRightWidth = 1
        Me.GroupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderTopWidth = 1
        Me.GroupPanel4.Style.CornerDiameter = 4
        Me.GroupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel4.TabIndex = 99
        Me.GroupPanel4.Text = "Ubicación objeto"
        '
        'SL_y
        '
        Me.SL_y.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.SL_y.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SL_y.ForeColor = System.Drawing.Color.Black
        Me.SL_y.LabelWidth = 10
        Me.SL_y.Location = New System.Drawing.Point(3, 3)
        Me.SL_y.Name = "SL_y"
        Me.SL_y.Size = New System.Drawing.Size(42, 156)
        Me.SL_y.SliderOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.SL_y.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.SL_y.TabIndex = 3
        Me.SL_y.Text = "Y"
        Me.SL_y.Value = 0
        '
        'SL_x
        '
        Me.SL_x.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.SL_x.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SL_x.ForeColor = System.Drawing.Color.Black
        Me.SL_x.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.SL_x.LabelWidth = 10
        Me.SL_x.Location = New System.Drawing.Point(51, 136)
        Me.SL_x.Name = "SL_x"
        Me.SL_x.Size = New System.Drawing.Size(132, 23)
        Me.SL_x.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.SL_x.TabIndex = 2
        Me.SL_x.Text = "X"
        Me.SL_x.TrackMarker = False
        Me.SL_x.Value = 0
        '
        'Frm_Mapa_Diseno_Elementos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 571)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.Panel_Propiedades)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Mapa_Diseno_Elementos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.TopMost = True
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Input_Alto_Y, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Ancho_X, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Panel_Propiedades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Private WithEvents buttonStyleCustom As DevComponents.DotNetBar.ColorPickerDropDown
    Private WithEvents Panel_Propiedades As DevComponents.DotNetBar.AdvPropertyGrid
    Friend WithEvents BtnRotar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Private WithEvents Input_Alto_Y As DevComponents.Editors.IntegerInput
    Private WithEvents Input_Ancho_X As DevComponents.Editors.IntegerInput
    Friend WithEvents SL_y As DevComponents.DotNetBar.Controls.Slider
    Friend WithEvents SL_x As DevComponents.DotNetBar.Controls.Slider
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents SL_w As DevComponents.DotNetBar.Controls.Slider
    Friend WithEvents SL_h As DevComponents.DotNetBar.Controls.Slider
End Class
