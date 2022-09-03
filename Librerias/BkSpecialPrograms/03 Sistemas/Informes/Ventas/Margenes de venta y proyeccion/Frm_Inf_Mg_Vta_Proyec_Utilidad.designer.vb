<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Inf_Mg_Vta_Proyec_Utilidad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inf_Mg_Vta_Proyec_Utilidad))
        Me.Txt_Costo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Proyeccion_Lineal = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Utilidad = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Calcular = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_PPMg = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Total_Neto = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Dias_Habiles = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Dias_Habiles_Total = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.SuspendLayout()
        '
        'Txt_Costo
        '
        Me.Txt_Costo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Costo.Border.Class = "TextBoxBorder"
        Me.Txt_Costo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Costo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Costo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Costo.Location = New System.Drawing.Point(93, 23)
        Me.Txt_Costo.Name = "Txt_Costo"
        Me.Txt_Costo.PreventEnterBeep = True
        Me.Txt_Costo.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Costo.TabIndex = 40
        Me.Txt_Costo.Tag = "0"
        Me.Txt_Costo.Text = "0"
        Me.Txt_Costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 22)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 41
        Me.LabelX1.Text = "Total costo"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 51)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(107, 23)
        Me.LabelX2.TabIndex = 42
        Me.LabelX2.Text = "Proyección lineal"
        '
        'Lbl_Proyeccion_Lineal
        '
        Me.Lbl_Proyeccion_Lineal.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Proyeccion_Lineal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Proyeccion_Lineal.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Proyeccion_Lineal.Location = New System.Drawing.Point(116, 51)
        Me.Lbl_Proyeccion_Lineal.Name = "Lbl_Proyeccion_Lineal"
        Me.Lbl_Proyeccion_Lineal.Size = New System.Drawing.Size(77, 23)
        Me.Lbl_Proyeccion_Lineal.TabIndex = 43
        Me.Lbl_Proyeccion_Lineal.Text = "$ 99.999.999"
        Me.Lbl_Proyeccion_Lineal.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(12, 108)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 44
        Me.LabelX4.Text = "Utilidad"
        '
        'Lbl_Utilidad
        '
        Me.Lbl_Utilidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Utilidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Utilidad.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Utilidad.Location = New System.Drawing.Point(118, 108)
        Me.Lbl_Utilidad.Name = "Lbl_Utilidad"
        Me.Lbl_Utilidad.Size = New System.Drawing.Size(75, 23)
        Me.Lbl_Utilidad.TabIndex = 45
        Me.Lbl_Utilidad.Text = "$ 99.999.999"
        Me.Lbl_Utilidad.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Btn_Calcular
        '
        Me.Btn_Calcular.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Calcular.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Calcular.Location = New System.Drawing.Point(199, 23)
        Me.Btn_Calcular.Name = "Btn_Calcular"
        Me.Btn_Calcular.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Calcular.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Calcular.TabIndex = 46
        Me.Btn_Calcular.Text = "Calcular"
        '
        'Lbl_PPMg
        '
        Me.Lbl_PPMg.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_PPMg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_PPMg.ForeColor = System.Drawing.Color.Black
        Me.Lbl_PPMg.Location = New System.Drawing.Point(118, 80)
        Me.Lbl_PPMg.Name = "Lbl_PPMg"
        Me.Lbl_PPMg.Size = New System.Drawing.Size(75, 23)
        Me.Lbl_PPMg.TabIndex = 48
        Me.Lbl_PPMg.Text = "100 %"
        Me.Lbl_PPMg.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(12, 79)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 47
        Me.LabelX5.Text = "PP Mg."
        '
        'Lbl_Total_Neto
        '
        Me.Lbl_Total_Neto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Total_Neto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Total_Neto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Total_Neto.Location = New System.Drawing.Point(423, 51)
        Me.Lbl_Total_Neto.Name = "Lbl_Total_Neto"
        Me.Lbl_Total_Neto.Size = New System.Drawing.Size(75, 23)
        Me.Lbl_Total_Neto.TabIndex = 50
        Me.Lbl_Total_Neto.Text = "$ 99.999.999"
        Me.Lbl_Total_Neto.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(317, 51)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 23)
        Me.LabelX6.TabIndex = 49
        Me.LabelX6.Text = "Total Neto"
        '
        'Lbl_Dias_Habiles
        '
        Me.Lbl_Dias_Habiles.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Dias_Habiles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Dias_Habiles.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Dias_Habiles.Location = New System.Drawing.Point(423, 80)
        Me.Lbl_Dias_Habiles.Name = "Lbl_Dias_Habiles"
        Me.Lbl_Dias_Habiles.Size = New System.Drawing.Size(75, 23)
        Me.Lbl_Dias_Habiles.TabIndex = 52
        Me.Lbl_Dias_Habiles.Text = "999.999"
        Me.Lbl_Dias_Habiles.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(317, 80)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(75, 23)
        Me.LabelX7.TabIndex = 51
        Me.LabelX7.Text = "Dias habiles"
        '
        'Lbl_Dias_Habiles_Total
        '
        Me.Lbl_Dias_Habiles_Total.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Dias_Habiles_Total.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Dias_Habiles_Total.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Dias_Habiles_Total.Location = New System.Drawing.Point(423, 109)
        Me.Lbl_Dias_Habiles_Total.Name = "Lbl_Dias_Habiles_Total"
        Me.Lbl_Dias_Habiles_Total.Size = New System.Drawing.Size(75, 23)
        Me.Lbl_Dias_Habiles_Total.TabIndex = 54
        Me.Lbl_Dias_Habiles_Total.Text = "999.999"
        Me.Lbl_Dias_Habiles_Total.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(317, 109)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(100, 23)
        Me.LabelX9.TabIndex = 53
        Me.LabelX9.Text = "Dias habiles total"
        '
        'Frm_Inf_Mg_Vta_Proyec_Utilidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 179)
        Me.Controls.Add(Me.Lbl_Dias_Habiles_Total)
        Me.Controls.Add(Me.LabelX9)
        Me.Controls.Add(Me.Lbl_Dias_Habiles)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.Lbl_Total_Neto)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.Lbl_PPMg)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.Btn_Calcular)
        Me.Controls.Add(Me.Lbl_Utilidad)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.Lbl_Proyeccion_Lineal)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Txt_Costo)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Inf_Mg_Vta_Proyec_Utilidad"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UTILIDAD"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Txt_Costo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Calcular As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Public WithEvents Lbl_Proyeccion_Lineal As DevComponents.DotNetBar.LabelX
    Public WithEvents Lbl_Utilidad As DevComponents.DotNetBar.LabelX
    Public WithEvents Lbl_PPMg As DevComponents.DotNetBar.LabelX
    Public WithEvents Lbl_Total_Neto As DevComponents.DotNetBar.LabelX
    Public WithEvents Lbl_Dias_Habiles As DevComponents.DotNetBar.LabelX
    Public WithEvents Lbl_Dias_Habiles_Total As DevComponents.DotNetBar.LabelX
End Class
