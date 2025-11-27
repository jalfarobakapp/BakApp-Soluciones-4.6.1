Imports DevComponents.DotNetBar

Public Class Frm_CruceAntiNoVinculados

    Dim Consulta_Sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Private _Tbl_Maedpce As DataTable

    Public Property Lista_Idmaedpce As List(Of Integer)

    ' Caché por ENDP para reutilizar listas de documentos y que se actualicen Abono/SaldoAct
    Private _CacheMaeedoPorEndp As New Dictionary(Of String, List(Of Cl_MaeedoItem))(StringComparer.OrdinalIgnoreCase)
    Private _Filtro_Idmaedpce As String

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

        Sb_Actualizar_Grilla()

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
    Cast('' As Varchar(30)) As NOTIDP,
    Cast('' As Varchar(30)) As NOKOENDP,
    Cast(0 As Bit) As Error,
    Cast(0 As Bit) As Exclamacion,
    Cast('' As Varchar(100)) As Observacion,
    Cast(0 As Bit) As CruzarPagoAuto
FROM MAEDPCE c WITH (NOLOCK)
OUTER APPLY (
    SELECT TOP 1 NOKOEN
    FROM MAEEN e WITH (NOLOCK)
    WHERE e.KOEN = c.ENDP
    ORDER BY e.KOEN -- aquí puedes cambiar el criterio de orden si quieres
) e
Left Join MAEEDO Edo On Edo.IDMAEEDO = c.IDRSD And c.ARCHIRSD = 'MAEEDO'
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
                                    _Fila("CruzarPagoAuto") = True
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
                                    _Fila("CruzarPagoAuto") = True
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
        Sb_Actualizar_Grilla()
    End Sub


    Private Sub Chk_Seleccionar_Todo_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Seleccionar_Todo.CheckedChanged

        Dim _HayFilasParaCruzar As Boolean = False

        For Each _Fila As DataRow In _Tbl_Maedpce.Rows

            If Chk_Seleccionar_Todo.Checked Then
                If _Fila.Item("CruzarPagoAuto") Then
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
                Return
            End If

        End If

    End Sub

    Private Sub Btn_Grabar_Autorizacion_Click(sender As Object, e As EventArgs) Handles Btn_Grabar_Autorizacion.Click

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

    End Sub

    Function Fx_Pagar_Documentos(_Fila As DataRow) As LsValiciones.Mensajes

        Dim _Mensaje As LsValiciones.Mensajes

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

            Dim _Tido As String = _Row_Maeedo.Item("TIDO")
            Dim _Nudo As String = _Row_Maeedo.Item("NUDO")

            'If IsNothing(_Row_Maeedo) Then

            '    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
            '       "Error_Paga = 1,PagarAuto = 0,Pagada = 0,Informacion_Paga = 'No se encontro el documentos en la tabla MAEEDO, IDMAEEDO =  " & _Idmaeedo & "'" & vbCrLf &
            '       "Where Id = " & _Id
            '    If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
            '        Log_Registro += _Sql.Pro_Error
            '    End If
            '    Continue For

            'End If

            Dim _Saldo As Double = _Row_Maeedo.Item("TOTSALDO")

            'If _Saldo <= 0 Then

            '    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
            '                       "Error_Paga = 1,PagarAuto = 0,Pagada = 0,Informacion_Paga = 'La " & _Notido & " no tiene saldo a pagar'" & vbCrLf &
            '                       "Where Id = " & _Id
            '    If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
            '        Log_Registro += _Sql.Pro_Error
            '    End If
            '    Continue For

            'End If

            Consulta_Sql = "Select TOP 1 * From MAEDPCE Where IDMAEDPCE = " & _Idmaedpce
            Dim _Row_Maedpce As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql, False)

            'If IsNothing(_Row_Maedpce) Then

            '    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
            '       "Error_Paga = 1,PagarAuto = 0,Pagada = 0,Informacion_Paga = 'No se encontro el documentos en la tabla MAEDPCE, IDMAEDPCE =  " & _Idmaedpce_Paga & "'" & vbCrLf &
            '       "Where Id = " & _Id
            '    If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
            '        Log_Registro += _Sql.Pro_Error
            '    End If
            '    Continue For

            'End If

            Dim _Vadp As Double = _Row_Maedpce.Item("VADP")
            Dim _Vaasdpce As Double = _Row_Maedpce.Item("VAASDP")

            Dim _SaldoPago As Double = _Row_Maedpce.Item("VADP") - _Row_Maedpce.Item("VAASDP")

            'If _SaldoPago <= 0 Then
            '    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
            '                       "Error_Paga = 1,PagarAuto = 0,Pagada = 0,Informacion_Paga = 'El documento de pago no tiene saldo para pagar'" & vbCrLf &
            '                       "Where Id = " & _Id
            '    If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
            '        Log_Registro += _Sql.Pro_Error
            '    End If
            '    Continue For
            'End If

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
                .ARCHIRSD = _Row_Maedpce.Item("ARCHIRSD"),
                .IDRSD = _Row_Maedpce.Item("IDRSD"),
                .KOTNDP = _Row_Maedpce.Item("KOTNDP"),
                .SUTNDP = _Row_Maedpce.Item("SUTNDP")
                }

            Dim _Fecha_Asignacion_Pago As Date = FechaDelServidor()
            Dim _Ls_Maedpce As New List(Of MAEDPCE)

            _Ls_Maedpce.Add(_Maedpce)

            _Mensaje = _Cl_Pagar.Fx_Pagar_Documento(_Idmaeedo, _Ls_Maedpce, _Fecha_Asignacion_Pago)

            If _Mensaje.EsCorrecto Then

                Dim _Row_Maedpcd As DataRow = _Mensaje.Tag

                Dim _Archirst = "MAEDPCD"
                Dim _Idrst = _Row_Maedpcd.Item("IDMAEDPCD")
                Dim _Accion = "PAGO DOCUMENTO CON SALDO DE ANTICIPO DE FORMA MASIVA DESDE BAKAPP"

                Dim _Id = Fx_Add_Log_Gestion(FUNCIONARIO, Mod_Modalidad, _Archirst, _Idrst, "", _Accion,
                                     "", "", "", "", False, FUNCIONARIO,,,, _Tido, _Nudo)

                'Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set Pagada = 1 Where Id = " & _Id
                '_Sql.Ej_consulta_IDU(Consulta_Sql, False)

                'If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                '    Log_Registro += _Sql.Pro_Error
                'End If

            Else

                _Mensaje.Mensaje = Replace(_Mensaje.Mensaje, " '", "''")
                'Log_Registro += _Mensaje.Mensaje & vbCrLf
                'Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
                '                   ",PagarAuto = 0" &
                '                   ",Pagada = 0" &
                '                   ",Error_Paga = 1" &
                '                   ",Informacion_Paga = '" & _Mensaje.Mensaje & "'" & vbCrLf &
                '                   "Where Id = " & _Id
                'If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                '    Log_Registro += _Sql.Pro_Error
                'End If

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


End Class
