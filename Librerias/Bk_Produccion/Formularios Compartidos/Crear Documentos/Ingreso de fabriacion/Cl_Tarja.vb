Imports BkSpecialPrograms

Public Class Cl_Tarja

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property _Cl_Tarja_Ent As New Cl_Tarja_Ent.CPT_Tarja

    Public Sub New()



    End Sub

    Function Fx_Grabar_Tarja() As Cl_Tarja_Ent.Mensaje_Tarja

        Dim _Mensaje_Tarja As New Cl_Tarja_Ent.Mensaje_Tarja
        Dim _Id As Integer

        Try

            With _Cl_Tarja_Ent

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja (Idmaeddo,Nro_CPT,Codigo,CodAlternativo,Turno,Planta," &
                               "Formato,Lote,FechaElab,SacosXPallet,Analista,Observaciones)" & vbCrLf &
                               "Values (" & .Idmaeddo & ",'','" & .Codigo & "','" & .CodAlternativo & "','" & .Turno &
                               "','" & .Planta & "','" & .Formato & "','" & .Lote & "','" & .FechaElab &
                               "'," & .SacosXPallet & ",'" & .Analista & "','" & .Observaciones & "')"

            End With

            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id)

            If CBool(_Id) Then

                _Mensaje_Tarja.EsCorrecto = True

            End If

        Catch ex As Exception
            _Mensaje_Tarja.Mensaje = ex.Message
        End Try

        Return _Mensaje_Tarja

    End Function

End Class

Namespace Cl_Tarja_Ent

    Public Class CPT_Tarja

        Public Property Idmaeddo As Integer
        Public Property Nro_CPT As String
        Public Property Lote As String
        Public Property Codigo As String
        Public Property CodAlternativo As String
        Public Property Turno As String
        Public Property Planta As String
        Public Property Formato As Integer
        Public Property FechaElab As DateTime
        Public Property SacosXPallet As Integer
        Public Property Analista As String
        Public Property Observaciones As String

    End Class

    Public Class Mensaje_Tarja

        Public Property EsCorrecto As Boolean
        Public Property Mensaje As String

    End Class

End Namespace

