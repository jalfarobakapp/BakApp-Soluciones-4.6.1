<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Modalidad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Modalidad))
        Me.BtnIngresar = New System.Windows.Forms.Button
        Me.Seleccion = New System.Windows.Forms.GroupBox
        Me.TxtLPCompra = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtLPVenta = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtCaja = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtBodega = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtSucursal = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbModalidad = New System.Windows.Forms.ComboBox
        Me.Seleccion.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnIngresar
        '
        Me.BtnIngresar.Location = New System.Drawing.Point(12, 96)
        Me.BtnIngresar.Name = "BtnIngresar"
        Me.BtnIngresar.Size = New System.Drawing.Size(200, 23)
        Me.BtnIngresar.TabIndex = 0
        Me.BtnIngresar.Text = "Seleccionar Modalidad"
        Me.BtnIngresar.UseVisualStyleBackColor = True
        '
        'Seleccion
        '
        Me.Seleccion.Controls.Add(Me.TxtLPCompra)
        Me.Seleccion.Controls.Add(Me.Label6)
        Me.Seleccion.Controls.Add(Me.TxtLPVenta)
        Me.Seleccion.Controls.Add(Me.Label5)
        Me.Seleccion.Controls.Add(Me.TxtCaja)
        Me.Seleccion.Controls.Add(Me.Label4)
        Me.Seleccion.Controls.Add(Me.TxtBodega)
        Me.Seleccion.Controls.Add(Me.Label3)
        Me.Seleccion.Controls.Add(Me.TxtSucursal)
        Me.Seleccion.Controls.Add(Me.Label2)
        Me.Seleccion.Controls.Add(Me.Label1)
        Me.Seleccion.Controls.Add(Me.CmbModalidad)
        Me.Seleccion.Location = New System.Drawing.Point(12, 12)
        Me.Seleccion.Name = "Seleccion"
        Me.Seleccion.Size = New System.Drawing.Size(505, 78)
        Me.Seleccion.TabIndex = 4
        Me.Seleccion.TabStop = False
        Me.Seleccion.Text = "Selección"
        '
        'TxtLPCompra
        '
        Me.TxtLPCompra.Location = New System.Drawing.Point(409, 43)
        Me.TxtLPCompra.Name = "TxtLPCompra"
        Me.TxtLPCompra.ReadOnly = True
        Me.TxtLPCompra.Size = New System.Drawing.Size(85, 20)
        Me.TxtLPCompra.TabIndex = 11
        Me.TxtLPCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(406, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "L.P. Compra"
        '
        'TxtLPVenta
        '
        Me.TxtLPVenta.Location = New System.Drawing.Point(318, 43)
        Me.TxtLPVenta.Name = "TxtLPVenta"
        Me.TxtLPVenta.ReadOnly = True
        Me.TxtLPVenta.Size = New System.Drawing.Size(85, 20)
        Me.TxtLPVenta.TabIndex = 9
        Me.TxtLPVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(315, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "L.P. Venta"
        '
        'TxtCaja
        '
        Me.TxtCaja.Location = New System.Drawing.Point(262, 43)
        Me.TxtCaja.Name = "TxtCaja"
        Me.TxtCaja.ReadOnly = True
        Me.TxtCaja.Size = New System.Drawing.Size(50, 20)
        Me.TxtCaja.TabIndex = 7
        Me.TxtCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(259, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Caja"
        '
        'TxtBodega
        '
        Me.TxtBodega.Location = New System.Drawing.Point(206, 43)
        Me.TxtBodega.Name = "TxtBodega"
        Me.TxtBodega.ReadOnly = True
        Me.TxtBodega.Size = New System.Drawing.Size(50, 20)
        Me.TxtBodega.TabIndex = 5
        Me.TxtBodega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(203, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Bodega"
        '
        'TxtSucursal
        '
        Me.TxtSucursal.Location = New System.Drawing.Point(150, 43)
        Me.TxtSucursal.Name = "TxtSucursal"
        Me.TxtSucursal.ReadOnly = True
        Me.TxtSucursal.Size = New System.Drawing.Size(50, 20)
        Me.TxtSucursal.TabIndex = 3
        Me.TxtSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(147, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Sucursal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Modalidad"
        '
        'CmbModalidad
        '
        Me.CmbModalidad.FormattingEnabled = True
        Me.CmbModalidad.Location = New System.Drawing.Point(18, 43)
        Me.CmbModalidad.Name = "CmbModalidad"
        Me.CmbModalidad.Size = New System.Drawing.Size(123, 21)
        Me.CmbModalidad.TabIndex = 0
        '
        'Frm_Modalidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 131)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnIngresar)
        Me.Controls.Add(Me.Seleccion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Modalidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione Modalidad"
        Me.Seleccion.ResumeLayout(False)
        Me.Seleccion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnIngresar As System.Windows.Forms.Button
    Friend WithEvents Seleccion As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbModalidad As System.Windows.Forms.ComboBox
    Friend WithEvents TxtLPCompra As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtLPVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtBodega As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
