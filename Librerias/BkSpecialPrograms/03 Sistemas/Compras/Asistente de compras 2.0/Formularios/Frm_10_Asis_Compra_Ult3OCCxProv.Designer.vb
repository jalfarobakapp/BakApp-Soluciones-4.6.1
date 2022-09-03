<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_10_Asis_Compra_Ult3OCCxProv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_10_Asis_Compra_Ult3OCCxProv))
        Me.BtnEntidadesExcluidas = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Incluir_Ent_Excluidas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ProgressBarX1 = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Procesar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_EntExcluidas = New DevComponents.DotNetBar.ButtonItem()
        Me.Input_MesesCP = New DevComponents.Editors.IntegerInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Input_UltDocumentosCP = New DevComponents.Editors.IntegerInput()
        Me.Tiempo_Accion_Automatica = New System.Windows.Forms.Timer(Me.components)
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_MesesCP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_UltDocumentosCP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnEntidadesExcluidas
        '
        Me.BtnEntidadesExcluidas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnEntidadesExcluidas.ForeColor = System.Drawing.Color.Black
        Me.BtnEntidadesExcluidas.Image = CType(resources.GetObject("BtnEntidadesExcluidas.Image"), System.Drawing.Image)
        Me.BtnEntidadesExcluidas.Name = "BtnEntidadesExcluidas"
        Me.BtnEntidadesExcluidas.Text = "Entidades excluidas"
        Me.BtnEntidadesExcluidas.Visible = False
        '
        'Chk_Incluir_Ent_Excluidas
        '
        Me.Chk_Incluir_Ent_Excluidas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Incluir_Ent_Excluidas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Incluir_Ent_Excluidas.ForeColor = System.Drawing.Color.Black
        Me.Chk_Incluir_Ent_Excluidas.Location = New System.Drawing.Point(12, 138)
        Me.Chk_Incluir_Ent_Excluidas.Name = "Chk_Incluir_Ent_Excluidas"
        Me.Chk_Incluir_Ent_Excluidas.Size = New System.Drawing.Size(524, 23)
        Me.Chk_Incluir_Ent_Excluidas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Incluir_Ent_Excluidas.TabIndex = 116
        Me.Chk_Incluir_Ent_Excluidas.Text = "Incluir los proveedores que estan en entidades excluidas"
        Me.Chk_Incluir_Ent_Excluidas.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Input_UltDocumentosCP)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.Input_MesesCP)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 3)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(524, 100)
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
        Me.GroupPanel1.TabIndex = 115
        Me.GroupPanel1.Text = "Fecha de tope para seleccionar proveedor"
        '
        'ProgressBarX1
        '
        Me.ProgressBarX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ProgressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBarX1.ForeColor = System.Drawing.Color.Black
        Me.ProgressBarX1.Location = New System.Drawing.Point(12, 109)
        Me.ProgressBarX1.Name = "ProgressBarX1"
        Me.ProgressBarX1.Size = New System.Drawing.Size(524, 23)
        Me.ProgressBarX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.ProgressBarX1.TabIndex = 114
        Me.ProgressBarX1.Text = "0%"
        Me.ProgressBarX1.TextVisible = True
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Procesar, Me.Btn_EntExcluidas})
        Me.Bar1.Location = New System.Drawing.Point(0, 149)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(544, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 113
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Procesar
        '
        Me.Btn_Procesar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Procesar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Procesar.Image = CType(resources.GetObject("Btn_Procesar.Image"), System.Drawing.Image)
        Me.Btn_Procesar.Name = "Btn_Procesar"
        Me.Btn_Procesar.Text = "Procesar"
        '
        'Btn_EntExcluidas
        '
        Me.Btn_EntExcluidas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_EntExcluidas.ForeColor = System.Drawing.Color.Black
        Me.Btn_EntExcluidas.Image = CType(resources.GetObject("Btn_EntExcluidas.Image"), System.Drawing.Image)
        Me.Btn_EntExcluidas.Name = "Btn_EntExcluidas"
        Me.Btn_EntExcluidas.Tooltip = "Entidades excluidas"
        Me.Btn_EntExcluidas.Visible = False
        '
        'Input_MesesCP
        '
        '
        '
        '
        Me.Input_MesesCP.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_MesesCP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_MesesCP.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_MesesCP.Location = New System.Drawing.Point(3, 19)
        Me.Input_MesesCP.MaxValue = 12
        Me.Input_MesesCP.MinValue = 3
        Me.Input_MesesCP.Name = "Input_MesesCP"
        Me.Input_MesesCP.ShowUpDown = True
        Me.Input_MesesCP.Size = New System.Drawing.Size(49, 22)
        Me.Input_MesesCP.TabIndex = 0
        Me.Input_MesesCP.Value = 3
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(71, 19)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(207, 23)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Ultimas ordenes de compra a estudiar"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(71, 46)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(207, 23)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Ultimos pedidos"
        '
        'Input_UltDocumentosCP
        '
        '
        '
        '
        Me.Input_UltDocumentosCP.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_UltDocumentosCP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_UltDocumentosCP.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_UltDocumentosCP.Location = New System.Drawing.Point(3, 47)
        Me.Input_UltDocumentosCP.MaxValue = 6
        Me.Input_UltDocumentosCP.MinValue = 3
        Me.Input_UltDocumentosCP.Name = "Input_UltDocumentosCP"
        Me.Input_UltDocumentosCP.ShowUpDown = True
        Me.Input_UltDocumentosCP.Size = New System.Drawing.Size(49, 22)
        Me.Input_UltDocumentosCP.TabIndex = 2
        Me.Input_UltDocumentosCP.Value = 3
        '
        'Tiempo_Accion_Automatica
        '
        Me.Tiempo_Accion_Automatica.Enabled = True
        Me.Tiempo_Accion_Automatica.Interval = 2000
        '
        'Frm_10_Asis_Compra_Ult3OCCxProv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 190)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.ProgressBarX1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Chk_Incluir_Ent_Excluidas)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_10_Asis_Compra_Ult3OCCxProv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calculo de % de ultimas recepciones por proveedor"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_MesesCP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_UltDocumentosCP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnEntidadesExcluidas As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Chk_Incluir_Ent_Excluidas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_UltDocumentosCP As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_MesesCP As DevComponents.Editors.IntegerInput
    Friend WithEvents ProgressBarX1 As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Procesar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_EntExcluidas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Tiempo_Accion_Automatica As Timer
End Class
