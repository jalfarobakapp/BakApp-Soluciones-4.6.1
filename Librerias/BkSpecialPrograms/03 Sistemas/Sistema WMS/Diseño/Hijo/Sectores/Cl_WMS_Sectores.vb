Imports System.Data.SqlClient

Public Class Cl_WMS_Sectores

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Ls_Zw_WMS_Ubicaciones_Sectores As List(Of Zw_WMS_Ubicaciones_Sectores)
    Public Property Zw_WMS_Ubicaciones_Sectores As New Zw_WMS_Ubicaciones_Sectores

    Public Sub New()

    End Sub

    Function Fx_Llenar_Sector(_Id_Sector As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje.EsCorrecto = False
        _Mensaje.Detalle = "Cargar Sector de Inventario"
        _Mensaje.Mensaje = String.Empty

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Sectores Where Id_Sector = " & _Id_Sector
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

        If IsNothing(_Row) Then
            _Mensaje.Mensaje = "No se encontro el registro en la tabla Zw_WMS_Ubicaciones_Sectores con el Id " & _Id_Sector
            Return _Mensaje
        End If

        With Zw_WMS_Ubicaciones_Sectores

            .Id_Sector = _Row.Item("Id_Sector")
            .Id_Mapa = _Row.Item("Id_Mapa")
            .Empresa = _Row.Item("Empresa")
            .Sucursal = _Row.Item("Sucursal")
            .Bodega = _Row.Item("Bodega")
            .Codigo_Sector = _Row.Item("Codigo_Sector")
            .Nombre_Sector = _Row.Item("Nombre_Sector")
            .Es_SubSector = _Row.Item("Es_SubSector")
            .EsCabecera = _Row.Item("EsCabecera")
            .SoloUnaUbicacion = _Row.Item("SoloUnaUbicacion")

        End With

        _Mensaje.EsCorrecto = True
        _Mensaje.Mensaje = "Registros cargados correctamente"
        _Mensaje.Tag = Zw_WMS_Ubicaciones_Sectores

        Return _Mensaje

    End Function

    Function Fx_Llenar_Sectores(_Id_Mapa As Integer)

        Ls_Zw_WMS_Ubicaciones_Sectores = New List(Of Zw_WMS_Ubicaciones_Sectores)

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje.EsCorrecto = False
        _Mensaje.Detalle = "Cargar Sector de Inventario"
        _Mensaje.Mensaje = String.Empty

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Sectores Where Id_Mapa = " & _Id_Mapa
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If _Tbl.Rows.Count = 0 Then
            _Mensaje.Mensaje = "No se encontraron el registros en la tabla Zw_WMS_Ubicaciones_Sectores con el Id " & _Id_Mapa
            Return _Mensaje
        End If

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Zw_WMS_Ubicaciones_Sectores As New Zw_WMS_Ubicaciones_Sectores

            With _Zw_WMS_Ubicaciones_Sectores

                .Id_Sector = _Fila.Item("Id_Sector")
                .Id_Mapa = _Fila.Item("Id_Mapa")
                .Empresa = _Fila.Item("Empresa")
                .Sucursal = _Fila.Item("Sucursal")
                .Bodega = _Fila.Item("Bodega")
                .Codigo_Sector = _Fila.Item("Codigo_Sector")
                .Nombre_Sector = _Fila.Item("Nombre_Sector")
                .Es_SubSector = _Fila.Item("Es_SubSector")
                .EsCabecera = _Fila.Item("EsCabecera")
                .SoloUnaUbicacion = _Fila.Item("SoloUnaUbicacion")

            End With

            Ls_Zw_WMS_Ubicaciones_Sectores.Add(_Zw_WMS_Ubicaciones_Sectores)

        Next

        _Mensaje.EsCorrecto = True
        _Mensaje.Mensaje = "Registros cargados correctamente"
        _Mensaje.Tag = Zw_WMS_Ubicaciones_Sectores

        Return _Mensaje

    End Function

    Function Fx_Crear_Sector() As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        _Mensaje_Stem.Detalle = "Crear Sector de bodega"
        _Mensaje_Stem.EsCorrecto = False
        _Mensaje_Stem.Mensaje = String.Empty
        _Mensaje_Stem.Icono = MessageBoxIcon.Stop

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_WMS_Ubicaciones_Sectores",
                                            "Codigo_Sector = '" & Zw_WMS_Ubicaciones_Sectores.Codigo_Sector & "' And Id_Mapa = " & Zw_WMS_Ubicaciones_Sectores.Id_Mapa)
        If CBool(_Reg) Then
            ' Modificación aquí: en lugar de lanzar una excepción, se establece el mensaje de error.
            _Mensaje_Stem.Mensaje = "El código del Sector/Estante ya existe en esta bodega"
            Return _Mensaje_Stem
        End If

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_WMS_Ubicaciones_Sectores

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Sectores (Id_Mapa,Empresa,Sucursal,Bodega,Codigo_Sector," &
                               "Nombre_Sector,Es_SubSector,EsCabecera,SoloUnaUbicacion) " &
                               "Values (" & .Id_Mapa & ",'" & .Empresa & "','" & .Sucursal & "'" & ",'" & .Bodega & "'," &
                               "'" & .Codigo_Sector & "', '" & .Nombre_Sector & "'," &
                               Convert.ToInt32(.Es_SubSector) & "," & Convert.ToInt32(.EsCabecera) & "," & Convert.ToInt32(.SoloUnaUbicacion) & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()
                Comando = New System.Data.SqlClient.SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
                Comando.Transaction = myTrans

                Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    .Id_Sector = dfd1("Identity")
                End While
                dfd1.Close()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Detalle = "Crear Sector de ubicaciones"
            _Mensaje_Stem.Mensaje = "Sector creado correctamente"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information
            _Mensaje_Stem.Id = Zw_WMS_Ubicaciones_Sectores.Id_Sector

        Catch ex As Exception

            _Mensaje_Stem.Mensaje = ex.Message
            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

    Function Fx_Editar_Sector() As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        _Mensaje_Stem.Detalle = "Crear Sector/Estante de ubicaciones"
        _Mensaje_Stem.EsCorrecto = False
        _Mensaje_Stem.Mensaje = String.Empty
        _Mensaje_Stem.Icono = MessageBoxIcon.Stop

        Consulta_sql = String.Empty

        'Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Sector",
        '                                    "Id <> " & Zw_Inv_Sector.Id & " And Sector = '" & Zw_Inv_Sector.Sector & "' And IdInventario = " & Zw_Inv_Sector.IdInventario)
        'If CBool(_Reg) Then
        '    _Mensaje_Stem.Mensaje = "El código del Sector """ & Zw_Inv_Sector.Sector & """ ya existe en este inventario"
        '    Return _Mensaje_Stem
        'End If

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_WMS_Ubicaciones_Sectores

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Sectores Set " &
                               "Id_Mapa = " & .Id_Mapa & ", " &
                               "Empresa = '" & .Empresa & "', " &
                               "Sucursal = '" & .Sucursal & "', " &
                               "Bodega = '" & .Bodega & "', " &
                               "Codigo_Sector = '" & .Codigo_Sector & "', " &
                               "Nombre_Sector = '" & .Nombre_Sector & "', " &
                               "Es_SubSector = " & .Es_SubSector & ", " &
                               "EsCabecera = " & .EsCabecera & " " &
                               "Where Id_Sector = " & .Id_Sector


                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Mensaje = "Sector actualizado correctamente"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje_Stem.Mensaje = ex.Message
            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

    Function Fx_Eliminar_Sector(_Id_Sector As Integer, _Codigo_Sector As String) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        _Mensaje_Stem.Detalle = "Eliminar Sector/Estante de ubicaciones"
        _Mensaje_Stem.EsCorrecto = False
        _Mensaje_Stem.Mensaje = String.Empty
        _Mensaje_Stem.Icono = MessageBoxIcon.Stop

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Sectores Where Id_Sector = " & _Id_Sector
            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            'Consulta_sql = "Delete " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega Where Codigo_Sector = '" & _Codigo_Sector & "'"
            'Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            'Comando.Transaction = myTrans
            'Comando.ExecuteNonQuery()

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Mensaje = "Sector eliminado correctamente"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje_Stem.Mensaje = ex.Message
            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

End Class
