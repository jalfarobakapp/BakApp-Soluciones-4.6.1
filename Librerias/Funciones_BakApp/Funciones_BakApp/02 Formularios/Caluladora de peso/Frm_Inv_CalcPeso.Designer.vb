<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Inv_CalcPeso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inv_CalcPeso))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnCalcular = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.CmbMuestras = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtTotalUnidades = New System.Windows.Forms.TextBox
        Me.TxtTara = New System.Windows.Forms.TextBox
        Me.TxtPesoTotal = New System.Windows.Forms.TextBox
        Me.TxtPesoMuestra = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolsCalculadora = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnCalcular)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.CmbMuestras)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(847, 78)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'BtnCalcular
        '
        Me.BtnCalcular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCalcular.Image = Global.Funciones_BakApp.My.Resources.Resources.calculator
        Me.BtnCalcular.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCalcular.Location = New System.Drawing.Point(740, 14)
        Me.BtnCalcular.Name = "BtnCalcular"
        Me.BtnCalcular.Size = New System.Drawing.Size(95, 58)
        Me.BtnCalcular.TabIndex = 3
        Me.BtnCalcular.Text = "CALCULAR"
        Me.BtnCalcular.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnCalcular.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(238, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(111, 25)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Unidades"
        '
        'CmbMuestras
        '
        Me.CmbMuestras.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbMuestras.FormattingEnabled = True
        Me.CmbMuestras.Items.AddRange(New Object() {"10", "50", "100", "150", "200"})
        Me.CmbMuestras.Location = New System.Drawing.Point(168, 30)
        Me.CmbMuestras.Name = "CmbMuestras"
        Me.CmbMuestras.Size = New System.Drawing.Size(64, 33)
        Me.CmbMuestras.TabIndex = 1
        Me.CmbMuestras.Text = "10"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(19, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 25)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Muestra de :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TxtTotalUnidades)
        Me.GroupBox2.Controls.Add(Me.TxtTara)
        Me.GroupBox2.Controls.Add(Me.TxtPesoTotal)
        Me.GroupBox2.Controls.Add(Me.TxtPesoMuestra)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 127)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(847, 343)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(742, 194)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 25)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Gramos"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(742, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 25)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Gramos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(742, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 25)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Gramos"
        '
        'TxtTotalUnidades
        '
        Me.TxtTotalUnidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalUnidades.Location = New System.Drawing.Point(453, 254)
        Me.TxtTotalUnidades.Name = "TxtTotalUnidades"
        Me.TxtTotalUnidades.ReadOnly = True
        Me.TxtTotalUnidades.Size = New System.Drawing.Size(283, 62)
        Me.TxtTotalUnidades.TabIndex = 7
        Me.TxtTotalUnidades.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtTara
        '
        Me.TxtTara.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTara.ForeColor = System.Drawing.Color.Red
        Me.TxtTara.Location = New System.Drawing.Point(453, 167)
        Me.TxtTara.Name = "TxtTara"
        Me.TxtTara.Size = New System.Drawing.Size(283, 62)
        Me.TxtTara.TabIndex = 6
        Me.TxtTara.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtPesoTotal
        '
        Me.TxtPesoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPesoTotal.Location = New System.Drawing.Point(453, 99)
        Me.TxtPesoTotal.Name = "TxtPesoTotal"
        Me.TxtPesoTotal.Size = New System.Drawing.Size(283, 62)
        Me.TxtPesoTotal.TabIndex = 5
        Me.TxtPesoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtPesoMuestra
        '
        Me.TxtPesoMuestra.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPesoMuestra.Location = New System.Drawing.Point(453, 31)
        Me.TxtPesoMuestra.Name = "TxtPesoMuestra"
        Me.TxtPesoMuestra.Size = New System.Drawing.Size(283, 62)
        Me.TxtPesoMuestra.TabIndex = 4
        Me.TxtPesoMuestra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 257)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(423, 55)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Total de unidades"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 55)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Tara"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(247, 55)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Peso total"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(403, 55)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Peso de muestra"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolsCalculadora})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(871, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolsCalculadora
        '
        Me.ToolsCalculadora.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolsCalculadora.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolsCalculadora.Name = "ToolsCalculadora"
        Me.ToolsCalculadora.Size = New System.Drawing.Size(23, 22)
        Me.ToolsCalculadora.Text = "ToolStripButton1"
        '
        'Frm_Inv_CalcPeso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 483)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(887, 521)
        Me.MinimumSize = New System.Drawing.Size(887, 521)
        Me.Name = "Frm_Inv_CalcPeso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calculadora de cantidades por peso"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtTotalUnidades As System.Windows.Forms.TextBox
    Friend WithEvents TxtTara As System.Windows.Forms.TextBox
    Friend WithEvents TxtPesoTotal As System.Windows.Forms.TextBox
    Friend WithEvents TxtPesoMuestra As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbMuestras As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolsCalculadora As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCalcular As System.Windows.Forms.Button
End Class
