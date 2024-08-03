Imports System.IO
Imports System.Security.Cryptography
Imports BkSpecialPrograms.Bk_Migrar_Producto
Imports DevComponents.DotNetBar
Imports Newtonsoft.Json
Public Module Funciones_Especiales_BakApp

    Dim Consulta_sql As String

    Function Fx_Formato_Modalidad(_Formulario As Form,
                                  _Modalidad As String,
                                  _TipoDoc As String, _Mostrar_Mensaje As Boolean) As DataRow

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _NombreFormato As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad",
                                                         "NombreFormato",
                                                         "Empresa = '" & ModEmpresa & "' And Modalidad = '" & _Modalidad & "' And TipoDoc = '" & _TipoDoc & "'",, _Mostrar_Mensaje)

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Format_01" & vbCrLf &
                       "Where TipoDoc = '" & _TipoDoc & "' And NombreFormato = '" & _NombreFormato & "'"
        Dim _RowFormato As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, _Mostrar_Mensaje)

        If _RowFormato Is Nothing Then

            Consulta_sql = "Select top 1 * From TABTIDO Where TIDO = '" & _TipoDoc & "'"
            Dim _RowTido As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, _Mostrar_Mensaje)

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

    Function Fx_Es_Electronico(_Tido As String) As Boolean

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

    Function Fx_Conectar_Empresa(_Formulario As Form, ByRef _Conectar_Empresa As Boolean) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Dir_Local As String = Application.StartupPath & "\Data\"

        'Select Case TOP(200) Rut, Razon, NombreCorto, Direccion, Giro, Ciudad, Pais, Telefonos, Libre, Fecha_caduca, Cant_licencias, Llave1, Llave2, Llave3, Llave4, Activa
        'From Zw_Licencia

        Dim _Class_BaseBk As New Class_Conectar_Base_BakApp(_Formulario)

        If _Class_BaseBk.Pro_Existe_Base Then
            _Global_BaseBk = _Class_BaseBk.Pro_Row_Tabcarac.Item("Global_BaseBk")
        Else

            MessageBoxEx.Show(_Formulario, "No esta configurada la base de datos de BakApp",
                              "Falta identificación de base BakApp", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                              MessageBoxDefaultButton.Button1, _Formulario.TopMost)

            If _Class_BaseBk.Fx_Grabar_Base_Bakapp_En_Tabcarac() Then
                _Global_BaseBk = Trim(_Class_BaseBk.Pro_Row_Tabcarac.Item("Global_BaseBk"))
            Else
                Return False
            End If
        End If

        Dim Rev_Estruc_Db As New Clas_Estructura_Base_De_Datos
        Rev_Estruc_Db.Sb_Revisar_Tabla(_Formulario, "Zw_Licencia", True)

        Consulta_sql = "Select EMPRESA From CONFIGP
                        Where RUT In (Select Rut From " & _Global_BaseBk & "Zw_Licencia Where Activa = 1)"
        Dim _Tbl_Configp As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Empresa As String

        If IsNothing(_Tbl_Configp) Then
            _Empresa = "01"
        Else
            If CBool(_Tbl_Configp.Rows.Count) Then
                If _Tbl_Configp.Rows.Count = 1 Then
                    _Empresa = _Tbl_Configp.Rows(0).Item("EMPRESA")
                Else
                    Dim _Fm As New Frm_Multiempresa_Random
                    _Fm.ShowDialog(_Formulario)
                    _Empresa = _Fm.Pro_Empresa_Seleccionada
                    _Fm.Dispose()
                End If
            End If
        End If


        If String.IsNullOrEmpty(_Empresa) Then
            Return False
        End If

        ModEmpresa = _Empresa

        Consulta_sql = "Select * From CONFIGP Where EMPRESA = " & ModEmpresa
        _Global_Row_Configp = _Sql.Fx_Get_DataRow(Consulta_sql)

        RazonEmpresa = _Global_Row_Configp.Item("RAZON").ToString.Trim
        DireccionEmpresa = _Global_Row_Configp.Item("DIRECCION").ToString.Trim
        RutEmpresa = _Global_Row_Configp.Item("RUT").ToString.Trim
        RutEmpresaActiva = RutEmpresa

        If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Empresas") Then

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Empresas Where Empresa = '" & ModEmpresa & "'"
            _Global_Row_Empresa = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Global_Row_Empresa) Then

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Empresas (Empresa,Rut,Razon,Ncorto,Direccion,Pais,Ciudad,Giro)" & vbCrLf &
                               "Select EMPRESA,RUT,RAZON,NCORTO,DIRECCION,PAIS,CIUDAD,GIRO From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Empresas Where Empresa = '" & ModEmpresa & "'"
                _Global_Row_Empresa = _Sql.Fx_Get_DataRow(Consulta_sql)

            End If

            RazonEmpresa = _Global_Row_Empresa.Item("Razon").ToString.Trim
            DireccionEmpresa = _Global_Row_Empresa.Item("Direccion").ToString.Trim
            'RutEmpresa = _Global_Row_Empresa.Item("Rut").ToString.Trim
            RutEmpresaActiva = _Global_Row_Empresa.Item("Rut").ToString.Trim

            RutEmpresa = RutEmpresaActiva

        End If

        Sb_Revisar_Zw_Productos()

        If Fx_Licencia(_Formulario, RutEmpresa) Then

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Licencia Where Rut = '" & RutEmpresa & "'"
            Dim _TblLicencia As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _Fecha_caduca = _TblLicencia.Rows(0).Item("Fecha_caduca")

            Dim _Dias = DateDiff(DateInterval.Day, FechaDelServidor, _Fecha_caduca)

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Configuracion (Empresa,Modalidad)" & vbCrLf &
                           "Select EMPRESA,MODALIDAD From CONFIEST" & vbCrLf &
                           "Where MODALIDAD NOT IN (Select Modalidad From " & _Global_BaseBk & "Zw_Configuracion) And EMPRESA <> ''"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        Else

            _Conectar_Empresa = True

            Return False

        End If

        RutEmpresa = RutEmpresaActiva

        If Not Directory.Exists(_Dir_Local & RutEmpresa) Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Data\" & RutEmpresa)
        End If

        If Not Directory.Exists(_Dir_Local & RutEmpresa & "\Tmp") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Data\" & RutEmpresa & "\Tmp")
        End If

        If Not Directory.Exists(_Dir_Local & RutEmpresa & "\BkPost") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Data\" & RutEmpresa & "\BkPost")
        End If

        If Not Directory.Exists(_Dir_Local & RutEmpresa & "\Configuracion_Local") Then
            System.IO.Directory.CreateDirectory(_Dir_Local & RutEmpresa & "\Configuracion_Local")
        End If


        If Not Directory.Exists(_Dir_Local & RutEmpresaActiva) Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Data\" & RutEmpresaActiva)
        End If

        If Not Directory.Exists(_Dir_Local & RutEmpresaActiva & "\Tmp") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Data\" & RutEmpresaActiva & "\Tmp")
        End If

        If Not Directory.Exists(_Dir_Local & RutEmpresaActiva & "\BkPost") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Data\" & RutEmpresaActiva & "\BkPost")
        End If

        If Not Directory.Exists(_Dir_Local & RutEmpresaActiva & "\Configuracion_Local") Then
            System.IO.Directory.CreateDirectory(_Dir_Local & RutEmpresaActiva & "\Configuracion_Local")
        End If


        Consulta_sql = "Select Top 1 *" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Configuracion" & vbCrLf &
                       "Where Modalidad = '  '"

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Configuracion", "Modalidad = '  '"))

        If Not CBool(_Reg) Then

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Configuracion (Modalidad) Values ('  ')"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        Dim Cl_Indicadores As New Class_Indicadores_Economicos_Json
        If Cl_Indicadores.Pro_Sitio_Activo Then
            Cl_Indicadores.Sb_Actualizar_Taza_De_Cambio_Hoy()
        End If

        ' -- ACTUALIZAR TABLA DE COLORES PARA DOCUMENTOS
        Consulta_sql = My.Resources.Recursos_Funciones.Colores_Documentos
        Consulta_sql = Replace(Consulta_sql, "Zw_TablaDeCaracterizaciones", _Global_BaseBk & "Zw_TablaDeCaracterizaciones")
        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        ' -- ACTUALIZA PUERTOS LPT PARA SALIDAS DE IMPRESION
        Consulta_sql = My.Resources.Recursos_Funciones.Salidas_LPT
        Consulta_sql = Replace(Consulta_sql, "Zw_TablaDeCaracterizaciones", _Global_BaseBk & "Zw_TablaDeCaracterizaciones")
        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Usuarios", "Password") Then

            ' -- ACTUALIZA TABLA DE USUARIOS DEL SISTEMA
            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Usuarios (NombreUsuario, [Password], CodFuncionario, NomFuncionario, Rut, Direccion, CodPais, CodCiudad,
                        CodComuna, Modalidad_defecto, Telefono_fijo, Telefono_movil, Email, Cargo, Pwfu, Es_Vendedor)
                        Select NOKOFU,'123456',KOFU,NOKOFU,RTFU,DIFU,'CHI',CIFU,CMFU,MODALIDAD,FOFU,FOFU,EMAIL,'',Isnull(PWFU,''),0
                        From TABFU
                        Where KOFU Not In (Select CodFuncionario From " & _Global_BaseBk & "Zw_Usuarios)"
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        End If

        If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Estaciones_Ruta_PDF") Then

            If Not _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Estaciones_Ruta_PDF", "Tipo_Ruta") Then

                Consulta_sql = "Alter Table " & _Global_BaseBk & "Zw_Estaciones_Ruta_PDF ADD Tipo_Ruta Varchar(10) Not NULL Default('')"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Estaciones_Ruta_PDF Set Tipo_Ruta = 'PDF'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

        End If

        Dim _Cl_RevVersion As New Cl_RevVersion
        If Not _Cl_RevVersion.Fx_RevisarEstructuraDeDatos(_Global_Version_BakApp) Then
            MessageBoxEx.Show(_Formulario, "ESTRUCTURA DE LA BASE DE DATOS NO COINCIDE CON LA VERSION" & vbCrLf & vbCrLf &
                              "INFORME DE ESTA SITUACION AL ADMINISTRADOR DEL SISTEMA.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Sb_Actualizar_Formar_De_Pago()

        Return True

    End Function

    Function Fx_Cambiar_Numeracion_Modalidad(_Tido As String,
                                             _Empresa As String,
                                             _Modalidad As String) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Consulta_sql = "Select Top 1 " & _Tido & " From CONFIEST Where EMPRESA = '" & _Empresa & "' And MODALIDAD = '" & _Modalidad & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(_Consulta_sql)

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

                    '_Consulta_sql = "UPDATE CONFIEST SET " & _Tido & " = '" & _ProxNumero & "'" & vbCrLf &
                    '                "WHERE EMPRESA = '" & _Empresa & "' AND  MODALIDAD = '" & _Modalidad & "'"

                    If _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDD" Then

                        _Consulta_sql = "UPDATE CONFIEST SET " &
                                        "GDV = '" & _ProxNumero & "'," & vbCrLf &
                                        "GTI = '" & _ProxNumero & "'," & vbCrLf &
                                        "GDP = '" & _ProxNumero & "'," & vbCrLf &
                                        "GDD = '" & _ProxNumero & "'" & vbCrLf &
                                        "WHERE EMPRESA = '" & ModEmpresa & "' AND  MODALIDAD = '" & _Modalidad & "'"
                    Else
                        _Consulta_sql = "UPDATE CONFIEST SET " & _Tido & " = '" & _ProxNumero & "'" & vbCrLf &
                                    "WHERE EMPRESA = '" & ModEmpresa & "' AND  MODALIDAD = '" & _Modalidad & "'"
                    End If

                End If

            End If

        End If

        If Not String.IsNullOrEmpty(_Consulta_sql) Then
            Return _Sql.Ej_consulta_IDU(_Consulta_sql)
        End If

    End Function

    Private Function Fx_Cambiar_Numeracion_Modalidad2(_Tido As String,
                                                     _Nudo As String,
                                                     _Modalidad As String) As Boolean


        ' _Modalidad = "  "
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Consulta_sql = "Select Top 1 " & _Tido & " From CONFIEST Where MODALIDAD = '" & _Modalidad & "' And EMPRESA = '" & ModEmpresa & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(_Consulta_sql)

        Dim _Nudo_Modalidad As String

        _Consulta_sql = String.Empty

        If CBool(_Tbl.Rows.Count) Then

            _Nudo_Modalidad = _Tbl.Rows(0).Item(_Tido).ToString.Trim

            If String.IsNullOrEmpty(_Nudo_Modalidad) Then
                _Consulta_sql = Fx_Cambiar_Numeracion_Modalidad2(_Tido, _Nudo, "  ")
            ElseIf _Nudo_Modalidad = "0000000000" Then
                _Consulta_sql = String.Empty
            Else

                Dim Continua As Boolean = True

                If Not String.IsNullOrEmpty(Trim(_Nudo_Modalidad)) Then

                    Dim _ProxNumero = Fx_Proximo_NroDocumento(_Nudo, 10)

                    If _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDD" Then

                        _Consulta_sql = "UPDATE CONFIEST SET " &
                                        "GDV = '" & _ProxNumero & "'," & vbCrLf &
                                        "GTI = '" & _ProxNumero & "'," & vbCrLf &
                                        "GDP = '" & _ProxNumero & "'," & vbCrLf &
                                        "GDD = '" & _ProxNumero & "'" & vbCrLf &
                                        "WHERE EMPRESA = '" & ModEmpresa & "' AND  MODALIDAD = '" & _Modalidad & "'"
                    Else
                        _Consulta_sql = "UPDATE CONFIEST SET " & _Tido & " = '" & _ProxNumero & "'" & vbCrLf &
                                    "WHERE EMPRESA = '" & ModEmpresa & "' AND  MODALIDAD = '" & _Modalidad & "'"
                    End If

                End If

            End If

        End If

        If Not String.IsNullOrEmpty(_Consulta_sql) Then
            Return _Sql.Ej_consulta_IDU(_Consulta_sql)
        End If

    End Function

    Public Function Fx_Licencia(_Formulario As Form, _RutEmpresa As String) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Licencia Where Rut = '" & _RutEmpresa & "'"
        Dim _TblLicencia As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If CBool(_TblLicencia.Rows.Count) Then

            With _TblLicencia.Rows(0)

                Dim _Rut = .Item("Rut")
                Dim _Fecha_caduca As Date = FormatDateTime(.Item("Fecha_caduca"), DateFormat.ShortDate)
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

                Dim _FechaDelServidor As Date = FormatDateTime(FechaDelServidor, DateFormat.ShortDate)

                Dim _Dias = DateDiff(DateInterval.Day, _FechaDelServidor, _Fecha_caduca)

                If _Dias > 0 Then

                    If _Dias < 10 Then
                        MessageBoxEx.Show(_Formulario, "Faltan " & _Dias & " días para que caduque la licencia", "Licencia",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return True
                    End If

                Else

                    If MessageBoxEx.Show(_Formulario, "SISTEMA SIN LICENCIAS DE USO" & vbCrLf & vbCrLf &
                                         "¿Desea ingresar una licencia?", "Licencia Expirada",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = DialogResult.Yes Then

                        Dim Fm As New Frm_Licencia_Empresa
                        Fm.ShowDialog(_Formulario)
                        Fm.Dispose()

                    End If

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
                           "From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            MessageBoxEx.Show(_Formulario, "No existe llave para el uso del sistema", "Validación BakApp",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False

        End If

    End Function

    Function Fx_Genera_Licencia_BakApp(_RutEmpresa As String,
                                        _FechaCaduca As Date,
                                        _CantLicencias As Integer,
                                        _Palabra_X As String) As String()

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

    Private Function Encripta_md5(TextoAEncriptar As String) As String

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

    Function MensajeSinPermiso(Nro As String,
                               Optional _CodUsuario As String = "",
                               Optional _NomUsuario As String = "")

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Mensaje As String
        Dim NombrePermiso As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_Permisos",
                                                "DescripcionPermiso", "CodPermiso = '" & Nro & "'")

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

    Public Function Traer_Numero_Documento(_Tido As String,
                                           Optional _NumeroDoc As String = "",
                                           Optional _Modalidad_Seleccionada As String = "",
                                           Optional _Mostrar_Mensaje As Boolean = True,
                                           Optional _Cambiar_Numeracion As Boolean = True,
                                           Optional _Formulario As Form = Nothing)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        If Not IsNothing(_Formulario) Then
            _Formulario.Cursor = Cursors.WaitCursor
        End If

        System.Windows.Forms.Application.DoEvents()

        Dim _Existe_Doc As Integer
        Dim _TipGrab As String
        Dim _Arr_Nudo(1) As String

        Dim _NrNumeroDoco As String

        If String.IsNullOrEmpty(_Modalidad_Seleccionada) Then
            _Modalidad_Seleccionada = Modalidad
        End If

        If String.IsNullOrEmpty(_NumeroDoc.Trim) Then
            If _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDD" Then
                Consulta_sql = "Select GDV As NrNumeroDoco From CONFIEST Where EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '" & _Modalidad_Seleccionada & "'
                                Union
                                Select GTI As NrNumeroDoco From CONFIEST Where EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '" & _Modalidad_Seleccionada & "'
                                Union
                                Select GDP As NrNumeroDoco From CONFIEST Where EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '" & _Modalidad_Seleccionada & "'
                                Union
                                Select GDD As NrNumeroDoco From CONFIEST Where EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '" & _Modalidad_Seleccionada & "'
                                Order By NrNumeroDoco Desc"
                Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                _NrNumeroDoco = _Tbl.Rows(0).Item("NrNumeroDoco")
            Else
                _NrNumeroDoco = _Sql.Fx_Trae_Dato("CONFIEST", _Tido, "EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '" & _Modalidad_Seleccionada & "'")
            End If
        Else
            _NrNumeroDoco = _NumeroDoc
        End If

        If _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDD" Then
            _Existe_Doc = _Sql.Fx_Cuenta_Registros("MAEEDO", "EMPRESA = '" & ModEmpresa & "' And TIDO In ('GDV','GTI','GDP','GDD') And NUDO = '" & _NrNumeroDoco & "'")
        Else
            _Existe_Doc = _Sql.Fx_Cuenta_Registros("MAEEDO", "EMPRESA = '" & ModEmpresa & "' And TIDO = '" & _Tido & "' And NUDO = '" & _NrNumeroDoco & "'")
        End If

        _TipGrab = Fx_Tipo_Grab_Modalidad(_Tido, _NrNumeroDoco)

        Dim Contador = 0

        Dim _ClModalidad As New Clas_Modalidades
        Dim _RowModalidad As DataRow

        If _TipGrab = "EnBlanco" Then

            _RowModalidad = _ClModalidad.Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.General, _Modalidad_Seleccionada)
            _NrNumeroDoco = _RowModalidad.Item(_Tido)

            If _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDD" Then
                Consulta_sql = "Select GDV As NrNumeroDoco From CONFIEST Where EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '  '
                                Union
                                Select GTI As NrNumeroDoco From CONFIEST Where EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '  '
                                Union
                                Select GDP As NrNumeroDoco From CONFIEST Where EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '  '
                                Union
                                Select GDD As NrNumeroDoco From CONFIEST Where EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '  '
                                Order By NrNumeroDoco Desc"
                Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                _NrNumeroDoco = _Tbl.Rows(0).Item("NrNumeroDoco")
            Else
                _NrNumeroDoco = _Sql.Fx_Trae_Dato("CONFIEST", _Tido, "EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '  '")
            End If

            If _Cambiar_Numeracion Then

                If _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDD" Then
                    _Existe_Doc = _Sql.Fx_Cuenta_Registros("MAEEDO", "EMPRESA = '" & ModEmpresa & "' And TIDO In ('GDV','GTI','GDP','GDD') And NUDO = '" & _NrNumeroDoco & "'")
                Else
                    _Existe_Doc = _Sql.Fx_Cuenta_Registros("MAEEDO", "EMPRESA = '" & ModEmpresa & "' And TIDO = '" & _Tido & "' And NUDO = '" & _NrNumeroDoco & "'")
                End If

                Do While CBool(_Existe_Doc)

                    Dim _Proximo_Nro As String = Fx_Proximo_NroDocumento(_NrNumeroDoco, 10)

                    If _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDD" Then
                        Consulta_sql = "UPDATE CONFIEST SET GDV = '" & _Proximo_Nro & "',GTI = '" & _Proximo_Nro & "',GDP = '" & _Proximo_Nro & "',GDD = '" & _Proximo_Nro & "'" & vbCrLf &
                                       "WHERE EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '  '"
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        Consulta_sql = "Select GDV As NrNumeroDoco From CONFIEST Where EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '  '
                                        Union
                                        Select GTI As NrNumeroDoco From CONFIEST Where EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '  '
                                        Union
                                        Select GDP As NrNumeroDoco From CONFIEST Where EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '  '
                                        Union
                                        Select GDD As NrNumeroDoco From CONFIEST Where EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '  '
                                        Order By NrNumeroDoco Desc"
                        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                        _NrNumeroDoco = _Tbl.Rows(0).Item("NrNumeroDoco")
                        _Existe_Doc = _Sql.Fx_Cuenta_Registros("MAEEDO", "EMPRESA = '" & ModEmpresa & "' And TIDO In ('GDV','GTI','GDP','GDD') And NUDO = '" & _NrNumeroDoco & "'")
                    Else
                        Consulta_sql = "UPDATE CONFIEST SET " & _Tido & " = '" & _Proximo_Nro & "'" & vbCrLf &
                                       "WHERE EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '  '"
                        _Sql.Ej_consulta_IDU(Consulta_sql)
                        _NrNumeroDoco = _Sql.Fx_Trae_Dato("CONFIEST", _Tido, "EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '  '")
                        _Existe_Doc = _Sql.Fx_Cuenta_Registros("MAEEDO", "EMPRESA = '" & ModEmpresa & "' And TIDO = '" & _Tido & "' And NUDO = '" & _NrNumeroDoco & "'")
                    End If

                Loop

            End If

        ElseIf _TipGrab = "Puros_Ceros" Then

            If _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDD" Then
                _NrNumeroDoco = _Sql.Fx_Trae_Dato("MAEEDO", "COALESCE(MAX(NUDO),'0000000000')", "EMPRESA = '" & ModEmpresa & "' And TIDO In ('GDV','GTI','GDP','GDD')")
            Else
                _NrNumeroDoco = _Sql.Fx_Trae_Dato("MAEEDO", "COALESCE(MAX(NUDO),'0000000000')", "EMPRESA = '" & ModEmpresa & "' And TIDO = '" & _Tido & "'")
            End If

            _NrNumeroDoco = Fx_Rellena_ceros(_NrNumeroDoco, 10, True)

            _Existe_Doc = 0

        ElseIf _TipGrab = "Con_Numeración" Then

            If _Cambiar_Numeracion Then

                Dim _MaxCuenta = 100
                Dim _Contador = 1
                Dim _ngTiempoTranscurrido As Double
                Dim _dteInicio As DateTime = DateTime.Now
                Dim _dteFinal As DateTime

                Do While CBool(_Existe_Doc)

                    Dim _Proximo_Nro As String = Fx_Proximo_NroDocumento(_NrNumeroDoco, 10)

                    If _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDD" Then

                        Consulta_sql = "UPDATE CONFIEST SET GDV = '" & _Proximo_Nro & "',GTI = '" & _Proximo_Nro & "',GDP = '" & _Proximo_Nro & "',GDD = '" & _Proximo_Nro & "'" & vbCrLf &
                                       "WHERE EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '" & _Modalidad_Seleccionada & "'"
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        Consulta_sql = "Select GDV As Tido From CONFIEST Where EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '" & _Modalidad_Seleccionada & "'
                                        Union
                                        Select GTI As Tido From CONFIEST Where EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '" & _Modalidad_Seleccionada & "'
                                        Union
                                        Select GDP As Tido From CONFIEST Where EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '" & _Modalidad_Seleccionada & "'
                                        Union
                                        Select GDD As Tido From CONFIEST Where EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '" & _Modalidad_Seleccionada & "'
                                        Order By Tido Desc"
                        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
                        _NrNumeroDoco = _Tbl.Rows(0).Item("Tido")

                        _Existe_Doc = _Sql.Fx_Cuenta_Registros("MAEEDO", "EMPRESA = '" & ModEmpresa & "' And TIDO In ('GDV','GTI','GDP','GDD') And NUDO = '" & _NrNumeroDoco & "'")
                        _Contador += 1
                        _dteFinal = DateTime.Now
                        _ngTiempoTranscurrido = DateDiff(DateInterval.Second, _dteInicio, _dteFinal)

                        If _Existe_Doc Then
                            If _ngTiempoTranscurrido >= 10 Then
                                Exit Do
                            End If
                        End If

                    Else

                        Consulta_sql = "UPDATE CONFIEST SET " & _Tido & " = '" & _Proximo_Nro & "' WHERE EMPRESA = '" & ModEmpresa & "' AND  MODALIDAD = '" & _Modalidad_Seleccionada & "'"
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        _NrNumeroDoco = _Sql.Fx_Trae_Dato("CONFIEST", _Tido, "EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '" & _Modalidad_Seleccionada & "'")
                        _Existe_Doc = _Sql.Fx_Cuenta_Registros("MAEEDO", "EMPRESA = '" & ModEmpresa & "' And TIDO = '" & _Tido & "' And NUDO = '" & _NrNumeroDoco & "'")
                        _Contador += 1
                        _dteFinal = DateTime.Now
                        _ngTiempoTranscurrido = DateDiff(DateInterval.Second, _dteInicio, _dteFinal)

                        If _Existe_Doc Then
                            If _ngTiempoTranscurrido >= 10 Then
                                Exit Do
                            End If
                        End If

                    End If

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
                              "El documento " & _Tido & " Nro " & _NrNumeroDoco & " ya exite en el sistema",
                              eTaskDialogButton.Close _
                              , eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)
                    Dim result As eTaskDialogResult = TaskDialog.Show(info)

                End If

                _NrNumeroDoco = String.Empty

            End If

        End If

        If Not IsNothing(_Formulario) Then
            _Formulario.Cursor = Cursors.Default
        End If

        Return _NrNumeroDoco

    End Function

    Public Function Fx_Tipo_Grab_Modalidad(_TipoDoc As String,
                                           _NrNumeroDoco As String) As String


        Dim Continua As Boolean = True

        If String.IsNullOrEmpty(Trim(_NrNumeroDoco)) Then
            Return "EnBlanco"
        ElseIf _NrNumeroDoco = "0000000000" Then
            Return "Puros_Ceros"
        Else
            Return "Con_Numeración"
        End If

    End Function

    Function _Dev_HoraGrab(Hora As String)

        Dim _HH, _MM, _SS As Double
        Dim _Horagrab As Integer

        _HH = Mid(Hora, 1, 2)
        _MM = Mid(Hora, 4, 2)
        _SS = Mid(Hora, 7, 2)

        _Horagrab = Math.Round((_HH * 3600) + (_MM * 60) + _SS, 0)

        Return _Horagrab

    End Function

    Function Fx_Decodifica_Horagrab(_Horagrab As Integer) As String

        Dim _Hora = Math.Floor(_Horagrab * 1.0 / 3600)
        Dim _Minutos = Math.Floor((_Horagrab * 1.0 / 3600 - _Hora) * 60)
        Dim _Segundos = Math.Round(((_Horagrab * 1.0 / 3600 - _Hora) * 60 - _Minutos) * 60, 0)

        Fx_Decodifica_Horagrab = _Hora & ":" & _Minutos

    End Function

    Function FechaDelServidor() As Date

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "select getdate() As Fecha"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

        If IsNothing(_Row) Then
            FechaDelServidor = Now
        Else
            FechaDelServidor = _Row.Item("Fecha")
        End If

    End Function

    Function Fx_Fecha_y_Hora_del_Servidor() As DateTime

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "select getdate() As Fecha"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
        Fx_Fecha_y_Hora_del_Servidor = _Row.Item("Fecha")

    End Function

    Function Fx_Trae_Permiso_Bk(_CodUsuario As String,
                                _CodPremiso As String) As DataTable

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Tbl As DataTable

        Consulta_sql = "Select * From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf &
                       "Where CodPermiso = '" & _CodPremiso & "' And CodUsuario = '" & _CodUsuario & "'"

        _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

        Return _Tbl

    End Function

    Function Fx_Traer_Datos_Entidad(_CodEntidad As String, _SucEntidad As String) As DataRow

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Row_Entidad As DataRow

        Consulta_sql = My.Resources.Recursos_Entidad.SqlQuery_Datos_Entidad
        Consulta_sql = Replace(Consulta_sql, "#CodEntidad#", _CodEntidad)
        Consulta_sql = Replace(Consulta_sql, "#SucEntidad#", _SucEntidad)

        _Row_Entidad = _Sql.Fx_Get_DataRow(Consulta_sql, False)

        If Not (_Row_Entidad Is Nothing) Then

            Dim _Rut As String = _Row_Entidad.Item("RTEN").ToString.Trim
            Dim _RutSP As String = String.Empty
            Dim _Rten = _Rut
            Dim _Dv As String

            If _Rut.Contains("-") Then
                Dim _Rt = Split(_Rut, "-")
                _Rut = _Rt(0)
            End If
            Try
                _Dv = RutDigito(_Rut)
                _Rut = FormatNumber(_Rut, 0) & "-" & _Dv
                _RutSP = _Rten & "-" & _Dv
            Catch ex As Exception
                _Rut = _Rut
                _RutSP = _Rut
            End Try

            _Row_Entidad.Item("Rut") = _Rut
            _Row_Entidad.Item("RutSP") = _RutSP

        End If

        Return _Row_Entidad

    End Function

    Function Fx_Traer_Datos_Entidad_Tabla(_CodEntidad As String, _SucEntidad As String) As DataTable

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Tbl_Entidad As DataTable

        Consulta_sql = My.Resources.Recursos_Entidad.SqlQuery_Datos_Entidad
        Consulta_sql = Replace(Consulta_sql, "#CodEntidad#", _CodEntidad)
        Consulta_sql = Replace(Consulta_sql, "#SucEntidad#", _SucEntidad)

        If String.IsNullOrWhiteSpace(_SucEntidad) Then
            Consulta_sql = Replace(Consulta_sql, "And SUEN = @SucEntidad", "")
        End If

        _Tbl_Entidad = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _Row_entidad As DataRow In _Tbl_Entidad.Rows

            If Not (_Row_entidad Is Nothing) Then

                'Dim _Rut As String = _Row_entidad.Item("RTEN")

                '_Rut = FormatNumber(_Rut, 0) & "-" & RutDigito(_Rut)
                '_Row_entidad.Item("Rut") = _Rut

                Dim _Rut As String = _Row_entidad.Item("RTEN").ToString.Trim
                Dim _RutSP As String = String.Empty
                Dim _Rten = _Rut
                Dim _Dv As String

                If _Rut.Contains("-") Then
                    Dim _Rt = Split(_Rut, "-")
                    _Rut = _Rt(0)
                End If
                Try
                    _Dv = RutDigito(_Rut)
                    _Rut = FormatNumber(_Rut, 0) & "-" & _Dv
                    _RutSP = _Rten & "-" & _Dv
                Catch ex As Exception
                    _Rut = _Rut
                    _RutSP = _Rut
                End Try

                _Row_entidad.Item("Rut") = _Rut
                _Row_entidad.Item("RutSP") = _RutSP

            End If

        Next

        Return _Tbl_Entidad

    End Function

    Function Fx_Revisar_Nombre_Equipo_BakApp(_Formulario As Form,
                                             _Dir_Empresa As String,
                                             _Rut_Empresa As String,
                                             _Nombre_Equipo As String) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Ds As New DatosBakApp

        Dim _Existe = System.IO.File.Exists(_Dir_Empresa & "\Nombre_Equipo.xml")

        If Not _Existe Then

            MessageBoxEx.Show(_Formulario, "El equipo no está registrado en el sistema" & vbCrLf &
                              "Debe ingresar un nombre al equipo (se sugiere dejar el mismo nombre por defecto)",
                              "Llave de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim _Aceptado As Boolean

            _Aceptado = InputBox_Bk(_Formulario, "Debe ingresar un nombre al equipo" & vbCrLf &
                                         "(se sugiere dejar el mismo)" & vbCrLf &
                                         "Ingrese nombre de la estación de trabajo",
                                         "El equipo no está registrado en el sistema", _Nombre_Equipo, False,
                                         _Tipo_Mayus_Minus.Normal, 0, True, _Tipo_Imagen.Texto, False)

            If _Aceptado Then

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
                NewFila.Item("Nombre_Equipo") = _Nombre_Equipo

                _Ds.Tables("Tbl_Nombre_Equipo").Rows.Add(NewFila)
                _Ds.WriteXml(_Dir_Empresa & "\Nombre_Equipo.xml")

                Return True

            End If

        Else
            Return True
        End If

    End Function

    Public Function Hora_Grab_fx(_HoraAlFinalDelDia As Boolean) As String

        Dim _HH_sistem As Date

        _HH_sistem = FechaDelServidor()

        Dim _HH, _MM, _SS As Double

        _HH = _HH_sistem.Hour
        _MM = _HH_sistem.Minute
        _SS = _HH_sistem.Second

        If _HoraAlFinalDelDia Then
            _HH = 23 : _MM = 59 : _SS = 59
        End If

        Dim _HoraGrab As String = Math.Round((_HH * 3600) + (_MM * 60) + _SS, 0)

        Return _HoraGrab

    End Function

    Function TraeClaveRD(Texto As String) As String

        Dim valorAscii As Integer
        Dim PassEncriptado, Letra As String
        Dim CadenaRD As Long


        Texto = Trim(Texto)
        For _xx = 1 To Len(Texto)
            Letra = Mid(Texto, _xx, 1)
            valorAscii = Asc(Letra)
            'txtAscii.Text = valor.ToString

            If _xx = 1 Then
                CadenaRD = (17225 + valorAscii) * 1
            ElseIf _xx = 2 Then
                CadenaRD = (1847 + valorAscii) * 8
            ElseIf _xx = 3 Then
                CadenaRD = (1217 + valorAscii) * 27
            ElseIf _xx = 4 Then
                CadenaRD = (237 + valorAscii) * 64
            ElseIf _xx = 5 Then
                CadenaRD = (201 + valorAscii) * 125
            End If

            PassEncriptado = PassEncriptado & CadenaRD
            CadenaRD = 0
        Next

        Return PassEncriptado

    End Function

    Function DecryptClaveRD(PassEncriptado As String) As String

        If String.IsNullOrEmpty(PassEncriptado) Then
            Return ""
        End If

        Dim PassDesencriptado As String = ""

        Dim Encriptacion(4, 1) As Integer
        Dim PassSeparado(4) As String
        PassSeparado(0) = Mid(PassEncriptado, 1, 5)
        PassSeparado(1) = Mid(PassEncriptado, 6, 5)
        PassSeparado(2) = Mid(PassEncriptado, 11, 5)
        PassSeparado(3) = Mid(PassEncriptado, 16, 5)
        PassSeparado(4) = Mid(PassEncriptado, 21, 5)

        Encriptacion(0, 0) = 17225
        Encriptacion(0, 1) = 1
        Encriptacion(1, 0) = 1847
        Encriptacion(1, 1) = 8
        Encriptacion(2, 0) = 1217
        Encriptacion(2, 1) = 27
        Encriptacion(3, 0) = 237
        Encriptacion(3, 1) = 64
        Encriptacion(4, 0) = 201
        Encriptacion(4, 1) = 125

        For i = 0 To 4

            If Not PassSeparado(i) = "     " Then
                PassDesencriptado &= Chr((Val(PassSeparado(i)) / Encriptacion(i, 1)) - Encriptacion(i, 0))
            Else
                PassDesencriptado &= ""
            End If

        Next

        Return PassDesencriptado

    End Function

    Function Fx_Cambiar_Numeracion_Modalidad(_Tido As String,
                                             _Modalidad As String) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Consulta_sql = "Select Top 1 " & _Tido & " From CONFIEST Where EMPRESA = '" & ModEmpresa & "' And MODALIDAD = '" & _Modalidad & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(_Consulta_sql)

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

    Function Fx_Proximo_NroDocumento(_NrNumeroDoco As String,
                                     _Cant_Caracteres As Integer) As String

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

        Try
            _NvoNumero1 = CInt(_Cadena) + 1
            _NvoNumero2 = _Prefijo & numero_(_NvoNumero1, Len(_Cadena))
        Catch ex As Exception
            _NvoNumero2 = _NrNumeroDoco
        End Try

        Return _NvoNumero2

    End Function

    Function Fx_Rellenar_NroDocumento_Ccaracteres(_NrNumeroDoco As String,
                                                  _Cant_Caracteres As Integer) As String

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
                _Prefijo = Replace(_NrNumeroDoco, _Caracter, "")
                _Cadena = Right(_NrNumeroDoco, (_Cant_Caracteres + 1) - _Pos)
                Exit Do
            End If

        Loop

        _NvoNumero1 = CInt(_Cadena) '+ 1

        Dim _Nc = _Cant_Caracteres - _Cadena.Length - _Prefijo.Length

        _NvoNumero2 = _Prefijo & numero_(_NvoNumero1, _Cadena.Length + _Nc)

        Return _NvoNumero2

    End Function

    Function Fx_Stock_Disponible(_Tido As String,
                                 _Empresa As String,
                                 _Sucursal As String,
                                 _Bodega As String,
                                 _Codigo As String,
                                 _Ud As Integer,
                                 _Campo As String) As Double


        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Select Top 1 * From TABTIDO Where TIDO = '" & _Tido & "'"
        Dim _RowTido As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Campo_Formula_Stock As String

        Try
            _Campo_Formula_Stock = _RowTido.Item("STOCK")
        Catch ex As Exception
            _Campo_Formula_Stock = String.Empty
        End Try

        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "A", "[A]")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "B", "[B]")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "C", "[C]")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "D", "[D]")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "E", "[E]")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "F", "[F]")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "G", "[G]")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "H", "[H]")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "I", "[I]")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "J", "[J]")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "K", "[K]")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "L", "[L]")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "M", "[M]")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "N", "[N]")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "O", "[O]")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "P", "[P]")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "Q", "[Q]")


        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[A]", "Case When STFI" & _Ud & " < 0 Then 0 Else STFI" & _Ud & " End")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[B]", "Case When STDV" & _Ud & " < 0 Then 0 Else STDV" & _Ud & " End")

        'Comprometido
        '_Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[C]", "(STOCNV" & _Ud & "+Isnull(StComp" & _Ud & ",0))")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[C]",
                                       "(Case When STOCNV" & _Ud & " < 0 Then 0 Else STOCNV" & _Ud & " End+Isnull(Case When StComp" & _Ud & " < 0 Then 0 Else StComp" & _Ud & " End,0))")

        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[D]", "Case When STDV" & _Ud & "C < 0 Then 0 Else STDV" & _Ud & "C End")

        'Pedido
        '_Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[E]", "(STOCNV" & _Ud & "C+Isnull(StPedi" & _Ud & ",0))")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[E]",
                                       "(Case When STOCNV" & _Ud & "C < 0 Then 0 Else STOCNV" & _Ud & "C End+Isnull(Case When StPedi" & _Ud & " < 0 Then 0 Else StPedi" & _Ud & " End,0))")

        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[F]", "Case When DESPNOFAC" & _Ud & " < 0 Then 0 Else DESPNOFAC" & _Ud & " End")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[G]", "Case When RECENOFAC" & _Ud & " < 0 Then 0 Else RECENOFAC" & _Ud & " End")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[H]", "Case When PRESALCLI" & _Ud & " < 0 Then 0 Else PRESALCLI" & _Ud & " End")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[I]", "Case When PRESDEPRO" & _Ud & " < 0 Then 0 Else PRESDEPRO" & _Ud & " End")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[J]", "Case When CONSALCLI" & _Ud & " < 0 Then 0 Else CONSALCLI" & _Ud & " End")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[K]", "Case When CONSDEPRO" & _Ud & " < 0 Then 0 Else CONSDEPRO" & _Ud & " End")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[L]", "Case When DEVENGNCV" & _Ud & " < 0 Then 0 Else DEVENGNCV" & _Ud & " End")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[M]", "Case When DEVENFNCC" & _Ud & " < 0 Then 0 Else DEVENFNCC" & _Ud & " End")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[N]", "Case When DEVSINNCV" & _Ud & " < 0 Then 0 Else DEVSINNCV" & _Ud & " End")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[O]", "Case When DEVSINNCC" & _Ud & " < 0 Then 0 Else DEVSINNCC" & _Ud & " End")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[P]", "Case When STENFAB" & _Ud & " < 0 Then 0 Else STENFAB" & _Ud & " End")
        _Campo_Formula_Stock = Replace(_Campo_Formula_Stock, "[Q]", "Case When STREQFAB" & _Ud & " < 0 Then 0 Else STREQFAB" & _Ud & " End")

        If String.IsNullOrEmpty(_Campo_Formula_Stock) Then
            _Campo_Formula_Stock = _Campo
        End If

        Consulta_sql = "Select " & _Campo_Formula_Stock & " As Stock_Disponible" & vbCrLf &
                       "From MAEST" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Prod_Stock On EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR = Codigo" & vbCrLf &
                       "Where" & vbCrLf &
                       "EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "'" & Space(1) &
                       "And KOBO = '" & _Bodega & "' And KOPR = '" & _Codigo & "'"

        Dim _RowStock As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not (_RowStock Is Nothing) Then
            Fx_Stock_Disponible = _RowStock.Item("Stock_Disponible")
        End If

    End Function

    Public Function Fx_Suma_cantidades(CAMPO As String,
                                       TABLA As String,
                                       Optional condicion As String = "",
                                       Optional Decimales As Integer = 0) As Double

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim Suma As Double

        If condicion <> "" Then
            condicion = " Where " & condicion
        End If

        Consulta_sql = "SELECT ROUND(SUM(" & CAMPO & ")," & Decimales & ") AS CAMPO FROM " & TABLA & condicion & ""
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

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

    Public Function Sb_Enviar_Doc_Por_Mail(_IdMaeedo_Doc As String,
                                           _Email_Para As String,
                                           _Encabezado_Cuerpo As String,
                                           _Pie_Cuerpo As String,
                                           _Form_Origen As Object,
                                           _Mostrar_Precios As Boolean) As Boolean


        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim Crea_Htm As New Clase_Crear_Documento_Htm
        Dim _Ruta As String = AppPath() & "\Data\" & RutEmpresa & "\Tmp"

        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _IdMaeedo_Doc
        Dim _Enc_Documento As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

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

            If Crea_Htm.Fx_Crear_Documento_Htm(_IdMaeedo_Doc, _Ruta, _Mostrar_Precios) Then

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

                Dim _Envio_Occ_Mail As New Class_Outlook

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

                _Envio_Occ_Mail.Sb_Crear_Correo_Outlook(_Para, _Adjunto, _Asunto, _Cuerpo, True)

            End If

            Return True

        Else
            MessageBoxEx.Show(_Form_Origen, "No se encontro el documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

    End Function

    Function Fx_CadenaConexionSQL(NombreConexion As String,
                                  DsConexion As DataSet) As String

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

    Function Fx_Trar_Datos_De_Bodega_Seleccionada(_Empresa As String,
                                                  _Sucursal As String,
                                                  _Bodega As String) As DataRow

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

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
                              _Tabla As String,
                              _Campoxdefecto As String,
                              _Incluir_Fila_Vacia As Boolean)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        caract_combo(_Cmb)

        Dim _SqlFilaVacia = "Select '' As Padre, '' As Hijo,0 As Orden Union" & vbCrLf

        If Not _Incluir_Fila_Vacia Then _SqlFilaVacia = String.Empty

        Consulta_sql = _SqlFilaVacia &
                       "Select CodigoTabla As Padre,NombreTabla as Hijo,Orden" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones" & vbCrLf &
                       "Where Tabla = '" & _Tabla & "'" & vbCrLf &
                       "order by Orden"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
        _Cmb.DataSource = _Tbl
        If CBool(_Tbl.Rows.Count) Then
            _Cmb.SelectedValue = _Campoxdefecto
        End If

    End Sub

    Function Fx_Solo_Enteros(_Cantidad As Double,
                             _Divisible As String) As Boolean

        Dim _Cant_Tiene_Decimales As Boolean

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

            If _Cant_Tiene_Decimales Then
                If _Divisible = "0" Or _Divisible = "N" Then
                    Fx_Solo_Enteros = True
                End If
            End If

        Else
            Return True
        End If

    End Function

    Function Trae_CostoUc(Codigo As String, Unidad As Integer) As Double

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim CostoUc As Double
        CostoUc = _Sql.Fx_Trae_Dato("MAEPREM", "PPUL0" & Unidad,
                            "KOPR = '" & Codigo & "' and EMPRESA = '" & ModEmpresa & "'", True)
        Return CostoUc

    End Function

    Function Trae_PM(Codigo As String) As Double

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim CostoPm As Double
        CostoPm = _Sql.Fx_Trae_Dato("MAEPREM", "PM", "KOPR = '" & Codigo & "' and EMPRESA = '" & ModEmpresa & "'", True)

        Return CostoPm

    End Function

    Function Trae_PM_Suc(Codigo As String) As Double

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim CostoPmSuc As Double
        CostoPmSuc = _Sql.Fx_Trae_Dato("MAEPMSUC", "PMSUC",
                            "KOPR = '" & Codigo &
                            "' and EMPRESA = '" & ModEmpresa & "' And KOSU = '" & ModSucursal & "'", True)

        Return CostoPmSuc

    End Function

    Function Fx_Revisar_Tasa_Cambio(_Formulario As Form,
                                    Optional _Fecha_Tasa As Date = Nothing,
                                    Optional _Revisar_Obligado As Boolean = False,
                                    Optional _Mostrar_Mensaje As Boolean = True) As LsValiciones.Mensajes

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _Revisa_Taza_Cambio As Boolean = True
            Dim _Revisar_Taza_Solo_Mon_Extranjeras As Boolean = _Global_Row_Configuracion_General.Item("Revisar_Taza_Solo_Mon_Extranjeras")

            If _Revisar_Obligado Then
                _Revisa_Taza_Cambio = True
            End If

            If Not _Revisa_Taza_Cambio Then

                _Mensaje.Detalle = "Revisar tasa de cambio"
                _Mensaje.Mensaje = "No se necesita revisar la tasa de cambio"
                _Mensaje.EsCorrecto = True
                _Mensaje.Icono = MessageBoxIcon.Information

                Return _Mensaje

            End If

            Dim _Fecha As String

            If (_Fecha_Tasa = Nothing) Then
                _Fecha_Tasa = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)
            End If

            _Fecha = Format(_Fecha_Tasa, "yyyyMMdd")

            Dim _CantMonedas As Integer = _Sql.Fx_Cuenta_Registros("TABMO", "TIMO = 'E' Or KOMO <> '$'", _Mostrar_Mensaje)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New System.Exception(_Sql.Pro_Error)
                _Mensaje.ErrorDeConexionSQL = True
            End If

            Consulta_sql = "Select Distinct KOMO From MAEMO Where (FEMO = '" & _Fecha & "' AND TIMO = 'E') Or " &
                           "(FEMO = '" & _Fecha & "' And KOMO <> '$')"
            Dim _CantMonedas_Con_Taza = _Sql.Fx_Get_DataTable(Consulta_sql, _Mostrar_Mensaje)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New System.Exception(_Sql.Pro_Error)
                _Mensaje.ErrorDeConexionSQL = True
            End If

            If CBool(_CantMonedas) Then

                If _CantMonedas_Con_Taza.Rows.Count = _CantMonedas Then

                    _Mensaje.Detalle = "Revisar tasa de cambio"
                    _Mensaje.Mensaje = "No se necesita revisar la tasa de cambio"
                    _Mensaje.EsCorrecto = True
                    _Mensaje.Icono = MessageBoxIcon.Information

                    Return _Mensaje

                Else

                    Consulta_sql = "Select *,(select COUNT(*) From TABMO WHERE TIMO = 'E') as NroMonedas" & vbCrLf &
                                   "From TABMO Where (TIMO = 'E' Or KOMO <> '$')" & vbCrLf &
                                   "And KOMO Not IN (Select Distinct KOMO From MAEMO Where FEMO = '" & _Fecha & "')"

                    Dim _TblMoneda As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, _Mostrar_Mensaje)

                    If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                        Throw New System.Exception(_Sql.Pro_Error)
                        _Mensaje.ErrorDeConexionSQL = True
                    End If

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

                        _Mensaje.Detalle = "Revisar tasa de cambio"
                        _Mensaje.Mensaje = "No se necesita revisar la tasa de cambio"
                        _Mensaje.EsCorrecto = True
                        _Mensaje.Icono = MessageBoxIcon.Information

                        Return _Mensaje

                    Else

                        _Mensaje.Mensaje = "No existe tasa de cambio para la fecha: " & FormatDateTime(_Fecha_Tasa, DateFormat.ShortDate) & ", para las monedas: " & _Monedas

                        If Not IsNothing(_Formulario) Then

                            If _Mostrar_Mensaje Then

                                If MessageBoxEx.Show(_Formulario, "No existe tasa de cambio para la fecha: " & FormatDateTime(_Fecha_Tasa, DateFormat.ShortDate) & vbCrLf &
                                                     "Para las monedas: " & vbCrLf & vbCrLf & _Monedas & vbCrLf & vbCrLf & "¿Desea ingresar la tasa de cambio?", "Validación",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = DialogResult.Yes Then

                                    If Fx_Tiene_Permiso(_Formulario, "Espr0032") Then

                                        Dim Fm As New Frm_MonedasLista
                                        Fm.ShowDialog(_Formulario)
                                        Fm.Dispose()

                                    End If

                                End If

                            End If

                        End If

                    End If

                End If

            Else

                _Mensaje.Detalle = "Revisar tasa de cambio"
                _Mensaje.Mensaje = "No se necesita revisar la tasa de cambio"
                _Mensaje.EsCorrecto = True
                _Mensaje.Icono = MessageBoxIcon.Information

                Return _Mensaje

            End If

        Catch ex As Exception
            _Mensaje.Detalle = "Error al revisar tasa de cambio"
            _Mensaje.Mensaje = ex.Message
            _Mensaje.EsCorrecto = False
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function

    Function Fx_Permitir_Vender_Validar_Formato_Modalidad(_Formulario As Form, Tido As String) As Boolean
        Dim _RowFormato As DataRow = Fx_Formato_Modalidad(_Formulario, Modalidad, Tido, True)

        If Not (_RowFormato Is Nothing) Then
            Return True
        Else
            Return False
        End If

    End Function

End Module

Public Module Modulo_Precios_Costos

    'Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub Actualizar_Precio_BkRandom(_Lista As String,
                                          _Tabla As String,
                                          _Condicion_Extra As String,
                                          _ActualizarFormula As Boolean)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Formula = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_ListaPreGlobal", "FormulaPrecio", "Lista = '" & _Lista & "'")
        Dim _Formula2 = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_ListaPreGlobal", "FormulaPrecio2", "Lista = '" & _Lista & "'")

        Consulta_sql =
                    "INSERT INTO " & _Tabla & " (Lista, Codigo, Formula,Formula2, Redondear, Precio, Margen, DsctoMax)" & vbCrLf &
                    "SELECT KOLT,KOPR,'" & _Formula & "','" & _Formula2 & "',1,0,MG01UD,DTMA01UD FROM TABPRE" & vbCrLf &
                    "WHERE KOLT = '" & _Lista & "'" & vbCrLf &
                    "And KOPR Not In (Select Codigo From " & _Tabla & " " & _Condicion_Extra & " Where Lista = '" & _Lista & "')"

        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Public Sub Sb_Actualizar_Precio_Formula_BkRandom(_Lista As String,
                                                     _TblProductos As DataTable)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        If CBool(_TblProductos.Rows.Count) Then

            For Each _Fila As DataRow In _TblProductos.Rows

                Dim _Codigo As String = _Fila.Item("Codigo")
                Dim _Rtu As Double = _Fila.Item("Rtu")

                Consulta_sql = "Select top 1 *,CAST( 0 AS Float) AS Pm,CAST( 0 AS Float) AS UC_Ud1,CAST( 0 AS Float) AS UC_Ud2" & vbCrLf &
                               "From Zw_ListaPreProducto Where Lista = '" & _Lista & "' And Codigo = '" & _Codigo & "'"
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

    Function Fx_Precio_Formula(_CPrecio As _Campo_Precio,
                               _RowPrecio As DataRow)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

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


    Function Fx_Funcion_Ecuacion_Random(_Formulario As Form,
                                        _Koen As String,
                                        _Ecuacion As String,
                                        _Codigo As String,
                                        _UnTrans As String,
                                        _RowPrecios As DataRow,
                                        _Cantidad As Double,
                                        _Caprco1 As Double,
                                        _Caprco2 As Double) As Double

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _PrecioLinea As Double
        Dim _Fx As String
        Dim _Kolt As String

        Dim _Campo_Precio
        Dim _Campo_Ecuacion

        If _UnTrans = 1 Then
            _Campo_Precio = "PP01UD"
            _Campo_Ecuacion = "ECUACION"
        Else
            _Campo_Precio = "PP02UD"
            _Campo_Ecuacion = "ECUACIONU2"
        End If

        _Ecuacion = _Ecuacion.Trim

        Dim _Formula = Split(_Ecuacion, "#")

        _Fx = _Formula(0)

        Dim _Tiene_Cor As Boolean = InStr(1, _Ecuacion, "[")

        Try

            Try
                _Kolt = _RowPrecios.Item("KOLT")
            Catch ex As Exception
                _Kolt = String.Empty
            End Try

            If String.IsNullOrEmpty(_Kolt) Then
                Throw New System.Exception(vbCrLf & vbCrLf & "No se encontro lista de precios")
            End If

            If _Tiene_Cor Then

                Dim _Ecuacion_Copy = Replace(_Ecuacion, "]", "")
                Dim _Ecuacion_1 = Split(_Ecuacion_Copy, "#")
                Dim _Ecuacion_2 = Split(_Ecuacion_1(0).ToString.Trim, "[")

                For i = 1 To _Ecuacion_2.Length

                    Dim _Ecuacion_3

                    Try
                        _Ecuacion_3 = Split(_Ecuacion_2(i), ",")
                    Catch ex As Exception
                        Exit For
                    End Try

                    Dim _Cant1_Ecu As Double = _Ecuacion_3(0)
                    Dim _Cant2_Ecu As Double = _Ecuacion_3(1)
                    Dim _Campo_Ecu As String = _Ecuacion_3(2)

                    _Ecuacion = Replace(_Ecuacion, " ", "")

                    Dim _Corchete1 = Split(_Ecuacion, "[")
                    Dim _Corchete2 = Split(_Ecuacion, "]")
                    Dim _Corchete3 = Split(_Ecuacion, "][")

                    If _Fx.Contains("-[") Then
                        _Fx = _Ecuacion
                        Throw New System.Exception(vbCrLf & vbCrLf & "Esto no esta permitido -> '-['")
                    End If

                    If _Fx.Contains("]-") Then
                        _Fx = _Ecuacion
                        Throw New System.Exception(vbCrLf & vbCrLf & "Esto no esta permitido -> ']-'")
                    End If

                    If _Corchete1.Length > _Corchete2.Length Then
                        Throw New System.Exception(vbCrLf & vbCrLf & "Falta un cierre de corchetes")
                    End If

                    If _Corchete1.Length < _Corchete2.Length Then
                        Throw New System.Exception(vbCrLf & vbCrLf & "Falta una apertura de corchetes")
                    End If

                    If Not String.IsNullOrEmpty(_Ecuacion_2(0).Trim) Then
                        _Fx = _Ecuacion
                        Throw New System.Exception(vbCrLf & vbCrLf & "Error cerca de " & _Ecuacion_2(0).Trim)
                    End If

                    'If Not String.IsNullOrEmpty(_Corchete2(_Corchete2.Length - 1).Trim) Then
                    '    If Not (_Corchete2(_Corchete2.Length - 1).Trim).Contains("#") Then
                    '        _Fx = _Ecuacion
                    '        Throw New System.Exception(vbCrLf & vbCrLf & "Error cerca de " & _Corchete2(_Corchete2.Length - 1).Trim)
                    '    End If
                    'End If

                    'If _Corchete3.Length <> _Ecuacion_2.Length - 1 Then
                    '    Throw New System.Exception(vbCrLf & vbCrLf & "Error en un cierre y apertura de corchetes")
                    'End If

                    Dim _Ejecutar_Consulta = False

                    If _Campo_Ecu.ToUpper = "CAPRCO1" Then
                        If _Caprco1 >= _Cant1_Ecu And _Caprco1 <= _Cant2_Ecu Then
                            _Ejecutar_Consulta = True
                        End If
                    End If

                    If _Campo_Ecu.ToUpper = "CAPRCO2" Then
                        If _Caprco2 >= _Cant1_Ecu And _Caprco2 <= _Cant2_Ecu Then
                            _Ejecutar_Consulta = True
                        End If
                    End If

                    If _Caprco1 = 0 And _Caprco2 = 0 Then
                        _Ejecutar_Consulta = True
                    End If

                    Try
                        _Ecuacion = _Ecuacion_3(3) & "#" & _Ecuacion_1(1)
                    Catch ex As Exception
                        _Ecuacion = _Ecuacion_3(3)
                    End Try

                    If _Ejecutar_Consulta Then

                        _PrecioLinea = Fx_Precio_Formula_Random_Ecuacion(_RowPrecios,
                                                 _Campo_Precio,
                                                 _Ecuacion,
                                                 Nothing,
                                                 True,
                                                 _Koen,
                                                 _Caprco1,
                                                 _Caprco2)
                        Return _PrecioLinea

                    End If

                Next

            Else

                _PrecioLinea = Fx_Precio_Formula_Random(_RowPrecios, _Campo_Precio, _Campo_Ecuacion, Nothing, True, _Koen, _Caprco1, _Caprco1)

            End If

            Return _PrecioLinea

        Catch ex As Exception

            If Not IsNothing(_Formulario) Then
                MessageBoxEx.Show(_Formulario, "La función que viene desde la lista " & _Kolt & " tiene errores" & vbCrLf & vbCrLf & _Fx & " " & ex.Message, "Validación",
                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End Try

        Return 0

    End Function

    Function Fx_Precio_Formula_Random(_RowPrecio As DataRow,
                                      _Campo_Precio As String,
                                      _Campo_Ecuacion As String,
                                      _RowCostos_PM As DataRow,
                                      _Aplicar_Formula_Dinamica As Boolean,
                                      _Koen As String,
                                      _vCantUd1 As Double,
                                      _vCantUd2 As Double)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        If (_RowPrecio Is Nothing) Then
            Return 0
        End If

        Dim _Kolt = _RowPrecio.Item("KOLT")
        Dim _Kopr = _RowPrecio.Item("KOPR")

        Dim _Rtu As String

        Try
            _Rtu = De_Num_a_Tx_01(_RowPrecio.Item("RLUD"), False, 5)
        Catch ex As Exception
            _Rtu = _Sql.Fx_Trae_Dato("MAEPR", "RLUD", "KOPR = '" & _Kopr & "'")
            Consulta_sql = "Update TABPRE Set RLUD = " & _Rtu & " Where KOLT = '" & _Kolt & "' And KOPR = '" & _Kopr & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End Try

        Dim _Precio As Double

        Dim _Formula

        Dim _Ecuacion As String

        If String.IsNullOrEmpty(_Campo_Ecuacion) Then
            _Ecuacion = String.Empty
        Else
            _Ecuacion = NuloPorNro(_RowPrecio.Item(_Campo_Ecuacion), "").ToString.Trim()
        End If

        Dim _Tiene_Cor As Boolean = InStr(1, _Ecuacion, "[")

        If _Tiene_Cor Then
            _Precio = Fx_Funcion_Ecuacion_Random(Nothing, "", _Ecuacion, _Kopr, 1, _RowPrecio, 1, 1, 1)
            Return _Precio
        End If


        Dim _Ejecutar_Ecuacion = False

        If _Aplicar_Formula_Dinamica Then

            If Not String.IsNullOrEmpty(_Ecuacion) Then
                _Ejecutar_Ecuacion = (_Ecuacion = LCase(_Ecuacion))
            End If

        Else

            _Ejecutar_Ecuacion = True

        End If


        _Precio = NuloPorNro(_RowPrecio.Item(_Campo_Precio), 0)
        Dim _New_Precio As Double

        If _Ejecutar_Ecuacion Then

            _Formula = Split(_Ecuacion, "#")

            Dim _Pp01ud = De_Num_a_Tx_01(_RowPrecio.Item("PP01UD"), False, 5)
            Dim _Pp02ud = De_Num_a_Tx_01(_RowPrecio.Item("PP02UD"), False, 5)

            Dim _CantUd1 = De_Num_a_Tx_01(_vCantUd1, False, 5)
            Dim _CantUd2 = De_Num_a_Tx_01(_vCantUd2, False, 5)

            Dim _Mg01ud = De_Num_a_Tx_01(_RowPrecio.Item("MG01UD"), False, 5)
            Dim _Mg02ud = De_Num_a_Tx_01(_RowPrecio.Item("MG02UD"), False, 5)

            Dim _Dtma01ud = De_Num_a_Tx_01(_RowPrecio.Item("DTMA01UD"), False, 5)
            Dim _Dtma02ud = De_Num_a_Tx_01(_RowPrecio.Item("DTMA02UD"), False, 5)

            Dim _Pm As String = 0
            Dim _Ppul01 As String = 0
            Dim _Ppul02 As String = 0
            Dim _Pmsuc As String = 0

            If (_RowCostos_PM Is Nothing) Then

                Consulta_sql = "Select Top 1 PM,PM As PM01,PPUL01,PPUL02,Isnull(Round(PMSUC,5),0) As PMSUC
                                From MAEPREM EM
                                Left Join MAEPMSUC SUC On EM.EMPRESA = SUC.EMPRESA AND SUC.KOSU = '" & ModSucursal & "' AND EM.KOPR = SUC.KOPR
                                Where EM.EMPRESA = '" & ModEmpresa & "' And EM.KOPR = '" & _Kopr & "'"

                _RowCostos_PM = _Sql.Fx_Get_DataRow(Consulta_sql)

            End If

            If Not (_RowCostos_PM Is Nothing) Then

                _Pm = Math.Round(NuloPorNro(_RowCostos_PM.Item("PM01"), 0), 5)
                _Ppul01 = Math.Round(NuloPorNro(_RowCostos_PM.Item("PPUL01"), 0), 5)
                _Ppul02 = Math.Round(NuloPorNro(_RowCostos_PM.Item("PPUL02"), 0), 5)
                _Pmsuc = Math.Round(NuloPorNro(_RowCostos_PM.Item("PMSUC"), 0), 5)

            End If

            Dim _Fx1, _Redondeo


            _Fx1 = UCase(_Formula(0))

            If _Formula.Length > 1 Then
                _Redondeo = Trim(_Formula(1))
            Else
                _Redondeo = 0
            End If

            If String.IsNullOrEmpty(_Fx1) Then

                _New_Precio = 0

            Else

                If _Fx1.ToString.Contains("<") Then
                    _Fx1 = Fx_Traer_Campo_Desde_Otra_Lista(_Kopr, _Fx1, _Koen, _vCantUd1, _vCantUd2)
                End If

                _Fx1 = Replace(_Fx1, "RLUD", _Rtu)

                _Fx1 = Replace(_Fx1, "PMSUC", _Pmsuc)
                _Fx1 = Replace(_Fx1, "PM", _Pm)
                _Fx1 = Replace(_Fx1, "PPUL01", _Ppul01)
                _Fx1 = Replace(_Fx1, "PPUL02", _Ppul02)
                _Fx1 = Replace(_Fx1, "PP01UD", _Pp01ud)
                _Fx1 = Replace(_Fx1, "PP02UD", _Pp02ud)

                _Fx1 = Replace(_Fx1, "MG01UD", _Mg01ud)
                _Fx1 = Replace(_Fx1, "MG02UD", _Mg02ud)

                _Fx1 = Replace(_Fx1, "DTMA01UD", _Dtma01ud)
                _Fx1 = Replace(_Fx1, "DTMA02UD", _Dtma02ud)

                _Fx1 = Replace(_Fx1, "CAPRCO1", _CantUd1)
                _Fx1 = Replace(_Fx1, "CAPRCO2", _CantUd2)

                _Fx1 = Replace(_Fx1, ",", ".")
                _Fx1 = UCase(_Fx1)

                Sb_Buscar_Valor_En_Dimensiones(_Fx1, _Kopr, _Koen)

                Consulta_sql = "Select " & _Fx1 & " As Valor"
                Dim _RowPr As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                _Precio = _RowPr.Item("Valor")

                _Redondeo = Fx_Redondeo_Random(_Redondeo)

            End If

            _New_Precio = Fx_Redondear_Precio(_Precio, _Redondeo)

        Else
            _New_Precio = _Precio
        End If

        _New_Precio = Math.Round(_New_Precio, 5)

        Return _New_Precio

    End Function

    Function Fx_Precio_Formula_Random_Ecuacion(_RowPrecio As DataRow,
                                               _Campo_Precio As String,
                                               _Ecuacion As String,
                                               _RowCostos_PM As DataRow,
                                               _Aplicar_Formula_Dinamica As Boolean,
                                               _Koen As String,
                                               _vCantUd1 As Double,
                                               _vCantUd2 As Double)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        If (_RowPrecio Is Nothing) Then
            Return 0
        End If

        Dim _Lista = _RowPrecio.Item("KOLT")
        Dim _Codigo = _RowPrecio.Item("KOPR")

        Dim _Rtu = De_Num_a_Tx_01(_RowPrecio.Item("RLUD"), False, 5)
        Dim _Precio As Double

        Dim _Formula

        Dim _Tiene_Cor As Boolean = InStr(1, _Ecuacion, "[")

        If _Tiene_Cor Then
            _Precio = Fx_Funcion_Ecuacion_Random(Nothing, "", _Ecuacion, _Codigo, 1, _RowPrecio, 1, 1, 1)
            Return _Precio
        End If


        Dim _Ejecutar_Ecuacion = False

        If _Aplicar_Formula_Dinamica Then

            If Not String.IsNullOrEmpty(_Ecuacion) Then
                _Ejecutar_Ecuacion = (_Ecuacion = LCase(_Ecuacion))
            End If

        Else

            _Ejecutar_Ecuacion = True

        End If


        _Precio = NuloPorNro(_RowPrecio.Item(_Campo_Precio), 0)
        Dim _New_Precio As Double

        If _Ejecutar_Ecuacion Then

            _Formula = Split(_Ecuacion, "#")

            Dim _Pp01ud = De_Num_a_Tx_01(_RowPrecio.Item("PP01UD"), False, 5)
            Dim _Pp02ud = De_Num_a_Tx_01(_RowPrecio.Item("PP02UD"), False, 5)

            Dim _CantUd1 = De_Num_a_Tx_01(_vCantUd1, False, 5)
            Dim _CantUd2 = De_Num_a_Tx_01(_vCantUd2, False, 5)

            Dim _Mg01ud = De_Num_a_Tx_01(_RowPrecio.Item("MG01UD"), False, 5)
            Dim _Mg02ud = De_Num_a_Tx_01(_RowPrecio.Item("MG02UD"), False, 5)

            Dim _Dtma01ud = De_Num_a_Tx_01(_RowPrecio.Item("DTMA01UD"), False, 5)
            Dim _Dtma02ud = De_Num_a_Tx_01(_RowPrecio.Item("DTMA02UD"), False, 5)

            Dim _Pm As String = 0
            Dim _Ppul01 As String = 0
            Dim _Ppul02 As String = 0
            Dim _Pmsuc As String = 0

            If (_RowCostos_PM Is Nothing) Then

                Consulta_sql = "Select Top 1 PM,PM As PM01,PPUL01,PPUL02,Isnull(Round(PMSUC,5),0) As PMSUC
                                From MAEPREM EM
                                Left Join MAEPMSUC SUC On EM.EMPRESA = SUC.EMPRESA AND SUC.KOSU = '" & ModSucursal & "' AND EM.KOPR = SUC.KOPR
                                Where EM.EMPRESA = '" & ModEmpresa & "' And EM.KOPR = '" & _Codigo & "'"

                _RowCostos_PM = _Sql.Fx_Get_DataRow(Consulta_sql)

            End If

            If Not (_RowCostos_PM Is Nothing) Then

                _Pm = Math.Round(NuloPorNro(_RowCostos_PM.Item("PM01"), 0), 5)
                _Ppul01 = Math.Round(NuloPorNro(_RowCostos_PM.Item("PPUL01"), 0), 5)
                _Ppul02 = Math.Round(NuloPorNro(_RowCostos_PM.Item("PPUL02"), 0), 5)
                _Pmsuc = Math.Round(NuloPorNro(_RowCostos_PM.Item("PMSUC"), 0), 5)

            End If

            Dim _Fx1, _Redondeo


            _Fx1 = UCase(_Formula(0))

            If _Formula.Length > 1 Then
                _Redondeo = Trim(_Formula(1))
            Else
                _Redondeo = 0
            End If

            If String.IsNullOrEmpty(_Fx1) Then

                _New_Precio = 0

            Else

                If _Fx1.ToString.Contains("<") Then
                    _Fx1 = Fx_Traer_Campo_Desde_Otra_Lista(_Codigo, _Fx1, _Koen, _vCantUd1, _vCantUd2)
                End If

                _Fx1 = Replace(_Fx1, "RLUD", _Rtu)

                _Fx1 = Replace(_Fx1, "PMSUC", _Pmsuc)
                _Fx1 = Replace(_Fx1, "PM", _Pm)
                _Fx1 = Replace(_Fx1, "PPUL01", _Ppul01)
                _Fx1 = Replace(_Fx1, "PPUL02", _Ppul02)
                _Fx1 = Replace(_Fx1, "PP01UD", _Pp01ud)
                _Fx1 = Replace(_Fx1, "PP02UD", _Pp02ud)

                _Fx1 = Replace(_Fx1, "MG01UD", _Mg01ud)
                _Fx1 = Replace(_Fx1, "MG02UD", _Mg02ud)

                _Fx1 = Replace(_Fx1, "DTMA01UD", _Dtma01ud)
                _Fx1 = Replace(_Fx1, "DTMA02UD", _Dtma02ud)

                _Fx1 = Replace(_Fx1, "CAPRCO1", _CantUd1)
                _Fx1 = Replace(_Fx1, "CAPRCO2", _CantUd2)

                _Fx1 = Replace(_Fx1, ",", ".")
                _Fx1 = UCase(_Fx1)

                Sb_Buscar_Valor_En_Dimensiones(_Fx1, _Codigo, _Koen)

                Consulta_sql = "Select " & _Fx1 & " As Valor"
                Dim _RowPr As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                _Precio = _RowPr.Item("Valor")

                _Redondeo = Fx_Redondeo_Random(_Redondeo)

            End If

            _New_Precio = Fx_Redondear_Precio(_Precio, _Redondeo)

        Else
            _New_Precio = _Precio
        End If

        _New_Precio = Math.Round(_New_Precio, 2)

        Return _New_Precio

    End Function

    Function Fx_Traer_Campo_Desde_Otra_Lista(_Codigo As String,
                                             _Ecuacion As String,
                                             _Koen As String,
                                             _vCantUd1 As Double,
                                             _vCantUd2 As Double) As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Ecuacion_Original As String = _Ecuacion

        Dim _Ecuaciones = Split(_Ecuacion, ">")
        Dim _Listas() As String
        Dim _Filtro_Listas As String

        Dim _Cont = 0

        Consulta_sql = "Select * From TABPP"
        Dim _TblListas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For i = 0 To _Ecuaciones.Length - 1

            Dim _Lt = _Ecuaciones(i)

            If _Lt.Contains("<") Then

                _Lt = Replace(_Lt, "<", "")
                _Lt = Replace(_Lt, "(", "")
                _Lt = Replace(_Lt, ")", "")

                ReDim Preserve _Listas(_Cont)

                For Each _Fl As DataRow In _TblListas.Rows

                    Dim _Lista As String = _Fl.Item("KOLT")

                    If _Lt.Contains(_Lista) Then
                        _Listas(_Cont) = _Lista
                        Exit For
                    End If

                Next

                _Cont += 1

            End If

        Next

        _Filtro_Listas = Generar_Filtro_IN_Arreglo(_Listas, False)

        Consulta_sql = "Select * From TABPP Where KOLT In (" & _Filtro_Listas & ")"
        Dim _Tbl_Listas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _Campo As String

        For Each _FLista As DataRow In _Tbl_Listas.Rows

            Dim _Kolt As String = _FLista.Item("KOLT")
            _Campo = "<" & _Kolt & ">"

            'Consulta_sql = "Select * From PNOMDIM Where CODIGO <> ''"
            'Dim _Tbl_Dimensiones As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If _Ecuacion.Contains(_Campo) Then

                Consulta_sql = "Select * From TABPRE Where KOLT = '" & _Kolt & "' And KOPR = '" & _Codigo & "'"
                Dim _RowPrecio As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Contador = 0

                Consulta_sql = "Select COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS Where TABLE_NAME = 'TABPRE'"
                Dim _Tbl_Campos_Tabpre As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                For Each _FColumnas As DataRow In _Tbl_Campos_Tabpre.Rows

                    Dim _Columna As String = _FColumnas.Item("COLUMN_NAME").ToString.Trim
                    Dim _Campo_Lista As String = _Campo & _Columna
                    'Dim _Resultado As String

                    Dim _Campo_Precio As String = _Columna
                    Dim _Campo_Ecacion As String = String.Empty

                    If _Ecuacion.Contains(_Campo_Lista) Then

                        Select Case _Campo_Precio
                            Case "PP01UD"
                                _Campo_Ecacion = "ECUACION"
                            Case "PP02UD"
                                _Campo_Ecacion = "ECUACIONU2"
                            Case "MG01UD"
                                _Campo_Ecacion = "EMG01UD"
                            Case "MG02UD"
                                _Campo_Ecacion = "EMG01UD"
                            Case "DTMA01UD"
                                _Campo_Ecacion = "EDTMA01UD"
                            Case "DTMA02UD"
                                _Campo_Ecacion = "DTMA02UD"
                            Case Else
                                If _Contador = 28 Then
                                    _Campo_Ecacion = _Tbl_Campos_Tabpre.Rows(_Contador + 1).Item("COLUMN_NAME")
                                End If
                        End Select

                        Dim _Precio As Double
                        Dim _Valor

                        Try
                            _Precio = _Sql.Fx_Trae_Dato("TABPRE", _Campo_Precio, "KOLT = '" & _Kolt & "' And KOPR = '" & _Codigo & "'", True, False, 0)
                        Catch ex As Exception
                            _Precio = 0
                        End Try

                        If CBool(_Precio) Then
                            _Valor = _Precio
                        Else
                            _Valor = Fx_Precio_Formula_Random(_RowPrecio, _Campo_Precio, _Campo_Ecacion, Nothing, False, _Koen, _vCantUd1, _vCantUd2)
                        End If

                        _Ecuacion = Replace(_Ecuacion, _Campo_Lista, LCase(_Valor))

                        If _Ecuacion <> _Ecuacion_Original Then
                            Return _Ecuacion
                        End If
                        'Sb_Buscar_Valor_En_Dimensiones(_Ecuacion, _Codigo, _Koen)

                    End If

                    _Contador += 1

                Next

            End If

        Next

        Return _Ecuacion

    End Function

    Sub Sb_Buscar_Valor_En_Dimensiones(ByRef _Fx1 As String, _Codigo As String, _Koen As String)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Contiene_Campos As Boolean

        For Each _Caracter As String In _Fx1.ToString
            _Contiene_Campos = CBool(InStr("abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ", _Caracter))
            If _Contiene_Campos Then
                Exit For
            End If
        Next

        If Not _Contiene_Campos Then
            Return
        End If

        Consulta_sql = "Select * From PNOMDIM Where DEPENDENCI = 'Valor_propio'"
        Dim _Tbl_Dimension_Valor_Propio As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _FDim_Vp As DataRow In _Tbl_Dimension_Valor_Propio.Rows

            Dim _Dimension = _FDim_Vp.Item("CODIGO").ToString.Trim
            Dim _Valor = De_Num_a_Tx_01(_FDim_Vp.Item("VALOR"), False, 5)

            _Fx1 = Replace(_Fx1, _Dimension, _Valor)

            For Each _Caracter As String In _Fx1.ToString
                _Contiene_Campos = CBool(InStr("abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ", _Caracter))
                If _Contiene_Campos Then
                    Exit For
                End If
            Next

            If Not _Contiene_Campos Then
                Return
            End If

        Next

        Consulta_sql = "Select * From PNOMDIM Where DEPENDENCI = 'Por_producto'"
        Dim _Tbl_Dimension_Por_Producto As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _FDim_Vp As DataRow In _Tbl_Dimension_Por_Producto.Rows

            Dim _Dimension = _FDim_Vp.Item("CODIGO").ToString.Trim
            Dim _Valor_Dim As Double = _Sql.Fx_Trae_Dato("PDIMEN", _Dimension, "EMPRESA = '" & ModEmpresa & "' And CODIGO = '" & _Codigo & "'", True, False)
            Dim _Valor = De_Num_a_Tx_01(_Valor_Dim, False, 5)

            _Fx1 = Replace(_Fx1, _Dimension, _Valor)

            For Each _Caracter As String In _Fx1.ToString
                _Contiene_Campos = CBool(InStr("abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ", _Caracter))
                If _Contiene_Campos Then
                    Exit For
                End If
            Next

            If Not _Contiene_Campos Then
                Return
            End If

        Next

        Consulta_sql = "Select * From PNOMDIM 
                        Inner Join INFORMATION_SCHEMA.COLUMNS On PNOMDIM.CODIGO = COLUMN_NAME And DATA_TYPE In ('float','int')
                        Where DEPENDENCI = 'Por_entidad' And TABLE_NAME = 'PDIMCLI'"
        Dim _Tbl_Dimension_Por_Entidad As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _FDim_Vp As DataRow In _Tbl_Dimension_Por_Entidad.Rows

            Dim _Dimension = _FDim_Vp.Item("CODIGO").ToString.Trim
            Dim _Valor_Dim As Double = _Sql.Fx_Trae_Dato("PDIMCLI", _Dimension, "CODIGO = '" & _Koen & "'", True, False)
            Dim _Valor = De_Num_a_Tx_01(_Valor_Dim, False, 5)

            _Fx1 = Replace(_Fx1, _Dimension, _Valor)

            For Each _Caracter As String In _Fx1.ToString
                _Contiene_Campos = CBool(InStr("abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ", _Caracter))
                If _Contiene_Campos Then
                    Exit For
                End If
            Next

            If Not _Contiene_Campos Then
                Return
            End If

        Next

    End Sub

    Function FX_Traer_Valor_Concepto(_RowConcepto As DataRow, _Koen As String) As Double

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Codigo As String = _RowConcepto.Item("KOCT")
        Dim _Poct As Double = _RowConcepto.Item("POCT")
        Dim _Ecuct As String = _RowConcepto.Item("ECUCT")

        Dim _Pp01ud = De_Num_a_Tx_01(_RowConcepto.Item("POCT"), False, 5)

        Dim _Formula = Split(_Ecuct, "#")
        Dim _Fx1, _Redondeo

        _Fx1 = UCase(_Formula(0))

        If _Formula.Length > 1 Then
            _Redondeo = Trim(_Formula(1))
        Else
            _Redondeo = 0
        End If

        Sb_Buscar_Valor_En_Dimensiones(_Fx1, _Codigo, _Koen)

        If String.IsNullOrEmpty(_Fx1.ToString.Trim) Then
            _Fx1 = 0
        End If

        Dim _Precio As Double

        Consulta_sql = "Select " & _Fx1 & " As Valor"
        Dim _RowPr As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Precio = _RowPr.Item("Valor")

        _Redondeo = Fx_Redondeo_Random(_Redondeo)

        _Precio = Fx_Redondear_Precio(_Precio, _Redondeo)

        Return _Precio

    End Function

    Function Fx_Redondeo_Random(_Redondeo As String) As Redondeo

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

    Function Fx_Redondear_Precio(_Precio As Double, _Redondedo As Redondeo) As Double

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

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

    Function Fx_Add_Log_Gestion(_Funcionario As String,
                                _Modalidad As String,
                                _Archirst As String,
                                _Idrst As Integer,
                                _CodAccion As String,
                                _Accion As String,
                                _CodPermiso As String,
                                _Kopr As String,
                                _Koen As String,
                                _Suen As String,
                                _Es_Solicitud_Permiso As Boolean,
                                _Funcionario_Autoriza As String) As Integer

        Dim _Id As Integer

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_sql As String

        _Accion = Replace(_Accion, "'", "''")

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Log_Gestiones (NombreEquipo,Funcionario,Modalidad,Archirst,Idrst," &
                       "CodAccion,Accion,CodPermiso,Kopr,Koen,Suen,Solicitud_Permiso,Funcionario_Autoriza) Values " & vbCrLf &
                       "('" & _NombreEquipo & "','" & _Funcionario & "','" & Modalidad & "','" & _Archirst & "'," & _Idrst & "," &
                       "'" & _CodAccion & "','" & _Accion & "','" & _CodPermiso & "','" & _Kopr & "','" & _Koen & "','" & _Suen &
                       "'," & CInt(_Es_Solicitud_Permiso) * -1 & ",'" & _Funcionario_Autoriza & "')"

        _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id, False)

        Return _Id

    End Function

    Function Fx_Formato_Numerico(_Valor As String,
                                 _Formato As String,
                                 _Es_Descuento As Boolean,
                                 Optional _Moneda_Str As String = "$") As String

        Dim _Cant_Caracteres As Integer = Len(_Formato)
        Dim _Moneda As Boolean

        Dim _Precio_Val As Double
        Dim _Es_Prcentaje As Boolean

        Dim _Decimales = 0

        If _Formato.Contains("%") Then
            _Es_Prcentaje = True
            _Cant_Caracteres -= 1
            _Formato = Replace(_Formato, "%", "")
        End If

        If _Formato.Contains(",") Then
            Dim _Dec = Split(_Formato, ",", 2)
            _Decimales = Len(_Dec(1))
        End If

        Dim _FORMAT As String

        If Not _Valor.Contains(",") Then

            _Decimales = 0
            Dim _Frmt = Split(_Formato, ",", 2)
            _Formato = _Frmt(0)

        End If

        Dim _Relleno As String = Mid(_Formato, 1, 1)

        If IsNumeric(_Relleno) Then
            _Relleno = " "
        Else
            _Formato = Replace(_Formato, _Relleno, "")
        End If

        If _Relleno = "$" Then

            _Moneda = True
            _Relleno = " "
            _Cant_Caracteres -= _Moneda_Str.Length '1

        End If

        _Precio_Val = De_Txt_a_Num_01(_Valor, _Decimales)
        _Precio_Val = Math.Round(_Precio_Val, _Decimales)

        If _Es_Descuento Then
            _Precio_Val = _Precio_Val * -1
        End If

        Dim _Precio = FormatNumber(_Precio_Val, _Decimales)

        ' Alinear a la derecha si el formato contiene 9
        If _Formato.Contains(9) Then 'Mid(_Formato, 1, 1) <> 8 Then
            _Precio = Rellenar(_Precio, _Cant_Caracteres, _Relleno, False)
        End If

        If _Moneda Then
            _Valor = _Moneda_Str & _Precio
        Else
            If _Es_Prcentaje Then
                _Valor = _Precio & "%"
            Else
                _Valor = _Precio
            End If
        End If

        Fx_Formato_Numerico = _Valor

    End Function



    Enum Enum_Tipo_Lista
        Compra
        Venta
    End Enum

    Function Fx_Buscar_Producto(_Formulario As Form,
                                _Codigo As String,
                                _CodEntidad As String,
                                _Lista As Enum_Tipo_Lista,
                                _Es_Documento_Interno As Boolean,
                                _Lista_Busqueda As String,
                                _Crear_Producto As Boolean) As DataRow

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        _Codigo = Trim(_Codigo)


        Dim _CodigoAlt As String
        'Dim _CodEntidad = _TblEncabezado.Rows(0).Item("CodEntidad")

        Consulta_sql = "SELECT * FROM MAEPR WHERE KOPR = '" & _Codigo & "'"
        Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)


        If Not (_RowProducto Is Nothing) Then
            Return _RowProducto
        Else

            Dim _RowTabcodal As DataRow

            _CodigoAlt = _Codigo
            Consulta_sql = "SELECT top 1 * FROM TABCODAL WHERE KOEN = '' And KOPRAL = '" & _CodigoAlt & "'"
            _RowTabcodal = _Sql.Fx_Get_DataRow(Consulta_sql)

            If _RowTabcodal Is Nothing Then
                _CodigoAlt = _Codigo
                Consulta_sql = "SELECT top 1 * FROM TABCODAL WHERE KOEN = '" & _CodEntidad & "' And KOPRAL = '" & _CodigoAlt & "'"
                _RowTabcodal = _Sql.Fx_Get_DataRow(Consulta_sql)
            End If

            If Not (_RowTabcodal Is Nothing) Then

                _Codigo = _RowTabcodal.Item("KOPR")
                Consulta_sql = "SELECT * FROM MAEPR WHERE KOPR = '" & _Codigo & "'"
                _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

                Return _RowProducto

            End If


        End If

        Dim _Tipo_Lista As String
        Dim _Actualizar_Precios As Boolean

        If _Lista = Enum_Tipo_Lista.Compra Then

            _Tipo_Lista = "C"
            _Actualizar_Precios = False

            If String.IsNullOrEmpty(_Lista_Busqueda) Then
                _Lista_Busqueda = ModListaPrecioCosto
            End If

        Else

            _Tipo_Lista = "P"
            _Actualizar_Precios = True

            If String.IsNullOrEmpty(_Lista_Busqueda) Then
                _Lista_Busqueda = ModListaPrecioVenta
            End If

        End If

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt
        Fm.Pro_CodEntidad = String.Empty
        Fm.Pro_CodSucEntidad = String.Empty
        Fm.Pro_Tipo_Lista = _Tipo_Lista
        Fm.Pro_Lista_Busqueda = _Lista_Busqueda
        Fm.Pro_Sucursal_Busqueda = ModSucursal
        Fm.Pro_Bodega_Busqueda = ModBodega
        Fm.Txtdescripcion.Text = _Codigo
        Fm.Pro_Mostrar_Info = True
        Fm.Pro_Actualizar_Precios = _Actualizar_Precios
        Fm.Pro_Mostrar_Clasificaciones = True
        Fm.Pro_Mostrar_Imagenes = True

        Fm.BtnCrearProductos.Visible = _Crear_Producto

        If _Es_Documento_Interno Then

            Dim _No_Puede_Ver_Precios As Boolean = Fx_Tiene_Permiso(_Formulario, "NO00001", , False)

            If _No_Puede_Ver_Precios Then
                Fm.Pro_Mostrar_Precios = False
            End If

        End If

        Fm.ShowDialog(_Formulario)

        If Fm.Pro_Seleccionado Then
            _RowProducto = Fm.Pro_RowProducto
        Else
            _RowProducto = Nothing
        End If

        Return _RowProducto

    End Function

