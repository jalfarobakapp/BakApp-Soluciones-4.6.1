'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Filtro_Especial_Informes_Opciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Tbl_Filtro_Entidad As DataTable
    Dim _Tbl_Filtro_Vendedor As DataTable
    Dim _Tbl_Filtro_Ciudad As DataTable
    Dim _Tbl_Filtro_Comunas As DataTable

    Dim _Tbl_Filtro_Productos As DataTable
    Dim _Tbl_Filtro_Super_Familias As DataTable
    Dim _Tbl_Filtro_Marcas As DataTable
    Dim _Tbl_Filtro_Rubro_Productos As DataTable
    Dim _Tbl_Filtro_Clalibpr As DataTable
    Dim _Tbl_Filtro_Zonas_Productos As DataTable

    Dim _Filtro_Extra_Entidad, _
        _Filtro_Extra_Vendedor, _
        _Filtro_Extra_Ciudad, _
        _Filtro_Extra_Comunas, _
        _Filtro_Extra_Productos, _
        _Filtro_Extra_Super_Familias, _
        _Filtro_Extra_Marcas, _
        _Filtro_Extra_Rubro_Productos, _
        _Filtro_Extra_Clalibpr, _
        _Filtro_Extra_Zonas_Productos As String

    Dim _Aceptar As Boolean
    Public ReadOnly Property Pro_Aceptar() As Boolean
        Get
            Return _Aceptar
        End Get
    End Property
    'Dim _Filtro_Marcas_Todas As Boolean
    'Dim _Filtro_Super_Familias_Todas As Boolean
    'Dim _Filtro_Rubro_Todas As Boolean
    'Dim _Filtro_Clalibpr_Todas As Boolean
    'Dim _Filtro_Zonas_Todas As Boolean

    Public Property Pro_Filtro_Extra_Entidad()
        Get
            Return _Filtro_Extra_Entidad
        End Get
        Set(ByVal value)
            _Filtro_Extra_Entidad = value
        End Set
    End Property

    Public Property Pro_Filtro_Extra_Vendedor()
        Get
            Return _Filtro_Extra_Vendedor
        End Get
        Set(ByVal value)
            _Filtro_Extra_Vendedor = value
        End Set
    End Property

    Public Property Pro_Filtro_Extra_Ciudad()
        Get
            Return _Filtro_Extra_Ciudad
        End Get
        Set(ByVal value)
            _Filtro_Extra_Ciudad = value
        End Set
    End Property

    Public Property Pro_Filtro_Extra_Comunas()
        Get
            Return _Filtro_Extra_Comunas
        End Get
        Set(ByVal value)
            _Filtro_Extra_Comunas = value
        End Set
    End Property

    Public Property Pro_Filtro_Extra_Productos()
        Get
            Return _Filtro_Extra_Productos
        End Get
        Set(ByVal value)
            _Filtro_Extra_Productos = value
        End Set
    End Property

    Public Property Pro_Filtro_Extra_Super_Familias()
        Get
            Return _Filtro_Extra_Super_Familias
        End Get
        Set(ByVal value)
            _Filtro_Extra_Super_Familias = value
        End Set
    End Property

    Public Property Pro_Filtro_Extra_Marcas()
        Get
            Return _Filtro_Extra_Marcas
        End Get
        Set(ByVal value)
            _Filtro_Extra_Marcas = value
        End Set
    End Property

    Public Property Pro_Filtro_Extra_Rubro_Productos()
        Get
            Return _Filtro_Extra_Rubro_Productos
        End Get
        Set(ByVal value)
            _Filtro_Extra_Rubro_Productos = value
        End Set
    End Property



    Public Property Pro_Tbl_Filtro_Entidad() As DataTable
        Get
            Return _Tbl_Filtro_Entidad
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Entidad = value
        End Set
    End Property

    Public Property Pro_Tbl_Filtro_Ciudad() As DataTable
        Get
            Return _Tbl_Filtro_Ciudad
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Ciudad = value
        End Set
    End Property

    Public Property Pro_Tbl_Filtro_Comunas() As DataTable
        Get
            Return _Tbl_Filtro_Comunas
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Comunas = value
        End Set
    End Property

    Public Property Pro_Tbl_Filtro_Vendedor() As DataTable
        Get
            Return _Tbl_Filtro_Vendedor
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Vendedor = value
        End Set
    End Property

    Public Property Pro_Tbl_Filtro_Productos() As DataTable
        Get
            Return _Tbl_Filtro_Productos
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Productos = value
        End Set
    End Property

    Public Property Pro_Tbl_Filtro_Super_Familias() As DataTable
        Get
            Return _Tbl_Filtro_Super_Familias
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Super_Familias = value
        End Set
    End Property

    Public Property Pro_Tbl_Filtro_Marcas() As DataTable
        Get
            Return _Tbl_Filtro_Marcas
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Marcas = value
        End Set
    End Property

    Public Property Pro_Tbl_Filtro_Rubro() As DataTable
        Get
            Return _Tbl_Filtro_Rubro_Productos
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Rubro_Productos = value
        End Set
    End Property

    Public Property Pro_Tbl_Filtro_Clalibpr() As DataTable
        Get
            Return _Tbl_Filtro_Clalibpr
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Clalibpr = value
        End Set
    End Property

    Public Property Pro_Tbl_Filtro_Zonas() As DataTable
        Get
            Return _Tbl_Filtro_Zonas_Productos
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Zonas_Productos = value
        End Set
    End Property

    Public Property Pro_Filtro_Enitades_Todas() As Boolean
        Get
            Return Rdb_Entidades_Todas.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Entidades_Todas.Checked = True
            Else
                Rdb_Entidades_Algunas.Checked = True
            End If
        End Set
    End Property

    Public Property Pro_Filtro_Ciudad_Todas() As Boolean
        Get
            Return Rdb_Ciudad_Todas.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Ciudad_Todas.Checked = True
            Else
                Rdb_Ciudad_Algunas.Checked = True
            End If
        End Set
    End Property

    Public Property Pro_Filtro_Comunas_Todas() As Boolean
        Get
            Return Rdb_Comunas_Todas.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Comunas_Todas.Checked = True
            Else
                Rdb_Comunas_Algunas.Checked = True
            End If
        End Set
    End Property

    Public Property Pro_Filtro_Vendedores_Todos() As Boolean
        Get
            Return Rdb_Vendedores_Todos.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Vendedores_Todos.Checked = True
            Else
                Rdb_Vendedores_Algunos.Checked = True
            End If
        End Set
    End Property

    Public Property Pro_Filtro_Productos_Todos() As Boolean
        Get
            Return Rdb_Productos_Todos.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Productos_Todos.Checked = True
            Else
                Rdb_Productos_Algunos.Checked = True
            End If
        End Set
    End Property

    Public Property Pro_Filtro_Marcas_Todas() As Boolean
        Get
            Return Rdb_Marcas_Todas.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Marcas_Todas.Checked = True
            Else
                Rdb_Marcas_Algunas.Checked = True
            End If
        End Set
    End Property

    Public Property Pro_Filtro_Super_Familias_Todas() As Boolean
        Get
            Return Rdb_Super_Familias_Todas.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Super_Familias_Todas.Checked = True
            Else
                Rdb_Super_Familias_Algunas.Checked = True
            End If
        End Set
    End Property

    Public Property Pro_Filtro_Rubro_Todas() As Boolean
        Get
            Return Rdb_Rubros_Todos.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Rubros_Todos.Checked = True
            Else
                Rdb_Rubros_Algunos.Checked = True
            End If
        End Set
    End Property

    Public Property Pro_Filtro_Clalibpr_Todas() As Boolean
        Get
            Return Rdb_Clasificacion_Libre_Todas.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Clasificacion_Libre_Todas.Checked = True
            Else
                Rdb_Clasificacion_Libre_Algunas.Checked = True
            End If
        End Set
    End Property

    Public Property Pro_Filtro_Zonas_Todas() As Boolean
        Get
            Return Rdb_Zonas_Todas.Checked
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Rdb_Zonas_Todas.Checked = True
            Else
                Rdb_Zonas_Algunas.Checked = True
            End If
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Filtro_Especial_Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Rdb_Entidades_Algunas.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Ciudad_Algunas.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Comunas_Algunas.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Vendedores_Algunos.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Productos_Algunos.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Clasificacion_Libre_Algunas.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Marcas_Algunas.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Rubros_Algunos.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Super_Familias_Algunas.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Zonas_Algunas.CheckedChanged, AddressOf Rdb_CheckedChanged

    End Sub

    Private Sub Rdb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Control As DevComponents.DotNetBar.Controls.CheckBoxX = sender
        Dim _Control_Todas As DevComponents.DotNetBar.Controls.CheckBoxX

        Dim _Tabla_Fl As Enum_Tabla_Fl
        Dim _Nombre_Control = CType(sender, Control).Name
        Dim _Tbl_Filtro As Object
        Dim _Sql_Filtro_Condicion_Extra = String.Empty

        Select Case _Nombre_Control

            Case "Rdb_Entidades_Algunas"
                _Tbl_Filtro = _Tbl_Filtro_Entidad
                _Tabla_Fl = Enum_Tabla_Fl._Entidades
                _Control_Todas = Rdb_Entidades_Todas
            Case "Rdb_Ciudad_Algunas"
                _Tbl_Filtro = _Tbl_Filtro_Ciudad
                _Tabla_Fl = Enum_Tabla_Fl._Ciudades
                _Control_Todas = Rdb_Ciudad_Todas
            Case "Rdb_Comunas_Algunas"
                _Tbl_Filtro = _Tbl_Filtro_Comunas
                _Tabla_Fl = Enum_Tabla_Fl._Comunas
                _Control_Todas = Rdb_Comunas_Todas
            Case "Rdb_Vendedores_Algunos"
                _Tbl_Filtro = _Tbl_Filtro_Vendedor
                _Tabla_Fl = Enum_Tabla_Fl._Funcionarios_Random
                _Control_Todas = Rdb_Vendedores_Todos
            Case "Rdb_Productos_Algunos"
                _Tbl_Filtro = _Tbl_Filtro_Productos
                _Tabla_Fl = Enum_Tabla_Fl._Productos
                _Control_Todas = Rdb_Productos_Todos
            Case "Rdb_Clasificacion_Libre_Algunas"
                _Tbl_Filtro = _Tbl_Filtro_Clalibpr
                _Tabla_Fl = Enum_Tabla_Fl._Tabla_Tabcarac
                _Sql_Filtro_Condicion_Extra = "And KOTABLA = 'CLALIBPR'"
                _Control_Todas = Rdb_Clasificacion_Libre_Todas
            Case "Rdb_Marcas_Algunas"
                _Tbl_Filtro = _Tbl_Filtro_Marcas
                _Tabla_Fl = Enum_Tabla_Fl._Tabla_Marcas
                _Control_Todas = Rdb_Marcas_Todas
            Case "Rdb_Super_Familias_Algunas"
                _Tbl_Filtro = _Tbl_Filtro_Super_Familias
                _Tabla_Fl = Enum_Tabla_Fl._Tabla_Super_Familia
                _Control_Todas = Rdb_Super_Familias_Todas
            Case "Rdb_Rubros_Algunos"
                _Tbl_Filtro = _Tbl_Filtro_Rubro_Productos
                _Tabla_Fl = Enum_Tabla_Fl._Tabla_Rubros
                _Control_Todas = Rdb_Rubros_Todos
            Case "Rdb_Zonas_Algunas"
                _Tbl_Filtro = _Tbl_Filtro_Zonas_Productos
                _Tabla_Fl = Enum_Tabla_Fl._Tabla_Zonas
                _Control_Todas = Rdb_Zonas_Todas
        End Select


        If _Control.Checked Then

            Dim Fm As New Frm_Filtro_Especial_Informes(_Tabla_Fl, False)
            Fm.Pro_Tbl_Filtro = _Tbl_Filtro
            Fm.Pro_Sql_Filtro_Condicion_Extra = _Sql_Filtro_Condicion_Extra
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then

                _Tbl_Filtro = Fm.Pro_Tbl_Filtro

                If Fm.Pro_Filtrar_Todo Then
                    _Control_Todas.Checked = True
                Else
                    If (_Tbl_Filtro Is Nothing) Then
                        _Control.Checked = True
                    Else
                        Select Case _Nombre_Control

                            Case "Rdb_Entidades_Algunas"
                                _Tbl_Filtro_Entidad = _Tbl_Filtro
                            Case "Rdb_Ciudad_Algunas"
                                _Tbl_Filtro_Ciudad = _Tbl_Filtro
                            Case "Rdb_Comunas_Algunas"
                                _Tbl_Filtro_Comunas = _Tbl_Filtro
                            Case "Rdb_Vendedores_Algunos"
                                _Tbl_Filtro_Vendedor = _Tbl_Filtro
                            Case "Rdb_Productos_Algunos"
                                _Tbl_Filtro_Productos = _Tbl_Filtro
                            Case "Rdb_Clasificacion_Libre_Algunas"
                                _Tbl_Filtro_Clalibpr = _Tbl_Filtro
                            Case "Rdb_Marcas_Algunas"
                                _Tbl_Filtro_Marcas = _Tbl_Filtro
                            Case "Rdb_Super_Familias_Algunas"
                                _Tbl_Filtro_Super_Familias = _Tbl_Filtro
                            Case "Rdb_Rubros_Algunos"
                                _Tbl_Filtro_Rubro_Productos = _Tbl_Filtro
                            Case "Rdb_Zonas_Algunas"
                                _Tbl_Filtro_Zonas_Productos = _Tbl_Filtro
                        End Select
                    End If
                End If

            End If

        End If

    End Sub

    Private Sub Frm_Filtro_Especial_Productos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        _Aceptar = True
        Me.Close()
    End Sub

End Class