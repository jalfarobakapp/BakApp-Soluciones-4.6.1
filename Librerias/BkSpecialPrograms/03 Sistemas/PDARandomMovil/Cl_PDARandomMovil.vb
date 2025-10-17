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


    Function Fx_Importar_NVV_Desde_PDARandomMOVIL_NVVAuto(_Row_Pdaenca As DataRow) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _Idpdaenca As Integer = _Row_Pdaenca.Item("IDPDAENCA")
            Dim _Empresa As String = _Row_Pdaenca.Item("EMPRESA")
            Dim _Endo As String = _Row_Pdaenca.Item("ENDO")
            Dim _Nudo As String = _Row_Pdaenca.Item("NUDO")

            Consulta_sql = $"
DECLARE @IdEnc INT;

Update PDAENCA Set VALIDO = 'B' Where IDPDAENCA = {_Idpdaenca};

-- Insertar encabezado y capturar el Id autogenerado
INSERT INTO {_Global_BaseBk}Zw_Demonio_NVVAuto (
    IdmaeedoOCC_Ori, NudoOCC_Ori, Endo_Ori, Suendo_Ori, FechaGrab,
    GenerarNVV, NVVGenerada, Idmaeedo_NVV, Nudo_NVV, Feemdo_NVV,
    Observaciones, TipoOri, Ocdo, Facturar, DocEmitir, CodFuncionario_Factura, EnvFacAutoBk, Empresa,  Feer_NVV
)
SELECT 
    IDPDAENCA, NUDO, ENDO, SUENDO, GETDATE(),
    1, 0, 0, '', FEEMDO,
    '', 'PDAENCA', '', 0, 'SOL', KOFUDO, 0, EMPRESA,FEER
FROM PDAENCA
WHERE IDPDAENCA = {_Idpdaenca};

-- Capturar el Id generado
SET @IdEnc = SCOPE_IDENTITY();

-- Insertar detalle usando el Id capturado
INSERT INTO {_Global_BaseBk}Zw_Demonio_NVVAutoDet (
    Id_Enc, Idmaeddo_Ori, Codigo, Cantidad, Untrans, Descripcion,
    Empresa, Sucursal, Bodega, CantidadDefinitiva, Precio,
    Kofulido, Prct, Tict
)
SELECT 
    @IdEnc, IDPDADETA, KOPR,
    CASE UDTRPR WHEN 1 THEN CAPRCO1 ELSE CAPRCO2 END,
    UDTRPR, NOKOPR,
    '{_Empresa}', SULIDO, BOSULIDO,
    CASE UDTRPR WHEN 1 THEN CAPRCO1 ELSE CAPRCO2 END,
    PPPRNE, KOFULIDO, 0, ''
FROM PDADETA
WHERE IDPDAENCA = {_Idpdaenca};

