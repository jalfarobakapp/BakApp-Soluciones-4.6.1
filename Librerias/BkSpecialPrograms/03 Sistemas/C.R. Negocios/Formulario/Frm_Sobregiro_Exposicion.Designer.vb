<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Sobregiro_Exposicion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Sobregiro_Exposicion))
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Lbl_Sobregiro = New DevComponents.DotNetBar.LabelX
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Lbl_Saldo_Linea_Dolar = New DevComponents.DotNetBar.LabelX
        Me.Lbl_Saldo_Linea_Uf = New DevComponents.DotNetBar.LabelX
        Me.Lbl_Saldo_Linea_Peso = New DevComponents.DotNetBar.LabelX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.Reflex_Img_Sobregiro = New DevComponents.DotNetBar.Controls.ReflectionImage
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.Lbl_Exposicion = New DevComponents.DotNetBar.LabelX
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX
        Me.Lbl_Porc_Exposicion = New DevComponents.DotNetBar.LabelX
        Me.Lbl_Exposicion_01 = New DevComponents.DotNetBar.LabelX
        Me.Lbl_Valor_Exposicion_02 = New DevComponents.DotNetBar.LabelX
        Me.Lbl_Exposicion_02 = New DevComponents.DotNetBar.LabelX
        Me.Lbl_Valor_Exposicion_01 = New DevComponents.DotNetBar.LabelX
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX
        Me.Reflex_Img_Exposicion = New DevComponents.DotNetBar.Controls.ReflectionImage
        Me.Imagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.Lbl_Exposicion_Dolar = New DevComponents.DotNetBar.LabelX
        Me.Lbl_Valor_Dolar = New DevComponents.DotNetBar.LabelX
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnCancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 376)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(350, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 114
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancelar.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Tooltip = "Cancelar"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Lbl_Sobregiro)
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel1.Controls.Add(Me.Reflex_Img_Sobregiro)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(328, 134)
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
        Me.GroupPanel1.TabIndex = 115
        Me.GroupPanel1.Text = "SOBREGIRO"
        '
        'Lbl_Sobregiro
        '
        Me.Lbl_Sobregiro.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Sobregiro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Sobregiro.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Sobregiro.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Sobregiro.Location = New System.Drawing.Point(3, 86)
        Me.Lbl_Sobregiro.Name = "Lbl_Sobregiro"
        Me.Lbl_Sobregiro.Size = New System.Drawing.Size(257, 23)
        Me.Lbl_Sobregiro.TabIndex = 2
        Me.Lbl_Sobregiro.Text = "LabelX4"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.05512!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.94488!))
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Saldo_Linea_Dolar, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Saldo_Linea_Uf, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Saldo_Linea_Peso, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(254, 68)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Lbl_Saldo_Linea_Dolar
        '
        '
        '
        '
        Me.Lbl_Saldo_Linea_Dolar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Saldo_Linea_Dolar.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Saldo_Linea_Dolar.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Saldo_Linea_Dolar.Location = New System.Drawing.Point(153, 50)
        Me.Lbl_Saldo_Linea_Dolar.Name = "Lbl_Saldo_Linea_Dolar"
        Me.Lbl_Saldo_Linea_Dolar.Size = New System.Drawing.Size(97, 13)
        Me.Lbl_Saldo_Linea_Dolar.TabIndex = 5
        Me.Lbl_Saldo_Linea_Dolar.Text = "999.999.999"
        Me.Lbl_Saldo_Linea_Dolar.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Lbl_Saldo_Linea_Uf
        '
        '
        '
        '
        Me.Lbl_Saldo_Linea_Uf.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Saldo_Linea_Uf.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Saldo_Linea_Uf.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Saldo_Linea_Uf.Location = New System.Drawing.Point(153, 27)
        Me.Lbl_Saldo_Linea_Uf.Name = "Lbl_Saldo_Linea_Uf"
        Me.Lbl_Saldo_Linea_Uf.Size = New System.Drawing.Size(97, 13)
        Me.Lbl_Saldo_Linea_Uf.TabIndex = 4
        Me.Lbl_Saldo_Linea_Uf.Text = "999.999.999"
        Me.Lbl_Saldo_Linea_Uf.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Lbl_Saldo_Linea_Peso
        '
        '
        '
        '
        Me.Lbl_Saldo_Linea_Peso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Saldo_Linea_Peso.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Saldo_Linea_Peso.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Saldo_Linea_Peso.Location = New System.Drawing.Point(153, 4)
        Me.Lbl_Saldo_Linea_Peso.Name = "Lbl_Saldo_Linea_Peso"
        Me.Lbl_Saldo_Linea_Peso.Size = New System.Drawing.Size(97, 13)
        Me.Lbl_Saldo_Linea_Peso.TabIndex = 3
        Me.Lbl_Saldo_Linea_Peso.Text = "999.999.999"
        Me.Lbl_Saldo_Linea_Peso.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(4, 50)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(142, 14)
        Me.LabelX3.TabIndex = 3
        Me.LabelX3.Text = "Total US$"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(4, 27)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(142, 13)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Total UF"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(4, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(142, 13)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Total $ "
        '
        'Reflex_Img_Sobregiro
        '
        Me.Reflex_Img_Sobregiro.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Reflex_Img_Sobregiro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Reflex_Img_Sobregiro.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Reflex_Img_Sobregiro.ForeColor = System.Drawing.Color.Black
        Me.Reflex_Img_Sobregiro.Image = CType(resources.GetObject("Reflex_Img_Sobregiro.Image"), System.Drawing.Image)
        Me.Reflex_Img_Sobregiro.Location = New System.Drawing.Point(270, 3)
        Me.Reflex_Img_Sobregiro.Name = "Reflex_Img_Sobregiro"
        Me.Reflex_Img_Sobregiro.Size = New System.Drawing.Size(49, 77)
        Me.Reflex_Img_Sobregiro.TabIndex = 0
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupPanel2.Controls.Add(Me.Reflex_Img_Exposicion)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 152)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(328, 182)
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
        Me.GroupPanel2.TabIndex = 116
        Me.GroupPanel2.Text = "EXPOSICION"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.05512!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.94488!))
        Me.TableLayoutPanel3.Controls.Add(Me.Lbl_Exposicion_Dolar, 1, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.LabelX4, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Lbl_Exposicion, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.LabelX10, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Lbl_Porc_Exposicion, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Lbl_Exposicion_01, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Lbl_Valor_Exposicion_02, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Lbl_Exposicion_02, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Lbl_Valor_Exposicion_01, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.LabelX7, 0, 2)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(6, 15)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 5
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(254, 138)
        Me.TableLayoutPanel3.TabIndex = 117
        '
        'Lbl_Exposicion
        '
        '
        '
        '
        Me.Lbl_Exposicion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Exposicion.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Exposicion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Exposicion.Location = New System.Drawing.Point(153, 85)
        Me.Lbl_Exposicion.Name = "Lbl_Exposicion"
        Me.Lbl_Exposicion.Size = New System.Drawing.Size(97, 20)
        Me.Lbl_Exposicion.TabIndex = 6
        Me.Lbl_Exposicion.Text = "999.999.999"
        Me.Lbl_Exposicion.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(4, 85)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(142, 20)
        Me.LabelX10.TabIndex = 4
        Me.LabelX10.Text = "Exposición (pesos)"
        '
        'Lbl_Porc_Exposicion
        '
        '
        '
        '
        Me.Lbl_Porc_Exposicion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Porc_Exposicion.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Porc_Exposicion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Porc_Exposicion.Location = New System.Drawing.Point(153, 58)
        Me.Lbl_Porc_Exposicion.Name = "Lbl_Porc_Exposicion"
        Me.Lbl_Porc_Exposicion.Size = New System.Drawing.Size(97, 20)
        Me.Lbl_Porc_Exposicion.TabIndex = 5
        Me.Lbl_Porc_Exposicion.Text = "10 %"
        Me.Lbl_Porc_Exposicion.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Lbl_Exposicion_01
        '
        '
        '
        '
        Me.Lbl_Exposicion_01.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Exposicion_01.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Exposicion_01.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Exposicion_01.Location = New System.Drawing.Point(4, 4)
        Me.Lbl_Exposicion_01.Name = "Lbl_Exposicion_01"
        Me.Lbl_Exposicion_01.Size = New System.Drawing.Size(142, 20)
        Me.Lbl_Exposicion_01.TabIndex = 2
        Me.Lbl_Exposicion_01.Text = "Deuda actual"
        '
        'Lbl_Valor_Exposicion_02
        '
        '
        '
        '
        Me.Lbl_Valor_Exposicion_02.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Valor_Exposicion_02.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Valor_Exposicion_02.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Valor_Exposicion_02.Location = New System.Drawing.Point(153, 31)
        Me.Lbl_Valor_Exposicion_02.Name = "Lbl_Valor_Exposicion_02"
        Me.Lbl_Valor_Exposicion_02.Size = New System.Drawing.Size(97, 20)
        Me.Lbl_Valor_Exposicion_02.TabIndex = 4
        Me.Lbl_Valor_Exposicion_02.Text = "999.999.999"
        Me.Lbl_Valor_Exposicion_02.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Lbl_Exposicion_02
        '
        '
        '
        '
        Me.Lbl_Exposicion_02.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Exposicion_02.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Exposicion_02.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Exposicion_02.Location = New System.Drawing.Point(4, 31)
        Me.Lbl_Exposicion_02.Name = "Lbl_Exposicion_02"
        Me.Lbl_Exposicion_02.Size = New System.Drawing.Size(142, 20)
        Me.Lbl_Exposicion_02.TabIndex = 3
        Me.Lbl_Exposicion_02.Text = "Venta"
        '
        'Lbl_Valor_Exposicion_01
        '
        '
        '
        '
        Me.Lbl_Valor_Exposicion_01.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Valor_Exposicion_01.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Valor_Exposicion_01.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Valor_Exposicion_01.Location = New System.Drawing.Point(153, 4)
        Me.Lbl_Valor_Exposicion_01.Name = "Lbl_Valor_Exposicion_01"
        Me.Lbl_Valor_Exposicion_01.Size = New System.Drawing.Size(97, 20)
        Me.Lbl_Valor_Exposicion_01.TabIndex = 3
        Me.Lbl_Valor_Exposicion_01.Text = "999.999.999"
        Me.Lbl_Valor_Exposicion_01.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(4, 58)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(142, 20)
        Me.LabelX7.TabIndex = 3
        Me.LabelX7.Text = "% No cubierto"
        '
        'Reflex_Img_Exposicion
        '
        Me.Reflex_Img_Exposicion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Reflex_Img_Exposicion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Reflex_Img_Exposicion.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Reflex_Img_Exposicion.ForeColor = System.Drawing.Color.Black
        Me.Reflex_Img_Exposicion.Image = CType(resources.GetObject("Reflex_Img_Exposicion.Image"), System.Drawing.Image)
        Me.Reflex_Img_Exposicion.Location = New System.Drawing.Point(259, 15)
        Me.Reflex_Img_Exposicion.Name = "Reflex_Img_Exposicion"
        Me.Reflex_Img_Exposicion.Size = New System.Drawing.Size(60, 59)
        Me.Reflex_Img_Exposicion.TabIndex = 1
        '
        'Imagenes
        '
        Me.Imagenes.ImageStream = CType(resources.GetObject("Imagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes.Images.SetKeyName(0, "warning.png")
        Me.Imagenes.Images.SetKeyName(1, "secure_ok.png")
        Me.Imagenes.Images.SetKeyName(2, "secure_err.png")
        Me.Imagenes.Images.SetKeyName(3, "secure-info.png")
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(4, 112)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(142, 20)
        Me.LabelX4.TabIndex = 118
        Me.LabelX4.Text = "Exposición (dolar)"
        '
        'Lbl_Exposicion_Dolar
        '
        '
        '
        '
        Me.Lbl_Exposicion_Dolar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Exposicion_Dolar.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Exposicion_Dolar.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Exposicion_Dolar.Location = New System.Drawing.Point(153, 112)
        Me.Lbl_Exposicion_Dolar.Name = "Lbl_Exposicion_Dolar"
        Me.Lbl_Exposicion_Dolar.Size = New System.Drawing.Size(97, 20)
        Me.Lbl_Exposicion_Dolar.TabIndex = 118
        Me.Lbl_Exposicion_Dolar.Text = "999.999.999"
        Me.Lbl_Exposicion_Dolar.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Lbl_Valor_Dolar
        '
        '
        '
        '
        Me.Lbl_Valor_Dolar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Valor_Dolar.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Valor_Dolar.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Valor_Dolar.Location = New System.Drawing.Point(12, 349)
        Me.Lbl_Valor_Dolar.Name = "Lbl_Valor_Dolar"
        Me.Lbl_Valor_Dolar.Size = New System.Drawing.Size(142, 20)
        Me.Lbl_Valor_Dolar.TabIndex = 119
        Me.Lbl_Valor_Dolar.Text = "Valor dolar: $ 99.999"
        '
        'Frm_Sobregiro_Exposicion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 417)
        Me.ControlBox = False
        Me.Controls.Add(Me.Lbl_Valor_Dolar)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Sobregiro_Exposicion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INFORMACIÓN ADICIONAL"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Reflex_Img_Sobregiro As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Reflex_Img_Exposicion As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Imagenes As System.Windows.Forms.ImageList
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Saldo_Linea_Dolar As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Saldo_Linea_Uf As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Saldo_Linea_Peso As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Sobregiro As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Porc_Exposicion As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Valor_Exposicion_01 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Valor_Exposicion_02 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Exposicion As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Exposicion_02 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Exposicion_01 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Exposicion_Dolar As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Valor_Dolar As DevComponents.DotNetBar.LabelX
End Class
