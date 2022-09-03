Imports DevComponents.DotNetBar

Public Class Frm_Ver_Documento_Observaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Maeedo As DataRow
    Dim _Row_Maeedoob As DataRow

    Dim _Doc_Random As Boolean
    Dim _Grabar As Boolean

    Dim _Class_Referencias_DTE As Class_Referencias_DTE

    Public Property Pro_Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Pro_Class_Referencias_DTE As Class_Referencias_DTE
        Get
            Return _Class_Referencias_DTE
        End Get
        Set(value As Class_Referencias_DTE)
            _Class_Referencias_DTE = value
        End Set
    End Property

    Public Sub New(Row_Maeedo As DataRow, Row_Maeedoob As DataRow, Doc_Random As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Row_Maeedo = Row_Maeedo
        _Row_Maeedoob = Row_Maeedoob
        _Doc_Random = Doc_Random

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_DocumentoTraza_Observaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If _Doc_Random Then
            Sb_Observaciones_Doc_Random()
        Else
            Sb_Observaciones_Doc_Bakapp()
        End If

    End Sub

    Sub Sb_Observaciones_Doc_Random()

        Dim _Feemdo As Date = NuloPorNro(_Row_Maeedo.Item("FEEMDO"), Nothing)
        Dim _Feer As Date = NuloPorNro(_Row_Maeedo.Item("FEER"), _Feemdo)

        Dim _Obdo As String = Trim(NuloPorNro(_Row_Maeedoob.Item("OBDO"), ""))
        Dim _Cpdo As String = Trim(NuloPorNro(_Row_Maeedoob.Item("CPDO"), ""))
        Dim _Ocdo As String = Trim(NuloPorNro(_Row_Maeedoob.Item("OCDO"), ""))

        ' Retirador de mercaderia
        Dim _Koreti As String = NuloPorNro(_Row_Maeedoob.Item("DIENDESP"), "")
        Dim _Nokoreti As String

        If Not String.IsNullOrEmpty(_Koreti) Then _Nokoreti = _Sql.Fx_Trae_Dato("TABRETI", "NORETI", "KORETI Like '" & _Koreti & "%'").ToString.Trim

        Dim _Placapat As String = Trim(NuloPorNro(_Row_Maeedoob.Item("PLACAPAT"), ""))
        Dim _Motivo As String = Trim(NuloPorNro(_Row_Maeedoob.Item("MOTIVO"), ""))

        Dtp_Fecha_Entrega_Recepcion.Value = _Feer
        Txt_Observaciones.Text = _Obdo
        Txt_Forma_de_pago.Text = _Cpdo
        Txt_Orden_de_compra.Text = _Ocdo

        If Not String.IsNullOrEmpty(_Koreti) Then Txt_Retirador_Mercaderia.Text = _Koreti & ": " & _Nokoreti
        Txt_Placa_Patente.Text = _Placapat

        Txt_Motivo.Text = _Motivo

        Dim _Tido As String = _Row_Maeedo.Item("TIDO")
        Dim _Nudo As String = _Row_Maeedo.Item("NUDO")

        Me.Text = "Observaciones " & _Tido & "-" & _Nudo

        If _Tido = "NVV" Then
            Btn_Editar_Fecha.Visible = True
        Else
            Btn_Editar_Fecha.Visible = False
        End If

        Btn_Editar_Fecha.Enabled = False

        Dim _Esdo As String = _Row_Maeedo.Item("ESDO")

        Btn_Editar_Observaciones.Enabled = Not (_Esdo = "N")

    End Sub

    Sub Sb_Observaciones_Doc_Bakapp()

        Dim _Feemdo As Date = _Row_Maeedo.Item("FechaEmision")
        Dim _Feer As Date = NuloPorNro(_Row_Maeedo.Item("FechaRecepcion"), _Feemdo)

        Dim _Obdo As String = Trim(NuloPorNro(_Row_Maeedoob.Item("Observaciones"), ""))
        Dim _Cpdo As String = Trim(NuloPorNro(_Row_Maeedoob.Item("Forma_pago"), ""))
        Dim _Ocdo As String = Trim(NuloPorNro(_Row_Maeedoob.Item("Orden_compra"), ""))

        ' Retirador de mercaderia

        Dtp_Fecha_Entrega_Recepcion.Value = _Feer
        Txt_Observaciones.Text = _Obdo
        Txt_Forma_de_pago.Text = _Cpdo
        Txt_Orden_de_compra.Text = _Ocdo

        Txt_Retirador_Mercaderia.Visible = False '.Text = _Koreti & ": " & _Nokoreti
        Txt_Placa_Patente.Visible = False '.Text = _Placapat

        Txt_Motivo.Visible = False '.Text = _Motivo

        Dim _Tido As String = _Row_Maeedo.Item("TipoDoc")
        Dim _Nudo As String = _Row_Maeedo.Item("NroDocumento")

        Me.Text = "Observaciones " & _Tido & "-" & _Nudo

        Btn_Editar_Fecha.Visible = False
        Btn_Editar_Observaciones.Enabled = False
        Btn_Grabar.Visible = False
        Btn_Referencias_DTE.Visible = False

    End Sub

    Private Sub Btn_Observaciones_adicionales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Observaciones_adicionales.Click

        Dim _Esdo As String '= _Row_Maeedo.Item("ESDO")
        Dim _Tido As String
        Dim _Nudo As String

        If _Doc_Random Then
            _Tido = _Row_Maeedo.Item("TIDO")
            _Nudo = _Row_Maeedo.Item("NUDO")
            _Esdo = _Row_Maeedo.Item("ESTADO")
        Else
            _Tido = _Row_Maeedo.Item("TipoDoc")
            _Nudo = _Row_Maeedo.Item("NroDocumento")
        End If

        Dim Fm As New Frm_Ver_Documento_Observaciones_Textos_Adicionales(_Row_Maeedoob, _Doc_Random) ' (_Idmaeedo)

        Fm.Text = "Observaciones adicionales " & _Tido & "-" & _Nudo
        Fm.Btn_Editar_Observaciones.Visible = Btn_Editar_Observaciones.Visible
        Fm.Btn_Editar_Observaciones.Enabled = Not (_Esdo = "N")
        Fm.ShowDialog(Me)

        If Fm.Pro_Grabar Then
            ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.save,
                                  1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
        End If

        Fm.Dispose()

    End Sub

    Private Sub Frm_DocumentoTraza_Observaciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Editar_Observaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar_Observaciones.Click

        If Fx_Tiene_Permiso(Me, "Doc00007") Then

            Dim _Idmaeedo As Integer = _Row_Maeedo.Item("IDMAEEDO")

            If CBool(_Id_Log_Gestion) Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Log_Gestiones Set Archirst = 'MAEEDO',Idrst = " & _Idmaeedo & vbCrLf &
                               "Where Id = " & _Id_Log_Gestion
                _Sql.Ej_consulta_IDU(Consulta_sql)
                _Id_Log_Gestion = 0
            End If

            Dim _Esdo As Boolean = String.IsNullOrEmpty(Trim(_Row_Maeedo.Item("ESDO")))

            Btn_Grabar.Visible = True
            Btn_Editar_Observaciones.Visible = False

            Txt_Observaciones.ReadOnly = False
            Txt_Forma_de_pago.ReadOnly = False
            Txt_Orden_de_compra.ReadOnly = False

            Txt_Observaciones.Enabled = True
            Txt_Forma_de_pago.Enabled = True
            Txt_Orden_de_compra.Enabled = True

            If _Row_Maeedo.Item("TIDO") = "NVV" Then
                If _Esdo Then
                    If Btn_Editar_Fecha.Visible Then
                        _Esdo = False
                    End If
                End If
            End If

            Btn_Editar_Fecha.Enabled = True
            Dtp_Fecha_Entrega_Recepcion.Enabled = _Esdo

            ToastNotification.Show(Me, "AHORA ES POSIBLE EDITAR LAS OBSERVACIONES", My.Resources.ok_button,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            Txt_Observaciones.Focus()


            Me.Refresh()

        End If

    End Sub

    Private Sub Btn_Editar_Fecha_Click(sender As Object, e As EventArgs) Handles Btn_Editar_Fecha.Click
        Dtp_Fecha_Entrega_Recepcion.Enabled = Fx_Tiene_Permiso(Me, "Bkp00057")
    End Sub

    Private Sub Btn_Referencias_DTE_Click(sender As Object, e As EventArgs) Handles Btn_Referencias_DTE.Click

        Dim _Idmaeedo As Integer = _Row_Maeedo.Item("IDMAEEDO")

        Dim _Tido = _Row_Maeedo.Item("TIDO")
        Dim _Habilita_CodRef = (_Tido = "NCV")

        Dim Fm As New Frm_Referencia_DTE_Enc(_Idmaeedo, _Habilita_CodRef)
        Fm.Class_Referencias_DTE = _Class_Referencias_DTE
        Fm.ShowDialog(Me)
        _Class_Referencias_DTE = Fm.Class_Referencias_DTE
        Fm.Dispose()

    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        Dim _Feer As String = Format(Dtp_Fecha_Entrega_Recepcion.Value, "yyyyMMdd")
        Dim _Esdo As Boolean = String.IsNullOrEmpty(Trim(_Row_Maeedo.Item("ESDO")))

        Dim _Idmaeedo As Integer = _Row_Maeedo.Item("IDMAEEDO")

        Dim _Sql_Cambiar_Feerli = String.Empty

        Dim _Feemdo As Date = FormatDateTime(_Row_Maeedo.Item("FEEMDO"), DateFormat.ShortDate)
        Dim _Fecha_Recepcion As Date = FormatDateTime(Dtp_Fecha_Entrega_Recepcion.Value, DateFormat.ShortDate)


        If _Fecha_Recepcion < _Feemdo Then
            MessageBoxEx.Show(Me, "La fecha de despacho/recepción no puede ser menor que la fecha de emisión del documento",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Dtp_Fecha_Entrega_Recepcion.Value = _Row_Maeedo.Item("FEER")
            Return
        End If

        If _Esdo Then

            Dim _Consulta = MessageBoxEx.Show(Me, "¿Desea cambiar la fecha de recepción en las filas igualmente?", "Grabar",
                                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)


            If _Consulta = Windows.Forms.DialogResult.Yes Then

                _Sql_Cambiar_Feerli = "Update MAEDDO Set FEERLI = '" & _Feer & "' Where IDMAEEDO = " & _Idmaeedo & vbCrLf

            ElseIf _Consulta = Windows.Forms.DialogResult.No Then

                MessageBoxEx.Show(Me, "La fecha solo se cambiara en el documento", "Acción",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Else
                Return
            End If

        End If


        Consulta_sql = "Update MAEEDO Set FEER = '" & _Feer & "'" & Space(1) &
                       "Where IDMAEEDO = " & _Idmaeedo & vbCrLf &
                       _Sql_Cambiar_Feerli & vbCrLf &
                       "Update MAEEDOOB Set" & Space(1) &
                       "OBDO = '" & Trim(Txt_Observaciones.Text) &
                       "',CPDO = '" & Trim(Txt_Forma_de_pago.Text) &
                       "',OCDO = '" & Txt_Orden_de_compra.Text & "'" & vbCrLf &
                       "Where IDMAEEDO = " & _Idmaeedo

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            _Row_Maeedo.Item("FEER") = Dtp_Fecha_Entrega_Recepcion.Value
            _Grabar = True
            Me.Close()
        End If

    End Sub

End Class
