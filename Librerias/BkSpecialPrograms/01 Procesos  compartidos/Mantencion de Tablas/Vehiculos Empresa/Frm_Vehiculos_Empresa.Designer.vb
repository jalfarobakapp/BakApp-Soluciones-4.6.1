<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Vehiculos_Empresa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Vehiculos_Empresa))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Fotos_Vehiculo = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Vehiculo = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Txt_Patente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Nombre_Vehiculo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_Nombre_Vehiculo = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Patente = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Txt_Nro_Motor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Cmb_Chofer = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Cmb_Tipo_Vehiculo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Cmb_Color = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Chk_Habilitado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Cmb_Modelo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Marca = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Lbl_Chofer = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Chofer = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_Kilometraje = New DevComponents.DotNetBar.LabelX()
        Me.Input_Kilometraje = New DevComponents.Editors.IntegerInput()
        Me.Txt_Nro_Vin = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_Nro_Vin = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nro_Serie = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Input_Ano = New DevComponents.Editors.IntegerInput()
        Me.Btn_Tipo_Vehiculo = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_Tipo_Vehiculo = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Modelo = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_Ano = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Modelo = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Marca = New DevComponents.DotNetBar.ButtonX()
        Me.Lbl_Marca = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Nro_Motor = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Chasis = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nro_Chasis = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_Nro_Serie = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Color = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Color = New DevComponents.DotNetBar.ButtonX()
        Me.Imagenes_32x32 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Vehiculo.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.Input_Kilometraje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Ano, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Editar, Me.Btn_Eliminar, Me.Btn_Cancelar, Me.Btn_Fotos_Vehiculo})
        Me.Bar2.Location = New System.Drawing.Point(0, 495)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(506, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 96
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
        'Btn_Fotos_Vehiculo
        '
        Me.Btn_Fotos_Vehiculo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Fotos_Vehiculo.FontBold = True
        Me.Btn_Fotos_Vehiculo.ForeColor = System.Drawing.Color.Black
        Me.Btn_Fotos_Vehiculo.Image = CType(resources.GetObject("Btn_Fotos_Vehiculo.Image"), System.Drawing.Image)
        Me.Btn_Fotos_Vehiculo.Name = "Btn_Fotos_Vehiculo"
        Me.Btn_Fotos_Vehiculo.Text = "Fotos del vehículo"
        Me.Btn_Fotos_Vehiculo.Visible = False
        '
        'Grupo_Vehiculo
        '
        Me.Grupo_Vehiculo.BackColor = System.Drawing.Color.White
        Me.Grupo_Vehiculo.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grupo_Vehiculo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Vehiculo.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Vehiculo.Controls.Add(Me.TableLayoutPanel2)
        Me.Grupo_Vehiculo.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Vehiculo.Location = New System.Drawing.Point(12, 12)
        Me.Grupo_Vehiculo.Name = "Grupo_Vehiculo"
        Me.Grupo_Vehiculo.Size = New System.Drawing.Size(484, 477)
        '
        '
        '
        Me.Grupo_Vehiculo.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Vehiculo.Style.BackColorGradientAngle = 90
        Me.Grupo_Vehiculo.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Vehiculo.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Vehiculo.Style.BorderBottomWidth = 1
        Me.Grupo_Vehiculo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Vehiculo.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Vehiculo.Style.BorderLeftWidth = 1
        Me.Grupo_Vehiculo.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Vehiculo.Style.BorderRightWidth = 1
        Me.Grupo_Vehiculo.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Vehiculo.Style.BorderTopWidth = 1
        Me.Grupo_Vehiculo.Style.CornerDiameter = 4
        Me.Grupo_Vehiculo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Vehiculo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Vehiculo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Vehiculo.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Vehiculo.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Vehiculo.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Vehiculo.TabIndex = 99
        Me.Grupo_Vehiculo.Text = "Información del Vehículo"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.28947!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.71053!))
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Patente, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Nombre_Vehiculo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Nombre_Vehiculo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Patente, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.1875!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.8125!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(456, 64)
        Me.TableLayoutPanel1.TabIndex = 69
        '
        'Txt_Patente
        '
        Me.Txt_Patente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Patente.Border.Class = "TextBoxBorder"
        Me.Txt_Patente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Patente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Patente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Patente.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Patente.FocusHighlightEnabled = True
        Me.Txt_Patente.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Patente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Patente.Location = New System.Drawing.Point(131, 30)
        Me.Txt_Patente.MaxLength = 10
        Me.Txt_Patente.Name = "Txt_Patente"
        Me.Txt_Patente.Size = New System.Drawing.Size(116, 33)
        Me.Txt_Patente.TabIndex = 89
        Me.Txt_Patente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_Nombre_Vehiculo
        '
        Me.Txt_Nombre_Vehiculo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre_Vehiculo.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre_Vehiculo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre_Vehiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nombre_Vehiculo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre_Vehiculo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nombre_Vehiculo.FocusHighlightEnabled = True
        Me.Txt_Nombre_Vehiculo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombre_Vehiculo.Location = New System.Drawing.Point(131, 3)
        Me.Txt_Nombre_Vehiculo.MaxLength = 50
        Me.Txt_Nombre_Vehiculo.Name = "Txt_Nombre_Vehiculo"
        Me.Txt_Nombre_Vehiculo.Size = New System.Drawing.Size(302, 22)
        Me.Txt_Nombre_Vehiculo.TabIndex = 100
        '
        'Lbl_Nombre_Vehiculo
        '
        Me.Lbl_Nombre_Vehiculo.AutoSize = True
        Me.Lbl_Nombre_Vehiculo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Nombre_Vehiculo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nombre_Vehiculo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Nombre_Vehiculo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nombre_Vehiculo.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Nombre_Vehiculo.Name = "Lbl_Nombre_Vehiculo"
        Me.Lbl_Nombre_Vehiculo.Size = New System.Drawing.Size(101, 20)
        Me.Lbl_Nombre_Vehiculo.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Nombre_Vehiculo.TabIndex = 100
        Me.Lbl_Nombre_Vehiculo.Text = "Nombre vehículo"
        '
        'Lbl_Patente
        '
        Me.Lbl_Patente.AutoSize = True
        Me.Lbl_Patente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Patente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Patente.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Patente.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Patente.Location = New System.Drawing.Point(3, 30)
        Me.Lbl_Patente.Name = "Lbl_Patente"
        Me.Lbl_Patente.Size = New System.Drawing.Size(46, 20)
        Me.Lbl_Patente.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Patente.TabIndex = 70
        Me.Lbl_Patente.Text = "Patente"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.28458!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.64822!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.26482!))
        Me.TableLayoutPanel2.Controls.Add(Me.Txt_Nro_Motor, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Cmb_Chofer, 1, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.Cmb_Tipo_Vehiculo, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Cmb_Color, 1, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Habilitado, 1, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.Cmb_Modelo, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX11, 0, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.Cmb_Marca, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Chofer, 0, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.Btn_Chofer, 2, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Kilometraje, 0, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.Input_Kilometraje, 1, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.Txt_Nro_Vin, 1, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Nro_Vin, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.Txt_Nro_Serie, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.Input_Ano, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Btn_Tipo_Vehiculo, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Tipo_Vehiculo, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Btn_Modelo, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Ano, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Modelo, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Btn_Marca, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Marca, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Nro_Motor, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Chasis, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Txt_Nro_Chasis, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Nro_Serie, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_Color, 0, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.Btn_Color, 2, 8)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 73)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 12
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(494, 360)
        Me.TableLayoutPanel2.TabIndex = 68
        '
        'Txt_Nro_Motor
        '
        Me.Txt_Nro_Motor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nro_Motor.Border.Class = "TextBoxBorder"
        Me.Txt_Nro_Motor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nro_Motor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nro_Motor.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nro_Motor.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nro_Motor.FocusHighlightEnabled = True
        Me.Txt_Nro_Motor.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nro_Motor.Location = New System.Drawing.Point(132, 123)
        Me.Txt_Nro_Motor.MaxLength = 50
        Me.Txt_Nro_Motor.Name = "Txt_Nro_Motor"
        Me.Txt_Nro_Motor.Size = New System.Drawing.Size(302, 22)
        Me.Txt_Nro_Motor.TabIndex = 100
        '
        'Cmb_Chofer
        '
        Me.Cmb_Chofer.DisplayMember = "Text"
        Me.Cmb_Chofer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Chofer.FormattingEnabled = True
        Me.Cmb_Chofer.ItemHeight = 16
        Me.Cmb_Chofer.Location = New System.Drawing.Point(132, 303)
        Me.Cmb_Chofer.Name = "Cmb_Chofer"
        Me.Cmb_Chofer.Size = New System.Drawing.Size(301, 22)
        Me.Cmb_Chofer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Chofer.TabIndex = 103
        '
        'Cmb_Tipo_Vehiculo
        '
        Me.Cmb_Tipo_Vehiculo.DisplayMember = "Text"
        Me.Cmb_Tipo_Vehiculo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tipo_Vehiculo.FormattingEnabled = True
        Me.Cmb_Tipo_Vehiculo.ItemHeight = 16
        Me.Cmb_Tipo_Vehiculo.Location = New System.Drawing.Point(132, 3)
        Me.Cmb_Tipo_Vehiculo.Name = "Cmb_Tipo_Vehiculo"
        Me.Cmb_Tipo_Vehiculo.Size = New System.Drawing.Size(301, 22)
        Me.Cmb_Tipo_Vehiculo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Tipo_Vehiculo.TabIndex = 70
        '
        'Cmb_Color
        '
        Me.Cmb_Color.DisplayMember = "Text"
        Me.Cmb_Color.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Color.FormattingEnabled = True
        Me.Cmb_Color.ItemHeight = 16
        Me.Cmb_Color.Location = New System.Drawing.Point(132, 243)
        Me.Cmb_Color.Name = "Cmb_Color"
        Me.Cmb_Color.Size = New System.Drawing.Size(301, 22)
        Me.Cmb_Color.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Color.TabIndex = 102
        '
        'Chk_Habilitado
        '
        '
        '
        '
        Me.Chk_Habilitado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Habilitado.Checked = True
        Me.Chk_Habilitado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Habilitado.CheckValue = "Y"
        Me.Chk_Habilitado.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_Habilitado.Location = New System.Drawing.Point(132, 333)
        Me.Chk_Habilitado.Name = "Chk_Habilitado"
        Me.Chk_Habilitado.Size = New System.Drawing.Size(175, 23)
        Me.Chk_Habilitado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Habilitado.TabIndex = 100
        Me.Chk_Habilitado.Text = "Vehículo habilitado"
        '
        'Cmb_Modelo
        '
        Me.Cmb_Modelo.DisplayMember = "Text"
        Me.Cmb_Modelo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Modelo.FormattingEnabled = True
        Me.Cmb_Modelo.ItemHeight = 16
        Me.Cmb_Modelo.Location = New System.Drawing.Point(132, 93)
        Me.Cmb_Modelo.Name = "Cmb_Modelo"
        Me.Cmb_Modelo.Size = New System.Drawing.Size(301, 22)
        Me.Cmb_Modelo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Modelo.TabIndex = 101
        '
        'LabelX11
        '
        Me.LabelX11.AutoSize = True
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(3, 333)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(62, 20)
        Me.LabelX11.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX11.TabIndex = 111
        Me.LabelX11.Text = "Habilitado"
        '
        'Cmb_Marca
        '
        Me.Cmb_Marca.DisplayMember = "Text"
        Me.Cmb_Marca.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Marca.FormattingEnabled = True
        Me.Cmb_Marca.ItemHeight = 16
        Me.Cmb_Marca.Location = New System.Drawing.Point(132, 63)
        Me.Cmb_Marca.Name = "Cmb_Marca"
        Me.Cmb_Marca.Size = New System.Drawing.Size(301, 22)
        Me.Cmb_Marca.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Marca.TabIndex = 100
        '
        'Lbl_Chofer
        '
        Me.Lbl_Chofer.AutoSize = True
        Me.Lbl_Chofer.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Chofer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Chofer.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Chofer.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Chofer.Location = New System.Drawing.Point(3, 303)
        Me.Lbl_Chofer.Name = "Lbl_Chofer"
        Me.Lbl_Chofer.Size = New System.Drawing.Size(97, 20)
        Me.Lbl_Chofer.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Chofer.TabIndex = 110
        Me.Lbl_Chofer.Text = "Chofer asignado"
        '
        'Btn_Chofer
        '
        Me.Btn_Chofer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Chofer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Chofer.Image = CType(resources.GetObject("Btn_Chofer.Image"), System.Drawing.Image)
        Me.Btn_Chofer.Location = New System.Drawing.Point(440, 303)
        Me.Btn_Chofer.Name = "Btn_Chofer"
        Me.Btn_Chofer.Size = New System.Drawing.Size(28, 20)
        Me.Btn_Chofer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Chofer.TabIndex = 69
        Me.Btn_Chofer.Tooltip = "Mantención de tabla de choferes"
        '
        'Lbl_Kilometraje
        '
        Me.Lbl_Kilometraje.AutoSize = True
        Me.Lbl_Kilometraje.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Kilometraje.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Kilometraje.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Kilometraje.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Kilometraje.Location = New System.Drawing.Point(3, 273)
        Me.Lbl_Kilometraje.Name = "Lbl_Kilometraje"
        Me.Lbl_Kilometraje.Size = New System.Drawing.Size(67, 20)
        Me.Lbl_Kilometraje.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Kilometraje.TabIndex = 109
        Me.Lbl_Kilometraje.Text = "Kilometraje"
        '
        'Input_Kilometraje
        '
        Me.Input_Kilometraje.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Kilometraje.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Kilometraje.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Kilometraje.ButtonClear.Visible = True
        Me.Input_Kilometraje.FocusHighlightEnabled = True
        Me.Input_Kilometraje.ForeColor = System.Drawing.Color.Black
        Me.Input_Kilometraje.Location = New System.Drawing.Point(132, 273)
        Me.Input_Kilometraje.MaxValue = 999999
        Me.Input_Kilometraje.MinValue = 1950
        Me.Input_Kilometraje.Name = "Input_Kilometraje"
        Me.Input_Kilometraje.ShowUpDown = True
        Me.Input_Kilometraje.Size = New System.Drawing.Size(90, 22)
        Me.Input_Kilometraje.TabIndex = 106
        Me.Input_Kilometraje.Value = 1950
        '
        'Txt_Nro_Vin
        '
        Me.Txt_Nro_Vin.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nro_Vin.Border.Class = "TextBoxBorder"
        Me.Txt_Nro_Vin.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nro_Vin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nro_Vin.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nro_Vin.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nro_Vin.FocusHighlightEnabled = True
        Me.Txt_Nro_Vin.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nro_Vin.Location = New System.Drawing.Point(132, 213)
        Me.Txt_Nro_Vin.MaxLength = 50
        Me.Txt_Nro_Vin.Name = "Txt_Nro_Vin"
        Me.Txt_Nro_Vin.Size = New System.Drawing.Size(302, 22)
        Me.Txt_Nro_Vin.TabIndex = 71
        '
        'Lbl_Nro_Vin
        '
        Me.Lbl_Nro_Vin.AutoSize = True
        Me.Lbl_Nro_Vin.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Nro_Vin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nro_Vin.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Nro_Vin.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nro_Vin.Location = New System.Drawing.Point(3, 213)
        Me.Lbl_Nro_Vin.Name = "Lbl_Nro_Vin"
        Me.Lbl_Nro_Vin.Size = New System.Drawing.Size(90, 20)
        Me.Lbl_Nro_Vin.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Nro_Vin.TabIndex = 107
        Me.Lbl_Nro_Vin.Text = "Número de Vin"
        '
        'Txt_Nro_Serie
        '
        Me.Txt_Nro_Serie.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nro_Serie.Border.Class = "TextBoxBorder"
        Me.Txt_Nro_Serie.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nro_Serie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nro_Serie.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nro_Serie.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nro_Serie.FocusHighlightEnabled = True
        Me.Txt_Nro_Serie.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nro_Serie.Location = New System.Drawing.Point(132, 183)
        Me.Txt_Nro_Serie.MaxLength = 50
        Me.Txt_Nro_Serie.Name = "Txt_Nro_Serie"
        Me.Txt_Nro_Serie.Size = New System.Drawing.Size(302, 22)
        Me.Txt_Nro_Serie.TabIndex = 70
        '
        'Input_Ano
        '
        Me.Input_Ano.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Ano.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Ano.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Ano.ButtonClear.Visible = True
        Me.Input_Ano.FocusHighlightEnabled = True
        Me.Input_Ano.ForeColor = System.Drawing.Color.Black
        Me.Input_Ano.Location = New System.Drawing.Point(132, 33)
        Me.Input_Ano.MaxValue = 2017
        Me.Input_Ano.MinValue = 1950
        Me.Input_Ano.Name = "Input_Ano"
        Me.Input_Ano.ShowUpDown = True
        Me.Input_Ano.Size = New System.Drawing.Size(65, 22)
        Me.Input_Ano.TabIndex = 105
        Me.Input_Ano.Value = 1950
        '
        'Btn_Tipo_Vehiculo
        '
        Me.Btn_Tipo_Vehiculo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Tipo_Vehiculo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Tipo_Vehiculo.Image = CType(resources.GetObject("Btn_Tipo_Vehiculo.Image"), System.Drawing.Image)
        Me.Btn_Tipo_Vehiculo.Location = New System.Drawing.Point(440, 3)
        Me.Btn_Tipo_Vehiculo.Name = "Btn_Tipo_Vehiculo"
        Me.Btn_Tipo_Vehiculo.Size = New System.Drawing.Size(28, 22)
        Me.Btn_Tipo_Vehiculo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Tipo_Vehiculo.TabIndex = 88
        Me.Btn_Tipo_Vehiculo.Tooltip = "Mantención de tabla de tipo de vehículos"
        '
        'Lbl_Tipo_Vehiculo
        '
        Me.Lbl_Tipo_Vehiculo.AutoSize = True
        Me.Lbl_Tipo_Vehiculo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Tipo_Vehiculo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Tipo_Vehiculo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Tipo_Vehiculo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Tipo_Vehiculo.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Tipo_Vehiculo.Name = "Lbl_Tipo_Vehiculo"
        Me.Lbl_Tipo_Vehiculo.Size = New System.Drawing.Size(97, 20)
        Me.Lbl_Tipo_Vehiculo.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Tipo_Vehiculo.TabIndex = 64
        Me.Lbl_Tipo_Vehiculo.Text = "Tipo de vehículo"
        '
        'Btn_Modelo
        '
        Me.Btn_Modelo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Modelo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Modelo.Image = CType(resources.GetObject("Btn_Modelo.Image"), System.Drawing.Image)
        Me.Btn_Modelo.Location = New System.Drawing.Point(440, 93)
        Me.Btn_Modelo.Name = "Btn_Modelo"
        Me.Btn_Modelo.Size = New System.Drawing.Size(28, 22)
        Me.Btn_Modelo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Modelo.TabIndex = 67
        Me.Btn_Modelo.Tooltip = "Mantención de tabla de modelos de marcas de vehículos"
        '
        'Lbl_Ano
        '
        Me.Lbl_Ano.AutoSize = True
        Me.Lbl_Ano.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Ano.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Ano.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Ano.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Ano.Location = New System.Drawing.Point(3, 33)
        Me.Lbl_Ano.Name = "Lbl_Ano"
        Me.Lbl_Ano.Size = New System.Drawing.Size(26, 20)
        Me.Lbl_Ano.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Ano.TabIndex = 44
        Me.Lbl_Ano.Text = "Año"
        '
        'Lbl_Modelo
        '
        Me.Lbl_Modelo.AutoSize = True
        Me.Lbl_Modelo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Modelo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Modelo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Modelo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Modelo.Location = New System.Drawing.Point(3, 93)
        Me.Lbl_Modelo.Name = "Lbl_Modelo"
        Me.Lbl_Modelo.Size = New System.Drawing.Size(47, 20)
        Me.Lbl_Modelo.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Modelo.TabIndex = 66
        Me.Lbl_Modelo.Text = "Modelo"
        '
        'Btn_Marca
        '
        Me.Btn_Marca.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Marca.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Marca.Image = CType(resources.GetObject("Btn_Marca.Image"), System.Drawing.Image)
        Me.Btn_Marca.Location = New System.Drawing.Point(440, 63)
        Me.Btn_Marca.Name = "Btn_Marca"
        Me.Btn_Marca.Size = New System.Drawing.Size(28, 22)
        Me.Btn_Marca.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Marca.TabIndex = 62
        Me.Btn_Marca.Tooltip = "Mantención de tabla de marcas de vehículos"
        '
        'Lbl_Marca
        '
        Me.Lbl_Marca.AutoSize = True
        Me.Lbl_Marca.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Marca.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Marca.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Marca.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Marca.Location = New System.Drawing.Point(3, 63)
        Me.Lbl_Marca.Name = "Lbl_Marca"
        Me.Lbl_Marca.Size = New System.Drawing.Size(38, 20)
        Me.Lbl_Marca.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Marca.TabIndex = 61
        Me.Lbl_Marca.Text = "Marca"
        '
        'Lbl_Nro_Motor
        '
        Me.Lbl_Nro_Motor.AutoSize = True
        Me.Lbl_Nro_Motor.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Nro_Motor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nro_Motor.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Nro_Motor.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nro_Motor.Location = New System.Drawing.Point(3, 123)
        Me.Lbl_Nro_Motor.Name = "Lbl_Nro_Motor"
        Me.Lbl_Nro_Motor.Size = New System.Drawing.Size(107, 20)
        Me.Lbl_Nro_Motor.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Nro_Motor.TabIndex = 69
        Me.Lbl_Nro_Motor.Text = "Número de Motor"
        '
        'Lbl_Chasis
        '
        Me.Lbl_Chasis.AutoSize = True
        Me.Lbl_Chasis.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Chasis.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Chasis.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Chasis.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Chasis.Location = New System.Drawing.Point(3, 153)
        Me.Lbl_Chasis.Name = "Lbl_Chasis"
        Me.Lbl_Chasis.Size = New System.Drawing.Size(107, 20)
        Me.Lbl_Chasis.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Chasis.TabIndex = 48
        Me.Lbl_Chasis.Text = "Número de Chasis"
        '
        'Txt_Nro_Chasis
        '
        Me.Txt_Nro_Chasis.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nro_Chasis.Border.Class = "TextBoxBorder"
        Me.Txt_Nro_Chasis.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nro_Chasis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nro_Chasis.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nro_Chasis.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nro_Chasis.FocusHighlightEnabled = True
        Me.Txt_Nro_Chasis.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nro_Chasis.Location = New System.Drawing.Point(132, 153)
        Me.Txt_Nro_Chasis.MaxLength = 50
        Me.Txt_Nro_Chasis.Name = "Txt_Nro_Chasis"
        Me.Txt_Nro_Chasis.Size = New System.Drawing.Size(302, 22)
        Me.Txt_Nro_Chasis.TabIndex = 69
        '
        'Lbl_Nro_Serie
        '
        Me.Lbl_Nro_Serie.AutoSize = True
        Me.Lbl_Nro_Serie.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Nro_Serie.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nro_Serie.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Nro_Serie.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nro_Serie.Location = New System.Drawing.Point(3, 183)
        Me.Lbl_Nro_Serie.Name = "Lbl_Nro_Serie"
        Me.Lbl_Nro_Serie.Size = New System.Drawing.Size(99, 20)
        Me.Lbl_Nro_Serie.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Nro_Serie.TabIndex = 106
        Me.Lbl_Nro_Serie.Text = "Número de Serie"
        '
        'Lbl_Color
        '
        Me.Lbl_Color.AutoSize = True
        Me.Lbl_Color.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Color.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Color.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Color.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Color.Location = New System.Drawing.Point(3, 243)
        Me.Lbl_Color.Name = "Lbl_Color"
        Me.Lbl_Color.Size = New System.Drawing.Size(33, 20)
        Me.Lbl_Color.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Color.TabIndex = 108
        Me.Lbl_Color.Text = "Color"
        '
        'Btn_Color
        '
        Me.Btn_Color.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Color.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Color.Image = CType(resources.GetObject("Btn_Color.Image"), System.Drawing.Image)
        Me.Btn_Color.Location = New System.Drawing.Point(440, 243)
        Me.Btn_Color.Name = "Btn_Color"
        Me.Btn_Color.Size = New System.Drawing.Size(28, 20)
        Me.Btn_Color.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Color.TabIndex = 69
        Me.Btn_Color.Tooltip = "Mantención de tabla de colores"
        '
        'Imagenes_32x32
        '
        Me.Imagenes_32x32.ImageStream = CType(resources.GetObject("Imagenes_32x32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_32x32.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_32x32.Images.SetKeyName(0, "warning.png")
        '
        'Frm_Vehiculos_Empresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 536)
        Me.Controls.Add(Me.Grupo_Vehiculo)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Vehiculos_Empresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Vehiculo.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.Input_Kilometraje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Ano, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Vehiculo As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Btn_Tipo_Vehiculo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Lbl_Tipo_Vehiculo As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Modelo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Lbl_Chasis As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Ano As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Modelo As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Marca As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Lbl_Marca As DevComponents.DotNetBar.LabelX
    Private WithEvents Input_Ano As DevComponents.Editors.IntegerInput
    Friend WithEvents Txt_Nro_Serie As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Nro_Motor As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Nro_Chasis As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Nro_Serie As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Chofer As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Chofer As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Lbl_Kilometraje As DevComponents.DotNetBar.LabelX
    Private WithEvents Input_Kilometraje As DevComponents.Editors.IntegerInput
    Friend WithEvents Txt_Nro_Vin As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Nro_Vin As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Color As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Color As DevComponents.DotNetBar.ButtonX
    Public WithEvents Btn_Fotos_Vehiculo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Habilitado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents Txt_Patente As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Nombre_Vehiculo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_Patente As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Nombre_Vehiculo As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Tipo_Vehiculo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Cmb_Chofer As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Cmb_Color As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Cmb_Modelo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Cmb_Marca As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Txt_Nro_Motor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Imagenes_32x32 As System.Windows.Forms.ImageList
End Class
