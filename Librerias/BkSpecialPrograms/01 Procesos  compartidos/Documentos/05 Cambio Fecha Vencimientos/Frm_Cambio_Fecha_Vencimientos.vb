Imports DevComponents.DotNetBar
Public Class Frm_Cambio_Fecha_Vencimientos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Idmaeedo
    Dim _TblEncDocumento, _TblVencimientos As DataTable
    Dim _Fechas_Actualizadas As Boolean

    Dim _Cuotas, _Dias_Entre_Vencimientos As Integer

    Public Property Pro_Fechas_Actualizadas As Boolean
        Get
            Return _Fechas_Actualizadas
        End Get
        Set(value As Boolean)
            _Fechas_Actualizadas = value
        End Set
    End Property

    Public Sub New(Idmaeedo As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        _Idmaeedo = Idmaeedo
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Txt_Cuotas.FocusHighlightEnabled = (Global_Thema <> Enum_Themas.Oscuro)
        Txt_Dias_Entre_Vencimientos.FocusHighlightEnabled = (Global_Thema <> Enum_Themas.Oscuro)
        Dtp_FechaUltVencimiento.FocusHighlightEnabled = (Global_Thema <> Enum_Themas.Oscuro)
        Dtp_Fecha_1er_Vencimiento.FocusHighlightEnabled = (Global_Thema <> Enum_Themas.Oscuro)
        Dtp_Fecha_Emision.FocusHighlightEnabled = (Global_Thema <> Enum_Themas.Oscuro)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Cambio_Fecha_Vencimientos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Sb_Ver_Vencimientos(False, False)

        Me.Text = "Cambiar vencimientos, " &
        _TblEncDocumento.Rows(0).Item("TIDO") & "-" & _TblEncDocumento.Rows(0).Item("NUDO")

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        _Cuotas = Txt_Cuotas.Text
        _Dias_Entre_Vencimientos = Txt_Dias_Entre_Vencimientos.Text

    End Sub


    Sub Sb_Ver_Vencimientos(_Solo_Encabezado As Boolean,
                            _Trae_Datos_Entidad As Boolean)

        Dim _SE As String = String.Empty

        If _Solo_Encabezado Then _SE = "And 0 > 1"

        Consulta_sql = "SELECT TOP 1 *,DATEDIFF(DD,FEEMDO,FE01VEDO) AS Dias_1er_Vencimiento FROM MAEEDO WITH ( NOLOCK ) " &
                       "WHERE IDMAEEDO = " & _Idmaeedo & vbCrLf &
                       "SELECT *,FEVE AS FECHA_OLD,Cast(0 As Int) As Id_Autoriza_Nomina FROM MAEVEN WHERE IDMAEEDO = " & _Idmaeedo & vbCrLf & _SE & vbCrLf

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql, False)

        _TblEncDocumento = _Ds.Tables(0)
        _TblVencimientos = _Ds.Tables(1)

        If _Trae_Datos_Entidad Then

            Consulta_sql = "SELECT TOP 1 * FROM MAEEN" & vbCrLf &
                           "WHERE KOEN = '" & _TblEncDocumento.Rows(0).Item("ENDO") &
                           "' And SUEN = '" & _TblEncDocumento.Rows(0).Item("SUENDO") & "'"
            Dim _TblMaeen As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Txt_Cuotas.Text = _TblMaeen.Rows(0).Item("NUVECR")
            Txt_Dias_Entre_Vencimientos.Text = _TblMaeen.Rows(0).Item("DIPRVE")

            _Dias_Entre_Vencimientos = Txt_Dias_Entre_Vencimientos.Text
            Dtp_Fecha_1er_Vencimiento.Value = DateAdd(DateInterval.Day, _Dias_Entre_Vencimientos, Dtp_Fecha_Emision.Value)
            Actualizar_Vencimientos(True)

        End If

        If Not _Solo_Encabezado Then

            Txt_Cuotas.Text = _TblEncDocumento.Rows(0).Item("NUVEDO")
            Txt_Dias_Entre_Vencimientos.Text = _TblEncDocumento.Rows(0).Item("Dias_1er_Vencimiento")
            Dtp_Fecha_Emision.Value = _TblEncDocumento.Rows(0).Item("FEEMDO")

            Dtp_Fecha_1er_Vencimiento.Value = _TblEncDocumento.Rows(0).Item("FE01VEDO")
            Dtp_FechaUltVencimiento.Value = _TblEncDocumento.Rows(0).Item("FEULVEDO")

            Btn_Reestablecer_Vencimientos.Visible = False
            Btn_Grabar_Vencimientos.Visible = False

            Dim _Vabrdo As Double = _TblEncDocumento.Rows(0).Item("VABRDO")
            Dim _Vaabdo As Double = _TblEncDocumento.Rows(0).Item("VAABDO")

            Dim _Saldo As Double = _Vabrdo - _Vaabdo

            If _Saldo = 0 Then
                Btn_Editar_Vencimientos.Enabled = False
            Else
                Btn_Editar_Vencimientos.Enabled = True
            End If

        End If


        With Grilla

            .DataSource = _TblVencimientos

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("FEVE").HeaderText = "Fecha Vencimiento" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("FEVE").Width = 90
            .Columns("FEVE").Visible = True
            .Columns("FEVE").ReadOnly = True

            .Columns("VAVE").HeaderText = "Valor Vencimiento." '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("VAVE").Width = 90
            .Columns("VAVE").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VAVE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAVE").Visible = True
            .Columns("VAVE").ReadOnly = True

            .Columns("VAABVE").HeaderText = "Valor Abonado" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("VAABVE").Width = 90
            .Columns("VAABVE").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VAABVE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAABVE").Visible = True
            .Columns("VAABVE").ReadOnly = True

            .Columns("OBSERVA").HeaderText = "Observación" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("OBSERVA").Width = 280
            .Columns("OBSERVA").Visible = True
            .Columns("OBSERVA").ReadOnly = True

        End With

        Me.Refresh()

        If CBool(Grilla.Rows.Count) Then

            Grilla.CurrentCell = Grilla.Rows(0).Cells("FEVE")
            Call Grilla_CellEnter(Nothing, Nothing)

        End If

    End Sub

    Private Sub Frm_Cambio_Fecha_Vencimientos_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Grabar_Vencimientos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Grabar_Vencimientos.Click

        If Fx_Grabar_Vencimientos(Me, _Idmaeedo, _TblVencimientos, _TblEncDocumento) Then

            _Fechas_Actualizadas = True
            Me.Close()

        End If

    End Sub

    Function Fx_Grabar_Vencimientos(_Formulario As Form,
                                    _Idmaeedo As Integer,
                                    _TblVencimientos As DataTable,
                                    _TblEncDocumento As DataTable) As Boolean

        Dim _Valor_Bruto_Doc As Double = _TblEncDocumento.Rows(0).Item("VABRDO")
        Dim _Valor_Bruto_Ven As Double = _TblVencimientos.Compute("Sum(VAVE)", "1>0")

        If _Valor_Bruto_Doc <> _Valor_Bruto_Ven Then
            MessageBoxEx.Show(_Formulario, "La sumatoria de los vencimientos no corresponde al total del documento" & vbCrLf &
                              "Modificaciones no serán incorporadas",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Consulta_sql = String.Empty
        Dim _Delete = False

        For Each _Fila As DataRow In _TblVencimientos.Rows

            Dim _Idmaeven = _Fila.Item("IDMAEVEN")
            Dim _Vave = _Fila.Item("VAVE")
            Dim _Espegve = _Fila.Item("ESPGVE")
            Dim _Feve = Format(_Fila.Item("FEVE"), "yyyyMMdd")
            Dim _Vaabve = _Fila.Item("VAABVE")
            Dim _Fecha_old = _Fila.Item("FECHA_OLD")
            Dim _Observa = Trim(_Fila.Item("OBSERVA"))
            Dim _Id_Autoriza_Nomina = NuloPorNro(_Fila.Item("Id_Autoriza_Nomina"), 0)

            If _Vave = _Vaabve Then
                _Espegve = "C"
            End If

            If CBool(_Idmaeven) Then

                Consulta_sql += "Update MAEVEN SET" & Space(1) &
                                "VAVE = " & _Vave & ",ESPGVE = '" & _Espegve & "'," &
                                "FEVE = '" & _Feve & "',VAABVE = " & _Vaabve & ",OBSERVA = '" & _Observa & "'" & vbCrLf &
                                "Where IDMAEVEN = " & _Idmaeven & vbCrLf & vbCrLf

            Else

                If Not _Delete Then
                    Consulta_sql += "Delete MAEVEN Where IDMAEEDO = " & _Idmaeedo & vbCrLf & vbCrLf
                End If

                _Delete = True

                Consulta_sql += "Insert Into MAEVEN (IDMAEEDO,FEVE,ESPGVE,VAVE,VAABVE,ARCHIRST,PORESTPAG,OBSERVA)" & vbCrLf &
                                "values (" & _Idmaeedo & ",'" & _Feve & "',''," & De_Num_a_Tx_01(_Vave, False, 5) & ",0,'',0,'" & _Observa & "')" & vbCrLf & vbCrLf

            End If

            If Not String.IsNullOrEmpty(_Observa) Then

                Dim _HoraGrab = Hora_Grab_fx(False)

                Consulta_sql += "Insert Into MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC," &
                                "FECHAREF,HORAGRAB) VALUES " & vbCrLf &
                                "('MAEEDO'," & _Idmaeedo & ",'',0,'" & FUNCIONARIO &
                                "',GetDate(),'FECHA_VENC','CAMBIO','" & _Observa &
                                "','" & Format(_Fecha_old, "yyyyMMdd") & "'," & _HoraGrab & ")" & vbCrLf & vbCrLf
            End If

            If CBool(_Id_Autoriza_Nomina) Then

                Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det_Eli (Id_Autoriza,Idmaeedo,Idmaeven,Saldo,Observacion)
                                 Select Id_Autoriza,Idmaeedo,Idmaeven,Saldo,'Se modifica fecha de vencimento desde Bakapp por (" & FUNCIONARIO & ")' 
                                 From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det
                                 Where Id_Autoriza = " & _Id_Autoriza_Nomina & " And Idmaeven = " & _Idmaeven & vbCrLf &
                                "Delete " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where Id_Autoriza = " & _Id_Autoriza_Nomina & " And Idmaeven = " & _Idmaeven & vbCrLf & vbCrLf

            End If

        Next

        Consulta_sql += vbCrLf &
                       "Update MAEEDO SET FE01VEDO = (Select Min(FEVE) From MAEVEN WHERE IDMAEEDO=" & _Idmaeedo & ") " &
                       "Where IDMAEEDO = " & _Idmaeedo & vbCrLf &
                       "Update MAEEDO SET FEULVEDO = (Select Max(FEVE) From MAEVEN WHERE IDMAEEDO=" & _Idmaeedo & ") " &
                       "Where IDMAEEDO = " & _Idmaeedo & vbCrLf &
                       "Update MAEEDO SET NUVEDO = (Select Count(*) From MAEVEN WHERE IDMAEEDO=" & _Idmaeedo & ") " &
                       "Where IDMAEEDO = " & _Idmaeedo

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
            Return True
        Else
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Function

    Private Sub Grilla_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles Grilla.CellBeginEdit

        Try

            Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Idmaeven = _Fila.Cells("IDMAEVEN").Value
            Dim _Vave = _Fila.Cells("VAVE").Value
            Dim _Espegve = _Fila.Cells("ESPGVE").Value
            Dim _Feve = _Fila.Cells("FEVE").Value
            Dim _Vaabve = _Fila.Cells("VAABVE").Value
            Dim _Observa = _Fila.Cells("OBSERVA").Value

            'Dim _Reg =_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "", "")

            'If CBool(_Reg) Then
            'Throw New Exception("Este vencimiento fue cancelado a travez de pagos masivos por BakApp, no se puede modificar")
            'End If

            If _Cabeza = "VAVE" Then
                If CBool(_Vaabve) Then
                    Throw New Exception("Este vencimiento tiene abonos asociados, no se puede cambiar")
                    'MessageBoxEx.Show(Me, "Este vencimiento tiene abonos asociados, no se puede cambiar", _
                    '                   "Validación", _
                    '                   MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End Try


    End Sub

    Private Sub Grilla_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Idmaeve = _Fila.Cells("IDMAEVEN").Value
        Dim _Vave = _Fila.Cells("VAVE").Value
        Dim _Espegve = _Fila.Cells("ESPGVE").Value
        Dim _Feve As Date = FormatDateTime(_Fila.Cells("FEVE").Value, DateFormat.ShortDate)
        Dim _Vaabve = _Fila.Cells("VAABVE").Value
        Dim _Observa = _Fila.Cells("OBSERVA").Value
        Dim _Fecha_old As Date = FormatDateTime(_Fila.Cells("FECHA_OLD").Value, DateFormat.ShortDate)

        Dim _Feemdo As Date = _TblEncDocumento.Rows(0).Item("FEEMDO")

        Grilla.Columns(_Cabeza).ReadOnly = True

        _Fila.Cells("OBSERVA").Value = String.Empty

        If Grilla.Rows.Count > 1 And Grilla.CurrentRow.Index > 0 Then

            If _Cabeza = "FEVE" Then

                Dim _Fl As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index - 1)
                Dim _Feve_Row As Date = FormatDateTime(_Fl.Cells("FEVE").Value, DateFormat.ShortDate)

                If _Feve_Row > _Feve Then
                    MessageBoxEx.Show(Me, "La fecha debe ser mayor que " & _Feve_Row & vbCrLf & vbCrLf &
                                      "Nota: La fecha de vencimiento debe ser mayor que la fecha del vencimiento anterior",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    _Fila.Cells("FEVE").Value = _Fecha_old
                    _Feve = _Fecha_old
                End If

                If _Feve_Row = _Feve Then
                    MessageBoxEx.Show(Me, "La fecha es igual al vencimiento anterior",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '_Fila.Cells("FEVE").Value = _Fecha_old
                End If

            End If

        End If
        If _Feemdo > _Feve Then

            MessageBoxEx.Show(Me, "La fecha de emisión no puede ser menor que la fecha de vencimiento",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            _Fila.Cells("FEVE").Value = _Fecha_old

        Else

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where Idmaeven = " & _Idmaeve
            Dim _Row_Pago_Prov As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Pago_Prov) Then

                Dim _Id_Autoriza = _Row_Pago_Prov.Item("Id_Autoriza")

                _Fila.Cells("Id_Autoriza_Nomina").Value = _Id_Autoriza

            End If

            If _Fecha_old <> _Feve Then

                _Fila.Cells("OBSERVA").Value = "Fecha de vencimiento " & FormatDateTime(_Fecha_old, DateFormat.ShortDate) &
                        " por " & FormatDateTime(_Feve, DateFormat.ShortDate)

            End If

        End If

    End Sub

    Private Sub Btn_AceptarVencimientos_Click(seder As System.Object, e As System.EventArgs) Handles Btn_AceptarVencimientos.Click

        Sb_Ver_Vencimientos(True, False)
        Actualizar_Vencimientos(True)
        Grupo_CondPago.Enabled = False
        Grilla.Enabled = True
        Btn_Grabar_Vencimientos.Visible = True
        Me.Refresh()

    End Sub


    Sub Sb_Procesar_Cond_Pago(_Fecha_Emision As Date)

        Sb_Ver_Vencimientos(True, False)

        Dim _Cuotas As Integer = _Cuotas

        If _Cuotas = 0 Then
            Txt_Cuotas.Text = 1
            _Cuotas = 1
        End If

        Dim Cuotas_(_Cuotas - 1) As Date

        Dim _FechasVenci,
            _Fecha_1er_Vencimiento,
            _FechaUltVencimiento As Date

        Dim _dias As Integer

        If _Dias_Entre_Vencimientos > 0 And _Cuotas > 1 Then
            _dias = _Dias_Entre_Vencimientos
            For i = 1 To _Cuotas
                _FechasVenci = DateAdd(DateInterval.Day, _dias, _Fecha_Emision)
                Cuotas_(i - 1) = _FechasVenci
                _dias = _Dias_Entre_Vencimientos '_Dias_Vencimiento
            Next
            _FechaUltVencimiento = _FechasVenci
        Else

            _Fecha_1er_Vencimiento = DateAdd(DateInterval.Day, _Dias_Entre_Vencimientos, Now)
            Dtp_Fecha_1er_Vencimiento.Value = _Fecha_1er_Vencimiento

            Cuotas_(0) = _Fecha_1er_Vencimiento

            _FechaUltVencimiento = _Fecha_1er_Vencimiento
            _Cuotas = 1

        End If

        Dtp_Fecha_1er_Vencimiento.Value = _Fecha_1er_Vencimiento
        Dtp_FechaUltVencimiento.Value = _FechaUltVencimiento

    End Sub


    Private Sub Nueva_Linea(_Feve As Date,
                            _Vave As Double)

        Dim NewFila As DataRow
        NewFila = _TblVencimientos.NewRow
        With NewFila

            .Item("VAVE") = _Vave
            .Item("ESPGVE") = ModBodega
            .Item("FEVE") = String.Empty
            .Item("VAABVE") = String.Empty
            .Item("OBSERVA") = 0
            .Item("FECHA_OLD") = 0


            _TblVencimientos.Rows.Add(NewFila)
        End With

    End Sub

    Sub Actualizar_Vencimientos(_Agregar_Fila As Boolean)

        Dim _Idmaeedo As Integer = _TblEncDocumento.Rows(0).Item("IDMAEEDO")
        Dim _TotalBrutoDoc As Double = _TblEncDocumento.Rows(0).Item("VABRDO")

        Dim _FechaEmision As Date = _TblEncDocumento.Rows(0).Item("FEEMDO")
        Dim _Fecha_1er_Vencimiento As Date = Dtp_Fecha_1er_Vencimiento.Value

        Dim _Cuotas As Integer = Val(Txt_Cuotas.Text)
        Dim _Dias_Vencimiento As Integer = Val(Txt_Dias_Entre_Vencimientos.Text)

        If _Cuotas = 0 Then _Cuotas = 1

        Dim Cuotas_(_Cuotas - 1) As Date
        Cuotas_(0) = _Fecha_1er_Vencimiento

        Dim _FechasVenci As Date = _FechaEmision
        Dim _dias As Integer

        Dim _Resultado As Double = _TotalBrutoDoc / _Cuotas
        Dim _Vave As Double = Math.Round(_TotalBrutoDoc / _Cuotas, 0)

        _dias = _Dias_Vencimiento

        For i = 1 To _Cuotas

            _FechasVenci = DateAdd(DateInterval.Day, _dias, _FechasVenci)
            Cuotas_(i - 1) = _FechasVenci
            _dias = _Dias_Vencimiento

            If _Agregar_Fila Then

                Dim NewFila As DataRow
                NewFila = _TblVencimientos.NewRow
                With NewFila

                    If i = _Cuotas Then
                        Dim rS = _Vave * _Cuotas
                        rS = _TotalBrutoDoc - rS
                        rS = _Vave + rS
                        _Vave = rS
                    End If

                    .Item("IDMAEVEN") = 0
                    .Item("IDMAEEDO") = _Idmaeedo
                    .Item("VAVE") = _Vave
                    .Item("ESPGVE") = ""

                    If i = 1 Then
                        .Item("FEVE") = _Fecha_1er_Vencimiento
                    Else
                        .Item("FEVE") = _FechasVenci
                    End If

                    .Item("VAABVE") = 0
                    .Item("OBSERVA") = "Fechas reestablecidas"
                    .Item("FECHA_OLD") = _FechasVenci

                    _TblVencimientos.Rows.Add(NewFila)

                End With

            End If

        Next

        Dtp_FechaUltVencimiento.Value = _FechasVenci

    End Sub

    Private Sub Btn_Reestablecer_Vencimientos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Reestablecer_Vencimientos.Click

        Dim _Suma As Double = _TblVencimientos.Compute("SUM(VAABVE)", "1>0")
        Btn_Reestablecer_Vencimientos.Visible = False
        Btn_Grabar_Vencimientos.Visible = False

        Me.Refresh()

        If Not CBool(_Suma) Then
            If Fx_Tiene_Permiso(Me, "Espr0008") Then
                Sb_Ver_Vencimientos(True, True)
                Grupo_CondPago.Enabled = True
                Grilla.Enabled = False
            Else
                Btn_Reestablecer_Vencimientos.Visible = True
                Btn_Grabar_Vencimientos.Visible = True
            End If
        Else
            MessageBoxEx.Show(Me, "Existen abonos en los vencimientos, no es posible reestablecer las fechas",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Txt_Validated(sender As System.Object, e As System.EventArgs)
        If String.IsNullOrEmpty(CType(sender, TextBox).Text) Then
            CType(sender, TextBox).Text = 0
        End If
    End Sub

    Private Sub Txt_Dias_Entre_Vencimientos_Validated(sender As System.Object, e As System.EventArgs) Handles Txt_Dias_Entre_Vencimientos.Validated

        _Dias_Entre_Vencimientos = Txt_Dias_Entre_Vencimientos.Text
        Dtp_Fecha_1er_Vencimiento.Value = DateAdd(DateInterval.Day, _Dias_Entre_Vencimientos, Dtp_Fecha_Emision.Value)
        Sb_Ver_Vencimientos(True, False)
        Actualizar_Vencimientos(True)

    End Sub

    Private Sub Grilla_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEnter

        Dim _Vabrdo As Double = _TblEncDocumento.Rows(0).Item("VABRDO")
        Dim _Vaabdo As Double = _TblEncDocumento.Rows(0).Item("VAABDO")

        Dim _Saldo As Double = _Vabrdo - _Vaabdo

        If _Saldo = 0 Then
            Warning_Nomina.Visible = 0
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaeven = _Fila.Cells("IDMAEVEN").Value

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where Idmaeven = " & _Idmaeven & " And Id_Autoriza <> 0"
        Dim _Row_Pago_Prov As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Warning_Nomina.Visible = (Not IsNothing(_Row_Pago_Prov))

    End Sub

    Private Sub Warning_Nomina_OptionsClick(sender As Object, e As EventArgs) Handles Warning_Nomina.OptionsClick

        Try
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Idmaeven = _Fila.Cells("IDMAEVEN").Value

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where Idmaeven = " & _Idmaeven & " --And Id_Autoriza <> 0"
            Dim _Row_Pago_Prov As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Pago_Prov) Then

                Dim _Id_Autoriza = _Row_Pago_Prov.Item("Id_Autoriza")

                Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_01_Enc Where Id_Autoriza = " & _Id_Autoriza
                Dim _Row_Pago_Prov_Enc As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Referencia = _Row_Pago_Prov_Enc.Item("Referencia")

                MessageBoxEx.Show(Me, "Este vencimiento se encuentra asociado a una nomina de pagos autorizados." & vbCrLf &
                                    "Nomina de pago: (Id " & _Id_Autoriza & ") - " & _Referencia.ToString.Trim & vbCrLf & vbCrLf &
                                    "Nota: si cambia la fecha se eliminara la asociación a la nomina", "Documento en nomina de pagos",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Idmaeve = _Fila.Cells("IDMAEVEN").Value
        Dim _Fecha_old = _Fila.Cells("FECHA_OLD").Value

        Dim _Editar As Boolean

        If Btn_Reestablecer_Vencimientos.Visible Or Grilla.RowCount = 1 Then

            If e.KeyValue = Keys.Enter Then

                If _Cabeza = "FEVE" Then

                    Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where Idmaeven = " & _Idmaeve
                    Dim _Row_Pago_Prov As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If Not IsNothing(_Row_Pago_Prov) Then

                        Dim _Id_Autoriza = _Row_Pago_Prov.Item("Id_Autoriza")

                        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_01_Enc Where Id_Autoriza = " & _Id_Autoriza
                        Dim _Row_Pago_Prov_Enc As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        Dim _Referencia = _Row_Pago_Prov_Enc.Item("Referencia")

                        If MessageBoxEx.Show(Me, "Este vencimiento se encuentra asociado a una nomina de pagos autorizados." & vbCrLf &
                                                "Nomina de pago: (Id " & _Id_Autoriza & ") - " & _Referencia.ToString.Trim & vbCrLf & vbCrLf &
                                                "Si confirma la grabación el documento se eliminara de la nomina al grabar los nuevos vencimientos." & vbCrLf & vbCrLf &
                                                "¿Confirma cambiar la fecha de vencimiento?", "Documento en nomina de pagos",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then

                            _Fila.Cells("FEVE").Value = _Fecha_old

                            Return

                        End If

                        _Fila.Cells("Id_Autoriza_Nomina").Value = _Id_Autoriza

                    End If

                    _Editar = True

                End If

                If _Cabeza = "VAVE" Then

                    If Grilla.RowCount <= 1 Then
                        Beep()
                        Return
                    End If

                    _Editar = True

                End If

            End If

        End If

        If _Editar Then

            Grilla.Columns(_Cabeza).ReadOnly = False
            Grilla.BeginEdit(True)

            e.SuppressKeyPress = False
            e.Handled = True

        End If

    End Sub

    Private Sub Grilla_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grilla.DataError

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Select Case _Cabeza

            Case "FEVE"

                _Fila.Cells(_Cabeza).Value = _Fila.Cells("FECHA_OLD").Value

        End Select

        MessageBoxEx.Show(Me, e.Exception.Message, "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)

    End Sub

    Private Sub Txt_Cuotas_Validated(sender As System.Object, e As System.EventArgs) Handles Txt_Cuotas.Validated
        _Dias_Entre_Vencimientos = Txt_Dias_Entre_Vencimientos.Text
        Dtp_Fecha_1er_Vencimiento.Value = DateAdd(DateInterval.Day, _Dias_Entre_Vencimientos, Dtp_Fecha_Emision.Value)
        Sb_Ver_Vencimientos(True, False)
        Actualizar_Vencimientos(True)
    End Sub


    Private Sub Btn_Editar_Vencimientos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Editar_Vencimientos.Click

        If Fx_Tiene_Permiso(Me, "Doc00006") Then

            Dim _Vaabdo As Double = _TblEncDocumento.Rows(0).Item("VAABDO")

            If CBool(_Vaabdo) Then
                Btn_Reestablecer_Vencimientos.Visible = False
            Else
                Btn_Reestablecer_Vencimientos.Visible = True
            End If

            Btn_Grabar_Vencimientos.Visible = True
            Btn_Editar_Vencimientos.Enabled = False

            Beep()
            ToastNotification.Show(Me, "AHORA ES POSIBLE EDITAR LOS VENCIMIENTOS", My.Resources.ok_button,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

            Me.Refresh()

        End If

    End Sub
End Class
