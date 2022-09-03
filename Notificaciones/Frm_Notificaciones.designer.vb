<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Notificaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Notificaciones))
        Me.Tiempo_Alerta = New System.Windows.Forms.Timer(Me.components)
        Me.Notify_Notificaciones = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Sub_Menu_Demonio = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AbrirDemonioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurarDemonioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_BakApp = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Menu_Extra = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Mnu_Btn_Play = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Pausa = New DevComponents.DotNetBar.ButtonItem()
        Me.Tiempo_Notificaciones = New System.Windows.Forms.Timer(Me.components)
        Me.Sub_Menu_Demonio.SuspendLayout()
        CType(Me.Menu_BakApp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tiempo_Alerta
        '
        Me.Tiempo_Alerta.Interval = 1000
        '
        'Notify_Notificaciones
        '
        Me.Notify_Notificaciones.BalloonTipText = "T2"
        Me.Notify_Notificaciones.BalloonTipTitle = "T1"
        Me.Notify_Notificaciones.Icon = CType(resources.GetObject("Notify_Notificaciones.Icon"), System.Drawing.Icon)
        Me.Notify_Notificaciones.Text = "BakApp (Demonio Activado)"
        Me.Notify_Notificaciones.Visible = True
        '
        'Sub_Menu_Demonio
        '
        Me.Menu_BakApp.SetContextMenuEx(Me.Sub_Menu_Demonio, Me.Menu_Contextual_Menu_Extra)
        Me.Sub_Menu_Demonio.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.AbrirDemonioToolStripMenuItem, Me.ConfigurarDemonioToolStripMenuItem})
        Me.Sub_Menu_Demonio.Name = "Sub_Menu_Demonio"
        Me.Sub_Menu_Demonio.Size = New System.Drawing.Size(106, 54)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(102, 6)
        '
        'AbrirDemonioToolStripMenuItem
        '
        Me.AbrirDemonioToolStripMenuItem.Name = "AbrirDemonioToolStripMenuItem"
        Me.AbrirDemonioToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.AbrirDemonioToolStripMenuItem.Text = "Play"
        '
        'ConfigurarDemonioToolStripMenuItem
        '
        Me.ConfigurarDemonioToolStripMenuItem.Name = "ConfigurarDemonioToolStripMenuItem"
        Me.ConfigurarDemonioToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.ConfigurarDemonioToolStripMenuItem.Text = "Pause"
        '
        'Menu_BakApp
        '
        Me.Menu_BakApp.AntiAlias = True
        Me.Menu_BakApp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Menu_BakApp.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Menu_Extra})
        Me.Menu_BakApp.Location = New System.Drawing.Point(254, 12)
        Me.Menu_BakApp.Name = "Menu_BakApp"
        Me.Menu_BakApp.Size = New System.Drawing.Size(118, 25)
        Me.Menu_BakApp.Stretch = True
        Me.Menu_BakApp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Menu_BakApp.TabIndex = 52
        Me.Menu_BakApp.TabStop = False
        Me.Menu_BakApp.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Menu_Extra
        '
        Me.Menu_Contextual_Menu_Extra.AutoExpandOnClick = True
        Me.Menu_Contextual_Menu_Extra.Name = "Menu_Contextual_Menu_Extra"
        Me.Menu_Contextual_Menu_Extra.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Mnu_Btn_Play, Me.Mnu_Btn_Pausa})
        Me.Menu_Contextual_Menu_Extra.Text = "Opciones"
        '
        'LabelItem1
        '
        Me.LabelItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.PaddingBottom = 1
        Me.LabelItem1.PaddingLeft = 10
        Me.LabelItem1.PaddingTop = 1
        Me.LabelItem1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem1.Text = "Opciones"
        '
        'Mnu_Btn_Play
        '
        Me.Mnu_Btn_Play.Image = CType(resources.GetObject("Mnu_Btn_Play.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Play.Name = "Mnu_Btn_Play"
        Me.Mnu_Btn_Play.Text = "Continuar notificando"
        '
        'Mnu_Btn_Pausa
        '
        Me.Mnu_Btn_Pausa.Image = CType(resources.GetObject("Mnu_Btn_Pausa.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Pausa.Name = "Mnu_Btn_Pausa"
        Me.Mnu_Btn_Pausa.Text = "Pausar las notificaciones"
        '
        'Tiempo_Notificaciones
        '
        Me.Tiempo_Notificaciones.Interval = 20000
        '
        'Frm_Notificaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 49)
        Me.Controls.Add(Me.Menu_BakApp)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Notificaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bakapp (NOTIFICACIONES)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.Sub_Menu_Demonio.ResumeLayout(False)
        CType(Me.Menu_BakApp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Tiempo_Alerta As Timer
    Public WithEvents Notify_Notificaciones As NotifyIcon
    Public WithEvents Menu_BakApp As DevComponents.DotNetBar.ContextMenuBar
    Public WithEvents Menu_Contextual_Menu_Extra As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Mnu_Btn_Play As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Pausa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Sub_Menu_Demonio As ContextMenuStrip
    Friend WithEvents AbrirDemonioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfigurarDemonioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Tiempo_Notificaciones As Timer
End Class
