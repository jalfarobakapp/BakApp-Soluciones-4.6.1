<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ExportarConsultaSQLaExcel
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
        Me.TxtQuerySQL = New System.Windows.Forms.TextBox
        Me.BtnEjecutarConsultaSQL = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TxtQuerySQL
        '
        Me.TxtQuerySQL.Location = New System.Drawing.Point(12, 12)
        Me.TxtQuerySQL.Multiline = True
        Me.TxtQuerySQL.Name = "TxtQuerySQL"
        Me.TxtQuerySQL.Size = New System.Drawing.Size(492, 95)
        Me.TxtQuerySQL.TabIndex = 0
        '
        'BtnEjecutarConsultaSQL
        '
        Me.BtnEjecutarConsultaSQL.Location = New System.Drawing.Point(12, 113)
        Me.BtnEjecutarConsultaSQL.Name = "BtnEjecutarConsultaSQL"
        Me.BtnEjecutarConsultaSQL.Size = New System.Drawing.Size(75, 23)
        Me.BtnEjecutarConsultaSQL.TabIndex = 1
        Me.BtnEjecutarConsultaSQL.Text = "Ejecutar consulta"
        Me.BtnEjecutarConsultaSQL.UseVisualStyleBackColor = True
        '
        'Frm_ExportarConsultaSQLaExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 165)
        Me.Controls.Add(Me.BtnEjecutarConsultaSQL)
        Me.Controls.Add(Me.TxtQuerySQL)
        Me.Name = "Frm_ExportarConsultaSQLaExcel"
        Me.Text = "Frm_ExportarConsultaSQLaExcel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtQuerySQL As System.Windows.Forms.TextBox
    Friend WithEvents BtnEjecutarConsultaSQL As System.Windows.Forms.Button
End Class
