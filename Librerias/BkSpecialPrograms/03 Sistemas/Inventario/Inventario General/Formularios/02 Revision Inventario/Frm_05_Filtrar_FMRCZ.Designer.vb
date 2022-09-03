<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_05_Filtrar_FMRCZ
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_05_Filtrar_FMRCZ))
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.TxtTotalCUC = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.TxtTotalPPP = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.CmbxFamilia = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.CmbxSubFamilia = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.CmbxSuperFamilia = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Grilla = New System.Windows.Forms.DataGridView
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnActualizar = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.GroupBox2.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(13, 445)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 78
        Me.LabelX2.Text = "Total C.Ult.C."
        '
        'TxtTotalCUC
        '
        Me.TxtTotalCUC.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtTotalCUC.Border.Class = "TextBoxBorder"
        Me.TxtTotalCUC.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtTotalCUC.ForeColor = System.Drawing.Color.Black
        Me.TxtTotalCUC.Location = New System.Drawing.Point(94, 448)
        Me.TxtTotalCUC.Name = "TxtTotalCUC"
        Me.TxtTotalCUC.PreventEnterBeep = True
        Me.TxtTotalCUC.ReadOnly = True
        Me.TxtTotalCUC.Size = New System.Drawing.Size(138, 22)
        Me.TxtTotalCUC.TabIndex = 77
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(13, 416)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 76
        Me.LabelX1.Text = "Total P.P.P"
        '
        'TxtTotalPPP
        '
        Me.TxtTotalPPP.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtTotalPPP.Border.Class = "TextBoxBorder"
        Me.TxtTotalPPP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtTotalPPP.ForeColor = System.Drawing.Color.Black
        Me.TxtTotalPPP.Location = New System.Drawing.Point(94, 419)
        Me.TxtTotalPPP.Name = "TxtTotalPPP"
        Me.TxtTotalPPP.PreventEnterBeep = True
        Me.TxtTotalPPP.ReadOnly = True
        Me.TxtTotalPPP.Size = New System.Drawing.Size(138, 22)
        Me.TxtTotalPPP.TabIndex = 75
        '
        'CmbxFamilia
        '
        Me.CmbxFamilia.DisplayMember = "Text"
        Me.CmbxFamilia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbxFamilia.ForeColor = System.Drawing.Color.Black
        Me.CmbxFamilia.ItemHeight = 16
        Me.CmbxFamilia.Location = New System.Drawing.Point(267, 26)
        Me.CmbxFamilia.Name = "CmbxFamilia"
        Me.CmbxFamilia.Size = New System.Drawing.Size(246, 22)
        Me.CmbxFamilia.TabIndex = 70
        Me.CmbxFamilia.WatermarkText = "Filtrar Familia"
        '
        'CmbxSubFamilia
        '
        Me.CmbxSubFamilia.DisplayMember = "Text"
        Me.CmbxSubFamilia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbxSubFamilia.ForeColor = System.Drawing.Color.Black
        Me.CmbxSubFamilia.ItemHeight = 16
        Me.CmbxSubFamilia.Location = New System.Drawing.Point(519, 25)
        Me.CmbxSubFamilia.Name = "CmbxSubFamilia"
        Me.CmbxSubFamilia.Size = New System.Drawing.Size(246, 22)
        Me.CmbxSubFamilia.TabIndex = 69
        Me.CmbxSubFamilia.WatermarkText = "Filtrar Sub-Familia"
        '
        'CmbxSuperFamilia
        '
        Me.CmbxSuperFamilia.DisplayMember = "Text"
        Me.CmbxSuperFamilia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbxSuperFamilia.ForeColor = System.Drawing.Color.Black
        Me.CmbxSuperFamilia.ItemHeight = 16
        Me.CmbxSuperFamilia.Location = New System.Drawing.Point(12, 26)
        Me.CmbxSuperFamilia.Name = "CmbxSuperFamilia"
        Me.CmbxSuperFamilia.Size = New System.Drawing.Size(249, 22)
        Me.CmbxSuperFamilia.TabIndex = 68
        Me.CmbxSuperFamilia.WatermarkText = "Filtrar Super familia"
        '
        'LabelX22
        '
        Me.LabelX22.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX22.ForeColor = System.Drawing.Color.Black
        Me.LabelX22.Location = New System.Drawing.Point(15, 6)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(89, 23)
        Me.LabelX22.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX22.TabIndex = 71
        Me.LabelX22.Text = "Super Familia"
        '
        'LabelX23
        '
        Me.LabelX23.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX23.ForeColor = System.Drawing.Color.Black
        Me.LabelX23.Location = New System.Drawing.Point(267, 6)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(89, 23)
        Me.LabelX23.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX23.TabIndex = 72
        Me.LabelX23.Text = "Familia"
        '
        'LabelX24
        '
        Me.LabelX24.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX24.ForeColor = System.Drawing.Color.Black
        Me.LabelX24.Location = New System.Drawing.Point(519, 6)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(89, 23)
        Me.LabelX24.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX24.TabIndex = 73
        Me.LabelX24.Text = "Sub-Familia"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.Grilla)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(12, 54)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(755, 359)
        Me.GroupBox2.TabIndex = 67
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle de inventario"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grilla.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.Location = New System.Drawing.Point(3, 18)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(749, 338)
        Me.Grilla.TabIndex = 0
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnActualizar, Me.ButtonItem1, Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 489)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(778, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 79
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnActualizar
        '
        Me.BtnActualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnActualizar.ForeColor = System.Drawing.Color.Black
        Me.BtnActualizar.Image = Global.BkSpecialPrograms.My.Resources.Resources.document_refresh1
        Me.BtnActualizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnActualizar.Name = "BtnActualizar"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.ForeColor = System.Drawing.Color.Black
        Me.ButtonItem1.Image = Global.BkSpecialPrograms.My.Resources.Resources.export_to_excel
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "Exportar a Excel"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = Global.BkSpecialPrograms.My.Resources.Resources.button_rounded_red_delete
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        '
        'Frm_05_Filtrar_FMRCZ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 530)
        Me.ControlBox = False
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.TxtTotalCUC)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.TxtTotalPPP)
        Me.Controls.Add(Me.CmbxFamilia)
        Me.Controls.Add(Me.CmbxSubFamilia)
        Me.Controls.Add(Me.CmbxSuperFamilia)
        Me.Controls.Add(Me.LabelX22)
        Me.Controls.Add(Me.LabelX23)
        Me.Controls.Add(Me.LabelX24)
        Me.Controls.Add(Me.GroupBox2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_05_Filtrar_FMRCZ"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtrar por Familia, Rubro, Marca, Clasificación libre o Zona"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtTotalCUC As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtTotalPPP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents CmbxFamilia As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CmbxSubFamilia As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CmbxSuperFamilia As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Grilla As System.Windows.Forms.DataGridView
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnActualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
End Class
