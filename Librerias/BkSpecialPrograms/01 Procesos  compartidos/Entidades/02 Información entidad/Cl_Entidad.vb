Imports Itenso

Public Class Cl_Entidad

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Crsd_Disponible As Double
    Public Property Crch_Disponible As Double
    Public Property Crlt_Disponible As Double
    Public Property Crpa_Disponible As Double
    Public Property Crto_Disponible As Double

    Public Property RowEntidad As DataRow
    Public Property Notraedeud As Boolean
    Public Property Bloqueada As Boolean
    Public Property Tiene_Deudas As Boolean
    Public Property Tiene_Protestos As Boolean
    Public Property Tiene_Deudas_Vencidas As Boolean
    Public Property Solicitar_Permiso_Remoto As Boolean
    Public Property Tbl_Deudas As DataTable
    Public Property MaxDiasMoraDocumentos As Integer
    Public Property PromedioDiasPago As Double
    Public Property PromedioUltimas3FacturasPago As Double
    Public Property Tiene_Mas_Ventas As Boolean
    Public Property Promedio_Venta_UltXMeses As Double
    Public Property BloqueadoDebePagarDeuda As Boolean
    Public Property UltFacPagadasEnMenosTiempoQueDimoper As Boolean
    Public Property VentaMayorPromedioUlt3Meses As Boolean
    Public Property ClienteMoroso As Boolean
    Public Property Mensaje As String
    Public Property Dimoper As Integer
    Public Property SuperaCreditoDisponible As Boolean
    Public Property DiasDeMora As Integer
    Public Property ListaProblemas As List(Of String)
    Public Sub New()

        ' Inicialización por defecto de propiedades
        RowEntidad = Nothing
        Notraedeud = False
        Bloqueada = False
        Tiene_Deudas = False
        Tiene_Protestos = False
        Tiene_Deudas_Vencidas = False
        Solicitar_Permiso_Remoto = False
        Tbl_Deudas = New DataTable()
        MaxDiasMoraDocumentos = 0
        PromedioDiasPago = 0.0
        PromedioUltimas3FacturasPago = 0.0
        Tiene_Mas_Ventas = False
        Promedio_Venta_UltXMeses = 0.0
        BloqueadoDebePagarDeuda = False
        UltFacPagadasEnMenosTiempoQueDimoper = False
        VentaMayorPromedioUlt3Meses = False
        ClienteMoroso = False
        Mensaje = String.Empty
        Dimoper = 0
        SuperaCreditoDisponible = False
        DiasDeMora = 0
        ListaProblemas = New List(Of String)()

        ' Inicializar disponibilidades de crédito
        Crsd_Disponible = 0.0
        Crch_Disponible = 0.0
        Crlt_Disponible = 0.0
        Crpa_Disponible = 0.0
        Crto_Disponible = 0.0


    End Sub

    Public Function Fx_Entidad_Tiene_Deudas_CtaCte(_RowEntidad As DataRow,
                                                   _Mostrar_Formulario As Boolean,
                                                   _Solicitar_Permiso_Remoto As Boolean,
                                                   _MontoVenta As Double) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Cl_Entidad As New Cl_Entidad

        'Dim _DiasMoraPermitidos As Integer = 80

        Dim _RevAutomaticaMorosidadClientes As Boolean = _Global_Row_Configuracion_General.Item("RevAutomaticaMorosidadClientes")
        Dim _RestarDimoper As Boolean = Not _RevAutomaticaMorosidadClientes

        Try

            If (_RowEntidad Is Nothing) Then Return _Mensaje

            _Cl_Entidad.RowEntidad = _RowEntidad
            _Cl_Entidad.Bloqueada = _RowEntidad.Item("BLOQUEADO")
            _Cl_Entidad.Notraedeud = _RowEntidad.Item("NOTRAEDEUD")

            If _Cl_Entidad.Notraedeud Then

                _Mensaje.EsCorrecto = True
                _Mensaje.Mensaje = "Cliente no afecto a revisión de cuenta corriente"
                _Mensaje.Tag = _Cl_Entidad

                Return _Mensaje

            Else

                '-- ESTA INSTRUCCION CIERRA LOS VENCIMIENTOS QUE YA ESTAN CANCELADOS COMPLETAMENTE
                Dim _Ms As LsValiciones.Mensajes = Fx_Reparar_Maeven(_RowEntidad)

                If Not _Ms.EsCorrecto Then
                    _Cl_Entidad.ListaProblemas.Add("Error al reparar los vencimientos de la entidad" & vbCrLf & _Ms.Mensaje)
                    Fx_LlenarMensaje(_Cl_Entidad)
                    Throw New System.Exception("Error al reparar los vencimientos de la entidad" & vbCrLf & _Ms.Mensaje)
                End If

                ' Dim _Msj As LsValiciones.Mensajes = Fx_Revisar_Deuda_Doc_Entidad(_RowEntidad)

                Dim _Fecha_Tope As Date = FechaDelServidor()
                Dim _Fecha As String = Format(FechaDelServidor, "yyyyMMdd")

                Dim _Koen As String = _RowEntidad.Item("KOEN")
                Dim _Suen As String = _RowEntidad.Item("SUEN")

                _Cl_Entidad.Dimoper = _RowEntidad.Item("DIMOPER")

                Consulta_sql = My.Resources.Sql_Entidad.SqlQuery_deuda_doc_comerciales
                Consulta_sql = Replace(Consulta_sql, "#CodEntidad#", _Koen)
                Consulta_sql = Replace(Consulta_sql, "#Fecha#", _Fecha)
                Consulta_sql = Replace(Consulta_sql, "#Empresa#", Mod_Empresa)

                Tbl_Deudas = _Sql.Fx_Get_DataTable(Consulta_sql)

                'If CBool(Tbl_Deudas.Rows.Count) Then

                Dim _Deudas As Integer
                Dim _MaxDiasDeAtraso As Integer = 0

                If CBool(Tbl_Deudas.Rows.Count) Then
                    '_Cl_Entidad.ListaProblemas.Add($"Tiene {Tbl_Deudas.Rows.Count} documentos con deuda")
                    _Cl_Entidad.ListaProblemas.Add($"Existen {Tbl_Deudas.Rows.Count} documentos impagos actualmente registrados.")
                Else
                    _Cl_Entidad.ListaProblemas.Add($"Cliente sin deudas")
                End If

                For Each _Fila As DataRow In Tbl_Deudas.Rows

                    Dim _Nudonodefi As Boolean = _Fila.Item("NUDONODEFI")
                    Dim _Dias_Atraso As Integer = _Fila.Item("DIAS_ATRASO")

                    If Not _Nudonodefi Then

                        Dim _DiasDeAtraso As Double = _Dias_Atraso

                        If _RestarDimoper Then
                            _DiasDeAtraso = _Dias_Atraso - _Cl_Entidad.Dimoper
                        End If

                        If _DiasDeAtraso >= 0 Then
                            _Deudas += 1

                            '' Actualizar el máximo de días de mora si corresponde
                            'If _DiasDeAtraso > _MaxDiasDeAtraso Then
                            '    _MaxDiasDeAtraso = _DiasDeAtraso
                            'End If

                            ' Actualizar el máximo de días de mora si corresponde
                            If _Dias_Atraso > _MaxDiasDeAtraso Then
                                _MaxDiasDeAtraso = _Dias_Atraso
                            End If

                        End If

                    End If

                Next

                Dim _Endo = _RowEntidad.Item("KOEN").ToString.Trim
                Dim _Suendo = _RowEntidad.Item("SUEN").ToString.Trim

                Dim _Reg2 As Integer = _Sql.Fx_Cuenta_Registros("MAEEDO", "TIDO In ('BLV','FCV','FDV') And ENDO = '" & _Endo & "' And SUENDO = '" & _Suen & "'")

                If CBool(_Reg2) Then
                    '_Cl_Entidad.ListaProblemas.Add($"El documentos con más días de atraso tiene {_MaxDiasDeAtraso} días de atraso")
                    _Cl_Entidad.ListaProblemas.Add($"El documento con mayor atraso acumula {_MaxDiasDeAtraso} días desde su fecha de vencimiento.")
                End If

                If CBool(_Cl_Entidad.Dimoper) Then
                    _Cl_Entidad.ListaProblemas.Add($"El cliente tiene {_Cl_Entidad.Dimoper} días de morosidad permitida")
                Else
                    _Cl_Entidad.ListaProblemas.Add($"El cliente no tiene días de morosidad permitida")
                End If

                ' Guardar el mayor dias de atraso en la instancia que se devuelve

                _Cl_Entidad.MaxDiasMoraDocumentos = _MaxDiasDeAtraso
                _Cl_Entidad.Tiene_Deudas = CBool(_Deudas)
                _Cl_Entidad.Tbl_Deudas = Tbl_Deudas
                _Cl_Entidad.ClienteMoroso = _Cl_Entidad.Tiene_Deudas

                Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("MAEEDO", $"TIDO = 'FCV' And ENDO = '{_Endo}' And SUENDO = '{_Suendo}'")

                _Cl_Entidad.Tiene_Mas_Ventas = IIf(_Reg > 1, True, False)
                _Cl_Entidad.Promedio_Venta_UltXMeses = Fx_Promedio_Venta_UltXMeses(_RowEntidad, 3)

                If _Cl_Entidad.MaxDiasMoraDocumentos > _Cl_Entidad.Dimoper Then
                    _Cl_Entidad.Tiene_Deudas_Vencidas = True
                    _Cl_Entidad.DiasDeMora = _Cl_Entidad.MaxDiasMoraDocumentos - _Cl_Entidad.Dimoper
                    '_Cl_Entidad.ListaProblemas.Add($"Hay un documento que tiene {_Cl_Entidad.DiasDeMora} días de morosidad restando los días permitidos de mora")
                    _Cl_Entidad.ListaProblemas.Add($"Uno de los documentos presenta {_Cl_Entidad.DiasDeMora} días de morosidad efectiva, considerando los {_Cl_Entidad.Dimoper} días permitidos.")
                End If

                '_Cl_Entidad.ClienteMoroso = _Cl_Entidad.Tiene_Deudas_Vencidas

                Dim _DiasMaxMora As Double = _Cl_Entidad.Dimoper + 5
                Dim _MaxDiasMoraDocumentos As Double = _Cl_Entidad.MaxDiasMoraDocumentos
                Dim _DiasMr As Integer = _DiasMaxMora - _MaxDiasMoraDocumentos

                If _MaxDiasMoraDocumentos > _DiasMaxMora Then
                    '_Cl_Entidad.ListaProblemas.Add($"El sistema tiene permitido como máximo 5 de mora posterior a los días de morosidad permitidos antes de que se bloquee")
                    _Cl_Entidad.ListaProblemas.Add($"El sistema admite un máximo de 5 días de morosidad adicional (posterior a los días permitidos) antes de activar el bloqueo.")
                    _Cl_Entidad.ListaProblemas.Add("¡El cliente supera el límite permitido, por lo que se encuentra bloqueado para nuevas ventas hasta regularizar su deuda!")
                    _Cl_Entidad.Bloqueada = True
                    _Mensaje.Tag = _Cl_Entidad
                    Fx_LlenarMensaje(_Cl_Entidad)
                    Throw New System.Exception("Cliente tiene documentos con deudas")
                End If

                Consulta_sql = My.Resources.Recursos_Inf.SQLQuery_Informe_de_comportamiento_de_pagos
                Consulta_sql = Replace(Consulta_sql, "#Filtro_Entidad#", "And ENDO = '" & _Endo & "'")
                Consulta_sql = Replace(Consulta_sql, "#Filtro_2#", "And TIPO_DOC <> 'NCV'")
                Consulta_sql = Replace(Consulta_sql, "#Empresa#", Mod_Empresa)

                Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                Dim _Row As DataRow = _Ds.Tables(2).Rows(0)
                Dim _Row2 As DataRow = _Ds.Tables(3).Rows(0)

                If CBool(_Reg2) Then

                    If Not IsNothing(_Row) Then
                        _Cl_Entidad.PromedioDiasPago = Math.Round(_Row.Item("PROMEDIO_DIAS_REAL_PAGO"), 2)
                        '_Cl_Entidad.ListaProblemas.Add($"El promedio de días que demora el cliente en pagar es de {_Cl_Entidad.PromedioDiasPago} días")
                        _Cl_Entidad.ListaProblemas.Add($"El cliente presenta un promedio de {_Cl_Entidad.PromedioDiasPago} días de retraso en el pago de sus documentos.")
                    End If

                    If Not IsNothing(_Row2) Then
                        _Cl_Entidad.PromedioUltimas3FacturasPago = Math.Round(_Row2.Item("PROMEDIO_ULTIMAS_3_FACTURAS"), 2)
                        '_Cl_Entidad.ListaProblemas.Add($"El promedio de dias que demora el cliente en pagar las últimas 3 facturas es de {_Cl_Entidad.PromedioUltimas3FacturasPago} días")
                        _Cl_Entidad.ListaProblemas.Add($"En sus últimas 3 facturas, el cliente ha registrado un plazo promedio de pago de {_Cl_Entidad.PromedioUltimas3FacturasPago} días.")
                    End If

                    If _Cl_Entidad.ClienteMoroso AndAlso
                       _Cl_Entidad.MaxDiasMoraDocumentos > _DiasMaxMora AndAlso
                       _Cl_Entidad.PromedioUltimas3FacturasPago > _Cl_Entidad.Dimoper Then

                        '_Cl_Entidad.ListaProblemas.Add("No se le puede vender a este cliente hasta que no pague su deuda" & vbCrLf &
                        '                       "Las ultimas 3 facturas han sido pagadas en un promedio de " &
                        '                       _Cl_Entidad.PromedioUltimas3FacturasPago & " días, solo se permiten hasta " & _Cl_Entidad.Dimoper & " días.")

                        _Cl_Entidad.ListaProblemas.Add($"El cliente no puede recibir nuevas ventas hasta regularizar su deuda pendiente.")
                        _Cl_Entidad.ListaProblemas.Add($"Las últimas 3 facturas fueron pagadas con un promedio de {_Cl_Entidad.PromedioUltimas3FacturasPago} días de atraso, superando el límite permitido de {_Cl_Entidad.Dimoper} días.")

                        _Cl_Entidad.Bloqueada = True
                        _Mensaje.Tag = _Cl_Entidad
                        Fx_LlenarMensaje(_Cl_Entidad)
                        Throw New System.Exception("Cliente tiene documentos con deudas")

                    End If

                    If _Cl_Entidad.Tiene_Deudas Then

                        If Not _Cl_Entidad.ClienteMoroso AndAlso _Cl_Entidad.PromedioUltimas3FacturasPago > _Cl_Entidad.Dimoper Then
                            _Cl_Entidad.ClienteMoroso = True
                            '_Cl_Entidad.ListaProblemas.Add("Cliente moroso, el promedio de pago de las ultimas 3 facturas es mayor a los días de morosidad permitida")
                            _Cl_Entidad.ListaProblemas.Add("El cliente presenta condición de moroso, ya que el promedio de pago" & vbCrLf &
                                                           "de sus últimas 3 facturas supera los días de morosidad permitidos.")
                        End If

                        If Not _Cl_Entidad.Tiene_Deudas_Vencidas And _Cl_Entidad.PromedioUltimas3FacturasPago < _Cl_Entidad.Dimoper Then
                            _Cl_Entidad.UltFacPagadasEnMenosTiempoQueDimoper = True
                            '_Cl_Entidad.ListaProblemas.Add("El promedio de pago de las ultimas 3 facturas es menor a los días de morosidad permitida")
                            _Cl_Entidad.ListaProblemas.Add("El promedio de pago de las últimas 3 facturas se encuentra por debajo del" & vbCrLf &
                                                           "límite de morosidad permitido, lo que indica un comportamiento de pago dentro" & vbCrLf &
                                                           "de los parámetros aceptados.")
                        End If

                    End If

                    If CBool(_MontoVenta) Then 'AndAlso CBool(_Cl_Entidad.Promedio_Venta_UltXMeses) Then

                        If _MontoVenta <= _Cl_Entidad.Promedio_Venta_UltXMeses Then
                            _Cl_Entidad.VentaMayorPromedioUlt3Meses = False
                            '_Cl_Entidad.ListaProblemas.Add("La venta es menor al promedio de ventas realizadas los últimos 3 meses. " &
                            '                   $"Venta: { FormatNumber(_MontoVenta, 0)}, promedio venta: {FormatNumber(_Cl_Entidad.Promedio_Venta_UltXMeses, 0)}")
                            _Cl_Entidad.ListaProblemas.Add("La venta actual ({ FormatNumber(_MontoVenta, 0)}) está por debajo del promedio de ventas de los" &
                                               $"últimos 3 meses ({FormatNumber(_Cl_Entidad.Promedio_Venta_UltXMeses, 0)}).")
                        Else
                            _Cl_Entidad.VentaMayorPromedioUlt3Meses = True
                            '_Cl_Entidad.ListaProblemas.Add("La venta es mayor al promedio de ventas realizadas los últimos 3 meses. " &
                            '                   $"Venta: { FormatNumber(_MontoVenta, 0)}, promedio venta: {FormatNumber(_Cl_Entidad.Promedio_Venta_UltXMeses, 0)}")

                            _Cl_Entidad.ListaProblemas.Add($"La venta actual ({ FormatNumber(_MontoVenta, 0)}) supera el promedio de ventas de los" &
                                               $"últimos 3 meses ({FormatNumber(_Cl_Entidad.Promedio_Venta_UltXMeses, 0)}).")

                        End If

                    End If

                End If

                Dim _EnCurso_Total As Double = _MontoVenta

                Sb_Revisar_Situacion_Credito_Entidad(_RowEntidad, _EnCurso_Total, 0, 0, 0)

                _Cl_Entidad.Crsd_Disponible = _Crsd_Disponible
                _Cl_Entidad.Crto_Disponible = _Crto_Disponible

                If _Cl_Entidad.Crto_Disponible < 0 Then
                    _Cl_Entidad.SuperaCreditoDisponible = True
                    '_Cl_Entidad.ListaProblemas.Add($"El cliente supera el crédito que tiene disponible con esta venta. " &
                    '                       $"(monto disponible: { FormatNumber(_Cl_Entidad.Crto_Disponible, 0)})")

                    _Cl_Entidad.ListaProblemas.Add($"El cliente excede el crédito disponible con esta venta.")
                    _Cl_Entidad.ListaProblemas.Add($"- Monto disponible actual: { FormatNumber(_Cl_Entidad.Crto_Disponible, 0)}, lo que indica que ya se encuentra sobrepasado.")

                End If

                Fx_LlenarMensaje(_Cl_Entidad)

                _Mensaje.Tag = _Cl_Entidad

                If _Cl_Entidad.ClienteMoroso Then
                    Throw New System.Exception("Cliente tiene documentos con deudas")
                End If

            End If

            'End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Cliente sin deudas vencidas"
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Tag = _Cl_Entidad

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
            If _Cl_Entidad.Tiene_Deudas AndAlso Not _Cl_Entidad.Tiene_Deudas_Vencidas Then
                _Mensaje.Icono = MessageBoxIcon.Warning
            End If
        End Try

        Return _Mensaje

    End Function
    Sub Fx_LlenarMensaje(ByRef _Cl_Entidad As Cl_Entidad)

        If CBool(_Cl_Entidad.ListaProblemas.Count) Then
            ' Construir mensaje acumulado con los problemas
            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine("Se han detectado los siguientes problemas:")
            sb.AppendLine()
            For Each problema In _Cl_Entidad.ListaProblemas
                If problema IsNot Nothing Then
                    sb.AppendLine(" - " & problema.ToString())
                End If
            Next
            sb.AppendLine()
            _Cl_Entidad.Mensaje = sb.ToString
        End If

    End Sub
    Function Fx_Promedio_Venta_UltXMeses(_RowEntidad As DataRow, _Meses As Integer) As Double

        Consulta_sql = $"
