Imports DevComponents.DotNetBar
Imports BkSpecialPrograms
Imports System.IO

Public Module Clase_Demonio

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Sub Sb_Sistema_Demonio()

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_Sql As String

        Dim _Dir_Local As String = Application.StartupPath & "\Data\"
        Dim _Row_Nom_Equipo As DataRow

        Dim _Nombre_Equipo As String = My.Computer.Name
        If Fx_Revisar_Nombre_Equipo_BakApp(Demonio, _Dir_Local & RutEmpresa & "\Configuracion_Local", RutEmpresa, _Nombre_Equipo) Then

            Dim _Ds As New DatosBakApp
            _Ds.Clear()
            _Ds.ReadXml(_Dir_Local & RutEmpresa & "\Configuracion_Local\Nombre_Equipo.xml")

            _Row_Nom_Equipo = _Ds.Tables("Tbl_Nombre_Equipo").Rows(0)
        Else
            MessageBoxEx.Show(Demonio, "Revise el nombre del equipo en la carpeta" & vbCrLf &
            _Dir_Local & RutEmpresa & "\Configuracion_Local", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End
        End If

        Dim _Mi_IP = getIp()
        _Nombre_Equipo = _Row_Nom_Equipo.Item("Nombre_Equipo") 'UCase(System.Net.Dns.GetHostName)

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_EstacionesBkp Where NombreEquipo = '" & _Nombre_Equipo & "'"
        _Global_Row_EstacionBk = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If Not (_Global_Row_EstacionBk Is Nothing) Then

            FUNCIONARIO = _Global_Row_EstacionBk.Item("Usuario_X_Defecto")
            Modalidad = _Global_Row_EstacionBk.Item("Modalidad_X_Defecto")

            If String.IsNullOrEmpty(Trim(FUNCIONARIO)) Then
                MessageBoxEx.Show(Demonio, "FALTA NOMBRE DE USUARIO POR DEFECTO Y MODALIDAD" & vbCrLf &
                                  "NOMBRE DE EQUIPO: " & _Nombre_Equipo, "VALIDACION",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Application.ExitThread()
            End If

            Dim _Mod As New Clas_Modalidades
            _Mod.Sb_Actualiza_Formatos_X_Modalidad()
            _Global_Row_Configuracion_General = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Modalidad.General, "")
            _Global_Row_Configuracion_Estacion = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Modalidad.Estacion, Modalidad)
            _Mod.Sb_Actualizar_Variables_Modalidad(Modalidad)

            Sb_Demonio(False) ', True)

        End If

    End Sub

    Sub Sb_Demonio(_Mostrar_Formulario As Boolean)

        Fx_Abrir_Demonio()

        Dim _Permiso As Boolean = True

        Try
            Demonio.Pro_Fm_Demonio.Close()
            Demonio.Pro_Fm_Demonio.Hide()
            Demonio.Pro_Fm_Demonio.Dispose()
            Demonio.Pro_Fm_Demonio = Nothing
        Catch ex As Exception

        End Try

        Demonio.Notify_Demonio.Visible = False

        Demonio.Pro_Fm_Demonio = New Frm_Demonio_01(Demonio)

        If _Mostrar_Formulario Then
            Demonio.Pro_Fm_Demonio.ShowDialog(Demonio)
            If Not Demonio.Pro_Fm_Demonio.Pro_Minimizar Then
                Application.ExitThread()
            End If
        End If

        Demonio.Pro_Fm_Demonio.Dispose()
        Demonio.Pro_Fm_Demonio = Nothing

        Demonio.Pro_Fm_Demonio = New Frm_Demonio_01(Demonio)
        Demonio.Pro_Fm_Demonio.Sb_Load()

        Dim _Demonio_Activado As Boolean = Demonio.Pro_Fm_Demonio.Pro_Demonio_Activado

        Demonio.Notify_Demonio.Visible = _Demonio_Activado

        'If _Mostrar_Notificacion Then
        Demonio.Notify_Demonio.ShowBalloonTip(5, "Info. BakApp", "Monitoreo de demonio de acciones automáticas activado",
                                                       ToolTipIcon.Info)
        'End If

        If Not Demonio.Pro_Fm_Demonio.Pro_Demonio_Activado Then
            Demonio.Pro_Fm_Demonio.Dispose()
            Demonio.Pro_Fm_Demonio = Nothing
        End If

    End Sub

    Function Fx_Abrir_Demonio()

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

        Return _Ejecutar_Automaticamente

    End Function

End Module
