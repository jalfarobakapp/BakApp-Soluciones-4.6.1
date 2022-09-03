<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Adjuntar_Arch_Rtf
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Adjuntar_Arch_Rtf))
        Me.Rtf_Observaciones = New DevComponents.DotNetBar.Controls.RichTextBoxEx()
        Me.Contex_Menu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Mnu_Tex_CortarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnu_Tex_CopiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnu_Tex_PegarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Pegar = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Contex_Menu1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Rtf_Observaciones
        '
        Me.Rtf_Observaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rtf_Observaciones.BackColor = System.Drawing.Color.White
        Me.Rtf_Observaciones.BackColorRichTextBox = System.Drawing.Color.White
        '
        '
        '
        Me.Rtf_Observaciones.BackgroundStyle.Class = "RichTextBoxBorder"
        Me.Rtf_Observaciones.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rtf_Observaciones.ContextMenuStrip = Me.Contex_Menu1
        Me.Rtf_Observaciones.ForeColor = System.Drawing.Color.Black
        Me.Rtf_Observaciones.Location = New System.Drawing.Point(12, 37)
        Me.Rtf_Observaciones.Name = "Rtf_Observaciones"
        Me.Rtf_Observaciones.Rtf = "{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang13322{\fonttbl{\f0\fnil\fcharset0" &
    " Segoe UI;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{\*\generator Riched20 10.0.19041}\viewkind4\uc1 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\pard\f0\fs17\p" &
    "ar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Rtf_Observaciones.Size = New System.Drawing.Size(650, 532)
        Me.Rtf_Observaciones.TabIndex = 117
        '
        'Contex_Menu1
        '
        Me.Contex_Menu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Mnu_Tex_CortarToolStripMenuItem, Me.Mnu_Tex_CopiarToolStripMenuItem, Me.Mnu_Tex_PegarToolStripMenuItem})
        Me.Contex_Menu1.Name = "ContextMenuStrip1"
        Me.Contex_Menu1.Size = New System.Drawing.Size(110, 70)
        '
        'Mnu_Tex_CortarToolStripMenuItem
        '
        Me.Mnu_Tex_CortarToolStripMenuItem.Image = CType(resources.GetObject("Mnu_Tex_CortarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Mnu_Tex_CortarToolStripMenuItem.Name = "Mnu_Tex_CortarToolStripMenuItem"
        Me.Mnu_Tex_CortarToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.Mnu_Tex_CortarToolStripMenuItem.Text = "Cortar"
        '
        'Mnu_Tex_CopiarToolStripMenuItem
        '
        Me.Mnu_Tex_CopiarToolStripMenuItem.Image = CType(resources.GetObject("Mnu_Tex_CopiarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Mnu_Tex_CopiarToolStripMenuItem.Name = "Mnu_Tex_CopiarToolStripMenuItem"
        Me.Mnu_Tex_CopiarToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.Mnu_Tex_CopiarToolStripMenuItem.Text = "Copiar"
        '
        'Mnu_Tex_PegarToolStripMenuItem
        '
        Me.Mnu_Tex_PegarToolStripMenuItem.Image = CType(resources.GetObject("Mnu_Tex_PegarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Mnu_Tex_PegarToolStripMenuItem.Name = "Mnu_Tex_PegarToolStripMenuItem"
        Me.Mnu_Tex_PegarToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.Mnu_Tex_PegarToolStripMenuItem.Text = "Pegar"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Pegar})
        Me.Bar1.Location = New System.Drawing.Point(0, 575)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(674, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 116
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
        'Btn_Pegar
        '
        Me.Btn_Pegar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Pegar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Pegar.Image = CType(resources.GetObject("Btn_Pegar.Image"), System.Drawing.Image)
        Me.Btn_Pegar.Name = "Btn_Pegar"
        Me.Btn_Pegar.Tooltip = "Pegar"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, -4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(631, 20)
        Me.LabelX1.TabIndex = 120
        Me.LabelX1.Text = "<b>Dimensiones máximas: 650x700</b>"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 14)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(631, 20)
        Me.LabelX2.TabIndex = 121
        Me.LabelX2.Text = "(si necesita insertar una imagen mas grande se recomienda subir la imagen desde e" &
    "l formulario anterior)"
        '
        'Frm_Adjuntar_Arch_Rtf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 616)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Rtf_Observaciones)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(690, 820)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(690, 655)
        Me.Name = "Frm_Adjuntar_Arch_Rtf"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        Me.Contex_Menu1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents Rtf_Observaciones As DevComponents.DotNetBar.Controls.RichTextBoxEx
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Contex_Menu1 As ContextMenuStrip
    Friend WithEvents Mnu_Tex_CortarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Mnu_Tex_CopiarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Mnu_Tex_PegarToolStripMenuItem As ToolStripMenuItem
    Public WithEvents Btn_Pegar As DevComponents.DotNetBar.ButtonItem
End Class
