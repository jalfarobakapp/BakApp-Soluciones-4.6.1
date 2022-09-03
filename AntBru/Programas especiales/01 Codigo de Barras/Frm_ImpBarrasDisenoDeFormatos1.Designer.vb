<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ImpBarrasDisenoDeFormatos1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ImpBarrasDisenoDeFormatos1))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Btneditar = New System.Windows.Forms.Button
        Me.Btnnuevabarra = New System.Windows.Forms.Button
        Me.Txtnuevabarra = New System.Windows.Forms.TextBox
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Controls.Add(Me.Btneditar)
        Me.GroupBox2.Controls.Add(Me.Btnnuevabarra)
        Me.GroupBox2.Controls.Add(Me.Txtnuevabarra)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(429, 249)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Etiquetas del sistema"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(13, 56)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(410, 150)
        Me.DataGridView1.TabIndex = 16
        '
        'Btneditar
        '
        Me.Btneditar.Location = New System.Drawing.Point(13, 212)
        Me.Btneditar.Name = "Btneditar"
        Me.Btneditar.Size = New System.Drawing.Size(101, 23)
        Me.Btneditar.TabIndex = 15
        Me.Btneditar.Text = "Editar Barra"
        Me.Btneditar.UseVisualStyleBackColor = True
        '
        'Btnnuevabarra
        '
        Me.Btnnuevabarra.Location = New System.Drawing.Point(349, 30)
        Me.Btnnuevabarra.Name = "Btnnuevabarra"
        Me.Btnnuevabarra.Size = New System.Drawing.Size(74, 20)
        Me.Btnnuevabarra.TabIndex = 14
        Me.Btnnuevabarra.Text = "Nueva "
        Me.Btnnuevabarra.UseVisualStyleBackColor = True
        '
        'Txtnuevabarra
        '
        Me.Txtnuevabarra.Location = New System.Drawing.Point(13, 30)
        Me.Txtnuevabarra.Name = "Txtnuevabarra"
        Me.Txtnuevabarra.Size = New System.Drawing.Size(330, 20)
        Me.Txtnuevabarra.TabIndex = 13
        '
        'Frm_ImpBarrasDisenoDeFormatos1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 274)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_ImpBarrasDisenoDeFormatos1"
        Me.ShowInTaskbar = False
        Me.Text = "Lista etiquetas para barras..."
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Btneditar As System.Windows.Forms.Button
    Friend WithEvents Btnnuevabarra As System.Windows.Forms.Button
    Friend WithEvents Txtnuevabarra As System.Windows.Forms.TextBox
End Class
