Imports BkSpecialPrograms

Public Class Cl_Notificaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _NombreEquipo As String
    Dim _Mos_Notif_X_CdPermiso As Boolean

    Dim _Remotas_Activas As Boolean

    Public Property Remotas_Activas As Boolean
        Get
            Return _Remotas_Activas
        End Get
        Set(value As Boolean)
            _Remotas_Activas = value
        End Set
    End Property

    Public Sub New()

        _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")
        _Mos_Notif_X_CdPermiso = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_EstacionesBkp", "Mos_Notif_X_CdPermiso",
                                                                      "NombreEquipo = '" & _NombreEquipo & "'")

    End Sub

    Sub Sb_Revisar_Notificaciones_Remotas(_Formulario As Form, _Revisar_todas As Boolean)

        If csNotificaciones.Notificacion._Revisando_Permiso_Remoto Then
            Return
        End If

        If _Global_Notificaciones Then

            If _Mos_Notif_X_CdPermiso Then

                If _Revisar_todas Then

                    'Muestra permisos remotos que estan en espera, pero que no son cadenas remotas.

                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Remotas 
                                    Where 1 > 0 And NroRemota In (Select  NroRemota From " & _Global_BaseBk & "Zw_Notificaciones 
                                        Where Usuario_Destino = '" & FUNCIONARIO & "' And Accion = 'Remota') And Otorga = '' And Eliminada = 0 And RCadena_Id_Enc = 0"

                    Dim _TblRemotas_Pendientes As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql, False)

                    If CBool(_TblRemotas_Pendientes.Rows.Count) Then

                        Dim _Titulo = "SOLICITUDES REMOTAS PENDIENTES" '= _Fila.Item("Titulo")
                        Dim _Texto = "EXISTEN PERMISOS REMOTOS ESPERANDO PARA SU APROBACION." & vbCrLf & vbCrLf &
                                     "PRECIONE ESTA ETIQUETA PARA REALIZAR GESTION"

                        csNotificaciones.Notificacion.Sb_Pop_Up_Remota(0, _Titulo, _Texto, csNotificaciones.Notificacion.Imagen.Llave,
                                                                      50, True, _Formulario)

                        csNotificaciones.Notificacion._Acumulado_Permiso_Remoto_Abierta = True

                    End If

                Else

                    If csNotificaciones.Notificacion._Acumulado_Permiso_Remoto_Abierta = True Then
                        Return
                    End If

                    Consulta_sql = "Select Top 5 * From " & _Global_BaseBk & "Zw_Notificaciones
                                Where Usuario_Destino = '" & FUNCIONARIO & "' And Mostrar = 1 And RCadena_Id_Enc > 0
                                Order by Id Desc"

                    Dim _TblNotificaciones As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql, False)

                    If CBool(_TblNotificaciones.Rows.Count) Then

                        Dim rnd As New Random()

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
                                                                        _Tiempo_Cerrar, _Cerrar, _Formulario)

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

                    Dim _Permisos_Aceptados As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Notificaciones",
                                                                              "Mostrar = 1 And Accion In ('Ok','Rechazado') And Usuario_Destino = '" & FUNCIONARIO & "'")

                    If CBool(_Permisos_Aceptados) Then

                        Dim _Titulo = "DOCUMENTOS GESTIONADOS"
                        Dim _Texto = "EXISTEN PERMISOS ACEPTADOS O RECHAZADOS." & Environment.NewLine &
                                     "DEBE REVISAR LOS DOCUMENTOS EN ESTADO PENDIENTES DESDE EL FORMULARIO DE CREACION DE NOTAS DE VENTA"
                        csNotificaciones.Notificacion.Sb_Pop_Up(0, _Titulo, _Texto, csNotificaciones.Notificacion.Imagen.Informacion,
                                                                  10, True, _Formulario)

                    End If

                End If

            End If

        End If

    End Sub

    Sub Sb_Revisar_Notificaciones_SolComProd(_Formulario As Form, _Revisar_todas As Boolean)

        If csNotificaciones.Notificacion._Revisando_SolComProd Then
            Return
        End If

        If _Global_Notificaciones Then

            If _Mos_Notif_X_CdPermiso Then

                If _Revisar_todas Then ' cada 5 minutos aparecera

                    If Not Fx_Tiene_Permiso(_Formulario, "Prod060",, False) Then
                        Return
                    End If

                    Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_SolCompra",
                                                             "Estado <> 'RPD'") ' And CodFun_Envio = '" & FUNCIONARIO & "'")

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
                                                                          60, True, _Formulario)

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
                                                                          60, True, _Formulario, True)

                        csNotificaciones.Notificacion._Acumulado_SolComProd_Abierta = True

                    End If

                Else

                    If csNotificaciones.Notificacion._Acumulado_SolComProd_Abierta = True Then
                        Return
                    End If

                    Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Notificaciones
                                    Where Usuario_Destino = '" & FUNCIONARIO & "' And Mostrar = 1 And Id_SCom > 0
                                    Order by Id"

                    Dim _TblNotificaciones As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql, False)

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

                            'Threading.Thread.Sleep(10000)

                        Next

                    End If

                End If

            End If

        End If

    End Sub


End Class
