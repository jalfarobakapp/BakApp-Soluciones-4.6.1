<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Vales_Listado_Espera
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Vales_Listado_Espera))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.BtnImprimirListadoActual = New DevComponents.DotNetBar.ButtonItem
        Me.BtnExportarExcelListado = New DevComponents.DotNetBar.ButtonItem
        Me.BtnActualizar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Configuracion = New DevComponents.DotNetBar.ButtonItem
        Me.Lbl_TiempoRest = New DevComponents.DotNetBar.LabelItem
        Me.Sw_RevisionAutomatica = New DevComponents.DotNetBar.SwitchButtonItem
        Me.CirProg_RevisionAutomatica = New DevComponents.DotNetBar.CircularProgressItem
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonItem
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarValeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AnularValeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.Btn_Filtrar = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_Buscar_documento = New DevComponents.DotNetBar.ButtonItem
        Me.Btn_BusquedaAvanzada = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem
        Me.Rdb_Retira_Cliente = New DevComponents.DotNetBar.CheckBoxItem
        Me.Rdb_Despacho_Domicilio = New DevComponents.DotNetBar.CheckBoxItem
        Me.Rdb_Ambos = New DevComponents.DotNetBar.CheckBoxItem
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem
        Me.Chk_VerMarcadas = New DevComponents.DotNetBar.CheckBoxItem
        Me.Chk_VerActivas = New DevComponents.DotNetBar.CheckBoxItem
        Me.Chk_VerCerradas = New DevComponents.DotNetBar.CheckBoxItem
        Me.Chk_VerNulas = New DevComponents.DotNetBar.CheckBoxItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnImprimirListadoActual, Me.BtnExportarExcelListado, Me.BtnActualizar, Me.Btn_Configuracion, Me.Lbl_TiempoRest, Me.Sw_RevisionAutomatica, Me.CirProg_RevisionAutomatica, Me.BtnCancelar})
        Me.Bar1.Location = New System.Drawing.Point(0, 532)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(876, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 48
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnImprimirListadoActual
        '
        Me.BtnImprimirListadoActual.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnImprimirListadoActual.ForeColor = System.Drawing.Color.Black
        Me.BtnImprimirListadoActual.Image = CType(resources.GetObject("BtnImprimirListadoActual.Image"), System.Drawing.Image)
        Me.BtnImprimirListadoActual.Name = "BtnImprimirListadoActual"
        Me.BtnImprimirListadoActual.Tooltip = "Imprimir listado actual"
        '
        'BtnExportarExcelListado
        '
        Me.BtnExportarExcelListado.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnExportarExcelListado.ForeColor = System.Drawing.Color.Black
        Me.BtnExportarExcelListado.Image = CType(resources.GetObject("BtnExportarExcelListado.Image"), System.Drawing.Image)
        Me.BtnExportarExcelListado.Name = "BtnExportarExcelListado"
        Me.BtnExportarExcelListado.Tooltip = "Exportar a excel"
        '
        'BtnActualizar
        '
        Me.BtnActualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnActualizar.ForeColor = System.Drawing.Color.Black
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Tooltip = "Refrescar información"
        '
        'Btn_Configuracion
        '
        Me.Btn_Configuracion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Configuracion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Configuracion.Image = CType(resources.GetObject("Btn_Configuracion.Image"), System.Drawing.Image)
        Me.Btn_Configuracion.Name = "Btn_Configuracion"
        Me.Btn_Configuracion.Tooltip = "Configuración"
        '
        'Lbl_TiempoRest
        '
        Me.Lbl_TiempoRest.ForeColor = System.Drawing.Color.Black
        Me.Lbl_TiempoRest.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Lbl_TiempoRest.Name = "Lbl_TiempoRest"
        Me.Lbl_TiempoRest.Text = "."
        '
        'Sw_RevisionAutomatica
        '
        Me.Sw_RevisionAutomatica.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Sw_RevisionAutomatica.Name = "Sw_RevisionAutomatica"
        Me.Sw_RevisionAutomatica.Text = "Revisión automática"
        '
        'CirProg_RevisionAutomatica
        '
        Me.CirProg_RevisionAutomatica.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.CirProg_RevisionAutomatica.Name = "CirProg_RevisionAutomatica"
        Me.CirProg_RevisionAutomatica.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.CirProg_RevisionAutomatica.TextPosition = DevComponents.DotNetBar.eTextPosition.Top
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
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(3, 18)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(861, 466)
        Me.Grilla.TabIndex = 84
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "transport.png")
        Me.ImageList1.Images.SetKeyName(1, "shipment-customer.png")
        Me.ImageList1.Images.SetKeyName(2, "transport-shipment.png")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarValeToolStripMenuItem, Me.AnularValeToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(135, 48)
        '
        'EditarValeToolStripMenuItem
        '
        Me.EditarValeToolStripMenuItem.Name = "EditarValeToolStripMenuItem"
        Me.EditarValeToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.EditarValeToolStripMenuItem.Text = "Ver vale"
        '
        'AnularValeToolStripMenuItem
        '
        Me.AnularValeToolStripMenuItem.Name = "AnularValeToolStripMenuItem"
        Me.AnularValeToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.AnularValeToolStripMenuItem.Text = "Anular Vale"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "transport.png")
        Me.ImageList2.Images.SetKeyName(1, "transport-ok.png")
        Me.ImageList2.Images.SetKeyName(2, "transport-lock.png")
        Me.ImageList2.Images.SetKeyName(3, "transport-delete.png")
        Me.ImageList2.Images.SetKeyName(4, "shipment.png")
        Me.ImageList2.Images.SetKeyName(5, "shipment-ok.png")
        Me.ImageList2.Images.SetKeyName(6, "shipment-lock.png")
        Me.ImageList2.Images.SetKeyName(7, "shipment-delete.png")
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Grilla)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(3, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(867, 487)
        Me.GroupBox1.TabIndex = 85
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lista"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Filtrar, Me.ButtonItem1, Me.ButtonItem2})
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(876, 33)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 103
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Filtrar
        '
        Me.Btn_Filtrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Filtrar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Filtrar.Image = CType(resources.GetObject("Btn_Filtrar.Image"), System.Drawing.Image)
        Me.Btn_Filtrar.Name = "Btn_Filtrar"
        Me.Btn_Filtrar.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Buscar_documento, Me.Btn_BusquedaAvanzada})
        Me.Btn_Filtrar.Text = "Filtrar, buscar documentos"
        Me.Btn_Filtrar.Tooltip = "Filtrar"
        '
        'Btn_Buscar_documento
        '
        Me.Btn_Buscar_documento.Name = "Btn_Buscar_documento"
        Me.Btn_Buscar_documento.Text = "Buscar documento"
        '
        'Btn_BusquedaAvanzada
        '
        Me.Btn_BusquedaAvanzada.Name = "Btn_BusquedaAvanzada"
        Me.Btn_BusquedaAvanzada.Text = "Busqueda avanzada"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.ForeColor = System.Drawing.Color.Black
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Rdb_Retira_Cliente, Me.Rdb_Despacho_Domicilio, Me.Rdb_Ambos})
        Me.ButtonItem1.Text = "Tipo de entrega"
        Me.ButtonItem1.Tooltip = "Filtrar"
        '
        'Rdb_Retira_Cliente
        '
        Me.Rdb_Retira_Cliente.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Retira_Cliente.Name = "Rdb_Retira_Cliente"
        Me.Rdb_Retira_Cliente.Text = "RETIRA CLIENTE"
        '
        'Rdb_Despacho_Domicilio
        '
        Me.Rdb_Despacho_Domicilio.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Despacho_Domicilio.Name = "Rdb_Despacho_Domicilio"
        Me.Rdb_Despacho_Domicilio.Text = "DESPACHO A DOMICILIO"
        '
        'Rdb_Ambos
        '
        Me.Rdb_Ambos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Ambos.Name = "Rdb_Ambos"
        Me.Rdb_Ambos.Text = "AMBOS"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.ForeColor = System.Drawing.Color.Black
        Me.ButtonItem2.Image = CType(resources.GetObject("ButtonItem2.Image"), System.Drawing.Image)
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Chk_VerMarcadas, Me.Chk_VerActivas, Me.Chk_VerCerradas, Me.Chk_VerNulas})
        Me.ButtonItem2.Text = "Ver estado documento"
        Me.ButtonItem2.Tooltip = "Filtrar"
        '
        'Chk_VerMarcadas
        '
        Me.Chk_VerMarcadas.Name = "Chk_VerMarcadas"
        Me.Chk_VerMarcadas.Text = "MARCADAS"
        '
        'Chk_VerActivas
        '
        Me.Chk_VerActivas.Name = "Chk_VerActivas"
        Me.Chk_VerActivas.Text = "ACTIVAS"
        '
        'Chk_VerCerradas
        '
        Me.Chk_VerCerradas.Name = "Chk_VerCerradas"
        Me.Chk_VerCerradas.Text = "CERRADAS"
        '
        'Chk_VerNulas
        '
        Me.Chk_VerNulas.Name = "Chk_VerNulas"
        Me.Chk_VerNulas.Text = "NULAS"
        '
        'Frm_Vales_Listado_Espera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(876, 573)
        Me.ControlBox = False
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Vales_Listado_Espera"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de documentos pendientes de retiro o despacho"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BtnExportarExcelListado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnImprimirListadoActual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents EditarValeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularValeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnActualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Sw_RevisionAutomatica As DevComponents.DotNetBar.SwitchButtonItem
    Friend WithEvents CirProg_RevisionAutomatica As DevComponents.DotNetBar.CircularProgressItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Lbl_TiempoRest As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Filtrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Configuracion As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Rdb_Retira_Cliente As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Rdb_Despacho_Domicilio As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Rdb_Ambos As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_VerMarcadas As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_VerActivas As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_VerCerradas As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Chk_VerNulas As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Btn_Buscar_documento As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_BusquedaAvanzada As DevComponents.DotNetBar.ButtonItem
End Class
