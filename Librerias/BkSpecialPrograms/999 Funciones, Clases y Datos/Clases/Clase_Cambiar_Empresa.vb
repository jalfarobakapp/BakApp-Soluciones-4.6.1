Imports DevComponents.DotNetBar

Public Class Clase_Cambiar_Empresa

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Formulario As Form
    Dim _Funcionario As String
    ' Dim _Pwfu As String
    Dim _Conexion_establecida As Boolean
    Dim _Cadena_ConexionSQL_Server_Original = Cadena_ConexionSQL_Server
    Dim _Cadena_ConexionSQL_Seleccionada = String.Empty

    Public Sub New(Formulario As Form)
        _Formulario = Formulario
        ' _Funcionario = Funcionario
        '_Pwfu = Trim(_Sql.Fx_Trae_Dato(, "PWFU", "TABFU", "KOFU = '" & _Funcionario & "'"))
    End Sub


    Enum Tipo_de_cambio
        Cambiar_totalmente
        Cambiar_solo_formulario_activo
    End Enum

    Function Fx_Cambiar_Empresa_Solo_Para_Formulario_Actual(_Tipo_de_cambio As Tipo_de_cambio,
                                                             _CodPermiso As String,
                                                             _Imagen As Image)

        Dim _Permitido As Boolean
        Dim _Global_BaseBk_Original = _Global_BaseBk

        If Fx_Tiene_Permiso(_Formulario, "Espr0010") Then

            Dim _Conexion_establecida As Boolean
            Dim _Cadena_ConexionSQL_Seleccionada = String.Empty

            Try

                Dim DatosConex As New ConexionBK

                Dim Directorio As String = Application.StartupPath & "\Data\"
                Dim _Exists = System.IO.File.Exists(Directorio & "Conexiones.xml")

                If Not _Exists Then
                    DatosConex.WriteXml(Directorio & "Conexiones.xml")
                    MessageBoxEx.Show("Arvhico XML creado correctamente", "Crear XML de Conexión",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If

                DatosConex.ReadXml(Directorio & "Conexiones.xml")

                Dim Frm_ConexionBD As New Frm_ConexionBD
                Frm_ConexionBD.BtnAgregar.Visible = False
                Frm_ConexionBD.BtnGenerateKey.Visible = False
                Frm_ConexionBD.ShowDialog(_Formulario)

                If Frm_ConexionBD.NombreConexionActiva = String.Empty Then
                    Frm_ConexionBD.Dispose()
                    Return False
                Else
                    _Cadena_ConexionSQL_Seleccionada = Fx_CadenaConexionSQL(Frm_ConexionBD.NombreConexionActiva, DatosConex)
                End If
                Frm_ConexionBD.Dispose()

                If _Cadena_ConexionSQL_Seleccionada = Cadena_ConexionSQL_Server Then
                    Beep()
                    ToastNotification.Show(_Formulario, "YA ESTA CONECTADO A ESTA EMPRESA", _Imagen,
                                           2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                    Return False
                End If

                Cadena_ConexionSQL_Server = _Cadena_ConexionSQL_Seleccionada

                If Fx_Conectar_Empresa(_Formulario, True) Then

                    If _Tipo_de_cambio = Tipo_de_cambio.Cambiar_totalmente Then

                        Dim Fm_ As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Que_Exite_El_Usuario, "", False, False)
                        Fm_.ShowDialog(_Formulario)
                        _Permitido = Fm_.Pro_Permiso_Aceptado
                        If _Permitido Then
                            _Funcionario = Fm_.Pro_RowUsuario.Item("kofu")

                            If Fx_Act_Usuario(_Funcionario) Then
                                _Conexion_establecida = True
                            End If
                        End If


                    ElseIf _Tipo_de_cambio = Tipo_de_cambio.Cambiar_solo_formulario_activo Then

                        Dim Fm_ As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, _CodPermiso, False, False)
                        Fm_.ShowDialog(_Formulario)
                        _Permitido = Fm_.Pro_Permiso_Aceptado
                        _Funcionario = Fm_.Pro_RowUsuario.Item("kofu")

                        _Conexion_establecida = Fx_Conectar_Usuario_Formulario_Actual(_CodPermiso)
                    End If

                    'End If

                    If _Conexion_establecida Then
                        Fx_Reconectar_Base_De_Datos(Cadena_ConexionSQL_Server)
                    Else
                        _Global_BaseBk = _Global_BaseBk_Original
                        Fx_Reconectar_Base_De_Datos(_Cadena_ConexionSQL_Server_Original)
                    End If
                Else
                    _Global_BaseBk = _Global_BaseBk_Original
                End If

                Return _Conexion_establecida

            Catch ex As Exception
                MessageBoxEx.Show(ex.Message)
            Finally

                If _Conexion_establecida Then
                    Beep()
                    ToastNotification.Show(_Formulario, "CONEXION ESTABLECIDA: " & RazonEmpresa, _Imagen,
                                           2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                End If
            End Try

        End If

    End Function

    Private Function Fx_Act_Usuario(_Kofu As String) As Boolean

        Consulta_sql = "Select top 1 * From TABFU Where KOFU = '" & _Funcionario & "'"
        Dim _TblFun As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)


        If CBool(_TblFun.Rows.Count) Then

            Dim _Nokofu = Trim(_TblFun.Rows(0).Item("NOKOFU"))
            Dim Fm_L As New Frm_Login

            If Fm_L.Fx_Sesion_Star(_Formulario, _Kofu, _Nokofu) Then

                FUNCIONARIO = _Kofu
                Nombre_funcionario_activo = _Nokofu
                Dim AccesoAdministrador = False
                _Global_Sesion = True

                Dim Frm_Modalidad As New Frm_Modalidad_Mt
                Frm_Modalidad.ShowDialog(_Formulario)
                Frm_Modalidad.Dispose()

                _Formulario.Text = "Sistema BakApp. Empresa :" & RazonEmpresa &
                           ", Funcionario Activo: " & Trim(Nombre_funcionario_activo) &
                           ", Modalidad: " & Modalidad & ", BakApp Versión: " & _Global_Version_BakApp & "..." & Space(4) &
                           "(Base BakApp: " & _Global_BaseBk & ")"
                Return True

            End If

        End If

    End Function

    Function Fx_Conectar_Usuario_Formulario_Actual(_CodPermiso As String) As Boolean

        Consulta_sql = "Select top 1 * From TABFU Where KOFU = '" & _Funcionario & "'"
        Dim _TblFun As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)


        If CBool(_TblFun.Rows.Count) Then

            Dim _Kofu = Trim(_TblFun.Rows(0).Item("KOFU"))
            Dim _Nokofu = Trim(_TblFun.Rows(0).Item("NOKOFU"))

            Dim Fm_L As New Frm_Login
            If Fm_L.Fx_Sesion_Star(_Formulario, _Kofu, _Nokofu) Then
                If Fx_Tiene_Permiso(_Formulario, _CodPermiso, _Kofu) Then
                    Return True
                    '_Conexion_establecida = True
                End If
            End If

        Else

            MessageBoxEx.Show(_Formulario, "No se reconoce el usuario en la empresa: " & RazonEmpresa & vbCrLf &
                              "Revise la clave, puede que sea distinta entre ambas bases", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Function

    Function Fx_Reconectar_Base_De_Datos(_Cadena_de_Conexion_SQL As String)
        Cadena_ConexionSQL_Server = _Cadena_de_Conexion_SQL
        Fx_Conectar_Empresa(_Formulario, True)
        'SQL_ServerClass.Sb_Cerrar_Conexion(cn1)
    End Function

End Class
