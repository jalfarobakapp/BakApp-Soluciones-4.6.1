<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Dem_Imprimir_Conf
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Dem_Imprimir_Conf))
        Me.Btn_Filtro_Doc_Impresion_X_Usuario = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Input_SegundosImpresion = New DevComponents.Editors.IntegerInput()
        Me.Chk_ImprimirDocumentos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Filtro_Doc_Impresion = New DevComponents.DotNetBar.ButtonX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_ImprimirPicking = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Ejecutar_Automaticamente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        CType(Me.Input_SegundosImpresion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Filtro_Doc_Impresion_X_Usuario
        '
        Me.Btn_Filtro_Doc_Impresion_X_Usuario.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Filtro_Doc_Impresion_X_Usuario.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Filtro_Doc_Impresion_X_Usuario.Image = CType(resources.GetObject("Btn_Filtro_Doc_Impresion_X_Usuario.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Doc_Impresion_X_Usuario.Location = New System.Drawing.Point(243, 19)
        Me.Btn_Filtro_Doc_Impresion_X_Usuario.Name = "Btn_Filtro_Doc_Impresion_X_Usuario"
        Me.Btn_Filtro_Doc_Impresion_X_Usuario.Size = New System.Drawing.Size(49, 19)
        Me.Btn_Filtro_Doc_Impresion_X_Usuario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Filtro_Doc_Impresion_X_Usuario.TabIndex = 131
        Me.Btn_Filtro_Doc_Impresion_X_Usuario.Tooltip = "Configurar documentos"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(13, 69)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(91, 19)
        Me.LabelX3.TabIndex = 128
        Me.LabelX3.Text = "Se imprime cada"
        '
        'Input_SegundosImpresion
        '
        Me.Input_SegundosImpresion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_SegundosImpresion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_SegundosImpresion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_SegundosImpresion.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_SegundosImpresion.ForeColor = System.Drawing.Color.Black
        Me.Input_SegundosImpresion.Location = New System.Drawing.Point(110, 66)
        Me.Input_SegundosImpresion.MaxValue = 10
        Me.Input_SegundosImpresion.MinValue = 3
        Me.Input_SegundosImpresion.Name = "Input_SegundosImpresion"
        Me.Input_SegundosImpresion.ShowUpDown = True
        Me.Input_SegundosImpresion.Size = New System.Drawing.Size(43, 22)
        Me.Input_SegundosImpresion.TabIndex = 127
        Me.Input_SegundosImpresion.Value = 3
        '
        'Chk_ImprimirDocumentos
        '
        Me.Chk_ImprimirDocumentos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_ImprimirDocumentos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ImprimirDocumentos.FocusCuesEnabled = False
        Me.Chk_ImprimirDocumentos.ForeColor = System.Drawing.Color.Black
        Me.Chk_ImprimirDocumentos.Location = New System.Drawing.Point(12, 19)
        Me.Chk_ImprimirDocumentos.Name = "Chk_ImprimirDocumentos"
        Me.Chk_ImprimirDocumentos.Size = New System.Drawing.Size(170, 19)
        Me.Chk_ImprimirDocumentos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ImprimirDocumentos.TabIndex = 126
        Me.Chk_ImprimirDocumentos.Text = "Monitoreo Cola Impresión"
        '
        'Btn_Filtro_Doc_Impresion
        '
        Me.Btn_Filtro_Doc_Impresion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Filtro_Doc_Impresion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Filtro_Doc_Impresion.Image = CType(resources.GetObject("Btn_Filtro_Doc_Impresion.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Doc_Impresion.Location = New System.Drawing.Point(188, 19)
        Me.Btn_Filtro_Doc_Impresion.Name = "Btn_Filtro_Doc_Impresion"
        Me.Btn_Filtro_Doc_Impresion.Size = New System.Drawing.Size(49, 19)
        Me.Btn_Filtro_Doc_Impresion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Filtro_Doc_Impresion.TabIndex = 130
        Me.Btn_Filtro_Doc_Impresion.Tooltip = "Configurar documentos"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 125)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(377, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 132
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
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(159, 69)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(58, 19)
        Me.LabelX1.TabIndex = 133
        Me.LabelX1.Text = "Segundos"
        '
        'Chk_ImprimirPicking
        '
        Me.Chk_ImprimirPicking.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_ImprimirPicking.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ImprimirPicking.FocusCuesEnabled = False
        Me.Chk_ImprimirPicking.ForeColor = System.Drawing.Color.Black
        Me.Chk_ImprimirPicking.Location = New System.Drawing.Point(12, 44)
        Me.Chk_ImprimirPicking.Name = "Chk_ImprimirPicking"
        Me.Chk_ImprimirPicking.Size = New System.Drawing.Size(170, 19)
        Me.Chk_ImprimirPicking.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ImprimirPicking.TabIndex = 135
        Me.Chk_ImprimirPicking.Text = "Monitoreo Cola Impresión"
        '
        'Chk_Ejecutar_Automaticamente
        '
        Me.Chk_Ejecutar_Automaticamente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Chk_Ejecutar_Automaticamente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Ejecutar_Automaticamente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Ejecutar_Automaticamente.CheckBoxImageChecked = CType(resources.GetObject("Chk_Ejecutar_Automaticamente.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Ejecutar_Automaticamente.FocusCuesEnabled = False
        Me.Chk_Ejecutar_Automaticamente.ForeColor = System.Drawing.Color.Black
        Me.Chk_Ejecutar_Automaticamente.Location = New System.Drawing.Point(12, 96)
        Me.Chk_Ejecutar_Automaticamente.Name = "Chk_Ejecutar_Automaticamente"
        Me.Chk_Ejecutar_Automaticamente.Size = New System.Drawing.Size(279, 23)
        Me.Chk_Ejecutar_Automaticamente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Ejecutar_Automaticamente.TabIndex = 136
        Me.Chk_Ejecutar_Automaticamente.Text = "Ejecutar automáticamente al abrir el sistema" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'ReflectionImage1
        '
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.Location = New System.Drawing.Point(309, 19)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(56, 70)
        Me.ReflectionImage1.TabIndex = 137
        '
        'Frm_Dem_Imprimir_Conf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 166)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.Chk_Ejecutar_Automaticamente)
        Me.Controls.Add(Me.Chk_ImprimirPicking)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Btn_Filtro_Doc_Impresion_X_Usuario)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.Input_SegundosImpresion)
        Me.Controls.Add(Me.Chk_ImprimirDocumentos)
        Me.Controls.Add(Me.Btn_Filtro_Doc_Impresion)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Dem_Imprimir_Conf"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONFIGURACION DE DIABLITO DE IMPRESION"
        CType(Me.Input_SegundosImpresion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Btn_Filtro_Doc_Impresion_X_Usuario As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_SegundosImpresion As DevComponents.Editors.IntegerInput
    Friend WithEvents Chk_ImprimirDocumentos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Filtro_Doc_Impresion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_ImprimirPicking As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Ejecutar_Automaticamente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
End Class
