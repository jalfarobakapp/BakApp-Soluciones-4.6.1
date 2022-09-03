Imports DevComponents.DotNetBar
Imports BkSpecialPrograms

Module Modulo_Notificaciones

    Sub Sb_Ejecutar_Notificaciones(Formulario As Form, _Mostrar_Mensaje As Boolean)

        Dim ejecutando As Process() = Process.GetProcessesByName(_Global_Nombre_BakApp_Notificaciones)

        If ejecutando.Length > 0 Then

            For Each prog As Process In Process.GetProcesses
                If UCase(prog.ProcessName) = UCase(_Global_Nombre_BakApp_Notificaciones) Then
                    prog.Kill()
                End If
            Next

        End If

        If System.IO.File.Exists(Application.StartupPath & "\" & _Global_Nombre_BakApp_Notificaciones & ".exe") Then

            Dim _Cadena_ConexionSQL_Server_Actual As String = Replace(Cadena_ConexionSQL_Server, " ", "@")
            Dim _Ejecutar As String = Application.StartupPath & "\" & _Global_Nombre_BakApp_Notificaciones & ".exe" & Space(1) &
                                    _Cadena_ConexionSQL_Server_Actual

            Try

                Shell(_Ejecutar, AppWinStyle.NormalFocus, False)

            Catch ex As Exception
                MessageBoxEx.Show(Formulario,
                        ex.Message, "Notificaciones", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try

        Else

            MessageBoxEx.Show(Formulario,
                        "No se encontro el archivo BakApp_Notificaciones.exe en el directorio (" & Application.StartupPath & ")",
                        "Demonio", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

End Module
