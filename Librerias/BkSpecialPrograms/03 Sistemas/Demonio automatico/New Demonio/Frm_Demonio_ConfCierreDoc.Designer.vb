<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Demonio_ConfCierreDoc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Demonio_ConfCierreDoc))
        Me.Cmb_Tido = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Txt_Modalidad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ConfProgramacion = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.Input_DiasCOV = New DevComponents.Editors.IntegerInput()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_DiasCOV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cmb_Tido
        '
        Me.Cmb_Tido.DisplayMember = "Text"
        Me.Cmb_Tido.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tido.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Tido.FormattingEnabled = True
        Me.Cmb_Tido.ItemHeight = 16
        Me.Cmb_Tido.Location = New System.Drawing.Point(229, 8)
        Me.Cmb_Tido.Name = "Cmb_Tido"
        Me.Cmb_Tido.Size = New System.Drawing.Size(154, 22)
        Me.Cmb_Tido.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Tido.TabIndex = 180
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(163, 8)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 181
        Me.LabelX2.Text = "Documento"
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
        Me.Txt_Modalidad.Location = New System.Drawing.Point(71, 9)
        Me.Txt_Modalidad.Name = "Txt_Modalidad"
        Me.Txt_Modalidad.PreventEnterBeep = True
        Me.Txt_Modalidad.ReadOnly = True
        Me.Txt_Modalidad.Size = New System.Drawing.Size(86, 22)
        Me.Txt_Modalidad.TabIndex = 179
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
        Me.LabelX1.Location = New System.Drawing.Point(6, 6)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 178
        Me.LabelX1.Text = "Modalidad"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_ConfProgramacion})
        Me.Bar1.Location = New System.Drawing.Point(0, 77)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(393, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 177
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
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
        Me.LabelX13.Location = New System.Drawing.Point(6, 35)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(264, 23)
        Me.LabelX13.TabIndex = 183
        Me.LabelX13.Text = "Días a restar a la fecha de cierre de cada documento"
        '
        'Input_DiasCOV
        '
        Me.Input_DiasCOV.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Input_DiasCOV.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_DiasCOV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_DiasCOV.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_DiasCOV.ForeColor = System.Drawing.Color.Black
        Me.Input_DiasCOV.Location = New System.Drawing.Point(347, 36)
        Me.Input_DiasCOV.MaxValue = 30
        Me.Input_DiasCOV.MinValue = 1
        Me.Input_DiasCOV.Name = "Input_DiasCOV"
        Me.Input_DiasCOV.ShowUpDown = True
        Me.Input_DiasCOV.Size = New System.Drawing.Size(36, 22)
        Me.Input_DiasCOV.TabIndex = 182
        Me.Input_DiasCOV.Value = 1
        '
        'Frm_Demonio_ConfCierreDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 118)
        Me.Controls.Add(Me.Input_DiasCOV)
        Me.Controls.Add(Me.LabelX13)
        Me.Controls.Add(Me.Cmb_Tido)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Txt_Modalidad)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Demonio_ConfCierreDoc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_DiasCOV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Cmb_Tido As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Modalidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_ConfProgramacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_DiasCOV As DevComponents.Editors.IntegerInput
End Class
