Imports DevComponents.DotNetBar

Public Class Frm_Crear_Entidad_Mt_Noficicaiones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Aceptar As Boolean
    Dim _Row_Maeenmail As DataRow

    Public Property Aceptar As Boolean
        Get
            Return _Aceptar
        End Get
        Set(value As Boolean)
            _Aceptar = value
        End Set
    End Property

    Public Sub New(_Row_Maeenmail As DataRow)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Row_Maeenmail = _Row_Maeenmail

        Dim _Koen As String = _Row_Maeenmail.Item("KOEN")
        Dim _Suen As String = _Row_Maeenmail.Item("SUEN")

        Dim _Komail As String = _Row_Maeenmail.Item("KOMAIL")
        Dim _Name_komail As String = _Row_Maeenmail.Item("NAME_KOMAIL")

        Dim _Mailto As String = _Row_Maeenmail.Item("MAILTO").ToString.Trim
        Dim _Nameto As String = _Row_Maeenmail.Item("NAMETO").ToString.Trim
        Dim _Mailcc As String = _Row_Maeenmail.Item("MAILCC").ToString.Trim
        Dim _Namecc As String = _Row_Maeenmail.Item("NAMECC").ToString.Trim
        Dim _Mailcc2 As String = _Row_Maeenmail.Item("MAILCC2").ToString.Trim
        Dim _Namecc2 As String = _Row_Maeenmail.Item("NAMECC2").ToString.Trim
        Dim _Mailbcc As String = _Row_Maeenmail.Item("MAILBCC").ToString.Trim
        Dim _Namebcc As String = _Row_Maeenmail.Item("NAMEBCC").ToString.Trim
        Dim _Mailini As Date = _Row_Maeenmail.Item("MAILINI").ToString.Trim

        Dim _Arr_Tipo(,) As String = {{"", ""},
                             {"001", "Envío de correo con PDF/XML de documentos tributarios electrónicos"},
                             {"004", "Informe de facturas impagas con mas de N días a fecha de emisión"},
                             {"CAM", "Campañas promocionales"},
                             {"ODS", "Envío de notificaciones por ordenes de servicio"}}
        Sb_Llenar_Combos(_Arr_Tipo, Cmb_Komail)
        Cmb_Komail.SelectedValue = _Komail

        caract_combo(Cmb_Suen)
        Consulta_Sql = "Select SUEN As Hijo,SUEN As Padre From MAEEN Where KOEN = '" & _Koen & "'"
        Cmb_Suen.DataSource = _Sql.Fx_Get_Tablas(Consulta_Sql)
        Cmb_Suen.SelectedValue = _Suen

        Txt_Mailto.Text = _Mailto
        Txt_Nameto.Text = _Nameto
        Txt_Mailcc.Text = _Mailcc
        Txt_Namecc.Text = _Namecc
        Txt_Mailcc2.Text = _Mailcc2
        Txt_Namecc2.Text = _Namecc2

        Dtp_Mailini.Value = _Mailini

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Crear_Entidad_Mt_Noficicaiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Agregar_cta_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_cta.Click

        If String.IsNullOrEmpty(Cmb_Komail.SelectedValue) Then

            MessageBoxEx.Show(Me, "Falta el Tipo de notificación", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        If String.IsNullOrEmpty(Txt_Mailto.Text) Then

            MessageBoxEx.Show(Me, "Debe ingresar el Email", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        If Not Fx_Validar_Email(Txt_Mailto.Text) Then
            MessageBoxEx.Show(Me, "El correo para dar aviso al cliente no es una cuenta de correo electrónico valida", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Mailto.Focus()
            Return
        End If

        If Not String.IsNullOrEmpty(Txt_Mailcc.Text) Then
            If Not Fx_Validar_Email(Txt_Mailcc.Text) Then
                MessageBoxEx.Show(Me, "El correo para dar aviso al cliente no es una cuenta de correo electrónico valida", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Mailcc.Focus()
                Return
            End If
        End If

        If Not String.IsNullOrEmpty(Txt_Mailcc2.Text) Then
            If Not Fx_Validar_Email(Txt_Mailcc2.Text) Then
                MessageBoxEx.Show(Me, "El correo para dar aviso al cliente no es una cuenta de correo electrónico valida", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Txt_Mailcc2.Focus()
                Return
            End If
        End If

        _Row_Maeenmail.Item("SUEN") = NuloPorNro(Cmb_Suen.SelectedValue, "")
        _Row_Maeenmail.Item("KOMAIL") = Cmb_Komail.SelectedValue
        _Row_Maeenmail.Item("NAME_KOMAIL") = Cmb_Komail.Text
        _Row_Maeenmail.Item("MAILTO") = Txt_Mailto.Text
        _Row_Maeenmail.Item("NAMETO") = Txt_Nameto.Text
        _Row_Maeenmail.Item("MAILCC") = Txt_Mailcc.Text
        _Row_Maeenmail.Item("NAMECC") = Txt_Namecc.Text
        _Row_Maeenmail.Item("MAILCC2") = Txt_Mailcc2.Text
        _Row_Maeenmail.Item("NAMECC2") = Txt_Namecc2.Text
        '_Row_Maeenmail.Item("MAILBCC") 
        '_Row_Maeenmail.Item("NAMEBCC")
        Dim _Mailini As Date = Dtp_Mailini.Value

        _Aceptar = True
        Me.Close()

    End Sub

End Class
