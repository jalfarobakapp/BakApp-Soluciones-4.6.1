<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Pocket_Equipos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Pocket_Equipos))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.Rdb_Enviar_Mail_X_Poswi = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Rdb_Enviar_Mail_X_BakApp = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Rdb_Impresion_X_Poswi = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Rdb_Impresion_X_BakApp = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Cmb_Modalidad = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.Cmb_Usuario = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.Txt_NombreEquipo = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Salir = New DevComponents.DotNetBar.ButtonItem
        Me.GroupPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel1.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(11, 3)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(488, 179)
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
        Me.GroupPanel1.TabIndex = 41
        Me.GroupPanel1.Text = "Datos del equipo asociado"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Enviar_Mail_X_Poswi, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Rdb_Enviar_Mail_X_BakApp, 0, 0)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(269, 96)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(208, 51)
        Me.TableLayoutPanel3.TabIndex = 3
        '
        'Rdb_Enviar_Mail_X_Poswi
        '
        '
        '
        '
        Me.Rdb_Enviar_Mail_X_Poswi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Enviar_Mail_X_Poswi.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Enviar_Mail_X_Poswi.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Enviar_Mail_X_Poswi.Location = New System.Drawing.Point(3, 28)
        Me.Rdb_Enviar_Mail_X_Poswi.Name = "Rdb_Enviar_Mail_X_Poswi"
        Me.Rdb_Enviar_Mail_X_Poswi.Size = New System.Drawing.Size(202, 19)
        Me.Rdb_Enviar_Mail_X_Poswi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Enviar_Mail_X_Poswi.TabIndex = 43
        Me.Rdb_Enviar_Mail_X_Poswi.Text = "Enviar correos via Poswii"
        '
        'Rdb_Enviar_Mail_X_BakApp
        '
        '
        '
        '
        Me.Rdb_Enviar_Mail_X_BakApp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Enviar_Mail_X_BakApp.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Enviar_Mail_X_BakApp.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Enviar_Mail_X_BakApp.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Enviar_Mail_X_BakApp.Name = "Rdb_Enviar_Mail_X_BakApp"
        Me.Rdb_Enviar_Mail_X_BakApp.Size = New System.Drawing.Size(202, 19)
        Me.Rdb_Enviar_Mail_X_BakApp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Enviar_Mail_X_BakApp.TabIndex = 42
        Me.Rdb_Enviar_Mail_X_BakApp.Text = "Enviar correos via BakApp"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Impresion_X_Poswi, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_Impresion_X_BakApp, 0, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(6, 96)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(208, 51)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'Rdb_Impresion_X_Poswi
        '
        '
        '
        '
        Me.Rdb_Impresion_X_Poswi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Impresion_X_Poswi.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Impresion_X_Poswi.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Impresion_X_Poswi.Location = New System.Drawing.Point(3, 28)
        Me.Rdb_Impresion_X_Poswi.Name = "Rdb_Impresion_X_Poswi"
        Me.Rdb_Impresion_X_Poswi.Size = New System.Drawing.Size(202, 19)
        Me.Rdb_Impresion_X_Poswi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Impresion_X_Poswi.TabIndex = 43
        Me.Rdb_Impresion_X_Poswi.Text = "Imprimir via Poswii"
        '
        'Rdb_Impresion_X_BakApp
        '
        '
        '
        '
        Me.Rdb_Impresion_X_BakApp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Impresion_X_BakApp.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Impresion_X_BakApp.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Impresion_X_BakApp.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_Impresion_X_BakApp.Name = "Rdb_Impresion_X_BakApp"
        Me.Rdb_Impresion_X_BakApp.Size = New System.Drawing.Size(202, 19)
        Me.Rdb_Impresion_X_BakApp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Impresion_X_BakApp.TabIndex = 42
        Me.Rdb_Impresion_X_BakApp.Text = "Imprimir via BakApp"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.31646!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.68355!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cmb_Modalidad, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX6, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Cmb_Usuario, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_NombreEquipo, 1, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(474, 87)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Cmb_Modalidad
        '
        Me.Cmb_Modalidad.DisplayMember = "Text"
        Me.Cmb_Modalidad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Modalidad.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Modalidad.FormattingEnabled = True
        Me.Cmb_Modalidad.ItemHeight = 16
        Me.Cmb_Modalidad.Location = New System.Drawing.Point(123, 61)
        Me.Cmb_Modalidad.Name = "Cmb_Modalidad"
        Me.Cmb_Modalidad.Size = New System.Drawing.Size(268, 22)
        Me.Cmb_Modalidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Modalidad.TabIndex = 11
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 61)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(114, 19)
        Me.LabelX6.TabIndex = 4
        Me.LabelX6.Text = "Modalidad"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 32)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(114, 19)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Usuario"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Cmb_Usuario
        '
        Me.Cmb_Usuario.DisplayMember = "Text"
        Me.Cmb_Usuario.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Usuario.FormattingEnabled = True
        Me.Cmb_Usuario.ItemHeight = 16
        Me.Cmb_Usuario.Location = New System.Drawing.Point(123, 32)
        Me.Cmb_Usuario.Name = "Cmb_Usuario"
        Me.Cmb_Usuario.Size = New System.Drawing.Size(268, 22)
        Me.Cmb_Usuario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Usuario.TabIndex = 0
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(114, 19)
        Me.LabelX4.TabIndex = 8
        Me.LabelX4.Text = "Nombre Equipo"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Txt_NombreEquipo
        '
        Me.Txt_NombreEquipo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreEquipo.Border.Class = "TextBoxBorder"
        Me.Txt_NombreEquipo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreEquipo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreEquipo.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreEquipo.Location = New System.Drawing.Point(123, 3)
        Me.Txt_NombreEquipo.Name = "Txt_NombreEquipo"
        Me.Txt_NombreEquipo.PreventEnterBeep = True
        Me.Txt_NombreEquipo.ReadOnly = True
        Me.Txt_NombreEquipo.Size = New System.Drawing.Size(348, 22)
        Me.Txt_NombreEquipo.TabIndex = 9
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Salir})
        Me.Bar1.Location = New System.Drawing.Point(0, 193)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(510, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 40
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        '
        'Btn_Salir
        '
        Me.Btn_Salir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Salir.ForeColor = System.Drawing.Color.Black
        Me.Btn_Salir.Image = CType(resources.GetObject("Btn_Salir.Image"), System.Drawing.Image)
        Me.Btn_Salir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Btn_Salir.Name = "Btn_Salir"
        '
        'Frm_Pocket_Equipos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 234)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Pocket_Equipos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EQUIPO POSWII"
        Me.GroupPanel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Usuario As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_NombreEquipo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Salir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Rdb_Enviar_Mail_X_Poswi As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Enviar_Mail_X_BakApp As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Rdb_Impresion_X_Poswi As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Impresion_X_BakApp As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Cmb_Modalidad As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
