Public Class Frm_PreciosLC_InfUltCompras_Mt

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim Tbl1 As String = "Zw_TblPasoUltGRC" & FUNCIONARIO
    Dim Actualizo_Precio As String
    Dim UnidadSeleccionada
    Dim UnidadDeTransaccionActual

    Dim _Tbl_Lista_LC As DataTable
    Dim _Tbl_Lista_LC_Actualizados As DataTable

    Dim _Tbl_Grilla_Old As DataTable

    Dim _Fecha_Hoy As Date = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(GrillaProdActualizados, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_PreciosLC_InfUltCompras_Mt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DFechaInicio.Value = Date.Now 'Primerdiadelmes(Date.Now)
        DFechaTermino.Value = Date.Now 'ultimodiadelmes(Date.Now)

        'Ejecutar()
        'Sb_Actualizar_Grilla()

        Call TabControl1_SelectedIndexChanged(Nothing, Nothing)

        'AddHandler GrillaProdActualizados.CellFormatting, AddressOf Grilla_CellFormatting

        AddHandler Grilla.RowPostPaint, AddressOf Grilla_RowPostPaint
        AddHandler GrillaProdActualizados.RowPostPaint, AddressOf Grilla_RowPostPaint

    End Sub

#Region "FUNCIONES"

    Function ActualizarInforme(ByVal Redondeo As String)

        Dim Unidad, UD, UdPEdido As String

        If UnidadSeleccionada = True Then
            Unidad = "StockUd1" : UD = "UD1" : UdPEdido = "StockUd1Pedido"
            UnidadDeTransaccionActual = 1
        Else
            Unidad = "StockUd2" : UD = "UD2"
            UnidadDeTransaccionActual = 2 : UdPEdido = "StockUd2Pedido"
        End If

        Consulta_sql = "select * from " & Tbl1

        Consulta_sql = "SELECT dbo." & Tbl1 & ".Id, dbo." & Tbl1 & ".KOPRCT, dbo." & Tbl1 & ".NOKOPR, dbo." & Tbl1 & ".RLUDPR," & vbCrLf &
                       "dbo." & Tbl1 & ".CAPRCO2, dbo." & Tbl1 & ".UD02PR, dbo." & Tbl1 & ".PPPRNE, dbo.MAEPREM.PM," & vbCrLf &
                       "ROUND(ISNULL(dbo." & Tbl1 & ".PPPRNERE2, 0) / ISNULL(dbo." & Tbl1 & ".RLUDPR, 0), 3) AS Ult_Compra, ISNULL(dbo.Zw_ListaLC_ValPro.Mcosto, " & vbCrLf &
                       "0) AS Mcosto, dbo." & Tbl1 & ".TIDO, dbo." & Tbl1 & ".NUDO, dbo." & Tbl1 & ".FEEMLI, dbo." & Tbl1 & ".ENDO, " & vbCrLf &
                       "dbo." & Tbl1 & ".SUENDO, dbo." & Tbl1 & ".NOKOEN, dbo." & Tbl1 & ".SULIDO, dbo." & Tbl1 & ".BOSULIDO" & vbCrLf &
                       "FROM         dbo." & Tbl1 & " LEFT OUTER JOIN" & vbCrLf &
                       "dbo.Zw_ListaLC_ValPro ON dbo." & Tbl1 & ".KOPRCT = dbo.Zw_ListaLC_ValPro.Codigo LEFT OUTER JOIN" & vbCrLf &
                       "dbo.MAEPREM ON dbo." & Tbl1 & ".KOPRCT = dbo.MAEPREM.KOPR" & vbCrLf &
                       "where " & vbCrLf &
                       "dbo.Zw_ListaLC_ValPro.FechaModif <> (SELECT replace(convert(varchar, getdate(), 111), '/',''))" & vbCrLf &
                       "OR dbo.Zw_ListaLC_ValPro.FechaModif IS NULL"

        'Grilla.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        _Tbl_Grilla_Old = _Sql.Fx_Get_Tablas(Consulta_sql)
        GrillaProdActualizados.DataSource = _Tbl_Grilla_Old

        ''cast((1375.0*100/1462) as decimal(10,2)) as porcentaj


        'ActualizaLaGrilla(Grilla, tb, Consulta_sql, cn1)
        FormatoGrilla(GrillaProdActualizados, Redondeo)
        'FormatoGrilla(Grilla, Redondeo)

        ' ActualizarGrilla2()

    End Function

    Sub ActualizarGrilla2()

        Consulta_sql = "SELECT dbo." & Tbl1 & ".Id, dbo." & Tbl1 & ".KOPRCT, dbo." & Tbl1 & ".NOKOPR, dbo." & Tbl1 & ".RLUDPR," & vbCrLf &
                       "dbo." & Tbl1 & ".CAPRCO2, dbo." & Tbl1 & ".UD02PR, dbo." & Tbl1 & ".PPPRNE, dbo.MAEPREM.PM," & vbCrLf &
                       "ROUND(ISNULL(dbo." & Tbl1 & ".PPPRNE, 0) / ISNULL(dbo." & Tbl1 & ".RLUDPR, 0), 3) AS Ult_Compra, ISNULL(dbo.Zw_ListaLC_ValPro.Mcosto, " & vbCrLf &
                       "0) AS Mcosto, dbo." & Tbl1 & ".TIDO, dbo." & Tbl1 & ".NUDO, dbo." & Tbl1 & ".FEEMLI, dbo." & Tbl1 & ".ENDO, " & vbCrLf &
                       "dbo." & Tbl1 & ".SUENDO, dbo." & Tbl1 & ".NOKOEN, dbo." & Tbl1 & ".SULIDO, dbo." & Tbl1 & ".BOSULIDO," & vbCrLf &
                       "dbo.Zw_ListaLC_ValPro.FechaModif,isnull(convert(varchar, dbo.Zw_ListaLC_ValPro.HoraModif, 108) ,'00:00:00') as Hora" & vbCrLf &
                       "FROM  dbo." & Tbl1 & " LEFT OUTER JOIN" & vbCrLf &
                       "dbo.Zw_ListaLC_ValPro ON dbo." & Tbl1 & ".KOPRCT = dbo.Zw_ListaLC_ValPro.Codigo LEFT OUTER JOIN" & vbCrLf &
                       "dbo.MAEPREM ON dbo." & Tbl1 & ".KOPRCT = dbo.MAEPREM.KOPR" & vbCrLf &
                       "where " & vbCrLf &
                       "dbo.Zw_ListaLC_ValPro.FechaModif = (SELECT replace(convert(varchar, getdate(), 111), '/',''))"


        Dim FechaDesde As String = Format(DFechaInicio.Value, "yyyyMMdd")
        Dim FechaHasta As String = Format(DFechaTermino.Value, "yyyyMMdd")


        Consulta_sql = "SELECT Codigo,(Select top 1 NOKOPR from MAEPR where KOPR = TB.Codigo ) AS Descripcion," & vbCrLf &
                       "Mcosto,VproNeto,VproBruto,MgDigitado,ValDigitado,FechaModif,isnull(convert(varchar, HoraModif, 108) ,'00:00:00') as Hora " & vbCrLf &
                       "FROM Zw_ListaLC_ValPro as TB" & vbCrLf &
                       "WHERE FechaModif BETWEEN '" & FechaDesde & "' AND '" & FechaHasta & "'"

        Consulta_sql = My.Resources.Listado_de_productos_con_precios_actualizados_entre_fechas
        Consulta_sql = Replace(Consulta_sql, "#FechaInicio#", FechaDesde)
        Consulta_sql = Replace(Consulta_sql, "#FechaFin#", FechaHasta)


        With GrillaProdActualizados

            .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)


            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"

            .Columns("Descripcion").Width = 300
            .Columns("Descripcion").HeaderText = "Descripción"

            .Columns("Mcosto").Width = 70
            .Columns("Mcosto").HeaderText = "Mejor costo (Anterior)"
            .Columns("Mcosto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Mcosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("VproNeto").Width = 70
            .Columns("VproNeto").HeaderText = "Valor propuesto Neto"
            .Columns("VproNeto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VproNeto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("VproBruto").Width = 70
            .Columns("VproBruto").HeaderText = "Valor propuesto Bruto"
            .Columns("VproBruto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VproBruto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("MgDigitado").Width = 70
            .Columns("MgDigitado").HeaderText = "Margen propuesto"
            .Columns("MgDigitado").DefaultCellStyle.Format = "$ ###,##"
            .Columns("MgDigitado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("ValDigitado").Width = 70
            .Columns("ValDigitado").HeaderText = "Valor digitado"
            .Columns("ValDigitado").DefaultCellStyle.Format = "$ ###,##"
            .Columns("ValDigitado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("FechaModif").Width = 80
            .Columns("FechaModif").HeaderText = "Fecha Mod."

            .Columns("Hora").Width = 100
            .Columns("Hora").HeaderText = "Hora Mod."


            .Columns("Tido_UlRc").Width = 50
            .Columns("Tido_UlRc").HeaderText = "Tipo Doc. (Ult. recepción)"

            .Columns("Nudo_UlRc").Width = 80
            .Columns("Nudo_UlRc").HeaderText = "Número Doc. (Ult. recepción)"

            .Columns("Fecha_UlRc").Width = 80
            .Columns("Fecha_UlRc").HeaderText = "Fecha Doc. (Ult. recepción)"

            .Columns("dias").Width = 40
            .Columns("dias").HeaderText = "Días dif."

            'FormatoGrilla(GrillaProdActualizados, 3)

        End With

    End Sub

    Function EjecutarInformeEvaluacionCompras(ByVal FechaDesde As String,
                                              ByVal FechaHasta As String,
                                              ByVal ConsideraFechas As String,
                                              ByVal TablaPaso As String)

        Consulta_sql = "IF EXISTS (SELECT * FROM sysobjects WHERE name='Trae_UltGRCxProducto') BEGIN" & vbCrLf &
                       "DROP PROCEDURE Trae_UltGRCxProducto End"
        _Sql.Ej_consulta_IDU(Consulta_sql)


        Consulta_sql = My.Resources.Trae_UltimoDocumentoXproducto.ToString

        Consulta_sql = Replace(Consulta_sql, "@1Tbl", TablaPaso)
        Consulta_sql = Replace(Consulta_sql, "@2Tbl", TablaPaso)

        _Sql.Ej_consulta_IDU(Consulta_sql)

        Consulta_sql = "exec Trae_UltGRCxProducto '" & FechaDesde & "','" & FechaHasta &
                       "','" & ConsideraFechas & "'"
        _Sql.Ej_consulta_IDU(Consulta_sql)


        ActualizarInforme(3)


    End Function

    Function FormatoGrilla(ByVal Grilla As DataGridView,
                           ByVal VarDecimal As String)
        Try

            Dim FormatDecimal As String
            If VarDecimal = 0 Then FormatDecimal = "##,###0"
            If VarDecimal = 1 Then FormatDecimal = "##,#0.0"
            If VarDecimal = 2 Then FormatDecimal = "##,##0.00"
            If VarDecimal = 3 Then FormatDecimal = "##0.000"
            If VarDecimal = 4 Then FormatDecimal = "##,###0.0000"
            If VarDecimal = 5 Then FormatDecimal = "##,###0.00000"

            With Grilla

                OcultarEncabezadoGrilla(Grilla, True)

                '.DefaultCellStyle.Font = New Font("Tahoma", 8)
                '.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod

                .Columns("Id").Visible = False
                .Columns("ENDO").Visible = False
                .Columns("NOKOEN").Visible = False
                .Columns("BOSULIDO").Visible = False
                .Columns("SUENDO").Visible = False
                .Columns("SULIDO").Visible = False

                .Columns("TIDO").Width = 60
                .Columns("TIDO").HeaderText = "Tipo Doc."
                .Columns("TIDO").Visible = True

                .Columns("NUDO").Width = 100
                .Columns("NUDO").HeaderText = "Nro Doc."
                .Columns("NUDO").Visible = True

                .Columns("FEEMLI").Width = 100
                .Columns("FEEMLI").HeaderText = "Fecha Doc."
                .Columns("FEEMLI").Visible = True

                .Columns("KOPRCT").Width = 100
                .Columns("KOPRCT").HeaderText = "Código producto"
                .Columns("KOPRCT").Visible = True

                .Columns("NOKOPR").Width = 300
                .Columns("NOKOPR").HeaderText = "Descripción producto"
                .Columns("NOKOPR").Visible = True

                .Columns("UD02PR").Width = 60
                .Columns("UD02PR").HeaderText = "Ud"
                .Columns("UD02PR").Visible = True

                .Columns("PPPRNE").Width = 60
                .Columns("PPPRNE").HeaderText = "Precio en Doc."
                .Columns("PPPRNE").DefaultCellStyle.Format = "$ ###,##"
                .Columns("PPPRNE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("PPPRNE").Visible = True

                .Columns("Ult_Compra").Width = 100
                .Columns("Ult_Compra").HeaderText = "$ Ult. Compra (Valor futuro en prox. FCC)"
                .Columns("Ult_Compra").DefaultCellStyle.Format = "$ ###,##"
                .Columns("Ult_Compra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Ult_Compra").Visible = True

                .Columns("PM").Width = 60
                .Columns("PM").HeaderText = "$ P.M."
                .Columns("PM").DefaultCellStyle.Format = "$ ###,##"
                .Columns("PM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("PM").Visible = True

                .Columns("Mcosto").Width = 60
                .Columns("Mcosto").HeaderText = "Mejor Costo (Anterior)"
                .Columns("Mcosto").DefaultCellStyle.Format = "$ ###,##"
                .Columns("Mcosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Mcosto").Visible = True

                .Columns("CAPRCO2").Width = 60
                .Columns("CAPRCO2").HeaderText = "Cantidad"
                .Columns("CAPRCO2").DefaultCellStyle.Format = FormatDecimal
                .Columns("CAPRCO2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("CAPRCO2").Visible = True

                .Columns("RLUDPR").Width = 30
                .Columns("RLUDPR").HeaderText = "Rtu"
                .Columns("RLUDPR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("RLUDPR").Visible = True


            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Sub Sb_Actualizar_Grilla(Grilla As DataGridView, _Tbl As DataTable, _Condicion As String)

        Dim VarDecimal = 3

        Dim FormatDecimal As String

        If VarDecimal = 0 Then FormatDecimal = "##,###0"
        If VarDecimal = 1 Then FormatDecimal = "##,#0.0"
        If VarDecimal = 2 Then FormatDecimal = "##,##0.00"
        If VarDecimal = 3 Then FormatDecimal = "##0.000"
        If VarDecimal = 4 Then FormatDecimal = "##,###0.0000"
        If VarDecimal = 5 Then FormatDecimal = "##,###0.00000"

        Dim _Fecha_Desde As String = Format(DFechaInicio.Value, "yyyyMMdd")
        Dim _Fecha_Hasta As String = Format(DFechaTermino.Value, "yyyyMMdd")

        Consulta_sql = My.Resources.Recursos_Lista_LC.Ult_Compras_GRC
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Desde#", _Fecha_Desde)
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Hasta#", _Fecha_Hasta)
        Consulta_sql = Replace(Consulta_sql, "#Condicion#", _Condicion)


        _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("TIDO").Width = 60
            .Columns("TIDO").HeaderText = "Tipo Doc."
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUDO").Width = 100
            .Columns("NUDO").HeaderText = "Nro Doc."
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FECHA").Width = 100
            .Columns("FECHA").HeaderText = "Fecha Doc."
            .Columns("FECHA").Visible = True
            .Columns("FECHA").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOPRCT").Width = 100
            .Columns("KOPRCT").HeaderText = "Código producto"
            .Columns("KOPRCT").Visible = True
            .Columns("KOPRCT").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").Width = 300
            .Columns("NOKOPR").HeaderText = "Descripción producto"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UD02PR").Width = 60
            .Columns("UD02PR").HeaderText = "Ud"
            .Columns("UD02PR").Visible = True
            .Columns("UD02PR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PPPRNE").Width = 60
            .Columns("PPPRNE").HeaderText = "Precio en Doc."
            .Columns("PPPRNE").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PPPRNE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PPPRNE").Visible = True
            .Columns("PPPRNE").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Ult_Compra").Width = 100
            .Columns("Ult_Compra").HeaderText = "$ Ult. Compra (Valor futuro en prox. FCC)"
            .Columns("Ult_Compra").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Ult_Compra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Ult_Compra").Visible = True
            .Columns("Ult_Compra").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PM").Width = 60
            .Columns("PM").HeaderText = "$ P.M."
            .Columns("PM").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PM").Visible = True
            .Columns("PM").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Mcosto").Width = 60
            .Columns("Mcosto").HeaderText = "Mejor Costo (Anterior)"
            .Columns("Mcosto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Mcosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Mcosto").Visible = True
            .Columns("Mcosto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CAPRCO2").Width = 60
            .Columns("CAPRCO2").HeaderText = "Cantidad"
            .Columns("CAPRCO2").DefaultCellStyle.Format = FormatDecimal
            .Columns("CAPRCO2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPRCO2").Visible = True
            .Columns("CAPRCO2").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RLUDPR").Width = 30
            .Columns("RLUDPR").HeaderText = "Rtu"
            .Columns("RLUDPR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("RLUDPR").Visible = True
            .Columns("RLUDPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim CostoPM As Double
            Dim CostoUC As Double
            Dim Mcosto, McostoNew As Double
            'Dim _FechaModif As Date = FormatDateTime(_Fila.Cells("FechaModif").Value, DateFormat.ShortDate)

            CostoPM = (_Fila.Cells("PM").Value)
            CostoUC = (_Fila.Cells("PPUL01").Value)
            Mcosto = NuloPorNro(_Fila.Cells("MCosto").Value, 0)

            If CostoPM > CostoUC Then
                McostoNew = CostoPM
            ElseIf CostoPM < CostoUC Then
                McostoNew = CostoUC
            ElseIf CostoPM = CostoUC Then
                McostoNew = CostoUC
            End If

            If Math.Round(McostoNew, 0) > Math.Round(Mcosto, 0) Then
                _Fila.DefaultCellStyle.BackColor = Color.Red ' Rojo
                _Fila.DefaultCellStyle.ForeColor = Color.White ' Rojo
            Else
                _Fila.DefaultCellStyle.BackColor = Color.White 'Blanco
                _Fila.DefaultCellStyle.ForeColor = Color.Black 'Negro
            End If

            'If _FechaModif = _Fecha_Hoy Then
            '    '_Fila.DefaultCellStyle.BackColor = Color.LightGreen
            '    '_Fila.DefaultCellStyle.ForeColor = Color.Black
            'End If

        Next

    End Sub

    Private Function Ejecutar()

        Dim FechaDesde As String = Format(DFechaInicio.Value, "yyyyMMdd")
        Dim FechaHasta As String = Format(DFechaTermino.Value, "yyyyMMdd")

        EjecutarInformeEvaluacionCompras(FechaDesde, FechaHasta, "S", Tbl1)

    End Function

#End Region

    Private Sub Grilla_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)

        With sender

            Dim CostoPM As Double
            Dim CostoUC As Double
            Dim Mcosto, McostoNew As Double

            CostoPM = NuloPorNro(.Rows(e.RowIndex).Cells(7).Value, 0)
            CostoUC = NuloPorNro(.Rows(e.RowIndex).Cells(8).Value, 0)
            Mcosto = NuloPorNro(.Rows(e.RowIndex).Cells(9).Value, 0)

            Dim _Codigo As String = .Rows(e.RowIndex).Cells("KOPRCT").Value.ToString.Trim

            If CostoPM > CostoUC Then
                McostoNew = CostoPM
            ElseIf CostoPM < CostoUC Then
                McostoNew = CostoUC
            ElseIf CostoPM = CostoUC Then
                McostoNew = CostoUC
            End If

            If Math.Round(McostoNew, 0) > Math.Round(Mcosto, 0) Then
                .Rows.Item(e.RowIndex).DefaultCellStyle.BackColor = Color.Red ' Rojo
                .Rows.Item(e.RowIndex).DefaultCellStyle.ForeColor = Color.White ' Rojo
            Else
                .Rows.Item(e.RowIndex).DefaultCellStyle.BackColor = Color.White 'Blanco
                .Rows.Item(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black 'Negro
            End If

        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Me.Enabled = False

        Try

            Select Case _Cabeza

                Case "TIDO", "NUDO"

                    Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
                    Dim _Idmaeddo = _Fila.Cells("IDMAEDDO").Value

                    Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
                    Fm.Idrst = _Idmaeddo
                    Fm.ShowDialog(Me)
                    Fm.Dispose()

                Case Else

                    If Fx_Tiene_Permiso(Me, "Pre0002") Then

                        Dim _Codigo As String = _Fila.Cells("KOPRCT").Value.ToString.Trim

                        Dim Fm As New Frm_PreciosLC_Mt01
                        Fm.CargarProducto(_Codigo)
                        Fm.Txtcodigo.Text = _Codigo
                        Fm.Cerrar_Al_Grabar = True
                        Fm.ShowDialog(Me)

                        If Fm.Grabar Then
                            '_Fila.DefaultCellStyle.BackColor = Color.White
                            '_Fila.DefaultCellStyle.ForeColor = Color.Black
                            Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index)
                        End If

                        Fm.Dispose()

                    End If

            End Select

        Catch ex As Exception
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub GrillaProdActualizados_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaProdActualizados.CellDoubleClick

        Dim _Cabeza = Grilla.Columns(GrillaProdActualizados.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = GrillaProdActualizados.Rows(GrillaProdActualizados.CurrentRow.Index)

        Me.Enabled = False

        Try

            Select Case _Cabeza

                Case "TIDO", "NUDO"

                    Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
                    Dim _Idmaeddo = _Fila.Cells("IDMAEDDO").Value

                    Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
                    Fm.Idrst = _Idmaeddo
                    Fm.ShowDialog(Me)
                    Fm.Dispose()

                Case Else

                    If Fx_Tiene_Permiso(Me, "Pre0002") Then

                        Dim _Codigo As String = _Fila.Cells("KOPRCT").Value.ToString.Trim

                        Dim Fm As New Frm_PreciosLC_Mt01
                        Fm.CargarProducto(_Codigo)
                        Fm.Txtcodigo.Text = _Codigo
                        Fm.Cerrar_Al_Grabar = True
                        Fm.ShowDialog(Me)
                        Fm.Dispose()

                    End If

            End Select

        Catch ex As Exception
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        'Ejecutar()
        TabControl1.SelectedIndex = 0
        Call TabControl1_SelectedIndexChanged(Nothing, Nothing)
        'Sb_Actualizar_Grilla()
    End Sub


    Private Sub Grilla_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < sender.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If sender.RowHeadersWidth < CInt(size.Width + 20) Then
                sender.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "vb.net",
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedIndex = 0 Then
            Sb_Actualizar_Grilla(Grilla, _Tbl_Lista_LC, "Where FechaModif <> '" & Format(_Fecha_Hoy, "yyyyMMdd") & "' Or FechaModif Is Null")
        Else
            Sb_Actualizar_Grilla(GrillaProdActualizados, _Tbl_Lista_LC_Actualizados, "Where FechaModif = '" & Format(_Fecha_Hoy, "yyyyMMdd") & "'")
        End If

    End Sub

End Class