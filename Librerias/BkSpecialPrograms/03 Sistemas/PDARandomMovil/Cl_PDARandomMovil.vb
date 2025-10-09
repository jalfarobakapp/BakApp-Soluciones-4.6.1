
Imports OfficeOpenXml.FormulaParsing.LexicalAnalysis

Public Class Cl_PDARandomMovil

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

    End Sub

    Function Fx_RevisarSituacionComercialCliente(_Row_Pdaenca As DataRow, _Fecha As Date) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            'STOCKSUP,DSCTOSUP,CRDTOSUP,MOROSISUP
            Dim _Pda_Pdaenca_Rev As New PDARevision.Pda_Pdaenca_Rev

            Dim _Idpdaenca As Integer = _Row_Pdaenca.Item("IDPDAENCA")
            Dim _Empresa As String = _Row_Pdaenca.Item("EMPRESA")
            Dim _Endo As String = _Row_Pdaenca.Item("ENDO")
            Dim _Nudo As String = _Row_Pdaenca.Item("NUDO")

            Consulta_sql = "Select Top 1 NOKOEN,CRTO,CRSD,CRLT,CRCH,CRPA,NOTRAEDEUD,BLOQUEADO,DIMOPER,LVEN" & vbCrLf &
                           "From MAEEN With (Nolock)" & vbCrLf &
                           "Where KOEN='" & _Endo & "' And TIPOSUC='P'"
            Dim _Row_Maeen As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            _Pda_Pdaenca_Rev.Cliente_Bloqueado = _Row_Maeen.Item("BLOQUEADO")

            Dim _Kolt As String = _Row_Maeen.Item("LVEN").ToString.Replace("TABPP", "")

            Consulta_sql = "SELECT EDO.TIDO, EDO.MODO, EDO.TIMODO, EDO.TAMODO, EDO.ESPGDO, EDO.FEULVEDO," & vbCrLf &
                           "ROUND(EDO.VABRDO,2) AS VABRDO, ROUND(EDO.VAABDO,2) AS VAABDO,ROUND(EDO.VAIVARET,2) AS VAIVARET," & vbCrLf &
                           "ROUND(EDO.VAIVDO,2) AS VAIVDO, ROUND(EDO.VANEDO,2) AS VANEDO," & vbCrLf &
                           "( SELECT TOP 1 VAMO FROM TABMO WHERE KOMO='US$' ) AS TASAVIGE" & vbCrLf &
                           "FROM MAEEDO AS EDO WITH (NOLOCK) " & vbCrLf &
                           "WHERE EDO.ENDO='" & _Endo & "'" & vbCrLf &
                           "AND EDO.TIDO IN  ('BLV','BSV','BLX','FCV','FDB','FDV','FDX','FDZ','FEV','FVL','FVT','FVX','FXV','FYV','FVZ'," &
                           "'RIN','ESC','FEE','FDE','NCC','NCB')" & vbCrLf &
                           "AND EDO.ESPGDO = 'P'" & vbCrLf &
                           "AND EDO.NUDONODEFI = 0  " & vbCrLf &
                           "AND EDO.EMPRESA = '" & _Empresa & "'" & vbCrLf &
                           "ORDER BY EDO.TIDO,EDO.NUDO "
            Dim _Tbl_Documentos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If _Tbl_Documentos.Rows.Count Then
                _Pda_Pdaenca_Rev.Cliente_Con_Morosidad = True
                _Row_Pdaenca.Item("MOROSISUP") = True
            End If

            Consulta_sql = "SELECT SUM(ROUND(VEN.VAVE,2)-ROUND(VEN.VAABVE,2)) AS SALDOVEN" & vbCrLf &
                           "FROM MAEEDO AS EDO WITH (NOLOCK)" & vbCrLf &
                           "INNER JOIN MAEVEN AS VEN ON VEN.IDMAEEDO=EDO.IDMAEEDO" & vbCrLf &
                           "AND VEN.FEVE<='" & Format(_Fecha, "yyyyMMdd") & "' AND VEN.ESPGVE=' '" & vbCrLf &
                           "WHERE EDO.ENDO='" & _Endo & "'  AND EDO.TIDO IN  ('BLV','BSV','BLX','FCV','FDB','FDV','FDX','FDZ','FEV','FVL'," &
                           "'FVT','FVX','FXV','FYV','FVZ','RIN','ESC','FEE','FDE','NCC','NCB')" & vbCrLf &
                           "And EDO.EMPRESA = '" & _Empresa & "' AND EDO.ESPGDO = 'P' AND EDO.NUDONODEFI = 0"
            Dim _Row_Saldo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Saldo) Then
                _Pda_Pdaenca_Rev.Cliente_Con_Morosidad = True
                _Row_Pdaenca.Item("MOROSISUP") = True
            End If

            Consulta_sql = "SELECT DPCE.IDMAEDPCE,DPCE.EMPRESA,DPCE.TIDP, DPCE.NUDP, DPCE.ENDP, DPCE.EMDP, DPCE.SUEMDP, DPCE.CUDP," &
                           "DPCE.NUCUDP, DPCE.FEEMDP, DPCE.FEVEDP, DPCE.MODP, DPCE.TIMODP, DPCE.TAMODP," & vbCrLf &
                           "DPCE.VADP, DPCE.VAABDP, DPCE.VAASDP, DPCE.VAVUDP, DPCE.ESPGDP, DPCE.REFANTI" & vbCrLf &
                           "FROM MAEDPCE AS DPCE WITH (NOLOCK)" & vbCrLf &
                           "WHERE DPCE.ENDP = '" & _Global_BaseBk & "'" & vbCrLf &
                           "AND DPCE.TIDP IN  ('ATB','CHV','CPV','CRV','DEP','EFV','LTV','PAV','RBV','RGV','RIV','TJV','VUE')" & vbCrLf &
                           "AND ( DPCE.ESPGDP = 'P' OR DPCE.ESPGDP = 'R' )" & vbCrLf &
                           "AND DPCE.EMPRESA = '" & _Empresa & "'"
            Dim _Tbl_Pagos1 As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Consulta_sql = "SELECT DPCE.IDMAEDPCE,DPCE.EMPRESA,DPCE.TIDP, DPCE.NUDP, DPCE.ENDP, DPCE.EMDP, DPCE.SUEMDP, DPCE.CUDP," &
                           "DPCE.NUCUDP, DPCE.FEEMDP, DPCE.FEVEDP, DPCE.MODP, DPCE.TIMODP, DPCE.TAMODP," & vbCrLf &
                           "DPCE.VADP, DPCE.VAABDP, DPCE.VAASDP, DPCE.VAVUDP, DPCE.ESPGDP, DPCE.REFANTI , DPCE.ARCHIRSD , DPCE.IDRSD" & vbCrLf &
                           "FROM MAEDPCE AS DPCE WITH (NOLOCK)" & vbCrLf &
                           "WHERE DPCE.ENDP = '" & _Empresa & "'" & vbCrLf &
                           "AND DPCE.TIDP IN  ('ATB','CHV','CPV','CRV','DEP','EFV','LTV','PAV','RBV','RGV','RIV','TJV','VUE')" & vbCrLf &
                           "AND DPCE.ESASDP = 'P'" & vbCrLf &
                           "AND DPCE.ESPGDP<> 'N'" & vbCrLf &
                           "AND DPCE.EMPRESA = '" & _Empresa & "'"
            Dim _Tbl_Pagos2 As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Consulta_sql = "Select * From PDADETA Where IDPDAENCA = " & _Idpdaenca
            Dim _Tbl_Pdadeta As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
            Dim _ItemConDscto As Integer = 0

            ' Revisar precios
            For Each _Fila As DataRow In _Tbl_Pdadeta.Rows

                Dim _Codigo As String = _Fila.Item("KOPR")
                Dim _Udtrpr As Integer = _Fila.Item("UDTRPR")
                Dim _Ppprne As Double = _Fila.Item("PPPRNE")
                Dim _Ppprbr As Double = _Fila.Item("PPPRBR")
                Dim _Vaneli As Double = _Fila.Item("VANELI")
                Dim _Vabrli As Double = _Fila.Item("VABRLI")
                Dim _Dctoven As Double = _Fila.Item("DCTOVEN")
                Dim _Cantidad As Double = IIf(_Udtrpr = 1, _Fila.Item("CAPRCO1"), _Fila.Item("CAPRCO2"))

                Consulta_sql = "Select Top 1 *,(Select top 1 MELT From TABPP Where KOLT = '" & _Kolt & "') as MELT From TABPRE" & vbCrLf &
                               "Where KOLT = '" & _Kolt & "' And KOPR = '" & _Codigo & "'"
                Dim _RowPrecios As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Consulta_sql = "Select  * From TABPP Where KOLT = '" & _Kolt & "'"
                Dim _RowTabpp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Ecuacion As String = _RowPrecios.Item("ECUACION").ToString.Trim
                Dim _Ecuacionu2 As String = _RowPrecios.Item("ECUACIONU2").ToString.Trim

                Dim _PrecioListaUd1 As Double = Fx_Funcion_Ecuacion_Random(Nothing, _Endo, _Ecuacion, _Codigo, 1, _RowPrecios, 0, 0, 0, False)
                Dim _PrecioListaUd2 As Double = Fx_Funcion_Ecuacion_Random(Nothing, _Endo, _Ecuacionu2, _Codigo, 2, _RowPrecios, 0, 0, 0, False)
                Dim _PrecioFinal As Double = IIf(_Udtrpr = 1, _PrecioListaUd1, _PrecioListaUd2)

                Dim _Total_Calculado As Double = _PrecioFinal * _Cantidad
                Dim _Total_Documento As Double

                _Total_Documento = IIf(_RowTabpp.Item("MELT") = "N", _Vaneli, _Vabrli)

                If _Total_Calculado > _Total_Documento Then

                    Dim _PorcDescuentoAplicado As Double = 0
                    If _Total_Calculado <> 0 Then
                        _PorcDescuentoAplicado = Math.Round((1 - (_Total_Documento / _Total_Calculado)) * 100, 2)
                    Else
                        _PorcDescuentoAplicado = 0
                    End If

                    If _PorcDescuentoAplicado >= 0.05 Then
                        _ItemConDscto += 1
                    End If

                End If

            Next

            If _ItemConDscto > 0 Then
                _Pda_Pdaenca_Rev.Descuento_Superado = True
            End If

            ' Revisar stock
            For Each _Fila As DataRow In _Tbl_Pdadeta.Rows

                Dim _Codigo As String = _Fila.Item("KOPR")
                Dim _Udtrpr As Integer = _Fila.Item("UDTRPR")
                Dim _Sucursal As String = _Fila.Item("SULIDO")
                Dim _Bodega As String = _Fila.Item("BOSULIDO")
                Dim _Cantidad As Double = IIf(_Udtrpr = 1, _Fila.Item("CAPRCO1"), _Fila.Item("CAPRCO2"))

                Dim _Stock_Disponible As Double = Fx_Stock_Disponible("NVV", _Empresa, _Sucursal, _Bodega, _Codigo, _Udtrpr, "STFI" & _Udtrpr)

                '_Stock_Disponible = 1 + _Cantidad

                Dim _Stock As Double = _Sql.Fx_Trae_Dato("MAEST", "STFI" & _Udtrpr,
                                                         "EMPRESA = '" & _Empresa &
                                                         "' AND KOSU = '" & _Sucursal &
                                                         "' AND KOBO = '" & _Bodega &
                                                         "' AND KOPR = '" & _Codigo & "'", True)

                Dim _Cantidad_Resul As Double = _Stock_Disponible - _Cantidad
                Dim _Stock_Suficiente As Boolean = False

                If _Stock_Disponible <= 0 Then
                    _Stock_Suficiente = False
                Else
                    If _Stock_Disponible - _Cantidad >= 0 Then
                        _Stock_Suficiente = True
                    End If
                End If

                If Not _Stock_Suficiente Then
                    _Pda_Pdaenca_Rev.Stock_Insificiente = True
                    Exit For
                End If

            Next

            _Mensaje.EsCorrecto = True
            _Mensaje.Tag = _Pda_Pdaenca_Rev

            'Bkp00015 Permiso por Stock Insuficiente
            'Bkp00019 Permiso por Morosidad
            'Bkp00062 Permisos por total minimo de venta
            'Bkp00063 Permisos por cupo de credito exedido
            'Doc00098 Fecha de credito vigente
            'Bkp00039 Permisos por descuento exedido
            'Bkp00057 Fecha de despacho invalida
            'Bkp00021 Permiso vender entidad bloqueada

        Catch ex As Exception


        End Try

        Return _Mensaje

    End Function

End Class

Namespace PDARevision
    Class Pda_Pdaenca_Rev

        Public Property Stock_Insificiente As Boolean
        Public Property Descuento_Superado As Boolean
        Public Property Credito_Superado As Boolean
        Public Property Cliente_Con_Morosidad As Boolean
        Public Property Fecha_Credito_Vigente As Boolean
        Public Property Cliente_Bloqueado As Boolean
    End Class
End Namespace
