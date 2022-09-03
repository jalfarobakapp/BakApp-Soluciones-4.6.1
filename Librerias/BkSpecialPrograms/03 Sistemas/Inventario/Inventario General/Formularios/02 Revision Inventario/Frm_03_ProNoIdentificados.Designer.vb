<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_03_ProNoIdentificados
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GrillaProductosDesconocidos = New System.Windows.Forms.DataGridView
        Me.GroupBox5.SuspendLayout()
        CType(Me.GrillaProductosDesconocidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.White
        Me.GroupBox5.Controls.Add(Me.GrillaProductosDesconocidos)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(0, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(654, 426)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Detalle de inventario"
        '
        'GrillaProductosDesconocidos
        '
        Me.GrillaProductosDesconocidos.AllowUserToAddRows = False
        Me.GrillaProductosDesconocidos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaProductosDesconocidos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GrillaProductosDesconocidos.BackgroundColor = System.Drawing.Color.White
        Me.GrillaProductosDesconocidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaProductosDesconocidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrillaProductosDesconocidos.Location = New System.Drawing.Point(3, 18)
        Me.GrillaProductosDesconocidos.Name = "GrillaProductosDesconocidos"
        Me.GrillaProductosDesconocidos.ReadOnly = True
        Me.GrillaProductosDesconocidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaProductosDesconocidos.Size = New System.Drawing.Size(648, 405)
        Me.GrillaProductosDesconocidos.TabIndex = 0
        '
        'Frm_03_ProNoIdentificados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 489)
        Me.Controls.Add(Me.GroupBox5)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_03_ProNoIdentificados"
        Me.ShowInTaskbar = False
        Me.Text = "MetroForm"
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.GrillaProductosDesconocidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GrillaProductosDesconocidos As System.Windows.Forms.DataGridView
End Class
