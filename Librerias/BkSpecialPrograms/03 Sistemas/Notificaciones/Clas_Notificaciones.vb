Imports System.Text
Imports System.Windows.Forms
Imports System.Collections
Imports DevComponents.DotNetBar

Namespace csNotificaciones
    Public NotInheritable Class Notificacion
        Private Sub New()
        End Sub
        'Enumerado que representa las imagenes
        Public Enum Imagen
            Ok               '0
            Advertencia      '1
            [Error]          '2
            Soporte          '3
            Usuarios         '4
            Ayuda            '5
            Llave            '6
            Tarea            '7
            Internet         '8
            SinImagen        '9 
            Remota           '10
            Informacion      '11
            Confirmacion     '12
            Rechazado        '13
            Scompra_Producto '14
            Solicitud_Compra '15
        End Enum

        Public FuncionarioConPermiso() As String
        Public Shared Gestionando As Boolean

        Public Shared _Revisando_Permiso_Remoto As Boolean
        Public Shared _Revisando_SolComProd As Boolean

        Public Shared _Acumulado_SolComProd_Abierta As Boolean
        Public Shared _Acumulado_Permiso_Remoto_Abierta As Boolean

        Public Shared _Notificacion_SolComProd_Abierta As Boolean
        Public Shared _Notificacion_Permiso_Remoto_Abierta As Boolean

        Public Shared _Contador_SolComPro_Abiertas As Integer
        Public Shared _Contador_SolComPro_Permiso_Remoto_Abiertas As Integer

        Enum Enum_Tipo_Pop_Up
            Remota
            Informacion
            Sol_Compra_Producto
            Solicitud_Compra
        End Enum

        Dim _Tipo_Pop_Up As Enum_Tipo_Pop_Up

        Friend Shared listaSlots As New ArrayList()
        Friend Shared _Formularios_Notificaciones As New List(Of Form)

        Public _Formulario_Padre As Form


