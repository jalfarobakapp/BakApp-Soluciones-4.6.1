<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Remotas_Espera_Permiso_Solicitado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Remotas_Espera_Permiso_Solicitado))
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.CircularProgressItem1 = New DevComponents.DotNetBar.CircularProgressItem()
        Me.Btn_Permiso_Autorizado = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Permiso_Rechazado = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Estatus = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Usuario_Autoriza = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Permiso_Solicitado = New DevComponents.DotNetBar.LabelX()
        Me.Label1 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Nombre_Solicitante = New DevComponents.DotNetBar.LabelX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.Timer_Revisando_Respuesta = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_respuesta = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.CircularProgressItem1, Me.Btn_Permiso_Autorizado, Me.Btn_Permiso_Rechazado, Me.BtnCancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 177)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(619, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 117
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'CircularProgressItem1
        '
        Me.CircularProgressItem1.Name = "CircularProgressItem1"
        Me.CircularProgressItem1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        '
        'Btn_Permiso_Autorizado
        '
        Me.Btn_Permiso_Autorizado.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Permiso_Autorizado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Btn_Permiso_Autorizado.Image = CType(resources.GetObject("Btn_Permiso_Autorizado.Image"), System.Drawing.Image)
        Me.Btn_Permiso_Autorizado.ImageAlt = CType(resources.GetObject("Btn_Permiso_Autorizado.ImageAlt"), System.Drawing.Image)
        Me.Btn_Permiso_Autorizado.Name = "Btn_Permiso_Autorizado"
        Me.Btn_Permiso_Autorizado.Text = "Autorizado"
        Me.Btn_Permiso_Autorizado.Visible = False
        '
        'Btn_Permiso_Rechazado
        '
        Me.Btn_Permiso_Rechazado.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Permiso_Rechazado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Btn_Permiso_Rechazado.Image = CType(resources.GetObject("Btn_Permiso_Rechazado.Image"), System.Drawing.Image)
        Me.Btn_Permiso_Rechazado.ImageAlt = CType(resources.GetObject("Btn_Permiso_Rechazado.ImageAlt"), System.Drawing.Image)
        Me.Btn_Permiso_Rechazado.Name = "Btn_Permiso_Rechazado"
        Me.Btn_Permiso_Rechazado.Text = "Rechazado"
        Me.Btn_Permiso_Rechazado.Visible = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancelar.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImageAlt = CType(resources.GetObject("BtnCancelar.ImageAlt"), System.Drawing.Image)
        Me.BtnCancelar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Tooltip = "Cancelar"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(595, 142)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 118
        Me.GroupPanel2.Text = "Información del permiso solicitado..."
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.99338!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.00662!))
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX2, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Estatus, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Usuario_Autoriza, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Permiso_Solicitado, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Nombre_Solicitante, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX18, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.LabelX19, 0, 2)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 4
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(581, 111)
        Me.TableLayoutPanel4.TabIndex = 83
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(4, 85)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(144, 22)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 87
        Me.LabelX2.Text = "Estatus"
        '
        'Lbl_Estatus
        '
        Me.Lbl_Estatus.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Estatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Estatus.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estatus.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Estatus.Location = New System.Drawing.Point(155, 85)
        Me.Lbl_Estatus.Name = "Lbl_Estatus"
        Me.Lbl_Estatus.Size = New System.Drawing.Size(359, 22)
        Me.Lbl_Estatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Lbl_Estatus.TabIndex = 86
        Me.Lbl_Estatus.Text = "Esperando respuesta..."
        Me.Lbl_Estatus.Visible = False
        '
        'Lbl_Usuario_Autoriza
        '
        Me.Lbl_Usuario_Autoriza.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Usuario_Autoriza.BackgroundStyle.Class = "RibbonGalleryContainer"
        Me.Lbl_Usuario_Autoriza.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Usuario_Autoriza.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Usuario_Autoriza.Location = New System.Drawing.Point(155, 58)
        Me.Lbl_Usuario_Autoriza.Name = "Lbl_Usuario_Autoriza"
        Me.Lbl_Usuario_Autoriza.Size = New System.Drawing.Size(267, 20)
        Me.Lbl_Usuario_Autoriza.TabIndex = 85
        '
        'Lbl_Permiso_Solicitado
        '
        Me.Lbl_Permiso_Solicitado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Permiso_Solicitado.BackgroundStyle.Class = "RibbonGalleryContainer"
        Me.Lbl_Permiso_Solicitado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Permiso_Solicitado.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Permiso_Solicitado.Location = New System.Drawing.Point(155, 31)
        Me.Lbl_Permiso_Solicitado.Name = "Lbl_Permiso_Solicitado"
        Me.Lbl_Permiso_Solicitado.Size = New System.Drawing.Size(422, 20)
        Me.Lbl_Permiso_Solicitado.TabIndex = 84
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 16)
        Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Usuario que solicita"
        '
        'Lbl_Nombre_Solicitante
        '
        Me.Lbl_Nombre_Solicitante.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Nombre_Solicitante.BackgroundStyle.Class = "RibbonGalleryContainer"
        Me.Lbl_Nombre_Solicitante.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Nombre_Solicitante.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Nombre_Solicitante.Location = New System.Drawing.Point(155, 4)
        Me.Lbl_Nombre_Solicitante.Name = "Lbl_Nombre_Solicitante"
        Me.Lbl_Nombre_Solicitante.Size = New System.Drawing.Size(422, 20)
        Me.Lbl_Nombre_Solicitante.TabIndex = 81
        '
        'LabelX18
        '
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX18.ForeColor = System.Drawing.Color.Black
        Me.LabelX18.Location = New System.Drawing.Point(4, 31)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(144, 16)
        Me.LabelX18.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX18.TabIndex = 61
        Me.LabelX18.Text = "Permiso Solicitado"
        '
        'LabelX19
        '
        Me.LabelX19.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX19.ForeColor = System.Drawing.Color.Black
        Me.LabelX19.Location = New System.Drawing.Point(4, 58)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(144, 17)
        Me.LabelX19.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX19.TabIndex = 59
        Me.LabelX19.Text = "Usuario que autoriza"
        '
        'Timer_Revisando_Respuesta
        '
        Me.Timer_Revisando_Respuesta.Interval = 3000
        '
        'Timer_respuesta
        '
        Me.Timer_respuesta.Interval = 1000
        '
        'Frm_Remotas_Espera_Permiso_Solicitado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 218)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Remotas_Espera_Permiso_Solicitado"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Esperando respuesta remota"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents CircularProgressItem1 As DevComponents.DotNetBar.CircularProgressItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lbl_Usuario_Autoriza As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Permiso_Solicitado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Nombre_Solicitante As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Timer_Revisando_Respuesta As System.Windows.Forms.Timer
    Friend WithEvents Timer_respuesta As System.Windows.Forms.Timer
    Friend WithEvents Lbl_Estatus As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Permiso_Autorizado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Permiso_Rechazado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
End Class
