<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Stmp_ConfLocal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Stmp_ConfLocal))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_NombreEquipoImprime_Ticket = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_ImprimirTicket = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_NombreFormato_Ticket = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Impresora_Ticket = New DevComponents.DotNetBar.Controls.TextBoxX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar2.Location = New System.Drawing.Point(0, 189)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(345, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 167
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar configuración local"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.LabelX9)
        Me.GroupPanel3.Controls.Add(Me.Txt_NombreEquipoImprime_Ticket)
        Me.GroupPanel3.Controls.Add(Me.LabelX10)
        Me.GroupPanel3.Controls.Add(Me.LabelX11)
        Me.GroupPanel3.Controls.Add(Me.Chk_ImprimirTicket)
        Me.GroupPanel3.Controls.Add(Me.Txt_NombreFormato_Ticket)
        Me.GroupPanel3.Controls.Add(Me.Txt_Impresora_Ticket)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(11, 12)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(322, 163)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 168
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(3, 110)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(150, 19)
        Me.LabelX9.TabIndex = 108
        Me.LabelX9.Text = "Nombre formato"
        '
        'Txt_NombreEquipoImprime_Ticket
        '
        Me.Txt_NombreEquipoImprime_Ticket.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreEquipoImprime_Ticket.Border.Class = "TextBoxBorder"
        Me.Txt_NombreEquipoImprime_Ticket.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreEquipoImprime_Ticket.ButtonCustom.Image = CType(resources.GetObject("Txt_NombreEquipoImprime_Ticket.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_NombreEquipoImprime_Ticket.ButtonCustom.Visible = True
        Me.Txt_NombreEquipoImprime_Ticket.ButtonCustom2.Image = CType(resources.GetObject("Txt_NombreEquipoImprime_Ticket.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_NombreEquipoImprime_Ticket.ButtonCustom2.Visible = True
        Me.Txt_NombreEquipoImprime_Ticket.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreEquipoImprime_Ticket.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreEquipoImprime_Ticket.Location = New System.Drawing.Point(3, 29)
        Me.Txt_NombreEquipoImprime_Ticket.Name = "Txt_NombreEquipoImprime_Ticket"
        Me.Txt_NombreEquipoImprime_Ticket.PreventEnterBeep = True
        Me.Txt_NombreEquipoImprime_Ticket.Size = New System.Drawing.Size(302, 22)
        Me.Txt_NombreEquipoImprime_Ticket.TabIndex = 1
        Me.Txt_NombreEquipoImprime_Ticket.WatermarkText = "Nombre de equipo que imprime"
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(3, 3)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(173, 20)
        Me.LabelX10.TabIndex = 106
        Me.LabelX10.Text = "Nombre de equipo que imprime"
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(3, 57)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(150, 19)
        Me.LabelX11.TabIndex = 103
        Me.LabelX11.Text = "Nombre impresora"
        '
        'Chk_ImprimirTicket
        '
        Me.Chk_ImprimirTicket.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_ImprimirTicket.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_ImprimirTicket.CheckBoxImageChecked = CType(resources.GetObject("Chk_ImprimirTicket.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_ImprimirTicket.FocusCuesEnabled = False
        Me.Chk_ImprimirTicket.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Chk_ImprimirTicket.ForeColor = System.Drawing.Color.Black
        Me.Chk_ImprimirTicket.Location = New System.Drawing.Point(182, 4)
        Me.Chk_ImprimirTicket.Name = "Chk_ImprimirTicket"
        Me.Chk_ImprimirTicket.Size = New System.Drawing.Size(123, 19)
        Me.Chk_ImprimirTicket.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_ImprimirTicket.TabIndex = 0
        Me.Chk_ImprimirTicket.Text = "Imprimir Ticket"
        '
        'Txt_NombreFormato_Ticket
        '
        Me.Txt_NombreFormato_Ticket.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_NombreFormato_Ticket.Border.Class = "TextBoxBorder"
        Me.Txt_NombreFormato_Ticket.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_NombreFormato_Ticket.ButtonCustom.Image = CType(resources.GetObject("Txt_NombreFormato_Ticket.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_NombreFormato_Ticket.ButtonCustom.Visible = True
        Me.Txt_NombreFormato_Ticket.ButtonCustom2.Image = CType(resources.GetObject("Txt_NombreFormato_Ticket.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_NombreFormato_Ticket.ButtonCustom2.Visible = True
        Me.Txt_NombreFormato_Ticket.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_NombreFormato_Ticket.ForeColor = System.Drawing.Color.Black
        Me.Txt_NombreFormato_Ticket.Location = New System.Drawing.Point(3, 130)
        Me.Txt_NombreFormato_Ticket.Name = "Txt_NombreFormato_Ticket"
        Me.Txt_NombreFormato_Ticket.PreventEnterBeep = True
        Me.Txt_NombreFormato_Ticket.Size = New System.Drawing.Size(302, 22)
        Me.Txt_NombreFormato_Ticket.TabIndex = 3
        Me.Txt_NombreFormato_Ticket.WatermarkText = "Nombre de formato"
        '
        'Txt_Impresora_Ticket
        '
        Me.Txt_Impresora_Ticket.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Impresora_Ticket.Border.Class = "TextBoxBorder"
        Me.Txt_Impresora_Ticket.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Impresora_Ticket.ButtonCustom.Image = CType(resources.GetObject("Txt_Impresora_Ticket.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Impresora_Ticket.ButtonCustom.Visible = True
        Me.Txt_Impresora_Ticket.ButtonCustom2.Image = CType(resources.GetObject("Txt_Impresora_Ticket.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Impresora_Ticket.ButtonCustom2.Visible = True
        Me.Txt_Impresora_Ticket.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Impresora_Ticket.ForeColor = System.Drawing.Color.Black
        Me.Txt_Impresora_Ticket.Location = New System.Drawing.Point(3, 82)
        Me.Txt_Impresora_Ticket.Name = "Txt_Impresora_Ticket"
        Me.Txt_Impresora_Ticket.PreventEnterBeep = True
        Me.Txt_Impresora_Ticket.Size = New System.Drawing.Size(302, 22)
        Me.Txt_Impresora_Ticket.TabIndex = 2
        Me.Txt_Impresora_Ticket.WatermarkText = "Nombre de impresora"
        '
        'Frm_Stmp_ConfLocal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 230)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Stmp_ConfLocal"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuiración local SGEM"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_NombreEquipoImprime_Ticket As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_ImprimirTicket As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_NombreFormato_Ticket As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Impresora_Ticket As DevComponents.DotNetBar.Controls.TextBoxX
End Class
