Public Class Clas_Filtros_Random

    Enum Enum_Tabla_Fl
        _Funcionarios_Random
        _Documentos
        _Documentos_Venta
        _Documentos_Compra
        _Sucursales
        _Entidades
        _Productos
        _Tabla_Tabcarac
        _Tabla_Marcas
        _Tabla_Super_Familia
        _Tabla_Familia
        _Tabla_Sub_Familia
        _Tabla_Rubros
        _Tabla_Zonas
        _Bodegas
        _Ciudades
        _Comunas
        _Otra
        _Funcionarios_BakApp
        _Estaciones_Bk
        _Pdc_Maquinas
        _Pdc_Operarios
        _Pdc_Operaciones
        _Conceptos
    End Enum

    Dim _Formulario As Form
    Dim _Tbl_Filtro As DataTable
    Dim _Filtro_Todas As Boolean
    Dim _Descripcion_X_Defecto As String
    Dim _Nombre_Encabezado_Informe As String

    Dim _Tabla As String
    Dim _Campo As String
    Dim _Descripcion As String

    Dim _Ver_Codigo As Boolean = True

    Public Property Pro_Tbl_Filtro() As DataTable
        Get
            Return _Tbl_Filtro
        End Get
        Set(value As DataTable)
            _Tbl_Filtro = value
        End Set
    End Property
    Public Property Pro_Filtro_Todas() As Boolean
        Get
            Return _Filtro_Todas
        End Get
        Set(value As Boolean)
            _Filtro_Todas = value
        End Set
    End Property
    Public Property Pro_Descripcion_X_Defecto() As String
        Get
            Return _Descripcion_X_Defecto
        End Get
        Set(value As String)
            _Descripcion_X_Defecto = value
        End Set
    End Property
    Public Property Pro_Nombre_Encabezado_Informe As String
        Get
            Return _Nombre_Encabezado_Informe
        End Get
        Set(value As String)
            _Nombre_Encabezado_Informe = value
        End Set
    End Property
    Public Property Tabla As String
        Get
            Return _Tabla
        End Get
        Set(value As String)
            _Tabla = value
        End Set
    End Property
    Public Property Campo As String
        Get
            Return _Campo
        End Get
        Set(value As String)
            _Campo = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property Ver_Codigo As Boolean
        Get
            Return _Ver_Codigo
        End Get
        Set(value As Boolean)
            _Ver_Codigo = value
        End Set
    End Property

    Public Sub New(Formulario As Form)
        _Formulario = Formulario
        _Nombre_Encabezado_Informe = "FILTRO INFORME"
    End Sub

    Function Fx_Filtrar(Tbl_Filtro As DataTable,
                   Tabla_Fl As Enum_Tabla_Fl,
                   Sql_Filtro_Condicion_Extra As String,
                   Filtro_Todas As Object,
                   Optional _Incorporar_Campo_Vacias As Boolean = True,
                   Optional _Seleccionar_Solo_Uno As Boolean = False,
                   Optional _Requiere_Seleccion As Boolean = True,
                   Optional _Activar_Crear_Editar_Eliminar As Boolean = False,
                   Optional _Seleccionar_Todos_Visible As Boolean = True,
                   Optional _TableName As String = "") As Boolean

        _Tbl_Filtro = Tbl_Filtro
        _Filtro_Todas = Filtro_Todas

        Dim Fm As New Frm_Filtro_Especial_Informes(Tabla_Fl, _Incorporar_Campo_Vacias)
        Fm.Activar_Crear_Editar_Eliminar = _Activar_Crear_Editar_Eliminar
        Fm.Pro_Tabla = Tabla
        Fm.Pro_Campo = Campo
        Fm.Pro_Descripcion = _Descripcion
        Fm.Pro_Tbl_Filtro = _Tbl_Filtro
        Fm.Pro_Sql_Filtro_Condicion_Extra = Sql_Filtro_Condicion_Extra
        Fm.Pro_Seleccionar_Todo = Filtro_Todas
        Fm.Pro_Seleccionar_Solo_Uno = _Seleccionar_Solo_Uno
        Fm.Pro_Txt_Descripcion = _Descripcion_X_Defecto
        Fm.Text = _Nombre_Encabezado_Informe
        Fm.Pro_Requiere_Seleccion = _Requiere_Seleccion
        Fm.Ver_Codigo = Ver_Codigo
        Fm.Chk_Seleccionar_Todos.Visible = _Seleccionar_Todos_Visible
        Fm.ShowDialog(_Formulario)

        If Fm.Pro_Filtrar Then

            _Tbl_Filtro = Fm.Pro_Tbl_Filtro

            If Not IsNothing(_Tbl_Filtro) Then _Tbl_Filtro.TableName = _TableName

            If Fm.Pro_Filtrar_Todo Then
                _Filtro_Todas = True '_Control_Todas.Checked = True
                Return True
            Else
                If Not (_Tbl_Filtro Is Nothing) Then
                    _Filtro_Todas = False
                    Return True
                Else
                    If Not _Requiere_Seleccion Then
                        Return True
                    End If
                End If
            End If

        End If

    End Function

End Class
