<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Inf_Ventas_X_Periodo_Proyeccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Inf_Ventas_X_Periodo_Proyeccion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Ent_Entidades = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Ent_Ciudades = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Ent_Comunas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Ent_Rubros = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Ent_Zonas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Ent_Tipo_Entidad = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Ent_Act_Economica = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Ent_Tamano_Empresa = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Pro_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Super_Familias = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Familias = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Sub_Familias = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Marcas = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Clas_Libre = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Rubros = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Pro_Zonas = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Sucursales = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Bodegas = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Filtro_Responzables = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Filtro_Vendedores = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Btn_Informe_X_Clientes = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Documentos_Entidades = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Informe_X_Productos = New DevComponents.DotNetBar.ButtonItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.Btn_Actualizar_Informe = New DevComponents.DotNetBar.ButtonItem()
        Me.Btn_Excel = New DevComponents.DotNetBar.ButtonItem()
        Me.Grilla_Proyeccion = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Rdb_Prom_R1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Prom_R2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Prorroga_R1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Prorroga_Igual = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Input_Total_Dias = New DevComponents.Editors.IntegerInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Input_Dias_Transcurridos = New DevComponents.Editors.IntegerInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_Dias_Proyeccion = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Grilla_Totales = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Btn_Dias_Feriados = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_FS_desde = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Proyeccion_Desde = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Lbl_FS_hasta = New DevComponents.DotNetBar.LabelX()
        Me.Dtp_Fecha_Proyeccion_Hasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Chk_Domingo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Chk_Sabado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_Proyeccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.Input_Total_Dias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Input_Dias_Transcurridos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
        CType(Me.Grilla_Totales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.Dtp_Fecha_Proyeccion_Desde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp_Fecha_Proyeccion_Hasta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.LabelItem3.Text = "Productos"
        '
        'Btn_Filtro_Ent_Entidades
        '
        Me.Btn_Filtro_Ent_Entidades.Image = CType(resources.GetObject("Btn_Filtro_Ent_Entidades.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Entidades.Name = "Btn_Filtro_Ent_Entidades"
        Me.Btn_Filtro_Ent_Entidades.Text = "Filtrar por <b><font color=""#0072BC"">CLIENTES</font></b>"
        Me.Btn_Filtro_Ent_Entidades.Visible = False
        '
        'Btn_Filtro_Ent_Ciudades
        '
        Me.Btn_Filtro_Ent_Ciudades.Image = CType(resources.GetObject("Btn_Filtro_Ent_Ciudades.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Ciudades.Name = "Btn_Filtro_Ent_Ciudades"
        Me.Btn_Filtro_Ent_Ciudades.Text = "Filtrar por <b><font color=""#0072BC"">CIUDADES</font></b>"
        '
        'Btn_Filtro_Ent_Comunas
        '
        Me.Btn_Filtro_Ent_Comunas.Image = CType(resources.GetObject("Btn_Filtro_Ent_Comunas.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Comunas.Name = "Btn_Filtro_Ent_Comunas"
        Me.Btn_Filtro_Ent_Comunas.Text = "Filtrar por <b><font color=""#0072BC"">COMUNAS</font></b>"
        '
        'Btn_Filtro_Ent_Rubros
        '
        Me.Btn_Filtro_Ent_Rubros.Image = CType(resources.GetObject("Btn_Filtro_Ent_Rubros.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Rubros.Name = "Btn_Filtro_Ent_Rubros"
        Me.Btn_Filtro_Ent_Rubros.Text = "Filtrar por <b><font color=""#0072BC""><font color=""#0072BC"">RUBROS</font></font></" &
    "b>"
        '
        'Btn_Filtro_Ent_Zonas
        '
        Me.Btn_Filtro_Ent_Zonas.Image = CType(resources.GetObject("Btn_Filtro_Ent_Zonas.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Zonas.Name = "Btn_Filtro_Ent_Zonas"
        Me.Btn_Filtro_Ent_Zonas.Text = "Filtrar por <b><font color=""#0072BC"">ZONAS</font></b>"
        '
        'Btn_Filtro_Ent_Tipo_Entidad
        '
        Me.Btn_Filtro_Ent_Tipo_Entidad.Image = CType(resources.GetObject("Btn_Filtro_Ent_Tipo_Entidad.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Tipo_Entidad.Name = "Btn_Filtro_Ent_Tipo_Entidad"
        Me.Btn_Filtro_Ent_Tipo_Entidad.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">TIPO ENTIDAD</font></f" &
    "ont></b>"
        '
        'Btn_Filtro_Ent_Act_Economica
        '
        Me.Btn_Filtro_Ent_Act_Economica.Image = CType(resources.GetObject("Btn_Filtro_Ent_Act_Economica.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Act_Economica.Name = "Btn_Filtro_Ent_Act_Economica"
        Me.Btn_Filtro_Ent_Act_Economica.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">ACT. ECONOMICA</font><" &
    "/font></b>"
        '
        'Btn_Filtro_Ent_Tamano_Empresa
        '
        Me.Btn_Filtro_Ent_Tamano_Empresa.Image = CType(resources.GetObject("Btn_Filtro_Ent_Tamano_Empresa.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Ent_Tamano_Empresa.Name = "Btn_Filtro_Ent_Tamano_Empresa"
        Me.Btn_Filtro_Ent_Tamano_Empresa.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">TAMAÑO EMPRESA</font><" &
    "/font></b>"
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
        Me.LabelItem2.Text = "Productos"
        '
        'Btn_Filtro_Pro_Productos
        '
        Me.Btn_Filtro_Pro_Productos.Image = CType(resources.GetObject("Btn_Filtro_Pro_Productos.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Productos.Name = "Btn_Filtro_Pro_Productos"
        Me.Btn_Filtro_Pro_Productos.Text = "Filtrar por <b><font color=""#0072BC"">PRODUCTOS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</font></b>"
        Me.Btn_Filtro_Pro_Productos.Visible = False
        '
        'Btn_Filtro_Pro_Super_Familias
        '
        Me.Btn_Filtro_Pro_Super_Familias.Image = CType(resources.GetObject("Btn_Filtro_Pro_Super_Familias.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Super_Familias.Name = "Btn_Filtro_Pro_Super_Familias"
        Me.Btn_Filtro_Pro_Super_Familias.Text = "Filtrar por <b><font color=""#0072BC"">SUPER FAMILIAS</font></b>"
        '
        'Btn_Filtro_Pro_Familias
        '
        Me.Btn_Filtro_Pro_Familias.Image = CType(resources.GetObject("Btn_Filtro_Pro_Familias.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Familias.Name = "Btn_Filtro_Pro_Familias"
        Me.Btn_Filtro_Pro_Familias.Text = "Filtrar por <b><font color=""#0072BC"">FAMILIAS</font></b>"
        '
        'Btn_Filtro_Pro_Sub_Familias
        '
        Me.Btn_Filtro_Pro_Sub_Familias.Image = CType(resources.GetObject("Btn_Filtro_Pro_Sub_Familias.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Sub_Familias.Name = "Btn_Filtro_Pro_Sub_Familias"
        Me.Btn_Filtro_Pro_Sub_Familias.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">SUB FAMILIAS</font></f" &
    "ont></b>"
        '
        'Btn_Filtro_Pro_Marcas
        '
        Me.Btn_Filtro_Pro_Marcas.Image = CType(resources.GetObject("Btn_Filtro_Pro_Marcas.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Marcas.Name = "Btn_Filtro_Pro_Marcas"
        Me.Btn_Filtro_Pro_Marcas.Text = "Filtrar por <b><font color=""#0072BC"">MARCAS</font></b>"
        '
        'Btn_Filtro_Pro_Clas_Libre
        '
        Me.Btn_Filtro_Pro_Clas_Libre.Image = CType(resources.GetObject("Btn_Filtro_Pro_Clas_Libre.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Clas_Libre.Name = "Btn_Filtro_Pro_Clas_Libre"
        Me.Btn_Filtro_Pro_Clas_Libre.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">CLAS. LIBRE</font></fo" &
    "nt></b>"
        '
        'Btn_Filtro_Pro_Rubros
        '
        Me.Btn_Filtro_Pro_Rubros.Image = CType(resources.GetObject("Btn_Filtro_Pro_Rubros.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Rubros.Name = "Btn_Filtro_Pro_Rubros"
        Me.Btn_Filtro_Pro_Rubros.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">RUBROS</font></font></" &
    "b>"
        '
        'Btn_Filtro_Pro_Zonas
        '
        Me.Btn_Filtro_Pro_Zonas.Image = CType(resources.GetObject("Btn_Filtro_Pro_Zonas.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Pro_Zonas.Name = "Btn_Filtro_Pro_Zonas"
        Me.Btn_Filtro_Pro_Zonas.Text = "Filtrar por <b><font color=""#4E5D30""><font color=""#0072BC"">ZONAS</font></font></b" &
    ">"
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
        Me.LabelItem4.Text = "Productos"
        '
        'Btn_Filtro_Sucursales
        '
        Me.Btn_Filtro_Sucursales.Image = CType(resources.GetObject("Btn_Filtro_Sucursales.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Sucursales.Name = "Btn_Filtro_Sucursales"
        Me.Btn_Filtro_Sucursales.Text = "Filtrar por <b><font color=""#0072BC"">SUCURSALES</font></b>"
        '
        'Btn_Filtro_Bodegas
        '
        Me.Btn_Filtro_Bodegas.Image = CType(resources.GetObject("Btn_Filtro_Bodegas.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Bodegas.Name = "Btn_Filtro_Bodegas"
        Me.Btn_Filtro_Bodegas.Text = "Filtrar por <b><font color=""#0072BC"">BODEGAS</font></b>"
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
        Me.LabelItem5.Text = "Productos"
        '
        'Btn_Filtro_Responzables
        '
        Me.Btn_Filtro_Responzables.Image = CType(resources.GetObject("Btn_Filtro_Responzables.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Responzables.Name = "Btn_Filtro_Responzables"
        Me.Btn_Filtro_Responzables.Text = "Filtrar por <b><font color=""#0072BC"">RESPONZABLE</font></b>"
        '
        'Btn_Filtro_Vendedores
        '
        Me.Btn_Filtro_Vendedores.Image = CType(resources.GetObject("Btn_Filtro_Vendedores.Image"), System.Drawing.Image)
        Me.Btn_Filtro_Vendedores.Name = "Btn_Filtro_Vendedores"
        Me.Btn_Filtro_Vendedores.Text = "Filtrar por <b><font color=""#0072BC"">VENDEDOR</font></b>"
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
        Me.LabelItem1.Text = "Informe detallado"
        '
        'Btn_Informe_X_Clientes
        '
        Me.Btn_Informe_X_Clientes.Image = CType(resources.GetObject("Btn_Informe_X_Clientes.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Clientes.Name = "Btn_Informe_X_Clientes"
        Me.Btn_Informe_X_Clientes.Text = "Ver detalle de los <b><font color=""#22B14C"">Clientes -> Documentos -> Detalle</fo" &
    "nt></b>"
        '
        'Btn_Informe_X_Documentos_Entidades
        '
        Me.Btn_Informe_X_Documentos_Entidades.Image = CType(resources.GetObject("Btn_Informe_X_Documentos_Entidades.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Documentos_Entidades.Name = "Btn_Informe_X_Documentos_Entidades"
        Me.Btn_Informe_X_Documentos_Entidades.Text = "Ver detalle de las <b><font color=""#22B14C"">Documentos -> Clientes</font></b>"
        Me.Btn_Informe_X_Documentos_Entidades.Visible = False
        '
        'Btn_Informe_X_Productos
        '
        Me.Btn_Informe_X_Productos.Image = CType(resources.GetObject("Btn_Informe_X_Productos.Image"), System.Drawing.Image)
        Me.Btn_Informe_X_Productos.Name = "Btn_Informe_X_Productos"
        Me.Btn_Informe_X_Productos.Text = "Ver detalle de los <b><font color=""#22B14C"">Productos->Detalle</font></b>"
        Me.Btn_Informe_X_Productos.Visible = False
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Btn_Actualizar_Informe, Me.Btn_Excel})
        Me.Bar1.Location = New System.Drawing.Point(0, 562)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1118, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 107
        Me.Bar1.TabStop = False
        '
        'Btn_Actualizar_Informe
        '
        Me.Btn_Actualizar_Informe.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Actualizar_Informe.ForeColor = System.Drawing.Color.Black
        Me.Btn_Actualizar_Informe.Image = CType(resources.GetObject("Btn_Actualizar_Informe.Image"), System.Drawing.Image)
        Me.Btn_Actualizar_Informe.ImageAlt = CType(resources.GetObject("Btn_Actualizar_Informe.ImageAlt"), System.Drawing.Image)
        Me.Btn_Actualizar_Informe.Name = "Btn_Actualizar_Informe"
        Me.Btn_Actualizar_Informe.Text = "Actualizar"
        '
        'Btn_Excel
        '
        Me.Btn_Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.Btn_Excel.ForeColor = System.Drawing.Color.Black
        Me.Btn_Excel.Image = CType(resources.GetObject("Btn_Excel.Image"), System.Drawing.Image)
        Me.Btn_Excel.ImageAlt = CType(resources.GetObject("Btn_Excel.ImageAlt"), System.Drawing.Image)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Tooltip = "Exportar a Excel"
        '
        'Grilla_Proyeccion
        '
        Me.Grilla_Proyeccion.AllowUserToAddRows = False
        Me.Grilla_Proyeccion.AllowUserToDeleteRows = False
        Me.Grilla_Proyeccion.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.Grilla_Proyeccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Proyeccion.DefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Proyeccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Proyeccion.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Proyeccion.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Proyeccion.Name = "Grilla_Proyeccion"
        Me.Grilla_Proyeccion.ReadOnly = True
        Me.Grilla_Proyeccion.Size = New System.Drawing.Size(1088, 303)
        Me.Grilla_Proyeccion.TabIndex = 108
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Grilla_Proyeccion)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(15, 99)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1094, 326)
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
        Me.GroupPanel1.TabIndex = 109
        Me.GroupPanel1.Text = "Detalle de la proyección"
        '
        'Rdb_Prom_R1
        '
        Me.Rdb_Prom_R1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Prom_R1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Prom_R1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Prom_R1.Checked = True
        Me.Rdb_Prom_R1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Prom_R1.CheckValue = "Y"
        Me.Rdb_Prom_R1.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Prom_R1.Location = New System.Drawing.Point(3, 6)
        Me.Rdb_Prom_R1.Name = "Rdb_Prom_R1"
        Me.Rdb_Prom_R1.Size = New System.Drawing.Size(233, 22)
        Me.Rdb_Prom_R1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Prom_R1.TabIndex = 156
        Me.Rdb_Prom_R1.Text = "Calcular promedio de ventas con Rango 1"
        '
        'Rdb_Prom_R2
        '
        Me.Rdb_Prom_R2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Prom_R2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Prom_R2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Prom_R2.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Prom_R2.Location = New System.Drawing.Point(3, 34)
        Me.Rdb_Prom_R2.Name = "Rdb_Prom_R2"
        Me.Rdb_Prom_R2.Size = New System.Drawing.Size(249, 17)
        Me.Rdb_Prom_R2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Prom_R2.TabIndex = 157
        Me.Rdb_Prom_R2.Text = "Calcular promedio de ventas con Rango 2"
        '
        'Rdb_Prorroga_R1
        '
        Me.Rdb_Prorroga_R1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Prorroga_R1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Prorroga_R1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Prorroga_R1.Checked = True
        Me.Rdb_Prorroga_R1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Prorroga_R1.CheckValue = "Y"
        Me.Rdb_Prorroga_R1.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Prorroga_R1.Location = New System.Drawing.Point(3, 6)
        Me.Rdb_Prorroga_R1.Name = "Rdb_Prorroga_R1"
        Me.Rdb_Prorroga_R1.Size = New System.Drawing.Size(281, 22)
        Me.Rdb_Prorroga_R1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Prorroga_R1.TabIndex = 158
        Me.Rdb_Prorroga_R1.Text = "Prorrogar según % de ventas del Rango 1"
        '
        'Rdb_Prorroga_Igual
        '
        Me.Rdb_Prorroga_Igual.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Rdb_Prorroga_Igual.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Prorroga_Igual.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Prorroga_Igual.ForeColor = System.Drawing.Color.Black
        Me.Rdb_Prorroga_Igual.Location = New System.Drawing.Point(3, 34)
        Me.Rdb_Prorroga_Igual.Name = "Rdb_Prorroga_Igual"
        Me.Rdb_Prorroga_Igual.Size = New System.Drawing.Size(235, 17)
        Me.Rdb_Prorroga_Igual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Prorroga_Igual.TabIndex = 159
        Me.Rdb_Prorroga_Igual.Text = "Prorrogar ventas en % igual para todos"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Rdb_Prom_R1)
        Me.GroupPanel2.Controls.Add(Me.Rdb_Prom_R2)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(15, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(239, 81)
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
        Me.GroupPanel2.TabIndex = 160
        Me.GroupPanel2.Text = "Calculo de proyección"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Rdb_Prorroga_R1)
        Me.GroupPanel3.Controls.Add(Me.Rdb_Prorroga_Igual)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(260, 12)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(247, 81)
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
        Me.GroupPanel3.TabIndex = 161
        Me.GroupPanel3.Text = "Prorroga de venta"
        '
        'Input_Total_Dias
        '
        '
        '
        '
        Me.Input_Total_Dias.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Total_Dias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Total_Dias.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Total_Dias.ForeColor = System.Drawing.Color.Black
        Me.Input_Total_Dias.Location = New System.Drawing.Point(122, 51)
        Me.Input_Total_Dias.MaxValue = 365
        Me.Input_Total_Dias.MinValue = 1
        Me.Input_Total_Dias.Name = "Input_Total_Dias"
        Me.Input_Total_Dias.ShowUpDown = True
        Me.Input_Total_Dias.Size = New System.Drawing.Size(73, 22)
        Me.Input_Total_Dias.TabIndex = 162
        Me.Input_Total_Dias.Value = 1
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(3, 51)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(90, 20)
        Me.LabelX1.TabIndex = 163
        Me.LabelX1.Text = "Total días"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(90, 18)
        Me.LabelX2.TabIndex = 165
        Me.LabelX2.Text = "Días trascurridos"
        '
        'Input_Dias_Transcurridos
        '
        '
        '
        '
        Me.Input_Dias_Transcurridos.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Input_Dias_Transcurridos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Input_Dias_Transcurridos.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.Input_Dias_Transcurridos.ForeColor = System.Drawing.Color.Black
        Me.Input_Dias_Transcurridos.Location = New System.Drawing.Point(122, 3)
        Me.Input_Dias_Transcurridos.MaxValue = 365
        Me.Input_Dias_Transcurridos.MinValue = 0
        Me.Input_Dias_Transcurridos.Name = "Input_Dias_Transcurridos"
        Me.Input_Dias_Transcurridos.ShowUpDown = True
        Me.Input_Dias_Transcurridos.Size = New System.Drawing.Size(73, 22)
        Me.Input_Dias_Transcurridos.TabIndex = 164
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(523, 66)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(90, 18)
        Me.LabelX3.TabIndex = 166
        Me.LabelX3.Text = "Días proyección"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.60606!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.39394!))
        Me.TableLayoutPanel1.Controls.Add(Me.Input_Dias_Transcurridos, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Input_Total_Dias, 1, 2)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(641, 451)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(198, 74)
        Me.TableLayoutPanel1.TabIndex = 167
        Me.TableLayoutPanel1.Visible = False
        '
        'Lbl_Dias_Proyeccion
        '
        Me.Lbl_Dias_Proyeccion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Lbl_Dias_Proyeccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Dias_Proyeccion.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Dias_Proyeccion.Location = New System.Drawing.Point(619, 67)
        Me.Lbl_Dias_Proyeccion.Name = "Lbl_Dias_Proyeccion"
        Me.Lbl_Dias_Proyeccion.Size = New System.Drawing.Size(44, 18)
        Me.Lbl_Dias_Proyeccion.TabIndex = 168
        Me.Lbl_Dias_Proyeccion.Text = "0"
        Me.Lbl_Dias_Proyeccion.TextAlignment = System.Drawing.StringAlignment.Far
        Me.Lbl_Dias_Proyeccion.TextLineAlignment = System.Drawing.StringAlignment.Near
        '
        'GroupPanel4
        '
        Me.GroupPanel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel4.BackColor = System.Drawing.Color.White
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Grilla_Totales)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Location = New System.Drawing.Point(15, 431)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(558, 113)
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
        Me.GroupPanel4.TabIndex = 168
        Me.GroupPanel4.Text = "Totales proyección"
        '
        'Grilla_Totales
        '
        Me.Grilla_Totales.AllowUserToAddRows = False
        Me.Grilla_Totales.AllowUserToDeleteRows = False
        Me.Grilla_Totales.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.Grilla_Totales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Totales.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Totales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Totales.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Grilla_Totales.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Totales.Name = "Grilla_Totales"
        Me.Grilla_Totales.Size = New System.Drawing.Size(552, 90)
        Me.Grilla_Totales.TabIndex = 108
        '
        'Btn_Dias_Feriados
        '
        Me.Btn_Dias_Feriados.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Dias_Feriados.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Dias_Feriados.Image = CType(resources.GetObject("Btn_Dias_Feriados.Image"), System.Drawing.Image)
        Me.Btn_Dias_Feriados.ImageAlt = CType(resources.GetObject("Btn_Dias_Feriados.ImageAlt"), System.Drawing.Image)
        Me.Btn_Dias_Feriados.Location = New System.Drawing.Point(806, 38)
        Me.Btn_Dias_Feriados.Name = "Btn_Dias_Feriados"
        Me.Btn_Dias_Feriados.Size = New System.Drawing.Size(33, 22)
        Me.Btn_Dias_Feriados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Dias_Feriados.TabIndex = 173
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(523, 13)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(160, 19)
        Me.LabelX5.TabIndex = 172
        Me.LabelX5.Text = "Fecha proyección"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.72581!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.84932!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.16245!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.90614!))
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_FS_desde, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Dtp_Fecha_Proyeccion_Desde, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Lbl_FS_hasta, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Dtp_Fecha_Proyeccion_Hasta, 3, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(523, 35)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(277, 25)
        Me.TableLayoutPanel2.TabIndex = 169
        '
        'Lbl_FS_desde
        '
        '
        '
        '
        Me.Lbl_FS_desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FS_desde.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FS_desde.Location = New System.Drawing.Point(3, 3)
        Me.Lbl_FS_desde.Name = "Lbl_FS_desde"
        Me.Lbl_FS_desde.Size = New System.Drawing.Size(32, 19)
        Me.Lbl_FS_desde.TabIndex = 7
        Me.Lbl_FS_desde.Text = "Desde"
        '
        'Dtp_Fecha_Proyeccion_Desde
        '
        '
        '
        '
        Me.Dtp_Fecha_Proyeccion_Desde.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Proyeccion_Desde.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Proyeccion_Desde.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Proyeccion_Desde.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Proyeccion_Desde.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Proyeccion_Desde.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Proyeccion_Desde.Location = New System.Drawing.Point(46, 3)
        '
        '
        '
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Proyeccion_Desde.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Proyeccion_Desde.Name = "Dtp_Fecha_Proyeccion_Desde"
        Me.Dtp_Fecha_Proyeccion_Desde.Size = New System.Drawing.Size(79, 22)
        Me.Dtp_Fecha_Proyeccion_Desde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Proyeccion_Desde.TabIndex = 7
        Me.Dtp_Fecha_Proyeccion_Desde.Value = New Date(2016, 7, 8, 16, 32, 31, 0)
        '
        'Lbl_FS_hasta
        '
        '
        '
        '
        Me.Lbl_FS_hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_FS_hasta.ForeColor = System.Drawing.Color.Black
        Me.Lbl_FS_hasta.Location = New System.Drawing.Point(133, 3)
        Me.Lbl_FS_hasta.Name = "Lbl_FS_hasta"
        Me.Lbl_FS_hasta.Size = New System.Drawing.Size(28, 19)
        Me.Lbl_FS_hasta.TabIndex = 9
        Me.Lbl_FS_hasta.Text = "Hasta"
        '
        'Dtp_Fecha_Proyeccion_Hasta
        '
        '
        '
        '
        Me.Dtp_Fecha_Proyeccion_Hasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.Dtp_Fecha_Proyeccion_Hasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Proyeccion_Hasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.Dtp_Fecha_Proyeccion_Hasta.ButtonDropDown.Visible = True
        Me.Dtp_Fecha_Proyeccion_Hasta.ForeColor = System.Drawing.Color.Black
        Me.Dtp_Fecha_Proyeccion_Hasta.IsPopupCalendarOpen = False
        Me.Dtp_Fecha_Proyeccion_Hasta.Location = New System.Drawing.Point(174, 3)
        '
        '
        '
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.TodayButtonVisible = True
        Me.Dtp_Fecha_Proyeccion_Hasta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.Dtp_Fecha_Proyeccion_Hasta.Name = "Dtp_Fecha_Proyeccion_Hasta"
        Me.Dtp_Fecha_Proyeccion_Hasta.Size = New System.Drawing.Size(81, 22)
        Me.Dtp_Fecha_Proyeccion_Hasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Dtp_Fecha_Proyeccion_Hasta.TabIndex = 8
        Me.Dtp_Fecha_Proyeccion_Hasta.Value = New Date(2016, 7, 8, 16, 33, 0, 0)
        '
        'Chk_Domingo
        '
        Me.Chk_Domingo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Domingo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Domingo.ForeColor = System.Drawing.Color.Black
        Me.Chk_Domingo.Location = New System.Drawing.Point(846, 61)
        Me.Chk_Domingo.Name = "Chk_Domingo"
        Me.Chk_Domingo.Size = New System.Drawing.Size(147, 17)
        Me.Chk_Domingo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Domingo.TabIndex = 175
        Me.Chk_Domingo.Text = "Considerar día Domingo"
        '
        'Chk_Sabado
        '
        Me.Chk_Sabado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Sabado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Sabado.ForeColor = System.Drawing.Color.Black
        Me.Chk_Sabado.Location = New System.Drawing.Point(846, 38)
        Me.Chk_Sabado.Name = "Chk_Sabado"
        Me.Chk_Sabado.Size = New System.Drawing.Size(138, 17)
        Me.Chk_Sabado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Sabado.TabIndex = 174
        Me.Chk_Sabado.Text = "Considerar día Sábado"
        '
        'Frm_Inf_Ventas_X_Periodo_Proyeccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1118, 603)
        Me.Controls.Add(Me.Chk_Domingo)
        Me.Controls.Add(Me.Chk_Sabado)
        Me.Controls.Add(Me.Lbl_Dias_Proyeccion)
        Me.Controls.Add(Me.Btn_Dias_Feriados)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "Frm_Inf_Ventas_X_Periodo_Proyeccion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PROYECCION DE VENTAS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_Proyeccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.Input_Total_Dias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Input_Dias_Transcurridos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupPanel4.ResumeLayout(False)
        CType(Me.Grilla_Totales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.Dtp_Fecha_Proyeccion_Desde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp_Fecha_Proyeccion_Hasta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Ent_Entidades As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Ent_Ciudades As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Ent_Comunas As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Ent_Rubros As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Ent_Zonas As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Ent_Tipo_Entidad As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Ent_Act_Economica As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Ent_Tamano_Empresa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Pro_Productos As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Super_Familias As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Familias As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Sub_Familias As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Marcas As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Clas_Libre As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Rubros As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Pro_Zonas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Sucursales As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Bodegas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Public WithEvents Btn_Filtro_Responzables As DevComponents.DotNetBar.ButtonItem
    Public WithEvents Btn_Filtro_Vendedores As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Btn_Informe_X_Clientes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Informe_X_Documentos_Entidades As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Btn_Informe_X_Productos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Btn_Excel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Grilla_Proyeccion As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Rdb_Prom_R1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Prom_R2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Prorroga_R1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Prorroga_Igual As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Input_Total_Dias As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Input_Dias_Transcurridos As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lbl_Dias_Proyeccion As DevComponents.DotNetBar.LabelX
    Friend WithEvents Btn_Actualizar_Informe As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Grilla_Totales As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Btn_Dias_Feriados As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lbl_FS_desde As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Proyeccion_Desde As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Lbl_FS_hasta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Dtp_Fecha_Proyeccion_Hasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Chk_Domingo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk_Sabado As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
