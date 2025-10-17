Imports System.Data.SqlClient

Public Class Cl_RemotasEnCadena

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_Remotas_En_Cadena_01_Enc As New Zw_Remotas_En_Cadena_01_Enc
    Public Property Ls_Zw_Remotas_En_Cadena_02_Det As New List(Of Zw_Remotas_En_Cadena_02_Det)
    Public Property Ls_Zw_Remotas_En_Cadena_03_Usu As New List(Of Zw_Remotas_En_Cadena_03_Usu)

    Public Property Ds_Matriz_Documentos As Ds_Matriz_Documentos

    Public Sub New(Ds_Matriz_Documentos As Ds_Matriz_Documentos)

        Me.Ds_Matriz_Documentos = Ds_Matriz_Documentos

    End Sub

    Function Fx_Cadena_Remotas_Crear_Cadena() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand


        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            Dim dfd1 As System.Data.SqlClient.SqlDataReader

            With Zw_Remotas_En_Cadena_01_Enc

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc (Empresa,Nro_RCadena,CodEntidad,CodSucEntidad,Nombre_Entidad,Id_DocEnc," &
                               "Usuario_Solicita,Fecha_Hora,Tido,Total_Original,Total_Documento)" & vbCrLf &
                               "Values ('" & .Empresa & "','" & .Nro_RCadena & "','" & .CodEntidad & "','" & .CodSucEntidad & "','" & .Nombre_Entidad &
                               "'," & .Id_DocEnc & ",'" & .Usuario_Solicita & "',Getdate(),'" & .Tido & "'," &
                               De_Num_a_Tx_01(.Total_Original, False, 5) & "," & De_Num_a_Tx_01(.Total_Original, False, 5) & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Comando = New System.Data.SqlClient.SqlCommand("Select @@IDENTITY AS 'Identity'", Cn2)
                Comando.Transaction = myTrans
                dfd1 = Comando.ExecuteReader()
                While dfd1.Read()
                    .Id_Enc = dfd1("Identity")
                End While
                dfd1.Close()

            End With

            Dim Contador As Integer = 1

            For Each _FDet As Zw_Remotas_En_Cadena_02_Det In Ls_Zw_Remotas_En_Cadena_02_Det

                Dim _Id_DetOri As Integer = _FDet.Id_Det

                With _FDet

                    .Id_Enc = Zw_Remotas_En_Cadena_01_Enc.Id_Enc
                    .Nro_RCadena = Zw_Remotas_En_Cadena_01_Enc.Nro_RCadena

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Remotas_En_Cadena_02_Det (Id_Enc,Nro_RCadena,Orden,CodPermiso,Descripcion,Monto_Aprobacion,NroRemota)" & vbCrLf &
                                   "Values (" & .Id_Enc & ",'" & .Nro_RCadena & "'," & .Orden & ",'" & .CodPermiso &
                                   "','" & .Descripcion & "'," & De_Num_a_Tx_01(.Monto_Aprobacion, False, 5) & ",'" & .NroRemota & "')"

                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                    Comando = New System.Data.SqlClient.SqlCommand("Select @@IDENTITY AS 'Identity'", Cn2)
                    Comando.Transaction = myTrans
                    dfd1 = Comando.ExecuteReader()
                    While dfd1.Read()
                        .Id_Det = dfd1("Identity")
                    End While
                    dfd1.Close()

                End With

                For Each _FUsu As Zw_Remotas_En_Cadena_03_Usu In Ls_Zw_Remotas_En_Cadena_03_Usu

                    With _FUsu

                        .Id_Enc = Zw_Remotas_En_Cadena_01_Enc.Id_Enc

                        If _Id_DetOri = .Id_Det Then

                            .Id_Det = _FDet.Id_Det

                            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Remotas_En_Cadena_03_Usu (Id_Enc,Id_Det,Usuario_Destino)" & vbCrLf &
                                           "Values (" & .Id_Enc & "," & .Id_Det & ",'" & .Usuario_Destino & "')"

                            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        End If

                    End With

                Next

                Contador += 1

            Next

            ' ====================================================================================================================================

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "OK"

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message

            Zw_Remotas_En_Cadena_01_Enc.Id_Enc = 0
            myTrans.Rollback()

        End Try

        Return _Mensaje

    End Function

    Sub Sb_Insertar_DetalleConUsuario(_CodPermiso As String, _InsertarFuncionario As Boolean)

        Dim _Det As New Zw_Remotas_En_Cadena_02_Det

        ' Obtener el Id_Det máximo actual en la lista y sumarle 1 para autoincrementar
        Dim maxIdDet As Integer = 0
        If Ls_Zw_Remotas_En_Cadena_02_Det.Count > 0 Then
            maxIdDet = Ls_Zw_Remotas_En_Cadena_02_Det.Max(Function(x) x.Id_Det)
        End If

        With _Det
            .Id_Det = maxIdDet + 1
            .Id_Enc = 0
            .Nro_RCadena = String.Empty
            .Orden = Ls_Zw_Remotas_En_Cadena_02_Det.Count + 1
            .CodPermiso = _CodPermiso
            .Descripcion = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_Permisos", "DescripcionPermiso", "CodPermiso = '" & _CodPermiso & "'")
            .Monto_Aprobacion = 0
        End With

        Ls_Zw_Remotas_En_Cadena_02_Det.Add(_Det)

        If Not _InsertarFuncionario Then
            Return
        End If

        Consulta_sql = "Select CodUsuario From " & _Global_BaseBk & " ZW_PermisosVsUsuarios Where CodPermiso = '" & _CodPermiso & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _Tbl.Rows
            Dim _Usu As New Zw_Remotas_En_Cadena_03_Usu
            With _Usu
                .Id_Enc = 0
                .Id_Det = _Det.Id_Det
                .Usuario_Destino = _Fila.Item("CodUsuario")
            End With
            Ls_Zw_Remotas_En_Cadena_03_Usu.Add(_Usu)
        Next

    End Sub

End Class
