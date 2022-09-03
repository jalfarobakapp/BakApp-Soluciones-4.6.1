<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cashdro_Pago_Nota_de_credito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cashdro_Pago_Nota_de_credito))
        Me.Lbl_Seleccion_Pago = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Cancelar_Operacion = New DevComponents.DotNetBar.ButtonItem()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.Btn_Efectivo = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Btn_Usar_NCV = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.Lbl_Total_A_Pagar = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Documento = New DevComponents.DotNetBar.LabelX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Lbl_Seleccion_Pago.Location = New System.Drawing.Point(212, 160)
        Me.Lbl_Seleccion_Pago.Name = "Lbl_Seleccion_Pago"
        Me.Lbl_Seleccion_Pago.Size = New System.Drawing.Size(254, 34)
        Me.Lbl_Seleccion_Pago.TabIndex = 38
        Me.Lbl_Seleccion_Pago.Text = "<b><font color=""#349FCE"">SELECCIONE SU OPCION</font></b>  "
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Cancelar_Operacion})
        Me.Bar2.Location = New System.Drawing.Point(0, 447)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(658, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 37
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
        Me.MetroTilePanel1.Location = New System.Drawing.Point(12, 200)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(699, 332)
        Me.MetroTilePanel1.TabIndex = 36
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.FixedSize = New System.Drawing.Size(650, 300)
        Me.ItemContainer1.MultiLine = True
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Efectivo, Me.Btn_Usar_NCV})
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
        Me.Btn_Efectivo.Text = "<font size=""28""><b>DEVOLUCION EFECTIVO</b></font><br/>"
        Me.Btn_Efectivo.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.Btn_Efectivo.TileSize = New System.Drawing.Size(300, 200)
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
        'Btn_Usar_NCV
        '
        Me.Btn_Usar_NCV.Image = CType(resources.GetObject("Btn_Usar_NCV.Image"), System.Drawing.Image)
        Me.Btn_Usar_NCV.ImageIndent = New System.Drawing.Point(9, -10)
        Me.Btn_Usar_NCV.ImageTextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.Btn_Usar_NCV.Name = "Btn_Usar_NCV"
        Me.Btn_Usar_NCV.SymbolColor = System.Drawing.Color.Empty
        Me.Btn_Usar_NCV.Text = "<font size=""28""><b>USAR NOTA DE CREDITO</b></font><br/>"
        Me.Btn_Usar_NCV.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Olive
        Me.Btn_Usar_NCV.TileSize = New System.Drawing.Size(300, 200)
        '
        '
        '
        Me.Btn_Usar_NCV.TileStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Usar_NCV.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Usar_NCV.TileStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Usar_NCV.TileStyle.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.Btn_Usar_NCV.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Btn_Usar_NCV.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
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
        Me.Lbl_Total_A_Pagar.Location = New System.Drawing.Point(54, 70)
        Me.Lbl_Total_A_Pagar.Name = "Lbl_Total_A_Pagar"
        Me.Lbl_Total_A_Pagar.Size = New System.Drawing.Size(524, 64)
        Me.Lbl_Total_A_Pagar.TabIndex = 35
        Me.Lbl_Total_A_Pagar.Text = "<b><font color=""#349FCE"">SALDO A FAVOR</font></b>  <b>$ 999.999.999</b>"
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
        Me.Lbl_Documento.Location = New System.Drawing.Point(173, 12)
        Me.Lbl_Documento.Name = "Lbl_Documento"
        Me.Lbl_Documento.Size = New System.Drawing.Size(351, 69)
        Me.Lbl_Documento.TabIndex = 34
        Me.Lbl_Documento.Text = "<b><font color=""#349FCE"">DOCUMENTO</font></b>  <b>9999999999</b>"
        '
        'Frm_Cashdro_Pago_Nota_de_credito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 488)
        Me.Controls.Add(Me.Lbl_Seleccion_Pago)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.MetroTilePanel1)
        Me.Controls.Add(Me.Lbl_Total_A_Pagar)
        Me.Controls.Add(Me.Lbl_Documento)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cashdro_Pago_Nota_de_credito"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Revisión de Nota de crédito"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lbl_Seleccion_Pago As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Cancelar_Operacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Private WithEvents Btn_Efectivo As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents Btn_Usar_NCV As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Lbl_Total_A_Pagar As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Documento As DevComponents.DotNetBar.LabelX
End Class
