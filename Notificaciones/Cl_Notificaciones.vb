Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Cl_Notificaciones

    Dim _Tiempo_Notificacion As Integer
    Dim _Contador_Tiempo_Remotas As Integer

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Formulario As Form

    Public Sub New(Formulario As Form)

        _Formulario = Formulario

    End Sub

    Public Property Tiempo_Notificacion As Integer
        Get
            Return _Tiempo_Notificacion
        End Get
        Set(value As Integer)
            _Tiempo_Notificacion = value
        End Set
    End Property

    Public Property Contador_Tiempo_Remotas As Integer
        Get
            Return _Contador_Tiempo_Remotas
        End Get
        Set(value As Integer)
            _Contador_Tiempo_Remotas = value
        End Set
    End Property

    Function Fx_Conectar_Sistema() As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_Sql As String

        RutEmpresa = Trim(_Sql.Fx_Trae_Dato("CONFIGP", "RUT", "EMPRESA = '01'"))

        If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Empresas") Then

            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Empresas Where Empresa = '01'"
            _Global_Row_Empresa = _Sql.Fx_Get_DataRow(Consulta_Sql)

            If IsNothing(_Global_Row_Empresa) Then

                Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Empresas (Empresa,Rut,Razon,Ncorto,Direccion,Pais,Ciudad,Giro)" & vbCrLf &
                               "Select EMPRESA,RUT,RAZON,NCORTO,DIRECCION,PAIS,CIUDAD,GIRO From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
                _Sql.Ej_consulta_IDU(Consulta_Sql)

                Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Empresas Where Empresa = '" & ModEmpresa & "'"
                _Global_Row_Empresa = _Sql.Fx_Get_DataRow(Consulta_Sql)

            End If

            RazonEmpresa = _Global_Row_Empresa.Item("Razon").ToString.Trim
            DireccionEmpresa = _Global_Row_Empresa.Item("Direccion").ToString.Trim
            RutEmpresaActiva = _Global_Row_Empresa.Item("Rut").ToString.Trim
            RutEmpresa = RutEmpresaActiva
            ModEmpresa = _Global_Row_Empresa.Item("Empresa").ToString.Trim

        End If

        Dim _Dir_Local As String = Application.StartupPath & "\Data\"
        Dim _Row_Nom_Equipo As DataRow

        Dim _Nombre_Equipo As String = My.Computer.Name
        If Fx_Revisar_Nombre_Equipo_BakApp(_Formulario, _Dir_Local & RutEmpresa & "\Configuracion_Local", RutEmpresa, _Nombre_Equipo) Then

            Dim _Ds As New DatosBakApp
            _Ds.Clear()
            _Ds.ReadXml(_Dir_Local & RutEmpresa & "\Configuracion_Local\Nombre_Equipo.xml")

            _Row_Nom_Equipo = _Ds.Tables("Tbl_Nombre_Equipo").Rows(0)
        Else
            MessageBoxEx.Show(_Formulario, "Revise el nombre del equipo en la carpeta" & vbCrLf &
            _Dir_Local & RutEmpresa & "\Configuracion_Local", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End
        End If

        Dim _Mi_IP = getIp()
        _Nombre_Equipo = _Row_Nom_Equipo.Item("Nombre_Equipo") 'UCase(System.Net.Dns.GetHostName)

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_EstacionesBkp Where NombreEquipo = '" & _Nombre_Equipo & "'"
        _Global_Row_EstacionBk = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If Not (_Global_Row_EstacionBk Is Nothing) Then

            FUNCIONARIO = _Global_Row_EstacionBk.Item("Usuario_Actual")
            ModEmpresa = _Global_Row_EstacionBk.Item("Empresa_Actual")
            Modalidad = _Global_Row_EstacionBk.Item("Modalidad_Actual")

            If String.IsNullOrEmpty(Trim(FUNCIONARIO)) Then

                FUNCIONARIO = String.Empty

                MessageBoxEx.Show(_Formulario, "FALTA NOMBRE DE USUARIO POR DEFECTO Y MODALIDAD" & vbCrLf &
                                  "NOMBRE DE EQUIPO: " & _Nombre_Equipo, "VALIDACION",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Dim Fml As New Frm_Login
                Fml.ShowDialog()
                Fml.Dispose()

                If Not String.IsNullOrEmpty(Trim(FUNCIONARIO)) Then

                    Dim Frm_Modalidad As New Frm_Modalidad_Mt
                    Frm_Modalidad.ShowDialog()
                    Frm_Modalidad.Dispose()

                Else

                    Application.ExitThread()

                End If

            End If

            Dim _Mod As New Clas_Modalidades
            _Mod.Sb_Actualiza_Formatos_X_Modalidad()
            _Global_Row_Configuracion_General = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.General, "")
            _Global_Row_Configuracion_Estacion = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.Estacion, Modalidad)
            _Mod.Sb_Actualizar_Variables_Modalidad(Modalidad)

            Return True

        End If

    End Function

    Sub Sb_Revisar_Notificaciones_Remotas(_Revisar_todas As Boolean, _Sonido_Beep As Boolean)

        If _Global_Notificaciones Then

            _Sql = New Class_SQL(Cadena_ConexionSQL_Server)

            Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

            If _Revisar_todas Then

                'Muestra permisos remotos que estan en espera, pero que no son cadenas remotas.

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Remotas 
                                    Where NroRemota In (Select  NroRemota From " & _Global_BaseBk & "Zw_Notificaciones 
                                        Where Usuario_Destino = '" & FUNCIONARIO & "' And Accion = 'Remota') And Otorga = '' And Eliminada = 0 And Empresa = '" & ModEmpresa & "' -- And RCadena_Id_Enc = 0"

                Dim _TblRemotas_Pendientes As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

                If CBool(_TblRemotas_Pendientes.Rows.Count) Then

                    Dim _Titulo = "SOLICITUDES REMOTAS PENDIENTES"

                    Dim _Texto = "EXISTEN PERMISOS REMOTOS ESPERANDO PARA SU APROBACION." & vbCrLf & vbCrLf &
                                 "REVISE LOS PERMISOS REMOTOS DE BAKAPP"
                    '"PRESIONE ESTA ETIQUETA PARA REALIZAR GESTION"

                    'csNotificaciones.Notificacion.Sb_Pop_Up_Remota(0, _Titulo, _Texto, csNotificaciones.Notificacion.Imagen.Llave,
                    '                                              20, True, _Formulario, _Sonido_Beep, False)

                    csNotificaciones.Notificacion._Acumulado_Permiso_Remoto_Abierta = True

                    Dim _Notificacion = _Titulo & vbCrLf & vbCrLf & _Texto

                    CType(_Formulario, Frm_Notificaciones).Notify_Notificaciones.ShowBalloonTip(5, "Info. BakApp",
                                                                            _Notificacion,
                                                                            ToolTipIcon.Info)

                End If

                Dim _Permisos_Aceptados As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Notificaciones",
                                    "Mostrar = 1 And Accion In ('Ok','Rechazado') And Usuario_Destino = '" & FUNCIONARIO & "' And Empresa = '" & ModEmpresa & "'")

                If CBool(_Permisos_Aceptados) Then

                    Dim _Titulo = "DOCUMENTOS GESTIONADOS"
                    Dim _Texto = "EXISTEN PERMISOS ACEPTADOS O RECHAZADOS." & vbCrLf &
                                 "DEBE REVISAR LOS DOCUMENTOS EN ESTADO PENDIENTES DESDE EL" & vbCrLf &
                                 "FORMULARIO DE CREACION DE NOTAS DE VENTA u ORDENES DE COMPRA"
                    'csNotificaciones.Notificacion.Sb_Pop_Up(0, _Titulo, _Texto, csNotificaciones.Notificacion.Imagen.Informacion,
                    '                                          10, True, _Formulario, False)

                    Dim _Notificacion = _Titulo & vbCrLf & vbCrLf & _Texto

                    CType(_Formulario, Frm_Notificaciones).Notify_Notificaciones.ShowBalloonTip(5, "Info. BakApp",
                                                                            _Notificacion,
                                                                            ToolTipIcon.Info)

                End If

            Else

                If csNotificaciones.Notificacion._Acumulado_Permiso_Remoto_Abierta = True Then
                    Return
                End If

                If False Then

                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Remotas
                                 Inner Join TABFU On KOFU = CodFuncionario_Solicita
                                    Where NroRemota In (Select  NroRemota From " & _Global_BaseBk & "Zw_Notificaciones 
                                        Where Usuario_Destino = '" & FUNCIONARIO & "' And Accion = 'Remota') And Otorga = '' And Eliminada = 0 And Empresa = '" & ModEmpresa & "' And RCadena_Id_Enc = 0"

                    Dim _TblRemotas_Pendientes As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

                    If CBool(_TblRemotas_Pendientes.Rows.Count) Then

                        For Each _Fila As DataRow In _TblRemotas_Pendientes.Rows

                            Dim _NroRemota = _Fila.Item("NroRemota")
                            Dim _Kofu = _Fila.Item("KOFU")
                            Dim _Nokofu = _Fila.Item("NOKOFU")

                            'Dim _Titulo = "SOLICITUD DE PERMISO REMOTO"

                            'Dim _Texto = "EXISTEN PERMISOS REMOTOS ESPERANDO PARA SU APROBACION." & vbCrLf & vbCrLf &
                            '         "PRESIONE ESTA ETIQUETA PARA REALIZAR GESTION"

                            Dim _Anotacion = _Fila.Item("Descripcion_Adicional")

                            'csNotificaciones.Notificacion.Sb_Pop_Up_Remota(0, _Titulo, _Texto, csNotificaciones.Notificacion.Imagen.Llave,
                            '                                          50, True, _Formulario, _Sonido_Beep)


                            csNotificaciones.Notificacion.Fx_Insertar_Notificacion(_Kofu,
                                               FUNCIONARIO, "Enviado por: " & _Nokofu,
                                               "SOLICITUD REMOTA Nro: " & _NroRemota & ")" & vbCrLf &
                                               "Información: " & _Anotacion,
                                               csNotificaciones.Notificacion.Imagen.Llave, _NroRemota, False, 0, True, 0, False, "", "", "")


                        Next

                        'csNotificaciones.Notificacion._Acumulado_Permiso_Remoto_Abierta = True

                    End If

                End If

                If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Notificaciones", "No_Volver_A_Notificar") Then

                    Consulta_sql = "Select Top 5 * From " & _Global_BaseBk & "Zw_Notificaciones
                                    Where Usuario_Destino = '" & FUNCIONARIO & "' And Mostrar = 1 And 
                                          Empresa = '" & ModEmpresa & "' And No_Volver_A_Notificar = 0 -- And RCadena_Id_Enc > 0
                                    Order by Id Desc"

                Else

                    Consulta_sql = "Select Top 5 * From " & _Global_BaseBk & "Zw_Notificaciones
                                    Where Usuario_Destino = '" & FUNCIONARIO & "' And Mostrar = 1 And Empresa = '" & ModEmpresa & "' --And RCadena_Id_Enc > 0
                                    Order by Id Desc"

                End If

                Dim _TblNotificaciones As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

                Dim rnd As New Random()

                If CBool(_TblNotificaciones.Rows.Count) Then

                    For Each _Fila As DataRow In _TblNotificaciones.Rows

                        Dim _Id = _Fila.Item("Id")
                        Dim _Accion = _Fila.Item("Accion")
                        Dim _Titulo = _Fila.Item("Titulo")
                        Dim _Texto = _Fila.Item("Texto")
                        Dim _NroRemota = _Fila.Item("NroRemota")

                        Dim _Tiempo_Cerrar As Integer = 10
                        Dim _Cerrar As Boolean = True
                        Dim _Enviar_Notificacion = True

                        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Remotas" & vbCrLf &
                                    "Where NroRemota = '" & _NroRemota & "'"
                        Dim _Row_Remota As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                        If Not (_Row_Remota Is Nothing) Then

                            Dim _Id_Casi_DocEnc = _Row_Remota.Item("Id_Casi_DocEnc")
                            Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Casi_DocTom",
                                                            "Id_DocEnc = " & _Id_Casi_DocEnc)

                            If CBool(_Reg) Then
                                _Enviar_Notificacion = False
                            End If

                        End If

                        If _Enviar_Notificacion Then

                            csNotificaciones.Notificacion.Sb_Pop_Up(_Id, _Titulo, _Texto, rnd.Next(0, 8),
                                                                _Tiempo_Cerrar, _Cerrar, _Formulario, _Sonido_Beep)

                        End If

                    Next

                Else


                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set Mostrar = 1
                                        Where Id In 
                                        (Select Id From " & _Global_BaseBk & "Zw_Notificaciones
                                        Where Usuario_Destino = '" & FUNCIONARIO & "' And Mostrar = 0 And Autorizado = 1 And Rechazado = 1 And 
                                        NroRemota In (Select NroRemota From " & _Global_BaseBk & "Zw_Remotas 
                                            Where Otorga = '' And Id_Casi_DocEnc In (Select Id_DocEnc From " & _Global_BaseBk & "Zw_Casi_DocEnc)))"

                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

                Consulta_sql = "Select Distinct Empresa,RUT,RAZON 
                                    From " & _Global_BaseBk & "Zw_Notificaciones
                                        Inner Join CONFIGP On Empresa = EMPRESA
                                    Where Usuario_Destino = '" & FUNCIONARIO & "' And Mostrar = 1 And RCadena_Id_Enc > 0 And Empresa <> '" & ModEmpresa & "'"

                _TblNotificaciones = _Sql.Fx_Get_DataTable(Consulta_sql, False)

                If CBool(_TblNotificaciones.Rows.Count) Then

                    Dim _Titulo = "PERMISOS OTRAS EMPRESAS"
                    Dim _Texto = "REVISE LA(S) SIGUIENTE(S) EMPRESA(S):" & vbCrLf & vbCrLf

                    For Each _Fila As DataRow In _TblNotificaciones.Rows

                        Dim _Empresa = _Fila.Item("Empresa")
                        Dim _Rut = _Fila.Item("RUT")
                        Dim _Razon = _Fila.Item("RAZON").ToString.Trim

                        _Texto += _Empresa & " - " & _Rut & " - " & _Razon & vbCrLf

                    Next

                    Dim _Tiempo_Cerrar As Integer = 10
                    Dim _Cerrar As Boolean = True

                    'csNotificaciones.Notificacion.Sb_Pop_Up(0, _Titulo, _Texto, csNotificaciones.Notificacion.Imagen.Internet,
                    '                                                _Tiempo_Cerrar, _Cerrar, _Formulario)

                    Dim _Notificacion = _Titulo & vbCrLf & vbCrLf & _Texto

                    CType(_Formulario, Frm_Notificaciones).Notify_Notificaciones.ShowBalloonTip(5, "Info. BakApp",
                                                                                                _Notificacion,
                                                                                                ToolTipIcon.Info)

                    'Else

                    '    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Notificaciones Set Mostrar = 1
                    '                        Where Id In 
                    '                        (Select Id From " & _Global_BaseBk & "Zw_Notificaciones
                    '                        Where Usuario_Destino = '" & FUNCIONARIO & "' And Mostrar = 0 And Autorizado = 1 And Rechazado = 1 And 
                    '                        NroRemota In (Select NroRemota From " & _Global_BaseBk & "Zw_Remotas 
                    '                            Where Otorga = '' And Id_Casi_DocEnc In (Select Id_DocEnc From " & _Global_BaseBk & "Zw_Casi_DocEnc)))"

                    '    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

                Dim _Permisos_Aceptados As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Notificaciones",
                                                "Mostrar = 1 And Accion In ('Ok','Rechazado') And Usuario_Destino = '" & FUNCIONARIO & "' And Empresa = '" & ModEmpresa & "'")

                If CBool(_Permisos_Aceptados) Then

                    Dim _Titulo = "DOCUMENTOS GESTIONADOS"
                    Dim _Texto = "EXISTEN PERMISOS ACEPTADOS O RECHAZADOS." & vbCrLf &
                             "DEBE REVISAR LOS DOCUMENTOS EN ESTADO PENDIENTES DESDE EL" & vbCrLf &
                             "FORMULARIO DE CREACION DE NOTAS DE VENTA u ORDENES DE COMPRA"

                    csNotificaciones.Notificacion.Sb_Pop_Up(0, _Titulo, _Texto, csNotificaciones.Notificacion.Imagen.Informacion,
                                                          10, True, _Formulario)

                    'Dim _Notificacion = _Titulo & vbCrLf & vbCrLf & _Texto

                    'CType(_Formulario, Frm_Notificaciones).Notify_Notificaciones.ShowBalloonTip(5, "Info. BakApp",
                    '                                                        _Notificacion,
                    '                                                        ToolTipIcon.Info)

                End If

            End If

        End If

    End Sub

    Sub Sb_Revisar_Notificaciones_SolComProd(_Revisar_todas As Boolean, _Sonido_Beep As Boolean)

        If _Global_Notificaciones Then

            _Sql = New Class_SQL(Cadena_ConexionSQL_Server)

            Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

            If _Revisar_todas Then ' cada 5 minutos aparecera

                If Not Fx_Tiene_Permiso(_Formulario, "Prod060",, False) Then
                    Return
                End If

                Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Notificaciones",
                                                    "Id_SCom In (Select Id_SCom From " & _Global_BaseBk & "Zw_Prod_SolCompra " &
                                                    "Where Estado Not in ('','RPD')) And Usuario_Destino = '" & FUNCIONARIO & "'")

                If Convert.ToBoolean(_Reg) Then

                    Dim _Titulo = "SOLICITUD DE PRODUCTOS PARA COMPRA"
                    Dim _Texto As String

                    If _Reg = 1 Then
                        _Texto = "EXISTE 1 REGISTRO PARA COMPRAR EN LA LISTA DE SOLICITUDES" & Environment.NewLine &
                                     "HAGA CLIC SOBRE ESTE MENSAJE PARA VER EL LISTADO..."
                    Else
                        _Texto = "EXISTEN " & _Reg & " REGISTROS PARA COMPRAR EN LA LISTA DE SOLICITUDES" & Environment.NewLine &
                                     "HAGA CLIC SOBRE ESTE MENSAJE PARA VER EL LISTADO..."
                    End If

                    csNotificaciones.Notificacion.Sb_Pop_Up_SolComProd(0, _Titulo, _Texto,
                                                                        csNotificaciones.Notificacion.Imagen.Tarea,
                                                                          60, True, _Formulario,, _Sonido_Beep)

                    csNotificaciones.Notificacion._Acumulado_SolComProd_Abierta = True

                End If

                _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_SolCompra",
                                                             "Estado = 'RPD' And CodFun_Solicita = '" & FUNCIONARIO & "' And Visto = 0")

                If Convert.ToBoolean(_Reg) Then

                    Dim _Titulo = "SOLICITUD DE PRODUCTOS PARA COMPRA"
                    Dim _Texto As String

                    If Convert.ToBoolean(_Reg) Then
                        _Texto = "EXISTEN REGISTROS DATOS QUE REVISAR EN SUS SOLICITUDES DE PRODUCTOS..."
                    End If

                    csNotificaciones.Notificacion.Sb_Pop_Up_SolComProd(0, _Titulo, _Texto,
                                                                          csNotificaciones.Notificacion.Imagen.Informacion,
                                                                          60, True, _Formulario, True, _Sonido_Beep)

                    'Dim _Notificacion = _Titulo & vbCrLf & vbCrLf & _Texto

                    'CType(_Formulario, Frm_Notificaciones).Notify_Notificaciones.ShowBalloonTip(5, "Info. BakApp",
                    '                                                        _Notificacion,
                    '                                                        ToolTipIcon.Info)

                    csNotificaciones.Notificacion._Acumulado_SolComProd_Abierta = True

                End If

            Else

                If csNotificaciones.Notificacion._Acumulado_SolComProd_Abierta = True Then
                    Return
                End If

                Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Notificaciones
                                    Where Usuario_Destino = '" & FUNCIONARIO & "' And Mostrar = 1 And Id_SCom > 0
                                    Order by Id"

                Dim _TblNotificaciones As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

                If CBool(_TblNotificaciones.Rows.Count) Then

                    Dim rnd As New Random()

                    For Each _Fila As DataRow In _TblNotificaciones.Rows

                        Dim _Id = _Fila.Item("Id")
                        Dim _Accion = _Fila.Item("Accion")
                        Dim _Titulo = _Fila.Item("Titulo")
                        Dim _Texto = _Fila.Item("Texto")
                        Dim _NroRemota = _Fila.Item("NroRemota")

                        csNotificaciones.Notificacion.Sb_Pop_Up_SolComProd(_Id, _Titulo, _Texto,
                                                                               csNotificaciones.Notificacion.Imagen.Tarea,
                                                                               25, True, _Formulario)

                    Next

                End If

            End If

        End If

    End Sub

End Class
