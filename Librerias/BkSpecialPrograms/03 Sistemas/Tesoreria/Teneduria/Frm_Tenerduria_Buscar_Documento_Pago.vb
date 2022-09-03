'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls


Public Class Frm_Tenerduria_Buscar_Documento_Pago

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Dim _Tbl_Filtro_Documentos As DataTable
    Dim _Filtro_Todos_Los_Documentos As Boolean
    Dim _Seleccionar As Boolean
    Dim _Row_Documento_Seleccionado As DataRow

    Dim _Row_Entidad As DataRow

    Enum Enum_Tipo_Pago
        Proveedores
        Clientes
        Ambos
    End Enum
    Enum Enum_Estado
        Sin_condicion
        Pendient
        Pagado
        Anulado
        Elimado
        Protestado
    End Enum
    Enum Enum_Fecha
        Sin_condicion
        Mayor_que
        Menor_que
        Igal_a
        Desd_hasta
    End Enum

    Dim _Tipo_Pago As Enum_Tipo_Pago

    Public Property Pro_Rdb_Tipo_Doc_Uno() As Boolean
        Get
            Return Rdb_Tipo_Doc_Uno.Checked
        End Get
        Set(value As Boolean)
            Rdb_Tipo_Doc_Uno.Checked = value
        End Set
    End Property
    Public Property Pro_Rdb_Tipo_Doc_Algunos() As Boolean
        Get
            Return Rdb_Tipo_Doc_Algunos.Checked
        End Get
        Set(value As Boolean)
            Rdb_Tipo_Doc_Algunos.Checked = value
        End Set
    End Property
    Public Property Pro_Rdb_Entidad_Una() As Boolean
        Get
            Return Rdb_Entidad_Una.Checked
        End Get
        Set(value As Boolean)
            Rdb_Entidad_Una.Checked = value
        End Set
    End Property
    Public Property Pro_Rdb_Entidad_Todas() As Boolean
        Get
            Return Rdb_Entidad_Todas.Checked
        End Get
        Set(value As Boolean)
            Rdb_Entidad_Todas.Checked = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Documentos() As DataTable
        Get
            Return _Tbl_Filtro_Documentos
        End Get
        Set(value As DataTable)
            _Tbl_Filtro_Documentos = value
        End Set
    End Property
    Public Property Pro_Filtro_Todos_Los_Documentos() As Boolean
        Get
            Return _Filtro_Todos_Los_Documentos
        End Get
        Set(value As Boolean)
            _Filtro_Todos_Los_Documentos = value
        End Set
    End Property
    Public Property Pro_Cmb_Tipo_de_documentos() As String
        Get
            Return Cmb_Tipo_de_documentos.SelectedValue
        End Get
        Set(value As String)
            Cmb_Tipo_de_documentos.SelectedValue = value
        End Set
    End Property
    Public Property Pro_Txt_Numero_Interno() As String
        Get
            Return Txt_Numero_Interno.Text
        End Get
        Set(value As String)
            Txt_Numero_Interno.Text = value
        End Set
    End Property
    Public Property ProTxt_Nro_Cheque() As String
        Get
            Return Txt_Nro_Cheque.Text
        End Get
        Set(value As String)
            Txt_Nro_Cheque.Text = value
        End Set
    End Property
    Public Property Pro_Num_Monto() As Double
        Get
            Return Num_Monto.Value
        End Get
        Set(value As Double)
            Num_Monto.Value = value
        End Set
    End Property
    Public Property Pro_Estado() As Enum_Estado
        Get

        End Get
        Set(value As Enum_Estado)

            Dim _Estado As String

            Select Case value
                Case Enum_Estado.Sin_condicion
                    _Estado = ""
                Case Enum_Estado.Pendient
                    _Estado = "P"
                Case Enum_Estado.Pagado
                    _Estado = "C"
                Case Enum_Estado.Anulado
                    _Estado = "N"
                Case Enum_Estado.Elimado
                    _Estado = "E"
                Case Enum_Estado.Protestado
                    _Estado = "R"
            End Select

            Cmb_Estado.SelectedValue = _Estado

        End Set
    End Property
    Public Property Pro_Fecha_Emision() As Enum_Fecha
        Get

        End Get
        Set(value As Enum_Fecha)
            Cmb_Fecha_Emision.SelectedValue = value
        End Set
    End Property
    Public Property Pro_Fecha_Vencimineto() As Enum_Fecha
        Get

        End Get
        Set(value As Enum_Fecha)
            Cmb_Fecha_Vencimineto.SelectedValue = value
        End Set
    End Property
    Public Property Pro_Row_Entidada() As DataRow
        Get
            Return _Row_Entidad
        End Get
        Set(value As DataRow)
            _Row_Entidad = value
            Txt_Entidad.Text = _Row_Entidad.Item("NOKOEN")
        End Set
    End Property

    Public ReadOnly Property Pro_Row_Documento_Seleccionado() As DataRow
        Get
            Return _Row_Documento_Seleccionado
        End Get
    End Property


    Public Sub New(Tipo_Pago As Enum_Tipo_Pago, Solo_Seleccionar As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Seleccionar = Solo_Seleccionar

        _Tipo_Pago = Tipo_Pago
        Dim _Filtro_TP

        If _Tipo_Pago = Enum_Tipo_Pago.Clientes Then
            Me.Text = "BUSCAR DOCUMENTO DE PAGO CLIENTES (TENEDURIA)"
            Grupo_Entidad.Text = "Cliente del documento"
            _Filtro_TP = "And Tabla In ('TIDP_Cli','TIDP_Cli_T')"
        ElseIf _Tipo_Pago = Enum_Tipo_Pago.Proveedores Then
            Me.Text = "BUSCAR DOCUMENTO DE PAGO PROVEEDORES (TENEDURIA)"
            Grupo_Entidad.Text = "Proveedor del documento"
            _Filtro_TP = "And Tabla = 'TIDP_Pro'"
        ElseIf _Tipo_Pago = Enum_Tipo_Pago.Ambos Then
            Me.Text = "BUSCAR DOCUMENTO DE PAGO CLIENTES/PROVEEDORES"
            Grupo_Entidad.Text = "Cliente del documento"
            _Filtro_TP = "And Tabla In ('TIDP_Cli','TIDP_Cli_T','TIDP_Pro')"
        End If

        caract_combo(Cmb_Tipo_de_documentos)

        Consulta_sql = "SELECT '' As PADRE,'Cualquiera...' As HIJO, 0 As Orden" & vbCrLf & "Union" & vbCrLf &
                       "SELECT CodigoTabla As PADRE,CodigoTabla+'-'+NombreTabla As HIJO,Orden" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "Where 1 > 0" & vbCrLf &
                       _Filtro_TP & vbCrLf &
                       "Order By Orden"

        Cmb_Tipo_de_documentos.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)
        Cmb_Tipo_de_documentos.SelectedValue = ""

        Sb_Llena_Combo_Estado_Documento()
        Sb_Llena_Combo_Fecha(Cmb_Fecha_Emision)
        Sb_Llena_Combo_Fecha(Cmb_Fecha_Vencimineto)

        Dim _Fecha_Servidor As Date = FechaDelServidor()

        Dtp_Fecha_Emision_Desde.Value = _Fecha_Servidor
        Dtp_Fecha_Emision_Hasta.Value = _Fecha_Servidor
        Dtp_Fecha_Vencimiento_Desde.Value = _Fecha_Servidor
        Dtp_Fecha_Emision_Hasta.Value = _Fecha_Servidor

        Btn_Entidad_Una.Enabled = False

        'Txt_Entidad.FocusHighlightColor = Color.FromArgb(139, 193, 232)
        'Txt_Nro_Cheque.FocusHighlightColor = Color.FromArgb(139, 193, 232)
        'Txt_Numero_Interno.FocusHighlightColor = Color.FromArgb(139, 193, 232)

        If Global_Thema = Enum_Themas.Oscuro Then
            Txt_Entidad.FocusHighlightEnabled = False
            Txt_Nro_Cheque.FocusHighlightEnabled = False
            Txt_Numero_Interno.FocusHighlightEnabled = False
        End If

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Tenerduria_Buscar_Documento_Pago_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Sb_Cmb_Fecha_SelectedIndexChanged(Nothing, Nothing)

        AddHandler Rdb_Tipo_Doc_Algunos.CheckedChanged, AddressOf Sb_Rdb_Tipo_Doc_CheckedChanged
        AddHandler Rdb_Tipo_Doc_Uno.CheckedChanged, AddressOf Sb_Rdb_Tipo_Doc_CheckedChanged

        AddHandler Rdb_Entidad_Una.CheckedChanged, AddressOf Sb_Rdb_Entidad_CheckedChanged
        AddHandler Rdb_Entidad_Todas.CheckedChanged, AddressOf Sb_Rdb_Entidad_CheckedChanged

        AddHandler Cmb_Fecha_Emision.SelectedIndexChanged, AddressOf Sb_Cmb_Fecha_SelectedIndexChanged
        AddHandler Cmb_Fecha_Vencimineto.SelectedIndexChanged, AddressOf Sb_Cmb_Fecha_SelectedIndexChanged

    End Sub

    Function Fx_Generar_Informe() As DataTable

        Dim _Filtro As String = Fx_Filtro()

        Dim _Top = String.Empty

        If CBool(Num_Top.Value) Then
            _Top = "Top " & Num_Top.Value
        End If

        Try

            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            Consulta_sql = My.Resources.Recursos_Teneduria_Pagos.SQLQuery_Buscar_documentos_de_pago
            Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
            Consulta_sql = Replace(Consulta_sql, "#Filtro#", _Filtro)
            Consulta_sql = Replace(Consulta_sql, "#Top#", _Top)

            Fx_Generar_Informe = _Sql.Fx_Get_Tablas(Consulta_sql)

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Problema al generar el informe", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try


    End Function

    Function Fx_Filtro() As String

        Dim _Filtro_Doc_Interno = String.Empty
        Dim _Filtro_Num_Cheque = String.Empty
        Dim _Filtro_Monto = String.Empty
        Dim _Filtro_Tipo_Doc = String.Empty
        Dim _Filtro_Estado = String.Empty
        Dim _Filtro_Entidad = String.Empty

        Dim _Filtro_Fecha_Emision = String.Empty
        Dim _Filtro_Fecha_Vencimiento = String.Empty

        Dim _Tidp
        Dim _Nudp

        If Rdb_Tipo_Doc_Uno.Checked Then
            _Tidp = Cmb_Tipo_de_documentos.SelectedValue
            If String.IsNullOrEmpty(_Tidp) Then

                Dim _Filtro_TP = String.Empty

                If _Tipo_Pago = Enum_Tipo_Pago.Clientes Then
                    _Filtro_TP = "And Tabla In ('TIDP_Cli','TIDP_Cli_T')"
                ElseIf _Tipo_Pago = Enum_Tipo_Pago.Proveedores Then
                    _Filtro_TP = "And Tabla = 'TIDP_Pro'"
                End If

                _Filtro_Tipo_Doc = "And TIDP In (SELECT CodigoTabla" & Space(1) &
                               "FROM " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                               "Where 1 > 0" & vbCrLf &
                               _Filtro_TP & ")"

            Else
                _Filtro_Tipo_Doc = "And TIDP = '" & _Tidp & "'"
            End If
        Else
            If _Filtro_Todos_Los_Documentos Then
                _Filtro_Tipo_Doc = String.Empty
            Else
                _Tidp = Generar_Filtro_IN(_Tbl_Filtro_Documentos, "Chk", "Codigo", False, True)
                _Filtro_Tipo_Doc = "And TIDP In " & _Tidp
            End If
        End If

        If Not String.IsNullOrEmpty(Txt_Numero_Interno.Text) Then
            If Trim(Txt_Numero_Interno.Text).Length = 13 Then
                _Nudp = Mid(Txt_Numero_Interno.Text, 4, 13)
                _Filtro_Doc_Interno = "And TIDP = '" & Mid(Txt_Numero_Interno.Text, 1, 3) & "' And NUDP = '" & _Nudp & "'"
            Else
                _Nudp = Txt_Numero_Interno.Text
                _Filtro_Doc_Interno = "And NUDP = '" & _Nudp & "'"
            End If
        End If

        If Not String.IsNullOrEmpty(Txt_Nro_Cheque.Text) Then
            _Filtro_Num_Cheque = "And NUCUDP Like '" & Txt_Nro_Cheque.Text & "'"
        End If

        If Not String.IsNullOrEmpty(Cmb_Estado.SelectedValue) Then
            _Filtro_Estado = "And ESPGDP = '" & Cmb_Estado.SelectedValue & "'"
        End If

        If String.IsNullOrEmpty(Num_Monto.Text) Then Num_Monto.Value = 0

        If CBool(Num_Monto.Value) Then
            _Filtro_Monto = "And VADP = " & De_Num_a_Tx_01(Num_Monto.Value)
        End If

        Dim _Index = Cmb_Fecha_Emision.SelectedValue

        Select Case _Index
            Case 0
                _Filtro_Fecha_Emision = String.Empty
            Case 1
                _Filtro_Fecha_Emision = "And FEEMDP > '" & Format(Dtp_Fecha_Emision_Desde.Value, "yyyyMMdd") & "'"
            Case 2
                _Filtro_Fecha_Emision = "And FEEMDP < '" & Format(Dtp_Fecha_Emision_Desde.Value, "yyyyMMdd") & "'"
            Case 3
                _Filtro_Fecha_Emision = "And FEEMDP = '" & Format(Dtp_Fecha_Emision_Desde.Value, "yyyyMMdd") & "'"
            Case 4
                _Filtro_Fecha_Emision = "And FEEMDP BETWEEN '" & Format(Dtp_Fecha_Emision_Desde.Value, "yyyyMMdd") &
                                 "' AND '" & Format(Dtp_Fecha_Emision_Hasta.Value, "yyyyMMdd") & "'"
        End Select


        _Index = Cmb_Fecha_Vencimineto.SelectedValue

        Select Case _Index
            Case 0
                _Filtro_Fecha_Vencimiento = String.Empty
            Case 1
                _Filtro_Fecha_Vencimiento = "And FEVEDP > '" & Format(Dtp_Fecha_Vencimiento_Desde.Value, "yyyyMMdd") & "'"
            Case 2
                _Filtro_Fecha_Vencimiento = "And FEVEDP < '" & Format(Dtp_Fecha_Vencimiento_Desde.Value, "yyyyMMdd") & "'"
            Case 3
                _Filtro_Fecha_Vencimiento = "And FEVEDP = '" & Format(Dtp_Fecha_Vencimiento_Desde.Value, "yyyyMMdd") & "'"
            Case 4
                _Filtro_Fecha_Vencimiento = "And FEVEDP BETWEEN '" & Format(Dtp_Fecha_Emision_Desde.Value, "yyyyMMdd") &
                                 "' AND '" & Format(Dtp_Fecha_Emision_Hasta.Value, "yyyyMMdd") & "'"
        End Select

        If Rdb_Entidad_Una.Checked Then
            _Filtro_Entidad = "And ENDP = '" & _Row_Entidad.Item("KOEN") & "'"
        End If

        Dim _Filtro As String

        _Filtro = _Filtro_Doc_Interno & Space(1) &
                  _Filtro_Entidad & Space(1) &
                  _Filtro_Estado & Space(1) &
                  _Filtro_Fecha_Emision & Space(1) &
                  _Filtro_Fecha_Vencimiento & Space(1) &
                  _Filtro_Monto & Space(1) &
                  _Filtro_Num_Cheque & Space(1) &
                  _Filtro_Tipo_Doc

        Return _Filtro

    End Function
    Private Sub Btn_Buscar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Buscar.Click

        Dim _Falta_Tidp As Boolean

        If Rdb_Tipo_Doc_Algunos.Checked Then
            If (_Tbl_Filtro_Documentos Is Nothing) Then
                _Falta_Tidp = True
            Else
                If CBool(_Tbl_Filtro_Documentos.Rows.Count) Then
                    _Falta_Tidp = True
                End If
            End If
        End If


        If _Falta_Tidp Then
            MessageBoxEx.Show(Me, "Debe ingresar algún tipo de documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Tbl As DataTable = Fx_Generar_Informe()

        If CBool(_Tbl.Rows.Count) Then
            If _Tbl.Rows.Count > 100 Then

                If MessageBoxEx.Show(Me, "Documentos encontrador " & FormatNumber(_Tbl.Rows.Count, 0), "Información",
                                  MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) <> Windows.Forms.DialogResult.Yes Then
                    Return
                End If

            End If

            Dim Fm As New Frm_Teneduria_Lista_Documentos(_Seleccionar)
            Fm.Pro_Tbl_Informe = _Tbl
            Fm.ShowDialog(Me)
            _Row_Documento_Seleccionado = Fm.Pro_Row_Documento
            Fm.Dispose()

            If _Seleccionar Then
                If Not (_Row_Documento_Seleccionado Is Nothing) Then
                    Me.Close()
                End If
            End If

        Else
            MessageBoxEx.Show(Me, "No se encontraron registros", "Buscar pagos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub
    Private Sub Btn_Buscar_Documentos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Buscar_Documentos.Click

        Dim _Condicion_Adicional = String.Empty
        Dim _No_Tiene_Filtros As Boolean

        If _Tipo_Pago = Enum_Tipo_Pago.Clientes Then
            _Condicion_Adicional = "And Tabla In ('TIDP_Cli','TIDP_Cli_T')"
        ElseIf _Tipo_Pago = Enum_Tipo_Pago.Proveedores Then
            _Condicion_Adicional = "And Tabla = 'TIDP_Pro'"
        End If

        Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Otra, False)
        Fm.Pro_Tabla = _Global_BaseBk & "Zw_TablaDeCaracterizaciones"
        Fm.Pro_Campo = "CodigoTabla"
        Fm.Pro_Descripcion = "NombreTabla"
        Fm.Pro_Tbl_Filtro = _Tbl_Filtro_Documentos
        Fm.Pro_Sql_Filtro_Condicion_Extra = _Condicion_Adicional
        Fm.Pro_Seleccionar_Todo = False
        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then
            _Tbl_Filtro_Documentos = Fm.Pro_Tbl_Filtro
            _Filtro_Todos_Los_Documentos = Fm.Pro_Filtrar_Todo
        Else
            If (_Tbl_Filtro_Documentos Is Nothing) Then
                _No_Tiene_Filtros = True
            Else
                If Not CBool(_Tbl_Filtro_Documentos.Rows.Count) Then
                    _No_Tiene_Filtros = True
                End If
            End If
        End If

        If _No_Tiene_Filtros Then
            Rdb_Tipo_Doc_Uno.Checked = True
        End If

    End Sub
    Private Sub Frm_Tenerduria_Buscar_Documento_Pago_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Btn_Entidad_Una_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Entidad_Una.Click

        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.BtnCrearUser.Visible = False
        Fm.BtnEditarUser.Visible = False
        Fm.BtnEliminarUser.Visible = False
        Fm.ShowDialog(Me)

        _Row_Entidad = Fm.Pro_RowEntidad

        If Not (Fm.Pro_RowEntidad Is Nothing) Then
            Txt_Entidad.Text = _Row_Entidad.Item("NOKOEN")
        Else
            Txt_Entidad.Text = String.Empty
            Rdb_Entidad_Todas.Checked = True
        End If

    End Sub
    Private Sub Rdb_Entidad_Todas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rdb_Entidad_Todas.CheckedChanged
        If Rdb_Entidad_Todas.Checked Then
            _Row_Entidad = Nothing
            Txt_Entidad.Text = String.Empty
        End If
    End Sub
    Sub Sb_Llena_Combo_Estado_Documento()

        caract_combo(Cmb_Estado)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))
        ',,,,,,

        dr = dt.NewRow() : dr("Padre") = "" : dr("Hijo") = "Sin condición..." : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "P" : dr("Hijo") = "Pendiente" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "C" : dr("Hijo") = "Pagado" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "N" : dr("Hijo") = "Anulado" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "E" : dr("Hijo") = "Elimado" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "R" : dr("Hijo") = "Protestado" : dt.Rows.Add(dr)

        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        With Cmb_Estado
            .DataSource = Nothing
            .DataSource = dt
        End With

        Cmb_Estado.SelectedValue = ""

    End Sub
    Sub Sb_Llena_Combo_Fecha(_Cmb_Combo As DevComponents.DotNetBar.Controls.ComboBoxEx)

        caract_combo(_Cmb_Combo)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))
        ',,,,,,

        dr = dt.NewRow() : dr("Padre") = "0" : dr("Hijo") = "Sin condición..." : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "1" : dr("Hijo") = "Mayor que" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "2" : dr("Hijo") = "Menor que" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "3" : dr("Hijo") = "Igual a" : dt.Rows.Add(dr)
        dr = dt.NewRow() : dr("Padre") = "4" : dr("Hijo") = "Desde Hasta" : dt.Rows.Add(dr)

        'cerramos el datareader y la conexión
        'añadimos la tabla al dataset
        rs.Tables.Add(dt)

        With _Cmb_Combo
            .DataSource = Nothing
            .DataSource = dt
        End With

        _Cmb_Combo.SelectedValue = 0

    End Sub
    Private Sub Sb_Rdb_Tipo_Doc_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Rdb_Tipo_Doc_Algunos.Checked Then
            Btn_Buscar_Documentos.Enabled = True
            Cmb_Tipo_de_documentos.Enabled = False
        Else
            Btn_Buscar_Documentos.Enabled = False
            Cmb_Tipo_de_documentos.Enabled = True
        End If
    End Sub
    Private Sub Sb_Rdb_Entidad_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Rdb_Entidad_Una.Checked Then
            Btn_Entidad_Una.Enabled = True
            Txt_Entidad.Enabled = True
        Else
            Btn_Entidad_Una.Enabled = False
            Txt_Entidad.Enabled = False
        End If
    End Sub
    Private Sub Sb_Cmb_Fecha_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

        Dim _Index = Cmb_Fecha_Emision.SelectedValue

        Select Case _Index
            Case 0
                Lbl_FE_hasta.Enabled = False
                Dtp_Fecha_Emision_Desde.Enabled = False
                Dtp_Fecha_Emision_Hasta.Enabled = False
            Case 1, 2, 3
                Lbl_FE_hasta.Enabled = False
                Dtp_Fecha_Emision_Desde.Enabled = True
                Dtp_Fecha_Emision_Hasta.Enabled = False
            Case 4
                Lbl_FE_hasta.Enabled = True
                Dtp_Fecha_Emision_Desde.Enabled = True
                Dtp_Fecha_Emision_Hasta.Enabled = True
        End Select


        _Index = Cmb_Fecha_Vencimineto.SelectedValue

        Select Case _Index
            Case 0
                Lbl_FV_hasta.Enabled = False
                Dtp_Fecha_Vencimiento_Desde.Enabled = False
                Dtp_Fecha_Vencimiento_Hasta.Enabled = False
            Case 1, 2, 3
                Lbl_FV_hasta.Enabled = False
                Dtp_Fecha_Vencimiento_Desde.Enabled = True
                Dtp_Fecha_Vencimiento_Hasta.Enabled = False
            Case 4
                Lbl_FV_hasta.Enabled = True
                Dtp_Fecha_Vencimiento_Desde.Enabled = True
                Dtp_Fecha_Vencimiento_Hasta.Enabled = True
        End Select

    End Sub
    Private Sub Txt_Numero_Interno_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Txt_Numero_Interno.KeyDown
        If e.KeyValue = Keys.Enter Then
            Call Btn_Buscar_Click(Nothing, Nothing)
        End If
    End Sub
End Class
