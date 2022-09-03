Imports DevComponents.DotNetBar
Imports System.Windows.Forms
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_ValidarPermisoUsuario

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String


    Dim _Permiso_Aceptado As Boolean
    Dim _Funcionario As String

    Dim _Codpermiso As String
    Dim _CodEntidad, _CodSucEntidad As String

    Dim _Solicitar_permiso_y_no_esperar As Boolean
    Dim _Solicitar_permiso_y_esperar As Boolean
    Dim _Solicitar_Permiso_Al_Final As Boolean

    Dim _Permiso_Presencial As Boolean

    Dim _NroRemota As String

    Dim _Row_Usuario_Autoriza As DataRow
    Dim _Row_Info_Respuesta_Remota As DataRow

    Dim _Id_DocEnc As Integer

    Public Property Pro_Nro_Remota()
        Get
            Return _NroRemota
        End Get
        Set(ByVal value)

        End Set
    End Property
    Public Property Pro_Permiso_Aceptado() As Boolean
        Get
            Return _Permiso_Aceptado
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property
    Public Property Pro_Funcionario()
        Get
            Return _Funcionario
        End Get
        Set(ByVal value)
            _Funcionario = value
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
    Public Property Pro_Cod_Permiso() As String
        Get
            Return _Codpermiso
        End Get
        Set(ByVal value As String)
            _Codpermiso = value
            LblCodPermiso.Text = value

            LblDescripcionPermiso.Text = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_Permisos", "DescripcionPermiso", "CodPermiso = '" & _Codpermiso & "'")

        End Set
    End Property
    Public Property Pro_Nombre_Permiso() As String
        Get

        End Get
        Set(ByVal value As String)
            LblDescripcionPermiso.Text = value
        End Set
    End Property
    Public Property Pro_Solicitar_permiso_y_esperar()
        Get
            Return _Solicitar_permiso_y_esperar
        End Get
        Set(ByVal value)
            _Solicitar_permiso_y_esperar = value
        End Set
    End Property
    Public Property Pro_Solicitar_permiso_y_no_esperar() As Boolean
        Get
            Return _Solicitar_permiso_y_no_esperar
        End Get
        Set(ByVal value As Boolean)
            _Solicitar_permiso_y_no_esperar = value
        End Set
    End Property

    Public Property Pro_Permiso_Presencial As Boolean
        Get
            Return _Permiso_Presencial
        End Get
        Set(value As Boolean)
            _Permiso_Presencial = value
        End Set
    End Property

    Public Property Id_DocEnc As Integer
        Get
            Return _Id_DocEnc
        End Get
        Set(value As Integer)
            _Id_DocEnc = value
        End Set
    End Property

    Public Property Solicitar_Permiso_Al_Final As Boolean
        Get
            Return _Solicitar_Permiso_Al_Final
        End Get
        Set(value As Boolean)
            _Solicitar_Permiso_Al_Final = value
        End Set
    End Property

    Public Sub New(Optional ByVal CodEntidad As String = "",
                   Optional ByVal CodSucEntidad As String = "")

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        _CodEntidad = CodEntidad
        _CodSucEntidad = CodSucEntidad
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.TopMost = True

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_ValidarPermisoUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Btn_Solicitar_Al_Grabar_Documento.Visible = _Solicitar_Permiso_Al_Final
        _Solicitar_Permiso_Al_Final = False

        If _Solicitar_permiso_y_esperar Then
            _Solicitar_permiso_y_esperar = False
            AddHandler Btn_Permiso_Remoto.Click, AddressOf Sb_Solicitar_Permiso_Remoto_Y_Esperar_En_Linea2
        Else
            AddHandler Btn_Permiso_Remoto.Click, AddressOf Sb_Solicitar_Permiso_Remoto_Y_Esperar_En_Linea
        End If

        _Permiso_Aceptado = False

    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub BtnOtorgarPermisoPermanente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOtorgarPermisoPermanente.Click

        Dim _Autorizado As Boolean

        Dim Fm_Pass As New Frm_Clave_Administrador
        Fm_Pass.TopMost = Me.TopMost
        Fm_Pass.ShowDialog(Me)
        _Autorizado = Fm_Pass.Pro_Autorizado

        If _Autorizado Then

            Dim _Clave_Admin As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_PermisosADM", "ClaveAdministrador")

            Dim _Llave As String = UCase(_Codpermiso.Trim & "@" & FUNCIONARIO.Trim)
            _Llave = Encripta_md5(_Llave)

            Consulta_sql = "Insert Into " & _Global_BaseBk & "ZW_PermisosVsUsuarios (CodUsuario, CodPermiso, Llave) VALUES " &
                                 "('" & _Funcionario & "','" & Trim(LblCodPermiso.Text) & "','" & _Llave & "')"

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "", 0, "",
                                   "PERMISO OTORGADO PERMANENTEMENTE", _Codpermiso, "", "", "", False, "")

                MessageBoxEx.Show(Fm_Pass, "Permisos otorgado permanentemente al usuario",
                                  "Otorgar permiso", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
                _Permiso_Aceptado = True
                Me.Close()

            End If

        End If

        Fm_Pass.Dispose()

    End Sub

    Private Sub Frm_ValidarPermisoUsuario_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close() 'Call BtnxSalir_Click(Nothing, Nothing)
        ElseIf e.KeyValue = Keys.Enter Then
            If Btn_Autorizar_Permiso.Visible Then
                Call Btn_Autorizar_Permiso_Click(Nothing, Nothing)
            End If
        End If
    End Sub


    Sub Sb_Permiso_Remoto(Optional ByVal _Tbl_Usuarios As DataTable = Nothing)

        Dim _NomEntidad As String = Trim(_Sql.Fx_Trae_Dato("MAEEN", "NOKOEN",
                                              "KOEN = '" & _CodEntidad & "' And SUEN = '" & _CodSucEntidad & "'"))

        _NroRemota = Fx_Solicitar_Remota(FUNCIONARIO, _Codpermiso, "", _Id_DocEnc, _CodEntidad, _NomEntidad, True, _CodSucEntidad)

        If Not String.IsNullOrEmpty(_NroRemota) Then

            'ENVIO DE NOTIFICACIONES A LOS USUARIOS CON PERMISO
            If Not (_Tbl_Usuarios Is Nothing) Then

                For Each _Fila As DataRow In _Tbl_Usuarios.Rows

                    Dim _CodUsuario = _Fila.Item("Codigo")
                    Dim _Usuario = Trim(_Fila.Item("Descripcion"))
                    Dim _Texto = "Solicitado por: " & FUNCIONARIO & " - " & Trim(Nombre_funcionario_activo) & vbCrLf & vbCrLf &
                                 "Nro Remota:" & _NroRemota & vbCrLf &
                                 LblDescripcionPermiso.Text

                    csNotificaciones.Notificacion.Fx_Insertar_Notificacion(FUNCIONARIO,
                                                                           _CodUsuario,
                                                                           "PERMISO REMOTO",
                                                                           _Texto,
                                                                           csNotificaciones.Notificacion.Imagen.Remota,
                                                                           _NroRemota, False, 0, True, 0, False, "", "", "")
                Next

            End If


            Dim Fm As New Frm_Remotas_Espera_Permiso_Solicitado(_Codpermiso, _NroRemota)
            Fm.ShowDialog(Me)

            Dim _Sql_Elimina_Remota = String.Empty

            If Fm.Pro_Permiso Then

                _Permiso_Aceptado = True
                _Row_Usuario_Autoriza = Fm.Pro_Rows_Usuario_Autoriza
                _Row_Info_Respuesta_Remota = Fm.Pro_Rows_Info_Remota

                Me.Close()

            Else

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Remotas Set " & vbCrLf &
                               "CodFuncionario_Autoriza = '',Permiso_Otorgado = 0," & vbCrLf &
                               "Otorga = 'Cancelada',Fecha_Otorga = GetDate(),Eliminada = 1," &
                               "Observaciones = 'Acción cancelada por el usuario solicitante'" & vbCrLf &
                               "Where NroRemota = '" & _NroRemota & "'" & vbCrLf &
                               "Delete " & _Global_BaseBk & "Zw_Notificaciones" & Space(1) &
                               "Where NroRemota = '" & _NroRemota & "' And Usuario_Solicita = '" & FUNCIONARIO & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

        End If

    End Sub

    Private Sub Btn_Solicitar_Usuarios_Todos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Solicitar_Usuarios_Todos.Click

        Consulta_sql = "SELECT CodUsuario,Isnull((Select Top 1 NOKOFU From TABFU Where KOFU = CodUsuario),'') As Usuario," &
                       "CodPermiso, Llave, Semilla, Valor_Dscto" & vbCrLf &
                       "FROM " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf &
                       "Where CodUsuario <> '" & FUNCIONARIO & "'"

        Dim _Tbl_Usuarios As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        For Each _Fila As DataRow In _Tbl_Usuarios.Rows

            Dim _CodUsuario = _Fila.Item("CodUsuario")
            Dim _Usuario = _Fila.Item("Usuario")
            Dim _Texto = "Solicitado por: " & _CodUsuario & " - " & _Usuario & vbCrLf & vbCrLf &
                         LblDescripcionPermiso.Text

            csNotificaciones.Notificacion.Fx_Insertar_Notificacion(FUNCIONARIO,
                                                                   _CodUsuario,
                                                                   "PERMISO REMOTO",
                                                                   _Texto,
                                                                   csNotificaciones.Notificacion.Imagen.Remota,
                                                                   _NroRemota, False, 0, True, 0, False, "", "", "")

        Next

        Sb_Permiso_Remoto()

    End Sub

    Sub Sb_Solicitar_Permiso_Remoto_Y_Esperar_En_Linea()

        Dim _Solo_Supervisores As Boolean

        Consulta_sql = "Select CodUsuario From " & _Global_BaseBk & "ZW_PermisosVsUsuarios Where CodPermiso = '" & _Codpermiso & "'"

        If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Configuracion", "Solo_Supervisores_Dan_Permisos") Then

            _Solo_Supervisores = _Global_Row_Configuracion_General.Item("Solo_Supervisores_Dan_Permisos")

            If _Solo_Supervisores Then

                Consulta_sql = "Select CodUsuario From " & _Global_BaseBk & "ZW_PermisosVsUsuarios
                                Where CodPermiso = '" & _Codpermiso & "' 
                                And CodUsuario In (Select CodUsuario From " & _Global_BaseBk & "ZW_PermisosVsUsuarios Where CodPermiso = 'Admin001')"

            End If

        End If

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Filtro_Usuarios_NOT_In As String

        If CBool(_Tbl.Rows.Count) Then

            _Filtro_Usuarios_NOT_In = "And KOFU In " & Generar_Filtro_IN(_Tbl, "", "CodUsuario", False, False, "'")

            Dim Fm As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Funcionarios_Random)
            Fm.Pro_Sql_Filtro_Condicion_Extra = "And INACTIVO = 0" & vbCrLf & _Filtro_Usuarios_NOT_In
            Fm.Text = "USUARIOS AUTORIZADOS A DAR ESTE PERMISO: " & _Codpermiso
            Fm.ShowDialog(Me)

            If Fm.Pro_Filtrar Then
                Sb_Permiso_Remoto(Fm.Pro_Tbl_Filtro)
            End If

            Fm.Dispose()

        Else

            If _Solo_Supervisores Then

                MessageBoxEx.Show(Me, "No existen usuarios con esta autorización." & vbCrLf & vbCrLf &
                                  "El sistema esta configurado para que solo usuarios Supervisores puedan otorgar permisos presenciales o remotos",
                                  "Validación", MessageBoxButtons.OK,
                              MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Me.TopMost)

            Else

                MessageBoxEx.Show(Me, "No existen usuarios con esta autorización", "Validación", MessageBoxButtons.OK,
                              MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Me.TopMost)

            End If

        End If

    End Sub

    Sub Sb_Solicitar_Permiso_Remoto_Y_Esperar_En_Linea2()

        _Solicitar_permiso_y_esperar = True
        Me.Close()

    End Sub

    Private Sub Btn_Autorizar_Permiso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Autorizar_Permiso.Click

        _Solicitar_permiso_y_esperar = False
        _Permiso_Presencial = True

        Dim Fm As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, LblCodPermiso.Text, True, False)
        Fm.ShowInTaskbar = True
        Fm.ShowDialog(Me)
        _Permiso_Aceptado = Fm.Pro_Permiso_Aceptado
        _Row_Usuario_Autoriza = Fm.Pro_RowUsuario
        Fm.Dispose()

        Me.Close()

    End Sub

    Private Sub Btn_Mnu_Remoto_y_esperar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Remoto_y_esperar.Click
        Me.Close()
    End Sub

    Private Sub Frm_ValidarPermisoUsuario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

    Private Sub Btn_Solicitar_Al_Grabar_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Solicitar_Al_Grabar_Documento.Click
        _Solicitar_Permiso_Al_Final = True
        Me.Close()
    End Sub

    Private Sub Btn_Remoto_y_no_esperar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Remoto_y_no_esperar.Click
        _Solicitar_permiso_y_no_esperar = True
        Me.Close()
    End Sub


End Class
