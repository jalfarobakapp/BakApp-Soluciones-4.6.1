Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Imports System.Data.SqlClient

Public Class Clas_Crear_DFA_Desde_Meson

    Dim Consulta_Sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Ds_DFA As DataSet
    Dim _Tbl_Pdatfae As DataTable
    Dim _Tbl_Pdatfad As DataTable
    Dim _Tbl_Pobrefad As DataTable

    Dim _Tbl_Fabricacion As DataTable

    Dim _Idpote As Integer
    Dim _Idpotl As Integer
    Dim _Error As String

    Dim _Row_Pote As DataRow

    Public ReadOnly Property Pro_Error() As String
        Get
            Return _Error
        End Get
    End Property

    Public Property Pro_Ds_DFA As DataSet
        Get
            Return _Ds_DFA
        End Get
        Set(value As DataSet)
            _Ds_DFA = value
        End Set
    End Property

    Public Property Pro_Tbl_Fabricacion As DataTable
        Get
            Return _Tbl_Fabricacion
        End Get
        Set(value As DataTable)
            _Tbl_Fabricacion = value
        End Set
    End Property

    Public Sub New(IdPote As Integer, Idpotl As String)

        Sb_Llenar_Ds_Y_Tablas()
        _Idpote = IdPote
        _Idpotl = Idpotl

        Consulta_Sql = "Select * From POTE Where IDPOTE = " & _Idpote
        _Row_Pote = _Sql.Fx_Get_DataRow(Consulta_Sql)

    End Sub

    Sub Sb_Crear_Dfa()

        Dim _Numdf = Fx_Siguiente_Nro_DFA()
        Dim _Fecha As Date = FechaDelServidor()

        Consulta_Sql = "Select Mq.*,
                        CONVERT(VARCHAR, Mq.Fecha_Hora_Inicio, 103) Fechaini,
                        CONVERT(VARCHAR, Mq.Fecha_Hora_Inicio, 108) Horaini,
	                    CONVERT(VARCHAR, Mq.Fecha_Hora_Termino, 103) Fechater,
                        CONVERT(VARCHAR, Mq.Fecha_Hora_Termino, 108) Horater,
	                    Convert(VARCHAR(200),((DateDiff(Minute, Mq.Fecha_Hora_Inicio, Mq.Fecha_Hora_Termino) / 60) / 24)) As Dias_En_Maquina,
                        Convert(VARCHAR(200), ((DateDiff(Minute, Mq.Fecha_Hora_Inicio, Mq.Fecha_Hora_Termino) / 60)%24)) As Horas_En_Maquina,
                        Convert(VARCHAR(200), DateDiff(Minute, Mq.Fecha_Hora_Inicio, Mq.Fecha_Hora_Termino)%60) As Minutos_En_Maquina,
	                    Nreg As SubOt 
                        From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Mq
                        Inner Join " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Op On Op.Idpotpr = Mq.Idpotpr 
                        Where Op.Idpote = " & _Idpote & " And Op.Idpotl = " & _Idpotl & " And Mq.Idpdatfae = 0 And Mq.Estado = 'FMQ'"

        _Tbl_Fabricacion = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Fx_Ingresar_Nueva_DFA_PDATFAE(_Numdf)

        For Each _Fila_Op As DataRow In _Tbl_Fabricacion.Rows

            Dim _HoraIni = Fx_Hora(_Fila_Op.Item("Horaini"))
            Dim _Horater = Fx_Hora(_Fila_Op.Item("Horater"))

            Dim _Fechaini = _Fila_Op.Item("Fechaini")
            Dim _Fechater = _Fila_Op.Item("Fechater")

            Dim _Idpotpr = _Fila_Op.Item("Idpotpr")
            Dim _Operacion = _Fila_Op.Item("Operacion")
            Dim _Codmaq = Trim(_Fila_Op.Item("CodMaq"))
            Dim _Codigo = Trim(_Fila_Op.Item("Codigo"))
            Dim _Fabricado = _Fila_Op.Item("Fabricado")
            Dim _Kocaudet = Trim(_Fila_Op.Item("Kocaudet"))


            Dim _Tiempo = Math.Round(_Horater - _HoraIni, 5)
            Dim _Idpotl = _Fila_Op.Item("Idpotl")
            Consulta_Sql = "Select Top 1 * From POTL Where IDPOTL = " & _Idpotl
            Dim _Row_Potl As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            Dim _Idpdatfad As Integer = _Tbl_Pdatfad.Rows.Count + 1
            Dim _New_Operacion As DataRow = Fx_Ingresar_Nueva_Operacion_PDATFAD(_Row_Potl,
                                                                                _Idpdatfad,
                                                                                _Operacion,
                                                                                _Codmaq,
                                                                                _Codigo,
                                                                                _Fechaini,
                                                                                _Fechater,
                                                                                _HoraIni,
                                                                                _Horater,
                                                                                _Tiempo,
                                                                                _Fabricado,
                                                                                _Idpotpr,
                                                                                _Kocaudet)

            Dim _Obrero = _Fila_Op.Item("Obrero")

            Consulta_Sql = "Select Top 1 * From PMAEOB Where CODIGOOB = '" & _Obrero & "'"

            Dim _Row_Operario As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)
            Dim _New_Operario As DataRow = Fx_Ingresar_Nuevo_Operario_POBREFAD(_Idpdatfad, _Row_Operario)

        Next
        
    End Sub

    Sub Sb_Crear_Dfa2(_Fila_Mq As DataRow)

        Dim _Numdf = Fx_Siguiente_Nro_DFA()
        Dim _Fecha As Date = FechaDelServidor()

        'Consulta_Sql = "Select Mq.*,
        '                CONVERT(VARCHAR, Mq.Fecha_Hora_Inicio, 103) Fechaini,
        '                CONVERT(VARCHAR, Mq.Fecha_Hora_Inicio, 108) Horaini,
        '                CONVERT(VARCHAR, Mq.Fecha_Hora_Termino, 103) Fechater,
        '                CONVERT(VARCHAR, Mq.Fecha_Hora_Termino, 108) Horater
        '                Nreg As SubOt 
        '                From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Mq
        '                Inner Join " & _Global_BaseBk & "Zw_Pdp_MesonVsProductos Op On Op.Idpotpr = Mq.Idpotpr 
        '                Where Op.Idpote = " & _Idpote & " And Op.Idpotl = " & _Idpotl & " And Mq.Idpdatfae = 0 And Mq.Estado = 'FMQ'"

        '_Tbl_Fabricacion = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Fx_Ingresar_Nueva_DFA_PDATFAE(_Numdf)

        'For Each _Fila_Op As DataRow In _Tbl_Fabricacion.Rows

        Dim _HoraIni = Fx_Hora(_Fila_Mq.Item("Horaini"))
        Dim _Horater = Fx_Hora(_Fila_Mq.Item("Horater"))

        Dim _Fechaini = _Fila_Mq.Item("Fechaini")
        Dim _Fechater = _Fila_Mq.Item("Fechater")

        Dim _Idpotpr = _Fila_Mq.Item("Idpotpr")
        Dim _Operacion = _Fila_Mq.Item("Operacion")
        Dim _Codmaq = Trim(_Fila_Mq.Item("CodMaq"))
        Dim _Codigo = Trim(_Fila_Mq.Item("Codigo"))
        Dim _Fabricado = _Fila_Mq.Item("Fabricado")
        Dim _Kocaudet = Trim(_Fila_Mq.Item("Kocaudet"))


        Dim _Tiempo = Math.Round(_Horater - _HoraIni, 5)
        Dim _Idpotl = _Fila_Mq.Item("Idpotl")
        Consulta_Sql = "Select Top 1 * From POTL Where IDPOTL = " & _Idpotl
        Dim _Row_Potl As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Dim _Idpdatfad As Integer = _Tbl_Pdatfad.Rows.Count + 1
        Dim _New_Operacion As DataRow = Fx_Ingresar_Nueva_Operacion_PDATFAD(_Row_Potl,
                                                                                _Idpdatfad,
                                                                                _Operacion,
                                                                                _Codmaq,
                                                                                _Codigo,
                                                                                _Fechaini,
                                                                                _Fechater,
                                                                                _HoraIni,
                                                                                _Horater,
                                                                                _Tiempo,
                                                                                _Fabricado,
                                                                                _Idpotpr,
                                                                                _Kocaudet)

        Dim _Obrero = _Fila_Mq.Item("Obrero")

        Consulta_Sql = "Select Top 1 * From PMAEOB Where CODIGOOB = '" & _Obrero & "'"

        Dim _Row_Operario As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)
        Dim _New_Operario As DataRow = Fx_Ingresar_Nuevo_Operario_POBREFAD(_Idpdatfad, _Row_Operario)

        'Next

    End Sub

    Function Fx_Hora(_Hora) As String

        Dim _LaHora = Split(_Hora, ":")

        Dim _Hh As Integer = _LaHora(0)
        Dim _Mm As Integer = _LaHora(1)

        Dim _Horaini = _Hh + (_Mm / 100)

        Return _Horaini

    End Function

    Function Fx_Ingresar_Nueva_DFA_PDATFAE(_Numdf As String) As DataRow

        Try
            'EMPRESA,NUMDF,NUMODC,FECHA,RESPONSABL,HORAGRAB,REQCONFIR
            Dim NewFila As DataRow
            NewFila = _Tbl_Pdatfae.NewRow
            With NewFila

                .Item("EMPRESA") = Trim(ModEmpresa)
                .Item("NUMDF") = _Numdf
                .Item("NUMODC") = String.Empty
                .Item("FECHA") = FormatDateTime(Now.Date, DateFormat.ShortDate)
                .Item("RESPONSABL") = FUNCIONARIO
                .Item("HORAGRAB") = Hora_Grab_fx(False)
                .Item("REQCONFIR") = 1

                _Tbl_Pdatfae.Rows.Add(NewFila)

            End With
            Return NewFila
        Catch ex As Exception

        End Try

    End Function

    Function Fx_Ingresar_Nueva_Operacion_PDATFAD(_Row_Potl As DataRow,
                                                 _Idpdatfad As Integer,
                                                 _Operacion As String,
                                                 _Codmaq As String,
                                                 _Codigo As String,
                                                 _Fechaini As Date,
                                                 _Fechater As Date,
                                                 _Horaini As Double,
                                                 _Horater As Double,
                                                 _Tiempo As Double,
                                                 _Fabricado As Double,
                                                 _Idpotpr As Integer,
                                                 _Kocaudet As String) As DataRow

        'Dim _Idpdatfad As Integer = Grilla_Pdatfad.Rows.Count + 1
        'Dim _Fecha = Dtp_Fecha_Ingreso.Value
        'Dim _Hora As String = FormatDateTime(FechaDelServidor, DateFormat.ShortTime)
        'Dim _LaHora = Split(_Hora, ":")
        'Dim _Hh As Integer = _LaHora(0)
        'Dim _Mm As Integer = _LaHora(1)
        'Dim _Horaini = _Hh + (_Mm / 100)
        'Dim _codigo = _Row_SubOt.Item("CODIGO")

        Consulta_Sql = "Select Top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
        Dim _Row_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Dim _Row_OT As DataRow = _Tbl_Pdatfae.Rows(0)

        Try

            Dim NewFila As DataRow
            NewFila = _Tbl_Pdatfad.NewRow
            With NewFila

                .Item("IDPDATFAD") = _Idpdatfad
                .Item("ARCHIRST") = "POTPR" 'String.Empty
                .Item("IDRST") = _Idpotpr
                .Item("EMPRESA") = _Row_OT.Item("EMPRESA")
                .Item("NUMDF") = _Row_OT.Item("NUMDF")
                .Item("NUMOT") = _Row_Pote.Item("NUMOT")
                .Item("NUMODC") = _Row_OT.Item("NUMODC")
                .Item("OPERACION") = _Operacion
                .Item("CODMAQ") = _Codmaq
                .Item("FECHA") = _Tbl_Pdatfae.Rows(0).Item("FECHA")
                .Item("NREGOTL") = _Row_Potl.Item("NREG")
                .Item("CODIGO") = _Row_Potl.Item("CODIGO")
                .Item("UDAD") = _Row_Potl.Item("UDAD")
                .Item("REALJOR") = _Fabricado
                .Item("FECHINI") = _Fechaini 'FormatDateTime(_Fecha, DateFormat.ShortDate)
                .Item("HORAINI") = _Horaini
                .Item("FECHTER") = _Fechater 'FormatDateTime(_Fecha, DateFormat.ShortDate)
                .Item("HORATER") = _Horater
                .Item("TIEMPO") = _Tiempo
                .Item("OBRERO1") = String.Empty
                .Item("OBRERO2") = String.Empty
                .Item("OBRERO3") = String.Empty
                .Item("OBRERO4") = String.Empty
                .Item("OBRERO5") = String.Empty
                .Item("OBRERO6") = String.Empty
                .Item("ESULTOPER") = 0
                .Item("UDAD2") = _Row_Producto.Item("UD02PR")
                .Item("REALJOR2") = 0
                .Item("RLUD") = _Row_Producto.Item("RLUD")
                .Item("KOCAUDET") = _Kocaudet
                .Item("FACTOR") = 1
                .Item("IDGDI") = 0
                .Item("KOMOLDE") = String.Empty
                .Item("CAVIUSADAS") = 0
                .Item("CICLOUSADO") = 0
                .Item("IDOCCOPEXT") = 0
                .Item("NUDOOCC") = String.Empty

                _Tbl_Pdatfad.Rows.Add(NewFila)

            End With
            Return NewFila
        Catch ex As Exception

        End Try

    End Function

    Function Fx_Ingresar_Nuevo_Operario_POBREFAD(ByVal _Idpdatfad As Integer,
                                                 ByVal _Row_Operario As DataRow) As DataRow

        'IDPDATFAD,OBRERO,FECHINIOB,HORAINIOB,FECHTEROB,HORATEROB,TIEMPOOB,KOJORNADA,TIEMPOOBHE

        Try

            Dim _Codigoob = _Row_Operario.Item("CODIGOOB")
            Dim _Nombreob = _Row_Operario.Item("NOMBREOB")
            Dim _Kojornada = Trim(_Row_Operario.Item("KOJORNADA"))

            Dim _Row_Jornada As DataRow = Fx_Jornada(_Kojornada, FechaDelServidor)

            Dim _Hijo01 As Double = _Row_Jornada.Item("HIJOR01")
            Dim _Htjo01 As Double = _Row_Jornada.Item("HTJOR01")

            Dim _Hijo02 As Double = _Row_Jornada.Item("HIJOR02")
            Dim _Htjo02 As Double = _Row_Jornada.Item("HTJOR02")

            Dim foundRows() As Data.DataRow
            foundRows = _Tbl_Pdatfad.Select("IDPDATFAD = " & _Idpdatfad)

            Dim _Row = foundRows(0)

            Dim _Hora As String = FormatDateTime(FechaDelServidor, DateFormat.ShortTime)

            Dim _LaHora = Split(_Hora, ":")

            Dim _Hh As Integer = _LaHora(0)
            Dim _Mm As Integer = _LaHora(1)

            Dim _Horaini = _Row.Item("HORAINI")
            Dim _Horater = _Row.Item("HORATER") '_Hh + (_Mm / 100)

            Dim _Tiempo = Math.Round(_Horater - _Horaini, 5)

            Dim _Tiempo_Jornada As Double = 0
            Dim _Tiempo_Extra As Double = 0

            If _Horater > _Htjo01 Then
                _Tiempo_Jornada = Math.Round(_Horaini - _Htjo01, 5)
                _Tiempo_Extra = Math.Round(Math.Round(_Horater - _Horaini, 5) - _Tiempo_Jornada, 5)
                _Tiempo = _Tiempo_Jornada
            End If

            _Horater = _Row.Item("HORATER")
            _Tiempo = _Row.Item("TIEMPO")


            Dim NewFila As DataRow
            NewFila = _Tbl_Pobrefad.NewRow
            With NewFila

                .Item("IDPDATFAD") = Trim(_Idpdatfad)
                .Item("CODIGOOB") = Trim(_Codigoob)
                .Item("NOMBREOB") = Trim(_Nombreob)

                .Item("OBRERO") = Trim(_Codigoob)
                .Item("FECHINIOB") = _Row.Item("FECHINI")
                .Item("HORAINIOB") = _Row.Item("HORAINI")
                .Item("FECHTEROB") = _Row.Item("FECHTER")
                .Item("HORATEROB") = _Horater
                .Item("TIEMPOOB") = _Tiempo
                .Item("KOJORNADA") = _Kojornada
                .Item("TIEMPOOBHE") = 0 '_Tiempo_Extra

                _Tbl_Pobrefad.Rows.Add(NewFila)

            End With

            Return NewFila

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message)
        End Try

    End Function

    Private Sub Sb_Llenar_Ds_Y_Tablas()

        Consulta_Sql = "SELECT TOP 1 * FROM PDATFAE" & vbCrLf &
                       "WHERE 1 < 0" &
                       vbCrLf &
                       vbCrLf &
                       "SELECT TOP 1 CAST(0 AS INT) AS IDPDATFAD,ARCHIRST,IDRST,EMPRESA,NUMDF,NUMOT,NUMODC,OPERACION,CODMAQ,FECHA,NREGOTL,CODIGO," &
                       "UDAD,REALJOR,FECHINI,HORAINI,FECHTER,HORATER,TIEMPO,OBRERO1,OBRERO2,OBRERO3,OBRERO4,OBRERO5,OBRERO6," &
                       "ESULTOPER,UDAD2,REALJOR2,RLUD,KOCAUDET,FACTOR,IDGDI,KOMOLDE,CAVIUSADAS,CICLOUSADO,IDOCCOPEXT,NUDOOCC" & vbCrLf &
                       "FROM PDATFAD" & vbCrLf &
                       "WHERE 1 < 0" &
                       vbCrLf &
                       vbCrLf &
                       "SELECT CAST(0 AS INT) AS IDPDATFAD,OBRERO,OBRERO AS CODIGOOB,CAST('' AS VARCHAR(50)) AS NOMBREOB,FECHINIOB,HORAINIOB,FECHTEROB,HORATEROB,TIEMPOOB,VALHORA,VALUNID," &
                       "VALADI1,VALADI2,KOJORNADA,TIEMPOOBHE" & vbCrLf &
                       "FROM POBREFAD" & vbCrLf &
                       "WHERE 1 < 0"

        _Ds_DFA = _Sql.Fx_Get_DataSet(Consulta_Sql)


        _Ds_DFA.Relations.Add("Relacion_DFA",
                                  _Ds_DFA.Tables("Table1").Columns("IDPDATFAD"),
                                  _Ds_DFA.Tables("Table2").Columns("IDPDATFAD"), False)

        _Tbl_Pdatfae = _Ds_DFA.Tables(0)
        _Tbl_Pdatfad = _Ds_DFA.Tables(1)
        _Tbl_Pobrefad = _Ds_DFA.Tables(2)

    End Sub

    Function Fx_Crear_Documento() As Integer

        Dim _Numdf = Fx_Siguiente_Nro_DFA()

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Try

            Dim cn2 As New SqlConnection
            Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

            SQL_ServerClass.Sb_Abrir_Conexion(cn2)

            myTrans = cn2.BeginTransaction()

            Dim _Row_Pdatfae As DataRow = _Tbl_Pdatfae.Rows(0)

            Dim _Empresa As String = _Row_Pdatfae.Item("EMPRESA")
            Dim _Numodc = _Row_Pdatfae.Item("NUMODC")
            Dim _Fecha = _Row_Pdatfae.Item("FECHA")
            Dim _Responsabl = _Row_Pdatfae.Item("RESPONSABL")
            Dim _Horagrab = _Row_Pdatfae.Item("HORAGRAB")
            Dim _Reqconfir = _Row_Pdatfae.Item("REQCONFIR")

            _Horagrab = Hora_Grab_fx(False)

            Dim _Idpdatfae As Integer

            If CBool(_Tbl_Pdatfad.Rows.Count) Then

                Consulta_Sql = "INSERT INTO PDATFAE ( EMPRESA,NUMDF,NUMODC,FECHA,RESPONSABL,HORAGRAB,REQCONFIR) VALUES " &
                           "('" & _Empresa & "','" & _Numdf & "','" & _Numodc & "','" & Format(_Fecha, "yyyyMMdd") &
                           "','" & _Responsabl & "'," & _Horagrab & "," & CInt(_Reqconfir) * -1 & ")"

                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
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

                        Consulta_Sql = "INSERT INTO PDATFAD(IDPDATFAE,ARCHIRST,IDRST,EMPRESA,NUMDF,NUMOT,NUMODC,OPERACION,CODMAQ," &
                                      "FECHA,NREGOTL,CODIGO,UDAD,REALJOR,FECHINI,HORAINI,FECHTER,HORATER,TIEMPO,OBRERO1,OBRERO2," &
                                      "OBRERO3,OBRERO4,OBRERO5,OBRERO6,ESULTOPER,UDAD2,REALJOR2,RLUD,KOCAUDET,FACTOR," &
                                      "IDGDI,KOMOLDE,CAVIUSADAS,CICLOUSADO,IDOCCOPEXT,NUDOOCC) Values " & vbCrLf &
                                      "(12,'POTPR   ',4,'01','0000000006','0000000001','','IFM1','IM-TO-C02',NULL,'00001'," &
                                      "'I1CR14HMZ4165','UN',2.00000,{d '2018-02-26'},14.30000,{d '2018-02-26'},14.30000,0.00000," &
                                      "'','','','','','',0,'',0,0,'',1,0,'',0,0,0,'')"

                        Consulta_Sql = "INSERT INTO PDATFAD(IDPDATFAE,ARCHIRST,IDRST,EMPRESA,NUMDF,NUMOT,NUMODC,OPERACION,CODMAQ," &
                                       "FECHA,NREGOTL,CODIGO,UDAD,REALJOR,FECHINI,HORAINI,FECHTER,HORATER,TIEMPO,OBRERO1,OBRERO2," &
                                       "OBRERO3,OBRERO4,OBRERO5,OBRERO6,ESULTOPER,UDAD2,REALJOR2,RLUD,KOCAUDET,FACTOR," &
                                       "IDGDI,KOMOLDE,CAVIUSADAS,CICLOUSADO,IDOCCOPEXT,NUDOOCC) Values " & vbCrLf &
                                       "(" & _Idpdatfae & ",'" & _Archirst & "'," & _Idrst & ",'" & _Empresa & "','" & _Numdf &
                                       "','" & _Numot & "','" & _Numodc & "','" & _Operacion & "','" & _Codmaq & "',NULL,'" & _Nregotl & "'," &
                                       "'" & _Codigo & "','" & _Udad & "'," & De_Num_a_Tx_01(_Realjor, False, 5) &
                                       ",'" & Format(_Fechini, "yyyyMMdd") & "'," & De_Num_a_Tx_01(_Horaini, False, 5) &
                                       ",'" & Format(_Fechter, "yyyyMMdd") & "'," & De_Num_a_Tx_01(_Horater, False, 5) &
                                       "," & De_Num_a_Tx_01(_Tiempo, False, 5) & "," & "'" & _Obrero1 & "','" & _Obrero2 &
                                       "','" & _Obrero3 & "','" & _Obrero4 & "','" & _Obrero5 & "','" & _Obrero6 &
                                       "'," & CInt(_Esultoper) * -1 & ",'" & _Udad2 & "'," & De_Num_a_Tx_01(_Realjor2, False, 5) &
                                       "," & De_Num_a_Tx_01(_Rlud, False, 5) & ",'" & _Kocaudet &
                                       "'," & _Factor & "," & _Idgdi & ",'" & _Komolde & "'," & De_Num_a_Tx_01(_Caviusadas, True) &
                                       "," & De_Num_a_Tx_01(_Ciclousado, False, 5) & "," & _Idoccopext & ",'" & _Nudoocc & "')"

                        Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                        Dim _Idpdatfad_Padre As Integer = _Detalle_Pdatfad.Item("IDPDATFAD")
                        Dim _Idpdatfad As Integer ' IDPDATFAD

                        Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
                        Comando.Transaction = myTrans
                        dfd1 = Comando.ExecuteReader()
                        While dfd1.Read()
                            _Idpdatfad = dfd1("Identity")
                        End While
                        dfd1.Close()

                        For Each _Detalle_Pobrefad As DataRow In _Tbl_Pobrefad.Rows

                            Dim _Idpdatfad_Pobre = _Detalle_Pobrefad.Item("IDPDATFAD")
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

                            Consulta_Sql = "INSERT INTO POBREFAD ( IDPDATFAD,OBRERO,FECHINIOB,HORAINIOB,FECHTEROB,HORATEROB,TIEMPOOB," &
                                           "KOJORNADA,TIEMPOOBHE) VALUES " & vbCrLf &
                                           "(22,'12675955',{d '2018-02-26'},14.30000,{d '2018-02-26'},14.30000,0.00000," &
                                           "'JORNADA_TIPO ',0.00000)"

                            If _Idpdatfad_Padre = _Idpdatfad_Pobre Then

                                Consulta_Sql = "INSERT INTO POBREFAD (IDPDATFAD,OBRERO,FECHINIOB,HORAINIOB,FECHTEROB,HORATEROB,TIEMPOOB," &
                                                                      "KOJORNADA,TIEMPOOBHE) VALUES " & vbCrLf &
                                                                      "(" & _Idpdatfad & ",'" & _Obrero & "','" & Format(_Fechiniob, "yyyyMMdd") &
                                                                      "'," & De_Num_a_Tx_01(_Horainiob, False, 5) & ",'" & Format(_Fechterob, "yyyyMMdd") &
                                                                      "'," & De_Num_a_Tx_01(_Horaterob, False, 5) & "," & De_Num_a_Tx_01(_Tiempoob, False, 5) & "," &
                                                                      "'" & _Kojornada & "'," & De_Num_a_Tx_01(_Tiempoobhe, False, 5) & ")"

                                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                                Comando.Transaction = myTrans
                                Comando.ExecuteNonQuery()
                                Exit For

                            End If

                        Next

                        Consulta_Sql = "SELECT TOP 1 REALIZADO FROM POTPR WITH ( NOLOCK )" &
                                       "WHERE NUMOT = '" & _Numot & "'" & Space(1) &
                                       "AND NREGOTL='" & _Nregotl & "'" & Space(1) &
                                       "AND OPERACION='" & _Operacion & "'"

                        Comando = New SqlCommand(Consulta_Sql, cn2)
                        Comando.Transaction = myTrans
                        Dim _Dr_Potpr = Comando.ExecuteReader()
                        Dim _Realizado As Double
                        While _Dr_Potpr.Read()
                            _Realizado = _Dr_Potpr.Item("REALIZADO")
                        End While
                        _Dr_Potpr.Close()

                        Consulta_Sql = "UPDATE POTPR SET REALIZADO=" & De_Num_a_Tx_01(_Realizado + _Realjor, False, 5) & vbCrLf &
                                       "WHERE NUMOT = '" & _Numot & "' AND NREGOTL = '" & _Nregotl & "'" & Space(1) &
                                       "AND OPERACION = '" & _Operacion & "'"

                        Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                        Contador += 1


                        Consulta_Sql = "Select Top 1 * From POTPR Where NUMOT = '" & _Numot & "' Order by ORDEN Desc"
                        Comando = New SqlCommand(Consulta_Sql, cn2)
                        Comando.Transaction = myTrans
                        Dim _Dr_RowPotpr = Comando.ExecuteReader()
                        Dim _Ult_Operacion As String
                        While _Dr_RowPotpr.Read()
                            _Ult_Operacion = _Dr_RowPotpr.Item("OPERACION")
                        End While
                        _Dr_RowPotpr.Close()


                        If Trim(_Ult_Operacion) = Trim(_Operacion) Then

                            '_Realizado = _Row_Potl.Item("REALIZADO")
                            Dim _Porentrar As Double = _Realjor + _Realizado

                            Consulta_Sql = "UPDATE POTL SET PORENTRAR = REALIZADO + " & _Realjor & ",INFORABODE='P'" & vbCrLf &
                                           "WHERE IDPOTL = " & _Idpotl

                            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        End If

                    End If

                Next



                'Dim _Tbl_Fabricacion As DataTable = Pro_Tbl_Fabricacion

                'Dim _Id_Maquinas As String = Generar_Filtro_IN(_Tbl_Fabricacion, "", "IdMaquina", False, False, "")

                'Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Set Idpdatfae = " & _Idpdatfae & "
                '                Where IdMaquina In " & _Id_Maquinas
                'Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                'Comando.Transaction = myTrans
                'Comando.ExecuteNonQuery()


                myTrans.Commit()
                SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            End If


            Return _Idpdatfae

        Catch ex As Exception

            _Error = ex.Message
            myTrans.Rollback()
            Return 0

        End Try

    End Function

End Class
