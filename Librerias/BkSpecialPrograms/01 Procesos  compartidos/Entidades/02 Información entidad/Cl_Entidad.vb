Imports DevComponents.DotNetBar

Public Class Cl_Entidad

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

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
    Public Property ClienteMoroso As Boolean
    Public Property Mensaje As String

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

    End Sub

    Public Function Fx_Entidad_Tiene_Deudas_CtaCte(_RowEntidad As DataRow,
                                                   _Mostrar_Formulario As Boolean,
                                                   _Solicitar_Permiso_Remoto As Boolean) As LsValiciones.Mensajes

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
                _Mensaje.Tag = _Cl_Entidad

                Return _Mensaje

            Else

                '-- ESTA INSTRUCCION CIERRA LOS VENCIMIENTOS QUE YA ESTAN CANCELADOS COMPLETAMENTE
                Dim _Ms As LsValiciones.Mensajes = Fx_Reparar_Maeven(_RowEntidad)

                If Not _Ms.EsCorrecto Then
                    Throw New System.Exception("Error al reparar los vencimientos de la entidad" & vbCrLf & _Ms.Mensaje)
                End If

                ' Dim _Msj As LsValiciones.Mensajes = Fx_Revisar_Deuda_Doc_Entidad(_RowEntidad)

                Dim _Fecha_Tope As Date = FechaDelServidor()
                Dim _Fecha As String = Format(FechaDelServidor, "yyyyMMdd")

                Dim _CodEntidad As String = _RowEntidad.Item("KOEN")
                Dim _Dimoper = _RowEntidad.Item("DIMOPER")

                Consulta_sql = My.Resources.Sql_Entidad.SqlQuery_deuda_doc_comerciales
                Consulta_sql = Replace(Consulta_sql, "#CodEntidad#", _CodEntidad)
                Consulta_sql = Replace(Consulta_sql, "#Fecha#", _Fecha)
                Consulta_sql = Replace(Consulta_sql, "#Empresa#", Mod_Empresa)

                Tbl_Deudas = _Sql.Fx_Get_DataTable(Consulta_sql)

                If CBool(Tbl_Deudas.Rows.Count) Then

                    Dim _Deudas As Integer

                    Dim _MaxDiasDeAtraso As Integer = 0

                    For Each _Fila As DataRow In Tbl_Deudas.Rows

                        Dim _Nudonodefi As Boolean = _Fila.Item("NUDONODEFI")
                        Dim _Dias_Atraso As Integer = _Fila.Item("DIAS_ATRASO")

                        If Not _Nudonodefi Then

                            Dim _DiasDeAtraso As Double = _Dias_Atraso

                            If _RestarDimoper Then
                                _DiasDeAtraso = _Dias_Atraso - _Dimoper
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

                    Consulta_sql = My.Resources.Recursos_Inf.SQLQuery_Informe_de_comportamiento_de_pagos
                    Consulta_sql = Replace(Consulta_sql, "#Filtro_Entidad#", "And ENDO = '" & _Endo & "'")
                    Consulta_sql = Replace(Consulta_sql, "#Filtro_2#", "And TIPO_DOC <> 'NCV'")
                    Consulta_sql = Replace(Consulta_sql, "#Empresa#", Mod_Empresa)

                    Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

                    Dim _Row As DataRow = _Ds.Tables(2).Rows(0)
                    Dim _Row2 As DataRow = _Ds.Tables(3).Rows(0)

                    If Not IsNothing(_Row) Then
                        _Cl_Entidad.PromedioDiasPago = Math.Round(_Row.Item("PROMEDIO_DIAS_REAL_PAGO"), 2)
                    End If

                    If Not IsNothing(_Row2) Then
                        _Cl_Entidad.PromedioUltimas3FacturasPago = Math.Round(_Row2.Item("PROMEDIO_ULTIMAS_3_FACTURAS"), 2)
                    End If

                    ' Guardar el mayor dias de atraso en la instancia que se devuelve

                    _Cl_Entidad.MaxDiasMoraDocumentos = _MaxDiasDeAtraso
                    _Cl_Entidad.Tiene_Deudas = CBool(_Deudas)
                    _Cl_Entidad.Tbl_Deudas = Tbl_Deudas
                    _Cl_Entidad.ClienteMoroso = _Cl_Entidad.Tiene_Deudas

                    Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("MAEEDO", $"TIDO = 'FCV' And ENDO = '{_Endo}' And SUENDO = '{_Suendo}'")

                    _Cl_Entidad.Tiene_Mas_Ventas = IIf(_Reg > 1, True, False)
                    _Cl_Entidad.Promedio_Venta_UltXMeses = Fx_Promedio_Venta_UltXMeses(_RowEntidad, 3)



                    Dim _DiasMaxMora As Double = _Dimoper + 10
                    Dim _MaxDiasMoraDocumentos As Double = _Cl_Entidad.MaxDiasMoraDocumentos

                    If _RevAutomaticaMorosidadClientes Then

                        Dim _DiasMinMora As Double = _Dimoper - _MaxDiasMoraDocumentos

                        If _DiasMinMora > 0 Then
                            _Cl_Entidad.ClienteMoroso = False
                        End If

                    End If

                    If _MaxDiasMoraDocumentos > _DiasMaxMora Then
                        _Cl_Entidad.Mensaje = "No se le puede vender a este cliente hasta que no pague su deuda"
                        _Cl_Entidad.Bloqueada = True
                        _Mensaje.Tag = _Cl_Entidad
                        Throw New System.Exception("Cliente tiene documentos con deudas")
                    End If

                    If _Cl_Entidad.ClienteMoroso AndAlso _Cl_Entidad.PromedioUltimas3FacturasPago > _Dimoper Then

                        _Cl_Entidad.Mensaje = "No se le puede vender a este cliente hasta que no pague su deuda" & vbCrLf &
                                              "Las ultimas 3 facturas han sido pagadas en un promedio de " &
                                              _Cl_Entidad.PromedioUltimas3FacturasPago & " días, solo se permiten hasta " & _Dimoper & " días."
                        _Cl_Entidad.Bloqueada = True
                        _Mensaje.Tag = _Cl_Entidad
                        Throw New System.Exception("Cliente tiene documentos con deudas")
                    End If

                    If Not _Cl_Entidad.ClienteMoroso AndAlso _Cl_Entidad.PromedioUltimas3FacturasPago > _Dimoper Then
                        _Cl_Entidad.ClienteMoroso = True
                    End If

                    _Mensaje.Tag = _Cl_Entidad

                    If _Cl_Entidad.ClienteMoroso Then
                        Throw New System.Exception("Cliente tiene documentos con deudas")
                    End If

                    _Mensaje.EsCorrecto = True
                    _Mensaje.Mensaje = "Cliente sin deudas vencidas"
                    _Mensaje.Icono = MessageBoxIcon.Information

                End If

            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function

    Function Fx_Promedio_Venta_UltXMeses(_RowEntidad As DataRow, _Meses As Integer) As Double

        Consulta_sql = $"
