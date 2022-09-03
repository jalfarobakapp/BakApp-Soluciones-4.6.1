<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Pagos_Agregar_Cte_Maeencta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Pagos_Agregar_Cte_Maeencta))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Rut = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Norut = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Grupo_Datos_CtaCte = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Buscar_Emisor = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_EMDP_Documento = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_CUDP_Nro_Cuenta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_SUEMDP_Sucursal = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.Grupo_Datos_CtaCte.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Aceptar})
        Me.Bar1.Location = New System.Drawing.Point(0, 250)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(456, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 40
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Text = "ACEPTAR"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_Rut)
        Me.GroupPanel1.Controls.Add(Me.Txt_Norut)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(10, 143)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(434, 95)
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
        Me.GroupPanel1.TabIndex = 41
        Me.GroupPanel1.Text = "Datos complementarios de la cuenta"
        '
        'Txt_Rut
        '
        Me.Txt_Rut.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Rut.Border.Class = "TextBoxBorder"
        Me.Txt_Rut.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Rut.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Rut.ForeColor = System.Drawing.Color.Black
        Me.Txt_Rut.Location = New System.Drawing.Point(65, 16)
        Me.Txt_Rut.MaxLength = 16
        Me.Txt_Rut.Name = "Txt_Rut"
        Me.Txt_Rut.PreventEnterBeep = True
        Me.Txt_Rut.Size = New System.Drawing.Size(121, 22)
        Me.Txt_Rut.TabIndex = 6
        Me.Txt_Rut.Text = " "
        '
        'Txt_Norut
        '
        Me.Txt_Norut.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Norut.Border.Class = "TextBoxBorder"
        Me.Txt_Norut.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Norut.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Norut.ForeColor = System.Drawing.Color.Black
        Me.Txt_Norut.Location = New System.Drawing.Point(65, 43)
        Me.Txt_Norut.MaxLength = 35
        Me.Txt_Norut.Name = "Txt_Norut"
        Me.Txt_Norut.PreventEnterBeep = True
        Me.Txt_Norut.Size = New System.Drawing.Size(355, 22)
        Me.Txt_Norut.TabIndex = 3
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 15)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(56, 20)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Rut"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 42)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(56, 20)
        Me.LabelX4.TabIndex = 5
        Me.LabelX4.Text = "Nombre"
        '
        'Grupo_Datos_CtaCte
        '
        Me.Grupo_Datos_CtaCte.BackColor = System.Drawing.Color.White
        Me.Grupo_Datos_CtaCte.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Datos_CtaCte.Controls.Add(Me.Btn_Buscar_Emisor)
        Me.Grupo_Datos_CtaCte.Controls.Add(Me.LabelX1)
        Me.Grupo_Datos_CtaCte.Controls.Add(Me.Txt_EMDP_Documento)
        Me.Grupo_Datos_CtaCte.Controls.Add(Me.Txt_CUDP_Nro_Cuenta)
        Me.Grupo_Datos_CtaCte.Controls.Add(Me.Txt_SUEMDP_Sucursal)
        Me.Grupo_Datos_CtaCte.Controls.Add(Me.LabelX2)
        Me.Grupo_Datos_CtaCte.Controls.Add(Me.LabelX5)
        Me.Grupo_Datos_CtaCte.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Datos_CtaCte.Location = New System.Drawing.Point(10, 12)
        Me.Grupo_Datos_CtaCte.Name = "Grupo_Datos_CtaCte"
        Me.Grupo_Datos_CtaCte.Size = New System.Drawing.Size(434, 115)
        '
        '
        '
        Me.Grupo_Datos_CtaCte.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Datos_CtaCte.Style.BackColorGradientAngle = 90
        Me.Grupo_Datos_CtaCte.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Datos_CtaCte.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Datos_CtaCte.Style.BorderBottomWidth = 1
        Me.Grupo_Datos_CtaCte.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Datos_CtaCte.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Datos_CtaCte.Style.BorderLeftWidth = 1
        Me.Grupo_Datos_CtaCte.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Datos_CtaCte.Style.BorderRightWidth = 1
        Me.Grupo_Datos_CtaCte.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Datos_CtaCte.Style.BorderTopWidth = 1
        Me.Grupo_Datos_CtaCte.Style.CornerDiameter = 4
        Me.Grupo_Datos_CtaCte.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Datos_CtaCte.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Datos_CtaCte.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Datos_CtaCte.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Datos_CtaCte.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Datos_CtaCte.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Datos_CtaCte.TabIndex = 42
        Me.Grupo_Datos_CtaCte.Text = "Datos de la cuenta"
        '
        'Btn_Buscar_Emisor
        '
        Me.Btn_Buscar_Emisor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Emisor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Emisor.Image = CType(resources.GetObject("Btn_Buscar_Emisor.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Emisor.Location = New System.Drawing.Point(395, 12)
        Me.Btn_Buscar_Emisor.Name = "Btn_Buscar_Emisor"
        Me.Btn_Buscar_Emisor.Size = New System.Drawing.Size(25, 21)
        Me.Btn_Buscar_Emisor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Emisor.TabIndex = 2
        Me.Btn_Buscar_Emisor.TabStop = False
        Me.Btn_Buscar_Emisor.Tooltip = "Buscar emisor"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 10)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(117, 20)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Emisor de documento"
        '
        'Txt_EMDP_Documento
        '
        Me.Txt_EMDP_Documento.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_EMDP_Documento.Border.Class = "TextBoxBorder"
        Me.Txt_EMDP_Documento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_EMDP_Documento.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_EMDP_Documento.ForeColor = System.Drawing.Color.Black
        Me.Txt_EMDP_Documento.Location = New System.Drawing.Point(154, 11)
        Me.Txt_EMDP_Documento.MaxLength = 16
        Me.Txt_EMDP_Documento.Name = "Txt_EMDP_Documento"
        Me.Txt_EMDP_Documento.PreventEnterBeep = True
        Me.Txt_EMDP_Documento.ReadOnly = True
        Me.Txt_EMDP_Documento.Size = New System.Drawing.Size(235, 22)
        Me.Txt_EMDP_Documento.TabIndex = 41
        Me.Txt_EMDP_Documento.TabStop = False
        Me.Txt_EMDP_Documento.Text = " "
        '
        'Txt_CUDP_Nro_Cuenta
        '
        Me.Txt_CUDP_Nro_Cuenta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CUDP_Nro_Cuenta.Border.Class = "TextBoxBorder"
        Me.Txt_CUDP_Nro_Cuenta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CUDP_Nro_Cuenta.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CUDP_Nro_Cuenta.ForeColor = System.Drawing.Color.Black
        Me.Txt_CUDP_Nro_Cuenta.Location = New System.Drawing.Point(154, 65)
        Me.Txt_CUDP_Nro_Cuenta.MaxLength = 16
        Me.Txt_CUDP_Nro_Cuenta.Name = "Txt_CUDP_Nro_Cuenta"
        Me.Txt_CUDP_Nro_Cuenta.PreventEnterBeep = True
        Me.Txt_CUDP_Nro_Cuenta.Size = New System.Drawing.Size(121, 22)
        Me.Txt_CUDP_Nro_Cuenta.TabIndex = 2
        Me.Txt_CUDP_Nro_Cuenta.Text = " "
        '
        'Txt_SUEMDP_Sucursal
        '
        Me.Txt_SUEMDP_Sucursal.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_SUEMDP_Sucursal.Border.Class = "TextBoxBorder"
        Me.Txt_SUEMDP_Sucursal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_SUEMDP_Sucursal.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_SUEMDP_Sucursal.ForeColor = System.Drawing.Color.Black
        Me.Txt_SUEMDP_Sucursal.Location = New System.Drawing.Point(154, 38)
        Me.Txt_SUEMDP_Sucursal.MaxLength = 3
        Me.Txt_SUEMDP_Sucursal.Name = "Txt_SUEMDP_Sucursal"
        Me.Txt_SUEMDP_Sucursal.PreventEnterBeep = True
        Me.Txt_SUEMDP_Sucursal.Size = New System.Drawing.Size(37, 22)
        Me.Txt_SUEMDP_Sucursal.TabIndex = 1
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 37)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(117, 20)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Sucursal"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 64)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(117, 20)
        Me.LabelX5.TabIndex = 4
        Me.LabelX5.Text = "Número de cuenta"
        '
        'Frm_Pagos_Agregar_Cte_Maeencta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 291)
        Me.Controls.Add(Me.Grupo_Datos_CtaCte)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Pagos_Agregar_Cte_Maeencta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NUEVA CUENTA PARA LA ENTIDAD"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.Grupo_Datos_CtaCte.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Norut As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_CUDP_Nro_Cuenta As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Btn_Buscar_Emisor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Public WithEvents Grupo_Datos_CtaCte As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Rut As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_EMDP_Documento As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_SUEMDP_Sucursal As DevComponents.DotNetBar.Controls.TextBoxX
End Class
