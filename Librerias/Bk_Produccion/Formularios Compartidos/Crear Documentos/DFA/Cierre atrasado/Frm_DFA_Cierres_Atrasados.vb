Imports Funciones_BakApp
Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Public Class Frm_DFA_Cierres_Atrasados

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Obrero As DataRow

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_DFA_Cierres_Atrasados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Codigoob = _Row_Obrero.Item("CODIGOOB")

        Consulta_sql = "SELECT * FROM PDATFAE WHERE IDPDATFAE IN " & vbCrLf &
                       "(SELECT IDPDATFAE FROM PDATFAD WHERE IDPDATFAD IN" & Space(1) &
                       "(SELECT IDPDATFAD FROM POBREFAD WHERE OBRERO = '" & _Codigoob & "' AND FECHINI < '" & _Fecha & "'))" & vbCrLf &
                       "AND REQCONFIR = 1" & vbCrLf & vbCrLf &
                       "SELECT * FROM PDATFAE WHERE IDPDATFAE IN " & vbCrLf &
                       "(SELECT IDPDATFAE FROM PDATFAD WHERE IDPDATFAD IN" & Space(1) &
                       "(SELECT IDPDATFAD FROM POBREFAD WHERE OBRERO = '" & _Codigoob & "' AND CODMAQ = '" & _Codmaq & "' AND FECHINI = '" & _Fecha & "'))" & vbCrLf &
                       "AND REQCONFIR = 1" & vbCrLf & vbCrLf &
                       "SELECT * FROM PDATFAE WHERE IDPDATFAE IN " & vbCrLf &
                       "(SELECT IDPDATFAE FROM PDATFAD WHERE IDPDATFAD IN" & Space(1) &
                       "(SELECT IDPDATFAD FROM POBREFAD WHERE OBRERO = '" & _Codigoob & "' AND CODMAQ <> '" & _Codmaq & "' AND FECHINI = '" & _Fecha & "'))" & vbCrLf &
                       "AND REQCONFIR = 1" & vbCrLf & vbCrLf &
                       "SELECT (Select Top 1 FABRICAR From POTPR Where IDPOTPR = IDRST) as Fabricar" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "FROM PDATFAD WHERE IDPDATFAD IN (SELECT IDPDATFAD FROM POBREFAD WHERE CODMAQ = '" & _Codmaq & "')" & vbCrLf &
                       "AND IDPDATFAE IN (SELECT IDPDATFAE FROM PDATFAE WHERE REQCONFIR = 1)" & vbCrLf &
                       "Select ISNULL(Sum(Fabricar),0) As Fabricando From #Paso" & vbCrLf &
                       "Drop Table #Paso"

        Dim _Ds_TO As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

    End Sub

End Class