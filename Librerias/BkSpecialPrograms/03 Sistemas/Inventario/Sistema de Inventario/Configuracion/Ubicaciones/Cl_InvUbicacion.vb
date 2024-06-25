Imports System.Data.SqlClient


Public Class Cl_InvUbicacion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_Inv_Ubicaciones As New Zw_Inv_Ubicaciones
    Public Property Ls_Zw_Inv_Ubicaciones As New List(Of Zw_Inv_Ubicaciones)

    Public Sub New()

    End Sub

    Function Fx_Llenar_Zw_Inv_Ubicaciones(_Id As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje.EsCorrecto = False
        _Mensaje.Detalle = "Cargar Ubicación de Inventario"
        _Mensaje.Mensaje = String.Empty

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Ubicaciones Where Id = " & _Id
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            _Mensaje.Mensaje = "No se encontro el registro en la tabla Zw_TmpInv_Ubicaciones con el Id " & _Id
            Return _Mensaje
        End If

        With Zw_Inv_Ubicaciones

            .Id = _Row.Item("Id")
            .IdInventario = _Row.Item("IdInventario")
            .Empresa = _Row.Item("Empresa")
            .Sucursal = _Row.Item("Sucursal")
            .Bodega = _Row.Item("Bodega")
            .Ubicacion = _Row.Item("Ubicacion")
            .Abierto = _Row.Item("Abierto")

        End With

        _Mensaje.EsCorrecto = True
        _Mensaje.Mensaje = "Registros cargados correctamente"

        Return _Mensaje

    End Function

    Function Fx_Llenar_Zw_Inv_Ubicaciones(_IdInventario As Integer, _Ubicacion As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje.EsCorrecto = False
        _Mensaje.Detalle = "Cargar Ubicación de Inventario"
        _Mensaje.Mensaje = String.Empty

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Ubicaciones Where IdInventario = " & _IdInventario & " And Ubicacion = '" & _Ubicacion & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            _Mensaje.Mensaje = "No se encontro el registro en la tabla Zw_TmpInv_Ubicaciones con el Ubicacion " & _Ubicacion
            Return _Mensaje
        End If

        With Zw_Inv_Ubicaciones

            .Id = _Row.Item("Id")
            .IdInventario = _Row.Item("IdInventario")
            .Empresa = _Row.Item("Empresa")
            .Sucursal = _Row.Item("Sucursal")
            .Bodega = _Row.Item("Bodega")
            .Ubicacion = _Row.Item("Ubicacion")
            .Abierto = _Row.Item("Abierto")

        End With

        _Mensaje.EsCorrecto = True
        _Mensaje.Mensaje = "Registros cargados correctamente"

        Return _Mensaje

    End Function

    Function Fx_Crear_Ubicacion(Zw_Inv_Ubicaciones As Zw_Inv_Ubicaciones) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        _Mensaje_Stem.Detalle = "Crear Ubicación de Inventario"
        _Mensaje_Stem.EsCorrecto = False
        _Mensaje_Stem.Mensaje = String.Empty
        _Mensaje_Stem.Icono = MessageBoxIcon.Stop

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Ubicaciones",
                                            "Ubicacion = '" & Zw_Inv_Ubicaciones.Ubicacion & "' And IdInventario = " & Zw_Inv_Ubicaciones.IdInventario)
        If CBool(_Reg) Then
            ' Modificación aquí: en lugar de lanzar una excepción, se establece el mensaje de error.
            _Mensaje_Stem.Mensaje = "El código de la Ubicación ya existe en este inventario"
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

            With Zw_Inv_Ubicaciones

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Inv_Ubicaciones (IdInventario,Empresa,Sucursal,Bodega,Ubicacion,Abierto) Values " &
                               "(" & .IdInventario & ",'" & .Empresa & "','" & .Sucursal & "','" & .Bodega & "','" & .Ubicacion & "'," & Convert.ToInt32(.Abierto) & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()
                Comando = New System.Data.SqlClient.SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
                Comando.Transaction = myTrans

                Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    .Id = dfd1("Identity")
                End While
                dfd1.Close()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Mensaje = "Ubicación creada correctamente"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje_Stem.Mensaje = ex.Message
            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

    Function Fx_Editar_Ubicacion() As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        _Mensaje_Stem.Detalle = "Crear Ubicación de Inventario"
        _Mensaje_Stem.EsCorrecto = False
        _Mensaje_Stem.Mensaje = String.Empty
        _Mensaje_Stem.Icono = MessageBoxIcon.Stop

        Consulta_sql = String.Empty

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Ubicaciones",
                                            "Id <> " & Zw_Inv_Ubicaciones.Id & " And Ubicacion = '" & Zw_Inv_Ubicaciones.Ubicacion & "' And IdInventario = " & Zw_Inv_Ubicaciones.IdInventario)
        If CBool(_Reg) Then
            _Mensaje_Stem.Mensaje = "El código de la Ubicación """ & Zw_Inv_Ubicaciones.Ubicacion & """ ya existe en este inventario"
            Return _Mensaje_Stem
        End If

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_Inv_Ubicaciones

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Inv_Ubicaciones set " &
                               "Ubicacion = '" & .Ubicacion & "'," &
                               "Abierto = " & Convert.ToInt32(.Abierto) & vbCrLf &
                               "Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Mensaje = "Ubicación editada correctamente"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje_Stem.Mensaje = ex.Message
            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

    Function Fx_Eliminar_Ubicacion() As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        _Mensaje_Stem.Detalle = "Crear Ubicación de Inventario"
        _Mensaje_Stem.EsCorrecto = False
        _Mensaje_Stem.Mensaje = String.Empty
        _Mensaje_Stem.Icono = MessageBoxIcon.Stop

        Consulta_sql = String.Empty

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_ProductosInventariados",
                                            "IdInventario = " & Zw_Inv_Ubicaciones.IdInventario & " And IdUbicacion = " & Zw_Inv_Ubicaciones.Id)
        If CBool(_Reg) Then
            _Mensaje_Stem.Mensaje = "No se puede eliminar la ubicación, tiene registros inventariados"
            Return _Mensaje_Stem
        End If

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_Inv_Ubicaciones

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Inv_Ubicaciones Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Mensaje = "Ubicación eliminada correctamente"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje_Stem.Mensaje = ex.Message
            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

    'Function Fx_NvoCodUbicacion() As String

    '    Dim _NvoCodUbicacion As String

    '    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    '    Dim _TblPaso = _Sql.Fx_Get_DataTable("Select Max(CodUbicacion) As CodUbicacion From " & _Global_BaseBk & "Zw_Inv_Ubicaciones")

    '    Dim _Ult_Nro_OT As String = NuloPorNro(_TblPaso.Rows(0).Item("CodUbicacion"), "")

    '    If String.IsNullOrEmpty(Trim(_Ult_Nro_OT)) Then
    '        _Ult_Nro_OT = "0000000000"
    '    End If

    '    _NvoCodUbicacion = Fx_Proximo_NroDocumento(_Ult_Nro_OT, 10)

    '    Return _NvoCodUbicacion

    'End Function



End Class
