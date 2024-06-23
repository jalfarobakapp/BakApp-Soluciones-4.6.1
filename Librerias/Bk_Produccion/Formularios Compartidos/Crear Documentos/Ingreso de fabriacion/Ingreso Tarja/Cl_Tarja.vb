Imports System.Data.SqlClient
Imports Bk_Produccion.Cl_Tarja_Ent
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Cl_Tarja

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_Pdp_CPT_Tarja As New Zw_Pdp_CPT_Tarja
    Public Property Zw_Pdp_CPT_Tarja_Det_Ls As New List(Of Zw_Pdp_CPT_Tarja_Det)

    Public Sub New()

        Zw_Pdp_CPT_Tarja.Empresa = ModEmpresa

    End Sub

    'Function Fx_Grabar_Tarja() As Cl_Tarja_Ent.Mensaje_Tarja

    '    Dim _Mensaje_Tarja As New Cl_Tarja_Ent.Mensaje_Tarja

    '    Try

    '        With _Cl_Tarja_Ent

    '            .Nro_CPT = Fx_NvoNro_CPT()

    '            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja (Empresa,Idmaeddo,Nro_CPT,Codigo,CodAlternativo,CodAlternativo_Pallet,Turno,Planta," &
    '                           "Udm,Formato,Lote,FechaElab,SacosXPallet,Analista,Observaciones,Tipo,CantidadTipo,CantidadFab,Descripcion_Kopral)" & vbCrLf &
    '                           "Values ('" & .Empresa & "'," & .Idmaeddo & ",'" & .Nro_CPT & "','" & .Codigo & "','" & .CodAlternativo & "','" & .CodAlternativo_Pallet & "','" & .Turno &
    '                           "','" & .Planta & "','" & .Udm & "','" & .Formato & "','" & .Lote & "','" & .FechaElab &
    '                           "'," & .SacosXPallet & ",'" & .Analista & "','" & .Observaciones.Replace("'", "''") &
    '                           "','" & .Tipo &
    '                           "'," & De_Num_a_Tx_01(.CantidadTipo, False, 5) &
    '                           "," & De_Num_a_Tx_01(.CantidadFab, False, 5) &
    '                           ",'" & .Descripcion_Kopral & "')"

    '        End With

    '        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
    '            _Mensaje_Tarja.EsCorrecto = True
    '        Else
    '            Throw New System.Exception(_Sql.Pro_Error)
    '        End If

    '    Catch ex As Exception
    '        _Mensaje_Tarja.Mensaje = ex.Message
    '    End Try

    '    Return _Mensaje_Tarja

    'End Function

    Function Fx_Grabar_Tarja2() As LsValiciones.Mensajes ' Cl_Tarja_Ent.Mensaje_Tarja

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        SQL_ServerClass.Sb_Abrir_Conexion(cn2)

        myTrans = cn2.BeginTransaction()

        Try

            With Zw_Pdp_CPT_Tarja

                .Nro_CPT = Fx_NvoNro_CPT()

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja (Empresa,Idmaeddo,Nro_CPT,Codigo,CodAlternativo,CodAlternativo_Pallet,Turno,Planta," &
                               "Udm,Formato,Lote,FechaElab,SacosXPallet,Analista,Observaciones,Tipo,CantidadTipo,CantidadFab,Descripcion_Kopral,Idpote,Idpotl,Tolva,BodegaDesde)" & vbCrLf &
                               "Values ('" & .Empresa & "'," & .Idmaeddo & ",'" & .Nro_CPT & "','" & .Codigo & "','" & .CodAlternativo & "','" & .CodAlternativo_Pallet & "','" & .Turno &
                               "','" & .Planta & "','" & .Udm & "','" & .Formato & "','" & .Lote & "','" & .FechaElab &
                               "'," & .SacosXPallet & ",'" & .Analista & "','" & .Observaciones.Replace("'", "''") &
                               "','" & .Tipo &
                               "'," & De_Num_a_Tx_01(.CantidadTipo, False, 5) &
                               "," & De_Num_a_Tx_01(.CantidadFab, False, 5) &
                               ",'" & .Descripcion_Kopral & "'," & .Idpote & "," & .Idpotl & ",'" & .Tolva & "','" & .BodegaDesde & "')"

            End With

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                Zw_Pdp_CPT_Tarja.Id = dfd1("Identity")
            End While
            dfd1.Close()

            Dim _Nro As Integer

            Consulta_sql = "Select Isnull(MAX(Nro),0)+1 As Nro From " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja_Det" & vbCrLf &
                           "Where Lote = '" & Zw_Pdp_CPT_Tarja.Lote & "' And Codigo = '" & Zw_Pdp_CPT_Tarja.Codigo & "'"

            Comando = New SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            dfd1 = Comando.ExecuteReader()
            While dfd1.Read()
                _Nro = dfd1("Nro")
            End While
            dfd1.Close()

            For Each _Fila As Zw_Pdp_CPT_Tarja_Det In Zw_Pdp_CPT_Tarja_Det_Ls

                With _Fila

                    .Id_CPT = Zw_Pdp_CPT_Tarja.Id
                    .Nro_CPT = Zw_Pdp_CPT_Tarja.Nro_CPT
                    .Nro = _Nro
                    .Nro_Tipo = Fx_NvoNro_Tipo(Comando, cn2, myTrans, .Tipo, "PLT")

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja_Det (Id_CPT,Nro_Tipo,Idmaeddo,Nro_CPT,Lote,Tipo,Nro,Codigo,CodAlternativo,CodAlternativo_Pallet)" & vbCrLf &
                                   "Values (" & .Id_CPT & ",'" & .Nro_Tipo & "'," & .Idmaeddo & ",'" & .Nro_CPT & "','" & .Lote & "','" & .Tipo & "'" &
                                   "," & .Nro & ",'" & .Codigo & "','" & .CodAlternativo & "','" & .CodAlternativo_Pallet & "')"

                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End With

                _Nro += 1

            Next

            '**********************************'**********************************
            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            _Mensaje.EsCorrecto = True
            _Mensaje.Id = Zw_Pdp_CPT_Tarja.Id
            _Mensaje.Detalle = "Grabar Tarja"
            _Mensaje.Mensaje = "Tarja guardada correctamente"
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Detalle = "Grabar Tarja"
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function

    Function Fx_NvoNro_CPT() As String

        Dim _Nro_CPT As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _TblPaso = _Sql.Fx_Get_DataTable("Select Max(Nro_CPT) As Numero From " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja")

        Dim _Ult_Nro_OT As String = NuloPorNro(_TblPaso.Rows(0).Item("Numero"), "")

        If String.IsNullOrEmpty(Trim(_Ult_Nro_OT)) Then
            _Ult_Nro_OT = "0000000000"
        End If

        _Nro_CPT = Fx_Proximo_NroDocumento(_Ult_Nro_OT, 10)

        Return _Nro_CPT

    End Function

    Function Fx_NvoNro_Tipo(Comando As SqlClient.SqlCommand,
                              cn2 As SqlConnection,
                              myTrans As SqlClient.SqlTransaction,
                              _Tipo As String,
                              _Sufijo As String) As String

        Dim _Nro_CPT As String
        Dim _Ult_Nro_Tipo As String

        Dim _Nro1 = Rellenar(_Sufijo, 10, "0")

        Consulta_sql = "Select Isnull(Max(Nro_Tipo),'" & _Nro1 & "') As Nro From " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja_Det" & vbCrLf &
                       "Where Tipo = '" & _Tipo & "'"

        Comando = New SqlCommand(Consulta_sql, cn2)
        Comando.Transaction = myTrans
        Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
        While dfd1.Read()
            _Ult_Nro_Tipo = dfd1("Nro")
        End While
        dfd1.Close()

        _Nro_CPT = Fx_Proximo_NroDocumento(_Ult_Nro_Tipo, 10)

        Return _Nro_CPT

    End Function

End Class

Namespace Cl_Tarja_Ent

    'Public Class CPT_Tarja
    '    Public Property Id As Integer
    '    Public Property Empresa As String
    '    Public Property Idmaeddo As Integer
    '    Public Property Nro_CPT As String
    '    Public Property Lote As String
    '    Public Property Codigo As String
    '    Public Property CodAlternativo As String
    '    Public Property CodAlternativo_Pallet As String
    '    Public Property Turno As String
    '    Public Property Planta As String
    '    Public Property Udm As String
    '    Public Property Formato As Integer
    '    Public Property FechaElab As DateTime
    '    Public Property SacosXPallet As Integer
    '    Public Property Analista As String
    '    Public Property Observaciones As String
    '    Public Property Tipo As String
    '    Public Property CantidadTipo As Double
    '    Public Property CantidadFab As Double
    '    Public Property Descripcion_Kopral As String
    '    Public Property Tolva As String
    'End Class

    'Public Class CPT_Tarja_Det

    '    Public Property Id As Integer
    '    Public Property Id_CPT As Integer
    '    Public Property Nro_Tipo As String
    '    Public Property Idmaeddo As Integer
    '    Public Property Nro_CPT As String
    '    Public Property Lote As String
    '    Public Property Tipo As String
    '    Public Property Nro As Integer
    '    Public Property Codigo As String
    '    Public Property CodAlternativo As String
    '    Public Property CodAlternativo_Pallet As String

    'End Class

End Namespace

