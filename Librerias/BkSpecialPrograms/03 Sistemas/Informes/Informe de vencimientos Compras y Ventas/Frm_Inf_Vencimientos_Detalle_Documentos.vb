Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Inf_Vencimientos_Detalle_Documentos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Fecha_Inicio, _Fecha_Fin As String
    Dim _SqlConsulta_informe As String
    Dim _CodEntidad, _CodSucEntidad As String
    Dim _TblInforme As DataTable
    Dim _Mover_Fechas As Boolean
    Dim _Nueva_Fecha_Vencimiento As Date
    Dim _Reprocesar_Informe As Boolean
    Dim _Imagen_Marcados As Image
    Dim _Informe As Tipo_Informe
    Dim _Correr_a_la_derecha
    Dim _Filtro_Maeedo As String
    Dim _Filtro_Maedpce As String

    Dim _Total_Saldos As Double = 0

    Enum Tipo_Informe
        Compras
        Ventas
    End Enum

    Dim _Revisado_Pago_Proveedores As Boolean
    Dim _Min_Rotacion_Anual As Double

    Public _Id_Correo As Integer

    Enum Accion
        Mover_Fechas
        Cobranza
        Mostrar_todo
        Pago_Proveedores
        Marcar_Anotaciones_Masivas
    End Enum

    Dim _Accion As Accion

    Dim _Solo_Cheques As Boolean

    Public ReadOnly Property Pro_Reprocesar_Informe() As Boolean
        Get
            Return _Reprocesar_Informe
        End Get
    End Property
    Public Property Pro_Solo_Cheques() As Boolean
        Get
            Return _Solo_Cheques
        End Get
        Set(value As Boolean)
            _Solo_Cheques = value
        End Set
    End Property

    Dim _Fecha_Inicio_Date As Date
    Dim _Fecha_Fin_Date As Date

    Public Property Pro_TblInforme() As DataTable
        Get
            Return _TblInforme
        End Get
        Set(value As DataTable)
            _TblInforme = value
        End Set
    End Property
    Public Property Pro_Mover_Fechas() As Boolean
        Get
            Return _Mover_Fechas
        End Get
        Set(value As Boolean)
            _Mover_Fechas = value
        End Set
    End Property
    Public Property Pro_Nueva_Fecha_Vencimiento() As Date
        Get
            Return _Nueva_Fecha_Vencimiento
        End Get
        Set(value As Date)
            _Nueva_Fecha_Vencimiento = value
        End Set
    End Property
    Public Property Pro_Fecha_Inicio() As Date
        Get
            Return _Fecha_Inicio_Date
        End Get
        Set(value As Date)
            _Fecha_Inicio_Date = value
        End Set
    End Property
    Public Property Pro_Fecha_Fin() As Date
        Get
            Return _Fecha_Fin_Date
        End Get
        Set(value As Date)
            _Fecha_Fin_Date = value
        End Set
    End Property

    Public Sub New(New_Endo As String,
                   New_Suendo As String,
                   New_SqlConsulta As String,
                   New_Fecha_I As String,
                   New_Fecha_F As String,
                   New_Accion As Accion,
                   New_Id_Correo As Integer,
                   New_Informe As Tipo_Informe)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        _SqlConsulta_informe = New_SqlConsulta
        _Fecha_Inicio = New_Fecha_I
        _Fecha_Fin = New_Fecha_F
        _CodEntidad = New_Endo
        _CodSucEntidad = New_Suendo
        _Accion = New_Accion
        _Id_Correo = New_Id_Correo
        _Informe = New_Informe

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Inf_Vencimientos_Detalle_Documentos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If _Correr_a_la_derecha Then
            Me.Top += 30
            Me.Left += 30
        End If

        Sb_Load()
        AddHandler Chk_Mostrar_Pagos_Pendientes.CheckedChanging, AddressOf Sb_Chk_Mostrar_Pagos_Pendientes_CheckedChanging

        AddHandler Btn_Exportar_Informe_01_Vista_Actual.Click, AddressOf Btn_Exportar_Informe_01_Vista_Actual_Click
        AddHandler Btn_Exportar_Informe_02_Mostrar_todas_las_Anotaciones.Click, AddressOf Btn_Exportar_Informe_02_Mostrar_todas_las_Anotaciones_Click
        AddHandler Btn_Exportar_Informe_03_Entidades.Click, AddressOf Btn_Exportar_Informe_03_Entidades_Click

    End Sub

    Sub Sb_Load()

        RemoveHandler Grilla.CellEnter, AddressOf Sb_Grilla_CellEnter
        RemoveHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        RemoveHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        RemoveHandler Grilla.CellBeginEdit, AddressOf Sb_Grilla_CellBeginEdit

        RemoveHandler Grilla.CellEndEdit, AddressOf Sb_Grilla_CellEndEdit
        RemoveHandler Grilla.CellDoubleClick, AddressOf Sb_Grilla_CellDoubleClick
        RemoveHandler Grilla.MouseUp, AddressOf Sb_Grilla_MouseUp
        RemoveHandler Grilla.ColumnHeaderMouseClick, AddressOf Sb_Grilla_ColumnHeaderMouseClick

        'Btn_Pagar_Transferencia.Visible = False
        Btn_Mover.Visible = False
        Btn_Enviar_correo.Visible = False
        Btn_Exportar_Excel.Visible = False
        Btn_Actualizar_Informacion.Visible = False
        Btn_Autorizar_Pago_De_Documentos_Proveedores.Visible = False
        Btn_Marcar_Masivamente_Anotaciones_De_Documentos.Visible = False
        Btn_Imprimir.Visible = False

        Chk_Marcar_todo.Visible = False
        Chk_Mostrar_Pagos_Pendientes.Visible = False

        If _Informe = Tipo_Informe.Compras Then
            Btn_Autorizar_Pago_De_Documentos_Proveedores.Visible = True
        ElseIf _Informe = Tipo_Informe.Ventas Then
            Btn_Autorizar_Pago_De_Documentos_Proveedores.Visible = False
        End If


        If _Accion = Accion.Mover_Fechas Then

            Btn_Mover.Visible = True
            'Btn_Enviar_correo.Visible = False
            'Btn_Exportar_Excel.Visible = False
            'Btn_Actualizar_Informacion.Visible = False
            'Btn_Pago_Proveedores.Visible = False
            'Btn_Marcar_Masivamente_Anotaciones_De_Documentos.Visible = False
            AddHandler Chk_Marcar_todo.CheckedChanged, AddressOf Sb_Chk_Marcar_todo_CheckedChanged
            Sb_Formato_Grilla()

        ElseIf _Accion = Accion.Mostrar_todo Then

            'Btn_Mover.Visible = False

            Btn_Exportar_Excel.Visible = True
            Btn_Actualizar_Informacion.Visible = True

            'Btn_Marcar_Masivamente_Anotaciones_De_Documentos.Visible = True
            'If _CodEntidad = "ZZZZZZ" Then
            'Btn_Marcar_Masivamente_Anotaciones_De_Documentos.Visible = False
            'End If
            'Chk_Marcar_todo.Visible = False

            Sb_Formato_Grilla()

        ElseIf _Accion = Accion.Cobranza Then

            Btn_Enviar_correo.Visible = True
            Btn_Exportar_Excel.Visible = True
            Btn_Marcar_Masivamente_Anotaciones_De_Documentos.Visible = True
            Chk_Marcar_todo.Visible = True

            AddHandler Chk_Marcar_todo.CheckedChanged, AddressOf Sb_Chk_Marcar_todo_CheckedChanged
            Sb_Formato_Grilla()

        ElseIf _Accion = Accion.Pago_Proveedores Then

            Btn_Exportar_Excel.Visible = True
            Btn_Autorizar_Pago_De_Documentos_Proveedores.Visible = True
            Btn_Autorizar_Pago_Proveedor.Visible = True

            Sb_Formato_Grilla()

        ElseIf _Accion = Accion.Marcar_Anotaciones_Masivas Then

            Btn_Autorizar_Pago_De_Documentos_Proveedores.Visible = False
            Chk_Marcar_todo.Visible = True

            AddHandler Chk_Marcar_todo.CheckedChanged, AddressOf Sb_Chk_Marcar_todo_CheckedChanged

            Sb_Formato_Grilla()

        End If


        _Mover_Fechas = False
        Me.ActiveControl = Grilla

        If CBool(Grilla.Rows.Count) Then
            Grilla.CurrentCell = Grilla.Rows(0).Cells("NUDO")
        End If

        AddHandler Grilla.CellEnter, AddressOf Sb_Grilla_CellEnter
        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown
        AddHandler Grilla.CellBeginEdit, AddressOf Sb_Grilla_CellBeginEdit

        AddHandler Grilla.CellEndEdit, AddressOf Sb_Grilla_CellEndEdit
        AddHandler Grilla.CellDoubleClick, AddressOf Sb_Grilla_CellDoubleClick
        AddHandler Grilla.MouseUp, AddressOf Sb_Grilla_MouseUp
        AddHandler Grilla.ColumnHeaderMouseClick, AddressOf Sb_Grilla_ColumnHeaderMouseClick

        Me.Refresh()

    End Sub

    Sub Sb_Generar_Informe(Optional _Sql_Filtro_Extra As String = "")

        Me.Cursor = Cursors.WaitCursor

        Consulta_sql = _SqlConsulta_informe
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", _Fecha_Inicio)
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", _Fecha_Fin)

        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)

        Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional_Maeedo#", _Filtro_Maeedo)
        Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional_Maedpce#", _Filtro_Maedpce)

        If Not Chk_Mostrar_Pagos_Pendientes.Checked Then
            Consulta_sql += vbCrLf & vbCrLf & "Delete #INFVEN Where Deuda = 'Pagos'" & vbCrLf & vbCrLf
        End If

        If _Solo_Cheques Then
            Consulta_sql += vbCrLf & vbCrLf &
            "Delete #INFVEN Where TIDO In ('ATB','CPV','CRV','DEP','LTV','PAV','RBV','RGV','RIV','VUE') " & vbCrLf & vbCrLf
        End If

        Dim _Sql_Actualiza_Chk As String

        _Sql_Actualiza_Chk = "Update #INFVEN Set Chk = Isnull((Select Autorizado From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where IDMAEVEN = Idmaeven),0)" & vbCrLf &
                             "Update #INFVEN Set REVISADO_PAGAR = Chk" & vbCrLf

        If _CodEntidad = "ZZZZZZ" Then

            Consulta_sql += _Sql_Actualiza_Chk & vbCrLf &
                            "Select * From #INFVEN" & vbCrLf &
                            "Where 1 > 0" & vbCrLf &
                            _Sql_Filtro_Extra & vbCrLf &
                            "Order By FEVE,FEEMDO" & vbCrLf &
                            "Drop Table #INFVEN"

        Else

            Select Case _Accion

                Case Accion.Mover_Fechas, Accion.Mostrar_todo, Accion.Marcar_Anotaciones_Masivas

                    Consulta_sql += _Sql_Actualiza_Chk & vbCrLf &
                                    "Select * From #INFVEN" & vbCrLf &
                                    "Where 1 > 0 And" & vbCrLf &
                                    "ENDO = '" & _CodEntidad & "'" & vbCrLf &
                                    _Sql_Filtro_Extra & vbCrLf &
                                    "Order By FEVE,FEEMDO" & vbCrLf &
                                    "Drop Table #INFVEN"

                Case Accion.Cobranza

                    Consulta_sql += _Sql_Actualiza_Chk & vbCrLf &
                                    "Select * From #INFVEN" & vbCrLf &
                                    "Where 1 > 0 And" & vbCrLf &
                                    "ENDO = '" & _CodEntidad & "'" & vbCrLf &
                                    "AND TIDO IN ('FCV','BLV','FVX','FDV')" & vbCrLf &
                                    _Sql_Filtro_Extra & vbCrLf &
                                    "Order By FEVE,FEEMDO" & vbCrLf &
                                    "Drop Table #INFVEN"

                Case Accion.Pago_Proveedores

                    Consulta_sql += _Sql_Actualiza_Chk & vbCrLf &
                                    "Select * From #INFVEN" & vbCrLf &
                                    "Where 1 > 0" & vbCrLf &
                                    "And ENDO = '" & _CodEntidad & "'" & vbCrLf &
                                    _Sql_Filtro_Extra & vbCrLf &
                                    "Order By FEVE,FEEMDO" & vbCrLf &
                                    "Drop Table #INFVEN"

            End Select

        End If


        _TblInforme = _Sql.Fx_Get_DataTable(Consulta_sql)


        If Chk_Mostrar_Pagos_Pendientes.Checked Then

            Dim _Cont_Pagos = 0
            For Each _Fila As DataRow In _TblInforme.Rows
                If Not CBool(_Fila.Item("IDMAEVEN")) Then
                    _Cont_Pagos += 1
                End If
            Next

            If Not CBool(_Cont_Pagos) Then
                'Beep()
                'ToastNotification.Show(Me, "NO HAY DOCUMENTOS DE PAGO PENDIENTES", _
                '                       My.Resources.cross, _
                '                       2 * 1000, eToastGlowColor.Red, _
                '                       eToastPosition.MiddleCenter)
            End If

        End If

        If _Accion = Accion.Mostrar_todo Then
            _Total_Saldos = NuloPorNro(_TblInforme.Compute("SUM(SALDO)", "SALDO <> 0"), 0)
        Else
            _Total_Saldos = 0
        End If

        Lbl_Total_Saldos.Text = FormatCurrency(_Total_Saldos, 0)

        Grilla.DataSource = _TblInforme

        Me.Cursor = Cursors.Default


    End Sub

    Private Sub Frm_Inf_Vencimientos_Detalle_Documentos_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyValue = Keys.F3 Then
            Sb_Buscar_Documento_Lista_Actual()
        End If
    End Sub

    Sub Sb_Ver_Documento()

        Dim _Mostrar_leyenda

        If _Reprocesar_Informe Then
            _Mostrar_leyenda = False
        Else
            _Mostrar_leyenda = True
        End If

        Dim _Cambio As Boolean

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
        Dim _Idmaeven = _Fila.Cells("IDMAEVEN").Value
        Dim _Feve = _Fila.Cells("FEVE").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.Marcar_Stock_VS_Cantidad = _Revisado_Pago_Proveedores
        Fm.Min_Rotacion_Anual = _Min_Rotacion_Anual
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Consulta_sql = "Select top 1 * From MAEVEN Where IDMAEVEN = " & _Idmaeven

        Dim _TblMaeven As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_TblMaeven.Rows.Count) Then

            Dim _Fecha_vencimiento = _TblMaeven.Rows(0).Item("FEVE")

            If _Fecha_vencimiento <> _Feve Then
                _Cambio = True
            End If

        Else

            _Cambio = True

        End If

        If _Cambio Then

            _Fila.DefaultCellStyle.BackColor = Color.Gray

            If _Mostrar_leyenda Then
                MessageBoxEx.Show(Me, "Este documento ya no tiene los mismos vencimientos" & vbCrLf &
                                  "por lo tanto ya no es posible seguir haciendo gestión, debe actualizar el listado para continuar",
                                  "Cambio de fechas en tiempo de ejecución", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Btn_Enviar_correo.Visible = False
                Btn_Exportar_Excel.Visible = False
                Btn_Mover.Visible = False
                'Btn_Pagar_Transferencia.Visible = False
                Btn_Autorizar_Pago_De_Documentos_Proveedores.Visible = False
                Btn_Actualizar_Informacion.Visible = False
                _Reprocesar_Informe = True
                Me.Refresh()
            End If

        End If


    End Sub

    Private Sub BtnActualizarInformacion_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Actualizar_Informacion.Click
        Sb_Generar_Informe()
        Sb_Load()
    End Sub

    Private Sub Btn_Mover_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Mover.Click
        _Mover_Fechas = True
        Me.Close()
    End Sub

    Sub Sb_Formato_Grilla()

        With Grilla

            '.DataSource = _TblInforme
            OcultarEncabezadoGrilla(Grilla)

            Dim _Mostrar_Chk As Boolean
            Dim _Menos = 0
            If _Accion <> Accion.Mostrar_todo Then
                _Mostrar_Chk = True
                _Menos = 10
            End If

            .Columns("Chk").Width = 30
            .Columns("Chk").HeaderText = "Sel."
            .Columns("Chk").Visible = _Mostrar_Chk
            .Columns("Chk").Frozen = True
            .Columns("Chk").DisplayIndex = 0
            .Columns("Chk").ReadOnly = False

            .Columns("ENDO").Width = 80
            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Visible = True
            .Columns("ENDO").Frozen = True
            .Columns("ENDO").DisplayIndex = 1
            .Columns("ENDO").ReadOnly = True

            .Columns("TIDO").Width = 30
            .Columns("TIDO").HeaderText = "Tipo"
            .Columns("TIDO").Visible = True
            .Columns("TIDO").Frozen = True
            .Columns("TIDO").DisplayIndex = 2
            .Columns("TIDO").ReadOnly = True

            .Columns("Tipo").Width = 150
            .Columns("Tipo").HeaderText = "Tipo Doc."
            .Columns("Tipo").Visible = True
            .Columns("Tipo").Frozen = True
            .Columns("Tipo").DisplayIndex = 3
            .Columns("Tipo").ReadOnly = True

            .Columns("NUDO").Width = 70
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Visible = True
            .Columns("NUDO").Frozen = True
            .Columns("NUDO").DisplayIndex = 4
            .Columns("NUDO").ReadOnly = True

            .Columns("FEEMDO").Width = 70
            .Columns("FEEMDO").HeaderText = "F. Emisión"
            .Columns("FEEMDO").Visible = True
            '.Columns("FEEMDO").Frozen = True
            .Columns("FEEMDO").DisplayIndex = 5
            .Columns("FEEMDO").ReadOnly = True

            .Columns("FEVE").Width = 80
            .Columns("FEVE").HeaderText = "Vencimiento"
            .Columns("FEVE").Visible = True
            '.Columns("FEVE").Frozen = True
            .Columns("FEVE").DisplayIndex = 6
            .Columns("FEVE").ReadOnly = True

            .Columns("DIAS").Width = 35
            .Columns("DIAS").HeaderText = "Días"
            .Columns("DIAS").Visible = True
            .Columns("DIAS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("DIAS").Frozen = True
            .Columns("DIAS").DisplayIndex = 7
            .Columns("DIAS").ReadOnly = True

            .Columns("DIAS_ATRASO").Width = 70
            .Columns("DIAS_ATRASO").HeaderText = "Días Morosidad"
            .Columns("DIAS_ATRASO").Visible = True
            .Columns("DIAS_ATRASO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("DIAS_ATRASO").Frozen = True
            .Columns("DIAS_ATRASO").DisplayIndex = 8
            .Columns("DIAS_ATRASO").ReadOnly = True

            .Columns("VAVE").HeaderText = "Valor Vencimiento" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("VAVE").Width = 90 - _Menos
            .Columns("VAVE").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("VAVE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAVE").Visible = True
            .Columns("VAVE").DisplayIndex = 9
            .Columns("VAVE").ReadOnly = True

            .Columns("VAABVE").HeaderText = "Valor Abonado" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("VAABVE").Width = 90 - _Menos
            .Columns("VAABVE").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("VAABVE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAABVE").Visible = True
            .Columns("VAABVE").DisplayIndex = 10
            .Columns("VAABVE").ReadOnly = True

            .Columns("SALDO").HeaderText = "Saldo" '_Dia_Palabra & ", " & _Dia & "-" & _Mes & "-" & _Ano
            .Columns("SALDO").Width = 90 - _Menos
            .Columns("SALDO").DefaultCellStyle.Format = "$ ###,##0"
            .Columns("SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO").Visible = True
            .Columns("SALDO").DisplayIndex = 11
            .Columns("SALDO").ReadOnly = True

            .Columns("FEULVEDO").Width = 70
            .Columns("FEULVEDO").HeaderText = "Ult. Venci."
            .Columns("FEULVEDO").Visible = True
            '.Columns("FEULVEDO").Frozen = True
            .Columns("FEULVEDO").DisplayIndex = 12
            .Columns("FEULVEDO").ReadOnly = True

        End With

        Dim _Cuenta_Error_Vencimiento = 0

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Tido = _Fila.Cells("TIDO").Value
            Dim _Dias_Atraso As Integer = _Fila.Cells("DIAS_ATRASO").Value

            Dim _Idmaeven = _Fila.Cells("IDMAEVEN").Value

            If _Idmaeven = 0 Then
                _Fila.DefaultCellStyle.BackColor = Color.Pink
            End If

            If _Tido = "NCV" Or _Tido = "NCC" Then
                _Fila.DefaultCellStyle.BackColor = Color.Yellow
            End If

            Dim _Color As Color

            If Global_Thema = Enum_Themas.Oscuro Then

                If _Dias_Atraso < 0 Then
                    _Color = Color.FromArgb(220, 78, 66)
                ElseIf _Dias_Atraso = 0 Then
                    _Color = Color.FromArgb(37, 136, 213)
                ElseIf _Dias_Atraso > 0 Then
                    _Color = Color.FromArgb(30, 215, 96)
                End If

            Else

                If _Dias_Atraso < 0 Then
                    _Color = Color.Red
                ElseIf _Dias_Atraso = 0 Then
                    _Color = Color.Blue
                ElseIf _Dias_Atraso > 0 Then
                    _Color = Color.Green
                End If

            End If

            _Fila.Cells("DIAS_ATRASO").Style.ForeColor = _Color

            If _Accion = Accion.Pago_Proveedores Then

                Dim _Sospecha_Stock As Boolean = _Fila.Cells("SOSPECHA_STOCK").Value
                Dim _Sospecha_Devolucion As Boolean = _Fila.Cells("SOSPECHA_DEVOLUCION").Value
                Dim _Revisado_Pagar As Boolean = _Fila.Cells("REVISADO_PAGAR").Value

                If _Revisado_Pagar Then

                    If _Sospecha_Stock Then
                        _Fila.DefaultCellStyle.BackColor = Color.Yellow
                    End If

                    If _Sospecha_Devolucion Then
                        _Fila.DefaultCellStyle.ForeColor = Color.White
                        _Fila.DefaultCellStyle.BackColor = Color.Red
                    End If

                Else
                    _Fila.DefaultCellStyle.BackColor = Color.LightSalmon
                End If

            End If

            If Global_Thema = Enum_Themas.Oscuro Then
                Dim _Cl As Color = _Fila.DefaultCellStyle.BackColor
                If _Cl.Name <> "0" Then
                    _Fila.DefaultCellStyle.ForeColor = Color.Black
                End If

            End If

            Dim _ForeColor As Color = _Fila.DefaultCellStyle.ForeColor
            Dim _BackColor As Color = _Fila.DefaultCellStyle.BackColor

            Try
                If _Fila.Cells("Revisar_Documento").Value Then
                    _Fila.DefaultCellStyle.ForeColor = Color.White
                    _Fila.DefaultCellStyle.BackColor = Color.Red
                    _Fila.Cells("DIAS_ATRASO").Style.ForeColor = _ForeColor
                    _Fila.Cells("DIAS_ATRASO").Style.BackColor = _BackColor
                    _Cuenta_Error_Vencimiento += 1
                End If
            Catch ex As Exception
                _Fila.DefaultCellStyle.ForeColor = _ForeColor
                _Fila.DefaultCellStyle.BackColor = _BackColor
                _Fila.Cells("DIAS_ATRASO").Style.ForeColor = _ForeColor
                _Fila.Cells("DIAS_ATRASO").Style.BackColor = _BackColor
            End Try

        Next

        If CBool(_Cuenta_Error_Vencimiento) Then
            MessageBoxEx.Show(Me, "Existen algún documento que tiene vencimiento, sin embargo, no existe pago asociado" & vbCrLf &
                             "La fila estara marcada en rojo completamente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
                    Dim _Cabeza = sender.Columns(CType(sender, DataGridView).CurrentCell.ColumnIndex).Name

                    Select Case _Cabeza
                        Case "ENDO"
                            ShowContextMenu(Menu_Contextual_04_Opciones_Cobranza)
                        Case Else
                            ShowContextMenu(Menu_Contextual_01_Opciones_Documento)
                    End Select
                End If
            End With
        End If

    End Sub

    Private Sub Sb_Grilla_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Nokoen = Trim(_Fila.Cells("NOKOEN").Value)
        Dim _Ult_evento = _Fila.Cells("ULT_EVENTO").Value

        If Global_Thema = Enum_Themas.Oscuro Then
            If Not String.IsNullOrEmpty(_Ult_evento) Then
                _Ult_evento = ", Anotación: " & _Ult_evento
                Lbl_Nombre_Entidad.ForeColor = Color.Yellow
            Else
                Lbl_Nombre_Entidad.ForeColor = Color.White
            End If
        Else
            If Not String.IsNullOrEmpty(_Ult_evento) Then
                _Ult_evento = ", Anotación: " & _Ult_evento
                Lbl_Nombre_Entidad.BackColor = Color.Yellow
            Else
                Lbl_Nombre_Entidad.BackColor = Color.White
            End If
        End If

        Lbl_Nombre_Entidad.Text = _Nokoen & " " & _Ult_evento


    End Sub

    Private Sub Sb_Grilla_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        If _Accion = Accion.Mover_Fechas Then

            Dim _Fecha_Emision As Date = _Fila.Cells("FEEMDO").Value

            If _Fecha_Emision > _Nueva_Fecha_Vencimiento Then
                'Beep()
                'ToastNotification.Show(Me, "LA", My.Resources.cross, 3 * 1000, _
                '                       eToastGlowColor.Red, eToastPosition.MiddleCenter)

                MessageBoxEx.Show(Me, "La fecha de emisión es menor a la fecha de vencimiento",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Cancel = True
            End If

        ElseIf _Accion = Accion.Pago_Proveedores Then

            'CAST( 0 AS Bit) AS SOSPECHA_STOCK,CAST( 0 AS Float) AS SOSPECHA_DEVOLUCION,  

            Dim _Chk As Boolean = _Fila.Cells("Chk").Value
            Dim _Revisado_Pagar As Boolean = _Fila.Cells("REVISADO_PAGAR").Value
            Dim _Sospecha_stock As Boolean = _Fila.Cells("SOSPECHA_STOCK").Value
            Dim _Sospecha_devolucion As Boolean = _Fila.Cells("SOSPECHA_DEVOLUCION").Value

            If Not _Revisado_Pagar Then

                If Not _Sospecha_stock And Not _Sospecha_devolucion Then
                    MessageBoxEx.Show(Me, "Este registro no ha sido revisado por el sistema para poder dar autorización de pago", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    e.Cancel = True
                    Exit Sub
                End If

            End If

            If _Sospecha_stock Then
                If Not Fx_Tiene_Permiso(Me, "Ppro0001") Then
                    'MessageBoxEx.Show(Me, "Hay productos con stock ", _
                    '             "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.Cancel = True
                    Exit Sub
                End If
            End If

            If _Sospecha_devolucion Then
                If Not Fx_Tiene_Permiso(Me, "Ppro0002") Then
                    'MessageBoxEx.Show(Me, "El documento tiene Guías de devolución sin Nota de credito", _
                    '                  "Documento sospechoso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.Cancel = True
                    Exit Sub
                End If
            End If

        End If

        Try
            If _Fila.Cells("Revisar_Documento").Value Then
                MessageBoxEx.Show(Me, "El Valor Abonado de este registro no tiene sustento en un pago relacionado." & vbCrLf &
                             "Esto quiere decir que el Saldo no es confiable y probablemente sea mayor al informado." & vbCrLf & vbCrLf &
                             "Revise el documento e informe de esta situación al administrador del sistema", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                e.Cancel = True
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Sb_Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
        ShowContextMenu(Menu_Contextual_01_Opciones_Documento) 'Sb_Ver_Documento()
    End Sub

    Private Sub Sb_Grilla_ColumnHeaderMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Sb_Formato_Grilla()
    End Sub

    Private Sub Sb_Grilla_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        Grilla.EndEdit()
    End Sub

    Private Sub Sb_Grilla_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        _Total_Saldos = 0
        For Each _Row As DataGridViewRow In Grilla.Rows
            If _Row.Cells("Chk").Value Then
                _Total_Saldos += _Row.Cells("SALDO").Value
            End If
        Next
        Lbl_Total_Saldos.Text = FormatCurrency(_Total_Saldos, 0)

    End Sub

    Private Sub Btn_Ver_documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_documento.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaeven = _Fila.Cells("IDMAEVEN").Value

        If CBool(_Idmaeven) Then
            Sb_Ver_Documento()
        Else

            Dim _Idmaedpce = _Fila.Cells("IDMAEEDO").Value

            Dim Fm As New Frm_Pagos_Documentos_Pagados(_Idmaedpce)
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Function ChequearTodo(Grilla As DataGridView,
                                  Chk As Boolean)

        _Total_Saldos = 0
        For Each _Fila As DataGridViewRow In Grilla.Rows
            _Fila.Cells("Chk").Value = Chk
            If Chk Then
                _Total_Saldos += _Fila.Cells("SALDO").Value
            End If
        Next

        Lbl_Total_Saldos.Text = FormatCurrency(_Total_Saldos, 0)


    End Function

    Private Sub Sb_Chk_Marcar_todo_CheckedChanged(sender As Object, e As EventArgs)
        Dim chk As Boolean = Chk_Marcar_todo.Checked
        ChequearTodo(Grilla, chk)
        Grilla.Refresh()
    End Sub

    Private Sub Btn_Enviar_correo_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Enviar_correo.Click
        Sb_Enviar_Detalle_Cobranza_Por_Mail(Me, _TblInforme)
    End Sub

#Region "ENVIO DE CORREO COBRANZA"

    Public Function Sb_Enviar_Detalle_Cobranza_Por_Mail(_Formulario As Form,
                                                        _TblInforme As DataTable) As Boolean


        Dim Crea_Htm As New Clase_Crear_Documento_Htm
        Dim _Ruta As String = AppPath() & "\Data\" & RutEmpresa & "\Tmp"
        Dim _Email_Contacto = String.Empty

        If CBool(_TblInforme.Rows.Count) Then

            If Fx_Revizar_Chequeados(True) Then

                Dim _Nudo As String '= _Enc_Documento.Rows(0).Item("NUDO")
                Dim _Tido As String '= _Enc_Documento.Rows(0).Item("TIDO")
                Dim _TipoDoc As String '= Trim(trae_dato(tb, cn1, "NOTIDO", "TABTIDO", "TIDO = '" & _Tido & "'"))
                Dim _Estado As String ' = _Enc_Documento.Rows(0).Item("ESDO")

                Dim _Endo = _TblInforme.Rows(0).Item("ENDO")
                Dim _Suendo = _TblInforme.Rows(0).Item("SUENDO")

                Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Endo & "' And SUEN = '" & _Suendo & "'"
                Dim _RowEntidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
                Dim _Row_Contacto As DataRow

                Dim _Razon_Social As String = _TblInforme.Rows(0).Item("NOKOEN")

                Dim Fm As New Frm_Crear_Entidad_Mt_Lista_contactos(True)
                Fm.Text = "SELECCIONE UN CONTACTO PARA ENVIAR EL CORREO DE COBRANZA"
                Fm.Pro_CodEntidad = _Endo
                Fm.Pro_SucEntidad = _Suendo
                Fm.ShowDialog(Me)

                If Fm.Pro_ContactoSeleccionado Then
                    _Row_Contacto = Fm.Row_Contacto
                    _Email_Contacto = Trim(_Row_Contacto.Item("EMAILCON"))
                Else
                    MessageBoxEx.Show(Me, "No se seleccionó ningún contacto", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                Fm.Dispose()


                If Fx_Crear_Informe_Html_Cobranza(_Ruta, _TblInforme, "Informe_cobranza") Then

                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Correos Where Id = " & _Id_Correo
                    Dim _TblCorreo As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                    If CBool(_TblCorreo.Rows.Count) Then

                        Dim _Remitente = _TblCorreo.Rows(0).Item("Remitente")
                        Dim _CC = _TblCorreo.Rows(0).Item("CC")
                        Dim _Host = _TblCorreo.Rows(0).Item("Host")
                        Dim _Puerto = _TblCorreo.Rows(0).Item("Puerto")
                        Dim _Contrasena = _TblCorreo.Rows(0).Item("Contrasena")
                        Dim _Asunto = _TblCorreo.Rows(0).Item("Asunto") & " (" & Trim(_Razon_Social) & ")"
                        Dim _CuerpoMensaje = _TblCorreo.Rows(0).Item("CuerpoMensaje")

                        If String.IsNullOrEmpty(Trim(_CuerpoMensaje)) Then
                            _CuerpoMensaje = "<HTML>"
                        End If

                        Dim _SSL = _TblCorreo.Rows(0).Item("SSL")
                        Dim _Es_Html = _TblCorreo.Rows(0).Item("Es_Html")


                        Dim _Adjunto As String = _Ruta & "\Informe_cobranza.Html"
                        Dim _Cuerpo_Html = LeeArchivo(_Adjunto)

                        _CuerpoMensaje = Replace(_CuerpoMensaje, "<HTML>", _Cuerpo_Html)

                        Dim Envio_Occ_Mail As New Class_Outlook
                        Dim _Para As String = _Email_Contacto
                        Dim _Cuerpo As String = _CuerpoMensaje

                        Envio_Occ_Mail.Sb_Crear_Correo_Outlook(_Para, "", _Asunto, _Cuerpo, _Es_Html)

                        If MessageBoxEx.Show(Me, "¿Se envío el correo de cobranza?",
                                             "Marcar documentos",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                            Sb_Marcar_Documentos(_TblInforme, Marca_Mevento.Correo, Btn_Enviar_correo.Image)
                            Me.Close()

                        End If
                        Return True
                    Else

                        MessageBoxEx.Show(_Formulario, "Debe asignar un correo por defecto", "Falta correo en configuración",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    End If
                End If
            End If
        Else
            MessageBoxEx.Show(_Formulario, "No se encontro el documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Function

    Enum Marca_Mevento
        Correo
        Telefono
        Visita
    End Enum

    Function Fx_Crear_Informe_Html_Cobranza(_Ruta_Archivo As String,
                                            _TblDetalle As DataTable,
                                            _Nombre_Archivo_Adjunto As String) As Boolean
        Try


            Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Crear_Html_Facturas_Cobranza

            Dim _Documento_Html As String = My.Resources.Recursos_Inf_Compras_Vencimiento.Crear_Html_Facturas_Cobranza
            Dim _Detalle_Doc As String
            Dim _Suma_saldo As Double

            Consulta_sql = "Select TOP 1 * From MAEEN Where KOEN = '" & _CodEntidad & "'" ' And SUEN = '" & _CodSucEntidad & "'"
            Dim _Tbl_Entidad As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            _Documento_Html = Replace(_Documento_Html, "#Razon_Social#", _Tbl_Entidad.Rows(0).Item("NOKOEN"))


            For Each _Detalle As DataRow In _TblDetalle.Rows

                Dim _Chk As Boolean = _Detalle.Item("Chk")

                If _Chk Then

                    Dim _Tido As String = UCase(_Detalle.Item("TIDO"))
                    Dim _Nudo As String = _Detalle.Item("NUDO")
                    Dim _Feemdo As String = FormatDateTime(_Detalle.Item("FEEMDO"), DateFormat.ShortDate)
                    Dim _Feve As String = FormatDateTime(_Detalle.Item("FEVE"), DateFormat.ShortDate)
                    Dim _Dias_Atraso As Long = _Detalle.Item("DIAS_ATRASO")

                    Dim _Vave As String = FormatCurrency(_Detalle.Item("VAVE"), 0)
                    Dim _Vaabve As String = FormatCurrency(_Detalle.Item("VAABVE"), 0)
                    Dim _Saldo As String = FormatCurrency(_Detalle.Item("SALDO"), 0)



                    If _Tido = "FCV" Then
                        _Tido = "Factura"
                    ElseIf _Tido = "BLV" Then
                        _Tido = "Boleta"
                    End If

                    _Detalle_Doc +=
                    "<tr bgcolor=" & Chr(34) & "PaleGoldenrod" & Chr(34) & ">" & vbCrLf &
                    "<td align=right class=" & Chr(34) & "style20" & Chr(34) &
                    " align=" & Chr(34) & "center" & Chr(34) & ">" & _Tido & "</td>" & vbCrLf &
                    "<td align=right class=" & Chr(34) & "style17" & Chr(34) & ">" & _Nudo & "</td>" & vbCrLf &
                    "<td align=right class=" & Chr(34) & "style18" & Chr(34) & ">" & _Feemdo & "</td>" & vbCrLf &
                    "<td align=right class=" & Chr(34) & "style21" & Chr(34) & ">" & _Feve & "</td>" & vbCrLf &
                    "<td align=right class=" & Chr(34) & "style19" & Chr(34) & ">" & _Dias_Atraso & "</td>" & vbCrLf &
                    "<td align=right class=" & Chr(34) & "style19" & Chr(34) & ">" & _Vave & "</td>" & vbCrLf &
                    "<td align=right class=" & Chr(34) & "style14" & Chr(34) & ">" & _Vaabve & "</td>" & vbCrLf &
                    "<td align=right class=" & Chr(34) & "style22" & Chr(34) & ">" & _Saldo & "</td></tr>" & vbCrLf

                    _Suma_saldo += _Detalle.Item("SALDO")

                End If

            Next

            Dim _Total_Deuda As String = FormatCurrency(_Suma_saldo, 0)

            _Documento_Html = Replace(_Documento_Html, "#Detalle#", _Detalle_Doc)
            _Documento_Html = Replace(_Documento_Html, "#Total_deuda#", _Total_Deuda)

            _Documento_Html = Replace(_Documento_Html, "á", "&aacute;")
            _Documento_Html = Replace(_Documento_Html, "é", "&eacute;")
            _Documento_Html = Replace(_Documento_Html, "í", "&iacute;")
            _Documento_Html = Replace(_Documento_Html, "ó", "&oacute;")
            _Documento_Html = Replace(_Documento_Html, "ú", "&uacute;")
            _Documento_Html = Replace(_Documento_Html, "ñ", "&ntilde;")
            _Documento_Html = Replace(_Documento_Html, "Ñ", "&Ntilde;")

            ' Acento en Html
            'a = &aacute;
            'é = &eacute;
            'í = &iacute;
            'ó = &oacute;
            'ú = &uacute;
            'ñ = &ntilde;
            'Ñ = &Ntilde;

            CrearArchivoTxt(_Ruta_Archivo & "\", _Nombre_Archivo_Adjunto & ".Html", _Documento_Html, False)

            Return True
        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try

    End Function

#End Region

    Function Fx_Revizar_Chequeados(_Mostrar_Mensaje As Boolean) As Boolean

        Dim _Registros = 0

        For Each _Detalle As DataRow In _TblInforme.Rows
            If _Detalle.Item("Chk") Then _Registros += 1
        Next

        If Not CBool(_Registros) Then
            If _Mostrar_Mensaje Then
                MessageBoxEx.Show(Me, "No hay documentos seleccionados", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If

        Return CBool(_Registros)


    End Function

    Sub Sb_Marcar_Documentos(_TblInforme As DataTable,
                             _Marca As Marca_Mevento,
                             _Imagen As Image,
                             Optional _Cerrar_al_guardar As Boolean = False)

        Dim _Kocarac As String

        Select Case _Marca
            Case Marca_Mevento.Correo : _Kocarac = "CORREO"
            Case Marca_Mevento.Telefono : _Kocarac = "TELEFONO"
            Case Marca_Mevento.Visita : _Kocarac = "VISITA"
        End Select


        Consulta_sql = String.Empty

        If CBool(_TblInforme.Rows.Count) Then

            Dim _Aceptado As Boolean
            Dim _Cotacto As String

            _Aceptado = InputBox_Bk(Me, _Kocarac, "Nombre del contacto", _Cotacto,
                                    False, _Tipo_Mayus_Minus.Mayusculas, 50, True, _Tipo_Imagen.Texto, False)
            Dim _Observacion As String = _Cotacto
            Dim _Contador = 0
            Dim _HoraGrab = Hora_Grab_fx(False)

            If Not _Aceptado Then

                Beep()
                ToastNotification.Show(Me, "NO SE MARCO NINGUN DOCUMENTO",
                                       My.Resources.cross,
                                       2 * 1000, eToastGlowColor.Red,
                                       eToastPosition.MiddleCenter)
                Return

            End If

            For Each _Detalle As DataRow In _TblInforme.Rows

                If _Detalle.Item("Chk") Then

                    Dim _Idmaeedo As Integer = _Detalle.Item("IDMAEEDO")
                    Dim _Idmaeven = _Detalle.Item("IDMAEVEN")
                    Dim _Archive As String

                    If CBool(_Idmaeven) Then
                        _Archive = "MAEEDO"
                    Else
                        _Archive = "MAEDPCE"
                    End If

                    Consulta_sql += "INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC," &
                                    "FECHAREF,HORAGRAB) VALUES " & vbCrLf &
                                    "('" & _Archive & "'," & _Idmaeedo & ",'',0,'" & FUNCIONARIO &
                                    "',GetDate(),'COBRANZA','" & _Kocarac & "'" &
                                    ",'" & _Observacion &
                                    "','" & Format(FechaDelServidor, "yyyyMMdd") & "'," & _HoraGrab & ")" & vbCrLf
                    _Contador += 1
                End If

            Next

            If CBool(_Contador) Then

                Dim _Idmaeen As Integer = _Sql.Fx_Trae_Dato("MAEEN", "IDMAEEN",
                                                    "KOEN = '" & _CodEntidad & "'And TIPOSUC = 'P'", True) ' And SUEN = '" & _Suendo & "'")

                Consulta_sql += "INSERT INTO MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC," &
                                "FECHAREF,HORAGRAB) VALUES " & vbCrLf &
                                "('MAEEN'," & _Idmaeen & ",'',0,'" & FUNCIONARIO &
                                "',GetDate(),'COBRANZA','" & _Kocarac & "'" &
                                ",'" & _Observacion &
                                "','" & Format(FechaDelServidor, "yyyyMMdd") & "'," & _HoraGrab & ")" & vbCrLf
            End If

            If Not String.IsNullOrEmpty(Consulta_sql) Then

                Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                    'If  _Sql.Ej_consulta_IDU(Consulta_Sql) Then

                    If _Cerrar_al_guardar Then
                        _Imagen_Marcados = _Imagen
                        Me.Close()
                    Else
                        Beep()
                        ToastNotification.Show(Me, "REGISTROS MARCADOS CORRECTAMENTE",
                                               _Imagen,
                                               2 * 1000, eToastGlowColor.Green,
                                               eToastPosition.MiddleCenter)

                        _Imagen_Marcados = Nothing
                    End If

                End If
            End If

        End If

    End Sub

    Sub Sb_Buscar_Documento_Lista_Actual(Optional Ult_Nro As String = "")

        Dim _UN As Integer = CInt(Val(Ult_Nro))

        If CBool(_UN) Then
            Ult_Nro = _UN
        Else
            Ult_Nro = String.Empty
        End If

        Dim _Aceptado As Boolean
        Dim _NroDocumento As String = Ult_Nro

        _Aceptado = InputBox_Bk(Me, "", "Buscar documento en listado actual", Ult_Nro,
                                                  False, _Tipo_Mayus_Minus.Mayusculas, 10, True,
                                                  _Tipo_Imagen.Buscar_documento, False, _Tipo_Caracter.Solo_Numeros_Enteros)

        If _Aceptado Then

            _NroDocumento = numero_(_NroDocumento, 10)

            If BuscarDatoEnGrilla(_NroDocumento, "NUDO", Grilla) Then
                Grilla.CurrentCell = Grilla.Rows(Grilla.CurrentRow.Index).Cells("NUDO")
                Grilla.Focus()
            Else
                If BuscarDatoEnGrilla(Trim(Int(_NroDocumento)), "NUDO", Grilla) Then
                    Grilla.CurrentCell = Grilla.Rows(Grilla.CurrentRow.Index).Cells("NUDO")
                    Grilla.Focus()
                Else
                    MessageBoxEx.Show(Me, "Documento no encontrado en el tratamiento actual", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Sb_Buscar_Documento_Lista_Actual(_NroDocumento)
                End If
            End If

        End If

    End Sub

    Private Sub Btn_Buscar_Documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Buscar_Documento.Click
        Sb_Buscar_Documento_Lista_Actual()
    End Sub



    Private Sub Btn_Marcar_Masivamente_Anotaciones_De_Documentos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Marcar_Masivamente_Anotaciones_De_Documentos.Click


        Dim Fm As New Frm_Inf_Vencimientos_Detalle_Documentos(_CodEntidad, _CodSucEntidad, _SqlConsulta_informe,
                                                              _Fecha_Inicio, _Fecha_Fin,
                                                              Accion.Marcar_Anotaciones_Masivas, _Id_Correo, _Informe)

        Fm._Nueva_Fecha_Vencimiento = _Nueva_Fecha_Vencimiento
        Fm.Pro_Correr_a_la_derecha = True
        Fm._Mover_Fechas = False
        Fm.Chk_Mostrar_Pagos_Pendientes.Checked = Chk_Mostrar_Pagos_Pendientes.Checked
        Fm.Sb_Generar_Informe()
        Fm.Btn_Anotaciones_al_documento.Visible = True
        Fm.ShowDialog(Me)

        Dim _Imagen As Image = Fm.Pro_Imagen_Marcados

        If Not (_Imagen Is Nothing) Then
            Beep()
            ToastNotification.Show(Me, "REGISTROS MARCADOS CORRECTAMENTE",
                                   _Imagen,
                                   2 * 1000, eToastGlowColor.Green,
                                   eToastPosition.MiddleCenter)
        End If

        Fm.Dispose()

    End Sub


    Private Sub Btn_Ver_Anotaciones_Documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_Anotaciones_Documento.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaeven = _Fila.Cells("IDMAEVEN").Value
        Dim _Id = _Fila.Cells("IDMAEEDO").Value

        Dim _Nokoen = Trim(_Fila.Cells("Nokoen").Value)
        Dim _Tipo = Trim(_Fila.Cells("Tipo").Value)
        Dim _Nudo = Trim(_Fila.Cells("NUDO").Value)
        Dim _Feve = FormatDateTime(_Fila.Cells("Feve").Value, DateFormat.ShortDate)

        If CBool(_Idmaeven) Then

            Dim Fm As New Frm_Anotaciones_Ver_Anotaciones(_Id, Frm_Anotaciones_Ver_Anotaciones.Tipo_Tabla.MAEEDO)
            Fm.Text = "Nómina de eventos asociados, " & _Tipo & " - " & _Nudo & ", Vencimiento: " & _Feve & "," & _Nokoen
            Fm.ShowDialog(Me)
            Fm.Dispose()
        Else
            Dim Fm As New Frm_Anotaciones_Ver_Anotaciones(_Id, Frm_Anotaciones_Ver_Anotaciones.Tipo_Tabla.MAEDPCE)
            Fm.Text = "Nómina de eventos asociados, " & _Tipo & " - " & _Nudo & ", Vencimiento: " & _Feve & "," & _Nokoen
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub


    Private Sub Btn_Anotaciones_al_documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Anotaciones_al_documento.Click
        If Fx_Revizar_Chequeados(True) Then
            ShowContextMenu(Menu_Contextual_02_Anotaciones)
        End If
    End Sub


    Private Sub Btn_Anotacion_Telefono_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Anotacion_Telefono.Click
        Sb_Marcar_Documentos(_TblInforme, Marca_Mevento.Telefono, Btn_Anotacion_Telefono.Image, True)
    End Sub

    Private Sub Btn_Anotacion_Mail_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Anotacion_Mail.Click
        Sb_Marcar_Documentos(_TblInforme, Marca_Mevento.Correo, Btn_Anotacion_Mail.Image, True)
    End Sub

    Private Sub Btn_Anotacion_Visita_Cliente_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Anotacion_Visita_Cliente.Click
        Sb_Marcar_Documentos(_TblInforme, Marca_Mevento.Visita, Btn_Anotacion_Visita_Cliente.Image, True)
    End Sub

    Sub Sb_Exportar_Excel_Con_Anotaciones()

        Consulta_sql = _SqlConsulta_informe
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", _Fecha_Inicio)
        Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", _Fecha_Fin)

        Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional_Maeedo#", _Filtro_Maeedo)
        Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional_Maedpce#", _Filtro_Maedpce)

        If Not Chk_Mostrar_Pagos_Pendientes.Checked Then
            Consulta_sql += vbCrLf & vbCrLf & "Delete #INFVEN Where Deuda = 'Pagos'" & vbCrLf & vbCrLf
        End If

        Consulta_sql += "SELECT Zw.ENDO,Zw.SUENDO,Zw.NOKOEN,Zw.TIDO,Zw.Tipo,Zw.NUDO,Zw.FEEMDO,Zw.FEVE," & vbCrLf &
                        "Zw.DIAS,Zw.DIAS_ATRASO,Zw.VAVE,Zw.VAABVE,Zw.SALDO,Zw.ESPGVE,Zw.FEULVEDO," & vbCrLf &
                        "Mv.FEVENTO,Mv.KOTABLA,Mv.KOCARAC,Mv.NOKOCARAC" & vbCrLf &
                        "FROM  #INFVEN Zw LEFT OUTER JOIN" & vbCrLf &
                        "dbo.MEVENTO Mv ON Zw.ARCHIRVE = Mv.ARCHIRVE AND Zw.IDRVE = Mv.IDRVE" & vbCrLf & vbCrLf &
                        "Order By Zw.TIDO,Zw.NUDO,Mv.IDEVENTO" & vbCrLf &
                        "Drop Table #INFVEN"
        Dim _TblInforme_Excel = _Sql.Fx_Get_DataTable(Consulta_sql)


        ExportarTabla_JetExcel_Tabla(_TblInforme_Excel, Me, "Cobranza")

        Return

        If Not Chk_Mostrar_Pagos_Pendientes.Checked Then
            Consulta_sql += vbCrLf & vbCrLf & "Delete #INFVEN Where Deuda = 'Pagos'" & vbCrLf & vbCrLf
        End If

        If _CodEntidad = "ZZZZZZ" Then
            Consulta_sql += "SELECT CAST( 0 AS bit) AS Chk,*" & vbCrLf &
                            "From #INFVEN" & vbCrLf &
                            "Order By FEVE,FEEMDO" & vbCrLf &
                            "Drop Table #INFVEN"
        Else

            'If Chk_Mostrar_Pagos_Pendientes.Checked Then
            'Consulta_sql += My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Pagos_Clientes & vbCrLf & vbCrLf

            'End If

            Select Case _Accion

                Case Accion.Mover_Fechas, Accion.Mostrar_todo, Accion.Marcar_Anotaciones_Masivas

                    Consulta_sql += "SELECT CAST( 0 AS bit) AS Chk,*" & vbCrLf &
                                "From #INFVEN" & vbCrLf &
                                "Where ENDO = '" & _CodEntidad & "'" & vbCrLf &
                                "Order By FEVE,FEEMDO" & vbCrLf &
                                "Drop Table #INFVEN"

                Case Accion.Cobranza

                    Consulta_sql += "SELECT CAST( 0 AS bit) AS Chk,*" & vbCrLf &
                                "From #INFVEN" & vbCrLf &
                                "Where ENDO = '" & _CodEntidad & "'" & vbCrLf &
                                "AND TIDO IN ('FCV','BLV')" & vbCrLf &
                                "Order By FEVE,FEEMDO" & vbCrLf &
                                "Drop Table #INFVEN"

            End Select

        End If




    End Sub

#Region "PROPIEDADES"

    Public Property Pro_Imagen_Marcados() As Image
        Get
            Return _Imagen_Marcados
        End Get
        Set(value As Image)

        End Set
    End Property

    Public Property Pro_Chk_Deuda_Efectiva()
        Get
            Return Chk_Mostrar_Pagos_Pendientes.Checked
        End Get
        Set(value)
            Chk_Mostrar_Pagos_Pendientes.Checked = value
        End Set
    End Property

    Public Property Pro_Correr_a_la_derecha() As Boolean
        Get
            Return _Correr_a_la_derecha
        End Get
        Set(value As Boolean)
            _Correr_a_la_derecha = value
        End Set
    End Property

    Public Property Pro_Filtro_Maeedo() As String
        Get
            Return _Filtro_Maeedo
        End Get
        Set(value As String)
            _Filtro_Maeedo = value
        End Set
    End Property

    Public Property Pro_Filtro_Maedpce() As String
        Get
            Return _Filtro_Maedpce
        End Get
        Set(value As String)
            _Filtro_Maedpce = value
        End Set
    End Property

#End Region


    Private Sub Btn_Exportar_Informe_01_Vista_Actual_Click(sender As System.Object, e As System.EventArgs)
        ExportarTabla_JetExcel_Tabla(_TblInforme, Me, "Detalle_de_documentos")
    End Sub

    Private Sub Btn_Exportar_Informe_02_Mostrar_todas_las_Anotaciones_Click(sender As System.Object, e As System.EventArgs)
        Sb_Exportar_Excel_Con_Anotaciones()
    End Sub

    Private Sub Btn_Exportar_Informe_03_Entidades_Click(sender As System.Object, e As System.EventArgs)

        Dim _Filtro As String = Generar_Filtro_IN(_TblInforme, "", "ENDO", False, False, "'")
        Consulta_sql = "Select Distinct * From MAEEN Where KOEN In " & _Filtro

        ExportarTabla_JetExcel(Consulta_sql, Me, "Entidades")
    End Sub


    Private Sub Btn_Imprimir_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Imprimir.Click

        Consulta_sql = "Select top 1 *  From MAEEN Where KOEN = '" & _CodEntidad & "'"
        Dim _Row_Entidada As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Sb_Imprimir_Reporte(_Row_Entidada)

    End Sub

    Sub Sb_Imprimir_Reporte(_Row_Entidad As DataRow)

        Dim _Registros = 0
        Dim _Total As Double
        Dim _Filtro_Documentos As String

        For Each _Detalle As DataRow In _TblInforme.Rows
            If _Detalle.Item("Chk") Then
                _Registros += 1
                _Total += _Detalle.Item("SALDO")
            End If
        Next

        If Not CBool(_Registros) Then
            Beep()
            ToastNotification.Show(Me, "NO HAY DOCUMENTOS SELECCIONADOS",
                                  My.Resources.cross,
                                   1 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Return
        End If

        _Filtro_Documentos = Generar_Filtro_IN(_TblInforme, "Chk", "IDMAEEDO", False, True, "")

        Consulta_sql = "Select Top 1 * From CONFIGP"
        Dim _Row_Configp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Try

            Consulta_sql = _SqlConsulta_informe
            Consulta_sql = Replace(Consulta_sql, "#Fecha_Inicio#", _Fecha_Inicio)
            Consulta_sql = Replace(Consulta_sql, "#Fecha_Fin#", _Fecha_Fin)

            Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional_Maeedo#", _Filtro_Maeedo)
            Consulta_sql = Replace(Consulta_sql, "--#Filtro_Adicional_Maedpce#", _Filtro_Maedpce)

            Consulta_sql += "SELECT CAST( 0 AS bit) AS Chk,*" & vbCrLf &
                            "From #INFVEN" & vbCrLf &
                            "Where ENDO = '" & _CodEntidad & "'" & vbCrLf &
                            "And IDMAEEDO In " & _Filtro_Documentos & vbCrLf &
                            "Order By FEVE,FEEMDO" & vbCrLf &
                            "Drop Table #INFVEN"

            Dim _Tbl_Informe As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)


            If _Tbl_Informe.Rows.Count > 0 Then
                'iniciamos el form y el reporte
                Dim form As New Frm_VerReportes
                Dim report As New CR_Infome_Estado_Cta

                'le indicamos el datasource al report, que sera el recordset
                'que hemos llenado
                report.SetDataSource(_Tbl_Informe)

                'le indicamos el reportsource al crviewer del segundo form
                'que sera el report que creamos


                report.SetParameterValue("Razon_Empresa", _Row_Configp.Item("RAZON"))
                report.SetParameterValue("Rut_Empresa", _Row_Configp.Item("RUT"))
                report.SetParameterValue("Giro_Empresa", _Row_Configp.Item("GIRO"))
                report.SetParameterValue("Telefono_Empresa", _Row_Configp.Item("TELEFONOS"))
                report.SetParameterValue("Direccion_Empresa", _Row_Configp.Item("DIRECCION"))


                Dim _Rut = _Row_Entidad.Item("RTEN")
                _Rut = FormatNumber(_Rut, 0) & "-" & RutDigito(_Rut)

                report.SetParameterValue("Koen", _Rut)
                report.SetParameterValue("Nokoen", _Row_Entidad.Item("NOKOEN"))


                report.SetParameterValue("Total", _Total)


                form.CrystalReportViewer1.ReportSource = report
                form.ShowInTaskbar = True
                form.Show()

                form = Nothing

            Else
                MessageBoxEx.Show(Me, "No hay datos en la tabla de aprobación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Exportar_Excel.Click
        ShowContextMenu(Menu_Contextual_03_Exportar_Excel)
    End Sub

    Private Sub Btn_Autorizar_Pago_Proveedor_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Autorizar_Pago_Proveedor.Click

        Dim _Contador_Pagar = 0
        Dim _Contador_No_Pagar = 0

        Dim _Consulta_sql = String.Empty

        Dim _Filtro_Idmaeven As String = Generar_Filtro_IN(_TblInforme, "", "IDMAEVEN", False, False, "")

        _Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det" & Space(1) &
                        "Where Idmaeven In " & _Filtro_Idmaeven & vbCrLf & vbCrLf

        For Each _Fila_G As DataGridViewRow In Grilla.Rows

            Dim _Idmaeedo As Integer = _Fila_G.Cells("IDMAEEDO").Value
            Dim _Idmaeven As Integer = _Fila_G.Cells("IDMAEVEN").Value
            Dim _Chk As Boolean = _Fila_G.Cells("Chk").Value
            Dim _Saldo As Double = _Fila_G.Cells("SALDO").Value

            Dim _Sospecha_Stock = CInt(_Fila_G.Cells("SOSPECHA_STOCK").Value) * -1
            Dim _Sospecha_Devolucion = CInt(_Fila_G.Cells("SOSPECHA_DEVOLUCION").Value) * -1
            Dim _Revisado = CInt(_Fila_G.Cells("REVISADO_PAGAR").Value) * -1
            Dim _Autorizado = CInt(_Fila_G.Cells("AUTORIZADO_PAGAR").Value) * -1

            If Not _Chk Then
                _Saldo = 0
            End If

            If CBool(_Revisado) Then '_Chk Then

                _Autorizado = CInt(_Chk) * -1

                _Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det" & Space(1) &
                                 "(Id_Autoriza,Idmaeedo,Idmaeven,Revisado,Sospecha_Stock,Sospecha_Devolucion,Autorizado,Funcionario_Autoriza,Saldo) Values" & Space(1) &
                                 "(@Id_Autoriza," & _Idmaeedo & "," & _Idmaeven & "," & _Revisado &
                                 "," & _Sospecha_Stock & "," & _Sospecha_Devolucion &
                                 "," & _Autorizado & ",'" & FUNCIONARIO &
                                 "'," & De_Num_a_Tx_01(_Saldo, False, 5) & ")" & vbCrLf
                _Contador_Pagar += 1
            Else
                _Contador_No_Pagar += 1
            End If

        Next

        If CBool(_Contador_Pagar) Then

            Dim _Grabar = True

            If CBool(_Contador_No_Pagar) Then

                If MessageBoxEx.Show(Me, "Existen (" & _Contador_No_Pagar & ") documentos que no han sido autorizados para pagar" & vbCrLf &
                                     "¿Desea seguir con la gestión?", "Autorizar a pagar documentos",
                                     MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.OK Then
                    Return
                End If

            End If

            Dim Fm As New Frm_Pago_Masivo_Autoriza_Enc(Frm_Pago_Masivo_Autoriza_Enc.Enum_Accion.Crear)
            Fm.Pro_Total = _Total_Saldos
            Fm.ShowDialog(Me)
            _Grabar = Fm.Pro_Grabar

            Dim _Fecha_Pago As Date = FormatDateTime(Fm.Pro_Fecha_Pago, DateFormat.ShortDate)
            Dim _Tipo_Pago As String = Fm.Pro_Tipo_Pago
            Dim _Referencia As String = Fm.Pro_Referencia
            Fm.Dispose()

            If _Grabar Then

                Dim _TblAutorizar As DataTable

                _Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_01_Enc (Funcionario,Referencia,Fecha_Autoriza,Fecha_Pago,Tipo_Pago,Total)" & vbCrLf &
                                "Values ('" & FUNCIONARIO & "','" & _Referencia & "',GETDATE(),'" &
                                Format("yyyyMMdd", _Fecha_Pago) & "','" & _Tipo_Pago & "'," &
                                De_Num_a_Tx_01(_Total_Saldos, False, 5) & ")" & vbCrLf & vbCrLf &
                                "Declare @Id_Autoriza Int" & vbCrLf & vbCrLf &
                                "Set @Id_Autoriza = (SELECT @@IDENTITY)" & vbCrLf & vbCrLf &
                                _Consulta_sql & vbCrLf &
                                "Update " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Set Id_Autoriza = 0 Where Autorizado = 0" & vbCrLf &
                                "Select @Id_Autoriza As Id_Autoriza"

                _TblAutorizar = _Sql.Fx_Get_DataTable(_Consulta_sql)

                If (_TblAutorizar.Rows.Count) Then

                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where Autorizado = 0"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    Dim _Id_Autoriza = _TblAutorizar.Rows(0).Item("Id_Autoriza")

                    MessageBoxEx.Show(Me, "Autorización guardada correctamente" & vbCrLf & vbCrLf &
                                      "Número de autorización: " & _Id_Autoriza & vbCrLf & vbCrLf &
                                      "Total de documentos autorizados a pagar " & FormatNumber(_Contador_Pagar, 0),
                                      "Autorizar a pagar a proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    RemoveHandler Grilla.CellBeginEdit, AddressOf Sb_Grilla_CellBeginEdit
                    Sb_Generar_Informe("And #INFVEN.IDMAEVEN Not In (Select Idmaeven From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where Autorizado = 1)")
                    AddHandler Grilla.CellBeginEdit, AddressOf Sb_Grilla_CellBeginEdit
                    _Reprocesar_Informe = True
                    Sb_Load()

                End If

            End If
        Else
            MessageBoxEx.Show(Me, "No hay documentos seleccionados", "Autorizar a pagar a proveedores",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub

    Private Sub Btn_Mnu_Ficha_Entidad_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Ficha_Entidad.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Endo = _Fila.Cells("ENDO").Value
        Dim _SuEndo = "" '_Fila.Cells("SUENDO").Value

        Dim Fm As New Frm_Crear_Entidad_Mt
        Fm.Fx_Llenar_Entidad(_Endo, _SuEndo)
        Fm.CrearEntidad = False
        Fm.EditarEntidad = True
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Mnu_Mostrar_deuda_actual_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Mostrar_deuda_actual.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Endo = _Fila.Cells("ENDO").Value
        Dim _SuEndo = _Fila.Cells("SUENDO").Value

        Sb_Mostrar_Deuda(_Endo, _SuEndo, Accion.Mostrar_todo, False)

    End Sub

    Private Sub Btn_Mnu_Mostrar_deuda_completa_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Mostrar_deuda_completa.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Endo = _Fila.Cells("ENDO").Value
        Dim _SuEndo = _Fila.Cells("SUENDO").Value

        Sb_Mostrar_Deuda(_Endo, _SuEndo, Accion.Mostrar_todo, True)

    End Sub

    Private Sub Btn_Mnu_Enviar_Correo_Cobranza_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Enviar_Correo_Cobranza.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Endo = _Fila.Cells("ENDO").Value
        Dim _SuEndo = _Fila.Cells("SUENDO").Value

        Sb_Mostrar_Deuda(_Endo, _SuEndo, Accion.Cobranza, False)

    End Sub

    Private Sub Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Enviar_Correo_Cobranza_Deuda_Completa.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Endo = _Fila.Cells("ENDO").Value
        Dim _SuEndo = _Fila.Cells("SUENDO").Value

        Sb_Mostrar_Deuda(_Endo, _SuEndo, Accion.Cobranza, True)

    End Sub

    Private Sub Sb_Chk_Mostrar_Pagos_Pendientes_CheckedChanging(sender As System.Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)
        e.Cancel = True
    End Sub


    Private Sub Btn_Autorizar_Pago_De_Documentos_Proveedores_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Autorizar_Pago_De_Documentos_Proveedores.Click

        If Fx_Tiene_Permiso(Me, "Ppro0003") Then

            If _Accion <> Accion.Pago_Proveedores Then

                Dim _Contador_Autorizado = 0
                Dim _Contador_No_Autorizado = 0
                Dim _Filtro_Idmaeven As String = Generar_Filtro_IN(_TblInforme, "Chk", "IDMAEVEN", True, True)
                Dim _TblAutorizados As DataTable

                If _Filtro_Idmaeven <> "()" Then
                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where Idmaeven In " & _Filtro_Idmaeven
                    _TblAutorizados = _Sql.Fx_Get_DataTable(Consulta_sql)
                End If

                If Not _TblAutorizados Is Nothing Then
                    _Contador_Autorizado = _TblAutorizados.Rows.Count
                End If

                Consulta_sql = String.Empty

                If CBool(_Contador_Autorizado) Then

                    Dim _Contador_Sin_Revisar = _TblInforme.Rows.Count - _Contador_Autorizado

                    Dim Chk_Gestionar_Solo_Pendientes As New Command
                    Chk_Gestionar_Solo_Pendientes.Checked = False
                    Chk_Gestionar_Solo_Pendientes.Name = "Chk_Gestionar_Solo_Pendientes"
                    Chk_Gestionar_Solo_Pendientes.Text = "Gestionar solo documentos que no tengan nomina de pago"

                    Dim Chk_Gestionar_Todos As New Command
                    Chk_Gestionar_Todos.Checked = False
                    Chk_Gestionar_Todos.Name = "Chk_Gestionar_Todos"
                    Chk_Gestionar_Todos.Text = "Gestionar todos (re-nominar anteriores)"

                    Dim Chk_Revisar As New Command
                    Chk_Revisar.Checked = False
                    Chk_Revisar.Name = "Chk_Revisar"
                    Chk_Revisar.Text = "Revisar los que ya tienen nomina (exportar a Excel)"

                    Dim _Opciones() As Command = {Chk_Gestionar_Solo_Pendientes, Chk_Gestionar_Todos, Chk_Revisar}

                    Dim info As New TaskDialogInfo("Autorización de pago a proveedor",
                                         eTaskDialogIcon.Shield,
                                         "Existen registros que ya han sido revisados y validados",
                                         "Exiten " & FormatNumber(_Contador_Autorizado, 0) & " documentos que ya estan autorizados de pagar en este tratamiento" & vbCrLf &
                                         "Se mostraran solo los registros pendientes de autorizar (" & FormatNumber(_Contador_Sin_Revisar, 0) & " registros)" & vbCrLf &
                                         "Elija su opción",
                                        eTaskDialogButton.Yes + eTaskDialogButton.No _
                                         , eTaskDialogBackgroundColor.Blue, _Opciones, Nothing, Nothing, "BakApp", Nothing)
                    Dim result As eTaskDialogResult = TaskDialog.Show(info)

                    If result = eTaskDialogResult.Yes Then

                        If Chk_Gestionar_Solo_Pendientes.Checked Then
                            Consulta_sql = "And #INFVEN.IDMAEVEN Not In " & _Filtro_Idmaeven
                        ElseIf Chk_Gestionar_Todos.Checked Then

                            If MessageBoxEx.Show(Me, "Esto eliminara las nominas anteriores para todos los documentos que ya tenian" & vbCrLf &
                                                 "¿Confirma la nueva nomina para todos los documentos?", "Validación",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then

                                Consulta_sql = String.Empty

                                For Each _Fnom As DataRow In _TblAutorizados.Rows

                                    Dim _Idmaeven = _Fnom.Item("Idmaeven")
                                    Dim _Id_Autoriza = _Fnom.Item("Id_Autoriza")

                                    Consulta_sql += "Insert Into " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det_Eli (Id_Autoriza,Idmaeedo,Idmaeven,Saldo,Observacion)
                                                     Select Id_Autoriza,Idmaeedo,Idmaeven,Saldo,'Se elimina nomina masiva desde informe de compras pagos a proveedores. Hecho por (" & FUNCIONARIO & ")' 
                                                     From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det
                                                     Where Id_Autoriza = " & _Id_Autoriza & " And Idmaeven = " & _Idmaeven & vbCrLf &
                                                    "Delete " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where Id_Autoriza = " & _Id_Autoriza & " And Idmaeven = " & _Idmaeven & vbCrLf

                                Next

                                If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                                    _Contador_Autorizado = 0
                                End If

                            Else
                                Return
                            End If

                        ElseIf Chk_Revisar.Checked Then

                            'Dim _Filtro_Idmaeedo = Generar_Filtro_IN(_TblAutorizados, "", "Idmaeedo", True, False, "")

                            Consulta_sql = "Select Edo.TIDO As Td,Edo.NUDO As Numero,Edo.ENDO As Entidad,Edo.SUENDO As Suc,Emp.NOKOEN As 'Razon Social',Ent.Id_Autoriza As Id_Nomina,Ent.Referencia As Nomina
                                            From MAEEDO Edo
                                            Left Join MAEEN Emp On Emp.KOEN = Edo.ENDO And Edo.SUENDO = Emp.SUEN
                                            Left Join MAEVEN Ven On Edo.IDMAEEDO = Ven.IDMAEEDO 
                                            Left Join " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Det On Det.Idmaeven = Ven.IDMAEVEN
                                            Left Join " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_01_Enc Ent On Ent.Id_Autoriza = Det.Id_Autoriza
                                            Where Ven.IDMAEVEN In " & _Filtro_Idmaeven
                            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                            ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Doc_Autorizados")

                            Return

                        Else

                            MessageBoxEx.Show(Me, "Debe seleccionar una opción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return

                        End If

                    Else
                        Return
                    End If

                End If


                If CBool(_Contador_Autorizado) And _Contador_Autorizado = Grilla.RowCount Then
                    MessageBoxEx.Show(Me, "Todos los documentos ya estan autorizados en otra nomina, no hay datos que mostrar",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                _Accion = Accion.Pago_Proveedores

                Dim _Filtro_Sql As String = "And #INFVEN.IDMAEVEN Not In (Select Idmaeven From " & _Global_BaseBk & "Zw_Pago_Prov_Autoriza_02_Det Where Autorizado = 1)" & vbCrLf &
                                            "And TIDO IN ('BLC','FCC','RGA')"

                Sb_Generar_Informe(_Filtro_Sql)
                Sb_Load()

            End If

            Dim Fm As New Frm_Inf_Vencimientos_Revisa_Documentos(Grilla)
            Fm.ShowDialog(Me)

            _Revisado_Pago_Proveedores = Fm.Pro_Revisado

            'Btn_Pagar_Transferencia.Visible = _Revisado_Pago_Proveedores

            _Min_Rotacion_Anual = Val(Fm.Txt_Cantidad.Text)

            Fm.Dispose()
            Grilla.EndEdit()
            Me.Refresh()

            _Total_Saldos = 0

            For Each _Fila As DataRow In _TblInforme.Rows
                If _Fila.Item("Chk") Then
                    _Total_Saldos += _Fila.Item("SALDO")
                End If
            Next

            Lbl_Total_Saldos.Text = FormatCurrency(_Total_Saldos, 0)

        End If


    End Sub

    Sub Sb_Mostrar_Deuda(_Endo As String,
                         _Suendo As String,
                         _Accion As Accion,
                         _Mostrar_todo As Boolean)


        Dim _Fx_Fecha_Inicio = _Fecha_Inicio
        Dim _Fx_Fecha_Fin = _Fecha_Fin

        If _Mostrar_todo Then
            _Fx_Fecha_Inicio = "19000101"
            _Fx_Fecha_Fin = "30001201"
        End If


        Dim Fm As New Frm_Inf_Vencimientos_Detalle_Documentos(_Endo, _Suendo, _SqlConsulta_informe,
                                                              _Fx_Fecha_Inicio, _Fx_Fecha_Fin,
                                                              _Accion, _Id_Correo, _Informe)

        Fm._Nueva_Fecha_Vencimiento = _Nueva_Fecha_Vencimiento
        Fm._Mover_Fechas = False
        Fm.Pro_Chk_Deuda_Efectiva = Chk_Mostrar_Pagos_Pendientes.Checked

        Fm.Pro_Filtro_Maeedo = _Filtro_Maeedo
        Fm.Pro_Filtro_Maedpce = _Filtro_Maedpce

        Fm.Sb_Generar_Informe()

        If Fm.Grilla.RowCount Then
            Fm.ShowDialog(Me)
        Else
            MessageBoxEx.Show(Me, "No hay datos que mostrar", "Informe detallado",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Fm.Dispose()

    End Sub

End Class




