<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Formatos_Numericos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Formatos_Numericos))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Ejemplo = New System.Windows.Forms.Label()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Rdb_Moneda = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Alineacion_Der = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Alineacion_Izq = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Lbl_X_Sumar_MM = New DevComponents.DotNetBar.LabelX()
        Me.Input_Decimales = New DevComponents.Editors.IntegerInput()
        Me.Input_Numeros = New DevComponents.Editors.IntegerInput()
        Me.Lbl_X = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Sin_Simbolo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Porcentaje = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo.SuspendLayout()
        CType(Me.Input_Decimales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Numeros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Aceptar})
        Me.Bar1.Location = New System.Drawing.Point(0, 249)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(296, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 95
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Text = "Aceptar"
        '
        'Grupo
        '
        Me.Grupo.BackColor = System.Drawing.Color.White
        Me.Grupo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo.Controls.Add(Me.TableLayoutPanel1)
        Me.Grupo.Controls.Add(Me.Lbl_Ejemplo)
        Me.Grupo.Controls.Add(Me.LabelX1)
        Me.Grupo.Controls.Add(Me.Rdb_Alineacion_Der)
        Me.Grupo.Controls.Add(Me.Rdb_Alineacion_Izq)
        Me.Grupo.Controls.Add(Me.Lbl_X_Sumar_MM)
        Me.Grupo.Controls.Add(Me.Input_Decimales)
        Me.Grupo.Controls.Add(Me.Input_Numeros)
        Me.Grupo.Controls.Add(Me.Lbl_X)
        Me.Grupo.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo.Location = New System.Drawing.Point(3, 12)
        Me.Grupo.Name = "Grupo"
        Me.Grupo.Size = New System.Drawing.Size(287, 230)
        '
        '
        '
        Me.Grupo.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo.Style.BackColorGradientAngle = 90
        Me.Grupo.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo.Style.BorderBottomWidth = 1
        Me.Grupo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo.Style.BorderLeftWidth = 1
        Me.Grupo.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo.Style.BorderRightWidth = 1
        Me.Grupo.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo.Style.BorderTopWidth = 1
        Me.Grupo.Style.CornerDiameter = 4
        Me.Grupo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo.TabIndex = 94
        Me.Grupo.Text = "Definición de formato de impresión"
        '
        'Lbl_Ejemplo
        '
        Me.Lbl_Ejemplo.BackColor = System.Drawing.Color.White
        Me.Lbl_Ejemplo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_Ejemplo.Font = New System.Drawing.Font("Courier New", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Ejemplo.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Ejemplo.Location = New System.Drawing.Point(3, 174)
        Me.Lbl_Ejemplo.Name = "Lbl_Ejemplo"
        Me.Lbl_Ejemplo.Size = New System.Drawing.Size(272, 26)
        Me.Lbl_Ejemplo.TabIndex = 109
        Me.Lbl_Ejemplo.Text = "$ 999.999.999,99999"
        Me.Lbl_Ejemplo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 145)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(97, 24)
        Me.LabelX1.TabIndex = 108
        Me.LabelX1.Text = "Vista previa"
        '
        'Rdb_Moneda
        '
        Me.Rdb_Moneda.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Moneda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Moneda.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Moneda.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Moneda.Location = New System.Drawing.Point(3, 43)
        Me.Rdb_Moneda.Name = "Rdb_Moneda"
        Me.Rdb_Moneda.Size = New System.Drawing.Size(142, 16)
        Me.Rdb_Moneda.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Moneda.TabIndex = 106
        Me.Rdb_Moneda.Text = "$ Moneda"
        '
        'Rdb_Alineacion_Der
        '
        Me.Rdb_Alineacion_Der.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Alineacion_Der.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Alineacion_Der.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Alineacion_Der.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Alineacion_Der.Location = New System.Drawing.Point(123, 48)
        Me.Rdb_Alineacion_Der.Name = "Rdb_Alineacion_Der"
        Me.Rdb_Alineacion_Der.Size = New System.Drawing.Size(100, 23)
        Me.Rdb_Alineacion_Der.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Alineacion_Der.TabIndex = 105
        Me.Rdb_Alineacion_Der.Text = "Alinear Derecha"
        '
        'Rdb_Alineacion_Izq
        '
        Me.Rdb_Alineacion_Izq.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Alineacion_Izq.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Alineacion_Izq.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Alineacion_Izq.Checked = True
        Me.Rdb_Alineacion_Izq.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Alineacion_Izq.CheckValue = "Y"
        Me.Rdb_Alineacion_Izq.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Alineacion_Izq.Location = New System.Drawing.Point(3, 48)
        Me.Rdb_Alineacion_Izq.Name = "Rdb_Alineacion_Izq"
        Me.Rdb_Alineacion_Izq.Size = New System.Drawing.Size(100, 23)
        Me.Rdb_Alineacion_Izq.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Alineacion_Izq.TabIndex = 96
        Me.Rdb_Alineacion_Izq.Text = "Alinear Izquierda"
        '
        'Lbl_X_Sumar_MM
        '
        Me.Lbl_X_Sumar_MM.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_X_Sumar_MM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_X_Sumar_MM.ForeColor = System.Drawing.Color.Black
        Me.Lbl_X_Sumar_MM.Location = New System.Drawing.Point(151, 20)
        Me.Lbl_X_Sumar_MM.Name = "Lbl_X_Sumar_MM"
        Me.Lbl_X_Sumar_MM.Size = New System.Drawing.Size(60, 24)
        Me.Lbl_X_Sumar_MM.TabIndex = 104
        Me.Lbl_X_Sumar_MM.Text = "Decimales"
        '
        'Input_Decimales
        '
        Me.Input_Decimales.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Decimales.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Decimales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Decimales.ButtonClear.Visible = True
        Me.Input_Decimales.FocusHighlightEnabled = True
        Me.Input_Decimales.ForeColor = System.Drawing.Color.Black
        Me.Input_Decimales.Location = New System.Drawing.Point(217, 20)
        Me.Input_Decimales.MaxValue = 5
        Me.Input_Decimales.MinValue = 0
        Me.Input_Decimales.Name = "Input_Decimales"
        Me.Input_Decimales.ShowUpDown = True
        Me.Input_Decimales.Size = New System.Drawing.Size(61, 22)
        Me.Input_Decimales.TabIndex = 102
        '
        'Input_Numeros
        '
        Me.Input_Numeros.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_Numeros.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Numeros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Numeros.ButtonClear.Visible = True
        Me.Input_Numeros.FocusHighlightEnabled = True
        Me.Input_Numeros.ForeColor = System.Drawing.Color.Black
        Me.Input_Numeros.Location = New System.Drawing.Point(72, 20)
        Me.Input_Numeros.MaxValue = 9
        Me.Input_Numeros.MinValue = 1
        Me.Input_Numeros.Name = "Input_Numeros"
        Me.Input_Numeros.ShowUpDown = True
        Me.Input_Numeros.Size = New System.Drawing.Size(73, 22)
        Me.Input_Numeros.TabIndex = 100
        Me.Input_Numeros.Value = 9
        '
        'Lbl_X
        '
        Me.Lbl_X.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_X.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_X.ForeColor = System.Drawing.Color.Black
        Me.Lbl_X.Location = New System.Drawing.Point(3, 20)
        Me.Lbl_X.Name = "Lbl_X"
        Me.Lbl_X.Size = New System.Drawing.Size(74, 24)
        Me.Lbl_X.TabIndex = 1
        Me.Lbl_X.Text = "Números"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Porcentaje, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Sin_Simbolo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Moneda, 0, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 77)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(275, 62)
        Me.TableLayoutPanel1.TabIndex = 110
        '
        'Rdb_Sin_Simbolo
        '
        Me.Rdb_Sin_Simbolo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Sin_Simbolo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Sin_Simbolo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Sin_Simbolo.Checked = True
        Me.Rdb_Sin_Simbolo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Sin_Simbolo.CheckValue = "Y"
        Me.Rdb_Sin_Simbolo.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Sin_Simbolo.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Sin_Simbolo.Name = "Rdb_Sin_Simbolo"
        Me.Rdb_Sin_Simbolo.Size = New System.Drawing.Size(100, 14)
        Me.Rdb_Sin_Simbolo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Sin_Simbolo.TabIndex = 111
        Me.Rdb_Sin_Simbolo.Text = "Sin Símbolo"
        '
        'Rdb_Porcentaje
        '
        Me.Rdb_Porcentaje.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Porcentaje.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Porcentaje.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Porcentaje.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Porcentaje.Location = New System.Drawing.Point(3, 23)
        Me.Rdb_Porcentaje.Name = "Rdb_Porcentaje"
        Me.Rdb_Porcentaje.Size = New System.Drawing.Size(100, 14)
        Me.Rdb_Porcentaje.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Porcentaje.TabIndex = 111
        Me.Rdb_Porcentaje.Text = "% Porcentaje"
        '
        'Frm_Formatos_Numericos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 290)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Grupo)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Formatos_Numericos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Formato númerico"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo.ResumeLayout(False)
        CType(Me.Input_Decimales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Numeros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Grupo As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_X_Sumar_MM As DevComponents.DotNetBar.LabelX
    Private WithEvents Input_Decimales As DevComponents.Editors.IntegerInput
    Private WithEvents Input_Numeros As DevComponents.Editors.IntegerInput
    Friend WithEvents Lbl_X As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Alineacion_Der As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Alineacion_Izq As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Moneda As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Ejemplo As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Rdb_Porcentaje As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Sin_Simbolo As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