DECLARE @Endo    AS VARCHAR(20) = '{_RowEntidad.Item("KOEN").ToString.Trim}';
DECLARE @Suendo  AS VARCHAR(10) = '{_RowEntidad.Item("SUEN").ToString.Trim}';

SELECT 
    ISNULL(AVG(VentaMensual), 0) AS PROMEDIO_ULT_X_MESES
FROM (
        SELECT 
            CAST(CONVERT(VARCHAR(7), FEEMDO, 120) + '-01' AS DATE) AS Mes,
            SUM(
                CASE 
                    WHEN TIDO = 'NCV' THEN VANEDO * -1
                    ELSE VANEDO
                END
            ) AS VentaMensual
        FROM MAEEDO
        WHERE 
            ENDO = @Endo
            AND SUENDO = @Suendo
            AND ESDO <> 'N'
            AND FEEMDO >= DATEADD(MONTH, -{_Meses}, CAST(GETDATE() AS date))
            AND TIDO IN ('FCV','FDV','NCV')
        GROUP BY 
            CAST(CONVERT(VARCHAR(7), FEEMDO, 120) + '-01' AS DATE)
    ) AS Tbl;
"

        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Fx_Promedio_Venta_UltXMeses = _Row.Item("PROMEDIO_ULT_X_MESES")

    End Function
    Function Fx_Reparar_Maeven(_RowEntidad As DataRow) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _SqlQuery = String.Empty

            Dim _Filtro_Entidad As String

            If (_RowEntidad Is Nothing) Then
                _Filtro_Entidad = String.Empty
            Else
                _Filtro_Entidad = "And ENDO = '" & _RowEntidad.Item("KOEN") & "'"
            End If

            Consulta_sql = My.Resources.Recursos_Reparar_Maeven.SQLQuery_Reparar_Maeven
            Consulta_sql = Replace(Consulta_sql, "#Filtro_Entidad#", _Filtro_Entidad)
            Dim _Tbl_Documentos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim i = 0

            For Each _Fila As DataRow In _Tbl_Documentos.Rows

                Dim _Idmaeedo = _Fila.Item("_ID")
                Dim _Abonar As Double = _Fila.Item("ABONAR")

                Consulta_sql = "Select * From MAEVEN Where IDMAEEDO = " & _Idmaeedo
                Dim _Tbl_Maeven As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                For Each _Fila_Mv As DataRow In _Tbl_Maeven.Rows

                    Dim _Idmaeven = _Fila_Mv.Item("IDMAEVEN")
                    Dim _Vave = _Fila_Mv.Item("VAVE")
                    Dim _Vaabve = _Fila_Mv.Item("VAABVE")

                    Dim _Saldo As Double = _Vave - _Vaabve

                    If CBool(_Saldo) Then
                        If _Saldo > _Abonar Then
                            _SqlQuery += "UPDATE MAEVEN SET VAABVE += " & De_Num_a_Tx_01(_Abonar, False, 5) & Space(1) &
                                         "WHERE IDMAEVEN = " & _Idmaeven & vbCrLf
                        Else
                            _SqlQuery += "UPDATE MAEVEN SET VAABVE += " & De_Num_a_Tx_01(_Saldo, False, 5) & Space(1) &
                                         "WHERE IDMAEVEN = " & _Idmaeven & vbCrLf
                        End If
                    End If

                    _Abonar = _Abonar - _Saldo
                    If _Abonar <= 0 Then Exit For

                Next

                _SqlQuery += vbCrLf

                i += 1

            Next

            _SqlQuery += vbCrLf & "UPDATE MAEVEN SET ESPGVE = 'C' WHERE ESPGVE = '' AND ROUND(VAVE,0) - ROUND(VAABVE,0) = 0"

            '-- Esta consulta libera los documentos con saldo pendiente, pero no aparecen en Random para pagar
            'UPDATE MAEEDO SET ESPGDO = 'P'
            'WHERE  VAABDO - VABRDO < 0 AND TIDO IN ('FCC') AND ESPGDO = 'C'

            If Not _Sql.Ej_consulta_IDU(_SqlQuery, False) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Proceso terminado"
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function
    Sub Sb_Revisar_Situacion_Credito_Entidad(_RowEntidad As DataRow,
                                             _EnCurso_Total As Double,
                                             _EnCurso_Cheque As Double,
                                             _EnCurso_Letra As Double,
                                             _EnCurso_Pagare As Double)
        Dim _DsInfCredito As New DataSet

        Dim _Utilizar_NVV_En_Credito_X_Cliente As Boolean = False

        Dim _CodEntidad As String = _RowEntidad.Item("KOEN")
        Dim _SucEntidad As String = _RowEntidad.Item("SUEN")

        Dim _CRSD As Double = _RowEntidad.Item("CRSD")
        Dim _CRCH As Double = _RowEntidad.Item("CRCH")
        Dim _CRLT As Double = _RowEntidad.Item("CRLT")
        Dim _CRPA As Double = _RowEntidad.Item("CRPA")
        Dim _CRTO As Double = _RowEntidad.Item("CRTO")
        Dim _CrNvv_Utilizado As Double

        Consulta_sql = My.Resources.Sql_Entidad.SqlQuery_InfoCreditoEntidad
        Consulta_sql = Replace(Consulta_sql, "#CodEntidad#", _CodEntidad)
        Consulta_sql = Replace(Consulta_sql, "#Base_Bakapp#", _Global_BaseBk)
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", Mod_Empresa)

        Dim _DsCredito As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _DsCredito.Tables(0).TableName = "SinDocumentar"
        _DsCredito.Tables(1).TableName = "Pagos"
        _DsCredito.Tables(2).TableName = "Cheques"
        _DsCredito.Tables(3).TableName = "Letras"
        _DsCredito.Tables(4).TableName = "Pagares"
        _DsCredito.Tables(5).TableName = "Utilizado_NVV"
        _DsCredito.Tables(6).TableName = "Totales"

        Dim _TblSinDocumentar As DataTable = _DsCredito.Tables("SinDocumentar")

        '_TblPagos = _DsCredito.Tables("Pagos")
        Dim _TblCheques As DataTable = _DsCredito.Tables("Cheques")
        Dim _TblLetras As DataTable = _DsCredito.Tables("Letras")
        Dim _TblPagares As DataTable = _DsCredito.Tables("Pagares")
        Dim _TblUtilizado_NVV As DataTable = _DsCredito.Tables("Utilizado_NVV")
        Dim _TblTotales As DataTable = _DsCredito.Tables("Totales")

        Dim _Crsd_Utilizado As Double = _TblTotales.Rows(0).Item("SIN_DOCUMENTAR")
        Dim _CrPgo_Utilizado As Double = _TblTotales.Rows(0).Item("PAGOS")
        Dim _Crch_Utilizado As Double = _TblTotales.Rows(0).Item("CHEQUES")
        Dim _Crlt_Utilizado As Double = _TblTotales.Rows(0).Item("LETRAS")
        Dim _Crpa_Utilizado As Double = _TblTotales.Rows(0).Item("PAGARES")

        If _Utilizar_NVV_En_Credito_X_Cliente Then
            _CrNvv_Utilizado = _TblTotales.Rows(0).Item("NVV")
        End If

        _Crsd_Disponible = _CRSD - (_Crsd_Utilizado + _CrNvv_Utilizado) - _EnCurso_Total
        _Crch_Disponible = _CRCH - (_Crch_Utilizado + _EnCurso_Cheque)
        _Crlt_Disponible = _CRLT - (_Crlt_Utilizado + _EnCurso_Letra)
        _Crpa_Disponible = _CRPA - (_Crpa_Utilizado + _EnCurso_Pagare)

        Dim _Crto_Utilizado As Double = _Crsd_Utilizado + _CrNvv_Utilizado + _Crch_Utilizado + _Crlt_Utilizado + _Crpa_Utilizado

        Dim _CRSF As Double
        Dim _CrPgo_Disponible As Double

        Dim _TblPagos As DataTable

        Sb_Revisar_Saldo_Favor(_TblPagos, _CRSF, _CrPgo_Utilizado, _CrPgo_Disponible, _CodEntidad)

        _Crto_Disponible = _CRTO - (_Crto_Utilizado + _EnCurso_Total + _EnCurso_Cheque + _EnCurso_Letra + _EnCurso_Pagare)
        _Crto_Disponible = _CRTO + _CrPgo_Disponible - (_Crto_Utilizado + _EnCurso_Total + _EnCurso_Cheque + _EnCurso_Letra + _EnCurso_Pagare)

    End Sub
    Sub Sb_Revisar_Saldo_Favor(ByRef _TblPagos As DataTable,
                               ByRef _CRSF As Double,
                               ByRef _CrPgo_Utilizado As Double,
                               ByRef _CrPgo_Disponible As Double,
                               _CodEntidad As String)

        Consulta_sql = "SELECT
