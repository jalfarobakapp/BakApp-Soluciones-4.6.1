<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RegistrarEquipo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RegistrarEquipo))
        Me.LblNombreEquipo = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbTipoEstacion = New System.Windows.Forms.ComboBox
        Me.ReflectionImage2 = New DevComponents.DotNetBar.Controls.ReflectionImage
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnxSalir = New DevComponents.DotNetBar.ButtonItem
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxX2 = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Txt1 = New DevComponents.DotNetBar.Controls.TextBoxX
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblNombreEquipo
        '
        Me.LblNombreEquipo.AutoSize = True
        Me.LblNombreEquipo.BackColor = System.Drawing.Color.Transparent
        Me.LblNombreEquipo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombreEquipo.ForeColor = System.Drawing.Color.Black
        Me.LblNombreEquipo.Location = New System.Drawing.Point(153, 77)
        Me.LblNombreEquipo.Name = "LblNombreEquipo"
        Me.LblNombreEquipo.Size = New System.Drawing.Size(92, 13)
        Me.LblNombreEquipo.TabIndex = 4
        Me.LblNombreEquipo.Text = "Nombre_Equipo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Tipo de estación de trabajo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(3, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Llave de registro"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(3, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nombre del equipo"
        '
        'CmbTipoEstacion
        '
        Me.CmbTipoEstacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmbTipoEstacion.ForeColor = System.Drawing.Color.Black
        Me.CmbTipoEstacion.FormattingEnabled = True
        Me.CmbTipoEstacion.Location = New System.Drawing.Point(153, 142)
        Me.CmbTipoEstacion.Name = "CmbTipoEstacion"
        Me.CmbTipoEstacion.Size = New System.Drawing.Size(178, 21)
        Me.CmbTipoEstacion.TabIndex = 19
        '
        'ReflectionImage2
        '
        Me.ReflectionImage2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ReflectionImage2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage2.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage2.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage2.Image = Global.Funciones_BakApp.My.Resources.Resources.computer_key
        Me.ReflectionImage2.Location = New System.Drawing.Point(421, 75)
        Me.ReflectionImage2.Name = "ReflectionImage2"
        Me.ReflectionImage2.Size = New System.Drawing.Size(64, 88)
        Me.ReflectionImage2.TabIndex = 3
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnAceptar, Me.BtnxSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 200)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(506, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 5
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAceptar.ForeColor = System.Drawing.Color.Black
        Me.BtnAceptar.Image = Global.Funciones_BakApp.My.Resources.Resources.save
        Me.BtnAceptar.Name = "BtnAceptar"
        '
        'BtnxSalir
        '
        Me.BtnxSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnxSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnxSalir.Image = Global.Funciones_BakApp.My.Resources.Resources.button_rounded_red_delete
        Me.BtnxSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnxSalir.Name = "BtnxSalir"
        '
        'TextBoxX1
        '
        Me.TextBoxX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX1.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX1.FocusHighlightEnabled = True
        Me.TextBoxX1.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX1.Location = New System.Drawing.Point(103, 15)
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.PreventEnterBeep = True
        Me.TextBoxX1.ReadOnly = True
        Me.TextBoxX1.Size = New System.Drawing.Size(139, 22)
        Me.TextBoxX1.TabIndex = 30
        Me.TextBoxX1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Rut empresa"
        '
        'TextBoxX2
        '
        Me.TextBoxX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX2.Border.Class = "TextBoxBorder"
        Me.TextBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX2.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX2.FocusHighlightEnabled = True
        Me.TextBoxX2.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX2.Location = New System.Drawing.Point(103, 40)
        Me.TextBoxX2.Name = "TextBoxX2"
        Me.TextBoxX2.PreventEnterBeep = True
        Me.TextBoxX2.ReadOnly = True
        Me.TextBoxX2.Size = New System.Drawing.Size(382, 22)
        Me.TextBoxX2.TabIndex = 32
        Me.TextBoxX2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(3, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Nombre empresa"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel1.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt1)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.ReflectionImage2)
        Me.GroupPanel1.Controls.Add(Me.CmbTipoEstacion)
        Me.GroupPanel1.Controls.Add(Me.TextBoxX2)
        Me.GroupPanel1.Controls.Add(Me.Label3)
        Me.GroupPanel1.Controls.Add(Me.Label5)
        Me.GroupPanel1.Controls.Add(Me.Label4)
        Me.GroupPanel1.Controls.Add(Me.TextBoxX1)
        Me.GroupPanel1.Controls.Add(Me.Label2)
        Me.GroupPanel1.Controls.Add(Me.LblNombreEquipo)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(5, 9)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(494, 180)
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
        Me.GroupPanel1.TabIndex = 6
        '
        'Txt1
        '
        Me.Txt1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt1.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.[Double]
        Me.Txt1.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.[Double]
        Me.Txt1.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.[Double]
        Me.Txt1.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.[Double]
        Me.Txt1.Border.Class = "TextBoxBorder"
        Me.Txt1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt1.DisabledBackColor = System.Drawing.Color.White
        Me.Txt1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt1.ForeColor = System.Drawing.Color.Black
        Me.Txt1.Location = New System.Drawing.Point(153, 100)
        Me.Txt1.MaxLength = 50
        Me.Txt1.Name = "Txt1"
        Me.Txt1.PreventEnterBeep = True
        Me.Txt1.Size = New System.Drawing.Size(247, 25)
        Me.Txt1.TabIndex = 33
        Me.Txt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Frm_RegistrarEquipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 241)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_RegistrarEquipo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Identificación de estación de trabajo"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnxSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ReflectionImage2 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents CmbTipoEstacion As System.Windows.Forms.ComboBox
    Friend WithEvents LblNombreEquipo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxX2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt1 As DevComponents.DotNetBar.Controls.TextBoxX
End Class
