<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cashdro_Presentacion
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cashdro_Presentacion))
        Me.Tiempo_Espera = New System.Windows.Forms.Timer(Me.components)
        Me.Demonio = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_Cerrar_Terminal = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Imprimir_Cierres = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_Configurar_Terminal = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cambiar_Tipo_Estacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Opciones = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Habilitar_Opciones = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Volver_Ejecutar_CashDro = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Cerrar = New DevComponents.DotNetBar.ButtonX()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tiempo_Espera
        '
        Me.Tiempo_Espera.Interval = 1000
        '
        'Demonio
        '
        Me.Demonio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Demonio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Demonio.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Demonio.ForeColor = System.Drawing.Color.Black
        Me.Demonio.Image = CType(resources.GetObject("Demonio.Image"), System.Drawing.Image)
        Me.Demonio.Location = New System.Drawing.Point(12, 12)
        Me.Demonio.Name = "Demonio"
        Me.Demonio.Size = New System.Drawing.Size(57, 42)
        Me.Demonio.TabIndex = 0
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(24, 127)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(153, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 46
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_01
        '
        Me.Menu_Contextual_01.AutoExpandOnClick = True
        Me.Menu_Contextual_01.Name = "Menu_Contextual_01"
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Mnu_Cerrar_Terminal, Me.Btn_Mnu_Imprimir_Cierres, Me.Btn_Mnu_Configurar_Terminal, Me.Btn_Cambiar_Tipo_Estacion})
        Me.Menu_Contextual_01.Text = "Opciones"
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
        'Btn_Mnu_Cerrar_Terminal
        '
        Me.Btn_Mnu_Cerrar_Terminal.Image = CType(resources.GetObject("Btn_Mnu_Cerrar_Terminal.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Cerrar_Terminal.Name = "Btn_Mnu_Cerrar_Terminal"
        Me.Btn_Mnu_Cerrar_Terminal.Text = "CERRAR TERMINAL"
        '
        'Btn_Mnu_Imprimir_Cierres
        '
        Me.Btn_Mnu_Imprimir_Cierres.Image = CType(resources.GetObject("Btn_Mnu_Imprimir_Cierres.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Imprimir_Cierres.Name = "Btn_Mnu_Imprimir_Cierres"
        Me.Btn_Mnu_Imprimir_Cierres.Text = "IMPRIMIR CIERRES (Otras fechas)"
        '
        'Btn_Mnu_Configurar_Terminal
        '
        Me.Btn_Mnu_Configurar_Terminal.Image = CType(resources.GetObject("Btn_Mnu_Configurar_Terminal.Image"), System.Drawing.Image)
        Me.Btn_Mnu_Configurar_Terminal.Name = "Btn_Mnu_Configurar_Terminal"
        Me.Btn_Mnu_Configurar_Terminal.Text = "CONFIGURACION LOCAL (Caja automática)"
        '
        'Btn_Cambiar_Tipo_Estacion
        '
        Me.Btn_Cambiar_Tipo_Estacion.Image = CType(resources.GetObject("Btn_Cambiar_Tipo_Estacion.Image"), System.Drawing.Image)
        Me.Btn_Cambiar_Tipo_Estacion.Name = "Btn_Cambiar_Tipo_Estacion"
        Me.Btn_Cambiar_Tipo_Estacion.Text = "CAMBIAR TIPO DE ESTACION DE TRABAJO"
        '
        'Btn_Opciones
        '
        Me.Btn_Opciones.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Opciones.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Opciones.Enabled = False
        Me.Btn_Opciones.Image = CType(resources.GetObject("Btn_Opciones.Image"), System.Drawing.Image)
        Me.Btn_Opciones.Location = New System.Drawing.Point(24, 60)
        Me.Btn_Opciones.Name = "Btn_Opciones"
        Me.Btn_Opciones.Size = New System.Drawing.Size(132, 50)
        Me.Btn_Opciones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Opciones.TabIndex = 47
        Me.Btn_Opciones.Text = "OPCIONES"
        Me.Btn_Opciones.Visible = False
        '
        'Btn_Habilitar_Opciones
        '
        Me.Btn_Habilitar_Opciones.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Habilitar_Opciones.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Habilitar_Opciones.Image = CType(resources.GetObject("Btn_Habilitar_Opciones.Image"), System.Drawing.Image)
        Me.Btn_Habilitar_Opciones.Location = New System.Drawing.Point(162, 60)
        Me.Btn_Habilitar_Opciones.Name = "Btn_Habilitar_Opciones"
        Me.Btn_Habilitar_Opciones.Size = New System.Drawing.Size(132, 50)
        Me.Btn_Habilitar_Opciones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Habilitar_Opciones.TabIndex = 48
        Me.Btn_Habilitar_Opciones.Text = "Habilitar opciones"
        '
        'Btn_Volver_Ejecutar_CashDro
        '
        Me.Btn_Volver_Ejecutar_CashDro.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Volver_Ejecutar_CashDro.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Volver_Ejecutar_CashDro.Image = CType(resources.GetObject("Btn_Volver_Ejecutar_CashDro.Image"), System.Drawing.Image)
        Me.Btn_Volver_Ejecutar_CashDro.Location = New System.Drawing.Point(300, 60)
        Me.Btn_Volver_Ejecutar_CashDro.Name = "Btn_Volver_Ejecutar_CashDro"
        Me.Btn_Volver_Ejecutar_CashDro.Size = New System.Drawing.Size(132, 50)
        Me.Btn_Volver_Ejecutar_CashDro.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Volver_Ejecutar_CashDro.TabIndex = 49
        Me.Btn_Volver_Ejecutar_CashDro.Text = "Volver a ejecutar cajero automático"
        '
        'Btn_Cerrar
        '
        Me.Btn_Cerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Cerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Cerrar.Image = CType(resources.GetObject("Btn_Cerrar.Image"), System.Drawing.Image)
        Me.Btn_Cerrar.Location = New System.Drawing.Point(438, 60)
        Me.Btn_Cerrar.Name = "Btn_Cerrar"
        Me.Btn_Cerrar.Size = New System.Drawing.Size(132, 50)
        Me.Btn_Cerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Cerrar.TabIndex = 50
        Me.Btn_Cerrar.Text = "Cerrar cajero automático"
        '
        'Frm_Cashdro_Presentacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(720, 579)
        Me.Controls.Add(Me.Btn_Cerrar)
        Me.Controls.Add(Me.Btn_Volver_Ejecutar_CashDro)
        Me.Controls.Add(Me.Btn_Habilitar_Opciones)
        Me.Controls.Add(Me.Btn_Opciones)
        Me.Controls.Add(Me.ContextMenuBar1)
        Me.Controls.Add(Me.Demonio)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cashdro_Presentacion"
        Me.Text = "CASHDRO"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tiempo_Espera As System.Windows.Forms.Timer
    Friend WithEvents Demonio As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_Cerrar_Terminal As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_Configurar_Terminal As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Opciones As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Mnu_Imprimir_Cierres As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cambiar_Tipo_Estacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Habilitar_Opciones As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Volver_Ejecutar_CashDro As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Cerrar As DevComponents.DotNetBar.ButtonX
End Class
