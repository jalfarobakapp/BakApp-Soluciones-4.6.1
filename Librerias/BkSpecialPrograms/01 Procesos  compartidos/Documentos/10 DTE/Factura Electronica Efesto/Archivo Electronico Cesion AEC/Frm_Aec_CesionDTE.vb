Imports DevComponents.DotNetBar
Imports HEFESTO.FIRMA.DOC.FORM

Public Class Frm_Aec_CesionDTE

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _RowDocumento As DataRow
    Dim _RutCesionario As String
    Dim _RazonSocialCesionario As String
    Dim _DireccionCesionario As String
    Dim _eMailCesionario As String
    Dim _RutAutoriza As String
    Dim _NombreAutoriza As String
    Dim _Id_Dte As Integer

    Public Property Id_Aec As Integer

    Public Sub New(_Id_Dte As Integer, _Idmaeedo As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
        _RowDocumento = _Sql.Fx_Get_DataRow(Consulta_sql)

        Me._Id_Dte = _Id_Dte

    End Sub

    Private Sub Frm_Aec_CesionDTE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lbl_Documento.Text = _RowDocumento.Item("TIDO") & "-" & _RowDocumento.Item("NUDO")
        Lbl_RazonSocialCedente.Text = RazonEmpresa
        Lbl_RutCedente.Text = RutEmpresaActiva
        Lbl_DireccionCedente.Text = DireccionEmpresa

    End Sub

    Private Sub Txt_FuncionarioAutorizado_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_FuncionarioAutorizado.ButtonCustomClick

        Dim Fm As New Frm_Filtro_Especial_Informes(Nothing)
        Fm.Pro_Seleccionar_Solo_Uno = True
        'Fm.Pro_Tbl_Filtro = _Tbl_Filtro
        'Fm.Pro_Sql_Filtro_Condicion_Extra = _Sql_Filtro_Condicion_Extra
        Fm.ShowDialog(Me)

        If Fm.Pro_Filtrar Then

            Consulta_sql = "Select * From TABFU Where KOFU = '" & Fm.Pro_Tbl_Filtro.Rows(0).Item("Codigo") & "'"
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            _RutAutoriza = Replace(_Row.Item("RTFU").ToString.Trim, ".", "")

            If Not VerificaDigito(_RutAutoriza) Then
                Txt_FuncionarioAutorizado.Text = String.Empty
                _RutAutoriza = String.Empty
                _NombreAutoriza = String.Empty
                MessageBoxEx.Show(Me, "Rut del funcionario invalido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_FuncionarioAutorizado.Focus()
                Return
            End If

            Txt_FuncionarioAutorizado.Text = _Row.Item("RTFU").ToString.Trim & "-" & _Row.Item("NOKOFU").ToString.Trim
            _RutAutoriza = _Row.Item("RTFU").ToString.Trim
            _NombreAutoriza = _Row.Item("NOKOFU").ToString.Trim
            Txt_NmbContacto.Focus()

        End If


    End Sub

    Private Sub Txt_Cesionario_Entidad_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Cesionario_Entidad.ButtonCustomClick

        Dim Fm As New Frm_BuscarEntidad_Mt(False)
        Fm.Rdb_Clientes.Checked = True
        Fm.ShowDialog(Me)
        Dim _RowEntidad = Fm.Pro_RowEntidad

        Fm.Dispose()

        If Not IsNothing(_RowEntidad) Then

            Txt_Cesionario_Entidad.Text = _RowEntidad.Item("Rut") & "-" & _RowEntidad.Item("NOKOEN").ToString.Trim
            Txt_Cesionario_Entidad.Tag = Replace(_RowEntidad.Item("Rut"), ".", "")
            Txt_Cesionario_Direccion.Text = _RowEntidad.Item("DIEN").ToString.Trim
            _RutCesionario = Txt_Cesionario_Entidad.Tag
            _RazonSocialCesionario = _RowEntidad.Item("NOKOEN").ToString.Trim
            _DireccionCesionario = _RowEntidad.Item("DIEN").ToString.Trim
            ' Txt_FonoContacto.Text = _RowEntidad.Item("FOEN").ToString.Trim
            Txt_Cesionario_Email.Text = String.Empty
            Txt_Cesionario_Email.Focus()

        End If

    End Sub

    Private Sub Btn_Grabar_Cesion_Click(sender As Object, e As EventArgs) Handles Btn_Grabar_Cesion.Click

        If String.IsNullOrEmpty(Txt_FuncionarioAutorizado.Text) Then
            MessageBoxEx.Show(Me, "Falta el funcionario autorizado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
            Txt_FuncionarioAutorizado.Focus()
        End If

        If String.IsNullOrEmpty(Txt_NmbContacto.Text) Then
            MessageBoxEx.Show(Me, "Falta el nombre del contacto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_NmbContacto.Focus()
            Return
        End If

        If Not Fx_Validar_Email(Txt_MailContacto.Text) Then
            MessageBoxEx.Show(Me, "Mail contacto invalido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_MailContacto.Focus()
            Return
        End If

        'If String.IsNullOrEmpty(Txt_MailContacto.Text) Then
        '    MessageBoxEx.Show(Me, "Falta el email del contacto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Txt_MailContacto.Focus()
        '    Return
        'End If

        If String.IsNullOrEmpty(Txt_FonoContacto.Text) Then
            MessageBoxEx.Show(Me, "Falta el teléfono del contacto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_FonoContacto.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Cesionario_Entidad.Text) Then
            MessageBoxEx.Show(Me, "Falta la entidad del cesionario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Cesionario_Entidad.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Cesionario_Direccion.Text) Then
            MessageBoxEx.Show(Me, "Falta la dirección del cesionario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Cesionario_Direccion.Focus()
            Return
        End If

        'If String.IsNullOrEmpty(Txt_Cesionario_Email.Text) Then
        '    MessageBoxEx.Show(Me, "Falta el email del cesionario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Txt_Cesionario_Email.Focus()
        '    Return
        'End If

        If Not Fx_Validar_Email(Txt_Cesionario_Email.Text) Then
            MessageBoxEx.Show(Me, "Mail cesionario invalido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Cesionario_Email.Focus()
            Return
        End If

        Dim _Class_DTE As New Class_Genera_DTE_RdBk(_RowDocumento.Item("IDMAEEDO"))

        Dim _RutCesionario = Me._RutCesionario
        Dim _RazonSocialCesionario = Me._RazonSocialCesionario
        Dim _DireccionCesionario = Me._DireccionCesionario
        Dim _eMailCesionario = Txt_Cesionario_Email.Text.Trim
        Dim _NmbContacto = Txt_NmbContacto.Text
        Dim _FonoContacto = Txt_FonoContacto.Text
        Dim _MailContacto = Txt_MailContacto.Text
        Dim _RutAutoriza = Me._RutAutoriza
        Dim _NombreAutoriza = Me._NombreAutoriza
        Dim _eMailCedente = Txt_MailContacto.Text

        Fx_Caracter_Raro_Quitar(_RazonSocialCesionario)
        Fx_Caracter_Raro_Quitar(_DireccionCesionario)
        Fx_Caracter_Raro_Quitar(_NmbContacto)
        Fx_Caracter_Raro_Quitar(_NombreAutoriza)

        _Id_Aec = 0

        _Id_Aec = _Class_DTE.Fx_AEC_CrearCesion(_Id_Dte,
                                                _RutCesionario,
                                                _RazonSocialCesionario,
                                                _DireccionCesionario,
                                                _eMailCesionario,
                                                _NmbContacto,
                                                _FonoContacto,
                                                _MailContacto,
                                                _RutAutoriza,
                                                _NombreAutoriza,
                                                _eMailCedente)

        If CBool(_Id_Aec) Then
            Me.Close()
        Else
            Dim _MsgList As String

            For Each _Msg As String In _Class_DTE.Pro_Errores
                _MsgList += _Msg & vbCrLf
            Next

            MessageBoxEx.Show(Me, _MsgList, "Errores", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Txt_FuncionarioAutorizado_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_FuncionarioAutorizado.ButtonCustom2Click

        _NombreAutoriza = String.Empty
        _RutAutoriza = String.Empty
        Txt_FuncionarioAutorizado.Text = String.Empty

    End Sub

    Private Sub Txt_FuncionarioAutorizado_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_FuncionarioAutorizado.KeyDown
        If String.IsNullOrEmpty(Txt_FuncionarioAutorizado.Text) Then
            Call Txt_FuncionarioAutorizado_ButtonCustomClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub Txt_Cesionario_Entidad_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Cesionario_Entidad.KeyDown
        If String.IsNullOrEmpty(Txt_Cesionario_Entidad.Text) Then
            Call Txt_Cesionario_Entidad_ButtonCustomClick(Nothing, Nothing)
        End If
    End Sub
End Class
