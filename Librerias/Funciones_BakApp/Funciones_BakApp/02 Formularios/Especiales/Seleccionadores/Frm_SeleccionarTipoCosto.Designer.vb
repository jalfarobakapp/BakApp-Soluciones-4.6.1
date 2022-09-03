<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SeleccionarTipoCosto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SeleccionarTipoCosto))
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.RdPMSuc = New System.Windows.Forms.RadioButton
        Me.RdPmTrans = New System.Windows.Forms.RadioButton
        Me.CmbListaDeCostos = New System.Windows.Forms.ComboBox
        Me.RdLP = New System.Windows.Forms.RadioButton
        Me.RdUC = New System.Windows.Forms.RadioButton
        Me.RdPM = New System.Windows.Forms.RadioButton
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnGenerar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.GroupBox5.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox5.Controls.Add(Me.RdPMSuc)
        Me.GroupBox5.Controls.Add(Me.RdPmTrans)
        Me.GroupBox5.Controls.Add(Me.CmbListaDeCostos)
        Me.GroupBox5.Controls.Add(Me.RdLP)
        Me.GroupBox5.Controls.Add(Me.RdUC)
        Me.GroupBox5.Controls.Add(Me.RdPM)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(429, 190)
        Me.GroupBox5.TabIndex = 24
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Datos para considerar costos de los productos "
        '
        'RdPMSuc
        '
        Me.RdPMSuc.AutoSize = True
        Me.RdPMSuc.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RdPMSuc.ForeColor = System.Drawing.Color.Black
        Me.RdPMSuc.Location = New System.Drawing.Point(15, 75)
        Me.RdPMSuc.Name = "RdPMSuc"
        Me.RdPMSuc.Size = New System.Drawing.Size(261, 17)
        Me.RdPMSuc.TabIndex = 10
        Me.RdPMSuc.Text = "Precio promedio ponderado sucursal (PMSUC)"
        Me.RdPMSuc.UseVisualStyleBackColor = False
        '
        'RdPmTrans
        '
        Me.RdPmTrans.AutoSize = True
        Me.RdPmTrans.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RdPmTrans.Checked = True
        Me.RdPmTrans.ForeColor = System.Drawing.Color.Black
        Me.RdPmTrans.Location = New System.Drawing.Point(15, 29)
        Me.RdPmTrans.Name = "RdPmTrans"
        Me.RdPmTrans.Size = New System.Drawing.Size(349, 17)
        Me.RdPmTrans.TabIndex = 9
        Me.RdPmTrans.TabStop = True
        Me.RdPmTrans.Text = "Precio promedio ponderado al momento de la transacción (PM)"
        Me.RdPmTrans.UseVisualStyleBackColor = False
        '
        'CmbListaDeCostos
        '
        Me.CmbListaDeCostos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmbListaDeCostos.ForeColor = System.Drawing.Color.Black
        Me.CmbListaDeCostos.FormattingEnabled = True
        Me.CmbListaDeCostos.Location = New System.Drawing.Point(15, 150)
        Me.CmbListaDeCostos.Name = "CmbListaDeCostos"
        Me.CmbListaDeCostos.Size = New System.Drawing.Size(220, 21)
        Me.CmbListaDeCostos.TabIndex = 8
        '
        'RdLP
        '
        Me.RdLP.AutoSize = True
        Me.RdLP.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RdLP.ForeColor = System.Drawing.Color.Black
        Me.RdLP.Location = New System.Drawing.Point(15, 124)
        Me.RdLP.Name = "RdLP"
        Me.RdLP.Size = New System.Drawing.Size(234, 17)
        Me.RdLP.TabIndex = 7
        Me.RdLP.Text = "Según lista de costo/precio a seleccionar"
        Me.RdLP.UseVisualStyleBackColor = False
        '
        'RdUC
        '
        Me.RdUC.AutoSize = True
        Me.RdUC.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RdUC.ForeColor = System.Drawing.Color.Black
        Me.RdUC.Location = New System.Drawing.Point(15, 101)
        Me.RdUC.Name = "RdUC"
        Me.RdUC.Size = New System.Drawing.Size(132, 17)
        Me.RdUC.TabIndex = 4
        Me.RdUC.Text = "Precio ultima compra"
        Me.RdUC.UseVisualStyleBackColor = False
        '
        'RdPM
        '
        Me.RdPM.AutoSize = True
        Me.RdPM.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RdPM.ForeColor = System.Drawing.Color.Black
        Me.RdPM.Location = New System.Drawing.Point(15, 52)
        Me.RdPM.Name = "RdPM"
        Me.RdPM.Size = New System.Drawing.Size(195, 17)
        Me.RdPM.TabIndex = 1
        Me.RdPM.Text = "Precio promedio ponderado (PM)"
        Me.RdPM.UseVisualStyleBackColor = False
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGenerar, Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 208)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(451, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 28
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
        'Frm_SeleccionarTipoCosto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 249)
        Me.ControlBox = False
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupBox5)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_SeleccionarTipoCosto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar tipo de costeo"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnGenerar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Public WithEvents RdPmTrans As System.Windows.Forms.RadioButton
    Public WithEvents CmbListaDeCostos As System.Windows.Forms.ComboBox
    Public WithEvents RdLP As System.Windows.Forms.RadioButton
    Public WithEvents RdUC As System.Windows.Forms.RadioButton
    Public WithEvents RdPM As System.Windows.Forms.RadioButton
    Public WithEvents RdPMSuc As System.Windows.Forms.RadioButton
End Class
