Public Class Cl_ImpMasiva

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Ls_ImpDocumentos As New List(Of ImpMasiva.ImpDocumentos)

    Public Sub New()

    End Sub

    Function Fx_llenar_ImpDocumento(_Idmaeedo As Integer) As ImpMasiva.ImpDocumentos

        Consulta_sql = "Select e.EMPRESA,e.IDMAEEDO,e.TIDO,e.NUDO,e.SUBTIDO,e.ENDO,e.SUENDO,Isnull(r.NOKOEN,'') As NOKOEN,Isnull(DEnt.Modalidad,'') As Modalidad" & vbCrLf &
                       "From MAEEDO e" & vbCrLf &
                       "Left Join MAEEN r On e.ENDO = r.KOEN And e.SUENDO = r.SUEN" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Docu_Ent DEnt On DEnt.Idmaeedo = e.IDMAEEDO" & vbCrLf &
                       "Where IDMAEEDO = " & _Idmaeedo

        Consulta_sql = "Select e.EMPRESA,e.IDMAEEDO,e.TIDO,e.NUDO,e.SUBTIDO,e.ENDO,e.SUENDO,Isnull(r.NOKOEN,'') As NOKOEN,Isnull(DEnt.Modalidad,'') As Modalidad,NombreFormato" & vbCrLf &
                        "From MAEEDO e" & vbCrLf &
                        "Left Join MAEEN r On e.ENDO = r.KOEN And e.SUENDO = r.SUEN" & vbCrLf &
                        "Left Join " & _Global_BaseBk & "Zw_Docu_Ent DEnt On DEnt.Idmaeedo = e.IDMAEEDO" & vbCrLf &
                        "Left Join " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad Fxm On Fxm.Modalidad = DEnt.Modalidad And Fxm.TipoDoc = e.TIDO And Fxm.Empresa = e.EMPRESA" & vbCrLf &
                        "Where IDMAEEDO = " & _Idmaeedo

        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _ImpDocumentos As New ImpMasiva.ImpDocumentos

        With _ImpDocumentos
            .Orden = Ls_ImpDocumentos.Count + 1
            .Idmaeedo = _Row.Item("IDMAEEDO")
            .Chk = False
            .Tido = _Row.Item("TIDO")
            .Subtido = _Row.Item("SUBTIDO")
            .Nudo = _Row.Item("NUDO")
            .Endo = _Row.Item("ENDO")
            .Suendo = _Row.Item("SUENDO")
            .Nokoen = _Row.Item("NOKOEN")
            .Empresa = _Row.Item("EMPRESA")
            .Modalidad = _Row.Item("Modalidad")
            .NombreFormato = _Row.Item("NombreFormato")
        End With

        Return _ImpDocumentos

    End Function

End Class

Namespace ImpMasiva
    Public Class ImpDocumentos
        Public Property Orden As Integer
        Public Property Idmaeedo As Integer
        Public Property Chk As Boolean
        Public Property Tido As String
        Public Property Subtido As String
        Public Property Nudo As String
        Public Property Endo As String
        Public Property Suendo As String
        Public Property Nokoen As String
        Public Property NombreFormato As String
        Public Property Impreso As Boolean
        Public Property Empresa As String
        Public Property Modalidad As String
    End Class

End Namespace
