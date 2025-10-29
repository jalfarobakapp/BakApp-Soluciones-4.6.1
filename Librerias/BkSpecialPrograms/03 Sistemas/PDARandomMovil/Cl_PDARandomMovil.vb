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

    Function Fx_Crear_NVV_PDARandomMOVIL(_Zw_Pda2NVV As Zw_Pda2NVV, _Modalidad As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            ' Revisamos que el numero de la nota de venta no exista
            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("MAEEDO", "TIDO = 'NVV' And NUDO = '" & _Zw_Pda2NVV.Numero & "'")

            If CBool(_Reg) Then
                _Mensaje.HuboOtroError = True
                Throw New InvalidOperationException("El número de la nota de venta " & _Zw_Pda2NVV.Numero & " ya existe en el sistema")
            End If

            ' Marcamos la pre-venta como "borrada" para que no pueda ser utilizada mientras se crea el documento
            Consulta_sql = "Update PDAENCA Set VALIDO = 'B' Where IDPDAENCA = " & _Zw_Pda2NVV.Idpdaenca
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                _Mensaje.HuboOtroError = True
                Throw New InvalidOperationException(_Sql.Pro_Error)
            End If

            Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Zw_Pda2NVV.CodEntidad & "' And SUEN = '" & _Zw_Pda2NVV.CodSucEntidad & "'"
            Dim _Row_Entidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then Throw New InvalidOperationException(_Sql.Pro_Error)

            If IsNothing(_Row_Entidad) Then
                _Mensaje.HuboOtroError = True
                Throw New InvalidOperationException("No se encuentra la entidad: " & _Zw_Pda2NVV.CodEntidad.ToString.Trim & "-" & _Zw_Pda2NVV.CodSucEntidad.ToString.Trim)
            End If

            ' Se extraen los productos de la pre-venta para armar el documento NVV o permiso de venta remota
            Consulta_sql = "SELECT KOPR As 'Codigo'," & vbCrLf &
                           "CASE UDTRPR WHEN 1 THEN CAPRCO1 ELSE CAPRCO2 END As Cantidad," & vbCrLf &
                           "UDTRPR, NOKOPR,'" & _Zw_Pda2NVV.Empresa & "' As Empresa,SULIDO As Sucursal,BOSULIDO As Bodega,PPPRBR As Precio,'' As 'Observacion'" & vbCrLf &
                           "FROM PDADETA" & vbCrLf &
                           "WHERE IDPDAENCA = " & _Zw_Pda2NVV.Idpdaenca
            Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New InvalidOperationException(_Sql.Pro_Error)
            End If

            If _Tbl_Productos.Rows.Count = 0 Then
                _Mensaje.HuboOtroError = True
                Throw New InvalidOperationException("No se encuentran registros para la tabla PDADETA con el IDPDAENCA = " & _Zw_Pda2NVV.Idpdaenca)
            End If

            Consulta_sql = "Select * From CONFIEST With (NOLOCK) Where EMPRESA = '" & Mod_Empresa & "' And MODALIDAD = '" & _Modalidad & "'"
            Dim _Row_Modalidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                _Mensaje.HuboOtroError = True
                Throw New InvalidOperationException(_Sql.Pro_Error)
            End If

            ' Se crea el documento
            Dim Fm As New Frm_Formulario_Documento("NVV",
                                                   csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta,
                                                   False, False, False, False, False)
            Fm.Sb_Limpiar(_Modalidad)
            Fm.Pro_RowEntidad = _Row_Entidad
            Fm.ChkValores.Checked = True
            Fm.Sb_Crear_Documento_Interno_Con_Tabla(Nothing, _Tbl_Productos, _Zw_Pda2NVV.FechaEmision,
                                                    "Codigo", "Cantidad", "Precio", "Observacion",
                                                    False, False, _Zw_Pda2NVV.Numero,,,,,, False, False,, False, True)

            ' Se revisan los permisos necesarios para grabar el documento
            Dim _Mensaje_RevPermisos As LsValiciones.Mensajes = Fm.Fx_Revisar_Permisos_Necesarios_Del_Documento_NVVAuto(_Zw_Pda2NVV.CodFuncionario, False)

            Dim _Cl_RemotasEnCadena As Cl_RemotasEnCadena
            Dim _Ds_Matriz_Documentos As Ds_Matriz_Documentos

            ' Si existe la clase de remotas en cadena la usamos para grabar el documento para el permiso remoto
            If Not IsNothing(_Mensaje_RevPermisos.Tag) Then

                _Cl_RemotasEnCadena = _Mensaje_RevPermisos.Tag
                _Ds_Matriz_Documentos = _Cl_RemotasEnCadena.Ds_Matriz_Documentos

                Dim _Tbl_Encabezado As DataTable = _Ds_Matriz_Documentos.Tables(4)

                With _Tbl_Encabezado.Rows(0)
                    .Item("PdaRMovil") = True
                    .Item("Idpdaenca") = _Zw_Pda2NVV.Idpdaenca
                    .Item("ConservaNudo") = True
                End With

            End If

            ' Si es correcto, se graba el documento
            If _Mensaje_RevPermisos.EsCorrecto Then

                Dim _Mensaje2 As LsValiciones.Mensajes = Fm.Fx_Grabar_Documento(False,, False)
                Fm.Dispose()

                _Zw_Pda2NVV.Idmaeedo = _Mensaje2.Id
                _Zw_Pda2NVV.Estado = "NVVGenerada"
                _Zw_Pda2NVV.NVVGenerada = True

                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "Documento creado correctamente"
                _Mensaje.Mensaje = "NVV Generada"
                _Mensaje.Icono = MessageBoxIcon.Information
                _Mensaje.Tag = _Zw_Pda2NVV

            Else

                ' Se crea el documento para el permiso remoto
                Dim _Crear_Doc As New Clase_Crear_Documento

                Dim _Id_DocEnc As Integer = _Crear_Doc.Fx_Crear_Documento_En_BakApp_Casi(_Ds_Matriz_Documentos, False, False)

                ' Una vez creado el documento de permiso remoto, se crea la cadena de remotas
                If CBool(_Id_DocEnc) Then

                    Dim _Nro_RCadena = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc",
                                               "COALESCE(MAX(Nro_RCadena),'0000000000')")
                    If _Nro_RCadena = "0000000000" Then
                        _Nro_RCadena = "RC00000000"
                    End If

                    _Nro_RCadena = Fx_Proximo_NroDocumento(_Nro_RCadena, 10)

                    ' Se actualizan los datos de encabezado y detalle de la cadena de remotas para hacer el enlace con el permiso remoto
                    With _Cl_RemotasEnCadena.Zw_Remotas_En_Cadena_01_Enc

                        .Nro_RCadena = _Nro_RCadena
                        .Id_DocEnc = _Id_DocEnc
                        '.Id_Enc = _Idpdaenca
                        .Usuario_Solicita = _Zw_Pda2NVV.CodFuncionario

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

                    ' Se crea el permiso remoto
                    _NroRemota = Fx_Solicitar_Remota(_Usuario_Solicita,
                                         _CodPermiso,
                                         _Descripcion_Permiso,
                                         _Id_DocEnc,
                                         _Koen,
                                         _Nokoen, False, "")

                    _Det1.NroRemota = _NroRemota

                    ' Se graba la cadena de remotas
                    _Cl_RemotasEnCadena.Fx_Cadena_Remotas_Crear_Cadena()

                    _Zw_Pda2NVV.RCadena_Id_Enc = _Cl_RemotasEnCadena.Zw_Remotas_En_Cadena_01_Enc.Id_Enc
                    _Zw_Pda2NVV.RCadena = True
                    _Zw_Pda2NVV.Nro_RCadena = _Nro_RCadena
                    _Zw_Pda2NVV.Estado = "SolPermiso"
                    _Zw_Pda2NVV.NecesitaPermiso = True

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Remotas Set " & vbCrLf &
                                   "RCadena = 1" &
                                   ",RCadena_Id_Enc = " & _Cl_RemotasEnCadena.Zw_Remotas_En_Cadena_01_Enc.Id_Enc &
                                   ",Nro_RCadena = '" & _Cl_RemotasEnCadena.Zw_Remotas_En_Cadena_01_Enc.Nro_RCadena & "'" & vbCrLf &
                                   "Where NroRemota = '" & _NroRemota & "'"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    ' Si solo hay un permiso remoto en la cadena, se marca para que cree el documento al grabar
                    If _Cl_RemotasEnCadena.Ls_Zw_Remotas_En_Cadena_02_Det.Count = 1 Then

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Remotas Set Crear_Doc_Def_Al_Grabar = 1" & vbCrLf &
                                       "Where NroRemota = '" & _NroRemota & "'"
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                    End If

                    _Mensaje.Detalle = "Se envia a solicitud de permisos remotos"
                    _Mensaje.Mensaje = "Pre-Venta con observaciones"
                    _Mensaje.Tag = _Zw_Pda2NVV

                End If

            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error al ejecutar la acción"
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function

    Function Fx_Llenar_Zw_Pda2NVV(_Id As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Zw_Pda2NVV As New Zw_Pda2NVV

        Try

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pda2NVV Where Id = " & _Id
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row) Then
                _Mensaje.Detalle = "No se encontro registro"
                Throw New System.Exception("No se encontro el registro en la tabla de Zw_Pda2NVV con el Id = " & _Id)
            End If

            With _Zw_Pda2NVV

                .Id = _Row.Item("Id")
                .Numero = _Row.Item("Numero")
                .CodEntidad = _Row.Item("CodEntidad")
                .CodSucEntidad = _Row.Item("CodSucEntidad")
                .Nombre_Entidad = _Row.Item("Nombre_Entidad")
                .Empresa = _Row.Item("Empresa")
                .Sucursal = _Row.Item("Sucursal")
                .CodFuncionario = _Row.Item("CodFuncionario")
                .FechaImporta = _Row.Item("FechaImporta")
                .FechaEmision = _Row.Item("FechaEmision")
                .Neto = _Row.Item("Neto")
                .Iva = _Row.Item("Iva")
                .Bruto = _Row.Item("Bruto")
                .Lineas = _Row.Item("Lineas")
                .Idpdaenca = _Row.Item("Idpdaenca")
                .NecesitaPermiso = _Row.Item("NecesitaPermiso")
                .RCadena = _Row.Item("RCadena")
                .RCadena_Id_Enc = _Row.Item("RCadena_Id_Enc")
                .Nro_RCadena = _Row.Item("Nro_RCadena")
                .NVVGenerada = _Row.Item("NVVGenerada")
                .Idmaeedo = _Row.Item("Idmaeedo")
                .Estado = _Row.Item("Estado")
                .Observaciones = _Row.Item("Observaciones")

            End With

            _Mensaje.EsCorrecto = True
            _Mensaje.Tag = _Zw_Pda2NVV

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Function Fx_Actualizar_Estado_Zw_Pda2NVV(_Zw_Pda2NVV As Zw_Pda2NVV) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            With _Zw_Pda2NVV

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Pda2NVV Set " & vbCrLf &
                               "NecesitaPermiso = " & Convert.ToInt32(.NecesitaPermiso) &
                               ",RCadena = '" & .RCadena & "'" &
                               ",RCadena_Id_Enc = " & Convert.ToInt32(.RCadena_Id_Enc) &
                               ",Nro_RCadena = '" & .Nro_RCadena & "'" &
                               ",NVVGenerada = " & Convert.ToInt32(.NVVGenerada) &
                               ",Idmaeedo = " & .Idmaeedo &
                               ",Estado = '" & .Estado & "'" &
                               ",Observaciones = '" & .Observaciones & "'" & vbCrLf &
                               "Where Id = " & .Id

            End With

            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)
            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New InvalidOperationException(_Sql.Pro_Error)
            End If
            _Mensaje.EsCorrecto = True
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
