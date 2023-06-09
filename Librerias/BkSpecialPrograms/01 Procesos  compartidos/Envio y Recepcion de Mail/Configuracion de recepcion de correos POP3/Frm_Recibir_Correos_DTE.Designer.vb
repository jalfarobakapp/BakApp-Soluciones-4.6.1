<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Recibir_Correos_DTE
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Recibir_Correos_DTE))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Descargar_Archivos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ConfGeneral = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Btn_BuscarSMTPRecepXMLComp = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CorreoSMTP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Directorio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Buscar_Directorio_Destino = New DevComponents.DotNetBar.ButtonX()
        Me.Chk_Borrar_Todos_Los_Correos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Progreso_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Progreso_Cont = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_Xml_InsertBD = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Total_Correos = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Xml_Descargados = New DevComponents.DotNetBar.LabelX()
        Me.Timer_Segundos = New System.Windows.Forms.Timer(Me.components)
        Me.Rdb_POP3 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_IMAP = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CarpetaLectura = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_CarpetaDestino = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Rdb_DecargarCorreosHoy = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Ly_Fechas = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_FS_desde = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Lbl_FS_hasta = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Rdb_DescargarRangoFechas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_DecargarNoLeidos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.Ly_Fechas.SuspendLayout()
        CType(Me.Dtp_Fecha_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Descargar_Archivos, Me.Btn_Cancelar, Me.Btn_ConfGeneral})
        Me.Bar1.Location = New System.Drawing.Point(0, 418)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(584, 41)
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
        Me.Btn_Descargar_Archivos.Text = "Recibir correos"
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
        'Btn_ConfGeneral
        '
        Me.Btn_ConfGeneral.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ConfGeneral.ForeColor = System.Drawing.Color.Black
        Me.Btn_ConfGeneral.Image = CType(resources.GetObject("Btn_ConfGeneral.Image"), System.Drawing.Image)
        Me.Btn_ConfGeneral.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_ConfGeneral.Name = "Btn_ConfGeneral"
        Me.Btn_ConfGeneral.Text = "Conf. General"
        '
        'Grupo
        '
        Me.Grupo.BackColor = System.Drawing.Color.White
        Me.Grupo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo.Location = New System.Drawing.Point(8, 12)
        Me.Grupo.Name = "Grupo"
        Me.Grupo.Size = New System.Drawing.Size(564, 110)
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
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.15569!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.84431!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_BuscarSMTPRecepXMLComp, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_CorreoSMTP, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Directorio, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Buscar_Directorio_Destino, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Borrar_Todos_Los_Correos, 1, 2)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(554, 80)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Btn_BuscarSMTPRecepXMLComp
        '
        Me.Btn_BuscarSMTPRecepXMLComp.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText
        Me.Btn_BuscarSMTPRecepXMLComp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_BuscarSMTPRecepXMLComp.Image = CType(resources.GetObject("Btn_BuscarSMTPRecepXMLComp.Image"), System.Drawing.Image)
        Me.Btn_BuscarSMTPRecepXMLComp.Location = New System.Drawing.Point(499, 3)
        Me.Btn_BuscarSMTPRecepXMLComp.Name = "Btn_BuscarSMTPRecepXMLComp"
        Me.Btn_BuscarSMTPRecepXMLComp.Size = New System.Drawing.Size(35, 20)
        Me.Btn_BuscarSMTPRecepXMLComp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_BuscarSMTPRecepXMLComp.TabIndex = 90
        Me.Btn_BuscarSMTPRecepXMLComp.Tooltip = "Seleccionar cuenta (SMTP)"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 20)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Correo"
        '
        'Txt_CorreoSMTP
        '
        Me.Txt_CorreoSMTP.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CorreoSMTP.Border.Class = "TextBoxBorder"
        Me.Txt_CorreoSMTP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CorreoSMTP.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CorreoSMTP.ForeColor = System.Drawing.Color.Black
        Me.Txt_CorreoSMTP.Location = New System.Drawing.Point(113, 3)
        Me.Txt_CorreoSMTP.Name = "Txt_CorreoSMTP"
        Me.Txt_CorreoSMTP.PreventEnterBeep = True
        Me.Txt_CorreoSMTP.ReadOnly = True
        Me.Txt_CorreoSMTP.Size = New System.Drawing.Size(380, 22)
        Me.Txt_CorreoSMTP.TabIndex = 3
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 29)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(104, 20)
        Me.LabelX4.TabIndex = 2
        Me.LabelX4.Text = "Directorio destino"
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
        Me.Txt_Directorio.Location = New System.Drawing.Point(113, 29)
        Me.Txt_Directorio.Name = "Txt_Directorio"
        Me.Txt_Directorio.PreventEnterBeep = True
        Me.Txt_Directorio.ReadOnly = True
        Me.Txt_Directorio.Size = New System.Drawing.Size(380, 22)
        Me.Txt_Directorio.TabIndex = 3
        '
        'Btn_Buscar_Directorio_Destino
        '
        Me.Btn_Buscar_Directorio_Destino.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Directorio_Destino.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Directorio_Destino.Enabled = False
        Me.Btn_Buscar_Directorio_Destino.Image = CType(resources.GetObject("Btn_Buscar_Directorio_Destino.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Directorio_Destino.Location = New System.Drawing.Point(499, 29)
        Me.Btn_Buscar_Directorio_Destino.Name = "Btn_Buscar_Directorio_Destino"
        Me.Btn_Buscar_Directorio_Destino.Size = New System.Drawing.Size(35, 20)
        Me.Btn_Buscar_Directorio_Destino.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Directorio_Destino.TabIndex = 1
        Me.Btn_Buscar_Directorio_Destino.Tooltip = "Buscar directorio destino"
        '
        'Chk_Borrar_Todos_Los_Correos
        '
        '
        '
        '
        Me.Chk_Borrar_Todos_Los_Correos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Borrar_Todos_Los_Correos.FocusCuesEnabled = False
        Me.Chk_Borrar_Todos_Los_Correos.ForeColor = System.Drawing.Color.Black
        Me.Chk_Borrar_Todos_Los_Correos.Location = New System.Drawing.Point(113, 55)
        Me.Chk_Borrar_Todos_Los_Correos.Name = "Chk_Borrar_Todos_Los_Correos"
        Me.Chk_Borrar_Todos_Los_Correos.Size = New System.Drawing.Size(287, 22)
        Me.Chk_Borrar_Todos_Los_Correos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Borrar_Todos_Los_Correos.TabIndex = 1
        Me.Chk_Borrar_Todos_Los_Correos.Text = "Eliminar los correos con DTE"
        '
        'Progreso_Porc
        '
        Me.Progreso_Porc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Porc.FocusCuesEnabled = False
        Me.Progreso_Porc.Location = New System.Drawing.Point(74, 128)
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
        Me.Progreso_Cont.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Cont.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Cont.FocusCuesEnabled = False
        Me.Progreso_Cont.Location = New System.Drawing.Point(12, 128)
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
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.38095!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.61905!))
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Xml_InsertBD, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX5, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Total_Correos, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX8, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX6, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Xml_Descargados, 1, 1)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(361, 128)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(211, 60)
        Me.TableLayoutPanel2.TabIndex = 33
        '
        'Lbl_Xml_InsertBD
        '
        Me.Lbl_Xml_InsertBD.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Xml_InsertBD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Xml_InsertBD.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Xml_InsertBD.Location = New System.Drawing.Point(134, 42)
        Me.Lbl_Xml_InsertBD.Name = "Lbl_Xml_InsertBD"
        Me.Lbl_Xml_InsertBD.Size = New System.Drawing.Size(73, 14)
        Me.Lbl_Xml_InsertBD.TabIndex = 35
        Me.Lbl_Xml_InsertBD.Text = "0"
        Me.Lbl_Xml_InsertBD.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(4, 42)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(89, 14)
        Me.LabelX5.TabIndex = 34
        Me.LabelX5.Text = "Xml insertados BD"
        '
        'Lbl_Total_Correos
        '
        Me.Lbl_Total_Correos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Total_Correos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Total_Correos.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Total_Correos.Location = New System.Drawing.Point(134, 4)
        Me.Lbl_Total_Correos.Name = "Lbl_Total_Correos"
        Me.Lbl_Total_Correos.Size = New System.Drawing.Size(73, 12)
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
        Me.LabelX8.Size = New System.Drawing.Size(89, 12)
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
        Me.LabelX6.Location = New System.Drawing.Point(4, 23)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(89, 12)
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
        Me.Lbl_Xml_Descargados.Location = New System.Drawing.Point(134, 23)
        Me.Lbl_Xml_Descargados.Name = "Lbl_Xml_Descargados"
        Me.Lbl_Xml_Descargados.Size = New System.Drawing.Size(73, 12)
        Me.Lbl_Xml_Descargados.TabIndex = 34
        Me.Lbl_Xml_Descargados.Text = "0"
        Me.Lbl_Xml_Descargados.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Timer_Segundos
        '
        Me.Timer_Segundos.Interval = 1000
        '
        'Rdb_POP3
        '
        Me.Rdb_POP3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_POP3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_POP3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_POP3.Checked = True
        Me.Rdb_POP3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_POP3.CheckValue = "Y"
        Me.Rdb_POP3.FocusCuesEnabled = False
        Me.Rdb_POP3.ForeColor = System.Drawing.Color.Black
        Me.Rdb_POP3.Location = New System.Drawing.Point(14, 205)
        Me.Rdb_POP3.Name = "Rdb_POP3"
        Me.Rdb_POP3.Size = New System.Drawing.Size(56, 22)
        Me.Rdb_POP3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_POP3.TabIndex = 34
        Me.Rdb_POP3.Text = "POP3"
        '
        'Rdb_IMAP
        '
        Me.Rdb_IMAP.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Rdb_IMAP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_IMAP.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_IMAP.FocusCuesEnabled = False
        Me.Rdb_IMAP.ForeColor = System.Drawing.Color.Black
        Me.Rdb_IMAP.Location = New System.Drawing.Point(76, 205)
        Me.Rdb_IMAP.Name = "Rdb_IMAP"
        Me.Rdb_IMAP.Size = New System.Drawing.Size(56, 22)
        Me.Rdb_IMAP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_IMAP.TabIndex = 35
        Me.Rdb_IMAP.Text = "IMAP"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(5, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 20)
        Me.LabelX2.TabIndex = 36
        Me.LabelX2.Text = "Carpeta lectura"
        '
        'Txt_CarpetaLectura
        '
        Me.Txt_CarpetaLectura.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CarpetaLectura.Border.Class = "TextBoxBorder"
        Me.Txt_CarpetaLectura.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CarpetaLectura.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CarpetaLectura.ForeColor = System.Drawing.Color.Black
        Me.Txt_CarpetaLectura.Location = New System.Drawing.Point(102, 3)
        Me.Txt_CarpetaLectura.Name = "Txt_CarpetaLectura"
        Me.Txt_CarpetaLectura.PreventEnterBeep = True
        Me.Txt_CarpetaLectura.ReadOnly = True
        Me.Txt_CarpetaLectura.Size = New System.Drawing.Size(449, 22)
        Me.Txt_CarpetaLectura.TabIndex = 37
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(5, 31)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(91, 20)
        Me.LabelX3.TabIndex = 38
        Me.LabelX3.Text = "Carpeta destino"
        '
        'Txt_CarpetaDestino
        '
        Me.Txt_CarpetaDestino.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CarpetaDestino.Border.Class = "TextBoxBorder"
        Me.Txt_CarpetaDestino.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CarpetaDestino.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CarpetaDestino.ForeColor = System.Drawing.Color.Black
        Me.Txt_CarpetaDestino.Location = New System.Drawing.Point(102, 31)
        Me.Txt_CarpetaDestino.Name = "Txt_CarpetaDestino"
        Me.Txt_CarpetaDestino.PreventEnterBeep = True
        Me.Txt_CarpetaDestino.ReadOnly = True
        Me.Txt_CarpetaDestino.Size = New System.Drawing.Size(449, 22)
        Me.Txt_CarpetaDestino.TabIndex = 39
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Rdb_DecargarCorreosHoy)
        Me.GroupPanel1.Controls.Add(Me.Ly_Fechas)
        Me.GroupPanel1.Controls.Add(Me.Rdb_DescargarRangoFechas)
        Me.GroupPanel1.Controls.Add(Me.Rdb_DecargarNoLeidos)
        Me.GroupPanel1.Controls.Add(Me.Txt_CarpetaLectura)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Txt_CarpetaDestino)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(8, 233)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(564, 171)
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
        Me.GroupPanel1.TabIndex = 40
        Me.GroupPanel1.Text = "Configuración IMAP"
        '
        'Rdb_DecargarCorreosHoy
        '
        Me.Rdb_DecargarCorreosHoy.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_DecargarCorreosHoy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_DecargarCorreosHoy.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_DecargarCorreosHoy.FocusCuesEnabled = False
        Me.Rdb_DecargarCorreosHoy.ForeColor = System.Drawing.Color.Black
        Me.Rdb_DecargarCorreosHoy.Location = New System.Drawing.Point(3, 87)
        Me.Rdb_DecargarCorreosHoy.Name = "Rdb_DecargarCorreosHoy"
        Me.Rdb_DecargarCorreosHoy.Size = New System.Drawing.Size(263, 22)
        Me.Rdb_DecargarCorreosHoy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_DecargarCorreosHoy.TabIndex = 43
        Me.Rdb_DecargarCorreosHoy.Text = "Descargar los correos recibidos hoy"
        '
        'Ly_Fechas
        '
        Me.Ly_Fechas.BackColor = System.Drawing.Color.Transparent
        Me.Ly_Fechas.ColumnCount = 4
        Me.Ly_Fechas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.72581!))
        Me.Ly_Fechas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.87097!))
        Me.Ly_Fechas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.51613!))
        Me.Ly_Fechas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.69355!))
        Me.Ly_Fechas.Controls.Add(Me.Lbl_FS_desde, 0, 0)
        Me.Ly_Fechas.Controls.Add(Me.Dtp_Fecha_Desde, 1, 0)
        Me.Ly_Fechas.Controls.Add(Me.Lbl_FS_hasta, 2, 0)
        Me.Ly_Fechas.Controls.Add(Me.Dtp_Fecha_Hasta, 3, 0)
        Me.Ly_Fechas.ForeColor = System.Drawing.Color.Black
        Me.Ly_Fechas.Location = New System.Drawing.Point(256, 115)
        Me.Ly_Fechas.Name = "Ly_Fechas"
        Me.Ly_Fechas.RowCount = 1
        Me.Ly_Fechas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Ly_Fechas.Size = New System.Drawing.Size(299, 25)
        Me.Ly_Fechas.TabIndex = 42
        '
        'Lbl_FS_desde
        '
        '
        '
        '
        Me.Lbl_FS_desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FS_desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FS_desde.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_FS_desde.Name = "Lbl_FS_desde"
        Me.Lbl_FS_desde.Size = New System.Drawing.Size(32, 19)
        Me.Lbl_FS_desde.TabIndex = 7
        Me.Lbl_FS_desde.Text = "Desde"
        '
        'Dtp_Fecha_Desde
        '
        '
        '
        '
        Me.Dtp_Fecha_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Desde.Location = New System.Drawing.Point(49, 3)
        '
        '
        '
        Me.Dtp_Fecha_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Desde.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Desde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Desde.Name = "Dtp_Fecha_Desde"
        Me.Dtp_Fecha_Desde.Size = New System.Drawing.Size(77, 22)
        Me.Dtp_Fecha_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Desde.TabIndex = 7
        Me.Dtp_Fecha_Desde.Value = New Date(2016, 7, 8, 16, 32, 31, 0)
        '
        'Lbl_FS_hasta
        '
        '
        '
        '
        Me.Lbl_FS_hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FS_hasta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FS_hasta.Location = New System.Drawing.Point(149, 3)
        Me.Lbl_FS_hasta.Name = "Lbl_FS_hasta"
        Me.Lbl_FS_hasta.Size = New System.Drawing.Size(29, 19)
        Me.Lbl_FS_hasta.TabIndex = 9
        Me.Lbl_FS_hasta.Text = "Hasta"
        '
        'Dtp_Fecha_Hasta
        '
        '
        '
        '
        Me.Dtp_Fecha_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Hasta.Location = New System.Drawing.Point(192, 3)
        '
        '
        '
        Me.Dtp_Fecha_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Hasta.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Hasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Hasta.Name = "Dtp_Fecha_Hasta"
        Me.Dtp_Fecha_Hasta.Size = New System.Drawing.Size(81, 22)
        Me.Dtp_Fecha_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Hasta.TabIndex = 8
        Me.Dtp_Fecha_Hasta.Value = New Date(2016, 7, 8, 16, 33, 0, 0)
        '
        'Rdb_DescargarRangoFechas
        '
        Me.Rdb_DescargarRangoFechas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_DescargarRangoFechas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_DescargarRangoFechas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_DescargarRangoFechas.FocusCuesEnabled = False
        Me.Rdb_DescargarRangoFechas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_DescargarRangoFechas.Location = New System.Drawing.Point(1, 115)
        Me.Rdb_DescargarRangoFechas.Name = "Rdb_DescargarRangoFechas"
        Me.Rdb_DescargarRangoFechas.Size = New System.Drawing.Size(263, 22)
        Me.Rdb_DescargarRangoFechas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_DescargarRangoFechas.TabIndex = 41
        Me.Rdb_DescargarRangoFechas.Text = "Descargar correos dentro de un rango de fecha"
        '
        'Rdb_DecargarNoLeidos
        '
        Me.Rdb_DecargarNoLeidos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_DecargarNoLeidos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_DecargarNoLeidos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_DecargarNoLeidos.Checked = True
        Me.Rdb_DecargarNoLeidos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_DecargarNoLeidos.CheckValue = "Y"
        Me.Rdb_DecargarNoLeidos.FocusCuesEnabled = False
        Me.Rdb_DecargarNoLeidos.ForeColor = System.Drawing.Color.Black
        Me.Rdb_DecargarNoLeidos.Location = New System.Drawing.Point(3, 59)
        Me.Rdb_DecargarNoLeidos.Name = "Rdb_DecargarNoLeidos"
        Me.Rdb_DecargarNoLeidos.Size = New System.Drawing.Size(183, 22)
        Me.Rdb_DecargarNoLeidos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_DecargarNoLeidos.TabIndex = 40
        Me.Rdb_DecargarNoLeidos.Text = "Descargar correos no leidos"
        '
        'Frm_Recibir_Correos_DTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 459)
        Me.Controls.Add(Me.Rdb_IMAP)
        Me.Controls.Add(Me.Rdb_POP3)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.Progreso_Porc)
        Me.Controls.Add(Me.Progreso_Cont)
        Me.Controls.Add(Me.Grupo)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
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
        Me.GroupPanel1.ResumeLayout(False)
        Me.Ly_Fechas.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Grupo As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Btn_Buscar_Directorio_Destino As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Directorio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_CorreoSMTP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Progreso_Cont As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Btn_Descargar_Archivos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Timer_Segundos As Timer
    Public WithEvents Chk_Borrar_Todos_Los_Correos As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Lbl_Xml_InsertBD As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Public WithEvents Lbl_Xml_Descargados As DevComponents.DotNetBar.LabelX
    Public WithEvents Lbl_Total_Correos As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_BuscarSMTPRecepXMLComp As DevComponents.DotNetBar.ButtonX
    Public WithEvents Rdb_POP3 As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_IMAP As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_CarpetaLectura As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_CarpetaDestino As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Rdb_DescargarRangoFechas As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Rdb_DecargarNoLeidos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Ly_Fechas As TableLayoutPanel
    Friend WithEvents Lbl_FS_desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Lbl_FS_hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Public WithEvents Rdb_DecargarCorreosHoy As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_ConfGeneral As DevComponents.DotNetBar.ButtonItem
End Class
