
Imports System.ComponentModel.DataAnnotations
Imports NUnrar

Public Class Cl_Cerrar_Documentos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Id_Padre As Integer = _Global_Row_EstacionBk.Item("Id")
    Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

#Region "PROPIEDADES"

    Public Property Ejecutar As Boolean
    Public Property COVCerrar As Boolean
    Public Property OCICerrar As Boolean
    Public Property OCCCerrar As Boolean
    Public Property NVVCerrar As Boolean
    Public Property NVV_FEmision As Boolean
    Public Property NVV_FDespacho As Boolean
    Public Property NVV_Id_ConfCorreo As Integer
    Public Property NVV_Nombre_ConfCorreo As String
    Public Property NVICerrar As Boolean
    Public Property DiasCOV As Integer
    Public Property DiasOCI As Integer
    Public Property DiasOCC As Integer
    Public Property DiasNVI As Integer
    Public Property DiasNVV As Integer
    Public Property Fecha_Revision As DateTime
    Public Property Procesando As Boolean
    Public Property Log_Registro As String

    'Public Property Zw_Demonio_Conf_Cerrar_Documentos As New Zw_Demonio_Conf_Cerrar_Documentos
    Public Property LS_Zw_Demonio_Conf_Cerrar_Documentos As New List(Of Zw_Demonio_Conf_Cerrar_Documentos)

