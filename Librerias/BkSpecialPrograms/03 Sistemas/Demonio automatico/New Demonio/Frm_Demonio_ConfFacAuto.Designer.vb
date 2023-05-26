<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Demonio_ConfFacAuto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Demonio_ConfFacAuto))
        Me.Txt_Modalidad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ConfProgramacion = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.Rdb_FA_1Todas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_FA_1Mes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_FA_1Semana = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_FA_1Dia = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Tido = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Txt_Modalidad
        '
        Me.Txt_Modalidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Modalidad.Border.Class = "TextBoxBorder"
        Me.Txt_Modalidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Modalidad.ButtonCustom.Visible = True
        Me.Txt_Modalidad.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Modalidad.ForeColor = System.Drawing.Color.Black
        Me.Txt_Modalidad.Location = New System.Drawing.Point(71, 6)
        Me.Txt_Modalidad.Name = "Txt_Modalidad"
        Me.Txt_Modalidad.PreventEnterBeep = True
        Me.Txt_Modalidad.ReadOnly = True
        Me.Txt_Modalidad.Size = New System.Drawing.Size(86, 22)
        Me.Txt_Modalidad.TabIndex = 186
        Me.Txt_Modalidad.TabStop = False
        Me.Txt_Modalidad.Tag = "Lunes"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(6, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 185
        Me.LabelX1.Text = "Modalidad"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_ConfProgramacion})
        Me.Bar1.Location = New System.Drawing.Point(0, 395)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(653, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 184
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_ConfProgramacion
        '
        Me.Btn_ConfProgramacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ConfProgramacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_ConfProgramacion.Image = CType(resources.GetObject("Btn_ConfProgramacion.Image"), System.Drawing.Image)
        Me.Btn_ConfProgramacion.Name = "Btn_ConfProgramacion"
        Me.Btn_ConfProgramacion.Tooltip = "Programación"
        '
        'LabelX19
        '
        Me.LabelX19.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX19.ForeColor = System.Drawing.Color.Black
        Me.LabelX19.Location = New System.Drawing.Point(193, 168)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(227, 19)
        Me.LabelX19.TabIndex = 191
        Me.LabelX19.Text = "Seleccionar NVV para facturar"
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel7.ColumnCount = 1
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.Rdb_FA_1Todas, 0, 3)
        Me.TableLayoutPanel7.Controls.Add(Me.Rdb_FA_1Mes, 0, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.Rdb_FA_1Semana, 0, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.Rdb_FA_1Dia, 0, 0)
        Me.TableLayoutPanel7.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(193, 187)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 4
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(267, 82)
        Me.TableLayoutPanel7.TabIndex = 190
        '
        'Rdb_FA_1Todas
        '
        Me.Rdb_FA_1Todas.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_FA_1Todas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_FA_1Todas.CheckBoxImageChecked = CType(resources.GetObject("Rdb_FA_1Todas.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_FA_1Todas.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_FA_1Todas.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_FA_1Todas.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_FA_1Todas.ForeColor = System.Drawing.Color.Black
        Me.Rdb_FA_1Todas.Location = New System.Drawing.Point(3, 63)
        Me.Rdb_FA_1Todas.Name = "Rdb_FA_1Todas"
        Me.Rdb_FA_1Todas.Size = New System.Drawing.Size(224, 16)
        Me.Rdb_FA_1Todas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_FA_1Todas.TabIndex = 145
        Me.Rdb_FA_1Todas.Text = "Todas"
        '
        'Rdb_FA_1Mes
        '
        Me.Rdb_FA_1Mes.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_FA_1Mes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_FA_1Mes.CheckBoxImageChecked = CType(resources.GetObject("Rdb_FA_1Mes.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_FA_1Mes.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_FA_1Mes.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_FA_1Mes.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_FA_1Mes.ForeColor = System.Drawing.Color.Black
        Me.Rdb_FA_1Mes.Location = New System.Drawing.Point(3, 43)
        Me.Rdb_FA_1Mes.Name = "Rdb_FA_1Mes"
        Me.Rdb_FA_1Mes.Size = New System.Drawing.Size(199, 14)
        Me.Rdb_FA_1Mes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_FA_1Mes.TabIndex = 143
        Me.Rdb_FA_1Mes.Text = "Un mes  (desde fecha asignada)"
        '
        'Rdb_FA_1Semana
        '
        Me.Rdb_FA_1Semana.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_FA_1Semana.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_FA_1Semana.CheckBoxImageChecked = CType(resources.GetObject("Rdb_FA_1Semana.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_FA_1Semana.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_FA_1Semana.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_FA_1Semana.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_FA_1Semana.ForeColor = System.Drawing.Color.Black
        Me.Rdb_FA_1Semana.Location = New System.Drawing.Point(3, 23)
        Me.Rdb_FA_1Semana.Name = "Rdb_FA_1Semana"
        Me.Rdb_FA_1Semana.Size = New System.Drawing.Size(224, 14)
        Me.Rdb_FA_1Semana.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_FA_1Semana.TabIndex = 142
        Me.Rdb_FA_1Semana.Text = "Una semana  (desde fecha asignada)"
        '
        'Rdb_FA_1Dia
        '
        Me.Rdb_FA_1Dia.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_FA_1Dia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_FA_1Dia.CheckBoxImageChecked = CType(resources.GetObject("Rdb_FA_1Dia.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_FA_1Dia.CheckBoxImageUnChecked = CType(resources.GetObject("Rdb_FA_1Dia.CheckBoxImageUnChecked"), System.Drawing.Image)
        Me.Rdb_FA_1Dia.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_FA_1Dia.Checked = True
        Me.Rdb_FA_1Dia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_FA_1Dia.CheckValue = "Y"
        Me.Rdb_FA_1Dia.ForeColor = System.Drawing.Color.Black
        Me.Rdb_FA_1Dia.Location = New System.Drawing.Point(3, 3)
        Me.Rdb_FA_1Dia.Name = "Rdb_FA_1Dia"
        Me.Rdb_FA_1Dia.Size = New System.Drawing.Size(224, 14)
        Me.Rdb_FA_1Dia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_FA_1Dia.TabIndex = 141
        Me.Rdb_FA_1Dia.Text = "solo las de la fecha asignada (un día)"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(163, 5)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 188
        Me.LabelX2.Text = "Documento"
        '
        'Cmb_Tido
        '
        Me.Cmb_Tido.DisplayMember = "Text"
        Me.Cmb_Tido.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tido.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tido.FormattingEnabled = True
        Me.Cmb_Tido.ItemHeight = 16
        Me.Cmb_Tido.Location = New System.Drawing.Point(229, 5)
        Me.Cmb_Tido.Name = "Cmb_Tido"
        Me.Cmb_Tido.Size = New System.Drawing.Size(231, 22)
        Me.Cmb_Tido.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Tido.TabIndex = 187
        '
        'Frm_Demonio_ConfFacAuto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 436)
        Me.Controls.Add(Me.LabelX19)
        Me.Controls.Add(Me.TableLayoutPanel7)
        Me.Controls.Add(Me.Cmb_Tido)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Txt_Modalidad)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_Demonio_ConfFacAuto"
        Me.Text = "MetroForm"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Txt_Modalidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_ConfProgramacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents Rdb_FA_1Todas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_FA_1Mes As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_FA_1Semana As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_FA_1Dia As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cmb_Tido As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
