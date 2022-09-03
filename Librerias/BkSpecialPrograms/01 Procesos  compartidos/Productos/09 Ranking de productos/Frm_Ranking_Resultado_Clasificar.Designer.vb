<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Ranking_Resultado_Clasificar
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Ranking_Resultado_Clasificar))
        Me.GrillaClasRK = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnRevInfAnterior = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Clasificar_Rk = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.TxtDescripcionRk = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LblEstado1 = New DevComponents.DotNetBar.LabelX()
        Me.BtnGrabarRankingTop = New DevComponents.DotNetBar.ButtonItem()
        Me.Imagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        CType(Me.GrillaClasRK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrillaClasRK
        '
        Me.GrillaClasRK.AllowUserToAddRows = False
        Me.GrillaClasRK.AllowUserToDeleteRows = False
        Me.GrillaClasRK.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaClasRK.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrillaClasRK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GrillaClasRK.DefaultCellStyle = DataGridViewCellStyle2
        Me.GrillaClasRK.EnableHeadersVisualStyles = False
        Me.GrillaClasRK.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.GrillaClasRK.Location = New System.Drawing.Point(12, 23)
        Me.GrillaClasRK.Name = "GrillaClasRK"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaClasRK.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.GrillaClasRK.RowHeadersVisible = False
        Me.GrillaClasRK.Size = New System.Drawing.Size(605, 204)
        Me.GrillaClasRK.TabIndex = 33
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnRevInfAnterior, Me.Btn_Clasificar_Rk, Me.Btn_Cancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 367)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(630, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 34
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnRevInfAnterior
        '
        Me.BtnRevInfAnterior.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnRevInfAnterior.ForeColor = System.Drawing.Color.Black
        Me.BtnRevInfAnterior.Name = "BtnRevInfAnterior"
        Me.BtnRevInfAnterior.Tooltip = "Ver ultimo informe"
        '
        'Btn_Clasificar_Rk
        '
        Me.Btn_Clasificar_Rk.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Clasificar_Rk.ForeColor = System.Drawing.Color.Black
        Me.Btn_Clasificar_Rk.Image = CType(resources.GetObject("Btn_Clasificar_Rk.Image"), System.Drawing.Image)
        Me.Btn_Clasificar_Rk.Name = "Btn_Clasificar_Rk"
        Me.Btn_Clasificar_Rk.Text = "Clasificar Ranking de productos"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar"
        '
        'TxtDescripcionRk
        '
        Me.TxtDescripcionRk.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtDescripcionRk.Border.Class = "TextBoxBorder"
        Me.TxtDescripcionRk.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDescripcionRk.DisabledBackColor = System.Drawing.Color.White
        Me.TxtDescripcionRk.ForeColor = System.Drawing.Color.Black
        Me.TxtDescripcionRk.Location = New System.Drawing.Point(3, 13)
        Me.TxtDescripcionRk.Multiline = True
        Me.TxtDescripcionRk.Name = "TxtDescripcionRk"
        Me.TxtDescripcionRk.PreventEnterBeep = True
        Me.TxtDescripcionRk.ReadOnly = True
        Me.TxtDescripcionRk.Size = New System.Drawing.Size(593, 61)
        Me.TxtDescripcionRk.TabIndex = 0
        '
        'LblEstado1
        '
        Me.LblEstado1.AutoSize = True
        Me.LblEstado1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LblEstado1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblEstado1.ForeColor = System.Drawing.Color.Black
        Me.LblEstado1.Location = New System.Drawing.Point(12, 339)
        Me.LblEstado1.Name = "LblEstado1"
        Me.LblEstado1.Size = New System.Drawing.Size(41, 17)
        Me.LblEstado1.TabIndex = 36
        Me.LblEstado1.Text = "LabelX1"
        '
        'BtnGrabarRankingTop
        '
        Me.BtnGrabarRankingTop.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabarRankingTop.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabarRankingTop.Name = "BtnGrabarRankingTop"
        Me.BtnGrabarRankingTop.Text = "Grabar clasificación..."
        '
        'Imagenes
        '
        Me.Imagenes.ImageStream = CType(resources.GetObject("Imagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes.Images.SetKeyName(0, "Star 0.png")
        Me.Imagenes.Images.SetKeyName(1, "Star 1.png")
        Me.Imagenes.Images.SetKeyName(2, "Star 2.png")
        Me.Imagenes.Images.SetKeyName(3, "Star 3.png")
        Me.Imagenes.Images.SetKeyName(4, "Star 4.png")
        Me.Imagenes.Images.SetKeyName(5, "Star 5.png")
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TxtDescripcionRk)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 233)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(605, 100)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 37
        Me.GroupPanel1.Text = "Descripción del Ranking seleccionado..."
        '
        'Frm_Ranking_Resultado_Clasificar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 408)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.LblEstado1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GrillaClasRK)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Ranking_Resultado_Clasificar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Marcar Ranking de productos"
        CType(Me.GrillaClasRK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GrillaClasRK As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnRevInfAnterior As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Clasificar_Rk As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TxtDescripcionRk As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LblEstado1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnGrabarRankingTop As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Imagenes As System.Windows.Forms.ImageList
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
End Class
