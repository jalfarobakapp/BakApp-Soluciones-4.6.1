Imports System.Data.SqlClient
Imports BkSpecialPrograms.Pallet

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

    'Public Sub Fx_EliminarDetalle(_Detalle As Nvv_Customizable.Detalle)

    '    Ls_Detalle.Remove(_Detalle)

    'End Sub

    'Public Sub Fx_ModificarDetalle(_Detalle As Nvv_Customizable.Detalle)

    '    Dim _DetalleModificar As Nvv_Customizable.Detalle = Ls_Detalle.Find(Function(x) x.Idmaeddo = _Detalle.Idmaeddo)

    '    _DetalleModificar = _Detalle

    'End Sub

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

                    If Not String.IsNullOrEmpty(.CodigoAlt) Then

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Docu_Det_Cust (Idmaeddo,CodigoAlt,Descripcion,Cantidad) Values " &
                                       "('" & .Idmaeddo & "','" & .CodigoAlt & "','" & .Descripcion & "','" & .Cantidad & "')"
                        Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                        Dim _Horagrab = Hora_Grab_fx(False)

                        Consulta_sql = "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC,HORAGRAB) Values " &
                                       "('MAEDDO'," & .Idmaeddo & ",'" & FUNCIONARIO & "'" &
                                       ",Getdate(),'CUSTNVV','" & .CodigoAlt.ToString.Trim & "'," & .Cantidad & "," & _Horagrab & ")"
                        Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                    End If

                End With

            Next

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Crear Hoja"
            _Mensaje.Mensaje = "Documento grabado correctamente"
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error al grabar"
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop

            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function



End Class


