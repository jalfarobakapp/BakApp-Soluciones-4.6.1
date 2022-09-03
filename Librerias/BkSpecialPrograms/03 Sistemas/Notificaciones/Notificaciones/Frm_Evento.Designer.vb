<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Evento
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Evento))
        Me.TiempoEspera = New System.Windows.Forms.Timer(Me.components)
        Me.TimerInicio = New System.Windows.Forms.Timer(Me.components)
        Me.TimerCerrar = New System.Windows.Forms.Timer(Me.components)
        Me.pnlFondo = New System.Windows.Forms.Panel()
        Me.Imagen_Fondo = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Lbltexto = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Cerrar = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer_Cerrar_X_Analisis = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Molestar = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Cierra_Molestar = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Abrir_Molestar = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlFondo.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TiempoEspera
        '
        Me.TiempoEspera.Interval = 5000
        '
        'TimerInicio
        '
        Me.TimerInicio.Interval = 7
        '
        'TimerCerrar
        '
        Me.TimerCerrar.Interval = 2
        '
        'pnlFondo
        '
        Me.pnlFondo.BackColor = System.Drawing.Color.Transparent
        Me.pnlFondo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnlFondo.Controls.Add(Me.Imagen_Fondo)
        Me.pnlFondo.Controls.Add(Me.Lbltexto)
        Me.pnlFondo.Location = New System.Drawing.Point(0, 0)
        Me.pnlFondo.Name = "pnlFondo"
        Me.pnlFondo.Size = New System.Drawing.Size(337, 116)
        Me.pnlFondo.TabIndex = 13
        '
        'Imagen_Fondo
        '
        Me.Imagen_Fondo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Imagen_Fondo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Imagen_Fondo.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Imagen_Fondo.Image = CType(resources.GetObject("Imagen_Fondo.Image"), System.Drawing.Image)
        Me.Imagen_Fondo.Location = New System.Drawing.Point(5, 26)
        Me.Imagen_Fondo.Name = "Imagen_Fondo"
        Me.Imagen_Fondo.Size = New System.Drawing.Size(54, 97)
        Me.Imagen_Fondo.TabIndex = 10
        '
        'Lbltexto
        '
        Me.Lbltexto.BackColor = System.Drawing.Color.Transparent
        Me.Lbltexto.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Lbltexto.ForeColor = System.Drawing.Color.White
        Me.Lbltexto.Location = New System.Drawing.Point(61, 26)
        Me.Lbltexto.Name = "Lbltexto"
        Me.Lbltexto.Size = New System.Drawing.Size(273, 83)
        Me.Lbltexto.TabIndex = 9
        Me.Lbltexto.Text = "NOTIFICACIONES LINEA 1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "NOTIFICACIONES LINEA 2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "NOTIFICACIONES LINEA 3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "NOTIFICAC" &
    "IONES LIENA 4" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "NOTIFICACIONES LINEA 5" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "NOTIFICACIONES LINEA 6" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel4.Controls.Add(Me.lblTitulo)
        Me.Panel4.Controls.Add(Me.Lbl_Cerrar)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.ForeColor = System.Drawing.Color.White
        Me.Panel4.Location = New System.Drawing.Point(2, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(337, 20)
        Me.Panel4.TabIndex = 17
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblTitulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTitulo.Location = New System.Drawing.Point(3, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(307, 20)
        Me.lblTitulo.TabIndex = 13
        Me.lblTitulo.Text = "LabelX1"
        '
        'Lbl_Cerrar
        '
        Me.Lbl_Cerrar.AutoSize = True
        Me.Lbl_Cerrar.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Cerrar.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Cerrar.ForeColor = System.Drawing.Color.White
        Me.Lbl_Cerrar.Location = New System.Drawing.Point(316, 2)
        Me.Lbl_Cerrar.Name = "Lbl_Cerrar"
        Me.Lbl_Cerrar.Size = New System.Drawing.Size(16, 16)
        Me.Lbl_Cerrar.TabIndex = 12
        Me.Lbl_Cerrar.Text = "X"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 1
        '
        'Timer_Cerrar_X_Analisis
        '
        Me.Timer_Cerrar_X_Analisis.Interval = 5000
        '
        'Timer_Molestar
        '
        Me.Timer_Molestar.Interval = 20000
        '
        'Timer_Cierra_Molestar
        '
        Me.Timer_Cierra_Molestar.Interval = 2
        '
        'Timer_Abrir_Molestar
        '
        Me.Timer_Abrir_Molestar.Interval = 7
        '
        'Frm_Evento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(339, 128)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.pnlFondo)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Evento"
        Me.ShowIcon = False
        Me.Text = "Frm_Evento"
        Me.pnlFondo.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TiempoEspera As System.Windows.Forms.Timer
    Friend WithEvents TimerInicio As System.Windows.Forms.Timer
    Friend WithEvents TimerCerrar As System.Windows.Forms.Timer
    Friend WithEvents pnlFondo As System.Windows.Forms.Panel
    Friend WithEvents Lbltexto As System.Windows.Forms.Label
    Private WithEvents Panel4 As System.Windows.Forms.Panel
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer_Cerrar_X_Analisis As System.Windows.Forms.Timer
    Friend WithEvents Timer_Molestar As System.Windows.Forms.Timer
    Friend WithEvents Timer_Cierra_Molestar As System.Windows.Forms.Timer
    Friend WithEvents Timer_Abrir_Molestar As System.Windows.Forms.Timer
    Friend WithEvents Imagen_Fondo As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Lbl_Cerrar As Label
    Friend WithEvents lblTitulo As DevComponents.DotNetBar.LabelX
    Friend WithEvents ToolTip1 As ToolTip
End Class
