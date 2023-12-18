Imports BkSpecialPrograms

Public Class Cl_Tarja

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property _Cl_Tarja_Ent As New Cl_Tarja_Ent.CPT_Tarja

    Public Sub New()

        _Cl_Tarja_Ent.Empresa = ModEmpresa

    End Sub

    Function Fx_Grabar_Tarja() As Cl_Tarja_Ent.Mensaje_Tarja

        Dim _Mensaje_Tarja As New Cl_Tarja_Ent.Mensaje_Tarja

        Try

            With _Cl_Tarja_Ent

                .Nro_CPT = Fx_NvoNro_CPT()

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja (Empresa,Idmaeddo,Nro_CPT,Codigo,CodAlternativo,CodAlternativo_Pallet,Turno,Planta," &
                               "Udm,Formato,Lote,FechaElab,SacosXPallet,Analista,Observaciones,Tipo,CantidadTipo,CantidadFab)" & vbCrLf &
                               "Values ('" & .Empresa & "'," & .Idmaeddo & ",'" & .Nro_CPT & "','" & .Codigo & "','" & .CodAlternativo & "','" & .CodAlternativo_Pallet & "','" & .Turno &
                               "','" & .Planta & "','" & .Udm & "','" & .Formato & "','" & .Lote & "','" & .FechaElab &
                               "'," & .SacosXPallet & ",'" & .Analista & "','" & .Observaciones.Replace("'", "''") &
                               "','" & .Tipo &
                               "'," & De_Num_a_Tx_01(.CantidadTipo, False, 5) &
                               "," & De_Num_a_Tx_01(.CantidadFab, False, 5) & ")"

            End With

            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                _Mensaje_Tarja.EsCorrecto = True
            Else
                Throw New System.Exception(_Sql.Pro_Error)
            End If

        Catch ex As Exception
            _Mensaje_Tarja.Mensaje = ex.Message
        End Try

        Return _Mensaje_Tarja

    End Function

    Function Fx_NvoNro_CPT() As String

        Dim _Nro_CPT As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _TblPaso = _Sql.Fx_Get_Tablas("Select Max(Nro_CPT) As Numero From " & _Global_BaseBk & "Zw_Pdp_CPT_Tarja")

        Dim _Ult_Nro_OT As String = NuloPorNro(_TblPaso.Rows(0).Item("Numero"), "")

        If String.IsNullOrEmpty(Trim(_Ult_Nro_OT)) Then
            _Ult_Nro_OT = "0000000000"
        End If

        _Nro_CPT = Fx_Proximo_NroDocumento(_Ult_Nro_OT, 10)

        Return _Nro_CPT

    End Function

End Class

Namespace Cl_Tarja_Ent

    Public Class CPT_Tarja

        Public Property Idmaeddo As Integer
        Public Property Empresa As String
        Public Property Nro_CPT As String
        Public Property Lote As String
        Public Property Codigo As String
        Public Property CodAlternativo As String
        Public Property CodAlternativo_Pallet As String
        Public Property Turno As String
        Public Property Planta As String
        Public Property Udm As String
        Public Property Formato As Integer
        Public Property FechaElab As DateTime
        Public Property SacosXPallet As Integer
        Public Property Analista As String
        Public Property Observaciones As String
        Public Property Tipo As String
        Public Property CantidadTipo As Double
        Public Property CantidadFab As Double

    End Class

    Public Class Mensaje_Tarja

        Public Property EsCorrecto As Boolean
        Public Property Mensaje As String

    End Class

End Namespace

