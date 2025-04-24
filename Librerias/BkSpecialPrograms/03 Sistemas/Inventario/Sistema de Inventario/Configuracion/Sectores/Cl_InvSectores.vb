Imports System.Data.SqlClient

Public Class Cl_InvSectores

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_Inv_Sector As New Zw_Inv_Sector
    Public Property Ls_Zw_Inv_Ubicaciones As New List(Of Zw_Inv_Sector)

    Public Sub New()

    End Sub

    Function Fx_Llenar_Zw_Inv_Sector(_Id As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje.EsCorrecto = False
        _Mensaje.Col2_Detalle = "Cargar Sector de Inventario"
        _Mensaje.Col1_Mensaje = String.Empty

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Sector Where Id = " & _Id
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            _Mensaje.Col1_Mensaje = "No se encontro el registro en la tabla Zw_Inv_Sector con el Id " & _Id
            Return _Mensaje
        End If

        With Zw_Inv_Sector

            .Id = _Row.Item("Id")
            .IdInventario = _Row.Item("IdInventario")
            .Empresa = _Row.Item("Empresa")
            .Sucursal = _Row.Item("Sucursal")
            .Bodega = _Row.Item("Bodega")
            .Sector = _Row.Item("Sector")
            .NombreSector = _Row.Item("NombreSector")
            .CodFuncionario = _Row.Item("CodFuncionario")
            .Abierto = _Row.Item("Abierto")

        End With

        _Mensaje.EsCorrecto = True
        _Mensaje.Col1_Mensaje = "Registros cargados correctamente"
        _Mensaje.Tag = Zw_Inv_Sector

        Return _Mensaje

    End Function

    Function Fx_Llenar_Zw_Inv_Sector(_IdInventario As Integer, _Ubicacion As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje.EsCorrecto = False
        _Mensaje.Col2_Detalle = "Cargar Sector de Inventario"
        _Mensaje.Col1_Mensaje = String.Empty

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Sector Where IdInventario = " & _IdInventario & " And Sector = '" & _Ubicacion & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            _Mensaje.Col1_Mensaje = "No se encontro el registro en la tabla Zw_Inv_Sector con el Sector " & _Ubicacion
            _Mensaje.Icono = MessageBoxIcon.Stop
            Return _Mensaje
        End If

        With Zw_Inv_Sector

            .Id = _Row.Item("Id")
            .IdInventario = _Row.Item("IdInventario")
            .Empresa = _Row.Item("Empresa")
            .Sucursal = _Row.Item("Sucursal")
            .Bodega = _Row.Item("Bodega")
            .Sector = _Row.Item("Sector")
            .NombreSector = _Row.Item("NombreSector")
            .CodFuncionario = _Row.Item("CodFuncionario")
            .Abierto = _Row.Item("Abierto")

        End With

        _Mensaje.EsCorrecto = True
        _Mensaje.Col1_Mensaje = "Registros cargados correctamente"
        _Mensaje.Icono = MessageBoxIcon.Information
        _Mensaje.Tag = Zw_Inv_Sector

        Return _Mensaje

    End Function

    Function Fx_Crear_Sector(Zw_Inv_Sector As Zw_Inv_Sector) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        _Mensaje_Stem.Col2_Detalle = "Crear Sector de Inventario"
        _Mensaje_Stem.EsCorrecto = False
        _Mensaje_Stem.Col1_Mensaje = String.Empty
        _Mensaje_Stem.Icono = MessageBoxIcon.Stop

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Sector",
                                            "Sector = '" & Zw_Inv_Sector.Sector & "' And IdInventario = " & Zw_Inv_Sector.IdInventario)
        If CBool(_Reg) Then
            ' Modificación aquí: en lugar de lanzar una excepción, se establece el mensaje de error.
            _Mensaje_Stem.Col1_Mensaje = "El código del Sector ya existe en este inventario"
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

            With Zw_Inv_Sector

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Inv_Sector (IdInventario,Empresa,Sucursal,Bodega,Sector,NombreSector,CodFuncionario,Abierto) Values " &
                               "(" & .IdInventario & ",'" & .Empresa & "','" & .Sucursal & "','" & .Bodega & "','" & .Sector & "','" & .NombreSector & "','" & .CodFuncionario & "'," & Convert.ToInt32(.Abierto) & ")"

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
            _Mensaje_Stem.Col2_Detalle = "Crear Sector de Inventario"
            _Mensaje_Stem.Col1_Mensaje = "Sector creado correctamente"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje_Stem.Col1_Mensaje = ex.Message
            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

    Function Fx_Editar_Sector() As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        _Mensaje_Stem.Col2_Detalle = "Crear Ubicación de Inventario"
        _Mensaje_Stem.EsCorrecto = False
        _Mensaje_Stem.Col1_Mensaje = String.Empty
        _Mensaje_Stem.Icono = MessageBoxIcon.Stop

        Consulta_sql = String.Empty

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Sector",
                                            "Id <> " & Zw_Inv_Sector.Id & " And Sector = '" & Zw_Inv_Sector.Sector & "' And IdInventario = " & Zw_Inv_Sector.IdInventario)
        If CBool(_Reg) Then
            _Mensaje_Stem.Col1_Mensaje = "El código del Sector """ & Zw_Inv_Sector.Sector & """ ya existe en este inventario"
            Return _Mensaje_Stem
        End If

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_Inv_Sector

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Inv_Sector set " &
                               "Sector = '" & .Sector & "'," &
                               "NombreSector = '" & .NombreSector & "'," &
                               "CodFuncionario = '" & .CodFuncionario & "'," &
                               "Abierto = " & Convert.ToInt32(.Abierto) & vbCrLf &
                               "Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Col1_Mensaje = "Sector actualizado correctamente"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje_Stem.Col1_Mensaje = ex.Message
            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

    Function Fx_Eliminar_Sector() As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        _Mensaje_Stem.Col2_Detalle = "Eliminar Sector de Inventario"
        _Mensaje_Stem.EsCorrecto = False
        _Mensaje_Stem.Col1_Mensaje = String.Empty
        _Mensaje_Stem.Icono = MessageBoxIcon.Stop

        Consulta_sql = String.Empty

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Hoja_Detalle",
                                            "IdInventario = " & Zw_Inv_Sector.IdInventario & " And IdSector = " & Zw_Inv_Sector.Id)
        If CBool(_Reg) Then
            _Mensaje_Stem.Col1_Mensaje = "No se puede eliminar el Sector, tiene registros inventariados"
            Return _Mensaje_Stem
        End If

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_Inv_Sector

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Inv_Sector Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Col1_Mensaje = "Sector eliminado correctamente"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje_Stem.Col1_Mensaje = ex.Message
            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

End Class
