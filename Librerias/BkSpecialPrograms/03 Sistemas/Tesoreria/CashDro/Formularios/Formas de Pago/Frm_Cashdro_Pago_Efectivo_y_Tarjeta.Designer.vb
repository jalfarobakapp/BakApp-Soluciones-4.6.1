<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cashdro_Pago_Efectivo_y_Tarjeta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cashdro_Pago_Efectivo_y_Tarjeta))
        Me.Lbl_Valor_Venta = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_Monto = New System.Windows.Forms.TextBox()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Sumar = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Restar = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_Saldo_Tarjeta = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Tiempo_Pago_Efectivo = New System.Windows.Forms.Timer(Me.components)
        Me.Btn_Cancelar_Operacion = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lbl_Valor_Venta
        '
        Me.Lbl_Valor_Venta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Valor_Venta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Valor_Venta.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Valor_Venta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Valor_Venta.Location = New System.Drawing.Point(59, 12)
        Me.Lbl_Valor_Venta.Name = "Lbl_Valor_Venta"
        Me.Lbl_Valor_Venta.Size = New System.Drawing.Size(582, 63)
        Me.Lbl_Valor_Venta.TabIndex = 38
        Me.Lbl_Valor_Venta.Text = "<b><font size = ""34"" color=""#349FCE"">VALOR VENTA: $ 99.999</font></b>  "
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Cancelar})
        Me.Bar2.Location = New System.Drawing.Point(0, 401)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(641, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 37
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "CANCELAR OPERACION"
        '
        'Txt_Monto
        '
        Me.Txt_Monto.Font = New System.Drawing.Font("Courier New", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Monto.Location = New System.Drawing.Point(12, 138)
        Me.Txt_Monto.Name = "Txt_Monto"
        Me.Txt_Monto.Size = New System.Drawing.Size(415, 116)
        Me.Txt_Monto.TabIndex = 44
        Me.Txt_Monto.Text = "100.000"
        Me.Txt_Monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Aceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.Location = New System.Drawing.Point(12, 324)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(238, 71)
        Me.Btn_Aceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Aceptar.TabIndex = 50
        Me.Btn_Aceptar.Text = "ACEPTAR"
        Me.Btn_Aceptar.TextColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        '
        'Btn_Sumar
        '
        Me.Btn_Sumar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Sumar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Sumar.Image = CType(resources.GetObject("Btn_Sumar.Image"), System.Drawing.Image)
        Me.Btn_Sumar.Location = New System.Drawing.Point(433, 138)
        Me.Btn_Sumar.Name = "Btn_Sumar"
        Me.Btn_Sumar.Size = New System.Drawing.Size(124, 55)
        Me.Btn_Sumar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Sumar.TabIndex = 51
        '
        'Btn_Restar
        '
        Me.Btn_Restar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Restar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Restar.Image = CType(resources.GetObject("Btn_Restar.Image"), System.Drawing.Image)
        Me.Btn_Restar.Location = New System.Drawing.Point(433, 199)
        Me.Btn_Restar.Name = "Btn_Restar"
        Me.Btn_Restar.Size = New System.Drawing.Size(124, 55)
        Me.Btn_Restar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Restar.TabIndex = 52
        '
        'Lbl_Saldo_Tarjeta
        '
        Me.Lbl_Saldo_Tarjeta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Saldo_Tarjeta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Saldo_Tarjeta.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Saldo_Tarjeta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Saldo_Tarjeta.Location = New System.Drawing.Point(12, 260)
        Me.Lbl_Saldo_Tarjeta.Name = "Lbl_Saldo_Tarjeta"
        Me.Lbl_Saldo_Tarjeta.Size = New System.Drawing.Size(617, 58)
        Me.Lbl_Saldo_Tarjeta.TabIndex = 53
        Me.Lbl_Saldo_Tarjeta.Text = "<b><font size = ""22"" color=""#349FCE"">Total saldo a pagar con tarjeta $ 99.999</fo" &
    "nt></b>  "
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
        Me.LabelX2.Location = New System.Drawing.Point(12, 81)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(449, 51)
        Me.LabelX2.TabIndex = 54
        Me.LabelX2.Text = "<b><font size = ""18"" color=""#349FCE"">Inquique el valor a pagar con efectivo</font" &
    "></b>  "
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
        Me.LabelX1.Location = New System.Drawing.Point(563, 142)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(78, 51)
        Me.LabelX1.TabIndex = 55
        Me.LabelX1.Text = "<b><font size = ""16"" color=""#349FCE"">Sumar</font></b>  "
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(563, 202)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(78, 51)
        Me.LabelX3.TabIndex = 56
        Me.LabelX3.Text = "<b><font size = ""16"" color=""#349FCE"">Restar</font></b>  "
        '
        'Tiempo_Pago_Efectivo
        '
        Me.Tiempo_Pago_Efectivo.Enabled = True
        Me.Tiempo_Pago_Efectivo.Interval = 1000
        '
        'Btn_Cancelar_Operacion
        '
        Me.Btn_Cancelar_Operacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar_Operacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar_Operacion.Image = CType(resources.GetObject("Btn_Cancelar_Operacion.Image"), System.Drawing.Image)
        Me.Btn_Cancelar_Operacion.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Cancelar_Operacion.Name = "Btn_Cancelar_Operacion"
        Me.Btn_Cancelar_Operacion.Text = "CANCELAR"
        '
        'Frm_Cashdro_Pago_Efectivo_y_Tarjeta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 442)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Lbl_Saldo_Tarjeta)
        Me.Controls.Add(Me.Btn_Restar)
        Me.Controls.Add(Me.Btn_Sumar)
        Me.Controls.Add(Me.Btn_Aceptar)
        Me.Controls.Add(Me.Txt_Monto)
        Me.Controls.Add(Me.Lbl_Valor_Venta)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cashdro_Pago_Efectivo_y_Tarjeta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PAGO EFECTIVO/TARJETA"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lbl_Valor_Venta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Txt_Monto As TextBox
    Friend WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Sumar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Restar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Lbl_Saldo_Tarjeta As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tiempo_Pago_Efectivo As Timer
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cancelar_Operacion As DevComponents.DotNetBar.ButtonItem
End Class
