<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Usuarios_Random_Ficha
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Usuarios_Random_Ficha))
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Codigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Rut = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX4 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Nombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Direccion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Telefono = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Email = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_EmailSup = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Cod_Ext = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Comuna = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Buscar_Comuna = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Password = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Lbl_111 = New DevComponents.DotNetBar.LabelX()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.Txt_Modalidad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Chk_Parafirma = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Inactivo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(139, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 42
        Me.LabelX2.Text = "Código del Funcionario"
        '
        'Txt_Codigo
        '
        Me.Txt_Codigo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Codigo.Border.Class = "TextBoxBorder"
        Me.Txt_Codigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Codigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Codigo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Codigo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Codigo.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Codigo, True)
        Me.Txt_Codigo.Location = New System.Drawing.Point(157, 13)
        Me.Txt_Codigo.Name = "Txt_Codigo"
        Me.Txt_Codigo.Size = New System.Drawing.Size(64, 22)
        Me.Txt_Codigo.TabIndex = 0
        '
        'Txt_Rut
        '
        Me.Txt_Rut.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Rut.Border.Class = "TextBoxBorder"
        Me.Txt_Rut.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Rut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Rut.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Rut.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Rut.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Rut, True)
        Me.Txt_Rut.Location = New System.Drawing.Point(454, 12)
        Me.Txt_Rut.Name = "Txt_Rut"
        Me.Txt_Rut.Size = New System.Drawing.Size(184, 22)
        Me.Txt_Rut.TabIndex = 1
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(405, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(43, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 47
        Me.LabelX1.Text = "RUT"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX4, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(89, 23)
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX4.TabIndex = 42
        Me.LabelX4.Text = "Código entidad"
        '
        'TextBoxX4
        '
        Me.TextBoxX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX4.Border.Class = "TextBoxBorder"
        Me.TextBoxX4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxX4.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX4.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxX4.FocusHighlightEnabled = True
        Me.TextBoxX4.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX4.Location = New System.Drawing.Point(157, 3)
        Me.TextBoxX4.Name = "TextBoxX4"
        Me.TextBoxX4.Size = New System.Drawing.Size(140, 20)
        Me.TextBoxX4.TabIndex = 43
        Me.TextBoxX4.WatermarkText = "Largo max. 13"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.38843!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.61157!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 354.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX3, 0, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 3)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(1, 23)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX3.TabIndex = 42
        Me.LabelX3.Text = "Código entidad"
        '
        'TextBoxX2
        '
        Me.TextBoxX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX2.Border.Class = "TextBoxBorder"
        Me.TextBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxX2.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX2.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxX2.FocusHighlightEnabled = True
        Me.TextBoxX2.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX2.Location = New System.Drawing.Point(108, 3)
        Me.TextBoxX2.Name = "TextBoxX2"
        Me.TextBoxX2.Size = New System.Drawing.Size(64, 20)
        Me.TextBoxX2.TabIndex = 43
        Me.TextBoxX2.WatermarkText = "Largo max. 13"
        '
        'Txt_Nombre
        '
        Me.Txt_Nombre.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nombre.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Nombre.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Nombre, True)
        Me.Txt_Nombre.Location = New System.Drawing.Point(157, 41)
        Me.Txt_Nombre.Name = "Txt_Nombre"
        Me.Txt_Nombre.Size = New System.Drawing.Size(481, 22)
        Me.Txt_Nombre.TabIndex = 2
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(12, 40)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelX5.Size = New System.Drawing.Size(102, 23)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX5.TabIndex = 47
        Me.LabelX5.Text = "Nombre"
        '
        'Txt_Direccion
        '
        Me.Txt_Direccion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Direccion.Border.Class = "TextBoxBorder"
        Me.Txt_Direccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Direccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.Txt_Direccion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Direccion.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Direccion.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Direccion, True)
        Me.Txt_Direccion.Location = New System.Drawing.Point(157, 69)
        Me.Txt_Direccion.Name = "Txt_Direccion"
        Me.Txt_Direccion.Size = New System.Drawing.Size(481, 22)
        Me.Txt_Direccion.TabIndex = 3
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
        Me.Txt_Telefono.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Telefono, True)
        Me.Txt_Telefono.Location = New System.Drawing.Point(120, 153)
        Me.Txt_Telefono.Name = "Txt_Telefono"
        Me.Txt_Telefono.Size = New System.Drawing.Size(170, 22)
        Me.Txt_Telefono.TabIndex = 6
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 323)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(649, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 117
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(13, 209)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelX6.Size = New System.Drawing.Size(101, 23)
        Me.LabelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX6.TabIndex = 118
        Me.LabelX6.Text = "Codigo Externo:"
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(12, 68)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelX7.Size = New System.Drawing.Size(89, 23)
        Me.LabelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX7.TabIndex = 119
        Me.LabelX7.Text = "Direccion:"
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(12, 153)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelX10.Size = New System.Drawing.Size(89, 23)
        Me.LabelX10.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX10.TabIndex = 122
        Me.LabelX10.Text = "Telefono:"
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(334, 153)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelX11.Size = New System.Drawing.Size(51, 23)
        Me.LabelX11.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX11.TabIndex = 123
        Me.LabelX11.Text = "e-Mail"
        Me.LabelX11.TextAlignment = System.Drawing.StringAlignment.Far
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
        Me.Txt_Email.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Email, True)
        Me.Txt_Email.Location = New System.Drawing.Point(391, 153)
        Me.Txt_Email.Name = "Txt_Email"
        Me.Txt_Email.Size = New System.Drawing.Size(247, 22)
        Me.Txt_Email.TabIndex = 7
        '
        'Txt_EmailSup
        '
        Me.Txt_EmailSup.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_EmailSup.Border.Class = "TextBoxBorder"
        Me.Txt_EmailSup.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_EmailSup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_EmailSup.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_EmailSup.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_EmailSup.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_EmailSup, True)
        Me.Txt_EmailSup.Location = New System.Drawing.Point(391, 181)
        Me.Txt_EmailSup.Name = "Txt_EmailSup"
        Me.Txt_EmailSup.Size = New System.Drawing.Size(247, 22)
        Me.Txt_EmailSup.TabIndex = 9
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(273, 180)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelX12.Size = New System.Drawing.Size(112, 23)
        Me.LabelX12.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX12.TabIndex = 125
        Me.LabelX12.Text = "e-Mail Supervisor"
        Me.LabelX12.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
        Me.LabelX13.Location = New System.Drawing.Point(12, 180)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelX13.Size = New System.Drawing.Size(89, 23)
        Me.LabelX13.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX13.TabIndex = 127
        Me.LabelX13.Text = "Modalidad:"
        '
        'Txt_Cod_Ext
        '
        Me.Txt_Cod_Ext.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Cod_Ext.Border.Class = "TextBoxBorder"
        Me.Txt_Cod_Ext.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Cod_Ext.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Cod_Ext.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Cod_Ext.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Cod_Ext.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Cod_Ext, True)
        Me.Txt_Cod_Ext.Location = New System.Drawing.Point(120, 209)
        Me.Txt_Cod_Ext.Name = "Txt_Cod_Ext"
        Me.Txt_Cod_Ext.Size = New System.Drawing.Size(261, 22)
        Me.Txt_Cod_Ext.TabIndex = 10
        '
        'Txt_Comuna
        '
        Me.Txt_Comuna.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Comuna.Border.Class = "TextBoxBorder"
        Me.Txt_Comuna.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Comuna.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Comuna.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Comuna.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Comuna, True)
        Me.Txt_Comuna.Location = New System.Drawing.Point(157, 97)
        Me.Txt_Comuna.MaxLength = 200
        Me.Txt_Comuna.Name = "Txt_Comuna"
        Me.Txt_Comuna.PreventEnterBeep = True
        Me.Txt_Comuna.ReadOnly = True
        Me.Txt_Comuna.Size = New System.Drawing.Size(375, 22)
        Me.Txt_Comuna.TabIndex = 4
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
        Me.LabelX24.Location = New System.Drawing.Point(12, 97)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(139, 19)
        Me.LabelX24.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX24.TabIndex = 150
        Me.LabelX24.Text = "Comuna, ciudad y pais"
        '
        'Btn_Buscar_Comuna
        '
        Me.Btn_Buscar_Comuna.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_Comuna.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_Comuna.Location = New System.Drawing.Point(541, 97)
        Me.Btn_Buscar_Comuna.Name = "Btn_Buscar_Comuna"
        Me.Btn_Buscar_Comuna.Size = New System.Drawing.Size(97, 22)
        Me.Btn_Buscar_Comuna.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_Comuna.TabIndex = 5
        Me.Btn_Buscar_Comuna.Text = "Buscar comuna..."
        '
        'Txt_Password
        '
        Me.Txt_Password.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Password.Border.Class = "TextBoxBorder"
        Me.Txt_Password.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Password.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Password.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Password.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Password.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Password, True)
        Me.Txt_Password.Location = New System.Drawing.Point(120, 237)
        Me.Txt_Password.Name = "Txt_Password"
        Me.Txt_Password.Size = New System.Drawing.Size(170, 22)
        Me.Txt_Password.TabIndex = 11
        '
        'Lbl_111
        '
        Me.Lbl_111.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_111.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_111.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_111.ForeColor = System.Drawing.Color.Black
        Me.Lbl_111.Location = New System.Drawing.Point(13, 237)
        Me.Lbl_111.Name = "Lbl_111"
        Me.Lbl_111.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Lbl_111.Size = New System.Drawing.Size(101, 23)
        Me.Lbl_111.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_111.TabIndex = 152
        Me.Lbl_111.Text = "Password:"
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Green
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'Txt_Modalidad
        '
        Me.Txt_Modalidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Modalidad.Border.Class = "TextBoxBorder"
        Me.Txt_Modalidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Modalidad.ButtonCustom.Image = CType(resources.GetObject("Txt_Modalidad.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Modalidad.ButtonCustom.Visible = True
        Me.Txt_Modalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Modalidad.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Modalidad.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt_Modalidad.ForeColor = System.Drawing.Color.Black
        Me.Highlighter1.SetHighlightOnFocus(Me.Txt_Modalidad, True)
        Me.Txt_Modalidad.Location = New System.Drawing.Point(120, 181)
        Me.Txt_Modalidad.Name = "Txt_Modalidad"
        Me.Txt_Modalidad.ReadOnly = True
        Me.Txt_Modalidad.Size = New System.Drawing.Size(101, 22)
        Me.Txt_Modalidad.TabIndex = 8
        '
        'Chk_Parafirma
        '
        Me.Chk_Parafirma.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Parafirma.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Parafirma.CheckBoxImageChecked = CType(resources.GetObject("Chk_Parafirma.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Parafirma.FocusCuesEnabled = False
        Me.Chk_Parafirma.ForeColor = System.Drawing.Color.Black
        Me.Chk_Parafirma.Location = New System.Drawing.Point(12, 275)
        Me.Chk_Parafirma.Name = "Chk_Parafirma"
        Me.Chk_Parafirma.Size = New System.Drawing.Size(139, 15)
        Me.Chk_Parafirma.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Parafirma.TabIndex = 12
        Me.Chk_Parafirma.TabStop = False
        Me.Chk_Parafirma.Text = "Desactivame para firma"
        '
        'Chk_Inactivo
        '
        Me.Chk_Inactivo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Inactivo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Inactivo.CheckBoxImageChecked = CType(resources.GetObject("Chk_Inactivo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Inactivo.FocusCuesEnabled = False
        Me.Chk_Inactivo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Inactivo.Location = New System.Drawing.Point(12, 296)
        Me.Chk_Inactivo.Name = "Chk_Inactivo"
        Me.Chk_Inactivo.Size = New System.Drawing.Size(124, 21)
        Me.Chk_Inactivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Inactivo.TabIndex = 13
        Me.Chk_Inactivo.TabStop = False
        Me.Chk_Inactivo.Text = "Bloquear funcionario"
        '
        'Frm_Usuarios_Random_Ficha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 364)
        Me.Controls.Add(Me.Chk_Inactivo)
        Me.Controls.Add(Me.Chk_Parafirma)
        Me.Controls.Add(Me.Txt_Modalidad)
        Me.Controls.Add(Me.Txt_Password)
        Me.Controls.Add(Me.Lbl_111)
        Me.Controls.Add(Me.Txt_Comuna)
        Me.Controls.Add(Me.LabelX24)
        Me.Controls.Add(Me.Btn_Buscar_Comuna)
        Me.Controls.Add(Me.Txt_Cod_Ext)
        Me.Controls.Add(Me.LabelX13)
        Me.Controls.Add(Me.Txt_EmailSup)
        Me.Controls.Add(Me.LabelX12)
        Me.Controls.Add(Me.Txt_Email)
        Me.Controls.Add(Me.LabelX11)
        Me.Controls.Add(Me.LabelX10)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Txt_Codigo)
        Me.Controls.Add(Me.Txt_Rut)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Txt_Direccion)
        Me.Controls.Add(Me.Txt_Telefono)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.Txt_Nombre)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Usuarios_Random_Ficha"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ficha usuario"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Codigo As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Rut As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Public WithEvents TextBoxX4 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Public WithEvents TextBoxX2 As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_Nombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Telefono As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Txt_Direccion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Public WithEvents Txt_Email As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Txt_EmailSup As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Cod_Ext As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Comuna As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Buscar_Comuna As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Password As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Lbl_111 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents Txt_Modalidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Chk_Parafirma As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Inactivo As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
