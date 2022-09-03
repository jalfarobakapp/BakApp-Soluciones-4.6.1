<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Choferes_Empresa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Choferes_Empresa))
        Me.Grupo_Chofer = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_Habilitado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Cmb_Comuna = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Cmb_Ciudad = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Cmb_Pais = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Btn_Tipo_Licencia = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Email = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Telefono = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Direccion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_NomChofer = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Licencia = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Imagenes_32x32 = New System.Windows.Forms.ImageList(Me.components)
        Me.Grupo_Chofer.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grupo_Chofer
        '
        Me.Grupo_Chofer.BackColor = System.Drawing.Color.White
        Me.Grupo_Chofer.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Chofer.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Chofer.Controls.Add(Me.Chk_Habilitado)
        Me.Grupo_Chofer.Controls.Add(Me.Cmb_Comuna)
        Me.Grupo_Chofer.Controls.Add(Me.Cmb_Ciudad)
        Me.Grupo_Chofer.Controls.Add(Me.Cmb_Pais)
        Me.Grupo_Chofer.Controls.Add(Me.LabelX22)
        Me.Grupo_Chofer.Controls.Add(Me.LabelX23)
        Me.Grupo_Chofer.Controls.Add(Me.LabelX24)
        Me.Grupo_Chofer.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Chofer.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Chofer.Location = New System.Drawing.Point(12, 3)
        Me.Grupo_Chofer.Name = "Grupo_Chofer"
        Me.Grupo_Chofer.Size = New System.Drawing.Size(577, 272)
        '
        '
        '
        Me.Grupo_Chofer.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Chofer.Style.BackColorGradientAngle = 90
        Me.Grupo_Chofer.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Chofer.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chofer.Style.BorderBottomWidth = 1
        Me.Grupo_Chofer.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Chofer.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chofer.Style.BorderLeftWidth = 1
        Me.Grupo_Chofer.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chofer.Style.BorderRightWidth = 1
        Me.Grupo_Chofer.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chofer.Style.BorderTopWidth = 1
        Me.Grupo_Chofer.Style.CornerDiameter = 4
        Me.Grupo_Chofer.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Chofer.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Chofer.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Chofer.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Chofer.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Chofer.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Chofer.TabIndex = 94
        Me.Grupo_Chofer.Text = "Datos del chofer"
        '
        'Chk_Habilitado
        '
        Me.Chk_Habilitado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Habilitado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Habilitado.Checked = True
        Me.Chk_Habilitado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Habilitado.CheckValue = "Y"
        Me.Chk_Habilitado.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_Habilitado.Location = New System.Drawing.Point(3, 223)
        Me.Chk_Habilitado.Name = "Chk_Habilitado"
        Me.Chk_Habilitado.Size = New System.Drawing.Size(175, 23)
        Me.Chk_Habilitado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Habilitado.TabIndex = 104
        Me.Chk_Habilitado.Text = "Chofer habilitado"
        '
        'Cmb_Comuna
        '
        Me.Cmb_Comuna.DisplayMember = "Text"
        Me.Cmb_Comuna.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Comuna.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cmb_Comuna.FocusHighlightEnabled = True
        Me.Cmb_Comuna.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Comuna.ItemHeight = 16
        Me.Cmb_Comuna.Location = New System.Drawing.Point(340, 175)
        Me.Cmb_Comuna.Name = "Cmb_Comuna"
        Me.Cmb_Comuna.Size = New System.Drawing.Size(140, 22)
        Me.Cmb_Comuna.TabIndex = 6
        Me.Cmb_Comuna.WatermarkText = "Comuna"
        '
        'Cmb_Ciudad
        '
        Me.Cmb_Ciudad.DisplayMember = "Text"
        Me.Cmb_Ciudad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Ciudad.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cmb_Ciudad.FocusHighlightEnabled = True
        Me.Cmb_Ciudad.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Ciudad.ItemHeight = 16
        Me.Cmb_Ciudad.Location = New System.Drawing.Point(151, 176)
        Me.Cmb_Ciudad.Name = "Cmb_Ciudad"
        Me.Cmb_Ciudad.Size = New System.Drawing.Size(183, 22)
        Me.Cmb_Ciudad.TabIndex = 5
        Me.Cmb_Ciudad.WatermarkText = "Ciudad - Región"
        '
        'Cmb_Pais
        '
        Me.Cmb_Pais.DisplayMember = "Text"
        Me.Cmb_Pais.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Pais.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cmb_Pais.FocusHighlightEnabled = True
        Me.Cmb_Pais.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Pais.ItemHeight = 16
        Me.Cmb_Pais.Location = New System.Drawing.Point(3, 176)
        Me.Cmb_Pais.Name = "Cmb_Pais"
        Me.Cmb_Pais.Size = New System.Drawing.Size(140, 22)
        Me.Cmb_Pais.TabIndex = 4
        Me.Cmb_Pais.WatermarkText = "País"
        '
        'LabelX22
        '
        Me.LabelX22.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX22.ForeColor = System.Drawing.Color.Black
        Me.LabelX22.Location = New System.Drawing.Point(3, 156)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(89, 23)
        Me.LabelX22.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX22.TabIndex = 101
        Me.LabelX22.Text = "País"
        '
        'LabelX23
        '
        Me.LabelX23.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX23.ForeColor = System.Drawing.Color.Black
        Me.LabelX23.Location = New System.Drawing.Point(151, 156)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(89, 23)
        Me.LabelX23.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX23.TabIndex = 102
        Me.LabelX23.Text = "Ciudad"
        '
        'LabelX24
        '
        Me.LabelX24.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX24.ForeColor = System.Drawing.Color.Black
        Me.LabelX24.Location = New System.Drawing.Point(340, 156)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(89, 23)
        Me.LabelX24.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX24.TabIndex = 103
        Me.LabelX24.Text = "Comuna"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.43694!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.348135!))
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Tipo_Licencia, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Email, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Telefono, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Direccion, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_NomChofer, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX5, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Cmb_Licencia, 1, 4)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(563, 147)
        Me.TableLayoutPanel1.TabIndex = 70
        '
        'Btn_Tipo_Licencia
        '
        Me.Btn_Tipo_Licencia.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Tipo_Licencia.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Tipo_Licencia.Image = CType(resources.GetObject("Btn_Tipo_Licencia.Image"), System.Drawing.Image)
        Me.Btn_Tipo_Licencia.Location = New System.Drawing.Point(518, 119)
        Me.Btn_Tipo_Licencia.Name = "Btn_Tipo_Licencia"
        Me.Btn_Tipo_Licencia.Size = New System.Drawing.Size(28, 22)
        Me.Btn_Tipo_Licencia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Tipo_Licencia.TabIndex = 105
        Me.Btn_Tipo_Licencia.Tooltip = "Maestra de tipo de licencia"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 119)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(177, 23)
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX4.TabIndex = 67
        Me.LabelX4.Text = "Tipo de licencia"
        '
        'Txt_Email
        '
        Me.Txt_Email.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Email.Border.Class = "TextBoxBorder"
        Me.Txt_Email.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Email.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Email.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Email.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Email.FocusHighlightEnabled = True
        Me.Txt_Email.ForeColor = System.Drawing.Color.Black
        Me.Txt_Email.Location = New System.Drawing.Point(190, 90)
        Me.Txt_Email.MaxLength = 50
        Me.Txt_Email.Name = "Txt_Email"
        Me.Txt_Email.Size = New System.Drawing.Size(279, 22)
        Me.Txt_Email.TabIndex = 3
        '
        'Txt_Telefono
        '
        Me.Txt_Telefono.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Telefono.Border.Class = "TextBoxBorder"
        Me.Txt_Telefono.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Telefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Telefono.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Telefono.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Telefono.FocusHighlightEnabled = True
        Me.Txt_Telefono.ForeColor = System.Drawing.Color.Black
        Me.Txt_Telefono.Location = New System.Drawing.Point(190, 61)
        Me.Txt_Telefono.MaxLength = 20
        Me.Txt_Telefono.Name = "Txt_Telefono"
        Me.Txt_Telefono.Size = New System.Drawing.Size(181, 22)
        Me.Txt_Telefono.TabIndex = 2
        '
        'Txt_Direccion
        '
        Me.Txt_Direccion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Direccion.Border.Class = "TextBoxBorder"
        Me.Txt_Direccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Direccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Direccion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Direccion.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Direccion.FocusHighlightEnabled = True
        Me.Txt_Direccion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Direccion.Location = New System.Drawing.Point(190, 32)
        Me.Txt_Direccion.MaxLength = 50
        Me.Txt_Direccion.Name = "Txt_Direccion"
        Me.Txt_Direccion.Size = New System.Drawing.Size(322, 22)
        Me.Txt_Direccion.TabIndex = 1
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(177, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 64
        Me.LabelX2.Text = "Nombre del chofer"
        '
        'Txt_NomChofer
        '
        Me.Txt_NomChofer.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NomChofer.Border.Class = "TextBoxBorder"
        Me.Txt_NomChofer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NomChofer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NomChofer.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NomChofer.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_NomChofer.FocusHighlightEnabled = True
        Me.Txt_NomChofer.ForeColor = System.Drawing.Color.Black
        Me.Txt_NomChofer.Location = New System.Drawing.Point(190, 3)
        Me.Txt_NomChofer.MaxLength = 50
        Me.Txt_NomChofer.Name = "Txt_NomChofer"
        Me.Txt_NomChofer.Size = New System.Drawing.Size(322, 22)
        Me.Txt_NomChofer.TabIndex = 0
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 90)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(89, 23)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX3.TabIndex = 66
        Me.LabelX3.Text = "Email"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 61)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(89, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 61
        Me.LabelX1.Text = "Teléfono"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 32)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(89, 23)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX5.TabIndex = 44
        Me.LabelX5.Text = "Dirección"
        '
        'Cmb_Licencia
        '
        Me.Cmb_Licencia.DisplayMember = "Text"
        Me.Cmb_Licencia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Licencia.FormattingEnabled = True
        Me.Cmb_Licencia.ItemHeight = 16
        Me.Cmb_Licencia.Location = New System.Drawing.Point(190, 119)
        Me.Cmb_Licencia.Name = "Cmb_Licencia"
        Me.Cmb_Licencia.Size = New System.Drawing.Size(141, 22)
        Me.Cmb_Licencia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Licencia.TabIndex = 101
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Editar, Me.Btn_Eliminar, Me.Btn_Cancelar})
        Me.Bar2.Location = New System.Drawing.Point(0, 292)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(604, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 93
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar "
        '
        'Btn_Editar
        '
        Me.Btn_Editar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Editar.FontBold = True
        Me.Btn_Editar.ForeColor = System.Drawing.Color.Red
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Tooltip = "Editar "
        Me.Btn_Editar.Visible = False
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Eliminar"
        Me.Btn_Eliminar.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.FontBold = True
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar edición"
        Me.Btn_Cancelar.Visible = False
        '
        'Imagenes_32x32
        '
        Me.Imagenes_32x32.ImageStream = CType(resources.GetObject("Imagenes_32x32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_32x32.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_32x32.Images.SetKeyName(0, "warning.png")
        '
        'Frm_Choferes_Empresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 333)
        Me.Controls.Add(Me.Grupo_Chofer)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Choferes_Empresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.Grupo_Chofer.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grupo_Chofer As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Cmb_Comuna As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Cmb_Ciudad As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Cmb_Pais As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Txt_Email As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Telefono As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Direccion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_NomChofer As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Habilitado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Cmb_Licencia As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Btn_Tipo_Licencia As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Imagenes_32x32 As System.Windows.Forms.ImageList
End Class
