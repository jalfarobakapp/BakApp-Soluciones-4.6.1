<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cashdro_Pago_Tarjeta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cashdro_Pago_Tarjeta))
        Me.Lbl_Total_A_Pagar = New DevComponents.DotNetBar.LabelX()
        Me.Tiempo_Respuesta_Transbank = New System.Windows.Forms.Timer(Me.components)
        Me.rtbDisplay = New System.Windows.Forms.RichTextBox()
        Me.Tiempo_Abrir = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_Respuesta_Transbank_Decodificada = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_Respuesta_Transbank_Codificada = New System.Windows.Forms.TextBox()
        Me.Txt_Requirimiento = New System.Windows.Forms.TextBox()
        Me.Lbl_Status = New DevComponents.DotNetBar.LabelX()
        Me.Tiempo_Cierre = New System.Windows.Forms.Timer(Me.components)
        Me.Tiempo_Label = New System.Windows.Forms.Timer(Me.components)
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lbl_Total_A_Pagar
        '
        Me.Lbl_Total_A_Pagar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Total_A_Pagar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Total_A_Pagar.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Total_A_Pagar.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Total_A_Pagar.Location = New System.Drawing.Point(8, 12)
        Me.Lbl_Total_A_Pagar.Name = "Lbl_Total_A_Pagar"
        Me.Lbl_Total_A_Pagar.Size = New System.Drawing.Size(662, 74)
        Me.Lbl_Total_A_Pagar.TabIndex = 38
        Me.Lbl_Total_A_Pagar.Text = "TOTAL $ 999.999.999"
        Me.Lbl_Total_A_Pagar.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Tiempo_Respuesta_Transbank
        '
        Me.Tiempo_Respuesta_Transbank.Enabled = True
        '
        'rtbDisplay
        '
        Me.rtbDisplay.BackColor = System.Drawing.Color.White
        Me.rtbDisplay.ForeColor = System.Drawing.Color.Black
        Me.rtbDisplay.Location = New System.Drawing.Point(808, 12)
        Me.rtbDisplay.Name = "rtbDisplay"
        Me.rtbDisplay.Size = New System.Drawing.Size(666, 75)
        Me.rtbDisplay.TabIndex = 39
        Me.rtbDisplay.Text = ""
        '
        'Tiempo_Abrir
        '
        Me.Tiempo_Abrir.Enabled = True
        Me.Tiempo_Abrir.Interval = 1000
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 8.25!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(801, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(162, 15)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "TRADUCCION DESDE TRANSBANK"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 8.25!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(801, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(156, 15)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "RESPUESTA DESDE TRANSBANK"
        '
        'Txt_Respuesta_Transbank_Decodificada
        '
        Me.Txt_Respuesta_Transbank_Decodificada.BackColor = System.Drawing.Color.White
        Me.Txt_Respuesta_Transbank_Decodificada.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Respuesta_Transbank_Decodificada.ForeColor = System.Drawing.Color.Black
        Me.Txt_Respuesta_Transbank_Decodificada.Location = New System.Drawing.Point(808, 227)
        Me.Txt_Respuesta_Transbank_Decodificada.Multiline = True
        Me.Txt_Respuesta_Transbank_Decodificada.Name = "Txt_Respuesta_Transbank_Decodificada"
        Me.Txt_Respuesta_Transbank_Decodificada.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.Txt_Respuesta_Transbank_Decodificada.Size = New System.Drawing.Size(662, 69)
        Me.Txt_Respuesta_Transbank_Decodificada.TabIndex = 68
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(801, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 15)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "REQUIRIMIENTO"
        '
        'Txt_Respuesta_Transbank_Codificada
        '
        Me.Txt_Respuesta_Transbank_Codificada.BackColor = System.Drawing.Color.White
        Me.Txt_Respuesta_Transbank_Codificada.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Respuesta_Transbank_Codificada.ForeColor = System.Drawing.Color.Black
        Me.Txt_Respuesta_Transbank_Codificada.Location = New System.Drawing.Point(808, 162)
        Me.Txt_Respuesta_Transbank_Codificada.Multiline = True
        Me.Txt_Respuesta_Transbank_Codificada.Name = "Txt_Respuesta_Transbank_Codificada"
        Me.Txt_Respuesta_Transbank_Codificada.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.Txt_Respuesta_Transbank_Codificada.Size = New System.Drawing.Size(662, 44)
        Me.Txt_Respuesta_Transbank_Codificada.TabIndex = 66
        '
        'Txt_Requirimiento
        '
        Me.Txt_Requirimiento.BackColor = System.Drawing.Color.White
        Me.Txt_Requirimiento.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Requirimiento.ForeColor = System.Drawing.Color.Black
        Me.Txt_Requirimiento.Location = New System.Drawing.Point(808, 108)
        Me.Txt_Requirimiento.Multiline = True
        Me.Txt_Requirimiento.Name = "Txt_Requirimiento"
        Me.Txt_Requirimiento.Size = New System.Drawing.Size(662, 33)
        Me.Txt_Requirimiento.TabIndex = 65
        '
        'Lbl_Status
        '
        Me.Lbl_Status.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Status.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Status.Font = New System.Drawing.Font("Segoe UI", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Status.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Status.Location = New System.Drawing.Point(8, 92)
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Size = New System.Drawing.Size(662, 73)
        Me.Lbl_Status.TabIndex = 37
        Me.Lbl_Status.Text = "STATUS"
        Me.Lbl_Status.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Tiempo_Cierre
        '
        Me.Tiempo_Cierre.Enabled = True
        Me.Tiempo_Cierre.Interval = 5000
        '
        'Tiempo_Label
        '
        Me.Tiempo_Label.Enabled = True
        Me.Tiempo_Label.Interval = 1000
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Cancelar})
        Me.Bar2.Location = New System.Drawing.Point(0, 164)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(678, 33)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 71
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Visible = False
        '
        'Frm_Cashdro_Pago_Tarjeta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 197)
        Me.ControlBox = False
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Txt_Respuesta_Transbank_Decodificada)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Txt_Respuesta_Transbank_Codificada)
        Me.Controls.Add(Me.Txt_Requirimiento)
        Me.Controls.Add(Me.rtbDisplay)
        Me.Controls.Add(Me.Lbl_Total_A_Pagar)
        Me.Controls.Add(Me.Lbl_Status)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cashdro_Pago_Tarjeta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PAGO CON TARJETA"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lbl_Total_A_Pagar As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tiempo_Respuesta_Transbank As System.Windows.Forms.Timer
    Private WithEvents rtbDisplay As System.Windows.Forms.RichTextBox
    Friend WithEvents Tiempo_Abrir As System.Windows.Forms.Timer
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txt_Respuesta_Transbank_Decodificada As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_Respuesta_Transbank_Codificada As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Requirimiento As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Status As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tiempo_Cierre As System.Windows.Forms.Timer
    Friend WithEvents Tiempo_Label As System.Windows.Forms.Timer
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
End Class
