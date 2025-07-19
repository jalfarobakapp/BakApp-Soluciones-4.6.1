Imports System.Security.Permissions
Imports System.Media
Imports DevComponents.DotNetBar

Public Class Frm_Evento

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Accion_Enum, _Imagen_De_Fondo As csNotificaciones.Notificacion.Imagen

    Private posicion As Integer = 0
    Private _Posicion_Vertical As Integer = 0

    Dim _Cerrar_Automaticamente As Boolean
    Dim _Row_Notificacion As DataRow
    Dim _Formulario_Padre As Form

    Dim _Abrir_Permisos_Remotos As Boolean
    Dim _Abrir_SolCom_Productos As Boolean
    Dim _Abrir_SolCom_Mis_Solicitudes As Boolean

    Dim _Mostrar_Cerrar As Boolean

    Public Property Pro_Abrir_Permisos_Remotos() As Boolean
        Get
            Return _Abrir_Permisos_Remotos
        End Get
        Set(ByVal value As Boolean)
            _Abrir_Permisos_Remotos = value
        End Set
    End Property
    Public Property Pro_Abrir_SolCom_Productos As Boolean
        Get
            Return _Abrir_SolCom_Productos
        End Get
        Set(value As Boolean)
            _Abrir_SolCom_Productos = value
        End Set
    End Property

#Region "- Constructor -"
    Public Sub New(Posicion_Vertical As Integer,
                   Cerrar_Automaticamente As Boolean,
                   Id_Notificacion As Integer,
                   Formulario_Padre As Form,
                   Imagen_De_Fondo As csNotificaciones.Notificacion.Imagen)

        InitializeComponent()
        _Posicion_Vertical = Posicion_Vertical
        _Cerrar_Automaticamente = Cerrar_Automaticamente

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Notificaciones Where Id = " & Id_Notificacion
        _Row_Notificacion = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Formulario_Padre = Formulario_Padre
        _Imagen_De_Fondo = Imagen_De_Fondo

    End Sub
#End Region

#Region "- Agrega el efecto DropShadow al formulario -"

    Private Const CS_DROPSHADOW As Integer = &H20000

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        <SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode:=True)>
        Get
            Dim parameters As CreateParams = MyBase.CreateParams

            If DropShadowSupported Then
                parameters.ClassStyle = (parameters.ClassStyle Or CS_DROPSHADOW)
            End If
            Return parameters
        End Get
    End Property
    Public Shared ReadOnly Property DropShadowSupported() As Boolean
        Get
            Return IsWindowsXPOrAbove
        End Get
    End Property
    Public Shared ReadOnly Property IsWindowsXPOrAbove() As Boolean
        Get
            Dim system As OperatingSystem = Environment.OSVersion
            Dim runningNT As Boolean = system.Platform = PlatformID.Win32NT

            Return runningNT AndAlso system.Version.CompareTo(New Version(5, 1, 0, 0)) >= 0
        End Get
    End Property

    Public Property Mostrar_Cerrar As Boolean
        Get
            Return _Mostrar_Cerrar
        End Get
        Set(value As Boolean)
            _Mostrar_Cerrar = value
        End Set
    End Property

