<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dte2Imp_
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dte2Imp_))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnImportar = New DevComponents.DotNetBar.ButtonItem()
        Me.ChkMarcaAgua = New DevComponents.DotNetBar.CheckBoxItem()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnBuscarProducto = New DevComponents.DotNetBar.ButtonX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNombreArchivo = New System.Windows.Forms.TextBox()
        Me.OpenBuscarImagen = New System.Windows.Forms.OpenFileDialog()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Location = New System.Drawing.Point(9, 1)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(472, 38)
        Me.ReflectionLabel1.TabIndex = 11
        Me.ReflectionLabel1.Text = "<b><font size=""+6""><i>Importar</i><font color=""#B02B2C""> archivo DTE.xml para con" &
    "vertir en PDF</font></font></b>"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnImportar, Me.ChkMarcaAgua, Me.BtnSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 113)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(583, 57)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 10
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnImportar
        '
        Me.BtnImportar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnImportar.ForeColor = System.Drawing.Color.Black
        Me.BtnImportar.Image = Global.BkSpecialPrograms.My.Resources.Resources.save_as_pdf
        Me.BtnImportar.Name = "BtnImportar"
        Me.BtnImportar.Text = "Importar a Pdf"
        '
        'ChkMarcaAgua
        '
        Me.ChkMarcaAgua.Name = "ChkMarcaAgua"
        Me.ChkMarcaAgua.Text = "Imprimir marca de agua (Uso interno)"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Text = "Volver..."
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.BtnBuscarProducto)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtNombreArchivo)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 67)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'BtnBuscarProducto
        '
        Me.BtnBuscarProducto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnBuscarProducto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnBuscarProducto.Image = Global.BkSpecialPrograms.My.Resources.Resources.folder_open1
        Me.BtnBuscarProducto.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnBuscarProducto.Location = New System.Drawing.Point(539, 38)
        Me.BtnBuscarProducto.Name = "BtnBuscarProducto"
        Me.BtnBuscarProducto.Size = New System.Drawing.Size(27, 20)
        Me.BtnBuscarProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnBuscarProducto.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Dirección del archivo de origen."
        '
        'TxtNombreArchivo
        '
        Me.TxtNombreArchivo.Location = New System.Drawing.Point(6, 38)
        Me.TxtNombreArchivo.Name = "TxtNombreArchivo"
        Me.TxtNombreArchivo.ReadOnly = True
        Me.TxtNombreArchivo.Size = New System.Drawing.Size(527, 20)
        Me.TxtNombreArchivo.TabIndex = 4
        Me.TxtNombreArchivo.Text = "C:\"
        '
        'OpenBuscarImagen
        '
        Me.OpenBuscarImagen.FileName = "OpenFileDialog1"
        '
        'Dte2Imp_
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Dte2Imp_"
        Me.Size = New System.Drawing.Size(583, 170)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnImportar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNombreArchivo As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscarProducto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents OpenBuscarImagen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ChkMarcaAgua As DevComponents.DotNetBar.CheckBoxItem

End Class
