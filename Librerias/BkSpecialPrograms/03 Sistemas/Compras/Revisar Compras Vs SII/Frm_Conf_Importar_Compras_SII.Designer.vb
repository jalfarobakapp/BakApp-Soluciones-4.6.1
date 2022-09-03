<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Conf_Importar_Compras_SII
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Conf_Importar_Compras_SII))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Abrir_Libro_SII = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cargar_Libro_SII = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Input_Periodo = New DevComponents.Editors.IntegerInput()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_12_Diciembre = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_06_Junio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_11_Noviembre = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_05_Mayo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_10_Octubre = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_04_Abril = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_09_Septiembre = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_03_Marzo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_08_Agosto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_02_Febrero = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_07_Julio = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_01_Enero = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Input_Periodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Abrir_Libro_SII, Me.Btn_Cargar_Libro_SII})
        Me.Bar1.Location = New System.Drawing.Point(0, 231)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(243, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 118
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Abrir_Libro_SII
        '
        Me.Btn_Abrir_Libro_SII.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Abrir_Libro_SII.ForeColor = System.Drawing.Color.Black
        Me.Btn_Abrir_Libro_SII.Image = CType(resources.GetObject("Btn_Abrir_Libro_SII.Image"), System.Drawing.Image)
        Me.Btn_Abrir_Libro_SII.Name = "Btn_Abrir_Libro_SII"
        Me.Btn_Abrir_Libro_SII.Tooltip = "Abrir libro"
        '
        'Btn_Cargar_Libro_SII
        '
        Me.Btn_Cargar_Libro_SII.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cargar_Libro_SII.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cargar_Libro_SII.Image = CType(resources.GetObject("Btn_Cargar_Libro_SII.Image"), System.Drawing.Image)
        Me.Btn_Cargar_Libro_SII.Name = "Btn_Cargar_Libro_SII"
        Me.Btn_Cargar_Libro_SII.Tooltip = "Buscar archivo Excel"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Input_Periodo)
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(218, 211)
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
        Me.GroupPanel1.TabIndex = 119
        Me.GroupPanel1.Text = "Meses"
        '
        'Input_Periodo
        '
        Me.Input_Periodo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Periodo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Periodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Periodo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Periodo.ForeColor = System.Drawing.Color.Black
        Me.Input_Periodo.Location = New System.Drawing.Point(120, 11)
        Me.Input_Periodo.MinValue = 2000
        Me.Input_Periodo.Name = "Input_Periodo"
        Me.Input_Periodo.ShowUpDown = True
        Me.Input_Periodo.Size = New System.Drawing.Size(80, 22)
        Me.Input_Periodo.TabIndex = 2
        Me.Input_Periodo.Value = 2000
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_12_Diciembre, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_06_Junio, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_11_Noviembre, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_05_Mayo, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_10_Octubre, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_04_Abril, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_09_Septiembre, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_03_Marzo, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_08_Agosto, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_02_Febrero, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_07_Julio, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_01_Enero, 0, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 44)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 131)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Rdb_12_Diciembre
        '
        Me.Rdb_12_Diciembre.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_12_Diciembre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_12_Diciembre.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_12_Diciembre.ForeColor = System.Drawing.Color.Black
        Me.Rdb_12_Diciembre.Location = New System.Drawing.Point(103, 108)
        Me.Rdb_12_Diciembre.Name = "Rdb_12_Diciembre"
        Me.Rdb_12_Diciembre.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_12_Diciembre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_12_Diciembre.TabIndex = 2
        Me.Rdb_12_Diciembre.Text = "Diciembre"
        '
        'Rdb_06_Junio
        '
        Me.Rdb_06_Junio.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_06_Junio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_06_Junio.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_06_Junio.ForeColor = System.Drawing.Color.Black
        Me.Rdb_06_Junio.Location = New System.Drawing.Point(3, 108)
        Me.Rdb_06_Junio.Name = "Rdb_06_Junio"
        Me.Rdb_06_Junio.Size = New System.Drawing.Size(94, 19)
        Me.Rdb_06_Junio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_06_Junio.TabIndex = 2
        Me.Rdb_06_Junio.Text = "Junio"
        '
        'Rdb_11_Noviembre
        '
        Me.Rdb_11_Noviembre.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_11_Noviembre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_11_Noviembre.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_11_Noviembre.ForeColor = System.Drawing.Color.Black
        Me.Rdb_11_Noviembre.Location = New System.Drawing.Point(103, 87)
        Me.Rdb_11_Noviembre.Name = "Rdb_11_Noviembre"
        Me.Rdb_11_Noviembre.Size = New System.Drawing.Size(94, 15)
        Me.Rdb_11_Noviembre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_11_Noviembre.TabIndex = 2
        Me.Rdb_11_Noviembre.Text = "Noviembre"
        '
        'Rdb_05_Mayo
        '
        Me.Rdb_05_Mayo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_05_Mayo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_05_Mayo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_05_Mayo.ForeColor = System.Drawing.Color.Black
        Me.Rdb_05_Mayo.Location = New System.Drawing.Point(3, 87)
        Me.Rdb_05_Mayo.Name = "Rdb_05_Mayo"
        Me.Rdb_05_Mayo.Size = New System.Drawing.Size(94, 15)
        Me.Rdb_05_Mayo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_05_Mayo.TabIndex = 2
        Me.Rdb_05_Mayo.Text = "Mayo"
        '
        'Rdb_10_Octubre
        '
        Me.Rdb_10_Octubre.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_10_Octubre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_10_Octubre.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_10_Octubre.ForeColor = System.Drawing.Color.Black
        Me.Rdb_10_Octubre.Location = New System.Drawing.Point(103, 66)
        Me.Rdb_10_Octubre.Name = "Rdb_10_Octubre"
        Me.Rdb_10_Octubre.Size = New System.Drawing.Size(94, 15)
        Me.Rdb_10_Octubre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_10_Octubre.TabIndex = 2
        Me.Rdb_10_Octubre.Text = "Octubre"
        '
        'Rdb_04_Abril
        '
        Me.Rdb_04_Abril.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_04_Abril.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_04_Abril.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_04_Abril.ForeColor = System.Drawing.Color.Black
        Me.Rdb_04_Abril.Location = New System.Drawing.Point(3, 66)
        Me.Rdb_04_Abril.Name = "Rdb_04_Abril"
        Me.Rdb_04_Abril.Size = New System.Drawing.Size(94, 15)
        Me.Rdb_04_Abril.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_04_Abril.TabIndex = 2
        Me.Rdb_04_Abril.Text = "Abril"
        '
        'Rdb_09_Septiembre
        '
        Me.Rdb_09_Septiembre.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_09_Septiembre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_09_Septiembre.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_09_Septiembre.ForeColor = System.Drawing.Color.Black
        Me.Rdb_09_Septiembre.Location = New System.Drawing.Point(103, 45)
        Me.Rdb_09_Septiembre.Name = "Rdb_09_Septiembre"
        Me.Rdb_09_Septiembre.Size = New System.Drawing.Size(94, 15)
        Me.Rdb_09_Septiembre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_09_Septiembre.TabIndex = 2
        Me.Rdb_09_Septiembre.Text = "Septiembre"
        '
        'Rdb_03_Marzo
        '
        Me.Rdb_03_Marzo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_03_Marzo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_03_Marzo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_03_Marzo.ForeColor = System.Drawing.Color.Black
        Me.Rdb_03_Marzo.Location = New System.Drawing.Point(3, 45)
        Me.Rdb_03_Marzo.Name = "Rdb_03_Marzo"
        Me.Rdb_03_Marzo.Size = New System.Drawing.Size(94, 15)
        Me.Rdb_03_Marzo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_03_Marzo.TabIndex = 2
        Me.Rdb_03_Marzo.Text = "Marzo"
        '
        'Rdb_08_Agosto
        '
        Me.Rdb_08_Agosto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_08_Agosto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_08_Agosto.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_08_Agosto.ForeColor = System.Drawing.Color.Black
        Me.Rdb_08_Agosto.Location = New System.Drawing.Point(103, 24)
        Me.Rdb_08_Agosto.Name = "Rdb_08_Agosto"
        Me.Rdb_08_Agosto.Size = New System.Drawing.Size(94, 15)
        Me.Rdb_08_Agosto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_08_Agosto.TabIndex = 2
        Me.Rdb_08_Agosto.Text = "Agosto"
        '
        'Rdb_02_Febrero
        '
        Me.Rdb_02_Febrero.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_02_Febrero.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_02_Febrero.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_02_Febrero.ForeColor = System.Drawing.Color.Black
        Me.Rdb_02_Febrero.Location = New System.Drawing.Point(3, 24)
        Me.Rdb_02_Febrero.Name = "Rdb_02_Febrero"
        Me.Rdb_02_Febrero.Size = New System.Drawing.Size(94, 15)
        Me.Rdb_02_Febrero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_02_Febrero.TabIndex = 2
        Me.Rdb_02_Febrero.Text = "Febrero"
        '
        'Rdb_07_Julio
        '
        Me.Rdb_07_Julio.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_07_Julio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_07_Julio.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_07_Julio.ForeColor = System.Drawing.Color.Black
        Me.Rdb_07_Julio.Location = New System.Drawing.Point(103, 3)
        Me.Rdb_07_Julio.Name = "Rdb_07_Julio"
        Me.Rdb_07_Julio.Size = New System.Drawing.Size(94, 15)
        Me.Rdb_07_Julio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_07_Julio.TabIndex = 2
        Me.Rdb_07_Julio.Text = "Julio"
        '
        'Rdb_01_Enero
        '
        Me.Rdb_01_Enero.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_01_Enero.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_01_Enero.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_01_Enero.ForeColor = System.Drawing.Color.Black
        Me.Rdb_01_Enero.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_01_Enero.Name = "Rdb_01_Enero"
        Me.Rdb_01_Enero.Size = New System.Drawing.Size(94, 15)
        Me.Rdb_01_Enero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_01_Enero.TabIndex = 0
        Me.Rdb_01_Enero.Text = "Enero"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(6, 16)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 17)
        Me.LabelX1.TabIndex = 3
        Me.LabelX1.Text = "Año periodo"
        '
        'Frm_Conf_Importar_Compras_SII
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(243, 272)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Conf_Importar_Compras_SII"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SII vs RD"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Input_Periodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Cargar_Libro_SII As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_07_Julio As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Rdb_01_Enero As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_12_Diciembre As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_06_Junio As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_11_Noviembre As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_05_Mayo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_10_Octubre As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_04_Abril As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_09_Septiembre As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_03_Marzo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_08_Agosto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_02_Febrero As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Btn_Abrir_Libro_SII As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Input_Periodo As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
