<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_GRI_Ingreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_GRI_Ingreso))
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_ImprimirEtiquetas = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnConfiguracion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ingresar_GRI = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_FabMezcla = New DevComponents.DotNetBar.ButtonX()
        Me.Metro_Bar_Color = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Estatus = New DevComponents.DotNetBar.LabelItem()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.ReflectionImage1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ReflectionImage1.Location = New System.Drawing.Point(16, 271)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(519, 101)
        Me.ReflectionImage1.TabIndex = 34
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_ImprimirEtiquetas, Me.BtnConfiguracion})
        Me.Bar1.Location = New System.Drawing.Point(0, 392)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(547, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 33
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_ImprimirEtiquetas
        '
        Me.Btn_ImprimirEtiquetas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ImprimirEtiquetas.ForeColor = System.Drawing.Color.Black
        Me.Btn_ImprimirEtiquetas.Image = CType(resources.GetObject("Btn_ImprimirEtiquetas.Image"), System.Drawing.Image)
        Me.Btn_ImprimirEtiquetas.ImageAlt = CType(resources.GetObject("Btn_ImprimirEtiquetas.ImageAlt"), System.Drawing.Image)
        Me.Btn_ImprimirEtiquetas.Name = "Btn_ImprimirEtiquetas"
        Me.Btn_ImprimirEtiquetas.Tooltip = "Imprimir etiquetas"
        '
        'BtnConfiguracion
        '
        Me.BtnConfiguracion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnConfiguracion.ForeColor = System.Drawing.Color.Black
        Me.BtnConfiguracion.Image = CType(resources.GetObject("BtnConfiguracion.Image"), System.Drawing.Image)
        Me.BtnConfiguracion.ImageAlt = CType(resources.GetObject("BtnConfiguracion.ImageAlt"), System.Drawing.Image)
        Me.BtnConfiguracion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnConfiguracion.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnConfiguracion.Name = "BtnConfiguracion"
        Me.BtnConfiguracion.Tooltip = "Configuración de sistema"
        '
        'Btn_Ingresar_GRI
        '
        Me.Btn_Ingresar_GRI.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Ingresar_GRI.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Ingresar_GRI.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Ingresar_GRI.Image = CType(resources.GetObject("Btn_Ingresar_GRI.Image"), System.Drawing.Image)
        Me.Btn_Ingresar_GRI.ImageAlt = CType(resources.GetObject("Btn_Ingresar_GRI.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ingresar_GRI.Location = New System.Drawing.Point(64, 40)
        Me.Btn_Ingresar_GRI.Name = "Btn_Ingresar_GRI"
        Me.Btn_Ingresar_GRI.Size = New System.Drawing.Size(411, 138)
        Me.Btn_Ingresar_GRI.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Ingresar_GRI.TabIndex = 32
        Me.Btn_Ingresar_GRI.Text = "<b>INGRESAR PRODUCTOS</b><br/> " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<b>FABRICADOS A BODEGA</b>"
        '
        'Btn_FabMezcla
        '
        Me.Btn_FabMezcla.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_FabMezcla.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_FabMezcla.Enabled = False
        Me.Btn_FabMezcla.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_FabMezcla.Image = CType(resources.GetObject("Btn_FabMezcla.Image"), System.Drawing.Image)
        Me.Btn_FabMezcla.ImageAlt = CType(resources.GetObject("Btn_FabMezcla.ImageAlt"), System.Drawing.Image)
        Me.Btn_FabMezcla.Location = New System.Drawing.Point(64, 184)
        Me.Btn_FabMezcla.Name = "Btn_FabMezcla"
        Me.Btn_FabMezcla.Size = New System.Drawing.Size(411, 81)
        Me.Btn_FabMezcla.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_FabMezcla.TabIndex = 35
        Me.Btn_FabMezcla.Text = "<b>FABRICAR MEZCLAS</b>"
        Me.Btn_FabMezcla.Visible = False
        '
        'Metro_Bar_Color
        '
        Me.Metro_Bar_Color.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Metro_Bar_Color.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Metro_Bar_Color.ContainerControlProcessDialogKey = True
        Me.Metro_Bar_Color.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Metro_Bar_Color.DragDropSupport = True
        Me.Metro_Bar_Color.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Metro_Bar_Color.ForeColor = System.Drawing.Color.Black
        Me.Metro_Bar_Color.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Estatus})
        Me.Metro_Bar_Color.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Metro_Bar_Color.Location = New System.Drawing.Point(0, 433)
        Me.Metro_Bar_Color.Name = "Metro_Bar_Color"
        Me.Metro_Bar_Color.Size = New System.Drawing.Size(547, 22)
        Me.Metro_Bar_Color.TabIndex = 72
        Me.Metro_Bar_Color.Text = "MetroStatusBar1"
        '
        'Lbl_Estatus
        '
        Me.Lbl_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estatus.Name = "Lbl_Estatus"
        Me.Lbl_Estatus.Text = "LabelItem2"
        '
        'Frm_GRI_Ingreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 455)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Metro_Bar_Color)
        Me.Controls.Add(Me.Btn_FabMezcla)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.Btn_Ingresar_GRI)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_GRI_Ingreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INGRESO DE DATOS DE FABRICACION"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Ingresar_GRI As DevComponents.DotNetBar.ButtonX
    Public WithEvents Btn_ImprimirEtiquetas As DevComponents.DotNetBar.ButtonItem
    Public WithEvents BtnConfiguracion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_FabMezcla As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Metro_Bar_Color As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Estatus As DevComponents.DotNetBar.LabelItem
End Class
