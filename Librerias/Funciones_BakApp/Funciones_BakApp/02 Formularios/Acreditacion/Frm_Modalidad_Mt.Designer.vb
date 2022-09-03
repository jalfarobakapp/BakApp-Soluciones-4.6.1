<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Modalidad_Mt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Modalidad_Mt))
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
        Me.BtnxActualizar = New DevComponents.DotNetBar.ButtonX
        Me.BtnxAceptar = New DevComponents.DotNetBar.ButtonX
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter
        Me.Seleccion.SuspendLayout()
        Me.SuspendLayout()
        '
        'Seleccion
        '
        Me.Seleccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        Me.Seleccion.ForeColor = System.Drawing.Color.Black
        Me.Seleccion.Location = New System.Drawing.Point(12, 5)
        Me.Seleccion.Name = "Seleccion"
        Me.Seleccion.Size = New System.Drawing.Size(505, 78)
        Me.Seleccion.TabIndex = 5
        Me.Seleccion.TabStop = False
        Me.Seleccion.Text = "Selección"
        '
        'TxtLPCompra
        '
        Me.TxtLPCompra.BackColor = System.Drawing.Color.White
        Me.TxtLPCompra.ForeColor = System.Drawing.Color.Black
        Me.TxtLPCompra.Location = New System.Drawing.Point(409, 43)
        Me.TxtLPCompra.Name = "TxtLPCompra"
        Me.TxtLPCompra.ReadOnly = True
        Me.TxtLPCompra.Size = New System.Drawing.Size(85, 22)
        Me.TxtLPCompra.TabIndex = 11
        Me.TxtLPCompra.TabStop = False
        Me.TxtLPCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(406, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "L.P. Compra"
        '
        'TxtLPVenta
        '
        Me.TxtLPVenta.BackColor = System.Drawing.Color.White
        Me.TxtLPVenta.ForeColor = System.Drawing.Color.Black
        Me.TxtLPVenta.Location = New System.Drawing.Point(318, 43)
        Me.TxtLPVenta.Name = "TxtLPVenta"
        Me.TxtLPVenta.ReadOnly = True
        Me.TxtLPVenta.Size = New System.Drawing.Size(85, 22)
        Me.TxtLPVenta.TabIndex = 9
        Me.TxtLPVenta.TabStop = False
        Me.TxtLPVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(315, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "L.P. Venta"
        '
        'TxtCaja
        '
        Me.TxtCaja.BackColor = System.Drawing.Color.White
        Me.TxtCaja.ForeColor = System.Drawing.Color.Black
        Me.TxtCaja.Location = New System.Drawing.Point(262, 43)
        Me.TxtCaja.Name = "TxtCaja"
        Me.TxtCaja.ReadOnly = True
        Me.TxtCaja.Size = New System.Drawing.Size(50, 22)
        Me.TxtCaja.TabIndex = 7
        Me.TxtCaja.TabStop = False
        Me.TxtCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(259, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Caja"
        '
        'TxtBodega
        '
        Me.TxtBodega.BackColor = System.Drawing.Color.White
        Me.TxtBodega.ForeColor = System.Drawing.Color.Black
        Me.TxtBodega.Location = New System.Drawing.Point(206, 43)
        Me.TxtBodega.Name = "TxtBodega"
        Me.TxtBodega.ReadOnly = True
        Me.TxtBodega.Size = New System.Drawing.Size(50, 22)
        Me.TxtBodega.TabIndex = 5
        Me.TxtBodega.TabStop = False
        Me.TxtBodega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(203, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Bodega"
        '
        'TxtSucursal
        '
        Me.TxtSucursal.BackColor = System.Drawing.Color.White
        Me.TxtSucursal.ForeColor = System.Drawing.Color.Black
        Me.TxtSucursal.Location = New System.Drawing.Point(150, 43)
        Me.TxtSucursal.Name = "TxtSucursal"
        Me.TxtSucursal.ReadOnly = True
        Me.TxtSucursal.Size = New System.Drawing.Size(50, 22)
        Me.TxtSucursal.TabIndex = 3
        Me.TxtSucursal.TabStop = False
        Me.TxtSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(147, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Sucursal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(15, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Modalidad"
        '
        'CmbModalidad
        '
        Me.CmbModalidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmbModalidad.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmbModalidad.ForeColor = System.Drawing.Color.Black
        Me.CmbModalidad.FormattingEnabled = True
        Me.CmbModalidad.Location = New System.Drawing.Point(18, 43)
        Me.CmbModalidad.Name = "CmbModalidad"
        Me.CmbModalidad.Size = New System.Drawing.Size(123, 21)
        Me.CmbModalidad.TabIndex = 0
        '
        'BtnxActualizar
        '
        Me.BtnxActualizar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnxActualizar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnxActualizar.Image = Global.Funciones_BakApp.My.Resources.Resources.refresh_update
        Me.BtnxActualizar.Location = New System.Drawing.Point(475, 89)
        Me.BtnxActualizar.Name = "BtnxActualizar"
        Me.BtnxActualizar.Size = New System.Drawing.Size(42, 34)
        Me.BtnxActualizar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnxActualizar.TabIndex = 6
        Me.BtnxActualizar.Tooltip = "Actualizar"
        '
        'BtnxAceptar
        '
        Me.BtnxAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnxAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Highlighter1.SetHighlightOnFocus(Me.BtnxAceptar, True)
        Me.BtnxAceptar.Image = Global.Funciones_BakApp.My.Resources.Resources.ok_button
        Me.BtnxAceptar.Location = New System.Drawing.Point(12, 89)
        Me.BtnxAceptar.Name = "BtnxAceptar"
        Me.BtnxAceptar.Size = New System.Drawing.Size(89, 34)
        Me.BtnxAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnxAceptar.TabIndex = 1
        Me.BtnxAceptar.Text = "Aceptar"
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Frm_Modalidad_Mt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 125)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnxActualizar)
        Me.Controls.Add(Me.BtnxAceptar)
        Me.Controls.Add(Me.Seleccion)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Modalidad_Mt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione Modalidad"
        Me.Seleccion.ResumeLayout(False)
        Me.Seleccion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Seleccion As System.Windows.Forms.GroupBox
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbModalidad As System.Windows.Forms.ComboBox
    Friend WithEvents BtnxAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnxActualizar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
End Class
