
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
                       "Edo.EMPRESA = '" & ModEmpresa & "' And Edo.TIDO = '" & _Tido & "' And Edo.ESDO = '' And Edo.FEEMDO <= '" & Format(_Fecha, "yyyyMMdd") & "'")
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
                       "Edo.EMPRESA = '" & ModEmpresa & "' And Edo.TIDO = '" & _Tido & "' And Edo.ESDO = ''" & _TdFecha)
        Consulta_Sql = Replace(Consulta_Sql, "#Campo_SUENDOFI#", "")
        Consulta_Sql = Replace(Consulta_Sql, "#Left_Join_MAEEN_ENDOFI_SUENDOFI#", "")
        Consulta_Sql = Replace(Consulta_Sql, "Isnull(Mae2.NOKOEN,'') As RAZON_FISICA,", "")
        Consulta_Sql = Replace(Consulta_Sql, "#Orden#", "")
        Consulta_Sql = Replace(Consulta_Sql, "#CantidadDoc#", "100")
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

                Fx_Add_Log_Gestion("XXX", Modalidad, "MAEEDO", _Idmaeedo, "", "CIERRE Y REACTIVACIÓN DE DOCUMENTOS DE COMPROMISO", "Doc00011", "", "", "", False, "XXX")

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
                                   "(NombreEquipo,Id_Padre,Ejecutar,Tido,Dias,FEmision,FDespacho)" & vbCrLf &
                                   "VALUES " & vbCrLf &
                                   "('" & _NombreEquipo & "'," & _Id_Padre & "," & Convert.ToInt32(.Ejecutar) &
                                   ",'" & .Tido & "'," & .Dias & "," & Convert.ToInt32(.FEmision) & "," & Convert.ToInt32(.FDespacho) & ")"

                Else

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_Conf_Cerrar_Documentos" & vbCrLf &
                                   "Set" & vbCrLf &
                                   "Ejecutar = " & Convert.ToInt32(.Ejecutar) & "," & vbCrLf &
                                   "Tido = '" & .Tido & "'," & vbCrLf &
                                   "Dias = " & .Dias & "," & vbCrLf &
                                   "FEmision = " & Convert.ToInt32(.FEmision) & "," & vbCrLf &
                                   "FDespacho = " & Convert.ToInt32(.FDespacho) & vbCrLf &
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

End Class


