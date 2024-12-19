<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Formulario_Diseno_Mapa_Crear_Sector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Formulario_Diseno_Mapa_Crear_Sector))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_EsCabecera = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Codigo_Sector = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Nombre_Sector = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_SoloUnaUbicacion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_OblConfimarUbic = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Chk_OblConfimarUbic)
        Me.GroupPanel1.Controls.Add(Me.Chk_SoloUnaUbicacion)
        Me.GroupPanel1.Controls.Add(Me.Chk_EsCabecera)
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(588, 120)
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
        Me.GroupPanel1.TabIndex = 94
        Me.GroupPanel1.Text = "Datos del sector/Pasillo/Estante/Vitrina..."
        '
        'Chk_EsCabecera
        '
        Me.Chk_EsCabecera.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_EsCabecera.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_EsCabecera.CheckBoxImageChecked = CType(resources.GetObject("Chk_EsCabecera.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_EsCabecera.FocusCuesEnabled = False
        Me.Chk_EsCabecera.ForeColor = System.Drawing.Color.Black
        Me.Chk_EsCabecera.Location = New System.Drawing.Point(5, 79)
        Me.Chk_EsCabecera.Name = "Chk_EsCabecera"
        Me.Chk_EsCabecera.Size = New System.Drawing.Size(100, 18)
        Me.Chk_EsCabecera.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_EsCabecera.TabIndex = 2
        Me.Chk_EsCabecera.Text = "Es Cabecera"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Txt_Codigo_Sector, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Txt_Nombre_Sector, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX7, 0, 1)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(5, 13)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(574, 60)
        Me.TableLayoutPanel2.TabIndex = 96
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 14)
        Me.LabelX1.TabIndex = 97
        Me.LabelX1.Text = "Código"
        '
        'Txt_Codigo_Sector
        '
        Me.Txt_Codigo_Sector.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Codigo_Sector.Border.Class = "TextBoxBorder"
        Me.Txt_Codigo_Sector.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Codigo_Sector.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Codigo_Sector.ForeColor = System.Drawing.Color.Black
        Me.Txt_Codigo_Sector.Location = New System.Drawing.Point(84, 3)
        Me.Txt_Codigo_Sector.Name = "Txt_Codigo_Sector"
        Me.Txt_Codigo_Sector.PreventEnterBeep = True
        Me.Txt_Codigo_Sector.Size = New System.Drawing.Size(129, 22)
        Me.Txt_Codigo_Sector.TabIndex = 0
        '
        'Txt_Nombre_Sector
        '
        Me.Txt_Nombre_Sector.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre_Sector.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre_Sector.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre_Sector.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre_Sector.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombre_Sector.Location = New System.Drawing.Point(84, 33)
        Me.Txt_Nombre_Sector.Name = "Txt_Nombre_Sector"
        Me.Txt_Nombre_Sector.PreventEnterBeep = True
        Me.Txt_Nombre_Sector.Size = New System.Drawing.Size(487, 22)
        Me.Txt_Nombre_Sector.TabIndex = 1
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 33)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(75, 14)
        Me.LabelX7.TabIndex = 2
        Me.LabelX7.Text = "Descripción"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 138)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(610, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 93
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
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
        'Chk_SoloUnaUbicacion
        '
        Me.Chk_SoloUnaUbicacion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_SoloUnaUbicacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_SoloUnaUbicacion.CheckBoxImageChecked = CType(resources.GetObject("Chk_SoloUnaUbicacion.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_SoloUnaUbicacion.FocusCuesEnabled = False
        Me.Chk_SoloUnaUbicacion.ForeColor = System.Drawing.Color.Black
        Me.Chk_SoloUnaUbicacion.Location = New System.Drawing.Point(89, 79)
        Me.Chk_SoloUnaUbicacion.Name = "Chk_SoloUnaUbicacion"
        Me.Chk_SoloUnaUbicacion.Size = New System.Drawing.Size(158, 18)
        Me.Chk_SoloUnaUbicacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_SoloUnaUbicacion.TabIndex = 97
        Me.Chk_SoloUnaUbicacion.Text = "Permite solo una ubicación"
        '
        'Chk_OblConfimarUbic
        '
        Me.Chk_OblConfimarUbic.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_OblConfimarUbic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_OblConfimarUbic.CheckBoxImageChecked = CType(resources.GetObject("Chk_OblConfimarUbic.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_OblConfimarUbic.FocusCuesEnabled = False
        Me.Chk_OblConfimarUbic.ForeColor = System.Drawing.Color.Black
        Me.Chk_OblConfimarUbic.Location = New System.Drawing.Point(248, 79)
        Me.Chk_OblConfimarUbic.Name = "Chk_OblConfimarUbic"
        Me.Chk_OblConfimarUbic.Size = New System.Drawing.Size(257, 18)
        Me.Chk_OblConfimarUbic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_OblConfimarUbic.TabIndex = 98
        Me.Chk_OblConfimarUbic.Text = "Obliga a confirmar ubicación diariamente"
        '
        'Frm_Formulario_Diseno_Mapa_Crear_Sector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 179)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Formulario_Diseno_Mapa_Crear_Sector"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sector"
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Nombre_Sector As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Codigo_Sector As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_EsCabecera As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_OblConfimarUbic As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_SoloUnaUbicacion As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