DPCE.TIDP AS TIDP,
DPCE.NUDP AS NUDP,
DPCE.NUCUDP AS NUCUDP,
DPCE.FEVEDP AS FEVEDP,
DPCE.ENDP AS ENTIDAD,
convert(char(10),DPCE.FEEMDP,103) AS EMISION,
convert(char(10),DPCE.FEVEDP,103) AS VENCIM,
DPCE.REFANTI AS GLOSA,DPCE.VADP,DPCE.VAASDP,
Isnull((Select Top 1 NOKOENDP From TABENDP Where KOENDP = EMDP),'????') AS BANCO,
DPCE.ESPGDP,
'VALOR' =CASE DPCE.TIMODP WHEN 'E' THEN 0 ELSE DPCE.VADP-DPCE.VAASDP-DPCE.VAVUDP END,
'VALORD'=CASE DPCE.TIMODP WHEN 'E' THEN DPCE.VADP-DPCE.VAASDP-DPCE.VAVUDP ELSE 0 END,
'NOMBRE'=( SELECT TOP 1 EN.NOKOEN FROM MAEEN EN WITH ( NOLOCK ) WHERE EN.KOEN=DPCE.ENDP ) 
Into #Paso
FROM MAEDPCE DPCE WITH ( NOLOCK ) 

