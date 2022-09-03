'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Remotas_Espera_Permiso_Solicitado

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Permiso As Boolean
    Dim _Cancelar As Boolean

    Dim _CodPermiso, _NroRemota, _CodFuncionario_Solicita As String
    Dim _CodFuncionario_Autoriza As String

    Dim _Row_Usuario_Autoriza As DataRow
    Dim _Row_Usuario_Solicitante As DataRow
    Dim _Row_Info_Respuesta_Remota As DataRow


    Public Property Pro_Permiso() As Boolean
        Get
            Return _Permiso
        End Get
        Set(ByVal value As Boolean)
            _Permiso = value
        End Set
    End Property
    Public Property Pro_Cancelar() As Boolean
        Get
            Return _Cancelar
        End Get
        Set(ByVal value As Boolean)
            _Cancelar = value
        End Set
    End Property

    Public Property Pro_Row_Usuario_Autoriza() As DataRow
        Get
            Return _Row_Usuario_Autoriza
        End Get
        Set(ByVal value As DataRow)
            _Row_Usuario_Autoriza = value
        End Set
    End Property
    Public Property Pro_Row_Usuario_Solicitante() As DataRow
        Get
            Return _Row_Usuario_Solicitante
        End Get
        Set(ByVal value As DataRow)
            _Row_Usuario_Solicitante = value
        End Set
    End Property
    Public Property Pro_Row_Info_Respuesta_Remota() As DataRow
        Get
            Return _Row_Info_Respuesta_Remota
        End Get
        Set(ByVal value As DataRow)
            _Row_Info_Respuesta_Remota = value
        End Set
    End Property

    Public Sub New(ByVal CodPermiso As String, _
                   ByVal NroRemota As String, _
                   Optional ByVal CodFuncionario_Solicita As String = "") ', _
        'Optional ByVal CodEntidad As String = "", _
        'Optional ByVal CodSucEntidad As String = "")

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _CodPermiso = CodPermiso
        _NroRemota = NroRemota

        If String.IsNullOrEmpty(CodFuncionario_Solicita) Then
            _CodFuncionario_Solicita = FUNCIONARIO
        End If

        Consulta_sql = "Select * From TABFU Where KOFU = '" & _CodFuncionario_Solicita & "'"
        _Row_Usuario_Solicitante = _Sql.Fx_Get_DataRow(Consulta_sql)

        Lbl_Nombre_Solicitante.Text = _CodFuncionario_Solicita & " - " & Trim(_Row_Usuario_Solicitante.Item("NOKOFU"))

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Remotas_Espera_Permiso_Solicitado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CircularProgressItem1.IsRunning = True

        Dim _Nombre_Permiso_Solicitado = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_Permisos", _
                                                           "DescripcionPermiso", _
                                                           "CodPermiso = '" & _CodPermiso & "'")

        Lbl_Permiso_Solicitado.Text = _CodPermiso & " - " & Trim(_Nombre_Permiso_Solicitado)
        Timer_respuesta.Enabled = True
        Timer_Revisando_Respuesta.Enabled = True

        Me.Text = "Esperando respuesta remota Nro: " & _NroRemota

    End Sub

    Private Sub Timer_respuesta_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_respuesta.Tick

        If Lbl_Estatus.Visible Then
            Lbl_Estatus.Visible = False
        Else
            Lbl_Estatus.Visible = True
        End If
        Me.Refresh()

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        _Cancelar = True
        Me.Close()
    End Sub

    Private Sub Timer_Revisando_Respuesta_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Revisando_Respuesta.Tick

        Consulta_sql = "Select top 1 * From " & _Global_BaseBk & "Zw_Remotas Where NroRemota = '" & _NroRemota & "' and CodFuncionario_Autoriza <> ''"
        Dim _Tbl_Remota As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl_Remota.Rows.Count) Then

            Timer_Revisando_Respuesta.Enabled = False
            Timer_respuesta.Enabled = False

            _CodFuncionario_Autoriza = _Tbl_Remota.Rows(0).Item("CodFuncionario_Autoriza")
            Dim _Permiso_Otorgado As Boolean = _Tbl_Remota.Rows(0).Item("Permiso_Otorgado")
            Dim _Observaciones As String = _Tbl_Remota.Rows(0).Item("Observaciones")

            If Not String.IsNullOrEmpty(_CodFuncionario_Autoriza) Then

                Consulta_sql = "Select top 1 *  From TABFU Where KOFU = '" & _CodFuncionario_Autoriza & "'"
                Dim _TblUsuario As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                If CBool(_TblUsuario.Rows.Count) Then

                    Dim _Nombre_Autoriza = _TblUsuario.Rows(0).Item("NOKOFU")

                    Lbl_Usuario_Autoriza.Text = _CodFuncionario_Autoriza & " - " & _Nombre_Autoriza

                    _Permiso = _Permiso_Otorgado

                    BtnCancelar.Visible = False
                    Lbl_Estatus.Visible = False
                    CircularProgressItem1.Visible = False

                    If _Permiso_Otorgado Then

                        MessageBoxEx.Show(Me, "La solicitud ha sido aceptada por : " & _Nombre_Autoriza, "PERMISO OTORGADO",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information,
                                          MessageBoxDefaultButton.Button1, True)
                    Else
                        MessageBoxEx.Show(Me, "La solicitud ha sido rechazada por : " & _Nombre_Autoriza & vbCrLf & vbCrLf &
                                          "Motivo rechazo: " & _Observaciones, "PERMISO RECHAZADO",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop,
                                          MessageBoxDefaultButton.Button1, True)

                    End If

                    _Row_Usuario_Autoriza = _TblUsuario.Rows(0)
                    _Row_Info_Respuesta_Remota = _Tbl_Remota.Rows(0)

                Else
                    MessageBoxEx.Show(Me, "El usuario (" & _CodFuncionario_Autoriza & ") no se econtro en la base de datos",
                                      "ERROR INESPERADO, VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Stop,
                                      MessageBoxDefaultButton.Button1, Me.TopMost)

                End If

                Me.Close()

            End If

        End If

    End Sub

    Private Sub Btn_Permiso_Autorizado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Permiso_Autorizado.Click
        Me.Close()
    End Sub

    Private Sub Btn_Permiso_Rechazado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Permiso_Rechazado.Click
        Me.Close()
    End Sub

    Public Property Pro_CodFuncionario_Aprueba() As String
        Get
            Return _CodFuncionario_Autoriza
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Property Pro_Rows_Info_Remota() As DataRow
        Get
            Return _Row_Info_Respuesta_Remota
        End Get
        Set(ByVal value As DataRow)

        End Set
    End Property

    Public Property Pro_Rows_Usuario_Autoriza() As DataRow
        Get
            Return _Row_Usuario_Autoriza
        End Get
        Set(ByVal value As DataRow)

        End Set
    End Property

End Class
