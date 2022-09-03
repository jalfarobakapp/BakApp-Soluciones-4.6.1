Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Clas_Alerta_Trab_Sin_Cerrar

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Public Sub New()

    End Sub


    Function Fx_Tiene_Trabajos_Abiertos(_Codigoob As String) As Integer

        Dim _Fecha As String = FechaDelServidor.ToString("yyyyMMdd")

        Consulta_sql = "Select Count(*) As OtAbiertas
                        From " & _Global_BaseBk & "Zw_Pdp_MaquinaVsProductos Z1
                        Inner Join POTE ON Idpote=IDPOTE
                        Where Estado='EMQ' And POTE.ESTADO = 'V' And Fecha_Hora_Inicio < '" & _Fecha & "' And Obrero = '" & _Codigoob & "'"

        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            Return 0
        End If

        Fx_Tiene_Trabajos_Abiertos = _Row.Item("OtAbiertas")

    End Function

End Class