WHERE DPCE.TIDP IN ( 'EFV','CHV','TJV','LTV','PAV','ncv','fcv','fdv','DEP','CRV','ATB' )
--AND DPCE.FEEMDP  >= '2010-09-01'
AND DPCE.EMPRESA='" & Mod_Empresa & "'  AND DPCE.ESASDP='P' 
 AND ROUND(DPCE.VADP,2)-ROUND(DPCE.VAASDP,2)-ROUND(DPCE.VAVUDP,2)<>0.0 
 AND DPCE.ENDP='" & _CodEntidad & "'

 Select * From #Paso

 Select Isnull(SUM(VADP),0) As 'CRSF',Isnull(SUM(VAASDP),0) As 'Utilizado',Isnull(Sum(VALOR),0) As 'Disponible'
 From #Paso

 Drop Table #Paso"

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _TblPagos = _Ds.Tables(0)

        _CRSF = _Ds.Tables(1).Rows(0).Item("CRSF")
        _CrPgo_Utilizado = _Ds.Tables(1).Rows(0).Item("Utilizado")
        _CrPgo_Disponible = _Ds.Tables(1).Rows(0).Item("Disponible")

    End Sub

    Function Fx_Llenar_Entidad_CiaSeguros(_Koen As String, _Suen As String) As LsValiciones.Mensajes

        Dim _Tbl As DataTable
        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Consulta_sql = Fx_Consulta_Sql_Entidad_CiaSeguros(_Koen, _Suen)
            _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Consulta realizada correctamente."
            _Mensaje.Tag = _Tbl

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "Error al consultar la información: " & ex.Message
            _Mensaje.Tag = Nothing
        End Try

        Return _Mensaje

    End Function

    Function Fx_Consulta_Sql_Entidad_CiaSeguros(_Koen As String, _Suen As String) As String

        Consulta_sql = $"
