<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Recibir_Correos_DTE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Recibir_Correos_DTE))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Descargar_Archivos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chk_Borrar_Todos_Los_Correos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Btn_Buscar_Directorio_Destino = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Directorio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Clave = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Usuario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Host = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Progreso_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Progreso_Cont = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_Total_Correos = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Xml_Descargados = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Descargar_Archivos, Me.Btn_Cancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 279)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(478, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 5
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Descargar_Archivos
        '
        Me.Btn_Descargar_Archivos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Descargar_Archivos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Descargar_Archivos.Image = CType(resources.GetObject("Btn_Descargar_Archivos.Image"), System.Drawing.Image)
        Me.Btn_Descargar_Archivos.Name = "Btn_Descargar_Archivos"
        Me.Btn_Descargar_Archivos.Text = "Recibe correos Nueva libreria"
        Me.Btn_Descargar_Archivos.Tooltip = "Importar archivos XML"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Tooltip = "Cancelar"
        '
        'Grupo
        '
        Me.Grupo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo.Location = New System.Drawing.Point(12, 12)
        Me.Grupo.Name = "Grupo"
        Me.Grupo.Size = New System.Drawing.Size(454, 192)
        '
        '
        '
        Me.Grupo.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo.Style.BackColorGradientAngle = 90
        Me.Grupo.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo.Style.BorderBottomWidth = 1
        Me.Grupo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo.Style.BorderLeftWidth = 1
        Me.Grupo.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo.Style.BorderRightWidth = 1
        Me.Grupo.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo.Style.BorderTopWidth = 1
        Me.Grupo.Style.CornerDiameter = 4
        Me.Grupo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo.TabIndex = 6
        Me.Grupo.Text = "Configuración de la importación"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.14607!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.85394!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Borrar_Todos_Los_Correos, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Buscar_Directorio_Destino, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Directorio, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Clave, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Usuario, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Host, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 21)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(445, 124)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Chk_Borrar_Todos_Los_Correos
        '
        '
        '
        '
        Me.Chk_Borrar_Todos_Los_Correos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Borrar_Todos_Los_Correos.ForeColor = System.Drawing.Color.Black
        Me.Chk_Borrar_Todos_Los_Correos.Location = New System.Drawing.Point(92, 107)
        Me.Chk_Borrar_Todos_Los_Correos.Name = "Chk_Borrar_Todos_Los_Correos"
        Me.Chk_Borrar_Todos_Los_Correos.Size = New System.Drawing.Size(291, 14)
        Me.Chk_Borrar_Todos_Los_Correos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Borrar_Todos_Los_Correos.TabIndex = 1
        Me.Chk_Borrar_Todos_Los_Correos.Text = "Eliminar los correos con DTE"
        '
        'Btn_Buscar_Directorio_Destino
        '
        Me.Btn_Buscar_Directorio_Destino.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Directorio_Destino.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Directorio_Destino.Image = CType(resources.GetObject("Btn_Buscar_Directorio_Destino.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Directorio_Destino.Location = New System.Drawing.Point(389, 81)
        Me.Btn_Buscar_Directorio_Destino.Name = "Btn_Buscar_Directorio_Destino"
        Me.Btn_Buscar_Directorio_Destino.Size = New System.Drawing.Size(27, 20)
        Me.Btn_Buscar_Directorio_Destino.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Directorio_Destino.TabIndex = 1
        Me.Btn_Buscar_Directorio_Destino.Tooltip = "Buscar directorio destino"
        '
        'Txt_Directorio
        '
        Me.Txt_Directorio.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Directorio.Border.Class = "TextBoxBorder"
        Me.Txt_Directorio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Directorio.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Directorio.ForeColor = System.Drawing.Color.Black
        Me.Txt_Directorio.Location = New System.Drawing.Point(92, 81)
        Me.Txt_Directorio.Name = "Txt_Directorio"
        Me.Txt_Directorio.PreventEnterBeep = True
        Me.Txt_Directorio.Size = New System.Drawing.Size(291, 22)
        Me.Txt_Directorio.TabIndex = 3
        '
        'Txt_Clave
        '
        Me.Txt_Clave.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Clave.Border.Class = "TextBoxBorder"
        Me.Txt_Clave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Clave.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Clave.ForeColor = System.Drawing.Color.Black
        Me.Txt_Clave.Location = New System.Drawing.Point(92, 55)
        Me.Txt_Clave.Name = "Txt_Clave"
        Me.Txt_Clave.PreventEnterBeep = True
        Me.Txt_Clave.Size = New System.Drawing.Size(173, 22)
        Me.Txt_Clave.TabIndex = 3
        '
        'Txt_Usuario
        '
        Me.Txt_Usuario.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Usuario.Border.Class = "TextBoxBorder"
        Me.Txt_Usuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Usuario.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Txt_Usuario.Location = New System.Drawing.Point(92, 29)
        Me.Txt_Usuario.Name = "Txt_Usuario"
        Me.Txt_Usuario.PreventEnterBeep = True
        Me.Txt_Usuario.Size = New System.Drawing.Size(173, 22)
        Me.Txt_Usuario.TabIndex = 3
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 81)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(83, 20)
        Me.LabelX4.TabIndex = 2
        Me.LabelX4.Text = "Directorio destino"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 55)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 20)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "Contraseña"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 29)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 20)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Usuario"
        '
        'Txt_Host
        '
        Me.Txt_Host.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Host.Border.Class = "TextBoxBorder"
        Me.Txt_Host.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Host.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Host.ForeColor = System.Drawing.Color.Black
        Me.Txt_Host.Location = New System.Drawing.Point(92, 3)
        Me.Txt_Host.Name = "Txt_Host"
        Me.Txt_Host.PreventEnterBeep = True
        Me.Txt_Host.Size = New System.Drawing.Size(173, 22)
        Me.Txt_Host.TabIndex = 2
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 20)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Host"
        '
        'Progreso_Porc
        '
        Me.Progreso_Porc.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Progreso_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Porc.Location = New System.Drawing.Point(74, 210)
        Me.Progreso_Porc.Name = "Progreso_Porc"
        Me.Progreso_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Porc.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Porc.ProgressTextVisible = True
        Me.Progreso_Porc.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Porc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Porc.TabIndex = 32
        '
        'Progreso_Cont
        '
        Me.Progreso_Cont.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Progreso_Cont.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Cont.Location = New System.Drawing.Point(12, 210)
        Me.Progreso_Cont.Name = "Progreso_Cont"
        Me.Progreso_Cont.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Cont.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Cont.ProgressTextFormat = "{0}"
        Me.Progreso_Cont.ProgressTextVisible = True
        Me.Progreso_Cont.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Cont.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Cont.TabIndex = 31
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.97157!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.02843!))
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Total_Correos, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX8, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX6, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Xml_Descargados, 1, 1)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(136, 210)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(211, 46)
        Me.TableLayoutPanel2.TabIndex = 33
        '
        'Lbl_Total_Correos
        '
        Me.Lbl_Total_Correos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Total_Correos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Total_Correos.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Total_Correos.Location = New System.Drawing.Point(100, 4)
        Me.Lbl_Total_Correos.Name = "Lbl_Total_Correos"
        Me.Lbl_Total_Correos.Size = New System.Drawing.Size(107, 15)
        Me.Lbl_Total_Correos.TabIndex = 34
        Me.Lbl_Total_Correos.Text = "0"
        Me.Lbl_Total_Correos.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(4, 4)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(89, 15)
        Me.LabelX8.TabIndex = 3
        Me.LabelX8.Text = "Total correos"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(4, 26)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(89, 16)
        Me.LabelX6.TabIndex = 2
        Me.LabelX6.Text = "Xml descargados"
        '
        'Lbl_Xml_Descargados
        '
        Me.Lbl_Xml_Descargados.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Xml_Descargados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Xml_Descargados.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Xml_Descargados.Location = New System.Drawing.Point(100, 26)
        Me.Lbl_Xml_Descargados.Name = "Lbl_Xml_Descargados"
        Me.Lbl_Xml_Descargados.Size = New System.Drawing.Size(107, 16)
        Me.Lbl_Xml_Descargados.TabIndex = 34
        Me.Lbl_Xml_Descargados.Text = "0"
        Me.Lbl_Xml_Descargados.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Frm_Recibir_Correos_DTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 320)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.Progreso_Porc)
        Me.Controls.Add(Me.Progreso_Cont)
        Me.Controls.Add(Me.Grupo)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Recibir_Correos_DTE"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar recepcion de correos de proveedores DTE XML"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Grupo As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Btn_Buscar_Directorio_Destino As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Directorio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Clave As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Usuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Host As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Borrar_Todos_Los_Correos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Progreso_Cont As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Btn_Descargar_Archivos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lbl_Xml_Descargados As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Total_Correos As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
End Class
