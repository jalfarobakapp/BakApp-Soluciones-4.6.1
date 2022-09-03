<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Prestashop
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Prestashop))
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Menu_Extra = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Mnu_Btn_Abrir_Demonio = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Configurar_Demonio = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Cerrar_Demonio = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Menu_Extra})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(43, 21)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(238, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 0
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 89)
        Me.Controls.Add(Me.ContextMenuBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Public WithEvents Menu_Contextual_Menu_Extra As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Mnu_Btn_Abrir_Demonio As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Mnu_Btn_Configurar_Demonio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Mnu_Btn_Cerrar_Demonio As DevComponents.DotNetBar.ButtonItem
End Class
