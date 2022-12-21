Public Class Cl_RevVersion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

    End Sub

    Function Fx_RevisarEstructuraDeDatos(_Version As String) As Boolean

        Select Case _Version

            Case "3.4.4.16"

                ' Revisar existecia de nuevas tablas
                If Not _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Conceptos") Then Return False

                ' Revisar existencia de nuevos campos
                If Not _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Configuracion", "RecepXMLCmp_MarcaAgua") Then Return False

        End Select

        Return True

    End Function

End Class