DECLARE @ENDO     VARCHAR(20) = '{_Koen}';
DECLARE @SUENDO   VARCHAR(20) = '{_Suen}';

/* =========================================================
   1) DOCUMENTOS NVV y FCV DESDE MAEEDO
========================================================= */
WITH Docs AS
(
    SELECT 
        IDMAEEDO,
        ENDO,
        SUENDO,
        TIDO,
        Saldo = VABRDO - VAABDO
    FROM MAEEDO
    WHERE TIDO IN ('NVV','FCV')
      AND ENDO = @ENDO
      AND SUENDO = @SUENDO
      AND EMPRESA = '{Mod_Empresa}'
      AND (
            (TIDO = 'NVV' AND ESDO = '')
         OR (TIDO = 'FCV' AND ESPGDO = 'P')
      )
),

/* =========================================================
   2) NVVSOL DESDE Zw_Casi_DocEnc (solo válidos)
========================================================= */
NVVSOL_Docs AS
(
    SELECT 
        C.Id_DocEnc,
        C.CodEntidad_Cia,
        C.CodSucEntidad_Cia,
        C.TotalBrutoDoc AS Monto
    FROM {_Global_BaseBk}Zw_Casi_DocEnc AS C
    INNER JOIN {_Global_BaseBk}Zw_Remotas AS R
        ON C.Id_DocEnc = R.Id_Casi_DocEnc
    INNER JOIN {_Global_BaseBk}Zw_Remotas_En_Cadena_01_Enc AS E
        ON R.RCadena_Id_Enc = E.Id_Enc
    WHERE C.Empresa = '{Mod_Empresa}'
      AND C.CodEntidad = @ENDO
      AND C.CodSucEntidad = @SUENDO
      AND C.Stand_by = 0
      AND C.TipoDoc = 'NVV'
      AND C.UsaCiaSeguro = 1
      AND E.Estado = ''
),

