<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Arbol_Asociacion_02
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Arbol_Asociacion_02))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Grabar = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Importar_Asociaciones_Desde_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Ver_Arbol = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_BuscarClasificacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_ClasificarMasivamente = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnEliminarTodo = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Exportar_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Carpeta_Padrel_Ver_Productos_Asociados = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Progreso_Porc = New DevComponents.DotNetBar.CircularProgressItem()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.Menu_Contextual_01 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Mnu_Btn_Ver_Sub_Carpetas = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Eliminar_Clasificacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Ver_Productos_Asociados = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Ver_Productos_Sin_Asociacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Menu_Contextual_02 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Mnu_Rdb_Es_Padre = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Mnu_Rdb_Es_Seleccionable = New DevComponents.DotNetBar.CheckBoxItem()
        Me.Menu_Contextual_03 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Mnu_Btn_Carpeta_Actual_Ver_Productos_Asociados = New DevComponents.DotNetBar.ButtonItem()
        Me.Mnu_Btn_Carpeta_Actual_Ver_Productos_Sin_Asociacion = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TxtFullPath = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Btn_Agregar_Nueva_Carpeta = New DevComponents.DotNetBar.ButtonX()
        Me.Txt_DescripcionBusqueda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Imagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.Switch_Modo_Edicion = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Barra_Progreso = New DevComponents.DotNetBar.Controls.ProgressBarX()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Grabar, Me.Btn_Importar_Asociaciones_Desde_Excel, Me.Btn_Ver_Arbol, Me.Btn_BuscarClasificacion, Me.Btn_ClasificarMasivamente, Me.BtnEliminarTodo, Me.Btn_Exportar_Excel, Me.Btn_Carpeta_Padrel_Ver_Productos_Asociados, Me.Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion, Me.Progreso_Porc, Me.BtnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 530)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(792, 41)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.Bar2.TabIndex = 34
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'Btn_Grabar
        '
        Me.Btn_Grabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Grabar.ForeColor = System.Drawing.Color.Black
        Me.Btn_Grabar.Image = CType(resources.GetObject("Btn_Grabar.Image"), System.Drawing.Image)
        Me.Btn_Grabar.ImageAlt = CType(resources.GetObject("Btn_Grabar.ImageAlt"), System.Drawing.Image)
        Me.Btn_Grabar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Grabar.Name = "Btn_Grabar"
        Me.Btn_Grabar.Tooltip = "Grabar"
        '
        'Btn_Importar_Asociaciones_Desde_Excel
        '
        Me.Btn_Importar_Asociaciones_Desde_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Importar_Asociaciones_Desde_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Importar_Asociaciones_Desde_Excel.Image = CType(resources.GetObject("Btn_Importar_Asociaciones_Desde_Excel.Image"), System.Drawing.Image)
        Me.Btn_Importar_Asociaciones_Desde_Excel.ImageAlt = CType(resources.GetObject("Btn_Importar_Asociaciones_Desde_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Importar_Asociaciones_Desde_Excel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Importar_Asociaciones_Desde_Excel.Name = "Btn_Importar_Asociaciones_Desde_Excel"
        Me.Btn_Importar_Asociaciones_Desde_Excel.Tooltip = "Importar asociaciones"
        '
        'Btn_Ver_Arbol
        '
        Me.Btn_Ver_Arbol.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Ver_Arbol.ForeColor = System.Drawing.Color.Black
        Me.Btn_Ver_Arbol.Image = CType(resources.GetObject("Btn_Ver_Arbol.Image"), System.Drawing.Image)
        Me.Btn_Ver_Arbol.ImageAlt = CType(resources.GetObject("Btn_Ver_Arbol.ImageAlt"), System.Drawing.Image)
        Me.Btn_Ver_Arbol.Name = "Btn_Ver_Arbol"
        Me.Btn_Ver_Arbol.Text = "Ver arbol"
        Me.Btn_Ver_Arbol.Tooltip = "Ver arbol"
        '
        'Btn_BuscarClasificacion
        '
        Me.Btn_BuscarClasificacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_BuscarClasificacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_BuscarClasificacion.Image = CType(resources.GetObject("Btn_BuscarClasificacion.Image"), System.Drawing.Image)
        Me.Btn_BuscarClasificacion.ImageAlt = CType(resources.GetObject("Btn_BuscarClasificacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_BuscarClasificacion.Name = "Btn_BuscarClasificacion"
        Me.Btn_BuscarClasificacion.Text = "Buscar clasificación en todo el árbol"
        Me.Btn_BuscarClasificacion.Tooltip = "Ver arbol"
        '
        'Btn_ClasificarMasivamente
        '
        Me.Btn_ClasificarMasivamente.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_ClasificarMasivamente.ForeColor = System.Drawing.Color.Black
        Me.Btn_ClasificarMasivamente.Image = CType(resources.GetObject("Btn_ClasificarMasivamente.Image"), System.Drawing.Image)
        Me.Btn_ClasificarMasivamente.ImageAlt = CType(resources.GetObject("Btn_ClasificarMasivamente.ImageAlt"), System.Drawing.Image)
        Me.Btn_ClasificarMasivamente.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_ClasificarMasivamente.Name = "Btn_ClasificarMasivamente"
        Me.Btn_ClasificarMasivamente.Tooltip = "Importar clasificaciones y productos masivamente"
        Me.Btn_ClasificarMasivamente.Visible = False
        '
        'BtnEliminarTodo
        '
        Me.BtnEliminarTodo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnEliminarTodo.ForeColor = System.Drawing.Color.Black
        Me.BtnEliminarTodo.Image = CType(resources.GetObject("BtnEliminarTodo.Image"), System.Drawing.Image)
        Me.BtnEliminarTodo.ImageAlt = CType(resources.GetObject("BtnEliminarTodo.ImageAlt"), System.Drawing.Image)
        Me.BtnEliminarTodo.Name = "BtnEliminarTodo"
        Me.BtnEliminarTodo.Tooltip = "Eliminar todas las clasificaciones que son clasificables"
        Me.BtnEliminarTodo.Visible = False
        '
        'Btn_Exportar_Excel
        '
        Me.Btn_Exportar_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Exportar_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exportar_Excel.Image = CType(resources.GetObject("Btn_Exportar_Excel.Image"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.ImageAlt = CType(resources.GetObject("Btn_Exportar_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Exportar_Excel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel"
        Me.Btn_Exportar_Excel.Tooltip = "Importar asociaciones"
        '
        'Btn_Carpeta_Padrel_Ver_Productos_Asociados
        '
        Me.Btn_Carpeta_Padrel_Ver_Productos_Asociados.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Carpeta_Padrel_Ver_Productos_Asociados.ForeColor = System.Drawing.Color.Black
        Me.Btn_Carpeta_Padrel_Ver_Productos_Asociados.Image = CType(resources.GetObject("Btn_Carpeta_Padrel_Ver_Productos_Asociados.Image"), System.Drawing.Image)
        Me.Btn_Carpeta_Padrel_Ver_Productos_Asociados.ImageAlt = CType(resources.GetObject("Btn_Carpeta_Padrel_Ver_Productos_Asociados.ImageAlt"), System.Drawing.Image)
        Me.Btn_Carpeta_Padrel_Ver_Productos_Asociados.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Carpeta_Padrel_Ver_Productos_Asociados.Name = "Btn_Carpeta_Padrel_Ver_Productos_Asociados"
        Me.Btn_Carpeta_Padrel_Ver_Productos_Asociados.Tooltip = "Ver productos asociados a las carpetas"
        Me.Btn_Carpeta_Padrel_Ver_Productos_Asociados.Visible = False
        '
        'Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion
        '
        Me.Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion.ForeColor = System.Drawing.Color.Black
        Me.Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion.Image = CType(resources.GetObject("Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion.Image"), System.Drawing.Image)
        Me.Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion.ImageAlt = CType(resources.GetObject("Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion.ImageAlt"), System.Drawing.Image)
        Me.Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion.Name = "Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion"
        Me.Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion.Tooltip = "Ver productos SIN asociación a ninguna de las carpetas"
        Me.Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion.Visible = False
        '
        'Progreso_Porc
        '
        Me.Progreso_Porc.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.Progreso_Porc.Name = "Progreso_Porc"
        Me.Progreso_Porc.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.Progreso_Porc.ProgressTextFormat = "{0}"
        Me.Progreso_Porc.TextColor = System.Drawing.Color.Black
        '
        'BtnSalir
        '
        Me.BtnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnSalir.ForeColor = System.Drawing.Color.Black
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImageAlt = CType(resources.GetObject("BtnSalir.ImageAlt"), System.Drawing.Image)
        Me.BtnSalir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Tooltip = "Salir"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Menu_Contextual_01, Me.Menu_Contextual_02, Me.Menu_Contextual_03})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(131, 69)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(296, 25)
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
        Me.Menu_Contextual_01.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.Mnu_Btn_Ver_Sub_Carpetas, Me.Mnu_Btn_Eliminar_Clasificacion, Me.Mnu_Btn_Ver_Productos_Asociados, Me.Mnu_Btn_Ver_Productos_Sin_Asociacion})
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
        Me.LabelItem1.Text = "Opciones dela línea"
        '
        'Mnu_Btn_Ver_Sub_Carpetas
        '
        Me.Mnu_Btn_Ver_Sub_Carpetas.Image = CType(resources.GetObject("Mnu_Btn_Ver_Sub_Carpetas.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Ver_Sub_Carpetas.ImageAlt = CType(resources.GetObject("Mnu_Btn_Ver_Sub_Carpetas.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Ver_Sub_Carpetas.Name = "Mnu_Btn_Ver_Sub_Carpetas"
        Me.Mnu_Btn_Ver_Sub_Carpetas.Text = "Ver Sub-Carpetas de asignaciones"
        '
        'Mnu_Btn_Eliminar_Clasificacion
        '
        Me.Mnu_Btn_Eliminar_Clasificacion.Image = CType(resources.GetObject("Mnu_Btn_Eliminar_Clasificacion.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Eliminar_Clasificacion.ImageAlt = CType(resources.GetObject("Mnu_Btn_Eliminar_Clasificacion.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Eliminar_Clasificacion.Name = "Mnu_Btn_Eliminar_Clasificacion"
        Me.Mnu_Btn_Eliminar_Clasificacion.Text = "Eliminar clasificación"
        '
        'Mnu_Btn_Ver_Productos_Asociados
        '
        Me.Mnu_Btn_Ver_Productos_Asociados.Image = CType(resources.GetObject("Mnu_Btn_Ver_Productos_Asociados.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Ver_Productos_Asociados.ImageAlt = CType(resources.GetObject("Mnu_Btn_Ver_Productos_Asociados.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Ver_Productos_Asociados.Name = "Mnu_Btn_Ver_Productos_Asociados"
        Me.Mnu_Btn_Ver_Productos_Asociados.Text = "Ver productos asociados a la carpeta"
        '
        'Mnu_Btn_Ver_Productos_Sin_Asociacion
        '
        Me.Mnu_Btn_Ver_Productos_Sin_Asociacion.Image = CType(resources.GetObject("Mnu_Btn_Ver_Productos_Sin_Asociacion.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Ver_Productos_Sin_Asociacion.ImageAlt = CType(resources.GetObject("Mnu_Btn_Ver_Productos_Sin_Asociacion.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Ver_Productos_Sin_Asociacion.Name = "Mnu_Btn_Ver_Productos_Sin_Asociacion"
        Me.Mnu_Btn_Ver_Productos_Sin_Asociacion.Text = "Ver productos SIN asociación (En Este Árbol)"
        '
        'Menu_Contextual_02
        '
        Me.Menu_Contextual_02.AutoExpandOnClick = True
        Me.Menu_Contextual_02.Name = "Menu_Contextual_02"
        Me.Menu_Contextual_02.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.Mnu_Rdb_Es_Padre, Me.Mnu_Rdb_Es_Seleccionable})
        Me.Menu_Contextual_02.Text = "Opciones"
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
        Me.LabelItem2.Text = "Tipo de carpeta"
        '
        'Mnu_Rdb_Es_Padre
        '
        Me.Mnu_Rdb_Es_Padre.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Mnu_Rdb_Es_Padre.Name = "Mnu_Rdb_Es_Padre"
        Me.Mnu_Rdb_Es_Padre.Text = "¿Es Padre?"
        '
        'Mnu_Rdb_Es_Seleccionable
        '
        Me.Mnu_Rdb_Es_Seleccionable.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Mnu_Rdb_Es_Seleccionable.Name = "Mnu_Rdb_Es_Seleccionable"
        Me.Mnu_Rdb_Es_Seleccionable.Text = "¿Es Seleccionable? "
        '
        'Menu_Contextual_03
        '
        Me.Menu_Contextual_03.AutoExpandOnClick = True
        Me.Menu_Contextual_03.Name = "Menu_Contextual_03"
        Me.Menu_Contextual_03.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.Mnu_Btn_Carpeta_Actual_Ver_Productos_Asociados, Me.Mnu_Btn_Carpeta_Actual_Ver_Productos_Sin_Asociacion})
        Me.Menu_Contextual_03.Text = "Opciones"
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
        Me.LabelItem3.Text = "Opciones de la carpeta actual"
        '
        'Mnu_Btn_Carpeta_Actual_Ver_Productos_Asociados
        '
        Me.Mnu_Btn_Carpeta_Actual_Ver_Productos_Asociados.Image = CType(resources.GetObject("Mnu_Btn_Carpeta_Actual_Ver_Productos_Asociados.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Carpeta_Actual_Ver_Productos_Asociados.ImageAlt = CType(resources.GetObject("Mnu_Btn_Carpeta_Actual_Ver_Productos_Asociados.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Carpeta_Actual_Ver_Productos_Asociados.Name = "Mnu_Btn_Carpeta_Actual_Ver_Productos_Asociados"
        Me.Mnu_Btn_Carpeta_Actual_Ver_Productos_Asociados.Text = "Ver productos asociados a la carpeta"
        '
        'Mnu_Btn_Carpeta_Actual_Ver_Productos_Sin_Asociacion
        '
        Me.Mnu_Btn_Carpeta_Actual_Ver_Productos_Sin_Asociacion.Image = CType(resources.GetObject("Mnu_Btn_Carpeta_Actual_Ver_Productos_Sin_Asociacion.Image"), System.Drawing.Image)
        Me.Mnu_Btn_Carpeta_Actual_Ver_Productos_Sin_Asociacion.ImageAlt = CType(resources.GetObject("Mnu_Btn_Carpeta_Actual_Ver_Productos_Sin_Asociacion.ImageAlt"), System.Drawing.Image)
        Me.Mnu_Btn_Carpeta_Actual_Ver_Productos_Sin_Asociacion.Name = "Mnu_Btn_Carpeta_Actual_Ver_Productos_Sin_Asociacion"
        Me.Mnu_Btn_Carpeta_Actual_Ver_Productos_Sin_Asociacion.Text = "Ver productos SIN asociación (En árbol de esta carpeta)"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(764, 324)
        Me.Grilla.TabIndex = 10
        '
        'TxtFullPath
        '
        Me.TxtFullPath.BackColor = System.Drawing.Color.White
        Me.TxtFullPath.ForeColor = System.Drawing.Color.Black
        Me.TxtFullPath.Location = New System.Drawing.Point(3, 3)
        Me.TxtFullPath.Name = "TxtFullPath"
        Me.TxtFullPath.ReadOnly = True
        Me.TxtFullPath.Size = New System.Drawing.Size(755, 22)
        Me.TxtFullPath.TabIndex = 41
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Btn_Agregar_Nueva_Carpeta
        '
        Me.Btn_Agregar_Nueva_Carpeta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Agregar_Nueva_Carpeta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Agregar_Nueva_Carpeta.Image = CType(resources.GetObject("Btn_Agregar_Nueva_Carpeta.Image"), System.Drawing.Image)
        Me.Btn_Agregar_Nueva_Carpeta.ImageAlt = CType(resources.GetObject("Btn_Agregar_Nueva_Carpeta.ImageAlt"), System.Drawing.Image)
        Me.Btn_Agregar_Nueva_Carpeta.Location = New System.Drawing.Point(610, 2)
        Me.Btn_Agregar_Nueva_Carpeta.Name = "Btn_Agregar_Nueva_Carpeta"
        Me.Btn_Agregar_Nueva_Carpeta.Size = New System.Drawing.Size(151, 23)
        Me.Btn_Agregar_Nueva_Carpeta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Agregar_Nueva_Carpeta.TabIndex = 47
        Me.Btn_Agregar_Nueva_Carpeta.Text = "Agregar clasificación"
        '
        'Txt_DescripcionBusqueda
        '
        Me.Txt_DescripcionBusqueda.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Txt_DescripcionBusqueda.Border.Class = "TextBoxBorder"
        Me.Txt_DescripcionBusqueda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Txt_DescripcionBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_DescripcionBusqueda.DisabledBackColor = System.Drawing.Color.White
        Me.Txt_DescripcionBusqueda.FocusHighlightEnabled = True
        Me.Txt_DescripcionBusqueda.ForeColor = System.Drawing.Color.Black
        Me.Txt_DescripcionBusqueda.Location = New System.Drawing.Point(3, 3)
        Me.Txt_DescripcionBusqueda.Name = "Txt_DescripcionBusqueda"
        Me.Txt_DescripcionBusqueda.PreventEnterBeep = True
        Me.Txt_DescripcionBusqueda.Size = New System.Drawing.Size(598, 22)
        Me.Txt_DescripcionBusqueda.TabIndex = 46
        '
        'Imagenes
        '
        Me.Imagenes.ImageStream = CType(resources.GetObject("Imagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagenes.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagenes.Images.SetKeyName(0, "folder.png")
        Me.Imagenes.Images.SetKeyName(1, "folder_open-bookmark.png")
        Me.Imagenes.Images.SetKeyName(2, "folder_open.png")
        Me.Imagenes.Images.SetKeyName(3, "folder_open-error.png")
        Me.Imagenes.Images.SetKeyName(4, "folder_open-option.png")
        Me.Imagenes.Images.SetKeyName(5, "package_small.png")
        Me.Imagenes.Images.SetKeyName(6, "folder-new.png")
        Me.Imagenes.Images.SetKeyName(7, "folder_open-add.png")
        '
        'Switch_Modo_Edicion
        '
        Me.Switch_Modo_Edicion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Switch_Modo_Edicion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Switch_Modo_Edicion.ForeColor = System.Drawing.Color.Black
        Me.Switch_Modo_Edicion.Location = New System.Drawing.Point(111, 487)
        Me.Switch_Modo_Edicion.Name = "Switch_Modo_Edicion"
        Me.Switch_Modo_Edicion.Size = New System.Drawing.Size(66, 22)
        Me.Switch_Modo_Edicion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Switch_Modo_Edicion.TabIndex = 47
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 486)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(93, 23)
        Me.LabelX1.TabIndex = 48
        Me.LabelX1.Text = "EDITAR CARPETAS"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Btn_Agregar_Nueva_Carpeta)
        Me.GroupPanel1.Controls.Add(Me.Txt_DescripcionBusqueda)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(770, 54)
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
        Me.GroupPanel1.TabIndex = 49
        Me.GroupPanel1.Text = "Buscar sub-clasificación dentro de esta clasificación"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ContextMenuBar1)
        Me.GroupPanel2.Controls.Add(Me.Grilla)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 72)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(770, 347)
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
        Me.GroupPanel2.TabIndex = 50
        Me.GroupPanel2.Text = "Carpetas de asociaciones"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.TxtFullPath)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(12, 425)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(770, 55)
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
        Me.GroupPanel3.TabIndex = 51
        Me.GroupPanel3.Text = "Directorio raíz"
        '
        'Barra_Progreso
        '
        Me.Barra_Progreso.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Barra_Progreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Barra_Progreso.ForeColor = System.Drawing.Color.Black
        Me.Barra_Progreso.Location = New System.Drawing.Point(303, 487)
        Me.Barra_Progreso.Name = "Barra_Progreso"
        Me.Barra_Progreso.Size = New System.Drawing.Size(479, 23)
        Me.Barra_Progreso.TabIndex = 52
        Me.Barra_Progreso.Text = "ProgressBarX1"
        Me.Barra_Progreso.Visible = False
        '
        'Frm_Arbol_Asociacion_02
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 571)
        Me.ControlBox = False
        Me.Controls.Add(Me.Barra_Progreso)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Switch_Modo_Edicion)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Arbol_Asociacion_02"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENCION DE ASOCIACIONES DE PRODUCTOS"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Grabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TxtFullPath As System.Windows.Forms.TextBox
    Public WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Progreso_Porc As DevComponents.DotNetBar.CircularProgressItem
    Public WithEvents Btn_Importar_Asociaciones_Desde_Excel As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Ver_Arbol As DevComponents.DotNetBar.ButtonItem
    Public WithEvents BtnEliminarTodo As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_ClasificarMasivamente As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_BuscarClasificacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Txt_DescripcionBusqueda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Btn_Agregar_Nueva_Carpeta As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents Menu_Contextual_01 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Mnu_Btn_Ver_Sub_Carpetas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Mnu_Btn_Eliminar_Clasificacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Mnu_Btn_Ver_Productos_Asociados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Imagenes As System.Windows.Forms.ImageList
    Friend WithEvents Mnu_Btn_Ver_Productos_Sin_Asociacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Switch_Modo_Edicion As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Menu_Contextual_02 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Mnu_Rdb_Es_Padre As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents Mnu_Rdb_Es_Seleccionable As DevComponents.DotNetBar.CheckBoxItem
    Public WithEvents Btn_Exportar_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Menu_Contextual_03 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Mnu_Btn_Carpeta_Actual_Ver_Productos_Asociados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Mnu_Btn_Carpeta_Actual_Ver_Productos_Sin_Asociacion As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Carpeta_Padrel_Ver_Productos_Asociados As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Carpeta_Padre_Ver_Productos_Sin_Asociacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Barra_Progreso As DevComponents.DotNetBar.Controls.ProgressBarX
End Class
