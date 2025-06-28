Imports System.Security.Claims

Public Class Cl_PPPPr

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblDetalleDocs As DataTable

    Dim _Cancelar As Boolean

    Public Property Pm As Double
    Public Property Pppini As Double
    Public Property Stexistini As Double
    Public Property Saldo_Stock As Double
    Public Property Fepm As DateTime
    Public Property Fepm_Maeprem As DateTime
    Public Property Pm_Maeprem As Double

    Public Property TblDetalleDocs As DataTable
        Get
            Return _TblDetalleDocs
        End Get
        Set(value As DataTable)
            _TblDetalleDocs = value
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

        Fepm = FechaDelServidor()

        Pm = 0
        Pppini = 0
        Stexistini = 0
        'Sum_Stock = 0

    End Sub

    ''' <summary>
    ''' Recalcula el Precio Promedio Ponderado por cada producto revisando
    ''' cada movimiento desde una fecha en adelante
    ''' </summary>
    ''' <param name="_Codigo"></param>Código del producto a estudiar
    ''' <param name="_Descripcion"></param>Descripción del producto a estudiar
    ''' <param name="_FechaTope"></param>Fecha de tope para la revisión del PPP
    ''' <param name="_Progreso"></param>Barra de progreso, si no hay dejar Nothing
    ''' <returns></returns>
    Function Fx_RecalcularPPPxPR2(_Codigo As String,
                                  _Descripcion As String,
                                  _FechaTope As DateTime,
                                  _Progreso As Object,
                                  _ActualizarPPP As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Fechinippp As DateTime

        ' Detectar si _Progreso es una barra de progreso válida
        Dim _EsBarraProgreso As Boolean = False
        Dim _BarraProgreso As Object = Nothing
        If Not IsNothing(_Progreso) Then
            ' Puede ser ProgressBarX o ProgressBar estándar
            If TypeOf _Progreso Is DevComponents.DotNetBar.Controls.ProgressBarX OrElse
           TypeOf _Progreso Is ProgressBar Then
                _EsBarraProgreso = True
                _BarraProgreso = _Progreso
            End If
        End If

        Try
            _Fechinippp = _Global_Row_Configp.Item("FECHINIPPP")
        Catch ex As Exception
            _Fechinippp = _FechaTope
        End Try

        Try

            Consulta_sql = "Select MAEPREM.PMIN,MAEPREM.PM,MAEPREM.FEPM,Cast('" & Format(_Fechinippp, "yyyyMMdd") & "' As Datetime) As FICPPP," &
                           "0 As Col5,MAEPR.KOPR,MAEPR.NOKOPR,MAEPR.UD01PR,MAEPR.UD02PR,MAEPR.KOPRRA,MAEPR.KOPRTE," &
                           "MAEPR.FMPR,MAEPR.PFPR,MAEPR.HFPR,MAEPR.MRPR,RUPR,MAEPR.RLUD" & vbCrLf &
                           "From MAEPR WITH ( NOLOCK )" & vbCrLf &
                           "Inner Join MAEPREM ON MAEPREM.KOPR=MAEPR.KOPR AND MAEPREM.EMPRESA='" & ModEmpresa & "'" & vbCrLf &
                           "Where MAEPR.TIPR = 'FPN' And MAEPR.KOPR = '" & _Codigo & "'"
            Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Msj As LsValiciones.Mensajes

            _Msj = Fx_PPPIniYStockIni(_Codigo, _Fechinippp, _Fepm)

            If _Msj.EsCorrecto Then
                _Pppini = CType(_Msj.Tag, DataRow).Item("PPPINI")
                _Stexistini = Math.Round(CType(_Msj.Tag, DataRow).Item("STEXISTINI"), 5)
                _Stexistini = _Stexistini

                If IsDBNull(CType(_Msj.Tag, DataRow).Item("ULT_FEDOCU")) OrElse CType(_Msj.Tag, DataRow).Item("ULT_FEDOCU") Is Nothing Then
                    Fepm = New DateTime(1900, 1, 1)
                Else
                    Fepm = CType(_Msj.Tag, DataRow).Item("ULT_FEDOCU")
                End If


            Else
                _Pppini = 0
                _Stexistini = 0
            End If

            _Pm = _Pppini

            If _EsBarraProgreso Then
                Try
                    _BarraProgreso.Text = "Analizando movimientos del producto..." & _Codigo.Trim & " - " & _Descripcion.Trim
                    _BarraProgreso.Value = 0
                    _BarraProgreso.Maximum = 100
                Catch ex As Exception
                End Try
                Application.DoEvents()
            End If


            _TblDetalleDocs = Fx_DetalleDocumentos(_Codigo, _Fechinippp)

            Dim _Fecha_Max As Date = DateAdd(DateInterval.Year, 1, _Fepm)

            'Dim _Stock_Fi(1) As Double
            'Dim _Stfi1, _Stfi2 As Double      ' STOCK FISICO

            'Dim _Stock_Trans(1) As Double
            'Dim _Sttr1, _Sttr2 As Double      ' STOCK EN TRANSITO


            'Dim _Total_Stfi_x_Pm As Double = _Pm * (_Stfi1 + _Sttr1)
            '_Sum_Stock = _Stfi1 + _Sttr1

            '_Sum_Stock = Stexistini

            Dim _Total_Stfi_x_Pm As Double
            _Total_Stfi_x_Pm = _Pm * Stexistini

            Dim _UltPm As Double = _Pm


            Dim _Saldo_Valor As Double = Math.Round(_Total_Stfi_x_Pm, 5)
            Dim _Pr_Pr_P As Double = _Pm

            'If _Stexistini < 0 Then
            '_Saldo_Stock = 0
            'Else
            _Saldo_Stock = Math.Round(_Stexistini, 2)
            'End If

            If _EsBarraProgreso Then
                Try
                    _BarraProgreso.Maximum = _TblDetalleDocs.Rows.Count
                    _BarraProgreso.Value = 0
                    _BarraProgreso.Text = _Codigo & ", Procesando documentos..."
                Catch ex As Exception
                End Try
                Application.DoEvents()
            End If

            Dim _ContadorDocs As Integer = 0
            Dim _SqlQuery As String = String.Empty

            For Each _Fila As DataRow In _TblDetalleDocs.Rows

                Dim _Idmaeddo As Integer = _Fila.Item("IDMAEDDO")
                Dim _Tido As String = _Fila.Item("TIDO")
                Dim _Nudo As String = _Fila.Item("NUDO")
                Dim _Subtido As String = _Fila.Item("SUBTIDO")
                Dim _Idrst As Integer = _Fila.Item("IDRST")
                Dim _Tidopa As String = _Fila.Item("TIDOPA").ToString.Trim
                Dim _Lincondesp As Boolean = _Fila.Item("LINCONDESP")
                Dim _Feemli As Date = _Fila.Item("FEEMLI")
                Dim _Cantidad As Double
                Dim _Caprco1 As Double = _Fila.Item("CAPRCO1")
                Dim _Caprad1 As Double = _Fila.Item("CAPRAD1")
                Dim _Ppprnere1 As Double = _Fila.Item("PPPRNERE1")
                Dim _Costotrib As Double = 0 '_Fila.Item("COSTOTRIB")
                Dim _Costoifrs As Double = _Fila.Item("COSTOIFRS")
                Dim _Vaneli As Double = _Fila.Item("VANELI")
                Dim _Lilg As String = _Fila.Item("LILG")

                Dim _Entrada As Double
                Dim _Salida As Double

                Dim _V_Salida As Double
                Dim _V_Entrada As Double

                Dim _Es_Entrada As Boolean = False
                Dim _Es_Salida As Boolean = False
                Dim _Es_Din As Boolean = False

                If _Tido.Contains("G") Then
                    _Cantidad = Math.Round(_Caprco1, 2)
                Else
                    _Cantidad = Math.Round(_Caprad1, 2)
                End If

                Dim _VaneliCalc As Double = Math.Round(_Cantidad * _Ppprnere1, 0)

                Dim _UltSaldoNegativo As Boolean = False

                If _Saldo_Valor < 0 Or _Saldo_Stock < 0 Then
                    _UltSaldoNegativo = True
                End If

                If _Nudo = "0000049984" Then
                    Dim _Aqui = 0
                End If

                If CBool(_Cantidad) AndAlso
                    ((_Tido = "GDD") Or
                    (_Tido = "GDI" And String.IsNullOrWhiteSpace(_Tidopa)) Or
                    (_Tido = "GDP") Or
                    (_Tido = "GDV") Or
                    (_Tido = "NCC" And String.IsNullOrWhiteSpace(_Tidopa)) Or
                    (_Tido = "FCV") Or
                    (_Tido = "FDV") Or
                    (_Tido = "BLV")) Then

                    _Cantidad = _Caprco1
                    _Salida = _Cantidad
                    _V_Salida = Math.Round(_Salida * Pm)
                    _Saldo_Valor -= Math.Round(_V_Salida, 5)
                    _Saldo_Stock -= Math.Round(_Salida, 3)

                    'If Math.Round(_Saldo_Stock, 0) > 0 And Math.Round(_Saldo_Valor, 0) > 0 Then
                    '    _Pr_Pr_P = _Saldo_Valor / _Saldo_Stock
                    'Else
                    '    _Pr_Pr_P = Math.Round(_Pm, 5)
                    'End If

                    '_Pm = Math.Round(_Pr_Pr_P, 5)
                    _Costotrib = Math.Round(_Pm * _Cantidad, 0)

                End If

                If CBool(_Cantidad) AndAlso
                   ((_Tido = "GRC") Or
                   (_Tido = "GRI" And String.IsNullOrWhiteSpace(_Tidopa)) Or
                   (_Tido = "FCC" And String.IsNullOrWhiteSpace(_Tidopa)) Or
                    _Tido = "BLC" Or
                    _Tido = "GRD" Or
                   (_Tido = "NCV" And String.IsNullOrWhiteSpace(_Tidopa)) Or
                   (_Tido = "NCV" And CBool(_Cantidad)) Or
                   (_Tido = "GDD" And String.IsNullOrWhiteSpace(_Tidopa))) Then

                    _Cantidad = _Caprco1
                    _Entrada = _Cantidad
                    _V_Entrada = _Vaneli

                    Dim _PrecioCompra As Double

                    If ((_Tido = "NCV" Or _Tido = "GRD") AndAlso _Tidopa = "FCV") Or (_Tido = "GRD" AndAlso _Tidopa = "NCV") Then

                        Consulta_sql = "Select TOP 1 TIDO,TIDOPA,PPPRPM,PPPRPMIFRS,ARCHIRST,IDRST,CAPRCO1,CAPRAD1,IDMAEDDO" & vbCrLf &
                                       "From MAEDDO With (Nolock)" & vbCrLf &
                                       "Where IDMAEDDO = " & _Idrst
                        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        If _Tido = "GRD" And _Tidopa = "NCV" Then

                            Consulta_sql = "Select TOP 1 TIDO,TIDOPA,PPPRPM,PPPRPMIFRS,ARCHIRST,IDRST,CAPRCO1,CAPRAD1,IDMAEDDO" & vbCrLf &
                                       "From MAEDDO With (Nolock)" & vbCrLf &
                                       "Where IDMAEDDO = " & _Row.Item("IDRST")
                            _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

                        End If

                        If _Tido = "NCV" And _Tidopa = "FCV" Then

                            Consulta_sql = "Select TOP 1 TIDO,TIDOPA,PPPRPM,PPPRPMIFRS,ARCHIRST,IDRST,CAPRCO1,CAPRAD1,IDMAEDDO" & vbCrLf &
                                           "From MAEDDO With (Nolock)" & vbCrLf &
                                           "Where ARCHIRST = 'MAEDDO' And IDRST = " & _Row.Item("IDMAEDDO") & " And IDMAEDDO <> " & _Idmaeddo
                            Dim _Row2 = _Sql.Fx_Get_DataRow(Consulta_sql)

                            If Not IsNothing(_Row2) Then
                                _Row = _Row2
                            End If

                        End If

                        '_Pm = _Row.Item("PPPRPM")
                        _PrecioCompra = _Row.Item("PPPRPM")

                    End If

                    If _Tido = "GRD" Or (_Tido = "NCV" And _Tidopa = "FCV") Then
                        _Costotrib = _PrecioCompra * _Cantidad
                    Else
                        _Costotrib = _Vaneli
                    End If

                    _PrecioCompra = Math.Round(_Costotrib / _Cantidad, 3)

                    Dim _PPP As Double = Fx_CalcularPrecioPromedioPonderado(Math.Round(_Saldo_Stock, 2), Pm, _Cantidad, _PrecioCompra)
                    Dim _PPP2 As Double = CalcularPPP(Saldo_Stock, Pm, _Cantidad, _PrecioCompra)

                    If _PPP > 0 Then
                        _Pm = _PPP
                    Else
                        _Pm = _PrecioCompra
                    End If

                    _Costotrib = Math.Round(_Costotrib)
                    _V_Entrada = _Costotrib

                    _Saldo_Valor += Math.Round(_V_Entrada, 5)
                    _Saldo_Stock += Math.Round(_Entrada, 3)

                    Fepm = _Feemli

                    'If _Tido = "NCV" Or _Tido = "GRD" Then
                    '    _Pr_Pr_P = _Saldo_Valor / _Saldo_Stock
                    '    _Pm = Math.Round(_Pr_Pr_P, 3)
                    'End If

                End If

                If _Tido = "DIN" Then

                    If _Lilg = "IM" Then

                        _V_Entrada = Math.Round(_Vaneli, 0)
                        _Saldo_Valor += _V_Entrada
                        _Costotrib = _V_Entrada
                        _Pr_Pr_P = _Saldo_Valor / _Saldo_Stock
                        _Pm = Math.Round(_Pr_Pr_P, 3)
                        Fepm = _Feemli

                        'Dim _PrecioCompra2 As Double = Math.Round(_Vaneli, 0) / _Cantidad
                        'Dim _DifStock As Double = _Saldo_Stock - _Cantidad
                        'Dim _PPP As Double = Fx_CalcularPrecioPromedioPonderado(_Saldo_Stock, Pm, 1, _Vaneli)
                        '_Pm = _PPP

                    End If

                End If

                _Fila.Item("SALDO") = _Saldo_Stock
                _Fila.Item("COSTOTRIB") = Math.Round(_Costotrib, 0)
                _Fila.Item("V_SALDO") = Math.Round(_Saldo_Valor, 2)
                _Fila.Item("NewPPPRPR") = _Pm
                _Fila.Item("Stfisico") = _Stexistini

                _ContadorDocs += 1

                If _EsBarraProgreso Then
                    Try
                        _BarraProgreso.Value = _ContadorDocs
                        _BarraProgreso.Text = _Codigo & ", Procesando documento " & _ContadorDocs.ToString & " de " & _TblDetalleDocs.Rows.Count.ToString
                    Catch ex As Exception
                    End Try
                    Application.DoEvents()
                End If

                If _Costotrib = 0 And (_Tido = "GTI" Or _Tido = "GRI" Or _Tido = "GDI") Then
                    _Costotrib = Math.Round(_Pm * _Cantidad)
                End If

                _SqlQuery += "Update MAEDDO Set PPPRPM = " & De_Num_a_Tx_01(_Pm, False, 5) & ",COSTOTRIB = " & De_Num_a_Tx_01(_Costotrib, False, 5) & Space(1) &
                             "Where IDMAEDDO = " & _Idmaeddo & " AND ARPROD<>'COMON' AND ARPROD<>'CIFRS' -- Documento: " & _Tido & " - " & _Nudo & vbCrLf

            Next

            If _EsBarraProgreso Then
                Try
                    _BarraProgreso.Value = 0
                    _BarraProgreso.Text = ""
                Catch ex As Exception
                End Try
                Application.DoEvents()
            End If

            If String.IsNullOrEmpty(_SqlQuery) Then

                Pm = Pm_Maeprem
                Fepm = Fepm_Maeprem

            End If

            _SqlQuery += "Update MAEPREM Set PM = " & De_Num_a_Tx_01(_Pm, False, 5) & ",FEPM = '" & Format(Fepm, "yyyyMMdd") & "' Where EMPRESA = '" & ModEmpresa & "' And KOPR = '" & _Codigo & "'" & vbCrLf &
                         "Update MAEPR Set PM = " & De_Num_a_Tx_01(_Pm, False, 5) & ",FEPM = '" & Format(Fepm, "yyyyMMdd") & "' Where KOPR = '" & _Codigo & "'" & vbCrLf &
                         "Update MAEDDO Set PPPRPM = " &
                         "(Select Top 1 PPPRPM From MAEDDO As CRIAS " &
                         "Where CRIAS.IDMAEEDO = MAEDDO.IDMAEEDO And CRIAS.LILG = 'CR' And CRIAS.NULILG = MAEDDO.NULIDO Order By CRIAS.NULIDO DESC) " &
                         "Where MAEDDO.KOPRCT = '" & _Codigo & "' And MAEDDO.LILG = 'GR'"

            _SqlQuery = "--CODIGO: " & _Codigo & " - " & _Descripcion & vbCrLf & _SqlQuery

            If _ActualizarPPP Then
                If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery, False) Then
                    Throw New Exception(_Sql.Pro_Error)
                End If
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Código: " & _Codigo & ", Descripción: " & _Descripcion
            _Mensaje.Detalle = "PPP recalculado: " & FormatCurrency(_Pm, 2) & vbCrLf &
                    "Fecha de inicio del cálculo: " & Format(_Fechinippp, "dd-MM-yyyy") & vbCrLf &
                    "Fecha de tope: " & Format(_FechaTope, "dd-MM-yyyy") & vbCrLf &
                    "Cantidad de documentos analizados: " & _TblDetalleDocs.Rows.Count.ToString("#,##0") & vbCrLf
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Tag = _TblDetalleDocs
            _Mensaje.Resultado = _Pm

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "Error al recalcular el PPP: " & ex.Message
            _Mensaje.Detalle = "Producto: " & _Codigo & " - " & _Descripcion
            _Mensaje.Icono = MessageBoxIcon.Error

            If _EsBarraProgreso Then
                Try
                    _BarraProgreso.Value = 0
                    _BarraProgreso.Text = ""
                Catch ex2 As Exception
                End Try
                Application.DoEvents()
            End If

        End Try

        Return _Mensaje

    End Function

    Function Fx_CalcularPrecioPromedioPonderado(_ST_Ant As Double,
                                                _PPP_Ant As Double,
                                                _Ingreso As Double,
                                                _Precio As Double) As Double

        If _PPP_Ant < 0 Then _PPP_Ant = 0
        If _ST_Ant < 0 Then _ST_Ant = 0

        Dim _TotalValorAnterior As Double = _ST_Ant * _PPP_Ant
        Dim _TotalValorCompra As Double = _Ingreso * _Precio
        Dim _TotalUnidades As Integer = _ST_Ant + _Ingreso

        If _TotalUnidades = 0 Then
            Return 0 ' Para evitar división por cero
        End If

        'Dim precioPromedio As Double = (_TotalValorAnterior + _TotalValorCompra) / _TotalUnidades

        Dim precioPromedioRd As Double = (_ST_Ant * _PPP_Ant + _Ingreso * _Precio) / (_ST_Ant + _Ingreso)

        Return Math.Round(precioPromedioRd, 5) ' Redondeo a 2 decimales
        'Return Math.Round(precioPromedio, 5) ' Redondeo a 2 decimales

    End Function

    Function CalcularPPP(stockAnterior As Decimal,
                         pppAnterior As Decimal,
                         ingreso As Decimal,
                         precioIngreso As Decimal) As Decimal

        If stockAnterior + ingreso = 0 Then
            Return 0 ' Evita división por cero
        End If

        Dim totalCostoAnterior As Decimal = stockAnterior * pppAnterior
        Dim totalCostoIngreso As Decimal = ingreso * precioIngreso
        Dim nuevoPPP As Decimal = (totalCostoAnterior + totalCostoIngreso) / (stockAnterior + ingreso)

        ' Retorna con hasta 5 decimales, si deseas exactitud como 10337.22016
        Return Math.Round(nuevoPPP, 5, MidpointRounding.AwayFromZero)

    End Function

    Function Fx_DetalleDocumentos(_Codigo As String, _Fechinippp As DateTime) As DataTable

        'Dim _Fechinippp As DateTime = _Global_Row_Configp.Item("FECHINIPPP")

        Consulta_sql = "-- Crea Tabla de Paso para hacer el recalculo
                        SELECT D.KOPRCT,E.EMPRESA,E.TIDO,E.NUDO,E.ENDO,E.TIMODO,E.TAMODO,E.HORAGRAB,E.SUBTIDO,'   ' AS TIDODCR,D.VANELI AS VALDCR,0 AS IDMAEDCR,
					    D.IDMAEDDO,D.LILG,D.CAPRCO1,D.CAPRAD1,D.CAPREX1,D.CAPRCO2,D.CAPRAD2,D.CAPREX2,D.VANELI,D.COSTOTRIB,D.COSTOIFRS,D.PPPRNERE1,D.FEEMLI,
					    D.PPPRPM,D.TIDOPA,D.IDRST,D.ARPROD,D.TIPR,D.PPOPPR,D.LINCONDESP,PE.SUBTIDO AS SUBTIDOPA, 
					    (SELECT COUNT(*) FROM MAEDDO AS POST WITH ( NOLOCK ) WHERE POST.IDRST = D.IDMAEDDO) AS NRODOCPOST,MAEEN.NOKOEN,
                        Cast(0 As Float) As Stfisico,Cast(0 As Float) As UltPmXStockActual,Cast(0 As Bit) As CambiaPPP,Cast(0 As Float) As NewPPPRPR,
                        Cast(0 As Float) As SALDO,Cast(0 As Float) As V_SALDO,Cast(0 As Float) As NewPPPRPR2
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
				                        MAEEN.NOKOEN,0,0,0,0,0,0,0   
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

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

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

            Dim Tbl As DataTable = _Sql.Fx_Get_DataTable(_SQLquery)

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

    Private Function Fx_PPPIniYStockIni(_Codigo As String, _FechaDesde As DateTime, _FechaHasta As DateTime) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Pm As Double = 0.0
        Try

            Consulta_sql = "
CREATE TABLE #PASOSALDO (
    KOPRCT        VARCHAR(13)   NOT NULL,   -- Código del producto
    FIUD01        FLOAT         NULL,       -- Stock inicial
    STPREPROV     FLOAT         NULL,       -- Stock pendiente proveedor
    STPRECLI      FLOAT         NULL,       -- Stock pendiente cliente
    STEXISTINI    FLOAT         NULL,       -- Stock existencia inicial
    PPPINI        FLOAT         NULL,       -- Precio promedio ponderado inicial
    VEXISTINI     FLOAT         NULL,       -- Valor existencia inicial
    TRANSITO      FLOAT         NULL,       -- Stock en tránsito
    NOKOPR        VARCHAR(100)  NULL,       -- Nombre del producto
    UD01PR        VARCHAR(10)   NULL,       -- Unidad 1
    UD02PR        VARCHAR(10)   NULL,       -- Unidad 2
    ULT_FEDOCU    DATE          NULL,       -- Última fecha de documento
    ULT_HGDOCU    INT           NULL,       -- Última hora de grabación de documento
    )

Declare @FECHADESDE As Datetime = '" & Format(_FechaDesde, "yyyyMMdd") & "'
Declare @FECHAHASTA As Datetime = '" & Format(_FechaHasta, "yyyyMMdd") & "'

SELECT KOPR INTO #PASOKOPR FROM MAEPR WITH (NOLOCK) 
WHERE TIPR <> 'SSN' AND TIPR <> 'FLN' And KOPR = '" & _Codigo & "'

INSERT INTO #PASOSALDO  (KOPRCT,FIUD01)
SELECT D.KOPRCT,SUM(D.CAPRCO1*FICO+D.CAPRAD1*FIAD)

FROM MAEDDO AS D WITH ( NOLOCK )  INNER JOIN TABTIDO WITH (NOLOCK) ON TABTIDO.TIDO = D.TIDO  INNER JOIN #PASOKOPR WITH (NOLOCK) ON #PASOKOPR.KOPR = D.KOPRCT  
WHERE D.PRCT= 0  AND D.LILG IN ('SI','CR')  AND  D.ARPROD <> 'CIFRS'  AND D.EMPRESA  = '" & ModEmpresa & "'  AND D.FEEMLI<@FECHADESDE GROUP BY D.KOPRCT 

UPDATE #PASOSALDO SET FIUD01 = 0 WHERE FIUD01 IS NULL 
UPDATE #PASOSALDO SET STPREPROV = COALESCE((SELECT SUM(D.CAPRCO1*FICO) FROM MAEDDO AS D WITH ( NOLOCK ) INNER JOIN MAEEDO WITH (NOLOCK) ON MAEEDO.IDMAEEDO = D.IDMAEEDO INNER JOIN TABTIDO WITH (NOLOCK) ON TABTIDO.TIDO = MAEEDO.TIDO WHERE #PASOSALDO.KOPRCT = D.KOPRCT  AND D.LILG IN ('SI','CR')  AND D.EMPRESA  = '" & ModEmpresa & "' AND D.FEEMLI<@FECHADESDE  AND MAEEDO.TIDO IN ('GRP','GDD') AND MAEEDO.SUBTIDO IN ( 'PRE','CON')),0) 
UPDATE #PASOSALDO SET STPREPROV = STPREPROV - COALESCE((SELECT SUM(FCCPRES.CAPRCO1) FROM MAEDDO AS FCCPRES WITH ( NOLOCK ) INNER JOIN MAEEDO WITH (NOLOCK) ON MAEEDO.IDMAEEDO = FCCPRES.IDMAEEDO INNER JOIN MAEDDO AS GRPPAS WITH (NOLOCK) ON FCCPRES.IDRST = GRPPAS.IDMAEDDO AND FCCPRES.ARCHIRST = 'MAEDDO' AND GRPPAS.TIDO = 'GRP' WHERE #PASOSALDO.KOPRCT = FCCPRES.KOPRCT  AND FCCPRES.LILG IN ('SI','CR')  AND FCCPRES.EMPRESA  = '" & ModEmpresa & "' AND FCCPRES.FEEMLI<@FECHADESDE  AND MAEEDO.TIDO IN ('BLC','FCC','FCT','FDC')),0) 
UPDATE #PASOSALDO SET STPRECLI = COALESCE((SELECT SUM(D.CAPRCO1*FICO*-1) FROM MAEDDO AS D WITH (NOLOCK) INNER JOIN MAEEDO WITH (NOLOCK) ON MAEEDO.IDMAEEDO = D.IDMAEEDO INNER JOIN TABTIDO WITH (NOLOCK) ON TABTIDO.TIDO = MAEEDO.TIDO WHERE #PASOSALDO.KOPRCT = D.KOPRCT  AND D.LILG IN ('SI','CR')  AND D.EMPRESA  = '" & ModEmpresa & "' AND D.FEEMLI<@FECHADESDE  AND MAEEDO.TIDO IN ('GDP','GRD') AND MAEEDO.SUBTIDO IN ( 'PRE','CON')),0) 
UPDATE #PASOSALDO SET STPRECLI = STPRECLI - COALESCE((SELECT SUM(FCVPRES.CAPRCO1) FROM MAEDDO AS FCVPRES WITH ( NOLOCK ) INNER JOIN MAEEDO WITH (NOLOCK) ON MAEEDO.IDMAEEDO = FCVPRES.IDMAEEDO INNER JOIN MAEDDO AS GDPPAS WITH (NOLOCK) ON FCVPRES.IDRST = GDPPAS.IDMAEDDO AND FCVPRES.ARCHIRST = 'MAEDDO' AND GDPPAS.TIDO = 'GDP' WHERE #PASOSALDO.KOPRCT = FCVPRES.KOPRCT  AND FCVPRES.LILG IN ('SI','CR')  AND FCVPRES.EMPRESA  = '" & ModEmpresa & "' AND FCVPRES.FEEMLI<@FECHADESDE  
AND MAEEDO.TIDO IN ('BLV','FCV','FDB')),0) 
INSERT INTO #PASOSALDO  SELECT M.KOPR,0,0,0,0,0,0,0,'','','',null,0  
				FROM MAEPR AS M WITH ( NOLOCK )  
				INNER JOIN MAEPREM AS E WITH (NOLOCK) ON E.KOPR=M.KOPR AND E.EMPRESA='" & ModEmpresa & "'  
				WHERE M.KOPR IN ( SELECT KOPR FROM #PASOKOPR WITH (NOLOCK) )  AND M.KOPR NOT IN ( SELECT KOPRCT FROM #PASOSALDO WITH (NOLOCK) )

UPDATE #PASOSALDO SET NOKOPR=MAEPR.NOKOPR,UD01PR=MAEPR.UD01PR,UD02PR=MAEPR.UD02PR  FROM MAEPR  WHERE MAEPR.KOPR=#PASOSALDO.KOPRCT 
SELECT D.IDMAEDDO,D.TIDO,D.NUDO,D.TIDOPA,D.KOPRCT,D.CAPRCO1,D.CAPRAD1,D.CAPREX1  
				INTO #GDINVI  
				FROM MAEDDO AS D WITH ( NOLOCK )  INNER JOIN #PASOSALDO WITH (NOLOCK) ON #PASOSALDO.KOPRCT = D.KOPRCT   
				WHERE D.TIDO = 'GDI' AND D.TIDOPA = 'NVI' AND D.CAPRCO1 = D.CAPREX1 AND D.FEEMLI<@FECHADESDE 
				AND NOT EXISTS( SELECT * FROM MAEDDO WITH (NOLOCK) WHERE MAEDDO.TIDO = 'GRI' AND MAEDDO.IDRST = D.IDMAEDDO AND MAEDDO.ARCHIRST = 'MAEDDO' ) 

UPDATE #PASOSALDO  SET TRANSITO = COALESCE(( SELECT SUM(D.CAPRCO1-D.CAPRAD1)  FROM MAEDDO AS D WITH (NOLOCK)  INNER JOIN MAEEDO AS E WITH (NOLOCK) ON E.IDMAEEDO=D.IDMAEEDO AND E.EMPRESA='" & ModEmpresa & "'  WHERE D.KOPRCT=#PASOSALDO.KOPRCT AND D.TIDO IN ('GTI','GDI')  AND D.LILG IN ('SI','CR') AND  D.ARPROD <> 'CIFRS'  AND D.ARCHIRST NOT IN ('POTL','POTD','PODCE','PODCD')  AND D.FEEMLI<@FECHADESDE AND NOT EXISTS (SELECT * FROM #GDINVI WITH (NOLOCK) WHERE #GDINVI.IDMAEDDO = D.IDMAEDDO) ) ,0) 
UPDATE #PASOSALDO  SET TRANSITO = TRANSITO - COALESCE(( SELECT SUM(D.CAPRCO1)  FROM MAEDDO AS D WITH (NOLOCK)  INNER JOIN MAEEDO AS E WITH (NOLOCK) ON E.IDMAEEDO=D.IDMAEEDO AND E.EMPRESA='" & ModEmpresa & "'  WHERE D.KOPRCT=#PASOSALDO.KOPRCT  AND D.TIDO = 'GRI'  AND D.TIDOPA IN ('GTI','GDI')  AND D.LILG IN ('SI','CR')  AND  D.ARPROD <> 'CIFRS'  AND D.FEEMLI<@FECHADESDE ),0) 
UPDATE #PASOSALDO SET STEXISTINI = FIUD01 + TRANSITO - STPREPROV + STPRECLI 
UPDATE #PASOSALDO  SET ULT_FEDOCU = ( SELECT MAX(FEEMLI) FROM MAEDDO AS D WITH (NOLOCK)   WHERE D.KOPRCT = #PASOSALDO.KOPRCT AND D.EMPRESA = '" & ModEmpresa & "' AND D.FEEMLI <@FECHADESDE )
UPDATE #PASOSALDO  SET ULT_HGDOCU = ( SELECT MAX(HORAGRAB) FROM MAEEDO AS E WITH (NOLOCK) INNER JOIN MAEDDO AS D ON D.IDMAEEDO = E.IDMAEEDO  WHERE D.KOPRCT = #PASOSALDO.KOPRCT AND D.EMPRESA = '" & ModEmpresa & "' AND D.FEEMLI = #PASOSALDO.ULT_FEDOCU )
UPDATE #PASOSALDO  SET PPPINI= ( SELECT TOP 1 (CASE WHEN D.ARPROD='COMOD' AND E.TIMODO='E' THEN D.PPPRPM*E.TAMODO ELSE D.PPPRPM END)+(CASE WHEN STEXISTINI<>0 THEN COALESCE(( SELECT SUM(MAEDCR.VALDCR)  FROM MAEDCR WITH ( NOLOCK )  INNER JOIN MAEDDO AS XD WITH (NOLOCK) ON XD.IDMAEDDO = MAEDCR.IDDDODCR  INNER JOIN MAEEDO AS XE WITH (NOLOCK) ON XE.IDMAEEDO=XD.IDMAEEDO AND XE.EMPRESA='" & ModEmpresa & "'  INNER JOIN MAEEDO AS XEBASE WITH (NOLOCK) ON XEBASE.IDMAEEDO=MAEDCR.IDMAEEDO AND XEBASE.EMPRESA='" & ModEmpresa & "'  WHERE XD.KOPRCT = D.KOPRCT  AND (XEBASE.FEEMDO> #PASOSALDO.ULT_FEDOCU OR (XEBASE.FEEMDO = #PASOSALDO.ULT_FEDOCU AND XEBASE.HORAGRAB > #PASOSALDO.ULT_HGDOCU))  AND XEBASE.FEEMDO <@FECHADESDE ) ,0.0)/STEXISTINI ELSE 0 END)  FROM MAEDDO AS D WITH (NOLOCK)  INNER JOIN MAEEDO AS E WITH (NOLOCK) ON E.IDMAEEDO=D.IDMAEEDO AND E.EMPRESA='" & ModEmpresa & "'  WHERE D.KOPRCT=#PASOSALDO.KOPRCT  AND D.FEEMLI<@FECHADESDE AND D.ARPROD NOT IN ('CIFRS')  ORDER BY D.FEEMLI DESC, E.HORAGRAB DESC, D.IDMAEDDO DESC, D.LILG DESC )
UPDATE #PASOSALDO SET PPPINI = 0 WHERE PPPINI IS NULL 
UPDATE #PASOSALDO SET VEXISTINI = ROUND(STEXISTINI * PPPINI,2) 

Select * From #PASOSALDO

Drop Table #PASOKOPR
Drop Table #PASOSALDO
Drop Table #GDINVI
"

            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If _Row Is Nothing Then
                _Mensaje.EsCorrecto = False
                _Mensaje.Mensaje = "No se encontró información para el código: " & _Codigo
                Return _Mensaje
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Tag = _Row

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "Error al obtener el último PPP: " & ex.Message
        End Try

        Return _Mensaje

    End Function

End Class
