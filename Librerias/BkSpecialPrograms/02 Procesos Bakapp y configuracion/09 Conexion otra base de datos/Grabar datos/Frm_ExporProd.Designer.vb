<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ExporProd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ExporProd))
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Listas = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Bodegas = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Listas = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Bodegas = New DevComponents.DotNetBar.ButtonX()
        Me.Chk_GrbProd_Nuevos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_GrbEnti_Nuevas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_GrbOCC_Nuevas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Lbl_Listas)
        Me.GroupPanel2.Controls.Add(Me.Lbl_Bodegas)
        Me.GroupPanel2.Controls.Add(Me.Btn_Listas)
        Me.GroupPanel2.Controls.Add(Me.Btn_Bodegas)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 41)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(311, 99)
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
        Me.GroupPanel2.TabIndex = 124
        Me.GroupPanel2.Text = "Grabar producto en"
        '
        'Lbl_Listas
        '
        Me.Lbl_Listas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Listas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Listas.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Listas.Location = New System.Drawing.Point(132, 43)
        Me.Lbl_Listas.Name = "Lbl_Listas"
        Me.Lbl_Listas.Size = New System.Drawing.Size(170, 23)
        Me.Lbl_Listas.TabIndex = 3
        Me.Lbl_Listas.Text = "Listas seleccionadas: 0"
        '
        'Lbl_Bodegas
        '
        Me.Lbl_Bodegas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Bodegas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Bodegas.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Bodegas.Location = New System.Drawing.Point(132, 14)
        Me.Lbl_Bodegas.Name = "Lbl_Bodegas"
        Me.Lbl_Bodegas.Size = New System.Drawing.Size(170, 23)
        Me.Lbl_Bodegas.TabIndex = 2
        Me.Lbl_Bodegas.Text = "Bodegas seleccionadas: 0"
        '
        'Btn_Listas
        '
        Me.Btn_Listas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Listas.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Listas.Location = New System.Drawing.Point(3, 43)
        Me.Btn_Listas.Name = "Btn_Listas"
        Me.Btn_Listas.Size = New System.Drawing.Size(123, 23)
        Me.Btn_Listas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Listas.TabIndex = 1
        Me.Btn_Listas.Text = "Listas de precio/costo"
        '
        'Btn_Bodegas
        '
        Me.Btn_Bodegas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Bodegas.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Bodegas.Location = New System.Drawing.Point(3, 14)
        Me.Btn_Bodegas.Name = "Btn_Bodegas"
        Me.Btn_Bodegas.Size = New System.Drawing.Size(123, 23)
        Me.Btn_Bodegas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Bodegas.TabIndex = 0
        Me.Btn_Bodegas.Text = "Bodegas"
        '
        'Chk_GrbProd_Nuevos
        '
        Me.Chk_GrbProd_Nuevos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_GrbProd_Nuevos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_GrbProd_Nuevos.CheckBoxImageChecked = CType(resources.GetObject("Chk_GrbProd_Nuevos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_GrbProd_Nuevos.ForeColor = System.Drawing.Color.Black
        Me.Chk_GrbProd_Nuevos.Location = New System.Drawing.Point(12, 12)
        Me.Chk_GrbProd_Nuevos.Name = "Chk_GrbProd_Nuevos"
        Me.Chk_GrbProd_Nuevos.Size = New System.Drawing.Size(293, 23)
        Me.Chk_GrbProd_Nuevos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_GrbProd_Nuevos.TabIndex = 125
        Me.Chk_GrbProd_Nuevos.Text = "Grabar nuevos productos"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 219)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(335, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 126
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
        Me.Btn_Grabar.Tooltip = "Procesar"
        '
        'Chk_GrbEnti_Nuevas
        '
        Me.Chk_GrbEnti_Nuevas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_GrbEnti_Nuevas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_GrbEnti_Nuevas.CheckBoxImageChecked = CType(resources.GetObject("Chk_GrbEnti_Nuevas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_GrbEnti_Nuevas.ForeColor = System.Drawing.Color.Black
        Me.Chk_GrbEnti_Nuevas.Location = New System.Drawing.Point(12, 146)
        Me.Chk_GrbEnti_Nuevas.Name = "Chk_GrbEnti_Nuevas"
        Me.Chk_GrbEnti_Nuevas.Size = New System.Drawing.Size(311, 23)
        Me.Chk_GrbEnti_Nuevas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_GrbEnti_Nuevas.TabIndex = 127
        Me.Chk_GrbEnti_Nuevas.Text = "Grabar Entidades"
        '
        'Chk_GrbOCC_Nuevas
        '
        Me.Chk_GrbOCC_Nuevas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_GrbOCC_Nuevas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_GrbOCC_Nuevas.CheckBoxImageChecked = CType(resources.GetObject("Chk_GrbOCC_Nuevas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_GrbOCC_Nuevas.ForeColor = System.Drawing.Color.Black
        Me.Chk_GrbOCC_Nuevas.Location = New System.Drawing.Point(12, 175)
        Me.Chk_GrbOCC_Nuevas.Name = "Chk_GrbOCC_Nuevas"
        Me.Chk_GrbOCC_Nuevas.Size = New System.Drawing.Size(311, 23)
        Me.Chk_GrbOCC_Nuevas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_GrbOCC_Nuevas.TabIndex = 128
        Me.Chk_GrbOCC_Nuevas.Text = "Grabar OCC en la otra empresa"
        '
        'Frm_ExporProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 260)
        Me.Controls.Add(Me.Chk_GrbOCC_Nuevas)
        Me.Controls.Add(Me.Chk_GrbEnti_Nuevas)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Chk_GrbProd_Nuevos)
        Me.Controls.Add(Me.GroupPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ExporProd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Grabaciones automáticas"
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_GrbProd_Nuevos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_GrbEnti_Nuevas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Lbl_Listas As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Bodegas As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Listas As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Bodegas As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Chk_GrbOCC_Nuevas As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
