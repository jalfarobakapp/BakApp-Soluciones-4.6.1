<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_RegistrarEquipo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RegistrarEquipo))
        Me.LblNombreEquipo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmb_TipoEstacion = New System.Windows.Forms.ComboBox()
        Me.ReflectionImage2 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxX2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_Alias = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Chk_Tiene_Lector_Huella = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Cmb_Lector_Huella = New System.Windows.Forms.ComboBox()
        Me.Lbl_Lector_Huella = New System.Windows.Forms.Label()
        Me.Chk_Buscar_Actualizacion_En_FTP = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Usar_Datos_X_Defecto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Cmb_Empresa_X_Defecto = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Cmb_Modalidad_X_Defecto = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cmb_Usuario_X_Defecto = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_KeyReg = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.STab = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grupo_ConfCaja = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Buscar_DirectorioDTE = New DevComponents.DotNetBar.ButtonX()
        Me.Rdb_NO_ImprDespGrabarCaja = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Rdb_ImprDespGrabarCaja = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Directorio_GenDTE = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Buscar_Modalidad = New DevComponents.DotNetBar.ButtonX()
        Me.Chk_Caja_Habilitada = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Modalidad_Caja = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Tab_Empresas = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Tab_EstTrabajo = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanel5 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Btn_Ver_Usuarios_Diablito = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Eliminar_Impresoras = New DevComponents.DotNetBar.ButtonX()
        Me.Grupo_Funcionarios = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.List_Impresoras = New System.Windows.Forms.ListBox()
        Me.Btn_Agregar_Impresoras = New DevComponents.DotNetBar.ButtonX()
        Me.Tab_Impresoras = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_DTEMonitorAmbienteCertificacion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_EsDTEMonitor = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Tab_Configuraciones = New DevComponents.DotNetBar.SuperTabItem()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.STab.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
        Me.Grupo_ConfCaja.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.SuperTabControlPanel4.SuspendLayout()
        Me.GroupPanel5.SuspendLayout()
        Me.Grupo_Funcionarios.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblNombreEquipo
        '
        Me.LblNombreEquipo.AutoSize = True
        Me.LblNombreEquipo.BackColor = System.Drawing.Color.Transparent
        Me.LblNombreEquipo.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombreEquipo.ForeColor = System.Drawing.Color.Black
        Me.LblNombreEquipo.Location = New System.Drawing.Point(153, 78)
        Me.LblNombreEquipo.Name = "LblNombreEquipo"
        Me.LblNombreEquipo.Size = New System.Drawing.Size(143, 17)
        Me.LblNombreEquipo.TabIndex = 4
        Me.LblNombreEquipo.Text = "Nombre_EquipoIL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Tipo de estación de trabajo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(3, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Llave de registro"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(3, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nombre del equipo"
        '
        'Cmb_TipoEstacion
        '
        Me.Cmb_TipoEstacion.BackColor = System.Drawing.Color.White
        Me.Cmb_TipoEstacion.ForeColor = System.Drawing.Color.Black
        Me.Cmb_TipoEstacion.FormattingEnabled = True
        Me.Cmb_TipoEstacion.Location = New System.Drawing.Point(153, 132)
        Me.Cmb_TipoEstacion.Name = "Cmb_TipoEstacion"
        Me.Cmb_TipoEstacion.Size = New System.Drawing.Size(332, 21)
        Me.Cmb_TipoEstacion.TabIndex = 19
        '
        'ReflectionImage2
        '
        Me.ReflectionImage2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ReflectionImage2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage2.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage2.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage2.Image = CType(resources.GetObject("ReflectionImage2.Image"), System.Drawing.Image)
        Me.ReflectionImage2.Location = New System.Drawing.Point(488, 5)
        Me.ReflectionImage2.Name = "ReflectionImage2"
        Me.ReflectionImage2.Size = New System.Drawing.Size(56, 57)
        Me.ReflectionImage2.TabIndex = 3
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnAceptar})
        Me.Bar1.Location = New System.Drawing.Point(0, 294)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(565, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 5
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAceptar.ForeColor = System.Drawing.Color.Black
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Tooltip = "Grabar"
        '
        'TextBoxX1
        '
        Me.TextBoxX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX1.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX1.FocusHighlightEnabled = True
        Me.TextBoxX1.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX1.Location = New System.Drawing.Point(103, 12)
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.PreventEnterBeep = True
        Me.TextBoxX1.ReadOnly = True
        Me.TextBoxX1.Size = New System.Drawing.Size(139, 22)
        Me.TextBoxX1.TabIndex = 30
        Me.TextBoxX1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Rut empresa"
        '
        'TextBoxX2
        '
        Me.TextBoxX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX2.Border.Class = "TextBoxBorder"
        Me.TextBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX2.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX2.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX2.Location = New System.Drawing.Point(103, 40)
        Me.TextBoxX2.Name = "TextBoxX2"
        Me.TextBoxX2.PreventEnterBeep = True
        Me.TextBoxX2.ReadOnly = True
        Me.TextBoxX2.Size = New System.Drawing.Size(382, 22)
        Me.TextBoxX2.TabIndex = 32
        Me.TextBoxX2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(3, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Nombre empresa"
        '
        'Txt_Alias
        '
        Me.Txt_Alias.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Alias.Border.Class = "TextBoxBorder"
        Me.Txt_Alias.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Alias.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Alias.ForeColor = System.Drawing.Color.Black
        Me.Txt_Alias.Location = New System.Drawing.Point(152, 159)
        Me.Txt_Alias.MaxLength = 60
        Me.Txt_Alias.Name = "Txt_Alias"
        Me.Txt_Alias.PreventEnterBeep = True
        Me.Txt_Alias.Size = New System.Drawing.Size(334, 22)
        Me.Txt_Alias.TabIndex = 47
        Me.Txt_Alias.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(4, 169)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "Alias"
        '
        'Chk_Tiene_Lector_Huella
        '
        Me.Chk_Tiene_Lector_Huella.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Tiene_Lector_Huella.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Tiene_Lector_Huella.ForeColor = System.Drawing.Color.Black
        Me.Chk_Tiene_Lector_Huella.Location = New System.Drawing.Point(3, 50)
        Me.Chk_Tiene_Lector_Huella.Name = "Chk_Tiene_Lector_Huella"
        Me.Chk_Tiene_Lector_Huella.Size = New System.Drawing.Size(148, 23)
        Me.Chk_Tiene_Lector_Huella.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Tiene_Lector_Huella.TabIndex = 44
        Me.Chk_Tiene_Lector_Huella.Text = "Tiene lector de huellas"
        '
        'Cmb_Lector_Huella
        '
        Me.Cmb_Lector_Huella.BackColor = System.Drawing.Color.White
        Me.Cmb_Lector_Huella.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Lector_Huella.FormattingEnabled = True
        Me.Cmb_Lector_Huella.Location = New System.Drawing.Point(152, 76)
        Me.Cmb_Lector_Huella.Name = "Cmb_Lector_Huella"
        Me.Cmb_Lector_Huella.Size = New System.Drawing.Size(332, 21)
        Me.Cmb_Lector_Huella.TabIndex = 42
        '
        'Lbl_Lector_Huella
        '
        Me.Lbl_Lector_Huella.AutoSize = True
        Me.Lbl_Lector_Huella.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Lector_Huella.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Lector_Huella.Location = New System.Drawing.Point(3, 79)
        Me.Lbl_Lector_Huella.Name = "Lbl_Lector_Huella"
        Me.Lbl_Lector_Huella.Size = New System.Drawing.Size(94, 13)
        Me.Lbl_Lector_Huella.TabIndex = 43
        Me.Lbl_Lector_Huella.Text = "Lector de huellas"
        '
        'Chk_Buscar_Actualizacion_En_FTP
        '
        Me.Chk_Buscar_Actualizacion_En_FTP.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Buscar_Actualizacion_En_FTP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Buscar_Actualizacion_En_FTP.ForeColor = System.Drawing.Color.Black
        Me.Chk_Buscar_Actualizacion_En_FTP.Location = New System.Drawing.Point(3, 12)
        Me.Chk_Buscar_Actualizacion_En_FTP.Name = "Chk_Buscar_Actualizacion_En_FTP"
        Me.Chk_Buscar_Actualizacion_En_FTP.Size = New System.Drawing.Size(327, 23)
        Me.Chk_Buscar_Actualizacion_En_FTP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Buscar_Actualizacion_En_FTP.TabIndex = 41
        Me.Chk_Buscar_Actualizacion_En_FTP.Text = "Buscar actualización automaticamente en FTP"
        '
        'Chk_Usar_Datos_X_Defecto
        '
        Me.Chk_Usar_Datos_X_Defecto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Usar_Datos_X_Defecto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Usar_Datos_X_Defecto.ForeColor = System.Drawing.Color.Black
        Me.Chk_Usar_Datos_X_Defecto.Location = New System.Drawing.Point(3, 3)
        Me.Chk_Usar_Datos_X_Defecto.Name = "Chk_Usar_Datos_X_Defecto"
        Me.Chk_Usar_Datos_X_Defecto.Size = New System.Drawing.Size(327, 23)
        Me.Chk_Usar_Datos_X_Defecto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Usar_Datos_X_Defecto.TabIndex = 40
        Me.Chk_Usar_Datos_X_Defecto.Text = "Usar datos por defecto al ingresar al sistema"
        '
        'Cmb_Empresa_X_Defecto
        '
        Me.Cmb_Empresa_X_Defecto.BackColor = System.Drawing.Color.White
        Me.Cmb_Empresa_X_Defecto.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Empresa_X_Defecto.FormattingEnabled = True
        Me.Cmb_Empresa_X_Defecto.Location = New System.Drawing.Point(152, 88)
        Me.Cmb_Empresa_X_Defecto.Name = "Cmb_Empresa_X_Defecto"
        Me.Cmb_Empresa_X_Defecto.Size = New System.Drawing.Size(332, 21)
        Me.Cmb_Empresa_X_Defecto.TabIndex = 38
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(3, 91)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 13)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Empresa por defecto"
        '
        'Cmb_Modalidad_X_Defecto
        '
        Me.Cmb_Modalidad_X_Defecto.BackColor = System.Drawing.Color.White
        Me.Cmb_Modalidad_X_Defecto.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Modalidad_X_Defecto.FormattingEnabled = True
        Me.Cmb_Modalidad_X_Defecto.Location = New System.Drawing.Point(152, 61)
        Me.Cmb_Modalidad_X_Defecto.Name = "Cmb_Modalidad_X_Defecto"
        Me.Cmb_Modalidad_X_Defecto.Size = New System.Drawing.Size(178, 21)
        Me.Cmb_Modalidad_X_Defecto.TabIndex = 36
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(2, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(126, 13)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Modalidad por defecto"
        '
        'Cmb_Usuario_X_Defecto
        '
        Me.Cmb_Usuario_X_Defecto.BackColor = System.Drawing.Color.White
        Me.Cmb_Usuario_X_Defecto.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Usuario_X_Defecto.FormattingEnabled = True
        Me.Cmb_Usuario_X_Defecto.Location = New System.Drawing.Point(152, 34)
        Me.Cmb_Usuario_X_Defecto.Name = "Cmb_Usuario_X_Defecto"
        Me.Cmb_Usuario_X_Defecto.Size = New System.Drawing.Size(332, 21)
        Me.Cmb_Usuario_X_Defecto.TabIndex = 34
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(3, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Usuario por defecto"
        '
        'Txt_KeyReg
        '
        Me.Txt_KeyReg.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_KeyReg.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.[Double]
        Me.Txt_KeyReg.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.[Double]
        Me.Txt_KeyReg.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.[Double]
        Me.Txt_KeyReg.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.[Double]
        Me.Txt_KeyReg.Border.Class = "TextBoxBorder"
        Me.Txt_KeyReg.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_KeyReg.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_KeyReg.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_KeyReg.ForeColor = System.Drawing.Color.Black
        Me.Txt_KeyReg.Location = New System.Drawing.Point(153, 101)
        Me.Txt_KeyReg.MaxLength = 50
        Me.Txt_KeyReg.Name = "Txt_KeyReg"
        Me.Txt_KeyReg.PreventEnterBeep = True
        Me.Txt_KeyReg.Size = New System.Drawing.Size(247, 25)
        Me.Txt_KeyReg.TabIndex = 33
        Me.Txt_KeyReg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.Transparent
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(5, 30)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(479, 23)
        Me.Line1.TabIndex = 45
        Me.Line1.Text = "Line1"
        '
        'STab
        '
        Me.STab.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.STab.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.STab.ControlBox.MenuBox.Name = ""
        Me.STab.ControlBox.Name = ""
        Me.STab.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.STab.ControlBox.MenuBox, Me.STab.ControlBox.CloseBox})
        Me.STab.Controls.Add(Me.SuperTabControlPanel4)
        Me.STab.Controls.Add(Me.SuperTabControlPanel1)
        Me.STab.Controls.Add(Me.SuperTabControlPanel2)
        Me.STab.Controls.Add(Me.SuperTabControlPanel3)
        Me.STab.ForeColor = System.Drawing.Color.Black
        Me.STab.Location = New System.Drawing.Point(5, 12)
        Me.STab.Name = "STab"
        Me.STab.ReorderTabsEnabled = True
        Me.STab.SelectedTabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.STab.SelectedTabIndex = 3
        Me.STab.Size = New System.Drawing.Size(553, 276)
        Me.STab.TabFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.STab.TabIndex = 7
        Me.STab.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Tab_EstTrabajo, Me.Tab_Empresas, Me.Tab_Configuraciones, Me.Tab_Impresoras})
        Me.STab.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.GroupPanel4)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(553, 276)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.Tab_Empresas
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Grupo_ConfCaja)
        Me.GroupPanel4.Controls.Add(Me.Chk_Usar_Datos_X_Defecto)
        Me.GroupPanel4.Controls.Add(Me.Label6)
        Me.GroupPanel4.Controls.Add(Me.Cmb_Usuario_X_Defecto)
        Me.GroupPanel4.Controls.Add(Me.Label7)
        Me.GroupPanel4.Controls.Add(Me.Cmb_Modalidad_X_Defecto)
        Me.GroupPanel4.Controls.Add(Me.Label8)
        Me.GroupPanel4.Controls.Add(Me.Cmb_Empresa_X_Defecto)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel4.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(553, 276)
        '
        '
        '
        Me.GroupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel4.Style.BackColorGradientAngle = 90
        Me.GroupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderBottomWidth = 1
        Me.GroupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderLeftWidth = 1
        Me.GroupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderRightWidth = 1
        Me.GroupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderTopWidth = 1
        Me.GroupPanel4.Style.CornerDiameter = 4
        Me.GroupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel4.TabIndex = 9
        '
        'Grupo_ConfCaja
        '
        Me.Grupo_ConfCaja.BackColor = System.Drawing.Color.White
        Me.Grupo_ConfCaja.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_ConfCaja.Controls.Add(Me.Btn_Buscar_DirectorioDTE)
        Me.Grupo_ConfCaja.Controls.Add(Me.Rdb_NO_ImprDespGrabarCaja)
        Me.Grupo_ConfCaja.Controls.Add(Me.Label10)
        Me.Grupo_ConfCaja.Controls.Add(Me.Rdb_ImprDespGrabarCaja)
        Me.Grupo_ConfCaja.Controls.Add(Me.Txt_Directorio_GenDTE)
        Me.Grupo_ConfCaja.Controls.Add(Me.Btn_Buscar_Modalidad)
        Me.Grupo_ConfCaja.Controls.Add(Me.Chk_Caja_Habilitada)
        Me.Grupo_ConfCaja.Controls.Add(Me.Txt_Modalidad_Caja)
        Me.Grupo_ConfCaja.Controls.Add(Me.Label11)
        Me.Grupo_ConfCaja.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_ConfCaja.Location = New System.Drawing.Point(3, 115)
        Me.Grupo_ConfCaja.Name = "Grupo_ConfCaja"
        Me.Grupo_ConfCaja.Size = New System.Drawing.Size(541, 122)
        '
        '
        '
        Me.Grupo_ConfCaja.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_ConfCaja.Style.BackColorGradientAngle = 90
        Me.Grupo_ConfCaja.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_ConfCaja.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_ConfCaja.Style.BorderBottomWidth = 1
        Me.Grupo_ConfCaja.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_ConfCaja.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_ConfCaja.Style.BorderLeftWidth = 1
        Me.Grupo_ConfCaja.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_ConfCaja.Style.BorderRightWidth = 1
        Me.Grupo_ConfCaja.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_ConfCaja.Style.BorderTopWidth = 1
        Me.Grupo_ConfCaja.Style.CornerDiameter = 4
        Me.Grupo_ConfCaja.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_ConfCaja.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_ConfCaja.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_ConfCaja.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_ConfCaja.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_ConfCaja.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_ConfCaja.TabIndex = 8
        '
        'Btn_Buscar_DirectorioDTE
        '
        Me.Btn_Buscar_DirectorioDTE.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_DirectorioDTE.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_DirectorioDTE.Image = CType(resources.GetObject("Btn_Buscar_DirectorioDTE.Image"), System.Drawing.Image)
        Me.Btn_Buscar_DirectorioDTE.Location = New System.Drawing.Point(490, 13)
        Me.Btn_Buscar_DirectorioDTE.Name = "Btn_Buscar_DirectorioDTE"
        Me.Btn_Buscar_DirectorioDTE.Size = New System.Drawing.Size(38, 23)
        Me.Btn_Buscar_DirectorioDTE.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_DirectorioDTE.TabIndex = 49
        Me.Btn_Buscar_DirectorioDTE.Tooltip = "Buscar directorio DTE Random"
        '
        'Rdb_NO_ImprDespGrabarCaja
        '
        Me.Rdb_NO_ImprDespGrabarCaja.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_NO_ImprDespGrabarCaja.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_NO_ImprDespGrabarCaja.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_NO_ImprDespGrabarCaja.ForeColor = System.Drawing.Color.Black
        Me.Rdb_NO_ImprDespGrabarCaja.Location = New System.Drawing.Point(185, 84)
        Me.Rdb_NO_ImprDespGrabarCaja.Name = "Rdb_NO_ImprDespGrabarCaja"
        Me.Rdb_NO_ImprDespGrabarCaja.Size = New System.Drawing.Size(220, 23)
        Me.Rdb_NO_ImprDespGrabarCaja.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_NO_ImprDespGrabarCaja.TabIndex = 56
        Me.Rdb_NO_ImprDespGrabarCaja.Text = "Solo Grabar No Imprimir (Post-Venta)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(3, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(127, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Directorio DTE Random"
        '
        'Rdb_ImprDespGrabarCaja
        '
        Me.Rdb_ImprDespGrabarCaja.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_ImprDespGrabarCaja.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_ImprDespGrabarCaja.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_ImprDespGrabarCaja.ForeColor = System.Drawing.Color.Black
        Me.Rdb_ImprDespGrabarCaja.Location = New System.Drawing.Point(5, 84)
        Me.Rdb_ImprDespGrabarCaja.Name = "Rdb_ImprDespGrabarCaja"
        Me.Rdb_ImprDespGrabarCaja.Size = New System.Drawing.Size(174, 23)
        Me.Rdb_ImprDespGrabarCaja.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_ImprDespGrabarCaja.TabIndex = 55
        Me.Rdb_ImprDespGrabarCaja.Text = "Grabar e Imprimir (Post-Venta)"
        '
        'Txt_Directorio_GenDTE
        '
        Me.Txt_Directorio_GenDTE.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Directorio_GenDTE.Border.Class = "TextBoxBorder"
        Me.Txt_Directorio_GenDTE.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Directorio_GenDTE.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Directorio_GenDTE.ForeColor = System.Drawing.Color.Black
        Me.Txt_Directorio_GenDTE.Location = New System.Drawing.Point(159, 13)
        Me.Txt_Directorio_GenDTE.Name = "Txt_Directorio_GenDTE"
        Me.Txt_Directorio_GenDTE.PreventEnterBeep = True
        Me.Txt_Directorio_GenDTE.ReadOnly = True
        Me.Txt_Directorio_GenDTE.Size = New System.Drawing.Size(325, 22)
        Me.Txt_Directorio_GenDTE.TabIndex = 48
        Me.Txt_Directorio_GenDTE.TabStop = False
        '
        'Btn_Buscar_Modalidad
        '
        Me.Btn_Buscar_Modalidad.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Modalidad.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Modalidad.Image = CType(resources.GetObject("Btn_Buscar_Modalidad.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Modalidad.Location = New System.Drawing.Point(231, 58)
        Me.Btn_Buscar_Modalidad.Name = "Btn_Buscar_Modalidad"
        Me.Btn_Buscar_Modalidad.Size = New System.Drawing.Size(35, 22)
        Me.Btn_Buscar_Modalidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Modalidad.TabIndex = 54
        Me.Btn_Buscar_Modalidad.Tooltip = "Buscar Modalidad"
        '
        'Chk_Caja_Habilitada
        '
        Me.Chk_Caja_Habilitada.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Caja_Habilitada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Caja_Habilitada.ForeColor = System.Drawing.Color.Black
        Me.Chk_Caja_Habilitada.Location = New System.Drawing.Point(5, 38)
        Me.Chk_Caja_Habilitada.Name = "Chk_Caja_Habilitada"
        Me.Chk_Caja_Habilitada.Size = New System.Drawing.Size(148, 23)
        Me.Chk_Caja_Habilitada.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Caja_Habilitada.TabIndex = 50
        Me.Chk_Caja_Habilitada.Text = "Caja habilitada (Post-Venta)"
        '
        'Txt_Modalidad_Caja
        '
        Me.Txt_Modalidad_Caja.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Modalidad_Caja.Border.Class = "TextBoxBorder"
        Me.Txt_Modalidad_Caja.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Modalidad_Caja.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Modalidad_Caja.ForeColor = System.Drawing.Color.Black
        Me.Txt_Modalidad_Caja.Location = New System.Drawing.Point(159, 58)
        Me.Txt_Modalidad_Caja.Name = "Txt_Modalidad_Caja"
        Me.Txt_Modalidad_Caja.PreventEnterBeep = True
        Me.Txt_Modalidad_Caja.ReadOnly = True
        Me.Txt_Modalidad_Caja.Size = New System.Drawing.Size(66, 22)
        Me.Txt_Modalidad_Caja.TabIndex = 53
        Me.Txt_Modalidad_Caja.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(4, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(152, 13)
        Me.Label11.TabIndex = 52
        Me.Label11.Text = "Modalidad Caja (Post-Venta)"
        '
        'Tab_Empresas
        '
        Me.Tab_Empresas.AttachedControl = Me.SuperTabControlPanel2
        Me.Tab_Empresas.GlobalItem = False
        Me.Tab_Empresas.Name = "Tab_Empresas"
        Me.Tab_Empresas.Text = "Empresa/datos por defecto"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.GroupPanel2)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(553, 249)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.Tab_EstTrabajo
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Label1)
        Me.GroupPanel2.Controls.Add(Me.Txt_Alias)
        Me.GroupPanel2.Controls.Add(Me.ReflectionImage2)
        Me.GroupPanel2.Controls.Add(Me.Label9)
        Me.GroupPanel2.Controls.Add(Me.LblNombreEquipo)
        Me.GroupPanel2.Controls.Add(Me.Label2)
        Me.GroupPanel2.Controls.Add(Me.TextBoxX1)
        Me.GroupPanel2.Controls.Add(Me.Label4)
        Me.GroupPanel2.Controls.Add(Me.Label5)
        Me.GroupPanel2.Controls.Add(Me.Cmb_TipoEstacion)
        Me.GroupPanel2.Controls.Add(Me.Label3)
        Me.GroupPanel2.Controls.Add(Me.TextBoxX2)
        Me.GroupPanel2.Controls.Add(Me.Txt_KeyReg)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(553, 249)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 0
        '
        'Tab_EstTrabajo
        '
        Me.Tab_EstTrabajo.AttachedControl = Me.SuperTabControlPanel1
        Me.Tab_EstTrabajo.GlobalItem = False
        Me.Tab_EstTrabajo.Name = "Tab_EstTrabajo"
        Me.Tab_EstTrabajo.Text = "Estación de trabajo"
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(Me.GroupPanel5)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 27)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(553, 249)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.TabItem = Me.Tab_Impresoras
        '
        'GroupPanel5
        '
        Me.GroupPanel5.BackColor = System.Drawing.Color.White
        Me.GroupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel5.Controls.Add(Me.Btn_Ver_Usuarios_Diablito)
        Me.GroupPanel5.Controls.Add(Me.Btn_Eliminar_Impresoras)
        Me.GroupPanel5.Controls.Add(Me.Grupo_Funcionarios)
        Me.GroupPanel5.Controls.Add(Me.Btn_Agregar_Impresoras)
        Me.GroupPanel5.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel5.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel5.Name = "GroupPanel5"
        Me.GroupPanel5.Size = New System.Drawing.Size(553, 249)
        '
        '
        '
        Me.GroupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel5.Style.BackColorGradientAngle = 90
        Me.GroupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderBottomWidth = 1
        Me.GroupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderLeftWidth = 1
        Me.GroupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderRightWidth = 1
        Me.GroupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderTopWidth = 1
        Me.GroupPanel5.Style.CornerDiameter = 4
        Me.GroupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel5.TabIndex = 9
        '
        'Btn_Ver_Usuarios_Diablito
        '
        Me.Btn_Ver_Usuarios_Diablito.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Ver_Usuarios_Diablito.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Ver_Usuarios_Diablito.Image = CType(resources.GetObject("Btn_Ver_Usuarios_Diablito.Image"), System.Drawing.Image)
        Me.Btn_Ver_Usuarios_Diablito.Location = New System.Drawing.Point(163, 173)
        Me.Btn_Ver_Usuarios_Diablito.Name = "Btn_Ver_Usuarios_Diablito"
        Me.Btn_Ver_Usuarios_Diablito.Size = New System.Drawing.Size(162, 36)
        Me.Btn_Ver_Usuarios_Diablito.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Ver_Usuarios_Diablito.TabIndex = 17
        Me.Btn_Ver_Usuarios_Diablito.Text = "Ver usuarios conectados a mi diablito" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Btn_Eliminar_Impresoras
        '
        Me.Btn_Eliminar_Impresoras.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Eliminar_Impresoras.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Eliminar_Impresoras.Image = CType(resources.GetObject("Btn_Eliminar_Impresoras.Image"), System.Drawing.Image)
        Me.Btn_Eliminar_Impresoras.Location = New System.Drawing.Point(497, 173)
        Me.Btn_Eliminar_Impresoras.Name = "Btn_Eliminar_Impresoras"
        Me.Btn_Eliminar_Impresoras.Size = New System.Drawing.Size(48, 31)
        Me.Btn_Eliminar_Impresoras.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Eliminar_Impresoras.TabIndex = 16
        Me.Btn_Eliminar_Impresoras.Tooltip = "Agregar impresora"
        Me.Btn_Eliminar_Impresoras.Visible = False
        '
        'Grupo_Funcionarios
        '
        Me.Grupo_Funcionarios.BackColor = System.Drawing.Color.White
        Me.Grupo_Funcionarios.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Funcionarios.Controls.Add(Me.List_Impresoras)
        Me.Grupo_Funcionarios.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Funcionarios.Location = New System.Drawing.Point(4, 3)
        Me.Grupo_Funcionarios.Name = "Grupo_Funcionarios"
        Me.Grupo_Funcionarios.Size = New System.Drawing.Size(540, 158)
        '
        '
        '
        Me.Grupo_Funcionarios.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Funcionarios.Style.BackColorGradientAngle = 90
        Me.Grupo_Funcionarios.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Funcionarios.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Funcionarios.Style.BorderBottomWidth = 1
        Me.Grupo_Funcionarios.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Funcionarios.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Funcionarios.Style.BorderLeftWidth = 1
        Me.Grupo_Funcionarios.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Funcionarios.Style.BorderRightWidth = 1
        Me.Grupo_Funcionarios.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Funcionarios.Style.BorderTopWidth = 1
        Me.Grupo_Funcionarios.Style.CornerDiameter = 4
        Me.Grupo_Funcionarios.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Funcionarios.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Funcionarios.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Funcionarios.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Funcionarios.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Funcionarios.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Funcionarios.TabIndex = 15
        '
        'List_Impresoras
        '
        Me.List_Impresoras.BackColor = System.Drawing.Color.White
        Me.List_Impresoras.ForeColor = System.Drawing.Color.Black
        Me.List_Impresoras.FormattingEnabled = True
        Me.List_Impresoras.Location = New System.Drawing.Point(3, 3)
        Me.List_Impresoras.Name = "List_Impresoras"
        Me.List_Impresoras.Size = New System.Drawing.Size(528, 147)
        Me.List_Impresoras.TabIndex = 2
        '
        'Btn_Agregar_Impresoras
        '
        Me.Btn_Agregar_Impresoras.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Agregar_Impresoras.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Agregar_Impresoras.Image = CType(resources.GetObject("Btn_Agregar_Impresoras.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Impresoras.Location = New System.Drawing.Point(4, 173)
        Me.Btn_Agregar_Impresoras.Name = "Btn_Agregar_Impresoras"
        Me.Btn_Agregar_Impresoras.Size = New System.Drawing.Size(153, 36)
        Me.Btn_Agregar_Impresoras.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Agregar_Impresoras.TabIndex = 0
        Me.Btn_Agregar_Impresoras.Text = "Actualizar listado de impresoras disponibles"
        '
        'Tab_Impresoras
        '
        Me.Tab_Impresoras.AttachedControl = Me.SuperTabControlPanel4
        Me.Tab_Impresoras.GlobalItem = False
        Me.Tab_Impresoras.Name = "Tab_Impresoras"
        Me.Tab_Impresoras.Text = "Impresoras diablito"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.GroupPanel3)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(553, 276)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.TabItem = Me.Tab_Configuraciones
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Chk_DTEMonitorAmbienteCertificacion)
        Me.GroupPanel3.Controls.Add(Me.Chk_EsDTEMonitor)
        Me.GroupPanel3.Controls.Add(Me.Chk_Buscar_Actualizacion_En_FTP)
        Me.GroupPanel3.Controls.Add(Me.Chk_Tiene_Lector_Huella)
        Me.GroupPanel3.Controls.Add(Me.Line1)
        Me.GroupPanel3.Controls.Add(Me.Cmb_Lector_Huella)
        Me.GroupPanel3.Controls.Add(Me.Lbl_Lector_Huella)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel3.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(553, 276)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 8
        '
        'Chk_DTEMonitorAmbienteCertificacion
        '
        Me.Chk_DTEMonitorAmbienteCertificacion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_DTEMonitorAmbienteCertificacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_DTEMonitorAmbienteCertificacion.ForeColor = System.Drawing.Color.Black
        Me.Chk_DTEMonitorAmbienteCertificacion.Location = New System.Drawing.Point(3, 140)
        Me.Chk_DTEMonitorAmbienteCertificacion.Name = "Chk_DTEMonitorAmbienteCertificacion"
        Me.Chk_DTEMonitorAmbienteCertificacion.Size = New System.Drawing.Size(266, 23)
        Me.Chk_DTEMonitorAmbienteCertificacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_DTEMonitorAmbienteCertificacion.TabIndex = 52
        Me.Chk_DTEMonitorAmbienteCertificacion.Text = "DTE Monitor en Ambiente Certificación"
        '
        'Chk_EsDTEMonitor
        '
        Me.Chk_EsDTEMonitor.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_EsDTEMonitor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_EsDTEMonitor.ForeColor = System.Drawing.Color.Black
        Me.Chk_EsDTEMonitor.Location = New System.Drawing.Point(3, 119)
        Me.Chk_EsDTEMonitor.Name = "Chk_EsDTEMonitor"
        Me.Chk_EsDTEMonitor.Size = New System.Drawing.Size(148, 23)
        Me.Chk_EsDTEMonitor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_EsDTEMonitor.TabIndex = 51
        Me.Chk_EsDTEMonitor.Text = "Es DTE Monitor"
        '
        'Tab_Configuraciones
        '
        Me.Tab_Configuraciones.AttachedControl = Me.SuperTabControlPanel3
        Me.Tab_Configuraciones.GlobalItem = False
        Me.Tab_Configuraciones.Name = "Tab_Configuraciones"
        Me.Tab_Configuraciones.Text = "Otras configuraciones"
        '
        'Frm_RegistrarEquipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(565, 335)
        Me.Controls.Add(Me.STab)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_RegistrarEquipo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Identificación de estación de trabajo"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.STab.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.GroupPanel4.ResumeLayout(False)
        Me.GroupPanel4.PerformLayout()
        Me.Grupo_ConfCaja.ResumeLayout(False)
        Me.Grupo_ConfCaja.PerformLayout()
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        Me.SuperTabControlPanel4.ResumeLayout(False)
        Me.GroupPanel5.ResumeLayout(False)
        Me.Grupo_Funcionarios.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ReflectionImage2 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Cmb_TipoEstacion As System.Windows.Forms.ComboBox
    Friend WithEvents LblNombreEquipo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxX2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Txt_KeyReg As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Cmb_Modalidad_X_Defecto As ComboBox
    Friend WithEvents Label7 As Label
    Public WithEvents Cmb_Usuario_X_Defecto As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Chk_Usar_Datos_X_Defecto As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Cmb_Empresa_X_Defecto As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Chk_Buscar_Actualizacion_En_FTP As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Tiene_Lector_Huella As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Cmb_Lector_Huella As ComboBox
    Friend WithEvents Lbl_Lector_Huella As Label
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Txt_Alias As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label9 As Label
    Friend WithEvents STab As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Tab_EstTrabajo As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Tab_Empresas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Tab_Configuraciones As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GroupPanel5 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Tab_Impresoras As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Btn_Agregar_Impresoras As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Grupo_Funcionarios As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Btn_Eliminar_Impresoras As DevComponents.DotNetBar.ButtonX
    Friend WithEvents List_Impresoras As ListBox
    Friend WithEvents Btn_Ver_Usuarios_Diablito As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Buscar_DirectorioDTE As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label10 As Label
    Friend WithEvents Txt_Directorio_GenDTE As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label11 As Label
    Friend WithEvents Chk_Caja_Habilitada As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Buscar_Modalidad As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Modalidad_Caja As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Rdb_NO_ImprDespGrabarCaja As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_ImprDespGrabarCaja As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Grupo_ConfCaja As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_EsDTEMonitor As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_DTEMonitorAmbienteCertificacion As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
