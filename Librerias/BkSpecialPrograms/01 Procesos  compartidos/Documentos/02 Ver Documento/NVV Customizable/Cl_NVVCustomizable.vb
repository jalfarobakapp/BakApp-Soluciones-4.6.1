Imports System.Data.SqlClient

Public Class Cl_NVVCustomizable

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Ls_Detalle As List(Of Zw_Docu_Det_Cust)

    Public Sub New()

        Ls_Detalle = New List(Of Zw_Docu_Det_Cust)

    End Sub

    Public Sub Fx_AgregarDetalle(_Detalle As Zw_Docu_Det_Cust)

        Ls_Detalle.Add(_Detalle)

    End Sub

    Function Fx_Llenar_Detalle(_Idmaeddo As Integer) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Docu_Det_Cust Where Idmaeddo = " & _Idmaeddo
        Dim _Tbl_Det As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Not CBool(_Tbl_Det.Rows.Count) Then

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Col1_Mensaje = "No se encontraron registros en la tabla Zw_Docu_Det_Cust con el Id_Enc " & _Idmaeddo

            Return _Mensaje_Stem

        End If

        For Each _Row As DataRow In _Tbl_Det.Rows

            Dim _Det As New Zw_Docu_Det_Cust

            With _Det
                .Id = _Row("Id")
                .Idmaeedo = _Row("Idmaeedo")
                .Idmaeddo = _Row("Idmaeddo")
                .CodigoAlt = _Row("CodigoAlt")
                .Descripcion = _Row("Descripcion")
                .Cantidad = _Row("Cantidad")
                .Codigo = _Row("Codigo")
            End With

            Ls_Detalle.Add(_Det)

        Next

        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Col1_Mensaje = "Registros cargados correctamente"

        Return _Mensaje_Stem

    End Function

    Function Fx_Grabar_Detalle_Customizados() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            For Each _Fila As Zw_Docu_Det_Cust In Ls_Detalle

                With _Fila

                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Docu_Det_Cust Where Idmaeedo = " & .Idmaeedo & " And Codigo = '" & .Codigo & "'"
                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End With

            Next


            For Each _Fila As Zw_Docu_Det_Cust In Ls_Detalle

                With _Fila

                    If Not String.IsNullOrEmpty(.CodigoAlt) Then

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Docu_Det_Cust (Idmaeedo,Idmaeddo,CodigoAlt,Descripcion,Cantidad,Codigo) Values " &
                                       "(" & .Idmaeedo & "," & .Idmaeddo & ",'" & .CodigoAlt & "','" & .Descripcion & "','" & .Cantidad & "','" & .Codigo & "')"
                        Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                    End If

                End With

            Next

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.EsCorrecto = True
            _Mensaje.Col2_Detalle = "Crear Hoja"
            _Mensaje.Col1_Mensaje = "Documento grabado correctamente"
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Col2_Detalle = "Error al grabar"
            _Mensaje.Col1_Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop

            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function



End Class


