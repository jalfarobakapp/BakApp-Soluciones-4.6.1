Imports System.IO
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Module Clas_Demonio

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    'Function Fx_Equipo_Registrado(ByVal _NombreEquipo As String) As Boolean

    '    Dim _Registro As New Frm_Licencia_Empresa
    '    KeyReg = UCase(Trim(RutEmpresa) & "@" & _NombreEquipo)
    '    KeyReg = Encripta_md5(KeyReg)


    '    Dim _RegKeyReg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_EstacionesBkp",
    '                                                       "NombreEquipo = '" & _NombreEquipo & "'"))

    '    If _RegKeyReg Then
    '        Return True
    '    Else

    '        MessageBoxEx.Show(DteMonitor, "Esta estación de trabajo no esta registrada, debe registrar", "Registro de estación",
    '                          MessageBoxButtons.OK, MessageBoxIcon.Stop)

    '        Dim FmReg As New Frm_RegistrarEquipo(Frm_RegistrarEquipo.Enum_Accion.Nuevo, 0, False)
    '        FmReg.ShowDialog(DteMonitor)
    '        FmReg.Dispose()

    '    End If

    'End Function

    Sub Sb_Sistema_Demonio_DTE(_Formulario As Form)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_Sql As String

        Dim _Class_BaseBk = New Class_Conectar_Base_BakApp(_Formulario)

        If _Class_BaseBk.Pro_Existe_Base Then

            _Global_BaseBk = _Class_BaseBk.Pro_Row_Tabcarac.Item("Global_BaseBk")

        End If



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

        If Fx_Revisar_Nombre_Equipo_BakApp(DteMonitor, _Dir_Local & RutEmpresa & "\Configuracion_Local", RutEmpresa, _Nombre_Equipo) Then

            Dim _Ds As New DatosBakApp
            _Ds.Clear()
            _Ds.ReadXml(_Dir_Local & RutEmpresa & "\Configuracion_Local\Nombre_Equipo.xml")

            _Row_Nom_Equipo = _Ds.Tables("Tbl_Nombre_Equipo").Rows(0)
        Else
            MessageBoxEx.Show(DteMonitor, "Revise el nombre del equipo en la carpeta" & vbCrLf &
            _Dir_Local & RutEmpresa & "\Configuracion_Local", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End
        End If

        Dim _Mi_IP '= getIp()
        _Nombre_Equipo = _Row_Nom_Equipo.Item("Nombre_Equipo") 'UCase(System.Net.Dns.GetHostName)

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_EstacionesBkp Where NombreEquipo = '" & _Nombre_Equipo & "'"
        _Global_Row_EstacionBk = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If Not (_Global_Row_EstacionBk Is Nothing) Then

            FUNCIONARIO = _Global_Row_EstacionBk.Item("Usuario_X_Defecto")
            Modalidad = _Global_Row_EstacionBk.Item("Modalidad_X_Defecto").ToString.Trim
            ModEmpresa = _Global_Row_EstacionBk.Item("Empresa_X_Defecto").ToString.Trim

            If String.IsNullOrEmpty(FUNCIONARIO.Trim) Or String.IsNullOrEmpty(Modalidad) Or String.IsNullOrEmpty(ModEmpresa) Then

                FUNCIONARIO = String.Empty

                MessageBoxEx.Show(DteMonitor, "FALTA NOMBRE DE USUARIO POR DEFECTO / MODALIDAD / EMPRESA" & vbCrLf &
                                  "NOMBRE DE EQUIPO: " & _Nombre_Equipo, "VALIDACION",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Dim Fml As New Frm_Login
                Fml.ShowDialog()
                Fml.Dispose()

                If Not String.IsNullOrEmpty(Trim(FUNCIONARIO)) Then

                    Dim Frm_Modalidad As New Frm_Modalidades(False)
                    Frm_Modalidad.ShowDialog()
                    Frm_Modalidad.Dispose()

                    If MessageBoxEx.Show(_Formulario, "¿Desea dejar a este funcionario permanentemente como usuario por defecto para la estación de trabajo?" & vbCrLf & vbCrLf &
                                         "Usuario: " & FUNCIONARIO & "-" & Nombre_funcionario_activo.Trim & " Modalidad: " & Modalidad,
                                         "Usuario por defecto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set " &
                                       "Empresa_X_Defecto = '" & ModEmpresa & "',Usuario_X_Defecto = '" & FUNCIONARIO & "', Modalidad_X_Defecto = '" & Modalidad & "'" & vbCrLf &
                                       "Where NombreEquipo = '" & _Nombre_Equipo & "'"
                        _Sql.Ej_consulta_IDU(Consulta_Sql)

                    End If

                Else

                    Application.ExitThread()

                End If

            End If

            Dim _Mod As New Clas_Modalidades
            _Mod.Sb_Actualiza_Formatos_X_Modalidad()
            _Global_Row_Configuracion_General = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.General, "")
            _Global_Row_Configuracion_Estacion = _Mod.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.Estacion, Modalidad)
            _Mod.Sb_Actualizar_Variables_Modalidad(Modalidad)

        End If

    End Sub


End Module
