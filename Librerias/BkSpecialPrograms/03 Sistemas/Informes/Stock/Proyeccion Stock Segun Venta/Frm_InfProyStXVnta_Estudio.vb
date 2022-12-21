Public Class Frm_InfProyStXVnta_Estudio

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Filtro_VistInf1 As New List(Of Filtro_VistInf1)
    Dim _NombreTablaPaso As String
    Dim _NombreTablaPasoInforme As String
    Dim _Tbl_Informe As DataTable

    Dim _TblBodVenta As DataTable
    Dim _Filtro_Bodegas_Est_Vta_Todas As Boolean

    Dim Cl_InfProyStXVnta As Cl_InfProyStXVnta

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub Frm_InfProyStXVnta_Estudio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Cl_InfProyStXVnta = New Cl_InfProyStXVnta

        _NombreTablaPaso = Cl_InfProyStXVnta.NombreTablaPaso
        _NombreTablaPasoInforme = Cl_InfProyStXVnta.NombreTablaPasoInforme
        _Filtro_Bodegas_Est_Vta_Todas = True

    End Sub

    Private Sub Btn_Bodega_Vta_Estudio_Click(sender As Object, e As EventArgs) Handles Btn_Bodega_Vta_Estudio.Click

        Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Bodegas, False)
        Fm.Pro_Tbl_Filtro = _TblBodVenta

        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then

            _TblBodVenta = Fm.Pro_Tbl_Filtro

            If Fm.Pro_Filtrar_Todo Then
                _Filtro_Bodegas_Est_Vta_Todas = True
            Else
                If (_TblBodVenta Is Nothing) Then
                    _Filtro_Bodegas_Est_Vta_Todas = True
                Else
                    _Filtro_Bodegas_Est_Vta_Todas = False
                End If
            End If

        End If
        Fm.Dispose()

    End Sub

    Private Sub Frm_InfProyStXVnta_Estudio_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        Consulta_sql = "Drop Table " & _NombreTablaPaso
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Drop Table " & _NombreTablaPasoInforme
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

    End Sub

    Private Sub Btn_Procesar_Informe_Click(sender As Object, e As EventArgs) Handles Btn_Procesar_Informe.Click

        Cl_InfProyStXVnta.Input_MesesEstudio = Input_MesesEstudio.Value
        Cl_InfProyStXVnta.Input_MesesProyeccion = Input_MesesProyeccion.Value
        Cl_InfProyStXVnta.TblBodVenta = _TblBodVenta
        Cl_InfProyStXVnta.Filtro_Bodegas_Est_Vta_Todas = _Filtro_Bodegas_Est_Vta_Todas
        Cl_InfProyStXVnta.Sb_Crear_Tabla_Paso()

        Dim Fm As New Frm_InfProyStXVnta
        Fm.Cl_InfProyStXVnta = Cl_InfProyStXVnta
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

End Class