End Module

Public Module Colores_Bakapp

    Enum Enum_Colores_Bakapp
        Rojo
        Celeste
        Naranjo
        Verde_Claro
        Amarillo
        Fuxia
        Azul_Petroleo
        Verde_Pistacho
        Crema
        Vino
        Azul_Oscuro
        Beig
        Verde
        Marron
        Gris
        Azul_Bakapp
        Gris_Oscuro
    End Enum

    Function Fx_Color_Bakapp(_Color_Bakapp As Enum_Colores_Bakapp) As Color

        Dim _Color As Color

        Select Case _Color_Bakapp
            Case Enum_Colores_Bakapp.Rojo
                _Color = ColorTranslator.FromHtml("#DC0000")'("#E2404C")
            Case Enum_Colores_Bakapp.Celeste
                _Color = ColorTranslator.FromHtml("#5BBDD9")
            Case Enum_Colores_Bakapp.Naranjo
                _Color = ColorTranslator.FromHtml("#E67D46")
            Case Enum_Colores_Bakapp.Verde_Claro
                _Color = ColorTranslator.FromHtml("#65C38B")
            Case Enum_Colores_Bakapp.Amarillo
                _Color = ColorTranslator.FromHtml("#F4B545")
            Case Enum_Colores_Bakapp.Fuxia
                _Color = ColorTranslator.FromHtml("#D15D7B")
            Case Enum_Colores_Bakapp.Azul_Petroleo
                _Color = ColorTranslator.FromHtml("#3D838C")
            Case Enum_Colores_Bakapp.Verde_Pistacho
                _Color = ColorTranslator.FromHtml("#A4B45D")
            'Case Enum_Colores_Bakapp.Crema
            '    _Color = ColorTranslator.FromHtml("#F7BA8F")
            Case Enum_Colores_Bakapp.Vino
                _Color = ColorTranslator.FromHtml("#801812")
            Case Enum_Colores_Bakapp.Azul_Oscuro
                _Color = ColorTranslator.FromHtml("#263068")
            Case Enum_Colores_Bakapp.Beig
                _Color = ColorTranslator.FromHtml("#CCB59A")
            Case Enum_Colores_Bakapp.Verde
                _Color = ColorTranslator.FromHtml("#4B7F51")
            Case Enum_Colores_Bakapp.Marron
                _Color = ColorTranslator.FromHtml("#6E5746")
            Case Enum_Colores_Bakapp.Gris
                _Color = ColorTranslator.FromHtml("#9C9B9B")
            Case Enum_Colores_Bakapp.Azul_Bakapp
                _Color = ColorTranslator.FromHtml("#349FCE")
            Case Enum_Colores_Bakapp.Gris_Oscuro
                _Color = ColorTranslator.FromHtml("#777E91")
            Case Else
                _Color = ColorTranslator.FromHtml("#349FCE")
        End Select

        Return _Color

    End Function

