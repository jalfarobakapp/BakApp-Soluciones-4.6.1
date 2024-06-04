Imports System.Data.SqlClient

Public Class Cl_Arbol_Asociaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Public Property Zw_TblArbol_Asociaciones As New Zw_TblArbol_Asociaciones

    Public Sub New()

    End Sub

    Function Fx_Llenar_Asociacion(_Codigo_Nodo As Integer) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If IsNothing(_Row) Then

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = "No se encontro el registro en la tabla Zw_TblArbol_Asociaciones con el Codigo_Nodo " & _Codigo_Nodo

            Return _Mensaje_Stem

        End If

        With Zw_TblArbol_Asociaciones

            .Codigo_Nodo = _Row.Item("Codigo_Nodo")
            .Identificador_Nodo = _Row.Item("Identificador_Nodo")
            .Identificacdor_NodoPadre = _Row.Item("Identificacdor_NodoPadre")
            .Descripcion = _Row.Item("Descripcion")
            .Es_Padre = _Row.Item("Es_Padre")
            .Es_Seleccionable = _Row.Item("Es_Seleccionable")
            .Es_Ubicacion = _Row.Item("Es_Ubicacion")
            .Clas_Unica_X_Producto = _Row.Item("Clas_Unica_X_Producto")
            .Nodo_Raiz = _Row.Item("Nodo_Raiz")
            .Codigo_Madre = _Row.Item("Codigo_Madre")

        End With

        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Mensaje = "Registro encontrado."

        Return _Mensaje_Stem

    End Function

    Function Fx_Grabar_Clasificacion() As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_Sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_TblArbol_Asociaciones

                If .Codigo_Nodo = 0 Then

                    Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_TblArbol_Asociaciones (Identificacdor_NodoPadre,Descripcion,Codigo_Madre,Nodo_Raiz) Values " &
                               "(" & .Identificacdor_NodoPadre & ",'" & .Descripcion & "','" & .Codigo_Madre & "'," & .Nodo_Raiz & ")"

                    Comando = New SqlClient.SqlCommand(Consulta_Sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                    Comando = New System.Data.SqlClient.SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
                    Comando.Transaction = myTrans
                    Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
                    While dfd1.Read()
                        .Codigo_Nodo = dfd1("Identity")
                        .Identificador_Nodo = dfd1("Identity")
                    End While
                    dfd1.Close()

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Set " & vbCrLf &
                                   "Codigo_Nodo = " & .Codigo_Nodo &
                                   "Where Identificador_Nodo = " & .Codigo_Nodo

                    Comando = New SqlClient.SqlCommand(Consulta_Sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End If

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Set " & vbCrLf &
                               "Descripcion = '" & .Descripcion & "'" &
                               ",Es_Padre = " & Convert.ToInt32(.Es_Padre) &
                               ",Es_Seleccionable = " & Convert.ToInt32(.Es_Seleccionable) & vbCrLf &
                               ",Clas_Unica_X_Producto = " & Convert.ToInt32(.Clas_Unica_X_Producto) & vbCrLf &
                               "Where Codigo_Nodo = " & .Codigo_Nodo

                Comando = New SqlClient.SqlCommand(Consulta_Sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Prod_Asociacion Set " & vbCrLf &
                               "DescripcionBusqueda = '" & .Descripcion & "'" & vbCrLf &
                               "Where Codigo_Nodo = " & .Codigo_Nodo

                Comando = New SqlClient.SqlCommand(Consulta_Sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Detalle = "Grabar"
            _Mensaje_Stem.Mensaje = "Documento grabado correctamente"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Detalle = "Error al grabar"
            _Mensaje_Stem.Mensaje = ex.Message
            _Mensaje_Stem.Icono = MessageBoxIcon.Stop
            Zw_TblArbol_Asociaciones.Identificador_Nodo = 0
            Zw_TblArbol_Asociaciones.Codigo_Nodo = 0

            If Not IsNothing(myTrans) Then
                myTrans.Rollback()
            End If

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

    Function Fx_Eliminar_Clasificacion() As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_Sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_TblArbol_Asociaciones

                Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_TblArbol_Asociaciones" & vbCrLf &
                               "Where Codigo_Nodo = " & .Codigo_Nodo & " Or Identificacdor_NodoPadre = " & .Codigo_Nodo

                Comando = New SqlClient.SqlCommand(Consulta_Sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Detalle = "Eliminar"
            _Mensaje_Stem.Mensaje = "Clasificación y sub clasificaciones eliminadas correctamente"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Detalle = "Error al grabar"
            _Mensaje_Stem.Mensaje = ex.Message
            _Mensaje_Stem.Icono = MessageBoxIcon.Stop
            Zw_TblArbol_Asociaciones.Identificador_Nodo = 0
            Zw_TblArbol_Asociaciones.Codigo_Nodo = 0

            If Not IsNothing(myTrans) Then
                myTrans.Rollback()
            End If

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

End Class
