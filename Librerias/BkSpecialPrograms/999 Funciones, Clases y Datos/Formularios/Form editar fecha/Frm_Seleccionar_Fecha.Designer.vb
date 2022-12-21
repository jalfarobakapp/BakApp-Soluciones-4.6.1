<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Seleccionar_Fecha
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Seleccionar_Fecha))
        Me.Mnt_Fecha = New DevComponents.Editors.DateTimeAdv.MonthCalendarAdv()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Btn_Aceptar = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_Fecha = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.SuspendLayout()
        '
        'Mnt_Fecha
        '
        Me.Mnt_Fecha.AnnuallyMarkedDates = New Date(-1) {}
        Me.Mnt_Fecha.AutoSize = True
        Me.Mnt_Fecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Mnt_Fecha.BackgroundStyle.Class = "MonthCalendarAdv"
        Me.Mnt_Fecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Mnt_Fecha.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Mnt_Fecha.ContainerControlProcessDialogKey = True
        Me.Mnt_Fecha.DisplayMonth = New Date(2022, 10, 27, 0, 0, 0, 0)
        Me.Mnt_Fecha.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Mnt_Fecha.ForeColor = System.Drawing.Color.Black
        Me.Mnt_Fecha.Location = New System.Drawing.Point(12, 8)
        Me.Mnt_Fecha.MarkedDates = New Date(-1) {}
        Me.Mnt_Fecha.MonthlyMarkedDates = New Date(-1) {}
        Me.Mnt_Fecha.Name = "Mnt_Fecha"
        '
        '
        '
        Me.Mnt_Fecha.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Mnt_Fecha.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Mnt_Fecha.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Mnt_Fecha.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Mnt_Fecha.Size = New System.Drawing.Size(170, 131)
        Me.Mnt_Fecha.TabIndex = 0
        Me.Mnt_Fecha.Text = "MonthCalendarAdv1"
        Me.Mnt_Fecha.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 145)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(103, 23)
        Me.LabelX1.TabIndex = 68
        Me.LabelX1.Text = "Fecha seleccionada"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Aceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Aceptar.Image = CType(resources.GetObject("Btn_Aceptar.Image"), System.Drawing.Image)
        Me.Btn_Aceptar.ImageAlt = CType(resources.GetObject("Btn_Aceptar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Aceptar.Location = New System.Drawing.Point(105, 167)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(77, 25)
        Me.Btn_Aceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Aceptar.TabIndex = 69
        Me.Btn_Aceptar.Text = "Aceptar"
        '
        'Txt_Fecha
        '
        Me.Txt_Fecha.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Fecha.Border.Class = "TextBoxBorder"
        Me.Txt_Fecha.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Fecha.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Fecha.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Fecha.ForeColor = System.Drawing.Color.Black
        Me.Txt_Fecha.Location = New System.Drawing.Point(12, 167)
        Me.Txt_Fecha.Name = "Txt_Fecha"
        Me.Txt_Fecha.PreventEnterBeep = True
        Me.Txt_Fecha.ReadOnly = True
        Me.Txt_Fecha.Size = New System.Drawing.Size(87, 25)
        Me.Txt_Fecha.TabIndex = 0
        Me.Txt_Fecha.Text = "27/10/2022"
        Me.Txt_Fecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Frm_Seleccionar_Fecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(196, 201)
        Me.Controls.Add(Me.Txt_Fecha)
        Me.Controls.Add(Me.Btn_Aceptar)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Mnt_Fecha)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Seleccionar_Fecha"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SELECCIONE LA FECHA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Mnt_Fecha As DevComponents.Editors.DateTimeAdv.MonthCalendarAdv
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Aceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Txt_Fecha As DevComponents.DotNetBar.Controls.TextBoxX
End Class