#Region "- Muestra un aviso -"
        ''' <summary>
        ''' Muestra un mensaje sobre la barra de tareas tipo MSN Messenger
        ''' </summary>
        ''' <param name="Titulo">Titulo del mensaje</param>
        ''' <param name="Texto">Texto del mensaje</param>
        ''' <param name="ImagenFondo">Imagen de fondo</param>
        ''' <param name="tiempoVisible">Por cuantos segundos el mensaje es visible</param>

        Public Shared Sub mostrarVentana(ByVal Titulo As String,
                                         ByVal Texto As String,
                                         ByVal ImagenFondo As Imagen,
                                         ByVal tiempoVisible As Integer,
                                         Optional ByVal _Cerrar As Boolean = False,
                                         Optional ByVal _Formulario_Padre As Form = Nothing)
            'Variables
            Dim slotAsignado As Boolean = False
            Dim posicionVertical As Integer = 0
            Dim multiplicador As Integer = 1

            '#Region "- Se asigna un slot a la nueva ventana -"
            'Le asignamos un slot a la ventana
            While slotAsignado = False
                'Calculamos la posicion del nuevo slot
                posicionVertical = Screen.PrimaryScreen.Bounds.Bottom - 30 - (80 * 2) * multiplicador

                'Verificamos si la posicion del slot ya esta ocupada. Si no,
                'Le asignamos el numero de posicion a la nueva  slot y lo
                'agregamos a la lista de slots asignados

                'MsgBox listaSlots.
                If listaSlots.Contains(posicionVertical) = False Then
                    If posicionVertical >= 34 Then '68 Then
                        listaSlots.Add(posicionVertical)
                        slotAsignado = True
                    Else

                        'Si todos los slots ya estan llenos
                        'entonces no mostramos el mensaje
                        Return
                    End If
                Else
                    'Si el slot ya esta asignado, entonces cambiamos el multiplicador
                    'y intentamos otravez
                    multiplicador += 1

                End If
            End While
            '#End Region

            '#Region "- Instancia de la nueva ventana de mensajes y asignacion de valores"
            'Creamos una nueva instancia de la ventana de mensajes
            'y le pasamos el lugar donde debe aparecer mediante el constructor
            Dim myForm As New Frm_Evento(posicionVertical, _Cerrar, 0, _Formulario_Padre, Imagen.Informacion)

            'Asignamos algunos valores al formulario de los mensajes
            myForm.Lbltexto.Text = Texto
            myForm.TiempoEspera.Interval = tiempoVisible * 1000
            '#End Region

            '#Region "- Preparamos el mensaje del titulo para ser mostrado -"
            'Si el titulo es demasiado largo, entonces le ponemos puntos suspensivos al final
            'luego del caracter 30
            If Titulo.Length > 30 Then
                Dim tmpTitulo As New StringBuilder()

                For i As Integer = 0 To 29
                    tmpTitulo.Append(Titulo(i).ToString())
                Next
                tmpTitulo.Append("...")

                myForm.lblTitulo.Text = tmpTitulo.ToString()
            Else

                'De lo contrario ponemos el titulo sin alterar
                myForm.lblTitulo.Text = Titulo
            End If
            '#End Region

            '#Region "- Se agrega la imagen seleccionada al fondo -"
            'Se pone la imagen de fondo seleccionada

            '#End Region
            'Por ultimo se muestra el aviso
            Beep()
            myForm.Show()
        End Sub

        Public Shared Sub Sb_Pop_Up(ByVal _Id As Integer,
                                    ByVal _Titulo As String,
                                    ByVal _Texto As String,
                                    ByVal _ImagenFondo As Imagen,
                                    Optional _Tiempo_Visible As Integer = 5,
                                    Optional _Cerrar As Boolean = False,
                                    Optional _Formulario_Padre As Form = Nothing,
                                    Optional _Sonido_Beep As Boolean = False,
                                    Optional _Mostrar_Cerrar As Boolean = False)
            'Variables
            Dim slotAsignado As Boolean = False
            Dim posicionVertical As Integer = 0
            Dim multiplicador As Integer = 1


            If Gestionando Then Exit Sub


            '#Region "- Se asigna un slot a la nueva ventana -"
            'Le asignamos un slot a la ventana
            While slotAsignado = False
                'Calculamos la posicion del nuevo slot
                posicionVertical = Screen.PrimaryScreen.Bounds.Bottom - 30 - (80 * 2) * multiplicador

                'Verificamos si la posicion del slot ya esta ocupada. Si no,
                'Le asignamos el numero de posicion a la nueva  slot y lo
                'agregamos a la lista de slots asignados

                'MsgBox listaSlots.
                If listaSlots.Contains(posicionVertical) = False Then
                    If posicionVertical >= 34 Then
                        listaSlots.Add(posicionVertical)
                        slotAsignado = True
                    Else

                        'Si todos los slots ya estan llenos
                        'entonces no mostramos el mensaje
                        Return
                    End If
                Else
                    'Si el slot ya esta asignado, entonces cambiamos el multiplicador
                    'y intentamos otravez
                    multiplicador += 1

                End If
            End While
            '#End Region

            '#Region "- Instancia de la nueva ventana de mensajes y asignacion de valores"
            'Creamos una nueva instancia de la ventana de mensajes
            'y le pasamos el lugar donde debe aparecer mediante el constructor
            Dim myForm As New Frm_Evento(posicionVertical, _Cerrar, _Id, _Formulario_Padre, _ImagenFondo)

            'Asignamos algunos valores al formulario de los mensajes
            myForm.Lbltexto.Text = _Texto
            myForm.TiempoEspera.Interval = _Tiempo_Visible * 1000
            myForm.Mostrar_Cerrar = _Mostrar_Cerrar
            '#End Region

            '#Region "- Preparamos el mensaje del titulo para ser mostrado -"
            'Si el titulo es demasiado largo, entonces le ponemos puntos suspensivos al final
            'luego del caracter 30
            If _Titulo.Length > 30 Then
                Dim tmpTitulo As New StringBuilder()

                For i As Integer = 0 To 29
                    tmpTitulo.Append(_Titulo(i).ToString())
                Next
                tmpTitulo.Append("...")

                myForm.lblTitulo.Text = tmpTitulo.ToString()
            Else

                'De lo contrario ponemos el titulo sin alterar
                myForm.lblTitulo.Text = _Titulo
            End If
            '#End Region

            'Por ultimo se muestra el aviso
            ' Beep()

            If _Sonido_Beep Then Beep()

            myForm.Show()

        End Sub

        Public Shared Sub Sb_Pop_Up_Remota(ByVal _Id As Integer,
                                           ByVal _Titulo As String,
                                           ByVal _Texto As String,
                                           ByVal _ImagenFondo As Imagen,
                                           Optional _Tiempo_Visible As Integer = 5,
                                           Optional _Cerrar As Boolean = False,
                                           Optional _Formulario_Padre As Form = Nothing,
                                           Optional _Sonido_Beep As Boolean = True,
                                           Optional _Mostra_Cerrar As Boolean = True)
            'Variables
            Dim slotAsignado As Boolean = False
            Dim posicionVertical As Integer = 0
            Dim multiplicador As Integer = 1

            If Gestionando Then Exit Sub

            '#Region "- Se asigna un slot a la nueva ventana -"
            'Le asignamos un slot a la ventana

            While slotAsignado = False
                'Calculamos la posicion del nuevo slot
                posicionVertical = Screen.PrimaryScreen.Bounds.Bottom - 30 - (80 * 2) * multiplicador

                'Verificamos si la posicion del slot ya esta ocupada. Si no,
                'Le asignamos el numero de posicion a la nueva  slot y lo
                'agregamos a la lista de slots asignados

                'MsgBox listaSlots.
                If listaSlots.Contains(posicionVertical) = False Then

                    If posicionVertical >= 34 Then
                        listaSlots.Add(posicionVertical)
                        slotAsignado = True
                    Else

                        'Si todos los slots ya estan llenos
                        'entonces no mostramos el mensaje
                        Return
                    End If

                Else

                    'Si el slot ya esta asignado, entonces cambiamos el multiplicador
                    'y intentamos otravez
                    multiplicador += 1

                End If

            End While
            '#End Region

            '#Region "- Instancia de la nueva ventana de mensajes y asignacion de valores"
            'Creamos una nueva instancia de la ventana de mensajes
            'y le pasamos el lugar donde debe aparecer mediante el constructor

            Dim myForm As New Frm_Evento(posicionVertical, _Cerrar, _Id, _Formulario_Padre, Imagen.Informacion)
            myForm.Pro_Abrir_Permisos_Remotos = True
            'Asignamos algunos valores al formulario de los mensajes
            myForm.Lbltexto.Text = _Texto
            myForm.TiempoEspera.Interval = _Tiempo_Visible * 1000
            myForm.Mostrar_Cerrar = _Mostra_Cerrar
            '#End Region

            '#Region "- Preparamos el mensaje del titulo para ser mostrado -"
            'Si el titulo es demasiado largo, entonces le ponemos puntos suspensivos al final
            'luego del caracter 30
            If _Titulo.Length > 30 Then
                Dim tmpTitulo As New StringBuilder()

                For i As Integer = 0 To 29
                    tmpTitulo.Append(_Titulo(i).ToString())
                Next
                tmpTitulo.Append("...")

                myForm.lblTitulo.Text = tmpTitulo.ToString()
            Else

                'De lo contrario ponemos el titulo sin alterar
                myForm.lblTitulo.Text = _Titulo
            End If
            '#End Region

            '#Region "- Se agrega la imagen seleccionada al fondo -"
            'Se pone la imagen de fondo seleccionada
            '#End Region
            'Por ultimo se muestra el aviso

            If _Sonido_Beep Then Beep()

            myForm.Show()

        End Sub

        Public Shared Sub Sb_Pop_Up_SolComProd(_Id As Integer,
                                               _Titulo As String,
                                               _Texto As String,
                                               _Accion_Imagen_Fondo As Imagen,
                                               Optional _Tiempo_Visible As Integer = 5,
                                               Optional _Cerrar As Boolean = False,
                                               Optional _Formulario_Padre As Form = Nothing,
                                               Optional _Mis_Solicitudes As Boolean = False,
                                               Optional _Sonido_Beep As Boolean = True)
            'Variables
            Dim slotAsignado As Boolean = False
            Dim posicionVertical As Integer = 0
            Dim multiplicador As Integer = 1

            'If Gestionando Then Exit Sub

            '#Region "- Se asigna un slot a la nueva ventana -"
            'Le asignamos un slot a la ventana
            While slotAsignado = False
                'Calculamos la posicion del nuevo slot
                posicionVertical = Screen.PrimaryScreen.Bounds.Bottom - 30 - (80 * 2) * multiplicador

                'Verificamos si la posicion del slot ya esta ocupada. Si no,
                'Le asignamos el numero de posicion a la nueva  slot y lo
                'agregamos a la lista de slots asignados

                'MsgBox listaSlots.
                If listaSlots.Contains(posicionVertical) = False Then
                    If posicionVertical >= 34 Then
                        listaSlots.Add(posicionVertical)
                        slotAsignado = True
                    Else

                        'Si todos los slots ya estan llenos
                        'entonces no mostramos el mensaje
                        Return
                    End If
                Else
                    'Si el slot ya esta asignado, entonces cambiamos el multiplicador
                    'y intentamos otravez
                    multiplicador += 1

                End If
            End While
            '#End Region

            '#Region "- Instancia de la nueva ventana de mensajes y asignacion de valores"
            'Creamos una nueva instancia de la ventana de mensajes
            'y le pasamos el lugar donde debe aparecer mediante el constructor


            Dim myForm As New Frm_Evento(posicionVertical, _Cerrar, _Id, _Formulario_Padre, Imagen.Informacion)
            myForm.Pro_Abrir_SolCom_Productos = True
            'Asignamos algunos valores al formulario de los mensajes
            myForm.Lbltexto.Text = _Texto
            myForm.TiempoEspera.Interval = _Tiempo_Visible * 1000
            '#End Region

            '#Region "- Preparamos el mensaje del titulo para ser mostrado -"
            'Si el titulo es demasiado largo, entonces le ponemos puntos suspensivos al final
            'luego del caracter 30
            If _Titulo.Length > 50 Then
                Dim tmpTitulo As New StringBuilder()

                For i As Integer = 0 To 50
                    tmpTitulo.Append(_Titulo(i).ToString())
                Next
                tmpTitulo.Append("...")

                myForm.lblTitulo.Text = tmpTitulo.ToString()
            Else

                'De lo contrario ponemos el titulo sin alterar
                myForm.lblTitulo.Text = _Titulo
            End If
            '#End Region
            'Por ultimo se muestra el aviso
            If _Sonido_Beep Then Beep()
            myForm.Show()

        End Sub

#End Region

        Public Shared Function Fx_Insertar_Notificacion(_Usuario_Solicita As String,
                                                        _Usuario_Destino As String,
                                                        _Titulo As String,
                                                        _Texto As String,
                                                        _Accion As Imagen,
                                                        _NroRemota As String,
                                                        _Solicita_Confirmacion As Boolean,
                                                        _Id_Respuesta As Integer,
                                                        _Mostrar As Boolean,
                                                        _RCadena_Id_Enc As Integer,
                                                        _Enviar_Correo As Boolean,
                                                        _Nombre_Usuario_Correo_Remotas As String,
                                                        _Asunto As String,
                                                        _Para As String) As Boolean

            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

            Dim _Empresas As Integer = _Sql.Fx_Cuenta_Registros("CONFIGP", "")

            If _Empresas > 1 Then
                _Texto = "Empresa: " & _Global_Row_Modalidad.Item("RAZON").ToString.Trim & vbCrLf & _Texto
            End If

            Dim _Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Notificaciones (Empresa,Usuario_Solicita,Usuario_Destino,Titulo,Texto,Accion," &
                                "NroRemota,Solicita_Confirmacion,IdRespuesta,Fecha,Hora,Mostrar,RCadena_Id_Enc) Values " & vbCrLf &
                                "('" & Mod_Empresa & "','" & _Usuario_Solicita & "','" & _Usuario_Destino & "','" & _Titulo & "','" & _Texto & "'," &
                                "'" & _Accion.ToString & "','" & _NroRemota & "'," & Convert.ToInt32(_Solicita_Confirmacion) &
                                "," & _Id_Respuesta & ",Getdate(),Getdate()," & Convert.ToInt32(_Mostrar) & "," & _RCadena_Id_Enc & ")"

            If Not String.IsNullOrEmpty(_NroRemota) Then

                If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Remotas_Notif") Then

                    Dim _Usuario_Sol = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Remotas_En_Cadena_01_Enc", "Usuario_Solicita", "Id_Enc = " & _RCadena_Id_Enc)

                    If _Usuario_Sol <> _Usuario_Destino Then

                        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Remotas_Notif",
                                                            "NroRemota = '" & _NroRemota & "' And CodFuncionario_Destino = '" & _Usuario_Destino & "'")

                        If _Reg = 0 Then
                            _Consulta_sql += vbCrLf & "Insert Into " & _Global_BaseBk & "Zw_Remotas_Notif (NroRemota,CodFuncionario_Destino) " &
                                        "Values ('" & _NroRemota & "','" & _Usuario_Destino & "')"
                        End If

                    End If

                End If

            End If

            If _Enviar_Correo Then
                If Not String.IsNullOrEmpty(_Para.Trim) Then
                    Fx_Enviar_Notificacion_X_Correo(_Nombre_Usuario_Correo_Remotas, _Para, _Asunto, _Texto)
                End If
            End If

            Return _Sql.Ej_consulta_IDU(_Consulta_sql)

        End Function

        Public Shared Function Fx_Insertar_Notificacion_SCom_Pr(ByVal _Id_SCom As Integer,
                                                                ByVal _Usuario_Solicita As String,
                                                                ByVal _Usuario_Destino As String,
                                                                ByVal _Titulo As String,
                                                                ByVal _Texto As String,
                                                                ByVal _Mostrar As Boolean) As Boolean

            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

            Dim _Accion As Imagen = Imagen.Scompra_Producto

            Dim _Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Notificaciones (Empresa,Usuario_Solicita,Usuario_Destino,Titulo,Texto,Accion," &
                                "Fecha,Hora,Mostrar,Id_SCom) Values " & vbCrLf &
                                "('" & Mod_Empresa & "','" & _Usuario_Solicita & "','" & _Usuario_Destino & "','" & _Titulo & "','" & _Texto & "'," &
                                "'" & _Accion.ToString & "',Getdate(),Getdate()," & Convert.ToInt32(_Mostrar) & "," & _Id_SCom & ")"

            Return _Sql.Ej_consulta_IDU(_Consulta_sql)

        End Function


        Private Shared Sub Fx_Enviar_Notificacion_X_Correo(_Nombre_Usuario_Correo_Remotas As String,
                                                           _Para As String,
                                                           _Asunto As String,
                                                           _CuerpoMensaje As String)

            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
            Dim Consulta_sql As String

            'Dim _Nombre_Correo = _Global_Row_Configuracion_General.Item("Nombre_Correo_Remotas")

            Consulta_sql = "Select Nombre_Usuario,Contrasena,Host,Puerto,SSL From " & _Global_BaseBk & "Zw_Correos_Cuentas" & vbCrLf &
                           "Where Nombre_Usuario = '" & _Nombre_Usuario_Correo_Remotas & "'"
            Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Correo) Then

                Dim _Crea_Html As New Clase_Crear_Documento_Htm
                Dim _Ruta_Html As String = AppPath() & "\Data\" & RutEmpresa & "\Tmp"

                Dim _Error

                Dim _Remitente = Trim(_Row_Correo.Item("Nombre_Usuario"))
                Dim _Host = Trim(_Row_Correo.Item("Host"))
                Dim _Puerto = Trim(_Row_Correo.Item("Puerto"))
                Dim _Contrasena = Trim(_Row_Correo.Item("Contrasena"))

                _CuerpoMensaje = Replace(_CuerpoMensaje, Chr(13), "<br/>")

                Dim _SSL = _Row_Correo.Item("SSL")

                'If _Tipo_Documento = csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta Then
                '    _Asunto = "Solicitud de permiso remoto... " & _Nombre_Usuario_Solicita & ". Bakapp VENTA"
                'ElseIf _Tipo_Documento = csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Compra Then
                '    _Asunto = "Solicitud de permiso remoto... " & _Nombre_Usuario_Solicita & ". Bakapp COMPRA"
                'End If

                Dim EnviarCorreo As New Frm_Correos_Conf

                Dim _Correo_Enviado As Boolean = EnviarCorreo.Fx_Enviar_Mail(_Host,
                                                                             _Remitente,
                                                                             _Contrasena,
                                                                             _Para,
                                                                             "",
                                                                             _Asunto,
                                                                             _CuerpoMensaje,
                                                                             Nothing,
                                                                             _Puerto,
                                                                             _SSL,
                                                                             False)

                _Error = EnviarCorreo.Pro_Error
                _Error = Replace(_Error, "'", "''")
                EnviarCorreo.Dispose()

            End If


        End Sub

        Public Shared Function Fx_Cerrar_Formularios_Notificaciones()
            For Each frm As Frm_Evento In _Formularios_Notificaciones
                frm.Sb_Solo_Cerrar()
            Next
        End Function

    End Class



End Namespace

