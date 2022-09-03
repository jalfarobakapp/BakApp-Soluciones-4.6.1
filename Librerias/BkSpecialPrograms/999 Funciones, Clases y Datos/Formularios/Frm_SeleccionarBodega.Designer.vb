<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SeleccionarBodega
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SeleccionarBodega))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cmbbodega = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Cmbsucursal = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Cmbempresa = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Cmbbodega)
        Me.GroupBox1.Controls.Add(Me.Cmbsucursal)
        Me.GroupBox1.Controls.Add(Me.Cmbempresa)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(396, 177)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Cmbbodega
        '
        Me.Cmbbodega.DisplayMember = "Text"
        Me.Cmbbodega.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmbbodega.ForeColor = System.Drawing.Color.Black
        Me.Cmbbodega.FormattingEnabled = True
        Me.Cmbbodega.ItemHeight = 16
        Me.Cmbbodega.Location = New System.Drawing.Point(10, 148)
        Me.Cmbbodega.Name = "Cmbbodega"
        Me.Cmbbodega.Size = New System.Drawing.Size(376, 22)
        Me.Cmbbodega.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Cmbbodega.TabIndex = 24
        '
        'Cmbsucursal
        '
        Me.Cmbsucursal.DisplayMember = "Text"
        Me.Cmbsucursal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmbsucursal.ForeColor = System.Drawing.Color.Black
        Me.Cmbsucursal.FormattingEnabled = True
        Me.Cmbsucursal.ItemHeight = 16
        Me.Cmbsucursal.Location = New System.Drawing.Point(10, 96)
        Me.Cmbsucursal.Name = "Cmbsucursal"
        Me.Cmbsucursal.Size = New System.Drawing.Size(376, 22)
        Me.Cmbsucursal.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Cmbsucursal.TabIndex = 23
        '
        'Cmbempresa
        '
        Me.Cmbempresa.DisplayMember = "Text"
        Me.Cmbempresa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmbempresa.ForeColor = System.Drawing.Color.Black
        Me.Cmbempresa.FormattingEnabled = True
        Me.Cmbempresa.ItemHeight = 16
        Me.Cmbempresa.Location = New System.Drawing.Point(10, 44)
        Me.Cmbempresa.Name = "Cmbempresa"
        Me.Cmbempresa.Size = New System.Drawing.Size(376, 22)
        Me.Cmbempresa.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Cmbempresa.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 24)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Sucursal"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 24)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Empresa"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(6, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 24)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Bodega"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnAceptar})
        Me.Bar1.Location = New System.Drawing.Point(0, 199)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(423, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 4
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAceptar.ForeColor = System.Drawing.Color.Black
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Text = "Aceptar"
        '
        'Frm_SeleccionarBodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 240)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_SeleccionarBodega"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccion de bodega"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonItem
    Private WithEvents Cmbbodega As DevComponents.DotNetBar.Controls.ComboBoxEx
    Private WithEvents Cmbsucursal As DevComponents.DotNetBar.Controls.ComboBoxEx
    Private WithEvents Cmbempresa As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
