Imports DevComponents.DotNetBar

Public Class Frm_Stmp_ConfLocal

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Stmp_ConfLocal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Parametros_Informe_Sql(False)

    End Sub

    Sub Sb_Parametros_Informe_Sql(_Actualizar As Boolean)

        _Sql.Sb_Parametro_Informe_Sql(Chk_ImprimirTicket, "ConfLocal_Sgem",
                                      Chk_ImprimirTicket.Name, Class_SQLite.Enum_Type._Boolean, Chk_ImprimirTicket.Checked, _Actualizar)

        _Sql.Sb_Parametro_Informe_Sql(Txt_NombreEquipoImprime_Ticket, "ConfLocal_Sgem",
                                      Txt_NombreEquipoImprime_Ticket.Name, Class_SQLite.Enum_Type._String, Txt_NombreEquipoImprime_Ticket.Text, _Actualizar)

        _Sql.Sb_Parametro_Informe_Sql(Txt_Impresora_Ticket, "ConfLocal_Sgem",
                                      Txt_Impresora_Ticket.Name, Class_SQLite.Enum_Type._String, Txt_Impresora_Ticket.Text, _Actualizar)

        _Sql.Sb_Parametro_Informe_Sql(Txt_NombreFormato_Ticket, "ConfLocal_Sgem",
                                      Txt_NombreFormato_Ticket.Name, Class_SQLite.Enum_Type._String, Txt_NombreFormato_Ticket.Text, _Actualizar)


    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If Chk_ImprimirTicket.Checked Then
            If String.IsNullOrWhiteSpace(Txt_NombreEquipoImprime_Ticket.Text.Trim) Then
                MessageBoxEx.Show(Me, "Falta el nombre del equipo que imprime los ticket",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_NombreEquipoImprime_Ticket.Focus()
                Return
            End If
            If String.IsNullOrWhiteSpace(Txt_Impresora_Ticket.Text.Trim) Then
                MessageBoxEx.Show(Me, "Falta el nombre de la impresora para imprimir los ticket",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Impresora_Ticket.Focus()
                Return
            End If
            If String.IsNullOrWhiteSpace(Txt_NombreFormato_Ticket.Text.Trim) Then
                MessageBoxEx.Show(Me, "Falta el nombre del formato de los ticket",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_NombreFormato_Ticket.Focus()
                Return
            End If
        End If

        Sb_Parametros_Informe_Sql(True)

        MessageBoxEx.Show(Me, "Configuración grabada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()

    End Sub


    Private Sub Txt_NombreEquipoImprime_Ticket_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_NombreEquipoImprime_Ticket.ButtonCustomClick

        If String.IsNullOrWhiteSpace(Cadena_ConexionSQL_Server) Then
            MessageBoxEx.Show(Me, "Faltan los datos de conexión a la base de datos de Random", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "DESDE DONDE SE IMPRIMIRAN LOS TICKET (Solo estaciones con Diablito)"

        _Filtrar.Tabla = _Global_BaseBk & "Zw_EstacionesBkp"
        _Filtrar.Campo = "NombreEquipo"
        _Filtrar.Descripcion = "Alias"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And NombreEquipo In (Select Distinct NombreEquipo From " & _Global_BaseBk & "Zw_Estaciones_Impresoras)",
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_NombreEquipoImprime_Ticket.Text = _Codigo

        End If

    End Sub

    Private Sub Txt_NombreEquipoImprime_Ticket_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_NombreEquipoImprime_Ticket.ButtonCustom2Click
        Txt_NombreEquipoImprime_Ticket.Tag = String.Empty
        Txt_NombreEquipoImprime_Ticket.Text = String.Empty
    End Sub

    Private Sub Txt_Impresora_Ticket_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Impresora_Ticket.ButtonCustomClick

        If String.IsNullOrWhiteSpace(Cadena_ConexionSQL_Server) Then
            MessageBoxEx.Show(Me, "Faltan los datos de conexión a la base de datos de Random", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "IMPRESORAS DISPONIBLES"

        _Filtrar.Tabla = _Global_BaseBk & "Zw_Estaciones_Impresoras"
        _Filtrar.Campo = "Impresora"
        _Filtrar.Descripcion = "Impresora"
        _Filtrar.Ver_Codigo = False

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Otra,
                               "And NombreEquipo = '" & Txt_NombreEquipoImprime_Ticket.Text & "'",
                               Nothing, False, True) Then

            Dim _Row As DataRow = _Filtrar.Pro_Tbl_Filtro.Rows(0)

            Dim _Codigo = _Row.Item("Codigo").ToString.Trim
            Dim _Descripcion = _Row.Item("Descripcion").ToString.Trim

            Txt_Impresora_Ticket.Tag = _Codigo
            Txt_Impresora_Ticket.Text = _Descripcion

        End If

    End Sub

    Private Sub Txt_Impresora_Ticket_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Impresora_Ticket.ButtonCustom2Click, Txt_NombreFormato_Ticket.ButtonCustom2Click
        Txt_Impresora_Ticket.Tag = String.Empty
        Txt_Impresora_Ticket.Text = String.Empty
    End Sub

    Private Sub Txt_NombreFormato_Ticket_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_NombreFormato_Ticket.ButtonCustomClick

        If String.IsNullOrWhiteSpace(Cadena_ConexionSQL_Server) Then
            MessageBoxEx.Show(Me, "Faltan los datos de conexión a la base de datos de Random", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim Fm As New Frm_Seleccionar_Formato("NVV")
        Fm.ShowDialog(Me)
        If Fm.Formato_Seleccionado Then
            Txt_NombreFormato_Ticket.Tag = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
            Txt_NombreFormato_Ticket.Text = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
        End If
        Fm.Dispose()

    End Sub

    Private Sub Txt_NombreFormato_Ticket_ButtonCustom2Click(sender As Object, e As EventArgs)
        Txt_NombreFormato_Ticket.Tag = String.Empty
        Txt_NombreFormato_Ticket.Text = String.Empty
    End Sub


End Class
