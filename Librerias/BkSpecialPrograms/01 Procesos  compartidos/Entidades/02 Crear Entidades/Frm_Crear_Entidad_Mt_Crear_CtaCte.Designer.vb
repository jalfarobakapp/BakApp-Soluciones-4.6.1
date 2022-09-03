<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Crear_Entidad_Mt_Crear_CtaCte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Crear_Entidad_Mt_Crear_CtaCte))
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_NroCtaCte = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Medio_Pago_Proveedor = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Cmb_Emisor = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Txt_Rut = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Nombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Agregar_cta = New DevComponents.DotNetBar.ButtonItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.CheckBoxX1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 81)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(117, 20)
        Me.LabelX4.TabIndex = 5
        Me.LabelX4.Text = "Rut"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 55)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(117, 20)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Número de la cuenta"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel1.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(11, 6)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(488, 162)
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
        Me.GroupPanel1.TabIndex = 39
        Me.GroupPanel1.Text = "Descripción de la cuenta"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.94937!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.05064!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX6, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_NroCtaCte, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Cmb_Medio_Pago_Proveedor, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cmb_Emisor, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Rut, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Nombre, 1, 4)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.30075!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.79699!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(474, 133)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 107)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(117, 20)
        Me.LabelX6.TabIndex = 10
        Me.LabelX6.Text = "Nombre"
        '
        'Txt_NroCtaCte
        '
        Me.Txt_NroCtaCte.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NroCtaCte.Border.Class = "TextBoxBorder"
        Me.Txt_NroCtaCte.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NroCtaCte.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NroCtaCte.ForeColor = System.Drawing.Color.Black
        Me.Txt_NroCtaCte.Location = New System.Drawing.Point(126, 55)
        Me.Txt_NroCtaCte.Name = "Txt_NroCtaCte"
        Me.Txt_NroCtaCte.PreventEnterBeep = True
        Me.Txt_NroCtaCte.Size = New System.Drawing.Size(121, 22)
        Me.Txt_NroCtaCte.TabIndex = 1
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(117, 20)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Tipo de documento"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 30)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(117, 19)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Emisor (Banco)"
        '
        'Cmb_Medio_Pago_Proveedor
        '
        Me.Cmb_Medio_Pago_Proveedor.DisplayMember = "Text"
        Me.Cmb_Medio_Pago_Proveedor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Medio_Pago_Proveedor.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Medio_Pago_Proveedor.FormattingEnabled = True
        Me.Cmb_Medio_Pago_Proveedor.ItemHeight = 16
        Me.Cmb_Medio_Pago_Proveedor.Location = New System.Drawing.Point(126, 3)
        Me.Cmb_Medio_Pago_Proveedor.Name = "Cmb_Medio_Pago_Proveedor"
        Me.Cmb_Medio_Pago_Proveedor.Size = New System.Drawing.Size(121, 22)
        Me.Cmb_Medio_Pago_Proveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Medio_Pago_Proveedor.TabIndex = 3
        '
        'Cmb_Emisor
        '
        Me.Cmb_Emisor.DisplayMember = "Text"
        Me.Cmb_Emisor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Emisor.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Emisor.FormattingEnabled = True
        Me.Cmb_Emisor.ItemHeight = 16
        Me.Cmb_Emisor.Location = New System.Drawing.Point(126, 30)
        Me.Cmb_Emisor.Name = "Cmb_Emisor"
        Me.Cmb_Emisor.Size = New System.Drawing.Size(267, 22)
        Me.Cmb_Emisor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Emisor.TabIndex = 8
        '
        'Txt_Rut
        '
        Me.Txt_Rut.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Rut.Border.Class = "TextBoxBorder"
        Me.Txt_Rut.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Rut.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Rut.ForeColor = System.Drawing.Color.Black
        Me.Txt_Rut.Location = New System.Drawing.Point(126, 81)
        Me.Txt_Rut.Name = "Txt_Rut"
        Me.Txt_Rut.PreventEnterBeep = True
        Me.Txt_Rut.ReadOnly = True
        Me.Txt_Rut.Size = New System.Drawing.Size(121, 22)
        Me.Txt_Rut.TabIndex = 7
        Me.Txt_Rut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_Nombre
        '
        Me.Txt_Nombre.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombre.Location = New System.Drawing.Point(126, 107)
        Me.Txt_Nombre.Name = "Txt_Nombre"
        Me.Txt_Nombre.PreventEnterBeep = True
        Me.Txt_Nombre.ReadOnly = True
        Me.Txt_Nombre.Size = New System.Drawing.Size(345, 22)
        Me.Txt_Nombre.TabIndex = 9
        Me.Txt_Nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Btn_Agregar_cta
        '
        Me.Btn_Agregar_cta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Agregar_cta.ForeColor = System.Drawing.Color.Black
        Me.Btn_Agregar_cta.Image = CType(resources.GetObject("Btn_Agregar_cta.Image"), System.Drawing.Image)
        Me.Btn_Agregar_cta.ImageAlt = CType(resources.GetObject("Btn_Agregar_cta.ImageAlt"), System.Drawing.Image)
        Me.Btn_Agregar_cta.Name = "Btn_Agregar_cta"
        Me.Btn_Agregar_cta.Text = "Agregar cuenta"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Agregar_cta})
        Me.Bar1.Location = New System.Drawing.Point(0, 202)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(510, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 38
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'CheckBoxX1
        '
        Me.CheckBoxX1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.CheckBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX1.ForeColor = System.Drawing.Color.Black
        Me.CheckBoxX1.Location = New System.Drawing.Point(11, 174)
        Me.CheckBoxX1.Name = "CheckBoxX1"
        Me.CheckBoxX1.Size = New System.Drawing.Size(100, 23)
        Me.CheckBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX1.TabIndex = 40
        Me.CheckBoxX1.Text = "Bloqueada"
        '
        'Frm_Crear_Entidad_Mt_Crear_CtaCte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 243)
        Me.Controls.Add(Me.CheckBoxX1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Crear_Entidad_Mt_Crear_CtaCte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas corrientes de la entidad"
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Txt_NroCtaCte As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Medio_Pago_Proveedor As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Rut As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Btn_Agregar_cta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Cmb_Emisor As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Nombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents CheckBoxX1 As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
