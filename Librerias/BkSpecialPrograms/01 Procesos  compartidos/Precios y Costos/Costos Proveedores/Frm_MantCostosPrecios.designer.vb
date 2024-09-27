<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_MantCostosPrecios
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MantCostosPrecios))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Barrar_Menu = New DevComponents.DotNetBar.Bar()
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Refrescar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnExportarExcel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Importar_Desde_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Cancelar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Actualizar_Lista_Random = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ImportarFletes = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ImportarPreciosOtraLista = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Lbl_Rtu = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Uc1 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Uc2 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Pm = New DevComponents.DotNetBar.LabelX()
        Me.ChkUd1XUd2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Estadisticas_Producto = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Codigos_Alternativos = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Copiar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Copiar_datos = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Formula = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Ejecutar_Formula = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Configurar_Formula_Linea = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Copiar_Formula = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Copiar_Datos_Precios = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Costo = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem6 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_PM_Linea = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_UC_Linea = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Importar_Lista = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Levantamiento_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Levantamiento_Ejemplo = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem10 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Mnu_ExportarExcelVistaActual = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Mnu_ExportarExcelTodo = New DevComponents.DotNetBar.ButtonItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BtnCopiarDatos = New System.Windows.Forms.ToolStripMenuItem()
        Me.Radio1 = New DevComponents.DotNetBar.Command(Me.components)
        Me.Radio2 = New DevComponents.DotNetBar.Command(Me.components)
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelItem7 = New DevComponents.DotNetBar.LabelItem()
        Me.ButtonItem11 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem12 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem8 = New DevComponents.DotNetBar.LabelItem()
        Me.ButtonItem13 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem14 = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnOrdenarRegistros = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ordenar_Lista_Codigo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ordenar_Codigo_Lista = New DevComponents.DotNetBar.ButtonItem()
        Me.RdbOrdenCodigo = New DevComponents.DotNetBar.CheckBoxItem()
        Me.RdbOrdenDescripcion = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Chk_OrdenDeLlegada = New DevComponents.DotNetBar.CheckBoxItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Txt_Buscar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Descripcion = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Ud1 = New DevComponents.DotNetBar.LabelX()
        Me.Lbl_Ud2 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Quitar_Sin_Usar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.Barra_Progreso = New DevComponents.DotNetBar.ProgressBarItem()
        Me.Lbl_Status = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem9 = New DevComponents.DotNetBar.LabelItem()
        Me.ChkMarcarTodo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.Lbl_Neto_Cn_Dscto = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel5 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel7 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel9 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel10 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel6 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel8 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel11 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Dtp_FechaVigenciaHasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_FechaVigenciaDesde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Quitar_Bloqueados_venta = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Ver_Solo_Repetidos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_NoUsar_Bloqueados = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel12 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Impuestos = New DevComponents.DotNetBar.LabelX()
        CType(Me.Barrar_Menu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
        Me.GroupPanel5.SuspendLayout()
        Me.GroupPanel7.SuspendLayout()
        Me.GroupPanel9.SuspendLayout()
        Me.GroupPanel10.SuspendLayout()
        Me.GroupPanel6.SuspendLayout()
        Me.GroupPanel8.SuspendLayout()
        Me.GroupPanel11.SuspendLayout()
        CType(Me.Dtp_FechaVigenciaHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_FechaVigenciaDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel12.SuspendLayout()
        Me.SuspendLayout()
        '
        'Barrar_Menu
        '
        Me.Barrar_Menu.AntiAlias = True
        Me.Barrar_Menu.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Barrar_Menu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Barrar_Menu.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnGrabar, Me.Btn_Refrescar, Me.BtnExportarExcel, Me.Btn_Importar_Desde_Excel, Me.Btn_Cancelar, Me.Btn_Actualizar_Lista_Random, Me.Btn_ImportarFletes, Me.Btn_ImportarPreciosOtraLista})
        Me.Barrar_Menu.Location = New System.Drawing.Point(0, 497)
        Me.Barrar_Menu.Name = "Barrar_Menu"
        Me.Barrar_Menu.Size = New System.Drawing.Size(1089, 41)
        Me.Barrar_Menu.Stretch = True
        Me.Barrar_Menu.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Barrar_Menu.TabIndex = 27
        Me.Barrar_Menu.TabStop = False
        Me.Barrar_Menu.Text = "Bar2"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlt = CType(resources.GetObject("BtnGrabar.ImageAlt"), System.Drawing.Image)
        Me.BtnGrabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Tooltip = "Grabar"
        '
        'Btn_Refrescar
        '
        Me.Btn_Refrescar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Refrescar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Refrescar.Image = CType(resources.GetObject("Btn_Refrescar.Image"), System.Drawing.Image)
        Me.Btn_Refrescar.ImageAlt = CType(resources.GetObject("Btn_Refrescar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Refrescar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Refrescar.Name = "Btn_Refrescar"
        Me.Btn_Refrescar.Tooltip = "Refrescar datos"
        '
        'BtnExportarExcel
        '
        Me.BtnExportarExcel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnExportarExcel.ForeColor = System.Drawing.Color.Black
        Me.BtnExportarExcel.Image = CType(resources.GetObject("BtnExportarExcel.Image"), System.Drawing.Image)
        Me.BtnExportarExcel.ImageAlt = CType(resources.GetObject("BtnExportarExcel.ImageAlt"), System.Drawing.Image)
        Me.BtnExportarExcel.Name = "BtnExportarExcel"
        Me.BtnExportarExcel.Text = "Exportar"
        Me.BtnExportarExcel.Tooltip = "Exportar a excel (Vista actual)"
        '
        'Btn_Importar_Desde_Excel
        '
        Me.Btn_Importar_Desde_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Importar_Desde_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Importar_Desde_Excel.Image = CType(resources.GetObject("Btn_Importar_Desde_Excel.Image"), System.Drawing.Image)
        Me.Btn_Importar_Desde_Excel.ImageAlt = CType(resources.GetObject("Btn_Importar_Desde_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Importar_Desde_Excel.Name = "Btn_Importar_Desde_Excel"
        Me.Btn_Importar_Desde_Excel.Text = "Importar"
        Me.Btn_Importar_Desde_Excel.Tooltip = "Importar datos masivamente desde Excel"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Cancelar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Cancelar.Image = CType(resources.GetObject("Btn_Cancelar.Image"), System.Drawing.Image)
        Me.Btn_Cancelar.ImageAlt = CType(resources.GetObject("Btn_Cancelar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Cancelar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.Visible = False
        '
        'Btn_Actualizar_Lista_Random
        '
        Me.Btn_Actualizar_Lista_Random.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar_Lista_Random.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar_Lista_Random.Image = CType(resources.GetObject("Btn_Actualizar_Lista_Random.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Lista_Random.ImageAlt = CType(resources.GetObject("Btn_Actualizar_Lista_Random.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar_Lista_Random.Name = "Btn_Actualizar_Lista_Random"
        Me.Btn_Actualizar_Lista_Random.Text = "Activar lista en Random"
        Me.Btn_Actualizar_Lista_Random.Tooltip = "Levantar estos precios en Random"
        Me.Btn_Actualizar_Lista_Random.Visible = False
        '
        'Btn_ImportarFletes
        '
        Me.Btn_ImportarFletes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ImportarFletes.ForeColor = System.Drawing.Color.Black
        Me.Btn_ImportarFletes.Image = CType(resources.GetObject("Btn_ImportarFletes.Image"), System.Drawing.Image)
        Me.Btn_ImportarFletes.ImageAlt = CType(resources.GetObject("Btn_ImportarFletes.ImageAlt"), System.Drawing.Image)
        Me.Btn_ImportarFletes.Name = "Btn_ImportarFletes"
        Me.Btn_ImportarFletes.Tooltip = "Importar el precio del flete desde la base datos del proveedor"
        '
        'Btn_ImportarPreciosOtraLista
        '
        Me.Btn_ImportarPreciosOtraLista.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ImportarPreciosOtraLista.ForeColor = System.Drawing.Color.Black
        Me.Btn_ImportarPreciosOtraLista.Image = CType(resources.GetObject("Btn_ImportarPreciosOtraLista.Image"), System.Drawing.Image)
        Me.Btn_ImportarPreciosOtraLista.ImageAlt = CType(resources.GetObject("Btn_ImportarPreciosOtraLista.ImageAlt"), System.Drawing.Image)
        Me.Btn_ImportarPreciosOtraLista.Name = "Btn_ImportarPreciosOtraLista"
        Me.Btn_ImportarPreciosOtraLista.Tooltip = "Importar precios desde otra lista, mismo proveedor"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
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
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grilla.Size = New System.Drawing.Size(1070, 291)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 27
        '
        'Lbl_Rtu
        '
        Me.Lbl_Rtu.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Rtu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Rtu.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Rtu.Location = New System.Drawing.Point(3, 1)
        Me.Lbl_Rtu.Name = "Lbl_Rtu"
        Me.Lbl_Rtu.Size = New System.Drawing.Size(59, 23)
        Me.Lbl_Rtu.TabIndex = 34
        Me.Lbl_Rtu.Text = "R.T.U."
        Me.Lbl_Rtu.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Lbl_Uc1
        '
        Me.Lbl_Uc1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Uc1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Uc1.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Uc1.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Uc1.Name = "Lbl_Uc1"
        Me.Lbl_Uc1.Size = New System.Drawing.Size(90, 23)
        Me.Lbl_Uc1.TabIndex = 34
        Me.Lbl_Uc1.Text = "UC1"
        Me.Lbl_Uc1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Lbl_Uc2
        '
        Me.Lbl_Uc2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Uc2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Uc2.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Uc2.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Uc2.Name = "Lbl_Uc2"
        Me.Lbl_Uc2.Size = New System.Drawing.Size(88, 23)
        Me.Lbl_Uc2.TabIndex = 34
        Me.Lbl_Uc2.Text = "UC2"
        Me.Lbl_Uc2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Lbl_Pm
        '
        Me.Lbl_Pm.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Pm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Pm.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Pm.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Pm.Name = "Lbl_Pm"
        Me.Lbl_Pm.Size = New System.Drawing.Size(87, 23)
        Me.Lbl_Pm.TabIndex = 34
        Me.Lbl_Pm.Text = "PM"
        Me.Lbl_Pm.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'ChkUd1XUd2
        '
        Me.ChkUd1XUd2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ChkUd1XUd2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChkUd1XUd2.Checked = True
        Me.ChkUd1XUd2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkUd1XUd2.CheckValue = "Y"
        Me.ChkUd1XUd2.ForeColor = System.Drawing.Color.Black
        Me.ChkUd1XUd2.Location = New System.Drawing.Point(7, 392)
        Me.ChkUd1XUd2.Name = "ChkUd1XUd2"
        Me.ChkUd1XUd2.Size = New System.Drawing.Size(205, 23)
        Me.ChkUd1XUd2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ChkUd1XUd2.TabIndex = 47
        Me.ChkUd1XUd2.Text = "Calculo automático Ud1 vs Ud2 * Rtu"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_Productos, Me.Menu_Contextual_Copiar, Me.Menu_Contextual_Formula, Me.Menu_Contextual_Costo, Me.Menu_Contextual_Importar_Lista, Me.Menu_Contextual_Exportar_Excel})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(92, 78)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(583, 47)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 47
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'Menu_Contextual_Productos
        '
        Me.Menu_Contextual_Productos.AutoExpandOnClick = True
        Me.Menu_Contextual_Productos.Name = "Menu_Contextual_Productos"
        Me.Menu_Contextual_Productos.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Btn_Estadisticas_Producto, Me.Btn_Codigos_Alternativos})
        Me.Menu_Contextual_Productos.Text = "Opciones Productos"
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
        Me.LabelItem1.Text = "Opciones del producto"
        '
        'Btn_Estadisticas_Producto
        '
        Me.Btn_Estadisticas_Producto.Image = CType(resources.GetObject("Btn_Estadisticas_Producto.Image"), System.Drawing.Image)
        Me.Btn_Estadisticas_Producto.ImageAlt = CType(resources.GetObject("Btn_Estadisticas_Producto.ImageAlt"), System.Drawing.Image)
        Me.Btn_Estadisticas_Producto.Name = "Btn_Estadisticas_Producto"
        Me.Btn_Estadisticas_Producto.Text = "Ver estadísticas del producto/información adicional"
        '
        'Btn_Codigos_Alternativos
        '
        Me.Btn_Codigos_Alternativos.Image = CType(resources.GetObject("Btn_Codigos_Alternativos.Image"), System.Drawing.Image)
        Me.Btn_Codigos_Alternativos.ImageAlt = CType(resources.GetObject("Btn_Codigos_Alternativos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Codigos_Alternativos.Name = "Btn_Codigos_Alternativos"
        Me.Btn_Codigos_Alternativos.Text = "Mantención de códigos alternativos del productos"
        '
        'Menu_Contextual_Copiar
        '
        Me.Menu_Contextual_Copiar.AutoExpandOnClick = True
        Me.Menu_Contextual_Copiar.Name = "Menu_Contextual_Copiar"
        Me.Menu_Contextual_Copiar.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Copiar_datos})
        Me.Menu_Contextual_Copiar.Text = "Opciones Copia"
        '
        'Btn_Copiar_datos
        '
        Me.Btn_Copiar_datos.Image = CType(resources.GetObject("Btn_Copiar_datos.Image"), System.Drawing.Image)
        Me.Btn_Copiar_datos.ImageAlt = CType(resources.GetObject("Btn_Copiar_datos.ImageAlt"), System.Drawing.Image)
        Me.Btn_Copiar_datos.Name = "Btn_Copiar_datos"
        Me.Btn_Copiar_datos.Text = "Copiar este datos en todos los productos marcados"
        '
        'Menu_Contextual_Formula
        '
        Me.Menu_Contextual_Formula.AutoExpandOnClick = True
        Me.Menu_Contextual_Formula.Name = "Menu_Contextual_Formula"
        Me.Menu_Contextual_Formula.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem4, Me.Btn_Ejecutar_Formula, Me.Btn_Configurar_Formula_Linea, Me.LabelItem5, Me.Btn_Copiar_Formula, Me.Btn_Copiar_Datos_Precios})
        Me.Menu_Contextual_Formula.Text = "Opciones Formula"
        '
        'LabelItem4
        '
        Me.LabelItem4.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem4.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem4.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.PaddingBottom = 1
        Me.LabelItem4.PaddingLeft = 10
        Me.LabelItem4.PaddingTop = 1
        Me.LabelItem4.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem4.Text = "Formulas de la línea activa"
        '
        'Btn_Ejecutar_Formula
        '
        Me.Btn_Ejecutar_Formula.Image = CType(resources.GetObject("Btn_Ejecutar_Formula.Image"), System.Drawing.Image)
        Me.Btn_Ejecutar_Formula.ImageAlt = CType(resources.GetObject("Btn_Ejecutar_Formula.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ejecutar_Formula.Name = "Btn_Ejecutar_Formula"
        Me.Btn_Ejecutar_Formula.Text = "Ejecutar formula"
        '
        'Btn_Configurar_Formula_Linea
        '
        Me.Btn_Configurar_Formula_Linea.Image = CType(resources.GetObject("Btn_Configurar_Formula_Linea.Image"), System.Drawing.Image)
        Me.Btn_Configurar_Formula_Linea.ImageAlt = CType(resources.GetObject("Btn_Configurar_Formula_Linea.ImageAlt"), System.Drawing.Image)
        Me.Btn_Configurar_Formula_Linea.Name = "Btn_Configurar_Formula_Linea"
        Me.Btn_Configurar_Formula_Linea.Text = "Configuración de formula"
        '
        'LabelItem5
        '
        Me.LabelItem5.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem5.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem5.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem5.Name = "LabelItem5"
        Me.LabelItem5.PaddingBottom = 1
        Me.LabelItem5.PaddingLeft = 10
        Me.LabelItem5.PaddingTop = 1
        Me.LabelItem5.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem5.Text = "Copiar datos"
        '
        'Btn_Copiar_Formula
        '
        Me.Btn_Copiar_Formula.Image = CType(resources.GetObject("Btn_Copiar_Formula.Image"), System.Drawing.Image)
        Me.Btn_Copiar_Formula.ImageAlt = CType(resources.GetObject("Btn_Copiar_Formula.ImageAlt"), System.Drawing.Image)
        Me.Btn_Copiar_Formula.Name = "Btn_Copiar_Formula"
        Me.Btn_Copiar_Formula.Text = "Copiar la fórmula de este producto en todos los productos marcados"
        '
        'Btn_Copiar_Datos_Precios
        '
        Me.Btn_Copiar_Datos_Precios.Image = CType(resources.GetObject("Btn_Copiar_Datos_Precios.Image"), System.Drawing.Image)
        Me.Btn_Copiar_Datos_Precios.ImageAlt = CType(resources.GetObject("Btn_Copiar_Datos_Precios.ImageAlt"), System.Drawing.Image)
        Me.Btn_Copiar_Datos_Precios.Name = "Btn_Copiar_Datos_Precios"
        Me.Btn_Copiar_Datos_Precios.Text = "Copiar este dato en todos los productos marcados (Valor)"
        '
        'Menu_Contextual_Costo
        '
        Me.Menu_Contextual_Costo.AutoExpandOnClick = True
        Me.Menu_Contextual_Costo.Name = "Menu_Contextual_Costo"
        Me.Menu_Contextual_Costo.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem6, Me.Btn_PM_Linea, Me.Btn_UC_Linea})
        Me.Menu_Contextual_Costo.Text = "Opciones Costo"
        '
        'LabelItem6
        '
        Me.LabelItem6.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem6.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem6.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem6.Name = "LabelItem6"
        Me.LabelItem6.PaddingBottom = 1
        Me.LabelItem6.PaddingLeft = 10
        Me.LabelItem6.PaddingTop = 1
        Me.LabelItem6.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem6.Text = "Costos de la línea activa"
        '
        'Btn_PM_Linea
        '
        Me.Btn_PM_Linea.Image = CType(resources.GetObject("Btn_PM_Linea.Image"), System.Drawing.Image)
        Me.Btn_PM_Linea.ImageAlt = CType(resources.GetObject("Btn_PM_Linea.ImageAlt"), System.Drawing.Image)
        Me.Btn_PM_Linea.Name = "Btn_PM_Linea"
        Me.Btn_PM_Linea.Text = "Traer el PM de este producto"
        '
        'Btn_UC_Linea
        '
        Me.Btn_UC_Linea.Image = CType(resources.GetObject("Btn_UC_Linea.Image"), System.Drawing.Image)
        Me.Btn_UC_Linea.ImageAlt = CType(resources.GetObject("Btn_UC_Linea.ImageAlt"), System.Drawing.Image)
        Me.Btn_UC_Linea.Name = "Btn_UC_Linea"
        Me.Btn_UC_Linea.Text = "Traer el Costo última compra de este producto"
        '
        'Menu_Contextual_Importar_Lista
        '
        Me.Menu_Contextual_Importar_Lista.AutoExpandOnClick = True
        Me.Menu_Contextual_Importar_Lista.Name = "Menu_Contextual_Importar_Lista"
        Me.Menu_Contextual_Importar_Lista.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.Btn_Levantamiento_Excel, Me.Btn_Levantamiento_Ejemplo})
        Me.Menu_Contextual_Importar_Lista.Text = "Opciones Importar lista"
        '
        'LabelItem3
        '
        Me.LabelItem3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem3.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem3.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingBottom = 1
        Me.LabelItem3.PaddingLeft = 10
        Me.LabelItem3.PaddingTop = 1
        Me.LabelItem3.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem3.Text = "Importar lista"
        '
        'Btn_Levantamiento_Excel
        '
        Me.Btn_Levantamiento_Excel.Image = CType(resources.GetObject("Btn_Levantamiento_Excel.Image"), System.Drawing.Image)
        Me.Btn_Levantamiento_Excel.ImageAlt = CType(resources.GetObject("Btn_Levantamiento_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Levantamiento_Excel.Name = "Btn_Levantamiento_Excel"
        Me.Btn_Levantamiento_Excel.Text = "Buscar archivo y levantar"
        '
        'Btn_Levantamiento_Ejemplo
        '
        Me.Btn_Levantamiento_Ejemplo.Image = CType(resources.GetObject("Btn_Levantamiento_Ejemplo.Image"), System.Drawing.Image)
        Me.Btn_Levantamiento_Ejemplo.ImageAlt = CType(resources.GetObject("Btn_Levantamiento_Ejemplo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Levantamiento_Ejemplo.Name = "Btn_Levantamiento_Ejemplo"
        Me.Btn_Levantamiento_Ejemplo.Text = "Ayuda, ejemplo archivo excel."
        '
        'Menu_Contextual_Exportar_Excel
        '
        Me.Menu_Contextual_Exportar_Excel.AutoExpandOnClick = True
        Me.Menu_Contextual_Exportar_Excel.Name = "Menu_Contextual_Exportar_Excel"
        Me.Menu_Contextual_Exportar_Excel.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem10, Me.Btn_Mnu_ExportarExcelVistaActual, Me.Btn_Mnu_ExportarExcelTodo})
        Me.Menu_Contextual_Exportar_Excel.Text = "Opciones Exportar Excel"
        '
        'LabelItem10
        '
        Me.LabelItem10.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem10.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem10.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem10.Name = "LabelItem10"
        Me.LabelItem10.PaddingBottom = 1
        Me.LabelItem10.PaddingLeft = 10
        Me.LabelItem10.PaddingTop = 1
        Me.LabelItem10.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem10.Text = "Exportar lista"
        '
        'Btn_Mnu_ExportarExcelVistaActual
        '
        Me.Btn_Mnu_ExportarExcelVistaActual.Image = CType(resources.GetObject("Btn_Mnu_ExportarExcelVistaActual.Image"), System.Drawing.Image)
        Me.Btn_Mnu_ExportarExcelVistaActual.ImageAlt = CType(resources.GetObject("Btn_Mnu_ExportarExcelVistaActual.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_ExportarExcelVistaActual.Name = "Btn_Mnu_ExportarExcelVistaActual"
        Me.Btn_Mnu_ExportarExcelVistaActual.Text = "Exportar vista actual"
        '
        'Btn_Mnu_ExportarExcelTodo
        '
        Me.Btn_Mnu_ExportarExcelTodo.Image = CType(resources.GetObject("Btn_Mnu_ExportarExcelTodo.Image"), System.Drawing.Image)
        Me.Btn_Mnu_ExportarExcelTodo.ImageAlt = CType(resources.GetObject("Btn_Mnu_ExportarExcelTodo.ImageAlt"), System.Drawing.Image)
        Me.Btn_Mnu_ExportarExcelTodo.Name = "Btn_Mnu_ExportarExcelTodo"
        Me.Btn_Mnu_ExportarExcelTodo.Text = "Exportar todo"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnCopiarDatos})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(345, 26)
        '
        'BtnCopiarDatos
        '
        Me.BtnCopiarDatos.Image = CType(resources.GetObject("BtnCopiarDatos.Image"), System.Drawing.Image)
        Me.BtnCopiarDatos.Name = "BtnCopiarDatos"
        Me.BtnCopiarDatos.Size = New System.Drawing.Size(344, 22)
        Me.BtnCopiarDatos.Text = "Copiar este datos en todos los productos marcados"
        '
        'Radio1
        '
        Me.Radio1.Checked = True
        Me.Radio1.Name = "Radio1"
        Me.Radio1.Text = "Los ultimos 12 meses"
        '
        'Radio2
        '
        Me.Radio2.Name = "Radio2"
        Me.Radio2.Text = "Toda la historia"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel1.Controls.Add(Me.Grilla)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(7, 76)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1076, 314)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 54
        Me.GroupPanel1.Text = "Detalle"
        '
        'LabelItem7
        '
        Me.LabelItem7.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem7.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem7.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem7.Name = "LabelItem7"
        Me.LabelItem7.PaddingBottom = 1
        Me.LabelItem7.PaddingLeft = 10
        Me.LabelItem7.PaddingTop = 1
        Me.LabelItem7.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem7.Text = "Opciones del producto"
        '
        'ButtonItem11
        '
        Me.ButtonItem11.Image = CType(resources.GetObject("ButtonItem11.Image"), System.Drawing.Image)
        Me.ButtonItem11.Name = "ButtonItem11"
        Me.ButtonItem11.Text = "Ver estadísticas del producto/información adicional"
        '
        'ButtonItem12
        '
        Me.ButtonItem12.Image = CType(resources.GetObject("ButtonItem12.Image"), System.Drawing.Image)
        Me.ButtonItem12.Name = "ButtonItem12"
        Me.ButtonItem12.Text = "Mantención de códigos alternativos del productos"
        '
        'LabelItem8
        '
        Me.LabelItem8.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem8.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem8.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem8.Name = "LabelItem8"
        Me.LabelItem8.PaddingBottom = 1
        Me.LabelItem8.PaddingLeft = 10
        Me.LabelItem8.PaddingTop = 1
        Me.LabelItem8.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem8.Text = "Costos de la línea activa"
        '
        'ButtonItem13
        '
        Me.ButtonItem13.Image = CType(resources.GetObject("ButtonItem13.Image"), System.Drawing.Image)
        Me.ButtonItem13.Name = "ButtonItem13"
        Me.ButtonItem13.Text = "Traer el PM de este producto"
        '
        'ButtonItem14
        '
        Me.ButtonItem14.Image = CType(resources.GetObject("ButtonItem14.Image"), System.Drawing.Image)
        Me.ButtonItem14.Name = "ButtonItem14"
        Me.ButtonItem14.Text = "Traer el Costo última compra de este producto"
        '
        'BtnOrdenarRegistros
        '
        Me.BtnOrdenarRegistros.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnOrdenarRegistros.ForeColor = System.Drawing.Color.Black
        Me.BtnOrdenarRegistros.Image = CType(resources.GetObject("BtnOrdenarRegistros.Image"), System.Drawing.Image)
        Me.BtnOrdenarRegistros.Name = "BtnOrdenarRegistros"
        Me.BtnOrdenarRegistros.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Ordenar_Lista_Codigo, Me.Btn_Ordenar_Codigo_Lista, Me.RdbOrdenCodigo, Me.RdbOrdenDescripcion, Me.Chk_OrdenDeLlegada})
        Me.BtnOrdenarRegistros.Text = "Ordenar registros"
        Me.BtnOrdenarRegistros.Tooltip = "Seleccionar productos"
        '
        'Btn_Ordenar_Lista_Codigo
        '
        Me.Btn_Ordenar_Lista_Codigo.Checked = True
        Me.Btn_Ordenar_Lista_Codigo.Name = "Btn_Ordenar_Lista_Codigo"
        Me.Btn_Ordenar_Lista_Codigo.Text = "Ordenar por Lista - Producto"
        '
        'Btn_Ordenar_Codigo_Lista
        '
        Me.Btn_Ordenar_Codigo_Lista.Name = "Btn_Ordenar_Codigo_Lista"
        Me.Btn_Ordenar_Codigo_Lista.Text = "Ordenar por Producto - Lista"
        '
        'RdbOrdenCodigo
        '
        Me.RdbOrdenCodigo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.RdbOrdenCodigo.Checked = True
        Me.RdbOrdenCodigo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RdbOrdenCodigo.Name = "RdbOrdenCodigo"
        Me.RdbOrdenCodigo.Text = "Ordenar por código"
        '
        'RdbOrdenDescripcion
        '
        Me.RdbOrdenDescripcion.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.RdbOrdenDescripcion.Name = "RdbOrdenDescripcion"
        Me.RdbOrdenDescripcion.Text = "Ordenar por descripción"
        '
        'Chk_OrdenDeLlegada
        '
        Me.Chk_OrdenDeLlegada.Name = "Chk_OrdenDeLlegada"
        Me.Chk_OrdenDeLlegada.Text = "ORDEN DE LLEGADA"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Txt_Buscar)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(6, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(765, 58)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 55
        Me.GroupPanel2.Text = "Buscar categoria por descripción"
        '
        'Txt_Buscar
        '
        Me.Txt_Buscar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_Buscar.Border.Class = "TextBoxBorder"
        Me.Txt_Buscar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_Buscar.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_Buscar.ForeColor = System.Drawing.Color.Black
        Me.Txt_Buscar.Location = New System.Drawing.Point(42, 6)
        Me.Txt_Buscar.Name = "Txt_Buscar"
        Me.Txt_Buscar.PreventEnterBeep = True
        Me.Txt_Buscar.Size = New System.Drawing.Size(709, 22)
        Me.Txt_Buscar.TabIndex = 14
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(33, 23)
        Me.LabelX2.TabIndex = 13
        Me.LabelX2.Text = "Buscar"
        '
        'Lbl_Descripcion
        '
        Me.Lbl_Descripcion.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Descripcion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Descripcion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Descripcion.Location = New System.Drawing.Point(2, 3)
        Me.Lbl_Descripcion.Name = "Lbl_Descripcion"
        Me.Lbl_Descripcion.Size = New System.Drawing.Size(365, 23)
        Me.Lbl_Descripcion.TabIndex = 34
        Me.Lbl_Descripcion.Text = "R.T.U."
        '
        'Lbl_Ud1
        '
        Me.Lbl_Ud1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Ud1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Ud1.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Ud1.Location = New System.Drawing.Point(3, 1)
        Me.Lbl_Ud1.Name = "Lbl_Ud1"
        Me.Lbl_Ud1.Size = New System.Drawing.Size(25, 23)
        Me.Lbl_Ud1.TabIndex = 34
        Me.Lbl_Ud1.Text = "UN"
        Me.Lbl_Ud1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Lbl_Ud2
        '
        Me.Lbl_Ud2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Ud2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Ud2.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Ud2.Location = New System.Drawing.Point(5, 1)
        Me.Lbl_Ud2.Name = "Lbl_Ud2"
        Me.Lbl_Ud2.Size = New System.Drawing.Size(25, 23)
        Me.Lbl_Ud2.TabIndex = 34
        Me.Lbl_Ud2.Text = "CJ"
        Me.Lbl_Ud2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Chk_Quitar_Sin_Usar
        '
        Me.Chk_Quitar_Sin_Usar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Quitar_Sin_Usar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Quitar_Sin_Usar.CheckBoxImageChecked = CType(resources.GetObject("Chk_Quitar_Sin_Usar.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Quitar_Sin_Usar.FocusCuesEnabled = False
        Me.Chk_Quitar_Sin_Usar.ForeColor = System.Drawing.Color.Black
        Me.Chk_Quitar_Sin_Usar.Location = New System.Drawing.Point(117, 471)
        Me.Chk_Quitar_Sin_Usar.Name = "Chk_Quitar_Sin_Usar"
        Me.Chk_Quitar_Sin_Usar.Size = New System.Drawing.Size(159, 20)
        Me.Chk_Quitar_Sin_Usar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Quitar_Sin_Usar.TabIndex = 66
        Me.Chk_Quitar_Sin_Usar.Text = "Quitar productos ""No Usar"""
        '
        'MetroStatusBar1
        '
        Me.MetroStatusBar1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.MetroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroStatusBar1.ContainerControlProcessDialogKey = True
        Me.MetroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MetroStatusBar1.DragDropSupport = True
        Me.MetroStatusBar1.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroStatusBar1.ForeColor = System.Drawing.Color.Black
        Me.MetroStatusBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Barra_Progreso, Me.Lbl_Status, Me.LabelItem9})
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 538)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.Size = New System.Drawing.Size(1089, 22)
        Me.MetroStatusBar1.TabIndex = 67
        Me.MetroStatusBar1.Text = "MetroStatusBar1"
        '
        'Barra_Progreso
        '
        '
        '
        '
        Me.Barra_Progreso.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_Progreso.ChunkGradientAngle = 0!
        Me.Barra_Progreso.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.Barra_Progreso.Name = "Barra_Progreso"
        Me.Barra_Progreso.RecentlyUsed = False
        Me.Barra_Progreso.Visible = False
        '
        'Lbl_Status
        '
        Me.Lbl_Status.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Text = "Status..."
        '
        'LabelItem9
        '
        Me.LabelItem9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelItem9.Name = "LabelItem9"
        Me.LabelItem9.Text = " *** Los productos que aparecen acá son aquellos que están asociados al proveedor" &
    " en la tabla de códigos alternativos TABCODAL. (No incluye productos bloqueados " &
    "desde el maestro)"
        Me.LabelItem9.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'ChkMarcarTodo
        '
        Me.ChkMarcarTodo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ChkMarcarTodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChkMarcarTodo.CheckBoxImageChecked = CType(resources.GetObject("ChkMarcarTodo.CheckBoxImageChecked"), System.Drawing.Image)
        Me.ChkMarcarTodo.FocusCuesEnabled = False
        Me.ChkMarcarTodo.ForeColor = System.Drawing.Color.Black
        Me.ChkMarcarTodo.Location = New System.Drawing.Point(7, 471)
        Me.ChkMarcarTodo.Name = "ChkMarcarTodo"
        Me.ChkMarcarTodo.Size = New System.Drawing.Size(81, 20)
        Me.ChkMarcarTodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ChkMarcarTodo.TabIndex = 68
        Me.ChkMarcarTodo.Text = "Marcar todo"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.AutoExpandOnClick = True
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.ButtonItem2, Me.ButtonItem3})
        Me.ButtonItem1.Text = "Opciones Costo"
        '
        'LabelItem2
        '
        Me.LabelItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem2.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingBottom = 1
        Me.LabelItem2.PaddingLeft = 10
        Me.LabelItem2.PaddingTop = 1
        Me.LabelItem2.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem2.Text = "Costos de la línea activa"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.Image = CType(resources.GetObject("ButtonItem2.Image"), System.Drawing.Image)
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "Traer el PM de este producto"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.Image = CType(resources.GetObject("ButtonItem3.Image"), System.Drawing.Image)
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "Traer el Costo última compra de este producto"
        '
        'Lbl_Neto_Cn_Dscto
        '
        Me.Lbl_Neto_Cn_Dscto.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Neto_Cn_Dscto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Neto_Cn_Dscto.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Neto_Cn_Dscto.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Neto_Cn_Dscto.Name = "Lbl_Neto_Cn_Dscto"
        Me.Lbl_Neto_Cn_Dscto.Size = New System.Drawing.Size(88, 23)
        Me.Lbl_Neto_Cn_Dscto.TabIndex = 34
        Me.Lbl_Neto_Cn_Dscto.Text = "0"
        Me.Lbl_Neto_Cn_Dscto.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Lbl_Descripcion)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(7, 414)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(377, 51)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 71
        Me.GroupPanel3.Text = "Descripción"
        '
        'GroupPanel4
        '
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Lbl_Ud1)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(497, 416)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(41, 49)
        '
        '
        '
        Me.GroupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel4.Style.BackColorGradientAngle = 90
        Me.GroupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderBottomWidth = 1
        Me.GroupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderLeftWidth = 1
        Me.GroupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderRightWidth = 1
        Me.GroupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderTopWidth = 1
        Me.GroupPanel4.Style.CornerDiameter = 4
        Me.GroupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel4.TabIndex = 72
        Me.GroupPanel4.Text = "Ud1"
        '
        'GroupPanel5
        '
        Me.GroupPanel5.BackColor = System.Drawing.Color.White
        Me.GroupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel5.Controls.Add(Me.Lbl_Neto_Cn_Dscto)
        Me.GroupPanel5.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel5.Location = New System.Drawing.Point(390, 414)
        Me.GroupPanel5.Name = "GroupPanel5"
        Me.GroupPanel5.Size = New System.Drawing.Size(100, 51)
        '
        '
        '
        Me.GroupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel5.Style.BackColorGradientAngle = 90
        Me.GroupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderBottomWidth = 1
        Me.GroupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderLeftWidth = 1
        Me.GroupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderRightWidth = 1
        Me.GroupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel5.Style.BorderTopWidth = 1
        Me.GroupPanel5.Style.CornerDiameter = 4
        Me.GroupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel5.TabIndex = 73
        Me.GroupPanel5.Text = "Neto - Dscto"
        '
        'GroupPanel7
        '
        Me.GroupPanel7.BackColor = System.Drawing.Color.White
        Me.GroupPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel7.Controls.Add(Me.Lbl_Ud2)
        Me.GroupPanel7.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel7.Location = New System.Drawing.Point(544, 416)
        Me.GroupPanel7.Name = "GroupPanel7"
        Me.GroupPanel7.Size = New System.Drawing.Size(41, 49)
        '
        '
        '
        Me.GroupPanel7.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel7.Style.BackColorGradientAngle = 90
        Me.GroupPanel7.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel7.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel7.Style.BorderBottomWidth = 1
        Me.GroupPanel7.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel7.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel7.Style.BorderLeftWidth = 1
        Me.GroupPanel7.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel7.Style.BorderRightWidth = 1
        Me.GroupPanel7.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel7.Style.BorderTopWidth = 1
        Me.GroupPanel7.Style.CornerDiameter = 4
        Me.GroupPanel7.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel7.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel7.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel7.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel7.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel7.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel7.TabIndex = 75
        Me.GroupPanel7.Text = "Ud2"
        '
        'GroupPanel9
        '
        Me.GroupPanel9.BackColor = System.Drawing.Color.White
        Me.GroupPanel9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel9.Controls.Add(Me.Lbl_Uc1)
        Me.GroupPanel9.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel9.Location = New System.Drawing.Point(771, 414)
        Me.GroupPanel9.Name = "GroupPanel9"
        Me.GroupPanel9.Size = New System.Drawing.Size(100, 51)
        '
        '
        '
        Me.GroupPanel9.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel9.Style.BackColorGradientAngle = 90
        Me.GroupPanel9.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel9.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel9.Style.BorderBottomWidth = 1
        Me.GroupPanel9.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel9.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel9.Style.BorderLeftWidth = 1
        Me.GroupPanel9.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel9.Style.BorderRightWidth = 1
        Me.GroupPanel9.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel9.Style.BorderTopWidth = 1
        Me.GroupPanel9.Style.CornerDiameter = 4
        Me.GroupPanel9.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel9.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel9.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel9.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel9.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel9.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel9.TabIndex = 77
        Me.GroupPanel9.Text = "Costo U.C. Ud1"
        '
        'GroupPanel10
        '
        Me.GroupPanel10.BackColor = System.Drawing.Color.White
        Me.GroupPanel10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel10.Controls.Add(Me.Lbl_Rtu)
        Me.GroupPanel10.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel10.Location = New System.Drawing.Point(592, 416)
        Me.GroupPanel10.Name = "GroupPanel10"
        Me.GroupPanel10.Size = New System.Drawing.Size(74, 49)
        '
        '
        '
        Me.GroupPanel10.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel10.Style.BackColorGradientAngle = 90
        Me.GroupPanel10.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel10.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel10.Style.BorderBottomWidth = 1
        Me.GroupPanel10.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel10.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel10.Style.BorderLeftWidth = 1
        Me.GroupPanel10.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel10.Style.BorderRightWidth = 1
        Me.GroupPanel10.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel10.Style.BorderTopWidth = 1
        Me.GroupPanel10.Style.CornerDiameter = 4
        Me.GroupPanel10.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel10.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel10.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel10.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel10.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel10.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel10.TabIndex = 78
        Me.GroupPanel10.Text = "R.T.U."
        '
        'GroupPanel6
        '
        Me.GroupPanel6.BackColor = System.Drawing.Color.White
        Me.GroupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel6.Controls.Add(Me.Lbl_Pm)
        Me.GroupPanel6.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel6.Location = New System.Drawing.Point(983, 414)
        Me.GroupPanel6.Name = "GroupPanel6"
        Me.GroupPanel6.Size = New System.Drawing.Size(100, 51)
        '
        '
        '
        Me.GroupPanel6.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel6.Style.BackColorGradientAngle = 90
        Me.GroupPanel6.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderBottomWidth = 1
        Me.GroupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderLeftWidth = 1
        Me.GroupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderRightWidth = 1
        Me.GroupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderTopWidth = 1
        Me.GroupPanel6.Style.CornerDiameter = 4
        Me.GroupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel6.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel6.TabIndex = 79
        Me.GroupPanel6.Text = "Costo PM"
        '
        'GroupPanel8
        '
        Me.GroupPanel8.BackColor = System.Drawing.Color.White
        Me.GroupPanel8.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel8.Controls.Add(Me.Lbl_Uc2)
        Me.GroupPanel8.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel8.Location = New System.Drawing.Point(877, 414)
        Me.GroupPanel8.Name = "GroupPanel8"
        Me.GroupPanel8.Size = New System.Drawing.Size(100, 51)
        '
        '
        '
        Me.GroupPanel8.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel8.Style.BackColorGradientAngle = 90
        Me.GroupPanel8.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel8.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel8.Style.BorderBottomWidth = 1
        Me.GroupPanel8.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel8.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel8.Style.BorderLeftWidth = 1
        Me.GroupPanel8.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel8.Style.BorderRightWidth = 1
        Me.GroupPanel8.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel8.Style.BorderTopWidth = 1
        Me.GroupPanel8.Style.CornerDiameter = 4
        Me.GroupPanel8.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel8.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel8.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel8.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel8.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel8.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel8.TabIndex = 80
        Me.GroupPanel8.Text = "Costo U.C. Ud2"
        '
        'GroupPanel11
        '
        Me.GroupPanel11.BackColor = System.Drawing.Color.White
        Me.GroupPanel11.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel11.Controls.Add(Me.Dtp_FechaVigenciaHasta)
        Me.GroupPanel11.Controls.Add(Me.LabelX3)
        Me.GroupPanel11.Controls.Add(Me.Dtp_FechaVigenciaDesde)
        Me.GroupPanel11.Controls.Add(Me.LabelX1)
        Me.GroupPanel11.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel11.Location = New System.Drawing.Point(777, 12)
        Me.GroupPanel11.Name = "GroupPanel11"
        Me.GroupPanel11.Size = New System.Drawing.Size(306, 58)
        '
        '
        '
        Me.GroupPanel11.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel11.Style.BackColorGradientAngle = 90
        Me.GroupPanel11.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel11.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel11.Style.BorderBottomWidth = 1
        Me.GroupPanel11.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel11.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel11.Style.BorderLeftWidth = 1
        Me.GroupPanel11.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel11.Style.BorderRightWidth = 1
        Me.GroupPanel11.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel11.Style.BorderTopWidth = 1
        Me.GroupPanel11.Style.CornerDiameter = 4
        Me.GroupPanel11.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel11.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel11.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel11.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel11.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel11.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel11.TabIndex = 81
        Me.GroupPanel11.Text = "Fecha de vigencia"
        '
        'Dtp_FechaVigenciaHasta
        '
        Me.Dtp_FechaVigenciaHasta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaVigenciaHasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaVigenciaHasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVigenciaHasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaVigenciaHasta.ButtonDropDown.Visible = True
        Me.Dtp_FechaVigenciaHasta.Enabled = False
        Me.Dtp_FechaVigenciaHasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaVigenciaHasta.IsPopupCalendarOpen = False
        Me.Dtp_FechaVigenciaHasta.Location = New System.Drawing.Point(204, 6)
        '
        '
        '
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.DisplayMonth = New Date(2022, 6, 1, 0, 0, 0, 0)
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaVigenciaHasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaVigenciaHasta.Name = "Dtp_FechaVigenciaHasta"
        Me.Dtp_FechaVigenciaHasta.Size = New System.Drawing.Size(82, 22)
        Me.Dtp_FechaVigenciaHasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaVigenciaHasta.TabIndex = 15
        Me.Dtp_FechaVigenciaHasta.Value = New Date(2022, 6, 10, 16, 36, 30, 0)
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(152, 6)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(46, 23)
        Me.LabelX3.TabIndex = 16
        Me.LabelX3.Text = "Hasta"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Dtp_FechaVigenciaDesde
        '
        Me.Dtp_FechaVigenciaDesde.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Dtp_FechaVigenciaDesde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_FechaVigenciaDesde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVigenciaDesde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_FechaVigenciaDesde.ButtonDropDown.Visible = True
        Me.Dtp_FechaVigenciaDesde.Enabled = False
        Me.Dtp_FechaVigenciaDesde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_FechaVigenciaDesde.IsPopupCalendarOpen = False
        Me.Dtp_FechaVigenciaDesde.Location = New System.Drawing.Point(53, 6)
        '
        '
        '
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.DisplayMonth = New Date(2022, 6, 1, 0, 0, 0, 0)
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_FechaVigenciaDesde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_FechaVigenciaDesde.Name = "Dtp_FechaVigenciaDesde"
        Me.Dtp_FechaVigenciaDesde.Size = New System.Drawing.Size(82, 22)
        Me.Dtp_FechaVigenciaDesde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_FechaVigenciaDesde.TabIndex = 0
        Me.Dtp_FechaVigenciaDesde.Value = New Date(2022, 6, 10, 16, 36, 30, 0)
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(1, 6)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(46, 23)
        Me.LabelX1.TabIndex = 14
        Me.LabelX1.Text = "Desde"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Chk_Quitar_Bloqueados_venta
        '
        Me.Chk_Quitar_Bloqueados_venta.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Quitar_Bloqueados_venta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Quitar_Bloqueados_venta.CheckBoxImageChecked = CType(resources.GetObject("Chk_Quitar_Bloqueados_venta.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Quitar_Bloqueados_venta.Checked = True
        Me.Chk_Quitar_Bloqueados_venta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Quitar_Bloqueados_venta.CheckValue = "Y"
        Me.Chk_Quitar_Bloqueados_venta.FocusCuesEnabled = False
        Me.Chk_Quitar_Bloqueados_venta.ForeColor = System.Drawing.Color.Black
        Me.Chk_Quitar_Bloqueados_venta.Location = New System.Drawing.Point(273, 471)
        Me.Chk_Quitar_Bloqueados_venta.Name = "Chk_Quitar_Bloqueados_venta"
        Me.Chk_Quitar_Bloqueados_venta.Size = New System.Drawing.Size(193, 20)
        Me.Chk_Quitar_Bloqueados_venta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Quitar_Bloqueados_venta.TabIndex = 82
        Me.Chk_Quitar_Bloqueados_venta.Text = "No mostrar productos Bloqueados"
        '
        'Chk_Ver_Solo_Repetidos
        '
        Me.Chk_Ver_Solo_Repetidos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_Ver_Solo_Repetidos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Ver_Solo_Repetidos.CheckBoxImageChecked = CType(resources.GetObject("Chk_Ver_Solo_Repetidos.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Ver_Solo_Repetidos.FocusCuesEnabled = False
        Me.Chk_Ver_Solo_Repetidos.ForeColor = System.Drawing.Color.Black
        Me.Chk_Ver_Solo_Repetidos.Location = New System.Drawing.Point(472, 471)
        Me.Chk_Ver_Solo_Repetidos.Name = "Chk_Ver_Solo_Repetidos"
        Me.Chk_Ver_Solo_Repetidos.Size = New System.Drawing.Size(159, 20)
        Me.Chk_Ver_Solo_Repetidos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Ver_Solo_Repetidos.TabIndex = 83
        Me.Chk_Ver_Solo_Repetidos.Text = "Ver solo productos repetidos"
        '
        'Chk_NoUsar_Bloqueados
        '
        Me.Chk_NoUsar_Bloqueados.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Chk_NoUsar_Bloqueados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_NoUsar_Bloqueados.CheckBoxImageChecked = CType(resources.GetObject("Chk_NoUsar_Bloqueados.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_NoUsar_Bloqueados.Checked = True
        Me.Chk_NoUsar_Bloqueados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_NoUsar_Bloqueados.CheckValue = "Y"
        Me.Chk_NoUsar_Bloqueados.FocusCuesEnabled = False
        Me.Chk_NoUsar_Bloqueados.ForeColor = System.Drawing.Color.Black
        Me.Chk_NoUsar_Bloqueados.Location = New System.Drawing.Point(637, 471)
        Me.Chk_NoUsar_Bloqueados.Name = "Chk_NoUsar_Bloqueados"
        Me.Chk_NoUsar_Bloqueados.Size = New System.Drawing.Size(190, 20)
        Me.Chk_NoUsar_Bloqueados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_NoUsar_Bloqueados.TabIndex = 84
        Me.Chk_NoUsar_Bloqueados.Text = """No Usar"" productos bloqueados"
        '
        'GroupPanel12
        '
        Me.GroupPanel12.BackColor = System.Drawing.Color.White
        Me.GroupPanel12.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel12.Controls.Add(Me.Lbl_Impuestos)
        Me.GroupPanel12.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel12.Location = New System.Drawing.Point(672, 414)
        Me.GroupPanel12.Name = "GroupPanel12"
        Me.GroupPanel12.Size = New System.Drawing.Size(93, 51)
        '
        '
        '
        Me.GroupPanel12.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel12.Style.BackColorGradientAngle = 90
        Me.GroupPanel12.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel12.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel12.Style.BorderBottomWidth = 1
        Me.GroupPanel12.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel12.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel12.Style.BorderLeftWidth = 1
        Me.GroupPanel12.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel12.Style.BorderRightWidth = 1
        Me.GroupPanel12.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel12.Style.BorderTopWidth = 1
        Me.GroupPanel12.Style.CornerDiameter = 4
        Me.GroupPanel12.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel12.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel12.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel12.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel12.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel12.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel12.TabIndex = 85
        Me.GroupPanel12.Text = "Impuestos"
        '
        'Lbl_Impuestos
        '
        Me.Lbl_Impuestos.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Lbl_Impuestos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Impuestos.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Impuestos.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_Impuestos.Name = "Lbl_Impuestos"
        Me.Lbl_Impuestos.Size = New System.Drawing.Size(78, 23)
        Me.Lbl_Impuestos.TabIndex = 34
        Me.Lbl_Impuestos.Text = "IMP"
        Me.Lbl_Impuestos.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Frm_MantCostosPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1089, 560)
        Me.Controls.Add(Me.GroupPanel12)
        Me.Controls.Add(Me.Chk_NoUsar_Bloqueados)
        Me.Controls.Add(Me.Chk_Ver_Solo_Repetidos)
        Me.Controls.Add(Me.Chk_Quitar_Bloqueados_venta)
        Me.Controls.Add(Me.GroupPanel11)
        Me.Controls.Add(Me.GroupPanel8)
        Me.Controls.Add(Me.GroupPanel6)
        Me.Controls.Add(Me.GroupPanel10)
        Me.Controls.Add(Me.GroupPanel9)
        Me.Controls.Add(Me.GroupPanel7)
        Me.Controls.Add(Me.GroupPanel5)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.ChkMarcarTodo)
        Me.Controls.Add(Me.Barrar_Menu)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.Controls.Add(Me.Chk_Quitar_Sin_Usar)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.ChkUd1XUd2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_MantCostosPrecios"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MetroForm"
        CType(Me.Barrar_Menu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel4.ResumeLayout(False)
        Me.GroupPanel5.ResumeLayout(False)
        Me.GroupPanel7.ResumeLayout(False)
        Me.GroupPanel9.ResumeLayout(False)
        Me.GroupPanel10.ResumeLayout(False)
        Me.GroupPanel6.ResumeLayout(False)
        Me.GroupPanel8.ResumeLayout(False)
        Me.GroupPanel11.ResumeLayout(False)
        CType(Me.Dtp_FechaVigenciaHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_FechaVigenciaDesde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel12.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Barrar_Menu As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Lbl_Rtu As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Uc1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Uc2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Pm As DevComponents.DotNetBar.LabelX
    Public WithEvents ChkUd1XUd2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BtnCopiarDatos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnExportarExcel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Radio1 As DevComponents.DotNetBar.Command
    Friend WithEvents Radio2 As DevComponents.DotNetBar.Command
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Estadisticas_Producto As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Codigos_Alternativos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Copiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Copiar_datos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Menu_Contextual_Formula As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Ejecutar_Formula As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Configurar_Formula_Linea As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Copiar_Formula As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Copiar_Datos_Precios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Costo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem6 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_PM_Linea As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_UC_Linea As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem7 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ButtonItem11 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem12 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem8 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ButtonItem13 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem14 As DevComponents.DotNetBar.ButtonItem
    Public WithEvents BtnOrdenarRegistros As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ordenar_Lista_Codigo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Ordenar_Codigo_Lista As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RdbOrdenCodigo As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents RdbOrdenDescripcion As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Chk_OrdenDeLlegada As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Btn_Refrescar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Descripcion As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Ud1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lbl_Ud2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Txt_Buscar As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents Chk_Quitar_Sin_Usar As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents Barra_Progreso As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents Lbl_Status As DevComponents.DotNetBar.LabelItem
    Public WithEvents ChkMarcarTodo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Btn_Importar_Desde_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_Importar_Lista As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Levantamiento_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Levantamiento_Ejemplo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Cancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Lbl_Neto_Cn_Dscto As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelItem9 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel5 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel7 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel9 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel10 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel6 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel8 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel11 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Dtp_FechaVigenciaDesde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Btn_Actualizar_Lista_Random As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Dtp_FechaVigenciaHasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_ImportarFletes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_ImportarPreciosOtraLista As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Chk_Quitar_Bloqueados_venta As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Chk_Ver_Solo_Repetidos As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents Chk_NoUsar_Bloqueados As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel12 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Impuestos As DevComponents.DotNetBar.LabelX
    Friend WithEvents Menu_Contextual_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem10 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Mnu_ExportarExcelVistaActual As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Mnu_ExportarExcelTodo As DevComponents.DotNetBar.ButtonItem
End Class
