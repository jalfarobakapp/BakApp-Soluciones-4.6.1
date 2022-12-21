<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Buscar_Pistoleando
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Buscar_Pistoleando))
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Numero = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_Leyenda_02 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Leyenda_01 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Ver_Clave = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Tiempo_Cierre_Automatico = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
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
        Me.ReflectionImage1.Location = New System.Drawing.Point(412, 12)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(83, 96)
        Me.ReflectionImage1.TabIndex = 9
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Aceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.Location = New System.Drawing.Point(306, 27)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(85, 39)
        Me.Btn_Aceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Aceptar.TabIndex = 12
        Me.Btn_Aceptar.Text = "Aceptar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Ingrese el código a buscar"
        '
        'Txt_Numero
        '
        Me.Txt_Numero.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Numero.Border.Class = "TextBoxBorder"
        Me.Txt_Numero.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Numero.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Numero.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Numero.ForeColor = System.Drawing.Color.Black
        Me.Txt_Numero.Location = New System.Drawing.Point(12, 27)
        Me.Txt_Numero.Name = "Txt_Numero"
        Me.Txt_Numero.PreventEnterBeep = True
        Me.Txt_Numero.Size = New System.Drawing.Size(288, 39)
        Me.Txt_Numero.TabIndex = 10
        Me.Txt_Numero.Text = "..."
        Me.Txt_Numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_Numero.WatermarkColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Txt_Numero.WatermarkText = "..."
        '
        'Lbl_Leyenda_02
        '
        Me.Lbl_Leyenda_02.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Leyenda_02.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Leyenda_02.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Leyenda_02.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Leyenda_02.Location = New System.Drawing.Point(12, 129)
        Me.Lbl_Leyenda_02.Name = "Lbl_Leyenda_02"
        Me.Lbl_Leyenda_02.Size = New System.Drawing.Size(315, 22)
        Me.Lbl_Leyenda_02.TabIndex = 14
        Me.Lbl_Leyenda_02.Text = "OPERACION: MECANIZADO TORNO CNC"
        '
        'Lbl_Leyenda_01
        '
        Me.Lbl_Leyenda_01.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Leyenda_01.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Leyenda_01.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Leyenda_01.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Leyenda_01.Location = New System.Drawing.Point(12, 101)
        Me.Lbl_Leyenda_01.Name = "Lbl_Leyenda_01"
        Me.Lbl_Leyenda_01.Size = New System.Drawing.Size(315, 22)
        Me.Lbl_Leyenda_01.TabIndex = 15
        Me.Lbl_Leyenda_01.Text = "OPERACION: MECANIZADO TORNO CNC"
        '
        'Chk_Ver_Clave
        '
        Me.Chk_Ver_Clave.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Ver_Clave.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Ver_Clave.CheckBoxImageChecked = CType(resources.GetObject("Chk_Ver_Clave.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Ver_Clave.Checked = True
        Me.Chk_Ver_Clave.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Ver_Clave.CheckValue = "Y"
        Me.Chk_Ver_Clave.FocusCuesEnabled = False
        Me.Chk_Ver_Clave.ForeColor = System.Drawing.Color.Black
        Me.Chk_Ver_Clave.Location = New System.Drawing.Point(12, 72)
        Me.Chk_Ver_Clave.Name = "Chk_Ver_Clave"
        Me.Chk_Ver_Clave.Size = New System.Drawing.Size(100, 23)
        Me.Chk_Ver_Clave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Ver_Clave.TabIndex = 16
        Me.Chk_Ver_Clave.Text = "Ver clave"
        '
        'Tiempo_Cierre_Automatico
        '
        Me.Tiempo_Cierre_Automatico.Interval = 1000
        '
        'Frm_Buscar_Pistoleando
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(507, 161)
        Me.Controls.Add(Me.Chk_Ver_Clave)
        Me.Controls.Add(Me.Lbl_Leyenda_01)
        Me.Controls.Add(Me.Lbl_Leyenda_02)
        Me.Controls.Add(Me.Btn_Aceptar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_Numero)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Buscar_Pistoleando"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ASISTENTE DE BUSQUEDA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Lbl_Leyenda_02 As DevComponents.DotNetBar.LabelX
    Public WithEvents Lbl_Leyenda_01 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Numero As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Chk_Ver_Clave As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Tiempo_Cierre_Automatico As Timer
End Class
