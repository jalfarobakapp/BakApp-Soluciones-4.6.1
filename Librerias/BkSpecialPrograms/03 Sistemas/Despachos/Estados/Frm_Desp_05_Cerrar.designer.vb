<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Desp_05_Cerrar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Desp_05_Cerrar))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Observaciones = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nro_Encomienda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Aceptar})
        Me.Bar1.Location = New System.Drawing.Point(0, 153)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(544, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 141
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.ImageAlt = CType(resources.GetObject("Btn_Aceptar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Text = "CERRAR DESPACHO"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(12, 40)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(138, 20)
        Me.LabelX4.TabIndex = 140
        Me.LabelX4.Text = "Observaciones"
        '
        'Txt_Observaciones
        '
        Me.Txt_Observaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Observaciones.Border.Class = "TextBoxBorder"
        Me.Txt_Observaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Observaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Observaciones.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Observaciones.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Observaciones, True)
        Me.Txt_Observaciones.Location = New System.Drawing.Point(12, 63)
        Me.Txt_Observaciones.Multiline = True
        Me.Txt_Observaciones.Name = "Txt_Observaciones"
        Me.Txt_Observaciones.PreventEnterBeep = True
        Me.Txt_Observaciones.Size = New System.Drawing.Size(522, 80)
        Me.Txt_Observaciones.TabIndex = 139
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(81, 20)
        Me.LabelX1.TabIndex = 142
        Me.LabelX1.Text = "N° Encomienda"
        '
        'Txt_Nro_Encomienda
        '
        Me.Txt_Nro_Encomienda.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nro_Encomienda.Border.Class = "TextBoxBorder"
        Me.Txt_Nro_Encomienda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nro_Encomienda.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nro_Encomienda.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Nro_Encomienda, True)
        Me.Txt_Nro_Encomienda.Location = New System.Drawing.Point(99, 12)
        Me.Txt_Nro_Encomienda.MaxLength = 25
        Me.Txt_Nro_Encomienda.Name = "Txt_Nro_Encomienda"
        Me.Txt_Nro_Encomienda.PreventEnterBeep = True
        Me.Txt_Nro_Encomienda.Size = New System.Drawing.Size(163, 22)
        Me.Txt_Nro_Encomienda.TabIndex = 143
        Me.Txt_Nro_Encomienda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Highlighter1
        '
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Green
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Frm_Desp_05_Cerrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 194)
        Me.Controls.Add(Me.Txt_Nro_Encomienda)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Txt_Observaciones)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Desp_05_Cerrar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CERRAR DESPACHO"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Observaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Nro_Encomienda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
End Class
