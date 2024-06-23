Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class Cl_Conteo

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_Inv_Hoja As New Zw_Inv_Hoja
    Public Property Ls_Zw_Inv_Hoja_Detalle As New List(Of Zw_Inv_Hoja_Detalle)

    Public Sub New()

    End Sub

    Function Fx_Llenar_Zw_Inv_Hoja(_Id As Integer) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        _Mensaje_Stem.EsCorrecto = False
        _Mensaje_Stem.Detalle = "Cargar Hoja"
        _Mensaje_Stem.Mensaje = String.Empty

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Hoja Where Id = " & _Id
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            _Mensaje_Stem.Mensaje = "No se encontro el registro en la tabla Zw_Inv_Hoja con el Id " & _Id
            Return _Mensaje_Stem
        End If

        With Zw_Inv_Hoja

            .Id = _Row.Item("Id")
            .IdInventario = _Row.Item("IdInventario")
            .Nro_Hoja = _Row.Item("Nro_Hoja")
            .NombreEquipo = _Row.Item("NombreEquipo")
            .FechaCreacion = _Row.Item("FechaCreacion")
            .CodResponsable = _Row.Item("CodResponsable")
            .IdContador1 = _Row.Item("IdContador1")
            .IdContador2 = _Row.Item("IdContador2")
            .FechaLevantamiento = _Row.Item("FechaLevantamiento")
            .Reconteo = _Row.Item("Reconteo")

        End With

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Hoja_Detalle Where IdHoja = " & _Id
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Zw_Inv_Hoja_Detalle As New Zw_Inv_Hoja_Detalle

            With _Zw_Inv_Hoja_Detalle

                .Id = _Row.Item("Id")
                .IdHoja = _Row.Item("IdHoja")
                .Nro_Hoja = _Row.Item("Nro_Hoja")
                .IdInventario = _Row.Item("IdInventario")
                .Empresa = _Row.Item("Empresa")
                .Sucursal = _Row.Item("Sucursal")
                .Bodega = _Row.Item("Bodega")
                .Responsable = _Row.Item("Responsable")
                .IdContador1 = _Row.Item("IdContador1")
                .IdContador2 = _Row.Item("IdContador2")
                .Item_Hoja = _Row.Item("Item_Hoja")
                .IdUbicacion = _Row.Item("IdUbicacion")
                .CodUbicacion = _Row.Item("CodUbicacion")
                .TipoConteo = _Row.Item("TipoConteo")
                .Codproducto = _Row.Item("Codproducto")
                .EsSeriado = _Row.Item("EsSeriado")
                .NroSerie = _Row.Item("NroSerie")
                .FechaHoraToma = _Row.Item("FechaHoraToma")
                .Rtu = _Row.Item("Rtu")
                .RtuVariable = _Row.Item("RtuVariable")
                .Udtrpr = _Row.Item("Udtrpr")
                .Ud1 = _Row.Item("Ud1")
                .CantidadUd1 = _Row.Item("CantidadUd1")
                .Ud2 = _Row.Item("Ud2")
                .CantidadUd2 = _Row.Item("CantidadUd2")
                .Observaciones = _Row.Item("Observaciones")
                .Recontado = _Row.Item("Recontado")
                .Actualizado_por = _Row.Item("Actualizado_por")
                .Obs_Actualizacion = _Row.Item("Obs_Actualizacion")

                Ls_Zw_Inv_Hoja_Detalle.Add(_Zw_Inv_Hoja_Detalle)

            End With

        Next

        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Mensaje = "Registros cargados correctamente"

    End Function

    Function Fx_Nueva_Hoja(Zw_Inv_Inventario As Zw_Inv_Inventario,
                           _NombreEquipo As String,
                           _CodResponsable As String) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        _Mensaje_Stem.EsCorrecto = False
        _Mensaje_Stem.Detalle = "Nueva Hoja"
        _Mensaje_Stem.Mensaje = String.Empty

        With Zw_Inv_Hoja

            .Id = 0
            .IdInventario = Zw_Inv_Inventario.Id
            .Nro_Hoja = String.Empty
            .NombreEquipo = _NombreEquipo
            .CodResponsable = _CodResponsable
            .IdContador1 = 0
            .IdContador2 = 0

        End With

        Dim _Zw_Inv_Hoja_Detalle As New Zw_Inv_Hoja_Detalle

        With _Zw_Inv_Hoja_Detalle

            .Id = 0
            .IdHoja = 1
            .Nro_Hoja = String.Empty
            .IdInventario = Zw_Inv_Inventario.Id
            .Empresa = Zw_Inv_Inventario.Empresa
            .Sucursal = Zw_Inv_Inventario.Sucursal
            .Bodega = Zw_Inv_Inventario.Bodega
            .Responsable = String.Empty
            .IdContador1 = 0
            .IdContador2 = 0
            .Item_Hoja = "001"
            .IdUbicacion = 0
            .CodUbicacion = String.Empty
            .TipoConteo = String.Empty
            .Codproducto = String.Empty
            .EsSeriado = False
            .NroSerie = String.Empty
            .Rtu = 0
            .RtuVariable = False
            .Udtrpr = 1
            .Ud1 = String.Empty
            .CantidadUd1 = 0
            .Ud2 = String.Empty
            .CantidadUd2 = 0
            .Observaciones = String.Empty
            .Recontado = False
            .Actualizado_por = String.Empty
            .Obs_Actualizacion = String.Empty

            Ls_Zw_Inv_Hoja_Detalle.Add(_Zw_Inv_Hoja_Detalle)

        End With

        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Mensaje = "Registros cargados correctamente"

    End Function

    Function Fx_Crear_Hoja(_Zw_Inv_Hoja As Zw_Inv_Hoja, Ls_Zw_Inv_Hoja_Detalle As List(Of Zw_Inv_Hoja_Detalle)) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        _Mensaje_Stem.Detalle = "Crear Hoja de Inventario"
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

            With _Zw_Inv_Hoja

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Inv_Hoja (IdInventario,Nro_Hoja,NombreEquipo,FechaCreacion,CodResponsable,IdContador1,IdContador2,FechaLevantamiento,Reconteo) Values " &
                               "(" & .IdInventario & ",'" & .Nro_Hoja & "','" & .NombreEquipo & "','" & .FechaCreacion & "','" & .CodResponsable & "'," & .IdContador1 & "," & .IdContador2 & ",'" & .FechaLevantamiento & "'," & Convert.ToInt32(.Reconteo) & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    .Id = dfd1("Identity")
                End While
                dfd1.Close()

            End With

            For Each _Zw_Inv_Hoja_Detalle As Zw_Inv_Hoja_Detalle In Ls_Zw_Inv_Hoja_Detalle

                With _Zw_Inv_Hoja_Detalle

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Inv_Hoja_Detalle (IdHoja,Nro_Hoja,IdInventario,Empresa,Sucursal,Bodega,Responsable,IdContador1,IdContador2,Item_Hoja,IdUbicacion,CodUbicacion,TipoConteo,Codproducto,EsSeriado,NroSerie,FechaHoraToma,Rtu,RtuVariable,Udtrpr,Ud1,CantidadUd1,Ud2,CantidadUd2,Observaciones,Recontado,Actualizado_por,Obs_Actualizacion) Values " &
                                   "(" & .IdHoja & ",'" & .Nro_Hoja & "'," & .IdInventario & ",'" & .Empresa & "','" & .Sucursal & "','" & .Bodega & "','" & .Responsable & "'," & .IdContador1 & "," & .IdContador2 & ",'" & .Item_Hoja & "'," & .IdUbicacion & ",'" & .CodUbicacion & "','" & .TipoConteo & "','" & .Codproducto & "'," & Convert.ToInt32(.EsSeriado) & ",'" & .NroSerie & "','" & .FechaHoraToma & "','" & .Rtu & "','" & .RtuVariable & "','" & .Udtrpr & "','" & .Ud1 & "'," & .CantidadUd1 & ",'" & .Ud2 & "'," & .CantidadUd2 & ",'" & .Observaciones & "'," & Convert.ToInt32(.Recontado) & ",'" & .Actualizado_por & "','" & .Obs_Actualizacion & "')"

                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End With

            Next

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Hoja Where Id = " & _Zw_Inv_Hoja.Id
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Mensaje = "Hoja creada correctamente"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information
            _Mensaje_Stem.Detalle = "Hoja creada correctamente con el Id " & _Row.Item("Id")
            _Mensaje_Stem.Tag = _Row
            _Mensaje_Stem.Id = _Row.Item("Id")

        Catch ex As Exception

            _Mensaje_Stem.Mensaje = ex.Message
            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

End Class
