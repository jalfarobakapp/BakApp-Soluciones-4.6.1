<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Demonio
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Demonio))
        Me.Tiempo_Alerta = New System.Windows.Forms.Timer(Me.components)
        Me.Notify_Demonio = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.SuspendLayout()
        '
        'Tiempo_Alerta
        '
        Me.Tiempo_Alerta.Interval = 1000
        '
        'Notify_Demonio
        '
        Me.Notify_Demonio.BalloonTipText = "T2"
        Me.Notify_Demonio.BalloonTipTitle = "T1"
        Me.Notify_Demonio.Icon = CType(resources.GetObject("Notify_Demonio.Icon"), System.Drawing.Icon)
        Me.Notify_Demonio.Text = "BakApp (Demonio Activado)"
        '
        'Demonio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 121)
        Me.Name = "Demonio"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Tiempo_Alerta As Timer
    Public WithEvents Notify_Demonio As NotifyIcon
End Class
