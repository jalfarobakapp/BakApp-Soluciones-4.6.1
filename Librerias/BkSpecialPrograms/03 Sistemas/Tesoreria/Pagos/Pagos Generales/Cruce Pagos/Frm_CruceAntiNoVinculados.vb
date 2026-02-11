Imports DevComponents.DotNetBar

Public Class Frm_CruceAntiNoVinculados

    Dim Consulta_Sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Private _Tbl_Maedpce As DataTable
    Private _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
    Public Property Lista_Idmaedpce As List(Of Integer)

    ' Caché por ENDP para reutilizar listas de documentos y que se actualicen Abono/SaldoAct
    Private _CacheMaeedoPorEndp As New Dictionary(Of String, List(Of Cl_MaeedoItem))(StringComparer.OrdinalIgnoreCase)
    Private _Filtro_Idmaedpce As String

    ' Bandera para evitar reentrada en el manejo de cambio de check
    Private _SuppressChkChanged As Boolean = False

    ' ==========================
    ' INSERTAR CAMPO A NIVEL DE CLASE
    ' ==========================
    Private _PaymentsCountPorIdRst As New Dictionary(Of Integer, Integer)

    ' Totales
    Private _TotalAnticipos As Double = 0
    Private _TotalAnticiposCalculado As Boolean = False

    Public Sub New(_Filtro_Idmaedpce As String)


        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me._Filtro_Idmaedpce = _Filtro_Idmaedpce

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Maedpce, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_CruceAntiNoVinculados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Maedpce.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        ' Manejar cambios en celdas tipo checkbox para procesar selección en cadena
        AddHandler Grilla_Maedpce.CurrentCellDirtyStateChanged, AddressOf Grilla_Maedpce_CurrentCellDirtyStateChanged
        AddHandler Grilla_Maedpce.CellValueChanged, AddressOf Grilla_Maedpce_CellValueChanged

        Sb_Actualizar_Grilla()

        'Dtp_FEmisionOtra.Value = Now.Date

    End Sub

    Sub Sb_Actualizar_Grilla()

        ' Dim _Filtro_Idmaedpce As String = Generar_Filtro_IN_Lista(Lista_Idmaedpce, True, "")

        Consulta_Sql = $"SELECT 
    Cast(0 As Int) As Id,
    Cast(0 As Bit) As Chk,
    c.IDMAEDPCE,
    c.EMPRESA,
    c.SUREDP,
    c.CJREDP,
    c.TIDP,
    Isnull(Tc.NombreTabla,'') As 'NOTIDP',
    c.NUDP,
    c.ENDP,
    c.EMDP,
    ISNULL(e.NOKOEN,'') AS RAZON,   -- nombre del cliente
    c.SUEMDP,
    c.CUDP,
    c.NUCUDP,
    c.FEEMDP,
    c.FEVEDP,
    c.MODP,
    c.TIMODP,
    c.TAMODP,
    c.VADP,
    c.VAABDP,
    c.VAASDP,
    c.VAVUDP,
    c.VADP-c.VAASDP As 'SALDO_PG',
    c.ESPGDP,
    c.REFANTI,
    c.KOTU,
    c.NUTRANSMI,
    c.DOCUENANTI,
    c.KOFUDP,
    c.KOTNDP,
    c.SUTNDP,
    c.ESASDP,
    c.CUOTAS,
    c.ARCHIRSD,
    c.IDRSD,
    Isnull(Edo.TIDO,'') As 'TIDO_SD',
    Isnull(Edo.NUDO,'') As NUDO_SD,
    CAST(0 AS INT) AS IDMAEEDO,
    CAST(0 AS FLOAT) AS SALDO,
    Cast(0 As Float) As LEY20956,
    Cast('' As Varchar(14)) As Doc_Anticipo,
    Cast('' As Varchar(30)) As NOKOENDP,
    Cast(0 As Bit) As Error,
    Cast(0 As Bit) As Exclamacion,
    Cast('' As Varchar(100)) As Observacion,
    Cast(0 As Bit) As PagoCruzado,
    Cast(0 As Bit) As CruzarPagoAuto,
    Cast(0 As Bit) As MatchExacto,
    Cast(0 As Bit) As MatchParcial
