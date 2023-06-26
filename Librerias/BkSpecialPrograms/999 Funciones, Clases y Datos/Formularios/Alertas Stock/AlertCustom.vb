'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Imports System.Windows.Forms
Imports System.Drawing

Public Class AlertCustom
    Inherits DevComponents.DotNetBar.Balloon

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    'Public _SQL_Query As String
    Friend WithEvents Rdb_Unidad_1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Rdb_Unidad_2 As DevComponents.DotNetBar.Controls.CheckBoxX

    Dim _Codigo As String
    Dim _RowProducto As DataRow
    Friend WithEvents Grupo As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbl_Producto As DevComponents.DotNetBar.LabelX
    Friend WithEvents Chk_Agrupar_Asociados As DevComponents.DotNetBar.Controls.CheckBoxX
    Dim _Unidad As Integer

    Dim _Row_Nodo_Clasificaciones As DataRow
    Dim _TblProductos As DataTable
    Dim _Agrupar_Asociados As Boolean

    Dim _Tido As String

    Dim _Mostrar_Stock_Fisico As Boolean
    Dim _Mostrar_Stock_Comprometido As Boolean
    Dim _Mostrar_Stock_Devengado As Boolean
    Dim _Mostrar_Stock_Pedido As Boolean
    Dim _Mostrar_Stock_Disponible As Boolean
    'Dim _Usar_Bodegas_NVI As Boolean

