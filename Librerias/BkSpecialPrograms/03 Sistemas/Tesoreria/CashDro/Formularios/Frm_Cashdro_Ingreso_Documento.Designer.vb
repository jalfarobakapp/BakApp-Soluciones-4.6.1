<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cashdro_Ingreso_Documento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cashdro_Ingreso_Documento))
        Me.Txt_Documento_Venta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.RfLbl_Informacion = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Tiempo_Label = New System.Windows.Forms.Timer(Me.components)
        Me.TouchKeyboard1 = New DevComponents.DotNetBar.Keyboard.TouchKeyboard()
        Me.Btn_Teclado = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Transbak_Pruebas = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Version = New DevComponents.DotNetBar.LabelItem()
        Me.Lbl_Datos_Ult_Venta = New DevComponents.DotNetBar.LabelItem()
        Me.RfImg_Flecha = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Rfl_Imagen = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Lbl_2 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_1 = New DevComponents.DotNetBar.LabelX()
        Me.Tiempo_Tocar_Pantalla = New System.Windows.Forms.Timer(Me.components)
        Me.PcImg_Dedo = New System.Windows.Forms.PictureBox()
        CType(Me.PcImg_Dedo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Txt_Documento_Venta
        '
        Me.Txt_Documento_Venta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Documento_Venta.Border.Class = "TextBoxBorder"
        Me.Txt_Documento_Venta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Documento_Venta.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Documento_Venta.ForeColor = System.Drawing.Color.Black
        Me.Txt_Documento_Venta.Location = New System.Drawing.Point(485, 498)
        Me.Txt_Documento_Venta.Name = "Txt_Documento_Venta"
        Me.Txt_Documento_Venta.PreventEnterBeep = True
        Me.Txt_Documento_Venta.Size = New System.Drawing.Size(132, 22)
        Me.Txt_Documento_Venta.TabIndex = 0
        Me.Txt_Documento_Venta.Visible = False
        '
        'CircularProgress1
        '
        Me.CircularProgress1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Location = New System.Drawing.Point(3, 12)
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.CircularProgress1.Size = New System.Drawing.Size(75, 23)
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress1.TabIndex = 1
        '
        'RfLbl_Informacion
        '
        Me.RfLbl_Informacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RfLbl_Informacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RfLbl_Informacion.ForeColor = System.Drawing.Color.Black
        Me.RfLbl_Informacion.Location = New System.Drawing.Point(47, 352)
        Me.RfLbl_Informacion.Name = "RfLbl_Informacion"
        Me.RfLbl_Informacion.Size = New System.Drawing.Size(942, 117)
        Me.RfLbl_Informacion.TabIndex = 2
        Me.RfLbl_Informacion.Text = "<b><font size=""+40""><font color=""#349FCE"">ACERQUE EL VALE AL LECTOR</font></font>" &
    "</b>"
        '
        'Tiempo_Label
        '
        Me.Tiempo_Label.Interval = 800
        '
        'TouchKeyboard1
        '
        Me.TouchKeyboard1.FloatingLocation = New System.Drawing.Point(0, 0)
        Me.TouchKeyboard1.FloatingSize = New System.Drawing.Size(740, 250)
        Me.TouchKeyboard1.Location = New System.Drawing.Point(0, 0)
        Me.TouchKeyboard1.Size = New System.Drawing.Size(740, 250)
        Me.TouchKeyboard1.Text = ""
        '
        'Btn_Teclado
        '
        Me.Btn_Teclado.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Teclado.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Teclado.Image = CType(resources.GetObject("Btn_Teclado.Image"), System.Drawing.Image)
        Me.Btn_Teclado.Location = New System.Drawing.Point(1054, 498)
        Me.Btn_Teclado.Name = "Btn_Teclado"
        Me.Btn_Teclado.Size = New System.Drawing.Size(40, 35)
        Me.Btn_Teclado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Teclado.TabIndex = 8
        '
        'Btn_Transbak_Pruebas
        '
        Me.Btn_Transbak_Pruebas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Transbak_Pruebas.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Transbak_Pruebas.Location = New System.Drawing.Point(3, 498)
        Me.Btn_Transbak_Pruebas.Name = "Btn_Transbak_Pruebas"
        Me.Btn_Transbak_Pruebas.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Transbak_Pruebas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Transbak_Pruebas.TabIndex = 41
        Me.Btn_Transbak_Pruebas.Text = "Transbank"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(84, 498)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 44
        Me.ButtonX1.Text = "Vuelto"
        Me.ButtonX1.Visible = False
        '
        'MetroStatusBar1
        '
        Me.MetroStatusBar1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.MetroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroStatusBar1.ContainerControlProcessDialogKey = True
        Me.MetroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MetroStatusBar1.DragDropSupport = True
        Me.MetroStatusBar1.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroStatusBar1.ForeColor = System.Drawing.Color.Black
        Me.MetroStatusBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Version, Me.Lbl_Datos_Ult_Venta})
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 539)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(1094, 22)
        Me.MetroStatusBar1.TabIndex = 45
        Me.MetroStatusBar1.Text = "MetroStatusBar1"
        '
        'Lbl_Version
        '
        Me.Lbl_Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Version.Name = "Lbl_Version"
        Me.Lbl_Version.Text = "Versión: 11111 - Pruebas: Efectivo,Notas de credito"
        '
        'Lbl_Datos_Ult_Venta
        '
        Me.Lbl_Datos_Ult_Venta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Datos_Ult_Venta.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Lbl_Datos_Ult_Venta.Name = "Lbl_Datos_Ult_Venta"
        Me.Lbl_Datos_Ult_Venta.Text = "Datos ult-venta"
        '
        'RfImg_Flecha
        '
        Me.RfImg_Flecha.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RfImg_Flecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RfImg_Flecha.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.RfImg_Flecha.ForeColor = System.Drawing.Color.Black
        Me.RfImg_Flecha.Image = CType(resources.GetObject("RfImg_Flecha.Image"), System.Drawing.Image)
        Me.RfImg_Flecha.Location = New System.Drawing.Point(985, 352)
        Me.RfImg_Flecha.Name = "RfImg_Flecha"
        Me.RfImg_Flecha.Size = New System.Drawing.Size(97, 130)
        Me.RfImg_Flecha.TabIndex = 47
        Me.RfImg_Flecha.Visible = False
        '
        'Rfl_Imagen
        '
        Me.Rfl_Imagen.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rfl_Imagen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rfl_Imagen.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Rfl_Imagen.ForeColor = System.Drawing.Color.Black
        Me.Rfl_Imagen.Image = CType(resources.GetObject("Rfl_Imagen.Image"), System.Drawing.Image)
        Me.Rfl_Imagen.Location = New System.Drawing.Point(328, 12)
        Me.Rfl_Imagen.Name = "Rfl_Imagen"
        Me.Rfl_Imagen.Size = New System.Drawing.Size(476, 314)
        Me.Rfl_Imagen.TabIndex = 48
        Me.Rfl_Imagen.Visible = False
        '
        'Lbl_2
        '
        Me.Lbl_2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_2.ForeColor = System.Drawing.Color.Black
        Me.Lbl_2.Location = New System.Drawing.Point(106, 126)
        Me.Lbl_2.Name = "Lbl_2"
        Me.Lbl_2.Size = New System.Drawing.Size(859, 127)
        Me.Lbl_2.TabIndex = 50
        Me.Lbl_2.Text = "<b><font size=""+45""><font color=""#349FCE"">PANTALLA PARA PAGAR</font></font></b>"
        '
        'Lbl_1
        '
        Me.Lbl_1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_1.ForeColor = System.Drawing.Color.Black
        Me.Lbl_1.Location = New System.Drawing.Point(84, 3)
        Me.Lbl_1.Name = "Lbl_1"
        Me.Lbl_1.Size = New System.Drawing.Size(948, 154)
        Me.Lbl_1.TabIndex = 49
        Me.Lbl_1.Text = "<b><font size=""+45""><font color=""#349FCE"">TOQUE EL CENTRO DE LA</font></font></b>" &
    ""
        '
        'Tiempo_Tocar_Pantalla
        '
        Me.Tiempo_Tocar_Pantalla.Enabled = True
        Me.Tiempo_Tocar_Pantalla.Interval = 1000
        '
        'PcImg_Dedo
        '
        Me.PcImg_Dedo.BackColor = System.Drawing.Color.White
        Me.PcImg_Dedo.ForeColor = System.Drawing.Color.Black
        Me.PcImg_Dedo.Image = CType(resources.GetObject("PcImg_Dedo.Image"), System.Drawing.Image)
        Me.PcImg_Dedo.Location = New System.Drawing.Point(451, 258)
        Me.PcImg_Dedo.Name = "PcImg_Dedo"
        Me.PcImg_Dedo.Size = New System.Drawing.Size(184, 234)
        Me.PcImg_Dedo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PcImg_Dedo.TabIndex = 51
        Me.PcImg_Dedo.TabStop = False
        '
        'Frm_Cashdro_Ingreso_Documento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1094, 561)
        Me.Controls.Add(Me.PcImg_Dedo)
        Me.Controls.Add(Me.Lbl_2)
        Me.Controls.Add(Me.Lbl_1)
        Me.Controls.Add(Me.Rfl_Imagen)
        Me.Controls.Add(Me.RfImg_Flecha)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.Btn_Transbak_Pruebas)
        Me.Controls.Add(Me.Btn_Teclado)
        Me.Controls.Add(Me.RfLbl_Informacion)
        Me.Controls.Add(Me.CircularProgress1)
        Me.Controls.Add(Me.Txt_Documento_Venta)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cashdro_Ingreso_Documento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PAGO EN CAJERO AUTOMATICO"
        CType(Me.PcImg_Dedo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Txt_Documento_Venta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents RfLbl_Informacion As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Tiempo_Label As System.Windows.Forms.Timer
    Friend WithEvents TouchKeyboard1 As DevComponents.DotNetBar.Keyboard.TouchKeyboard
    Friend WithEvents Btn_Teclado As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Transbak_Pruebas As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Version As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Lbl_Datos_Ult_Venta As DevComponents.DotNetBar.LabelItem
    Friend WithEvents RfImg_Flecha As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Rfl_Imagen As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Lbl_2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tiempo_Tocar_Pantalla As Timer
    Friend WithEvents PcImg_Dedo As PictureBox
End Class
