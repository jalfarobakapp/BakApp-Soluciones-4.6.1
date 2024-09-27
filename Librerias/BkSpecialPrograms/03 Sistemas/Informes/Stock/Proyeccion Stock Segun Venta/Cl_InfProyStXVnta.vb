Public Class Cl_InfProyStXVnta

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property NombreTablaPaso As String
    Public Property NombreTablaPasoInforme As String
    Public Property Input_MesesProyeccion As Integer
    Public Property Input_MesesEstudio As Integer
    Public Property Filtro_Bodegas_Est_Vta_Todas As Boolean
    Public Property TblBodVenta As DataTable

    Public Sub New()

        Dim _Rd As New Random

        NombreTablaPaso = "TblPs" & FUNCIONARIO & _Rd.Next(100, 999)
        NombreTablaPasoInforme = "TblPsInf" & FUNCIONARIO & _Rd.Next(100, 999)

        Consulta_sql = "Select Distinct TABLE_NAME From INFORMATION_SCHEMA.COLUMNS Where TABLE_NAME Like 'TblPs" & FUNCIONARIO & "%'"
        Dim _Tblspaso As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
        Consulta_sql = String.Empty

        For Each _Fila As DataRow In _Tblspaso.Rows
            Consulta_sql += "Drop Table " & _Fila.Item("TABLE_NAME") & vbCrLf
        Next

        Consulta_sql = "Select Distinct TABLE_NAME From INFORMATION_SCHEMA.COLUMNS Where TABLE_NAME Like 'TblPsInf" & FUNCIONARIO & "%'"
        _Tblspaso = _Sql.Fx_Get_DataTable(Consulta_sql)
        Consulta_sql = String.Empty

        For Each _Fila As DataRow In _Tblspaso.Rows
            Consulta_sql += "Drop Table " & _Fila.Item("TABLE_NAME") & vbCrLf
        Next

        If Not String.IsNullOrEmpty(Consulta_sql) Then
            _Sql.Ej_consulta_IDU(Consulta_sql, False)
        End If
        Consulta_sql = String.Empty

    End Sub

    Sub Sb_Crear_Tabla_Paso()

        Dim Fm_Espera As New Frm_Form_Esperar
        Fm_Espera.BarraCircular.IsRunning = True
        Fm_Espera.Show()

        Consulta_sql = "Drop Table " & NombreTablaPaso
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Drop Table " & NombreTablaPasoInforme
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = My.Resources.Recursos_InfProyStXVnta.SQLQuery_Crear_Tabla_Paso_InfStockProyecVnta
        Consulta_sql = Replace(Consulta_sql, "#Global_BaseBk#", _Global_BaseBk)
        Consulta_sql = Replace(Consulta_sql, "#MesesProyeccion#", Input_MesesProyeccion)
        Consulta_sql = Replace(Consulta_sql, "#MesesEstudio#", Input_MesesEstudio)
        Consulta_sql = Replace(Consulta_sql, "#TblPs#", NombreTablaPaso)
        Consulta_sql = Replace(Consulta_sql, "#Tbl2Ps#", NombreTablaPasoInforme)
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", ModSucursal)

        Dim _Filtro_Bodega As String

        If Filtro_Bodegas_Est_Vta_Todas Then
            _Filtro_Bodega = String.Empty
        Else
            _Filtro_Bodega = Generar_Filtro_IN(TblBodVenta, "Chk", "Codigo", False, True, "'")
            _Filtro_Bodega = "And Ddo.EMPRESA+Ddo.SULIDO+Ddo.BOSULIDO In " & _Filtro_Bodega
        End If

        Consulta_sql = Replace(Consulta_sql, "#FiltroBodegas#", _Filtro_Bodega)

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Fm_Espera.Dispose()

    End Sub

End Class
