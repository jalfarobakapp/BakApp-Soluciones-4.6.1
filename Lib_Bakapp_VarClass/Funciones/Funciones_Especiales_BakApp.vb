Imports System.Reflection.Assembly
Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Security.Cryptography
Imports System.Drawing.Printing
Imports System.Windows.Forms


Public Module Funciones_Especiales_BakApp

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Function Fx_Formato_Modalidad(ByVal _Formulario As Form,
                                  ByVal _Modalidad As String,
                                  ByVal _TipoDoc As String, ByVal _Mostrar_Mensaje As Boolean) As DataRow

        Dim _NombreFormato As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad",
                                                         "NombreFormato",
                                                         "Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _TipoDoc & "'")

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Format_01" & vbCrLf &
                       "Where TipoDoc = '" & _TipoDoc & "' and NombreFormato = '" & _NombreFormato & "'"
        Dim _RowFormato As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)


        If _RowFormato Is Nothing Then

            Consulta_sql = "Select top 1 *From TABTIDO Where TIDO = '" & _TipoDoc & "'"
            Dim _RowTido As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Notido As String = _TipoDoc

            If Not (_RowTido Is Nothing) Then
                _Notido = Trim(_RowTido.Item("NOTIDO"))
            End If

            If _Mostrar_Mensaje Then

                MessageBoxEx.Show(_Formulario, "No existe formato para " & _TipoDoc & "-" & _Notido &
                                  " asociado a la modalidad " & _Modalidad,
                                  "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        End If

        Return _RowFormato

    End Function

    Function Fx_Es_Electronico(ByVal _Tido As String) As Boolean

        Dim _Salida As String

        Try
            _Salida = _Global_Row_Configuracion_Estacion.Item(_Tido & "LSR")
        Catch ex As Exception
            _Salida = String.Empty
        End Try


        Select Case _Salida
            Case "l", "s", "r", "p", "5", "6", "7", "8", "m"
                Return True
            Case Else
                Return False
        End Select
        '-- l = ELECTRONICA + Local 
        '-- s = ELECTRONICA + Serial
        '-- r = ELECTRONICA + Remota
        '-- p = ELECTRONICA + Remota
        '-- 5 = ELECTRONICA + LPT1 
        '-- 6 = ELECTRONICA + LPT2 
        '-- 7 = ELECTRONICA + LPT3 
        '-- 8 = ELECTRONICA + LPT4
        '-- m = ELECTRONICA + Multiprinter

    End Function

    Function Fx_Conectar_Empresa(ByVal _Formulario As Form, ByRef _Conectar_Empresa As Boolean) As Boolean

        _Sql = New Class_SQL(Cadena_ConexionSQL_Server)

        Dim Directorio As String = Application.StartupPath & "\Data\"

        RazonEmpresa = Trim(_Sql.Fx_Trae_Dato("CONFIGP", "RAZON", "EMPRESA = '01'"))
        DireccionEmpresa = Trim(_Sql.Fx_Trae_Dato("CONFIGP", "DIRECCION", "EMPRESA = '01'"))
        RutEmpresa = Trim(_Sql.Fx_Trae_Dato("CONFIGP", "RUT", "EMPRESA = '01'"))

        If Not Directory.Exists(Directorio & RutEmpresa) Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Data\" & RutEmpresa)
        End If

        If Not Directory.Exists(Directorio & RutEmpresa & "\Tmp") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Data\" & RutEmpresa & "\Tmp")
        End If

        If Not Directory.Exists(Directorio & RutEmpresa & "\BkPost") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Data\" & RutEmpresa & "\BkPost")
        End If

        If Not Directory.Exists(Directorio & RutEmpresa & "\Configuracion_Local") Then
            System.IO.Directory.CreateDirectory(Directorio & RutEmpresa & "\Configuracion_Local")
        End If

        Dim _Class_BaseBk As New Class_Conectar_Base_BakApp(_Formulario)

        If _Class_BaseBk.Pro_Existe_Base Then
            _Global_BaseBk = _Class_BaseBk.Pro_Row_Tabcarac.Item("Global_BaseBk")
        Else

            MessageBoxEx.Show(_Formulario, "No esta configurada la base de datos de BakApp",
                              "Falta identificación de base BakApp", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            If _Class_BaseBk.Fx_Grabar_Base_Bakapp_En_Tabcarac() Then
                _Global_BaseBk = Trim(_Class_BaseBk.Pro_Row_Tabcarac.Item("Global_BaseBk"))
            Else
                Return False
            End If
        End If


        If Fx_Licencia(_Formulario, RutEmpresa) Then

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Licencia Where Rut = '" & RutEmpresa & "'"
            Dim _TblLicencia As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Fecha_caduca = _TblLicencia.Rows(0).Item("Fecha_caduca")

            Dim _Dias = DateDiff(DateInterval.Day, FechaDelServidor, _Fecha_caduca)

            Consulta_sql = "INSERT INTO " & _Global_BaseBk & "Zw_Configuracion (Modalidad)" & vbCrLf &
                           "Select MODALIDAD From CONFIEST" & vbCrLf &
                           "Where MODALIDAD NOT IN (Select Modalidad From " & _Global_BaseBk & "Zw_Configuracion)"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        Else

            _Conectar_Empresa = True
            'Dim _Fm As New Frm_Licencia_Empresa
            '_Fm.ShowDialog(_Formulario)
            Return False

        End If


        Consulta_sql = "SELECT Top 1 *" & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_Configuracion" & vbCrLf &
                       "Where Modalidad = '  '"

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Configuracion", "Modalidad = '  '"))

        If Not CBool(_Reg) Then

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Configuracion (Modalidad) Values ('  ')"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If


        'Dim Fm As New Frm_Instalar_Sistema
        'Fm.Fx_Revisar_Tabla(_Formulario, "Zw_TblFiltro_InfxUs")
        'Fm.Fx_Revisar_Tabla(_Formulario, "ZW_PermisosADM")
        'Fm.Fx_Revisar_Tabla(_Formulario, "Zw_Turnos")
        'Fm.Fx_Revisar_Tabla(_Formulario, "Zw_TablaDeCaracterizaciones")
        'Fm.Fx_Revisar_Tabla(_Formulario, "Zw_MrVsPro")
        'Fm.Fx_Revisar_Tabla(_Formulario, "Zw_TblArbol_Asociaciones")
        'Fm.Fx_Revisar_Tabla(_Formulario, "Zw_Prod_Asociacion")

        'Fm.Fx_Revisar_Tabla(_Formulario, "Zw_ListaPreGlobal")
        'Fm.Fx_Revisar_Tabla(_Formulario, "Zw_ListaPreCosto")
        'Fm.Fx_Revisar_Tabla(_Formulario, "Zw_ListaPreProducto")

        'Fm.Dispose()

        Return True

    End Function

    Function Fx_Cambiar_Numeracion_Modalidad(ByVal _Tido As String,
                                             _Empresa As String,
                                             _Modalidad As String) As Boolean

        ' _Modalidad = "  "

        Dim _Consulta_sql = "Select Top 1 " & _Tido & " From CONFIEST Where MODALIDAD = '" & _Modalidad & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql) 'get_Tablas(_Consulta_sql, cn1)

        Dim _Nudo_Modalidad As String

        _Consulta_sql = String.Empty

        If CBool(_Tbl.Rows.Count) Then

            _Nudo_Modalidad = Trim(_Tbl.Rows(0).Item(_Tido))

            If String.IsNullOrEmpty(_Nudo_Modalidad) Then
                If Fx_Cambiar_Numeracion_Modalidad(_Tido, _Empresa, "  ") Then
                    _Consulta_sql = String.Empty
                End If
            ElseIf _Nudo_Modalidad = "0000000000" Then
                _Consulta_sql = String.Empty
            Else

                Dim Continua As Boolean = True

                If Not String.IsNullOrEmpty(Trim(_Nudo_Modalidad)) Then

                    Dim _ProxNumero As String = Fx_Proximo_NroDocumento(_Nudo_Modalidad, 10)

                    _Consulta_sql = "UPDATE CONFIEST SET " & _Tido & " = '" & _ProxNumero & "'" & vbCrLf &
                                    "WHERE EMPRESA = '" & _Empresa & "' AND  MODALIDAD = '" & _Modalidad & "'"

                End If

            End If

        End If

        If Not String.IsNullOrEmpty(_Consulta_sql) Then
            Return _Sql.Ej_consulta_IDU(_Consulta_sql)
        End If

    End Function

    Public Function Fx_Licencia(ByVal _Formulario As Form, ByVal _RutEmpresa As String) As Boolean

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Licencia Where Rut = '" & _RutEmpresa & "'"
        Dim _TblLicencia As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)


        If CBool(_TblLicencia.Rows.Count) Then
            With _TblLicencia.Rows(0)
                Dim _Rut = .Item("Rut")
                Dim _Fecha_caduca As Date = .Item("Fecha_caduca")
                Dim _Cant_licencias = .Item("Cant_licencias")

                Dim _Llave1 As String = .Item("Llave1")
                Dim _Llave2 As String = .Item("Llave2")
                Dim _Llave3 As String = .Item("Llave3")
                Dim _Llave4 As String = .Item("Llave4")

                Dim _LLaves = Fx_Genera_Licencia_BakApp(_Rut, _Fecha_caduca, _Cant_licencias, "b4s1ng4")

                Dim _Llave1_R = _LLaves(0)
                Dim _Llave2_R = _LLaves(1)
                Dim _Llave3_R = _LLaves(2)
                Dim _Llave4_R = _LLaves(3) '= Encripta_md5(_Llave1 & _Llave2 & _Llave3)

                Dim _Dias = DateDiff(DateInterval.Day, FechaDelServidor, _Fecha_caduca)

                If _Dias > 0 Then

                    If _Dias < 10 Then
                        MessageBoxEx.Show(_Formulario, "Faltan " & _Dias & " días para que caduque la licencia", "Licencia",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return True
                    End If

                Else
                    MessageBoxEx.Show(_Formulario, "Sistema sin licencias de uso", "Licencia Expirada",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If

                If _Llave1_R <> _Llave1 Or
                   _Llave2_R <> _Llave2 Or
                   _Llave3_R <> _Llave3 Or
                   _Llave4_R <> _Llave4 Then

                    MessageBoxEx.Show(_Formulario, "Licencia corrupta", "Error en base de datos",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                Else
                    Return True
                End If


            End With

        Else

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Licencia (Rut,Razon,NombreCorto,Direccion,Giro,Ciudad,Pais,Telefonos) " & vbCrLf &
                           "Select TOP 1 RUT,RAZON,NCORTO,DIRECCION,GIRO,CIUDAD,PAIS,TELEFONOS" & vbCrLf &
                           "From CONFIGP Where EMPRESA = '01'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            MessageBoxEx.Show(_Formulario, "No existe llave para el uso del sistema", "Validación BakApp",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

    End Function

    Function Fx_Genera_Licencia_BakApp(ByVal _RutEmpresa As String,
                                        ByVal _FechaCaduca As Date,
                                        ByVal _CantLicencias As Integer,
                                        ByVal _Palabra_X As String) As String()

        Dim _Llave1, _Llave2, _Llave3, _Llave4 As String

        _Llave1 = Encripta_md5(Trim(_RutEmpresa) & _Palabra_X)
        _Llave2 = Encripta_md5(Format(_FechaCaduca, "yyyyMMdd"))
        _Llave3 = Encripta_md5(_CantLicencias & _Palabra_X)
        _Llave4 = Encripta_md5(_Llave1 & _Llave2 & _Llave3 & _Palabra_X)

        Dim Licencia(3) As String

        Licencia(0) = _Llave1
        Licencia(1) = _Llave2
        Licencia(2) = _Llave3
        Licencia(3) = _Llave4

        Return Licencia

    End Function

    Private Function Encripta_md5(ByVal TextoAEncriptar As String) As String
        Dim vlo_MD5 As New MD5CryptoServiceProvider
        Dim vlby_Byte(), vlby_Hash() As Byte
        Dim vls_TextoEncriptado As String = ""

        'Convierte texto a encriptar a Bytes
        vlby_Byte = System.Text.Encoding.UTF8.GetBytes(TextoAEncriptar)

        'Aplicación del algoritmo hash
        vlby_Hash = vlo_MD5.ComputeHash(vlby_Byte)

        'Convierte la matriz de byte en una cadena
        For Each vlby_Aux As Byte In vlby_Hash
            vls_TextoEncriptado += vlby_Aux.ToString("x2")
        Next

        'Retorno de función
        Return vls_TextoEncriptado
    End Function


    Function MensajeSinPermiso(ByVal Nro As String,
                               Optional ByVal _CodUsuario As String = "",
                               Optional ByVal _NomUsuario As String = "")

        Dim _Mensaje As String
        Dim NombrePermiso As String = _Sql.Fx_Trae_Dato("DescripcionPermiso",
                                                _Global_BaseBk & "ZW_Permisos", "CodPermiso = '" & Nro & "'")

        If String.IsNullOrEmpty(Trim(_CodUsuario)) Then
            _Mensaje = "Usted no posee permisos para realizar esta acción, permiso: " & Nro
        Else
            _Mensaje = _NomUsuario & vbCrLf &
                       "No posee permisos para realizar esta acción, permiso: " & Nro
        End If

        If String.IsNullOrEmpty(Trim(_CodUsuario)) Then
            _Mensaje = "Usted no posee permisos para realiza esta acción"
        Else
            _Mensaje = _NomUsuario & vbCrLf &
                       "No posee permisos para realiza esta acción"
        End If

        Dim info As New TaskDialogInfo("Permisos de usuarios",
                                       eTaskDialogIcon.ShieldStop,
                                       "PERMISO: " & Nro,
                                       _Mensaje & vbCrLf &
                                       "Para ejecutar esta acción se necesita el permiso indicado. " & vbCrLf &
                                       "Descripción: " & vbCrLf & vbCrLf & NombrePermiso & vbCrLf, eTaskDialogButton.Ok _
                                       , eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing) ', "BakApp", My.Resources.BakApp)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)

        '        MsgBox("Usted no posee permisos para realiza esta acción" & vbCrLf & "Permiso Nro: " & Nro & " - " & NombrePermiso, MsgBoxStyle.Critical, "Permiso denegado")


    End Function

    Public Function Traer_Numero_Documento(ByVal _TipoDoc As String,
                                           Optional ByVal _NumeroDoc As String = "",
                                           Optional ByVal _Modalidad_Seleccionada As String = "",
                                           Optional ByVal _Mostrar_Mensaje As Boolean = True,
                                           Optional ByVal _Cambiar_Numeracion As Boolean = True)

        Dim _Existe_Doc As Integer
        Dim _TipGrab As String
        Dim _Arr_Nudo(1) As String

        Dim _NrNumeroDoco As String

        'If String.IsNullOrEmpty(_Modalidad_Seleccionada) Then
        '_Modalidad_Seleccionada = Modalidad
        'End If

        If String.IsNullOrEmpty(Trim(_NumeroDoc)) Then
            _NrNumeroDoco = _Sql.Fx_Trae_Dato("CONFIEST", "EMPRESA = '" & ModEmpresa &
                                         "' AND MODALIDAD = '" & _Modalidad_Seleccionada & "'") 'FUNCIONARIO & numero_(Trim(Str(CantOCCFuncionario)), 7)
        Else
            _NrNumeroDoco = _NumeroDoc
        End If

        _Existe_Doc = _Sql.Fx_Cuenta_Registros("MAEEDO", "TIDO = '" & _TipoDoc & "' And NUDO = '" & _NrNumeroDoco & "'")

        _TipGrab = Fx_Tipo_Grab_Modalidad(_TipoDoc, _NrNumeroDoco)

        Dim Contador = 0

        If _TipGrab = "EnBlanco" Then

            _NrNumeroDoco = _Sql.Fx_Trae_Dato("CONFIEST", _TipoDoc, "EMPRESA = '" & _Modalidad_Seleccionada &
                   "' AND MODALIDAD = '  '")

            If _Cambiar_Numeracion Then
                _Existe_Doc = _Sql.Fx_Cuenta_Registros("MAEEDO", "TIDO = '" & _TipoDoc & "' And NUDO = '" & _NrNumeroDoco & "'")

                Do While CBool(_Existe_Doc)

                    Dim _Proximo_Nro As String = Fx_Proximo_NroDocumento(_NrNumeroDoco, 10)
                    Consulta_sql = "UPDATE CONFIEST SET " & _TipoDoc & " = '" & _Proximo_Nro & "'" & vbCrLf &
                                   "WHERE EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '  '"

                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    _NrNumeroDoco = _Sql.Fx_Trae_Dato("CONFIEST", _TipoDoc, "EMPRESA = '" & ModEmpresa &
                                             "' AND MODALIDAD = '  '")

                    _Existe_Doc = _Sql.Fx_Cuenta_Registros("MAEEDO", "TIDO = '" & _TipoDoc & "' And NUDO = '" & _NrNumeroDoco & "'")

                Loop
            End If

        ElseIf _TipGrab = "Puros_Ceros" Then

            _NrNumeroDoco = _Sql.Fx_Trae_Dato("MAEEDO", "COALESCE(MAX(NUDO),'0000000000')", "TIDO = '" & _TipoDoc & "'")
            _NrNumeroDoco = Fx_Rellena_ceros(_NrNumeroDoco, 10, True)

            _Existe_Doc = 0

        ElseIf _TipGrab = "Con_Numeración" Then

            If _Cambiar_Numeracion Then
                Do While CBool(_Existe_Doc)

                    Dim _Proximo_Nro As String = Fx_Proximo_NroDocumento(_NrNumeroDoco, 10)
                    Consulta_sql = "UPDATE CONFIEST SET " & _TipoDoc & " = '" & _Proximo_Nro & "' WHERE EMPRESA = '" & ModEmpresa &
                                   "' AND  MODALIDAD = '" & _Modalidad_Seleccionada & "'"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    _NrNumeroDoco = _Sql.Fx_Trae_Dato("CONFIEST", _TipoDoc, "EMPRESA = '" & ModEmpresa &
                                             "' AND MODALIDAD = '" & _Modalidad_Seleccionada & "'")

                    _Existe_Doc = _Sql.Fx_Cuenta_Registros("MAEEDO", "TIDO = '" & _TipoDoc & "' And NUDO = '" & _NrNumeroDoco & "'")

                Loop
            End If

        End If

        If _Cambiar_Numeracion Then

            If CBool(_Existe_Doc) Then

                If _Mostrar_Mensaje Then

                    Dim info As New TaskDialogInfo("Grabar documento",
                              eTaskDialogIcon.Stop,
                              "El documento no se puede guardar correctamente",
                              "Favor colocar la numeración correspondiente en Modalidad de trabajo " & _Modalidad_Seleccionada & vbCrLf &
                              "vuelva a intentar la grabación." & vbCrLf &
                              "El documento " & _TipoDoc & " Nro " & _NrNumeroDoco & " ya exite en el sistema",
                              eTaskDialogButton.Close _
                              , eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)
                    Dim result As eTaskDialogResult = TaskDialog.Show(info)

                End If

                _NrNumeroDoco = String.Empty

            End If

        End If

        Return _NrNumeroDoco

    End Function

    Public Function Fx_Tipo_Grab_Modalidad(ByVal _TipoDoc As String,
                                           ByVal _NrNumeroDoco As String) As String


        'Dim _NrNumeroDoco As String = trae_dato(tb, cn1, _TipoDoc, "CONFIEST", "EMPRESA = '" & ModEmpresa & _
        '                              "' AND MODALIDAD = '" & Modalidad & "'") 'FUNCIONARIO & numero_(Trim(Str(CantOCCFuncionario)), 7)

        Dim Continua As Boolean = True

        If String.IsNullOrEmpty(Trim(_NrNumeroDoco)) Then
            Return "EnBlanco"
        ElseIf _NrNumeroDoco = "0000000000" Then
            Return "Puros_Ceros"
        Else
            Return "Con_Numeración"
        End If

    End Function


    Function _Dev_HoraGrab(ByVal Hora As String)

        Dim _HH, _MM, _SS As Double
        Dim _Horagrab As Integer

        _HH = Mid(Hora, 1, 2)
        _MM = Mid(Hora, 4, 2)
        _SS = Mid(Hora, 7, 2)

        _Horagrab = Math.Round((_HH * 3600) + (_MM * 60) + _SS, 0)

        Return _Horagrab

    End Function

    Function FechaDelServidor() As Date
        Consulta_sql = "select getdate() As Fecha"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
        FechaDelServidor = _Row.Item("Fecha")
    End Function

    Function Fx_Trae_Permiso_Bk(ByVal _CodUsuario As String,
                                ByVal _CodPremiso As String) As DataTable

        Dim _Tbl As DataTable

        Consulta_sql = "Select * From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf &
                       "Where CodPermiso = '" & _CodPremiso & "' And CodUsuario = '" & _CodUsuario & "'"

        _Tbl = _Sql.Fx_Get_Tablas(Consulta_sql)

        Return _Tbl

    End Function

    Function Fx_Traer_Datos_Entidad(ByVal _CodEntidad As String, ByVal _SucEntidad As String) As DataRow

        Dim _Row_Entidad As DataRow

        Consulta_sql = My.Resources.Recursos_Entidad.SqlQuery_Datos_Entidad
        Consulta_sql = Replace(Consulta_sql, "#CodEntidad#", _CodEntidad)
        Consulta_sql = Replace(Consulta_sql, "#SucEntidad#", _SucEntidad)

        _Row_Entidad = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not (_Row_Entidad Is Nothing) Then
            Dim _Rut As String = _Row_Entidad.Item("RTEN")
            _Rut = FormatNumber(_Rut, 0) & "-" & RutDigito(_Rut)
            _Row_Entidad.Item("Rut") = _Rut
        End If

        Return _Row_Entidad

    End Function

    Function Fx_Traer_Datos_Entidad_Tabla(ByVal _CodEntidad As String, ByVal _SucEntidad As String) As DataTable

        Dim _Tbl_Entidad As DataTable

        Consulta_sql = My.Resources.Recursos_Entidad.SqlQuery_Datos_Entidad
        Consulta_sql = Replace(Consulta_sql, "#CodEntidad#", _CodEntidad)
        Consulta_sql = Replace(Consulta_sql, "#SucEntidad#", _SucEntidad)
        Consulta_sql = Replace(Consulta_sql, "And SUEN = @SucEntidad", "")

        _Tbl_Entidad = _Sql.Fx_Get_Tablas(Consulta_sql)

        For Each _Row_entidad As DataRow In _Tbl_Entidad.Rows

            If Not (_Row_entidad Is Nothing) Then
                Dim _Rut As String = _Row_entidad.Item("RTEN")
                _Rut = FormatNumber(_Rut, 0) & "-" & RutDigito(_Rut)
                _Row_entidad.Item("Rut") = _Rut
            End If

        Next

        Return _Tbl_Entidad


    End Function

    Function Fx_Revisar_Nombre_Equipo_BakApp(ByVal _Formulario As Form,
                                             ByVal _Dir_Empresa As String,
                                             ByVal _Rut_Empresa As String,
                                             ByVal _Nombre_Equipo As String) As Boolean

        Dim _Ds As New DatosBakApp

        Dim _Existe = System.IO.File.Exists(_Dir_Empresa & "\Nombre_Equipo.xml")

        If Not _Existe Then

            MessageBoxEx.Show(_Formulario, "El equipo no está registrado en el sistema" & vbCrLf &
                              "Debe ingresar un nombre al equipo (se sugiere dejar el mismo nombre por defecto)",
                              "Llave de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information)

            '_Nombre_Equipo = InputBox_Bk(_Formulario, "Debe ingresar un nombre al equipo" & vbCrLf & _
            '                             "(se sugiere dejar el mismo)" & vbCrLf & _
            '                             "Ingrese nombre de la estación de trabajo", _
            '                             "El equipo no está registrado en el sistema", _Nombre_Equipo, False, _
            ' _Tipo_Mayus_Minus.Normal, 0, True, _Tipo_Imagen.Texto, False)

            _Nombre_Equipo = InputBox("Debe ingresar un nombre al equipo" & vbCrLf &
                                      "(se sugiere dejar el mismo)" & vbCrLf &
                                        "Ingrese nombre de la estación de trabajo", "El equipo no está registrado en el sistema")

            If _Nombre_Equipo = "@@Accion_Cancelada##" Then
                Return False
            Else

                Dim _Sigue As Boolean
                Dim _Nro = 0

                Do
                    Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_EstacionesBkp", "NombreEquipo = '" & _Nombre_Equipo & "'")

                    If CBool(_Reg) Then
                        _Nombre_Equipo = _Nombre_Equipo & "_" & numero_(_Nro + 1, 2)
                        _Sigue = True
                    Else
                        _Sigue = False
                    End If

                Loop While _Sigue

                Dim NewFila As DataRow
                NewFila = _Ds.Tables("Tbl_Nombre_Equipo").NewRow
                With NewFila
                    .Item("Nombre_Equipo") = _Nombre_Equipo
                End With

                _Ds.Tables("Tbl_Nombre_Equipo").Rows.Add(NewFila)
                _Ds.WriteXml(_Dir_Empresa & "\Nombre_Equipo.xml")

            End If

            Return True
        Else
            Return True
            ' _Ds.Clear()
            ' _Ds.ReadXml(_Dir_Empresa & "\Nombre_Equipo.xml")
            'Fx_Revisar_Nombre_Equipo_BakApp
        End If

    End Function

    Public Function Hora_Grab_fx(ByVal _EsAjuste As Boolean) As String

        Dim _HH_sistem As Date

        _HH_sistem = FechaDelServidor()

        Dim _HH, _MM, _SS As Double

        _HH = _HH_sistem.Hour
        _MM = _HH_sistem.Minute
        _SS = _HH_sistem.Second

        If _EsAjuste Then
            _HH = 23 : _MM = 59 : _SS = 59
        End If

        Dim _HoraGrab As String = Math.Round((_HH * 3600) + (_MM * 60) + _SS, 0)

        Return _HoraGrab

    End Function

    Function TraeClaveRD(ByVal Texto As String) As String

        Dim valorAscii As Integer
        Dim PassEncriptado, Letra As String
        Dim CadenaRD As Long


        Texto = Trim(Texto)
        For x = 1 To Len(Texto)
            Letra = Mid(Texto, x, 1)
            valorAscii = Asc(Letra)
            'txtAscii.Text = valor.ToString

            If x = 1 Then
                CadenaRD = (17225 + valorAscii) * 1
            ElseIf x = 2 Then
                CadenaRD = (1847 + valorAscii) * 8
            ElseIf x = 3 Then
                CadenaRD = (1217 + valorAscii) * 27
            ElseIf x = 4 Then
                CadenaRD = (237 + valorAscii) * 64
            ElseIf x = 5 Then
                CadenaRD = (201 + valorAscii) * 125
            End If

            PassEncriptado = PassEncriptado & CadenaRD
            CadenaRD = 0
        Next

        Return PassEncriptado

    End Function

    Function Fx_Cambiar_Numeracion_Modalidad(ByVal _Tido As String,
                                             ByVal _Modalidad As String) As Boolean

        ' _Modalidad = "  "

        Dim _Consulta_sql = "Select Top 1 " & _Tido & " From CONFIEST Where MODALIDAD = '" & _Modalidad & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql) 'get_Tablas(_Consulta_sql, cn1)

        Dim _Nudo_Modalidad As String

        _Consulta_sql = String.Empty

        If CBool(_Tbl.Rows.Count) Then

            _Nudo_Modalidad = Trim(_Tbl.Rows(0).Item(_Tido))

            If String.IsNullOrEmpty(_Nudo_Modalidad) Then
                If Fx_Cambiar_Numeracion_Modalidad(_Tido, "  ") Then
                    _Consulta_sql = String.Empty
                End If
            ElseIf _Nudo_Modalidad = "0000000000" Then
                _Consulta_sql = String.Empty
            Else

                Dim Continua As Boolean = True

                If Not String.IsNullOrEmpty(Trim(_Nudo_Modalidad)) Then

                    Dim _ProxNumero As String = Fx_Proximo_NroDocumento(_Nudo_Modalidad, 10)

                    _Consulta_sql = "UPDATE CONFIEST SET " & _Tido & " = '" & _ProxNumero & "'" & vbCrLf &
                                    "WHERE EMPRESA = '" & ModEmpresa & "' AND  MODALIDAD = '" & _Modalidad & "'"

                End If

            End If

        End If

        If Not String.IsNullOrEmpty(_Consulta_sql) Then
            Return _Sql.Ej_consulta_IDU(_Consulta_sql)
        End If

    End Function

    Function Fx_Proximo_NroDocumento(ByVal _NrNumeroDoco As String, ByVal _Cant_Caracteres As Integer) As String

        If String.IsNullOrEmpty(_NrNumeroDoco) Then
            _NrNumeroDoco = StrDup(_Cant_Caracteres, "0")
        End If

        Dim _Pos As Integer = 0
        Dim _Prefijo As String
        Dim _Cadena As String = String.Empty
        Dim _NvoNumero1 As Integer
        Dim _NvoNumero2 As String

        Do While _Pos < _Cant_Caracteres
            _Pos += 1
            Dim _Caracter As String = Right(_NrNumeroDoco, (_Cant_Caracteres + 1) - _Pos)

            If IsNumeric(_Caracter) Then
                _Prefijo = Left(_NrNumeroDoco, _Pos - 1)
                _Cadena = Right(_NrNumeroDoco, (_Cant_Caracteres + 1) - _Pos)
                Exit Do
            End If

        Loop

        _NvoNumero1 = CInt(_Cadena) + 1
        _NvoNumero2 = _Prefijo & numero_(_NvoNumero1, Len(_Cadena))

        Return _NvoNumero2

    End Function


    Function Fx_Stock_Disponible(ByVal _Tido As String,
                                 ByVal _Empresa As String,
                                 ByVal _Sucursal As String,
                                 ByVal _Bodega As String,
                                 ByVal _Codigo As String,
                                 ByVal _Ud As Integer,
                                 ByVal _Campo As String) As Double


        Dim _Stock_Fisico_A As Double                   ' STFI1,STFI2
        Dim _Stock_Devengado_B As Double                ' STDV1,STDV2
        Dim _Stock_Comprometido_C As Double             ' STOCNV1,STOCNV2
        Dim _Stock_Compras_No_Recibidas_D As Double     ' STDV1C,STDV2C
        Dim _Stock_Pedido_E As Double                   ' STOCNV1C,STOCNV2C   
        Dim _Stock_Despacho_Sin_Facturar_F As Double    ' DESPNOFAC1, DESPNOFAC2
        Dim _Stock_Recepciones_Sin_Facturar_G As Double ' RECENOFAC1,RECENOFAC2

        Dim _Stock_Prestamos_X_Recuperar_H As Double    ' PRESALCLI1,PRESALCLI2 
        Dim _Stock_Prestamos_X_Devolver_I As Double     ' PRESDEPRO1,PRESDEPRO2

        Dim _Stock_Dato_En_Consignacion_J As Double     ' CONSALCLI1,CONSALCLI2
        Dim _Stock_Recibido_En_Consignacion_K As Double ' CONDESPRO1,CONDESPRO2

        Dim _Stock_NCV_sin_GRD_L As Double              ' DEVENGNCV1,DEVENGNCV2
        Dim _Stock_NCC_sin_GRD_M As Double              ' DEVENFNCC1,DEVENFNCC2

        Dim _Stock_Devolucion_sin_NCV_N As Double       ' DEVSINNCV1,DEVSINNCV2
        Dim _Stock_Devolucion_sin_NCC_O As Double       ' DEVSINNCC1,DEVSINNCC2
        Dim _Stock_Pedido_a_Fabricar_P As Double        ' STENFAB1,STENFAB2
        Dim _Stock_Comprometido_x_Fabricar_Q As Double  ' STREQFAB1,STREQFAB2


        Consulta_sql = "Select Top 1 * From TABTIDO Where TIDO = '" & _Tido & "'"
        Dim _RowTido As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Campo_Stock As String

        Try
            _Campo_Stock = _RowTido.Item("STOCK")
        Catch ex As Exception
            _Campo_Stock = String.Empty
        End Try

        _Campo_Stock = Replace(_Campo_Stock, "A", "[A]")
        _Campo_Stock = Replace(_Campo_Stock, "B", "[B]")
        _Campo_Stock = Replace(_Campo_Stock, "C", "[C]")
        _Campo_Stock = Replace(_Campo_Stock, "D", "[D]")
        _Campo_Stock = Replace(_Campo_Stock, "E", "[E]")
        _Campo_Stock = Replace(_Campo_Stock, "F", "[F]")
        _Campo_Stock = Replace(_Campo_Stock, "G", "[G]")
        _Campo_Stock = Replace(_Campo_Stock, "H", "[H]")
        _Campo_Stock = Replace(_Campo_Stock, "I", "[I]")
        _Campo_Stock = Replace(_Campo_Stock, "J", "[J]")
        _Campo_Stock = Replace(_Campo_Stock, "K", "[K]")
        _Campo_Stock = Replace(_Campo_Stock, "L", "[L]")
        _Campo_Stock = Replace(_Campo_Stock, "M", "[M]")
        _Campo_Stock = Replace(_Campo_Stock, "N", "[N]")
        _Campo_Stock = Replace(_Campo_Stock, "O", "[O]")
        _Campo_Stock = Replace(_Campo_Stock, "P", "[P]")
        _Campo_Stock = Replace(_Campo_Stock, "Q", "[Q]")


        _Campo_Stock = Replace(_Campo_Stock, "[A]", "STFI" & _Ud)
        _Campo_Stock = Replace(_Campo_Stock, "[B]", "STDV" & _Ud)
        _Campo_Stock = Replace(_Campo_Stock, "[C]", "STOCNV" & _Ud)
        _Campo_Stock = Replace(_Campo_Stock, "[D]", "STDV" & _Ud & "C")
        _Campo_Stock = Replace(_Campo_Stock, "[E]", "STOCNV" & _Ud & "C")
        _Campo_Stock = Replace(_Campo_Stock, "[F]", "DESPNOFAC" & _Ud)
        _Campo_Stock = Replace(_Campo_Stock, "[G]", "RECENOFAC" & _Ud)
        _Campo_Stock = Replace(_Campo_Stock, "[H]", "PRESALCLI" & _Ud)
        _Campo_Stock = Replace(_Campo_Stock, "[I]", "PRESDEPRO" & _Ud)
        _Campo_Stock = Replace(_Campo_Stock, "[J]", "CONSALCLI" & _Ud)
        _Campo_Stock = Replace(_Campo_Stock, "[K]", "CONDESPRO" & _Ud)
        _Campo_Stock = Replace(_Campo_Stock, "[L]", "DEVENGNCV" & _Ud)
        _Campo_Stock = Replace(_Campo_Stock, "[M]", "DEVENFNCC" & _Ud)
        _Campo_Stock = Replace(_Campo_Stock, "[N]", "DEVSINNCV" & _Ud)
        _Campo_Stock = Replace(_Campo_Stock, "[O]", "DEVSINNCC" & _Ud)
        _Campo_Stock = Replace(_Campo_Stock, "[P]", "STENFAB" & _Ud)
        _Campo_Stock = Replace(_Campo_Stock, "[Q]", "STREQFAB" & _Ud)

        If String.IsNullOrEmpty(_Campo_Stock) Then
            _Campo_Stock = _Campo
        End If

        Consulta_sql = "Select " & _Campo_Stock & " As Stock_Disponible From MAEST" & vbCrLf &
                       "Where" & vbCrLf &
                       "EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "'" & Space(1) &
                       "And KOBO = '" & _Bodega & "' And KOPR = '" & _Codigo & "'"

        Dim _RowStock As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not (_RowStock Is Nothing) Then
            Fx_Stock_Disponible = _RowStock.Item("Stock_Disponible")
        End If

    End Function

    Public Function Fx_Suma_cantidades(ByVal CAMPO As String,
                                       ByVal TABLA As String,
                                       Optional ByVal condicion As String = "",
                                       Optional ByVal Decimales As Integer = 0) As Double

        Dim Suma As Double

        If condicion <> "" Then
            condicion = " Where " & condicion
        End If

        Consulta_sql = "SELECT ROUND(SUM(" & CAMPO & ")," & Decimales & ") AS CAMPO FROM " & TABLA & condicion & ""
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim cuenta As Long = _Tbl.Rows.Count
        Dim dr As DataRow = _Tbl.Rows(0)

        Suma = NuloPorNro(dr("CAMPO"), 0)

        Return Suma

        If CBool(cuenta) Then
            If IsDBNull(dr("CAMPO")) Then
                Return 0
            Else
                Return RTrim(dr("CAMPO"))
            End If
        Else
            Return 0
        End If

    End Function

    Public Function Sb_Enviar_Doc_Por_Mail(ByVal _IdMaeedo_Doc As String,
                                      ByVal _Email_Para As String,
                                      ByVal _Encabezado_Cuerpo As String,
                                      ByVal _Pie_Cuerpo As String,
                                      ByVal _Form_Origen As Object) As Boolean


        Dim Crea_Htm As New Clase_Crear_Documento_Htm
        Dim _Ruta As String = AppPath() & "\Data\" & RutEmpresa & "\Tmp"

        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _IdMaeedo_Doc
        Dim _Enc_Documento As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Enc_Documento.Rows.Count) Then

            Dim _Nudo As String = _Enc_Documento.Rows(0).Item("NUDO")
            Dim _Tido As String = _Enc_Documento.Rows(0).Item("TIDO")
            Dim _TipoDoc As String = Trim(_Sql.Fx_Trae_Dato("TABTIDO", "NOTIDO", "TIDO = '" & _Tido & "'"))
            Dim _Estado As String = _Enc_Documento.Rows(0).Item("ESDO")

            If _Estado = "N" Then
                MessageBoxEx.Show(_Form_Origen, "Documento NULO, no se puede adjuntar",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

            If Crea_Htm.Fx_Crear_Documento_Htm(_IdMaeedo_Doc, _Ruta) Then

                ' Acento en Html
                'á = &aacute
                'é = &eacute
                'í = &iacute
                'ó = &oacute
                'ú = &uacute
                'ñ = &ntilde
                'Ñ = &Ntilde

                Dim fic As String = _Ruta & "\Documento.Htm"
                Dim _Cuerpo_Html = LeeArchivo(fic)

                Dim Envio_Occ_Mail As New Class_Outlook

                _Cuerpo_Html = Replace(_Cuerpo_Html, "&aacute", "á")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&eacute", "é")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&iacute", "í")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&oacute", "ó")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&uacute", "ú")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&ntilde", "ñ")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&Ntilde", "Ñ")

                Dim _Para As String = _Email_Para '"jalfaro@bakapp.cl"
                Dim _Adjunto As String = _Ruta & "\Documento.Htm"
                Dim _Cuerpo As String = _Encabezado_Cuerpo & vbCrLf & vbCrLf & _Cuerpo_Html & vbCrLf & vbCrLf & _Pie_Cuerpo
                Dim _Asunto As String = _TipoDoc & " Nro " & _Nudo

                Envio_Occ_Mail.Sb_Crear_Correo_Outlook(_Para, _Adjunto, _Asunto, _Cuerpo, True)
            End If
            Return True
        Else
            MessageBoxEx.Show(_Form_Origen, "No se encontro el documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
    End Function

    Function Fx_CadenaConexionSQL(ByVal NombreConexion As String,
                                  ByVal DsConexion As DataSet) As String

        Dim Cadena = "data source = #SV#; initial catalog = #BD#; user id = #US#; password = #PW#"

        Dim SV, PT, BD, US, PW As String

        Dim Tbl As New DataTable
        Tbl = DsConexion.Tables(0)

        Dim Reg As Integer = 0


        For Each Fila As DataRow In Tbl.Rows

            If Fila.Item("NombreConexion").ToString = NombreConexion Then
                SV = Fila.Item("Servidor").ToString 'trae_datoAccess(tb, "Servidor", "Tmp_Conexiones", "NombreConexion = '" & Rut & "'", , "TmpConexionBD.mdb")
                PT = Fila.Item("Puerto").ToString 'trae_datoAccess(tb, "Puerto", "Tmp_Conexiones", "NombreConexion = '" & Rut & "'", , "TmpConexionBD.mdb")
                US = Fila.Item("Usuario").ToString 'trae_datoAccess(tb, "Usuario", "Tmp_Conexiones", "NombreConexion = '" & Rut & "'", , "TmpConexionBD.mdb")
                PW = Fila.Item("Clave").ToString 'trae_datoAccess(tb, "Clave", "Tmp_Conexiones", "NombreConexion = '" & Rut & "'", , "TmpConexionBD.mdb")
                BD = Fila.Item("BaseDeDatos").ToString 'trae_datoAccess(tb, "BaseDeDatos", "Tmp_Conexiones", "NombreConexion = '" & Rut & "'", , "TmpConexionBD.mdb")

                If Trim(PT) <> "" Then
                    SV = Trim(SV & "," & PT)
                End If

                Cadena = Replace(Cadena, "#SV#", SV)
                Cadena = Replace(Cadena, "#BD#", BD)
                Cadena = Replace(Cadena, "#US#", US)
                Cadena = Replace(Cadena, "#PW#", PW)
            End If

        Next

        Return Cadena

    End Function

    Function Fx_Trar_Datos_De_Bodega_Seleccionada(ByVal _Empresa As String,
                                                  ByVal _Sucursal As String,
                                                  ByVal _Bodega As String) As DataRow

        _Sql = New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Select '" & _Empresa & "' As 'EMPRESA'," & vbCrLf &
                      "(Select top 1 RAZON From CONFIGP Where EMPRESA = '" & _Empresa & "') As 'RAZON'," & vbCrLf &
                      "'" & _Sucursal & "' As KOSU,(Select top 1 NOKOSU From TABSU " &
                      "Where EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "') As 'NOKOSU'," & vbCrLf &
                      "'" & _Bodega & "' As 'KOBO'," &
                      "(Select top 1 NOKOBO From TABBO " &
                      "Where EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "' And KOBO = '" & _Bodega & "') As 'NOKOBO'"

        Dim _Row_Bodega_Sel As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Return _Row_Bodega_Sel

    End Function

    Sub Sb_Cargar_ComboBoxEx_TablaDeCaracterizaciones(ByRef _Cmb As DevComponents.DotNetBar.Controls.ComboBoxEx,
                              ByVal _Tabla As String,
                              ByVal _Campoxdefecto As String,
                              ByVal _Incluir_Fila_Vacia As Boolean)
        caract_combo(_Cmb)

        Dim _SqlFilaVacia = "Select '' As Padre, '' As Hijo,0 As Orden Union" & vbCrLf

        If Not _Incluir_Fila_Vacia Then _SqlFilaVacia = String.Empty

        Consulta_sql = _SqlFilaVacia &
                       "Select CodigoTabla As Padre,NombreTabla as Hijo,Orden" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "Where Tabla = '" & _Tabla & "'" & vbCrLf &
                       "order by Orden"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
        _Cmb.DataSource = _Tbl
        If CBool(_Tbl.Rows.Count) Then
            _Cmb.SelectedValue = _Campoxdefecto
        End If

    End Sub

    Function Fx_Solo_Enteros(ByVal _Cantidad As Double,
                             ByVal _Divisible As String) As Boolean

        _Sql = New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Cant_Tiene_Decimales As Boolean
        Dim _Campo_Divisible As String

        If CBool(_Cantidad) Then

            If IsNumeric(_Cantidad) Then
                If CInt(_Cantidad) = _Cantidad Then
                    ' es entero
                    _Cant_Tiene_Decimales = False
                Else
                    ' es decimal
                    _Cant_Tiene_Decimales = True
                End If
            End If

            Dim _Solo_Enteros_Ud1, _Solo_Enteros_Ud2 As Boolean

            If _Cant_Tiene_Decimales Then
                If _Divisible = "0" Or _Divisible = "N" Then
                    Fx_Solo_Enteros = True
                End If
            End If

        Else
            Return True
        End If

    End Function

    Function Trae_CostoUc(ByVal Codigo As String, ByVal Unidad As Integer) As Double
        Dim CostoUc As Double
        CostoUc = _Sql.Fx_Trae_Dato("MAEPREM", "PPUL0" & Unidad,
                            "KOPR = '" & Codigo & "' and EMPRESA = '" & ModEmpresa & "'", True)
        Return CostoUc
    End Function

    Function Trae_PM(ByVal Codigo As String) As Double
        Dim CostoPm As Double
        CostoPm = _Sql.Fx_Trae_Dato("MAEPREM", "PM", "KOPR = '" & Codigo & "' and EMPRESA = '" & ModEmpresa & "'", True)
        Return CostoPm
    End Function

    Function Trae_PM_Suc(ByVal Codigo As String) As Double
        Dim CostoPmSuc As Double
        CostoPmSuc = _Sql.Fx_Trae_Dato("MAEPMSUC", "PMSUC",
                            "KOPR = '" & Codigo &
                            "' and EMPRESA = '" & ModEmpresa & "' And KOSU = '" & ModSucursal & "'", True)
        Return CostoPmSuc
    End Function

    Function Fx_Revisar_Taza_Cambio(ByVal _Formulario As Form,
                                    Optional ByVal _Fecha_Taza As Date = Nothing) As Boolean

        _Sql = New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Revisa_Taza_Cambio As Boolean = _Global_Row_Configuracion_General.Item("Revisa_Taza_Cambio")
        Dim _Revisar_Taza_Solo_Mon_Extranjeras As Boolean = _Global_Row_Configuracion_General.Item("Revisar_Taza_Solo_Mon_Extranjeras")

        If _Revisa_Taza_Cambio Then

            Dim _Fecha As String

            If (_Fecha_Taza = Nothing) Then
                _Fecha_Taza = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)
            End If

            _Fecha = Format(_Fecha_Taza, "yyyyMMdd")


            Dim _CantMonedas As Integer = _Sql.Fx_Cuenta_Registros("TABMO", "TIMO = 'E' Or KOMO <> '$'")

            Consulta_sql = "Select Distinct KOMO From MAEMO Where (FEMO = '" & _Fecha & "' AND TIMO = 'E') Or " &
                           "(FEMO = '" & _Fecha & "' And KOMO <> '$')"
            Dim _CantMonedas_Con_Taza = _Sql.Fx_Get_Tablas(Consulta_sql)

            If CBool(_CantMonedas) Then

                If _CantMonedas_Con_Taza.Rows.Count = _CantMonedas Then
                    Return True
                Else

                    Consulta_sql = "Select *,(select COUNT(*) from TABMO WHERE TIMO = 'E') as NroMonedas" & vbCrLf &
                                   "From TABMO Where TIMO = 'E' Or KOMO <> '$'" & vbCrLf &
                                   "And KOMO Not IN (Select Distinct KOMO From MAEMO Where FEMO = '" & _Fecha & "')"

                    Dim _TblMoneda As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                    Dim _Monedas = String.Empty
                    For Each _Filas As DataRow In _TblMoneda.Rows
                        Dim _Revisar = False
                        Dim _Timo = _Filas.Item("TIMO")

                        If _Revisar_Taza_Solo_Mon_Extranjeras Then
                            If _Timo = "E" Then
                                _Revisar = True
                            End If
                        Else
                            _Revisar = True
                        End If

                        If _Revisar Then
                            _Monedas += _Filas.Item("KOMO") & "-" & Trim(_Filas.Item("NOKOMO") & vbCrLf)
                        End If
                    Next

                    If String.IsNullOrEmpty(_Monedas) Then
                        Return True
                    Else
                        MessageBoxEx.Show(_Formulario, "No existe taza de cambio para la fecha: " & FormatDateTime(_Fecha_Taza, DateFormat.ShortDate) & vbCrLf &
                                                                                                          "Para las monedas: " & vbCrLf & vbCrLf & _Monedas, "Validación",
                                                                                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If

            Else
                Return True
            End If
        Else
            Return True
        End If

    End Function

End Module

Public Module Modulo_Precios_Costos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub Actualizar_Precio_BkRandom(ByVal _Lista As String,
                                          ByVal _Tabla As String,
                                          ByVal _Condicion_Extra As String,
                                          ByVal _ActualizarFormula As Boolean)

        Dim _Formula = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_ListaPreGlobal", "FormulaPrecio", "Lista = '" & _Lista & "'")
        Dim _Formula2 = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_ListaPreGlobal", "FormulaPrecio2", "Lista = '" & _Lista & "'")

        Consulta_sql =
                    "INSERT INTO " & _Tabla & " (Lista, Codigo, Formula,Formula2, Redondear, Precio, Margen, DsctoMax)" & vbCrLf &
                    "SELECT KOLT,KOPR,'" & _Formula & "','" & _Formula2 & "',1,0,MG01UD,DTMA01UD FROM TABPRE" & vbCrLf &
                    "WHERE KOLT = '" & _Lista & "'" & vbCrLf &
                    "And KOPR Not In (Select Codigo From " & _Tabla & " " & _Condicion_Extra & " Where Lista = '" & _Lista & "')"

        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Public Sub Sb_Actualizar_Precio_Formula_BkRandom(ByVal _Lista As String,
                                                     ByVal _TblProductos As DataTable)


        If CBool(_TblProductos.Rows.Count) Then

            For Each _Fila As DataRow In _TblProductos.Rows

                Dim _Codigo As String = _Fila.Item("Codigo")
                Dim _Rtu As Double = _Fila.Item("Rtu")

                Consulta_sql = "Select top 1 *,CAST( 0 AS Float) AS Pm,CAST( 0 AS Float) AS UC_Ud1,CAST( 0 AS Float) AS UC_Ud2" & vbCrLf &
                               "From Zw_ListaPreProducto Where Lista = '" & _Lista & "' And Codigo = '" & _Codigo & "'"

                ' Dim _DsPrecios As DataSet = _Sql _Sql.Fx_Get_DataSet(Consulta_sql)
                Dim _RowPrecio As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                _RowPrecio.Item("Pm") = Trae_PM(_Codigo)
                _RowPrecio.Item("UC_Ud1") = Trae_CostoUc(_Codigo, 1)
                _RowPrecio.Item("UC_Ud2") = Trae_CostoUc(_Codigo, 2)

                _RowPrecio.Item("Rtu") = _Rtu

                _Fila.Item("Precio_Ud1") = Fx_Precio_Formula(_Campo_Precio.Precio_Ud1, _RowPrecio)
                _Fila.Item("Precio_Ud2") = Fx_Precio_Formula(_Campo_Precio.Precio_Ud2, _RowPrecio)

            Next



        End If

    End Sub

    Enum _Campo_Precio
        Precio_Ud1
        Precio_Ud2
    End Enum

    Function Fx_Precio_Formula(ByVal _CPrecio As _Campo_Precio,
                               ByVal _RowPrecio As DataRow)

        Dim _Ej_Fx_documento As Boolean = _RowPrecio.Item("Ej_Fx_documento")

        Dim _Lista = _RowPrecio.Item("Lista")
        Dim _Codigo = _RowPrecio.Item("Codigo")

        Dim _Rtu = De_Num_a_Tx_01(_RowPrecio.Item("Rtu"), False, 5)
        Dim _Precio As Double '= _RowPrecio.Item("Precio")
        'im _Precio2 As Double = _RowPrecio.Item("Precio2")

        Dim _Formula '= Split(_RowPrecio.Item("Formula"), "#")

        If _CPrecio = _Campo_Precio.Precio_Ud1 Then
            _Formula = Split(_RowPrecio.Item("Formula"), "#")
            _Precio = _RowPrecio.Item("Precio")
        Else
            _Formula = Split(_RowPrecio.Item("Formula2"), "#")
            _Precio = _RowPrecio.Item("Precio2")
        End If

        'Dim _Formula2 = Split(_RowPrecio.Item("Formula2"), "#")

        Dim _Flete = De_Num_a_Tx_01(_RowPrecio.Item("Flete"), False, 5)
        Dim _Margen = De_Num_a_Tx_01(_RowPrecio.Item("Margen"), False, 5)
        Dim _Margen_Adicional = De_Num_a_Tx_01(_RowPrecio.Item("Margen_Adicional"), False, 5)
        Dim _Margen2 = De_Num_a_Tx_01(_RowPrecio.Item("Margen2"), False, 5)
        Dim _Margen_Adicional2 = De_Num_a_Tx_01(_RowPrecio.Item("Margen_Adicional2"), False, 5)
        Dim _Costo = De_Num_a_Tx_01(_RowPrecio.Item("Costo"), False, 5)
        Dim _Costo2 = De_Num_a_Tx_01(_RowPrecio.Item("Costo2"), False, 5)

        Dim _Pm = De_Num_a_Tx_01(_RowPrecio.Item("Pm"), False, 5)
        Dim _UC_Ud1 = De_Num_a_Tx_01(_RowPrecio.Item("UC_Ud1"), False, 5)
        Dim _UC_Ud2 = De_Num_a_Tx_01(_RowPrecio.Item("UC_Ud2"), False, 5)

        Dim _Fx1, _Fx2, _Redondeo
        Dim _New_Precio

        If _Ej_Fx_documento Then
            If CBool(_Formula.Length) Then
                _Fx1 = _Formula(0)

                If _Formula.Length > 1 Then
                    _Redondeo = _Formula(1)
                Else
                    _Redondeo = 0
                End If

                _Fx1 = Replace(_Fx1, "Flete", _Flete)
                '_Fx1 = Replace(_Fx1, "Ila", 1)
                '_Fx1 = Replace(_Fx1, "Iva", 1)
                _Fx1 = Replace(_Fx1, "Costo", _Costo)
                _Fx1 = Replace(_Fx1, "Costo2", _Costo2)
                _Fx1 = Replace(_Fx1, "Rtu", _Rtu)
                _Fx1 = Replace(_Fx1, "Pm", _Pm)
                _Fx1 = Replace(_Fx1, "UC_Ud1", _UC_Ud1)
                _Fx1 = Replace(_Fx1, "UC_Ud2", _UC_Ud2)
                _Fx1 = Replace(_Fx1, "Margen", _Margen)
                _Fx1 = Replace(_Fx1, "Margen_Adicional", _Margen_Adicional)
                _Fx1 = Replace(_Fx1, "Margen2", _Margen2)
                _Fx1 = Replace(_Fx1, "Margen_Adicional2", _Margen_Adicional2)

                _Fx1 = Replace(_Fx1, ",", ".")

                Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

                Consulta_sql = "Select " & _Fx1 & " As Valor"
                Dim _RowPr As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                _Precio = _RowPr.Item("Valor") '_Sql.Fx_Trae_Dato(, _Fx1, "", "") '_
                '   "Lista = '" & _Lista & "' And Codigo = '" & _Codigo & "'")

                _New_Precio = Fx_Redondear_Precio(_Precio, _Redondeo)

            End If
        Else
            _New_Precio = _Precio
        End If

        Return _New_Precio

    End Function

    Function Fx_Precio_Formula_Random(ByVal _RowPrecio As DataRow,
                                      ByVal _Campo_Precio As String,
                                      ByVal _Campo_Ecuacion As String,
                                      ByVal _RowCostos_PM As DataRow)


        If (_RowPrecio Is Nothing) Then
            Return 0
        End If

        Dim _Lista = _RowPrecio.Item("KOLT")
        Dim _Codigo = _RowPrecio.Item("KOPR")

        Dim _Rtu = De_Num_a_Tx_01(_RowPrecio.Item("RLUD"), False, 5)
        Dim _Precio As Double '= _RowPrecio.Item("Precio")
        'im _Precio2 As Double = _RowPrecio.Item("Precio2")

        Dim _Formula '= Split(_RowPrecio.Item("Formula"), "#")

        'If _Unidada = 1 Then
        _Formula = Split(_RowPrecio.Item(_Campo_Ecuacion), "#")
        _Precio = _RowPrecio.Item(_Campo_Precio)
        'Else
        '_Formula = Split(_RowPrecio.Item("ECUACION2"), "#")
        '_Precio = _RowPrecio.Item("PP02UD")
        'End If

        Dim _Mg01ud = De_Num_a_Tx_01(_RowPrecio.Item("MG01UD"), False, 5)
        Dim _Mg02ud = De_Num_a_Tx_01(_RowPrecio.Item("MG02UD"), False, 5)

        Dim _Pm As String = 0
        Dim _Ppul01 As String = 0
        Dim _Ppul02 As String = 0

        If (_RowCostos_PM Is Nothing) Then

            Consulta_sql = "Select Top 1 PM,PM AS PM01,PPUL01,PPUL02 From MAEPREM Where EMPRESA = '" & ModEmpresa & "' And KOPR = '" & _Codigo & "'"
            _RowCostos_PM = _Sql.Fx_Get_DataRow(Consulta_sql)

        End If

        If Not (_RowCostos_PM Is Nothing) Then

            _Pm = _RowCostos_PM.Item("PM01")
            _Ppul01 = _RowCostos_PM.Item("PPUL01")
            _Ppul02 = _RowCostos_PM.Item("PPUL02")

        End If


        Dim _Fx1, _Fx2, _Redondeo
        Dim _New_Precio


        If CBool(_Formula.Length) Then
            _Fx1 = UCase(_Formula(0))

            If _Formula.Length > 1 Then
                _Redondeo = Trim(_Formula(1))
            Else
                _Redondeo = 0
            End If

            _Fx1 = Replace(_Fx1, "RLUD", _Rtu)
            '_Fx1 = Replace(_Fx1, "PM01", _Pm)
            _Fx1 = Replace(_Fx1, "PM", _Pm)
            _Fx1 = Replace(_Fx1, "PPUL01", _Ppul01)
            _Fx1 = Replace(_Fx1, "PPUL02", _Ppul02)
            _Fx1 = Replace(_Fx1, "MG01UD", _Mg01ud)
            _Fx1 = Replace(_Fx1, "MG02UD", _Mg02ud)

            _Fx1 = Replace(_Fx1, ",", ".")

            Consulta_sql = "Select " & _Fx1 & " As Valor"
            Dim _RowPr As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            _Precio = _RowPr.Item("Valor")

            _Redondeo = Fx_Redondeo_Random(_Redondeo)
            _New_Precio = Fx_Redondear_Precio(_Precio, _Redondeo)

        Else
            _New_Precio = _Precio
        End If

        Return _New_Precio

    End Function

    Function Fx_Redondeo_Random(ByVal _Redondeo As String) As Redondeo

        Select Case _Redondeo
            Case 1
                Return Redondeo.Redondear_2_decimales
            Case 2
                Return Redondeo.Redondear_1_decimales
            Case 3
                Return Redondeo.Redondear_0_decimales
            Case 4
                Return Redondeo.Redondear_con_multiplo_de_5
            Case 5
                Return Redondeo.Redondear_a_la_decena_mas_proxima
            Case 6
                Return Redondeo.Redondear_con_multiplo_de_5
            Case 7
                Return Redondeo.No_aplicar_redondeo
            Case 8
                Return Redondeo.Redondear_a_la_centena_mas_proxima
            Case 9
                Return Redondeo.Redondear_990
            Case "E"
                Return Redondeo.Redondear_al_entero_superior
            Case "F"
                Return Redondeo.Redondear_4_decimales
            Case "T"
                Return Redondeo.Redondear_3_decimales
            Case Else
                Return Redondeo.No_aplicar_redondeo
        End Select

    End Function

    Enum Redondeo
        No_aplicar_redondeo
        Redondear_0_decimales
        Redondear_1_decimales
        Redondear_2_decimales
        Redondear_3_decimales
        Redondear_4_decimales
        Redondear_5_decimales
        Redondear_a_la_decena_mas_proxima
        Redondear_a_la_centena_mas_proxima
        Redondear_con_multiplo_de_5
        Redondear_990
        Redondear_al_entero_superior
    End Enum

    Function Fx_Redondear_Precio(ByVal _Precio As Double, ByVal _Redondedo As Redondeo) As Double

        Dim _Valor As String = De_Num_a_Tx_01(_Precio, False, 5)

        Dim _Redondear, _UltNro, _Digito As Integer
        Dim _Red As Boolean

        Select Case _Redondedo

            Case Redondeo.No_aplicar_redondeo

                Return _Precio

            Case Redondeo.Redondear_0_decimales

                _Precio = Math.Round(_Precio, 0)

            Case Redondeo.Redondear_1_decimales

                '_Precio = Math.Round(_Precio, 1, MidpointRounding.ToEven)
                _Precio = De_Txt_a_Num_01(_Valor, 1)

            Case Redondeo.Redondear_2_decimales

                '_Precio = Math.Round(_Precio, 2, MidpointRounding.ToEven)
                _Precio = De_Txt_a_Num_01(_Valor, 2)

            Case Redondeo.Redondear_3_decimales

                '_Precio = Math.Round(_Precio, 3, MidpointRounding.ToEven)
                _Precio = De_Txt_a_Num_01(_Valor, 3)

            Case Redondeo.Redondear_4_decimales

                '_Precio = Math.Round(_Precio, 4, MidpointRounding.ToEven)
                _Precio = De_Txt_a_Num_01(_Valor, 4)

            Case Redondeo.Redondear_5_decimales

                '_Precio = Math.Round(_Precio, 5, MidpointRounding.ToEven)
                _Precio = De_Txt_a_Num_01(_Valor, 5)


            Case Redondeo.Redondear_a_la_decena_mas_proxima

                _Precio = Math.Round(_Precio, 0)
                Dim _Decena = Split(_Precio, ".")
                Dim _Len = Len(_Decena(0))
                Dim _Ult_Dig = Mid(_Decena(0), _Len, 1)

                If _Ult_Dig = 0 And _Decena.Length = 1 Then
                    Return _Precio
                End If

                _Redondear = 10
                _UltNro = 1
                _Red = True

            Case Redondeo.Redondear_a_la_centena_mas_proxima

                _Redondear = 100
                _UltNro = 2
                _Red = True

            Case Redondeo.Redondear_con_multiplo_de_5

                _Redondear = 5
                _UltNro = 1
                _Red = True

            Case Redondeo.Redondear_990

                _Redondear = 990
                _UltNro = 3
                _Red = True

            Case Redondeo.Redondear_al_entero_superior

                _Valor = De_Num_a_Tx_01(_Precio, False, 1)
                _Digito = CInt(Right(_Valor, 1))
                _Precio = Math.Round(_Precio, 0)
                If _Digito > 0 And _Digito < 5 Then
                    _Precio += 1
                End If

            Case Else

        End Select

        If _Red Then

            _Valor = De_Num_a_Tx_01(_Precio, True, 0)

            _Digito = CInt(Right(_Valor, _UltNro))
            _Precio = (_Valor - _Digito) + _Redondear
        End If

        Return _Precio

    End Function

End Module

