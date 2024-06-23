'Imports Lib_Bakapp_VarClassFunc

Module Inv_parcial

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Sub ProductosContados()

        Try

            Consulta_sql = "SELECT Bodega,CodigoPr as Codigo,Descripcion,Rtu,CantidadUd1 as Cantidad," & vbCrLf &
                           "convert(varchar, FechaInv, 103) as Fecha, " & vbCrLf &
                           "HoraInv as Hora,case when Levantado = 0 then 'Pendiente' else 'Ajustado' End as Estado" & vbCrLf &
                           "FROM Zw_TmpInv_InvParcial" & vbCrLf &
                           "order by FechaInv,Orden"


            Dim tb = _Sql.Fx_Get_DataTable(Consulta_sql)

            If tb.Rows.Count > 0 Then
                'iniciamos el form y el reporte
                Dim form As New Frm_VerReportes
                Dim report As New ProdContados

                'le indicamos el datasource al report, que sera el recordset
                'que hemos llenado
                report.SetDataSource(tb)

                'le indicamos el reportsource al crviewer del segundo form
                'que sera el report que creamos
                report.SetParameterValue("RutEmpresa", RutEmpresa)
                report.SetParameterValue("RazonEmpresa", RazonEmpresa)
                Dim Bode As String
                Bode = _Sql.Fx_Trae_Dato("TABBO", "NOKOBO", "KOSU = '" & ModSucursal & "' AND KOBO = '" & ModBodega & "'")

                report.SetParameterValue("Sucursal", ModSucursal)
                report.SetParameterValue("Bodega", Bode)
                'report.SetParameterValue("FechaInv", Format(FechaInv.Value, "dd-MM-yyyy"))
                form.CrystalReportViewer1.ReportSource = report
                form.Show()

                form = Nothing
            Else
                MsgBox("No hay registros que mostrar", MsgBoxStyle.Critical, "Seleccionar registros")
            End If
            'ProdNoContados
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Sub ProductosNoInvConStockMenorACero()
        Dim Ocultar As String = ""

        Dim Pregunta As Integer
        Pregunta = MsgBox("¿Desea quitar los productos ocultos?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Informe")


        If Pregunta = MsgBoxResult.Yes Then
            Ocultar = "And dbo.MAEPR.ATPR =''"
        ElseIf Pregunta = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        Consulta_sql = "SELECT dbo.MAEPR.KOPR AS Codigo, dbo.MAEPR.NOKOPR as Descripcion," & vbCrLf & _
                       "ISNULL(dbo.MAEST.STFI1,0) as Stock,dbo.MAEPR.ATPR as Oculto" & vbCrLf & _
                       "FROM dbo.MAEST RIGHT OUTER JOIN dbo.TABBOPR ON dbo.MAEST.KOPR = dbo.TABBOPR.KOPR" & vbCrLf & _
                       "AND dbo.MAEST.EMPRESA = dbo.TABBOPR.EMPRESA AND dbo.MAEST.KOBO = dbo.TABBOPR.KOBO " & vbCrLf & _
                       "RIGHT OUTER JOIN dbo.MAEPR WITH (NOLOCK) ON dbo.TABBOPR.KOPR = dbo.MAEPR.KOPR " & vbCrLf & _
                       "WHERE (dbo.TABBOPR.EMPRESA = '" & ModEmpresa & "') AND (dbo.TABBOPR.KOSU = '" & ModSucursal & _
                       "') AND (dbo.TABBOPR.KOBO = '" & ModBodega & "')" & vbCrLf & _
                       "AND dbo.MAEPR.KOPR NOT IN (SELECT CodigoPr FROM Zw_TmpInv_InvParcial" & vbCrLf & _
                       "Where Empresa = '" & ModEmpresa & "' And Sucursal = '" & ModSucursal & _
                       "' And Bodega ='" & ModBodega & "')" & vbCrLf & _
                       "And dbo.MAEST.STFI1 <=0" & vbCrLf & _
                       Ocultar & vbCrLf & _
                       "Order by Stock Desc OPTION ( FAST 20 )"

        Dim tb = _Sql.Fx_Get_DataTable(Consulta_sql)

        If tb.Rows.Count > 0 Then
            MostrarInforme(tb)
        Else
            MsgBox("No hay datos que mostrar", MsgBoxStyle.Critical, "Informe")
        End If
    End Sub

    Sub ProductosInvConStockMenorACero()
        Dim Ocultar As String = ""

        Dim Pregunta As Integer
        Pregunta = MsgBox("¿Desea quitar los productos ocultos?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Informe")


        If Pregunta = MsgBoxResult.Yes Then
            Ocultar = "And dbo.MAEPR.ATPR =''"
        ElseIf Pregunta = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        Consulta_sql = "SELECT dbo.MAEPR.KOPR AS Codigo, dbo.MAEPR.NOKOPR as Descripcion," & vbCrLf & _
                       "ISNULL(dbo.MAEST.STFI1,0) as Stock,dbo.MAEPR.ATPR as Oculto" & vbCrLf & _
                       "FROM dbo.MAEST RIGHT OUTER JOIN dbo.TABBOPR ON dbo.MAEST.KOPR = dbo.TABBOPR.KOPR" & vbCrLf & _
                       "AND dbo.MAEST.EMPRESA = dbo.TABBOPR.EMPRESA AND dbo.MAEST.KOBO = dbo.TABBOPR.KOBO " & vbCrLf & _
                       "RIGHT OUTER JOIN dbo.MAEPR WITH (NOLOCK) ON dbo.TABBOPR.KOPR = dbo.MAEPR.KOPR " & vbCrLf & _
                       "WHERE (dbo.TABBOPR.EMPRESA = '" & ModEmpresa & "') AND (dbo.TABBOPR.KOSU = '" & ModSucursal & _
                       "') AND (dbo.TABBOPR.KOBO = '" & ModBodega & "')" & vbCrLf & _
                       "AND dbo.MAEPR.KOPR IN (SELECT CodigoPr FROM Zw_TmpInv_InvParcial" & vbCrLf & _
                       "Where Empresa = '" & ModEmpresa & "' And Sucursal = '" & ModSucursal & _
                       "' And Bodega ='" & ModBodega & "' And CantidadUd1 > 0)" & vbCrLf & _
                       "And dbo.MAEST.STFI1 <=0" & vbCrLf & _
                       Ocultar & vbCrLf & _
                       "Order by dbo.MAEPR.KOPR OPTION ( FAST 20 )"

        Dim tb = _Sql.Fx_Get_DataTable(Consulta_sql)

        If tb.Rows.Count > 0 Then
            MostrarInforme(tb)
        Else
            MsgBox("No hay datos que mostrar", MsgBoxStyle.Critical, "Informe")
        End If
    End Sub

    Sub MostrarInforme(ByVal tb As DataTable)
        Try
            If tb.Rows.Count > 0 Then
                'iniciamos el form y el reporte
                Dim form As New Frm_VerReportes
                Dim report As New ProdNoContados

                'le indicamos el datasource al report, que sera el recordset
                'que hemos llenado
                report.SetDataSource(tb)

                'le indicamos el reportsource al crviewer del segundo form
                'que sera el report que creamos
                report.SetParameterValue("RutEmpresa", RutEmpresa)
                report.SetParameterValue("RazonEmpresa", RazonEmpresa)
                Dim Bode As String
                Bode = _Sql.Fx_Trae_Dato("TABBO", "NOKOBO", "KOSU = '" & ModSucursal & "' AND KOBO = '" & ModBodega & "'")

                report.SetParameterValue("Sucursal", ModSucursal)
                report.SetParameterValue("Bodega", Bode)
                'report.SetParameterValue("FechaInv", Format(FechaInv.Value, "dd-MM-yyyy"))
                form.CrystalReportViewer1.ReportSource = report
                form.Show()

                form = Nothing
            Else
                MsgBox("No hay registros que mostrar", MsgBoxStyle.Critical, "Seleccionar registros")
            End If
            'ProdNoContados
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub


    Sub ProductosNocontados()
        Dim Ocultar As String = ""

        Dim Pregunta As Integer
        Pregunta = MsgBox("¿Desea quitar los productos ocultos?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Informe")


        If Pregunta = MsgBoxResult.Yes Then
            Ocultar = "And dbo.MAEPR.ATPR =''"
        ElseIf Pregunta = MsgBoxResult.Cancel Then
            Exit Sub
        End If


        Consulta_sql = "SELECT dbo.MAEPR.KOPR AS Codigo, dbo.MAEPR.NOKOPR as Descripcion," & vbCrLf & _
                       "ISNULL(dbo.MAEST.STFI1,0) as Stock,dbo.MAEPR.ATPR as Oculto" & vbCrLf & _
                       "FROM dbo.MAEST RIGHT OUTER JOIN dbo.TABBOPR ON dbo.MAEST.KOPR = dbo.TABBOPR.KOPR" & vbCrLf & _
                       "AND dbo.MAEST.EMPRESA = dbo.TABBOPR.EMPRESA AND dbo.MAEST.KOBO = dbo.TABBOPR.KOBO " & vbCrLf & _
                       "RIGHT OUTER JOIN dbo.MAEPR WITH (NOLOCK) ON dbo.TABBOPR.KOPR = dbo.MAEPR.KOPR " & vbCrLf & _
                       "WHERE (dbo.TABBOPR.EMPRESA = '" & ModEmpresa & "') AND (dbo.TABBOPR.KOSU = '" & ModSucursal & _
                       "') AND (dbo.TABBOPR.KOBO = '" & ModBodega & "')" & vbCrLf & _
                       "AND dbo.MAEPR.KOPR NOT IN (SELECT CodigoPr FROM Zw_TmpInv_InvParcial" & vbCrLf & _
                       "Where Empresa = '" & ModEmpresa & "' And Sucursal = '" & ModSucursal & _
                       "' And Bodega ='" & ModBodega & "')" & vbCrLf & _
                       Ocultar & vbCrLf & _
                       "Order by dbo.MAEPR.KOPR OPTION ( FAST 20 )"

        Dim tb = _Sql.Fx_Get_DataTable(Consulta_sql)

        If tb.Rows.Count > 0 Then
            MostrarInforme(tb)
        Else
            MsgBox("No hay datos que mostrar", MsgBoxStyle.Critical, "Informe")
        End If
    End Sub

End Module
