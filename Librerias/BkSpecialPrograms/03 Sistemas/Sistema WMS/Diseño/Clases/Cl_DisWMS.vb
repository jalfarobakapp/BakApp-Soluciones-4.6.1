
Imports System.Data.SqlClient

Public Class Cl_DisWMS

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    ''' <summary>
    ''' Sectores
    ''' </summary>
    ''' <returns></returns>
    Public Property Ls_Zw_WMS_Ubicaciones_Mapa_Det As New List(Of Zw_WMS_Ubicaciones_Mapa_Det)

    Public Sub New()

    End Sub

    Function Fx_Llenar_Sector(_Id As Integer) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det Where Id = " & _Id
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Col1_Mensaje = "No se encontraron registros en la tabla Zw_WMS_Ubicaciones_Mapa_Det con el Id " & _Id

            Return _Mensaje_Stem

        End If

        Dim _Objeto_Det As New Zw_WMS_Ubicaciones_Mapa_Det

        With _Objeto_Det

            .Id_Mapa = _Row.Item("Id_Mapa")
            .Id = _Row.Item("Id")
            .Empresa = _Row.Item("Empresa")
            .Sucursal = _Row.Item("Sucursal")
            .Bodega = _Row.Item("Bodega")
            .Codigo_Sector = _Row.Item("Codigo_Sector")
            .Nombre_Sector = _Row.Item("Nombre_Sector")
            .Tipo_Objeto = _Row.Item("Tipo_Objeto")
            .Nombre_Objeto = _Row.Item("Nombre_Objeto")
            .Texto = _Row.Item("Texto")
            .Font_Nombre = _Row.Item("Font_Nombre")
            .Font_Tamano = _Row.Item("Font_Tamano")
            .Font_Estilo = _Row.Item("Font_Estilo")
            .Font_Negrita = _Row.Item("Font_Negrita")
            .Font_Italic = _Row.Item("Font_Italic")
            .Font_Tachado = _Row.Item("Font_Tachado")
            .Font_Subrayado = _Row.Item("Font_Subrayado")
            .Alto_H = _Row.Item("Alto_H")
            .Ancho_W = _Row.Item("Ancho_W")
            .BackColor = _Row.Item("BackColor")
            .ForeColor = _Row.Item("ForeColor")
            .Relleno = _Row.Item("Relleno")
            .Y_Fila = _Row.Item("Y_Fila")
            .X_Columna = _Row.Item("X_Columna")
            .Orientacion = _Row.Item("Orientacion")
            .Habilitado = _Row.Item("Habilitado")
            .EsCabecera = _Row.Item("EsCabecera")

        End With

        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Col1_Mensaje = "Registro cargado correctamente"
        _Mensaje_Stem.Tag = _Objeto_Det

        Return _Mensaje_Stem

    End Function

    Function Fx_Nuevo_Sector(_Id_Mapa As Integer,
                             _Empresa As String,
                             _Sucursal As String,
                             _Bodega As String) As Zw_WMS_Ubicaciones_Mapa_Det

        Dim _Objeto_Det As New Zw_WMS_Ubicaciones_Mapa_Det

        With _Objeto_Det

            .Id_Mapa = 0
            .Id = 0
            .Empresa = _Empresa
            .Sucursal = _Sucursal
            .Bodega = _Bodega
            .Codigo_Sector = String.Empty
            .Nombre_Sector = String.Empty
            .Tipo_Objeto = String.Empty
            .Nombre_Objeto = String.Empty
            .Texto = String.Empty
            .Font_Nombre = String.Empty
            .Font_Tamano = 0
            .Font_Estilo = 0
            .Font_Negrita = False
            .Font_Italic = False
            .Font_Tachado = False
            .Font_Subrayado = False
            .Alto_H = 0
            .Ancho_W = 0
            .BackColor = 0
            .ForeColor = 0
            .Relleno = 0
            .Y_Fila = 0
            .X_Columna = 0
            .Orientacion = 0
            .Habilitado = 0
            .EsCabecera = 0

        End With

        Return _Objeto_Det

    End Function

    Function Fx_Llenar_Lista_Sector(_Id_Mapa As Integer,
                                    _Empresa As String,
                                    _Sucursal As String,
                                    _Bodega As String) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Det" & vbCrLf &
                       "Where Id_Mapa = " & _Id_Mapa & " And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If IsNothing(_Tbl) Then

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Col1_Mensaje = "No se encontraron registros en la tabla Zw_WMS_Ubicaciones_Mapa_Det con el Id_Mapa = " & _Id_Mapa & " And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "'"

            Return _Mensaje_Stem

        End If

        For Each _Row As DataRow In _Tbl.Rows

            Dim _Objeto_Det As New Zw_WMS_Ubicaciones_Mapa_Det

            With _Objeto_Det

                .Id_Mapa = _Row.Item("Id_Mapa")
                .Id = _Row.Item("Id")
                .Empresa = _Row.Item("Empresa")
                .Sucursal = _Row.Item("Sucursal")
                .Bodega = _Row.Item("Bodega")
                .Codigo_Sector = _Row.Item("Codigo_Sector")
                .Nombre_Sector = _Row.Item("Nombre_Sector")
                .Tipo_Objeto = _Row.Item("Tipo_Objeto")
                .Nombre_Objeto = _Row.Item("Nombre_Objeto")
                .Texto = _Row.Item("Texto")
                .Font_Nombre = _Row.Item("Font_Nombre")
                .Font_Tamano = _Row.Item("Font_Tamano")
                .Font_Estilo = _Row.Item("Font_Estilo")
                .Font_Negrita = _Row.Item("Font_Negrita")
                .Font_Italic = _Row.Item("Font_Italic")
                .Font_Tachado = _Row.Item("Font_Tachado")
                .Font_Subrayado = _Row.Item("Font_Subrayado")
                .Alto_H = _Row.Item("Alto_H")
                .Ancho_W = _Row.Item("Ancho_W")
                .BackColor = _Row.Item("BackColor")
                .ForeColor = _Row.Item("ForeColor")
                .Relleno = _Row.Item("Relleno")
                .Y_Fila = _Row.Item("Y_Fila")
                .X_Columna = _Row.Item("X_Columna")
                .Orientacion = _Row.Item("Orientacion")
                .Habilitado = _Row.Item("Habilitado")
                .EsCabecera = _Row.Item("EsCabecera")

            End With

            Ls_Zw_WMS_Ubicaciones_Mapa_Det.Add(_Objeto_Det)

        Next

        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Col1_Mensaje = "Registros cargados correctamente"
        _Mensaje_Stem.Tag = Ls_Zw_WMS_Ubicaciones_Mapa_Det

        Return _Mensaje_Stem

    End Function


End Class
