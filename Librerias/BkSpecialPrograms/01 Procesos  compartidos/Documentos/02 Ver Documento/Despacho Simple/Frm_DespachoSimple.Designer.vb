<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DespachoSimple
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_DespachoSimple))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_TipoDespacho = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_DireccionDesp = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_TransporteDesp = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_TipoPagoDesp = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_DocDestino = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Txt_DocDestino)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.Txt_TipoPagoDesp)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.Txt_TransporteDesp)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.Txt_DireccionDesp)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Txt_TipoDespacho)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(7, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(591, 194)
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
        Me.GroupPanel1.TabIndex = 0
        Me.GroupPanel1.Text = "Datos del despacho"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(18, 19)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(134, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "TIPO DESPACHO"
        '
        'Txt_TipoDespacho
        '
        Me.Txt_TipoDespacho.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_TipoDespacho.Border.Class = "TextBoxBorder"
        Me.Txt_TipoDespacho.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_TipoDespacho.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_TipoDespacho.ForeColor = System.Drawing.Color.Black
        Me.Txt_TipoDespacho.Location = New System.Drawing.Point(118, 19)
        Me.Txt_TipoDespacho.Name = "Txt_TipoDespacho"
        Me.Txt_TipoDespacho.PreventEnterBeep = True
        Me.Txt_TipoDespacho.ReadOnly = True
        Me.Txt_TipoDespacho.Size = New System.Drawing.Size(453, 22)
        Me.Txt_TipoDespacho.TabIndex = 1
        '
        'Txt_DireccionDesp
        '
        Me.Txt_DireccionDesp.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_DireccionDesp.Border.Class = "TextBoxBorder"
        Me.Txt_DireccionDesp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_DireccionDesp.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_DireccionDesp.ForeColor = System.Drawing.Color.Black
        Me.Txt_DireccionDesp.Location = New System.Drawing.Point(118, 48)
        Me.Txt_DireccionDesp.Name = "Txt_DireccionDesp"
        Me.Txt_DireccionDesp.PreventEnterBeep = True
        Me.Txt_DireccionDesp.ReadOnly = True
        Me.Txt_DireccionDesp.Size = New System.Drawing.Size(453, 22)
        Me.Txt_DireccionDesp.TabIndex = 3
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(18, 48)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(134, 23)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "DIRECCION"
        '
        'Txt_TransporteDesp
        '
        Me.Txt_TransporteDesp.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_TransporteDesp.Border.Class = "TextBoxBorder"
        Me.Txt_TransporteDesp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_TransporteDesp.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_TransporteDesp.ForeColor = System.Drawing.Color.Black
        Me.Txt_TransporteDesp.Location = New System.Drawing.Point(118, 77)
        Me.Txt_TransporteDesp.Name = "Txt_TransporteDesp"
        Me.Txt_TransporteDesp.PreventEnterBeep = True
        Me.Txt_TransporteDesp.ReadOnly = True
        Me.Txt_TransporteDesp.Size = New System.Drawing.Size(453, 22)
        Me.Txt_TransporteDesp.TabIndex = 5
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(18, 77)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(134, 23)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "TRANSPORTE"
        '
        'Txt_TipoPagoDesp
        '
        Me.Txt_TipoPagoDesp.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_TipoPagoDesp.Border.Class = "TextBoxBorder"
        Me.Txt_TipoPagoDesp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_TipoPagoDesp.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_TipoPagoDesp.ForeColor = System.Drawing.Color.Black
        Me.Txt_TipoPagoDesp.Location = New System.Drawing.Point(118, 106)
        Me.Txt_TipoPagoDesp.Name = "Txt_TipoPagoDesp"
        Me.Txt_TipoPagoDesp.PreventEnterBeep = True
        Me.Txt_TipoPagoDesp.ReadOnly = True
        Me.Txt_TipoPagoDesp.Size = New System.Drawing.Size(453, 22)
        Me.Txt_TipoPagoDesp.TabIndex = 7
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(18, 106)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(134, 23)
        Me.LabelX4.TabIndex = 6
        Me.LabelX4.Text = "TIPO DE PAGO"
        '
        'Txt_DocDestino
        '
        Me.Txt_DocDestino.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_DocDestino.Border.Class = "TextBoxBorder"
        Me.Txt_DocDestino.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_DocDestino.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_DocDestino.ForeColor = System.Drawing.Color.Black
        Me.Txt_DocDestino.Location = New System.Drawing.Point(118, 135)
        Me.Txt_DocDestino.Name = "Txt_DocDestino"
        Me.Txt_DocDestino.PreventEnterBeep = True
        Me.Txt_DocDestino.ReadOnly = True
        Me.Txt_DocDestino.Size = New System.Drawing.Size(453, 22)
        Me.Txt_DocDestino.TabIndex = 9
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(18, 135)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(134, 23)
        Me.LabelX5.TabIndex = 8
        Me.LabelX5.Text = "DOC. DESTINO"
        '
        'Frm_DespachoSimple
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 216)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_DespachoSimple"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INFORMACION DE DESPACHO SIMPLE"
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Txt_DocDestino As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_TipoPagoDesp As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_TransporteDesp As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_DireccionDesp As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_TipoDespacho As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