Update PDAENCA Set VALIDO = 'b' Where IDPDAENCA = {_Idpdaenca}"

            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then

                _Mensaje.Detalle = "Problemas al importar la pre-venta desde PDA Random MOVIL para el Número: " & _Nudo
                Throw New InvalidOperationException(_Sql.Pro_Error)

            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = String.Empty
            _Mensaje.Mensaje = "Se ha importado la pre-venta desde PDA Random MOVIL para el Número: " & _Nudo
            _Mensaje.Id = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_NVVAuto", "Id_Enc", "IdmaeedoOCC_Ori = " & _Idpdaenca)
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function

    Function Fx_Crear_NVV_PDARandomMOVIL(_Row_Pdaenca As DataRow, _Modalidad As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _Idpdaenca As Integer = _Row_Pdaenca.Item("IDPDAENCA")

            Consulta_sql = "Update PDAENCA Set VALIDO = 'B' Where IDPDAENCA = " & _Idpdaenca
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New InvalidOperationException(_Sql.Pro_Error)
            End If

            'Consulta_sql = "Select * From PDAENCA Where Id_Enc = " & _Idpdaenca
            'Dim _Row_Encabezado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            'If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then Throw New InvalidOperationException(_Sql.Pro_Error)

            'If IsNothing(_Row_Encabezado) Then
            '    Throw New InvalidOperationException("No se encuentra el Id_Enc = " & _Idpdaenca & " en la tabla PDAENCA")
            'End If

            Dim _Empresa As String = _Row_Pdaenca.Item("EMPRESA")
            Dim _Endo As String = _Row_Pdaenca.Item("ENDO")
            Dim _Suendo As String = _Row_Pdaenca.Item("SUENDO")
            Dim _Nudo As String = _Row_Pdaenca.Item("NUDO")
            Dim _CodFuncionario As String = _Row_Pdaenca.Item("KOFUDO")
            Dim _Tido As String = "NVV"
            Dim _FechaEmision As DateTime = _Row_Pdaenca.Item("FEEMDO")
            'Dim _FechaRecepcion As DateTime = _Row_Pdaenca.Item("FEERDO")

            Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Endo & "' And SUEN = '" & _Suendo & "'"
            Dim _Row_Entidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then Throw New InvalidOperationException(_Sql.Pro_Error)

            If IsNothing(_Row_Entidad) Then
                Throw New InvalidOperationException("No se encuentra la entidad: " & _Endo.ToString.Trim & "-" & _Suendo.ToString.Trim)
            End If

            Consulta_sql = "SELECT KOPR As 'Codigo'," & vbCrLf &
                           "CASE UDTRPR WHEN 1 THEN CAPRCO1 ELSE CAPRCO2 END As Cantidad," & vbCrLf &
                           "UDTRPR, NOKOPR,'" & _Empresa & "' As Empresa,SULIDO As Sucursal,BOSULIDO As Bodega,PPPRBR As Precio,'' As 'Observacion'" & vbCrLf &
                           "FROM PDADETA" & vbCrLf &
                           "WHERE IDPDAENCA = " & _Idpdaenca
            Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New InvalidOperationException(_Sql.Pro_Error)
            End If

            If _Tbl_Productos.Rows.Count = 0 Then
                Throw New InvalidOperationException("No se encuentran registros para la tabla PDADETA con el IDPDAENCA = " & _Idpdaenca)
            End If

            Consulta_sql = "Select * From CONFIEST With (NOLOCK) Where EMPRESA = '" & Mod_Empresa & "' And MODALIDAD = '" & _Modalidad & "'"
            Dim _Row_Modalidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New InvalidOperationException(_Sql.Pro_Error)
            End If

            Dim Fm As New Frm_Formulario_Documento(_Tido,
                                                   csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta,
                                                   False, False, False, False, False)
            Fm.Sb_Limpiar(_Modalidad)
            Fm.Pro_RowEntidad = _Row_Entidad
            Fm.ChkValores.Checked = True
            Fm.Sb_Crear_Documento_Interno_Con_Tabla(Nothing, _Tbl_Productos, _FechaEmision,
                                                    "Codigo", "Cantidad", "Precio", "Observacion",
                                                    False, False, _Nudo,,,,,, False, False,, False, True)
            'CodFuncionario_Autoriza
            Dim _Mensaje_RevPermisos As LsValiciones.Mensajes = Fm.Fx_Revisar_Permisos_Necesarios_Del_Documento_NVVAuto(_CodFuncionario, False)

            If _Mensaje_RevPermisos.EsCorrecto Then

                Dim _Mensaje2 As LsValiciones.Mensajes = Fm.Fx_Grabar_Documento(False,, False)
                Fm.Dispose()

                Return _Mensaje2

            Else

                Dim _Cl_RemotasEnCadena As Cl_RemotasEnCadena = _Mensaje_RevPermisos.Tag
                Dim _Ds_Matriz_Documentos As Ds_Matriz_Documentos = _Cl_RemotasEnCadena.Ds_Matriz_Documentos

                Dim _Tbl_Encabezado As DataTable = _Ds_Matriz_Documentos.Tables(4)

                With _Tbl_Encabezado.Rows(0)
                    .Item("PdaRMovil") = True
                    .Item("Idpdaenca") = _Idpdaenca
                    .Item("ConservaNudo") = True
                End With


                ' CREAMOS EL DOCUMENTO DE PASO
                Dim _Crear_Doc As New Clase_Crear_Documento

                Dim _Id_DocEnc As Integer = _Crear_Doc.Fx_Crear_Documento_En_BakApp_Casi(_Ds_Matriz_Documentos, False, False)

                If CBool(_Id_DocEnc) Then

                    Dim _Nro_RCadena = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc",
                                               "COALESCE(MAX(Nro_RCadena),'0000000000')")
                    If _Nro_RCadena = "0000000000" Then
                        _Nro_RCadena = "RC00000000"
                    End If

                    _Nro_RCadena = Fx_Proximo_NroDocumento(_Nro_RCadena, 10)

                    With _Cl_RemotasEnCadena.Zw_Remotas_En_Cadena_01_Enc

                        .Nro_RCadena = _Nro_RCadena
                        .Id_DocEnc = _Id_DocEnc
                        .Id_Enc = _Idpdaenca
                        .Usuario_Solicita = _CodFuncionario

                    End With

                    For Each _Det As Zw_Remotas_En_Cadena_02_Det In _Cl_RemotasEnCadena.Ls_Zw_Remotas_En_Cadena_02_Det
                        _Det.Nro_RCadena = _Nro_RCadena
                        _Det.NroRemota = String.Empty
                    Next

                    Dim _NroRemota As String

                    Dim _Det1 As Zw_Remotas_En_Cadena_02_Det
                    _Det1 = _Cl_RemotasEnCadena.Ls_Zw_Remotas_En_Cadena_02_Det.Item(0)

                    Dim _Usuario_Solicita = _Cl_RemotasEnCadena.Zw_Remotas_En_Cadena_01_Enc.Usuario_Solicita
                    Dim _CodPermiso = _Det1.CodPermiso
                    Dim _Descripcion_Permiso = _Det1.Descripcion
                    Dim _Koen = _Cl_RemotasEnCadena.Zw_Remotas_En_Cadena_01_Enc.CodEntidad
                    Dim _Nokoen = _Cl_RemotasEnCadena.Zw_Remotas_En_Cadena_01_Enc.Nombre_Entidad

                    _NroRemota = Fx_Solicitar_Remota(_Usuario_Solicita,
                                         _CodPermiso,
                                         _Descripcion_Permiso,
                                         _Id_DocEnc,
                                         _Koen,
                                         _Nokoen, False, "")

                    _Det1.NroRemota = _NroRemota

                    If _Cl_RemotasEnCadena.Ls_Zw_Remotas_En_Cadena_02_Det.Count = 1 Then

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Remotas Set Crear_Doc_Def_Al_Grabar = 1" & vbCrLf &
                                       "Where NroRemota = '" & _NroRemota & "'"
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                    End If

                    _Cl_RemotasEnCadena.Fx_Cadena_Remotas_Crear_Cadena()

                End If

            End If

            'Dim _Mensaje2 As LsValiciones.Mensajes = Fm.Fx_Grabar_Documento(False,, False)
            'Fm.Dispose()

            'Fm.Sb_Actualizar_Permisos_Necesarios_Del_Documento_New()


            'If _Mensaje2.EsCorrecto Then

            '    'Dim _Cl_Imprimir As New Cl_Enviar_Impresion_Diablito
            '    '_Cl_Imprimir.Fx_Enviar_Impresion_Al_Diablito(Mod_Empresa, Mod_Modalidad, _Mensaje2.Id)

            '    Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _Mensaje2.Id
            '    Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            '    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Demonio_NVVAuto Set " &
            '                   "NVVGenerada = 1" &
            '                   ",Idmaeedo_NVV = " & _Row.Item("IDMAEEDO") &
            '                   ",Nudo_NVV = '" & _Row.Item("NUDO") & "'" &
            '                   ",Feemdo_NVV = '" & Format(_Row.Item("FEEMDO"), "yyyyMMdd") & "'" & vbCrLf &
            '                    "Where Id_Enc = " & _Idpdaenca
            '    _Sql.Ej_consulta_IDU(Consulta_sql, False)

            '    _Mensaje.EsCorrecto = True
            '    _Mensaje.Id = _Mensaje2.Id
            '    _Mensaje.Tag = _Row

            'End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
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
