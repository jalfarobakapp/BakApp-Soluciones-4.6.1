<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ctr_Sql2Excel
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnSQL = New DevComponents.DotNetBar.ButtonItem
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtQuerySQL
        '
        Me.TxtQuerySQL.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtQuerySQL.Location = New System.Drawing.Point(9, 45)
        Me.TxtQuerySQL.Multiline = True
        Me.TxtQuerySQL.Name = "TxtQuerySQL"
        Me.TxtQuerySQL.Size = New System.Drawing.Size(690, 270)
        Me.TxtQuerySQL.TabIndex = 1
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnSQL, Me.BtnSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 334)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(709, 57)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 8
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnSQL
        '
        Me.BtnSQL.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSQL.ForeColor = System.Drawing.Color.Black
        Me.BtnSQL.Image = Global.Funciones_BakApp.My.Resources.Resources.sql_check
        Me.BtnSQL.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSQL.Name = "BtnSQL"
        Me.BtnSQL.Text = "Ejecutar consulta SQL"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = Global.Funciones_BakApp.My.Resources.Resources.arrow_left
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Text = "Volver..."
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Location = New System.Drawing.Point(9, 0)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(175, 46)
        Me.ReflectionLabel1.TabIndex = 9
        Me.ReflectionLabel1.Text = "<b><font size=""+6""><i>SQL</i><font color=""#B02B2C"">2Excel</font></font></b>"
        '
        'Ctr_Sql2Excel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.TxtQuerySQL)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Name = "Ctr_Sql2Excel"
        Me.Size = New System.Drawing.Size(709, 391)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtQuerySQL As System.Windows.Forms.TextBox
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSQL As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel

End Class