/* =========================================================
   3) FCV / NVV CON COMPAÑÍA (Zw_Docu_Ent)
========================================================= */
Docs_Cia AS
(
    SELECT 
        D.CodEntidad_Cia,
        D.CodSucEntidad_Cia,
        M.TIDO,
        M.Saldo
    FROM Docs AS M
    INNER JOIN {_Global_BaseBk}Zw_Docu_Ent AS D
        ON D.Idmaeedo = M.IDMAEEDO
    WHERE D.CodEntidad_Cia <> ''
),

/* =========================================================
   4) AGRUPAR MONTOS POR COMPAÑÍA
========================================================= */
Cias_Usadas AS
(
    SELECT 
        CodEntidad_Cia,
        CodSucEntidad_Cia,
        FCV  = SUM(CASE WHEN TIDO = 'FCV' THEN Saldo ELSE 0 END),
        NVV  = SUM(CASE WHEN TIDO = 'NVV' THEN Saldo ELSE 0 END),
        NVVSOL = 0
    FROM Docs_Cia
    GROUP BY CodEntidad_Cia, CodSucEntidad_Cia

    UNION ALL

    SELECT 
        CodEntidad_Cia,
        CodSucEntidad_Cia,
        FCV = 0,
        NVV = 0,
        NVVSOL = SUM(Monto)
    FROM NVVSOL_Docs
    GROUP BY CodEntidad_Cia, CodSucEntidad_Cia
),

