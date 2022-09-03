<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Codigos_Alternativos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Codigos_Alternativos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Crear_Codigo_Alternativo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel_Permisos_Usuario = New DevComponents.DotNetBar.ButtonItem()
        Me.Chk_Ean13 = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Btn_LevantarMasivamente = New DevComponents.DotNetBar.ButtonItem()
        Me.Grupo_Permisos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Permisos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Editar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Usuario_Con_Este_Permiso = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Btn_Grabar_Permisos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Duplicar_Permisos_Usuario_A_Otro = New DevComponents.DotNetBar.ButtonItem()
        Me.ChkSeleccionar = New DevComponents.DotNetBar.CheckBoxItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo_Permisos.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Crear_Codigo_Alternativo, Me.Btn_Exportar_Excel_Permisos_Usuario, Me.Chk_Ean13, Me.Btn_LevantarMasivamente})
        Me.Bar2.Location = New System.Drawing.Point(0, 498)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(726, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 18
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Crear_Codigo_Alternativo
        '
        Me.Btn_Crear_Codigo_Alternativo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_Codigo_Alternativo.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_Codigo_Alternativo.Image = CType(resources.GetObject("Btn_Crear_Codigo_Alternativo.Image"), System.Drawing.Image)
        Me.Btn_Crear_Codigo_Alternativo.ImageAlt = CType(resources.GetObject("Btn_Crear_Codigo_Alternativo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Crear_Codigo_Alternativo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Crear_Codigo_Alternativo.Name = "Btn_Crear_Codigo_Alternativo"
        Me.Btn_Crear_Codigo_Alternativo.Tooltip = "Exportar a Excel "
        '
        'Btn_Exportar_Excel_Permisos_Usuario
        '
        Me.Btn_Exportar_Excel_Permisos_Usuario.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel_Permisos_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel_Permisos_Usuario.Image = CType(resources.GetObject("Btn_Exportar_Excel_Permisos_Usuario.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel_Permisos_Usuario.ImageAlt = CType(resources.GetObject("Btn_Exportar_Excel_Permisos_Usuario.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Excel_Permisos_Usuario.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Exportar_Excel_Permisos_Usuario.Name = "Btn_Exportar_Excel_Permisos_Usuario"
        Me.Btn_Exportar_Excel_Permisos_Usuario.Tooltip = "Exportar a Excel "
        '
        'Chk_Ean13
        '
        Me.Chk_Ean13.Name = "Chk_Ean13"
        Me.Chk_Ean13.Text = "Insertar EAN13"
        '
        'Btn_LevantarMasivamente
        '
        Me.Btn_LevantarMasivamente.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_LevantarMasivamente.ForeColor = System.Drawing.Color.Black
        Me.Btn_LevantarMasivamente.Image = CType(resources.GetObject("Btn_LevantarMasivamente.Image"), System.Drawing.Image)
        Me.Btn_LevantarMasivamente.ImageAlt = CType(resources.GetObject("Btn_LevantarMasivamente.ImageAlt"), System.Drawing.Image)
        Me.Btn_LevantarMasivamente.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_LevantarMasivamente.Name = "Btn_LevantarMasivamente"
        Me.Btn_LevantarMasivamente.Tooltip = "Levantar masivamente códigos alternativos"
        '
        'Grupo_Permisos
        '
        Me.Grupo_Permisos.BackColor = System.Drawing.Color.White
        Me.Grupo_Permisos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_Permisos.Controls.Add(Me.ContextMenuBar1)
        Me.Grupo_Permisos.Controls.Add(Me.Grilla)
        Me.Grupo_Permisos.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_Permisos.Location = New System.Drawing.Point(8, 79)
        Me.Grupo_Permisos.Name = "Grupo_Permisos"
        Me.Grupo_Permisos.Size = New System.Drawing.Size(711, 413)
        '
        '
        '
        Me.Grupo_Permisos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_Permisos.Style.BackColorGradientAngle = 90
        Me.Grupo_Permisos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_Permisos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Permisos.Style.BorderBottomWidth = 1
        Me.Grupo_Permisos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_Permisos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Permisos.Style.BorderLeftWidth = 1
        Me.Grupo_Permisos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Permisos.Style.BorderRightWidth = 1
        Me.Grupo_Permisos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_Permisos.Style.BorderTopWidth = 1
        Me.Grupo_Permisos.Style.CornerDiameter = 4
        Me.Grupo_Permisos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_Permisos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_Permisos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_Permisos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_Permisos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_Permisos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_Permisos.TabIndex = 17
        Me.Grupo_Permisos.Text = "Códigos"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Permisos})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(199, 183)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(306, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 57
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Permisos
        '
        Me.Menu_Contextual_Permisos.AutoExpandOnClick = True
        Me.Menu_Contextual_Permisos.Name = "Menu_Contextual_Permisos"
        Me.Menu_Contextual_Permisos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Editar, Me.Btn_Ver_Usuario_Con_Este_Permiso})
        Me.Menu_Contextual_Permisos.Text = "Opciones productos"
        '
        'Btn_Editar
        '
        Me.Btn_Editar.Image = CType(resources.GetObject("Btn_Editar.Image"), System.Drawing.Image)
        Me.Btn_Editar.ImageAlt = CType(resources.GetObject("Btn_Editar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Text = "Editar"
        '
        'Btn_Ver_Usuario_Con_Este_Permiso
        '
        Me.Btn_Ver_Usuario_Con_Este_Permiso.Image = CType(resources.GetObject("Btn_Ver_Usuario_Con_Este_Permiso.Image"), System.Drawing.Image)
        Me.Btn_Ver_Usuario_Con_Este_Permiso.ImageAlt = CType(resources.GetObject("Btn_Ver_Usuario_Con_Este_Permiso.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_Usuario_Con_Este_Permiso.Name = "Btn_Ver_Usuario_Con_Este_Permiso"
        Me.Btn_Ver_Usuario_Con_Este_Permiso.Text = "Eliminar"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.RowTemplate.Height = 25
        Me.Grilla.Size = New System.Drawing.Size(705, 390)
        Me.Grilla.TabIndex = 55
        '
        'Btn_Grabar_Permisos
        '
        Me.Btn_Grabar_Permisos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar_Permisos.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar_Permisos.Image = CType(resources.GetObject("Btn_Grabar_Permisos.Image"), System.Drawing.Image)
        Me.Btn_Grabar_Permisos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar_Permisos.Name = "Btn_Grabar_Permisos"
        Me.Btn_Grabar_Permisos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Duplicar_Permisos_Usuario_A_Otro})
        Me.Btn_Grabar_Permisos.Tooltip = "Crear  nueva entidad"
        '
        'Btn_Duplicar_Permisos_Usuario_A_Otro
        '
        Me.Btn_Duplicar_Permisos_Usuario_A_Otro.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Duplicar_Permisos_Usuario_A_Otro.ForeColor = System.Drawing.Color.Black
        Me.Btn_Duplicar_Permisos_Usuario_A_Otro.Image = CType(resources.GetObject("Btn_Duplicar_Permisos_Usuario_A_Otro.Image"), System.Drawing.Image)
        Me.Btn_Duplicar_Permisos_Usuario_A_Otro.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Duplicar_Permisos_Usuario_A_Otro.Name = "Btn_Duplicar_Permisos_Usuario_A_Otro"
        Me.Btn_Duplicar_Permisos_Usuario_A_Otro.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ChkSeleccionar})
        Me.Btn_Duplicar_Permisos_Usuario_A_Otro.Tooltip = "Duplicar los permisos de este usuario a otros"
        '
        'ChkSeleccionar
        '
        Me.ChkSeleccionar.Name = "ChkSeleccionar"
        Me.ChkSeleccionar.Text = "Seleccionar todo"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Txt_Descripcion)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(8, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(711, 61)
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
        Me.GroupPanel2.TabIndex = 19
        Me.GroupPanel2.Text = "Buscar producto ingrese algo del código o la descripción del producto"
        '
        'Txt_Descripcion
        '
        Me.Txt_Descripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Descripcion.Border.Class = "TextBoxBorder"
        Me.Txt_Descripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Descripcion.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Txt_Descripcion.Location = New System.Drawing.Point(3, 13)
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.Size = New System.Drawing.Size(699, 22)
        Me.Txt_Descripcion.TabIndex = 0
        '
        'Frm_Codigos_Alternativos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 539)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Grupo_Permisos)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Codigos_Alternativos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CODIGOS DE ACCESO ALTERNATIVO"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo_Permisos.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Exportar_Excel_Permisos_Usuario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grupo_Permisos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Chk_Ean13 As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Btn_Grabar_Permisos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Duplicar_Permisos_Usuario_A_Otro As DevComponents.DotNetBar.ButtonItem
    Public WithEvents ChkSeleccionar As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Btn_Crear_Codigo_Alternativo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_LevantarMasivamente As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Permisos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Editar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ver_Usuario_Con_Este_Permiso As DevComponents.DotNetBar.ButtonItem
End Class
