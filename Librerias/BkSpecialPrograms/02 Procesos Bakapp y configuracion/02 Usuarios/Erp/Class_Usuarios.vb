Public Class Class_Usuarios

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Row_Usuario As DataRow
    Dim _Kofu As String


    Public Property Pro_Row_Usuario As DataRow
        Get
            Return _Row_Usuario
        End Get
        Set(value As DataRow)
            _Row_Usuario = value
        End Set
    End Property

    Public Property Pro_Kofu As String
        Get
            Return _Kofu
        End Get
        Set(value As String)
            _Kofu = value
        End Set
    End Property

    Sub Sb_Crear_Usuario()

        Dim _Kofu
        Dim _Nokofu


        Consulta_Sql = "Insert Into TABFU () Values ()"

    End Sub

End Class