#Region " Windows Form Designer generated code "

    Public Property Pro_Agrupar_Asociados() As Boolean
        Get
            Return _Agrupar_Asociados
        End Get
        Set(ByVal value As Boolean)
            _Agrupar_Asociados = value
            Chk_Agrupar_Asociados.Checked = value
        End Set
    End Property

    Public Property Pro_RowProducto As DataRow
        Get
            Return _RowProducto
        End Get
        Set(value As DataRow)
            _RowProducto = value
        End Set
    End Property

    Public Property Tido As String
        Get
            Return _Tido
        End Get
        Set(value As String)
            _Tido = value
        End Set
    End Property

    Public Property Mostrar_Stock_Fisico As Boolean
        Get
            Return _Mostrar_Stock_Fisico
        End Get
        Set(value As Boolean)
            _Mostrar_Stock_Fisico = value
        End Set
    End Property

    Public Property Mostrar_Stock_Comprometido As Boolean
        Get
            Return _Mostrar_Stock_Comprometido
        End Get
        Set(value As Boolean)
            _Mostrar_Stock_Comprometido = value
        End Set
    End Property

    Public Property Mostrar_Stock_Devengado As Boolean
        Get
            Return _Mostrar_Stock_Devengado
        End Get
        Set(value As Boolean)
            _Mostrar_Stock_Devengado = value
        End Set
    End Property

    Public Property Mostrar_Stock_Pedido As Boolean
        Get
            Return _Mostrar_Stock_Pedido
        End Get
        Set(value As Boolean)
            _Mostrar_Stock_Pedido = value
        End Set
    End Property

    Public Property Mostrar_Stock_Disponible As Boolean
        Get
            Return _Mostrar_Stock_Disponible
        End Get
        Set(value As Boolean)
            _Mostrar_Stock_Disponible = value
        End Set
    End Property

    Public Sub New(ByVal Codigo As String, ByVal Unidad As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        _Codigo = Codigo
        _Unidad = Unidad

        If _Unidad = 1 Then
            Rdb_Unidad_1.Checked = True
            Rdb_Unidad_2.Checked = False
        Else
            Rdb_Unidad_1.Checked = False
            Rdb_Unidad_2.Checked = True
        End If

        Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
        _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents Grilla As DevComponents.DotNetBar.Controls.DataGridViewX

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlertCustom))
        Me.Grilla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Rdb_Unidad_1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Rdb_Unidad_2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Grupo = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Lbl_Producto = New DevComponents.DotNetBar.LabelX()
        Me.Chk_Agrupar_Asociados = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        Me.Grilla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.Size = New System.Drawing.Size(459, 117)
        Me.Grilla.StandardTab = True
        Me.Grilla.TabIndex = 27
        '
        'Rdb_Unidad_1
        '
        '
        '
        '
        Me.Rdb_Unidad_1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Unidad_1.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Unidad_1.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Unidad_1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Unidad_1.Checked = True
        Me.Rdb_Unidad_1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Rdb_Unidad_1.CheckValue = "Y"
        Me.Rdb_Unidad_1.FocusCuesEnabled = False
        Me.Rdb_Unidad_1.Location = New System.Drawing.Point(11, 157)
        Me.Rdb_Unidad_1.Name = "Rdb_Unidad_1"
        Me.Rdb_Unidad_1.Size = New System.Drawing.Size(75, 23)
        Me.Rdb_Unidad_1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Unidad_1.TabIndex = 44
        Me.Rdb_Unidad_1.Text = "Unidad 1"
        '
        'Rdb_Unidad_2
        '
        '
        '
        '
        Me.Rdb_Unidad_2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Rdb_Unidad_2.CheckBoxImageChecked = CType(resources.GetObject("Rdb_Unidad_2.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Rdb_Unidad_2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.Rdb_Unidad_2.FocusCuesEnabled = False
        Me.Rdb_Unidad_2.Location = New System.Drawing.Point(93, 157)
        Me.Rdb_Unidad_2.Name = "Rdb_Unidad_2"
        Me.Rdb_Unidad_2.Size = New System.Drawing.Size(75, 23)
        Me.Rdb_Unidad_2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Rdb_Unidad_2.TabIndex = 45
        Me.Rdb_Unidad_2.Text = "Unidad 2"
        '
        'Grupo
        '
        Me.Grupo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grupo.BackColor = System.Drawing.Color.White
        Me.Grupo.CanvasColor = System.Drawing.SystemColors.Control
        Me.Grupo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Grupo.Controls.Add(Me.Grilla)
        Me.Grupo.DisabledBackColor = System.Drawing.Color.Empty
        Me.Grupo.Location = New System.Drawing.Point(8, 28)
        Me.Grupo.Name = "Grupo"
        Me.Grupo.Size = New System.Drawing.Size(465, 123)
        '
        '
        '
        Me.Grupo.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Grupo.Style.BackColorGradientAngle = 90
        Me.Grupo.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Grupo.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo.Style.BorderBottomWidth = 1
        Me.Grupo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Grupo.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo.Style.BorderLeftWidth = 1
        Me.Grupo.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo.Style.BorderRightWidth = 1
        Me.Grupo.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Grupo.Style.BorderTopWidth = 1
        Me.Grupo.Style.CornerDiameter = 4
        Me.Grupo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Grupo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Grupo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Grupo.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.Grupo.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.Grupo.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Grupo.TabIndex = 46
        '
        'Lbl_Producto
        '
        '
        '
        '
        Me.Lbl_Producto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Lbl_Producto.Location = New System.Drawing.Point(12, 2)
        Me.Lbl_Producto.Name = "Lbl_Producto"
        Me.Lbl_Producto.Size = New System.Drawing.Size(452, 23)
        Me.Lbl_Producto.TabIndex = 47
        Me.Lbl_Producto.Text = "LabelX1"
        '
        'Chk_Agrupar_Asociados
        '
        Me.Chk_Agrupar_Asociados.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Chk_Agrupar_Asociados.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.Chk_Agrupar_Asociados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Chk_Agrupar_Asociados.CheckBoxImageChecked = CType(resources.GetObject("Chk_Agrupar_Asociados.CheckBoxImageChecked"), System.Drawing.Image)
        Me.Chk_Agrupar_Asociados.FocusCuesEnabled = False
        Me.Chk_Agrupar_Asociados.ForeColor = System.Drawing.Color.Black
        Me.Chk_Agrupar_Asociados.Location = New System.Drawing.Point(284, 157)
        Me.Chk_Agrupar_Asociados.Name = "Chk_Agrupar_Asociados"
        Me.Chk_Agrupar_Asociados.Size = New System.Drawing.Size(186, 23)
        Me.Chk_Agrupar_Asociados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Chk_Agrupar_Asociados.TabIndex = 48
        Me.Chk_Agrupar_Asociados.Text = "Agrupar por productos asociados"
        '
        'AlertCustom
        '
        Me.BackColor = System.Drawing.Color.White
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.CaptionFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(485, 183)
        Me.ControlBox = True
        Me.Controls.Add(Me.Chk_Agrupar_Asociados)
        Me.Controls.Add(Me.Grupo)
        Me.Controls.Add(Me.Rdb_Unidad_2)
        Me.Controls.Add(Me.Rdb_Unidad_1)
        Me.Controls.Add(Me.Lbl_Producto)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(0, 0)
        Me.MinimumSize = New System.Drawing.Size(485, 183)
        Me.Name = "AlertCustom"
        Me.Style = DevComponents.DotNetBar.eBallonStyle.Office2007Alert
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub AlertCustom_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim _Nokopr As String = _RowProducto.Item("NOKOPR")
        Dim _Rtu As String = _RowProducto.Item("RLUD")

        If Not (_RowProducto Is Nothing) Then
            Lbl_Producto.Text = "Stock Producto: " & _Codigo & " - " & _Nokopr
        End If

        If _Rtu = 1 Then Rdb_Unidad_2.Enabled = False


        Dim _Nodo_Raiz_Asociados As Integer = CInt(_Global_Row_Configuracion_General.Item("Nodo_Raiz_Asociados"))

        Consulta_sql = "SELECT Top 1 * From " & _Global_BaseBk & "Zw_Prod_Asociacion" & vbCrLf &
                       "Where (Codigo = '" & _Codigo & "') AND (Para_filtro = 1)" & vbCrLf &
                       "And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Nodo_Raiz = " & _Nodo_Raiz_Asociados & ")"

        _Row_Nodo_Clasificaciones = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Codigo_Nodo As Integer

        If _Row_Nodo_Clasificaciones Is Nothing Then
            _Codigo_Nodo = 0
        Else
            _Codigo_Nodo = _Row_Nodo_Clasificaciones.Item("Codigo_Nodo")
        End If

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        _Row_Nodo_Clasificaciones = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "SELECT Distinct KOPR FROM MAEPR WHERE KOPR IN (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Asociacion Where Codigo_Nodo = " & _Codigo_Nodo & " And Codigo_Nodo <> 0)"
        _TblProductos = _Sql.Fx_Get_Tablas(Consulta_sql)

        If _TblProductos.Rows.Count > 1 Then
            Chk_Agrupar_Asociados.Enabled = True
        Else
            Chk_Agrupar_Asociados.Enabled = False
        End If

        AddHandler Rdb_Unidad_1.CheckedChanged, AddressOf Sb_Rdb_Unidad_CheckedChanged
        AddHandler Rdb_Unidad_2.CheckedChanged, AddressOf Sb_Rdb_Unidad_CheckedChanged
        AddHandler Chk_Agrupar_Asociados.CheckedChanged, AddressOf Sb_Chk_Agrupar_Asociados_CheckedChanged

        Sb_Actualizar_Grilla()

    End Sub

    Public Sub Sb_Actualizar_Grilla()

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _Filtro_Productos As String

        If Chk_Agrupar_Asociados.Checked And Not IsNothing(_Row_Nodo_Clasificaciones) Then
            Lbl_Producto.Text = "Stock Producto: " & _Row_Nodo_Clasificaciones.Item("Descripcion")
            _Filtro_Productos = Generar_Filtro_IN(_TblProductos, "", "KOPR", False, False, "'")
        Else
            Lbl_Producto.Text = "Stock Producto: " & _RowProducto.Item("KOPR") & " - " & _RowProducto.Item("NOKOPR")
            _Filtro_Productos = "('" & _Codigo & "')"
        End If

        Dim _Ud As Integer

        If Rdb_Unidad_1.Checked Then
            _Ud = 1
        Else
            _Ud = 2
        End If

        If _Tido = "NVI" Then

            Consulta_sql = "Select Distinct EMPRESA+KOSU+KOBO As Cod,* From TABBO" & vbCrLf &
                           "Where EMPRESA+KOSU+KOBO" & vbCrLf &
                           "In (" & vbCrLf &
                           "Select SUBSTRING(CodPermiso, 5, 10)" & vbCrLf &
                           "From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf &
                           "Where CodUsuario = '" & FUNCIONARIO & "'" & Space(1) &
                           "And CodPermiso In (Select CodPermiso From " & _Global_BaseBk & "ZW_Permisos Where CodFamilia = 'Bodega_NVI'))" & vbCrLf &
                           "Or (EMPRESA = '" & ModEmpresa & "' And KOSU = '" & ModSucursal & "' And KOBO = '" & ModBodega & "')"

        Else

            Consulta_sql = "Select Distinct EMPRESA+KOSU+KOBO As Cod,* From TABBO" & vbCrLf &
                           "Where EMPRESA+KOSU+KOBO" & vbCrLf &
                           "In (" & vbCrLf &
                           "Select SUBSTRING(CodPermiso, 3, 10)" & vbCrLf &
                           "From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf &
                           "Where CodUsuario = '" & FUNCIONARIO & "'" & Space(1) &
                           "And CodPermiso In (Select CodPermiso From " & _Global_BaseBk & "ZW_Permisos Where CodFamilia = 'Bodega'))" & vbCrLf &
                           "Or (EMPRESA = '" & ModEmpresa & "' And KOSU = '" & ModSucursal & "' And KOBO = '" & ModBodega & "')"

        End If

        Dim _Tbl_Bodegas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Filtro As String = Generar_Filtro_IN(_Tbl_Bodegas, "", "Cod", False, False, "'")

        _Filtro = "And Empresa+Sucursal+Bodega In " & _Filtro

        Dim _Orden_Bod = "ORDEN_BOD_" & ModEmpresa.Trim & ModSucursal.Trim

        Consulta_sql = My.Resources.Recursos_Alerta_Stock.Stock_productos_por_emp_suc_bod
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Codigo)
        Consulta_sql = Replace(Consulta_sql, "#Codigos#", _Filtro_Productos)
        Consulta_sql = Replace(Consulta_sql, "#Ud#", _Ud)
        Consulta_sql = Replace(Consulta_sql, "#Filtro#", _Filtro)
        Consulta_sql = Replace(Consulta_sql, "#Tabla#", _Orden_Bod)
        Consulta_sql = Replace(Consulta_sql, "#Global_BaseBk#", _Global_BaseBk)

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("SUC_BOD").Visible = True
            .Columns("SUC_BOD").HeaderText = "Suc-Bod"
            .Columns("SUC_BOD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("SUC_BOD").Width = 60

            .Columns("NOKOBO").Visible = True
            .Columns("NOKOBO").HeaderText = "Bodega"
            .Columns("NOKOBO").Width = 240

            .Columns("ST_FISICO").Visible = Mostrar_Stock_Fisico
            .Columns("ST_FISICO").HeaderText = "Físico"
            .Columns("ST_FISICO").Width = 85
            .Columns("ST_FISICO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_FISICO").DefaultCellStyle.Format = "##,###0.##"
            .Columns("ST_FISICO").ToolTipText = "Stock Ud" & _Unidad



            .Columns("ST_COMPROMETIDO").Visible = Mostrar_Stock_Comprometido
            .Columns("ST_COMPROMETIDO").HeaderText = "Comp.RD"
            .Columns("ST_COMPROMETIDO").Width = 65
            .Columns("ST_COMPROMETIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_COMPROMETIDO").DefaultCellStyle.Format = "##,###0.##"
            .Columns("ST_COMPROMETIDO").ToolTipText = "Stock comprometido Ud" & _Unidad & " (NVV)"

            .Columns("ST_COMPROMETIDO_BK").Visible = Mostrar_Stock_Comprometido
            .Columns("ST_COMPROMETIDO_BK").HeaderText = "Comp.BK"
            .Columns("ST_COMPROMETIDO_BK").Width = 65
            .Columns("ST_COMPROMETIDO_BK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_COMPROMETIDO_BK").DefaultCellStyle.Format = "##,###0.##"
            .Columns("ST_COMPROMETIDO_BK").ToolTipText = "Stock comprometido Ud" & _Unidad & " (NVV - Pendientes de permisos remotos)"

            .Columns("ST_DEVENGADO").Visible = Mostrar_Stock_Devengado
            .Columns("ST_DEVENGADO").HeaderText = "Ven.N/Entr."
            .Columns("ST_DEVENGADO").Width = 65
            .Columns("ST_DEVENGADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_DEVENGADO").DefaultCellStyle.Format = "##,###0.##"
            .Columns("ST_DEVENGADO").ToolTipText = "Ventas no despachadas (Devengados)"

            Dim _NomCampo As String
            Dim _ToolCampo As String

            If String.IsNullOrEmpty(_Tido) Then
                _NomCampo = "Teorico"
                _ToolCampo = "Stock teórico = (Stock físico - Stock devengado- Stock comprometido)"
            Else
                _NomCampo = "Disponible"
                _ToolCampo = "Stock disponible teóricamente Ud" & _Unidad & " (según configuración de calculo de stock)"
            End If

            .Columns("ST_DISPONIBLE").Visible = Mostrar_Stock_Disponible
            .Columns("ST_DISPONIBLE").HeaderText = _NomCampo
            .Columns("ST_DISPONIBLE").Width = 65
            .Columns("ST_DISPONIBLE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_DISPONIBLE").DefaultCellStyle.Format = "##,###0.##"
            .Columns("ST_DISPONIBLE").ToolTipText = _ToolCampo

            .Columns("ST_PEDIDO").Visible = Mostrar_Stock_Pedido
            .Columns("ST_PEDIDO").HeaderText = "Pedido"
            .Columns("ST_PEDIDO").Width = 65
            .Columns("ST_PEDIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_PEDIDO").DefaultCellStyle.Format = "##,###0.##"
            .Columns("ST_PEDIDO").ToolTipText = "Stock Pedido OCC"

        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Suc_Bod = Trim(_Fila.Cells("SUC_BOD").Value)
            Dim _St_Disponible = _Fila.Cells("ST_DISPONIBLE").Value

            Dim _Sucursal As String = _Fila.Cells("Sucursal").Value
            Dim _Bodega As String = _Fila.Cells("Bodega").Value

            If Not String.IsNullOrEmpty(_Tido) Then
                _St_Disponible = Fx_Stock_Disponible(_Tido, ModEmpresa, _Sucursal, _Bodega, _Codigo, _Ud, "STFI" & _Ud)
                If _St_Disponible < 0 Then _St_Disponible = 0
                _Fila.Cells("ST_DISPONIBLE").Value = _St_Disponible
            End If

            If String.IsNullOrEmpty(_Suc_Bod) Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.BackColor = Color.Black
                    _Fila.DefaultCellStyle.ForeColor = Color.Gold
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.Gold
                End If
            Else
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.BackColor = Color.Black
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.White
                End If
            End If

            For Each Columna As DataGridViewColumn In Grilla.Columns
                Dim _Columna As String = Columna.Name
                If _Columna.Contains("ST_") Then

                    Dim _Valor As Double = _Fila.Cells(_Columna).Value

                    Dim _Color_Cero As Color = Color.LightGray
                    Dim _Color_Positivo As Color = Azul
                    Dim _Color_Negativo As Color = Rojo

                    If Global_Thema = Enum_Themas.Oscuro Then
                        _Color_Cero = Color.FromArgb(60, 60, 60)
                        _Color_Positivo = Verde
                    End If

                    If _Valor = 0 Then
                        _Fila.Cells(_Columna).Style.ForeColor = _Color_Cero
                    ElseIf _Valor < 0 Then
                        _Fila.Cells(_Columna).Style.ForeColor = Rojo
                    ElseIf _Valor > 0 Then
                        _Fila.Cells(_Columna).Style.ForeColor = _Color_Positivo
                    End If

                End If
            Next

        Next

    End Sub

    Private Sub Sb_Rdb_Unidad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CType(sender, DevComponents.DotNetBar.Controls.CheckBoxX).Checked Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub AlertCustom_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Sb_Chk_Agrupar_Asociados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Sb_Actualizar_Grilla()
    End Sub

End Class