FROM MAEDPCE c WITH (NOLOCK)
OUTER APPLY (
    SELECT TOP 1 NOKOEN
    FROM MAEEN e WITH (NOLOCK)
    WHERE e.KOEN = c.ENDP
    ORDER BY e.KOEN -- aquí puedes cambiar el criterio de orden si quieres
) e
Left Join MAEEDO Edo On Edo.IDMAEEDO = c.IDRSD And c.ARCHIRSD = 'MAEEDO'
Left Join {_Global_BaseBk}Zw_TablaDeCaracterizaciones Tc On Tc.Tabla = 'TIDP_Cli' And Tc.CodigoTabla = c.TIDP
WHERE IDMAEDPCE In {_Filtro_Idmaedpce}
And (c.VADP-c.VAASDP) > 0
Order By c.ENDP,c.FEEMDP"

        _Tbl_Maedpce = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Dim _DisplayIndex = 0

        With Grilla_Maedpce

            .DataSource = _Tbl_Maedpce

            OcultarEncabezadoGrilla(Grilla_Maedpce, True)

            '.Columns("Btn_Ico").HeaderText = ""
            '.Columns("Btn_Ico").Width = 35
            '.Columns("Btn_Ico").Visible = True
            '.Columns("Btn_Ico").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Chk").HeaderText = "Sel"
            .Columns("Chk").Width = 30
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").Visible = True
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PagoCruzado").HeaderText = "PGX"
            .Columns("PagoCruzado").ToolTipText = "Pago cruzado"
            .Columns("PagoCruzado").Width = 30
            .Columns("PagoCruzado").Visible = True
            .Columns("PagoCruzado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Exclamacion").HeaderText = "!"
            .Columns("Exclamacion").ToolTipText = "Exclamación"
            .Columns("Exclamacion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Exclamacion").Width = 30
            .Columns("Exclamacion").Visible = True
            .Columns("Exclamacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TIDP").HeaderText = "TD"
            .Columns("TIDP").Width = 30
            .Columns("TIDP").Visible = True
            .Columns("TIDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ENDP").HeaderText = "Entidad"
            .Columns("ENDP").Width = 80
            .Columns("ENDP").Visible = True
            .Columns("ENDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("RAZON").HeaderText = "Nombre Entidad"
            .Columns("RAZON").Width = 190
            .Columns("RAZON").Visible = True
            .Columns("RAZON").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEEMDP").HeaderText = "F.Emisión"
            .Columns("FEEMDP").Width = 65
            .Columns("FEEMDP").Visible = True
            .Columns("FEEMDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEEMDP").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEEMDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("FEVEDP").HeaderText = "F.venci."
            '.Columns("FEVEDP").Width = 65
            '.Columns("FEVEDP").Visible = True
            '.Columns("FEVEDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("FEVEDP").DefaultCellStyle.Format = "dd/MM/yyyy"
            '.Columns("FEVEDP").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("CUDP").HeaderText = "Mon"
            '.Columns("CUDP").Width = 30
            '.Columns("CUDP").Visible = True
            '.Columns("CUDP").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("CUDP").HeaderText = "Cuenta"
            '.Columns("CUDP").Width = 100
            '.Columns("CUDP").Visible = True
            '.Columns("CUDP").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("NUCUDP").HeaderText = "Número doc."
            .Columns("NUCUDP").Width = 80
            .Columns("NUCUDP").Visible = True
            .Columns("NUCUDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MODP").HeaderText = "M."
            .Columns("MODP").ToolTipText = "Moneda"
            .Columns("MODP").Width = 30
            .Columns("MODP").Visible = True
            .Columns("MODP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("MODP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("SALDO_PG").HeaderText = "Monto Saldo"
            .Columns("SALDO_PG").Width = 80
            .Columns("SALDO_PG").Visible = True
            .Columns("SALDO_PG").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO_PG").DefaultCellStyle.Format = "###,##.##"
            .Columns("SALDO_PG").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("REFANTI").HeaderText = "Referencia (REFANTI)"
            .Columns("REFANTI").Width = 300
            .Columns("REFANTI").Visible = True
            .Columns("REFANTI").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CruzarPagoAuto").HeaderText = "CPA"
            .Columns("CruzarPagoAuto").ToolTipText = "Cruzar pago automáticamente"
            .Columns("CruzarPagoAuto").Width = 30
            '.Columns("CruzarPagoAuto").ReadOnly = False
            .Columns("CruzarPagoAuto").Visible = True
            .Columns("CruzarPagoAuto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MatchExacto").HeaderText = "M.E."
            .Columns("MatchExacto").ToolTipText = "Match Exacto"
            .Columns("MatchExacto").Width = 30
            '.Columns("CruzarPagoAuto").ReadOnly = False
            .Columns("MatchExacto").Visible = True
            .Columns("MatchExacto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MatchParcial").HeaderText = "M.P."
            .Columns("MatchParcial").ToolTipText = "Match Parcial"
            .Columns("MatchParcial").Width = 30
            '.Columns("CruzarPagoAuto").ReadOnly = False
            .Columns("MatchParcial").Visible = True
            .Columns("MatchParcial").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Doc_Anticipo").HeaderText = "Doc.Asoc.Anticipo"
            .Columns("Doc_Anticipo").Width = 110
            .Columns("Doc_Anticipo").Visible = True
            .Columns("Doc_Anticipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        ' Calcular totales: total de anticipos (solo la primera vez) y total seleccionado (inicialmente 0)
        Sb_Actualizar_Totales(True)

    End Sub

    ''' <summary>
    ''' Actualiza Lbl_TotalSeleccion y Lbl_TotalAnticipos.
    ''' Si RecalcularTotalAnticipos = True o no se ha calculado antes, calcula el total de todos los SALDO_PG una vez.
    ''' </summary>
    Private Sub Sb_Actualizar_Totales(Optional ByVal RecalcularTotalAnticipos As Boolean = False)

        Try
            If _Tbl_Maedpce Is Nothing Then
                Lbl_TotalSeleccion.Text = FormatCurrency(0, 0)
                Lbl_TotalAnticipos.Text = FormatCurrency(0, 0)
                Return
            End If

            If RecalcularTotalAnticipos OrElse Not _TotalAnticiposCalculado Then
                Dim totalAnt As Double = 0
                For Each dr As DataRow In _Tbl_Maedpce.Rows
                    Try
                        If dr.Table.Columns.Contains("SALDO_PG") AndAlso dr.Item("SALDO_PG") IsNot Nothing AndAlso Not IsDBNull(dr.Item("SALDO_PG")) Then
                            totalAnt += Convert.ToDouble(dr.Item("SALDO_PG"))
                        End If
                    Catch
                        ' ignorar fila problemática
                    End Try
                Next
                _TotalAnticipos = Math.Round(totalAnt, 2)
                _TotalAnticiposCalculado = True
            End If

            Dim totalSel As Double = 0
            For Each dr As DataRow In _Tbl_Maedpce.Rows
                Try
                    Dim chk As Boolean = False
                    If dr.Table.Columns.Contains("Chk") AndAlso dr.Item("Chk") IsNot Nothing AndAlso Not IsDBNull(dr.Item("Chk")) Then
                        chk = Convert.ToBoolean(dr.Item("Chk"))
                    End If

                    If chk Then
                        If dr.Table.Columns.Contains("SALDO_PG") AndAlso dr.Item("SALDO_PG") IsNot Nothing AndAlso Not IsDBNull(dr.Item("SALDO_PG")) Then
                            totalSel += Convert.ToDouble(dr.Item("SALDO_PG"))
                        End If
                    End If
                Catch
                    ' ignorar fila problemática
                End Try
            Next

            Lbl_TotalSeleccion.Text = FormatCurrency(Math.Round(totalSel, 0), 0)
            Lbl_TotalAnticipos.Text = FormatCurrency(Math.Round(_TotalAnticipos, 0), 0)
        Catch ex As Exception
            ' En caso de error no interrumpir UI
        End Try

    End Sub

    Private Sub Btn_MatchDocumentos_Click(sender As Object, e As EventArgs) Handles Btn_MatchDocumentos.Click

        If Not Fx_Tiene_Permiso(Me, "Pcli0003") Then
            Return
        End If

        Consulta_Sql = $"Select Top 1 *,Isnull(NOKOFU,'') As Funcionario From {_Global_BaseBk}Zw_CrucePAuto_Tom 
Left Join TABFU On KOFU = CodFuncionario
Where NombreEquipo <> '{_NombreEquipo}'-- And CodFuncionario <> '{FUNCIONARIO}'"
        Dim _Row_CruceTom As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If Not IsNothing(_Row_CruceTom) Then

            Dim _Funcionario = _Row_CruceTom.Item("Funcionario")
            Dim _NombreEquipo2 = _Row_CruceTom.Item("NombreEquipo")

            MessageBoxEx.Show(Me, "El proceso se encuentra tomado por: " & _Funcionario & vbCrLf &
                              "En el equipo: " & _NombreEquipo2,
                              "No puede hacer gestión mientras esto este ocurriendo", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Return

        End If

        Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_CrucePAuto_Tom" & vbCrLf &
                       "Insert Into " & _Global_BaseBk & "Zw_CrucePAuto_Tom (CodFuncionario,FechaToma,NombreEquipo) " &
                       "Values ('" & FUNCIONARIO & "',Getdate(),'" & _NombreEquipo & "')"
        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql)

        Dim _Ls_MaeedoItem As New List(Of Cl_MaeedoItem)
        Dim _Cl_MaeedoItem As New Cl_MaeedoItem

        _CacheMaeedoPorEndp.Clear()

        ' Limpiar contador de pagos por documento
        _PaymentsCountPorIdRst.Clear()

        ' Listas para resumen
        Dim exactMatches As New List(Of String)
        Dim partialMatches As New List(Of String)
        Dim noMatches As New List(Of String)

        ' Inicializar progreso y estado
        Try
            Me.Enabled = False
            Cursor = Cursors.WaitCursor

            If _Tbl_Maedpce Is Nothing OrElse _Tbl_Maedpce.Rows.Count = 0 Then
                Barra_Progreso.Minimum = 0
                Barra_Progreso.Maximum = 1
                Barra_Progreso.Value = 1
                Lbl_Status.Text = "No hay filas para procesar."
                Application.DoEvents()
                Return
            End If

            Barra_Progreso.Minimum = 0
            Barra_Progreso.Maximum = _Tbl_Maedpce.Rows.Count
            Barra_Progreso.Value = 0
            Barra_Progreso.Visible = True
            Me.Refresh()
            Lbl_Status.Text = "Iniciando búsqueda de documentos..."
            Application.DoEvents()

            Dim _contador As Integer = 0

            For Each _Fila As DataRow In _Tbl_Maedpce.Rows

                _contador += 1

                Dim _Idmaedpce As Integer = _Fila.Item("IDMAEDPCE")
                Dim _Endp As String = _Fila.Item("ENDP").ToString.Trim
                Dim _Saldo_Pg As Double = _Fila.Item("SALDO_PG")
                Dim _Modp As String = _Fila.Item("MODP")
                Dim _Exclamacion As Boolean = _Fila.Item("Exclamacion")

                ' Actualizar estado por fila
                Lbl_Status.Text = String.Format("Procesando {0} de {1}. ENDP: {2} - IDMAEDPCE: {3}", _contador, Barra_Progreso.Maximum, _Endp, _Idmaedpce)
                If _contador <= Barra_Progreso.Maximum Then
                    Barra_Progreso.Value = _contador
                End If
                Application.DoEvents()

                If _Modp.ToString.Trim <> "$" Or _Exclamacion Then
                    ' Considerar como no procesado por moneda diferente: aquí no se añade a noMatches
                    Continue For
                End If

                If String.IsNullOrEmpty(_Endp) Then
                    ' No hay cliente/endp: registrar como sin match
                    noMatches.Add(String.Format("IDMAEDPCE: {0}, ENDP vacío, SaldoPago: {1}", _Idmaedpce, FormatNumber(_Saldo_Pg, 2)))
                    Continue For
                End If

                Dim _Ls As List(Of Cl_MaeedoItem) = Nothing
                Dim _CargaDesdeBD As Boolean = False

                ' Comprobar caché
                If _CacheMaeedoPorEndp.ContainsKey(_Endp) Then
                    _Ls = _CacheMaeedoPorEndp(_Endp)
                Else
                    ' No está en caché: consultar BD y añadir al caché
                    Consulta_Sql = $"SELECT CAST(0 AS INT) AS ID,CAST(0 AS INT) AS ID_PADRE,CAST(0 AS INT) AS ID_PAGO,
       CAST(0 AS INT) AS IDMAEDPCE,
       EDO.IDMAEEDO AS IDRST,
       'MAEEDO' AS ARCHIRST,
       EDO.TAMODO AS TCASIG,
       EDO.EMPRESA, 
       EDO.TIDO AS DP, 
       EDO.NUDO AS NUDP, 
       EDO.ENDO AS ENDP, 
      -- EDO.SUENDO, 
       '' AS EMDP,'' AS SUEMDP,'' AS CUDP,'' AS NUCUDP,EDO.FEEMDO AS FEEMDP,EDO.FEULVEDO AS FEVEDP,EDO.MODO AS MODP, 
       EDO.TIMODO AS TIMODP, EDO.TAMODO AS TAMODP, 
       ROUND(EDO.VABRDO,2) AS VADP, 
       ROUND(EDO.VAABDO,2) AS VAABDP,
       ROUND(EDO.VABRDO,2) -  ROUND(EDO.VAABDO,2) As SALDO,
       CAST(0 AS FLOAT) AS ABONO,
       CAST(0 AS FLOAT) AS ABONO2,
       ROUND(EDO.VABRDO,2) -  ROUND(EDO.VAABDO,2) As SALDO_ACT,
       0 As Orden,
       Cast('' As Varchar(30)) As Fevedp_Str,	    
       Cast('' As Varchar(30)) As Modp_Str,	    
       Cast('' As Varchar(30)) As Vadp_Str,	    
       Cast('' As Varchar(30)) As Saldo_Str,	    
       Cast('' As Varchar(30)) As Saldo_Act_Str,
       Cast(0 As Float) As LEY20956
	   	        
       FROM MAEEDO AS EDO  WITH ( NOLOCK )  
       WHERE 
		EDO.ENDO = '{_Endp}' AND 
		EDO.TIDO IN  ('BLV','BSV','BLX','FCV','FDB','FDV','FDX','FDZ','FEV','FVL','FVT','FVX','FVZ',
		              'RIN','ESC','FEE','NCC','NCB') AND 
		EDO.ESPGDO = 'P'  AND 
		EDO.NUDONODEFI = 0  AND 
		EDO.EMPRESA = '{Mod_Empresa}'
ORDER BY Orden,FEVEDP"

                    Dim _Tbl_Maeedo As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

                    _Ls = _Cl_MaeedoItem.ListFromDataTable(_Tbl_Maeedo)

                    If _Ls Is Nothing Then
                        _Ls = New List(Of Cl_MaeedoItem)
                    End If

                    ' Añadir a caché (aunque lista esté vacía para evitar múltiples consultas)
                    _CacheMaeedoPorEndp.Add(_Endp, _Ls)

                    ' Añadir los items encontrados a la lista acumulada solo si hay items
                    If _Ls IsNot Nothing AndAlso _Ls.Count > 0 Then
                        _Ls_MaeedoItem.AddRange(_Ls)
                    End If

                    _CargaDesdeBD = True
                End If

                Dim _Match = False

                ' Si la lista tiene elementos, intentar hacer match reutilizando SaldoAct/Abono ya actualizados
                If _Ls IsNot Nothing AndAlso _Ls.Count > 0 Then
                    Try
                        Dim _Tolerancia As Double = 0.01

                        ' 1) Intento de match exacto por SaldoAct == SaldoPago (con tolerancia)
                        For Each _Item As Cl_MaeedoItem In _Ls
                            Try
                                If Math.Abs(_Item.SaldoAct - _Saldo_Pg) <= _Tolerancia Then
                                    Try
                                        ' Calcular id del documento destino
                                        Dim _IdRst As Integer = _Item.IdRst

                                        ' Incrementar contador de pagos que se aplican a este documento
                                        If _PaymentsCountPorIdRst.ContainsKey(_IdRst) Then
                                            _PaymentsCountPorIdRst(_IdRst) += 1
                                        Else
                                            _PaymentsCountPorIdRst.Add(_IdRst, 1)
                                        End If

                                        ' Obtener saldo original del documento (si existe la propiedad Saldo)
                                        Dim originalSaldo As Double = _Item.Saldo

                                        ' Actualizar abono y saldo en el item (afectará al caché y a _Ls_MaeedoItem porque son mismas referencias)
                                        If Double.IsNaN(_Item.Abono) Then
                                            _Item.Abono = 0
                                        End If

                                        _Item.Abono = Math.Round(_Item.Abono + _Saldo_Pg, 2)
                                        _Item.SaldoAct = Math.Round(Math.Max(0, _Item.SaldoAct - _Saldo_Pg), 2)
                                        _Fila("REFANTI") = "Match con: " & _Item.Tido & " - " & _Item.Nudo & ", Saldo: " & FormatNumber(_Item.SaldoAct, 0)

                                        ' Determinar si es MatchExacto: solo si el pago cubre exactamente el saldo original
                                        ' y además este documento solo ha recibido un pago (contador = 1)
                                        Dim pagosAplicados As Integer = _PaymentsCountPorIdRst(_IdRst)

                                        If pagosAplicados = 1 AndAlso Math.Abs(originalSaldo - _Saldo_Pg) <= _Tolerancia Then
                                            ' Es un match exacto (factura cruzada por un único pago que la cubre)
                                            exactMatches.Add(String.Format("Pago ID:{0}, ENDP:{1}, SaldoPago:{2} -> {3}-{4} (IDRST:{5})",
                                                                           _Idmaedpce, _Endp, FormatNumber(_Saldo_Pg, 2),
                                                                           _Item.Tido, _Item.Nudo, _Item.IdRst))

                                            _Fila("CruzarPagoAuto") = True
                                            _Fila("IDMAEEDO") = _Item.IdRst
                                            _Fila("MatchExacto") = True
                                        Else
                                            ' No es match exacto (o se ha aplicado mas de un pago): marcar como parcial/no exacto
                                            partialMatches.Add(String.Format("Pago ID:{0}, ENDP:{1}, SaldoPago:{2} -> {3}-{4} (IDRST:{5})",
                                                                         _Idmaedpce, _Endp, FormatNumber(_Saldo_Pg, 2),
                                                                         _Item.Tido, _Item.Nudo, _Item.IdRst))

                                            _Fila("CruzarPagoAuto") = True
                                            _Fila("IDMAEEDO") = _Item.IdRst
                                            _Fila("MatchParcial") = True
                                        End If

                                        _Match = True

                                    Catch ex As Exception
                                        ' Ignorar si no se puede escribir en la fila
                                    End Try

                                    Exit For
                                End If
                            Catch ex As Exception
                                ' Ignorar errores por valores nulos o conversiones inesperadas
                            End Try
                        Next

                        ' 2) Si no hubo match exacto, buscar el primer documento con saldo suficiente
                        If Not _Match Then
                            For Each _Item As Cl_MaeedoItem In _Ls
                                Try
                                    ' Si el documento ya no tiene saldo, continuar
                                    If _Item.SaldoAct = 0 Then
                                        Continue For
                                    End If

                                    ' Calcular id del documento destino
                                    Dim _IdRst As Integer = _Item.IdRst

                                    ' Incrementar contador de pagos que se aplican a este documento
                                    If _PaymentsCountPorIdRst.ContainsKey(_IdRst) Then
                                        _PaymentsCountPorIdRst(_IdRst) += 1
                                    Else
                                        _PaymentsCountPorIdRst.Add(_IdRst, 1)
                                    End If

                                    If Double.IsNaN(_Item.Abono) Then
                                        _Item.Abono = 0
                                    End If

                                    _Item.Abono = Math.Round(_Item.Abono + _Saldo_Pg, 2)
                                    _Item.SaldoAct = Math.Round(Math.Max(0, _Item.SaldoAct - _Saldo_Pg), 2)
                                    _Fila("REFANTI") = "Match con: " & _Item.Tido & " - " & _Item.Nudo & ", Saldo: " & FormatNumber(_Item.SaldoAct, 0)

                                    ' Agregar al resumen de matches parciales/no exactos
                                    partialMatches.Add(String.Format("Pago ID:{0}, ENDP:{1}, SaldoPago:{2} -> {3}-{4} (IDRST:{5})",
                                                                     _Idmaedpce, _Endp, FormatNumber(_Saldo_Pg, 2),
                                                                     _Item.Tido, _Item.Nudo, _Item.IdRst))

                                    _Fila("CruzarPagoAuto") = True
                                    _Fila("IDMAEEDO") = _Item.IdRst
                                    _Fila("MatchParcial") = True
                                    _Match = True

                                    Dim _Utilizado As Double = _Saldo_Pg - _Item.SaldoAct

                                Catch ex As Exception
                                    ' Ignorar si no se puede escribir en la fila
                                End Try

                                Exit For
                            Next
                        End If

                    Catch ex As Exception
                        ' Por seguridad, ignorar errores al escribir en la fila (si columna no existe por ejemplo)
                    End Try
                End If

                ' Si no hubo match y la lista estaba vacía, o no se encontró documento adecuado
                If Not _Match Then
                    noMatches.Add(String.Format("Pago ID:{0}, ENDP:{1}, SaldoPago:{2}", _Idmaedpce, _Endp, FormatNumber(_Saldo_Pg, 2)))
                End If

                ' Actualizar barra después de procesar la fila (asegurar que se muestre al final de la iteración)
                Lbl_Status.Text = String.Format("Procesadas {0} de {1}", _contador, Barra_Progreso.Maximum)
                If _contador <= Barra_Progreso.Maximum Then
                    Barra_Progreso.Value = _contador
                End If
                Application.DoEvents()

            Next

            ' Construir y mostrar resumen al finalizar el proceso
            Try
                Dim totalIterados As Integer = _contador
                Dim totalExactos As Integer = exactMatches.Count
                Dim totalParciales As Integer = partialMatches.Count
                Dim totalSinMatch As Integer = noMatches.Count

                Dim resumen As New System.Text.StringBuilder()
                resumen.AppendLine("Proceso finalizado.")
                resumen.AppendLine()
                resumen.AppendLine(String.Format("Total filas iteradas: {0}", totalIterados))
                resumen.AppendLine(String.Format("Matches exactos: {0}", totalExactos))
                resumen.AppendLine(String.Format("Matches parciales/no exactos: {0}", totalParciales))
                resumen.AppendLine(String.Format("Sin match: {0}", totalSinMatch))
                resumen.AppendLine()

                ' Añadir listados (limitar para no mostrar un cuadro gigantesco)
                Dim maxDetalle As Integer = 50

                ' Mostrar resumen al usuario
                MessageBoxEx.Show(Me, resumen.ToString(), "Resumen de cruce automático", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                ' En caso de error al construir el resumen, no interrumpir el flujo
            End Try

            ' Opcional: si desea usar _Ls_MaeedoItem más adelante, ya contiene referencias cuyo Abono y SaldoAct fueron actualizados

        Catch ex As Exception
            MessageBoxEx.Show(Me, "Error al realizar match de documentos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                Barra_Progreso.Value = 0
                Lbl_Status.Text = "Proceso finalizado"
                Application.DoEvents()
            Catch
            End Try

            Cursor = Cursors.Default
            Me.Refresh()
            Me.Enabled = True

            ' Deshabilitar el botón al finalizar tal como se pidió
            Btn_MatchDocumentos.Enabled = False
        End Try

    End Sub

    ' Cuando el usuario hace clic en el checkbox, el DataGridView queda en estado sucio.
    ' Commit para que CellValueChanged se dispare inmediatamente.
    Private Sub Grilla_Maedpce_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs)
        Try
            If Grilla_Maedpce Is Nothing Then
                Return
            End If

            If Grilla_Maedpce.IsCurrentCellDirty Then
                Dim col = Grilla_Maedpce.CurrentCell.OwningColumn
                If col IsNot Nothing AndAlso col.Name = "Chk" Then
                    Grilla_Maedpce.CommitEdit(DataGridViewDataErrorContexts.Commit)
                End If
            End If
        Catch ex As Exception
            ' Ignorar
        End Try
    End Sub

    ' Manejo centralizado cuando cambia el valor de la columna "Chk"
    Private Sub Grilla_Maedpce_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
        If e Is Nothing Then
            Return
        End If

        Try
            If _SuppressChkChanged Then
                Return
            End If

            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
                Return
            End If

            Dim colName As String = Grilla_Maedpce.Columns(e.ColumnIndex).Name

            If Not String.Equals(colName, "Chk", StringComparison.OrdinalIgnoreCase) Then
                Return
            End If

            _SuppressChkChanged = True

            Dim filaGrid As DataGridViewRow = Grilla_Maedpce.Rows(e.RowIndex)

            ' Obtener nuevo valor de checkbox (con tolerancia a DBNull)
            Dim nuevoValor As Boolean = False
            Try
                If filaGrid.Cells("Chk").Value IsNot Nothing AndAlso Not IsDBNull(filaGrid.Cells("Chk").Value) Then
                    nuevoValor = Convert.ToBoolean(filaGrid.Cells("Chk").Value)
                End If
            Catch ex As Exception
                nuevoValor = False
            End Try

            ' --- NUEVA VALIDACIÓN: si Exclamacion = True no permitir marcar y mostrar Observacion ---
            If nuevoValor Then
                Try
                    Dim tieneExclamacion As Boolean = False
                    Dim observacion As String = String.Empty

                    If filaGrid.Cells("Exclamacion").Value IsNot Nothing AndAlso Not IsDBNull(filaGrid.Cells("Exclamacion").Value) Then
                        tieneExclamacion = Convert.ToBoolean(filaGrid.Cells("Exclamacion").Value)
                    End If

                    If tieneExclamacion Then
                        If filaGrid.Cells("Observacion").Value IsNot Nothing AndAlso Not IsDBNull(filaGrid.Cells("Observacion").Value) Then
                            observacion = filaGrid.Cells("Observacion").Value.ToString().Trim()
                        End If

                        If String.IsNullOrEmpty(observacion) Then
                            observacion = "Registro con observación. Consulte detalles."
                        End If

                        MessageBoxEx.Show(Me, observacion, "No se puede seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                        ' Revertir el cambio
                        filaGrid.Cells("Chk").Value = False

                        Return
                    End If
                Catch ex As Exception
                    ' Si falla la validación dejar proceder con el flujo normal
                End Try
            End If
            ' ---------------------------------------------------------------------------------------

            ' Comprobar que la fila tenga CruzarPagoAuto = True si se intenta chequear
            Dim puedeCruzar As Boolean = False
            Try
                If filaGrid.Cells("CruzarPagoAuto").Value IsNot Nothing AndAlso Not IsDBNull(filaGrid.Cells("CruzarPagoAuto").Value) Then
                    puedeCruzar = Convert.ToBoolean(filaGrid.Cells("CruzarPagoAuto").Value)
                End If
            Catch ex As Exception
                puedeCruzar = False
            End Try

            If nuevoValor AndAlso Not puedeCruzar Then
                MessageBoxEx.Show(Me, "No se puede seleccionar este registro porque la columna [CPA] ('Cruzar Pago Automáticamente') no está marcado.",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ' Revertir el cambio
                filaGrid.Cells("Chk").Value = False
                Return
            End If

            ' Propagar el mismo cambio a todas las filas del mismo ENDP que además tengan CruzarPagoAuto = True
            Dim endp As String = String.Empty
            Try
                If filaGrid.Cells("ENDP").Value IsNot Nothing AndAlso Not IsDBNull(filaGrid.Cells("ENDP").Value) Then
                    endp = filaGrid.Cells("ENDP").Value.ToString().Trim()
                End If
            Catch ex As Exception
                endp = String.Empty
            End Try

            If String.IsNullOrEmpty(endp) Then
                Return
            End If

            ' Recorremos las filas de la tabla de datos para mantener consistencia y disparar UI automáticamente
            If _Tbl_Maedpce Is Nothing Then
                Return
            End If

            For Each dr As DataRow In _Tbl_Maedpce.Rows
                Try
                    Dim rEndp As String = String.Empty
                    If dr.Table.Columns.Contains("ENDP") AndAlso dr.Item("ENDP") IsNot Nothing AndAlso Not IsDBNull(dr.Item("ENDP")) Then
                        rEndp = dr.Item("ENDP").ToString().Trim()
                    End If

                    Dim rCruzar As Boolean = False
                    If dr.Table.Columns.Contains("CruzarPagoAuto") AndAlso dr.Item("CruzarPagoAuto") IsNot Nothing AndAlso Not IsDBNull(dr.Item("CruzarPagoAuto")) Then
                        rCruzar = Convert.ToBoolean(dr.Item("CruzarPagoAuto"))
                    End If

                    If String.Equals(endp, rEndp, StringComparison.OrdinalIgnoreCase) AndAlso rCruzar Then
                        ' Solo actualizar si hay diferencia para evitar escrituras innecesarias
                        If dr.Item("Chk") Is Nothing OrElse IsDBNull(dr.Item("Chk")) OrElse Convert.ToBoolean(dr.Item("Chk")) <> nuevoValor Then
                            dr.Item("Chk") = nuevoValor
                        End If
                    End If
                Catch ex As Exception
                    ' Ignorar fila con problemas y continuar
                End Try
            Next

        Catch ex As Exception
            ' Ignorar errores en el proceso para no interrumpir la UI
        Finally
            ' Actualizar totales después de cualquier cambio de selección
            Try
                Sb_Actualizar_Totales(False)
            Catch
            End Try

            _SuppressChkChanged = False
        End Try
    End Sub

    Private Sub Grilla_Maedpce_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Maedpce.CellEnter
        Try

            Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

            Dim _Tidp = _Fila.Cells("TIDP").Value.ToString.Trim
            Dim _Notidp = _Fila.Cells("NOTIDP").Value.ToString.Trim
            Dim _Nokoendp = _Fila.Cells("NOKOENDP").Value.ToString.Trim
            Dim _Razon = _Fila.Cells("RAZON").Value.ToString.Trim
            Dim _Cudp = _Fila.Cells("CUDP").Value.ToString.Trim
            Dim _Nucudp = _Fila.Cells("NUCUDP").Value.ToString.Trim
            Dim _Vadp = _Fila.Cells("VADP").Value
            Dim _Refanti = _Fila.Cells("Refanti").Value.ToString.Trim
            Dim _Tido_sd = _Fila.Cells("TIDO_SD").Value.ToString.Trim
            Dim _Nudo_sd = _Fila.Cells("NUDO_SD").Value.ToString.Trim

            Dim _Error As Boolean = _Fila.Cells("Error").Value
            Dim _Exclamacion As Boolean = _Fila.Cells("Exclamacion").Value

            Dim _Observacion = _Fila.Cells("Observacion").Value.ToString.Trim

            Lbl_Razon_Social.Text = _Razon
            Lbl_Tipo_Documento.Text = _Tidp & " - " & _Notidp
            Lbl_Banco_Cta_Cte.Text = _Nokoendp & ", Cta. Cte: " & _Cudp & ", Nro: " & _Nucudp & ", Monto: " & FormatCurrency(_Vadp, 0)
            Lbl_Referencia.Text = _Refanti

            If Not String.IsNullOrEmpty(_Tido_sd) Then
                Lbl_Referencia.Text = _Refanti & ", " & _Tido_sd & "-" & _Nudo_sd
            End If

            If Not String.IsNullOrEmpty(_Observacion) Then

                If _Error Then Lbl_Informacion.Text = "Problemas: " & _Observacion
                If _Exclamacion Then Lbl_Informacion.Text = "Reparos: " & _Observacion

                Lbl_Informacion.ForeColor = Rojo
            Else
                Lbl_Informacion.Text = String.Empty
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click

        If Not Btn_MatchDocumentos.Enabled Then

            If MessageBoxEx.Show(Me, "Si actualiza se perdera el Match que que acaba de realizar" & vbCrLf &
                                 "¿Confirma su decición?", "Actualizar",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
            End If

        End If

        Sb_Actualizar_Grilla()
        Btn_MatchDocumentos.Enabled = True

    End Sub


    Private Sub Chk_Seleccionar_Todo_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Seleccionar_Todo.CheckedChanged

        Dim _HayFilasParaCruzar As Boolean = False

        For Each _Fila As DataRow In _Tbl_Maedpce.Rows

            If Chk_Seleccionar_Todo.Checked Then
                If _Fila.Item("CruzarPagoAuto") And Not _Fila.Item("Exclamacion") Then
                    _Fila.Item("Chk") = True
                    _HayFilasParaCruzar = True
                Else
                    _Fila.Item("Chk") = False
                End If
            Else
                _Fila.Item("Chk") = Chk_Seleccionar_Todo.Checked
            End If

        Next

        If Chk_Seleccionar_Todo.Checked AndAlso Not _HayFilasParaCruzar Then

            If Not _HayFilasParaCruzar Then
                MessageBoxEx.Show("No hay filas seleccionadas y marcadas para cruce automático. No se realizará ninguna acción.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Chk_Seleccionar_Todo.Checked = False

                ' Actualizar totales tras revertir la selección
                Sb_Actualizar_Totales(False)

                Return
            End If

        End If

        ' Actualizar totales después de cambiar selección en bloque
        Sb_Actualizar_Totales(False)

    End Sub

    Private Sub Btn_Grabar_Autorizacion_Click(sender As Object, e As EventArgs) Handles Btn_Grabar_Autorizacion.Click

        'If Rdb_FechaAsignacionOtraFecha.Checked Then
        '    If Dtp_FEmisionOtra.Value.Date > Now.Date Then
        '        MessageBoxEx.Show(Me, "La fecha de emisión no puede ser mayor a la fecha actual." & vbCrLf &
        '                          "Corrija la fecha para poder continuar.", "Validación",
        '                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '        Dtp_FEmisionOtra.Focus()
        '        Return
        '    End If
        'End If

        Dim _Ls_Mensajes As New List(Of LsValiciones.Mensajes)

        ' 1) Comprobar si hay al menos una fila seleccionada y marcada para cruce automático
        Dim _HayFilasParaCruzar As Boolean = False

        If _Tbl_Maedpce IsNot Nothing Then
            For Each _FilaChk As DataRow In _Tbl_Maedpce.Rows
                Try
                    If _FilaChk.Item("Chk") AndAlso _FilaChk.Item("CruzarPagoAuto") Then
                        _HayFilasParaCruzar = True
                        Exit For
                    End If
                Catch ex As Exception
                    ' Ignorar filas con datos inesperados y continuar la comprobación
                End Try
            Next
        End If

        ' 2) Si no hay filas que cumplan la condición, mostrar mensaje y salir del método
        If Not _HayFilasParaCruzar Then
            MessageBoxEx.Show("No hay filas seleccionadas y marcadas para cruce automático. No se realizará ninguna acción.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' 3) Proceder con el procesamiento de las filas que cumplan la condición
        For Each _Fila As DataRow In _Tbl_Maedpce.Rows

            If _Fila.Item("Chk") AndAlso _Fila.Item("CruzarPagoAuto") Then

                Dim _Idmaedpce As Integer = _Fila.Item("IDMAEDPCE")
                Dim _Idmaeedo As Integer = _Fila.Item("IDMAEEDO")

                Dim _Mensaje As LsValiciones.Mensajes

                _Mensaje = Fx_Pagar_Documentos(_Fila)

                If _Mensaje.EsCorrecto Then
                    _Fila.Item("Error") = False
                    _Fila.Item("Exclamacion") = False
                    _Fila.Item("Observacion") = String.Empty
                    _Fila.Item("PagoCruzado") = True
                Else
                    _Fila.Item("Error") = True
                    _Fila.Item("Exclamacion") = False
                    _Fila.Item("Observacion") = _Mensaje.Mensaje
                End If

                _Ls_Mensajes.Add(_Mensaje)

            End If

        Next

        Dim ListaQr As LsValiciones.Mensajes = _Ls_Mensajes.FirstOrDefault(Function(p) p.EsCorrecto = False)

        If Not IsNothing(ListaQr) Then

            MessageBoxEx.Show(Me, "Hay documentos con problemas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

        Dim Fmv As New Frm_Validaciones
        Fmv.ListaMensajes = _Ls_Mensajes
        Fmv.ShowDialog(Me)
        Fmv.Dispose()

        Btn_Grabar_Autorizacion.Enabled = False
        Btn_CruceDocParaPago.Enabled = False
        Btn_Actualizar.Enabled = False

        ' Actualizar totales por si cambió algo relevante
        Sb_Actualizar_Totales(False)

    End Sub

    Function Fx_Pagar_Documentos(_Fila As DataRow) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _IpEquipo As String = Fx_GetLocalIPAddress()

            'Dim _Id As Integer = _Fila.Item("Id")
            'Dim _Notido As String = _Fila.Item("NOTIDO").ToString.Trim.ToLower
            'Dim _Tido As String = _Fila.Item("TIDO").ToString.Trim
            Dim _Idmaeedo As Integer = _Fila.Item("IDMAEEDO")
            Dim _Idmaedpce As Integer = _Fila.Item("IDMAEDPCE")
            'Dim _CodFuncionario_Paga As String = _Fila.Item("CodFuncionario_Paga").ToString.Trim

            Dim _Cl_Pagar As New Clas_Pagar
            Dim _Maedpce As MAEDPCE

            Consulta_Sql = "Select *,VABRDO-VAABDO As 'TOTSALDO' From MAEEDO Where IDMAEEDO = " & _Idmaeedo
            Dim _Row_Maeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql, False)

            If IsNothing(_Row_Maeedo) Then
                Throw New InvalidOperationException($"No se encontro el documentos en la tabla MAEEDO, IDMAEEDO = {_Idmaeedo}")
            End If

            Dim _Tido As String = _Row_Maeedo.Item("TIDO")
            Dim _Nudo As String = _Row_Maeedo.Item("NUDO")

            Dim _Saldo As Double = _Row_Maeedo.Item("TOTSALDO")

            If _Saldo <= 0 Then
                Throw New InvalidOperationException($"El documento {_Tido}-{_Nudo} no tiene saldo a pagar")
            End If

            Consulta_Sql = "Select TOP 1 * From MAEDPCE Where IDMAEDPCE = " & _Idmaedpce
            Dim _Row_Maedpce As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql, False)

            If IsNothing(_Row_Maedpce) Then
                Throw New InvalidOperationException($"No se encontro el documentos en la tabla MAEDPCE, IDMAEDPCE = {_Idmaedpce}")
            End If

            Dim _Vadp As Double = _Row_Maedpce.Item("VADP")
            Dim _Vaasdpce As Double = _Row_Maedpce.Item("VAASDP")

            Dim _SaldoPago As Double = _Row_Maedpce.Item("VADP") - _Row_Maedpce.Item("VAASDP")

            If _SaldoPago <= 0 Then
                Throw New InvalidOperationException($"El documento de pago no tiene saldo para pagar")
            End If

            If _Saldo > _SaldoPago Then
                _Saldo = _SaldoPago
            End If

            _Maedpce = New MAEDPCE With {
                .IDMAEDPCE = _Row_Maedpce.Item("IDMAEDPCE"),
                .TIDP = _Row_Maedpce.Item("TIDP"),
                .EMPRESA = _Row_Maedpce.Item("EMPRESA"),
                .ENDP = _Row_Maedpce.Item("ENDP"),
                .EMDP = _Row_Maedpce.Item("EMDP"),
                .SUEMDP = _Row_Maedpce.Item("SUEMDP"),
                .CUDP = _Row_Maedpce.Item("CUDP"),
                .NUCUDP = _Row_Maedpce.Item("NUCUDP"),
                .FEEMDP = _Row_Maedpce.Item("FEEMDP"),
                .FEVEDP = _Row_Maedpce.Item("FEVEDP"),
                .MODP = _Row_Maedpce.Item("MODP"),
                .TIMODP = _Row_Maedpce.Item("TIMODP"),
                .TAMODP = _Row_Maedpce.Item("TAMODP"),
                .VADP = _Row_Maedpce.Item("VADP"),
                .VAASDP = _Saldo,
                .VAVUDP = 0,
                .ESASDP = _Row_Maedpce.Item("ESASDP"),
                .ESPGDP = _Row_Maedpce.Item("ESPGDP"),
                .SUREDP = _Row_Maedpce.Item("SUREDP"),
                .CJREDP = _Row_Maedpce.Item("CJREDP"),
                .KOFUDP = _Row_Maedpce.Item("KOFUDP"),
                .REFANTI = "Cruce automático/Bakapp",
                .KOTU = _Row_Maedpce.Item("KOTU"),
                .VAABDP = _Row_Maedpce.Item("VAABDP"),
                .CUOTAS = _Row_Maedpce.Item("CUOTAS"),
                .ARCHIRSD = NuloPorNro(_Row_Maedpce.Item("ARCHIRSD"), ""),
                .IDRSD = NuloPorNro(_Row_Maedpce.Item("IDRSD"), 0),
                .KOTNDP = _Row_Maedpce.Item("KOTNDP"),
                .SUTNDP = _Row_Maedpce.Item("SUTNDP")
                }

            Dim _Fecha_Asignacion_Pago As Date = FechaDelServidor()
            Dim _Ls_Maedpce As New List(Of MAEDPCE)

            If Chk_Fecha_Asignacion.Checked Then
                _Fecha_Asignacion_Pago = FechaDelServidor()
            Else
                _Fecha_Asignacion_Pago = _Row_Maedpce.Item("FEEMDP")
            End If


            _Ls_Maedpce.Add(_Maedpce)

            _Mensaje = _Cl_Pagar.Fx_Pagar_Documento(_Idmaeedo, _Ls_Maedpce, _Fecha_Asignacion_Pago)

            If _Mensaje.EsCorrecto Then

                Dim _Maedpcd As MAEDPCD = _Mensaje.Tag

                Dim _Idmaedpcd As Integer = _Maedpcd.IDMAEDPCD
                Dim _Vaasdp As Double = _Maedpcd.VAASDP
                Dim _Archirst As String = "MAEEDO"
                Dim _Idrst As Integer = _Idmaeedo
                Dim _Accion As String = $"Procesamiento masivo: cruce de documentos con saldo de anticipo (Bakapp). " &
                                        $"IDMAEDPCE: {_Idmaedpce},IDMAEDPCD: {_Idmaedpcd},Valor asignado: {FormatNumber(_Vaasdp, 2)}"

                Dim _Id = Fx_Add_Log_Gestion(FUNCIONARIO, Mod_Modalidad, _Archirst, _Idrst, "", _Accion, "", "", "", "", False, FUNCIONARIO,,,, _Tido, _Nudo)

            Else

                _Mensaje.Mensaje = Replace(_Mensaje.Mensaje, " '", "''")

            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "Error al pagar documento: " & ex.Message
            _Mensaje.Tag = Nothing
            _Mensaje.Detalle = "Cruzar pago"
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

    Private Sub Chk_Seleccionar_MatchExacto_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Seleccionar_MatchExacto.CheckedChanged

        Dim _HayFilasParaCruzar As Boolean = False

        For Each _Fila As DataRow In _Tbl_Maedpce.Rows

            If Chk_Seleccionar_MatchExacto.Checked Then
                If _Fila.Item("CruzarPagoAuto") And _Fila.Item("MatchExacto") And Not _Fila.Item("Exclamacion") Then
                    _Fila.Item("Chk") = True
                    _HayFilasParaCruzar = True
                Else
                    _Fila.Item("Chk") = False
                End If
            Else
                _Fila.Item("Chk") = Chk_Seleccionar_MatchExacto.Checked
            End If

        Next

        If Chk_Seleccionar_MatchExacto.Checked AndAlso Not _HayFilasParaCruzar Then

            If Not _HayFilasParaCruzar Then
                MessageBoxEx.Show("No hay filas seleccionadas y marcadas para cruce automático. No se realizará ninguna acción.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Chk_Seleccionar_MatchExacto.Checked = False
                Chk_Seleccionar_Todo.Checked = False

                ' Actualizar totales tras revertir la selección
                Sb_Actualizar_Totales(False)

                Return
            End If

        End If

        ' Actualizar totales después de cambiar selección en bloque
        Sb_Actualizar_Totales(False)

    End Sub

    Private Sub Btn_Ver_Cta_Cte_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Cta_Cte.Click

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.CurrentRow
        Dim _Koen = _Fila.Cells("ENDP").Value
        Dim _Razon = _Fila.Cells("RAZON").Value
        Dim _Idmaedpce As Integer = _Fila.Cells("IDMAEDPCE").Value
        Dim _Vadp As Double = _Fila.Cells("VADP").Value
        Dim _Vaasdp As Double = _Fila.Cells("VAASDP").Value
        Dim _Vavudp As Double = _Fila.Cells("VAVUDP").Value
        Dim _Saldo_pg As Double = _Fila.Cells("SALDO_PG").Value

        Dim _Grabar As Boolean

        Dim Fm As New Frm_Pagos_Generales(Frm_Pagos_Generales.Enum_Tipo_Pago.Clientes)
        Fm.Koen = _Koen
        Fm.BtnActualizarLista.Visible = False
        Fm.Cerrar_al_grabar = True
        'Fm.ModoLectura = True
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then

            ' Marcar todas las filas cuyo ENDP coincide con _Koen:
            Try
                If _Tbl_Maedpce IsNot Nothing Then
                    For Each dr As DataRow In _Tbl_Maedpce.Rows
                        Try
                            Dim rEndp As String = String.Empty
                            If dr.Table.Columns.Contains("ENDP") AndAlso dr.Item("ENDP") IsNot Nothing AndAlso Not IsDBNull(dr.Item("ENDP")) Then
                                rEndp = dr.Item("ENDP").ToString().Trim()
                            End If

                            If String.Equals(rEndp, _Koen.ToString().Trim(), StringComparison.OrdinalIgnoreCase) Then
                                If dr.Table.Columns.Contains("Exclamacion") Then
                                    dr.Item("Exclamacion") = True
                                    dr.Item("CruzarPagoAuto") = False
                                    dr.Item("MatchExacto") = False
                                    dr.Item("MatchParcial") = False
                                    dr.Item("REFANTI") = String.Empty
                                    dr.Item("Observacion") = "Se realizo gestión de pago a traves de pagos generales, el registro queda visado"
                                End If
                                'If dr.Table.Columns.Contains("Observacion") Then
                                '    dr.Item("Observacion") = "Se realizo gestión de pago a traves de pagos genrales, el registro queda vizado"
                                'End If
                            End If
                        Catch ex As Exception
                            ' Ignorar fila con problemas y continuar
                        End Try
                    Next
                End If
            Catch ex As Exception
                ' No interrumpir UI si ocurre algún error al marcar filas
            End Try

            MessageBoxEx.Show(Me, "El valor del saldo de este registro ya no corresponde a lo informado" & vbCrLf &
                          "Esta fila ya no estara disponible para revisión, ni ninguna de los registros que pertenezcan a este cliente",
                          "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Call Grilla_Maedpce_CellEnter(Nothing, Nothing)
            ' Refrescar grilla y totales
            Try
                Grilla_Maedpce.Refresh()
                Sb_Actualizar_Totales(False)
            Catch
            End Try

        End If

    End Sub

    Private Sub Grilla_Maedpce_MouseDown(sender As Object, e As MouseEventArgs) Handles Grilla_Maedpce.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then

            With sender

                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)

                If Hitest.Type = DataGridViewHitTestType.Cell Then

                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

                    Dim _Idmaedpce As Boolean = _Fila.Cells("IDMAEDPCE").Value
                    Dim _Idrsd As Boolean = _Fila.Cells("IDRSD").Value
                    Dim _Endp As Boolean = Not String.IsNullOrEmpty(_Fila.Cells("ENDP").Value)

                    Dim _Cabeza = Grilla_Maedpce.Columns(Grilla_Maedpce.CurrentCell.ColumnIndex).Name

                    If String.IsNullOrEmpty(_Fila.Cells("TIDP").Value) Then
                        Return
                    End If

                    If _Idmaedpce Then

                        Btn_Ver_Cta_Cte.Enabled = True
                        ShowContextMenu(Menu_Contextual_01)
                        Return

                    End If

                End If

            End With

        End If

    End Sub

    Private Sub Grilla_Maedpce_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla_Maedpce.CellMouseUp
        Grilla_Maedpce.EndEdit()
    End Sub

    Private Sub Chk_MostrarSoloMatchExactos_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_MostrarSoloMatchExactos.CheckedChanged
        Try
            If _Tbl_Maedpce Is Nothing Then
                Return
            End If

            If Chk_MostrarSoloMatchExactos.Checked Then
                ' Mostrar solo filas con Chk = True
                Try
                    _Tbl_Maedpce.DefaultView.RowFilter = "MatchExacto = True"
                Catch
                    ' En caso de que la columna no exista o tipo diferente, intentar con 1
                    Try
                        _Tbl_Maedpce.DefaultView.RowFilter = "MatchExacto = 1"
                    Catch ex As Exception
                        MessageBoxEx.Show(Me, "No se pudo aplicar el filtro: " & ex.Message, "Filtro",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End Try
                End Try
            Else
                ' Mostrar todas las filas
                _Tbl_Maedpce.DefaultView.RowFilter = String.Empty
            End If

            ' Asegurar que el DataGridView muestre la vista actualizada
            Grilla_Maedpce.DataSource = _Tbl_Maedpce.DefaultView

            ' Actualizar totales (la selección no cambia pero actualiza visualmente)
            Sb_Actualizar_Totales(False)

        Catch ex As Exception
            MessageBoxEx.Show(Me, "Error al aplicar el filtro de selección: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn_Importar_Pagos_Click(sender As Object, e As EventArgs) Handles Btn_Importar_Pagos.Click
        ShowContextMenu(Menu_Contextual_Exportar_Excel)
    End Sub

    Private Sub Btn_Mnu_ExportarExcelVistaActual_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_ExportarExcelVistaActual.Click

        Dim _Tbl As DataTable = CrearTablaPasoFiltrada()

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Pagos no vinculados - Cruce automatico - Vista actual")

    End Sub

    ''' <summary>
    ''' Crea una tabla de paso con las filas que actualmente pasan el filtro aplicado en _Tbl_Maedpce.DefaultView.
    ''' Esta versión es la más directa y rápida (usa DataView.ToTable()).
    ''' </summary>
    Private Function CrearTablaPasoFiltrada() As DataTable

        If _Tbl_Maedpce Is Nothing Then
            Return New DataTable()
        End If

        Try
            ' Devuelve una nueva DataTable con las filas que cumple el RowFilter actual
            Return _Tbl_Maedpce.DefaultView.ToTable()
        Catch ex As Exception
            ' En caso de error devolver tabla vacía
            Return New DataTable()
        End Try

    End Function

    ''' <summary>
    ''' Crea una tabla de paso con las filas filtradas pero preservando el esquema (tipos, restricciones, PK).
    ''' Esta versión clona el esquema y luego importa las filas visibles.
    ''' </summary>
    Private Function CrearTablaPasoFiltradaPreservandoEsquema() As DataTable

        If _Tbl_Maedpce Is Nothing Then
            Return New DataTable()
        End If

        Dim dtPaso As DataTable = _Tbl_Maedpce.Clone()

        Try
            For Each drv As DataRowView In _Tbl_Maedpce.DefaultView
                dtPaso.ImportRow(drv.Row)
            Next
        Catch ex As Exception
            ' Si falla, devolver la versión rápida como fallback
            Return CrearTablaPasoFiltrada()
        End Try

        Return dtPaso

    End Function

    ' Ejemplos de uso:
    ' Dim dt1 As DataTable = CrearTablaPasoFiltrada()
    ' Dim dt2 As DataTable = CrearTablaPasoFiltradaPreservandoEsquema()

    Private Sub Btn_Mnu_ExportarExcelTodo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_ExportarExcelTodo.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Maedpce, Me, "Pagos no vinculados - Cruce automatico")
    End Sub

    Private Sub Chk_MostrarSoloSeleccionados_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_MostrarSoloSeleccionados.CheckedChanged
        Try
            If _Tbl_Maedpce Is Nothing Then
                Return
            End If

            If Chk_MostrarSoloSeleccionados.Checked Then
                ' Mostrar solo filas con Chk = True
                Try
                    _Tbl_Maedpce.DefaultView.RowFilter = "Chk = True"
                Catch
                    ' En caso de que la columna no exista o tipo diferente, intentar con 1
                    Try
                        _Tbl_Maedpce.DefaultView.RowFilter = "Chk = 1"
                    Catch ex As Exception
                        MessageBoxEx.Show(Me, "No se pudo aplicar el filtro: " & ex.Message, "Filtro",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End Try
                End Try
            Else
                ' Mostrar todas las filas
                _Tbl_Maedpce.DefaultView.RowFilter = String.Empty
            End If

            ' Asegurar que el DataGridView muestre la vista actualizada
            Grilla_Maedpce.DataSource = _Tbl_Maedpce.DefaultView

            ' Actualizar totales visuales
            Sb_Actualizar_Totales(False)

        Catch ex As Exception
            MessageBoxEx.Show(Me, "Error al aplicar el filtro de selección: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Frm_CruceAntiNoVinculados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_CrucePAuto_Tom" & vbCrLf &
                       $"Where NombreEquipo = '{_NombreEquipo}'"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

    End Sub

End Class
