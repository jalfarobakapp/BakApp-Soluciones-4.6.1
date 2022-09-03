<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Formulario_Iva_Ila
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Formulario_Iva_Ila))
        Me.Txt_Valor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_Etiqueta = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Txt_Valor
        '
        Me.Txt_Valor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Valor.Border.Class = "TextBoxBorder"
        Me.Txt_Valor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Valor.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Valor.FocusHighlightEnabled = True
        Me.Txt_Valor.ForeColor = System.Drawing.Color.Black
        Me.Txt_Valor.Location = New System.Drawing.Point(125, 21)
        Me.Txt_Valor.Name = "Txt_Valor"
        Me.Txt_Valor.PreventEnterBeep = True
        Me.Txt_Valor.Size = New System.Drawing.Size(97, 22)
        Me.Txt_Valor.TabIndex = 0
        Me.Txt_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Aceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Aceptar.Location = New System.Drawing.Point(3, 49)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(219, 23)
        Me.Btn_Aceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Aceptar.TabIndex = 1
        Me.Btn_Aceptar.Text = "ACEPTAR"
        '
        'Lbl_Etiqueta
        '
        Me.Lbl_Etiqueta.AutoSize = True
        Me.Lbl_Etiqueta.BackColor = System.Drawing.Color.White
        Me.Lbl_Etiqueta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Etiqueta.Location = New System.Drawing.Point(0, 23)
        Me.Lbl_Etiqueta.Name = "Lbl_Etiqueta"
        Me.Lbl_Etiqueta.Size = New System.Drawing.Size(119, 13)
        Me.Lbl_Etiqueta.TabIndex = 21
        Me.Lbl_Etiqueta.Text = "Nuevo valor Impuesto"
        '
        'Frm_Formulario_Iva_Ila
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(227, 81)
        Me.Controls.Add(Me.Txt_Valor)
        Me.Controls.Add(Me.Btn_Aceptar)
        Me.Controls.Add(Me.Lbl_Etiqueta)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Formulario_Iva_Ila"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar valor de I.V.A."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Txt_Valor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Lbl_Etiqueta As Label
End Class