/* =========================================================
   5) SUMAR POR COMPAÑÍA
========================================================= */
Cias_Final AS
(
    SELECT 
        CodEntidad_Cia,
        CodSucEntidad_Cia,
        FCV     = SUM(FCV),
        NVV     = SUM(NVV),
        NVVSOL  = SUM(NVVSOL)
    FROM Cias_Usadas
    GROUP BY CodEntidad_Cia, CodSucEntidad_Cia
),

/* =========================================================
   6) MONTOS ASIGNADOS POR COMPAÑÍA + NOMBRE
========================================================= */
Asignaciones AS
(
    SELECT 
        E.CodEntidad_Cia,
        E.CodSucEntidad_Cia,
        E.MontoAsignado,
        M.NOKOEN AS Nombre_Entidad
    FROM {_Global_BaseBk}Zw_Entidad_CiaSeguro AS E
    LEFT JOIN MAEEN AS M
        ON M.KOEN = E.CodEntidad_Cia
       AND M.SUEN = E.CodSucEntidad_Cia
    WHERE E.CodEntidad = @ENDO
      AND E.CodSucEntidad = @SUENDO
),

/* =========================================================
   7) DOCUMENTOS SIN COMPAÑÍA
========================================================= */
Sin_Cia AS
(
    SELECT 
        'SIN_CIA' AS CodEntidad_Cia,
        '' AS CodSucEntidad_Cia,
        FCV = SUM(CASE WHEN TIDO = 'FCV' THEN Saldo ELSE 0 END),
        NVV = SUM(CASE WHEN TIDO = 'NVV' THEN Saldo ELSE 0 END),
        NVVSOL = 0
    FROM Docs AS D
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM {_Global_BaseBk}Zw_Docu_Ent AS Z
        WHERE Z.Idmaeedo = D.IDMAEEDO
    )
)

