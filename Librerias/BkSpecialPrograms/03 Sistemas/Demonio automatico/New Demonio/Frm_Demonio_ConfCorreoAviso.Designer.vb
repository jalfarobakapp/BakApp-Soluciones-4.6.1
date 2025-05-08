<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Demonio_ConfCorreoAviso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Demonio_ConfCorreoAviso))
        Me.Txt_Nombre_Correo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX39 = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Txt_MailRemitente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX27 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_MailCC = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Rdb_Enviar_VendedorCliente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Enviar_Remitente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Enviar_VendedorLinea = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Enviar_ResponsableDoc = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_Enviar_EntidadDoc = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_CC_EntidadDoc = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_CC_Remitente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_CC_ResponsableDoc = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_CC_VendedorCliente = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_CC_VendedorLinea = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Txt_Nombre_Correo
        '
        Me.Txt_Nombre_Correo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Nombre_Correo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Nombre_Correo.Border.Class = "TextBoxBorder"
        Me.Txt_Nombre_Correo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Nombre_Correo.ButtonCustom.Image = CType(resources.GetObject("Txt_Nombre_Correo.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Nombre_Correo.ButtonCustom.Visible = True
        Me.Txt_Nombre_Correo.ButtonCustom2.Image = CType(resources.GetObject("Txt_Nombre_Correo.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Nombre_Correo.ButtonCustom2.Visible = True
        Me.Txt_Nombre_Correo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Nombre_Correo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Nombre_Correo.Location = New System.Drawing.Point(102, 136)
        Me.Txt_Nombre_Correo.Name = "Txt_Nombre_Correo"
        Me.Txt_Nombre_Correo.PreventEnterBeep = True
        Me.Txt_Nombre_Correo.ReadOnly = True
        Me.Txt_Nombre_Correo.Size = New System.Drawing.Size(529, 22)
        Me.Txt_Nombre_Correo.TabIndex = 10017
        Me.Txt_Nombre_Correo.Tag = "9999"
        Me.Txt_Nombre_Correo.WatermarkText = "Sino hay correo en esta casilla no se enviaran correos..."
        '
        'LabelX39
        '
        Me.LabelX39.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX39.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX39.ForeColor = System.Drawing.Color.Black
        Me.LabelX39.Location = New System.Drawing.Point(7, 136)
        Me.LabelX39.Name = "LabelX39"
        Me.LabelX39.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX39.Size = New System.Drawing.Size(87, 22)
        Me.LabelX39.TabIndex = 10018
        Me.LabelX39.Text = "Correo de envío"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 170)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(780, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 10019
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
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Txt_MailRemitente
        '
        Me.Txt_MailRemitente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_MailRemitente.Border.Class = "TextBoxBorder"
        Me.Txt_MailRemitente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_MailRemitente.ButtonCustom2.Image = CType(resources.GetObject("Txt_MailRemitente.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_MailRemitente.ButtonCustom2.Visible = True
        Me.Txt_MailRemitente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_MailRemitente.ForeColor = System.Drawing.Color.Black
        Me.Txt_MailRemitente.Location = New System.Drawing.Point(102, 46)
        Me.Txt_MailRemitente.Name = "Txt_MailRemitente"
        Me.Txt_MailRemitente.PreventEnterBeep = True
        Me.Txt_MailRemitente.Size = New System.Drawing.Size(543, 22)
        Me.Txt_MailRemitente.TabIndex = 10021
        Me.Txt_MailRemitente.WatermarkText = "Puede ingresar mas de un correo separado por ;"
        '
        'LabelX27
        '
        Me.LabelX27.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX27.ForeColor = System.Drawing.Color.Black
        Me.LabelX27.Location = New System.Drawing.Point(7, 45)
        Me.LabelX27.Name = "LabelX27"
        Me.LabelX27.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX27.Size = New System.Drawing.Size(89, 23)
        Me.LabelX27.TabIndex = 10020
        Me.LabelX27.Text = "Correo remitente"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(9, 16)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX1.Size = New System.Drawing.Size(87, 23)
        Me.LabelX1.TabIndex = 10022
        Me.LabelX1.Text = "Enviar a "
        '
        'Txt_MailCC
        '
        Me.Txt_MailCC.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_MailCC.Border.Class = "TextBoxBorder"
        Me.Txt_MailCC.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_MailCC.ButtonCustom2.Image = CType(resources.GetObject("Txt_MailCC.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_MailCC.ButtonCustom2.Visible = True
        Me.Txt_MailCC.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_MailCC.ForeColor = System.Drawing.Color.Black
        Me.Txt_MailCC.Location = New System.Drawing.Point(102, 108)
        Me.Txt_MailCC.Name = "Txt_MailCC"
        Me.Txt_MailCC.PreventEnterBeep = True
        Me.Txt_MailCC.Size = New System.Drawing.Size(543, 22)
        Me.Txt_MailCC.TabIndex = 10024
        Me.Txt_MailCC.WatermarkText = "Puede ingresar mas de un correo separado por ;"
        '
        'Rdb_Enviar_VendedorCliente
        '
        Me.Rdb_Enviar_VendedorCliente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Enviar_VendedorCliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Enviar_VendedorCliente.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Enviar_VendedorCliente.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Enviar_VendedorCliente.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Enviar_VendedorCliente.FocusCuesEnabled = False
        Me.Rdb_Enviar_VendedorCliente.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Enviar_VendedorCliente.Location = New System.Drawing.Point(102, 4)
        Me.Rdb_Enviar_VendedorCliente.Name = "Rdb_Enviar_VendedorCliente"
        Me.Rdb_Enviar_VendedorCliente.Size = New System.Drawing.Size(116, 20)
        Me.Rdb_Enviar_VendedorCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Enviar_VendedorCliente.TabIndex = 10026
        Me.Rdb_Enviar_VendedorCliente.Text = "Vendedor (cliente)"
        '
        'Rdb_Enviar_Remitente
        '
        Me.Rdb_Enviar_Remitente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Enviar_Remitente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Enviar_Remitente.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Enviar_Remitente.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Enviar_Remitente.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Enviar_Remitente.Checked = True
        Me.Rdb_Enviar_Remitente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Enviar_Remitente.CheckValue = "Y"
        Me.Rdb_Enviar_Remitente.FocusCuesEnabled = False
        Me.Rdb_Enviar_Remitente.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Enviar_Remitente.Location = New System.Drawing.Point(4, 4)
        Me.Rdb_Enviar_Remitente.Name = "Rdb_Enviar_Remitente"
        Me.Rdb_Enviar_Remitente.Size = New System.Drawing.Size(91, 20)
        Me.Rdb_Enviar_Remitente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Enviar_Remitente.TabIndex = 10025
        Me.Rdb_Enviar_Remitente.Text = "Remitente"
        '
        'Rdb_Enviar_VendedorLinea
        '
        Me.Rdb_Enviar_VendedorLinea.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Enviar_VendedorLinea.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Enviar_VendedorLinea.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Enviar_VendedorLinea.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Enviar_VendedorLinea.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Enviar_VendedorLinea.FocusCuesEnabled = False
        Me.Rdb_Enviar_VendedorLinea.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Enviar_VendedorLinea.Location = New System.Drawing.Point(244, 4)
        Me.Rdb_Enviar_VendedorLinea.Name = "Rdb_Enviar_VendedorLinea"
        Me.Rdb_Enviar_VendedorLinea.Size = New System.Drawing.Size(133, 20)
        Me.Rdb_Enviar_VendedorLinea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Enviar_VendedorLinea.TabIndex = 10027
        Me.Rdb_Enviar_VendedorLinea.Text = "Vendedor (línea doc.)"
        '
        'Rdb_Enviar_ResponsableDoc
        '
        Me.Rdb_Enviar_ResponsableDoc.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Enviar_ResponsableDoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Enviar_ResponsableDoc.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Enviar_ResponsableDoc.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Enviar_ResponsableDoc.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Enviar_ResponsableDoc.FocusCuesEnabled = False
        Me.Rdb_Enviar_ResponsableDoc.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Enviar_ResponsableDoc.Location = New System.Drawing.Point(386, 4)
        Me.Rdb_Enviar_ResponsableDoc.Name = "Rdb_Enviar_ResponsableDoc"
        Me.Rdb_Enviar_ResponsableDoc.Size = New System.Drawing.Size(135, 20)
        Me.Rdb_Enviar_ResponsableDoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Enviar_ResponsableDoc.TabIndex = 10028
        Me.Rdb_Enviar_ResponsableDoc.Text = "Responsable documento"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.74883!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.31279!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.31279!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.31279!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.31279!))
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Enviar_EntidadDoc, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Enviar_Remitente, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Enviar_ResponsableDoc, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Enviar_VendedorCliente, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Rdb_Enviar_VendedorLinea, 2, 0)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(102, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(669, 28)
        Me.TableLayoutPanel1.TabIndex = 10029
        '
        'Rdb_Enviar_EntidadDoc
        '
        Me.Rdb_Enviar_EntidadDoc.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Enviar_EntidadDoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Enviar_EntidadDoc.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Enviar_EntidadDoc.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Enviar_EntidadDoc.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Enviar_EntidadDoc.FocusCuesEnabled = False
        Me.Rdb_Enviar_EntidadDoc.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Enviar_EntidadDoc.Location = New System.Drawing.Point(528, 4)
        Me.Rdb_Enviar_EntidadDoc.Name = "Rdb_Enviar_EntidadDoc"
        Me.Rdb_Enviar_EntidadDoc.Size = New System.Drawing.Size(137, 20)
        Me.Rdb_Enviar_EntidadDoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Enviar_EntidadDoc.TabIndex = 10033
        Me.Rdb_Enviar_EntidadDoc.Text = "Entidad documento"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.15152!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.21212!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.21212!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.21212!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.21212!))
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_CC_EntidadDoc, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_CC_Remitente, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_CC_ResponsableDoc, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_CC_VendedorCliente, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Rdb_CC_VendedorLinea, 2, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(102, 74)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(669, 28)
        Me.TableLayoutPanel2.TabIndex = 10030
        '
        'Rdb_CC_EntidadDoc
        '
        Me.Rdb_CC_EntidadDoc.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_CC_EntidadDoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_CC_EntidadDoc.CheckBoxImageChecked = CType(resources.GetObject("Rdb_CC_EntidadDoc.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_CC_EntidadDoc.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_CC_EntidadDoc.FocusCuesEnabled = False
        Me.Rdb_CC_EntidadDoc.ForeColor = System.Drawing.Color.Black
        Me.Rdb_CC_EntidadDoc.Location = New System.Drawing.Point(528, 4)
        Me.Rdb_CC_EntidadDoc.Name = "Rdb_CC_EntidadDoc"
        Me.Rdb_CC_EntidadDoc.Size = New System.Drawing.Size(137, 20)
        Me.Rdb_CC_EntidadDoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_CC_EntidadDoc.TabIndex = 10034
        Me.Rdb_CC_EntidadDoc.Text = "Entidad documento"
        '
        'Rdb_CC_Remitente
        '
        Me.Rdb_CC_Remitente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_CC_Remitente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_CC_Remitente.CheckBoxImageChecked = CType(resources.GetObject("Rdb_CC_Remitente.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_CC_Remitente.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_CC_Remitente.Checked = True
        Me.Rdb_CC_Remitente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_CC_Remitente.CheckValue = "Y"
        Me.Rdb_CC_Remitente.FocusCuesEnabled = False
        Me.Rdb_CC_Remitente.ForeColor = System.Drawing.Color.Black
        Me.Rdb_CC_Remitente.Location = New System.Drawing.Point(4, 4)
        Me.Rdb_CC_Remitente.Name = "Rdb_CC_Remitente"
        Me.Rdb_CC_Remitente.Size = New System.Drawing.Size(92, 20)
        Me.Rdb_CC_Remitente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_CC_Remitente.TabIndex = 10025
        Me.Rdb_CC_Remitente.Text = "Remitente"
        '
        'Rdb_CC_ResponsableDoc
        '
        Me.Rdb_CC_ResponsableDoc.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_CC_ResponsableDoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_CC_ResponsableDoc.CheckBoxImageChecked = CType(resources.GetObject("Rdb_CC_ResponsableDoc.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_CC_ResponsableDoc.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_CC_ResponsableDoc.FocusCuesEnabled = False
        Me.Rdb_CC_ResponsableDoc.ForeColor = System.Drawing.Color.Black
        Me.Rdb_CC_ResponsableDoc.Location = New System.Drawing.Point(387, 4)
        Me.Rdb_CC_ResponsableDoc.Name = "Rdb_CC_ResponsableDoc"
        Me.Rdb_CC_ResponsableDoc.Size = New System.Drawing.Size(134, 20)
        Me.Rdb_CC_ResponsableDoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_CC_ResponsableDoc.TabIndex = 10028
        Me.Rdb_CC_ResponsableDoc.Text = "Responsable documento"
        '
        'Rdb_CC_VendedorCliente
        '
        Me.Rdb_CC_VendedorCliente.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_CC_VendedorCliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_CC_VendedorCliente.CheckBoxImageChecked = CType(resources.GetObject("Rdb_CC_VendedorCliente.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_CC_VendedorCliente.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_CC_VendedorCliente.FocusCuesEnabled = False
        Me.Rdb_CC_VendedorCliente.ForeColor = System.Drawing.Color.Black
        Me.Rdb_CC_VendedorCliente.Location = New System.Drawing.Point(105, 4)
        Me.Rdb_CC_VendedorCliente.Name = "Rdb_CC_VendedorCliente"
        Me.Rdb_CC_VendedorCliente.Size = New System.Drawing.Size(116, 20)
        Me.Rdb_CC_VendedorCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_CC_VendedorCliente.TabIndex = 10026
        Me.Rdb_CC_VendedorCliente.Text = "Vendedor (cliente)"
        '
        'Rdb_CC_VendedorLinea
        '
        Me.Rdb_CC_VendedorLinea.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_CC_VendedorLinea.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_CC_VendedorLinea.CheckBoxImageChecked = CType(resources.GetObject("Rdb_CC_VendedorLinea.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_CC_VendedorLinea.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_CC_VendedorLinea.FocusCuesEnabled = False
        Me.Rdb_CC_VendedorLinea.ForeColor = System.Drawing.Color.Black
        Me.Rdb_CC_VendedorLinea.Location = New System.Drawing.Point(246, 4)
        Me.Rdb_CC_VendedorLinea.Name = "Rdb_CC_VendedorLinea"
        Me.Rdb_CC_VendedorLinea.Size = New System.Drawing.Size(130, 20)
        Me.Rdb_CC_VendedorLinea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_CC_VendedorLinea.TabIndex = 10027
        Me.Rdb_CC_VendedorLinea.Text = "Vendedor (línea doc.)"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(7, 108)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX3.Size = New System.Drawing.Size(79, 23)
        Me.LabelX3.TabIndex = 10031
        Me.LabelX3.Text = "Correo C.C."
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(7, 74)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX2.Size = New System.Drawing.Size(60, 23)
        Me.LabelX2.TabIndex = 10032
        Me.LabelX2.Text = "C.C."
        '
        'Frm_Demonio_ConfCorreoAviso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 211)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Txt_MailCC)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Txt_MailRemitente)
        Me.Controls.Add(Me.LabelX27)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Txt_Nombre_Correo)
        Me.Controls.Add(Me.LabelX39)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Demonio_ConfCorreoAviso"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONFIGURACION DE ENVIO DE CORREO AUTOMATICO"
        Me.TopMost = True
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Txt_Nombre_Correo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX39 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_MailRemitente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX27 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_MailCC As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Rdb_Enviar_VendedorCliente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Enviar_Remitente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Enviar_VendedorLinea As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Enviar_ResponsableDoc As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Rdb_CC_Remitente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_CC_ResponsableDoc As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_CC_VendedorCliente As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_CC_VendedorLinea As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_Enviar_EntidadDoc As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_CC_EntidadDoc As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
End Class
