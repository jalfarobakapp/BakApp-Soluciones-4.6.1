Imports DevComponents.DotNetBar
Imports BkSpecialPrograms
Imports System.Data
Imports System.Data.SqlClient

Public Class Clas_Crear_DFA

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Error As String
    Public ReadOnly Property Pro_Error() As String
        Get
            Return _Error
        End Get
    End Property

    Function Fx_Crear_Documento(ByVal _Row_Pdatfae As DataRow, _
                                ByVal _Tbl_Pdatfad As DataTable, _
                                ByVal _Tbl_Pobrefad As DataTable) As Integer



        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Try

            Dim cn2 As New SqlConnection
            Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

            myTrans = cn2.BeginTransaction()



            Dim _Empresa As String = _Row_Pdatfae.Item("EMPRESA")
            Dim _Numdf = _Row_Pdatfae.Item("NUMDF")
            Dim _Numodc = _Row_Pdatfae.Item("NUMODC")
            Dim _Fecha = _Row_Pdatfae.Item("FECHA")
            Dim _Responsabl = _Row_Pdatfae.Item("RESPONSABL")
            Dim _Horagrab = _Row_Pdatfae.Item("HORAGRAB")
            Dim _Reqconfir = _Row_Pdatfae.Item("REQCONFIR")

            _Horagrab = Hora_Grab_fx(False) 'Math.Round((_HH * 3600) + (_MM * 60) + _SS, 0)

            Dim _Idpdatfae As Integer


            Consulta_sql = "INSERT INTO PDATFAE ( EMPRESA,NUMDF,NUMODC,FECHA,RESPONSABL,HORAGRAB,REQCONFIR) VALUES " & _
                           "('" & _Empresa & "','" & _Numdf & "','" & _Numodc & "','" & Format(_Fecha, "yyyyMMdd") & _
                           "','" & _Responsabl & "'," & _Horagrab & "," & CInt(_Reqconfir) * -1 & ")"

            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                _Idpdatfae = dfd1("Identity")
            End While
            dfd1.Close()



            Dim Contador As Integer = 1

            For Each _Detalle_Pdatfad As DataRow In _Tbl_Pdatfad.Rows

                Dim Estado As DataRowState = _Detalle_Pdatfad.RowState

                If Not Estado = DataRowState.Deleted Then

                    Dim _Archirst = _Detalle_Pdatfad.Item("ARCHIRST")
                    Dim _Idrst = _Detalle_Pdatfad.Item("IDRST")
                    'Dim _Empresa
                    'Dim _Numdf
                    Dim _Numot = _Detalle_Pdatfad.Item("NUMOT")
                    'Dim _Numodc = _Detalle_Pdatfad.Item("NUMODC")
                    Dim _Operacion = _Detalle_Pdatfad.Item("OPERACION")
                    Dim _Codmaq = _Detalle_Pdatfad.Item("CODMAQ")
                    'Dim _Fecha
                    Dim _Nregotl = _Detalle_Pdatfad.Item("NREGOTL")
                    Dim _Codigo = _Detalle_Pdatfad.Item("CODIGO")
                    Dim _Udad = _Detalle_Pdatfad.Item("UDAD")
                    Dim _Realjor = _Detalle_Pdatfad.Item("REALJOR")
                    Dim _Fechini = _Detalle_Pdatfad.Item("FECHINI")
                    Dim _Horaini = _Detalle_Pdatfad.Item("HORAINI")
                    Dim _Fechter = _Detalle_Pdatfad.Item("FECHTER")
                    Dim _Horater = _Detalle_Pdatfad.Item("HORATER")
                    Dim _Tiempo = _Detalle_Pdatfad.Item("TIEMPO")
                    Dim _Obrero1 = _Detalle_Pdatfad.Item("OBRERO1")
                    Dim _Obrero2 = _Detalle_Pdatfad.Item("OBRERO2")
                    Dim _Obrero3 = _Detalle_Pdatfad.Item("OBRERO3")
                    Dim _Obrero4 = _Detalle_Pdatfad.Item("OBRERO4")
                    Dim _Obrero5 = _Detalle_Pdatfad.Item("OBRERO5")
                    Dim _Obrero6 = _Detalle_Pdatfad.Item("OBRERO6")
                    Dim _Esultoper = _Detalle_Pdatfad.Item("ESULTOPER")
                    Dim _Udad2 = _Detalle_Pdatfad.Item("UDAD2")
                    Dim _Realjor2 = _Detalle_Pdatfad.Item("REALJOR2")
                    Dim _Rlud = _Detalle_Pdatfad.Item("RLUD")
                    Dim _Kocaudet = _Detalle_Pdatfad.Item("KOCAUDET")
                    Dim _Factor = _Detalle_Pdatfad.Item("FACTOR")
                    Dim _Idgdi = _Detalle_Pdatfad.Item("IDGDI")
                    Dim _Komolde = _Detalle_Pdatfad.Item("KOMOLDE")
                    Dim _Caviusadas = _Detalle_Pdatfad.Item("CAVIUSADAS")
                    Dim _Ciclousado = _Detalle_Pdatfad.Item("CICLOUSADO")
                    Dim _Idoccopext = _Detalle_Pdatfad.Item("IDOCCOPEXT")
                    Dim _Nudoocc = _Detalle_Pdatfad.Item("NUDOOCC")

                    Consulta_sql = "INSERT INTO PDATFAD(IDPDATFAE,ARCHIRST,IDRST,EMPRESA,NUMDF,NUMOT,NUMODC,OPERACION,CODMAQ," & _
                                  "FECHA,NREGOTL,CODIGO,UDAD,REALJOR,FECHINI,HORAINI,FECHTER,HORATER,TIEMPO,OBRERO1,OBRERO2," & _
                                  "OBRERO3,OBRERO4,OBRERO5,OBRERO6,ESULTOPER,UDAD2,REALJOR2,RLUD,KOCAUDET,FACTOR," & _
                                  "IDGDI,KOMOLDE,CAVIUSADAS,CICLOUSADO,IDOCCOPEXT,NUDOOCC) Values " & vbCrLf & _
                                  "(12,'POTPR   ',4,'01','0000000006','0000000001','','IFM1','IM-TO-C02',NULL,'00001'," & _
                                  "'I1CR14HMZ4165','UN',2.00000,{d '2018-02-26'},14.30000,{d '2018-02-26'},14.30000,0.00000," & _
                                  "'','','','','','',0,'',0,0,'',1,0,'',0,0,0,'')"

                    Consulta_sql = "INSERT INTO PDATFAD(IDPDATFAE,ARCHIRST,IDRST,EMPRESA,NUMDF,NUMOT,NUMODC,OPERACION,CODMAQ," & _
                                   "FECHA,NREGOTL,CODIGO,UDAD,REALJOR,FECHINI,HORAINI,FECHTER,HORATER,TIEMPO,OBRERO1,OBRERO2," & _
                                   "OBRERO3,OBRERO4,OBRERO5,OBRERO6,ESULTOPER,UDAD2,REALJOR2,RLUD,KOCAUDET,FACTOR," & _
                                   "IDGDI,KOMOLDE,CAVIUSADAS,CICLOUSADO,IDOCCOPEXT,NUDOOCC) Values " & vbCrLf & _
                                   "(" & _Idpdatfae & ",'" & _Archirst & "'," & _Idrst & ",'" & _Empresa & "','" & _Numdf & _
                                   "','" & _Numot & "','" & _Numodc & "','" & _Operacion & "','" & _Codmaq & "',NULL,'" & _Nregotl & "'," & _
                                   "'" & _Codigo & "','" & _Udad & "'," & De_Num_a_Tx_01(_Realjor, False, 5) & _
                                   ",'" & Format(_Fechini, "yyyyMMdd") & "'," & De_Num_a_Tx_01(_Horaini, False, 5) & _
                                   ",'" & Format(_Fechter, "yyyyMMdd") & "'," & De_Num_a_Tx_01(_Horater, False, 5) & _
                                   "," & De_Num_a_Tx_01(_Tiempo, False, 5) & "," & "'" & _Obrero1 & "','" & _Obrero2 & _
                                   "','" & _Obrero3 & "','" & _Obrero4 & "','" & _Obrero5 & "','" & _Obrero6 & _
                                   "'," & CInt(_Esultoper) * -1 & ",'" & _Udad2 & "'," & De_Num_a_Tx_01(_Realjor2, False, 5) & _
                                   "," & De_Num_a_Tx_01(_Rlud, False, 5) & ",'" & _Kocaudet & _
                                   "'," & _Factor & "," & _Idgdi & ",'" & _Komolde & "'," & De_Num_a_Tx_01(_Caviusadas, True) & _
                                   "," & De_Num_a_Tx_01(_Ciclousado, False, 5) & "," & _Idoccopext & ",'" & _Nudoocc & "')"

                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                    Dim _Idpdatfad As Integer ' IDPDATFAD

                    Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
                    Comando.Transaction = myTrans
                    dfd1 = Comando.ExecuteReader()
                    While dfd1.Read()
                        _Idpdatfad = dfd1("Identity")
                    End While
                    dfd1.Close()

                    For Each _Detalle_Pobrefad As DataRow In _Tbl_Pobrefad.Rows

                        'Dim _Idpdatfad = _Detalle_Pobrefad.Item("IDPDATFAD")
                        Dim _Obrero = _Detalle_Pobrefad.Item("OBRERO")
                        Dim _Fechiniob = _Detalle_Pobrefad.Item("FECHINIOB")
                        Dim _Horainiob = _Detalle_Pobrefad.Item("HORAINIOB")
                        Dim _Fechterob = _Detalle_Pobrefad.Item("FECHTEROB")
                        Dim _Horaterob = _Detalle_Pobrefad.Item("HORATEROB")
                        Dim _Tiempoob = _Detalle_Pobrefad.Item("TIEMPOOB")
                        Dim _Kojornada = _Detalle_Pobrefad.Item("KOJORNADA")
                        Dim _Tiempoobhe = _Detalle_Pobrefad.Item("TIEMPOOBHE")

                        ' INSERT INTO POBREFAD ( IDPDATFAD,OBRERO,FECHINIOB,HORAINIOB,FECHTEROB,HORATEROB,TIEMPOOB,KOJORNADA,TIEMPOOBHE) VALUES 
                        ' ( 22,'12675955',{d '2018-02-26'},14.30000,{d '2018-02-26'},14.30000,0.00000,'JORNADA_TIPO ',0.00000)

                        Consulta_sql = "INSERT INTO POBREFAD ( IDPDATFAD,OBRERO,FECHINIOB,HORAINIOB,FECHTEROB,HORATEROB,TIEMPOOB," & _
                                       "KOJORNADA,TIEMPOOBHE) VALUES " & vbCrLf & _
                                       "(22,'12675955',{d '2018-02-26'},14.30000,{d '2018-02-26'},14.30000,0.00000," & _
                                       "'JORNADA_TIPO ',0.00000)"

                        Consulta_sql = "INSERT INTO POBREFAD ( IDPDATFAD,OBRERO,FECHINIOB,HORAINIOB,FECHTEROB,HORATEROB,TIEMPOOB," & _
                                      "KOJORNADA,TIEMPOOBHE) VALUES " & vbCrLf & _
                                      "(" & _Idpdatfad & ",'" & _Obrero & "','" & Format(_Fechiniob, "yyyyMMdd") & _
                                      "'," & De_Num_a_Tx_01(_Horainiob, False, 5) & ",'" & Format(_Fechterob, "yyyyMMdd") & _
                                      "'," & De_Num_a_Tx_01(_Horaterob, False, 5) & "," & De_Num_a_Tx_01(_Tiempoob, False, 5) & "," & _
                                      "'" & _Kojornada & "'," & De_Num_a_Tx_01(_Tiempoobhe, False, 5) & ")"

                        Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                    Next

                    'Dim _Row_Potpr As DataRow
                    Consulta_sql = "SELECT TOP 1 REALIZADO FROM POTPR WITH ( NOLOCK )" & _
                                   "WHERE NUMOT = '" & _Numot & "'" & Space(1) & _
                                   "AND NREGOTL='" & _Nregotl & "'" & Space(1) & _
                                   "AND OPERACION='" & _Operacion & "'"

                    Comando = New SqlCommand(Consulta_sql, cn2)
                    Comando.Transaction = myTrans
                    Dim _Dr_Potpr = Comando.ExecuteReader()
                    Dim _Realizado As Double
                    While _Dr_Potpr.Read()
                        _Realizado = _Dr_Potpr.Item("REALIZADO") + _Realjor
                    End While
                    _Dr_Potpr.Close()

                    Consulta_sql = "UPDATE POTPR SET REALIZADO=" & De_Num_a_Tx_01(_Realizado, False, 5) & vbCrLf & _
                                   "WHERE NUMOT = '" & _Numot & "' AND NREGOTL = '" & _Nregotl & "'" & Space(1) & _
                                   "AND OPERACION = '" & _Operacion & "'"

                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                    Contador += 1

                End If

            Next

            

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Return _Idpdatfae

        Catch ex As Exception

            myTrans.Rollback()
            _Error = ex.Message
            Return 0

        End Try

    End Function

End Class
