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

    ' Nueva lista con Codigo y Descripcion
    Dim _ListaCodigoDescripcion As List(Of CodigoDescripcionItem)

    Public Property Pro_Tbl_Filtro() As DataTable
        Get
            Return _Tbl_Filtro
        End Get
        Set(value As DataTable)
            _Tbl_Filtro = value
            ' Invalidate cached list when source table changes
            _ListaCodigoDescripcion = Nothing
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

    Public Property SonProductos As Boolean

    Public Sub New(Formulario As Form)
        _Formulario = Formulario
        _Nombre_Encabezado_Informe = "FILTRO INFORME"
    End Sub

    ' Propiedad pública que expone la lista Codigo/Descripcion
    Public Property Pro_Lista_CodigoDescripcion As List(Of CodigoDescripcionItem)
        Get
            If _ListaCodigoDescripcion Is Nothing Then
                _ListaCodigoDescripcion = Fx_Llenar_Lista_CodigoDescripcion()
            End If
            Return _ListaCodigoDescripcion
        End Get
        Set(value As List(Of CodigoDescripcionItem))
            _ListaCodigoDescripcion = value
        End Set
    End Property

    ' Función que rellena la lista a partir de _Tbl_Filtro
    Public Function Fx_Llenar_Lista_CodigoDescripcion(Optional CodigoFieldName As String = "Codigo", Optional DescripcionFieldName As String = "Descripcion") As List(Of CodigoDescripcionItem)
        Dim lista As New List(Of CodigoDescripcionItem)

        If _Tbl_Filtro Is Nothing Then
            Return lista
        End If

        ' Determinar nombres de columna a usar
        Dim colCodigo As String = Nothing
        Dim colDescripcion As String = Nothing

        If _Tbl_Filtro.Columns.Contains(CodigoFieldName) Then
            colCodigo = CodigoFieldName
        End If

        If _Tbl_Filtro.Columns.Contains(DescripcionFieldName) Then
            colDescripcion = DescripcionFieldName
        End If

        ' Si no existen las columnas solicitadas, usar columnas por posición
        If String.IsNullOrEmpty(colCodigo) Then
            If _Tbl_Filtro.Columns.Count >= 1 Then
                colCodigo = _Tbl_Filtro.Columns(0).ColumnName
            End If
        End If

        If String.IsNullOrEmpty(colDescripcion) Then
            If _Tbl_Filtro.Columns.Count >= 2 Then
                colDescripcion = _Tbl_Filtro.Columns(1).ColumnName
            ElseIf _Tbl_Filtro.Columns.Count >= 1 Then
                ' Si sólo hay una columna, usarla también para descripción
                colDescripcion = _Tbl_Filtro.Columns(0).ColumnName
            End If
        End If

        ' Si aún no se resolvieron columnas, devolver lista vacía
        If String.IsNullOrEmpty(colCodigo) Or String.IsNullOrEmpty(colDescripcion) Then
            Return lista
        End If

        ' Recorrer filas y agregar a la lista
        For Each row As DataRow In _Tbl_Filtro.Rows
            Dim valCodigo As String = String.Empty
            Dim valDescripcion As String = String.Empty

            If _Tbl_Filtro.Columns.Contains(colCodigo) Then
                If Not IsDBNull(row(colCodigo)) Then
                    valCodigo = Convert.ToString(row(colCodigo))
                End If
            End If

            If _Tbl_Filtro.Columns.Contains(colDescripcion) Then
                If Not IsDBNull(row(colDescripcion)) Then
                    valDescripcion = Convert.ToString(row(colDescripcion))
                End If
            End If

            lista.Add(New CodigoDescripcionItem With {.Codigo = valCodigo, .Descripcion = valDescripcion})
        Next

        Return lista
    End Function

    Function Fx_Filtrar(Tbl_Filtro As DataTable,
                   Tabla_Fl As Enum_Tabla_Fl,
                   Sql_Filtro_Condicion_Extra As String,
                   Filtro_Todas As Object,
                   Optional _Incorporar_Campo_Vacias As Boolean = True,
                   Optional _Seleccionar_Solo_Uno As Boolean = False,
                   Optional _Requiere_Seleccion As Boolean = True,
                   Optional _Activar_Crear_Editar_Eliminar As Boolean = False,
                   Optional _Seleccionar_Todos_Visible As Boolean = True,
                   Optional _TableName As String = "",
                   Optional _MostrarNumeracionDeRegistros As Boolean = False,
                   Optional _ReemplazarComillaspor As String = "") As Boolean

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
        Fm.MostrarNumeracionDeRegistros = _MostrarNumeracionDeRegistros
        Fm.SonProductos = SonProductos
        Fm.ReemplazarComillaspor = _ReemplazarComillaspor
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

' Clase simple para almacenar pares Codigo/Descripcion
Public Class CodigoDescripcionItem
    Public Property Codigo As String
    Public Property Descripcion As String
End Class
