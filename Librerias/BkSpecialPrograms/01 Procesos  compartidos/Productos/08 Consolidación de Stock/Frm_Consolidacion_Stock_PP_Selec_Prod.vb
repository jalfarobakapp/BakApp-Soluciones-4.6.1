Imports DevComponents.DotNetBar

Public Class Frm_Consolidacion_Stock_PP_Selec_Prod

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Productos As DataTable
    Dim _Consolidar As Boolean

    Public ReadOnly Property Pro_Consolidar() As Boolean
        Get
            Return _Consolidar
        End Get
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Aceptar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Consolidacion_Stock_PP_Selec_Prod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dtp_Fecha_Movimientos_Desde.Value = FechaDelServidor()
        Dtp_Fecha_Movimientos_Hasta.Value = Dtp_Fecha_Movimientos_Desde.Value

        AddHandler Rdb_Productos_Todos.CheckedChanged, AddressOf Sb_Enable_Botones
        AddHandler Rdb_Productos_Con_Movimientos.CheckedChanged, AddressOf Sb_Enable_Botones
        AddHandler Rdb_Productos_Seleccionar.CheckedChanged, AddressOf Sb_Enable_Botones

        Sb_Enable_Botones()

    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Dim _Aceptar = False

        If Rdb_Productos_Todos.Checked Then

            Consulta_sql = "Select KOPR AS 'Codigo', NOKOPR AS 'Descripcion' From MAEPR -- Where ATPR = '' And TIPR = 'FPN'"
            _Tbl_Productos = _Sql.Fx_Get_DataTable(Consulta_sql)

        ElseIf Rdb_Productos_Con_Movimientos.Checked Then

            Consulta_sql = "Select KOPR AS 'Codigo', NOKOPR AS 'Descripcion' From MAEPR" & vbCrLf &
                           "Where ATPR = '' And TIPR = 'FPN' And" & Space(1) &
                           "KOPR IN (Select Distinct KOPRCT From MAEDDO" & Space(1) &
                           "Where FEEMLI BETWEEN '" & Format(Dtp_Fecha_Movimientos_Desde.Value, "yyyyMMdd") & "'" & Space(1) &
                           "And '" & Format(Dtp_Fecha_Movimientos_Hasta.Value, "yyyyMMdd") & "')"
            _Tbl_Productos = _Sql.Fx_Get_DataTable(Consulta_sql)

        End If

        If Not (_Tbl_Productos Is Nothing) Then
            If CBool(_Tbl_Productos.Rows.Count) Then
                _Aceptar = True
            End If
        End If

        If _Aceptar Then

            Dim _Consolidado As Boolean
            Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos, "", "Codigo", False, False, "'")

            Dim Fm As New Frm_Consolidacion_Stock_PP(_Filtro_Productos)
            Fm.ShowDialog(Me)
            _Consolidado = Fm.Pro_Consolidacion_terminada
            Fm.Dispose()

            If _Consolidado Then
                Me.Close()
            End If

        Else
            MessageBoxEx.Show(Me, "No exiten datos seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Btn_Seleccionar_Productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Seleccionar_Productos.Click

        Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'FPN'"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Tbl_Productos = _Filtrar.Pro_Tbl_Filtro
            If _Filtrar.Pro_Filtro_Todas Then
                Rdb_Productos_Todos.Checked = True
                _Tbl_Productos = Nothing
            End If

        End If

    End Sub

    Sub Sb_Enable_Botones()

        Lbl_Desde.Enabled = Rdb_Productos_Con_Movimientos.Checked
        Lbl_Hasta.Enabled = Rdb_Productos_Con_Movimientos.Checked
        Dtp_Fecha_Movimientos_Desde.Enabled = Rdb_Productos_Con_Movimientos.Checked
        Dtp_Fecha_Movimientos_Hasta.Enabled = Rdb_Productos_Con_Movimientos.Checked

        Btn_Seleccionar_Productos.Enabled = Rdb_Productos_Seleccionar.Checked

    End Sub

End Class
