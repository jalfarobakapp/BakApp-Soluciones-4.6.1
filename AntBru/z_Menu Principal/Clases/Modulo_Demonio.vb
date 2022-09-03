Imports DevComponents.DotNetBar
Imports BkSpecialPrograms
Imports System.IO

Module Modulo_Demonio

    Sub Sb_Demonio(_Mostrar_Mensaje As Boolean, Optional _Ejecutar_Demonio As Boolean = False)

        Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Demonio"
        Dim _Datos_Conf As New Ds_Config_Picking

        If Not Directory.Exists(_Path) Then
            System.IO.Directory.CreateDirectory(_Path)
        End If

        _Datos_Conf.Clear()
        Dim exists = System.IO.File.Exists(_Path & "\Config_Local.xml")
        With _Datos_Conf
            If Not exists Then

                Dim NewFila As DataRow
                NewFila = _Datos_Conf.Tables("Tbl_Configuracion").NewRow

                With NewFila

                    .Item("Impresora") = String.Empty
                    .Item("RutaImagen") = String.Empty

                End With

                .Tables("Tbl_Configuracion").Rows.Add(NewFila)

                .WriteXml(_Path & "\Config_Local.xml")

            End If
        End With

        _Datos_Conf.Clear()
        _Datos_Conf.ReadXml(_Path & "\Config_Local.xml")

        Dim _Fila As DataRow = _Datos_Conf.Tables("Tbl_Configuracion").Rows(0)
        Dim _Ejecutar_Automaticamente As Boolean = NuloPorNro(_Fila.Item("Ejecutar_Automaticamente"), False)

        'If _Ejecutar_Demonio Then _Ejecutar_Automaticamente = True

        If _Ejecutar_Automaticamente Then
            Fx_Ejecutar_Demonio2(Frm_Menu, _Mostrar_Mensaje)
        End If

        'Fx_Ejecutar_Demonio(Frm_Menu, _Mostrar_Mensaje)

    End Sub

    Function Fx_Ejecutar_Demonio2(Formulario As Form, _Mostrar_Mensaje As Boolean) As Boolean

        Dim ejecutando As Process() = Process.GetProcessesByName(_Global_Nombre_BakApp_Demonio)

        If ejecutando.Length > 0 Then

            If _Mostrar_Mensaje Then
                MessageBoxEx.Show(Formulario, "la aplicación se está ejecutando" & vbCrLf & "revise la barra de tareas",
                              "Demonio BakApp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

            Return False

        Else

            If System.IO.File.Exists(Application.StartupPath & "\" & _Global_Nombre_BakApp_Demonio & ".exe") Then

                Dim _Cadena_ConexionSQL_Server_Actual As String = Replace(Cadena_ConexionSQL_Server, " ", "@")
                Dim _Ejecutar As String = Application.StartupPath & "\BakApp_Demonio.exe" & Space(1) & _Cadena_ConexionSQL_Server_Actual

                Try
                    Shell(_Ejecutar, AppWinStyle.NormalFocus, False)
                    Return True
                Catch ex As Exception
                    MessageBoxEx.Show(Formulario,
                        ex.Message, "Demonio", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Try

            Else

                MessageBoxEx.Show(Formulario,
                        "No se encontro el archivo BakApp_Demonio.exe en el directorio (" & Application.StartupPath & ")",
                        "Demonio", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False

            End If

        End If

    End Function

    Sub Sb_Ejecutar_DTEMonitor(Formulario As Form, _Mostrar_Mensaje As Boolean)

        Dim ejecutando As Process() = Process.GetProcessesByName(_Global_Nombre_BakApp_DTEMonitor)

        If ejecutando.Length > 0 Then

            If _Mostrar_Mensaje Then
                MessageBoxEx.Show(Formulario, "la aplicación se está ejecutando" & vbCrLf & "revise la barra de tareas",
                              "BakApp DTEMonitor", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Else

            If Not _Global_Row_EstacionBk.Item("EsDTEMonitor") Then
                MessageBoxEx.Show(Formulario, "Este computador no es el DTEMonitor",
                              "BakApp DTEMonitor", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If System.IO.File.Exists(Application.StartupPath & "\" & _Global_Nombre_BakApp_DTEMonitor & ".exe") Then

                Dim _Cadena_ConexionSQL_Server_Actual As String = Replace(Cadena_ConexionSQL_Server, " ", "@")
                Dim _Ejecutar As String = Application.StartupPath & "\BakApp_DTEMonitor.exe" & Space(1) & _Cadena_ConexionSQL_Server_Actual

                Try
                    Shell(_Ejecutar, AppWinStyle.NormalFocus, False)
                Catch ex As Exception
                    MessageBoxEx.Show(Formulario,
                        ex.Message, "DTEMonitor", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Try

            Else

                MessageBoxEx.Show(Formulario,
                        "No se encontro el archivo BakApp_DTEMonitor.exe en el directorio (" & Application.StartupPath & ")",
                        "Demonio", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        End If

    End Sub

End Module
