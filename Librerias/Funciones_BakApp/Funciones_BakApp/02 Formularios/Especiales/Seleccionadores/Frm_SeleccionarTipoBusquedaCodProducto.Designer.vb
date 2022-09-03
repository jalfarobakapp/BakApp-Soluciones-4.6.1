<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SeleccionarTipoBusquedaCodProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SeleccionarTipoBusquedaCodProducto))
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnGenerar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.GrupoBusquedaCod = New System.Windows.Forms.GroupBox
        Me.RdbCodTecnico = New System.Windows.Forms.RadioButton
        Me.RdbCodAlternativo = New System.Windows.Forms.RadioButton
        Me.RdbCodRapido = New System.Windows.Forms.RadioButton
        Me.RdbCodPrincipal = New System.Windows.Forms.RadioButton
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrupoBusquedaCod.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGenerar, Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 79)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(401, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 29
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnGenerar
        '
        Me.BtnGenerar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGenerar.ForeColor = System.Drawing.Color.Black
        Me.BtnGenerar.Image = Global.Funciones_BakApp.My.Resources.Resources.ok_button
        Me.BtnGenerar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Tooltip = "Grabar"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Tooltip = "Salir"
        '
        'GrupoBusquedaCod
        '
        Me.GrupoBusquedaCod.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GrupoBusquedaCod.Controls.Add(Me.RdbCodTecnico)
        Me.GrupoBusquedaCod.Controls.Add(Me.RdbCodAlternativo)
        Me.GrupoBusquedaCod.Controls.Add(Me.RdbCodRapido)
        Me.GrupoBusquedaCod.Controls.Add(Me.RdbCodPrincipal)
        Me.GrupoBusquedaCod.ForeColor = System.Drawing.Color.Black
        Me.GrupoBusquedaCod.Location = New System.Drawing.Point(12, 12)
        Me.GrupoBusquedaCod.Name = "GrupoBusquedaCod"
        Me.GrupoBusquedaCod.Size = New System.Drawing.Size(380, 55)
        Me.GrupoBusquedaCod.TabIndex = 46
        Me.GrupoBusquedaCod.TabStop = False
        Me.GrupoBusquedaCod.Text = "Código de busqueda"
        '
        'RdbCodTecnico
        '
        Me.RdbCodTecnico.AutoSize = True
        Me.RdbCodTecnico.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RdbCodTecnico.ForeColor = System.Drawing.Color.Black
        Me.RdbCodTecnico.Location = New System.Drawing.Point(197, 19)
        Me.RdbCodTecnico.Name = "RdbCodTecnico"
        Me.RdbCodTecnico.Size = New System.Drawing.Size(63, 17)
        Me.RdbCodTecnico.TabIndex = 3
        Me.RdbCodTecnico.Text = "Técnico"
        Me.RdbCodTecnico.UseVisualStyleBackColor = False
        '
        'RdbCodAlternativo
        '
        Me.RdbCodAlternativo.AutoSize = True
        Me.RdbCodAlternativo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RdbCodAlternativo.ForeColor = System.Drawing.Color.Black
        Me.RdbCodAlternativo.Location = New System.Drawing.Point(283, 21)
        Me.RdbCodAlternativo.Name = "RdbCodAlternativo"
        Me.RdbCodAlternativo.Size = New System.Drawing.Size(81, 17)
        Me.RdbCodAlternativo.TabIndex = 2
        Me.RdbCodAlternativo.Text = "Alternativo"
        Me.RdbCodAlternativo.UseVisualStyleBackColor = False
        '
        'RdbCodRapido
        '
        Me.RdbCodRapido.AutoSize = True
        Me.RdbCodRapido.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RdbCodRapido.ForeColor = System.Drawing.Color.Black
        Me.RdbCodRapido.Location = New System.Drawing.Point(99, 21)
        Me.RdbCodRapido.Name = "RdbCodRapido"
        Me.RdbCodRapido.Size = New System.Drawing.Size(62, 17)
        Me.RdbCodRapido.TabIndex = 1
        Me.RdbCodRapido.Text = "Rapido"
        Me.RdbCodRapido.UseVisualStyleBackColor = False
        '
        'RdbCodPrincipal
        '
        Me.RdbCodPrincipal.AutoSize = True
        Me.RdbCodPrincipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RdbCodPrincipal.Checked = True
        Me.RdbCodPrincipal.ForeColor = System.Drawing.Color.Black
        Me.RdbCodPrincipal.Location = New System.Drawing.Point(6, 21)
        Me.RdbCodPrincipal.Name = "RdbCodPrincipal"
        Me.RdbCodPrincipal.Size = New System.Drawing.Size(69, 17)
        Me.RdbCodPrincipal.TabIndex = 0
        Me.RdbCodPrincipal.TabStop = True
        Me.RdbCodPrincipal.Text = "Principal"
        Me.RdbCodPrincipal.UseVisualStyleBackColor = False
        '
        'Frm_SeleccionarTipoBusquedaCodProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 120)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrupoBusquedaCod)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_SeleccionarTipoBusquedaCodProducto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecciones tipo de código de lectura de los productos"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrupoBusquedaCod.ResumeLayout(False)
        Me.GrupoBusquedaCod.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnGenerar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GrupoBusquedaCod As System.Windows.Forms.GroupBox
    Public WithEvents RdbCodTecnico As System.Windows.Forms.RadioButton
    Public WithEvents RdbCodAlternativo As System.Windows.Forms.RadioButton
    Public WithEvents RdbCodRapido As System.Windows.Forms.RadioButton
    Public WithEvents RdbCodPrincipal As System.Windows.Forms.RadioButton
End Class
