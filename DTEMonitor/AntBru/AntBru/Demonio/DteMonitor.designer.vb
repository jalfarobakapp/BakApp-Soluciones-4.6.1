<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DteMonitor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DteMonitor))
        Me.Tiempo_Alerta = New System.Windows.Forms.Timer(Me.components)
        Me.Sub_Menu_Demonio = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DemonioBakappToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AbrirDemonioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurarDemonioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_BakApp = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Menu_Extra = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Mnu_Btn_Abrir_Demonio = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Configurar_Demonio = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Cerrar_Demonio = New DevComponents.DotNetBar.ButtonItem()
        Me.Notify_Bk2Dte = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Tiempo_DTEMonitor = New System.Windows.Forms.Timer(Me.components)
        Me.Sub_Menu_Demonio.SuspendLayout()
        CType(Me.Menu_BakApp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tiempo_Alerta
        '
        Me.Tiempo_Alerta.Interval = 1000
        '
        'Sub_Menu_Demonio
        '
        Me.Menu_BakApp.SetContextMenuEx(Me.Sub_Menu_Demonio, Me.Menu_Contextual_Menu_Extra)
        Me.Sub_Menu_Demonio.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DemonioBakappToolStripMenuItem, Me.ToolStripSeparator1, Me.AbrirDemonioToolStripMenuItem, Me.ConfigurarDemonioToolStripMenuItem, Me.CerrarToolStripMenuItem})
        Me.Sub_Menu_Demonio.Name = "Sub_Menu_Demonio"
        Me.Sub_Menu_Demonio.Size = New System.Drawing.Size(166, 98)
        '
        'DemonioBakappToolStripMenuItem
        '
        Me.DemonioBakappToolStripMenuItem.Name = "DemonioBakappToolStripMenuItem"
        Me.DemonioBakappToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.DemonioBakappToolStripMenuItem.Text = "Demonio Bakapp"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(162, 6)
        '
        'AbrirDemonioToolStripMenuItem
        '
        Me.AbrirDemonioToolStripMenuItem.Name = "AbrirDemonioToolStripMenuItem"
        Me.AbrirDemonioToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.AbrirDemonioToolStripMenuItem.Text = "Abrir"
        '
        'ConfigurarDemonioToolStripMenuItem
        '
        Me.ConfigurarDemonioToolStripMenuItem.Name = "ConfigurarDemonioToolStripMenuItem"
        Me.ConfigurarDemonioToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ConfigurarDemonioToolStripMenuItem.Text = "Configurar"
        '
        'CerrarToolStripMenuItem
        '
        Me.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem"
        Me.CerrarToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.CerrarToolStripMenuItem.Text = "Cerrar"
        '
        'Menu_BakApp
        '
        Me.Menu_BakApp.AntiAlias = True
        Me.Menu_BakApp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Menu_BakApp.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Menu_Extra})
        Me.Menu_BakApp.Location = New System.Drawing.Point(136, 12)
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
        Me.Menu_Contextual_Menu_Extra.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Mnu_Btn_Abrir_Demonio, Me.Mnu_Btn_Configurar_Demonio, Me.Mnu_Btn_Cerrar_Demonio})
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
        'Mnu_Btn_Abrir_Demonio
        '
        Me.Mnu_Btn_Abrir_Demonio.Name = "Mnu_Btn_Abrir_Demonio"
        Me.Mnu_Btn_Abrir_Demonio.Text = "Abrir Demonio"
        '
        'Mnu_Btn_Configurar_Demonio
        '
        Me.Mnu_Btn_Configurar_Demonio.Name = "Mnu_Btn_Configurar_Demonio"
        Me.Mnu_Btn_Configurar_Demonio.Text = "Configurar Demonio"
        '
        'Mnu_Btn_Cerrar_Demonio
        '
        Me.Mnu_Btn_Cerrar_Demonio.Name = "Mnu_Btn_Cerrar_Demonio"
        Me.Mnu_Btn_Cerrar_Demonio.Text = "Cerrar Demonio"
        '
        'Notify_Bk2Dte
        '
        Me.Notify_Bk2Dte.BalloonTipText = "T2"
        Me.Notify_Bk2Dte.BalloonTipTitle = "T1"
        Me.Notify_Bk2Dte.Icon = CType(resources.GetObject("Notify_Bk2Dte.Icon"), System.Drawing.Icon)
        '
        'Tiempo_DTEMonitor
        '
        Me.Tiempo_DTEMonitor.Interval = 1000
        '
        'DteMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 61)
        Me.Controls.Add(Me.Menu_BakApp)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DteMonitor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Demonio"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.Sub_Menu_Demonio.ResumeLayout(False)
        CType(Me.Menu_BakApp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Tiempo_Alerta As Timer
    Public WithEvents Menu_BakApp As DevComponents.DotNetBar.ContextMenuBar
    Public WithEvents Menu_Contextual_Menu_Extra As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Mnu_Btn_Abrir_Demonio As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Configurar_Demonio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Mnu_Btn_Cerrar_Demonio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Sub_Menu_Demonio As ContextMenuStrip
    Friend WithEvents AbrirDemonioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfigurarDemonioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CerrarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents DemonioBakappToolStripMenuItem As ToolStripMenuItem
    Public WithEvents Notify_Bk2Dte As NotifyIcon
    Friend WithEvents Tiempo_DTEMonitor As Timer
End Class
