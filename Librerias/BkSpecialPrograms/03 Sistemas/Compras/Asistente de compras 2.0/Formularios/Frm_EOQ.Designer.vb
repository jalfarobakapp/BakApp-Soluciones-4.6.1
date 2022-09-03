<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_EOQ
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Txt_Demanda_Anual = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.Txt_Costo_emitir_orden = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.Txt_Costo_Mantencion = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Txt_EOQ = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.TextBoxX4 = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX
        Me.TextBoxX5 = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Btn_Cal_EOQ = New DevComponents.DotNetBar.ButtonX
        Me.SuspendLayout()
        '
        'Txt_Demanda_Anual
        '
        Me.Txt_Demanda_Anual.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Demanda_Anual.Border.Class = "TextBoxBorder"
        Me.Txt_Demanda_Anual.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Demanda_Anual.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Demanda_Anual.ForeColor = System.Drawing.Color.Black
        Me.Txt_Demanda_Anual.Location = New System.Drawing.Point(18, 36)
        Me.Txt_Demanda_Anual.Name = "Txt_Demanda_Anual"
        Me.Txt_Demanda_Anual.PreventEnterBeep = True
        Me.Txt_Demanda_Anual.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Demanda_Anual.TabIndex = 0
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(18, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(231, 23)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "D: Demanda. Unidades por año"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(18, 62)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(231, 23)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "S : Costo de emitir una orden (k)"
        '
        'Txt_Costo_emitir_orden
        '
        Me.Txt_Costo_emitir_orden.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Costo_emitir_orden.Border.Class = "TextBoxBorder"
        Me.Txt_Costo_emitir_orden.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Costo_emitir_orden.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Costo_emitir_orden.ForeColor = System.Drawing.Color.Black
        Me.Txt_Costo_emitir_orden.Location = New System.Drawing.Point(18, 91)
        Me.Txt_Costo_emitir_orden.Name = "Txt_Costo_emitir_orden"
        Me.Txt_Costo_emitir_orden.PreventEnterBeep = True
        Me.Txt_Costo_emitir_orden.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Costo_emitir_orden.TabIndex = 2
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(18, 117)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(345, 23)
        Me.LabelX3.TabIndex = 5
        Me.LabelX3.Text = "H : Costo asociado a mantener una unidad en inventario en un año (h)"
        '
        'Txt_Costo_Mantencion
        '
        Me.Txt_Costo_Mantencion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Costo_Mantencion.Border.Class = "TextBoxBorder"
        Me.Txt_Costo_Mantencion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Costo_Mantencion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Costo_Mantencion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Costo_Mantencion.Location = New System.Drawing.Point(18, 146)
        Me.Txt_Costo_Mantencion.Name = "Txt_Costo_Mantencion"
        Me.Txt_Costo_Mantencion.PreventEnterBeep = True
        Me.Txt_Costo_Mantencion.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Costo_Mantencion.TabIndex = 4
        '
        'Txt_EOQ
        '
        Me.Txt_EOQ.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_EOQ.Border.Class = "TextBoxBorder"
        Me.Txt_EOQ.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_EOQ.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_EOQ.ForeColor = System.Drawing.Color.Black
        Me.Txt_EOQ.Location = New System.Drawing.Point(18, 201)
        Me.Txt_EOQ.Name = "Txt_EOQ"
        Me.Txt_EOQ.PreventEnterBeep = True
        Me.Txt_EOQ.Size = New System.Drawing.Size(100, 20)
        Me.Txt_EOQ.TabIndex = 6
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(18, 172)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(231, 23)
        Me.LabelX4.TabIndex = 7
        Me.LabelX4.Text = "Q : Cantidad a ordenar"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(18, 248)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(231, 23)
        Me.LabelX5.TabIndex = 9
        Me.LabelX5.Text = "Dias laborales"
        '
        'TextBoxX4
        '
        Me.TextBoxX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX4.Border.Class = "TextBoxBorder"
        Me.TextBoxX4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX4.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX4.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX4.Location = New System.Drawing.Point(18, 277)
        Me.TextBoxX4.Name = "TextBoxX4"
        Me.TextBoxX4.PreventEnterBeep = True
        Me.TextBoxX4.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxX4.TabIndex = 8
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(18, 303)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(231, 23)
        Me.LabelX6.TabIndex = 11
        Me.LabelX6.Text = "Lead Time (Tiempo reposición)"
        '
        'TextBoxX5
        '
        Me.TextBoxX5.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX5.Border.Class = "TextBoxBorder"
        Me.TextBoxX5.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX5.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX5.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX5.Location = New System.Drawing.Point(18, 332)
        Me.TextBoxX5.Name = "TextBoxX5"
        Me.TextBoxX5.PreventEnterBeep = True
        Me.TextBoxX5.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxX5.TabIndex = 10
        '
        'Btn_Cal_EOQ
        '
        Me.Btn_Cal_EOQ.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Cal_EOQ.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Cal_EOQ.Location = New System.Drawing.Point(140, 201)
        Me.Btn_Cal_EOQ.Name = "Btn_Cal_EOQ"
        Me.Btn_Cal_EOQ.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Cal_EOQ.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Cal_EOQ.TabIndex = 12
        Me.Btn_Cal_EOQ.Text = "Calcular EOQ"
        '
        'Frm_EOQ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 401)
        Me.Controls.Add(Me.Btn_Cal_EOQ)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.TextBoxX5)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.TextBoxX4)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Txt_EOQ)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.Txt_Costo_Mantencion)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Txt_Costo_emitir_orden)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Txt_Demanda_Anual)
        Me.Name = "Frm_EOQ"
        Me.Text = "Frm_EOQ"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Txt_Demanda_Anual As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Costo_emitir_orden As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Costo_Mantencion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_EOQ As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX4 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX5 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Cal_EOQ As DevComponents.DotNetBar.ButtonX
End Class