#End Region

    Public Sub New()
        Sb_Llenar_Zw_Conf_Cerrar_Documentos()
    End Sub

    Sub Sb_Procedimientos_Cierre_Masivo_Documentos(_Formulario As Form, _Tido As String)

        Dim _Dias As Integer
        Dim _Ejecutar As Boolean

        Select Case _Tido
            Case "COV"
                _Dias = DiasCOV : _Ejecutar = COVCerrar
            Case "OCI"
                _Dias = DiasOCI : _Ejecutar = OCICerrar
            Case "OCC"
                _Dias = DiasOCC : _Ejecutar = OCCCerrar
            Case "NVI"
                _Dias = DiasNVI : _Ejecutar = NVICerrar
            Case "NVV"
                _Dias = DiasNVV : _Ejecutar = NVVCerrar
            Case Else
                Return
        End Select

        If Not _Ejecutar Then
            Return
        End If

        Dim _Fecha As Date = Fecha_Revision

        _Fecha = DateAdd(DateInterval.Day, -_Dias, _Fecha)

        Consulta_Sql = My.Resources.Recursos_Demonio.SQLQuery_Cierrer_Docmuento
        Consulta_Sql = Replace(Consulta_Sql, "#Filtro#",
                       "Edo.EMPRESA = '" & Mod_Empresa & "' And Edo.TIDO = '" & _Tido & "' And Edo.ESDO = '' And Edo.FEEMDO <= '" & Format(_Fecha, "yyyyMMdd") & "'")
        Consulta_Sql = Replace(Consulta_Sql, "#Campo_SUENDOFI#", "")
        Consulta_Sql = Replace(Consulta_Sql, "#Left_Join_MAEEN_ENDOFI_SUENDOFI#", "")
        Consulta_Sql = Replace(Consulta_Sql, "Isnull(Mae2.NOKOEN,'') As RAZON_FISICA,", "")
        Consulta_Sql = Replace(Consulta_Sql, "#Orden#", "")
        Consulta_Sql = Replace(Consulta_Sql, "#CantidadDoc#", "100")
        Consulta_Sql = Replace(Consulta_Sql, "Cast(0 As Bit) As Chk,", "Cast(1 As Bit) As Chk,")

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql, False)

        If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
            Log_Registro += _Sql.Pro_Error & vbCrLf
        End If

        If _Tbl.Rows.Count Then

            Dim Fm As New Frm_BuscarDocumento_Mt
            Fm.Ocultar_Envio_Correos_Masivamente = True
            Fm.Lbl_Ver.Text = False
            Fm.BtnAceptar.Visible = True
            Fm.Pro_Sql_Query = Consulta_Sql
            Fm.CmbCantFilas.Text = 100
            Fm.Pro_Pago_a_Documento = False
            Fm.Pro_Abrir_Seleccionado = False
            Fm.Seleccion_Multiple = True
            Fm.Abrir_Cerrar_Documentos_Compromiso = True
            Fm.Abrir_Documentos = False
            Fm.Cerrar_Documentos = True
            Fm.Cerrar_Documentos_Automaticamente = True
            Fm.Bar1.Enabled = False
            Fm.ShowDialog(_Formulario)
            Fm.Dispose()

        End If

    End Sub

    Sub Sb_Procedimientos_Cierre_Masivo_Documentos_New(_Formulario As Form, _Tido As String)

        Log_Registro = String.Empty

        Dim _Zw_Demonio_Conf_Cerrar_Documentos As New Zw_Demonio_Conf_Cerrar_Documentos

        _Zw_Demonio_Conf_Cerrar_Documentos = Fx_Llenar_Zw_Conf_Cerrar_Documentos(_Id_Padre, _NombreEquipo, _Tido)

        If Not _Zw_Demonio_Conf_Cerrar_Documentos.Ejecutar Then
            Return
        End If

        Dim _Dias As Integer = _Zw_Demonio_Conf_Cerrar_Documentos.Dias
        Dim _Fecha As Date

        Dim _TdFecha As String = String.Empty
        _Fecha = DateAdd(DateInterval.Day, -_Dias, Fecha_Revision)

        If _Zw_Demonio_Conf_Cerrar_Documentos.FEmision Then
            _TdFecha = " And Edo.FEEMDO <= '" & Format(_Fecha, "yyyyMMdd") & "'"
        ElseIf _Zw_Demonio_Conf_Cerrar_Documentos.FDespacho Then
            _TdFecha = " And Edo.FEER <= '" & Format(_Fecha, "yyyyMMdd") & "'"
        End If

        _Fecha = DateAdd(DateInterval.Day, -_Dias, _Fecha)

        Consulta_Sql = My.Resources.Recursos_Demonio.SQLQuery_Cierrer_Docmuento
        Consulta_Sql = Replace(Consulta_Sql, "#Filtro#",
                       "Edo.EMPRESA = '" & Mod_Empresa & "' And Edo.TIDO = '" & _Tido & "' And Edo.ESDO = ''" & _TdFecha)
        Consulta_Sql = Replace(Consulta_Sql, "#Campo_SUENDOFI#", "")
        Consulta_Sql = Replace(Consulta_Sql, "#Left_Join_MAEEN_ENDOFI_SUENDOFI#", "")
        Consulta_Sql = Replace(Consulta_Sql, "Isnull(Mae2.NOKOEN,'') As RAZON_FISICA,", "")
        Consulta_Sql = Replace(Consulta_Sql, "#Orden#", "")
        Consulta_Sql = Replace(Consulta_Sql, "#CantidadDoc#", "200")
        Consulta_Sql = Replace(Consulta_Sql, "Cast(0 As Bit) As Chk,", "Cast(1 As Bit) As Chk,")

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql, False)

        If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
            Log_Registro += _Sql.Pro_Error & vbCrLf
        Else
            If CBool(_Tbl.Rows.Count) Then
                Dim _NombreTido As String = _Sql.Fx_Trae_Dato("TABTIDO", "NOTIDO", "TIDO = '" & _Tido & "'",, False)
                Log_Registro += vbCrLf & "Cerrando " & _Tbl.Rows.Count & " documentos " & _NombreTido.Trim & vbCrLf
            End If
        End If

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Idmaeedo As Integer = _Fila.Item("IDMAEEDO")
            Dim Cerrar_Doc As New Clas_Cerrar_Documento

            Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Stmp_Enc Where Idmaeedo = " & _Idmaeedo & " And Estado Not In ('NULO','NULA','CERRA')"
            Dim _Row_Stmp_Enc As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql, False)

            Consulta_Sql = Replace(My.Resources.Recursos_Ver_Documento.Traer_Documento_Random, "#Idmaeedo#", _Idmaeedo)

            Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql, True, False)

            If IsNothing(_Ds) Then
                Log_Registro += "No se pudo obtener el documento " & _Idmaeedo & vbCrLf
                Continue For
            End If

            Dim _Row_Maeedo = _Ds.Tables(0).Rows(0)
            Dim _Tbl_Maeddo = _Ds.Tables(1)

            If Cerrar_Doc.Fx_Cerrar_Documento(_Idmaeedo, _Tbl_Maeddo) Then

                Fx_Add_Log_Gestion("XXX", Mod_Modalidad, "MAEEDO", _Idmaeedo, "", "CIERRE Y REACTIVACIÓN DE DOCUMENTOS DE COMPROMISO", "Doc00011", "", "", "", False, "XXX")

                If Not IsNothing(_Row_Stmp_Enc) Then

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set " &
                                   "Estado = 'NULA'," &
                                   "Idmaeedo = 0," &
                                   "Observacion = 'Cerrado automáticamente mediante el proceso de cierre masivo del sistema ""Diablito"".'" & vbCrLf &
                                   "Where Id = " & _Row_Stmp_Enc.Item("Id") & vbCrLf &
                                   "Update " & _Global_BaseBk & "Zw_Stmp_Det Set Idmaeedo = 0,Idmaeddo = 0 Where Id_Enc = " & _Row_Stmp_Enc.Item("Id") & vbCrLf &
                                   "Update " & _Global_BaseBk & "Zw_Stmp_DetPick Set Idmaeedo = 0,Idmaeddo = 0 Where Id_Enc = " & _Row_Stmp_Enc.Item("Id")
                    If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                        Log_Registro += _Sql.Pro_Error & vbCrLf
                    End If

                End If

                Dim _HoraGrab = Hora_Grab_fx(False)

                Consulta_Sql = "Insert Into MEVENTO (ARCHIRVE,IDRVE,ARCHIRSE,IDRSE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC," &
                               "FECHAREF,HORAGRAB) Values " & vbCrLf &
                               "('MAEEDO'," & _Idmaeedo & ",'',0,'XXX','" & Format(FechaDelServidor, "yyyyMMdd") & "','',''," &
                               "'CERRADO AUTOMÁTICAMENTE MEDIANTE EL PROCESO DE CIERRE MASIVO DEL SISTEMA ""DIABLITO"".',GetDate()," & _HoraGrab & ")"
                If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                    Log_Registro += _Sql.Pro_Error & vbCrLf
                End If

            End If

        Next

    End Sub

    Sub Sb_Procedimientos_Envio_Correos(_Formulario As Form, _Tido As String)

        Log_Registro = String.Empty

        Dim _Zw_Demonio_Conf_Cerrar_Documentos As New Zw_Demonio_Conf_Cerrar_Documentos

        _Zw_Demonio_Conf_Cerrar_Documentos = Fx_Llenar_Zw_Conf_Cerrar_Documentos(_Id_Padre, _NombreEquipo, _Tido)

        If Not _Zw_Demonio_Conf_Cerrar_Documentos.Ejecutar And CBool(_Zw_Demonio_Conf_Cerrar_Documentos.Id_ConfCorreo) Then
            Return
        End If

        Dim _Id_ConfCorreo As Integer = _Zw_Demonio_Conf_Cerrar_Documentos.Id_ConfCorreo
        Dim _Cl_ConfCorreoAviso As New Cl_ConfCorreoAviso

        _Cl_ConfCorreoAviso.Fx_Llenar_ConfCorreo(_Id_ConfCorreo)

        Dim _DiasEnvioAnticipacion As Integer = _Cl_ConfCorreoAviso.Zw_Demonio_Conf_Correo.DiasEnvioAnticipacion
        Dim _Dias As Integer = _Zw_Demonio_Conf_Cerrar_Documentos.Dias
        Dim _Fecha As Date

        Dim _TdFecha As String = String.Empty
        '_Dias = 1

        If _Zw_Demonio_Conf_Cerrar_Documentos.FEmision Then
            _Fecha = DateAdd(DateInterval.Day, -_Dias, Fecha_Revision)
            _TdFecha = " And Edo.FEEMDO <= '" & Format(_Fecha, "yyyyMMdd") & "'"
        ElseIf _Zw_Demonio_Conf_Cerrar_Documentos.FDespacho Then
            _Fecha = Fecha_Revision
            _TdFecha = " And Edo.FEER <= '" & Format(_Fecha, "yyyyMMdd") & "'"
        End If

        _Fecha = DateAdd(DateInterval.Day, -_DiasEnvioAnticipacion, _Fecha)

        Consulta_Sql = My.Resources.Recursos_Demonio.SQLQuery_Cierrer_Docmuento
        Consulta_Sql = Replace(Consulta_Sql, "#Filtro#",
                       "Edo.EMPRESA = '" & Mod_Empresa & "' And Edo.TIDO = '" & _Tido & "' And Edo.ESDO = ''" & _TdFecha)
        Consulta_Sql = Replace(Consulta_Sql, "#Campo_SUENDOFI#", "")
        Consulta_Sql = Replace(Consulta_Sql, "#Left_Join_MAEEN_ENDOFI_SUENDOFI#", "")
        Consulta_Sql = Replace(Consulta_Sql, "Isnull(Mae2.NOKOEN,'') As RAZON_FISICA,", "")
        Consulta_Sql = Replace(Consulta_Sql, "#Orden#", "")
        Consulta_Sql = Replace(Consulta_Sql, "#CantidadDoc#", "200")
        Consulta_Sql = Replace(Consulta_Sql, "Cast(0 As Bit) As Chk,", "Cast(1 As Bit) As Chk,")

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql, False)

        If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
            Log_Registro += _Sql.Pro_Error & vbCrLf
        Else
            If CBool(_Tbl.Rows.Count) Then
                Dim _NombreTido As String = _Sql.Fx_Trae_Dato("TABTIDO", "NOTIDO", "TIDO = '" & _Tido & "'",, False)
                Log_Registro += vbCrLf & "Cerrando " & _Tbl.Rows.Count & " documentos " & _NombreTido.Trim & vbCrLf
            End If
        End If

        Dim _Filtro_Idmaeedo As String = Generar_Filtro_IN(_Tbl, "", "IDMAEEDO", True, False)

        Consulta_Sql = "Select Distinct KOFULIDO,NOKOFU,Tf.EMAIL" & vbCrLf &
                       "From MAEDDO Ddo" & vbCrLf &
                       "Inner Join MAEEDO Edo On Edo.IDMAEEDO = Ddo.IDMAEEDO" & vbCrLf &
                       "Left Join MAEEN Mae1 On Edo.ENDO = Mae1.KOEN And Edo.SUENDO = Mae1.SUEN " & vbCrLf &
                       "Left Join TABFU Tf On Tf.KOFU = Ddo.KOFULIDO" & vbCrLf &
                       "Where Edo.EMPRESA = '" & Mod_Empresa & "' And Edo.TIDO = 'NVV' And Edo.ESDO = '' " & _TdFecha
        Dim _Tbl_Vendedores As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql, False)

        If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
            Log_Registro += _Sql.Pro_Error & vbCrLf
        End If

        If Not CBool(_Tbl_Vendedores.Rows.Count) Then
            Log_Registro += "No se encontraron correos para enviar aviso de cierre de documentos." & vbCrLf
            Return
        End If

        For Each _Fl As DataRow In _Tbl_Vendedores.Rows

            Dim _Kofulido As String = _Fl.Item("KOFULIDO")
            Dim _Para As String = _Fl.Item("EMAIL").ToString.Trim
            Dim _Cc As String = String.Empty
            Dim _Html As String = String.Empty

            Consulta_Sql = "Select Distinct Edo.TIDO As TD,Edo.NUDO As 'Número',En.KOEN As 'Entidad',En.SUEN As 'Suc.',En.NOKOEN As 'Razón Social'," &
                           "Edo.FEEMDO As 'F.Emisión',Edo.FEER As 'F.Despacho',Edo.VANEDO As 'Total Neto',Edo.VAIMDO+Edo.VAIVDO As 'Impuestos',Edo.VABRDO As 'Total Bruto'" & vbCrLf &
                           "From MAEEDO Edo" & vbCrLf &
                           "Inner Join MAEDDO Ddo On Edo.IDMAEEDO = Ddo.IDMAEEDO" & vbCrLf &
                           "Left Join MAEEN En On En.KOEN = Edo.ENDO And En.SUEN = Edo.SUENDO" & vbCrLf &
                           "Where Ddo.KOFULIDO = '" & _Kofulido & "' And Edo.IDMAEEDO In " & _Filtro_Idmaeedo
            Dim _Tbl_Documentos = _Sql.Fx_Get_DataTable(Consulta_Sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Log_Registro += _Sql.Pro_Error & vbCrLf
            End If

            If Not CBool(_Tbl_Documentos.Rows.Count) Then
                Log_Registro += "No se encontraron documentos para enviar aviso de cierre de documentos." & vbCrLf
                Continue For
            End If

            If _Cl_ConfCorreoAviso.Zw_Demonio_Conf_Correo.CC_Remitente Then
                _Cc = _Cl_ConfCorreoAviso.Zw_Demonio_Conf_Correo.MailCC
            End If

            _Html = Fx_GenerarTablaHTML(_Tbl_Documentos)

            '_Para = "jalfaro@bakapp.cl"

            If String.IsNullOrWhiteSpace(_Para) Then
                _Para = _Kofulido
            End If

            Fx_Enviar_Notificacion_Correo(_Para, _Cc, _Cl_ConfCorreoAviso.Zw_Demonio_Conf_Correo.Id_Correo, _Html)

        Next

    End Sub

    Sub Sb_Llenar_Zw_Conf_Cerrar_Documentos()

        Dim _Zw_Demonio_Conf_Cerrar_Documentos As New Zw_Demonio_Conf_Cerrar_Documentos

        _Zw_Demonio_Conf_Cerrar_Documentos = Fx_Llenar_Zw_Conf_Cerrar_Documentos(_Id_Padre, _NombreEquipo, "COV")
        LS_Zw_Demonio_Conf_Cerrar_Documentos.Add(_Zw_Demonio_Conf_Cerrar_Documentos)
        _Zw_Demonio_Conf_Cerrar_Documentos = Fx_Llenar_Zw_Conf_Cerrar_Documentos(_Id_Padre, _NombreEquipo, "NVI")
        LS_Zw_Demonio_Conf_Cerrar_Documentos.Add(_Zw_Demonio_Conf_Cerrar_Documentos)
        _Zw_Demonio_Conf_Cerrar_Documentos = Fx_Llenar_Zw_Conf_Cerrar_Documentos(_Id_Padre, _NombreEquipo, "NVV")
        LS_Zw_Demonio_Conf_Cerrar_Documentos.Add(_Zw_Demonio_Conf_Cerrar_Documentos)
        _Zw_Demonio_Conf_Cerrar_Documentos = Fx_Llenar_Zw_Conf_Cerrar_Documentos(_Id_Padre, _NombreEquipo, "OCI")
        LS_Zw_Demonio_Conf_Cerrar_Documentos.Add(_Zw_Demonio_Conf_Cerrar_Documentos)
        _Zw_Demonio_Conf_Cerrar_Documentos = Fx_Llenar_Zw_Conf_Cerrar_Documentos(_Id_Padre, _NombreEquipo, "OCC")
        LS_Zw_Demonio_Conf_Cerrar_Documentos.Add(_Zw_Demonio_Conf_Cerrar_Documentos)

    End Sub

    Function Fx_Llenar_Zw_Conf_Cerrar_Documentos(_Id_Padre As Integer,
                                                 _NombreEquipo As String,
                                                 _Tido As String) As Zw_Demonio_Conf_Cerrar_Documentos

        Dim _Zw_Demonio_Conf_Cerrar_Documentos As New Zw_Demonio_Conf_Cerrar_Documentos

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_Conf_Cerrar_Documentos" & vbCrLf &
                       "Where Id_Padre = " & _Id_Padre & " And NombreEquipo = '" & _NombreEquipo & "' And Tido = '" & _Tido & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        If IsNothing(_Row) Then

            With _Zw_Demonio_Conf_Cerrar_Documentos

                ' Asignar valores por defecto a las propiedades de la clase
                .Id = 0
                .NombreEquipo = _NombreEquipo
                .Id_Padre = _Id_Padre
                .Ejecutar = False
                .Tido = _Tido
                .Dias = 0
                .FEmision = True
                .FDespacho = False
                .Id_ConfCorreo = 0

            End With

            Dim _Mensaje As LsValiciones.Mensajes = Fx_Grabar_Cl_Cerrar_Documentos(_Zw_Demonio_Conf_Cerrar_Documentos)

            If _Mensaje.EsCorrecto Then
                _Zw_Demonio_Conf_Cerrar_Documentos = Fx_Llenar_Zw_Conf_Cerrar_Documentos(_Id_Padre, _NombreEquipo, _Tido)
            End If

        Else

            With _Zw_Demonio_Conf_Cerrar_Documentos

                .Id = _Row.Item("Id")
                .NombreEquipo = _Row.Item("NombreEquipo")
                .Id_Padre = _Row.Item("Id_Padre")
                .Ejecutar = _Row.Item("Ejecutar")
                .Tido = _Row.Item("Tido")
                .Dias = _Row.Item("Dias")
                .FEmision = _Row.Item("FEmision")
                .FDespacho = _Row.Item("FDespacho")
                .Id_ConfCorreo = _Row.Item("Id_ConfCorreo")

            End With

        End If

        Return _Zw_Demonio_Conf_Cerrar_Documentos

    End Function

    Function Fx_Grabar_Cl_Cerrar_Documentos(_Zw_Demonio_Conf_Cerrar_Documentos As Zw_Demonio_Conf_Cerrar_Documentos) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            With _Zw_Demonio_Conf_Cerrar_Documentos

                ' Construir la consulta SQL para insertar o actualizar los datos en Zw_Demonio_Conf_Cerrar_Documentos

                If .Id = 0 Then

                    Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Conf_Cerrar_Documentos" &
                                   "(NombreEquipo,Id_Padre,Ejecutar,Tido,Dias,FEmision,FDespacho,Id_ConfCorreo)" & vbCrLf &
                                   "VALUES " & vbCrLf &
                                   "('" & _NombreEquipo & "'," & _Id_Padre & "," & Convert.ToInt32(.Ejecutar) &
                                   ",'" & .Tido & "'," & .Dias & "," & Convert.ToInt32(.FEmision) & "," & Convert.ToInt32(.FDespacho) & "," & .Id_ConfCorreo & ")"

                Else

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_Conf_Cerrar_Documentos" & vbCrLf &
                                   "Set" & vbCrLf &
                                   "Ejecutar = " & Convert.ToInt32(.Ejecutar) & vbCrLf &
                                   ",Tido = '" & .Tido & "'" & vbCrLf &
                                   ",Dias = " & .Dias & vbCrLf &
                                   ",FEmision = " & Convert.ToInt32(.FEmision) & vbCrLf &
                                   ",FDespacho = " & Convert.ToInt32(.FDespacho) & vbCrLf &
                                   ",Id_ConfCorreo = " & .Id_ConfCorreo & vbCrLf &
                                   "Where NombreEquipo = '" & _NombreEquipo & "' AND Id_Padre = " & _Id_Padre & " And Tido = '" & .Tido & "'"
                End If

            End With

            ' Ejecutar la consulta SQL
            If Not _Sql.Ej_consulta_IDU(Consulta_Sql) Then
                _Mensaje.ConsultaSQLEjecutada = Consulta_Sql
                Throw New System.Exception("Error al intentar guardar los datos en Zw_Demonio_Conf_Cerrar_Documentos." & vbCrLf & _Sql.Pro_Error)
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Grabar configuración"
            _Mensaje.Mensaje = "Datos guardados correctamente en Zw_Demonio_Conf_Cerrar_Documentos."
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "Error: " & ex.Message
            _Mensaje.Detalle = "No se pudo guardar la configuración de cierre de documentos."
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

    Function Fx_Enviar_Notificacion_Correo(_Para As String,
                                           _Cc As String,
                                           _Id_Correo As Integer,
                                           _Html As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Error = String.Empty

        Try

            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Correos Corr Where Id = " & _Id_Correo
            Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql, False)

            If IsNothing(_Row_Correo) Then
                Throw New System.Exception("No existe configuración para el envio de correos")
            End If

            Dim _Nombre_Correo As String = _Row_Correo.Item("Nombre_Correo")
            Dim _Auto_Asunto As Boolean = _Row_Correo.Item("Auto_Asunto")
            Dim _Asunto As String = _Row_Correo.Item("Asunto")
            Dim _CuerpoMensaje As String = _Row_Correo.Item("CuerpoMensaje")

            If String.IsNullOrEmpty(_Asunto) Then
                _Asunto = "Correo de notificación de pedido " & RazonEmpresa
            End If

            If _Auto_Asunto Then
                _Asunto += " - (" & Fx_CreaNroRandom() & " - " & Now & ")"
            End If

            _CuerpoMensaje = Replace(_CuerpoMensaje, "&lt;", "<")
            _CuerpoMensaje = Replace(_CuerpoMensaje, "&gt;", ">")
            _CuerpoMensaje = Replace(_CuerpoMensaje, "&quot;", """")
            _CuerpoMensaje = Replace(_CuerpoMensaje, "<HTML>", _Html)
            _CuerpoMensaje = Replace(_CuerpoMensaje, "'", "''")

            If Not String.IsNullOrEmpty(_Nombre_Correo) Then

                Dim _Fecha = "Getdate()"
                Dim _NombreEquipo As String = String.Empty

                _Para = _Para.Trim

                Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo (NombreEquipo,Id_Correo,Nombre_Correo,CodFuncionario,Asunto," &
                                "Para,Cc,Idmaeedo,Tido,Nudo,NombreFormato,Enviar,Mensaje,Fecha,Adjuntar_Documento,Doc_Adjuntos,Id_Acp)" &
                                vbCrLf &
                                "Values ('" & _NombreEquipo & "'," & _Id_Correo & ",'" & _Nombre_Correo & "','','" & _Asunto & "','" & _Para & "','" & _Cc &
                                "',0,'','','',1,'" & _CuerpoMensaje & "'," & _Fecha &
                                ",0,'',0)"

                If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                    Throw New System.Exception(_Sql.Pro_Error)
                End If

            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Correo enviado correctamente"
            _Mensaje.Detalle = "El correo se ha enviado correctamente a " & _Para
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "Error: " & ex.Message
            _Mensaje.Detalle = "No se pudo enviar el correo de notificación"
            _Mensaje.Icono = MessageBoxIcon.Error
            If Not String.IsNullOrEmpty(_Error) Then
                Log_Registro += vbCrLf & _Error
            End If

        End Try

        Return _Mensaje

    End Function

    Function Fx_GenerarTablaHTML(_Tbl_Documentos As DataTable) As String
        Dim _Html As New System.Text.StringBuilder()

        _Html.Append("<table border='1' style='border-collapse:collapse; width:70%;'>" & vbCrLf)
        _Html.Append("<thead>" & vbCrLf)
        _Html.Append(vbTab & "<tr>" & vbCrLf)
        For Each _Col As DataColumn In _Tbl_Documentos.Columns
            _Html.AppendFormat(vbTab & vbTab & "<th>{0}</th>" & vbCrLf, _Col.ColumnName)
        Next
        _Html.Append(vbTab & "</tr>" & vbCrLf)
        _Html.Append("</thead>" & vbCrLf)
        _Html.Append("<tbody>" & vbCrLf)
        For Each _Row As DataRow In _Tbl_Documentos.Rows
            _Html.Append(vbTab & "<tr>" & vbCrLf)
            For Each _Col As DataColumn In _Tbl_Documentos.Columns
                If TypeOf _Row(_Col.ColumnName) Is DateTime Then
                    _Html.AppendFormat(vbTab & vbTab & "<td style='text-align:center;padding-left:6px;padding-right:6px'>{0}</td>" & vbCrLf, Format(CDate(_Row(_Col.ColumnName)), "dd-MM-yyyy"))
                ElseIf TypeOf _Row(_Col.ColumnName) Is Decimal OrElse TypeOf _Row(_Col.ColumnName) Is Double OrElse TypeOf _Row(_Col.ColumnName) Is Single Then
                    _Html.AppendFormat(vbTab & vbTab & "<td style='text-align:right;padding-left:6px;padding-right:6px'>{0}</td>" & vbCrLf, Format(CDec(_Row(_Col.ColumnName)), "N0"))
                ElseIf TypeOf _Row(_Col.ColumnName) Is Integer OrElse TypeOf _Row(_Col.ColumnName) Is Long Then
                    _Html.AppendFormat(vbTab & vbTab & "<td style='text-align:right';padding-left:6px;padding-right:6px>{0}</td>" & vbCrLf, Format(CLng(_Row(_Col.ColumnName)), ""))
                Else
                    _Html.AppendFormat(vbTab & vbTab & "<td style='padding-left:6px;padding-right:6px'>{0}</td>" & vbCrLf, _Row(_Col.ColumnName).ToString().Trim())
                End If
            Next
            _Html.Append(vbTab & "</tr>" & vbCrLf)
        Next
        _Html.Append("</tbody>" & vbCrLf)
        _Html.Append("</table>" & vbCrLf)

        Return _Html.ToString()
    End Function

End Class


