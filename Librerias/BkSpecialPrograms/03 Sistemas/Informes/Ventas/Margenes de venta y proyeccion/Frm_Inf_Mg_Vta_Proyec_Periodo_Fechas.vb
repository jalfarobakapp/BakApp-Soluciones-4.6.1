Imports DevComponents.DotNetBar

Public Class Frm_Inf_Mg_Vta_Proyec_Periodo_Fechas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Ds As DataSet

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Filtrar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Btn_Filtrar_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar.Click

        Sb_Ejecutar_Informe()

    End Sub

    Sub Sb_Ejecutar_Informe()

        Dim _Fecha_Desde As String = Format(Dtp_Fecha_Desde.Value, "yyyyMMdd")
        Dim _Fecha_Hasta As String = Format(Dtp_Fecha_Hasta.Value, "yyyyMMdd")

        Consulta_Sql = My.Resources.Recursos_Inf_MgProyecion.SQLQuery_Revision_Margenes_SeaGarden_Con_Mediana
        Consulta_Sql = Replace(Consulta_Sql, "#Fecha_Desde#", _Fecha_Desde)
        Consulta_Sql = Replace(Consulta_Sql, "#Fecha_Hasta#", _Fecha_Hasta)

        _Ds = _Sql.Fx_Get_DataSet(Consulta_Sql)

    End Sub

    Private Sub Frm_Inf_Mg_Vta_Proyec_Periodo_Fechas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class