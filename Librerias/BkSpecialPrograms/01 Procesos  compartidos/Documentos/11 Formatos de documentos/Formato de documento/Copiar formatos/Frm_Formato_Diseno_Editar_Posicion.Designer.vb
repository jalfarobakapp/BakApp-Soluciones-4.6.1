<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Formato_Diseno_Editar_Posicion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Formato_Diseno_Editar_Posicion))
        Me.Grupo = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Y_Sumar_MM = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_X_Sumar_MM = New DevComponents.DotNetBar.LabelX()
        Me.Sumar_Y = New DevComponents.Editors.IntegerInput()
        Me.Sumar_X = New DevComponents.Editors.IntegerInput()
        Me.Input_Alto_Y = New DevComponents.Editors.IntegerInput()
        Me.Input_Ancho_X = New DevComponents.Editors.IntegerInput()
        Me.Lbl_Y = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_X = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo.SuspendLayout()
        CType(Me.Sumar_Y, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sumar_X, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Alto_Y, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Ancho_X, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grupo
        '
        Me.Grupo.BackColor = System.Drawing.Color.White
        Me.Grupo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo.Controls.Add(Me.Lbl_Y_Sumar_MM)
        Me.Grupo.Controls.Add(Me.Lbl_X_Sumar_MM)
        Me.Grupo.Controls.Add(Me.Sumar_Y)
        Me.Grupo.Controls.Add(Me.Sumar_X)
        Me.Grupo.Controls.Add(Me.Input_Alto_Y)
        Me.Grupo.Controls.Add(Me.Input_Ancho_X)
        Me.Grupo.Controls.Add(Me.Lbl_Y)
        Me.Grupo.Controls.Add(Me.Lbl_X)
        Me.Grupo.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo.Location = New System.Drawing.Point(12, 12)
        Me.Grupo.Name = "Grupo"
        Me.Grupo.Size = New System.Drawing.Size(287, 81)
        '
        '
        '
        Me.Grupo.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo.Style.BackColorGradientAngle = 90
        Me.Grupo.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo.Style.BorderBottomWidth = 1
        Me.Grupo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo.Style.BorderLeftWidth = 1
        Me.Grupo.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo.Style.BorderRightWidth = 1
        Me.Grupo.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo.Style.BorderTopWidth = 1
        Me.Grupo.Style.CornerDiameter = 4
        Me.Grupo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo.TabIndex = 92
        Me.Grupo.Text = "Medidas en puntos"
        '
        'Lbl_Y_Sumar_MM
        '
        Me.Lbl_Y_Sumar_MM.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Y_Sumar_MM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Y_Sumar_MM.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Y_Sumar_MM.Location = New System.Drawing.Point(171, 31)
        Me.Lbl_Y_Sumar_MM.Name = "Lbl_Y_Sumar_MM"
        Me.Lbl_Y_Sumar_MM.Size = New System.Drawing.Size(40, 24)
        Me.Lbl_Y_Sumar_MM.TabIndex = 105
        Me.Lbl_Y_Sumar_MM.Text = "Sumar"
        '
        'Lbl_X_Sumar_MM
        '
        Me.Lbl_X_Sumar_MM.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_X_Sumar_MM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_X_Sumar_MM.ForeColor = System.Drawing.Color.Black
        Me.Lbl_X_Sumar_MM.Location = New System.Drawing.Point(171, 7)
        Me.Lbl_X_Sumar_MM.Name = "Lbl_X_Sumar_MM"
        Me.Lbl_X_Sumar_MM.Size = New System.Drawing.Size(40, 24)
        Me.Lbl_X_Sumar_MM.TabIndex = 104
        Me.Lbl_X_Sumar_MM.Text = "Sumar"
        '
        'Sumar_Y
        '
        Me.Sumar_Y.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Sumar_Y.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Sumar_Y.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Sumar_Y.ButtonClear.Visible = True
        Me.Sumar_Y.FocusHighlightEnabled = True
        Me.Sumar_Y.ForeColor = System.Drawing.Color.Black
        Me.Sumar_Y.Location = New System.Drawing.Point(217, 33)
        Me.Sumar_Y.MaxValue = 100
        Me.Sumar_Y.Name = "Sumar_Y"
        Me.Sumar_Y.ShowUpDown = True
        Me.Sumar_Y.Size = New System.Drawing.Size(61, 22)
        Me.Sumar_Y.TabIndex = 103
        '
        'Sumar_X
        '
        Me.Sumar_X.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Sumar_X.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Sumar_X.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Sumar_X.ButtonClear.Visible = True
        Me.Sumar_X.FocusHighlightEnabled = True
        Me.Sumar_X.ForeColor = System.Drawing.Color.Black
        Me.Sumar_X.Location = New System.Drawing.Point(217, 7)
        Me.Sumar_X.MaxValue = 100
        Me.Sumar_X.Name = "Sumar_X"
        Me.Sumar_X.ShowUpDown = True
        Me.Sumar_X.Size = New System.Drawing.Size(61, 22)
        Me.Sumar_X.TabIndex = 102
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
        Me.Input_Alto_Y.Location = New System.Drawing.Point(72, 33)
        Me.Input_Alto_Y.Name = "Input_Alto_Y"
        Me.Input_Alto_Y.ShowUpDown = True
        Me.Input_Alto_Y.Size = New System.Drawing.Size(73, 22)
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
        Me.Input_Ancho_X.Location = New System.Drawing.Point(72, 7)
        Me.Input_Ancho_X.Name = "Input_Ancho_X"
        Me.Input_Ancho_X.ShowUpDown = True
        Me.Input_Ancho_X.Size = New System.Drawing.Size(73, 22)
        Me.Input_Ancho_X.TabIndex = 100
        Me.Input_Ancho_X.Value = 120
        '
        'Lbl_Y
        '
        Me.Lbl_Y.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Y.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Y.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Y.Location = New System.Drawing.Point(3, 31)
        Me.Lbl_Y.Name = "Lbl_Y"
        Me.Lbl_Y.Size = New System.Drawing.Size(74, 24)
        Me.Lbl_Y.TabIndex = 3
        Me.Lbl_Y.Text = "Fila (Y)"
        '
        'Lbl_X
        '
        Me.Lbl_X.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_X.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_X.ForeColor = System.Drawing.Color.Black
        Me.Lbl_X.Location = New System.Drawing.Point(3, 7)
        Me.Lbl_X.Name = "Lbl_X"
        Me.Lbl_X.Size = New System.Drawing.Size(74, 24)
        Me.Lbl_X.TabIndex = 1
        Me.Lbl_X.Text = "Columna (X)"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Aceptar})
        Me.Bar1.Location = New System.Drawing.Point(0, 104)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(308, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 93
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Text = "Aceptar"
        '
        'Frm_Formato_Diseno_Editar_Posicion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 145)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Grupo)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Formato_Diseno_Editar_Posicion"
        Me.ShowInTaskbar = False
        Me.Text = "Posicion"
        Me.Grupo.ResumeLayout(False)
        CType(Me.Sumar_Y, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Sumar_X, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Alto_Y, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Ancho_X, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents Input_Alto_Y As DevComponents.Editors.IntegerInput
    Private WithEvents Input_Ancho_X As DevComponents.Editors.IntegerInput
    Friend WithEvents Lbl_Y As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_X As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Y_Sumar_MM As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_X_Sumar_MM As DevComponents.DotNetBar.LabelX
    Private WithEvents Sumar_Y As DevComponents.Editors.IntegerInput
    Private WithEvents Sumar_X As DevComponents.Editors.IntegerInput
    Public WithEvents Grupo As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonItem
End Class
