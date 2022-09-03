<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Familias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Familias))
        Me.Grupo = New System.Windows.Forms.GroupBox
        Me.GrillaFamilias = New System.Windows.Forms.DataGridView
        Me.LblFamilia = New System.Windows.Forms.Label
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnEditar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnEliminar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnVolver = New DevComponents.DotNetBar.ButtonItem
        Me.BtnxSalir = New DevComponents.DotNetBar.ButtonItem
        Me.Label3 = New System.Windows.Forms.Label
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.Grupo.SuspendLayout()
        CType(Me.GrillaFamilias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grupo
        '
        Me.Grupo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo.Controls.Add(Me.GrillaFamilias)
        Me.Grupo.ForeColor = System.Drawing.Color.Black
        Me.Grupo.Location = New System.Drawing.Point(12, 93)
        Me.Grupo.Name = "Grupo"
        Me.Grupo.Size = New System.Drawing.Size(386, 325)
        Me.Grupo.TabIndex = 0
        Me.Grupo.TabStop = False
        Me.Grupo.Text = "Detalle"
        '
        'GrillaFamilias
        '
        Me.GrillaFamilias.AllowUserToOrderColumns = True
        Me.GrillaFamilias.BackgroundColor = System.Drawing.Color.White
        Me.GrillaFamilias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaFamilias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrillaFamilias.Location = New System.Drawing.Point(3, 18)
        Me.GrillaFamilias.Name = "GrillaFamilias"
        Me.GrillaFamilias.Size = New System.Drawing.Size(380, 304)
        Me.GrillaFamilias.TabIndex = 0
        '
        'LblFamilia
        '
        Me.LblFamilia.AutoSize = True
        Me.LblFamilia.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblFamilia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblFamilia.ForeColor = System.Drawing.Color.Black
        Me.LblFamilia.Location = New System.Drawing.Point(61, 19)
        Me.LblFamilia.Name = "LblFamilia"
        Me.LblFamilia.Size = New System.Drawing.Size(212, 15)
        Me.LblFamilia.TabIndex = 1
        Me.LblFamilia.Text = "SUPER FAMILIA - FAMILIA - SUB FAMILIA"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnAceptar, Me.BtnEditar, Me.BtnEliminar, Me.BtnVolver, Me.BtnxSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 424)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(401, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 11
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAceptar.ForeColor = System.Drawing.Color.Black
        Me.BtnAceptar.Image = Global.Funciones_BakApp.My.Resources.Resources.save
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Text = "Grabar cambios"
        '
        'BtnEditar
        '
        Me.BtnEditar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnEditar.FontBold = True
        Me.BtnEditar.ForeColor = System.Drawing.Color.Navy
        Me.BtnEditar.Name = "BtnEditar"
        Me.BtnEditar.Tooltip = "Editar"
        Me.BtnEditar.Visible = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnEliminar.FontBold = True
        Me.BtnEliminar.ForeColor = System.Drawing.Color.Navy
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Tooltip = "Eliminar"
        Me.BtnEliminar.Visible = False
        '
        'BtnVolver
        '
        Me.BtnVolver.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnVolver.ForeColor = System.Drawing.Color.Black
        Me.BtnVolver.Image = Global.Funciones_BakApp.My.Resources.Resources.arrow_left
        Me.BtnVolver.Name = "BtnVolver"
        Me.BtnVolver.Text = "Volver"
        '
        'BtnxSalir
        '
        Me.BtnxSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnxSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnxSalir.Image = Global.Funciones_BakApp.My.Resources.Resources.button_rounded_red_delete
        Me.BtnxSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnxSalir.Name = "BtnxSalir"
        Me.BtnxSalir.Text = "Salir"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Origen"
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.White
        Me.TreeView1.ForeColor = System.Drawing.Color.Black
        Me.TreeView1.Location = New System.Drawing.Point(404, 47)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(330, 371)
        Me.TreeView1.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(15, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Buscar descripción..."
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.BackColor = System.Drawing.Color.White
        Me.TxtDescripcion.ForeColor = System.Drawing.Color.Black
        Me.TxtDescripcion.Location = New System.Drawing.Point(133, 59)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(265, 22)
        Me.TxtDescripcion.TabIndex = 15
        '
        'Frm_Familias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 465)
        Me.ControlBox = False
        Me.Controls.Add(Me.TxtDescripcion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.LblFamilia)
        Me.Controls.Add(Me.Grupo)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Familias"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantención de tablas de Familias..."
        Me.Grupo.ResumeLayout(False)
        CType(Me.GrillaFamilias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grupo As System.Windows.Forms.GroupBox
    Friend WithEvents GrillaFamilias As System.Windows.Forms.DataGridView
    Friend WithEvents LblFamilia As System.Windows.Forms.Label
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnxSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents BtnVolver As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents BtnEliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnEditar As DevComponents.DotNetBar.ButtonItem
End Class
