'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Class_Informe_Analisis_Recepcion_Vs_Despacho

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Informe_Analisis As DataTable
    Dim _Tbl_Informe_Prox_Recepciones As DataTable
    Dim _Tbl_Informe_Comp_No_Despachados As DataTable

    Dim _Tabla_Paso_Ppr_VS_Cnd As String = _Global_BaseBk & "Tbl_Paso" & FUNCIONARIO & "_Ppr_VS_Cnd"  '#Tabla_Paso#

    Dim _Tabla_Paso_Prox_Recep, _
        _Tabla_Paso_Comp_No_Desp As String

    Dim _Informe_Generado As Boolean

    Public ReadOnly Property Pro_Tabla_Paso_Ppr_VS_Cnd()
        Get
            Return _Tabla_Paso_Ppr_VS_Cnd
        End Get
    End Property

    Public ReadOnly Property Pro_Tabla_Paso_Prox_Recep()
        Get
            Return _Tabla_Paso_Prox_Recep
        End Get
    End Property

    Public ReadOnly Property Pro_Tabla_Paso_Comp_No_Desp()
        Get
            Return _Tabla_Paso_Comp_No_Desp
        End Get
    End Property

    Public ReadOnly Property Pro_Informe_Generado() As Boolean
        Get
            Return _Informe_Generado
        End Get
    End Property

    Sub Sb_Generar_Reporte(ByVal _Formulario As Form, _
                           ByVal _Unidad As Integer)

        Dim _Filtro_Doc_Recepcion, _Filtro_Doc_Despacho As String
        Dim _Informe_Generado As Boolean

        Dim Fm_Ipr As New Frm_Informe_Proximas_Recepiones
        Fm_Ipr.Pro_Informe_Analisis = True
        Fm_Ipr.ShowDialog(_Formulario)
        _Tabla_Paso_Prox_Recep = Fm_Ipr.Pro_Nombre_Tabla_Paso
        _Filtro_Doc_Recepcion = Fm_Ipr.Pro_Filtro_Documentos
        _Informe_Generado = Fm_Ipr.Pro_Informe_Generado
        Fm_Ipr.Dispose()

        If Not _Informe_Generado Then
            MessageBoxEx.Show(_Formulario, "Acción cancelada por el usuario", "Cancelar", MessageBoxButtons.OK, _
                              MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim Fm_Icnd As New Frm_Informe_Compr_No_Despachados
        Fm_Icnd.Pro_Informe_Analisis = True
        Fm_Icnd.ShowDialog(_Formulario)
        _Tabla_Paso_Comp_No_Desp = Fm_Icnd.Pro_Nombre_Tabla_Paso
        _Filtro_Doc_Despacho = Fm_Icnd.Pro_Filtro_Documentos
        _Informe_Generado = Fm_Icnd.Pro_Informe_Generado
        Fm_Icnd.Dispose()

        If Not _Informe_Generado Then
            MessageBoxEx.Show(_Formulario, "Acción cancelada por el usuario", "Cancelar", MessageBoxButtons.OK, _
                              MessageBoxIcon.Stop)
            Exit Sub
        End If

        Consulta_sql = "Drop Table " & _Tabla_Paso_Ppr_VS_Cnd
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = My.Resources.Recursos_Proximas_Recepciones.SQLQuery_Informe_Analisis_Pendientes_Recibir_VS_Despacho
        Consulta_sql = Replace(Consulta_sql, "#Base_BakApp#", Replace(_Global_BaseBk, ".dbo.", ""))
        Consulta_sql = Replace(Consulta_sql, "#Ud#", _Unidad)
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso_Ppr_VS_Cnd#", _Tabla_Paso_Ppr_VS_Cnd)
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso_Ppr#", _Tabla_Paso_Prox_Recep)
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso_Cnd#", _Tabla_Paso_Comp_No_Desp)

        Consulta_sql = Replace(Consulta_sql, _Global_BaseBk, "")


        Dim _Ds As New DataSet

        _Ds = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Tbl_Informe_Analisis = _Ds.Tables(0)
        '_Tbl_Informe_Prox_Recepciones = _Ds.Tables(1)
        '_Tbl_Informe_Comp_No_Despachados = _Ds.Tables(2)

        _Informe_Generado = CBool(_Tbl_Informe_Analisis.Rows.Count)

        If _Informe_Generado Then

            'Dim _Unidad
            'Dim _Tabla_Paso_Comp_No_Desp = _Analisis.Pro_Tabla_Paso_Comp_No_Desp
            'Dim _Tabla_Paso_Ppr_VS_Cnd = _Analisis.Pro_Tabla_Paso_Ppr_VS_Cnd
            'Dim _Tabla_Paso_Prox_Recep = _Analisis.Pro_Tabla_Paso_Prox_Recep

            Consulta_sql = "Update " & _Tabla_Paso_Ppr_VS_Cnd & vbCrLf & _
                           "Set STK_FIS_BOD = Isnull((Select Sum(STFI" & _Unidad & ") From MAEST Where KOPR = KOPRCT_),0)"
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            Dim Fm_Vs As New Frm_Informe_Prox_Recep_VS_Comp_No_Desp(_Tabla_Paso_Ppr_VS_Cnd, _
                                                                    _Tabla_Paso_Prox_Recep, _
                                                                    _Filtro_Doc_Recepcion, _
                                                                    _Tabla_Paso_Comp_No_Desp, _
                                                                    _Filtro_Doc_Despacho, _
                                                                    _Unidad)
            Fm_Vs.Text = "Informe de Recepciones VS Despachos"
            Fm_Vs.Sb_Actualizar_Grillas()
            Fm_Vs.ShowDialog(_Formulario)
            Fm_Icnd.Dispose()

        Else

            MessageBoxEx.Show(_Formulario, "No existe información", "Informe Recepción VS Despacho", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        Consulta_sql = "Drop Table " & _Tabla_Paso_Ppr_VS_Cnd & vbCrLf & _
                       "Drop Table " & _Tabla_Paso_Prox_Recep & vbCrLf & _
                       "Drop Table " & _Tabla_Paso_Comp_No_Desp
        _Sql.Ej_consulta_IDU(Consulta_sql, False)


        'select * from #INF004 -- INFORME ANALISIS
        'Select * From #Tabla_Paso_Ppr# -- INFORME PROXIMAS RECEPCIONES
        'Select * From #Tabla_Paso_Cnd# -- INFORME COMPROMISOS NO DESPACHADOS

    End Sub

End Class