End Module

Public Module Crear_Documentos_Desde_Otro

    Dim Consulta_sql As String

    Sub Sb_Crear_Documento_Desde_Otro_Automaticamente(_Formulario As Form,
                                                      _Tido_Destino As String,
                                                      _Idmaeedo_Origen As Integer)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _RowFormato As DataRow = Fx_Formato_Modalidad(_Formulario, Modalidad, _Tido_Destino, True)

        If Not IsNothing(_RowFormato) Then

            Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen
            Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Documento) Then

                Dim _Tido = _Row_Documento.Item("TIDO")
                Dim _Nudo = _Row_Documento.Item("NUDO")

                Dim _Msj_Tsc As LsValiciones.Mensajes

                _Msj_Tsc = Fx_Revisar_Tasa_Cambio(Nothing,,, False)
                'If Not _Msj_Tsc.EsCorrecto Then

                '    _Mensaje.ErrorDeConexionSQL = _Msj_Tsc.ErrorDeConexionSQL
                '    Throw New System.Exception(_Mensaje.Mensaje)
                '    'Throw New System.Exception("No existe taza de cambio para la fecha: " & FechaDelServidor.ToShortDateString)

                'End If

                If _Msj_Tsc.EsCorrecto Then

                    If Fx_Se_Puede_Trasladar_Para_Crear_Otro_Documento(_Idmaeedo_Origen) Then

                        Dim _Empresa As String = ModEmpresa
                        Dim _Sucursal As String = ModSucursal
                        Dim _Bodega As String = ModBodega

                        Dim _Permiso = "Bo" & _Empresa & _Sucursal & _Bodega

                        If Not Fx_Tiene_Permiso(_Formulario, _Permiso, , True) Then

                            Dim _Bod = _Global_Row_Configuracion_Estacion.Item("NOKOBO")
                            MessageBoxEx.Show(_Formulario, "NO ESTA AUTORIZADO PARA EFECTUAR DOCUMENTOS DESDE LA BODEGA DE ESTA MODALIDAD" & vbCrLf & vbCrLf &
                                              "BODEGA: " & _Bodega & " - " & _Bod,
                                              "VALIDACION",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, _Formulario.TopMost)
                            Return

                        End If

                        If Fx_Tiene_Permiso(_Formulario, _Permiso) Then

                            Dim Fm_Post As New Frm_Formulario_Documento("FCV", csGlobales.Enum_Tipo_Documento.Venta, False, True)
                            If _Formulario.Name <> "Frm_Menu_Extra" Then Fm_Post.MinimizeBox = True
                            Fm_Post.MinimizeBox = False

                            Fm_Post.Pro_Ejecutar_Creacion_Automaticas_Desde_Doc_Origen = True

                            Fm_Post.Pro_Idmaeedo_Relacionado = _Idmaeedo_Origen
                            Fm_Post.Pro_Tido_Origen = _Tido
                            Fm_Post.Pro_Nudo_Origen = _Nudo

                            Fm_Post.ShowDialog(_Formulario)
                            Fm_Post.Dispose()

                        End If

                    Else

                        MessageBoxEx.Show(_Formulario, "Documento se encuentra cerrado completamente", "Documento cerrado",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, _Formulario.TopMost)

                    End If

                End If

            End If

        Else

            MessageBoxEx.Show(_Formulario, "Debe configurar el formato de salida en la configuración por modalidad de trabajo",
                          "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Function Fx_Se_Puede_Trasladar_Para_Crear_Otro_Documento(_Idmaeedo As Integer) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "SELECT *
                        FROM MAEDDO  WITH ( NOLOCK ) 
                        WHERE IDMAEEDO =  " & _Idmaeedo & " AND ( ESLIDO<>'C' OR ESFALI='I' ) AND TICT = ''"

        Dim _Tbl_Saldo_Facturar As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

        If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
            Return False
        End If

        Return CBool(_Tbl_Saldo_Facturar.Rows.Count)

    End Function

    Function Fx_Insertar_Jefe(_Hijo As String, ByRef _Jefes As List(Of String)) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Select CodJefe From " & _Global_BaseBk & "Zw_Usuarios_VS_Jefes 
                        Where CodFuncionario = '" & _Hijo & "' And Empresa = '" & ModEmpresa & "'"
        Dim _Row_Jefe As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Jefe) Then

            Dim _CodJefe = Trim(_Row_Jefe.Item("CodJefe"))

            If Not String.IsNullOrEmpty(_CodJefe) Then

                _Jefes.Add(_CodJefe)
                Fx_Insertar_Jefe(_CodJefe, _Jefes)

            End If

        End If

    End Function

    Function Fx_Insertar_Jefe_Y_SubJefes(_Hijo As String, ByRef _Jefes As List(Of String)) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Select CodJefe,CodJefeReemplazo 
                        From " & _Global_BaseBk & "Zw_Usuarios_VS_Jefes 
                        Where CodFuncionario = '" & _Hijo & "' And Empresa = '" & ModEmpresa & "'"
        Dim _Row_Jefe As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Jefe) Then

            Dim _CodJefe = Trim(_Row_Jefe.Item("CodJefe"))
            Dim _CodJefeReemplazo = Trim(_Row_Jefe.Item("CodJefeReemplazo"))

            If Not String.IsNullOrEmpty(_CodJefe) Then

                _Jefes.Add(_CodJefe)

                If Not String.IsNullOrEmpty(_CodJefeReemplazo) Then
                    _Jefes.Add(_CodJefeReemplazo)
                End If

                Fx_Insertar_Jefe(_CodJefe, _Jefes)

            End If

        End If

    End Function

    Function Fx_Tipo_DTE_VS_TIDO(_Tido As String) As Integer

        Select Case _Tido
            Case "FCV"
                Return 33
            Case "FDV"
                Return 56
            Case "BLV", "BSV"
                Return 39
            Case "GDV", "GDP", "GTI", "GDD"
                Return 52
            Case "NCV"
                Return 61
            Case "OCC"
                Return 801
            Case Else
                Return 0
        End Select

        'Return "FACTURA" 33
        'Return "FACTURA EXENTA" 34
        'Return "GUIA DE DESPACHO" 52
        'Return "FACTURA DE COMPRA" 46
        'Return "NOTA DE DEBITO" 56
        'Return "NOTA DE CREDITO" 61
        'Return "ORDEN DE COMPRA" 801

    End Function

    Function Fx_Tipo_TIDO_VS_DTE(_Td As Integer) As String

        Select Case _Td
            Case 33
                Return "FCV"
            Case 39
                Return "BLV"
            Case 52
                Return "GDV"
            Case 56
                Return "FDV"
            Case 61
                Return "NCV"
            Case 801
                Return "OCC"
            Case Else
                Return String.Empty
        End Select

        'Return "FACTURA" 33
        'Return "FACTURA EXENTA" 34
        'Return "GUIA DE DESPACHO" 52
        'Return "FACTURA DE COMPRA" 46
        'Return "NOTA DE DEBITO" 56
        'Return "NOTA DE CREDITO" 61
        'Return "ORDEN DE COMPRA" 801

    End Function

    Dim _Dir_Local As String = Application.StartupPath & "\Data\" & RutEmpresaActiva & "\Configuracion_Local" '\Configuracion_Local"

    Function Fx_Cambiar_Thema(_Estilo As Enum_Themas, _Color As Color)

        Dim _Dir_Local As String = Application.StartupPath & "\Data\" & RutEmpresaActiva & "\Configuracion_Local" '\Configuracion_Local"

        Dim _Existe = System.IO.File.Exists(_Dir_Local & "\Estilo.xml")
        Dim _Ds_Estilo As New DatosBakApp

        _Ds_Estilo.Clear()

        If Not _Existe Then
            _Estilo = Enum_Themas.Claro
            Sb_Actualizar_Estilo(_Dir_Local, _Ds_Estilo, Enum_Themas.Claro, Enum_Themas.Claro.ToString, -16748352, Enum_Themas.Claro)
        End If

        _Ds_Estilo.ReadXml(_Dir_Local & "\Estilo.xml")

        _Ds_Estilo.Tables("Themas").Rows(0).Item("Cod_Estilo") = _Estilo
        _Ds_Estilo.Tables("Themas").Rows(0).Item("Color") = _Color.ToArgb
        _Ds_Estilo.Tables("Themas").Rows(0).Item("Nombre_Estilo") = _Estilo.ToString
        _Ds_Estilo.Tables("Themas").Rows(0).Item("Global_Thema") = _Estilo

        _Ds_Estilo.WriteXml(_Dir_Local & "\Estilo.xml")

    End Function

    Sub Sb_Revisar_Estilo(_Tido As String,
                          Optional _Estilo As eStyle = eStyle.Metro,
                          Optional _Color As Integer = -16748352)

        Dim _Dir_Local As String = Application.StartupPath & "\Data\" & RutEmpresaActiva & "\Configuracion_Local" '\Configuracion_Local"

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _baseColor As Color
        Dim _camvasColor As Color

        If Not Directory.Exists(_Dir_Local) Then
            System.IO.Directory.CreateDirectory(_Dir_Local)
        End If

        Dim _Existe = System.IO.File.Exists(_Dir_Local & "\Estilo.xml")
        Dim _Ds_Estilo As New DatosBakApp

        If Not _Existe Then

            Dim _Dir_Local2 As String = Application.StartupPath & "\Data\Configuracion_Local"

            If System.IO.File.Exists(_Dir_Local2 & "\Estilo.xml") Then
                File.Copy(_Dir_Local2 & "\Estilo.xml", _Dir_Local & "\Estilo.xml")
            Else
                Sb_Actualizar_Estilo(_Dir_Local, _Ds_Estilo, Enum_Themas.Claro, Enum_Themas.Claro.ToString, -16748352, Enum_Themas.Claro)
            End If

        End If

        _Ds_Estilo.Clear()
        _Ds_Estilo.ReadXml(_Dir_Local & "\Estilo.xml")

        Dim _Cod_Estilo = _Ds_Estilo.Tables("Themas").Rows(0).Item("Cod_Estilo")
        Dim _Nombre_Estilo = _Ds_Estilo.Tables("Themas").Rows(0).Item("Nombre_Estilo")

        _Color = _Ds_Estilo.Tables("Themas").Rows(0).Item("Color")

        _baseColor = Color.FromArgb(_Color)

        Global_camvasColor = _Color

        Try
            Global_Thema = _Ds_Estilo.Tables("Themas").Rows(0).Item("Global_Thema")
        Catch ex As Exception
            My.Computer.FileSystem.DeleteFile(_Dir_Local & "\Estilo.xml")
            Sb_Revisar_Estilo(_Tido)
            Exit Sub
        End Try


        Select Case Global_Thema

            Case Enum_Themas.Claro

                _camvasColor = Color.White

            Case Enum_Themas.Gris

                _camvasColor = Color.FromArgb(216, 216, 216)

            Case Enum_Themas.Oscuro

                _camvasColor = Color.FromArgb(32, 32, 32)

            Case Enum_Themas.Azul

                _camvasColor = Color.FromArgb(217, 224, 248)

            Case Enum_Themas.Oscuro_Ligth

                _camvasColor = Color.FromArgb(45, 45, 45)

        End Select

        Global_baseColor = _baseColor.ToArgb
        Global_camvasColor = _camvasColor.ToArgb

        StyleManager.Style = _Estilo
        StyleManager.MetroColorGeneratorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(_camvasColor, _baseColor)

    End Sub

    Sub Sb_Actualizar_Estilo(_Directorio As String,
                             _Ds As DataSet,
                             _Cod_Estilo As String,
                             _Nombre_Estilo As String,
                             _Color As Integer,
                             _Global_Thema As Enum_Themas)

        Dim NewFila As DataRow
        NewFila = _Ds.Tables("Themas").NewRow
        With NewFila
            .Item("Cod_Estilo") = _Cod_Estilo
            .Item("Color") = _Color
            .Item("Nombre_Estilo") = _Nombre_Estilo
            .Item("Global_Thema") = _Global_Thema
        End With

        _Ds.Tables("Themas").Rows.Add(NewFila)
        _Ds.WriteXml(_Directorio & "\Estilo.xml")

    End Sub


    Function Fx_Eliminar_Kasidoc_BakApp(_Id_DocEnc As Integer,
                                        _NombreEquipo As String,
                                        _Stand_by As Boolean)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Casi_DocEnc Where Id_DocEnc = " & _Id_DocEnc & "
                        Delete " & _Global_BaseBk & "Zw_Casi_DocDet Where Id_DocEnc = " & _Id_DocEnc & "
                        Delete " & _Global_BaseBk & "Zw_Casi_DocDsc Where Id_DocEnc = " & _Id_DocEnc & "
                        Delete " & _Global_BaseBk & "Zw_Casi_DocImp Where Id_DocEnc = " & _Id_DocEnc & "
                        Delete " & _Global_BaseBk & "Zw_Casi_DocObs Where Id_DocEnc = " & _Id_DocEnc & "
                        Delete " & _Global_BaseBk & "Zw_Casi_DocPer Where Id_DocEnc = " & _Id_DocEnc & "
                        Delete " & _Global_BaseBk & "Zw_Referencias_Dte Where Id_Doc = " & _Id_DocEnc & " And Kasi = 1"

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Casi_DocArc") Then

                If _Stand_by Then
                    Consulta_sql = "Update  " & _Global_BaseBk & "Zw_Casi_DocArc Set Id_DocEnc = 0,En_Construccion = 1,NombreEquipo = '" & _NombreEquipo & "' 
                                    Where Id_DocEnc = " & _Id_DocEnc
                Else
                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Casi_DocArc Where Id_DocEnc = " & _Id_DocEnc
                End If

                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

            End If

        End If

        Return True

    End Function

    Function Fx_Revisar_Expiracion_Folio_SII(_Formulario As Form,
                                             _Tido As String,
                                             _Folio As String,
                                             _MostrarMensajeExpiracion As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

            Dim _Firma_Bakapp As Boolean = Fx_Firmar_X_Bakapp2(_Tido)
            Dim _Firma_RunMonitor As Boolean = Not _Firma_Bakapp

            If _Firma_Bakapp Then
                Return Fx_Revisar_Expiracion_Folio_SII_Hefesto_Bakapp(_Formulario, _Tido, _Folio, _MostrarMensajeExpiracion)
            End If

            If _Tido = "GDP" Or _Tido = "GDD" Or _Tido = "GTI" Then
                _Tido = "GDV"
            End If

            Dim _Td = Fx_Tipo_DTE_VS_TIDO(_Tido)

            Dim _AmbienteCertificacion As Integer = Convert.ToInt32(_Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion"))

            If _Firma_Bakapp Then
                Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_DTE_Caf With ( NOLOCK )" & vbCrLf &
                          "Where Cast(RNG_D AS INT)<=" & Val(_Folio) & " And Cast(RNG_H AS INT)>=" & Val(_Folio) &
                          " And TD='" & _Td & "' And Empresa='" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion
            Else
                Consulta_sql = "Select TOP 1 * FROM FFOLIOS WITH ( NOLOCK )" & vbCrLf &
                               "Where CAST(RNG_D AS INT)<=" & Val(_Folio) & " And Cast(RNG_H AS INT)>=" & Val(_Folio) &
                               "  And TD='" & _Td & "'  AND EMPRESA='" & ModEmpresa & "' "
            End If

            Dim _Row_Folios As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Folios) Then

                If Not IsNothing(_Formulario) Then

                    Dim _MsgFolio As String

                    If _Firma_Bakapp Then
                        _MsgFolio = "(Folios por Hefesto BakApp)"
                    Else
                        _MsgFolio = "(Folios Random)"
                    End If

                    _Mensaje.Detalle = "Validación Modalidad: " & Modalidad
                    Throw New System.Exception("El folio del documento electrónico no está autorizado por el SII: " & _Folio & vbCrLf & vbCrLf &
                                          "INFORME ESTA SITUACION AL ADMINISTRADOR DEL SISTEMA POR FAVOR")

                End If

            Else

                Dim _Fa As DateTime = FormatDateTime(CDate(_Row_Folios.Item("FA")), DateFormat.ShortDate)
                Dim _Fecha_Servisor As DateTime = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

                Dim _Meses As Integer = 6

                If _Sql.Fx_Existe_Tabla("FDTECONF") Then

                    Try
                        _Meses = _Sql.Fx_Trae_Dato("FDTECONF", "VALOR", "CAMPO = 'sii.meses.expiran.folios' And ACTIVO=1 And EMPRESA = '" & ModEmpresa & "'")
                    Catch ex As Exception
                        If _Tido = "BLV" Then
                            _Meses = 24
                        ElseIf _Tido = "GDV" Then
                            _Meses = 12
                        End If
                    End Try

                End If

                Dim _Meses_Dif As Double = DateDiff(DateInterval.Month, _Fa, _Fecha_Servisor)
                Dim _Dias_Dif As Integer = DateDiff(DateInterval.Day, _Fa, _Fecha_Servisor)

                _Meses_Dif = Math.Round(_Dias_Dif / 31, 2)

                If _Meses_Dif > _Meses Then

                    If Not IsNothing(_Formulario) Then

                        _Mensaje.Detalle = "Validación Modalidad: " & Modalidad
                        Throw New System.Exception("Este folio " & _Folio & " tiene mas de (" & _Meses & ") meses desde su fecha de creación" & vbCrLf &
                              "en el SII y su configuración indica que podría estar vencido." & vbCrLf &
                              "Si usted insite en el envío, este documento podria ser rechazado." & vbCrLf & vbCrLf &
                              "INFORME ESTA SITUACION AL ADMINISTRADOR DEL SISTEMA")

                    End If

                Else

                    _Mensaje.EsCorrecto = True
                    _Mensaje.Detalle = "Información"
                    _Mensaje.Mensaje = "Folios encontrados correctamente."
                    _Mensaje.Icono = MessageBoxIcon.Information

                End If

            End If

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function

    Function Fx_Revisar_Expiracion_Folio_SII_Old(_Formulario As Form,
                                             _Tido As String,
                                             _Folio As String,
                                             _MostrarMensajeExpiracion As Boolean) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Firma_Bakapp As Boolean = Fx_Firmar_X_Bakapp2(_Tido)
        Dim _Firma_RunMonitor As Boolean = Not _Firma_Bakapp

        If _Firma_Bakapp Then
            'Return Fx_Revisar_Expiracion_Folio_SII_Hefesto_Bakapp(_Formulario, _Tido, _Folio, _MostrarMensajeExpiracion)
        End If

        If _Tido = "GDP" Or _Tido = "GDD" Or _Tido = "GTI" Then
            _Tido = "GDV"
        End If

        Dim _Td = Fx_Tipo_DTE_VS_TIDO(_Tido)

        Dim _AmbienteCertificacion As Integer = Convert.ToInt32(_Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion"))

        If _Firma_Bakapp Then
            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_DTE_Caf With ( NOLOCK )" & vbCrLf &
                      "Where Cast(RNG_D AS INT)<=" & Val(_Folio) & " And Cast(RNG_H AS INT)>=" & Val(_Folio) &
                      " And TD='" & _Td & "' And Empresa='" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion
        Else
            Consulta_sql = "Select TOP 1 * FROM FFOLIOS WITH ( NOLOCK )" & vbCrLf &
                           "Where CAST(RNG_D AS INT)<=" & Val(_Folio) & " And Cast(RNG_H AS INT)>=" & Val(_Folio) &
                           "  And TD='" & _Td & "'  AND EMPRESA='" & ModEmpresa & "' "
        End If

        Dim _Row_Folios As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Folios) Then

            If Not IsNothing(_Formulario) Then

                Dim _MsgFolio As String

                If _Firma_Bakapp Then
                    _MsgFolio = "(Folios por Hefesto BakApp)"
                Else
                    _MsgFolio = "(Folios Random)"
                End If

                MessageBoxEx.Show(_Formulario, "el folio del documento electrónico no está autorizado por el SII: " & _Folio & vbCrLf & vbCrLf &
                                  "INFORME ESTA SITUACION AL ADMINISTRADOR DEL SISTEMA POR FAVOR", "Validación Modalidad: " & Modalidad & " " & _MsgFolio,
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        Else

            Dim _Fa As DateTime = FormatDateTime(CDate(_Row_Folios.Item("FA")), DateFormat.ShortDate)
            Dim _Fecha_Servisor As DateTime = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

            Dim _Meses As Integer = 6

            If _Sql.Fx_Existe_Tabla("FDTECONF") Then

                Try
                    _Meses = _Sql.Fx_Trae_Dato("FDTECONF", "VALOR", "CAMPO = 'sii.meses.expiran.folios' And ACTIVO=1 And EMPRESA = '" & ModEmpresa & "'")
                Catch ex As Exception
                    If _Tido = "BLV" Then
                        _Meses = 24
                    ElseIf _Tido = "GDV" Then
                        _Meses = 12
                    End If
                End Try

            End If

            Dim _Meses_Dif As Double = DateDiff(DateInterval.Month, _Fa, _Fecha_Servisor)
            Dim _Dias_Dif As Integer = DateDiff(DateInterval.Day, _Fa, _Fecha_Servisor)

            _Meses_Dif = Math.Round(_Dias_Dif / 31, 2)

            If _Meses_Dif > _Meses Then

                If Not IsNothing(_Formulario) Then

                    MessageBoxEx.Show(_Formulario, "Este folio " & _Folio & " tiene mas de (" & _Meses & ") meses desde su fecha de creación" & vbCrLf &
                              "en el SII y su configuración indica que podría estar vencido." & vbCrLf &
                              "Si usted insite en el envío, este documento podria ser rechazado." & vbCrLf & vbCrLf &
                              "INFORME ESTA SITUACION AL ADMINISTRADOR DEL SISTEMA POR FAVOR", "Validación Modalidad: " & Modalidad, MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If

            Else

                Return True

            End If

        End If

    End Function

    Function Fx_Revisar_Expiracion_Folio_SII_Hefesto_Bakapp(_Formulario As Form,
                                                            _Tido As String,
                                                            _Folio As String,
                                                            _MostrarMensajeExpiracion As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        'Throw New System.Exception("No se encontro el detalle del documento en la tabla Zw_Stmp_Det")
        Try

            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

            If _Tido = "GDP" Or _Tido = "GDD" Or _Tido = "GTI" Then
                _Tido = "GDV"
            End If

            Dim _Td = Fx_Tipo_DTE_VS_TIDO(_Tido)
            Dim _AmbienteCertificacion As Integer

            _AmbienteCertificacion = Convert.ToInt32(_Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion"))

            Consulta_sql = "Select Empresa,Tido,RE,RS,TD,RNG_D,RNG_H,FA,DATEADD(MONTH,6,FA) As 'FechaVencFolios'," &
                           "DATEDIFF(DAY,GETDATE(),DATEADD(MONTH,6,FA)) As 'DiasDif', RSAPK_M," & vbCrLf &
                           "(Select COUNT(*) From MAEEDO Where TIDO = '" & _Tido & "' And NUDO Between RIGHT(REPLICATE('0', 10) + " &
                           "CAST(RNG_D AS VARCHAR(10)), 10) And RIGHT(REPLICATE('0', 10) + CAST(RNG_H AS VARCHAR(10)), 10)) As 'DocGen'," & vbCrLf &
                           "RNG_H-RNG_D+1 As 'NroDoc'," & vbCrLf &
                           "(RNG_H-RNG_D+1) - (Select COUNT(*) From MAEEDO Where TIDO = '" & _Tido & "' And NUDO between RIGHT(REPLICATE('0', 10) + " &
                           "CAST(RNG_D AS VARCHAR(10)), 10) And RIGHT(REPLICATE('0', 10) + CAST(RNG_H AS VARCHAR(10)), 10)) As 'SaldoFolios'," & vbCrLf &
                           "RIGHT(REPLICATE('0', 10) + CAST(RNG_D AS VARCHAR(10)), 10) AS NroDesde," & vbCrLf &
                           "RIGHT(REPLICATE('0', 10) + CAST(RNG_H AS VARCHAR(10)), 10) AS NroHasta," & vbCrLf &
                           "RSAPK_E, IDK, FRMA, RSASK, RSAPUBK, CAF, AmbienteCertificacion" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_DTE_Caf" & vbCrLf &
                           "Where TD='" & _Td & "' And Empresa='" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion & vbCrLf &
                           "And " & Val(_Folio) & " Between Cast(RNG_D As int) And Cast(RNG_H As int) "

            Dim _Row_Folios As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New System.Exception(_Mensaje.Mensaje)
            End If

            If IsNothing(_Row_Folios) Then

                If Not IsNothing(_Formulario) Then

                    _Mensaje.Detalle = "Validación Modalidad: " & Modalidad
                    Throw New System.Exception("El folio del documento electrónico no está autorizado por el SII: " & _Folio & vbCrLf & vbCrLf &
                                      "INFORME ESTA SITUACION AL ADMINISTRADOR DEL SISTEMA POR FAVOR")

                End If

            Else

                Dim _FolioActual As Integer = _Folio
                Dim _Rng_d As Integer = _Row_Folios.Item("RNG_D")
                Dim _Rng_h As Integer = _Row_Folios.Item("RNG_H")

                Dim _DiasAvisoExpiraFolio As Integer
                Dim _AvisoSaldoFolios As Integer

                Try
                    _DiasAvisoExpiraFolio = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad",
                                                              "DiasAvisoExpiraFolio", "Empresa = '" & ModEmpresa & "' And TipoDoc = '" & _Tido & "' And Modalidad = '  '",, False)
                Catch ex As Exception
                    _DiasAvisoExpiraFolio = 14
                End Try

                If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                    Throw New System.Exception(_Sql.Pro_Error)
                End If

                Try
                    _AvisoSaldoFolios = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad",
                                                              "AvisoSaldoFolios", "Empresa = '" & ModEmpresa & "' And TipoDoc = '" & _Tido & "' And Modalidad = '  '",, False)
                Catch ex As Exception
                    _AvisoSaldoFolios = 20
                End Try

                If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                    Throw New System.Exception(_Sql.Pro_Error)
                End If

                Dim _DiasDif As Integer = _Row_Folios.Item("DiasDif")
                Dim _SaldoFolios As Integer = _Row_Folios.Item("SaldoFolios")

                Dim _MsgExpiraFolios As String = String.Empty
                Dim _MsgSaldoFolios As String = String.Empty

                If _DiasDif >= 0 Then

                    If (_DiasAvisoExpiraFolio >= _DiasDif) Then
                        _MsgExpiraFolios = "- Faltan más o menos " & _DiasDif & " día(s) para que expire este correlativo de folios" & vbCrLf
                    End If

                    If (_AvisoSaldoFolios >= _SaldoFolios) Then

                        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_DTE_Caf",
                                     "TD='" & _Td & "' And Empresa='" & ModEmpresa & "' " &
                                     "And AmbienteCertificacion = " & _AmbienteCertificacion & " And Cast(RNG_D As int) > " & Val(_Folio), False)

                        If Not CBool(_Reg) Then
                            _MsgSaldoFolios = "- Solo queda(n) " & _SaldoFolios & " folio(s) disponible(s) y no hay mas CAF registrados" & vbCrLf &
                                "Folios Desde:" & _Rng_d & ", hasta:" & _Rng_h
                        End If

                    End If

                End If

                If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                    Throw New System.Exception(_Sql.Pro_Error)
                End If

                If Not IsNothing(_Formulario) Then

                    If Not String.IsNullOrEmpty(_MsgExpiraFolios) Or Not String.IsNullOrEmpty(_MsgSaldoFolios) Then

                        If _MostrarMensajeExpiracion Then

                            Sb_Confirmar_Lectura("Información importante del SII" & vbCrLf & _Tido & "-" & _Folio,
                                         _MsgExpiraFolios & _MsgSaldoFolios & vbCrLf & vbCrLf, eTaskDialogIcon.Shield,
                                         "INFORME ESTA SITUACION AL ADMINISTRADOR DEL SISTEMA")

                        End If

                    End If

                End If

                Dim _DifFolios As Integer = _Rng_h - _FolioActual

                Dim _Fa As DateTime = FormatDateTime(CDate(_Row_Folios.Item("FA")), DateFormat.ShortDate)
                Dim _Fecha_Servisor As DateTime = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

                Dim _Meses As Integer = 6

                If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_DTE_Configuracion", False) Then

                    Try

                        Select Case _Tido
                            Case "BLV"
                                _Meses = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor",
                                     "Campo = 'Input_siimesesexpiranfolios_BOLETAS' And Empresa = '" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion,, False)
                            Case "NCV"
                                _Meses = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor",
                                     "Campo = 'Input_siimesesexpiranfolios_NOTASCREDITO' And Empresa = '" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion,, False)
                            Case "FDV"
                                _Meses = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor",
                                     "Campo = 'Input_siimesesexpiranfolios_NOTASDEBITO' And Empresa = '" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion,, False)
                            Case "GDV"
                                _Meses = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor",
                                     "Campo = 'siimesesexpiranfolios_GUIAS' And Empresa = '" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion,, False)
                            Case Else
                                _Meses = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor",
                                        "Campo = 'siimesesexpiranfolios' And Empresa = '" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion,, False)
                        End Select

                    Catch ex As Exception
                        _Meses = 6
                    End Try

                End If

                If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                    Throw New System.Exception(_Sql.Pro_Error)
                End If

                Dim _Meses_Dif As Double = DateDiff(DateInterval.Month, _Fa, _Fecha_Servisor)
                Dim _Dias_Dif As Integer = DateDiff(DateInterval.Day, _Fa, _Fecha_Servisor)

                _Meses_Dif = Math.Round(_Dias_Dif / 31, 2)

                If _Meses_Dif > _Meses Then

                    'If Not IsNothing(_Formulario) Then

                    _Mensaje.Detalle = "Validación Modalidad: " & Modalidad
                    Throw New System.Exception("Este folio " & _Folio & " tiene mas de (" & _Meses & ") meses desde su fecha de creación" & vbCrLf &
                          "en el SII y su configuración indica que podría estar vencido." & vbCrLf &
                          "Si usted insite en el envío, este documento podria ser rechazado." & vbCrLf & vbCrLf &
                          "INFORME ESTA SITUACION AL ADMINISTRADOR DEL SISTEMA")

                    'End If

                Else

                    _Mensaje.EsCorrecto = True
                    _Mensaje.Detalle = "Información"
                    _Mensaje.Mensaje = "Folios encontrados correctamente."
                    _Mensaje.Icono = MessageBoxIcon.Information

                End If

            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function

    Function Fx_Revisar_Expiracion_Folio_SII_Hefesto_Bakapp_Old(_Formulario As Form,
                                                            _Tido As String,
                                                            _Folio As String,
                                                            _MostrarMensajeExpiracion As Boolean) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        If _Tido = "GDP" Or _Tido = "GDD" Or _Tido = "GTI" Then
            _Tido = "GDV"
        End If

        Dim _Td = Fx_Tipo_DTE_VS_TIDO(_Tido)
        Dim _AmbienteCertificacion As Integer

        _AmbienteCertificacion = Convert.ToInt32(_Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion"))

        Consulta_sql = "Select Empresa,Tido,RE,RS,TD,RNG_D,RNG_H,FA,DATEADD(MONTH,6,FA) As 'FechaVencFolios'," &
                       "DATEDIFF(DAY,GETDATE(),DATEADD(MONTH,6,FA)) As 'DiasDif', RSAPK_M," & vbCrLf &
                       "(Select COUNT(*) From MAEEDO Where TIDO = '" & _Tido & "' And NUDO Between RIGHT(REPLICATE('0', 10) + " &
                       "CAST(RNG_D AS VARCHAR(10)), 10) And RIGHT(REPLICATE('0', 10) + CAST(RNG_H AS VARCHAR(10)), 10)) As 'DocGen'," & vbCrLf &
                       "RNG_H-RNG_D+1 As 'NroDoc'," & vbCrLf &
                       "(RNG_H-RNG_D+1) - (Select COUNT(*) From MAEEDO Where TIDO = '" & _Tido & "' And NUDO between RIGHT(REPLICATE('0', 10) + " &
                       "CAST(RNG_D AS VARCHAR(10)), 10) And RIGHT(REPLICATE('0', 10) + CAST(RNG_H AS VARCHAR(10)), 10)) As 'SaldoFolios'," & vbCrLf &
                       "RIGHT(REPLICATE('0', 10) + CAST(RNG_D AS VARCHAR(10)), 10) AS NroDesde," & vbCrLf &
                       "RIGHT(REPLICATE('0', 10) + CAST(RNG_H AS VARCHAR(10)), 10) AS NroHasta," & vbCrLf &
                       "RSAPK_E, IDK, FRMA, RSASK, RSAPUBK, CAF, AmbienteCertificacion" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_DTE_Caf" & vbCrLf &
                       "Where TD='" & _Td & "' And Empresa='" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion & vbCrLf &
                       "And " & Val(_Folio) & " Between Cast(RNG_D As int) And Cast(RNG_H As int) "

        Dim _Row_Folios As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Folios) Then

            If Not IsNothing(_Formulario) Then

                MessageBoxEx.Show(_Formulario, "El folio del documento electrónico no está autorizado por el SII: " & _Folio & vbCrLf & vbCrLf &
                                  "INFORME ESTA SITUACION AL ADMINISTRADOR DEL SISTEMA POR FAVOR", "Validación Modalidad: " & Modalidad,
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        Else

            Dim _FolioActual As Integer = _Folio
            Dim _Rng_d As Integer = _Row_Folios.Item("RNG_D")
            Dim _Rng_h As Integer = _Row_Folios.Item("RNG_H")

            Dim _DiasAvisoExpiraFolio As Integer
            Dim _AvisoSaldoFolios As Integer

            Try
                _DiasAvisoExpiraFolio = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad",
                                                          "DiasAvisoExpiraFolio", "Empresa = '" & ModEmpresa & "' And TipoDoc = '" & _Tido & "' And Modalidad = '  '",, False)
            Catch ex As Exception
                _DiasAvisoExpiraFolio = 14
            End Try

            Try
                _AvisoSaldoFolios = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad",
                                                          "AvisoSaldoFolios", "Empresa = '" & ModEmpresa & "' And TipoDoc = '" & _Tido & "' And Modalidad = '  '",, False)
            Catch ex As Exception
                _AvisoSaldoFolios = 20
            End Try

            Dim _DiasDif As Integer = _Row_Folios.Item("DiasDif")
            Dim _SaldoFolios As Integer = _Row_Folios.Item("SaldoFolios")

            Dim _MsgExpiraFolios As String = String.Empty
            Dim _MsgSaldoFolios As String = String.Empty

            If _DiasDif >= 0 Then

                If (_DiasAvisoExpiraFolio >= _DiasDif) Then
                    _MsgExpiraFolios = "- Faltan más o menos " & _DiasDif & " día(s) para que expire este correlativo de folios" & vbCrLf
                End If

                If (_AvisoSaldoFolios >= _SaldoFolios) Then

                    Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_DTE_Caf",
                                 "TD='" & _Td & "' And Empresa='" & ModEmpresa & "' " &
                                 "And AmbienteCertificacion = " & _AmbienteCertificacion & " And Cast(RNG_D As int) > " & Val(_Folio))

                    If Not CBool(_Reg) Then
                        _MsgSaldoFolios = "- Solo queda(n) " & _SaldoFolios & " folio(s) disponible(s) y no hay mas CAF registrados" & vbCrLf &
                            "Folios Desde:" & _Rng_d & ", hasta:" & _Rng_h
                    End If
                End If

            End If

            If Not IsNothing(_Formulario) Then

                If Not String.IsNullOrEmpty(_MsgExpiraFolios) Or Not String.IsNullOrEmpty(_MsgSaldoFolios) Then

                    If _MostrarMensajeExpiracion Then

                        Sb_Confirmar_Lectura("Información importante del SII" & vbCrLf & _Tido & "-" & _Folio,
                                     _MsgExpiraFolios & _MsgSaldoFolios & vbCrLf & vbCrLf, eTaskDialogIcon.Shield,
                                     "INFORME ESTA SITUACION AL ADMINISTRADOR DEL SISTEMA")

                    End If

                End If

            End If

            Dim _DifFolios As Integer = _Rng_h - _FolioActual

            Dim _Fa As DateTime = FormatDateTime(CDate(_Row_Folios.Item("FA")), DateFormat.ShortDate)
            Dim _Fecha_Servisor As DateTime = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

            Dim _Meses As Integer = 6

            If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_DTE_Configuracion") Then

                Try

                    Select Case _Tido
                        Case "BLV"
                            _Meses = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor",
                                 "Campo = 'Input_siimesesexpiranfolios_BOLETAS' And Empresa = '" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion)
                        Case "NCV"
                            _Meses = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor",
                                 "Campo = 'Input_siimesesexpiranfolios_NOTASCREDITO' And Empresa = '" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion)
                        Case "FDV"
                            _Meses = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor",
                                 "Campo = 'Input_siimesesexpiranfolios_NOTASDEBITO' And Empresa = '" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion)
                        Case "GDV"
                            _Meses = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor",
                                 "Campo = 'siimesesexpiranfolios_GUIAS' And Empresa = '" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion)
                        Case Else
                            _Meses = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor",
                                    "Campo = 'siimesesexpiranfolios' And Empresa = '" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion)
                    End Select

                    'If _Tido = "GDV" Then
                    '    _Meses = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor",
                    '             "Campo = 'siimesesexpiranfolios_GUIAS' And Empresa = '" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion)
                    'Else
                    '    _Meses = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor",
                    '                       "Campo = 'siimesesexpiranfolios' And Empresa = '" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion)
                    'End If

                Catch ex As Exception
                    _Meses = 6
                End Try

            End If

            Dim _Meses_Dif As Double = DateDiff(DateInterval.Month, _Fa, _Fecha_Servisor)
            Dim _Dias_Dif As Integer = DateDiff(DateInterval.Day, _Fa, _Fecha_Servisor)

            _Meses_Dif = Math.Round(_Dias_Dif / 31, 2)

            If _Meses_Dif > _Meses Then

                If Not IsNothing(_Formulario) Then

                    MessageBoxEx.Show(_Formulario, "Este folio " & _Folio & " tiene mas de (" & _Meses & ") meses desde su fecha de creación" & vbCrLf &
                          "en el SII y su configuración indica que podría estar vencido." & vbCrLf &
                          "Si usted insite en el envío, este documento podria ser rechazado." & vbCrLf & vbCrLf &
                          "INFORME ESTA SITUACION AL ADMINISTRADOR DEL SISTEMA", "Validación Modalidad: " & Modalidad, MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If

            Else

                Return True

            End If

        End If

    End Function

    Sub Sb_Imprimir_Documento(_Formulario As Form, _Idmaeedo As Integer, _Post_Venta As Boolean, _Modalidad_Formato As String)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Try

            Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
            Dim _RowEncabezado As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Tido = _RowEncabezado.Item("TIDO")
            Dim _Nudo = _RowEncabezado.Item("NUDO")
            Dim _Subtido = _RowEncabezado.Item("SUBTIDO")

            _Formulario.Enabled = False

            If _Post_Venta Then

                Dim exists = System.IO.File.Exists(AppPath() & "\Data\" & RutEmpresa & "\BkPost\Imp_Bkpost.xml")

                If Not exists Then
                    MessageBoxEx.Show(_Formulario, "No existe dispositivo de impresión configurado" & vbCrLf & vbCrLf &
                                      "Para configurar esta operación debe hacer lo siguiente:" & vbCrLf & vbCrLf &
                                        "-> Clic en el botón de la AMPOLLETA (Opciones especiales)" & vbCrLf &
                                        "-> Configuración impresora de salida" & vbCrLf &
                                        "-> Impresora local o conectada a red", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                Dim _DtsImp As New DatosBakApp
                _DtsImp.ReadXml(AppPath() & "\Data\" & RutEmpresa & "\BkPost\Imp_Bkpost.xml")

                If CBool(_DtsImp.Tables("Conf_Impresora_Local").Rows.Count) Then

                    Dim _Impresora As String = _DtsImp.Tables("Conf_Impresora_Local").Rows(0).Item("Impresora").ToString

                    Consulta_sql = "Select Top 1 Modalidad, TipoDoc, NombreFormato
                                    From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad
                                    Where Empresa = '" & ModEmpresa & "' And TipoDoc = '" & _Tido & "' And Modalidad = '" & _Modalidad_Formato & "'"

                    Dim _RowNombreFormato As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
                    Dim _NombreFormato = _RowNombreFormato.Item("NombreFormato")

                    If Not String.IsNullOrEmpty(_Impresora) Then

                        Dim _Imprime As String = Fx_Enviar_A_Imprimir_Documento(_Formulario, _NombreFormato, _Idmaeedo,
                                                                            False, False, _Impresora, False, 0, False, _Subtido)
                        If Not String.IsNullOrEmpty(Trim(_Imprime)) Then
                            MessageBox.Show(_Formulario, _Imprime, "Problemas al Imprimir",
                                       MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                    End If

                Else

                    MessageBoxEx.Show(_Formulario, "No existe dispositivo de impresión configurado" & vbCrLf & vbCrLf &
                                      "Para configurar esta operación debe hacer lo siguiente:" & vbCrLf & vbCrLf &
                                        "-> Clic en el botón de la AMPOLLETA (Opciones especiales)" & vbCrLf &
                                        "-> Configuración impresora de salida" & vbCrLf &
                                        "-> Impresora local o conectada a red", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If

            Else

                Dim _Mostrar_Mensaje = _Sql.Fx_Exite_Campo("CONFIEST", _Tido)

                Consulta_sql = "Select TOP 1 Modalidad, TipoDoc, NombreFormato
                                From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad
                                Where Empresa = '" & ModEmpresa & "' And Modalidad = '" & _Modalidad_Formato & "' And TipoDoc = '" & _Tido & "'"

                Dim _Row_Formatos_X_Modalidad As DataRow = Fx_Formato_Modalidad(_Formulario, _Modalidad_Formato, _Tido, _Mostrar_Mensaje) ' _Sql.Fx_Get_DataRow(Consulta_sql)
                Dim _NombreFormato As String

                If (_Row_Formatos_X_Modalidad Is Nothing) Then

                    Dim Fm As New Frm_Seleccionar_Formato(_Tido)

                    If CBool(Fm.Tbl_Formatos.Rows.Count) Then

                        Fm.ShowDialog(_Formulario)

                        If Fm.Formato_Seleccionado Then
                            _NombreFormato = Fm.Row_Formato_Seleccionado.Item("NombreFormato")
                            If _NombreFormato = "" Then
                                _NombreFormato = String.Empty
                            End If

                        End If

                    Else

                        MessageBoxEx.Show(_Formulario, "No existen formatos adicionales para este documento", "Validación",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, _Formulario.TopMost)
                        Return

                    End If

                    Fm.Dispose()

                Else

                    _NombreFormato = _Row_Formatos_X_Modalidad.Item("NombreFormato")

                End If


                Dim _Ruta_Impresora = AppPath() & "\Data\" & RutEmpresa & "\Configuracion_Local"

                If Not Directory.Exists(_Ruta_Impresora) Then
                    System.IO.Directory.CreateDirectory(_Ruta_Impresora)
                End If

                Dim _Archivo = _Ruta_Impresora & "\Imp_" & _Tido & ".xml"

                Dim _Existe_File = System.IO.File.Exists(_Archivo)

                If _Existe_File Then

                    Dim _DtsImp As New DatosBakApp
                    _DtsImp.ReadXml(_Archivo)

                    If CBool(_DtsImp.Tables("Conf_Impresora_Local").Rows.Count) Then

                        Dim _Impresora As String = _DtsImp.Tables("Conf_Impresora_Local").Rows(0).Item("Impresora").ToString

                        Dim _Imprime As String = Fx_Enviar_A_Imprimir_Documento(_Formulario, _NombreFormato, _Idmaeedo,
                                                                            False, False, _Impresora, False, 0, False, _Subtido)
                        If String.IsNullOrEmpty(Trim(_Imprime)) Then
                            Return
                        Else

                            If System.IO.File.Exists(_Archivo) Then Kill(_Archivo)

                            MessageBoxEx.Show(_Formulario, "Problemas al Imprimir en impresora seleccionada: " & _Impresora, "Imprimir",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, _Formulario.TopMost)

                        End If

                    End If

                End If

                Dim _Instance As New Printing.PrinterSettings
                Dim _ImpresosaPredt As String = _Instance.PrinterName
                Dim _Seleccionar_Impresora = True


                Dim Chk_Imprimir_Predeterminada As New Command
                Chk_Imprimir_Predeterminada.Visible = Not String.IsNullOrEmpty(_ImpresosaPredt.Trim)
                Chk_Imprimir_Predeterminada.Checked = Not String.IsNullOrEmpty(_ImpresosaPredt.Trim)
                Chk_Imprimir_Predeterminada.Name = "Chk_Imprimir_Predeterminada"
                Chk_Imprimir_Predeterminada.Text = "Imprimir en impresora predeterminada (" & _ImpresosaPredt & ")"

                Dim Chk_Imprimir_Cambiar As New Command
                Chk_Imprimir_Cambiar.Checked = Not Chk_Imprimir_Predeterminada.Checked
                Chk_Imprimir_Cambiar.Name = "Chk_Imprimir_Cambiar"
                Chk_Imprimir_Cambiar.Text = "Imprimir, seleccionar una impresora..."

                Dim Chk_No_Imprimir As New Command
                Chk_No_Imprimir.Checked = False
                Chk_No_Imprimir.Name = "Chk_No_Imprimir"
                Chk_No_Imprimir.Text = "No imprimir"

                Dim _Opciones() As Command = {Chk_Imprimir_Predeterminada, Chk_Imprimir_Cambiar, Chk_No_Imprimir}

                Dim _Info As New TaskDialogInfo("Imprimir documento",
                          eTaskDialogIcon.CheckMark2,
                          "Documento grabado correctamente" & vbCrLf & _Tido & " - " & _Nudo,
                          vbCrLf & "CONFIRME SU OPCION",
                          eTaskDialogButton.Ok + eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red, _Opciones,
                          Nothing, Nothing, Nothing, Nothing, True)

                Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

                If _Resultado = eTaskDialogResult.Ok Then

                    If Chk_Imprimir_Predeterminada.Checked Or Chk_Imprimir_Cambiar.Checked Then

                        _Seleccionar_Impresora = Chk_Imprimir_Cambiar.Checked

                        Dim _Imprime As String = Fx_Enviar_A_Imprimir_Documento(_Formulario, _NombreFormato, _Idmaeedo,
                                                                        False, _Seleccionar_Impresora, _ImpresosaPredt, False,
                                                                        0, False, _Subtido)

                        If Not String.IsNullOrEmpty(Trim(_Imprime)) Then
                            MessageBoxEx.Show(_Formulario, _Imprime, "Problemas al Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Stop,
                                      MessageBoxDefaultButton.Button1, _Formulario.TopMost)
                        End If

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBoxEx.Show(_Formulario, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, _Formulario.TopMost)
        Finally
            _Formulario.Enabled = True
        End Try

    End Sub

    Function Fx_Revisar_Si_Hay_Archivos_Adjuntos(_NombreEquipo As String, _TblDetalle As DataTable, _Campo_Idmaeedo As String) As Integer

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Archivos As Integer
        Dim _Filtros_Idmaeedo = Generar_Filtro_IN(_TblDetalle, "", _Campo_Idmaeedo, False, False, "")

        If _Filtros_Idmaeedo <> "()" Then

            _Archivos += _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Docu_Archivos", "Idmaeedo In " & _Filtros_Idmaeedo)

        End If

        _Archivos += _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Casi_DocArc", "NombreEquipo = '" & _NombreEquipo & "' And En_Construccion = 1")

        Return _Archivos

        'If _Archivos > 0 Then
        '    Btn_Archivos_Adjuntos.Text = _Archivos
        '    Btn_Archivos_Adjuntos.Tooltip = "Archivos adjuntos al documento (" & _Archivos & " archivo(s))"
        'Else
        '    Btn_Archivos_Adjuntos.Text = String.Empty
        '    Btn_Archivos_Adjuntos.Tooltip = "Archivos adjuntos al documento"
        'End If

    End Function

    Sub Sb_Actualizar_Formar_De_Pago()

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) Values " &
                       "('TIDP_Cli','Pago en efectivo','EFV','EFECTIVO',0)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) Values " &
                       "('TIDP_Cli','Pago con cheque','CHV','CHEQUE',1)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) Values " &
                       "('TIDP_Cli','Pago con tarjeta','TJV','TARJETA',3)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) Values " &
                       "('TIDP_Cli','Pago con letra de cambio','LTV','LETRA DE CAMBIO',4)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) Values " &
                       "('TIDP_Cli','Pagare de credito','PAV','PAGARE DE CREDITO',5)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) Values " &
                       "('TIDP_Cli','Pago con deposito','DEP','DEPOSITO',6)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) Values " &
                       "('TIDP_Cli','Pago con transferencia','ATB','TRANSFERENCIA BANCARIA',7)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) Values " &
                       "('TIDP_Cli','Pago con Nota de Credito','ncv','NOTA DE CREDITO',8)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        '----

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) Values " &
               "('TIDP_Cli','Pago con Nota de Credito Exportacion.','nev','PAGO CON NOTA DE CREDITO EXPORTACION',9)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) Values " &
               "('TIDP_Cli','Pago con Nota de Credito Exenta','ncx','PAGO CON NOTA DE CREDITO EXENTA',10)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) Values " &
               "('TIDP_Cli','Pago con Factura del cliente/proveedor','fcc','PAGO CON FACTURA DEL CLIENTE/PROVEEDOR',11)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) Values " &
               "('TIDP_Cli','Pago con Nota de Debito del cliente/proveedor','fdc','PAGO CON NOTA DE DEBITO DEL CLIENTE/PROVEEDOR',12)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) Values " &
               "('TIDP_Cli','Pago con Comprobante de retencion venta','CRV','COMPROBANTE DE RETENCION VENTA',13)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) Values " &
               "('TIDP_Cli','Pago con Comprobante retencion iva venta','RIV','COMPROBANTE RETENCION IVA VENTA',14)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) Values " &
               "('TIDP_Cli','Pago con Comprobante retencion ing. brutos venta','RBV','COMPROBANTE RETENCION ING. BRUTOS VENTA',15)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) Values " &
               "('TIDP_Cli','Pago con Comprobante retencion ganancias venta','RGV','COMPROBANTE RETENCION GANANCIAS VENTA',16)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        ''''
        '''
        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) Values " &
               "('TIDP_Cli','Pago con Cta. Cte.','CTA','CUENTA CORRIENTE / SALDO A FAVOR',3)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

    End Sub

    Sub Sb_Llenar_Listado_Funciones(_Posicion_Desde As Integer,
                                    _Texto As String,
                                    ByRef _Funciones As List(Of String))

        Dim _Posicion_Hasta = _Texto.Length

        Dim _Funcion As String

        For i = _Posicion_Desde To _Posicion_Hasta

            Dim _Inicio As String

            Try
                _Inicio = _Texto.Substring(i, 1)
            Catch ex As Exception
                _Inicio = ""
            End Try


            If _Inicio = "<" Then

                For _x = i + 1 To _Posicion_Hasta

                    Dim _Letra As String = _Texto.Substring(_x, 1)

                    If _Letra = ">" Then

                        If _Funcion <> "br /" And _Funcion <> "!DOCTYPE html" Then
                            _Funciones.Add(_Funcion)
                        End If

                        Dim _Resto = _Texto.Length - _x

                        If _Resto < _Posicion_Hasta Then

                            Sb_Llenar_Listado_Funciones(_x + 1, _Texto, _Funciones)
                            Return

                        End If

                    Else
                        _Funcion = _Funcion & _Letra
                    End If

                Next

            End If

        Next

    End Sub

    Function Fx_Parametro_Vs_Variable(_Parametro As String, _Row As DataRow) As String

        Dim _Valor
        Dim _Valor_Devuelto = String.Empty
        Dim _Type As String

        Try

            Dim _Vl = Split(Replace(Replace(_Parametro, "<", ""), ">", ""), ",")

            Dim _Campo As String = _Vl(0)
            Dim _Formato As String
            Dim _Rango_Desde As Integer
            Dim _Rango_Hasta As Integer

            If _Parametro.Contains(",") Then
                If _Vl.Length = 3 Then
                    Try
                        _Rango_Desde = _Vl(1)
                        _Rango_Hasta = _Vl(2)
                    Catch ex As Exception
                        Throw New System.Exception(ex.Message)
                    End Try
                End If
                If _Vl.Length = 2 Then
                    _Formato = _Vl(1).ToUpper
                End If
            End If

            _Campo = Replace(_Campo.ToUpper, "DOC_", "").ToUpper
            _Campo = Replace(_Campo.ToUpper, "DESPACHO_", "").ToUpper

            Try

                _Type = _Row.Item(_Campo).GetType.ToString

                'If _Parametro.ToString.ToUpper.Contains("DOC_") Then

                'If _Parametro.ToString.ToUpper.Contains("DESPACHO_") Then

                '    _Valor = _Row.Item(_Campo)

                'End If

                Select Case _Parametro

                    Case "<Doc_Vanedo,0>"

                        _Valor = FormatCurrency(_Row.Item(_Campo), 0)

                    Case "<Doc_Vanedo,1>"

                        _Valor = FormatCurrency(_Row.Item(_Campo), 1)

                    Case "<Doc_Vanedo,2>"

                        _Valor = FormatCurrency(_Row.Item(_Campo), 2)

                    Case "<Doc_Vabrdo>"

                        _Valor = FormatCurrency(_Row.Item(_Campo), 0)

                    Case "<Doc_Feemdo>", "<Doc_Feemdo,1>"

                        _Valor = FormatDateTime(_Row.Item(_Campo), DateFormat.ShortDate)

                    Case "<Doc_Feemdo,2>"

                        _Valor = FormatDateTime(_Row.Item(_Campo), DateFormat.LongDate)

                    Case Else

                        _Valor = _Row.Item(_Campo)

                End Select

                'End If

                If _Type.Contains("Double") Or _Type.Contains("Int") Then

                    If IsNothing(_Formato) Then
                        _Valor_Devuelto = FormatNumber(_Valor, 0)
                    Else

                        If _Formato.ToUpper.Contains("C") Then
                            Select Case _Formato
                                Case "C1"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 1)
                                Case "C2"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 2)
                                Case "C3"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 3)
                                Case Else
                                    _Valor_Devuelto = FormatCurrency(_Valor, 0)
                            End Select
                        End If

                        If _Formato.ToUpper.Contains("N") Then
                            Select Case _Formato
                                Case "N1"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 1)
                                Case "N2"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 2)
                                Case "N3"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 3)
                                Case Else
                                    _Valor_Devuelto = FormatCurrency(_Valor, 0)
                            End Select
                        End If
                    End If

                ElseIf _Type.Contains("Date") Then

                    If IsNothing(_Formato) Then
                        _Valor_Devuelto = Format(_Valor, "dd/MM/yyyy")
                    Else

                        Try
                            Select Case _Formato
                                Case "DD/MM/AAAA"
                                    _Valor_Devuelto = Format(_Valor, "dd/MM/yyyy")
                                Case "DD-MM-AAAA"
                                    _Valor_Devuelto = Format(_Valor, "dd-MM-yyyy")
                                Case "LONGDATE"
                                    _Valor_Devuelto = FormatDateTime(_Valor, DateFormat.LongDate)
                                Case Else
                                    _Valor_Devuelto = FormatDateTime(_Valor, DateFormat.ShortDate)
                            End Select
                        Catch ex As Exception
                            Throw New System.Exception(ex.Message)
                        End Try

                    End If

                    '_Valor_Devuelto = NuloPorNro(_Valor, "")

                ElseIf _Type.Contains("Boolean") Then
                    _Valor_Devuelto = NuloPorNro(_Valor, 0)
                Else

                    _Valor_Devuelto = NuloPorNro(_Valor, "")

                    If _Rango_Hasta > _Rango_Desde Then

                        _Rango_Hasta = (_Rango_Hasta - _Rango_Desde) + 1

                        _Valor_Devuelto = Mid(_Valor_Devuelto, _Rango_Desde, _Rango_Hasta) & "_"

                    End If

                    _Valor_Devuelto = _Valor_Devuelto.Trim

                End If

                'Dim _Typos As New List(Of String)
                'For i = 0 To _Row.ItemArray.Length - 1
                '    _Typos.Add(_Row.Item(i).GetType.ToString)
                'Next
                'Dim f = 0

            Catch ex As Exception
                _Valor_Devuelto = _Campo & " -> Función desconocida"
            End Try

        Catch ex As Exception
            _Valor_Devuelto = ex.Message & "... Error en función: " & _Parametro
        End Try

        Return _Valor_Devuelto

    End Function

    Function Fx_Parametro_Vs_Variable(_Parametro As String, _Row As DataRow, _Sufijo As String) As String

        Dim _Valor
        Dim _Valor_Devuelto = String.Empty
        Dim _Type As String

        Try

            Dim _Vl = Split(Replace(Replace(_Parametro, "<", ""), ">", ""), ",")

            Dim _Campo As String = _Vl(0)
            Dim _Formato As String
            Dim _Rango_Desde As Integer
            Dim _Rango_Hasta As Integer

            _Campo = _Campo.Replace(_Sufijo, "")

            If _Parametro.Contains(",") Then
                If _Vl.Length = 3 Then
                    Try
                        _Rango_Desde = _Vl(1)
                        _Rango_Hasta = _Vl(2)
                    Catch ex As Exception
                        Throw New System.Exception(ex.Message)
                    End Try
                End If
                If _Vl.Length = 2 Then
                    _Formato = _Vl(1).ToUpper
                End If
            End If

            _Campo = Replace(_Campo.ToUpper, "DOC_", "").ToUpper
            _Campo = Replace(_Campo.ToUpper, "DESPACHO_", "").ToUpper

            Try

                _Type = _Row.Item(_Campo).GetType.ToString

                'If _Parametro.ToString.ToUpper.Contains("DOC_") Then

                'If _Parametro.ToString.ToUpper.Contains("DESPACHO_") Then

                '    _Valor = _Row.Item(_Campo)

                'End If

                Select Case _Parametro

                    Case "<Doc_Vanedo,0>"

                        _Valor = FormatCurrency(_Row.Item(_Campo), 0)

                    Case "<Doc_Vanedo,1>"

                        _Valor = FormatCurrency(_Row.Item(_Campo), 1)

                    Case "<Doc_Vanedo,2>"

                        _Valor = FormatCurrency(_Row.Item(_Campo), 2)

                    Case "<Doc_Vabrdo>"

                        _Valor = FormatCurrency(_Row.Item(_Campo), 0)

                    Case "<Doc_Feemdo>", "<Doc_Feemdo,1>"

                        _Valor = FormatDateTime(_Row.Item(_Campo), DateFormat.ShortDate)

                    Case "<Doc_Feemdo,2>"

                        _Valor = FormatDateTime(_Row.Item(_Campo), DateFormat.LongDate)

                    Case Else

                        _Valor = _Row.Item(_Campo)

                End Select

                'End If

                If _Type.Contains("Double") Or _Type.Contains("Int") Then

                    If IsNothing(_Formato) Then
                        _Valor_Devuelto = FormatNumber(_Valor, 0)
                    Else

                        If _Formato.ToUpper.Contains("C") Then
                            Select Case _Formato
                                Case "C1"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 1)
                                Case "C2"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 2)
                                Case "C3"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 3)
                                Case Else
                                    _Valor_Devuelto = FormatCurrency(_Valor, 0)
                            End Select
                        End If

                        If _Formato.ToUpper.Contains("N") Then
                            Select Case _Formato
                                Case "N1"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 1)
                                Case "N2"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 2)
                                Case "N3"
                                    _Valor_Devuelto = FormatCurrency(_Valor, 3)
                                Case Else
                                    _Valor_Devuelto = FormatCurrency(_Valor, 0)
                            End Select
                        End If
                    End If

                ElseIf _Type.Contains("Date") Then

                    If IsNothing(_Formato) Then
                        _Valor_Devuelto = Format(_Valor, "dd/MM/yyyy")
                    Else

                        Try
                            Select Case _Formato
                                Case "DD/MM/AAAA"
                                    _Valor_Devuelto = Format(_Valor, "dd/MM/yyyy")
                                Case "DD-MM-AAAA"
                                    _Valor_Devuelto = Format(_Valor, "dd-MM-yyyy")
                                Case "LONGDATE"
                                    _Valor_Devuelto = FormatDateTime(_Valor, DateFormat.LongDate)
                                Case Else
                                    _Valor_Devuelto = FormatDateTime(_Valor, DateFormat.ShortDate)
                            End Select
                        Catch ex As Exception
                            Throw New System.Exception(ex.Message)
                        End Try

                    End If

                    '_Valor_Devuelto = NuloPorNro(_Valor, "")

                ElseIf _Type.Contains("Boolean") Then
                    _Valor_Devuelto = NuloPorNro(_Valor, 0)
                Else

                    _Valor_Devuelto = NuloPorNro(_Valor, "")

                    If _Rango_Hasta > _Rango_Desde Then

                        _Rango_Hasta = (_Rango_Hasta - _Rango_Desde) + 1

                        _Valor_Devuelto = Mid(_Valor_Devuelto, _Rango_Desde, _Rango_Hasta) & "_"

                    End If

                    _Valor_Devuelto = _Valor_Devuelto.Trim

                End If

                'Dim _Typos As New List(Of String)
                'For i = 0 To _Row.ItemArray.Length - 1
                '    _Typos.Add(_Row.Item(i).GetType.ToString)
                'Next
                'Dim f = 0

            Catch ex As Exception
                _Valor_Devuelto = _Campo & " -> Función desconocida"
            End Try

        Catch ex As Exception
            _Valor_Devuelto = ex.Message & "... Error en función: " & _Parametro
        End Try

        Return _Valor_Devuelto

    End Function

    Function Fx_Guargar_PDF_Automaticamente_Por_Doc_Modalidad(_Idmaeedo As Integer) As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _Error = String.Empty

        Try

            If Not _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad", "Guardar_PDF_Auto") Then
                Return ""
            End If

            If Not _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Estaciones_Ruta_PDF") Then
                Return ""
            End If

            Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo & "-- And NUDONODEFI = 0"
            Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Documento) Then
                Return ""
            End If

            Dim _Tido As String = _Row_Documento.Item("TIDO")
            Dim _Nudo As String = _Row_Documento.Item("NUDO")
            Dim _Nudonodefi As String = _Row_Documento.Item("NUDONODEFI")
            Dim _Tidoelec As Boolean = _Row_Documento.Item("TIDOELEC")

            'Dim _Subtido As String = _Sql.Fx_Trae_Dato("MAEEDO", "SUBTIDO", "IDMAEEDO = " & _Idmaeedo)

            If _Nudonodefi Then
                Return ""
            End If

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad 
                            Where Empresa = '" & ModEmpresa & "' And Modalidad = '" & Modalidad & "' And TipoDoc = '" & _Tido & "'"
            Dim _RowFormato_Mod As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Guardar_PDF_Auto As Boolean = _RowFormato_Mod.Item("Guardar_PDF_Auto")
            Dim _NombreFormato_PDF As String = _RowFormato_Mod.Item("NombreFormato_PDF")
            Dim _Ruta_PDF As String

            If _Guardar_PDF_Auto Then

                Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

                _Ruta_PDF = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Estaciones_Ruta_PDF", "Ruta_PDF",
                                              "Empresa = '" & ModEmpresa & "' And NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & Modalidad & "' And Tido = '" & _Tido & "'")

                If Not Directory.Exists(_Ruta_PDF) Then
                    Return "No se puede guardar el PDF. No existe Ruta (Carpeta de destino de los archivos)"
                End If

                Dim _Pdf_Adjunto As New Clas_PDF_Crear_Documento(_Idmaeedo,
                                                                 _Tido,
                                                                 _NombreFormato_PDF,
                                                                 _Tido & "-" & _Nudo,
                                                                 _Ruta_PDF,
                                                                 _Tido & "-" & _Nudo,
                                                                 _Tidoelec)
                _Error = _Pdf_Adjunto.Pro_Error

                If String.IsNullOrEmpty(_Error) Then

                    _Pdf_Adjunto.Sb_Crear_PDF("", False, _Pdf_Adjunto.Pro_Nombre_Archivo)
                    _Error = _Pdf_Adjunto.Pro_Error

                    Dim _Existe_File = System.IO.File.Exists(_Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf")

                End If

            End If

        Catch ex As Exception
            _Error = ex.Message
        End Try

        Return _Error

    End Function

    Sub Sb_ReGuargar_PDF_Automaticamente_Por_Doc_Modalidad(_Formulario As Form, _Idmaeedo As Integer)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _Error = String.Empty
        Dim _Ruta_PDF As String
        Dim _NombreFormato_PDF As String
        Dim _Nombre_Archivo_PDF As String

        Try

            If Not _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad", "Guardar_PDF_Auto") Then
                Throw New System.Exception("No existe el campo [Guardar_PDF_Auto] En la Tabla [Zw_Configuracion_Formatos_X_Modalidad]")
            End If

            If Not _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Estaciones_Ruta_PDF") Then
                Throw New System.Exception("No existe la Tabla [Zw_Estaciones_Ruta_PDF]")
            End If

            Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
            Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Documento) Then
                Throw New System.Exception("No se encontro el documento")
            End If

            Dim _Tido As String = _Row_Documento.Item("TIDO")
            Dim _Nudo As String = _Row_Documento.Item("NUDO")
            Dim _Nudonodefi As String = _Row_Documento.Item("NUDONODEFI")
            Dim _Tidoelec As Boolean = _Row_Documento.Item("TIDOELEC")
            'Dim _Subtido As String = _Row_Documento.Item("SUBTIDO")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad 
                            Where Empresa = '" & ModEmpresa & "' And  Modalidad = '" & Modalidad & "' And TipoDoc = '" & _Tido & "'"
            Dim _RowFormato_Mod As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Guardar_PDF_Auto As Boolean = _RowFormato_Mod.Item("Guardar_PDF_Auto")
            _NombreFormato_PDF = _RowFormato_Mod.Item("NombreFormato_PDF")


            If _Guardar_PDF_Auto Then

                Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

                _Ruta_PDF = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Estaciones_Ruta_PDF", "Ruta_PDF",
                                              "NombreEquipo = '" & _NombreEquipo & "' And Modalidad = '" & Modalidad & "' And Tido = '" & _Tido & "'")

                If Not Directory.Exists(_Ruta_PDF) Then
                    Throw New System.Exception("No se puede guardar el PDF. No existe Ruta (Carpeta de destino de los archivos)" & vbCrLf & vbCrLf & "Ruta:" & _Ruta_PDF)
                End If

                Dim _Pdf_Adjunto As New Clas_PDF_Crear_Documento(_Idmaeedo,
                                                                 _Tido,
                                                                 _NombreFormato_PDF,
                                                                 _Tido & "-" & _Nudo,
                                                                 _Ruta_PDF,
                                                                 _Tido & "-" & _Nudo,
                                                                 _Tidoelec)
                _Error = _Pdf_Adjunto.Pro_Error

                If String.IsNullOrEmpty(_Error) Then

                    _Pdf_Adjunto.Sb_Crear_PDF("", False, _Pdf_Adjunto.Pro_Nombre_Archivo)
                    _Error = _Pdf_Adjunto.Pro_Error
                    _Nombre_Archivo_PDF = _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf"
                    Dim _Existe_File = System.IO.File.Exists(_Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Nombre_Archivo_PDF)

                End If

            Else
                Throw New System.Exception("No existe configuración de salida para este equipo" & vbCrLf &
                                           "Para configurar debe ir a la configuración de modalidad y en los documentos grabar la salida a PDF junto con el formato")
            End If

        Catch ex As Exception
            _Error = ex.Message
        End Try

        If String.IsNullOrEmpty(_Error) Then
            MessageBoxEx.Show(_Formulario, "Documento guardado correctamente." & vbCrLf & "Ruta:" & _Ruta_PDF & "\" & _Nombre_Archivo_PDF, "Guardar PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Process.Start("explorer.exe", _Ruta_PDF)
        Else
            MessageBoxEx.Show(_Formulario, _Error.Trim, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Function Fx_Lista_Campos_Dscto() As List(Of String)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _Lista As New List(Of String)

        Consulta_sql = "Declare @Campos Int

                        Set @Campos =(Select Count(*) From PNOMDIM Where DEPENDENCI = 'Por_tabpp' And NOMBRE = CODIGO And CODIGO <> 'PASO01P')

                        Select TOP 1 OPERA,Cast(SUBSTRING(OPERA,28,@Campos*2) As Varchar(200)) As Opera_Rev 
                        INTO #Paso
                        From TABPP Where OPERA LIKE 'XX%'

                         Update #Paso Set Opera_Rev = REPLACE(Opera_Rev,'  ','Dp,')
                         Update #Paso Set Opera_Rev = REPLACE(Opera_Rev,' 1','Dv,')
                         Update #Paso Set Opera_Rev = REPLACE(Opera_Rev,' 2','Rp,')
                         Update #Paso Set Opera_Rev = REPLACE(Opera_Rev,' 3','Rv,')

                        Select * From #Paso
                        Drop Table #Paso"

        Dim _Row_Opera As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Opera) Then

            Dim _Opera As String = _Row_Opera.Item("Opera_Rev")
            Dim _Opera_Rev = Split(_Opera, ",")

            Consulta_sql = "Select Top 1 * From TABPRE"
            Dim _TblTabpre As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            ' Asi es como actua el campo OPERA, este campo define como se comportaran los campos adicionales a partir del campo nro 29 en adelante

            '       28 - Ultimo Campo EDTMA02UD

            '        '' = Descuento Porcentaje
            '        1  = Descuento Valor
            '        2  = Recargo Porcentaje
            '        3  = Recargo Valor

            Dim _j = 0

            For _i = 28 To _TblTabpre.Columns.Count - 1

                Dim _Columna As DataColumn = _TblTabpre.Columns(_i)
                Dim _Nombre_Columna As String = _Columna.ColumnName

                If Mid(_Nombre_Columna, 1, 5) <> "FORM_" Then

                    Dim _Campo_Ecuacion As String = "FORM_" & numero_(_i + 1, 3)
                    Dim _TCampo As String

                    Try
                        _TCampo = _Opera_Rev(_j)
                    Catch ex As Exception
                        _TCampo = String.Empty
                    End Try

                    If _TCampo = "Dp" Then
                        _Lista.Add(_Nombre_Columna)
                    End If

                End If

                _j += 1

            Next

        End If

        Return _Lista

    End Function

    Public Sub Sb_Color_Botones_Barra(_Barra As DevComponents.DotNetBar.Bar)

        Dim _Color As Color = Color.Black

        If Global_Thema = Enum_Themas.Oscuro Then _Color = Color.White

        For Each _Objeto As Object In _Barra.Items
            If (TypeOf _Objeto Is ButtonItem) Or (TypeOf _Objeto Is LabelItem) Then
                Dim _Name = _Objeto.Name
                Try
                    _Objeto.ForeColor = _Color
                Catch ex As Exception

                End Try
            End If
        Next

    End Sub

    Public Function Fx_Crear_Voucher_Transbank(_Tipo_de_Tarjeta As String,
                                                _Fecha As String,
                                                _Hora As String,
                                                _Nro_Tarjeta As String,
                                                _Monto As Double,
                                                _Numero_Ticket_Boleta As String,
                                                _Nro_Operacion As String,
                                                _Cod_Autorizacion As String,
                                                _Marca_tjv As String) As String

        Dim _Voucher As String

        Dim _Nombre_Empresa As String = "SIERRALTA AUTOSERV"
        Dim _Direccion_Empresa As String = "AVDA BRASIL 24 SN"
        Dim _Comuna_Empresa As String = "SANTIAGO"

        ' 40 espacios
        Dim _Post_Terminal = "597034692696"
        Dim _Post_Version = "U18.1L2"
        Dim _Post_Tem_Ver = _Post_Terminal.Trim & "-" & _Post_Version.Trim

        'Formato fecha = "dd/MM/yyyy"
        'Formatop hora = "hh:mm"

        _Voucher = "          COMPROBANTE DE VENTA          " &
                   "<tipo_de_tarjeta>" &
                   "<nombre_empresa>" &
                   "<direccion_empresa>" &
                   "<comuna_empresa>" &
                   "<Post_Tem_Ver>" &
                   "                                        " &
                   "FECHA             HORA          TERMINAL" &
                   "<Fecha...>       <Hor>    <post_version>" &
                   "                                        " &
                   "NUMERO DE TARJETA                       " &
                   "<Nro_Tarjeta>" &
                   "                                        " &
                   "TOTAL:<Total>" &
                   "NUMERO DE BOLETA:<NroBoletaFactura>" &
                   "NUMERO DE OPERACION:<Nro_Operacion>" &
                   "CODIGO DE AUTORIZACION:<Cod_Autorizacion>" &
                   "                                        " &
                   "         GRACIAS POR SU COMPRA          " &
                   " ACEPTO PAGAR SEGUN CONTRATO CON EMISOR."

        _Nombre_Empresa = Fx_Crear_Etiqueta(_Nombre_Empresa)
        _Direccion_Empresa = Fx_Crear_Etiqueta(_Direccion_Empresa)
        _Comuna_Empresa = Fx_Crear_Etiqueta(_Comuna_Empresa)

        _Post_Tem_Ver = Fx_Crear_Etiqueta(_Post_Tem_Ver)

        If _Tipo_de_Tarjeta = "DB" Then
            _Tipo_de_Tarjeta = "TARJETA DE DEBITO "
        ElseIf _Tipo_de_Tarjeta = "CR" Then
            _Tipo_de_Tarjeta = "TARJETA DE CREDITO"
        End If

        _Tipo_de_Tarjeta = Fx_Crear_Etiqueta(_Tipo_de_Tarjeta)

        _Voucher = Replace(_Voucher, "<nombre_empresa>", _Nombre_Empresa)
        _Voucher = Replace(_Voucher, "<direccion_empresa>", _Direccion_Empresa)
        _Voucher = Replace(_Voucher, "<comuna_empresa>", _Comuna_Empresa)
        _Voucher = Replace(_Voucher, "<Post_Tem_Ver>", _Post_Tem_Ver)

        _Voucher = Replace(_Voucher, "<tipo_de_tarjeta>", _Tipo_de_Tarjeta)

        _Voucher = Replace(_Voucher, "<Fecha...>", _Fecha)
        _Voucher = Replace(_Voucher, "<Hor>", _Hora)

        Dim _largo = 40 - _Nro_Tarjeta.ToString.Length
        _Voucher = Replace(_Voucher, "<Nro_Tarjeta>", _Nro_Tarjeta & Rellenar(_Marca_tjv, _largo, " ", False))

        _Post_Version = Rellenar(_Post_Version, 14, " ", False)
        _Voucher = Replace(_Voucher, "<post_version>", _Post_Version)

        Dim _Total As String

        _Total = FormatCurrency(_Monto, 0)
        _Total = Rellenar(_Total, 34, " ", False)

        _Voucher = Replace(_Voucher, "<Total>", _Total)
        _Voucher = Replace(_Voucher, "<NroBoletaFactura>", Rellenar(_Numero_Ticket_Boleta, 23, " ", False))
        _Voucher = Replace(_Voucher, "<Nro_Operacion>", Rellenar(_Nro_Operacion, 20, " ", False))
        _Voucher = Replace(_Voucher, "<Cod_Autorizacion>", Rellenar(_Cod_Autorizacion, 17, " ", False))

        _Voucher = Replace(_Voucher, "<Total>", _Total)

        Return _Voucher


        ' Old
        '_Voucher = "          COMPROBANTE DE VENTA          " &
        '           "            <tipo_de_tarjeta_>          " &
        '           "           SIERRALTA AUTOSERV           " &
        '           "           AVDA BRASIL 24 SN            " &
        '           "                SANTIAGO                " &
        '           "          597034692696-U18.1L2          " &
        '           "                                        " &
        '           "FECHA             HORA          TERMINAL" &
        '           "<Fecha>        <Hora>         UX101992" &
        '           "                                        " &
        '           "NUMERO DE TARJETA                       " &
        '           "<Nro_Tarjeta>" &
        '           "                                        " &
        '           "TOTAL:<Total>" &
        '           "NUMERO DE BOLETA:<NroBoletaFactura>" &
        '           "NUMERO DE OPERACION:<Nro_Operacion>" &
        '           "CODIGO DE AUTORIZACION:<Cod_Autorizacion>" &
        '           "                                        " &
        '           "         GRACIAS POR SU COMPRA          " &
        '           " ACEPTO PAGAR SEGUN CONTRATO CON EMISOR."

    End Function

    Function Fx_Crear_Etiqueta(_Etiqueta As String) As String

        _Etiqueta = _Etiqueta.Trim

        Dim _largo = _Etiqueta.Length
        Dim _resto = 40 - _largo
        Dim _Div = _resto / 2
        _Etiqueta = Space(_Div) & _Etiqueta & Space(_Div)
        _largo = _Etiqueta.Length

        _Etiqueta = Mid(_Etiqueta, 1, 40)

        Return _Etiqueta

    End Function

    Sub Sb_Imprimir_Voucher_Tarjeta_Bakapp(_Formulario As Form, _Idmaeedo As Integer, _Impresora As String)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _LogError As String

        Dim _Cl_Voucher As New Clas_Imprimir_Voucher

        If Not _Cl_Voucher.Fx_Imprimir_Voucher(_Formulario, _Idmaeedo, _Impresora) Then

            Consulta_sql = "Select Top 1 Id,OperationId,FechaHora_Inicio,FechaHora_Fin,posid,posuser,Venta_Generada,Cancelado_Por_Usuario," &
                           "Cancelado_Por_Tiempo,Tido,Nudo,Pagado_CashDro,Pagado_Transbank,Pagado_Random,Idmaeedo,Tipo_De_Pago,Monto," &
                           "Impreso,Log_Error,Status_Tarjeta, Respuesta_Tarjeta" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                           "Where Idmaeedo = " & _Idmaeedo & " And Tipo_De_Pago = 'TJV'"

            Dim _Row_Tarjeta_Cashdro As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not (_Row_Tarjeta_Cashdro Is Nothing) Then

                Consulta_sql = "Select Top 1  * From MAEDPCE" & vbCrLf &
                               "Where TIDP = 'TJV' And IDMAEDPCE In" & Space(1) &
                               "(Select Top 1 IDMAEDPCE From MAEDPCD Where ARCHIRST = 'MAEEDO' And IDRST = " & _Idmaeedo & ")" & vbCrLf &
                               "Order By IDMAEDPCE Desc"
                Dim _Row_Maedpce As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If (_Row_Tarjeta_Cashdro Is Nothing) Or (_Row_Maedpce Is Nothing) Then
                    _LogError = "Documento de pago no existe en MAEDPCE"
                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                                   "Log_Error = '" & _LogError & "'" & vbCrLf &
                                   "Where Idmaeedo = " & _Idmaeedo & " And Tipo_De_Pago = 'TJV'"
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                    Return
                End If

                Dim _NombreFormato As String
                Dim _Row_Formato As DataRow

                Dim _Idmaedpce = _Row_Maedpce.Item("IDMAEDPCE")
                Dim _Tidp = _Row_Maedpce.Item("TIDP")
                Dim _Tip = _Tidp
                Dim _Nudp = _Row_Maedpce.Item("NUDP")
                Dim _Emdp = Trim(_Row_Maedpce.Item("EMDP"))

                Consulta_sql = "Select Top 1 * From TABENDP WHERE TIDPEN = '" & Mid(_Tidp, 1, 2) & "' AND KOENDP = '" & _Emdp & "'"
                Dim _Row_Tabendp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not (_Row_Tabendp Is Nothing) Then
                    Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Format_01" & vbCrLf &
                                              "Where TipoDoc = 'TJV' And Emdp = '" & _Emdp & "'"
                    _NombreFormato = Trim(_Row_Tabendp.Item("KOENDP")) & "-" & Trim(_Row_Tabendp.Item("NOKOENDP")) '000069764215

                    _Row_Formato = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Dim _Imprimir As New Clas_Imprimir_Documento(_Idmaedpce,
                                                                 _Tidp,
                                                                 _NombreFormato,
                                                                 _Tip & "-" & _Nudp,
                                                                 False, _Emdp, "")

                    _Imprimir.Pro_Impresora = _Impresora
                    _Imprimir.Fx_Imprimir_Documento(Nothing, False, False)
                    _LogError += _Imprimir.Pro_Ultimo_Error

                Else
                    _LogError = "No fue posible imprimir el Voucher de TRANSBANK, no existe tipo de pago (" & _Emdp & ") " & _Row_Tarjeta_Cashdro.Item("Respuesta_Tarjeta")
                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                               "Log_Error = '" & _LogError & "'" & vbCrLf &
                               "Where Idmaeedo = " & _Idmaeedo & " And Tipo_De_Pago = 'TJV'"
                    _Sql.Ej_consulta_IDU(Consulta_sql)
                End If

            End If

        End If

    End Sub

    Enum Enum_Tipo_Ruta
        PDF
        GRI_Ing
        GRI_Gen
    End Enum

    Sub Sb_Configuracion_Salida_PDF(_Formulario As Form, _Tido As String)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        Dim _FolderBrowserDialog As New FolderBrowserDialog

        Dim _Ruta_PDF = String.Empty

        Consulta_sql = "Select *
                        From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad" & vbCrLf &
                        "Where Empresa = '" & ModEmpresa & "' And Modalidad = '" & Modalidad & "' And TipoDoc = '" & _Tido & "'"
        Dim _RowFormato_Mod As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Guardar_PDF_Auto As Boolean = _RowFormato_Mod.Item("Guardar_PDF_Auto")

        If Not _Guardar_PDF_Auto Then

            MessageBoxEx.Show(_Formulario, "No esta configurada la grabación de PDF automático para esta modalidad." & vbCrLf &
                              "Para configurar esta operación debe hacer lo siguiente: " & vbCrLf & vbCrLf &
                              "-> Ir al Menú principal" & vbCrLf &
                              "-> Configuración de sistema (botón de las herramientas)" & vbCrLf &
                              "-> Configuración" & vbCrLf &
                              "-> Configuración de estación (Modalidades)" & vbCrLf &
                              "-> Seleccionar la modalidad" & vbCrLf &
                              "-> Numeración" & vbCrLf &
                              "-> Marcar la casilla [Guardar en PDF] en el documento " & _Tido & vbCrLf &
                              "-> Seleccionar la carpeta de salida de impresión (esto es distinto por cada estación de trabajo)" & vbCrLf &
                              "-> Grabar la fila modificada",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        _Ruta_PDF = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Estaciones_Ruta_PDF", "Ruta_PDF",
                                      "NombreEquipo = '" & _NombreEquipo & "' And Empresa = '" & ModEmpresa & "' And Modalidad = '" & Modalidad & "' And Tido = '" & _Tido & "' And Tipo_Ruta = 'PDF'")

        If Directory.Exists(_Ruta_PDF) Then

            If MessageBoxEx.Show(_Formulario, "la carpeta de salida para guardar los PDF en este equipo es: " & vbCrLf & _Ruta_PDF & vbCrLf & vbCrLf &
                                 "¿Desea cambiar el directorio?", "Configuración PDF de " & _Tido,
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                Return

            End If

        Else

            If MessageBoxEx.Show(_Formulario, "Falta la carpeta de salida para guardar los PDF en esta estación de trabajo" & vbCrLf & vbCrLf &
                  "¿Desea ingresar el directorio?", "Validación",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Stop) <> DialogResult.Yes Then
                Return
            End If

        End If

        If Not Fx_Tiene_Permiso(_Formulario, "Doc00064") Then
            Return
        End If


        Dim _Aceptar As Boolean = InputBox_Bk(_Formulario, "Ingrese la Ruta de destino" & vbCrLf &
                                              "Escriba directamente la ruta de destino o bien puede buscar la carpta...", "Guardar PDF",
                                              _Ruta_PDF, False,,, True, _Tipo_Imagen.Folder,,,,,, True)

        If Not _Aceptar Then
            Return
        End If

        If String.IsNullOrEmpty(_Ruta_PDF) Then
            MessageBoxEx.Show(_Formulario, "No se selección o ninguna carpeta de salida" & vbCrLf & "¿Desea agregar la Ruta Manualmente?",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            If Directory.Exists(_Ruta_PDF) Then
                MessageBoxEx.Show(_Formulario, "La Ruta: " & _Ruta_PDF, "Ruta no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Ruta_PDF = String.Empty
            End If

        End If


        If String.IsNullOrEmpty(_Ruta_PDF) Then
            Return
        End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Estaciones_Ruta_PDF" & vbCrLf &
                           "Where NombreEquipo = '" & _NombreEquipo & "' And Empresa = '" & ModEmpresa & "' And Modalidad = '" & Modalidad & "' And Tido = '" & _Tido & "' And Tipo_Ruta = 'PDF'" & vbCrLf &
                           "Insert Into " & _Global_BaseBk & "Zw_Estaciones_Ruta_PDF (NombreEquipo,Modalidad,Tido,Ruta_PDF,Empresa,Tipo_Ruta) " &
                            "Values ('" & _NombreEquipo & "','" & Modalidad & "','" & _Tido & "','" & _Ruta_PDF & "','" & ModEmpresa & "','PDF')"
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            MessageBoxEx.Show(_Formulario, "La carpeta de salida quedo guardada exitosamente", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Sub Sb_Configuracion_Salida_Ruta_Archivo_X_Estacion(_Formulario As Form, _Tido As String, _Tipo_Ruta As Enum_Tipo_Ruta)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

        Dim _FolderBrowserDialog As New FolderBrowserDialog
        Dim _Ruta = String.Empty

        Consulta_sql = "Select *
                        From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad" & vbCrLf &
                        "Where Empresa = '" & ModEmpresa & "' And Modalidad = '" & Modalidad & "' And TipoDoc = '" & _Tido & "'"
        Dim _RowFormato_Mod As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Guardar_PDF_Auto As Boolean = _RowFormato_Mod.Item("Guardar_PDF_Auto")

        _Ruta = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Estaciones_Ruta_PDF", "Ruta_PDF",
                "NombreEquipo = '" & _NombreEquipo & "' And Empresa = '" & ModEmpresa & "' And Modalidad = '" & Modalidad & "' And Tido = '" & _Tido & "' And Tipo_Ruta = '" & _Tipo_Ruta.ToString & "'")

        If Directory.Exists(_Ruta) Then

            If MessageBoxEx.Show(_Formulario, "la carpeta de salida para guardar los " & _Tipo_Ruta.ToString & " en este equipo es: " & vbCrLf & _Ruta & vbCrLf & vbCrLf &
                                 "¿Desea cambiar el directorio?", "Configuración PDF de " & _Tido,
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> DialogResult.Yes Then
                Return

            End If

        End If

        Dim _Permiso As String

        Select Case _Tipo_Ruta
            Case Enum_Tipo_Ruta.PDF
                _Permiso = "Doc00064"
            Case Enum_Tipo_Ruta.GRI_Ing, Enum_Tipo_Ruta.GRI_Gen
                _Permiso = "Doc00068"
        End Select

        If Not Fx_Tiene_Permiso(_Formulario, _Permiso) Then
            Return
        End If

        _FolderBrowserDialog.Reset()

        ' leyenda  
        _FolderBrowserDialog.Description = "Seleccionar una carpeta "
        ' Path " Mis documentos "  
        _FolderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        'Habilita el botón " crear nueva carpeta "  
        _FolderBrowserDialog.ShowNewFolderButton = True

        Dim ret As DialogResult = _FolderBrowserDialog.ShowDialog

        ' si se presionó el botón aceptar ...  
        If ret = Windows.Forms.DialogResult.OK Then

            Dim nFiles As ObjectModel.ReadOnlyCollection(Of String)

            nFiles = My.Computer.FileSystem.GetFiles(_FolderBrowserDialog.SelectedPath)
            _Ruta = _FolderBrowserDialog.SelectedPath

        Else

            If _Guardar_PDF_Auto Then _Ruta = String.Empty
            MessageBoxEx.Show(_Formulario, "No se selección o ninguna carpeta de salida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        _FolderBrowserDialog.Dispose()

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Estaciones_Ruta_PDF" & vbCrLf &
                       "Where NombreEquipo = '" & _NombreEquipo & "' And Empresa = '" & ModEmpresa & "' And Modalidad = '" & Modalidad & "' And Tido = '" & _Tido & "' And Tipo_Ruta = '" & _Tipo_Ruta.ToString & "'" & vbCrLf &
                       "Insert Into " & _Global_BaseBk & "Zw_Estaciones_Ruta_PDF (NombreEquipo,Modalidad,Tido,Ruta_PDF,Empresa,Tipo_Ruta) " &
                        "Values ('" & _NombreEquipo & "','" & Modalidad & "','" & _Tido & "','" & _Ruta & "','" & ModEmpresa & "','" & _Tipo_Ruta.ToString & "')"
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            MessageBoxEx.Show(_Formulario, "La carpeta quedo guardada exitosamente para esta configuración", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Public Function Fx_Eliminar_Entidad(_CodEntidad As String,
                                        _SucEntidad As String,
                                        _Fmr As Form) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        If Fx_Tiene_Permiso(_Fmr, "CfEnt004") Then

            Dim _Reg As Integer = 0

            _Reg += _Sql.Fx_Cuenta_Registros("MAEEDO", "ENDO='" & _CodEntidad & "' AND SUENDO='" & _SucEntidad & "'")

            Dim _CanEnt As Integer = _Sql.Fx_Cuenta_Registros("MAEEDO", "ENDO='" & _CodEntidad & "'")

            If _CanEnt = 1 Then
                _Reg += _Sql.Fx_Cuenta_Registros("CDOCCOE", "ENDO='" & _CodEntidad & "'")
                _Reg += _Sql.Fx_Cuenta_Registros("MAEDPCE", "ENDP='" & _CodEntidad & "'")
                _Reg += _Sql.Fx_Cuenta_Registros("MAEENPRO", "KOEN='" & _CodEntidad & "'")
            End If

            If Not CBool(_Reg) Then

                If MessageBoxEx.Show(_Fmr, "¿Esta seguro de querer eliminar esta entidad?", "Eliminar",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                    Return False
                End If

                Consulta_sql = "Delete MAEEN Where KOEN = '" & _CodEntidad & "' AND SUEN = '" & _SucEntidad & "'" & vbCrLf

                If _CanEnt = 1 Then
                    Consulta_sql += "Delete MAEENCON Where KOEN = '" & _CodEntidad & "'" & vbCrLf &
                                    "Delete MAEENPRO Where KOEN = '" & _CodEntidad & "'" & vbCrLf &
                                    "Delete MAEENCTA Where KOEN = '" & _CodEntidad & "'" & vbCrLf
                End If

                If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Entidades") Then
                    Consulta_sql += "Delete " & _Global_BaseBk & "Zw_Entidades Where CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _SucEntidad & "'"
                End If

                If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Entidades_ProdExcluidos") Then
                    Consulta_sql += "Delete " & _Global_BaseBk & "Zw_Entidades_ProdExcluidos Where CodEntidad = '" & _CodEntidad & "' And CodSucEntidad = '" & _SucEntidad & "'"
                End If

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                    MessageBoxEx.Show(_Fmr, "Entidad eliminada correctamente",
                                      "Eliminar entidad", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return True
                Else
                    MessageBoxEx.Show(_Fmr, "Entidad no puede ser eliminada" & vbCrLf &
                                    _Sql.Pro_Error, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Else
                MessageBoxEx.Show(_Fmr, "Entidad no puede ser eliminada" & vbCrLf &
                                    "Tiene movimientos asociados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If

    End Function

    Function Fx_Agregar_Permiso_Otorgado_Al_Documento(_Formulario As Form,
                                                      ByRef _TblPermisos As DataTable,
                                                      _CodPermiso As String,
                                                      _Ds_Matriz_Documentos As Ds_Matriz_Documentos,
                                                      _CodEntidad As String,
                                                      _CodSucEntidad As String) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _CodFuncionario_Autoriza As String
        Dim _NomFuncionario_Autoriza As String
        Dim _NroRemota As String = String.Empty
        Dim _Permiso_Presencial As Boolean
        Dim _Row_Usuario_Autoriza As DataRow

        For Each _Fl As DataRow In _TblPermisos.Rows
            If _Fl.Item("CodPermiso") = _CodPermiso Then
                Return True
            End If
        Next

        If Fx_Tiene_Permiso(_Formulario, _CodPermiso,,,, , _CodEntidad, _CodSucEntidad,,,
                                                         _Row_Usuario_Autoriza,,, _Permiso_Presencial, _Ds_Matriz_Documentos, False) Then

            For Each _Fl As DataRow In _TblPermisos.Rows
                If _Fl.Item("CodPermiso") = _CodPermiso Then
                    Return True
                End If
            Next

            If Not IsNothing(_Rows_Info_Remota) Then
                _NroRemota = _Rows_Info_Remota.Item("NroRemota")
            End If

            Dim _DescripcionPermiso = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_Permisos", "DescripcionPermiso", "CodPermiso = '" & _CodPermiso & "'")
            _CodFuncionario_Autoriza = _Row_Usuario_Autoriza.Item("KOFU")
            _NomFuncionario_Autoriza = _Row_Usuario_Autoriza.Item("NOKOFU").ToString.Trim

            Dim NewFila = _TblPermisos.NewRow
            With NewFila

                .Item("CodPermiso") = _CodPermiso
                .Item("DescripcionPermiso") = _DescripcionPermiso
                .Item("Necesita_Permiso") = True
                .Item("Autorizado") = True
                .Item("CodFuncionario_Autoriza") = _CodFuncionario_Autoriza
                .Item("NomFuncionario_Autoriza") = _NomFuncionario_Autoriza
                .Item("NroRemota") = _NroRemota
                .Item("Permiso_Presencial") = _Permiso_Presencial
                .Item("Solicitado_Por_Cadena") = False
                .Item("PermisoIndependiente") = True
                .Item("Solicitar_Permiso_Al_Final") = False

                _TblPermisos.Rows.Add(NewFila)

            End With

            _Rows_Info_Remota = Nothing

            Return True

        End If

    End Function
    Function Fx_Agregar_Permiso_Otorgado_Al_Documento(_Formulario As Form,
                                                      ByRef _TblPermisos As DataTable,
                                                      _CodPermiso As String,
                                                      _Ds_Matriz_Documentos As Ds_Matriz_Documentos,
                                                      _CodEntidad As String,
                                                      _CodSucEntidad As String,
                                                      _Descripcion_Permiso As String) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _CodFuncionario_Autoriza As String
        Dim _NomFuncionario_Autoriza As String
        Dim _NroRemota As String = String.Empty
        Dim _Permiso_Presencial As Boolean
        Dim _Row_Usuario_Autoriza As DataRow

        If Fx_Tiene_Permiso(_Formulario, _CodPermiso,,,, _Descripcion_Permiso, _CodEntidad, _CodSucEntidad,,, _Row_Usuario_Autoriza,,, _Permiso_Presencial, _Ds_Matriz_Documentos, False) Then

            For Each _Fl As DataRow In _TblPermisos.Rows
                If _Fl.Item("CodPermiso") = _CodPermiso Then
                    Return True
                End If
            Next

            If Not IsNothing(_Rows_Info_Remota) Then
                _NroRemota = _Rows_Info_Remota.Item("NroRemota")
            End If

            Dim _DescripcionPermiso = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_Permisos", "DescripcionPermiso", "CodPermiso = '" & _CodPermiso & "'")
            _CodFuncionario_Autoriza = _Row_Usuario_Autoriza.Item("KOFU")
            _NomFuncionario_Autoriza = _Row_Usuario_Autoriza.Item("NOKOFU").ToString.Trim

            Dim NewFila = _TblPermisos.NewRow
            With NewFila

                .Item("CodPermiso") = _CodPermiso
                .Item("DescripcionPermiso") = _DescripcionPermiso
                .Item("Necesita_Permiso") = True
                .Item("Autorizado") = True
                .Item("CodFuncionario_Autoriza") = _CodFuncionario_Autoriza
                .Item("NomFuncionario_Autoriza") = _NomFuncionario_Autoriza
                .Item("NroRemota") = _NroRemota
                .Item("Permiso_Presencial") = _Permiso_Presencial
                .Item("Solicitado_Por_Cadena") = False
                .Item("PermisoIndependiente") = True
                .Item("Solicitar_Permiso_Al_Final") = False

                _TblPermisos.Rows.Add(NewFila)

            End With

            _Rows_Info_Remota = Nothing

            Return True

        End If

    End Function
    Function Fx_Agregar_Permiso_Otorgado_Al_Documento(_Formulario As Form,
                                                      ByRef _TblPermisos As DataTable,
                                                      _CodPermiso As String,
                                                      _Ds_Matriz_Documentos As Ds_Matriz_Documentos) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _CodFuncionario_Autoriza As String
        Dim _NomFuncionario_Autoriza As String
        Dim _NroRemota As String = String.Empty
        Dim _Permiso_Presencial As Boolean
        Dim _Row_Usuario_Autoriza As DataRow

        If Fx_Tiene_Permiso(_Formulario, _CodPermiso,,,, , , ,,, _Row_Usuario_Autoriza,,, _Permiso_Presencial, _Ds_Matriz_Documentos, False) Then

            For Each _Fl As DataRow In _TblPermisos.Rows
                If _Fl.Item("CodPermiso") = _CodPermiso Then
                    Return True
                End If
            Next

            If Not IsNothing(_Rows_Info_Remota) Then
                _NroRemota = _Rows_Info_Remota.Item("NroRemota")
            End If

            Dim _DescripcionPermiso = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_Permisos", "DescripcionPermiso", "CodPermiso = '" & _CodPermiso & "'")
            _CodFuncionario_Autoriza = _Row_Usuario_Autoriza.Item("KOFU")
            _NomFuncionario_Autoriza = _Row_Usuario_Autoriza.Item("NOKOFU").ToString.Trim

            Dim NewFila = _TblPermisos.NewRow
            With NewFila

                .Item("CodPermiso") = _CodPermiso
                .Item("DescripcionPermiso") = _DescripcionPermiso
                .Item("Necesita_Permiso") = True
                .Item("Autorizado") = True
                .Item("CodFuncionario_Autoriza") = _CodFuncionario_Autoriza
                .Item("NomFuncionario_Autoriza") = _NomFuncionario_Autoriza
                .Item("NroRemota") = _NroRemota
                .Item("Permiso_Presencial") = _Permiso_Presencial
                .Item("Solicitado_Por_Cadena") = False
                .Item("PermisoIndependiente") = True
                .Item("Solicitar_Permiso_Al_Final") = False

                _TblPermisos.Rows.Add(NewFila)

            End With

            _Rows_Info_Remota = Nothing

            Return True

        End If

    End Function
    Function Fx_Agregar_Permiso_Otorgado_Al_Documento(_Formulario As Form,
                                                      ByRef _TblPermisos As DataTable,
                                                      _CodPermiso As String,
                                                      _Ds_Matriz_Documentos As Ds_Matriz_Documentos,
                                                      _CodEntidad As String,
                                                      _CodSucEntidad As String,
                                                      ByRef _Solicitar_Permiso_Al_Final As Boolean) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _CodFuncionario_Autoriza As String
        Dim _NomFuncionario_Autoriza As String
        Dim _NroRemota As String = String.Empty
        Dim _Permiso_Presencial As Boolean
        Dim _Row_Usuario_Autoriza As DataRow

        For Each _Fl As DataRow In _TblPermisos.Rows
            If _Fl.Item("CodPermiso") = _CodPermiso Then
                Return True
            End If
        Next

        Dim _Tiene_Permiso As Boolean

        _Tiene_Permiso = Fx_Tiene_Permiso(_Formulario, _CodPermiso,,,, , _CodEntidad, _CodSucEntidad,,,
                                          _Row_Usuario_Autoriza,,, _Permiso_Presencial, _Ds_Matriz_Documentos,
                                          False, _Solicitar_Permiso_Al_Final)

        If Not _Tiene_Permiso Then
            If _Solicitar_Permiso_Al_Final Then
                Fx_Incorporar_Permiso_Al_Documento(_TblPermisos, _CodPermiso, True, False, "", "", "", False, True, True)
                Return True
            End If
        End If

        If _Tiene_Permiso Then

            For Each _Fl As DataRow In _TblPermisos.Rows
                If _Fl.Item("CodPermiso") = _CodPermiso Then
                    Return True
                End If
            Next

            If Not IsNothing(_Rows_Info_Remota) Then
                _NroRemota = _Rows_Info_Remota.Item("NroRemota")
            End If

            _CodFuncionario_Autoriza = _Row_Usuario_Autoriza.Item("KOFU")
            _NomFuncionario_Autoriza = _Row_Usuario_Autoriza.Item("NOKOFU").ToString.Trim

            Fx_Incorporar_Permiso_Al_Documento(_TblPermisos, _CodPermiso, True, True, _CodFuncionario_Autoriza, _NomFuncionario_Autoriza,
                                               _NroRemota, _Permiso_Presencial, True, False)

            _Rows_Info_Remota = Nothing

            Return True

        End If

    End Function

    Function Fx_Incorporar_Permiso_Al_Documento(ByRef _Tbl_Permisos_Doc As DataTable,
                                                _CodPermiso As String,
                                                _Necesita_Permiso As Boolean,
                                                _Autorizado As Boolean,
                                                _CodFuncionario_Autoriza As String,
                                                _NomFuncionario_Autoriza As String,
                                                _NroRemota As String,
                                                _Permiso_Presencial As Boolean,
                                                _PermisoIndependiente As Boolean,
                                                _Solicitar_Permiso_Al_Final As Boolean) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Try

            Dim _DescripcionPermiso = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_Permisos", "DescripcionPermiso", "CodPermiso = '" & _CodPermiso & "'")


            Dim NewFila = _Tbl_Permisos_Doc.NewRow
            With NewFila

                .Item("CodPermiso") = _CodPermiso
                .Item("DescripcionPermiso") = _DescripcionPermiso
                .Item("Necesita_Permiso") = _Necesita_Permiso
                .Item("Autorizado") = _Autorizado
                .Item("CodFuncionario_Autoriza") = _CodFuncionario_Autoriza
                .Item("NomFuncionario_Autoriza") = _NomFuncionario_Autoriza
                .Item("NroRemota") = _NroRemota
                .Item("Permiso_Presencial") = _Permiso_Presencial
                .Item("Solicitado_Por_Cadena") = False
                .Item("PermisoIndependiente") = _PermisoIndependiente
                .Item("Solicitar_Permiso_Al_Final") = _Solicitar_Permiso_Al_Final

                _Tbl_Permisos_Doc.Rows.Add(NewFila)

                Return True

            End With

        Catch ex As Exception

        End Try

    End Function

    Sub Sb_Reestablecer_Stock_En_Zw_Prod_Stock(_Tido As String, _TblDetalle As DataTable)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _SqlQuery As String

        Dim _CampoUd1, _CampoUd2 As String

        If _Tido = "NVV" Then
            _CampoUd1 = "StComp1" : _CampoUd2 = "StComp2"
        ElseIf _Tido = "OCC" Then
            _CampoUd1 = "StPedi1" : _CampoUd2 = "StPedi2"
        End If

        For Each _Fila As DataRow In _TblDetalle.Rows

            Dim _CantUd1 As String = De_Num_a_Tx_01(_Fila.Item("CantUd1"), True, 5)
            Dim _CantUd2 As String = De_Num_a_Tx_01(_Fila.Item("CantUd2"), True, 5)

            Dim _Empresa As String = _Fila.Item("Empresa")
            Dim _Sucursal As String = _Fila.Item("Sucursal")
            Dim _Bodega As String = _Fila.Item("Bodega")
            Dim _Codigo As String = _Fila.Item("Codigo")

            _SqlQuery += "Update " & _Global_BaseBk & "Zw_Prod_Stock Set" & vbCrLf &
                            _CampoUd1 & " = " & _CampoUd1 & " - " & _CantUd1 & "," &
                            _CampoUd2 & " = " & _CampoUd2 & " - " & _CantUd2 & vbCrLf &
                             "Where Empresa ='" & _Empresa & "' And Sucursal ='" & _Sucursal & "' And Bodega ='" & _Bodega &
                             "' And Codigo = '" & _Codigo & "'" & vbCrLf

        Next

        If Not String.IsNullOrEmpty(_SqlQuery) Then
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery)
        End If

    End Sub

    Function Fx_Insertar_Permiso_en_Tabla_Permisos(_TblPermisos As DataTable, _CodPermiso As String, _Row_Usuario_Autoriza As DataRow, _Permiso_Presencial As Boolean)

        Dim _NroRemota As String
        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _DescripcionPermiso = _Sql.Fx_Trae_Dato(_Global_BaseBk & "ZW_Permisos", "DescripcionPermiso", "CodPermiso = '" & _CodPermiso & "'")
        Dim _CodFuncionario_Autoriza = _Row_Usuario_Autoriza.Item("KOFU")
        Dim _NomFuncionario_Autoriza = _Row_Usuario_Autoriza.Item("NOKOFU").ToString.Trim

        For Each _Fl As DataRow In _TblPermisos.Rows
            If _Fl.Item("CodPermiso") = _CodPermiso Then

                If _CodPermiso = "Bkp00033" Then
                    _Fl.Item("DescripcionPermiso") = _DescripcionPermiso
                    _Fl.Item("CodFuncionario_Autoriza") = _CodFuncionario_Autoriza
                    _Fl.Item("NomFuncionario_Autoriza") = _NomFuncionario_Autoriza
                    _Fl.Item("Permiso_Presencial") = _Permiso_Presencial
                    _Fl.Item("Solicitado_Por_Cadena") = False
                    _Fl.Item("Necesita_Permiso") = True
                    _Fl.Item("Autorizado") = True
                End If

                Return True
            End If
        Next

        If Not IsNothing(_Rows_Info_Remota) Then
            _NroRemota = _Rows_Info_Remota.Item("NroRemota")
        End If

        Dim NewFila = _TblPermisos.NewRow
        With NewFila

            .Item("CodPermiso") = _CodPermiso
            .Item("DescripcionPermiso") = _DescripcionPermiso
            .Item("Necesita_Permiso") = True
            .Item("Autorizado") = True
            .Item("CodFuncionario_Autoriza") = _CodFuncionario_Autoriza
            .Item("NomFuncionario_Autoriza") = _NomFuncionario_Autoriza
            .Item("NroRemota") = _NroRemota
            .Item("Permiso_Presencial") = _Permiso_Presencial
            .Item("Solicitado_Por_Cadena") = False
            .Item("PermisoIndependiente") = True

            _TblPermisos.Rows.Add(NewFila)

        End With

        _Rows_Info_Remota = Nothing

    End Function

    Function Fx_Actualizar_Lista_De_Costos_Random_Desde_Bakapp(_Formulario As Form, _Koen As String, _Suen As String) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_ListaPreCosto_Enc" & vbCrLf &
                       "Where Proveedor = '" & _Koen & "' And Sucursal = '" & _Suen & "' And Vigente = 1"
        Dim _RowListaPreCosto_Enc As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_RowListaPreCosto_Enc) Then

            If MessageBoxEx.Show(_Formulario, "Falta una la lista de costos vigente para el proveedor en BakApp" & vbCrLf & vbCrLf &
                                "¿Desde continuar sin revisar esta situación?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = DialogResult.Yes Then
                If Fx_Tiene_Permiso(_Formulario, "Comp0097") Then
                    Return True
                End If
            End If

            Return False

        End If

        Dim _Id_Padre As Integer = _RowListaPreCosto_Enc.Item("Id")
        Dim _NombreLista As String = _RowListaPreCosto_Enc.Item("NombreLista")
        Dim _Lista As String = _RowListaPreCosto_Enc.Item("Lista")
        Dim _Vigente As Boolean = _RowListaPreCosto_Enc.Item("Vigente")
        Dim _FechaVigenciaDesde As Date = FormatDateTime(_RowListaPreCosto_Enc.Item("FechaVigenciaDesde"), DateFormat.ShortDate)
        Dim _FechaVigenciaHasta As Date = FormatDateTime(_RowListaPreCosto_Enc.Item("FechaVigenciaHasta"), DateFormat.ShortDate)

        Dim _FechaActual As Date = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

        If _FechaActual < _FechaVigenciaDesde Or _FechaActual > _FechaVigenciaHasta Then

            Dim _MsgError As String

            If _FechaActual < _FechaVigenciaDesde Then
                _MsgError = "La <fecha desde> de la lista vigente es mayor a la fecha:" & _FechaActual
            End If

            If _FechaActual > _FechaVigenciaHasta Then
                _MsgError = "La lista de costos vigente para el proveedor esta caducada."
            End If

            If MessageBoxEx.Show(_Formulario, _MsgError & vbCrLf & vbCrLf &
                                "Lista de costos:  " & _NombreLista.Trim & vbCrLf &
                                "Fecha vigencia desde :" & _FechaVigenciaDesde & " hasta: " & _FechaVigenciaHasta & vbCrLf & vbCrLf &
                                "¿Desde continuar sin revisar esta situación?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = DialogResult.Yes Then
                If Fx_Tiene_Permiso(_Formulario, "Comp0098") Then
                    Return True
                End If
            End If

            Return False

        End If

        Dim _ErrorLPC As String = Fx_ActualizarListaRandomDesdeBakApp(_Koen, _Suen, _Id_Padre)

        If String.IsNullOrEmpty(_ErrorLPC) Then
            MessageBoxEx.Show(_Formulario, "Costos levantados correctamente en lista " & _Lista, "Actualización de costos del proveedor",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBoxEx.Show(_Formulario, _ErrorLPC, "Error al cargar lista de proveedor" & vbCrLf &
                              "Los costos seguiran siendo los de la lista actual", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Return True

    End Function

    Private Function Fx_ActualizarListaRandomDesdeBakApp(_CodProveedor As String, _SucProveedor As String, _Id_Padre As Integer) As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _Error As String = String.Empty

        Try
            Consulta_sql = "Select Id, Tabla_Random, Campo_Random, Tabla_Bakapp, Campo_Bakapp
                        From " & _Global_BaseBk & "Zw_Tablas_Equivalentes_Rd_Bk
                        Where Tabla_Bakapp = 'Zw_ListaPreCosto'"
            Dim _Tbl_Equivalentes As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            Dim _Sql_Equivalentes As String

            For Each _Fila As DataRow In _Tbl_Equivalentes.Rows

                Dim _Campo_Rd As String = _Fila.Item("Campo_Random")
                Dim _Campo_Bk As String = _Fila.Item("Campo_Bakapp")

                _Sql_Equivalentes += "," & _Campo_Rd & " = " & _Campo_Bk

            Next

            Consulta_sql = "Insert Into TABRECPR (KOPR,RECARGO,KOEN,ECUARECAR)" & vbCrLf &
                           "Select Codigo,Flete,Proveedor,'' From " & _Global_BaseBk & "Zw_ListaPreCosto" &
                           vbCrLf &
                           "Where Codigo Not In (Select KOPR From TABRECPR Where KOEN = '" & _CodProveedor & "') And Flete > 0 And Id_Padre = " & _Id_Padre &
                           vbCrLf &
                           vbCrLf &
                           "--Update TABRECPR Set RECARGO = Flete" & vbCrLf &
                           "--From " & _Global_BaseBk & "Zw_ListaPreCosto Tbp" & vbCrLf &
                           "--Inner Join TABRECPR On KOEN = Tbp.Proveedor And KOPR = Tbp.Codigo And No_Usar = 0" &
                           "--Where Id_Padre = " & _Id_Padre &
                           vbCrLf &
                           vbCrLf &
                           "Update TABPRE Set PP01UD = CostoUd1,PP02UD = CostoUd2" & _Sql_Equivalentes & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_ListaPreCosto Tbp " & vbCrLf &
                           "Inner Join TABPRE On KOLT = Tbp.Lista And KOPR = Tbp.Codigo And No_Usar = 0" & vbCrLf &
                           "Where Id_Padre = " & _Id_Padre

            If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If
        Catch ex As Exception
            _Error = ex.Message
        End Try

        Return _Error

    End Function

    Sub Sb_Firmar_Documento_Electronico(_Formulario As Form, _Idmaeedo As Integer, _Tido As String)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)

        Dim _Firma_Bakapp As Boolean = Fx_Firmar_X_Bakapp(_Idmaeedo)
        Dim _Firma_RunMonitor As Boolean = Not _Firma_Bakapp

        'Try
        '    If _Global_Row_Configuracion_General.Item("FacElec_Bakapp_Hefesto") Then
        '        Dim _TimbrarXRandom As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad",
        '                                           "TimbrarXRandom",
        '                                           "Modalidad = '" & Modalidad & "' And TipoDoc = '" & _Tido & "'")
        '        _Firma_Bakapp = Not _TimbrarXRandom
        '        _Firma_RunMonitor = True
        '    End If
        'Catch ex As Exception
        '    _Firma_RunMonitor = True
        'End Try

        If _Firma_RunMonitor Then

            Dim _Iddt As Integer = _Class_DTE.Fx_Dte_Genera_Documento(_Formulario, False)
            If CBool(_Iddt) Then
                _Class_DTE.Fx_Dte_Firma(_Formulario, _Iddt, False)
            End If

        End If

        If _Firma_Bakapp Then

            Dim _Icono As Image = My.Resources.Recursos_DTE.script_edit
            _Formulario.Cursor = Cursors.WaitCursor

            Try
                'Lbl_Version.Text = "Versión: " & _Global_Version_BakApp & "... Firmando documento electrónico DTE"
                _Formulario.Refresh()
                If CBool(_Class_DTE.Fx_FirmarXHefesto()) Then
                    ToastNotification.Show(_Formulario, "FIRMADO...", _Icono, 3 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                End If
            Catch ex As Exception
            Finally
                _Formulario.Enabled = True
                Application.DoEvents()
                _Formulario.Cursor = Cursors.Default
            End Try

        End If

    End Sub

    Function Fx_Firmar_X_Bakapp(_Idmaeedo As Integer) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Tido As String = _Sql.Fx_Trae_Dato("MAEEDO", "TIDO", "IDMAEEDO = " & _Idmaeedo)

        Try
            If _Global_Row_Configuracion_General.Item("FacElec_Bakapp_Hefesto") Then
                Dim _TimbrarXRandom As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad",
                                                   "TimbrarXRandom",
                                                   "Modalidad = '" & Modalidad & "' And TipoDoc = '" & _Tido & "'")
                If _TimbrarXRandom Then
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    Function Fx_Firmar_X_Bakapp2(_Tido As String) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Try
            If _Global_Row_Configuracion_General.Item("FacElec_Bakapp_Hefesto") Then
                Dim _TimbrarXRandom As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad",
                                                   "TimbrarXRandom",
                                                   "Modalidad = '" & Modalidad & "' And TipoDoc = '" & _Tido & "'",, False)
                If _TimbrarXRandom Then
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    Function Fx_Firmar_X_Bakapp3(_Td As Integer) As Boolean

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Tido As String = Fx_Tipo_TIDO_VS_DTE(_Td)

        Try
            If _Global_Row_Configuracion_General.Item("FacElec_Bakapp_Hefesto") Then
                Dim _TimbrarXRandom As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad",
                                                   "TimbrarXRandom",
                                                   "Modalidad = '" & Modalidad & "' And TipoDoc = '" & _Tido & "'")
                If _TimbrarXRandom Then
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    Function Fx_Caracter_Raro_Quitar(ByRef _Texto As String)

        _Texto = Replace(_Texto, "&", "&amp;")
        _Texto = Replace(_Texto, "<", "&lt;")
        _Texto = Replace(_Texto, ">", "&gt;")
        _Texto = Replace(_Texto, "'", "&apos;")
        _Texto = Replace(_Texto, """", "&quot;")
        _Texto = Replace(_Texto, "´", "")
        _Texto = Replace(_Texto, "°", "")
        _Texto = Replace(_Texto, "º", "")
        _Texto = Replace(_Texto, "ñ", "n")
        _Texto = Replace(_Texto, "Ñ", "N")

        _Texto = Replace(_Texto, "á", "a")
        _Texto = Replace(_Texto, "é", "e")
        _Texto = Replace(_Texto, "í", "i")
        _Texto = Replace(_Texto, "ó", "o")
        _Texto = Replace(_Texto, "ú", "u")

        _Texto = Replace(_Texto, "Á", "A")
        _Texto = Replace(_Texto, "É", "E")
        _Texto = Replace(_Texto, "Í", "I")
        _Texto = Replace(_Texto, "Ó", "O")
        _Texto = Replace(_Texto, "Ú", "U")

        _Texto = Replace(_Texto, "ü", "u")
        _Texto = Replace(_Texto, "Ü", "U")

        _Texto = Replace(_Texto, vbCrLf, "")
        _Texto = Replace(_Texto, " ", "")
        _Texto = Replace(_Texto, "ª", "")

        If Not String.IsNullOrEmpty(_Texto) Then
            For i = 1 To _Texto.Length
                Dim Letra As String = Mid(_Texto, i, 1)
                Dim codeInt = Asc(Letra)
                If (codeInt >= 0 And codeInt <= 31) Or (codeInt >= 127 And codeInt <= 255) Then
                    _Texto = Replace(_Texto, Letra, " ")
                End If
            Next
        End If

        If IsNothing(_Texto) Then
            _Texto = String.Empty
        End If

        _Texto = _Texto.Trim

    End Function

    Function Fx_TblFromJson(Respuesta As String, Objeto As String) As DataTable

        Dim result As Object
        result = JsonConvert.DeserializeObject(Of Object)(Respuesta)

        Dim _Json = "{'" & Objeto & "':" & result(Objeto).ToString & "}"

        Dim dataSet As DataSet

        dataSet = JsonConvert.DeserializeObject(Of DataSet)(_Json)

        Dim _Tbl As DataTable = dataSet.Tables(0)

        Return _Tbl

    End Function

    Sub Sb_EjecConsultaBasesExternas(_Formulario As Form, _SqlQuery As String, _Mostrar_Mensaje As Boolean)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion Where SincroProductos = 1"
        Dim _Tbl_Conexiones As DataTable = _Sql.Fx_Get_DataTable(_Consulta_sql)

        If _Tbl_Conexiones.Rows.Count Then

            Dim _Cl_ConexionExterna As New Cl_ConexionExterna
            Dim _Conexion As New ConexionExternas

            For Each _FilaCx As DataRow In _Tbl_Conexiones.Rows

                Dim _Id_Conexion As Integer = _FilaCx.Item("Id")
                _Conexion = _Cl_ConexionExterna.Fx_CadenaConexionServExt(_Id_Conexion)

                If _Conexion.EsCorrecto Then

                    _SqlQuery = Replace(_SqlQuery, _Global_BaseBk, _Conexion.Global_BaseBk)

                    Dim _Sql2 As New Class_SQL(_Conexion.Cadena_ConexionSQL_Server_Ext)

                    If _Sql2.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery) Then
                        If _Mostrar_Mensaje Then
                            MessageBoxEx.Show(_Formulario, "Datos actualizado en la base de datos externa" & vbCrLf & vbCrLf &
                                          "Base de dato: " & _FilaCx.Item("BaseDeDatos"), "Sincronización base externa",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        If _Mostrar_Mensaje Then
                            MessageBoxEx.Show(_Formulario, "Error al actualizar la base de datos externa" & vbCrLf & vbCrLf &
                                          "Base de dato: " & _FilaCx.Item("BaseDeDatos") & vbCrLf &
                                          _Sql2.Pro_Error, "Sincronización base externa",
                                          MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    End If

                End If

            Next

        End If

    End Sub

    Function Fx_Confirmar_Lectura(_Mensaje1 As String, _Mensaje2 As String, _eTaskDialogIcon As eTaskDialogIcon) As Boolean

        Dim Chk_Confirmar_Lectura As New Command
        Chk_Confirmar_Lectura.Checked = False
        Chk_Confirmar_Lectura.Name = "Chk_Confirmar_Lectura"
        Chk_Confirmar_Lectura.Text = "CONFIRMAR TIPO DE ENVIO Y LECTURA DE LA ALERTA"

        Dim _Opciones As Command = Chk_Confirmar_Lectura

        Dim _Info As New TaskDialogInfo("Alerta",
                  _eTaskDialogIcon,
                  _Mensaje1, _Mensaje2,
                  eTaskDialogButton.Yes + eTaskDialogButton.No, eTaskDialogBackgroundColor.Red, Nothing, Nothing,
                  _Opciones, Nothing, Nothing)

        Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

        If _Resultado = eTaskDialogResult.Yes Then

            If Chk_Confirmar_Lectura.Checked Then
                Return True
            Else
                Return Fx_Confirmar_Lectura(_Mensaje1, _Mensaje2, _eTaskDialogIcon)
            End If

        Else
            Return False
        End If

    End Function

    Function Fx_Vaidar_Fincred(_Idmaeedo As Integer,
                               _Tido As String,
                               _Nudo As String,
                               _vRut_girador As String,
                               _vMonto_total_venta As Double,
                               _vFec_primer_venc As Date,
                               _vNum_telefono As String) As Fincred_API.Respuesta

        Dim _Respuesta As New Fincred_API.Respuesta

        '_Row_Encabezado_Doc = _TblEncabezado.Rows(0)

        Dim _Rut_girador As String = _vRut_girador '_RowEntidad.Item("Rut")

        _Rut_girador = Replace(_Rut_girador, "-", "")
        _Rut_girador = Replace(_Rut_girador, ".", "")

        Dim Generator As System.Random = New System.Random()

        Dim _Rut_comprador As String
        Dim _Numero_transaccion_cliente As Integer = Generator.Next(10000, 99999)
        Dim _Numero_documento_transaccion As String = "XXXXXXXXX"
        Dim _Producto As Cl_Fincred_Bakapp.Cl_Fincred_SQL.Producto = Cl_Fincred_Bakapp.Cl_Fincred_SQL.Producto.Facturas
        Dim _Banco As Integer = 0
        Dim _Monto_total_venta As Double = _vMonto_total_venta '_Row_Encabezado_Doc.Item("TotalBrutoDoc")
        Dim _Cantidad_documentos_venta As Integer = 1
        Dim _Num_primer_doc As Integer = _Numero_transaccion_cliente
        Dim _Fec_primer_venc As String = Format(_vFec_primer_venc, "ddMMyyyy")
        Dim _Num_telefono As String = _vNum_telefono '_RowEntidad.Item("FOEN").ToString.Trim

        Dim _ProductoV = _Producto + 1

        '_Rut_girador = "118549252" ' APROBACION DE PRUEBAS
        '_Rut_girador = "094005051" ' NEGACION DE PRUEBAS

        _Rut_comprador = _Rut_girador

        Dim _Fincred_Id_Token = _Global_Row_Configuracion_Estacion.Item("Fincred_Id_Token")

        Dim _Fincred As New Cl_Fincred_Bakapp.Cl_Fincred_SQL(_Fincred_Id_Token)
        _Fincred.Fx_Generar_Consulta(_Rut_girador,
                                     _Rut_comprador,
                                     _Numero_transaccion_cliente,
                                     _Numero_documento_transaccion,
                                     _ProductoV,
                                     _Banco,
                                     _Monto_total_venta,
                                     _Cantidad_documentos_venta,
                                     _Num_primer_doc,
                                     _Fec_primer_venc,
                                     _Num_telefono,
                                     _Idmaeedo,
                                     _Tido,
                                     _Nudo)

        Return _Fincred.Respuesta

    End Function

    Sub Sb_Confirmar_Lectura(_Mensaje1 As String,
                             _Mensaje2 As String,
                             _TaskDialogIcon As eTaskDialogIcon,
                             _FooterText As String)

        Dim Chk_Confirmar_Lectura As New Command
        Chk_Confirmar_Lectura.Checked = False
        Chk_Confirmar_Lectura.Name = "Chk_Confirmar_Lectura"
        Chk_Confirmar_Lectura.Text = "CONFIRMAR LECTURA DE LA ALERTA"

        Dim _Opciones As Command = Chk_Confirmar_Lectura
        Dim _ImagenFoot As Image

        If String.IsNullOrWhiteSpace(_FooterText) Then
            _FooterText = Nothing
        Else
            Dim iconoAlerta As Icon = SystemIcons.Warning
            _ImagenFoot = iconoAlerta.ToBitmap()

            ' Cambiar el tamaño del icono a 64x64 píxeles (puedes ajustar el tamaño según tus necesidades)
            Dim nuevoTamaño As New Size(16, 16)
            Dim iconoRedimensionado As Image = _ImagenFoot.GetThumbnailImage(nuevoTamaño.Width, nuevoTamaño.Height, Nothing, IntPtr.Zero)

            _ImagenFoot = iconoRedimensionado
        End If

        Do While Not Chk_Confirmar_Lectura.Checked

            Dim _Info As New TaskDialogInfo("Alerta",
                  _TaskDialogIcon,
                  _Mensaje1, _Mensaje2,
                  eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red, Nothing, Nothing,
                  _Opciones, _FooterText, _ImagenFoot, True)

            Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

        Loop

    End Sub

    Public Function Fx_CalcularRTUVariable(_Kilosdisponibles As Double, _Cajasdisponibles As Double, _Cajamasalta As Double) As Double

        Dim _Rtu As Double
        Dim _Promedio As Double = _Kilosdisponibles / _Cajasdisponibles

        _Rtu = (_Promedio + _Cajamasalta) / 2
        _Rtu = Math.Ceiling(_Rtu)

        Return _Rtu

    End Function

    Public Sub Sb_Revisar_Zw_Productos()

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        If _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Productos") Then

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Productos (Codigo, Descripcion, ExluyeTipoVenta)" & vbCrLf &
                           "Select KOPR,NOKOPR,0 From MAEPR Where KOPR Not In (Select Codigo From " & _Global_BaseBk & "Zw_Productos)" & vbCrLf &
                           "Delete " & _Global_BaseBk & "Zw_Productos Where Codigo Not In (Select KOPR From MAEPR)"
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        End If

    End Sub

End Module

