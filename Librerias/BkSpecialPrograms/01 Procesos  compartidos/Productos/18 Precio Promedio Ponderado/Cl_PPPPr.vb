Imports DevComponents.DotNetBar.Controls

Public Class Cl_PPPPr

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblDetalleDocs As DataTable
    Dim _Pm As Double
    Dim _Cancelar As Boolean

    Public Property TblDetalleDocs As DataTable
        Get
            Return _TblDetalleDocs
        End Get
        Set(value As DataTable)
            _TblDetalleDocs = value
        End Set
    End Property

    Public Property Pm As Double
        Get
            Return _Pm
        End Get
        Set(value As Double)
            _Pm = value
        End Set
    End Property

    Public Property Cancelar As Boolean
        Get
            Return _Cancelar
        End Get
        Set(value As Boolean)
            _Cancelar = value
        End Set
    End Property

    Public Sub New()

    End Sub

    ''' <summary>
    ''' Recalcula el Precio Promedio Ponderado por cada producto revisando
    ''' cada movimiento desde una fecha en adelante
    ''' </summary>
    ''' <param name="_Codigo"></param>Código del producto a estudiar
    ''' <param name="_FechaTope"></param>Fecha de tope para la revisión del PPP
    ''' <param name="ProgressBarX1"></param>Barra de progreso, si no hay dejar Nothing
    ''' <returns></returns>
    Function Fx_RecalcularPPPxPR(_Codigo As String,
                                 _FechaTope As DateTime,
                                 _ProgressBarX1 As ProgressBarX) As Boolean

        Dim _Fechinippp As DateTime

        Try
            _Fechinippp = _Global_Row_Configp.Item("FECHINIPPP")
        Catch ex As Exception
            _Fechinippp = _FechaTope
        End Try

        '_Fechinippp = _FechaTope

        Consulta_sql = "Select MAEPREM.PMIN,MAEPREM.PM,MAEPREM.FEPM,Cast('" & Format(_Fechinippp, "yyyyMMdd") & "' As Datetime) As FICPPP,0 As Col5,MAEPR.KOPR,MAEPR.NOKOPR,MAEPR.UD01PR,MAEPR.UD02PR,MAEPR.KOPRRA,MAEPR.KOPRTE,
		                MAEPR.FMPR,MAEPR.PFPR,MAEPR.HFPR,MAEPR.MRPR,RUPR,MAEPR.RLUD  
	                    From MAEPR WITH ( NOLOCK )  
				            INNER JOIN MAEPREM ON MAEPREM.KOPR=MAEPR.KOPR AND MAEPREM.EMPRESA='" & ModEmpresa & "'  
	                    WHERE MAEPR.TIPR='FPN' And MAEPR.KOPR = '" & _Codigo & "'"
        Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Consulta_sql = "Select Top 1 * From MAEDDO Where KOPRCT = '" & _Codigo & "' And FEEMLI < '" & Format("yyyyMMdd", _FechaTope) & "' And PPPRPM <> 0 Order By FEEMLI Desc"
        Dim _RowUltDoc As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_RowUltDoc) Then
            _Pm = 0
        Else
            _Pm = _RowUltDoc.Item("PPPRPM")
        End If

        If Not IsNothing(_ProgressBarX1) Then
            _ProgressBarX1.Text = "Analizando movimientos del producto..."
            Application.DoEvents()
        End If

        _TblDetalleDocs = Fx_DetalleDocumentos(_Codigo, _Fechinippp)

        Dim _Fecha_Max As Date = DateAdd(DateInterval.Year, 1, FechaDelServidor)

        Dim _Stock_Fi(1) As Double
        Dim _Stfi1, _Stfi2 As Double      ' STOCK FISICO

        Dim _Stock_Trans(1) As Double
        Dim _Sttr1, _Sttr2 As Double      ' STOCK EN TRANSITO

        Consulta_sql = "Select * From TABBO"
        Dim _TblBodegas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        _Fecha_Max = DateAdd(DateInterval.Day, -1, _Fechinippp)

        _Stfi1 = 0 : _Stfi2 = 0
        _Sttr1 = 0 : _Sttr2 = 0

        If Not IsNothing(_ProgressBarX1) Then
            _ProgressBarX1.Maximum = _TblBodegas.Rows.Count
            _ProgressBarX1.Value = 0
        End If

        For Each _FlBod As DataRow In _TblBodegas.Rows

            Application.DoEvents()

            Dim _Emp = _FlBod.Item("EMPRESA")
            Dim _Suc = _FlBod.Item("KOSU").ToString.Trim
            Dim _Bod = _FlBod.Item("KOBO").ToString.Trim
            Dim _Bodega = _FlBod.Item("NOKOBO").ToString.Trim

            If Not IsNothing(_ProgressBarX1) Then
                _ProgressBarX1.Value += 1
                _ProgressBarX1.Text = "Revisando Movimientos " & FormatNumber(_ProgressBarX1.Value, 0) & " de " & FormatNumber(_TblBodegas.Rows.Count, 0) & " Suc: " & _Suc & " bodega " & _Bod & " - " & _Bodega & " - "
            End If

            'STOCK FISICO ************** STFI1
            Consulta_sql = My.Resources._SQLquery.Consolidacion_Stock_Fisico_X_producto
            _Stock_Fi = Stock_A_Una_Fecha_X_Producto(_RowProducto, _Emp, _Suc, _Bod, Consulta_sql, _Fecha_Max)

            _Stfi1 += _Stock_Fi(0) '- _CantidadUd1
            _Stfi2 += _Stock_Fi(1) '- _CantidadUd2

            'STOCK EN TRANSITO *************** STTR1
            Consulta_sql = My.Resources._SQLquery.Consolidacion_Stock_En_Transito
            _Stock_Trans = Stock_A_Una_Fecha_X_Producto(_RowProducto, _Emp, _Suc, _Bod, Consulta_sql, _Fecha_Max)

            _Sttr1 += _Stock_Trans(0) '- _CantidadUd1
            _Sttr2 += _Stock_Trans(1) '- _CantidadUd2

        Next

        If Not IsNothing(_ProgressBarX1) Then
            _ProgressBarX1.Value = 0
            _ProgressBarX1.Text = String.Empty
        End If

        Dim _Total_Stfi_x_Pm As Double = _Pm * (_Stfi1 + _Sttr1)
        Dim _Sum_Stock As Double = _Stfi1 + _Sttr1
        Dim _UltPm As Double = _Pm

        If Not IsNothing(_ProgressBarX1) Then
            _ProgressBarX1.Maximum = _TblDetalleDocs.Rows.Count
            _ProgressBarX1.Value = 0
        End If

        For Each _Fila As DataRow In _TblDetalleDocs.Rows

            Dim _Tido As String = _Fila.Item("TIDO")
            Dim _Nudo As String = _Fila.Item("NUDO")
            Dim _Subtido As String = _Fila.Item("SUBTIDO")
            Dim _Tidopa As String = _Fila.Item("TIDOPA").ToString.Trim
            Dim _Lincondesp As Boolean = _Fila.Item("LINCONDESP")
            Dim _Caprco1 As Double = _Fila.Item("CAPRCO1")
            Dim _Ppprnere1 As Double = _Fila.Item("PPPRNERE1")
            Dim _Vaneli As Double = _Fila.Item("VANELI")

            Dim _VaneliCalc As Double = Math.Round(_Caprco1 * _Ppprnere1, 0)

            If _Tido = "GDD" Or _Tido = "GDI" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDV" Or (_Lincondesp And (_Tido = "NCC" Or _Tido = "FCV" Or _Tido = "BLV")) Then
                _Caprco1 = _Caprco1 * -1
            End If

            If _Tido = "OCC" Or _Tido = "NVI" Or _Tido = "COV" Or _Tido = "NVV" Then
                _Caprco1 = 0
            End If

            'If Not _Lincondesp And (_Tido = "NCC" Or _Tido = "FCV" Or _Tido = "BLV" Or _Tido = "FCC") Then
            '    _Caprco1 = 0
            'End If

            If Not _Lincondesp And (_Tido = "FCV" Or _Tido = "BLV") Then
                _Caprco1 = 0
            End If

            'If _Nudo = "0038349525" Then
            '    Dim ssas = 0
            'End If

            Dim _UltPmXStockActual As Double = _Sum_Stock * _UltPm

            _Sum_Stock += _Caprco1

            'If _Sum_Stock = 0 Then
            '    _Total_Stfi_x_Pm = 0
            'Else
            '    _Total_Stfi_x_Pm = _Total_Stfi_x_Pm - ((_UltPm * _Caprco1) * -1)
            '    _Total_Stfi_x_Pm = _Total_Stfi_x_Pm - ((_UltPm * _Caprco1) * -1)
            'End If

            Application.DoEvents()
            If Not IsNothing(_ProgressBarX1) Then
                _ProgressBarX1.Value += 1
                _ProgressBarX1.Text = "Documentos revisados " & FormatNumber(_ProgressBarX1.Value, 0) & " de " & FormatNumber(_TblDetalleDocs.Rows.Count, 0)
            End If

            'If _Tido = "GRC" Or
            '   (_Tido = "GRI" And _Tidopa <> "GTI") Or
            '   (_Tido = "GDI" And _Tidopa <> "GTI") Or
            '   (_Tido = "FCC" And _Lincondesp) Or
            '   (_Tido = "BLC" And _Lincondesp) Or
            '   (_Tido = "GDD" And _Subtido = String.Empty) Then

            If _Tido = "GRC" Or
               (_Tido = "GRI" And _Tidopa <> "GTI") Or
               (_Tido = "GDI" And _Tidopa <> "GTI") Or
               (_Tido = "FCC") Or
               (_Tido = "BLC") Or
               (_Tido = "GDD" And _Subtido = String.Empty) Then

                Dim _NewPm As Double

                If _Sum_Stock = 0 Then
                    _Total_Stfi_x_Pm = 0
                    _NewPm = 0
                    _UltPm = 0
                Else
                    '_NewPm = (_Total_Stfi_x_Pm + _Vaneli) / _Sum_Stock
                    _NewPm = (_UltPmXStockActual + _Vaneli) / _Sum_Stock
                End If

                _Pm = Math.Round(_NewPm, 2)

                If _Pm > 0 Then
                    _UltPm = _Pm
                End If

            End If

            _Fila.Item("NewPPPRPR") = _Pm
            _Fila.Item("Stfisico") = _Sum_Stock

            If _Cancelar Then
                _ProgressBarX1.Value = 0
                _ProgressBarX1.Text = String.Empty
                Return False
            End If

        Next

        If Not IsNothing(_ProgressBarX1) Then
            _ProgressBarX1.Value = 0
            _ProgressBarX1.Text = String.Empty
        End If

        ' Al recalcular hay que ir descontando los valores...

        Return True

    End Function

    Function Fx_DetalleDocumentos(_Codigo As String, _Fechinippp As DateTime) As DataTable

        'Dim _Fechinippp As DateTime = _Global_Row_Configp.Item("FECHINIPPP")

        Consulta_sql = "-- Crea Tabla de Paso para hacer el recalculo
                        SELECT D.KOPRCT,E.EMPRESA,E.TIDO,E.NUDO,E.ENDO,E.TIMODO,E.TAMODO,E.HORAGRAB,E.SUBTIDO,'   ' AS TIDODCR,D.VANELI AS VALDCR,0 AS IDMAEDCR,
					    D.IDMAEDDO,D.LILG,D.CAPRCO1,D.CAPRAD1,D.CAPREX1,D.CAPRCO2,D.CAPRAD2,D.CAPREX2,D.VANELI,D.COSTOTRIB,D.COSTOIFRS,D.PPPRNERE1,D.FEEMLI,
					    D.PPPRPM,D.TIDOPA,D.IDRST,D.ARPROD,D.TIPR,D.PPOPPR,D.LINCONDESP,PE.SUBTIDO AS SUBTIDOPA, 
					    (SELECT COUNT(*) FROM MAEDDO AS POST WITH ( NOLOCK ) WHERE POST.IDRST = D.IDMAEDDO) AS NRODOCPOST,MAEEN.NOKOEN,
                        Cast(0 As Float) As Stfisico,Cast(0 As Float) As NewPPPRPR
					  	    INTO #DDO  
					            FROM MAEDDO AS D WITH ( NOLOCK )  
						             INNER JOIN MAEEDO AS E WITH ( NOLOCK ) ON E.IDMAEEDO=D.IDMAEEDO AND E.EMPRESA='01'  
							              LEFT OUTER JOIN MAEDDO AS PD WITH ( NOLOCK ) ON D.ARCHIRST = 'MAEDDO' AND PD.IDMAEDDO = D.IDRST  
								              LEFT OUTER JOIN MAEEDO AS PE WITH ( NOLOCK ) ON PE.IDMAEEDO = PD.IDMAEEDO  
									               LEFT OUTER JOIN MAEEN WITH ( NOLOCK ) ON E.ENDO=MAEEN.KOEN AND E.SUENDO=MAEEN.SUEN  
					    WHERE 
						    D.KOPRCT = '" & _Codigo & "'  AND 
						    D.ARPROD <> 'COMOD' AND 
						    D.ARPROD <> 'CIFRS'  AND 
						    D.FEEMLI >= '" & Format(_Fechinippp, "yyyyMMdd") & "'
					     ORDER BY D.FEEMLI,E.HORAGRAB,D.IDMAEDDO,D.LILG 

                        -- Inserta una fila nose para que??? Esto es para productos que tienen recargos asociados, hay que investigar
                        INSERT INTO #DDO  
				                        SELECT D.KOPRCT,E.EMPRESA,E.TIDO,E.NUDO,E.ENDO,E.TIMODO,E.TAMODO,EBASE.HORAGRAB,E.SUBTIDO,'DCR',
				                        MAEDCR.VALDCR,MAEDCR.IDMAEDCR,D.IDMAEDDO,D.LILG,D.CAPRCO1,D.CAPRAD1,D.CAPREX1,D.CAPRCO2,
				                        D.CAPRAD2,D.CAPREX2,D.VANELI,D.COSTOTRIB,D.COSTOIFRS,D.PPPRNERE1,EBASE.FEEMDO,D.PPPRPM,D.TIDOPA,
				                        D.IDRST,D.ARPROD,D.TIPR,D.PPOPPR,D.LINCONDESP,'   ' AS SUBTIDOPA,0 AS NRODOCPOST,
				                        MAEEN.NOKOEN,0,0   
		                        FROM MAEDCR WITH ( NOLOCK )  
			                        INNER JOIN MAEDDO AS D WITH ( NOLOCK ) ON D.IDMAEDDO = MAEDCR.IDDDODCR  
				                        INNER JOIN MAEEDO AS E WITH ( NOLOCK ) ON E.IDMAEEDO=D.IDMAEEDO AND E.EMPRESA='01'  
					                        INNER JOIN MAEEDO AS EBASE WITH ( NOLOCK ) ON EBASE.IDMAEEDO=MAEDCR.IDMAEEDO AND EBASE.EMPRESA='01'  
						                        LEFT OUTER JOIN MAEEN WITH ( NOLOCK ) ON E.ENDO=MAEEN.KOEN AND E.SUENDO=MAEEN.SUEN  
                        WHERE 
	                        D.KOPRCT = '" & _Codigo & "'  AND 
	                        D.ARPROD <> 'COMOD' AND 
	                        D.ARPROD <> 'CIFRS' AND 
	                        EBASE.FEEMDO >= '" & Format(_Fechinippp, "yyyyMMdd") & "'
                        ORDER BY D.FEEMLI,E.HORAGRAB,D.IDMAEDDO,D.LILG 


                        SELECT * FROM #DDO ORDER BY FEEMLI,HORAGRAB,IDMAEDDO,LILG,TIDODCR 
                        DROP TABLE #DDO"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Return _Tbl

    End Function


    Private Function Stock_A_Una_Fecha_X_Producto(_Row_Producto As DataRow,
                                                  _Empresa As String,
                                                  _Sucursal As String,
                                                  _Bodega As String,
                                                  _SQLquery As String,
                                                  _Fecha As Date) As Double()


        Dim Stock_(1) As Double

        If Not (_Row_Producto Is Nothing) Then

            Dim _Codigo = _Row_Producto.Item("KOPR")
            Dim _Rtu = _Row_Producto.Item("RLUD")

            _SQLquery = Replace(_SQLquery, "#Empresa#", _Empresa)
            _SQLquery = Replace(_SQLquery, "#Sucursal#", _Sucursal)
            _SQLquery = Replace(_SQLquery, "#Bodega#", _Bodega)
            _SQLquery = Replace(_SQLquery, "#@Codigo#", _Codigo)
            _SQLquery = Replace(_SQLquery, "#Fecha#", Format(_Fecha, "yyyyMMdd"))
            _SQLquery = Replace(_SQLquery, "Zw_TblStockConsolid", "#Zw_TblStockConsolid")

            Dim Tbl As DataTable = _Sql.Fx_Get_Tablas(_SQLquery)

            If Tbl.Rows.Count > 0 Then
                Stock_(0) = Math.Round(Tbl.Rows(0).Item("CantidadUd1"), 5)
                Stock_(1) = Math.Round(Tbl.Rows(0).Item("CantidadUd2"), 5)
            Else
                Stock_(0) = 0
                Stock_(1) = 0
            End If

        Else
            Stock_(0) = 0
            Stock_(1) = 0
        End If

        Return Stock_

    End Function


End Class
