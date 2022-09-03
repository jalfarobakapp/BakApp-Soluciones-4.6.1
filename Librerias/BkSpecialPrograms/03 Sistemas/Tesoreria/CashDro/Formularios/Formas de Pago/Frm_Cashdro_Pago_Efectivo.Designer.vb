<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cashdro_Pago_Efectivo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cashdro_Pago_Efectivo))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Cancelar_Operacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Tiempo_Pago_Efectivo = New System.Windows.Forms.Timer(Me.components)
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Lbl_Total_A_Pagar = New DevComponents.DotNetBar.LabelX()
        Me.Pbox_01 = New System.Windows.Forms.PictureBox()
        Me.Pbox_02 = New System.Windows.Forms.PictureBox()
        Me.Pbox_03 = New System.Windows.Forms.PictureBox()
        Me.Lbl_Esperando = New DevComponents.DotNetBar.LabelX()
        Me.Tiempo_Flecha = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pbox_01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pbox_02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pbox_03, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Cancelar_Operacion})
        Me.Bar2.Location = New System.Drawing.Point(0, 473)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(398, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 32
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Cancelar_Operacion
        '
        Me.Btn_Cancelar_Operacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar_Operacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar_Operacion.Image = CType(resources.GetObject("Btn_Cancelar_Operacion.Image"), System.Drawing.Image)
        Me.Btn_Cancelar_Operacion.Name = "Btn_Cancelar_Operacion"
        Me.Btn_Cancelar_Operacion.Text = "CANCELAR OPERACION"
        '
        'Tiempo_Pago_Efectivo
        '
        Me.Tiempo_Pago_Efectivo.Interval = 1000
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 66)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(368, 56)
        Me.LabelX1.TabIndex = 33
        Me.LabelX1.Text = "<b>FAVOR INGRESAR PAGO EN CAJERO</b>"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(65, 106)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(256, 56)
        Me.LabelX2.TabIndex = 34
        Me.LabelX2.Text = "<b>(BILLETES Y MONEDAS)</b>"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.Location = New System.Drawing.Point(200, 180)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(165, 209)
        Me.ReflectionImage1.TabIndex = 35
        '
        'Lbl_Total_A_Pagar
        '
        Me.Lbl_Total_A_Pagar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Total_A_Pagar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Total_A_Pagar.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Total_A_Pagar.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Total_A_Pagar.Location = New System.Drawing.Point(22, -4)
        Me.Lbl_Total_A_Pagar.Name = "Lbl_Total_A_Pagar"
        Me.Lbl_Total_A_Pagar.Size = New System.Drawing.Size(364, 64)
        Me.Lbl_Total_A_Pagar.TabIndex = 36
        Me.Lbl_Total_A_Pagar.Text = "<b><font color=""#ED1C24"">TOTAL</font></b>  <b>$ 999.999.999</b>"
        '
        'Pbox_01
        '
        Me.Pbox_01.BackColor = System.Drawing.Color.White
        Me.Pbox_01.ForeColor = System.Drawing.Color.Black
        Me.Pbox_01.Image = CType(resources.GetObject("Pbox_01.Image"), System.Drawing.Image)
        Me.Pbox_01.Location = New System.Drawing.Point(90, 180)
        Me.Pbox_01.Name = "Pbox_01"
        Me.Pbox_01.Size = New System.Drawing.Size(65, 67)
        Me.Pbox_01.TabIndex = 38
        Me.Pbox_01.TabStop = False
        '
        'Pbox_02
        '
        Me.Pbox_02.BackColor = System.Drawing.Color.White
        Me.Pbox_02.ForeColor = System.Drawing.Color.Black
        Me.Pbox_02.Image = CType(resources.GetObject("Pbox_02.Image"), System.Drawing.Image)
        Me.Pbox_02.Location = New System.Drawing.Point(90, 253)
        Me.Pbox_02.Name = "Pbox_02"
        Me.Pbox_02.Size = New System.Drawing.Size(65, 67)
        Me.Pbox_02.TabIndex = 39
        Me.Pbox_02.TabStop = False
        '
        'Pbox_03
        '
        Me.Pbox_03.BackColor = System.Drawing.Color.White
        Me.Pbox_03.ForeColor = System.Drawing.Color.Black
        Me.Pbox_03.Image = CType(resources.GetObject("Pbox_03.Image"), System.Drawing.Image)
        Me.Pbox_03.Location = New System.Drawing.Point(90, 326)
        Me.Pbox_03.Name = "Pbox_03"
        Me.Pbox_03.Size = New System.Drawing.Size(65, 67)
        Me.Pbox_03.TabIndex = 40
        Me.Pbox_03.TabStop = False
        '
        'Lbl_Esperando
        '
        Me.Lbl_Esperando.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Esperando.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Esperando.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Esperando.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Esperando.Location = New System.Drawing.Point(46, 399)
        Me.Lbl_Esperando.Name = "Lbl_Esperando"
        Me.Lbl_Esperando.Size = New System.Drawing.Size(299, 43)
        Me.Lbl_Esperando.TabIndex = 41
        Me.Lbl_Esperando.Text = "Esperando pago..."
        '
        'Tiempo_Flecha
        '
        Me.Tiempo_Flecha.Enabled = True
        Me.Tiempo_Flecha.Interval = 500
        '
        'Frm_Cashdro_Pago_Efectivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 514)
        Me.ControlBox = False
        Me.Controls.Add(Me.Lbl_Esperando)
        Me.Controls.Add(Me.Pbox_03)
        Me.Controls.Add(Me.Pbox_02)
        Me.Controls.Add(Me.Pbox_01)
        Me.Controls.Add(Me.Lbl_Total_A_Pagar)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cashdro_Pago_Efectivo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PAGO EN EFECTIVO"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pbox_01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pbox_02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pbox_03, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Cancelar_Operacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Tiempo_Pago_Efectivo As System.Windows.Forms.Timer
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Lbl_Total_A_Pagar As DevComponents.DotNetBar.LabelX
    Friend WithEvents Pbox_01 As System.Windows.Forms.PictureBox
    Friend WithEvents Pbox_02 As System.Windows.Forms.PictureBox
    Friend WithEvents Pbox_03 As System.Windows.Forms.PictureBox
    Friend WithEvents Lbl_Esperando As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tiempo_Flecha As System.Windows.Forms.Timer
End Class
