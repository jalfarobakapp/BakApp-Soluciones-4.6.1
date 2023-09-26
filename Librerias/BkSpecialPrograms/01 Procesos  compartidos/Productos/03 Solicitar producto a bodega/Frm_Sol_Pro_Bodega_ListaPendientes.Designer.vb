<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Sol_Pro_Bodega_ListaPendientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Sol_Pro_Bodega_ListaPendientes))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_VerTraza = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Ver_Informacion_de_producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnActualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnExportarExcel = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnxSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.TxtCodigoSol = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Radio1 = New DevComponents.DotNetBar.Command(Me.components)
        Me.Radio2 = New DevComponents.DotNetBar.Command(Me.components)
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Radio3 = New DevComponents.DotNetBar.Command(Me.components)
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.DtpFecharevision = New System.Windows.Forms.DateTimePicker()
        Me.Chk_Validar_Usuario_Con_Huella = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ReflectionImage2 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(8, 49)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(906, 432)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.Color.White
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
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
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
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
        Me.GroupPanel1.TabIndex = 0
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(287, 203)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(330, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 56
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Mnu_Btn_VerTraza, Me.Mnu_Btn_Ver_Informacion_de_producto})
        Me.Menu_Contextual_01.Text = "Opciones"
        '
        'Mnu_Btn_VerTraza
        '
        Me.Mnu_Btn_VerTraza.Image = CType(resources.GetObject("Mnu_Btn_VerTraza.Image"), System.Drawing.Image)
        Me.Mnu_Btn_VerTraza.ImageAlt = CType(resources.GetObject("Mnu_Btn_VerTraza.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_VerTraza.Name = "Mnu_Btn_VerTraza"
        Me.Mnu_Btn_VerTraza.Text = "Ver trazabilidad"
        '
        'Mnu_Btn_Ver_Informacion_de_producto
        '
        Me.Mnu_Btn_Ver_Informacion_de_producto.Image = CType(resources.GetObject("Mnu_Btn_Ver_Informacion_de_producto.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Ver_Informacion_de_producto.ImageAlt = CType(resources.GetObject("Mnu_Btn_Ver_Informacion_de_producto.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Ver_Informacion_de_producto.Name = "Mnu_Btn_Ver_Informacion_de_producto"
        Me.Mnu_Btn_Ver_Informacion_de_producto.Text = "Ver información adicional del producto"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.MultiSelect = False
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(904, 430)
        Me.Grilla.TabIndex = 2
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnActualizar, Me.BtnExportarExcel, Me.BtnxSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 534)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(921, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 11
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnActualizar
        '
        Me.BtnActualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnActualizar.ForeColor = System.Drawing.Color.Black
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.ImageAlt = CType(resources.GetObject("BtnActualizar.ImageAlt"), System.Drawing.Image)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Tooltip = "Actualizar"
        '
        'BtnExportarExcel
        '
        Me.BtnExportarExcel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnExportarExcel.ForeColor = System.Drawing.Color.Black
        Me.BtnExportarExcel.Image = CType(resources.GetObject("BtnExportarExcel.Image"), System.Drawing.Image)
        Me.BtnExportarExcel.ImageAlt = CType(resources.GetObject("BtnExportarExcel.ImageAlt"), System.Drawing.Image)
        Me.BtnExportarExcel.Name = "BtnExportarExcel"
        Me.BtnExportarExcel.Tooltip = "Exportar a Excel"
        '
        'BtnxSalir
        '
        Me.BtnxSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnxSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnxSalir.Image = CType(resources.GetObject("BtnxSalir.Image"), System.Drawing.Image)
        Me.BtnxSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnxSalir.Name = "BtnxSalir"
        Me.BtnxSalir.Visible = False
        '
        'TxtCodigoSol
        '
        Me.TxtCodigoSol.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtCodigoSol.Border.Class = "TextBoxBorder"
        Me.TxtCodigoSol.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCodigoSol.DisabledBackColor = System.Drawing.Color.White
        Me.TxtCodigoSol.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoSol.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.TxtCodigoSol, True)
        Me.TxtCodigoSol.Location = New System.Drawing.Point(107, 499)
        Me.TxtCodigoSol.MaxLength = 10
        Me.TxtCodigoSol.Name = "TxtCodigoSol"
        Me.TxtCodigoSol.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtCodigoSol.PreventEnterBeep = True
        Me.TxtCodigoSol.Size = New System.Drawing.Size(133, 29)
        Me.TxtCodigoSol.TabIndex = 12
        Me.TxtCodigoSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Radio1
        '
        Me.Radio1.Checked = True
        Me.Radio1.Name = "Radio1"
        Me.Radio1.Text = "Los ultimos 12 meses"
        '
        'Radio2
        '
        Me.Radio2.Name = "Radio2"
        Me.Radio2.Text = "Toda la historia"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(8, 501)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(93, 23)
        Me.LabelX1.TabIndex = 13
        Me.LabelX1.Text = "Lector de códigos"
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.Location = New System.Drawing.Point(246, 498)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(30, 46)
        Me.ReflectionImage1.TabIndex = 14
        '
        'Radio3
        '
        Me.Radio3.Name = "Radio3"
        Me.Radio3.Text = "Toda la historia"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(8, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(109, 23)
        Me.LabelX2.TabIndex = 17
        Me.LabelX2.Text = "Fecha de impresión:"
        '
        'DtpFecharevision
        '
        Me.DtpFecharevision.BackColor = System.Drawing.Color.White
        Me.DtpFecharevision.ForeColor = System.Drawing.Color.Black
        Me.DtpFecharevision.Location = New System.Drawing.Point(123, 13)
        Me.DtpFecharevision.Name = "DtpFecharevision"
        Me.DtpFecharevision.Size = New System.Drawing.Size(216, 22)
        Me.DtpFecharevision.TabIndex = 16
        '
        'Chk_Validar_Usuario_Con_Huella
        '
        Me.Chk_Validar_Usuario_Con_Huella.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Validar_Usuario_Con_Huella.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Validar_Usuario_Con_Huella.Checked = True
        Me.Chk_Validar_Usuario_Con_Huella.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Validar_Usuario_Con_Huella.CheckValue = "Y"
        Me.Chk_Validar_Usuario_Con_Huella.FocusCuesEnabled = False
        Me.Chk_Validar_Usuario_Con_Huella.ForeColor = System.Drawing.Color.Black
        Me.Chk_Validar_Usuario_Con_Huella.Location = New System.Drawing.Point(759, 496)
        Me.Chk_Validar_Usuario_Con_Huella.Name = "Chk_Validar_Usuario_Con_Huella"
        Me.Chk_Validar_Usuario_Con_Huella.Size = New System.Drawing.Size(155, 23)
        Me.Chk_Validar_Usuario_Con_Huella.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Validar_Usuario_Con_Huella.TabIndex = 18
        Me.Chk_Validar_Usuario_Con_Huella.Text = "Validar usuario con huella"
        '
        'ReflectionImage2
        '
        Me.ReflectionImage2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ReflectionImage2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage2.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage2.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage2.Image = CType(resources.GetObject("ReflectionImage2.Image"), System.Drawing.Image)
        Me.ReflectionImage2.Location = New System.Drawing.Point(726, 496)
        Me.ReflectionImage2.Name = "ReflectionImage2"
        Me.ReflectionImage2.ReflectionEnabled = False
        Me.ReflectionImage2.Size = New System.Drawing.Size(27, 32)
        Me.ReflectionImage2.TabIndex = 19
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Frm_Sol_Pro_Bodega_ListaPendientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 575)
        Me.Controls.Add(Me.ReflectionImage2)
        Me.Controls.Add(Me.Chk_Validar_Usuario_Con_Huella)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.DtpFecharevision)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.TxtCodigoSol)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Sol_Pro_Bodega_ListaPendientes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productos solicitados a bodega"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnActualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnxSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TxtCodigoSol As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Radio1 As DevComponents.DotNetBar.Command
    Friend WithEvents Radio2 As DevComponents.DotNetBar.Command
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Radio3 As DevComponents.DotNetBar.Command
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DtpFecharevision As System.Windows.Forms.DateTimePicker
    Public WithEvents BtnExportarExcel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Validar_Usuario_Con_Huella As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ReflectionImage2 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Mnu_Btn_VerTraza As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Ver_Informacion_de_producto As DevComponents.DotNetBar.ButtonItem
End Class
