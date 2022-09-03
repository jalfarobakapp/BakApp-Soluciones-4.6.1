<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Kardex_Procesar_Estudio_X_Producto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Kardex_Procesar_Estudio_X_Producto))
        Me.Grupo_01 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TxtNmov = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.RdbUltNmov = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.RdbTodos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Pri100 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Pri10 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Ult100 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Ult10 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo_02 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.CheckBoxX1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.RdbBodega_todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.RdbBodega_act = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Procesar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Progreso_Kardex = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Progreso_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Progreso_Cont = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Grupo_01.SuspendLayout()
        Me.Grupo_02.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grupo_01
        '
        Me.Grupo_01.BackColor = System.Drawing.Color.White
        Me.Grupo_01.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_01.Controls.Add(Me.TxtNmov)
        Me.Grupo_01.Controls.Add(Me.RdbUltNmov)
        Me.Grupo_01.Controls.Add(Me.RdbTodos)
        Me.Grupo_01.Controls.Add(Me.Rdb_Pri100)
        Me.Grupo_01.Controls.Add(Me.Rdb_Pri10)
        Me.Grupo_01.Controls.Add(Me.Rdb_Ult100)
        Me.Grupo_01.Controls.Add(Me.Rdb_Ult10)
        Me.Grupo_01.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_01.Location = New System.Drawing.Point(7, 12)
        Me.Grupo_01.Name = "Grupo_01"
        Me.Grupo_01.Size = New System.Drawing.Size(241, 203)
        '
        '
        '
        Me.Grupo_01.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_01.Style.BackColorGradientAngle = 90
        Me.Grupo_01.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_01.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_01.Style.BorderBottomWidth = 1
        Me.Grupo_01.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_01.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_01.Style.BorderLeftWidth = 1
        Me.Grupo_01.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_01.Style.BorderRightWidth = 1
        Me.Grupo_01.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_01.Style.BorderTopWidth = 1
        Me.Grupo_01.Style.CornerDiameter = 4
        Me.Grupo_01.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_01.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_01.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_01.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_01.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_01.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_01.TabIndex = 0
        Me.Grupo_01.Text = "Seleccione cantidad de movimientos"
        '
        'TxtNmov
        '
        Me.TxtNmov.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtNmov.Border.Class = "TextBoxBorder"
        Me.TxtNmov.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNmov.DisabledBackColor = System.Drawing.Color.White
        Me.TxtNmov.Enabled = False
        Me.TxtNmov.ForeColor = System.Drawing.Color.Black
        Me.TxtNmov.Location = New System.Drawing.Point(75, 143)
        Me.TxtNmov.Name = "TxtNmov"
        Me.TxtNmov.PreventEnterBeep = True
        Me.TxtNmov.Size = New System.Drawing.Size(86, 22)
        Me.TxtNmov.TabIndex = 7
        Me.TxtNmov.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RdbUltNmov
        '
        Me.RdbUltNmov.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.RdbUltNmov.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RdbUltNmov.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.RdbUltNmov.ForeColor = System.Drawing.Color.Black
        Me.RdbUltNmov.Location = New System.Drawing.Point(3, 142)
        Me.RdbUltNmov.Name = "RdbUltNmov"
        Me.RdbUltNmov.Size = New System.Drawing.Size(66, 23)
        Me.RdbUltNmov.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RdbUltNmov.TabIndex = 6
        Me.RdbUltNmov.Text = "Últimos"
        '
        'RdbTodos
        '
        Me.RdbTodos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.RdbTodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RdbTodos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.RdbTodos.Checked = True
        Me.RdbTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RdbTodos.CheckValue = "Y"
        Me.RdbTodos.ForeColor = System.Drawing.Color.Black
        Me.RdbTodos.Location = New System.Drawing.Point(3, 65)
        Me.RdbTodos.Name = "RdbTodos"
        Me.RdbTodos.Size = New System.Drawing.Size(229, 23)
        Me.RdbTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RdbTodos.TabIndex = 4
        Me.RdbTodos.Text = "Todos los movimientos"
        '
        'Rdb_Pri100
        '
        Me.Rdb_Pri100.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Pri100.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Pri100.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Pri100.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Pri100.Location = New System.Drawing.Point(3, 104)
        Me.Rdb_Pri100.Name = "Rdb_Pri100"
        Me.Rdb_Pri100.Size = New System.Drawing.Size(229, 23)
        Me.Rdb_Pri100.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Pri100.TabIndex = 3
        Me.Rdb_Pri100.Text = "Primeros 100 movimientos"
        '
        'Rdb_Pri10
        '
        Me.Rdb_Pri10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Pri10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Pri10.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Pri10.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Pri10.Location = New System.Drawing.Point(3, 85)
        Me.Rdb_Pri10.Name = "Rdb_Pri10"
        Me.Rdb_Pri10.Size = New System.Drawing.Size(229, 23)
        Me.Rdb_Pri10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Pri10.TabIndex = 2
        Me.Rdb_Pri10.Text = "Primeros 10 movimientos"
        '
        'Rdb_Ult100
        '
        Me.Rdb_Ult100.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Ult100.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Ult100.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ult100.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Ult100.Location = New System.Drawing.Point(3, 45)
        Me.Rdb_Ult100.Name = "Rdb_Ult100"
        Me.Rdb_Ult100.Size = New System.Drawing.Size(229, 23)
        Me.Rdb_Ult100.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Ult100.TabIndex = 1
        Me.Rdb_Ult100.Text = "Últimos 100 movimientos"
        '
        'Rdb_Ult10
        '
        Me.Rdb_Ult10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Ult10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Ult10.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ult10.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Ult10.Location = New System.Drawing.Point(3, 25)
        Me.Rdb_Ult10.Name = "Rdb_Ult10"
        Me.Rdb_Ult10.Size = New System.Drawing.Size(229, 23)
        Me.Rdb_Ult10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Ult10.TabIndex = 0
        Me.Rdb_Ult10.Text = "Últimos 10 movimientos"
        '
        'Grupo_02
        '
        Me.Grupo_02.BackColor = System.Drawing.Color.White
        Me.Grupo_02.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo_02.Controls.Add(Me.CheckBoxX1)
        Me.Grupo_02.Controls.Add(Me.RdbBodega_todas)
        Me.Grupo_02.Controls.Add(Me.RdbBodega_act)
        Me.Grupo_02.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo_02.Location = New System.Drawing.Point(7, 221)
        Me.Grupo_02.Name = "Grupo_02"
        Me.Grupo_02.Size = New System.Drawing.Size(240, 100)
        '
        '
        '
        Me.Grupo_02.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo_02.Style.BackColorGradientAngle = 90
        Me.Grupo_02.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo_02.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_02.Style.BorderBottomWidth = 1
        Me.Grupo_02.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo_02.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_02.Style.BorderLeftWidth = 1
        Me.Grupo_02.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_02.Style.BorderRightWidth = 1
        Me.Grupo_02.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo_02.Style.BorderTopWidth = 1
        Me.Grupo_02.Style.CornerDiameter = 4
        Me.Grupo_02.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo_02.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo_02.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo_02.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo_02.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo_02.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo_02.TabIndex = 1
        Me.Grupo_02.Text = "Bodegas"
        '
        'CheckBoxX1
        '
        Me.CheckBoxX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CheckBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.CheckBoxX1.Enabled = False
        Me.CheckBoxX1.ForeColor = System.Drawing.Color.Black
        Me.CheckBoxX1.Location = New System.Drawing.Point(3, 47)
        Me.CheckBoxX1.Name = "CheckBoxX1"
        Me.CheckBoxX1.Size = New System.Drawing.Size(229, 23)
        Me.CheckBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX1.TabIndex = 7
        Me.CheckBoxX1.Text = "Algunas bodegas de la sucursal"
        '
        'RdbBodega_todas
        '
        Me.RdbBodega_todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.RdbBodega_todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RdbBodega_todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.RdbBodega_todas.Enabled = False
        Me.RdbBodega_todas.ForeColor = System.Drawing.Color.Black
        Me.RdbBodega_todas.Location = New System.Drawing.Point(3, 27)
        Me.RdbBodega_todas.Name = "RdbBodega_todas"
        Me.RdbBodega_todas.Size = New System.Drawing.Size(229, 23)
        Me.RdbBodega_todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RdbBodega_todas.TabIndex = 6
        Me.RdbBodega_todas.Text = "Todas las bodegas"
        '
        'RdbBodega_act
        '
        Me.RdbBodega_act.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.RdbBodega_act.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RdbBodega_act.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.RdbBodega_act.Checked = True
        Me.RdbBodega_act.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RdbBodega_act.CheckValue = "Y"
        Me.RdbBodega_act.ForeColor = System.Drawing.Color.Black
        Me.RdbBodega_act.Location = New System.Drawing.Point(3, 7)
        Me.RdbBodega_act.Name = "RdbBodega_act"
        Me.RdbBodega_act.Size = New System.Drawing.Size(229, 23)
        Me.RdbBodega_act.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RdbBodega_act.TabIndex = 5
        Me.RdbBodega_act.Text = "Bodega actual"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Procesar, Me.Btn_Cancelar})
        Me.Bar2.Location = New System.Drawing.Point(0, 401)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(258, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 41
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Procesar
        '
        Me.Btn_Procesar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Procesar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Btn_Procesar.Image = CType(resources.GetObject("Btn_Procesar.Image"), System.Drawing.Image)
        Me.Btn_Procesar.ImageAlt = CType(resources.GetObject("Btn_Procesar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Procesar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.Btn_Procesar.Name = "Btn_Procesar"
        Me.Btn_Procesar.Text = "Procesar"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.Enabled = False
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ImageAlt = CType(resources.GetObject("Btn_Cancelar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.Visible = False
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Progreso_Kardex)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(7, 327)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(241, 57)
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
        Me.GroupPanel3.TabIndex = 42
        Me.GroupPanel3.Text = "Proceso..."
        '
        'Progreso_Kardex
        '
        Me.Progreso_Kardex.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Kardex.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Kardex.ForeColor = System.Drawing.Color.Black
        Me.Progreso_Kardex.Location = New System.Drawing.Point(3, 4)
        Me.Progreso_Kardex.Name = "Progreso_Kardex"
        Me.Progreso_Kardex.Size = New System.Drawing.Size(229, 23)
        Me.Progreso_Kardex.TabIndex = 33
        Me.Progreso_Kardex.Text = "%"
        Me.Progreso_Kardex.TextVisible = True
        '
        'Progreso_Porc
        '
        Me.Progreso_Porc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Porc.Location = New System.Drawing.Point(289, 308)
        Me.Progreso_Porc.Name = "Progreso_Porc"
        Me.Progreso_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Porc.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Porc.ProgressTextVisible = True
        Me.Progreso_Porc.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Porc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Porc.TabIndex = 32
        '
        'Progreso_Cont
        '
        Me.Progreso_Cont.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Cont.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Cont.Location = New System.Drawing.Point(277, 221)
        Me.Progreso_Cont.Name = "Progreso_Cont"
        Me.Progreso_Cont.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Cont.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Cont.ProgressTextFormat = "{0}"
        Me.Progreso_Cont.ProgressTextVisible = True
        Me.Progreso_Cont.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Cont.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Cont.TabIndex = 31
        '
        'Frm_Kardex_Procesar_Estudio_X_Producto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(258, 442)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.Progreso_Cont)
        Me.Controls.Add(Me.Progreso_Porc)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Grupo_02)
        Me.Controls.Add(Me.Grupo_01)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Kardex_Procesar_Estudio_X_Producto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kargex por producto"
        Me.Grupo_01.ResumeLayout(False)
        Me.Grupo_02.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grupo_01 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_Ult10 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents RdbUltNmov As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents RdbTodos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Pri100 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Pri10 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Ult100 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TxtNmov As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Grupo_02 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Procesar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents CheckBoxX1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents RdbBodega_todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents RdbBodega_act As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Progreso_Kardex As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Progreso_Cont As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
End Class
