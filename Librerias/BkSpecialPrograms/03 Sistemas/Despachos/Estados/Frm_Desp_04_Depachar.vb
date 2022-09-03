Imports DevComponents.DotNetBar

Public Class Frm_Desp_04_Depachar

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Despachado As Boolean
    Dim _Cerrado As Boolean
    Dim _Cl_Despacho As Clas_Despacho

    Dim _Row_Despacho As DataRow
    Dim _Tipo_Envio As String


    Dim _Tbl_Lector_Prod_Despachados As DataTable

    Public Property Despachado As Boolean
        Get
            Return _Despachado
        End Get
        Set(value As Boolean)
            _Despachado = value
        End Set
    End Property

    Public Property Despachos As Clas_Despacho
        Get
            Return _Cl_Despacho
        End Get
        Set(value As Clas_Despacho)
            _Cl_Despacho = value
        End Set
    End Property

    Public Property Cerrado As Boolean
        Get
            Return _Cerrado
        End Get
        Set(value As Boolean)
            _Cerrado = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Desp_04_Depachar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Row_Despacho = _Cl_Despacho.Tbl_Despacho.Rows(0)

        caract_combo(Cmb_Tipo_Entrega)
        Cmb_Tipo_Entrega.DataSource = _Cl_Despacho.Fx_Tbl_Tipo_Entrega(True)
        Cmb_Tipo_Entrega.SelectedValue = String.Empty '_Cl_Despacho.Tbl_Despacho.Rows(0).Item("Tipo_Entrega")

        Txt_Nombre_Transpor.Tag = String.Empty
        Txt_Entregado_Por.Tag = String.Empty

        Btn_CodFuncionario_Transpor.Enabled = False

        _Cl_Despacho.Fx_Tomar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO)

    End Sub

    Private Sub Frm_Desp_04_Depachar_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Despachar_Click(sender As Object, e As EventArgs) Handles Btn_Despachar.Click

        Dim _Tipo_Entrega = Cmb_Tipo_Entrega.SelectedValue

        If String.IsNullOrEmpty(_Tipo_Entrega) Then
            MessageBoxEx.Show(Me, "Debe indicar el tipo de entrega", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrEmpty(Txt_Entregado_Por.Tag.ToString.Trim) Then

            MessageBoxEx.Show(Me, "Falta el nombre del funcionario que entrega el o los bultos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            If _Tipo_Entrega = "FUN" Then
                Call Btn_Entregado_Por_Click(Nothing, Nothing)
            Else
                Txt_Nombre_Transpor.Focus()
            End If

            Return

        End If

        If String.IsNullOrEmpty(Txt_Nombre_Transpor.Text.ToString.Trim) Then

            Dim _Msg As String

            Select Case _Tipo_Entrega
                Case "FUN"
                    _Msg = "Falta el nombre del funcionario que lleva los bultos"
                Case "TRA"
                    _Msg = "Falta el nombre del transportista que se leva los bultos"
                Case "CLI"
                    _Msg = "Falta el nombre del cliente que retira"
            End Select

            MessageBoxEx.Show(Me, _Msg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            If _Tipo_Envio = "TRA" Then
                Call Btn_Entregado_Por_Click(Nothing, Nothing)
            Else
                Txt_Nombre_Transpor.Focus()
            End If
            Return

        End If

        Dim _Nro_Encomienda As String = String.Empty
        Dim _Transportista = _Row_Despacho.Item("Transportista").ToString.Trim

        If _Tipo_Entrega = "TRA" Then

            If _Transportista = "CHILEXPRESS" Then

                Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Chilexpress_Env Where IdDespacho = " & _Row_Despacho.Item("Id_Despacho")
                Dim _Row_Chilexpress As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                If Not IsNothing(_Row_Chilexpress) Then

                    Dim _Estatusenvio = _Row_Chilexpress.Item("Estatusenvio")
                    _Nro_Encomienda = _Row_Chilexpress.Item("Nro_Encomienda").ToString.Trim

                    If _Estatusenvio = "ENVIADO" Then
                        _Nro_Encomienda = _Nro_Encomienda
                    End If
                End If

            End If

            If String.IsNullOrEmpty(_Nro_Encomienda) Then
                Dim _Aceptar As Boolean = InputBox_Bk(Me, "DEBE INGRESAR EL NUMERO DE LA ENCOMIENDA",
                                                      "Nro. Encomienda", _Nro_Encomienda, False,, 30, True, _Tipo_Imagen.Texto)

                If Not _Aceptar Then
                    Return
                End If
            End If

        End If

        _Tipo_Envio = _Row_Despacho.Item("Tipo_Envio")

        If ((_Tipo_Envio = "RT" Or _Tipo_Envio = "RR") And _Tipo_Entrega <> "CLI") Or ((_Tipo_Envio = "DD" Or _Tipo_Envio = "AG") And _Tipo_Entrega = "CLI") Then

            If Not Fx_Tiene_Permiso(Me, "ODp00014") Then
                Return
            End If

        End If

        _Row_Despacho.Item("Tipo_Entrega") = Cmb_Tipo_Entrega.SelectedValue
        _Row_Despacho.Item("CodFuncionario_Transpor") = Txt_Nombre_Transpor.Tag
        _Row_Despacho.Item("Entregado_Por") = Txt_Entregado_Por.Tag
        _Row_Despacho.Item("Nombre_Transpor") = Txt_Nombre_Transpor.Text.Trim
        _Row_Despacho.Item("Nro_Encomienda") = _Nro_Encomienda 'Txt_Nro_Encomienda.Text.Trim

        _Despachado = _Cl_Despacho.Fx_Accion_Despachado(Txt_Observaciones.Text)

        If _Despachado Then

            Select Case _Tipo_Envio

                Case "RT", "RR"

                    _Cerrado = True

                Case "DD", "AG"

                    If Not String.IsNullOrEmpty(_Nro_Encomienda) Then

                        _Cerrado = True

                        MessageBoxEx.Show(Me, "Orden de despacho cerrada" & vbCrLf &
                                          "Transportista: " & _Transportista & ", Nro. Encomienda: " & _Nro_Encomienda, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

            End Select

            Me.Close()

        Else
            MessageBoxEx.Show(Me, _Cl_Despacho.Error, "Problemas!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Cmb_Tipo_Entrega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Tipo_Entrega.SelectedIndexChanged

        _Tipo_Envio = _Row_Despacho.Item("Tipo_Envio")
        Dim _Tipo_Entrega = Cmb_Tipo_Entrega.SelectedValue

        Txt_Entregado_Por.Tag = String.Empty
        Txt_Entregado_Por.Text = String.Empty

        Select Case _Tipo_Entrega
            Case "CLI"
                Lbl_Link_Nombre_Transpor.Text = "Nombre cliente"
                Txt_Nombre_Transpor.Tag = "@cl"
                Txt_Nombre_Transpor.Text = String.Empty
                Btn_CodFuncionario_Transpor.Enabled = False

                Txt_Nombre_Transpor.ReadOnly = False
                Txt_Nombre_Transpor.Enabled = True
                Txt_Observaciones.Enabled = True
                Btn_Entregado_Por.Enabled = True
                Txt_Nombre_Transpor.Focus()
            Case "TRA"
                Lbl_Link_Nombre_Transpor.Text = "Nombre transportista"
                Txt_Nombre_Transpor.Tag = "@tr"
                Txt_Nombre_Transpor.Text = String.Empty
                Btn_CodFuncionario_Transpor.Enabled = False

                Txt_Nombre_Transpor.ReadOnly = False
                Txt_Nombre_Transpor.Enabled = True
                Txt_Observaciones.Enabled = True
                Btn_Entregado_Por.Enabled = True
                Txt_Nombre_Transpor.Focus()
            Case "FUN"
                Lbl_Link_Nombre_Transpor.Text = "Nombre transportista"
                Btn_CodFuncionario_Transpor.Enabled = True
                Txt_Nombre_Transpor.ReadOnly = True

                Txt_Observaciones.Enabled = True
                Btn_Entregado_Por.Enabled = True
                Call Btn_CodFuncionario_Transpor_Click(Nothing, Nothing)
            Case Else
                Lbl_Link_Nombre_Transpor.Text = "..."
                Txt_Nombre_Transpor.Tag = String.Empty
                Txt_Nombre_Transpor.Text = String.Empty
                Txt_Nombre_Transpor.Enabled = False
                Btn_CodFuncionario_Transpor.Enabled = False
                Btn_Entregado_Por.Enabled = False

                Txt_Observaciones.Enabled = False
        End Select

    End Sub

    Private Sub Btn_CodFuncionario_Transpor_Click(sender As Object, e As EventArgs) Handles Btn_CodFuncionario_Transpor.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "FUNCIONARIO DE LA EMPRESA QUE TRANSPORTA LOS BULTOS"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, "",
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            Dim _Kofu = _Row.Item("Codigo").ToString.Trim
            Dim _Nokofu = _Row.Item("Descripcion").ToString.Trim

            Txt_Nombre_Transpor.Tag = _Kofu
            Txt_Nombre_Transpor.Text = _Nokofu

            If String.IsNullOrEmpty(Txt_Entregado_Por.Text.Trim) Then
                Call Btn_Entregado_Por_Click(Nothing, Nothing)
            End If

        End If

    End Sub

    Private Sub Btn_Entregado_Por_Click(sender As Object, e As EventArgs) Handles Btn_Entregado_Por.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        _Filtrar.Pro_Nombre_Encabezado_Informe = "FUNCIONARIO DE LA EMPRESA QUE ENTREGA LOS BULTOS"

        If _Filtrar.Fx_Filtrar(Nothing,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Funcionarios_Random, "",
                               Nothing, False, True) Then

            Dim _Tbl_Transportista As DataTable = _Filtrar.Pro_Tbl_Filtro

            Dim _Row As DataRow = _Tbl_Transportista.Rows(0)

            Dim _Kofu = _Row.Item("Codigo").ToString.Trim
            Dim _Nokofu = _Row.Item("Descripcion").ToString.Trim

            Txt_Entregado_Por.Tag = _Kofu
            Txt_Entregado_Por.Text = _Nokofu

            Dim _Tipo_Entrega = Cmb_Tipo_Entrega.SelectedValue

            Txt_Observaciones.Focus()

        End If

    End Sub

    Private Sub Txt_Nombre_Transpor_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Nombre_Transpor.KeyDown
        If e.KeyValue = Keys.Enter Then
            Dim _Tipo_Entrega = Cmb_Tipo_Entrega.SelectedValue
            If _Tipo_Entrega = "FUN" Then
                Call Btn_CodFuncionario_Transpor_Click(Nothing, Nothing)
            Else
                If Not String.IsNullOrEmpty(Txt_Nombre_Transpor.Text.Trim) Then
                    Call Btn_Entregado_Por_Click(Nothing, Nothing)
                    'Txt_Observaciones.Focus()
                Else
                    MessageBoxEx.Show(Me, "Debe ingresar el nombre del retirador", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If
        End If
    End Sub

    Private Sub Txt_Entregado_Por_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Entregado_Por.KeyDown
        If e.KeyValue = Keys.Enter Then
            Call Btn_Entregado_Por_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Frm_Desp_04_Depachar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _Cl_Despacho.Fx_Soltar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO)
    End Sub
End Class
