<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Huella_Por_Usuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Huella_Por_Usuario))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Delete = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Salir = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Warning_H2 = New DevComponents.DotNetBar.Controls.WarningBox()
        Me.Warning_H1 = New DevComponents.DotNetBar.Controls.WarningBox()
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Lbl_Funcionario = New DevComponents.DotNetBar.LabelX()
        Me.Imagenes_16x16 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Delete, Me.Btn_Salir})
        Me.Bar1.Location = New System.Drawing.Point(0, 181)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(590, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 127
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Visible = False
        '
        'Btn_Delete
        '
        Me.Btn_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Delete.ForeColor = System.Drawing.Color.Black
        Me.Btn_Delete.Image = CType(resources.GetObject("Btn_Delete.Image"), System.Drawing.Image)
        Me.Btn_Delete.Name = "Btn_Delete"
        Me.Btn_Delete.Visible = False
        '
        'Btn_Salir
        '
        Me.Btn_Salir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Salir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Salir.Image = CType(resources.GetObject("Btn_Salir.Image"), System.Drawing.Image)
        Me.Btn_Salir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Tooltip = "Cancelar"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Warning_H2)
        Me.GroupPanel1.Controls.Add(Me.Warning_H1)
        Me.GroupPanel1.Controls.Add(Me.ReflectionImage1)
        Me.GroupPanel1.Controls.Add(Me.Lbl_Funcionario)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(564, 148)
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
        Me.GroupPanel1.TabIndex = 128
        Me.GroupPanel1.Text = "Huellas del funcionario"
        '
        'Warning_H2
        '
        Me.Warning_H2.BackColor = System.Drawing.Color.White
        Me.Warning_H2.CloseButtonVisible = False
        Me.Warning_H2.ForeColor = System.Drawing.Color.Black
        Me.Warning_H2.Image = CType(resources.GetObject("Warning_H2.Image"), System.Drawing.Image)
        Me.Warning_H2.Location = New System.Drawing.Point(3, 72)
        Me.Warning_H2.Name = "Warning_H2"
        Me.Warning_H2.Size = New System.Drawing.Size(427, 33)
        Me.Warning_H2.TabIndex = 135
        Me.Warning_H2.Tag = "2"
        Me.Warning_H2.Text = "<b>Warning Box</b> control with <i>text-markup</i> support."
        '
        'Warning_H1
        '
        Me.Warning_H1.BackColor = System.Drawing.Color.White
        Me.Warning_H1.CloseButtonVisible = False
        Me.Warning_H1.ForeColor = System.Drawing.Color.Black
        Me.Warning_H1.Image = CType(resources.GetObject("Warning_H1.Image"), System.Drawing.Image)
        Me.Warning_H1.Location = New System.Drawing.Point(3, 33)
        Me.Warning_H1.Name = "Warning_H1"
        Me.Warning_H1.Size = New System.Drawing.Size(427, 33)
        Me.Warning_H1.TabIndex = 134
        Me.Warning_H1.Tag = "1"
        Me.Warning_H1.Text = "<b>Existe huella</b> Huella Nro 1<i>huella nro 1</i> support."
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.Location = New System.Drawing.Point(452, 3)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(77, 131)
        Me.ReflectionImage1.TabIndex = 133
        '
        'Lbl_Funcionario
        '
        Me.Lbl_Funcionario.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Funcionario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Funcionario.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Funcionario.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Funcionario.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Funcionario.Name = "Lbl_Funcionario"
        Me.Lbl_Funcionario.Size = New System.Drawing.Size(552, 23)
        Me.Lbl_Funcionario.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Funcionario.TabIndex = 126
        Me.Lbl_Funcionario.Text = "Código: XXX - NOMBRE DEL FUNCIONARIO"
        '
        'Imagenes_16x16
        '
        Me.Imagenes_16x16.ImageStream = CType(resources.GetObject("Imagenes_16x16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_16x16.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_16x16.Images.SetKeyName(0, "warning.png")
        Me.Imagenes_16x16.Images.SetKeyName(1, "ok.png")
        Me.Imagenes_16x16.Images.SetKeyName(2, "cancel.png")
        Me.Imagenes_16x16.Images.SetKeyName(3, "delete_button_error.png")
        '
        'Frm_Huella_Por_Usuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 222)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Huella_Por_Usuario"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IDENTIFICADOR DE HUELLA POR USUARIO"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Salir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Funcionario As DevComponents.DotNetBar.LabelX
    Friend WithEvents Warning_H1 As DevComponents.DotNetBar.Controls.WarningBox
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Warning_H2 As DevComponents.DotNetBar.Controls.WarningBox
    Friend WithEvents Imagenes_16x16 As ImageList
    Public WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Delete As DevComponents.DotNetBar.ButtonItem
End Class
