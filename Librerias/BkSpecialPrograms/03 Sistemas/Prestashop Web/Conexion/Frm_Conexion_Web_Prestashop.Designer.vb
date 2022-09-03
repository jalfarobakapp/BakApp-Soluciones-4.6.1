<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Conexion_Web_Prestashop
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Conexion_Web_Prestashop))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Chk_Grabar_Stock_X_Bodega = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Usar_Stock_Maximo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Conexion_Activa = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Num_Stock_Maximo = New System.Windows.Forms.NumericUpDown()
        Me.Cmb_Lista_Precios = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Puerto_X_Defecto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_Base_Datos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Clave = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Usuario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Host = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Nombre_Pagina = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Codigo_Pagina = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Num_Puerto = New System.Windows.Forms.NumericUpDown()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Salir = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Num_Stock_Maximo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_Puerto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Chk_Grabar_Stock_X_Bodega)
        Me.GroupPanel1.Controls.Add(Me.Chk_Usar_Stock_Maximo)
        Me.GroupPanel1.Controls.Add(Me.Chk_Conexion_Activa)
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(4, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(394, 362)
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
        Me.GroupPanel1.Text = "Datos de conexión"
        '
        'Chk_Grabar_Stock_X_Bodega
        '
        Me.Chk_Grabar_Stock_X_Bodega.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Grabar_Stock_X_Bodega.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Grabar_Stock_X_Bodega.ForeColor = System.Drawing.Color.Black
        Me.Chk_Grabar_Stock_X_Bodega.Location = New System.Drawing.Point(12, 301)
        Me.Chk_Grabar_Stock_X_Bodega.Name = "Chk_Grabar_Stock_X_Bodega"
        Me.Chk_Grabar_Stock_X_Bodega.Size = New System.Drawing.Size(315, 23)
        Me.Chk_Grabar_Stock_X_Bodega.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Grabar_Stock_X_Bodega.TabIndex = 44
        Me.Chk_Grabar_Stock_X_Bodega.Text = "Subir stock por bodegas"
        '
        'Chk_Usar_Stock_Maximo
        '
        Me.Chk_Usar_Stock_Maximo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Usar_Stock_Maximo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Usar_Stock_Maximo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Usar_Stock_Maximo.Location = New System.Drawing.Point(12, 261)
        Me.Chk_Usar_Stock_Maximo.Name = "Chk_Usar_Stock_Maximo"
        Me.Chk_Usar_Stock_Maximo.Size = New System.Drawing.Size(315, 23)
        Me.Chk_Usar_Stock_Maximo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Usar_Stock_Maximo.TabIndex = 10
        Me.Chk_Usar_Stock_Maximo.Text = "Usar stock máximo"
        '
        'Chk_Conexion_Activa
        '
        Me.Chk_Conexion_Activa.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Conexion_Activa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Conexion_Activa.ForeColor = System.Drawing.Color.Black
        Me.Chk_Conexion_Activa.Location = New System.Drawing.Point(12, 281)
        Me.Chk_Conexion_Activa.Name = "Chk_Conexion_Activa"
        Me.Chk_Conexion_Activa.Size = New System.Drawing.Size(315, 23)
        Me.Chk_Conexion_Activa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Conexion_Activa.TabIndex = 11
        Me.Chk_Conexion_Activa.Text = "Conexión activa"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.86059!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.13941!))
        Me.TableLayoutPanel1.Controls.Add(Me.Num_Stock_Maximo, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.Cmb_Lista_Precios, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX9, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_Puerto_X_Defecto, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Base_Datos, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX8, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Clave, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX7, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Usuario, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX6, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Host, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Nombre_Pagina, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Codigo_Pagina, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Num_Puerto, 1, 4)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(373, 252)
        Me.TableLayoutPanel1.TabIndex = 43
        '
        'Num_Stock_Maximo
        '
        Me.Num_Stock_Maximo.BackColor = System.Drawing.Color.White
        Me.Num_Stock_Maximo.ForeColor = System.Drawing.Color.Black
        Me.Num_Stock_Maximo.Location = New System.Drawing.Point(92, 228)
        Me.Num_Stock_Maximo.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.Num_Stock_Maximo.Name = "Num_Stock_Maximo"
        Me.Num_Stock_Maximo.Size = New System.Drawing.Size(62, 22)
        Me.Num_Stock_Maximo.TabIndex = 9
        Me.Num_Stock_Maximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Num_Stock_Maximo.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'Cmb_Lista_Precios
        '
        Me.Cmb_Lista_Precios.DisplayMember = "Text"
        Me.Cmb_Lista_Precios.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Lista_Precios.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Lista_Precios.FormattingEnabled = True
        Me.Cmb_Lista_Precios.ItemHeight = 16
        Me.Cmb_Lista_Precios.Location = New System.Drawing.Point(92, 203)
        Me.Cmb_Lista_Precios.Name = "Cmb_Lista_Precios"
        Me.Cmb_Lista_Precios.Size = New System.Drawing.Size(200, 22)
        Me.Cmb_Lista_Precios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Lista_Precios.TabIndex = 8
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(3, 228)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(75, 18)
        Me.LabelX9.TabIndex = 47
        Me.LabelX9.Text = "Stock máximo"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 203)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 18)
        Me.LabelX4.TabIndex = 47
        Me.LabelX4.Text = "Lista de precios"
        '
        'Chk_Puerto_X_Defecto
        '
        Me.Chk_Puerto_X_Defecto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Puerto_X_Defecto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Puerto_X_Defecto.ForeColor = System.Drawing.Color.Black
        Me.Chk_Puerto_X_Defecto.Location = New System.Drawing.Point(92, 78)
        Me.Chk_Puerto_X_Defecto.Name = "Chk_Puerto_X_Defecto"
        Me.Chk_Puerto_X_Defecto.Size = New System.Drawing.Size(119, 18)
        Me.Chk_Puerto_X_Defecto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Puerto_X_Defecto.TabIndex = 3
        Me.Chk_Puerto_X_Defecto.Text = "Puerto por defecto"
        '
        'Txt_Base_Datos
        '
        Me.Txt_Base_Datos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Base_Datos.Border.Class = "TextBoxBorder"
        Me.Txt_Base_Datos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Base_Datos.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Base_Datos.ForeColor = System.Drawing.Color.Black
        Me.Txt_Base_Datos.Location = New System.Drawing.Point(92, 178)
        Me.Txt_Base_Datos.Name = "Txt_Base_Datos"
        Me.Txt_Base_Datos.PreventEnterBeep = True
        Me.Txt_Base_Datos.Size = New System.Drawing.Size(112, 22)
        Me.Txt_Base_Datos.TabIndex = 7
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(3, 178)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(75, 19)
        Me.LabelX8.TabIndex = 46
        Me.LabelX8.Text = "Base de datos"
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
        Me.Txt_Clave.Location = New System.Drawing.Point(92, 153)
        Me.Txt_Clave.Name = "Txt_Clave"
        Me.Txt_Clave.PreventEnterBeep = True
        Me.Txt_Clave.Size = New System.Drawing.Size(112, 22)
        Me.Txt_Clave.TabIndex = 6
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(3, 153)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(75, 18)
        Me.LabelX7.TabIndex = 46
        Me.LabelX7.Text = "Clave"
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
        Me.Txt_Usuario.Location = New System.Drawing.Point(92, 128)
        Me.Txt_Usuario.Name = "Txt_Usuario"
        Me.Txt_Usuario.PreventEnterBeep = True
        Me.Txt_Usuario.Size = New System.Drawing.Size(112, 22)
        Me.Txt_Usuario.TabIndex = 5
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 128)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 18)
        Me.LabelX6.TabIndex = 46
        Me.LabelX6.Text = "Usuario"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 103)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 18)
        Me.LabelX5.TabIndex = 46
        Me.LabelX5.Text = "Puerto"
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
        Me.Txt_Host.Location = New System.Drawing.Point(92, 53)
        Me.Txt_Host.Name = "Txt_Host"
        Me.Txt_Host.PreventEnterBeep = True
        Me.Txt_Host.Size = New System.Drawing.Size(278, 22)
        Me.Txt_Host.TabIndex = 2
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 53)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 18)
        Me.LabelX3.TabIndex = 46
        Me.LabelX3.Text = "Servidor/Host"
        '
        'Txt_Nombre_Pagina
        '
        Me.Txt_Nombre_Pagina.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre_Pagina.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre_Pagina.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre_Pagina.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre_Pagina.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombre_Pagina.Location = New System.Drawing.Point(92, 28)
        Me.Txt_Nombre_Pagina.Name = "Txt_Nombre_Pagina"
        Me.Txt_Nombre_Pagina.PreventEnterBeep = True
        Me.Txt_Nombre_Pagina.Size = New System.Drawing.Size(278, 22)
        Me.Txt_Nombre_Pagina.TabIndex = 1
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 28)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 18)
        Me.LabelX2.TabIndex = 46
        Me.LabelX2.Text = "Nombre"
        '
        'Txt_Codigo_Pagina
        '
        Me.Txt_Codigo_Pagina.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Codigo_Pagina.Border.Class = "TextBoxBorder"
        Me.Txt_Codigo_Pagina.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Codigo_Pagina.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Codigo_Pagina.ForeColor = System.Drawing.Color.Black
        Me.Txt_Codigo_Pagina.Location = New System.Drawing.Point(92, 3)
        Me.Txt_Codigo_Pagina.Name = "Txt_Codigo_Pagina"
        Me.Txt_Codigo_Pagina.PreventEnterBeep = True
        Me.Txt_Codigo_Pagina.Size = New System.Drawing.Size(112, 22)
        Me.Txt_Codigo_Pagina.TabIndex = 0
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 18)
        Me.LabelX1.TabIndex = 44
        Me.LabelX1.Text = "Código"
        '
        'Num_Puerto
        '
        Me.Num_Puerto.BackColor = System.Drawing.Color.White
        Me.Num_Puerto.ForeColor = System.Drawing.Color.Black
        Me.Num_Puerto.Location = New System.Drawing.Point(92, 103)
        Me.Num_Puerto.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.Num_Puerto.Name = "Num_Puerto"
        Me.Num_Puerto.Size = New System.Drawing.Size(62, 22)
        Me.Num_Puerto.TabIndex = 4
        Me.Num_Puerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Num_Puerto.Value = New Decimal(New Integer() {3306, 0, 0, 0})
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar2.Location = New System.Drawing.Point(0, 380)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(402, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 42
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar conexión"
        '
        'Btn_Salir
        '
        Me.Btn_Salir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Salir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Salir.Image = CType(resources.GetObject("Btn_Salir.Image"), System.Drawing.Image)
        Me.Btn_Salir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Salir.Name = "Btn_Salir"
        '
        'Frm_Conexion_Web_Prestashop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 421)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Conexion_Web_Prestashop"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos de conexión Prestashop Web"
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Num_Stock_Maximo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_Puerto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Salir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Chk_Puerto_X_Defecto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Txt_Base_Datos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Clave As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Usuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Host As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Nombre_Pagina As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Codigo_Pagina As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Num_Puerto As System.Windows.Forms.NumericUpDown
    Friend WithEvents Chk_Conexion_Activa As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Usar_Stock_Maximo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Num_Stock_Maximo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Cmb_Lista_Precios As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Grabar_Stock_X_Bodega As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
