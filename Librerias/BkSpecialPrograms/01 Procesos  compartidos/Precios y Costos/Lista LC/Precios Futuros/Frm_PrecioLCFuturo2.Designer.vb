<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PrecioLCFuturo2
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PrecioLCFuturo2))
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_ListaLc = New DevComponents.DotNetBar.ButtonItem()
        Me.Btnimprimir = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnActualizarLista = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Grabar_Programacion = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.CmbEtiqueta = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.CmbPuerto = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Chk_Marcar_todo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_Lista_Precios = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.CmbLista = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Btn_CambiarLista = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.Grupo_Lista_Precios.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Grilla)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(867, 409)
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
        Me.GroupPanel2.TabIndex = 65
        Me.GroupPanel2.Text = "Productos programados para cambio de precios a futuro"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(861, 386)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 28
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_ListaLc, Me.Btnimprimir, Me.Btn_Eliminar, Me.BtnActualizarLista, Me.Btn_Grabar_Programacion})
        Me.Bar1.Location = New System.Drawing.Point(0, 518)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(890, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 67
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_ListaLc
        '
        Me.Btn_ListaLc.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ListaLc.ForeColor = System.Drawing.Color.Black
        Me.Btn_ListaLc.Image = CType(resources.GetObject("Btn_ListaLc.Image"), System.Drawing.Image)
        Me.Btn_ListaLc.ImageAlt = CType(resources.GetObject("Btn_ListaLc.ImageAlt"), System.Drawing.Image)
        Me.Btn_ListaLc.Name = "Btn_ListaLc"
        Me.Btn_ListaLc.Tooltip = "Mantención de listas LC"
        '
        'Btnimprimir
        '
        Me.Btnimprimir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btnimprimir.ForeColor = System.Drawing.Color.Black
        Me.Btnimprimir.Image = CType(resources.GetObject("Btnimprimir.Image"), System.Drawing.Image)
        Me.Btnimprimir.ImageAlt = CType(resources.GetObject("Btnimprimir.ImageAlt"), System.Drawing.Image)
        Me.Btnimprimir.Name = "Btnimprimir"
        Me.Btnimprimir.Text = "Imprimir flejes"
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Eliminar programación"
        Me.Btn_Eliminar.Visible = False
        '
        'BtnActualizarLista
        '
        Me.BtnActualizarLista.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnActualizarLista.ForeColor = System.Drawing.Color.Black
        Me.BtnActualizarLista.Image = CType(resources.GetObject("BtnActualizarLista.Image"), System.Drawing.Image)
        Me.BtnActualizarLista.ImageAlt = CType(resources.GetObject("BtnActualizarLista.ImageAlt"), System.Drawing.Image)
        Me.BtnActualizarLista.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnActualizarLista.Name = "BtnActualizarLista"
        Me.BtnActualizarLista.Tooltip = "Actualizar (F5)"
        '
        'Btn_Grabar_Programacion
        '
        Me.Btn_Grabar_Programacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar_Programacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar_Programacion.Image = CType(resources.GetObject("Btn_Grabar_Programacion.Image"), System.Drawing.Image)
        Me.Btn_Grabar_Programacion.ImageAlt = CType(resources.GetObject("Btn_Grabar_Programacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar_Programacion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar_Programacion.Name = "Btn_Grabar_Programacion"
        Me.Btn_Grabar_Programacion.Tooltip = "Actualizar precios según programación"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.CmbEtiqueta)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 452)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(468, 50)
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
        Me.GroupPanel3.TabIndex = 70
        Me.GroupPanel3.Text = "Etiqueta"
        '
        'CmbEtiqueta
        '
        Me.CmbEtiqueta.DisplayMember = "Text"
        Me.CmbEtiqueta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbEtiqueta.ForeColor = System.Drawing.Color.Black
        Me.CmbEtiqueta.FormattingEnabled = True
        Me.CmbEtiqueta.ItemHeight = 16
        Me.CmbEtiqueta.Location = New System.Drawing.Point(3, 2)
        Me.CmbEtiqueta.Name = "CmbEtiqueta"
        Me.CmbEtiqueta.Size = New System.Drawing.Size(456, 22)
        Me.CmbEtiqueta.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.CmbEtiqueta.TabIndex = 74
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.CmbPuerto)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(486, 452)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(108, 50)
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
        Me.GroupPanel1.TabIndex = 71
        Me.GroupPanel1.Text = "Puerto salida"
        '
        'CmbPuerto
        '
        Me.CmbPuerto.DisplayMember = "Text"
        Me.CmbPuerto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbPuerto.ForeColor = System.Drawing.Color.Black
        Me.CmbPuerto.FormattingEnabled = True
        Me.CmbPuerto.ItemHeight = 16
        Me.CmbPuerto.Location = New System.Drawing.Point(3, 3)
        Me.CmbPuerto.Name = "CmbPuerto"
        Me.CmbPuerto.Size = New System.Drawing.Size(95, 22)
        Me.CmbPuerto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbPuerto.TabIndex = 0
        '
        'Chk_Marcar_todo
        '
        Me.Chk_Marcar_todo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Marcar_todo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Marcar_todo.CheckBoxImageChecked = CType(resources.GetObject("Chk_Marcar_todo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Marcar_todo.FocusCuesEnabled = False
        Me.Chk_Marcar_todo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Marcar_todo.Location = New System.Drawing.Point(12, 429)
        Me.Chk_Marcar_todo.Name = "Chk_Marcar_todo"
        Me.Chk_Marcar_todo.Size = New System.Drawing.Size(85, 17)
        Me.Chk_Marcar_todo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Marcar_todo.TabIndex = 72
        Me.Chk_Marcar_todo.Text = "Marcar todo"
        '
        'Grupo_Lista_Precios
        '
        Me.Grupo_Lista_Precios.BackColor = System.Drawing.Color.White
        Me.Grupo_Lista_Precios.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Lista_Precios.Controls.Add(Me.Btn_CambiarLista)
        Me.Grupo_Lista_Precios.Controls.Add(Me.CmbLista)
        Me.Grupo_Lista_Precios.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Lista_Precios.Location = New System.Drawing.Point(600, 452)
        Me.Grupo_Lista_Precios.Name = "Grupo_Lista_Precios"
        Me.Grupo_Lista_Precios.Size = New System.Drawing.Size(279, 50)
        '
        '
        '
        Me.Grupo_Lista_Precios.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Lista_Precios.Style.BackColorGradientAngle = 90
        Me.Grupo_Lista_Precios.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Lista_Precios.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Lista_Precios.Style.BorderBottomWidth = 1
        Me.Grupo_Lista_Precios.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Lista_Precios.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Lista_Precios.Style.BorderLeftWidth = 1
        Me.Grupo_Lista_Precios.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Lista_Precios.Style.BorderRightWidth = 1
        Me.Grupo_Lista_Precios.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Lista_Precios.Style.BorderTopWidth = 1
        Me.Grupo_Lista_Precios.Style.CornerDiameter = 4
        Me.Grupo_Lista_Precios.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Lista_Precios.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Lista_Precios.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Lista_Precios.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Lista_Precios.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Lista_Precios.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Lista_Precios.TabIndex = 73
        Me.Grupo_Lista_Precios.Text = "Lista de precios"
        '
        'CmbLista
        '
        Me.CmbLista.DisplayMember = "Text"
        Me.CmbLista.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbLista.ForeColor = System.Drawing.Color.Black
        Me.CmbLista.FormattingEnabled = True
        Me.CmbLista.ItemHeight = 16
        Me.CmbLista.Location = New System.Drawing.Point(3, 2)
        Me.CmbLista.Name = "CmbLista"
        Me.CmbLista.Size = New System.Drawing.Size(238, 22)
        Me.CmbLista.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbLista.TabIndex = 75
        '
        'Btn_CambiarLista
        '
        Me.Btn_CambiarLista.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_CambiarLista.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_CambiarLista.Image = CType(resources.GetObject("Btn_CambiarLista.Image"), System.Drawing.Image)
        Me.Btn_CambiarLista.ImageAlt = CType(resources.GetObject("Btn_CambiarLista.ImageAlt"), System.Drawing.Image)
        Me.Btn_CambiarLista.Location = New System.Drawing.Point(245, 2)
        Me.Btn_CambiarLista.Name = "Btn_CambiarLista"
        Me.Btn_CambiarLista.Size = New System.Drawing.Size(25, 22)
        Me.Btn_CambiarLista.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_CambiarLista.TabIndex = 76
        Me.Btn_CambiarLista.Tooltip = "Cambiar lista de precios"
        '
        'Frm_PrecioLCFuturo2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 559)
        Me.Controls.Add(Me.Grupo_Lista_Precios)
        Me.Controls.Add(Me.Chk_Marcar_todo)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_PrecioLCFuturo2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PRECIOS PROGRAMADOS A FUTURO"
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.Grupo_Lista_Precios.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_ListaLc As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btnimprimir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents CmbEtiqueta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents CmbPuerto As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Chk_Marcar_todo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Grupo_Lista_Precios As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents CmbLista As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents BtnActualizarLista As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Grabar_Programacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_CambiarLista As DevComponents.DotNetBar.ButtonX
End Class
