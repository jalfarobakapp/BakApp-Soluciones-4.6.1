Imports DevComponents.DotNetBar

Imports BkSpecialPrograms

Public Class Frm_DFA_Ingreso

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_OT As DataRow
    Dim _Row_SubOt As DataRow
    Dim _Row_Maquina As DataRow

    Dim _Idpote As Integer
    Dim _Idpotl As Integer


    Dim _Ds_DFA As DataSet

    Dim _Tbl_Pdatfae As DataTable
    Dim _Tbl_Pdatfad As DataTable ' PDATFAD Detalle Sub-OT
    Dim _Tbl_Pobrefad As DataTable ' Operarios


    Public Property Pro_Row_OT() As DataRow
        Get
            Return _Row_OT
        End Get
        Set(ByVal value As DataRow)
            _Row_OT = value
        End Set
    End Property
    Public Property Pro_Row_Maquina() As DataRow
        Get
            Return _Row_Maquina
        End Get
        Set(ByVal value As DataRow)

        End Set
    End Property
    Public Property Pro_Tbl_Pobrefad() As DataTable
        Get
            Return _Tbl_Pobrefad
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Pobrefad = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Pobrefad, 20, New Font("Tahoma", 10), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Dim _TipoEstacion = Trim(_Global_Row_EstacionBk.Item("TipoEstacion"))

        If _TipoEstacion = "Dfa" Then
            Me.ControlBox = True
            Me.MinimizeBox = True
            Me.ShowInTaskbar = True
        End If

    End Sub

    Private Sub Frm_DFA_Ingreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = UCase(Me.Text)
        Sb_Limpiar_DFA()
        Me.ActiveControl = Txt_Numero_OT

    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Function Fx_Trae_OT(ByVal _Numot As String) As DataRow

        Consulta_sql = "Select Top 1 * From POTE Where EMPRESA = '" & ModEmpresa & "' Adn NUMOT = '" & _Numot & "'"
        Fx_Trae_OT = _Sql.Fx_Get_DataRow(Consulta_sql)

    End Function

    Function Fx_Trae_Operaciones_SubOt(ByVal _Idpotl As Integer, ByVal _Cod_Maquina As String) As DataTable

        Consulta_sql = "SELECT POTPR.*,POPER.NOMBREOP,POPER.UDAD,POPER.OBREROS,POPER.CODMAQ," & _
                       "ISNULL((SELECT TOP 1 NOMBREMAQ FROM PMAQUI WITH ( NOLOCK )  WHERE CODMAQ=POPER.CODMAQ),'') as MAQUINA," & _
                       "PVELPROP.NOOPPR,PVELPROP.CODMAQOPPR " & vbCrLf & _
                       "FROM POTPR WITH ( NOLOCK ) " & vbCrLf & _
                       "LEFT OUTER JOIN POPER ON POTPR.OPERACION=POPER.OPERACION " & vbCrLf & _
                       "LEFT OUTER JOIN PVELPROP ON POTPR.OPERACION=PVELPROP.OPERACION AND POTPR.CODIGO = PVELPROP.KOPR " & vbCrLf & _
                       "WHERE POTPR.IDPOTL='" & _Idpotl & "'" & vbCrLf & _
                       "AND POPER.CODMAQ = '" & _Cod_Maquina & "'"

        Fx_Trae_Operaciones_SubOt = _Sql.Fx_Get_Tablas(Consulta_sql)

    End Function

    Private Sub Btn_Crear_Nueva_DFA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_Nueva_DFA.Click
        Sb_Limpiar_DFA()
        Txt_Numero_OT.Focus()
    End Sub

    Sub Sb_Nueva_DFA()

        Dim Fm_B As Frm_Seleccionar_Op_SubOt_Maq_Etc
        Dim Fm As Frm_Buscar_Pistoleando

        Fm = New Frm_Buscar_Pistoleando(Frm_Buscar_Pistoleando.Enum_Tipo_Busqueda.OT)
        Fm.ShowDialog(Me)
        _Row_OT = Fm.Pro_Row_Fila
        Fm.Dispose()

        If Not (_Row_OT Is Nothing) Then
            _Idpote = _Row_OT.Item("IDPOTE")
            Txt_Numero_OT.Text = _Row_OT.Item("NUMOT")
            Lbl_Referencia.Text = _Row_OT.Item("REFERENCIA")
        Else
            Return
        End If

        Consulta_sql = "Select * From POTL Where IDPOTE = " & _Idpote ' & " And NIVEL = 0"
        Dim _Tbl_SubOt As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If _Tbl_SubOt.Rows.Count = 1 Then
            _Row_SubOt = _Tbl_SubOt.Rows(0)
        ElseIf _Tbl_SubOt.Rows.Count > 1 Then
            ' MAS DE UNA SUB OT
            Fm_B = New Frm_Seleccionar_Op_SubOt_Maq_Etc("CODIGO", "GLOSA", _Tbl_SubOt)
            Fm_B.ShowDialog(Me)
            _Row_SubOt = Fm_B.Pro_Row
            Fm_B.Dispose()
        End If

        If Not (_Row_SubOt Is Nothing) Then
            _Idpotl = _Row_SubOt.Item("IDPOTL")
            'Lbl_SubOt.Text = _Row_SubOt.Item("NREG") & ", " & _Row_SubOt.Item("CODIGO") & " - " & _Row_SubOt.Item("GLOSA")
        Else
            Return
        End If

        Dim _Row_Maquina As DataRow
        Fm = New Frm_Buscar_Pistoleando(Frm_Buscar_Pistoleando.Enum_Tipo_Busqueda.Maquinas)
        Fm.ShowDialog(Me)
        _Row_Maquina = Fm.Pro_Row_Fila
        Fm.Dispose()

        Dim _Tbl_Operaciones As DataTable

        If Not (_Row_Maquina Is Nothing) Then
            Dim _Cod_Maquina As String = _Row_Maquina.Item("CODMAQ")

            _Tbl_Operaciones = Fx_Trae_Operaciones_SubOt(_Idpotl, _Cod_Maquina)

            If CBool(_Tbl_Operaciones.Rows.Count) Then

                If _Tbl_Operaciones.Rows.Count = 1 Then
                    'Lbl_Operacion.Text = Trim(_Tbl_Operaciones.Rows(0).Item("OPERACION")) & " - " & _Tbl_Operaciones.Rows(0).Item("NOMBREOP")
                Else

                End If

                'Txt_Maquina.Text = UCase(Trim(_Row_Maquina.Item("CODMAQ")) & " - " & _Row_Maquina.Item("NOMBREMAQ"))

            Else
                MessageBoxEx.Show(Me, "ESTA MAQUINA NO ESTA ASOCIADA A NINGUNA OPERACION DE LA SUB OT", _
                                  "MAQUINA: " & _Row_Maquina.Item("NOMBREMAQ"), MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If


        Else
            Return
        End If

    End Sub

    Sub Sb_Limpiar_DFA()

        Dtp_Fecha_Ingreso.Value = FormatDateTime(FechaDelServidor, DateFormat.ShortDate)

        Txt_Numero_OT.Enabled = True
        Lbl_Referencia.Text = String.Empty
        Txt_Numero_DFA.Text = Fx_Siguiente_Nro_DFA()
        Txt_Numero_OT.Text = String.Empty
        Lbl_Referencia.Enabled = True
        Txt_Numero_OT.Focus()

        _Row_Maquina = Nothing
        _Row_OT = Nothing
        _Row_SubOt = Nothing

        _Tbl_Pdatfae = Nothing
        _Tbl_Pdatfad = Nothing
        _Tbl_Pobrefad = Nothing

        Sb_Actualizar_Grillas()

        Me.Refresh()

    End Sub

    Sub Sb_Actualizar_Grillas()

        Consulta_sql = "SELECT TOP 1 * FROM PDATFAE" & vbCrLf & _
                       "WHERE 1 < 0" & _
                       vbCrLf & _
                       vbCrLf & _
                       "SELECT TOP 1 CAST(0 AS INT) AS IDPDATFAD,ARCHIRST,IDRST,EMPRESA,NUMDF,NUMOT,NUMODC,OPERACION,CODMAQ,FECHA,NREGOTL,CODIGO," & _
                       "UDAD,REALJOR,FECHINI,HORAINI,FECHTER,HORATER,TIEMPO,OBRERO1,OBRERO2,OBRERO3,OBRERO4,OBRERO5,OBRERO6," & _
                       "ESULTOPER,UDAD2,REALJOR2,RLUD,KOCAUDET,FACTOR,IDGDI,KOMOLDE,CAVIUSADAS,CICLOUSADO,IDOCCOPEXT,NUDOOCC" & vbCrLf & _
                       "FROM PDATFAD" & vbCrLf & _
                       "WHERE 1 < 0" & _
                       vbCrLf & _
                       vbCrLf & _
                       "SELECT CAST(0 AS INT) AS IDPDATFAD,OBRERO,OBRERO AS CODIGOOB,CAST('' AS VARCHAR(50)) AS NOMBREOB,FECHINIOB,HORAINIOB,FECHTEROB,HORATEROB,TIEMPOOB,VALHORA,VALUNID," & _
                       "VALADI1,VALADI2,KOJORNADA,TIEMPOOBHE" & vbCrLf & _
                       "FROM POBREFAD" & vbCrLf & _
                       "WHERE 1 < 0"

        _Ds_DFA = _Sql.Fx_Get_DataSet(Consulta_sql)


        _Ds_DFA.Relations.Add("Relacion_DFA", _
                                  _Ds_DFA.Tables("Table1").Columns("IDPDATFAD"), _
                                  _Ds_DFA.Tables("Table2").Columns("IDPDATFAD"), False)


        Grilla_Pdatfad.DataSource = _Ds_DFA
        Grilla_Pdatfad.DataMember = "Table1"

        Grilla_Pobrefad.DataSource = _Ds_DFA
        Grilla_Pobrefad.DataMember = "Table1.Relacion_DFA"

        _Tbl_Pdatfae = _Ds_DFA.Tables(0)
        _Tbl_Pdatfad = _Ds_DFA.Tables(1)
        _Tbl_Pobrefad = _Ds_DFA.Tables(2)

        '_Tbl_Pobrefad = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Pdatfad

            '.DataSource = _Tbl_Pobrefad

            OcultarEncabezadoGrilla(Grilla_Pdatfad, True)

            .Columns("NUMOT").Visible = True
            .Columns("NUMOT").HeaderText = "Nro. OT"
            .Columns("NUMOT").Width = 100
            .Columns("NUMOT").DisplayIndex = 0

            .Columns("NREGOTL").Visible = True
            .Columns("NREGOTL").HeaderText = "Sub-OT"
            .Columns("NREGOTL").Width = 50
            .Columns("NREGOTL").DisplayIndex = 1

            .Columns("CODIGO").Visible = True
            .Columns("CODIGO").HeaderText = "Producto"
            .Columns("CODIGO").Width = 100
            .Columns("CODIGO").DisplayIndex = 2

            .Columns("UDAD").Visible = True
            .Columns("UDAD").HeaderText = "UD"
            .Columns("UDAD").Width = 30
            .Columns("UDAD").DisplayIndex = 3

            .Columns("OPERACION").Visible = True
            .Columns("OPERACION").HeaderText = "Oper."
            .Columns("OPERACION").Width = 100
            .Columns("OPERACION").DisplayIndex = 4

            .Columns("CODMAQ").Visible = True
            .Columns("CODMAQ").HeaderText = "Máquina"
            .Columns("CODMAQ").Width = 160
            .Columns("CODMAQ").DisplayIndex = 5

            '.Columns("REALJOR").Visible = True
            '.Columns("REALJOR").HeaderText = "Realizado"
            '.Columns("REALJOR").Width = 550
            '.Columns("REALJOR").DisplayIndex = 1

            .Columns("FECHINI").Visible = True
            .Columns("FECHINI").HeaderText = "Fecha Ini."
            .Columns("FECHINI").Width = 80
            .Columns("HORAINI").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FECHINI").DisplayIndex = 6

            .Columns("HORAINI").Visible = True
            .Columns("HORAINI").HeaderText = "Hora Ini."
            .Columns("HORAINI").Width = 60
            .Columns("HORAINI").DefaultCellStyle.Format = "##,###0.##"
            .Columns("HORAINI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("HORAINI").DisplayIndex = 7

            '.Columns("CODIGO").Visible = True
            '.Columns("CODIGO").HeaderText = "Descripción"
            '.Columns("CODIGO").Width = 550
            '.Columns("CODIGO").DisplayIndex = 1



        End With

        With Grilla_Pobrefad

            '.DataSource = _Tbl_Pobrefad

            OcultarEncabezadoGrilla(Grilla_Pobrefad, True)

            .Columns("CODIGOOB").Visible = True
            .Columns("CODIGOOB").HeaderText = "Código"
            .Columns("CODIGOOB").Width = 120
            .Columns("CODIGOOB").DisplayIndex = 0

            .Columns("NOMBREOB").Visible = True
            .Columns("NOMBREOB").HeaderText = "Descripción"
            .Columns("NOMBREOB").Width = 550
            .Columns("NOMBREOB").DisplayIndex = 1

        End With

        Me.Refresh()


    End Sub

    Function Fx_Es_Inicio(ByVal _Lectura As String, _
                          ByRef _Row_Ot As DataRow, _
                          ByRef _Row_SubOt As DataRow) As Boolean

        If _Lectura.Contains(";") Then
            If _Lectura.Contains("stx") Then

                Dim _Cadena = Split(_Lectura, ";")
                Dim _Idoptd = _Cadena(1)

                Consulta_sql = "Select * From POTD Where IDPOTD = " & _Idoptd
                _Row_SubOt = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Numot As String = _Row_SubOt.Item("NUMOT")

                Consulta_sql = "Select Top 1 * From POTE" & vbCrLf & _
                               "Where 1 > 0 And NUMOT = '" & _Numot & "'"
                _Row_Ot = _Sql.Fx_Get_DataRow(Consulta_sql)

                Return True

            End If
        Else
            Return False
        End If

    End Function

    Function Fx_Es_Fin(ByVal _Lectura As String, _
                       ByRef _Row_Ot As DataRow, _
                       ByRef _Row_SubOt As DataRow) As Boolean

        If _Lectura.Contains(";") Then
            If _Lectura.Contains("ext") Then

                Dim _Cadena = Split(_Lectura, ";")
                Dim _Idoptd = _Cadena(1)

                Consulta_sql = "Select * From POTD Where IDPOTD = " & _Idoptd
                _Row_SubOt = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Numot As String = _Row_SubOt.Item("NUMOT")

                Consulta_sql = "Select Top 1 * From POTE" & vbCrLf & _
                               "Where 1 > 0 And NUMOT = '" & _Numot & "'"
                _Row_Ot = _Sql.Fx_Get_DataRow(Consulta_sql)

                Return True

            End If
        Else
            Return False
        End If

    End Function

    Sub Fx_Lectura_Codigo_Operacion_X_Tarea_En_Hoja_de_Ruta(ByVal _Lectura As String, _
                                                            ByRef _Row_Ot As DataRow, _
                                                            ByRef _Row_SubOt As DataRow, _
                                                            ByRef _Row_Operacion_SubOt As DataRow, _
                                                            ByRef _Row_Operacion As DataRow, _
                                                            ByRef _Es_Inicio As Boolean, _
                                                            ByRef _Es_Fin As Boolean)

        Dim _Error_Formato_Lectura As Boolean

        Try

            If _Lectura.Contains(";") Then

                If _Lectura.Contains("stx") Then _Es_Inicio = True
                If _Lectura.Contains("etx") Then _Es_Fin = True

                If _Es_Inicio Or _Es_Fin Then

                    Dim _Cadena = Split(_Lectura, ";")
                    Dim _Idotpr As Integer = _Cadena(1)
                    Dim _Idpotl As Integer

                    Consulta_sql = "Select * From POTPR Where IDPOTPR = " & _Idotpr
                    _Row_Operacion_SubOt = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If Not (_Row_Operacion_SubOt Is Nothing) Then

                        _Idpotl = _Row_Operacion_SubOt.Item("IDPOTL")

                        Consulta_sql = "Select * From POTL Where IDPOTL = " & _Idpotl
                        _Row_SubOt = _Sql.Fx_Get_DataRow(Consulta_sql)

                        Dim _Numot As String = _Row_SubOt.Item("NUMOT")

                        Consulta_sql = "Select Top 1 * From POTE" & vbCrLf & _
                                       "Where 1 > 0 And NUMOT = '" & _Numot & "'"
                        _Row_Ot = _Sql.Fx_Get_DataRow(Consulta_sql)

                        Dim _Operacion = _Row_Operacion_SubOt.Item("OPERACION")

                        Consulta_sql = "Select Top 1 * From POPER" & vbCrLf & _
                                       "Where 1 > 0 And OPERACION = '" & _Operacion & "'"
                        _Row_Operacion = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Else
                        _Es_Inicio = False : _Es_Fin = False
                        MessageBoxEx.Show(Me, "Registro no encontrado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Txt_Numero_OT.Text = String.Empty
                        Txt_Numero_OT.Focus()
                    End If
                Else
                    _Error_Formato_Lectura = True
                End If
            Else
                _Error_Formato_Lectura = True
            End If

        Catch ex As Exception
            _Error_Formato_Lectura = True
        End Try

        If _Error_Formato_Lectura Then
            _Es_Inicio = False : _Es_Fin = False
            Beep()
            ToastNotification.Show(Me, "NO SE RECONOCE EL COMANDO", Nothing, _
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            Sb_Limpiar_DFA()
            Txt_Numero_OT.Focus()
        End If


    End Sub

    Private Sub Txt_Numero_OT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Numero_OT.KeyDown

        If e.KeyValue = Keys.Enter Then

            Dim _Es_Inicio, _Es_Fin As Boolean

            Dim _Row_Operacion As DataRow
            Dim _Row_Operacion_SubOt As DataRow

            Fx_Lectura_Codigo_Operacion_X_Tarea_En_Hoja_de_Ruta(Txt_Numero_OT.Text, _
                                                                _Row_OT, _
                                                                _Row_SubOt, _
                                                                _Row_Operacion_SubOt, _
                                                                _Row_Operacion, _
                                                                _Es_Inicio, _
                                                                _Es_Fin)


            If _Es_Inicio Then

                Dim _Fabricar As Double = _Row_Operacion_SubOt.Item("FABRICAR")
                Dim _Realizado As Double = _Row_Operacion_SubOt.Item("REALIZADO")

                If _Realizado > 0 Then
                    If _Fabricar <= _Realizado Then

                        '_Fabricar = 2.23
                        'Dim _Flor_1 = _Fabricar - Math.Floor(_Fabricar)
                        Dim _Dec_01 = 0
                        Dim _Dec_02 = 0
                        If _Fabricar - Math.Floor(_Fabricar) > 0 Then _Dec_01 = 1
                        If _Fabricar - Math.Floor(_Fabricar) > 0 Then _Dec_02 = 1

                        Dim _Operacion = _Row_Operacion.Item("OPERACION")
                        Dim _Nombreop = _Row_Operacion.Item("NOMBREOP")

                        Dim Pregunta = MessageBoxEx.Show(Me, "Esta operación se encuentra realizada." & vbCrLf & vbCrLf & _
                                        _Operacion & " - " & _Nombreop & vbCrLf & vbCrLf & _
                                       "FABRICAR : " & FormatNumber(_Fabricar, _Dec_01) & vbCrLf & _
                                       "REALIZADO: " & FormatNumber(_Realizado, _Dec_02) & vbCrLf & vbCrLf & _
                                        "¿Desea seguir con la gestión?", "OPERACION REGISTRADA", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

                        If Pregunta <> Windows.Forms.DialogResult.Yes Then
                            Sb_Limpiar_DFA()
                            Txt_Numero_OT.Focus()
                            Return
                        End If

                    End If
                End If

                Sb_Txt_Leer_SubOT_Pistoleado_Inicio(_Row_OT, _Row_SubOt, _Row_Operacion_SubOt, _Row_Operacion)

            ElseIf _Es_Fin Then
                Sb_Txt_Leer_SubOT_Pistoleado_Fin(_Row_OT, _Row_SubOt, _Row_Operacion_SubOt)
            End If

            Return


            'Fx_Lectura_Codigo(Txt_Numero_OT.Text, _Row_OT, _Row_SubOt, _Es_Inicio, _Es_Fin)

            'Consulta_sql = "Select Top 1 * From POTE" & vbCrLf & _
            '               "Where 1 > 0 And NUMOT = '" & Txt_Numero_OT.Text & "'"
            '_Row_OT = _Sql.Fx_Get_DataRow(Consulta_sql)

            If _Row_OT Is Nothing Then
                MessageBoxEx.Show(Me, "Registro no encontrado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Numero_OT.Text = String.Empty
                Txt_Numero_OT.Focus()
            Else

                Dim _Estado As String = _Row_OT.Item("ESTADO")

                If _Estado = "V" Then

                    _Idpote = _Row_OT.Item("IDPOTE")
                    Lbl_Referencia.Text = _Row_OT.Item("REFERENCIA")

                    Consulta_sql = "Select * From POTL Where IDPOTE = " & _Idpote
                    Dim _Tbl_SubOt As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                    If _Tbl_SubOt.Rows.Count = 1 Then
                        _Row_SubOt = _Tbl_SubOt.Rows(0)
                    ElseIf _Tbl_SubOt.Rows.Count > 1 Then
                        ' MAS DE UNA SUB OT
                        Dim Fm = New Frm_Seleccionar_Op_SubOt_Maq_Etc("CODIGO", "GLOSA", _Tbl_SubOt)
                        Fm.Text = "SUB-OT DE LA ORDEN DE TRABAJO"
                        Fm.GroupPanel4.Text = "SELECCIONE LA SUB-OT PARA TRABAJAR"
                        Fm.ShowDialog(Me)
                        _Row_SubOt = Fm.Pro_Row
                        Fm.Dispose()
                    End If

                    If Not (_Row_SubOt Is Nothing) Then

                        _Idpotl = _Row_SubOt.Item("IDPOTL")
                        Txt_Numero_OT.Enabled = False

                        'TextBoxX1.Text = _Row_SubOt.Item("FABRICAR")
                        'TextBoxX2.Text = _Row_SubOt.Item("REALIZADO")
                        'TextBoxX3.Text = _Row_SubOt.Item("DIFERENCIA")

                        Fx_Ingresar_Nueva_DFA_PDATFAE(0, 0, "")
                        Fx_Ingresar_Nueva_Operacion_PDATFAD(_Row_SubOt.Item("NREG"))

                        Dim _Fila As DataGridViewRow = Grilla_Pdatfad.Rows(Grilla_Pdatfad.Rows.Count - 1)

                        Consulta_sql = "Select distinct * From PMAQUI" & vbCrLf & _
                                       "Where CODMAQ IN (Select CODMAQ From POPER Where OPERACION = 'IFF2') OR" & Space(1) & _
                                       "CODMAQ IN (Select CODMAQAL From PMAQALT Where CODMAQPR In" & Space(1) & _
                                       "(Select CODMAQ From POPER Where OPERACION = 'IFF2'))"

                        Dim _Tbl_Maquinas_Permitidas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                        Sb_Agregar_Maquina_Solo_Operacion(_Fila, True, _Tbl_Maquinas_Permitidas, _Row_Operacion, _Row_Maquina)
                        'Sb_Agregar_Maquina("", _Fila, True)

                        If (_Row_Maquina Is Nothing) Then
                            Sb_Limpiar_DFA()
                            Txt_Numero_OT.Focus()
                            Return
                        End If

                        Dim _Codmaq = Trim(_Tbl_Pdatfad.Rows(0).Item("CODMAQ"))
                        Dim _Operacion = Trim(_Tbl_Pdatfad.Rows(0).Item("OPERACION"))

                        Consulta_sql = "SELECT * FROM PDATFAE" & vbCrLf & _
                                       "WHERE" & vbCrLf & _
                                       "REQCONFIR = 1 AND IDPDATFAE IN" & Space(1) & _
                                       "(SELECT IDPDATFAE FROM PDATFAD" & Space(1) & _
                                       "WHERE OPERACION = '" & _Operacion & "' AND CODMAQ = '" & _Codmaq & "' AND" & Space(1) & _
                                       "NUMOT = '" & Txt_Numero_OT.Text & "')" & vbCrLf & _
                                       "And FECHA = '" & Format(Dtp_Fecha_Ingreso.Value, "yyyyMMdd") & "'"
                        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
                        Dim _Ds_DFA_Encontrada As DataSet

                        Dim _Existe_Pre_DFA As Boolean
                        Dim _Pre_Idpdatfae As Integer
                        Dim _Pre_Numdf As String

                        If _Tbl.Rows.Count = 1 Then

                            _Existe_Pre_DFA = True

                            _Pre_Idpdatfae = _Tbl.Rows(0).Item("IDPDATFAE")
                            Consulta_sql = "Select * From PDATFAE Where IDPDATFAE =" & _Pre_Idpdatfae & vbCrLf & _
                                           "SELECT * FROM PDATFAD WHERE IDPDATFAE =" & _Pre_Idpdatfae & vbCrLf & _
                                           "SELECT * FROM POBREFAD WHERE IDPDATFAD IN" & Space(1) & _
                                           "(SELECT DISTINCT IDPDATFAD FROM PDATFAD WHERE IDPDATFAE = " & _Pre_Idpdatfae & ")"
                            _Ds_DFA_Encontrada = _Sql.Fx_Get_DataSet(Consulta_sql)

                            Dim _Hora As String = FormatDateTime(FechaDelServidor, DateFormat.ShortTime)

                            Dim _LaHora = Split(_Hora, ":")

                            Dim _Hh As Integer = _LaHora(0)
                            Dim _Mm As Integer = _LaHora(1)

                            Dim _Horaini = _Ds_DFA_Encontrada.Tables(1).Rows(0).Item("HORAINI")
                            Dim _Horater = _Hh + (_Mm / 100)

                            Dim _Tiempo = Math.Round(_Horater - _Horaini, 5)

                            _Tbl_Pdatfad.Rows(0).Item("HORAINI") = _Horaini
                            _Tbl_Pdatfad.Rows(0).Item("HORATER") = _Horater
                            _Tbl_Pdatfad.Rows(0).Item("TIEMPO") = _Tiempo
                            _Pre_Numdf = _Ds_DFA_Encontrada.Tables(0).Rows(0).Item("NUMDF")


                        End If

                        Dim _Fabricar As Double = _Row_SubOt.Item("FABRICAR")

                        Dim _Idpdatfad = _Fila.Cells("IDPDATFAD").Value
                        Sb_Agregar_Operario(_Idpdatfad, _Existe_Pre_DFA, False, _Row_Maquina, Chk_Acepta_estar_en_mas_de_una_maquina.Checked)

                        If CBool(_Tbl_Pobrefad.Rows.Count) Then

                            If _Existe_Pre_DFA Then

                                Dim _Realjor As Double
                                Dim Fm_F As New Frm_Ing_Cant_Fabricada()
                                Fm_F.Pro_Estimado_Fabricar = _Fabricar
                                Fm_F.ShowDialog(Me)
                                _Realjor = Fm_F.Pro_Realjor
                                Fm_F.Dispose()

                                Dim _Rlud = _Tbl_Pdatfad.Rows(0).Item("RLUD")

                                If CBool(_Realjor) Then
                                    _Tbl_Pdatfad.Rows(0).Item("REALJOR") = _Realjor
                                    _Tbl_Pdatfad.Rows(0).Item("REALJOR2") = _Realjor * _Rlud
                                Else
                                    Sb_Limpiar_DFA()
                                    Txt_Numero_OT.Focus()
                                    Return
                                End If

                            End If

                            'If MessageBoxEx.Show(Me, "¿Confirma Grabar?", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                            If _Existe_Pre_DFA Then

                                _Tbl_Pdatfae.Rows(0).Item("NUMDF") = Fx_Siguiente_Nro_DFA()
                                Consulta_sql = "DELETE POBREFAD FROM PDATFAD WHERE POBREFAD.IDPDATFAD = PDATFAD.IDPDATFAD AND PDATFAD.IDPDATFAE= " & _Pre_Idpdatfae & vbCrLf & _
                                               "DELETE FROM PDATFAD WHERE IDPDATFAE= " & _Pre_Idpdatfae & vbCrLf & _
                                               "DELETE FROM PDATFAE WHERE IDPDATFAE=" & _Pre_Idpdatfae
                                _Sql.Ej_consulta_IDU(Consulta_sql)
                                _Tbl_Pdatfae.Rows(0).Item("REQCONFIR") = 0

                            End If


                            Dim _Clas_Dfa As New Clas_Crear_DFA
                            Dim _Idpdatfae = _Clas_Dfa.Fx_Crear_Documento(_Tbl_Pdatfae.Rows(0), _Tbl_Pdatfad, _Tbl_Pobrefad)

                            If CBool(_Idpdatfae) Then

                                'Select Count(*) From POTPR Where IDPOTL = 17
                                Dim _Nro_Operaciones As Integer = _Sql.Fx_Cuenta_Registros("POTPR", "IDPOTL = " & _Idpotl)
                                Dim _Orden As Integer = _Sql.Fx_Trae_Dato("POTPR", "ORDEN", "OPERACION = '" & _Operacion & "'")

                                If _Orden = _Nro_Operaciones Then

                                    Dim _Numot = _Row_SubOt.Item("NUMOT")
                                    Dim _Nreg = _Row_SubOt.Item("NREG")

                                    Consulta_sql = "SELECT TOP 1 PORENTRAR,REALIZADO FROM POTL WITH ( NOLOCK )" & vbCrLf & _
                                                   "WHERE NUMOT = '" & _Numot & "' AND NREG = '" & _Nreg & "'"
                                    Dim _Row_Potl As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                                    Dim _Porentrar As Double = _Tbl_Pdatfad.Rows(0).Item("REALJOR") + _Row_Potl.Item("REALIZADO")

                                    Consulta_sql = "UPDATE POTL SET PORENTRAR=" & _Porentrar & ",INFORABODE='P'" & vbCrLf & _
                                                   "WHERE NUMOT = '" & _Numot & "' AND NREG = '" & _Nreg & "'"
                                    _Sql.Ej_consulta_IDU(Consulta_sql)

                                End If


                                MessageBoxEx.Show(Me, "DATOS INGRESADOS CORRECTAMENTE", "GRABAR", _
                                            MessageBoxButtons.OK, MessageBoxIcon.Information)

                                'MessageBoxEx.Show(Me, "Pre-DFA creada correctamente", "GRABAR DFA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Sb_Limpiar_DFA()
                                Txt_Numero_OT.Focus()

                            End If

                            'Else
                            'Sb_Limpiar_DFA()
                            'Txt_Numero_OT.Focus()
                            'End If

                        Else

                            Sb_Limpiar_DFA()
                            Txt_Numero_OT.Focus()

                        End If

                        'Lbl_SubOt.Text = _Row_SubOt.Item("NREG") & ", " & _Row_SubOt.Item("CODIGO") & " - " & _Row_SubOt.Item("GLOSA")
                        'Txt_Maquina.Enabled = True
                        'Txt_Maquina.Focus()

                    Else
                        MessageBoxEx.Show(Me, "NO SE SELECCIONO NINGUNA SUB-OT", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ' Sb_Nueva_DFA()
                    End If
                Else

                    Dim _Msg As String

                    If _Estado = "E" Then
                        _Msg = "Orden de Compra en Estudio"
                    ElseIf _Estado = "C" Then
                        _Msg = "Orden de Compra Cerrada"
                    End If

                    MessageBoxEx.Show(Me, "Solo se pueden ingresar Datos de Fabricación para Ordenes de Trabajo Vigente", _
                                      "Validación, " & _Msg, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Txt_Numero_OT.Text = String.Empty
                    Txt_Numero_OT.Focus()
                End If

            End If

        End If

    End Sub

    Private Sub Sb_Txt_Leer_SubOT_Pistoleado_Inicio(ByVal _Row_Ot As DataRow, _
                                                    ByVal _Row_SubOt As DataRow, _
                                                    ByVal _Row_Operacion_SubOt As DataRow, _
                                                    ByVal _Row_Operacion As DataRow)



        Dim _Estado As String = _Row_Ot.Item("ESTADO")

        If _Estado = "V" Then

            _Idpote = _Row_Ot.Item("IDPOTE")
            Lbl_Referencia.Text = _Row_Ot.Item("REFERENCIA")

            If Not (_Row_SubOt Is Nothing) Then

                Dim _Idpotpr = _Row_Operacion_SubOt.Item("IDPOTPR")

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Produccion_DFA_Espera" & vbCrLf & _
                               "Where Idpdatfae NOT In (Select IDPDATFAE From PDATFAE)" & vbCrLf & _
                               "SELECT Id,Idpdatfae,Idpotpr" & vbCrLf & _
                               "From " & _Global_BaseBk & "Zw_Produccion_DFA_Espera" & vbCrLf & _
                               "Where Idpotpr = " & _Idpotpr

                Dim _Row_Dfa_Espera As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If _Row_Dfa_Espera Is Nothing Then

                    _Idpotl = _Row_SubOt.Item("IDPOTL")
                    Txt_Numero_OT.Enabled = False

                    Fx_Ingresar_Nueva_DFA_PDATFAE(0, 0, "")
                    Fx_Ingresar_Nueva_Operacion_PDATFAD(_Row_SubOt.Item("NREG"))

                    Dim _Fila As DataGridViewRow = Grilla_Pdatfad.Rows(Grilla_Pdatfad.Rows.Count - 1)

                    Dim _Operacion = _Row_Operacion.Item("OPERACION")

                    Consulta_sql = "Select distinct * From PMAQUI" & vbCrLf & _
                                   "Where CODMAQ IN (Select CODMAQ From POPER Where OPERACION = '" & _Operacion & "') OR" & Space(1) & _
                                   "CODMAQ IN (Select CODMAQAL From PMAQALT Where CODMAQPR In" & Space(1) & _
                                   "(Select CODMAQ From POPER Where OPERACION = '" & _Operacion & "'))"

                    Dim _Tbl_Maquinas_Permitidas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                    If _Tbl_Maquinas_Permitidas.Rows.Count = 1 Then
                        Consulta_sql = "Select Top 1 * From PMAQUI Where CODMAQ = '" & _Tbl_Maquinas_Permitidas.Rows(0).Item("CODMAQ") & "'"
                        _Row_Maquina = _Sql.Fx_Get_DataRow(Consulta_sql)
                    Else
                        Sb_Agregar_Maquina_Solo_Operacion(_Fila, False, _Tbl_Maquinas_Permitidas, _Row_Operacion, _Row_Maquina)
                    End If

                    'Sb_Agregar_Maquina("", _Fila, False)

                    If (_Row_Maquina Is Nothing) Then
                        Sb_Limpiar_DFA()
                        Txt_Numero_OT.Focus()
                        Return
                    Else
                        _Fila.Cells("OPERACION").Value = _Row_Operacion.Item("OPERACION")
                        _Fila.Cells("CODMAQ").Value = _Row_Maquina.Item("CODMAQ")
                        _Fila.Cells("ARCHIRST").Value = "POTPR"
                        _Fila.Cells("IDRST").Value = _Row_Operacion_SubOt.Item("IDPOTPR")
                    End If


                    Dim _Codmaq = Trim(_Tbl_Pdatfad.Rows(0).Item("CODMAQ"))
                    'Dim _Operacion = Trim(_Tbl_Pdatfad.Rows(0).Item("OPERACION"))
                    Dim _Fabricar As Double = _Row_SubOt.Item("FABRICAR")

                    Dim _Idpdatfad = _Fila.Cells("IDPDATFAD").Value
                    Sb_Agregar_Operario(_Idpdatfad, False, False, _Row_Maquina, Chk_Acepta_estar_en_mas_de_una_maquina.Checked)

                    If CBool(_Tbl_Pobrefad.Rows.Count) Then

                        Dim _Codigoob = _Tbl_Pobrefad.Rows(0).Item("CODIGOOB")

                        Dim _Clas_Dfa As New Clas_Crear_DFA
                        Dim _Idpdatfae = _Clas_Dfa.Fx_Crear_Documento(_Tbl_Pdatfae.Rows(0), _Tbl_Pdatfad, _Tbl_Pobrefad)

                        If CBool(_Idpdatfae) Then

                            'Select Count(*) From POTPR Where IDPOTL = 17
                            Dim _Nro_Operaciones As Integer = _Sql.Fx_Cuenta_Registros("POTPR", "IDPOTL = " & _Idpotl)
                            Dim _Orden As Integer = _Sql.Fx_Trae_Dato("POTPR", "ORDEN", "OPERACION = '" & _Operacion & "'")

                            If _Orden = _Nro_Operaciones Then

                                Dim _Numot = _Row_SubOt.Item("NUMOT")
                                Dim _Nreg = _Row_SubOt.Item("NREG")

                                Consulta_sql = "SELECT TOP 1 PORENTRAR,REALIZADO FROM POTL WITH ( NOLOCK )" & vbCrLf & _
                                               "WHERE NUMOT = '" & _Numot & "' AND NREG = '" & _Nreg & "'"
                                Dim _Row_Potl As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                                Dim _Porentrar As Double = _Tbl_Pdatfad.Rows(0).Item("REALJOR") + _Row_Potl.Item("REALIZADO")

                                Consulta_sql = "UPDATE POTL SET PORENTRAR=" & _Porentrar & ",INFORABODE='P'" & vbCrLf & _
                                               "WHERE NUMOT = '" & _Numot & "' AND NREG = '" & _Nreg & "'"
                                _Sql.Ej_consulta_IDU(Consulta_sql)

                            End If

                            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Produccion_DFA_Espera" & Space(1) & _
                                           "(Idpdatfae,Idpotpr,Operacion,Codmaq,Codigoob) Values" & vbCrLf & _
                                           "(" & _Idpdatfae & "," & _Idpotpr & ",'" & _Operacion & _
                                           "','" & _Codmaq & "','" & _Codigoob & "')"

                            If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                                Beep()
                                ToastNotification.Show(Me, "DATOS INGRESADOS CORRECTAMENTE", Nothing, _
                                  3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                            End If

                            'MessageBoxEx.Show(Me, "Pre-DFA creada correctamente", "GRABAR DFA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Sb_Limpiar_DFA()
                            Txt_Numero_OT.Focus()

                        End If

                    Else

                        Sb_Limpiar_DFA()
                        Txt_Numero_OT.Focus()

                    End If

                Else

                    'EL DOCUMENTO YA FUE PISTOLEADO PARA INICIAR EL TRABAJO
                    MessageBoxEx.Show(Me, "Esta operación se encuentra en curso" & vbCrLf & _
                                     "Para iniciar el proceso nuevamente debe cerrar la operación anterior", _
                                     "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Sb_Limpiar_DFA()
                    Txt_Numero_OT.Focus()
                End If

            Else
                MessageBoxEx.Show(Me, "NO SE SELECCIONO NINGUNA SUB-OT", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else

            Dim _Msg As String

            If _Estado = "E" Then
                _Msg = "Orden de Trabajo en Estudio"
            ElseIf _Estado = "C" Then
                _Msg = "Orden de Trabajo Cerrada"
            End If

            MessageBoxEx.Show(Me, "Solo se pueden ingresar Datos de Fabricación para Ordenes de Trabajo Vigente", _
                              "Validación, " & _Msg, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Numero_OT.Text = String.Empty
            Txt_Numero_OT.Focus()
        End If

    End Sub

    Private Sub Sb_Txt_Leer_SubOT_Pistoleado_Fin(ByVal _Row_Ot As DataRow, _
                                                 ByVal _Row_SubOt As DataRow, _
                                                 ByVal _Row_Operacion_SubOt As DataRow)


        Dim _Estado As String = _Row_Ot.Item("ESTADO")

        If _Estado = "V" Then

            _Idpote = _Row_Ot.Item("IDPOTE")
            Lbl_Referencia.Text = _Row_Ot.Item("REFERENCIA")

            If Not (_Row_SubOt Is Nothing) Then

                Dim _Idpotpr = _Row_Operacion_SubOt.Item("IDPOTPR")
                Consulta_sql = "SELECT * From " & _Global_BaseBk & "Zw_Produccion_DFA_Espera" & vbCrLf & _
                               "Where Idpotpr = " & _Idpotpr

                Dim _Row_Dfa_Espera As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not (_Row_Dfa_Espera Is Nothing) Then


                    _Idpotl = _Row_SubOt.Item("IDPOTL")
                    Txt_Numero_OT.Enabled = False

                    Fx_Ingresar_Nueva_DFA_PDATFAE(0, 0, "")
                    Fx_Ingresar_Nueva_Operacion_PDATFAD(_Row_SubOt.Item("NREG"))

                    Dim _Fila As DataGridViewRow = Grilla_Pdatfad.Rows(Grilla_Pdatfad.Rows.Count - 1)

                    Dim _Id_Dfa_Espera = _Row_Dfa_Espera.Item("Id")
                    Dim _Idpdatfae = _Row_Dfa_Espera.Item("Idpdatfae")
                    Dim _Codmaq = Trim(_Row_Dfa_Espera.Item("Codmaq"))
                    Dim _Codigoob = Trim(_Row_Dfa_Espera.Item("Codigoob"))

                    Dim _Operacion = Trim(_Row_Dfa_Espera.Item("Operacion"))

                    Consulta_sql = "Select * From PDATFAE where IDPDATFAE = " & _Idpdatfae
                    Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                    'Sb_Agregar_Maquina(_Codmaq, _Fila, False)

                    Dim _Ds_DFA_Encontrada As DataSet

                    'Dim _Existe_Pre_DFA As Boolean
                    Dim _Pre_Idpdatfae As Integer
                    Dim _Pre_Numdf As String

                    If _Tbl.Rows.Count = 1 Then

                        '_Existe_Pre_DFA = True

                        _Pre_Idpdatfae = _Tbl.Rows(0).Item("IDPDATFAE")
                        Consulta_sql = "Select * From PDATFAE Where IDPDATFAE =" & _Pre_Idpdatfae & vbCrLf & _
                                       "SELECT * FROM PDATFAD WHERE IDPDATFAE =" & _Pre_Idpdatfae & vbCrLf & _
                                       "SELECT * FROM POBREFAD WHERE IDPDATFAD IN" & Space(1) & _
                                       "(SELECT DISTINCT IDPDATFAD FROM PDATFAD WHERE IDPDATFAE = " & _Pre_Idpdatfae & ")"
                        _Ds_DFA_Encontrada = _Sql.Fx_Get_DataSet(Consulta_sql)

                        Dim _Hora As String = FormatDateTime(FechaDelServidor, DateFormat.ShortTime)

                        Dim _LaHora = Split(_Hora, ":")

                        Dim _Hh As Integer = _LaHora(0)
                        Dim _Mm As Integer = _LaHora(1)

                        Dim _Horaini = _Ds_DFA_Encontrada.Tables(1).Rows(0).Item("HORAINI")
                        Dim _Horater = _Hh + (_Mm / 100)

                        Dim _Tiempo = Math.Round(_Horater - _Horaini, 5)

                        Dim _Fechini As Date = FormatDateTime(_Ds_DFA_Encontrada.Tables(1).Rows(0).Item("FECHINI"), DateFormat.ShortDate)
                        Dim _Fecha_Hoy As Date = FormatDateTime(FechaDelServidor, DateFormat.ShortDate)

                        If _Fechini <> _Fecha_Hoy Then

                            Dim _Aceptar As Boolean

                            Dim _LaHora_Ini = Split(_Horaini, ",", 2)

                            Dim _Hh_Ini As Integer ' = _LaHora_Ini(0)
                            Dim _Mm_Ini As Integer ' = _LaHora_Ini(1)

                            If _LaHora_Ini.Length = 1 Then
                                _Hh_Ini = _LaHora_Ini(0)
                                _Mm_Ini = 0
                            Else
                                _Hh_Ini = _LaHora_Ini(0)
                                _Mm_Ini = _LaHora_Ini(1)
                            End If

                            Dim _Fechini_HM As DateTime = DateAdd(DateInterval.Hour, _Hh_Ini, _Fechini)
                            _Fechini_HM = DateAdd(DateInterval.Minute, _Mm_Ini, _Fechini_HM)

                            Dim _Hora_Inicio = Convert.ToDateTime(_Hh_Ini & ":" & _Mm_Ini)

                            MessageBoxEx.Show(Me, "Esta operación está atrasada, debe cerrarse con los antecedentes del día en que fue abierta.", _
                                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                            Dim Fm_C As New Frm_DFA_Cierre_Atrasado
                            Fm_C.Pro_Fecha_Ingreso = _Fechini
                            Fm_C.Pro_Fecha_Cierre = _Fechini
                            Fm_C.Pro_Hora_Ingreso = _Fechini_HM
                            Fm_C.Pro_Hora_Cierre = _Fechini_HM

                            Fm_C.ShowDialog(Me)
                            _Aceptar = Fm_C.Pro_Aceptar
                            _Hora = FormatDateTime(Fm_C.Pro_Hora_Cierre, DateFormat.ShortTime)
                            Fm_C.Dispose()

                            If _Aceptar Then
                                _Tbl_Pdatfad.Rows(0).Item("FECHTER") = _Fechini

                                '_Hora = Fm_C.Pro_Hora_Cierre 'FormatDateTime(FechaDelServidor, DateFormat.ShortTime)

                                _LaHora = Split(_Hora, ":")

                                _Hh = _LaHora(0)
                                _Mm = _LaHora(1)

                                _Horater = _Hh + (_Mm / 100)

                                _Tiempo = Math.Round(_Horater - _Horaini, 5)
                            Else
                                Sb_Limpiar_DFA()
                                Txt_Numero_OT.Focus()
                                Return
                            End If

                        End If

                        _Tbl_Pdatfad.Rows(0).Item("FECHINI") = _Fechini
                        _Tbl_Pdatfad.Rows(0).Item("HORAINI") = _Horaini
                        _Tbl_Pdatfad.Rows(0).Item("HORATER") = _Horater
                        _Tbl_Pdatfad.Rows(0).Item("TIEMPO") = _Tiempo
                        _Pre_Numdf = _Ds_DFA_Encontrada.Tables(0).Rows(0).Item("NUMDF")

                        Dim _Archirst = _Ds_DFA_Encontrada.Tables(1).Rows(0).Item("ARCHIRST")
                        Dim _Idrst = _Ds_DFA_Encontrada.Tables(1).Rows(0).Item("IDRST")

                        _Tbl_Pdatfad.Rows(0).Item("OPERACION") = _Operacion
                        _Tbl_Pdatfad.Rows(0).Item("CODMAQ") = _Codmaq
                        _Tbl_Pdatfad.Rows(0).Item("ARCHIRST") = _Archirst
                        _Tbl_Pdatfad.Rows(0).Item("IDRST") = _Idrst

                    End If

                    Dim _Fabricar As Double = _Row_SubOt.Item("FABRICAR")

                    Dim _Idpdatfad = _Fila.Cells("IDPDATFAD").Value

                    Consulta_sql = "Select Top 1 * From PMAEOB Where CODIGOOB = '" & _Codigoob & "'"
                    Dim _Row_Operario As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Fx_Ingresar_Nuevo_Operario_POBREFAD(_Idpdatfad, _Row_Operario, True)


                    If CBool(_Tbl_Pobrefad.Rows.Count) Then

                        'If _Existe_Pre_DFA Then

                        Dim _Fabricado As Boolean

                        Dim _Realjor As Double
                        Dim Fm_F As New Frm_Ing_Cant_Fabricada()
                        Fm_F.Pro_Estimado_Fabricar = _Fabricar
                        Fm_F.ShowDialog(Me)
                        _Realjor = Fm_F.Pro_Realjor
                        _Fabricado = Fm_F.Pro_Fabricado
                        Fm_F.Dispose()

                        Dim _Rlud = _Tbl_Pdatfad.Rows(0).Item("RLUD")

                        If _Fabricado Then
                            _Tbl_Pdatfad.Rows(0).Item("REALJOR") = _Realjor
                            _Tbl_Pdatfad.Rows(0).Item("REALJOR2") = _Realjor * _Rlud
                        Else

                            Beep()
                            ToastNotification.Show(Me, "LOS DATOS NO FUERON GRABADOS", Nothing, _
                              3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                            'Dim info As New TaskDialogInfo("Conectar con base de datos", _
                            '                            eTaskDialogIcon.ShieldOk, _
                            '                             "XXX", _
                            '                             "la conexión con la base de datos resulto exitosa." & vbCrLf & vbCrLf & _
                            '                             "Rut: " & RutEmpresa & vbCrLf & _
                            '                             "Empresa: " & RazonEmpresa, _
                            '                             eTaskDialogButton.Ok _
                            '                             , eTaskDialogBackgroundColor.Blue, Nothing, Nothing, Nothing, Nothing, Nothing)
                            'Dim result As eTaskDialogResult = TaskDialog.Show(info)

                            Sb_Limpiar_DFA()
                            Txt_Numero_OT.Focus()
                            Return
                        End If

                        'End If

                        'If MessageBoxEx.Show(Me, "¿Confirma Grabar?", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        'If _Existe_Pre_DFA Then

                        Dim _Numdf_Old As String = _Ds_DFA_Encontrada.Tables(0).Rows(0).Item("NUMDF")

                        _Tbl_Pdatfae.Rows(0).Item("NUMDF") = Fx_Siguiente_Nro_DFA() '
                        _Tbl_Pdatfae.Rows(0).Item("REQCONFIR") = 0

                        'End If


                        Dim _Clas_Dfa As New Clas_Crear_DFA
                        _Idpdatfae = _Clas_Dfa.Fx_Crear_Documento(_Tbl_Pdatfae.Rows(0), _Tbl_Pdatfad, _Tbl_Pobrefad)

                        If CBool(_Idpdatfae) Then

                            Consulta_sql = "DELETE POBREFAD FROM PDATFAD WHERE POBREFAD.IDPDATFAD = PDATFAD.IDPDATFAD AND PDATFAD.IDPDATFAE= " & _Pre_Idpdatfae & vbCrLf & _
                                           "DELETE FROM PDATFAD WHERE IDPDATFAE= " & _Pre_Idpdatfae & vbCrLf & _
                                           "DELETE FROM PDATFAE WHERE IDPDATFAE=" & _Pre_Idpdatfae & vbCrLf & _
                                           vbCrLf & _
                                           "UPDATE PDATFAE SET NUMDF = '" & _Numdf_Old & "' WHERE IDPDATFAE = " & _Idpdatfae & vbCrLf & _
                                           "UPDATE PDATFAD SET NUMDF = '" & _Numdf_Old & "' WHERE IDPDATFAE = " & _Idpdatfae
                            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                            'Select Count(*) From POTPR Where IDPOTL = 17
                            Dim _Nro_Operaciones As Integer = _Sql.Fx_Cuenta_Registros("POTPR", "IDPOTL = " & _Idpotl)
                            Dim _Orden As Integer = _Sql.Fx_Trae_Dato("POTPR", "ORDEN", "OPERACION = '" & _Operacion & "'")

                            If _Orden = _Nro_Operaciones Then

                                Dim _Numot = _Row_SubOt.Item("NUMOT")
                                Dim _Nreg = _Row_SubOt.Item("NREG")

                                Consulta_sql = "SELECT TOP 1 PORENTRAR,REALIZADO FROM POTL WITH ( NOLOCK )" & vbCrLf & _
                                               "WHERE NUMOT = '" & _Numot & "' AND NREG = '" & _Nreg & "'"
                                Dim _Row_Potl As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                                Dim _Porentrar As Double = _Tbl_Pdatfad.Rows(0).Item("REALJOR") + _Row_Potl.Item("REALIZADO")

                                Consulta_sql = "UPDATE POTL SET PORENTRAR=" & _Porentrar & ",INFORABODE='P'" & vbCrLf & _
                                               "WHERE NUMOT = '" & _Numot & "' AND NREG = '" & _Nreg & "'"
                                _Sql.Ej_consulta_IDU(Consulta_sql)

                            End If

                            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Produccion_DFA_Espera" & vbCrLf & _
                                           "Where Id = " & _Id_Dfa_Espera
                            _Sql.Ej_consulta_IDU(Consulta_sql)


                            Beep()
                            ToastNotification.Show(Me, "DATOS INGRESADOS CORRECTAMENTE", Nothing, _
                              3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

                            'MessageBoxEx.Show(Me, "DATOS INGRESADOS CORRECTAMENTE", "GRABAR", _
                            '            MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Sb_Limpiar_DFA()
                            Txt_Numero_OT.Focus()

                        End If

                    Else

                        Sb_Limpiar_DFA()
                        Txt_Numero_OT.Focus()


                    End If

                Else
                    MessageBoxEx.Show(Me, "Esta operación aun no ha sido iniciada", "Validación", _
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Sb_Limpiar_DFA()
                    Txt_Numero_OT.Focus()
                End If

            Else
                MessageBoxEx.Show(Me, "NO SE SELECCIONO NINGUNA SUB-OT", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else

            Dim _Msg As String

            If _Estado = "E" Then
                _Msg = "Orden de Trabajo en Estudio"
            ElseIf _Estado = "C" Then
                _Msg = "Orden de Trabajo Cerrada"
            End If

            MessageBoxEx.Show(Me, "Solo se pueden ingresar Datos de Fabricación para Ordenes de Trabajo Vigente", _
                              "Validación, " & _Msg, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Numero_OT.Text = String.Empty
            Txt_Numero_OT.Focus()
        End If


    End Sub

    Private Sub Txt_Maquina_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyValue = Keys.Enter Then

            _Row_Maquina = Nothing

            'Txt_Maquina.Text = Trim(Txt_Maquina.Text)
            Dim _Maquina As String

            If String.IsNullOrEmpty(_Maquina) Then

                Consulta_sql = "SELECT DISTINCT POPER.CODMAQ," & _
                               "ISNULL((SELECT TOP 1 NOMBREMAQ FROM PMAQUI WITH ( NOLOCK )" & Space(1) & _
                               "WHERE CODMAQ=POPER.CODMAQ),'') as NOMBREMAQ" & vbCrLf & _
                               "FROM POTPR WITH ( NOLOCK ) " & vbCrLf & _
                               "LEFT OUTER JOIN POPER ON POTPR.OPERACION=POPER.OPERACION " & vbCrLf & _
                               "LEFT OUTER JOIN PVELPROP ON POTPR.OPERACION=PVELPROP.OPERACION AND POTPR.CODIGO = PVELPROP.KOPR" & vbCrLf & _
                               "WHERE(POTPR.IDPOTL = " & _Idpotl & ")"

                Dim _Tbl_Maquinas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
                Dim Fm_m = New Frm_Seleccionar_Op_SubOt_Maq_Etc("CODMAQ", "NOMBREMAQ", _Tbl_Maquinas)
                Fm_m.Text = ""
                Fm_m.ShowDialog(Me)
                _Row_Maquina = Fm_m.Pro_Row
                Fm_m.Dispose()

            Else
                Consulta_sql = "Select Top 1 * From PMAQUI" & vbCrLf & _
                                           "Where 1 > 0 And CODMAQ = '" & _Maquina & "'"

                _Row_Maquina = _Sql.Fx_Get_DataRow(Consulta_sql)
            End If

            If _Row_Maquina Is Nothing Then
                If Not String.IsNullOrEmpty(_Maquina) Then
                    MessageBoxEx.Show(Me, "Registro no encontrado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                'Txt_Maquina.Text = String.Empty
                'Txt_Maquina.Focus()
            Else

                Dim _Tbl_Operaciones As DataTable

                If Not (_Row_Maquina Is Nothing) Then
                    Dim _Cod_Maquina As String = _Row_Maquina.Item("CODMAQ")

                    _Tbl_Operaciones = Fx_Trae_Operaciones_SubOt(_Idpotl, _Cod_Maquina)

                    Dim _Row_Operacion As DataRow

                    If CBool(_Tbl_Operaciones.Rows.Count) Then

                        If _Tbl_Operaciones.Rows.Count = 1 Then
                            _Row_Operacion = _Tbl_Operaciones.Rows(0)
                        Else

                            Dim Fm = New Frm_Seleccionar_Op_SubOt_Maq_Etc("OPERACION", "NOMBREOP", _Tbl_Operaciones)
                            Fm.ShowDialog(Me)
                            _Row_Operacion = Fm.Pro_Row
                            Fm.Dispose()

                        End If

                        If Not (_Row_Operacion Is Nothing) Then
                            _Maquina = _Row_Maquina.Item("CODMAQ")
                            'Txt_Maquina.Enabled = False
                            'Lbl_Maquina.Text = UCase(Trim(_Row_Maquina.Item("CODMAQ")) & " - " & _Row_Maquina.Item("NOMBREMAQ"))

                            'Txt_Operacion.Text = _Row_Operacion.Item("NREGOTL")
                            'Lbl_Operacion.Text = Trim(_Row_Operacion.Item("OPERACION")) & " - " & _Row_Operacion.Item("NOMBREOP")
                            'Sb_Agregar_Operario()
                        Else
                            MessageBoxEx.Show(Me, "NO SE SELECCIONO NINGUNA OPERACION", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            'Txt_Maquina.Text = String.Empty
                            'Txt_Maquina.Focus()
                        End If

                    Else
                        MessageBoxEx.Show(Me, "ESTA MAQUINA NO ESTA ASOCIADA A NINGUNA OPERACION DE LA SUB OT", _
                                          "MAQUINA: " & _Row_Maquina.Item("NOMBREMAQ"), MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        'Txt_Maquina.Text = String.Empty
                        'Txt_Maquina.Focus()
                    End If

                    'Txt_Operacion.Enabled = True
                    'Txt_Operacion.Focus()
                End If

            End If

        End If

    End Sub

    Sub Sb_Agregar_Maquina(ByVal _Maquina As String, _
                           ByVal _Fila As DataGridViewRow, _
                           ByVal _Buscar_Con_Lector As Boolean, _
                           Optional ByVal _Es_Maquina_Alternativa As Boolean = False, _
                           Optional ByVal _Row_Maquina_Alternativa As DataRow = Nothing)

        _Row_Maquina = Nothing

        If _Buscar_Con_Lector Then

            Dim Fm As New Frm_Buscar_Pistoleando(Frm_Buscar_Pistoleando.Enum_Tipo_Busqueda.Maquinas)
            Fm.ShowDialog(Me)
            Dim _Row_Maquina = Fm.Pro_Row_Fila
            Fm.Dispose()

            Dim _Codmaq = String.Empty
            If Not _Row_Maquina Is Nothing Then _Maquina = _Row_Maquina.Item("CODMAQ")

        End If

        If String.IsNullOrEmpty(_Maquina) Then

            'Consulta_sql = "SELECT DISTINCT POPER.CODMAQ," & _
            '               "ISNULL((SELECT TOP 1 NOMBREMAQ FROM PMAQUI WITH ( NOLOCK )" & Space(1) & _
            '               "WHERE CODMAQ=POPER.CODMAQ),'') as NOMBREMAQ" & vbCrLf & _
            '               "FROM POTPR WITH ( NOLOCK ) " & vbCrLf & _
            '               "LEFT OUTER JOIN POPER ON POTPR.OPERACION=POPER.OPERACION " & vbCrLf & _
            '               "LEFT OUTER JOIN PVELPROP ON POTPR.OPERACION=PVELPROP.OPERACION AND POTPR.CODIGO = PVELPROP.KOPR" & vbCrLf & _
            '               "WHERE(POTPR.IDPOTL = " & _Idpotl & ")"

            'Return

            Dim _Tbl_Maquinas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
            Dim Fm_m = New Frm_Seleccionar_Op_SubOt_Maq_Etc("CODMAQ", "NOMBREMAQ", _Tbl_Maquinas)
            Fm_m.Text = ""
            Fm_m.ShowDialog(Me)
            _Row_Maquina = Fm_m.Pro_Row
            Fm_m.Dispose()

        Else
            Consulta_sql = "Select Top 1 * From PMAQUI" & vbCrLf & _
                           "Where 1 > 0 And CODMAQ = '" & _Maquina & "'"
            _Row_Maquina = _Sql.Fx_Get_DataRow(Consulta_sql)
        End If

        If _Row_Maquina Is Nothing Then
            If Not String.IsNullOrEmpty(_Maquina) Then
                MessageBoxEx.Show(Me, "Registro no encontrado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else

            Dim _Tbl_Operaciones As DataTable

            If Not (_Row_Maquina Is Nothing) Then

                Dim _Cod_Maquina As String = _Row_Maquina.Item("CODMAQ")
                Dim _Nom_Maquina As String = _Row_Maquina.Item("NOMBREMAQ")

                _Tbl_Operaciones = Fx_Trae_Operaciones_SubOt(_Idpotl, _Cod_Maquina)

                Dim _Row_Operacion As DataRow

                If CBool(_Tbl_Operaciones.Rows.Count) Then

                    If _Es_Maquina_Alternativa Then
                        _Cod_Maquina = Trim(_Row_Maquina_Alternativa.Item("CODMAQ"))
                        _Nom_Maquina = Trim(_Row_Maquina_Alternativa.Item("NOMBREMAQ"))
                    End If

                    If _Tbl_Operaciones.Rows.Count = 1 Then
                        _Row_Operacion = _Tbl_Operaciones.Rows(0)
                    Else

                        Dim Fm = New Frm_Seleccionar_Op_SubOt_Maq_Etc("OPERACION", "NOMBREOP", _Tbl_Operaciones)
                        Fm.ShowDialog(Me)
                        _Row_Operacion = Fm.Pro_Row
                        Fm.Dispose()

                    End If

                    If Not (_Row_Operacion Is Nothing) Then

                        _Maquina = _Row_Maquina.Item("CODMAQ")

                        _Fila.Cells("OPERACION").Value = _Row_Operacion.Item("OPERACION")
                        _Fila.Cells("CODMAQ").Value = _Cod_Maquina '_Row_Maquina.Item("CODMAQ")
                        _Fila.Cells("ARCHIRST").Value = "POTPR" '_Row_Operacion.Item("")
                        _Fila.Cells("IDRST").Value = _Row_Operacion.Item("IDPOTPR")

                    Else
                        MessageBoxEx.Show(Me, "NO SE SELECCIONO NINGUNA OPERACION", "Validación", _
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                Else

                    Consulta_sql = "SELECT EMPRESA,OPERACION,CODMAQPR,CODMAQAL,RENDIMIEN" & vbCrLf & _
                       "FROM PMAQALT" & vbCrLf & _
                       "Where CODMAQAL = '" & _Cod_Maquina & "' And CODMAQPR <> '" & _Cod_Maquina & "'"
                    Dim _Tbl_Maquinas_Alternativas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                    Dim _Existe_Maquina As Boolean

                    If CBool(_Tbl_Maquinas_Alternativas.Rows.Count) Then

                        If _Tbl_Maquinas_Alternativas.Rows.Count = 1 Then
                            _Existe_Maquina = True
                            _Cod_Maquina = _Tbl_Maquinas_Alternativas.Rows(0).Item("CODMAQPR")
                            _Es_Maquina_Alternativa = True
                            _Row_Maquina_Alternativa = _Row_Maquina
                        Else

                            Dim _Filtro_Maquinas As String = Generar_Filtro_IN(_Tbl_Maquinas_Alternativas, "", _
                                                                               "CODMAQPR", False, False, "'")

                            Consulta_sql = "Select CODMAQ,NOMBREMAQ * From PMAQUI" & vbCrLf & _
                                           "Where 1 > 0 And CODMAQ In " & _Filtro_Maquinas

                            Dim Fm = New Frm_Seleccionar_Op_SubOt_Maq_Etc("CODMAQ", "NOMBREMAQ", _Tbl_Maquinas_Alternativas)
                            Fm.ShowDialog(Me)
                            _Row_Maquina = Fm.Pro_Row
                            Fm.Dispose()

                            If Not (_Row_Maquina Is Nothing) Then
                                _Existe_Maquina = True
                                _Es_Maquina_Alternativa = True
                                _Row_Maquina_Alternativa = _Row_Maquina
                            End If

                        End If

                    End If

                    If _Existe_Maquina Then

                        Sb_Agregar_Maquina(_Cod_Maquina, _Fila, False, _Es_Maquina_Alternativa, _Row_Maquina_Alternativa)

                        If _Row_Maquina Is Nothing Then
                            Sb_Agregar_Maquina("", _Fila, _Buscar_Con_Lector)
                        End If

                    Else
                        MessageBoxEx.Show(Me, "ESTA MAQUINA NO ESTA ASOCIADA A NINGUNA OPERACION DE LA SUB OT", _
                                          "MAQUINA: " & _Row_Maquina.Item("NOMBREMAQ"), MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Sb_Agregar_Maquina("", _Fila, _Buscar_Con_Lector)
                    End If

                End If

                'Txt_Operacion.Enabled = True
                'Txt_Operacion.Focus()
            End If

        End If

    End Sub

    'CREAR VALIDADOR DE MAQUINA EN ESTA CLASE

    Sub Sb_Agregar_Maquina_Solo_Operacion(ByVal _Fila As DataGridViewRow, _
                                          ByVal _Buscar_Con_Lector As Boolean, _
                                          ByVal _Tbl_Maquinas_Permitidas As DataTable, _
                                          ByVal _Row_Operacion As DataRow, _
                                          ByRef _Row_Maquina As DataRow)

        _Row_Maquina = Nothing

        Dim _Operacion As String = Trim(_Row_Operacion.Item("OPERACION"))
        Dim _Nombreop As String = Trim(_Row_Operacion.Item("NOMBREOP"))

        Dim _Codmaq As String
        Dim _Nombremaq As String

        Dim _Maquina_Aceptada As Boolean

        If _Buscar_Con_Lector Then

            Dim Fm As New Frm_Buscar_Pistoleando(Frm_Buscar_Pistoleando.Enum_Tipo_Busqueda.Maquinas)
            Fm.Lbl_Leyenda_01.Text = "OPERACION: " & _Operacion
            Fm.Lbl_Leyenda_02.Text = _Nombreop
            Fm.ShowDialog(Me)
            _Row_Maquina = Fm.Pro_Row_Fila
            Fm.Dispose()

            If Not _Row_Maquina Is Nothing Then
                _Codmaq = _Row_Maquina.Item("CODMAQ")
            Else
                Return
            End If

        Else

            'Dim _Tbl_Maquinas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
            Dim Fm_m = New Frm_Seleccionar_Op_SubOt_Maq_Etc("CODMAQ", "NOMBREMAQ", _Tbl_Maquinas_Permitidas)
            Fm_m.Text = ""
            Fm_m.GroupPanel4.Text = "SELECCIONE LA MAQUINA QUE VA A UTILIZAR"
            Fm_m.ShowDialog(Me)
            _Row_Maquina = Fm_m.Pro_Row
            Fm_m.Dispose()

        End If


        If Not (_Row_Maquina Is Nothing) Then

            _Codmaq = _Row_Maquina.Item("CODMAQ")
            _Nombremaq = _Row_Maquina.Item("NOMBREMAQ")

            If CBool(_Tbl_Maquinas_Permitidas.Rows.Count) Then

                For Each _Fila_Maq As DataRow In _Tbl_Maquinas_Permitidas.Rows

                    Dim _Codmaq_Permitida As String = _Fila_Maq.Item("CODMAQ")

                    If _Codmaq_Permitida = _Codmaq Then
                        _Maquina_Aceptada = True
                        Exit For
                    End If

                Next

            End If

            If _Maquina_Aceptada Then
                Return
            Else
                MessageBoxEx.Show(Me, "ESTA MAQUINA NO ESTA ASOCIADA A LA OPERACION: " & _Operacion & " - " & _Nombreop, _
                                     "MAQUINA: " & _Row_Maquina.Item("NOMBREMAQ"), MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Sb_Agregar_Maquina_Solo_Operacion(_Fila, _Buscar_Con_Lector, _Tbl_Maquinas_Permitidas, _Row_Operacion, _Row_Maquina)
            End If

        End If

    End Sub

    Sub Sb_Agregar_Operario(ByVal _Idpdatfad As Integer, _
                            ByVal _Cierre As Boolean, _
                            ByVal _Preguntar_Agrega_Otro_Operario As Boolean, _
                            ByVal _Row_Maquina As DataRow, _
                            ByVal _Acepta_estar_en_mas_de_una_maquina As Boolean)

        Dim _Fecha As String = Format(FechaDelServidor, "yyyyMMdd")

        Dim _Row_Operario As DataRow

        Dim _Codmaq As String = _Row_Maquina.Item("CODMAQ")
        Dim _Nombremaq As String = Trim(_Row_Maquina.Item("NOMBREMAQ"))

        Dim Fm As New Frm_Buscar_Pistoleando(Frm_Buscar_Pistoleando.Enum_Tipo_Busqueda.Operario_Codigo)
        Fm.Lbl_Leyenda_01.Text = "MAQUINA: " & _Codmaq
        Fm.Lbl_Leyenda_02.Text = _Nombremaq
        Fm.ShowDialog(Me)
        _Row_Operario = Fm.Pro_Row_Fila
        Fm.Dispose()


        Dim _Oper_Abiertas_Otros_dias As Integer
        Dim _Oper_Abiertas_Hoy_Misma_Maquina As Integer
        Dim _Oper_Abiertas_Hoy_Otras_Maquinas As Integer
        Dim _Oper_Abiertas As Integer


        If Not (_Row_Operario Is Nothing) Then

            Dim _Codigoob As String = _Row_Operario.Item("CODIGOOB")
            Dim _Inactivo As Boolean = _Row_Operario.Item("INACTIVO")

            Consulta_sql = "SELECT * FROM PDATFAE WHERE IDPDATFAE IN " & vbCrLf & _
                           "(SELECT IDPDATFAE FROM PDATFAD WHERE IDPDATFAD IN" & Space(1) & _
                           "(SELECT IDPDATFAD FROM POBREFAD WHERE OBRERO = '" & _Codigoob & "' AND FECHINI < '" & _Fecha & "'))" & vbCrLf & _
                           "AND REQCONFIR = 1" & vbCrLf & vbCrLf & _
                           "SELECT * FROM PDATFAE WHERE IDPDATFAE IN " & vbCrLf & _
                           "(SELECT IDPDATFAE FROM PDATFAD WHERE IDPDATFAD IN" & Space(1) & _
                           "(SELECT IDPDATFAD FROM POBREFAD WHERE OBRERO = '" & _Codigoob & "' AND CODMAQ = '" & _Codmaq & "' AND FECHINI = '" & _Fecha & "'))" & vbCrLf & _
                           "AND REQCONFIR = 1" & vbCrLf & vbCrLf & _
                           "SELECT * FROM PDATFAE WHERE IDPDATFAE IN " & vbCrLf & _
                           "(SELECT IDPDATFAE FROM PDATFAD WHERE IDPDATFAD IN" & Space(1) & _
                           "(SELECT IDPDATFAD FROM POBREFAD WHERE OBRERO = '" & _Codigoob & "' AND CODMAQ <> '" & _Codmaq & "' AND FECHINI = '" & _Fecha & "'))" & vbCrLf & _
                           "AND REQCONFIR = 1" & vbCrLf & vbCrLf & _
                           "SELECT (Select Top 1 FABRICAR From POTPR Where IDPOTPR = IDRST) as Fabricar" & vbCrLf & _
                           "Into #Paso" & vbCrLf & _
                           "FROM PDATFAD WHERE IDPDATFAD IN (SELECT IDPDATFAD FROM POBREFAD WHERE CODMAQ = '" & _Codmaq & "')" & vbCrLf & _
                           "AND IDPDATFAE IN (SELECT IDPDATFAE FROM PDATFAE WHERE REQCONFIR = 1)" & vbCrLf & _
                           "Select ISNULL(Sum(Fabricar),0) As Fabricando From #Paso" & vbCrLf & _
                           "Drop Table #Paso"

            Dim _Ds_TO As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

            _Oper_Abiertas_Otros_dias = _Ds_TO.Tables(0).Rows.Count
            _Oper_Abiertas_Hoy_Misma_Maquina = _Ds_TO.Tables(1).Rows.Count
            _Oper_Abiertas_Hoy_Otras_Maquinas = _Ds_TO.Tables(2).Rows.Count

            _Oper_Abiertas = _Oper_Abiertas_Otros_dias + _Oper_Abiertas_Hoy_Misma_Maquina + _Oper_Abiertas_Hoy_Otras_Maquinas

            Dim _Fabricando As Integer = _Ds_TO.Tables(3).Rows(0).Item("Fabricando")

            'Consulta_sql = "SELECT * FROM PDATFAE WHERE IDPDATFAE IN " & vbCrLf & _
            '               "(SELECT IDPDATFAE FROM PDATFAD WHERE IDPDATFAD IN" & Space(1) & _
            '               "(SELECT IDPDATFAD FROM POBREFAD WHERE" & Space(1) & _
            '               "OBRERO = '" & _Codigoob & "' AND FECHINI < '" & _Fecha & "'))" & vbCrLf & _
            '               "AND REQCONFIR = 1"
            'Dim _Tbl_DFA_Ddtes As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)


            'SE DEBE INCLUIR LA OPCION DE QUE UN OPERARIO PUEDA TRABAJAR EN MAS DE UNA MAQUINA A LA VEZ.
            'DEBE EXISTIR UN MAXIMO DE MAQUINAS QUE ATENDER AL MISMO TIEMPO.

            If Not _Acepta_estar_en_mas_de_una_maquina Then

                If CBool(_Oper_Abiertas) Then

                    'If _Oper_Abiertas_Otros_dias + _Oper_Abiertas_Hoy_Otras_Maquinas = 1 And _Oper_Abiertas_Hoy_Misma_Maquina = 0 Then

                    If _Oper_Abiertas_Otros_dias = 1 Then
                        MessageBoxEx.Show(Me, "¡Existe 1 operación que aún no ha sido cerrada por usted en otro día!" & vbCrLf & vbCrLf & _
                        "Ahora podrá registrar este trabajo, pero debe informar a la administración para cerrar la orden pendiente." & vbCrLf & _
                        "Si tiene más de una orden pendiente no podrá ingresar más tareas hasta que no haya solucionado el problema", _
                        "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        'If (_Oper_Abiertas_Hoy_Otras_Maquinas + _Oper_Abiertas_Otros_dias) > 1 Then
                        If (_Oper_Abiertas_Hoy_Otras_Maquinas + _Oper_Abiertas_Otros_dias) > 1 Then
                            MessageBoxEx.Show(Me, "Existen " & _Oper_Abiertas & " operaciones que aún no han sido cerradas por usted de otros días." & vbCrLf & _
                                              "Para poder continuar debe dirigirse a la administración para que cierren las ordenes y luego podrá ingresar un trabajo." & vbCrLf & vbCrLf & _
                                              "¡LOS DATOS NO SERAN GUARDADOS!", _
                                              "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return
                        End If

                    End If

                End If

            End If

            Dim _Multicarga = _Row_Maquina.Item("MULTICARGA")
            Dim _Udadcarga = _Row_Maquina.Item("UDADCARGA")
            Dim _Capacidad As Double = _Row_Maquina.Item("CAPACIDAD")

            If _Multicarga = "S" Then
                If _Fabricando > _Capacidad Then
                    MessageBoxEx.Show(Me, "La máquina esta sobre cargada según datos de parametrización" & vbCrLf & vbCrLf & _
                                      "Capacidad máxima " & FormatNumber(_Capacidad, 0) & Space(1) & _Udadcarga & vbCrLf & _
                                      "Cantidad que está siendo fabricada: " & FormatNumber(_Fabricando, 0) & Space(1) & _Udadcarga & vbCrLf & vbCrLf & _
                                      "¡LOS DATOS NO SERAN GUARDADOS!", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If
            Else
                MessageBoxEx.Show(Me, "La máquina  [" & _Nombremaq & "] no acepta sobre carga según datos de parametrización" & vbCrLf & _
                            "Para poder continuar debe dirigirse a la administración para que cierren las ordenes y luego podrá ingresar un trabajo." & vbCrLf & vbCrLf & _
                             "¡LOS DATOS NO SERAN GUARDADOS!", _
                             "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            'Consulta_sql = "SELECT * FROM PDATFAE WHERE IDPDATFAE IN " & vbCrLf & _
            '               "(SELECT IDPDATFAE FROM PDATFAD WHERE IDPDATFAD IN" & Space(1) & _
            '               "(SELECT IDPDATFAD FROM POBREFAD WHERE OBRERO = '" & _Codigoob & "'))" & vbCrLf & _
            '                "AND REQCONFIR = 1 AND FECHINI = '" & _Fecha & "'"
            '_Tbl_DFA_Ddtes = _Sql.Fx_Get_Tablas(Consulta_sql)

            If _Inactivo Then
                MessageBoxEx.Show(Me, "USUARIO INACTIVO", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Sb_Agregar_Operario(_Idpdatfad, _Cierre, _Preguntar_Agrega_Otro_Operario, _Row_Maquina, Chk_Acepta_estar_en_mas_de_una_maquina.Checked)
            Else
                Dim foundRows() As Data.DataRow
                foundRows = _Tbl_Pobrefad.Select("CODIGOOB = '" & _Codigoob & "'")

                If CBool(foundRows.Length) Then
                    MessageBoxEx.Show(Me, "Este operario ya esta en la lista", "Validación", _
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Sb_Agregar_Operario(_Idpdatfad, _Cierre, _Preguntar_Agrega_Otro_Operario, _Row_Maquina, Chk_Acepta_estar_en_mas_de_una_maquina.Checked)
                Else
                    If Fx_Ingresar_Nuevo_Operario_POBREFAD(_Idpdatfad, _Row_Operario, _Cierre) Then
                        If _Preguntar_Agrega_Otro_Operario Then
                            If MessageBoxEx.Show(Me, "¿Desea ingresar otro operario a la DFA?", "Ingreso de operarios", _
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                Sb_Agregar_Operario(_Idpdatfad, _Cierre, _Preguntar_Agrega_Otro_Operario, _Row_Maquina, Chk_Acepta_estar_en_mas_de_una_maquina.Checked)
                            End If
                        End If
                    End If
                End If
            End If

        Else
            Return
        End If

    End Sub

    Function Fx_Ingresar_Nueva_DFA_PDATFAE(ByVal _Idpdatfad As Integer, ByVal _Codigoob As String, ByVal _Nombreob As String) As Boolean

        Try
            'EMPRESA,NUMDF,NUMODC,FECHA,RESPONSABL,HORAGRAB,REQCONFIR
            Dim NewFila As DataRow
            NewFila = _Tbl_Pdatfae.NewRow
            With NewFila

                .Item("EMPRESA") = Trim(ModEmpresa)
                .Item("NUMDF") = Txt_Numero_DFA.Text
                .Item("NUMODC") = String.Empty
                .Item("FECHA") = FormatDateTime(Dtp_Fecha_Ingreso.Value, DateFormat.ShortDate)
                .Item("RESPONSABL") = FUNCIONARIO
                .Item("HORAGRAB") = Hora_Grab_fx(False)
                .Item("REQCONFIR") = 1

                _Tbl_Pdatfae.Rows.Add(NewFila)

            End With
            Return True
        Catch ex As Exception

        End Try


    End Function

    Function Fx_Ingresar_Nueva_Operacion_PDATFAD(ByVal _Nreglot As String) As Boolean

        Dim _Idpdatfad As Integer = Grilla_Pdatfad.Rows.Count + 1

        Dim _Fecha = Dtp_Fecha_Ingreso.Value
        Dim _Hora As String = FormatDateTime(FechaDelServidor, DateFormat.ShortTime)

        Dim _LaHora = Split(_Hora, ":")

        Dim _Hh As Integer = _LaHora(0)
        Dim _Mm As Integer = _LaHora(1)

        Dim _Horaini = _Hh + (_Mm / 100)

        Dim _codigo = _Row_SubOt.Item("CODIGO")

        Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & _codigo & "'"
        Dim _Row_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Try

            Dim NewFila As DataRow
            NewFila = _Tbl_Pdatfad.NewRow
            With NewFila

                .Item("IDPDATFAD") = Trim(_Idpdatfad)
                .Item("ARCHIRST") = String.Empty ' "POTPR"
                .Item("IDRST") = 0 '_Row_OT.Item("NUMDF")
                .Item("EMPRESA") = _Row_OT.Item("EMPRESA")
                .Item("NUMDF") = _Row_OT.Item("IDPOTE")
                .Item("NUMOT") = _Row_OT.Item("NUMOT")
                .Item("NUMODC") = Trim(Txt_Numero_DFA.Text)
                .Item("OPERACION") = String.Empty
                .Item("CODMAQ") = String.Empty
                .Item("FECHA") = _Fecha
                .Item("NREGOTL") = _Row_SubOt.Item("NREG")
                .Item("CODIGO") = _Row_SubOt.Item("CODIGO")
                .Item("UDAD") = _Row_SubOt.Item("UDAD")
                .Item("REALJOR") = 0
                .Item("FECHINI") = FormatDateTime(_Fecha, DateFormat.ShortDate)
                .Item("HORAINI") = _Horaini
                .Item("FECHTER") = FormatDateTime(_Fecha, DateFormat.ShortDate)
                .Item("HORATER") = _Horaini
                .Item("TIEMPO") = 0
                .Item("OBRERO1") = String.Empty
                .Item("OBRERO2") = String.Empty
                .Item("OBRERO3") = String.Empty
                .Item("OBRERO4") = String.Empty
                .Item("OBRERO5") = String.Empty
                .Item("OBRERO6") = String.Empty
                .Item("ESULTOPER") = 0
                .Item("UDAD2") = _Row_Producto.Item("UD02PR")
                .Item("REALJOR2") = 0
                .Item("RLUD") = _Row_Producto.Item("RLUD")
                .Item("KOCAUDET") = String.Empty
                .Item("FACTOR") = 1
                .Item("IDGDI") = 0
                .Item("KOMOLDE") = String.Empty
                .Item("CAVIUSADAS") = 0
                .Item("CICLOUSADO") = 0
                .Item("IDOCCOPEXT") = 0
                .Item("NUDOOCC") = String.Empty

                _Tbl_Pdatfad.Rows.Add(NewFila)

            End With
            Return True
        Catch ex As Exception

        End Try


    End Function

    Function Fx_Ingresar_Nuevo_Operario_POBREFAD(ByVal _Idpdatfad As Integer, _
                                                 ByVal _Row_Operario As DataRow, _
                                                 ByVal _Cierre As Boolean) As Boolean

        'IDPDATFAD,OBRERO,FECHINIOB,HORAINIOB,FECHTEROB,HORATEROB,TIEMPOOB,KOJORNADA,TIEMPOOBHE

        Dim _Codigoob = _Row_Operario.Item("CODIGOOB")
        Dim _Nombreob = _Row_Operario.Item("NOMBREOB")
        Dim _Kojornada = Trim(_Row_Operario.Item("KOJORNADA"))

        Dim _Row_Jornada As DataRow = Fx_Jornada(_Kojornada, FechaDelServidor)

        Dim _Hijo01 As Double = _Row_Jornada.Item("HIJOR01")
        Dim _Htjo01 As Double = _Row_Jornada.Item("HTJOR01")

        Dim _Hijo02 As Double = _Row_Jornada.Item("HIJOR02")
        Dim _Htjo02 As Double = _Row_Jornada.Item("HTJOR02")

        Dim foundRows() As Data.DataRow
        foundRows = _Tbl_Pdatfad.Select("IDPDATFAD = " & _Idpdatfad)

        Dim _Row = foundRows(0)

        Dim _Hora As String = FormatDateTime(FechaDelServidor, DateFormat.ShortTime)

        Dim _LaHora = Split(_Hora, ":")

        Dim _Hh As Integer = _LaHora(0)
        Dim _Mm As Integer = _LaHora(1)

        Dim _Horaini = _Row.Item("HORAINI")
        Dim _Horater = _Hh + (_Mm / 100)

        Dim _Tiempo = Math.Round(_Horater - _Horaini, 5)

        Dim _Tiempo_Jornada As Double = 0 ' = Math.Round(_Horater - _Horaini, 5)
        Dim _Tiempo_Extra As Double = 0 ' = Math.Round(_Horater - _Horaini, 5)

        If _Cierre Then
            If _Horater > _Htjo01 Then
                _Tiempo_Jornada = Math.Round(_Horaini - _Htjo01, 5)
                _Tiempo_Extra = Math.Round(Math.Round(_Horater - _Horaini, 5) - _Tiempo_Jornada, 5)
                _Tiempo = _Tiempo_Jornada
            End If
            _Horater = _Row.Item("HORATER")
            _Tiempo = _Row.Item("TIEMPO")
        Else
            _Row.Item("HORATER") = _Horater
            _Row.Item("TIEMPO") = _Tiempo
        End If


        Try

            Dim NewFila As DataRow
            NewFila = _Tbl_Pobrefad.NewRow
            With NewFila

                .Item("IDPDATFAD") = Trim(_Idpdatfad)
                .Item("CODIGOOB") = Trim(_Codigoob)
                .Item("NOMBREOB") = Trim(_Nombreob)

                .Item("OBRERO") = Trim(_Codigoob)
                .Item("FECHINIOB") = _Row.Item("FECHINI")
                .Item("HORAINIOB") = _Row.Item("HORAINI")
                .Item("FECHTEROB") = _Row.Item("FECHTER")
                .Item("HORATEROB") = _Horater
                .Item("TIEMPOOB") = _Tiempo
                .Item("KOJORNADA") = _Kojornada
                .Item("TIEMPOOBHE") = _Tiempo_Extra

                _Tbl_Pobrefad.Rows.Add(NewFila)

            End With
            Return True
        Catch ex As Exception

        End Try


    End Function

    Private Sub Frm_DFA_Ingreso_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Dim _TipoEstacion = Trim(_Global_Row_EstacionBk.Item("TipoEstacion"))

        If _TipoEstacion = "Dfa" Then
            Dim _Autorizado As Boolean

            Dim Fm_Pass As New Frm_Clave_Administrador
            Fm_Pass.ShowDialog(Me)
            _Autorizado = Fm_Pass.Pro_Autorizado
            Fm_Pass.Dispose()

            If Not _Autorizado Then
                e.Cancel = True
            End If
        End If

    End Sub

End Class