<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_02_Detalle_Producto_Actual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_02_Detalle_Producto_Actual))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnEstadisticas = New DevComponents.DotNetBar.ButtonItem
        Me.BtnAgregarConteo = New DevComponents.DotNetBar.ButtonItem
        Me.BtnGrabarAnalisis_Reconteo = New DevComponents.DotNetBar.ButtonItem
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GrillaHistoriaProducto = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.LblContador1 = New DevComponents.DotNetBar.LabelX
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.LblActualizadoPor = New DevComponents.DotNetBar.LabelX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.LblDigitador = New DevComponents.DotNetBar.LabelX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX
        Me.LblContador2 = New DevComponents.DotNetBar.LabelX
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.LblObsActualizacion = New DevComponents.DotNetBar.LabelX
        Me.LblObservaciones = New DevComponents.DotNetBar.LabelX
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.LblTotalFotoStock = New DevComponents.DotNetBar.LabelX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.LblTotalInventariado = New DevComponents.DotNetBar.LabelX
        Me.LblTotalDiferencia = New DevComponents.DotNetBar.LabelX
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX
        Me.ChkRecontado = New System.Windows.Forms.CheckBox
        Me.ChkCerrado = New System.Windows.Forms.CheckBox
        Me.ChkLevantado = New System.Windows.Forms.CheckBox
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GrillaHistoriaProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnEstadisticas, Me.BtnAgregarConteo, Me.BtnGrabarAnalisis_Reconteo, Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 470)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(718, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 33
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnEstadisticas
        '
        Me.BtnEstadisticas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnEstadisticas.ForeColor = System.Drawing.Color.Black
        Me.BtnEstadisticas.Image = CType(resources.GetObject("BtnEstadisticas.Image"), System.Drawing.Image)
        Me.BtnEstadisticas.Name = "BtnEstadisticas"
        Me.BtnEstadisticas.Tooltip = "Ultimos movimientos (Compra, Ventas, Estadisticas)"
        '
        'BtnAgregarConteo
        '
        Me.BtnAgregarConteo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAgregarConteo.ForeColor = System.Drawing.Color.Black
        Me.BtnAgregarConteo.Image = CType(resources.GetObject("BtnAgregarConteo.Image"), System.Drawing.Image)
        Me.BtnAgregarConteo.Name = "BtnAgregarConteo"
        Me.BtnAgregarConteo.Text = "Agregar conteo"
        '
        'BtnGrabarAnalisis_Reconteo
        '
        Me.BtnGrabarAnalisis_Reconteo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabarAnalisis_Reconteo.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabarAnalisis_Reconteo.Image = CType(resources.GetObject("BtnGrabarAnalisis_Reconteo.Image"), System.Drawing.Image)
        Me.BtnGrabarAnalisis_Reconteo.Name = "BtnGrabarAnalisis_Reconteo"
        Me.BtnGrabarAnalisis_Reconteo.Text = "Grabar analisis, reconteo"
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.GrillaHistoriaProducto)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(695, 149)
        Me.GroupBox1.TabIndex = 45
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ubicaciones en las que se ha encontrado"
        '
        'GrillaHistoriaProducto
        '
        Me.GrillaHistoriaProducto.AllowUserToAddRows = False
        Me.GrillaHistoriaProducto.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaHistoriaProducto.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GrillaHistoriaProducto.BackgroundColor = System.Drawing.Color.White
        Me.GrillaHistoriaProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaHistoriaProducto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrillaHistoriaProducto.Location = New System.Drawing.Point(3, 18)
        Me.GrillaHistoriaProducto.Name = "GrillaHistoriaProducto"
        Me.GrillaHistoriaProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GrillaHistoriaProducto.Size = New System.Drawing.Size(689, 128)
        Me.GrillaHistoriaProducto.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(11, 198)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(695, 89)
        Me.GroupBox2.TabIndex = 47
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Contadores"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.44118!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.26471!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.42424!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.57576!))
        Me.TableLayoutPanel1.Controls.Add(Me.LblContador1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX5, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LblActualizadoPor, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LblDigitador, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX9, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LblContador2, 3, 1)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 21)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(683, 59)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'LblContador1
        '
        '
        '
        '
        Me.LblContador1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblContador1.ForeColor = System.Drawing.Color.Black
        Me.LblContador1.Location = New System.Drawing.Point(145, 34)
        Me.LblContador1.Name = "LblContador1"
        Me.LblContador1.Size = New System.Drawing.Size(190, 19)
        Me.LblContador1.TabIndex = 5
        Me.LblContador1.Text = "LabelX6"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(6, 34)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 19)
        Me.LabelX5.TabIndex = 4
        Me.LabelX5.Text = "Contador 1"
        '
        'LblActualizadoPor
        '
        '
        '
        '
        Me.LblActualizadoPor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblActualizadoPor.ForeColor = System.Drawing.Color.Black
        Me.LblActualizadoPor.Location = New System.Drawing.Point(463, 6)
        Me.LblActualizadoPor.Name = "LblActualizadoPor"
        Me.LblActualizadoPor.Size = New System.Drawing.Size(209, 18)
        Me.LblActualizadoPor.TabIndex = 3
        Me.LblActualizadoPor.Text = "LabelX4"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(344, 6)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(110, 18)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "Actualizador [Rec.]"
        '
        'LblDigitador
        '
        '
        '
        '
        Me.LblDigitador.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblDigitador.ForeColor = System.Drawing.Color.Black
        Me.LblDigitador.Location = New System.Drawing.Point(145, 6)
        Me.LblDigitador.Name = "LblDigitador"
        Me.LblDigitador.Size = New System.Drawing.Size(190, 18)
        Me.LblDigitador.TabIndex = 1
        Me.LblDigitador.Text = "LabelX2"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(6, 6)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(113, 19)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Responzable/Digitador"
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(344, 34)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(75, 19)
        Me.LabelX9.TabIndex = 8
        Me.LabelX9.Text = "Contador 2"
        '
        'LblContador2
        '
        '
        '
        '
        Me.LblContador2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblContador2.ForeColor = System.Drawing.Color.Black
        Me.LblContador2.Location = New System.Drawing.Point(463, 34)
        Me.LblContador2.Name = "LblContador2"
        Me.LblContador2.Size = New System.Drawing.Size(209, 19)
        Me.LblContador2.TabIndex = 9
        Me.LblContador2.Text = "LabelX10"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(11, 293)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(695, 95)
        Me.GroupBox3.TabIndex = 48
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Observaciones"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.14706!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.85294!))
        Me.TableLayoutPanel2.Controls.Add(Me.LblObsActualizacion, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.LblObservaciones, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX13, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelX8, 0, 1)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(6, 21)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(683, 64)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'LblObsActualizacion
        '
        '
        '
        '
        Me.LblObsActualizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblObsActualizacion.ForeColor = System.Drawing.Color.Black
        Me.LblObsActualizacion.Location = New System.Drawing.Point(144, 36)
        Me.LblObsActualizacion.Name = "LblObsActualizacion"
        Me.LblObsActualizacion.Size = New System.Drawing.Size(394, 22)
        Me.LblObsActualizacion.TabIndex = 5
        Me.LblObsActualizacion.Text = "LabelX6"
        '
        'LblObservaciones
        '
        '
        '
        '
        Me.LblObservaciones.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblObservaciones.ForeColor = System.Drawing.Color.Black
        Me.LblObservaciones.Location = New System.Drawing.Point(144, 6)
        Me.LblObservaciones.Name = "LblObservaciones"
        Me.LblObservaciones.Size = New System.Drawing.Size(394, 21)
        Me.LblObservaciones.TabIndex = 1
        Me.LblObservaciones.Text = "LabelX2"
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
        Me.LabelX13.Location = New System.Drawing.Point(6, 6)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(113, 21)
        Me.LabelX13.TabIndex = 0
        Me.LabelX13.Text = "Observaciones"
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(6, 36)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(129, 22)
        Me.LabelX8.TabIndex = 4
        Me.LabelX8.Text = "Obs. Actualización [Rec.]"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(11, 394)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(695, 70)
        Me.GroupBox4.TabIndex = 49
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Inventario"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble
        Me.TableLayoutPanel3.ColumnCount = 6
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.LblTotalFotoStock, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.LabelX4, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.LblTotalInventariado, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.LblTotalDiferencia, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.LabelX10, 4, 0)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(6, 21)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(683, 39)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(6, 6)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(78, 27)
        Me.LabelX2.TabIndex = 5
        Me.LabelX2.Text = "Stock Foto"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LblTotalFotoStock
        '
        '
        '
        '
        Me.LblTotalFotoStock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblTotalFotoStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalFotoStock.ForeColor = System.Drawing.Color.Black
        Me.LblTotalFotoStock.Location = New System.Drawing.Point(119, 6)
        Me.LblTotalFotoStock.Name = "LblTotalFotoStock"
        Me.LblTotalFotoStock.Size = New System.Drawing.Size(78, 27)
        Me.LblTotalFotoStock.TabIndex = 1
        Me.LblTotalFotoStock.Text = "LabelX2"
        Me.LblTotalFotoStock.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(232, 6)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(78, 27)
        Me.LabelX4.TabIndex = 6
        Me.LabelX4.Text = "Inventariado"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LblTotalInventariado
        '
        '
        '
        '
        Me.LblTotalInventariado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblTotalInventariado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalInventariado.ForeColor = System.Drawing.Color.Black
        Me.LblTotalInventariado.Location = New System.Drawing.Point(345, 6)
        Me.LblTotalInventariado.Name = "LblTotalInventariado"
        Me.LblTotalInventariado.Size = New System.Drawing.Size(78, 27)
        Me.LblTotalInventariado.TabIndex = 7
        Me.LblTotalInventariado.Text = "LabelX2"
        Me.LblTotalInventariado.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LblTotalDiferencia
        '
        '
        '
        '
        Me.LblTotalDiferencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblTotalDiferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalDiferencia.ForeColor = System.Drawing.Color.Black
        Me.LblTotalDiferencia.Location = New System.Drawing.Point(571, 6)
        Me.LblTotalDiferencia.Name = "LblTotalDiferencia"
        Me.LblTotalDiferencia.Size = New System.Drawing.Size(81, 27)
        Me.LblTotalDiferencia.TabIndex = 8
        Me.LblTotalDiferencia.Text = "LabelX2"
        Me.LblTotalDiferencia.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(458, 6)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(78, 27)
        Me.LabelX10.TabIndex = 9
        Me.LabelX10.Text = "Diferencia"
        Me.LabelX10.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox5.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble
        Me.TableLayoutPanel4.ColumnCount = 6
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX7, 0, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(6, 6)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(23, 27)
        Me.LabelX7.TabIndex = 5
        Me.LabelX7.Text = "Stock Foto"
        Me.LabelX7.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(119, 6)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(78, 27)
        Me.LabelX11.TabIndex = 1
        Me.LabelX11.Text = "LabelX2"
        Me.LabelX11.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'ChkRecontado
        '
        Me.ChkRecontado.AutoSize = True
        Me.ChkRecontado.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ChkRecontado.Enabled = False
        Me.ChkRecontado.ForeColor = System.Drawing.Color.Black
        Me.ChkRecontado.Location = New System.Drawing.Point(12, 20)
        Me.ChkRecontado.Name = "ChkRecontado"
        Me.ChkRecontado.Size = New System.Drawing.Size(82, 17)
        Me.ChkRecontado.TabIndex = 50
        Me.ChkRecontado.Text = "Recontado"
        Me.ChkRecontado.UseVisualStyleBackColor = False
        '
        'ChkCerrado
        '
        Me.ChkCerrado.AutoSize = True
        Me.ChkCerrado.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ChkCerrado.Enabled = False
        Me.ChkCerrado.ForeColor = System.Drawing.Color.Black
        Me.ChkCerrado.Location = New System.Drawing.Point(100, 20)
        Me.ChkCerrado.Name = "ChkCerrado"
        Me.ChkCerrado.Size = New System.Drawing.Size(67, 17)
        Me.ChkCerrado.TabIndex = 51
        Me.ChkCerrado.Text = "Cerrado"
        Me.ChkCerrado.UseVisualStyleBackColor = False
        '
        'ChkLevantado
        '
        Me.ChkLevantado.AutoSize = True
        Me.ChkLevantado.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ChkLevantado.Enabled = False
        Me.ChkLevantado.ForeColor = System.Drawing.Color.Black
        Me.ChkLevantado.Location = New System.Drawing.Point(173, 20)
        Me.ChkLevantado.Name = "ChkLevantado"
        Me.ChkLevantado.Size = New System.Drawing.Size(79, 17)
        Me.ChkLevantado.TabIndex = 52
        Me.ChkLevantado.Text = "Levantado"
        Me.ChkLevantado.UseVisualStyleBackColor = False
        '
        'Frm_02_Detalle_Producto_Actual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 511)
        Me.ControlBox = False
        Me.Controls.Add(Me.ChkLevantado)
        Me.Controls.Add(Me.ChkCerrado)
        Me.Controls.Add(Me.ChkRecontado)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_02_Detalle_Producto_Actual"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle del inventario del producto activo"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GrillaHistoriaProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LblContador2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblContador1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblActualizadoPor As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblDigitador As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LblObsActualizacion As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblObservaciones As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Public WithEvents GrillaHistoriaProducto As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Public WithEvents LblTotalInventariado As DevComponents.DotNetBar.LabelX
    Public WithEvents LblTotalDiferencia As DevComponents.DotNetBar.LabelX
    Public WithEvents LblTotalFotoStock As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnEstadisticas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnGrabarAnalisis_Reconteo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Public WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnAgregarConteo As DevComponents.DotNetBar.ButtonItem
    Public WithEvents ChkRecontado As System.Windows.Forms.CheckBox
    Public WithEvents ChkCerrado As System.Windows.Forms.CheckBox
    Public WithEvents ChkLevantado As System.Windows.Forms.CheckBox
End Class