/* =========================================================
   8) RESULTADO FINAL (TODO CON NULL→0)
========================================================= */
SELECT 
	ISNULL(A.CodEntidad_Cia,'') AS CodEntidad_Cia,
	ISNULL(A.CodSucEntidad_Cia,'') AS CodSucEntidad_Cia,
    ISNULL(A.Nombre_Entidad, 'SIN COMPAÑÍA') AS NombreCia,
    ISNULL(A.MontoAsignado, 0) AS MontoAsignado,
    ISNULL(F.FCV, 0) AS FCV,
    ISNULL(F.NVV, 0) AS NVV,
    ISNULL(F.NVVSOL, 0) AS NVVSOL,
    TotalUtilizado = ISNULL(F.FCV,0) + ISNULL(F.NVV,0) + ISNULL(F.NVVSOL,0),
    SaldoDisponible = ISNULL(A.MontoAsignado,0) - (ISNULL(F.FCV,0) + ISNULL(F.NVV,0) + ISNULL(F.NVVSOL,0))
FROM Asignaciones AS A
LEFT JOIN Cias_Final AS F
    ON A.CodEntidad_Cia = F.CodEntidad_Cia
   AND A.CodSucEntidad_Cia = F.CodSucEntidad_Cia

UNION ALL

SELECT 
	'','',
    'SIN COMPAÑÍA',
    0,
    ISNULL(FCV,0),
    ISNULL(NVV,0),
    ISNULL(NVVSOL,0),
    ISNULL(FCV,0) + ISNULL(NVV,0) + ISNULL(NVVSOL,0),
    0
FROM Sin_Cia;
"

        Return Consulta_sql

    End Function

End Class
