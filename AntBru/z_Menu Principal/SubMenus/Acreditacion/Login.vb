Imports DevComponents.DotNetBar
Imports BkSpecialPrograms
Imports BkSpecialPrograms.LsValiciones

Public Class Login

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public _Cancelar_Login As Boolean
    Public _Usuario_Activado As Boolean
    Public _Inicio_Sesion As Boolean

    Dim _Teclado As Boolean
    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Dim _PWFU_Codificada As String

    Public Property FormMenu As UserControl

    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

        Dim _Color = "#474747"

        If Global_Thema = Enum_Themas.Oscuro Or Global_Thema = Enum_Themas.Oscuro_Ligth Then
            _Color = "#ffffff"
            Btn_Cancelar.ForeColor = Color.White
        End If

        Reflex_Nombre_Usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 15, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Reflex_Contrasena.Font = New System.Drawing.Font("Microsoft Sans Serif", 15, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        Reflex_Nombre_Usuario.Text = "<font color=""" & _Color & """>Nombre usuario</font><font color=""" & _Color & """></font>"
        Reflex_Contrasena.Text = "<font color=""" & _Color & """>Contraseña (Random)</font><font color=""" & _Color & """></font>"

        '"<b>OT: " & Numot & " SubOt: </b><font color=""" & _Color & """>" & Subot & "</font><br/>" &
        '               "<b>Código: " & Codigo & "</b><br/><font color=""" & _Color & """>" & Descripcion & "</font>"

    End Sub

    Private Sub Login_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Lbl_Version.Text = "BakApp Versión: " & _Version_BakApp
        Txt_Pass.Focus()
    End Sub

    Private Sub TxtxPassword_TextChanged(sender As System.Object, e As System.EventArgs) Handles Txt_Pass.TextChanged

        If Trim(Txt_Pass.Text) = "" Then Return
        Lbl_Usuario.Text = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "PWFU = '" &
                  TraeClaveRD(Txt_Pass.Text) & "'")
        If Lbl_Usuario.Text <> "" Then
            Btn_Ok.Enabled = True
        Else
            Btn_Ok.Enabled = False
        End If

    End Sub

    Private Sub Sb_Cancelar()

        If Not _Global_Sesion Then
            Application.ExitThread()
        End If
        TouchKeyboard1.HideKeyboard()

        If _Inicio_Sesion Then
            Dim NewPanel As Menu = Nothing
            NewPanel = New Menu(_Fm_Menu_Padre, False)
            _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)
        End If

        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Right)

    End Sub



    Private Sub Btn_Teclado_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Teclado.Click
        SendKeys.Send("{TAB}")
        If _Teclado Then
            Fx_Activar_Deactivar_Teclado(Me, False, TouchKeyboard1, Txt_Pass)
            Btn_Teclado.Text = "Ver"
            _Teclado = False
        Else
            Fx_Activar_Deactivar_Teclado(Me, True, TouchKeyboard1, Txt_Pass)
            Btn_Teclado.Text = "Ocultar"
            _Teclado = True
        End If
        Txt_Pass.Focus()
    End Sub

    Private Sub Btn_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cancelar.Click
        Sb_Cancelar()
    End Sub

    Private Sub Txt_Pass_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Txt_Pass.KeyDown

        Select Case e.KeyValue
            Case Keys.Enter
                Sb_Acepta(True)
            Case Keys.Escape
                Sb_Cancelar()
        End Select

    End Sub

    Private Sub Btn_Ok_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ok.Click
        Sb_Acepta(True)
    End Sub

    Sub Sb_Acepta(_Pass_Codificada As Boolean)

        Dim _Revisar_Demonio As Boolean

        If Not _Global_Sesion Then _Revisar_Demonio = True

        Me.Enabled = False
        Dim Fm As New Frm_Login

        Dim _Auntenficar_Usuario As Boolean
        Dim _ClaveCorrecta As Boolean

        If _Pass_Codificada Then
            _Auntenficar_Usuario = Fm.Fx_Autentificar_Usuario_Pass_Codificada(Txt_Pass.Text, Lbl_Usuario.Text, _ClaveCorrecta)
        Else
            _Auntenficar_Usuario = Fm.Fx_Autentificar_Usuario_Decodificada(_PWFU_Codificada, Lbl_Usuario.Text)
        End If

        Fm.Dispose()

        If _Auntenficar_Usuario Then

            Nombre_funcionario_activo = Lbl_Usuario.Text
            _Usuario_Activado = True
            _Global_Sesion = True

            Dim Fm_L As New Frm_Login
            _Auntenficar_Usuario = Fm_L.Fx_Sesion_Star(_Fm_Menu_Padre, FUNCIONARIO, Nombre_funcionario_activo)
            Fm_L.Dispose()

            If _Global_Sesion Then

                'Sb_Revisar_Estilo("")

                Dim Frm_Modalidad As New Frm_Modalidades(False)
                Frm_Modalidad.ShowDialog(Me)
                Frm_Modalidad.Dispose()

                Dim _Mod As New Clas_Modalidades

                _Mod.FormMenu = FormMenu
                _Mod.Sb_Actualiza_Formatos_X_Modalidad()
                _Mod.Sb_Actualizar_Variables_Modalidad(Modalidad)

                If _Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion") Then
                    MessageBoxEx.Show(Me, "ESTA MODALIDAD ESTA EN AMBIENTE CERTIFICACION", "FACTURA ELECTRONICA SII",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                Dim TipoEstacion = Trim(_Global_Row_EstacionBk.Item("TipoEstacion"))
                Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Casi_DocTom Where NombreEquipo = '" & _NombreEquipo & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                If Not _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_EstacionesBkp", "Empresa_Actual") Then

                    Consulta_sql = "ALTER TABLE " & _Global_BaseBk & "Zw_EstacionesBkp ADD Empresa_Actual CHAR(2) Not NULL Default('')"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp 
                                Set Empresa_Actual = '" & ModEmpresa & "', Usuario_Actual = '" & FUNCIONARIO & "', Modalidad_Actual = '" & Modalidad & "' 
                                Where NombreEquipo = '" & _NombreEquipo & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Frm_Menu.Notify_Menu_BakApp.Visible = True

                If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_EstacionesBkp", "Silenciar_Notificaciones") Then
                    Frm_Menu.Silenciar_Notificaciones.Checked = Not _Global_Row_EstacionBk.Item("Silenciar_Notificaciones")
                    Frm_Menu.Silenciar_Notificaciones.Enabled = True
                Else
                    Frm_Menu.Silenciar_Notificaciones.Enabled = False
                End If

                Frm_Menu.Mos_Notif_X_CdPermiso.Checked = Not _Global_Row_EstacionBk.Item("Mos_Notif_X_CdPermiso")

                Sb_Ejecutar_Notificaciones(_Fm_Menu_Padre, False)

                Select Case TipoEstacion

                    Case "P" ' Post-Venta

                        Sb_Post_de_venta(_Revisar_Demonio)
                        End

                    Case "Nvv"

                        Sb_Solo_Venta_NVV(_Revisar_Demonio)
                        End

                    Case "C" ' Consultor de precios

                        'TimpoEsperaNotificacion.Enabled = False
                        'Dim Frm_ConsultaPrecios As New Frm_ConsultaPrecios
                        'EditFrConsultaPre = False
                        'Frm_ConsultaPrecios.ShowDialog(Me)
                        End

                    Case "Dfa"

                        Sb_Produccion_Mesones_DFA()
                        End

                    Case "OT1"

                        Sb_IngresoGRIProduccion()
                        End

                    Case "BR1"
                        Sb_Impresora_CodigosDeBarraXProductos()
                        End
                    Case "N" ' Estación comun, Normal

                        If _Revisar_Demonio Then
                            Sb_Demonio(False)
                        End If

                    Case "Cd" ' CashDro

                        Sb_CashDro(_Fm_Menu_Padre)
                        Sb_Cerrar_Sistema(False)
                        End

                    Case "C1" ' CAJA TIPO PAGO A DOCUMENTOS

                        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Pcli0001") Then

                            If _Revisar_Demonio Then Sb_Demonio(False, True)

                            Frm_Menu.Mnu_Ventas.Visible = False
                            Frm_Menu.Notify_Menu_BakApp.Visible = True

                            Dim _Msj_Tsc As LsValiciones.Mensajes

                            _Msj_Tsc = Fx_Revisar_Tasa_Cambio(_Fm_Menu_Padre)

                            If _Msj_Tsc.EsCorrecto Then
                                _Fm_Menu_Padre.Hide()
                                Dim Fm_Pd As New Frm_Pagos_Documentos
                                Fm_Pd.ShowInTaskbar = True
                                Fm_Pd.ShowDialog(Me)
                                Fm_Pd.Dispose()
                            End If

                        End If

                        Sb_Cerrar_Sistema(False)

                        End

                End Select

                TouchKeyboard1.HideKeyboard()

                If _Inicio_Sesion Then

                    Dim NewPanel As Menu = Nothing
                    NewPanel = New Menu(_Fm_Menu_Padre, False)
                    _Fm_Menu_Padre.ShowModalPanel(NewPanel, DevComponents.DotNetBar.Controls.eSlideSide.Left)

                End If

                _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Right)

            Else
                End
            End If

        Else

            Me.Enabled = True
            If Not _ClaveCorrecta Then
                MessageBoxEx.Show(_Fm_Menu_Padre, "Clave desconocida", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            Txt_Pass.SelectAll()

        End If

    End Sub

    Private Sub Btn_Autenticar_Huella_Click(sender As Object, e As EventArgs) Handles Btn_Autenticar_Huella.Click

        Dim _Huella As String
        Dim _Registrado As Boolean
        Dim _Row_Usuario As DataRow

        Dim Fm As New Frm_Huella_Identificar(_Fm_Menu_Padre, _Huella, False, False, Frm_Huella_Identificar.Enum_Accion.Buscar_Huella)
        If Fm.Pro_Conectado Then
            Fm.ShowDialog(Me)
            _Registrado = Fm.Pro_Verificado
            _Row_Usuario = Fm.Pro_Row_Usuario
            _Huella = Fm.Pro_Huella
        End If
        Fm.Dispose()

        If _Registrado Then

            _PWFU_Codificada = _Row_Usuario.Item("PWFU")
            Lbl_Usuario.Text = _Row_Usuario.Item("NOKOFU")

            Sb_Acepta(False)

        End If

    End Sub

    Sub Sb_Post_de_venta(_Revisar_Demonio As Boolean)

        _Fm_Menu_Padre.Hide()

        Frm_Menu.Mnu_Ventas.Visible = False
        Frm_Menu.Notify_Menu_BakApp.Visible = True

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Bkp00027") Then

            Dim _RowFormato_BLV As DataRow = Fx_Formato_Modalidad(_Fm_Menu_Padre, Modalidad, "BLV", True)
            Dim _RowFormato_FCV As DataRow = Fx_Formato_Modalidad(_Fm_Menu_Padre, Modalidad, "FCV", True)
            Dim _RowFormato_COV As DataRow = Fx_Formato_Modalidad(_Fm_Menu_Padre, Modalidad, "COV", True)
            Dim _RowFormato_NVV As DataRow = Fx_Formato_Modalidad(_Fm_Menu_Padre, Modalidad, "NVV", True)

            If (_RowFormato_BLV Is Nothing) Or
               (_RowFormato_BLV Is Nothing) Or
               (_RowFormato_COV Is Nothing) Or
               (_RowFormato_NVV Is Nothing) Then

                MessageBoxEx.Show(_Fm_Menu_Padre, "Debe configurar el formato de salida en la configuración por modalidad de trabajo",
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                If _Revisar_Demonio Then Sb_Demonio(False, True)

                Dim _Msj_Tsc As LsValiciones.Mensajes

                _Msj_Tsc = Fx_Revisar_Tasa_Cambio(_Fm_Menu_Padre)

                If _Msj_Tsc.EsCorrecto Then

                    Dim Fm_Post As New Frm_Formulario_Documento("BLV", csGlobales.Enum_Tipo_Documento.Venta, True)
                    Fm_Post.ShowInTaskbar = True
                    Fm_Post.ShowDialog(Me)
                    Fm_Post.Dispose()

                End If
            End If

        End If

        Sb_Cerrar_Sistema(False)

    End Sub

    Sub Sb_Solo_Venta_NVV(_Revisar_Demonio As Boolean)

        _Fm_Menu_Padre.Hide()

        Frm_Menu.Mnu_Ventas.Visible = False
        Frm_Menu.Notify_Menu_BakApp.Visible = True

        If Fx_Tiene_Permiso(_Fm_Menu_Padre, "Bkp00041") Then

            Dim _RowFormato_NVV As DataRow = Fx_Formato_Modalidad(_Fm_Menu_Padre, Modalidad, "NVV", True)

            If IsNothing(_RowFormato_NVV) Then

                MessageBoxEx.Show(_Fm_Menu_Padre, "Debe configurar el formato de salida en la configuración por modalidad de trabajo",
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                If _Revisar_Demonio Then Sb_Demonio(False, True)

                Dim _Msj_Tsc As LsValiciones.Mensajes

                _Msj_Tsc = Fx_Revisar_Tasa_Cambio(_Fm_Menu_Padre)

                If _Msj_Tsc.EsCorrecto Then

                    Dim Fm_Post As New Frm_Formulario_Documento("NVV", csGlobales.Enum_Tipo_Documento.Venta)
                    Fm_Post.MinimizeBox = True
                    Fm_Post.ShowInTaskbar = True
                    Fm_Post.ShowDialog(Me)
                    Fm_Post.Dispose()

                End If

            End If

        End If

        Sb_Cerrar_Sistema(False)

    End Sub

End Class