DECLARE @Endo    AS VARCHAR(20) = '{_RowEntidad.Item("KOEN").ToString.Trim}';
DECLARE @Suendo  AS VARCHAR(10) = '{_RowEntidad.Item("SUEN").ToString.Trim}';

SELECT 
    ISNULL(AVG(VentaMensual), 0) AS PROMEDIO_ULT_X_MESES
FROM (
        SELECT 
            DATEFROMPARTS(YEAR(FEEMDO), MONTH(FEEMDO), 1) AS Mes,
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
            DATEFROMPARTS(YEAR(FEEMDO), MONTH(FEEMDO), 1)
    ) AS Tbl;"

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

    'Function Fx_Revisar_Deuda_Doc_Entidad(_RowEntidad As DataRow) As LsValiciones.Mensajes

    '    Dim _Mensaje As New LsValiciones.Mensajes

    '    Try

    '        Dim _Fecha_Tope As Date = FechaDelServidor()
    '        Dim _Fecha As String = Format(FechaDelServidor, "yyyyMMdd")

    '        Dim _CodEntidad As String = _RowEntidad.Item("KOEN")
    '        Dim _Dimoper = _RowEntidad.Item("DIMOPER")

    '        Consulta_sql = My.Resources.Sql_Entidad.SqlQuery_deuda_doc_comerciales
    '        Consulta_sql = Replace(Consulta_sql, "#CodEntidad#", _CodEntidad)
    '        Consulta_sql = Replace(Consulta_sql, "#Fecha#", _Fecha)
    '        Consulta_sql = Replace(Consulta_sql, "#Empresa#", Mod_Empresa)

    '        Dim _TblDeuda As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

    '        If CBool(_TblDeuda.Rows.Count) Then

    '            Dim _Deudas As Integer

    '            For Each _Fila As DataRow In _TblDeuda.Rows

    '                Dim _Nudonodefi As Boolean = _Fila.Item("NUDONODEFI")
    '                Dim _Dias_Atraso As Integer = _Fila.Item("DIAS_ATRASO")

    '                If Not _Nudonodefi Then
    '                    Dim _DiasDeAtraso = _Dias_Atraso - _Dimoper
    '                    If _DiasDeAtraso >= 0 Then
    '                        _Deudas += 1
    '                    End If
    '                End If

    '            Next

    '            _Mensaje.Tag = _TblDeuda

    '            If CBool(_Deudas) Then
    '                Throw New System.Exception("Cliente tiene documentos con deudas")
    '            End If

    '            _Mensaje.EsCorrecto = True
    '            _Mensaje.Mensaje = "Cliente sin deudas vencidas"
    '            _Mensaje.Icono = MessageBoxIcon.Information

    '        End If

    '    Catch ex As Exception
    '        _Mensaje.EsCorrecto = False
    '        _Mensaje.Mensaje = ex.Message
    '        _Mensaje.Icono = MessageBoxIcon.Error
    '    End Try

    '    Return _Mensaje

    'End Function

End Class
