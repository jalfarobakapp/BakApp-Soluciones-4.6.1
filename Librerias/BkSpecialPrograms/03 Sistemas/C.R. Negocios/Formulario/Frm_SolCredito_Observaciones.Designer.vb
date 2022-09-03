<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SolCredito_Observaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SolCredito_Observaciones))
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Observaciones_Cierre = New DevComponents.DotNetBar.ButtonItem
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem
        Me.Txt_Observaciones = New DevComponents.DotNetBar.Controls.TextBoxX
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Observaciones_Cierre, Me.BtnCancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 265)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(667, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 113
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Text = "Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_Observaciones_Cierre
        '
        Me.Btn_Observaciones_Cierre.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Observaciones_Cierre.ForeColor = System.Drawing.Color.Black
        Me.Btn_Observaciones_Cierre.Image = CType(resources.GetObject("Btn_Observaciones_Cierre.Image"), System.Drawing.Image)
        Me.Btn_Observaciones_Cierre.Name = "Btn_Observaciones_Cierre"
        Me.Btn_Observaciones_Cierre.Text = "Observaciones al cierre"
        Me.Btn_Observaciones_Cierre.Visible = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancelar.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Tooltip = "Cancelar"
        '
        'Txt_Observaciones
        '
        Me.Txt_Observaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Observaciones.Border.Class = "TextBoxBorder"
        Me.Txt_Observaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Observaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Observaciones.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Observaciones.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Observaciones.ForeColor = System.Drawing.Color.Black
        Me.Txt_Observaciones.Location = New System.Drawing.Point(12, 12)
        Me.Txt_Observaciones.MaxLength = 1000
        Me.Txt_Observaciones.Multiline = True
        Me.Txt_Observaciones.Name = "Txt_Observaciones"
        Me.Txt_Observaciones.PreventEnterBeep = True
        Me.Txt_Observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Observaciones.Size = New System.Drawing.Size(643, 236)
        Me.Txt_Observaciones.TabIndex = 114
        Me.Txt_Observaciones.TabStop = False
        '
        'Frm_SolCredito_Observaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 306)
        Me.ControlBox = False
        Me.Controls.Add(Me.Txt_Observaciones)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Frm_SolCredito_Observaciones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Observaciones jefe(a) de crédito "
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_Observaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Btn_Observaciones_Cierre As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
End Class
