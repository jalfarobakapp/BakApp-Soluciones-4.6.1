<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Tickets_Lista_Tree
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Tickets_Lista_Tree))
        Me.advTree1 = New DevComponents.AdvTree.AdvTree()
        Me.columnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.columnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.columnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader7 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader8 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader9 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader10 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader11 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader12 = New DevComponents.AdvTree.ColumnHeader()
        Me.elementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Crear_Ticket = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_RevisarTicket = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar = New DevComponents.DotNetBar.ButtonItem()
        Me.Metro_Bar_Color = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Lbl_Estatus = New DevComponents.DotNetBar.LabelItem()
        CType(Me.advTree1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'advTree1
        '
        Me.advTree1.AllowDrop = True
        Me.advTree1.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.advTree1.BackgroundStyle.Class = "TreeBorderKey"
        Me.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.advTree1.Columns.Add(Me.columnHeader1)
        Me.advTree1.Columns.Add(Me.columnHeader2)
        Me.advTree1.Columns.Add(Me.columnHeader3)
        Me.advTree1.Columns.Add(Me.ColumnHeader4)
        Me.advTree1.Columns.Add(Me.ColumnHeader5)
        Me.advTree1.Columns.Add(Me.ColumnHeader6)
        Me.advTree1.Columns.Add(Me.ColumnHeader7)
        Me.advTree1.Columns.Add(Me.ColumnHeader8)
        Me.advTree1.Columns.Add(Me.ColumnHeader9)
        Me.advTree1.Columns.Add(Me.ColumnHeader10)
        Me.advTree1.Columns.Add(Me.ColumnHeader11)
        Me.advTree1.Columns.Add(Me.ColumnHeader12)
        Me.advTree1.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle
        Me.advTree1.ExpandWidth = 14
        Me.advTree1.HotTracking = True
        Me.advTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.advTree1.Location = New System.Drawing.Point(12, 28)
        Me.advTree1.Name = "advTree1"
        Me.advTree1.NodeStyle = Me.elementStyle1
        Me.advTree1.PathSeparator = ";"
        Me.advTree1.Size = New System.Drawing.Size(905, 475)
        Me.advTree1.Styles.Add(Me.elementStyle1)
        Me.advTree1.TabIndex = 1
        Me.advTree1.Text = "advTree1"
        '
        'columnHeader1
        '
        Me.columnHeader1.Name = "columnHeader1"
        Me.columnHeader1.Text = "Número"
        Me.columnHeader1.Width.Absolute = 100
        '
        'columnHeader2
        '
        Me.columnHeader2.Name = "columnHeader2"
        Me.columnHeader2.Text = "Sub"
        Me.columnHeader2.Width.Relative = 3
        '
        'columnHeader3
        '
        Me.columnHeader3.Name = "columnHeader3"
        Me.columnHeader3.Text = "De"
        Me.columnHeader3.Width.Relative = 15
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Asunto"
        Me.ColumnHeader4.Width.Absolute = 150
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "Estado"
        Me.ColumnHeader5.Width.Absolute = 150
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "Prioridad"
        Me.ColumnHeader6.Width.Absolute = 150
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Name = "ColumnHeader7"
        Me.ColumnHeader7.Text = "F.Creación"
        Me.ColumnHeader7.Width.Absolute = 150
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Name = "ColumnHeader8"
        Me.ColumnHeader8.Text = "Código"
        Me.ColumnHeader8.Width.Absolute = 150
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Name = "ColumnHeader9"
        Me.ColumnHeader9.Text = "UM"
        Me.ColumnHeader9.Width.Absolute = 150
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Name = "ColumnHeader10"
        Me.ColumnHeader10.Text = "Stk.Bod"
        Me.ColumnHeader10.Width.Absolute = 150
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Name = "ColumnHeader11"
        Me.ColumnHeader11.Text = "Cant."
        Me.ColumnHeader11.Width.Absolute = 150
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Name = "ColumnHeader12"
        Me.ColumnHeader12.Text = "Dif."
        Me.ColumnHeader12.Width.Absolute = 150
        '
        'elementStyle1
        '
        Me.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.elementStyle1.Name = "elementStyle1"
        Me.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Crear_Ticket, Me.Btn_RevisarTicket, Me.Btn_Exportar_Excel, Me.Btn_Actualizar})
        Me.Bar2.Location = New System.Drawing.Point(0, 509)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(929, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 174
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Crear_Ticket
        '
        Me.Btn_Crear_Ticket.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Crear_Ticket.ForeColor = System.Drawing.Color.Black
        Me.Btn_Crear_Ticket.Image = CType(resources.GetObject("Btn_Crear_Ticket.Image"), System.Drawing.Image)
        Me.Btn_Crear_Ticket.ImageAlt = CType(resources.GetObject("Btn_Crear_Ticket.ImageAlt"), System.Drawing.Image)
        Me.Btn_Crear_Ticket.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Crear_Ticket.Name = "Btn_Crear_Ticket"
        Me.Btn_Crear_Ticket.Tooltip = "Crear nuevo Ticket"
        '
        'Btn_RevisarTicket
        '
        Me.Btn_RevisarTicket.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_RevisarTicket.ForeColor = System.Drawing.Color.Black
        Me.Btn_RevisarTicket.Image = CType(resources.GetObject("Btn_RevisarTicket.Image"), System.Drawing.Image)
        Me.Btn_RevisarTicket.ImageAlt = CType(resources.GetObject("Btn_RevisarTicket.ImageAlt"), System.Drawing.Image)
        Me.Btn_RevisarTicket.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_RevisarTicket.Name = "Btn_RevisarTicket"
        Me.Btn_RevisarTicket.Tooltip = "Ver Ticket"
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.ImageAlt = CType(resources.GetObject("Btn_Exportar_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Exportar a Excel"
        '
        'Btn_Actualizar
        '
        Me.Btn_Actualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar.Image = CType(resources.GetObject("Btn_Actualizar.Image"), System.Drawing.Image)
        Me.Btn_Actualizar.ImageAlt = CType(resources.GetObject("Btn_Actualizar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Actualizar.Name = "Btn_Actualizar"
        Me.Btn_Actualizar.Tooltip = "Refrescar datos"
        '
        'Metro_Bar_Color
        '
        Me.Metro_Bar_Color.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Metro_Bar_Color.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Metro_Bar_Color.ContainerControlProcessDialogKey = True
        Me.Metro_Bar_Color.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Metro_Bar_Color.DragDropSupport = True
        Me.Metro_Bar_Color.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Metro_Bar_Color.ForeColor = System.Drawing.Color.Black
        Me.Metro_Bar_Color.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Lbl_Estatus})
        Me.Metro_Bar_Color.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.Metro_Bar_Color.Location = New System.Drawing.Point(0, 550)
        Me.Metro_Bar_Color.Name = "Metro_Bar_Color"
        Me.Metro_Bar_Color.Size = New System.Drawing.Size(929, 22)
        Me.Metro_Bar_Color.TabIndex = 175
        Me.Metro_Bar_Color.Text = "MetroStatusBar1"
        '
        'Lbl_Estatus
        '
        Me.Lbl_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estatus.Name = "Lbl_Estatus"
        Me.Lbl_Estatus.Text = "LabelItem2"
        '
        'Frm_Tickets_Lista_Tree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 572)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Metro_Bar_Color)
        Me.Controls.Add(Me.advTree1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_Tickets_Lista_Tree"
        Me.Text = "MetroForm"
        CType(Me.advTree1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents advTree1 As DevComponents.AdvTree.AdvTree
    Private WithEvents columnHeader1 As DevComponents.AdvTree.ColumnHeader
    Private WithEvents columnHeader2 As DevComponents.AdvTree.ColumnHeader
    Private WithEvents columnHeader3 As DevComponents.AdvTree.ColumnHeader
    Private WithEvents elementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Public WithEvents Btn_Crear_Ticket As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_RevisarTicket As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Actualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Metro_Bar_Color As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Lbl_Estatus As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader7 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader8 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader9 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader10 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader11 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader12 As DevComponents.AdvTree.ColumnHeader
End Class
