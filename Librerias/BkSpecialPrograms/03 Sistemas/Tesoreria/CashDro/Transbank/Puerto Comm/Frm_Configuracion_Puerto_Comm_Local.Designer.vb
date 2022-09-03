<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Configuracion_Puerto_Comm_Local
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Configuracion_Puerto_Comm_Local))
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.label5 = New System.Windows.Forms.Label
        Me.Cmb_Bits_de_datos = New System.Windows.Forms.ComboBox
        Me.label4 = New System.Windows.Forms.Label
        Me.Cmb_Bits_de_parada = New System.Windows.Forms.ComboBox
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.Cmb_Paridad = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Cmb_Tasa_de_baudios = New System.Windows.Forms.ComboBox
        Me.Cmb_Puerto = New System.Windows.Forms.ComboBox
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.Rdb_Texto = New System.Windows.Forms.RadioButton
        Me.Rdb_Hexadecimal = New System.Windows.Forms.RadioButton
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem
        Me.Sw_Activar_Pto = New DevComponents.DotNetBar.Controls.SwitchButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.groupBox2.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.BackColor = System.Drawing.Color.White
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.Cmb_Bits_de_datos)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.Cmb_Bits_de_parada)
        Me.groupBox2.Controls.Add(Me.label3)
        Me.groupBox2.Controls.Add(Me.label2)
        Me.groupBox2.Controls.Add(Me.Cmb_Paridad)
        Me.groupBox2.Controls.Add(Me.Label1)
        Me.groupBox2.Controls.Add(Me.Cmb_Tasa_de_baudios)
        Me.groupBox2.Controls.Add(Me.Cmb_Puerto)
        Me.groupBox2.ForeColor = System.Drawing.Color.Black
        Me.groupBox2.Location = New System.Drawing.Point(12, 12)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(444, 75)
        Me.groupBox2.TabIndex = 68
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Options"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.BackColor = System.Drawing.Color.White
        Me.label5.ForeColor = System.Drawing.Color.Black
        Me.label5.Location = New System.Drawing.Point(346, 18)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(53, 13)
        Me.label5.TabIndex = 19
        Me.label5.Text = "Data Bits"
        '
        'Cmb_Bits_de_datos
        '
        Me.Cmb_Bits_de_datos.BackColor = System.Drawing.Color.White
        Me.Cmb_Bits_de_datos.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Bits_de_datos.FormattingEnabled = True
        Me.Cmb_Bits_de_datos.Items.AddRange(New Object() {"7", "8", "9"})
        Me.Cmb_Bits_de_datos.Location = New System.Drawing.Point(349, 34)
        Me.Cmb_Bits_de_datos.Name = "Cmb_Bits_de_datos"
        Me.Cmb_Bits_de_datos.Size = New System.Drawing.Size(76, 21)
        Me.Cmb_Bits_de_datos.TabIndex = 14
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.BackColor = System.Drawing.Color.White
        Me.label4.ForeColor = System.Drawing.Color.Black
        Me.label4.Location = New System.Drawing.Point(261, 18)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(53, 13)
        Me.label4.TabIndex = 18
        Me.label4.Text = "Stop Bits"
        '
        'Cmb_Bits_de_parada
        '
        Me.Cmb_Bits_de_parada.BackColor = System.Drawing.Color.White
        Me.Cmb_Bits_de_parada.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Bits_de_parada.FormattingEnabled = True
        Me.Cmb_Bits_de_parada.Location = New System.Drawing.Point(263, 34)
        Me.Cmb_Bits_de_parada.Name = "Cmb_Bits_de_parada"
        Me.Cmb_Bits_de_parada.Size = New System.Drawing.Size(76, 21)
        Me.Cmb_Bits_de_parada.TabIndex = 13
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.BackColor = System.Drawing.Color.White
        Me.label3.ForeColor = System.Drawing.Color.Black
        Me.label3.Location = New System.Drawing.Point(176, 18)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(35, 13)
        Me.label3.TabIndex = 17
        Me.label3.Text = "Parity"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.Color.White
        Me.label2.ForeColor = System.Drawing.Color.Black
        Me.label2.Location = New System.Drawing.Point(91, 18)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(60, 13)
        Me.label2.TabIndex = 16
        Me.label2.Text = "Baud Rate"
        '
        'Cmb_Paridad
        '
        Me.Cmb_Paridad.BackColor = System.Drawing.Color.White
        Me.Cmb_Paridad.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Paridad.FormattingEnabled = True
        Me.Cmb_Paridad.Location = New System.Drawing.Point(179, 34)
        Me.Cmb_Paridad.Name = "Cmb_Paridad"
        Me.Cmb_Paridad.Size = New System.Drawing.Size(76, 21)
        Me.Cmb_Paridad.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Port"
        '
        'Cmb_Tasa_de_baudios
        '
        Me.Cmb_Tasa_de_baudios.BackColor = System.Drawing.Color.White
        Me.Cmb_Tasa_de_baudios.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tasa_de_baudios.FormattingEnabled = True
        Me.Cmb_Tasa_de_baudios.Items.AddRange(New Object() {"300", "600", "1200", "2400", "4800", "9600", "14400", "28800", "36000", "115000"})
        Me.Cmb_Tasa_de_baudios.Location = New System.Drawing.Point(94, 34)
        Me.Cmb_Tasa_de_baudios.Name = "Cmb_Tasa_de_baudios"
        Me.Cmb_Tasa_de_baudios.Size = New System.Drawing.Size(76, 21)
        Me.Cmb_Tasa_de_baudios.TabIndex = 11
        '
        'Cmb_Puerto
        '
        Me.Cmb_Puerto.BackColor = System.Drawing.Color.White
        Me.Cmb_Puerto.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Puerto.FormattingEnabled = True
        Me.Cmb_Puerto.Location = New System.Drawing.Point(9, 34)
        Me.Cmb_Puerto.Name = "Cmb_Puerto"
        Me.Cmb_Puerto.Size = New System.Drawing.Size(76, 21)
        Me.Cmb_Puerto.TabIndex = 10
        '
        'groupBox3
        '
        Me.groupBox3.BackColor = System.Drawing.Color.White
        Me.groupBox3.Controls.Add(Me.Rdb_Texto)
        Me.groupBox3.Controls.Add(Me.Rdb_Hexadecimal)
        Me.groupBox3.ForeColor = System.Drawing.Color.Black
        Me.groupBox3.Location = New System.Drawing.Point(12, 93)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(120, 53)
        Me.groupBox3.TabIndex = 69
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Mode"
        '
        'Rdb_Texto
        '
        Me.Rdb_Texto.AutoSize = True
        Me.Rdb_Texto.BackColor = System.Drawing.Color.White
        Me.Rdb_Texto.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Texto.Location = New System.Drawing.Point(59, 21)
        Me.Rdb_Texto.Name = "Rdb_Texto"
        Me.Rdb_Texto.Size = New System.Drawing.Size(44, 17)
        Me.Rdb_Texto.TabIndex = 1
        Me.Rdb_Texto.TabStop = True
        Me.Rdb_Texto.Text = "Text"
        Me.Rdb_Texto.UseVisualStyleBackColor = False
        '
        'Rdb_Hexadecimal
        '
        Me.Rdb_Hexadecimal.AutoSize = True
        Me.Rdb_Hexadecimal.BackColor = System.Drawing.Color.White
        Me.Rdb_Hexadecimal.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Hexadecimal.Location = New System.Drawing.Point(9, 21)
        Me.Rdb_Hexadecimal.Name = "Rdb_Hexadecimal"
        Me.Rdb_Hexadecimal.Size = New System.Drawing.Size(44, 17)
        Me.Rdb_Hexadecimal.TabIndex = 0
        Me.Rdb_Hexadecimal.TabStop = True
        Me.Rdb_Hexadecimal.Text = "Hex"
        Me.Rdb_Hexadecimal.UseVisualStyleBackColor = False
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.BtnCancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 156)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(468, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 120
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancelar.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Tooltip = "Cancelar"
        '
        'Sw_Activar_Pto
        '
        Me.Sw_Activar_Pto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Sw_Activar_Pto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Sw_Activar_Pto.ForeColor = System.Drawing.Color.Black
        Me.Sw_Activar_Pto.Location = New System.Drawing.Point(157, 124)
        Me.Sw_Activar_Pto.Name = "Sw_Activar_Pto"
        Me.Sw_Activar_Pto.Size = New System.Drawing.Size(66, 22)
        Me.Sw_Activar_Pto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Sw_Activar_Pto.TabIndex = 121
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(154, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 122
        Me.Label6.Text = "Puerto activo"
        '
        'Frm_Configuracion_Puerto_Comm_Local
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 197)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Sw_Activar_Pto)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Configuracion_Puerto_Comm_Local"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuracion Puerto COMM"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents Cmb_Bits_de_datos As System.Windows.Forms.ComboBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents Cmb_Bits_de_parada As System.Windows.Forms.ComboBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents Cmb_Paridad As System.Windows.Forms.ComboBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents Cmb_Tasa_de_baudios As System.Windows.Forms.ComboBox
    Private WithEvents Cmb_Puerto As System.Windows.Forms.ComboBox
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents Rdb_Texto As System.Windows.Forms.RadioButton
    Private WithEvents Rdb_Hexadecimal As System.Windows.Forms.RadioButton
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Sw_Activar_Pto As DevComponents.DotNetBar.Controls.SwitchButton
    Private WithEvents Label6 As System.Windows.Forms.Label
End Class
