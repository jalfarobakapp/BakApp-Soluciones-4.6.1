<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Permisos_Usuario_Mis_Jefes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Permisos_Usuario_Mis_Jefes))
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Cmb_Empresa = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Txt_CodJefe = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Buscar_CodJefe = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_CodJefeReemplazo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Btn_Buscar_CodJefeReemplazo = New DevComponents.DotNetBar.ButtonX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar})
        Me.Bar2.Location = New System.Drawing.Point(0, 100)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(460, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 13
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Crear  nueva entidad"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(14, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(53, 22)
        Me.LabelX1.TabIndex = 127
        Me.LabelX1.Text = "Empresa"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(14, 40)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(53, 22)
        Me.LabelX2.TabIndex = 129
        Me.LabelX2.Text = "Jefe"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(14, 68)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(90, 22)
        Me.LabelX3.TabIndex = 131
        Me.LabelX3.Text = "Jefe de reemplazo"
        '
        'Cmb_Empresa
        '
        Me.Cmb_Empresa.DisplayMember = "Text"
        Me.Cmb_Empresa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Empresa.ForeColor = System.Drawing.Color.Black
        Me.Cmb_Empresa.FormattingEnabled = True
        Me.Cmb_Empresa.ItemHeight = 16
        Me.Cmb_Empresa.Location = New System.Drawing.Point(110, 12)
        Me.Cmb_Empresa.Name = "Cmb_Empresa"
        Me.Cmb_Empresa.Size = New System.Drawing.Size(286, 22)
        Me.Cmb_Empresa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Empresa.TabIndex = 128
        '
        'Txt_CodJefe
        '
        Me.Txt_CodJefe.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CodJefe.Border.Class = "TextBoxBorder"
        Me.Txt_CodJefe.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CodJefe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_CodJefe.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CodJefe.ForeColor = System.Drawing.Color.Black
        Me.Txt_CodJefe.Location = New System.Drawing.Point(110, 42)
        Me.Txt_CodJefe.Name = "Txt_CodJefe"
        Me.Txt_CodJefe.PreventEnterBeep = True
        Me.Txt_CodJefe.ReadOnly = True
        Me.Txt_CodJefe.Size = New System.Drawing.Size(286, 22)
        Me.Txt_CodJefe.TabIndex = 132
        '
        'Btn_Buscar_CodJefe
        '
        Me.Btn_Buscar_CodJefe.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_CodJefe.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_CodJefe.Image = CType(resources.GetObject("Btn_Buscar_CodJefe.Image"), System.Drawing.Image)
        Me.Btn_Buscar_CodJefe.Location = New System.Drawing.Point(402, 42)
        Me.Btn_Buscar_CodJefe.Name = "Btn_Buscar_CodJefe"
        Me.Btn_Buscar_CodJefe.Size = New System.Drawing.Size(51, 22)
        Me.Btn_Buscar_CodJefe.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_CodJefe.TabIndex = 133
        Me.Btn_Buscar_CodJefe.TabStop = False
        Me.Btn_Buscar_CodJefe.Tooltip = "Buscar Cliente"
        '
        'Txt_CodJefeReemplazo
        '
        Me.Txt_CodJefeReemplazo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_CodJefeReemplazo.Border.Class = "TextBoxBorder"
        Me.Txt_CodJefeReemplazo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_CodJefeReemplazo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_CodJefeReemplazo.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_CodJefeReemplazo.ForeColor = System.Drawing.Color.Black
        Me.Txt_CodJefeReemplazo.Location = New System.Drawing.Point(110, 72)
        Me.Txt_CodJefeReemplazo.Name = "Txt_CodJefeReemplazo"
        Me.Txt_CodJefeReemplazo.PreventEnterBeep = True
        Me.Txt_CodJefeReemplazo.ReadOnly = True
        Me.Txt_CodJefeReemplazo.Size = New System.Drawing.Size(286, 22)
        Me.Txt_CodJefeReemplazo.TabIndex = 134
        '
        'Btn_Buscar_CodJefeReemplazo
        '
        Me.Btn_Buscar_CodJefeReemplazo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Buscar_CodJefeReemplazo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Buscar_CodJefeReemplazo.Image = CType(resources.GetObject("Btn_Buscar_CodJefeReemplazo.Image"), System.Drawing.Image)
        Me.Btn_Buscar_CodJefeReemplazo.Location = New System.Drawing.Point(402, 72)
        Me.Btn_Buscar_CodJefeReemplazo.Name = "Btn_Buscar_CodJefeReemplazo"
        Me.Btn_Buscar_CodJefeReemplazo.Size = New System.Drawing.Size(51, 22)
        Me.Btn_Buscar_CodJefeReemplazo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Buscar_CodJefeReemplazo.TabIndex = 135
        Me.Btn_Buscar_CodJefeReemplazo.TabStop = False
        Me.Btn_Buscar_CodJefeReemplazo.Tooltip = "Buscar Cliente"
        '
        'Frm_Permisos_Usuario_Mis_Jefes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 141)
        Me.Controls.Add(Me.Txt_CodJefeReemplazo)
        Me.Controls.Add(Me.Btn_Buscar_CodJefeReemplazo)
        Me.Controls.Add(Me.Txt_CodJefe)
        Me.Controls.Add(Me.Btn_Buscar_CodJefe)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Cmb_Empresa)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Permisos_Usuario_Mis_Jefes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MIS JEFES"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Public WithEvents Cmb_Empresa As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Txt_CodJefe As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Buscar_CodJefe As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_CodJefeReemplazo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Buscar_CodJefeReemplazo As DevComponents.DotNetBar.ButtonX
End Class
