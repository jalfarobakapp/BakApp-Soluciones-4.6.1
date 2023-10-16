<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Tickets_Mant
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Tickets_Mant))
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Agente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Grupo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Tipo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Area = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Line2 = New DevComponents.DotNetBar.Controls.Line()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Chk_Asignar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_AsignadoFuncionario = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Asunto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Prioridad = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Rdb_AsignadoGrupo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Txt_CodFuncionario_Crea = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Eliminar = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Txt_Agente)
        Me.GroupPanel2.Controls.Add(Me.Txt_Grupo)
        Me.GroupPanel2.Controls.Add(Me.Txt_Tipo)
        Me.GroupPanel2.Controls.Add(Me.Txt_Area)
        Me.GroupPanel2.Controls.Add(Me.Line2)
        Me.GroupPanel2.Controls.Add(Me.Line1)
        Me.GroupPanel2.Controls.Add(Me.Chk_Asignar)
        Me.GroupPanel2.Controls.Add(Me.Rdb_AsignadoFuncionario)
        Me.GroupPanel2.Controls.Add(Me.LabelX6)
        Me.GroupPanel2.Controls.Add(Me.Txt_Descripcion)
        Me.GroupPanel2.Controls.Add(Me.LabelX5)
        Me.GroupPanel2.Controls.Add(Me.LabelX4)
        Me.GroupPanel2.Controls.Add(Me.Txt_Asunto)
        Me.GroupPanel2.Controls.Add(Me.LabelX3)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.Cmb_Prioridad)
        Me.GroupPanel2.Controls.Add(Me.Rdb_AsignadoGrupo)
        Me.GroupPanel2.Controls.Add(Me.Txt_CodFuncionario_Crea)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 3)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(560, 433)
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
        Me.GroupPanel2.TabIndex = 165
        Me.GroupPanel2.Text = "Datos del ticket"
        '
        'Txt_Agente
        '
        Me.Txt_Agente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Agente.Border.Class = "TextBoxBorder"
        Me.Txt_Agente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Agente.ButtonCustom.Image = CType(resources.GetObject("Txt_Agente.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Agente.ButtonCustom.Visible = True
        Me.Txt_Agente.ButtonCustom2.Image = CType(resources.GetObject("Txt_Agente.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Agente.ButtonCustom2.Visible = True
        Me.Txt_Agente.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Agente.ForeColor = System.Drawing.Color.Black
        Me.Txt_Agente.Location = New System.Drawing.Point(146, 222)
        Me.Txt_Agente.Name = "Txt_Agente"
        Me.Txt_Agente.PreventEnterBeep = True
        Me.Txt_Agente.ReadOnly = True
        Me.Txt_Agente.Size = New System.Drawing.Size(291, 22)
        Me.Txt_Agente.TabIndex = 9
        '
        'Txt_Grupo
        '
        Me.Txt_Grupo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Grupo.Border.Class = "TextBoxBorder"
        Me.Txt_Grupo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Grupo.ButtonCustom.Image = CType(resources.GetObject("Txt_Grupo.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Grupo.ButtonCustom.Visible = True
        Me.Txt_Grupo.ButtonCustom2.Image = CType(resources.GetObject("Txt_Grupo.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Grupo.ButtonCustom2.Visible = True
        Me.Txt_Grupo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Grupo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Grupo.Location = New System.Drawing.Point(146, 193)
        Me.Txt_Grupo.Name = "Txt_Grupo"
        Me.Txt_Grupo.PreventEnterBeep = True
        Me.Txt_Grupo.ReadOnly = True
        Me.Txt_Grupo.Size = New System.Drawing.Size(291, 22)
        Me.Txt_Grupo.TabIndex = 7
        '
        'Txt_Tipo
        '
        Me.Txt_Tipo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Tipo.Border.Class = "TextBoxBorder"
        Me.Txt_Tipo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Tipo.ButtonCustom.Image = CType(resources.GetObject("Txt_Tipo.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Tipo.ButtonCustom.Visible = True
        Me.Txt_Tipo.ButtonCustom2.Image = CType(resources.GetObject("Txt_Tipo.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Tipo.ButtonCustom2.Visible = True
        Me.Txt_Tipo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Tipo.ForeColor = System.Drawing.Color.Black
        Me.Txt_Tipo.Location = New System.Drawing.Point(89, 121)
        Me.Txt_Tipo.Name = "Txt_Tipo"
        Me.Txt_Tipo.PreventEnterBeep = True
        Me.Txt_Tipo.ReadOnly = True
        Me.Txt_Tipo.Size = New System.Drawing.Size(291, 22)
        Me.Txt_Tipo.TabIndex = 4
        '
        'Txt_Area
        '
        Me.Txt_Area.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Area.Border.Class = "TextBoxBorder"
        Me.Txt_Area.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Area.ButtonCustom.Image = CType(resources.GetObject("Txt_Area.ButtonCustom.Image"), System.Drawing.Image)
        Me.Txt_Area.ButtonCustom.Visible = True
        Me.Txt_Area.ButtonCustom2.Image = CType(resources.GetObject("Txt_Area.ButtonCustom2.Image"), System.Drawing.Image)
        Me.Txt_Area.ButtonCustom2.Visible = True
        Me.Txt_Area.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Area.ForeColor = System.Drawing.Color.Black
        Me.Txt_Area.Location = New System.Drawing.Point(89, 92)
        Me.Txt_Area.Name = "Txt_Area"
        Me.Txt_Area.PreventEnterBeep = True
        Me.Txt_Area.ReadOnly = True
        Me.Txt_Area.Size = New System.Drawing.Size(291, 22)
        Me.Txt_Area.TabIndex = 3
        '
        'Line2
        '
        Me.Line2.BackColor = System.Drawing.Color.Transparent
        Me.Line2.ForeColor = System.Drawing.Color.Black
        Me.Line2.Location = New System.Drawing.Point(3, 245)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(377, 23)
        Me.Line2.TabIndex = 57
        Me.Line2.Text = "Line2"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.Transparent
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.Location = New System.Drawing.Point(3, 147)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(377, 23)
        Me.Line1.TabIndex = 56
        Me.Line1.Text = "Line1"
        '
        'Chk_Asignar
        '
        Me.Chk_Asignar.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Asignar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Asignar.CheckBoxImageChecked = CType(resources.GetObject("Chk_Asignar.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Asignar.FocusCuesEnabled = False
        Me.Chk_Asignar.ForeColor = System.Drawing.Color.Black
        Me.Chk_Asignar.Location = New System.Drawing.Point(3, 165)
        Me.Chk_Asignar.Name = "Chk_Asignar"
        Me.Chk_Asignar.Size = New System.Drawing.Size(125, 22)
        Me.Chk_Asignar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Asignar.TabIndex = 5
        Me.Chk_Asignar.TabStop = False
        Me.Chk_Asignar.Text = "ASIGNAR EL TICKET"
        '
        'Rdb_AsignadoFuncionario
        '
        Me.Rdb_AsignadoFuncionario.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_AsignadoFuncionario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_AsignadoFuncionario.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_AsignadoFuncionario.FocusCuesEnabled = False
        Me.Rdb_AsignadoFuncionario.ForeColor = System.Drawing.Color.Black
        Me.Rdb_AsignadoFuncionario.Location = New System.Drawing.Point(3, 221)
        Me.Rdb_AsignadoFuncionario.Name = "Rdb_AsignadoFuncionario"
        Me.Rdb_AsignadoFuncionario.Size = New System.Drawing.Size(137, 23)
        Me.Rdb_AsignadoFuncionario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_AsignadoFuncionario.TabIndex = 8
        Me.Rdb_AsignadoFuncionario.Text = "Asignar a un agente"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(3, 274)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(80, 23)
        Me.LabelX6.TabIndex = 51
        Me.LabelX6.Text = "Descripción"
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
        Me.Txt_Descripcion.Location = New System.Drawing.Point(3, 303)
        Me.Txt_Descripcion.MaxLength = 200
        Me.Txt_Descripcion.Multiline = True
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.PreventEnterBeep = True
        Me.Txt_Descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Descripcion.Size = New System.Drawing.Size(548, 104)
        Me.Txt_Descripcion.TabIndex = 10
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(3, 118)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(80, 23)
        Me.LabelX5.TabIndex = 49
        Me.LabelX5.Text = "Tipo"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(3, 89)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(80, 23)
        Me.LabelX4.TabIndex = 47
        Me.LabelX4.Text = "Area"
        '
        'Txt_Asunto
        '
        Me.Txt_Asunto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Asunto.Border.Class = "TextBoxBorder"
        Me.Txt_Asunto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Asunto.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Asunto.ForeColor = System.Drawing.Color.Black
        Me.Txt_Asunto.Location = New System.Drawing.Point(89, 32)
        Me.Txt_Asunto.MaxLength = 30
        Me.Txt_Asunto.Name = "Txt_Asunto"
        Me.Txt_Asunto.PreventEnterBeep = True
        Me.Txt_Asunto.Size = New System.Drawing.Size(462, 22)
        Me.Txt_Asunto.TabIndex = 1
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(3, 31)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(80, 23)
        Me.LabelX3.TabIndex = 45
        Me.LabelX3.Text = "Asunto"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 60)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(80, 23)
        Me.LabelX2.TabIndex = 44
        Me.LabelX2.Text = "Prioridad"
        '
        'Cmb_Prioridad
        '
        Me.Cmb_Prioridad.DisplayMember = "Text"
        Me.Cmb_Prioridad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Prioridad.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Cmb_Prioridad.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Prioridad.ItemHeight = 16
        Me.Cmb_Prioridad.Location = New System.Drawing.Point(89, 61)
        Me.Cmb_Prioridad.Name = "Cmb_Prioridad"
        Me.Cmb_Prioridad.Size = New System.Drawing.Size(137, 22)
        Me.Cmb_Prioridad.TabIndex = 2
        '
        'Rdb_AsignadoGrupo
        '
        Me.Rdb_AsignadoGrupo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_AsignadoGrupo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_AsignadoGrupo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_AsignadoGrupo.FocusCuesEnabled = False
        Me.Rdb_AsignadoGrupo.ForeColor = System.Drawing.Color.Black
        Me.Rdb_AsignadoGrupo.Location = New System.Drawing.Point(3, 193)
        Me.Rdb_AsignadoGrupo.Name = "Rdb_AsignadoGrupo"
        Me.Rdb_AsignadoGrupo.Size = New System.Drawing.Size(125, 23)
        Me.Rdb_AsignadoGrupo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_AsignadoGrupo.TabIndex = 6
        Me.Rdb_AsignadoGrupo.Text = "Asignar a un grupo"
        '
        'Txt_CodFuncionario_Crea
        '
        Me.Txt_CodFuncionario_Crea.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CodFuncionario_Crea.Border.Class = "TextBoxBorder"
        Me.Txt_CodFuncionario_Crea.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CodFuncionario_Crea.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CodFuncionario_Crea.ForeColor = System.Drawing.Color.Black
        Me.Txt_CodFuncionario_Crea.Location = New System.Drawing.Point(89, 4)
        Me.Txt_CodFuncionario_Crea.MaxLength = 30
        Me.Txt_CodFuncionario_Crea.Name = "Txt_CodFuncionario_Crea"
        Me.Txt_CodFuncionario_Crea.PreventEnterBeep = True
        Me.Txt_CodFuncionario_Crea.ReadOnly = True
        Me.Txt_CodFuncionario_Crea.Size = New System.Drawing.Size(462, 22)
        Me.Txt_CodFuncionario_Crea.TabIndex = 0
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
        Me.LabelX1.Size = New System.Drawing.Size(80, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Solicitado por:"
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Eliminar})
        Me.Bar2.Location = New System.Drawing.Point(0, 442)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(583, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 164
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
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
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Eliminar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlt = CType(resources.GetObject("Btn_Eliminar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Tooltip = "Eliminar comisión"
        '
        'Frm_Tickets_Mant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(583, 483)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Tickets_Mant"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENCION DE TICKET"
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_AsignadoGrupo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_CodFuncionario_Crea As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Eliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Asunto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Public WithEvents Cmb_Prioridad As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Rdb_AsignadoFuncionario As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Line2 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Chk_Asignar As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Txt_Tipo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Area As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Agente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Grupo As DevComponents.DotNetBar.Controls.TextBoxX
End Class