#End Region

    Private Sub Frm_Evento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _Formulario_Padre = Fm_Padre_Notificaciones

        If _Formulario_Padre Is Nothing Then
            _Formulario_Padre = Me
        End If

        If Not csNotificaciones.Notificacion._Formularios_Notificaciones.Contains(Me) Then
            csNotificaciones.Notificacion._Formularios_Notificaciones.Add(Me)
        End If


        Dim _Rnd As New Random
        Dim _Numero = _Rnd.Next(0, 16)

        Select Case _Numero
            Case 0, 4, 5, 9
                _Numero = 6
        End Select

        Dim _Color As Color = Fx_Color_Bakapp(_Numero) '(Enum_Colores_Bakapp.Azul_Oscuro)


        Me.TopMost = True
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)

        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Right - Me.Size.Width - 10, Screen.PrimaryScreen.Bounds.Bottom)
        TimerInicio.Enabled = True

        'Btn_No_Volver_A_Notificar.Visible = _Mostrar_Cerrar

        If (_Row_Notificacion Is Nothing) Then

            Sb_Imagen_De_Fondo()

            If Pro_Abrir_SolCom_Productos Then
                _Color = Fx_Color_Bakapp(Enum_Colores_Bakapp.Vino)
            End If

            If Pro_Abrir_Permisos_Remotos Then
                _Color = Fx_Color_Bakapp(Enum_Colores_Bakapp.Vino)
            End If

        Else

            Dim _Id = _Row_Notificacion.Item("Id")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set Mostrar = 0 Where Id = " & _Id
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Dim _Accion As String = _Row_Notificacion.Item("Accion")

            Select Case _Accion

                Case "Ok"

                    _Accion_Enum = csNotificaciones.Notificacion.Imagen.Ok
                    'pnlFondo.BackgroundImage = My.Resources.Recursos_Notif.ok1
                    Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Aceptado
                    _Color = Fx_Color_Bakapp(Enum_Colores_Bakapp.Verde)

                Case "Advertencia"

                    _Accion_Enum = csNotificaciones.Notificacion.Imagen.Advertencia
                    'pnlFondo.BackgroundImage = My.Resources.Recursos_Notif.advertencia1
                    Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Warning
                    _Color = Fx_Color_Bakapp(Enum_Colores_Bakapp.Amarillo)

                Case "Error"

                    _Accion_Enum = csNotificaciones.Notificacion.Imagen.Error
                    'pnlFondo.BackgroundImage = My.Resources.Recursos_Notif._error
                    Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Error
                    _Color = Fx_Color_Bakapp(Enum_Colores_Bakapp.Vino)

                Case "Soporte"

                    _Accion_Enum = csNotificaciones.Notificacion.Imagen.Soporte
                    'pnlFondo.BackgroundImage = My.Resources.Recursos_Notif.soporte1
                    Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Soporte

                Case "Usuarios"

                    _Accion_Enum = csNotificaciones.Notificacion.Imagen.Usuarios
                    'pnlFondo.BackgroundImage = My.Resources.Recursos_Notif.usuarios1
                    Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Usuarios

                Case "Ayuda"

                    _Accion_Enum = csNotificaciones.Notificacion.Imagen.Ayuda
                    'pnlFondo.BackgroundImage = My.Resources.Recursos_Notif.ayuda1
                    'Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Error
                    Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Ayuda

                Case "Llave"

                    _Accion_Enum = csNotificaciones.Notificacion.Imagen.Llave
                    'pnlFondo.BackgroundImage = My.Resources.Recursos_Notif.llave1

                Case "Scompra_Producto"

                    _Accion_Enum = csNotificaciones.Notificacion.Imagen.Scompra_Producto
                    'pnlFondo.BackgroundImage = My.Resources.Recursos_Notif.tarea1
                    Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Comprar

                Case "Tarea"

                    _Accion_Enum = csNotificaciones.Notificacion.Imagen.Tarea
                    'pnlFondo.BackgroundImage = My.Resources.Recursos_Notif.tarea1
                    Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Informacion

                Case "Internet"

                    _Accion_Enum = csNotificaciones.Notificacion.Imagen.Internet
                    'pnlFondo.BackgroundImage = My.Resources.Recursos_Notif.internet1
                    Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Internet

                Case "SinImagen"

                    _Accion_Enum = csNotificaciones.Notificacion.Imagen.SinImagen
                    Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Informacion

                Case "Remota"

                    _Accion_Enum = csNotificaciones.Notificacion.Imagen.Remota
                    'pnlFondo.BackgroundImage = My.Resources.Recursos_Notif.llave1
                    Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Llave
                    _Color = Fx_Color_Bakapp(Enum_Colores_Bakapp.Vino)

                Case "Informacion"

                    _Accion_Enum = csNotificaciones.Notificacion.Imagen.Informacion
                    'pnlFondo.BackgroundImage = My.Resources.Recursos_Notif.soporte1
                    Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Informacion
                    _Color = Fx_Color_Bakapp(Enum_Colores_Bakapp.Gris_Oscuro)

                Case "Confirmacion"

                    _Accion_Enum = csNotificaciones.Notificacion.Imagen.Confirmacion
                    'pnlFondo.BackgroundImage = My.Resources.Recursos_Notif.ok1
                    Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Aceptado

                Case "Rechazado"

                    _Accion_Enum = csNotificaciones.Notificacion.Imagen.Rechazado
                    'pnlFondo.BackgroundImage = My.Resources.Recursos_Notif._error
                    Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Error
                    _Color = Fx_Color_Bakapp(Enum_Colores_Bakapp.Rojo)

            End Select

            Dim _Titulo = _Row_Notificacion.Item("Titulo")
            Dim _Texto = _Row_Notificacion.Item("Texto")

            lblTitulo.Text = _Titulo
            Lbltexto.Text = _Texto

            'Btn_No_Volver_A_Notificar.Visible = Not String.IsNullOrEmpty(_Row_Notificacion.Item("NroRemota"))

        End If

        If Not (_Row_Notificacion Is Nothing) Then
            Timer_Cerrar_X_Analisis.Enabled = True
        End If

        Me.BackColor = _Color

        'If Btn_No_Volver_A_Notificar.Visible Then
        'Btn_No_Volver_A_Notificar.Visible = _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Notificaciones", "No_Volver_A_Notificar")
        'End If

    End Sub

    Sub Sb_Imagen_De_Fondo()

        Select Case _Imagen_De_Fondo

            Case csNotificaciones.Notificacion.Imagen.Ok

                Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Ok

            Case csNotificaciones.Notificacion.Imagen.Advertencia

                Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Warning

            Case csNotificaciones.Notificacion.Imagen.Error

                Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Error

            Case csNotificaciones.Notificacion.Imagen.Soporte

                Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Soporte

            Case csNotificaciones.Notificacion.Imagen.Usuarios

                Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Usuarios

            Case csNotificaciones.Notificacion.Imagen.Ayuda

                Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Ayuda

            Case csNotificaciones.Notificacion.Imagen.Llave

                Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Llave

            Case csNotificaciones.Notificacion.Imagen.Tarea

                Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Informacion

            Case csNotificaciones.Notificacion.Imagen.Internet

                Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Internet

            Case csNotificaciones.Notificacion.Imagen.Remota

                Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Llave

            Case csNotificaciones.Notificacion.Imagen.Informacion

                Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Informacion

            Case csNotificaciones.Notificacion.Imagen.Confirmacion

                Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Aceptado

            Case csNotificaciones.Notificacion.Imagen.Rechazado

                Imagen_Fondo.Image = My.Resources.Recursos_Iconos_Notificacion.Noti_Error

        End Select

    End Sub

    Private Sub TimerInicio_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerInicio.Tick

        posicion += 5
        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Right - posicion - 37, _Posicion_Vertical)

        If posicion >= Me.Width - 30 Then
            TimerInicio.Enabled = False

            ' SI SE DEJA ESTO ACTIVO LA VENTANITA SE ESCONDE AUTOMATICAMENTE
            TiempoEspera.Enabled = _Cerrar_Automaticamente

            ' sonido
            'Dim myPlayer As New SoundPlayer(My.Resources.Recursos_Notif.Popup)
            'myPlayer.Play()

        End If
    End Sub

    Private Sub TimerCerrar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerCerrar.Tick

        posicion -= 5
        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Right - posicion, _Posicion_Vertical)

        If posicion <= 0 Then
            Me.Opacity = 0.3
            csNotificaciones.Notificacion.listaSlots.Remove(_Posicion_Vertical)
            Me.Close()
        End If

    End Sub

    Private Sub TiempoEspera_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiempoEspera.Tick

        'Me.Invalidate()
        TiempoEspera.Enabled = False

        ' SI SE DEJA ESTO ACTIVO LA VENTANITA SE ESCONDE AUTOMATICAMENTE
        'TimerCerrar.Enabled = _Cerrar_Automaticamente

        If _Cerrar_Automaticamente Then
            Sb_Solo_Cerrar()
        End If

    End Sub

    Private Sub Lbltexto_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lbltexto.MouseHover

        If _Cerrar_Automaticamente Then
            TiempoEspera.Enabled = False
        End If

    End Sub

    Private Sub Lbltexto_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lbltexto.MouseLeave
        TiempoEspera.Enabled = _Cerrar_Automaticamente
    End Sub

    Sub Sb_Cerrar()

        If Not (_Row_Notificacion Is Nothing) Then

            Dim _Id = _Row_Notificacion.Item("Id")
            Dim _Usuario_Solicita = _Row_Notificacion.Item("Usuario_Solicita")
            Dim _Accion As String = _Row_Notificacion.Item("Accion")
            Dim _NroRemota As String = _Row_Notificacion.Item("NroRemota")
            Dim _Id_SCom = _Row_Notificacion.Item("Id_SCom")

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Notificaciones" & vbCrLf &
                                            "Where IdRespuesta = " & _Id & " And Usuario_Solicita = '" & FUNCIONARIO & "' And Accion = 'Cerrar'"
            Dim _Row_Confirmacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If (_Row_Confirmacion Is Nothing) Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set Leido = Leido+1 Where Id = " & _Id '& vbCrLf & _

            Else

                Dim _Id_Confirmacion As Integer = _Row_Confirmacion.Item("Id")
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set Leido = Leido+1 Where Id = " & _Id & vbCrLf &
                                "Update " & _Global_BaseBk & "Zw_Notificaciones Set Leido = Leido+1,Fecha = Getdate(),Hora = Getdate() Where Id = " & _Id_Confirmacion

            End If

            _Sql.Ej_consulta_IDU(Consulta_sql)

            If Not _Accion = "Cerrar" And Not _Accion = "Confirmacion" Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set Cerrado = Cerrado+1 Where Id = " & _Id
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

        End If

        Sb_Solo_Cerrar()

    End Sub

    Public Sub Sb_Solo_Cerrar()

        If Not (_Row_Notificacion Is Nothing) Then

            Dim _Id = _Row_Notificacion.Item("Id")
            Dim _Accion As String = _Row_Notificacion.Item("Accion")

            If Not _Accion = "Cerrar" And Not _Accion = "Confirmacion" And Not _Accion = "Scompra_Producto" Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set Mostrar = 1 Where Id = " & _Id
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

        End If

        TimerInicio.Enabled = False
        TiempoEspera.Enabled = False
        TimerCerrar.Enabled = True

    End Sub

    Private Sub Lbltexto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lbltexto.Click

        Sb_Revisar_Estilo("")

        _Global_Notificaciones = False

        Me.Enabled = False
        _Cerrar_Automaticamente = False

        If Not (_Row_Notificacion Is Nothing) Then

            Me.TopMost = False

            Timer_Molestar.Enabled = False
            Timer_Cerrar_X_Analisis.Enabled = False
            TimerInicio.Enabled = False
            TiempoEspera.Enabled = False
            TimerCerrar.Enabled = False
            Timer_Abrir_Molestar.Enabled = False


            Dim _Id = _Row_Notificacion.Item("Id")
            Dim _Usuario_Solicita = _Row_Notificacion.Item("Usuario_Solicita")
            Dim _Accion As String = _Row_Notificacion.Item("Accion")
            Dim _NroRemota As String = _Row_Notificacion.Item("NroRemota")
            Dim _Id_SCom = _Row_Notificacion.Item("Id_SCom")

            Select Case _Accion

                Case "Remota"

                    Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Notificaciones" & vbCrLf &
                                "Where IdRespuesta = " & _Id & " And Usuario_Solicita = '" & FUNCIONARIO & "' And Accion = 'Confirmacion'"
                    Dim _Row_Confirmacion As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If (_Row_Confirmacion Is Nothing) Then

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set Leido = Leido+1 Where Id = " & _Id '& vbCrLf & _

                    Else

                        Dim _Id_Confirmacion As Integer = _Row_Confirmacion.Item("Id")
                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set Leido = Leido+1 Where Id = " & _Id & vbCrLf &
                                        "Update " & _Global_BaseBk & "Zw_Notificaciones Set Leido = Leido+1,Fecha = Getdate(),Hora = Getdate() Where Id = " & _Id_Confirmacion

                    End If

                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    Consulta_sql = "Select Top 1 Empresa,RAZON As Razon,NroRemota,CodFuncionario_Solicita,CodFuncionario_Autoriza,CodPermiso,
                                    Descripcion_Adicional,Permiso_Otorgado,Otorga,Id_Casi_DocEnc,Fecha_Solicita,Fecha_Otorga,
                                    CodEntidad, CodSucEntidad,NomEntidad,TotalBruto,Espera_En_Linea,Eliminada,Observaciones 
                                    From " & _Global_BaseBk & "Zw_Remotas
                                    Left Join CONFIGP On EMPRESA = Empresa
                                    Where NroRemota = '" & _NroRemota & "' And Eliminada = 0"

                    Dim _Row_Remota As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If Not (_Row_Remota Is Nothing) Then

                        Dim _Empresa = _Row_Remota.Item("Empresa")
                        Dim _Razon = _Row_Remota.Item("Razon").ToString.Trim
                        Dim _Revisar_Permiso = True

                        If Mod_Empresa <> _Empresa Then

                            MessageBoxEx.Show(Me, "Este permiso corresponde a la empresa " & _Empresa & " - " & _Razon & vbCrLf &
                                              "Debe cambiarse de modalidad y seleccionar la empresa para dar el permiso", "Permiso desde otra empresa",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set Mostrar = 1,Autorizado = 1,Rechazado = 1 Where Id = " & _Id
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                            _Revisar_Permiso = False

                        End If

                        If _Revisar_Permiso Then

                            Dim _Id_Casi_DocEnc = _Row_Remota.Item("Id_Casi_DocEnc")

                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Remotas Set Id_Notificacion = " & _Id & vbCrLf &
                                           "Where NroRemota = '" & _NroRemota & "'"
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                            csNotificaciones.Notificacion.Gestionando = True

                            Dim Fm_Remotas As New Frm_Remotas_Lista_Permisos_Solicitados(FUNCIONARIO, CBool(_Id_Casi_DocEnc))
                            Fm_Remotas.Pro_NroRemota_Marcar = _NroRemota
                            Fm_Remotas.Grilla.Enabled = False
                            Fm_Remotas.ShowDialog(Me)
                            Fm_Remotas.Dispose()

                            csNotificaciones.Notificacion.Gestionando = False

                            Consulta_sql = "Select Top 1 NroRemota,CodFuncionario_Solicita,CodFuncionario_Autoriza,CodPermiso," & vbCrLf &
                                           "Descripcion_Adicional,Permiso_Otorgado,Otorga,Id_Casi_DocEnc,Fecha_Solicita,Fecha_Otorga," &
                                           "CodEntidad, CodSucEntidad,NomEntidad,TotalBruto,Espera_En_Linea,Eliminada,Observaciones" & vbCrLf &
                                           "From " & _Global_BaseBk & "Zw_Remotas" & vbCrLf &
                                           "Where NroRemota = '" & _NroRemota & "' And Eliminada = 0"

                            _Row_Remota = _Sql.Fx_Get_DataRow(Consulta_sql)

                        End If

                    End If


                    If Not (_Row_Remota Is Nothing) Then

                        Dim _Otorga As String = _Row_Remota.Item("Otorga")

                        If String.IsNullOrEmpty(_Otorga) Then

                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set Mostrar = 1 Where Id = " & _Id
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                        End If

                    Else

                        Dim _Log = "El permisos remoto no fue encontrado o fue cancelado por el usuario que solicito el permiso"

                        _Row_Notificacion.Item("Accion") = "Rev. por otro usuario"

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set" & vbCrLf &
                                        "Log_Notificacion = '" & _Log & "',Mostrar = 0 Where Id = " & _Id
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        Beep()
                        ToastNotification.Show(Me, "La solicitud ya no esta disponible o fue cancelada por el usuario",
                                             Nothing,
                                               5 * 1000, eToastGlowColor.Green,
                                               eToastPosition.MiddleCenter)

                    End If

                Case "Ok"

                    Consulta_sql = "SELECT TOP 1 * From " & _Global_BaseBk & "Zw_Remotas" & vbCrLf &
                                   "Where NroRemota = '" & _NroRemota & "' And Eliminada = 0"

                    Dim _Row_Remota As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If Not (_Row_Remota Is Nothing) Then

                        Dim _CodFuncionario_Autoriza = _Row_Remota.Item("CodFuncionario_Autoriza")
                        Dim _CodFuncionario_Solicita = _Row_Remota.Item("CodFuncionario_Solicita")
                        Dim _Otorga = _Row_Remota.Item("Otorga")
                        Dim _Observaciones = _Row_Remota.Item("Observaciones")
                        Dim _Id_Casi_DocEnc = _Row_Remota.Item("Id_Casi_DocEnc")
                        Dim _Idmaeedo = _Row_Remota.Item("Idmaeedo")

                        Dim _Permiso_Otorgado = _Row_Remota.Item("Permiso_Otorgado")
                        Dim _Rev_Usuario_Solicita = _Row_Remota.Item("Rev_Usuario_Solicita")

                        If CBool(_Idmaeedo) Then

                            csNotificaciones.Notificacion.Gestionando = True

                            Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
                            Fm.ShowInTaskbar = True
                            Fm.ShowDialog(_Formulario_Padre)
                            Fm.Dispose()

                            csNotificaciones.Notificacion.Gestionando = False

                        Else

                            Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Casi_DocEnc", "Id_DocEnc = " & _Id_Casi_DocEnc)

                            If CBool(_Reg) Then

                                Dim _Autorizado = 0
                                Dim _Rechazado = 0

                                If _Otorga = "Autorizado" Then _Autorizado = 1
                                If _Otorga = "Rechazado" Then _Rechazado = 1

                                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set" & Space(1) &
                                                "Autorizado = " & _Autorizado & ",Rechazado = " & _Rechazado & vbCrLf &
                                                "Where Id = " & _Id & vbCrLf &
                                                "Update " & _Global_BaseBk & "Zw_Remotas Set Rev_Usuario_Solicita = 1 Where NroRemota = '" & _NroRemota & "'"
                                _Sql.Ej_consulta_IDU(Consulta_sql)

                                Dim TipoDoc As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Casi_DocEnc", "TipoDoc",
                                                                          "Id_DocEnc = " & _Id_Casi_DocEnc)

                                _Row_Remota.Item("Rev_Usuario_Solicita") = True

                                csNotificaciones.Notificacion.Gestionando = True

                                Dim Fm_Post As New Frm_Formulario_Documento(TipoDoc, csGlobales.Enum_Tipo_Documento.Venta, False)
                                Fm_Post.Pro_RowRemota_Notificacion = _Row_Remota
                                Fm_Post.Pro_Correr_a_la_derecha = True
                                Fm_Post.ShowInTaskbar = True
                                Fm_Post.ShowDialog(Me)
                                Fm_Post.Dispose()

                                csNotificaciones.Notificacion.Gestionando = False

                            Else

                                If Not _Rev_Usuario_Solicita Then

                                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set " & Space(1) &
                                                    "Leido = Leido+1,Fecha = Getdate(),Hora = Getdate(),Mostrar = 1 Where Id = " & _Id
                                    _Sql.Ej_consulta_IDU(Consulta_sql)

                                End If

                            End If

                        End If

                    End If

                Case "Rechazado"

                    Consulta_sql = "SELECT TOP 1 * From " & _Global_BaseBk & "Zw_Remotas" & vbCrLf &
                                "Where NroRemota = '" & _NroRemota & "'"

                    Dim _Row_Remota As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If Not (_Row_Remota Is Nothing) Then

                        Dim _CodFuncionario_Autoriza = _Row_Remota.Item("CodFuncionario_Autoriza")
                        Dim _CodFuncionario_Solicita = _Row_Remota.Item("CodFuncionario_Solicita")
                        Dim _Otorga = _Row_Remota.Item("Otorga")
                        Dim _Observaciones = _Row_Remota.Item("Observaciones")
                        Dim _Id_Casi_DocEnc = _Row_Remota.Item("Id_Casi_DocEnc")

                        Dim _Permiso_Otorgado = _Row_Remota.Item("Permiso_Otorgado")
                        Dim _Rev_Usuario_Solicita = _Row_Remota.Item("Rev_Usuario_Solicita")

                        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Casi_DocEnc", "Id_DocEnc = " & _Id_Casi_DocEnc)

                        If CBool(_Reg) Then

                            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Notificaciones" & vbCrLf &
                                           "Where NroRemota = '" & _NroRemota & "'" & vbCrLf &
                                           "Update " & _Global_BaseBk & "Zw_Remotas Set Rev_Usuario_Solicita = 1 Where NroRemota = '" & _NroRemota & "'"
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                            Dim _TipoDoc As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Casi_DocEnc", "TipoDoc",
                                                                      "Id_DocEnc = " & _Id_Casi_DocEnc)

                            csNotificaciones.Notificacion.Gestionando = True

                            Dim _RCadena_Id_Enc = _Row_Remota.Item("RCadena_Id_Enc")

                            Dim Fm As New Frm_Cadenas_Remotas_Lista(Frm_Cadenas_Remotas_Lista.Enum_Accion.Mis_CRemotas, _TipoDoc)
                            Fm.Pro_Revisar_Notificacion = True
                            Fm.Pro_Id_Enc_Revisar = _RCadena_Id_Enc
                            Fm.ShowDialog(Me)
                            Fm.Dispose()

                            csNotificaciones.Notificacion.Gestionando = False

                        Else

                            If Not _Rev_Usuario_Solicita Then

                                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set " & Space(1) &
                                                "Leido = Leido+1,Fecha = Getdate(),Hora = Getdate(),Mostrar = 1 Where Id = " & _Id
                                _Sql.Ej_consulta_IDU(Consulta_sql)

                            End If

                        End If

                    End If

                Case "Scompra_Producto"

                    If Not _Global_Menu_Sol_Compra_Productos_Abierto Then

                        Dim _Cl_Sol_Recom_Compra_Pr As New Cl_Sol_Recom_Compra_Pr

                        csNotificaciones.Notificacion.Gestionando = True

                        Dim Fm As New Frm_Sol_Recom_Respuesta(_Id_SCom)
                        Fm.ShowDialog(Me)
                        _Cl_Sol_Recom_Compra_Pr = Fm.Pro_Cl_Sol_Recom_Compra_Pr
                        Dim _Grabar = Fm.Pro_Grabar
                        Fm.Dispose()

                        csNotificaciones.Notificacion.Gestionando = False

                        If Not _Grabar Then

                            If _Cl_Sol_Recom_Compra_Pr.Estado = Cl_Sol_Recom_Compra_Pr.Enum_Estados.Pendiente And
                               _Cl_Sol_Recom_Compra_Pr.Row_Prod_SolCompra.Item("CodFun_Solicita") <> FUNCIONARIO Then

                                Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_SolCompra_Resp",
                                                                    "Id_SCom = " & _Id_SCom & " And Estado = 'ACU'")

                                If Not Convert.ToBoolean(_Reg) Then

                                    _Cl_Sol_Recom_Compra_Pr.Fx_Insertar_Respuesta(FUNCIONARIO, Cl_Sol_Recom_Compra_Pr.Enum_Estados.Revisado, "", 0, 0)

                                End If

                            End If

                        End If

                    End If

            End Select

        Else

            If _Abrir_Permisos_Remotos Then

                Me.TopMost = False

                Timer_Molestar.Enabled = False
                Timer_Cerrar_X_Analisis.Enabled = False
                TimerInicio.Enabled = False
                TiempoEspera.Enabled = False
                TimerCerrar.Enabled = False
                Timer_Abrir_Molestar.Enabled = False

                csNotificaciones.Notificacion.Gestionando = True

                Dim Fm_Rem As New Frm_Remotas_Lista_Permisos_Solicitados(FUNCIONARIO, False)
                Fm_Rem.ShowDialog(Me)
                Fm_Rem.Dispose()

                csNotificaciones.Notificacion.Gestionando = False

            End If

            If _Abrir_SolCom_Productos Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set 
                                Leido = Leido+1,Fecha = Getdate(),Hora = Getdate(),Mostrar = 0 
                                Where Id_SCom > 0 And Mostrar = 1 And Usuario_Destino = '" & FUNCIONARIO & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                csNotificaciones.Notificacion.Gestionando = True

                Dim Fm As Frm_Sol_Recom_Lista

                If _Abrir_SolCom_Mis_Solicitudes Then
                    Fm = New Frm_Sol_Recom_Lista(Frm_Sol_Recom_Lista.Enum_Vista_Solicitudes.Mis_Solicitudes)
                Else
                    Fm = New Frm_Sol_Recom_Lista(Frm_Sol_Recom_Lista.Enum_Vista_Solicitudes.Todas)
                End If

                Fm.MinimizeBox = True
                Fm.ShowDialog(Me)
                Fm.Dispose()

                csNotificaciones.Notificacion.Gestionando = False

            End If

        End If

        TimerCerrar.Enabled = True

        _Global_Notificaciones = True

    End Sub


    Private Sub Timer_Cerrar_X_Analisis_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Cerrar_X_Analisis.Tick

        Timer_Cerrar_X_Analisis.Stop()

        Dim _Id = _Row_Notificacion.Item("Id")
        Dim _IdRespuesta = _Row_Notificacion.Item("IdRespuesta")
        Dim _Cerrar As Boolean

        If CBool(_Id) Then

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Notificaciones Where Id = " & _Id
            Dim _Row_Respuesta = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            _Cerrar = (_Row_Respuesta Is Nothing)

            If Not _Cerrar Then

                Dim _Autorizado = _Row_Respuesta.Item("Autorizado")
                Dim _Rechazado = _Row_Respuesta.Item("Rechazado")

                If _Autorizado Or _Rechazado Then
                    _Cerrar = True
                End If

            End If

        End If

        If _Cerrar Then

            TimerInicio.Enabled = False
            TiempoEspera.Enabled = False
            TimerCerrar.Enabled = True

        Else
            Timer_Cerrar_X_Analisis.Start()
        End If

    End Sub

    Private Sub Timer_Molestar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Molestar.Tick

        Timer_Molestar.Stop()
        Timer_Cierra_Molestar.Enabled = True

    End Sub

    Private Sub Timer_Cierra_Molestar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Cierra_Molestar.Tick

        posicion -= 5
        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Right - posicion, _Posicion_Vertical)

        If posicion <= 0 Then
            Timer_Cierra_Molestar.Enabled = False
            Timer_Abrir_Molestar.Enabled = True
        End If

    End Sub

    Private Sub Timer_Abrir_Molestar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Abrir_Molestar.Tick

        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Right - posicion - 37, _Posicion_Vertical)

        If posicion >= Me.Width - 30 Then
            Timer_Abrir_Molestar.Enabled = False
            Timer_Molestar.Start()
        End If

        posicion += 5

    End Sub

    Private Sub Lbl_Cerrar_Click(sender As Object, e As EventArgs) Handles Lbl_Cerrar.Click
        Sb_No_Volver_A_Notificar()
        Sb_Cerrar()
    End Sub

    Private Sub Sb_No_Volver_A_Notificar()

        Sb_Revisar_Estilo("")

        _Global_Notificaciones = False

        Me.Enabled = False
        _Cerrar_Automaticamente = False

        If Not (_Row_Notificacion Is Nothing) Then

            Me.TopMost = False

            Timer_Molestar.Enabled = False
            Timer_Cerrar_X_Analisis.Enabled = False
            TimerInicio.Enabled = False
            TiempoEspera.Enabled = False
            TimerCerrar.Enabled = False
            Timer_Abrir_Molestar.Enabled = False

            Dim _Id = _Row_Notificacion.Item("Id")
            Dim _Usuario_Solicita = _Row_Notificacion.Item("Usuario_Solicita")
            Dim _Accion As String = _Row_Notificacion.Item("Accion")
            Dim _NroRemota As String = _Row_Notificacion.Item("NroRemota")
            Dim _Id_SCom = _Row_Notificacion.Item("Id_SCom")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set 
                            Leido = Leido+1,Fecha = Getdate(),Hora = Getdate(),Mostrar = 0,
                            Log_Notificacion = 'Aceptado sin abrir por el usuario: " & FUNCIONARIO & "',No_Volver_A_Notificar = 1 
                            Where Id = " & _Id
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        TimerCerrar.Enabled = True

        _Global_Notificaciones = True

    End Sub

    Private Sub Frm_Evento_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        If csNotificaciones.Notificacion._Acumulado_SolComProd_Abierta Then
            csNotificaciones.Notificacion._Acumulado_SolComProd_Abierta = False
        End If

        If csNotificaciones.Notificacion._Acumulado_Permiso_Remoto_Abierta Then
            csNotificaciones.Notificacion._Acumulado_Permiso_Remoto_Abierta = False
        End If

    End Sub
End Class
