<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtrExportar_Excel
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress
        Me.CircularProgress2 = New DevComponents.DotNetBar.Controls.CircularProgress
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtNombreArchivo = New System.Windows.Forms.TextBox
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnExportarExcel = New DevComponents.DotNetBar.ButtonItem
        Me.BtnVerTabla = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.SvfDirectorio = New System.Windows.Forms.SaveFileDialog
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        Me.BtnBuscarDireccion = New DevComponents.DotNetBar.ButtonX
        Me.GroupBox1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.BtnBuscarDireccion)
        Me.GroupBox1.Controls.Add(Me.CircularProgress1)
        Me.GroupBox1.Controls.Add(Me.CircularProgress2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtNombreArchivo)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 67)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sino selecciona una ubicación quedara en la carpeta por defecto..."
        '
        'CircularProgress1
        '
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Location = New System.Drawing.Point(6, 15)
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.CircularProgress1.ProgressColor = System.Drawing.Color.SteelBlue
        Me.CircularProgress1.ProgressTextVisible = True
        Me.CircularProgress1.Size = New System.Drawing.Size(56, 46)
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress1.TabIndex = 7
        '
        'CircularProgress2
        '
        '
        '
        '
        Me.CircularProgress2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress2.Location = New System.Drawing.Point(56, 15)
        Me.CircularProgress2.Name = "CircularProgress2"
        Me.CircularProgress2.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.CircularProgress2.ProgressColor = System.Drawing.Color.SteelBlue
        Me.CircularProgress2.ProgressTextFormat = "{0}"
        Me.CircularProgress2.ProgressTextVisible = True
        Me.CircularProgress2.Size = New System.Drawing.Size(56, 46)
        Me.CircularProgress2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress2.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(115, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Nombre de archivo de salida (Sin Extención)"
        '
        'TxtNombreArchivo
        '
        Me.TxtNombreArchivo.Location = New System.Drawing.Point(118, 38)
        Me.TxtNombreArchivo.Name = "TxtNombreArchivo"
        Me.TxtNombreArchivo.Size = New System.Drawing.Size(402, 20)
        Me.TxtNombreArchivo.TabIndex = 4
        Me.TxtNombreArchivo.Text = "Datos"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnExportarExcel, Me.BtnVerTabla, Me.BtnCancelar, Me.BtnSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 122)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(583, 57)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 7
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnExportarExcel
        '
        Me.BtnExportarExcel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnExportarExcel.ForeColor = System.Drawing.Color.Black
        Me.BtnExportarExcel.Image = Global.Funciones_BakApp.My.Resources.Resources.export_to_excel
        Me.BtnExportarExcel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnExportarExcel.Name = "BtnExportarExcel"
        Me.BtnExportarExcel.Text = "Exportar"
        '
        'BtnVerTabla
        '
        Me.BtnVerTabla.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnVerTabla.ForeColor = System.Drawing.Color.Black
        Me.BtnVerTabla.Image = Global.Funciones_BakApp.My.Resources.Resources.table_lookup
        Me.BtnVerTabla.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnVerTabla.Name = "BtnVerTabla"
        Me.BtnVerTabla.Text = "Ver detalle..."
        '
        'BtnCancelar
        '
        Me.BtnCancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancelar.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelar.Image = Global.Funciones_BakApp.My.Resources.Resources.delete_button_error1
        Me.BtnCancelar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Text = "Cancelar"
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
        'SvfDirectorio
        '
        Me.SvfDirectorio.FileName = "..\..\..\"
        Me.SvfDirectorio.Filter = "Archivos Excel|*.xlsx"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Location = New System.Drawing.Point(9, 3)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(175, 38)
        Me.ReflectionLabel1.TabIndex = 8
        Me.ReflectionLabel1.Text = "<b><font size=""+6""><i>Exportar</i><font color=""#B02B2C""> a Excel</font></font></b" & _
            ">"
        '
        'BtnBuscarDireccion
        '
        Me.BtnBuscarDireccion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnBuscarDireccion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnBuscarDireccion.Image = Global.Funciones_BakApp.My.Resources.Resources.folder_open
        Me.BtnBuscarDireccion.Location = New System.Drawing.Point(526, 38)
        Me.BtnBuscarDireccion.Name = "BtnBuscarDireccion"
        Me.BtnBuscarDireccion.Size = New System.Drawing.Size(33, 20)
        Me.BtnBuscarDireccion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnBuscarDireccion.TabIndex = 9
        Me.BtnBuscarDireccion.Text = "..."
        '
        'CtrExportar_Excel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "CtrExportar_Excel"
        Me.Size = New System.Drawing.Size(583, 179)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents CircularProgress2 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNombreArchivo As System.Windows.Forms.TextBox
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnExportarExcel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SvfDirectorio As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents BtnVerTabla As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnBuscarDireccion As DevComponents.DotNetBar.ButtonX

End Class
