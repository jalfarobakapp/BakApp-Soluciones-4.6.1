<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Inf_Vencimientos_Revisa_Documentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inf_Vencimientos_Revisa_Documentos))
        Me.LblEstado = New DevComponents.DotNetBar.LabelX()
        Me.Progreso_Porc = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Progreso_Cont = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.BtnProcesar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.TxtLog = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Txt_Cantidad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Revisar_solo_devoluciones = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblEstado
        '
        Me.LblEstado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblEstado.ForeColor = System.Drawing.Color.Black
        Me.LblEstado.Location = New System.Drawing.Point(9, 136)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(678, 23)
        Me.LblEstado.TabIndex = 40
        Me.LblEstado.Text = "Presione Porocesar...."
        '
        'Progreso_Porc
        '
        Me.Progreso_Porc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Porc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Porc.Location = New System.Drawing.Point(9, 64)
        Me.Progreso_Porc.Name = "Progreso_Porc"
        Me.Progreso_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Porc.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Porc.ProgressTextVisible = True
        Me.Progreso_Porc.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Porc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Porc.TabIndex = 39
        '
        'Progreso_Cont
        '
        Me.Progreso_Cont.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Progreso_Cont.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Progreso_Cont.Location = New System.Drawing.Point(9, 12)
        Me.Progreso_Cont.Name = "Progreso_Cont"
        Me.Progreso_Cont.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Cont.ProgressColor = System.Drawing.Color.SteelBlue
        Me.Progreso_Cont.ProgressTextFormat = "{0}"
        Me.Progreso_Cont.ProgressTextVisible = True
        Me.Progreso_Cont.Size = New System.Drawing.Size(56, 46)
        Me.Progreso_Cont.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Progreso_Cont.TabIndex = 38
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnProcesar, Me.Btn_Cancelar})
        Me.Bar2.Location = New System.Drawing.Point(0, 219)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(702, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 37
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnProcesar
        '
        Me.BtnProcesar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnProcesar.ForeColor = System.Drawing.Color.Black
        Me.BtnProcesar.Image = CType(resources.GetObject("BtnProcesar.Image"), System.Drawing.Image)
        Me.BtnProcesar.Name = "BtnProcesar"
        Me.BtnProcesar.Text = "Procesar"
        Me.BtnProcesar.Tooltip = "Grabar"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.Enabled = False
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.Tooltip = "Grabar"
        '
        'TxtLog
        '
        Me.TxtLog.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtLog.Border.Class = "TextBoxBorder"
        Me.TxtLog.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLog.DisabledBackColor = System.Drawing.Color.White
        Me.TxtLog.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLog.ForeColor = System.Drawing.Color.Black
        Me.TxtLog.Location = New System.Drawing.Point(71, 12)
        Me.TxtLog.Multiline = True
        Me.TxtLog.Name = "TxtLog"
        Me.TxtLog.ReadOnly = True
        Me.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtLog.Size = New System.Drawing.Size(619, 118)
        Me.TxtLog.TabIndex = 36
        '
        'Txt_Cantidad
        '
        Me.Txt_Cantidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Cantidad.Border.Class = "TextBoxBorder"
        Me.Txt_Cantidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Cantidad.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Cantidad.ForeColor = System.Drawing.Color.Black
        Me.Txt_Cantidad.Location = New System.Drawing.Point(432, 161)
        Me.Txt_Cantidad.MaxLength = 2
        Me.Txt_Cantidad.Name = "Txt_Cantidad"
        Me.Txt_Cantidad.PreventEnterBeep = True
        Me.Txt_Cantidad.Size = New System.Drawing.Size(46, 22)
        Me.Txt_Cantidad.TabIndex = 41
        Me.Txt_Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(9, 161)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(417, 23)
        Me.LabelX1.TabIndex = 42
        Me.LabelX1.Text = "Cantidad mínima de rotación anual por producto para considerar como sospechoso"
        '
        'Chk_Revisar_solo_devoluciones
        '
        Me.Chk_Revisar_solo_devoluciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Revisar_solo_devoluciones.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Revisar_solo_devoluciones.ForeColor = System.Drawing.Color.Black
        Me.Chk_Revisar_solo_devoluciones.Location = New System.Drawing.Point(12, 190)
        Me.Chk_Revisar_solo_devoluciones.Name = "Chk_Revisar_solo_devoluciones"
        Me.Chk_Revisar_solo_devoluciones.Size = New System.Drawing.Size(279, 23)
        Me.Chk_Revisar_solo_devoluciones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Revisar_solo_devoluciones.TabIndex = 0
        Me.Chk_Revisar_solo_devoluciones.Text = "Revisar solo devoluciones"
        '
        'Frm_Inf_Vencimientos_Revisa_Documentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 260)
        Me.Controls.Add(Me.Chk_Revisar_solo_devoluciones)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Txt_Cantidad)
        Me.Controls.Add(Me.LblEstado)
        Me.Controls.Add(Me.Progreso_Porc)
        Me.Controls.Add(Me.Progreso_Cont)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.TxtLog)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Inf_Vencimientos_Revisa_Documentos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Revisión de detalle de documentos"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Progreso_Cont As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnProcesar As DevComponents.DotNetBar.ButtonItem
    Private WithEvents TxtLog As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Txt_Cantidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Revisar_solo_devoluciones As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
End Class
