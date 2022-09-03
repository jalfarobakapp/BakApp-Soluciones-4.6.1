<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_St_Mant_Tecnicos_Talleres
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_St_Mant_Tecnicos_Talleres))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Txt_Informacion = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Grupo_Presupuesto = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Cmb_Comuna = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.Cmb_Ciudad = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.Cmb_Pais = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Txt_Email = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Txt_Telefono = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Txt_Direccion = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.Txt_NomFuncionario = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.Btn_Direccion_Servicio = New DevComponents.DotNetBar.ButtonX
        Me.Rating_Star = New DevComponents.DotNetBar.Controls.RatingStar
        Me.Chk_Supervisor = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Chk_Taller_Externo = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Salir = New DevComponents.DotNetBar.ButtonItem
        Me.Grupo_Chk_Tipo_Reparacion = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Chk_Domicilio = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Chk_Habilitado = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Imagenes_32x32 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupPanel1.SuspendLayout()
        Me.Grupo_Presupuesto.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Chk_Tipo_Reparacion.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_Informacion)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 210)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(577, 89)
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
        Me.GroupPanel1.TabIndex = 91
        Me.GroupPanel1.Text = "Información adicional del técnico / taller externo"
        '
        'Txt_Informacion
        '
        Me.Txt_Informacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Informacion.Border.Class = "TextBoxBorder"
        Me.Txt_Informacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Informacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Informacion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Informacion.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Informacion.FocusHighlightEnabled = True
        Me.Txt_Informacion.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Informacion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Informacion.Location = New System.Drawing.Point(6, 3)
        Me.Txt_Informacion.MaxLength = 1000
        Me.Txt_Informacion.Multiline = True
        Me.Txt_Informacion.Name = "Txt_Informacion"
        Me.Txt_Informacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Informacion.Size = New System.Drawing.Size(560, 60)
        Me.Txt_Informacion.TabIndex = 7
        '
        'Grupo_Presupuesto
        '
        Me.Grupo_Presupuesto.BackColor = System.Drawing.Color.White
        Me.Grupo_Presupuesto.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Presupuesto.Controls.Add(Me.Cmb_Comuna)
        Me.Grupo_Presupuesto.Controls.Add(Me.Cmb_Ciudad)
        Me.Grupo_Presupuesto.Controls.Add(Me.Cmb_Pais)
        Me.Grupo_Presupuesto.Controls.Add(Me.LabelX22)
        Me.Grupo_Presupuesto.Controls.Add(Me.LabelX23)
        Me.Grupo_Presupuesto.Controls.Add(Me.LabelX24)
        Me.Grupo_Presupuesto.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo_Presupuesto.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Presupuesto.Location = New System.Drawing.Point(12, 6)
        Me.Grupo_Presupuesto.Name = "Grupo_Presupuesto"
        Me.Grupo_Presupuesto.Size = New System.Drawing.Size(577, 198)
        '
        '
        '
        Me.Grupo_Presupuesto.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Presupuesto.Style.BackColorGradientAngle = 90
        Me.Grupo_Presupuesto.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Presupuesto.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderBottomWidth = 1
        Me.Grupo_Presupuesto.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Presupuesto.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderLeftWidth = 1
        Me.Grupo_Presupuesto.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderRightWidth = 1
        Me.Grupo_Presupuesto.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Presupuesto.Style.BorderTopWidth = 1
        Me.Grupo_Presupuesto.Style.CornerDiameter = 4
        Me.Grupo_Presupuesto.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Presupuesto.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Presupuesto.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Presupuesto.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Presupuesto.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Presupuesto.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Presupuesto.TabIndex = 90
        Me.Grupo_Presupuesto.Text = "Datos del técnico o taller"
        '
        'Cmb_Comuna
        '
        Me.Cmb_Comuna.DisplayMember = "Text"
        Me.Cmb_Comuna.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Comuna.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cmb_Comuna.FocusHighlightEnabled = True
        Me.Cmb_Comuna.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Comuna.ItemHeight = 16
        Me.Cmb_Comuna.Location = New System.Drawing.Point(340, 145)
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
        Me.Cmb_Ciudad.Location = New System.Drawing.Point(151, 146)
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
        Me.Cmb_Pais.Location = New System.Drawing.Point(3, 146)
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
        Me.LabelX22.Location = New System.Drawing.Point(3, 126)
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
        Me.LabelX23.Location = New System.Drawing.Point(151, 126)
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
        Me.LabelX24.Location = New System.Drawing.Point(340, 126)
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
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Email, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Telefono, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Direccion, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_NomFuncionario, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX5, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Direccion_Servicio, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Rating_Star, 2, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(563, 117)
        Me.TableLayoutPanel1.TabIndex = 70
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
        Me.Txt_Email.Location = New System.Drawing.Point(186, 90)
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
        Me.Txt_Telefono.Location = New System.Drawing.Point(186, 61)
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
        Me.Txt_Direccion.Location = New System.Drawing.Point(186, 32)
        Me.Txt_Direccion.MaxLength = 50
        Me.Txt_Direccion.Name = "Txt_Direccion"
        Me.Txt_Direccion.Size = New System.Drawing.Size(279, 22)
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
        Me.LabelX2.Text = "Nombre del técnico o Taller"
        '
        'Txt_NomFuncionario
        '
        Me.Txt_NomFuncionario.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NomFuncionario.Border.Class = "TextBoxBorder"
        Me.Txt_NomFuncionario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NomFuncionario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NomFuncionario.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NomFuncionario.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_NomFuncionario.FocusHighlightEnabled = True
        Me.Txt_NomFuncionario.ForeColor = System.Drawing.Color.Black
        Me.Txt_NomFuncionario.Location = New System.Drawing.Point(186, 3)
        Me.Txt_NomFuncionario.Name = "Txt_NomFuncionario"
        Me.Txt_NomFuncionario.Size = New System.Drawing.Size(279, 22)
        Me.Txt_NomFuncionario.TabIndex = 0
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
        'Btn_Direccion_Servicio
        '
        Me.Btn_Direccion_Servicio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Direccion_Servicio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Direccion_Servicio.Image = CType(resources.GetObject("Btn_Direccion_Servicio.Image"), System.Drawing.Image)
        Me.Btn_Direccion_Servicio.Location = New System.Drawing.Point(471, 32)
        Me.Btn_Direccion_Servicio.Name = "Btn_Direccion_Servicio"
        Me.Btn_Direccion_Servicio.Size = New System.Drawing.Size(86, 23)
        Me.Btn_Direccion_Servicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Direccion_Servicio.TabIndex = 90
        Me.Btn_Direccion_Servicio.Text = "Ver mapa"
        '
        'Rating_Star
        '
        Me.Rating_Star.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rating_Star.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rating_Star.ForeColor = System.Drawing.Color.Black
        Me.Rating_Star.Location = New System.Drawing.Point(471, 3)
        Me.Rating_Star.Name = "Rating_Star"
        Me.Rating_Star.Size = New System.Drawing.Size(73, 23)
        Me.Rating_Star.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Rating_Star.TabIndex = 69
        Me.Rating_Star.TextColor = System.Drawing.Color.Empty
        '
        'Chk_Supervisor
        '
        Me.Chk_Supervisor.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Supervisor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Supervisor.ForeColor = System.Drawing.Color.Black
        Me.Chk_Supervisor.Location = New System.Drawing.Point(3, 53)
        Me.Chk_Supervisor.Name = "Chk_Supervisor"
        Me.Chk_Supervisor.Size = New System.Drawing.Size(280, 19)
        Me.Chk_Supervisor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Supervisor.TabIndex = 71
        Me.Chk_Supervisor.Text = "<b>Técnico Supervisor o encargado de taller</b>"
        '
        'Chk_Taller_Externo
        '
        Me.Chk_Taller_Externo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Taller_Externo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Taller_Externo.FocusCuesEnabled = False
        Me.Chk_Taller_Externo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Taller_Externo.Location = New System.Drawing.Point(3, 3)
        Me.Chk_Taller_Externo.Name = "Chk_Taller_Externo"
        Me.Chk_Taller_Externo.Size = New System.Drawing.Size(183, 16)
        Me.Chk_Taller_Externo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Taller_Externo.TabIndex = 70
        Me.Chk_Taller_Externo.Text = "<b>Taller o técnico externo</b>"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Editar, Me.Btn_Eliminar, Me.Btn_Cancelar, Me.Btn_Salir})
        Me.Bar2.Location = New System.Drawing.Point(0, 459)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(599, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 89
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
        'Btn_Salir
        '
        Me.Btn_Salir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Salir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Salir.Image = CType(resources.GetObject("Btn_Salir.Image"), System.Drawing.Image)
        Me.Btn_Salir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Salir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Tooltip = "Salir"
        '
        'Grupo_Chk_Tipo_Reparacion
        '
        Me.Grupo_Chk_Tipo_Reparacion.BackColor = System.Drawing.Color.White
        Me.Grupo_Chk_Tipo_Reparacion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Chk_Tipo_Reparacion.Controls.Add(Me.TableLayoutPanel2)
        Me.Grupo_Chk_Tipo_Reparacion.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Chk_Tipo_Reparacion.Location = New System.Drawing.Point(12, 305)
        Me.Grupo_Chk_Tipo_Reparacion.Name = "Grupo_Chk_Tipo_Reparacion"
        Me.Grupo_Chk_Tipo_Reparacion.Size = New System.Drawing.Size(577, 139)
        '
        '
        '
        Me.Grupo_Chk_Tipo_Reparacion.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Chk_Tipo_Reparacion.Style.BackColorGradientAngle = 90
        Me.Grupo_Chk_Tipo_Reparacion.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderBottomWidth = 1
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderLeftWidth = 1
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderRightWidth = 1
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Chk_Tipo_Reparacion.Style.BorderTopWidth = 1
        Me.Grupo_Chk_Tipo_Reparacion.Style.CornerDiameter = 4
        Me.Grupo_Chk_Tipo_Reparacion.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Chk_Tipo_Reparacion.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Chk_Tipo_Reparacion.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Chk_Tipo_Reparacion.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Chk_Tipo_Reparacion.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Chk_Tipo_Reparacion.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Chk_Tipo_Reparacion.TabIndex = 92
        Me.Grupo_Chk_Tipo_Reparacion.Text = "Acciones"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Taller_Externo, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Domicilio, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Habilitado, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Chk_Supervisor, 0, 2)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.5!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(590, 101)
        Me.TableLayoutPanel2.TabIndex = 68
        '
        'Chk_Domicilio
        '
        Me.Chk_Domicilio.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Domicilio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Domicilio.ForeColor = System.Drawing.Color.Black
        Me.Chk_Domicilio.Location = New System.Drawing.Point(3, 81)
        Me.Chk_Domicilio.Name = "Chk_Domicilio"
        Me.Chk_Domicilio.Size = New System.Drawing.Size(568, 17)
        Me.Chk_Domicilio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Domicilio.TabIndex = 72
        Me.Chk_Domicilio.Text = "<b>Técnico autorizado para realizar reparaciones Domicilio</b>"
        '
        'Chk_Habilitado
        '
        Me.Chk_Habilitado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Habilitado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Habilitado.ForeColor = System.Drawing.Color.Black
        Me.Chk_Habilitado.Location = New System.Drawing.Point(3, 28)
        Me.Chk_Habilitado.Name = "Chk_Habilitado"
        Me.Chk_Habilitado.Size = New System.Drawing.Size(328, 19)
        Me.Chk_Habilitado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Habilitado.TabIndex = 72
        Me.Chk_Habilitado.Text = "<b><font color=""#BA1419"">HABILITADO</font></b>"
        '
        'Imagenes_32x32
        '
        Me.Imagenes_32x32.ImageStream = CType(resources.GetObject("Imagenes_32x32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes_32x32.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes_32x32.Images.SetKeyName(0, "warning.png")
        '
        'Frm_St_Mant_Tecnicos_Talleres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 500)
        Me.ControlBox = False
        Me.Controls.Add(Me.Grupo_Chk_Tipo_Reparacion)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Grupo_Presupuesto)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_St_Mant_Tecnicos_Talleres"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantención de técnicos o talleres externos"
        Me.GroupPanel1.ResumeLayout(False)
        Me.Grupo_Presupuesto.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Chk_Tipo_Reparacion.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Informacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Grupo_Presupuesto As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_Supervisor As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Taller_Externo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rating_Star As DevComponents.DotNetBar.Controls.RatingStar
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Salir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_NomFuncionario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Comuna As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Cmb_Ciudad As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Cmb_Pais As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Email As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Telefono As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Direccion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Grupo_Chk_Tipo_Reparacion As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Chk_Habilitado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Domicilio As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Imagenes_32x32 As System.Windows.Forms.ImageList
    Friend WithEvents Btn_Direccion_Servicio As DevComponents.DotNetBar.ButtonX
End Class
