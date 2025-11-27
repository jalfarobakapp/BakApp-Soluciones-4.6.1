Public Class Frm_CruceAntiNoVinculados

    Dim Consulta_Sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Private _Tbl_Maedpce As DataTable

    Public Property Lista_Idmaedpce As List(Of Integer)

    ' Caché por ENDP para reutilizar listas de documentos y que se actualicen Abono/SaldoAct
    Private _CacheMaeedoPorEndp As New Dictionary(Of String, List(Of Cl_MaeedoItem))(StringComparer.OrdinalIgnoreCase)

    Public Sub New()


        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Maedpce, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_CruceAntiNoVinculados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla_Maedpce.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()


        Dim _Filtro_Idmaedpce As String = Generar_Filtro_IN_Lista(Lista_Idmaedpce, True, "")

        Consulta_Sql = $"SELECT 
    Cast(0 As Int) As Id,
    Cast(0 As Bit) As Chk,
    c.IDMAEDPCE,
    c.EMPRESA,
    c.SUREDP,
    c.CJREDP,
    c.TIDP,
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
    CAST(0 AS INT) AS IDMAEEDO,
    CAST(0 AS FLOAT) AS SALDO,
    Cast(0 As Float) As LEY20956,
    Cast('' As Varchar(14)) As Doc_Anticipo,
    Cast('' As Varchar(30)) As NOTIDP,
    Cast('' As Varchar(30)) As NOKOENDP,
    Cast(0 As Bit) As Error,
    Cast(0 As Bit) As Exclamacion,
    Cast('' As Varchar(100)) As Observacion,
    CAST(0 As Bit) As CruzarPagoAuto
FROM MAEDPCE c WITH (NOLOCK)
OUTER APPLY (
    SELECT TOP 1 NOKOEN
    FROM MAEEN e WITH (NOLOCK)
    WHERE e.KOEN = c.ENDP
    ORDER BY e.KOEN -- aquí puedes cambiar el criterio de orden si quieres
) e
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

            .Columns("FEVEDP").HeaderText = "F.venci."
            .Columns("FEVEDP").Width = 65
            .Columns("FEVEDP").Visible = True
            .Columns("FEVEDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEVEDP").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEVEDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CUDP").HeaderText = "Mon"
            .Columns("CUDP").Width = 30
            .Columns("CUDP").Visible = True
            .Columns("CUDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CUDP").HeaderText = "Cuenta"
            .Columns("CUDP").Width = 100
            .Columns("CUDP").Visible = True
            .Columns("CUDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NUCUDP").HeaderText = "Número doc."
            .Columns("NUCUDP").Width = 80
            .Columns("NUCUDP").Visible = True
            .Columns("NUCUDP").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MODP").HeaderText = "M."
            .Columns("MODP").ToolTipText = "Moneda"
            .Columns("MODP").Width = 30
            .Columns("MODP").Visible = True
            .Columns("SALDO_PG").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
            .Columns("REFANTI").Width = 220
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

            .Columns("Doc_Anticipo").HeaderText = "Doc.Asoc.Anticipo"
            .Columns("Doc_Anticipo").Width = 110
            .Columns("Doc_Anticipo").Visible = True
            .Columns("Doc_Anticipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_MacthDocumentos_Click(sender As Object, e As EventArgs) Handles Btn_MacthDocumentos.Click

        Dim _Ls_MaeedoItem As New List(Of Cl_MaeedoItem)
        Dim _Cl_MaeedoItem As New Cl_MaeedoItem

        _CacheMaeedoPorEndp.Clear()

        For Each _Fila As DataRow In _Tbl_Maedpce.Rows

            Dim _Idmaedpce As Integer = _Fila.Item("IDMAEDPCE")
            Dim _Endp As String = _Fila.Item("ENDP").ToString.Trim
            Dim _Saldo_Pg As Double = _Fila.Item("SALDO_PG")
            Dim _Modp As String = _Fila.Item("MODP")

            If _Modp.ToString.Trim <> "$" Then
                Continue For
            End If

            If String.IsNullOrEmpty(_Endp) Then
                Continue For
            End If

            If _Endp = "21276350" Then
                Dim _Acato = 1
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
       ROUND(EDO.VABRDO,2) -  ROUND(EDO.VAABDO,2) as SALDO,
       CAST(0 AS FLOAT) AS ABONO,
       CAST(0 AS FLOAT) AS ABONO2,
       ROUND(EDO.VABRDO,2) -  ROUND(EDO.VAABDO,2) as SALDO_ACT,
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
                                    _Fila("Chk") = True
                                    _Fila("IDMAEEDO") = _Item.IdRst
                                    _Match = True

                                    ' Actualizar abono y saldo en el item (afectará al caché y a _Ls_MaeedoItem porque son mismas referencias)
                                    If Double.IsNaN(_Item.Abono) Then
                                        _Item.Abono = 0
                                    End If

                                    _Item.Abono = Math.Round(_Item.Abono + _Saldo_Pg, 2)
                                    _Item.SaldoAct = Math.Round(Math.Max(0, _Item.SaldoAct - _Saldo_Pg), 2)
                                    _Fila("REFANTI") = "Match con: " & _Item.Tido & " - " & _Item.Nudo & ", Saldo: " & FormatNumber(_Item.SaldoAct, 0)


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
                                'If _Item.SaldoAct >= _Saldo_Pg Then
                                Try
                                    _Fila("Chk") = True
                                    _Fila("IDMAEEDO") = _Item.IdRst
                                    _Match = True

                                    If Double.IsNaN(_Item.Abono) Then
                                        _Item.Abono = 0
                                    End If

                                    _Item.Abono = Math.Round(_Item.Abono + _Saldo_Pg, 2)
                                    _Item.SaldoAct = Math.Round(Math.Max(0, _Item.SaldoAct - _Saldo_Pg), 2)
                                    _Fila("REFANTI") = "Match con: " & _Item.Tido & " - " & _Item.Nudo & ", Saldo: " & FormatNumber(_Item.SaldoAct, 0)

                                    Dim _Utilizado As Double = _Saldo_Pg - _Item.SaldoAct

                                Catch ex As Exception
                                    ' Ignorar si no se puede escribir en la fila
                                End Try

                                Exit For
                                'End If
                            Catch ex As Exception
                                ' Ignorar errores por valores nulos o conversiones inesperadas
                            End Try
                        Next
                    End If

                Catch ex As Exception
                    ' Por seguridad, ignorar errores al escribir en la fila (si columna no existe por ejemplo)
                End Try
            End If

            ' Si no hubo match y la lista estaba vacía, ya se cargó y no hay documentos.
            ' Si hubiera lógica para distribuir pagos en varios documentos (split), implementarla aquí.

        Next

        ' Opcional: si desea usar _Ls_MaeedoItem más adelante, ya contiene referencias cuyo Abono y SaldoAct fueron actualizados.

    End Sub

End Class
