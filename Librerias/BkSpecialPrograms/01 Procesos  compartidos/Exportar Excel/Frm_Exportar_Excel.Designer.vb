<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Exportar_Excel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Exportar_Excel))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Exportar_a_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Csv = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Txt = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Detalle = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Carpeta_Informes = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Circular_Progres_Porcentaje = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Circular_Progres_Contador = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Cmb_Separador = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Txt_Separador = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Direccion_File = New System.Windows.Forms.Button()
        Me.Rdb_xls = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Nombre_Archivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rdb_Xlsx = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.SvfDirectorio = New System.Windows.Forms.SaveFileDialog()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Exportar_a_Excel, Me.Btn_Exportar_Csv, Me.Btn_Exportar_Txt, Me.Btn_Ver_Detalle, Me.Btn_Carpeta_Informes, Me.Btn_Cancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 159)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(635, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 4
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Exportar_a_Excel
        '
        Me.Btn_Exportar_a_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_a_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_a_Excel.Image = CType(resources.GetObject("Btn_Exportar_a_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_a_Excel.ImageAlt = CType(resources.GetObject("Btn_Exportar_a_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_a_Excel.Name = "Btn_Exportar_a_Excel"
        Me.Btn_Exportar_a_Excel.Tooltip = "Exportar a Excel (.xlmx)"
        '
        'Btn_Exportar_Csv
        '
        Me.Btn_Exportar_Csv.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Csv.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Csv.Image = CType(resources.GetObject("Btn_Exportar_Csv.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Csv.ImageAlt = CType(resources.GetObject("Btn_Exportar_Csv.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Csv.Name = "Btn_Exportar_Csv"
        Me.Btn_Exportar_Csv.Tooltip = "Exportar a .csv"
        '
        'Btn_Exportar_Txt
        '
        Me.Btn_Exportar_Txt.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Txt.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Txt.Image = CType(resources.GetObject("Btn_Exportar_Txt.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Txt.ImageAlt = CType(resources.GetObject("Btn_Exportar_Txt.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Txt.Name = "Btn_Exportar_Txt"
        Me.Btn_Exportar_Txt.Tooltip = "Exportar a .txt"
        '
        'Btn_Ver_Detalle
        '
        Me.Btn_Ver_Detalle.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ver_Detalle.ForeColor = System.Drawing.Color.Black
        Me.Btn_Ver_Detalle.Image = CType(resources.GetObject("Btn_Ver_Detalle.Image"), System.Drawing.Image)
        Me.Btn_Ver_Detalle.ImageAlt = CType(resources.GetObject("Btn_Ver_Detalle.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_Detalle.Name = "Btn_Ver_Detalle"
        Me.Btn_Ver_Detalle.Text = "Ver detalle"
        '
        'Btn_Carpeta_Informes
        '
        Me.Btn_Carpeta_Informes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Carpeta_Informes.ForeColor = System.Drawing.Color.Black
        Me.Btn_Carpeta_Informes.Image = CType(resources.GetObject("Btn_Carpeta_Informes.Image"), System.Drawing.Image)
        Me.Btn_Carpeta_Informes.ImageAlt = CType(resources.GetObject("Btn_Carpeta_Informes.ImageAlt"), System.Drawing.Image)
        Me.Btn_Carpeta_Informes.Name = "Btn_Carpeta_Informes"
        Me.Btn_Carpeta_Informes.Tooltip = "Ver carpeta de archivos temporales"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ImageAlt = CType(resources.GetObject("Btn_Cancelar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.Tooltip = "Eliminar Servidor de correo de salida SMTP"
        Me.Btn_Cancelar.Visible = False
        '
        'Circular_Progres_Porcentaje
        '
        Me.Circular_Progres_Porcentaje.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Circular_Progres_Porcentaje.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Circular_Progres_Porcentaje.Location = New System.Drawing.Point(3, 14)
        Me.Circular_Progres_Porcentaje.Name = "Circular_Progres_Porcentaje"
        Me.Circular_Progres_Porcentaje.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Circular_Progres_Porcentaje.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Circular_Progres_Porcentaje.ProgressTextVisible = True
        Me.Circular_Progres_Porcentaje.Size = New System.Drawing.Size(56, 46)
        Me.Circular_Progres_Porcentaje.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Circular_Progres_Porcentaje.TabIndex = 7
        '
        'Circular_Progres_Contador
        '
        Me.Circular_Progres_Contador.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Circular_Progres_Contador.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Circular_Progres_Contador.Location = New System.Drawing.Point(53, 14)
        Me.Circular_Progres_Contador.Name = "Circular_Progres_Contador"
        Me.Circular_Progres_Contador.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Circular_Progres_Contador.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Circular_Progres_Contador.ProgressTextFormat = "{0}"
        Me.Circular_Progres_Contador.ProgressTextVisible = True
        Me.Circular_Progres_Contador.Size = New System.Drawing.Size(56, 46)
        Me.Circular_Progres_Contador.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Circular_Progres_Contador.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(115, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(231, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Nombre de archivo de salida (Sin Extención)"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Cmb_Separador)
        Me.GroupPanel1.Controls.Add(Me.Txt_Separador)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.Btn_Direccion_File)
        Me.GroupPanel1.Controls.Add(Me.Rdb_xls)
        Me.GroupPanel1.Controls.Add(Me.Txt_Nombre_Archivo)
        Me.GroupPanel1.Controls.Add(Me.Circular_Progres_Porcentaje)
        Me.GroupPanel1.Controls.Add(Me.Rdb_Xlsx)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.Circular_Progres_Contador)
        Me.GroupPanel1.Controls.Add(Me.Line1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(611, 141)
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
        Me.GroupPanel1.TabIndex = 7
        Me.GroupPanel1.Text = "Exportar informe a Excel"
        '
        'Cmb_Separador
        '
        Me.Cmb_Separador.DisplayMember = "Text"
        Me.Cmb_Separador.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Separador.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Separador.FormattingEnabled = True
        Me.Cmb_Separador.ItemHeight = 16
        Me.Cmb_Separador.Location = New System.Drawing.Point(172, 93)
        Me.Cmb_Separador.Name = "Cmb_Separador"
        Me.Cmb_Separador.Size = New System.Drawing.Size(121, 22)
        Me.Cmb_Separador.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Separador.TabIndex = 15
        '
        'Txt_Separador
        '
        Me.Txt_Separador.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Separador.Border.Class = "TextBoxBorder"
        Me.Txt_Separador.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Separador.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Separador.ForeColor = System.Drawing.Color.Black
        Me.Txt_Separador.Location = New System.Drawing.Point(299, 93)
        Me.Txt_Separador.MaxLength = 10
        Me.Txt_Separador.Name = "Txt_Separador"
        Me.Txt_Separador.PreventEnterBeep = True
        Me.Txt_Separador.Size = New System.Drawing.Size(78, 22)
        Me.Txt_Separador.TabIndex = 14
        Me.Txt_Separador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 92)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(173, 23)
        Me.LabelX1.TabIndex = 12
        Me.LabelX1.Text = "Separador para archivos .csv/.txt"
        '
        'Btn_Direccion_File
        '
        Me.Btn_Direccion_File.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Direccion_File.ForeColor = System.Drawing.Color.Black
        Me.Btn_Direccion_File.Image = CType(resources.GetObject("Btn_Direccion_File.Image"), System.Drawing.Image)
        Me.Btn_Direccion_File.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Btn_Direccion_File.Location = New System.Drawing.Point(563, 29)
        Me.Btn_Direccion_File.Name = "Btn_Direccion_File"
        Me.Btn_Direccion_File.Size = New System.Drawing.Size(39, 23)
        Me.Btn_Direccion_File.TabIndex = 9
        Me.Btn_Direccion_File.Text = "..."
        Me.Btn_Direccion_File.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Direccion_File.UseVisualStyleBackColor = False
        '
        'Rdb_xls
        '
        Me.Rdb_xls.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_xls.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_xls.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_xls.ForeColor = System.Drawing.Color.Black
        Me.Rdb_xls.Location = New System.Drawing.Point(172, 58)
        Me.Rdb_xls.Name = "Rdb_xls"
        Me.Rdb_xls.Size = New System.Drawing.Size(174, 23)
        Me.Rdb_xls.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_xls.TabIndex = 11
        Me.Rdb_xls.Text = ".xls (recomendado office libre)"
        '
        'Txt_Nombre_Archivo
        '
        Me.Txt_Nombre_Archivo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre_Archivo.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre_Archivo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre_Archivo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre_Archivo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombre_Archivo.Location = New System.Drawing.Point(118, 30)
        Me.Txt_Nombre_Archivo.Name = "Txt_Nombre_Archivo"
        Me.Txt_Nombre_Archivo.PreventEnterBeep = True
        Me.Txt_Nombre_Archivo.Size = New System.Drawing.Size(439, 22)
        Me.Txt_Nombre_Archivo.TabIndex = 8
        '
        'Rdb_Xlsx
        '
        Me.Rdb_Xlsx.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Xlsx.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Xlsx.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Xlsx.Checked = True
        Me.Rdb_Xlsx.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Xlsx.CheckValue = "Y"
        Me.Rdb_Xlsx.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Xlsx.Location = New System.Drawing.Point(118, 58)
        Me.Rdb_Xlsx.Name = "Rdb_Xlsx"
        Me.Rdb_Xlsx.Size = New System.Drawing.Size(58, 23)
        Me.Rdb_Xlsx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Xlsx.TabIndex = 10
        Me.Rdb_Xlsx.Text = ".xlsx"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.Transparent
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(3, 72)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(374, 23)
        Me.Line1.TabIndex = 13
        Me.Line1.Text = "Line1"
        '
        'SvfDirectorio
        '
        Me.SvfDirectorio.FileName = "..\..\..\"
        Me.SvfDirectorio.Filter = "Archivos Excel|*.xlsx"
        '
        'Frm_Exportar_Excel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 200)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Exportar_Excel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportar a Excel"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_a_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Circular_Progres_Porcentaje As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Circular_Progres_Contador As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_Nombre_Archivo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Exportar_Csv As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Detalle As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Direccion_File As System.Windows.Forms.Button
    Friend WithEvents SvfDirectorio As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Rdb_xls As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Xlsx As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Carpeta_Informes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_Txt As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Cmb_Separador As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Txt_Separador As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
End Class
