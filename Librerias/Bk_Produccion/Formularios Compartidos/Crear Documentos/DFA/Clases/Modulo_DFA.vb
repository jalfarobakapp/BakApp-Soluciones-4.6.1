Imports BkSpecialPrograms

Module Modulo_DFA


    Function Fx_Siguiente_Nro_DFA() As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_sql As String

        Consulta_sql = "SELECT Top 1 * FROM PDATFAE WITH ( NOLOCK )  ORDER BY NUMDF DESC"
        Dim _Row_DFA As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
        Dim _Numero As String

        If Not IsNothing(_Row_DFA) Then
            _Numero = _Row_DFA.Item("NUMDF")
        Else
            _Numero = "0000000000"
        End If

        Dim _ProxNumero As String = Fx_Proximo_NroDocumento(_Numero, 10)

        Return _ProxNumero

    End Function


    Function Fx_Jornada(ByVal _Kojornada As String, ByVal _Fecha As Date) As DataRow

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_sql As String

        Dim _Dia_Semana As Integer

        Select Case _Fecha.DayOfWeek
            Case DayOfWeek.Monday
                _Dia_Semana = 1
            Case DayOfWeek.Tuesday
                _Dia_Semana = 2
            Case DayOfWeek.Wednesday
                _Dia_Semana = 3
            Case DayOfWeek.Thursday
                _Dia_Semana = 4
            Case DayOfWeek.Friday
                _Dia_Semana = 5
            Case DayOfWeek.Saturday
                _Dia_Semana = 6
            Case DayOfWeek.Sunday
                _Dia_Semana = 7
        End Select

        Consulta_sql = "SELECT KOJORNADA,DIASEMANA,HIJOR01,HTJOR01,HIJOR02,HTJOR02" & vbCrLf & _
                       "FROM PJORTRAD" & vbCrLf & _
                       "Where KOJORNADA = '" & _Kojornada & "' And DIASEMANA = " & _Dia_Semana
        Dim _Row_Jornada As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Return _Row_Jornada

    End Function

End Module
