<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cashdro_Forma_de_Pago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cashdro_Forma_de_Pago))
        Me.Lbl_Documento = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Total_A_Pagar = New DevComponents.DotNetBar.LabelX()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Efectivo = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Tarjeta = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Nota_De_Credito = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Efectivo_Tarjeta = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Cancelar_Operacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Seleccion_Pago = New DevComponents.DotNetBar.LabelX()
        Me.Tiempo_Espera = New System.Windows.Forms.Timer(Me.components)
        Me.Lbl_Abonado_Con_NCV = New DevComponents.DotNetBar.LabelX()
        Me.Txt = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_Nro_Documento = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Total_Documento = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Abonado_Con_Nota_De_Credito = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Saldo_A_Pagar = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lbl_Documento
        '
        Me.Lbl_Documento.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Documento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Documento.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Documento.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Documento.Location = New System.Drawing.Point(1134, 151)
        Me.Lbl_Documento.Name = "Lbl_Documento"
        Me.Lbl_Documento.Size = New System.Drawing.Size(351, 45)
        Me.Lbl_Documento.TabIndex = 0
        Me.Lbl_Documento.Text = "<b><font color=""#ED1C24"">DOCUMENTO</font></b>  <b>9999999999</b>"
        '
        'Lbl_Total_A_Pagar
        '
        Me.Lbl_Total_A_Pagar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Total_A_Pagar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Total_A_Pagar.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Total_A_Pagar.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Total_A_Pagar.Location = New System.Drawing.Point(1165, 366)
        Me.Lbl_Total_A_Pagar.Name = "Lbl_Total_A_Pagar"
        Me.Lbl_Total_A_Pagar.Size = New System.Drawing.Size(524, 49)
        Me.Lbl_Total_A_Pagar.TabIndex = 1
        Me.Lbl_Total_A_Pagar.Text = "<b><font color=""#ED1C24"">TOTAL A PAGAR</font></b>  <b>$ 999.999.999</b>"
        '
        'MetroTilePanel1
        '
        Me.MetroTilePanel1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.MetroTilePanel1.BackgroundStyle.Class = "MetroTilePanel"
        Me.MetroTilePanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTilePanel1.ContainerControlProcessDialogKey = True
        Me.MetroTilePanel1.DragDropSupport = True
        Me.MetroTilePanel1.ForeColor = System.Drawing.Color.Black
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(12, 282)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(1160, 355)
        Me.MetroTilePanel1.TabIndex = 30
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.FixedSize = New System.Drawing.Size(1050, 300)
        Me.ItemContainer1.MultiLine = True
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Efectivo, Me.Btn_Tarjeta, Me.Btn_Nota_De_Credito, Me.Btn_Efectivo_Tarjeta})
        '
        '
        '
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.TitleStyle.Font = New System.Drawing.Font("Comic Sans MS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemContainer1.TitleStyle.TextColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(66, Byte), Integer))
        '
        'Btn_Efectivo
        '
        Me.Btn_Efectivo.Image = CType(resources.GetObject("Btn_Efectivo.Image"), System.Drawing.Image)
        Me.Btn_Efectivo.ImageIndent = New System.Drawing.Point(9, -10)
        Me.Btn_Efectivo.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Efectivo.Name = "Btn_Efectivo"
        Me.Btn_Efectivo.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Efectivo.Text = "<font size=""50""><b>EFECTIVO</b></font><br/>"
        Me.Btn_Efectivo.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Efectivo.TileSize = New System.Drawing.Size(520, 120)
        '
        '
        '
        Me.Btn_Efectivo.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Efectivo.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Efectivo.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Efectivo.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.Btn_Efectivo.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Efectivo.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        '
        'Btn_Tarjeta
        '
        Me.Btn_Tarjeta.Image = CType(resources.GetObject("Btn_Tarjeta.Image"), System.Drawing.Image)
        Me.Btn_Tarjeta.ImageIndent = New System.Drawing.Point(9, -10)
        Me.Btn_Tarjeta.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Tarjeta.Name = "Btn_Tarjeta"
        Me.Btn_Tarjeta.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Tarjeta.Text = "<font size=""50""><b>TARJETA</b></font><br/>"
        Me.Btn_Tarjeta.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Olive
        Me.Btn_Tarjeta.TileSize = New System.Drawing.Size(520, 120)
        '
        '
        '
        Me.Btn_Tarjeta.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Tarjeta.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Tarjeta.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Tarjeta.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Btn_Tarjeta.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Tarjeta.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Btn_Tarjeta.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Btn_Nota_De_Credito
        '
        Me.Btn_Nota_De_Credito.Image = CType(resources.GetObject("Btn_Nota_De_Credito.Image"), System.Drawing.Image)
        Me.Btn_Nota_De_Credito.ImageIndent = New System.Drawing.Point(9, -10)
        Me.Btn_Nota_De_Credito.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Nota_De_Credito.Name = "Btn_Nota_De_Credito"
        Me.Btn_Nota_De_Credito.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Nota_De_Credito.Text = "<font size=""36""><b>NOTA DE CREDITO</b></font><br/>"
        Me.Btn_Nota_De_Credito.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange
        Me.Btn_Nota_De_Credito.TileSize = New System.Drawing.Size(520, 120)
        '
        '
        '
        Me.Btn_Nota_De_Credito.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Nota_De_Credito.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Nota_De_Credito.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Nota_De_Credito.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Btn_Nota_De_Credito.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Nota_De_Credito.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        '
        'Btn_Efectivo_Tarjeta
        '
        Me.Btn_Efectivo_Tarjeta.Image = CType(resources.GetObject("Btn_Efectivo_Tarjeta.Image"), System.Drawing.Image)
        Me.Btn_Efectivo_Tarjeta.ImageIndent = New System.Drawing.Point(9, -10)
        Me.Btn_Efectivo_Tarjeta.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Efectivo_Tarjeta.Name = "Btn_Efectivo_Tarjeta"
        Me.Btn_Efectivo_Tarjeta.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Efectivo_Tarjeta.Text = "<font size=""34""><b>EFECTIVO/TARJETA</b></font>"
        Me.Btn_Efectivo_Tarjeta.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Olive
        Me.Btn_Efectivo_Tarjeta.TileSize = New System.Drawing.Size(520, 120)
        '
        '
        '
        Me.Btn_Efectivo_Tarjeta.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Efectivo_Tarjeta.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Efectivo_Tarjeta.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Efectivo_Tarjeta.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.Btn_Efectivo_Tarjeta.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Efectivo_Tarjeta.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Btn_Efectivo_Tarjeta.TileStyle.TextColor = System.Drawing.Color.White
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Cancelar_Operacion})
        Me.Bar2.Location = New System.Drawing.Point(0, 566)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(1094, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 31
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Cancelar_Operacion
        '
        Me.Btn_Cancelar_Operacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar_Operacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar_Operacion.Image = CType(resources.GetObject("Btn_Cancelar_Operacion.Image"), System.Drawing.Image)
        Me.Btn_Cancelar_Operacion.Name = "Btn_Cancelar_Operacion"
        Me.Btn_Cancelar_Operacion.Text = "CANCELAR"
        '
        'Lbl_Seleccion_Pago
        '
        Me.Lbl_Seleccion_Pago.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Seleccion_Pago.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Seleccion_Pago.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Seleccion_Pago.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Seleccion_Pago.Location = New System.Drawing.Point(279, 216)
        Me.Lbl_Seleccion_Pago.Name = "Lbl_Seleccion_Pago"
        Me.Lbl_Seleccion_Pago.Size = New System.Drawing.Size(580, 51)
        Me.Lbl_Seleccion_Pago.TabIndex = 32
        Me.Lbl_Seleccion_Pago.Text = "<b><font size = ""26"" color=""#349FCE"">SELECCIONE SU OPCION DE PAGO</font></b>  "
        '
        'Tiempo_Espera
        '
        Me.Tiempo_Espera.Interval = 1000
        '
        'Lbl_Abonado_Con_NCV
        '
        Me.Lbl_Abonado_Con_NCV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Abonado_Con_NCV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Abonado_Con_NCV.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Abonado_Con_NCV.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Abonado_Con_NCV.Location = New System.Drawing.Point(1165, 270)
        Me.Lbl_Abonado_Con_NCV.Name = "Lbl_Abonado_Con_NCV"
        Me.Lbl_Abonado_Con_NCV.Size = New System.Drawing.Size(524, 36)
        Me.Lbl_Abonado_Con_NCV.TabIndex = 33
        Me.Lbl_Abonado_Con_NCV.Text = "Abonado con Nota de crédito: $ 99.999.999"
        Me.Lbl_Abonado_Con_NCV.Visible = False
        '
        'Txt
        '
        Me.Txt.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt.Border.Class = "TextBoxBorder"
        Me.Txt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt.DisabledBackColor = System.Drawing.Color.White
        Me.Txt.ForeColor = System.Drawing.Color.Black
        Me.Txt.Location = New System.Drawing.Point(1153, 312)
        Me.Txt.Name = "Txt"
        Me.Txt.PreventEnterBeep = True
        Me.Txt.Size = New System.Drawing.Size(100, 22)
        Me.Txt.TabIndex = 34
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.56097!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.43903!))
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Nro_Documento, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Total_Documento, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX5, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Abonado_Con_Nota_De_Credito, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Saldo_A_Pagar, 1, 3)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(180, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(749, 185)
        Me.TableLayoutPanel1.TabIndex = 35
        '
        'Lbl_Nro_Documento
        '
        '
        '
        '
        Me.Lbl_Nro_Documento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nro_Documento.Font = New System.Drawing.Font("Courier New", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Nro_Documento.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nro_Documento.Location = New System.Drawing.Point(434, 4)
        Me.Lbl_Nro_Documento.Name = "Lbl_Nro_Documento"
        Me.Lbl_Nro_Documento.Size = New System.Drawing.Size(311, 38)
        Me.Lbl_Nro_Documento.TabIndex = 37
        Me.Lbl_Nro_Documento.Text = "9999999999"
        Me.Lbl_Nro_Documento.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(4, 4)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(308, 38)
        Me.LabelX4.TabIndex = 39
        Me.LabelX4.Text = "Número de documento"
        '
        'Lbl_Total_Documento
        '
        '
        '
        '
        Me.Lbl_Total_Documento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Total_Documento.Font = New System.Drawing.Font("Courier New", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Total_Documento.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Total_Documento.Location = New System.Drawing.Point(434, 50)
        Me.Lbl_Total_Documento.Name = "Lbl_Total_Documento"
        Me.Lbl_Total_Documento.Size = New System.Drawing.Size(311, 38)
        Me.Lbl_Total_Documento.TabIndex = 36
        Me.Lbl_Total_Documento.Text = "$ 99.999.999"
        Me.Lbl_Total_Documento.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(4, 50)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(308, 38)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Total documento"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(4, 96)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(423, 38)
        Me.LabelX5.TabIndex = 36
        Me.LabelX5.Text = "Abonado con Nota de crédito"
        '
        'Lbl_Abonado_Con_Nota_De_Credito
        '
        '
        '
        '
        Me.Lbl_Abonado_Con_Nota_De_Credito.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Abonado_Con_Nota_De_Credito.Font = New System.Drawing.Font("Courier New", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Abonado_Con_Nota_De_Credito.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Abonado_Con_Nota_De_Credito.Location = New System.Drawing.Point(434, 96)
        Me.Lbl_Abonado_Con_Nota_De_Credito.Name = "Lbl_Abonado_Con_Nota_De_Credito"
        Me.Lbl_Abonado_Con_Nota_De_Credito.Size = New System.Drawing.Size(311, 38)
        Me.Lbl_Abonado_Con_Nota_De_Credito.TabIndex = 37
        Me.Lbl_Abonado_Con_Nota_De_Credito.Text = "$ 99.999.999"
        Me.Lbl_Abonado_Con_Nota_De_Credito.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(4, 142)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(300, 39)
        Me.LabelX3.TabIndex = 36
        Me.LabelX3.Text = "Saldo a pagar"
        '
        'Lbl_Saldo_A_Pagar
        '
        '
        '
        '
        Me.Lbl_Saldo_A_Pagar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Saldo_A_Pagar.Font = New System.Drawing.Font("Courier New", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Saldo_A_Pagar.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Saldo_A_Pagar.Location = New System.Drawing.Point(434, 142)
        Me.Lbl_Saldo_A_Pagar.Name = "Lbl_Saldo_A_Pagar"
        Me.Lbl_Saldo_A_Pagar.Size = New System.Drawing.Size(311, 39)
        Me.Lbl_Saldo_A_Pagar.TabIndex = 38
        Me.Lbl_Saldo_A_Pagar.Text = "$ 99.999.999"
        Me.Lbl_Saldo_A_Pagar.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Frm_Cashdro_Forma_de_Pago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1094, 607)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Txt)
        Me.Controls.Add(Me.Lbl_Abonado_Con_NCV)
        Me.Controls.Add(Me.Lbl_Seleccion_Pago)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Controls.Add(Me.Lbl_Total_A_Pagar)
        Me.Controls.Add(Me.Lbl_Documento)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cashdro_Forma_de_Pago"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FORMA DE PAGO"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lbl_Documento As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Total_A_Pagar As DevComponents.DotNetBar.LabelX
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Efectivo As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Tarjeta As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Nota_De_Credito As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Cancelar_Operacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Seleccion_Pago As DevComponents.DotNetBar.LabelX
    Friend WithEvents Tiempo_Espera As System.Windows.Forms.Timer
    Friend WithEvents Lbl_Abonado_Con_NCV As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Saldo_A_Pagar As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Abonado_Con_Nota_De_Credito As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Total_Documento As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Nro_Documento As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Private WithEvents Btn_Efectivo_Tarjeta As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
End Class
