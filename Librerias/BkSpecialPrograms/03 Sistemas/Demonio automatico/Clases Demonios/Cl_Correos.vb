Imports System.ComponentModel
Imports System.IO
Imports Limilabs.Client.SMTP

Public Class Cl_Correos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim WithEvents _Tiempo As Timer
    Dim WithEvents _BackgroundWorker As New BackgroundWorker

    Dim _Lbl_Estado As String
    Dim _Procesando As Boolean
    Dim _Fecha_Revision As Date
    Dim _Nombre_Equipo As String
    Dim _Path As String

    Dim _Segundos_Correo As Integer
    Dim _Input_Tiempo_Correo As Integer

    Public Property CantMmail As Integer
    Public Property EnviarSiempreLosCorreosDTE As Boolean

    Public Property Lbl_Estado As String
        Get
            Return _Lbl_Estado
        End Get
        Set(value As String)
            _Lbl_Estado = value
        End Set
    End Property

    Public Property Procesando As Boolean
        Get
            Return _Procesando
        End Get
        Set(value As Boolean)
            _Procesando = value
        End Set
    End Property

    Public Property Fecha_Revision As Date
        Get
            Return _Fecha_Revision
        End Get
        Set(value As Date)
            _Fecha_Revision = value
        End Set
    End Property

    Public Property Nombre_Equipo As String
        Get
            Return _Nombre_Equipo
        End Get
        Set(value As String)
            _Nombre_Equipo = value
        End Set
    End Property

    Public Property Path As String
        Get
            Return _Path
        End Get
        Set(value As String)
            _Path = value
        End Set
    End Property

    Public Property Segundos_Correo As Integer
        Get
            Return _Segundos_Correo
        End Get
        Set(value As Integer)
            _Segundos_Correo = value
        End Set
    End Property

    Public Property Input_Tiempo_Correo As Integer
        Get
            Return _Input_Tiempo_Correo
        End Get
        Set(value As Integer)
            _Input_Tiempo_Correo = value
        End Set
    End Property
    Public Property Ejecutar As Boolean
    Public Sub New()

        '_BackgroundWorker.WorkerReportsProgress = True
        '_BackgroundWorker.WorkerSupportsCancellation = True

        _Lbl_Estado = "Monitoreo Correos"
        CantMmail = 30

    End Sub

    Sub Sb_Iniciar() '--, ByRef CirProgress As CircularProgress)

        _Procesando = True
        _BackgroundWorker.RunWorkerAsync()

    End Sub

    Sub Sb_Detener()

        If _BackgroundWorker.IsBusy Then
            _BackgroundWorker.CancelAsync()
        End If

    End Sub

    Private Sub BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles _BackgroundWorker.DoWork

        Dim worker As BackgroundWorker = TryCast(sender, BackgroundWorker)

        Try

            Sb_Procedimiento_Correos()
            '_CirProgress.Visible = False

        Catch ex As Exception
            e.Cancel = True
        End Try

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles _BackgroundWorker.ProgressChanged
        'Lbl_Progreso.Text = (e.ProgressPercentage.ToString() & "%")
        'ProgressBarItem1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _BackgroundWorker.RunWorkerCompleted

        If e.Cancelled = True Then
            'Lbl_Progreso.Text = "Canceled!"
        ElseIf e.[Error] IsNot Nothing Then
            'Lbl_Progreso.Text = "Error: " & e.[Error].Message
        Else
            'Lbl_Progreso.Text = "Done!"
            'If _BackgroundWorker.IsBusy <> True Then
            '_BackgroundWorker.RunWorkerAsync()
            'End If
        End If

        _Procesando = False
        _Lbl_Estado = "Monitoreo Correos"

    End Sub

    Sub Sb_Procedimiento_Correos()

        ' _Procesando = True

        '_Nombre_Equipo = "RANDOM_AUXILIAR"

        _Path = AppPath() & "\Data\" & RutEmpresa & "\Demonio"

        Dim _Consulta_sql = String.Empty

        Dim _Fecha = Format(_Fecha_Revision, "yyyyMMdd")
        Dim _Tbl_Correos As DataTable

        Dim Dia_1 As String = numero_(_Fecha_Revision.Day, 2)
        Dim Mes_1 As String = numero_(_Fecha_Revision.Month, 2)
        Dim Ano_1 As String = _Fecha_Revision.Year

        Dim _Filtro_Fecha =
                      "FEEMDO BETWEEN CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
                      "AND CONVERT(DATETIME, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 23:59:59', 102)"

        _Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & vbCrLf &
                        "Where Fecha < '" & _Fecha & "' And NombreEquipo In ('" & _Nombre_Equipo & "','') And Enviado = 1"
        _Sql.Ej_consulta_IDU(_Consulta_sql)

        _Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo_Adjuntos 
                        Where Id_Padre Not In (Select Id From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo)"
        _Sql.Ej_consulta_IDU(_Consulta_sql)

        _Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_Cof_Estacion" & vbCrLf &
                        "Where NombreEquipo = '" & _Nombre_Equipo & "' And Traer_Doc_Auto_Correo = 1"

        Dim _Tbl_Zw_Demonio_Cof_Estacion As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql)

        Dim _SqlQuery_Correo = String.Empty

        Dim _Contador = 0

        For Each _Fila As DataRow In _Tbl_Zw_Demonio_Cof_Estacion.Rows

            Dim _Tido As String = _Fila.Item("TipoDoc")
            Dim _NombreFormato As String = _Fila.Item("NombreFormato")
            Dim _IdPadre As String = _Fila.Item("Id")
            Dim _Condicion_Func = String.Empty

            Dim _Imprimir_Picking = _Fila.Item("Imprimir_Picking")

            _Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion" & vbCrLf &
                            "Where NombreEquipo = '" & _Nombre_Equipo & "' And Nombre_Correo <> '' And (Correo_Para <> '' Or Para_Maeenmail = 1) And TipoDoc = '" & _Tido & "' --And Codigo = 'JPT'"
            Dim _TblFiltroFunc As DataTable = _Sql.Fx_Get_Tablas(_Consulta_sql)

            If CBool(_TblFiltroFunc.Rows.Count) Then

                For Each _Fila_Correo As DataRow In _TblFiltroFunc.Rows

                    System.Windows.Forms.Application.DoEvents()

                    Dim _TipoDoc = _Fila_Correo.Item("TipoDoc")
                    Dim _Nombre_Correo = _Fila_Correo.Item("Nombre_Correo")
                    Dim _NombreFormato_Correo = _Fila_Correo.Item("NombreFormato_Correo")
                    Dim _Correo_Para = _Fila_Correo.Item("Correo_Para")
                    Dim _Kofudo = _Fila_Correo.Item("Codigo")
                    Dim _Para_Maeenmail = _Fila_Correo.Item("Para_Maeenmail")

                    Dim _Nudonodefi As String = "0"

                    Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Correos Where Nombre_Correo = '" & _Nombre_Correo & "'"
                    Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    _Contador += 1
                    _Lbl_Estado = "Revisando Conf. para envio " & _Contador & " (" & _TblFiltroFunc.Rows.Count & ")..."
                    System.Windows.Forms.Application.DoEvents()

                    If Not IsNothing(_Row_Correo) Then

                        Dim _Asunto = _Row_Correo.Item("Asunto")
                        Dim _CuerpoMensaje = _Row_Correo.Item("CuerpoMensaje").ToString.Replace("'", "''")

                        If Not String.IsNullOrEmpty(_Correo_Para) Or _Para_Maeenmail Then

                            Dim _Tbl_Destinatarios As DataTable
                            Dim _Para As String

                            If Not String.IsNullOrEmpty(_Correo_Para) Then

                                Consulta_Sql = "Select KOFU,NOKOFU,Rtrim(Ltrim(EMAIL)) As EMAIL From TABFU Where KOFU In " & _Correo_Para
                                _Tbl_Destinatarios = _Sql.Fx_Get_Tablas(Consulta_Sql)
                                _Para = Generar_Filtro_IN_Email(_Tbl_Destinatarios, "EMAIL")

                            End If

                            _SqlQuery_Correo += "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & Space(1) &
                                         "(NombreEquipo,Nombre_Correo,CodFuncionario,Asunto,Para,Cc,Idmaeedo," &
                                         "Tido,Nudo,NombreFormato,Enviar,Intentos,Enviado,Adjuntar_Documento,Mensaje,Fecha,Para_Maeenmail) " & vbCrLf &
                                         "Select '" & _Nombre_Equipo & "','" & _Nombre_Correo & "','" & _Kofudo & "','" & _Asunto & "','" & _Para &
                                         "','',IDMAEEDO,TIDO,NUDO,'" & _NombreFormato_Correo & "',1,0,0,1,'" & _CuerpoMensaje & "',
                                         Cast(Floor(Cast(Getdate() As Float)) As Datetime)," & Convert.ToInt32(_Para_Maeenmail) & vbCrLf &
                                         "From MAEEDO Where TIDO = '" & _TipoDoc & "' And " & _Filtro_Fecha & " And NUDONODEFI = 0" & vbCrLf &
                                         "And IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & Space(1) &
                                         "Where NombreEquipo In ('" & _Nombre_Equipo & "'))" & Space(1) &
                                         "And KOFUDO = '" & _Kofudo & "'" & vbCrLf &
                                         vbCrLf & "-------------------------------------------------" & vbCrLf

                        End If

                    End If

                Next

            End If

        Next


        If Not String.IsNullOrEmpty(_SqlQuery_Correo) Then
            _Lbl_Estado = "Insertando datos..."
            System.Windows.Forms.Application.DoEvents()
            _Sql.Ej_consulta_IDU(_SqlQuery_Correo, False)
        End If

        Sb_Correos_Automaticos_MEENMAIL()

        'Dim _Filtro_Fecha_Enviar =
        '              "And Fecha Between Convert(Datetime, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 00:00:00', 102)" & vbCrLf &
        '              "And Convert(Datetime, '" & Ano_1 & "-" & Mes_1 & "-" & Dia_1 & " 23:59:59', 102)"

        Dim _Filtro_Fecha_Enviar As String

        If EnviarSiempreLosCorreosDTE Then
            _Filtro_Fecha_Enviar = "And (CONVERT(varchar, Fecha, 112) = '" & _Fecha & "' Or (Id_Dte <> 0 And Id_Trackid <> 0))"
        Else
            _Filtro_Fecha_Enviar = "And CONVERT(varchar, Fecha, 112) = '" & _Fecha & "'"
        End If

        'Se reactivan los correos que se cerraron y por error no pudieron ser enviados
        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo Set Enviar = 1 " &
                       "Where NombreEquipo = '" & _Nombre_Equipo & "' And Enviar = 0 And Enviado = 0 And Intentos <= 2"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

        '_Nombre_Equipo = "VILLAR_CLOUD"

        Consulta_Sql = "Select Top " & CantMmail & " *,Isnull(NOKOFU,'Funcionario?????') As 'Nombre_Funcionario'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & vbCrLf &
                       "Left Join TABFU On KOFU = CodFuncionario" & vbCrLf &
                       "Where Enviar = 1 And Enviado = 0 And NombreEquipo In ('','" & _Nombre_Equipo & "')" & _Filtro_Fecha_Enviar & vbCrLf &
                       "Order By Intentos, Id"

        'Consulta_Sql = "Select Top " & CantMmail & " *,Isnull(NOKOFU,'Funcionario?????') As 'Nombre_Funcionario'" & vbCrLf &
        '               "From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & vbCrLf &
        '               "Left Join TABFU On KOFU = CodFuncionario" & vbCrLf &
        '               "Where Enviar = 1 And Enviado = 0 And NombreEquipo = '" & _Nombre_Equipo & "'" & _Filtro_Fecha_Enviar & vbCrLf &
        '               "Order By Intentos, Id"

        _Tbl_Correos = _Sql.Fx_Get_Tablas(Consulta_Sql)

        'Dim fic As String = AppPath(True) & "Log_Bk.txt"

        'Dim sw As New System.IO.StreamWriter(fic)
        'sw.WriteLine(Consulta_Sql)
        'sw.Close()


        _Lbl_Estado = "Creando correos para envio..."
        System.Windows.Forms.Application.DoEvents()

        Dim _Conteo_envio = 0
        Dim _Conteo_Error = 0

        If (_Tbl_Correos.Rows.Count) Then

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo Set NombreEquipo = '" & _Nombre_Equipo & "',Enviar = 0 
                            Where Id In " & Generar_Filtro_IN(_Tbl_Correos, "", "Id", False, False, "")
            _Sql.Ej_consulta_IDU(Consulta_Sql, False)

            For Each _Fila As DataRow In _Tbl_Correos.Rows

                Dim _Id = _Fila.Item("Id")
                Dim _NombreEquipo = _Fila.Item("NombreEquipo")
                Dim _Id_Correo = _Fila.Item("Id_Correo")
                Dim _Nombre_Correo = _Fila.Item("Nombre_Correo")
                Dim _CodFuncionario = _Fila.Item("CodFuncionario")
                Dim _Nombre_Funcionario = _Fila.Item("Nombre_Funcionario").ToString.Trim
                Dim _Asunto = _Fila.Item("Asunto").ToString.Trim
                Dim _Para As String = _Fila.Item("Para").ToString.Trim
                Dim _Cc As String = _Fila.Item("Cc").ToString.Trim
                Dim _IdMaeedo = _Fila.Item("Idmaeedo")
                Dim _Tido = _Fila.Item("Tido").ToString.Trim
                Dim _Nudo = _Fila.Item("Nudo").ToString.Trim
                Dim _NombreFormato = _Fila.Item("NombreFormato")
                Dim _Enviar = _Fila.Item("Enviar")
                Dim _Intentos = _Fila.Item("Intentos")
                Dim _Enviado = _Fila.Item("Enviado")
                Dim _Adjuntar_Documento = _Fila.Item("Adjuntar_Documento")
                Dim _Archivos_Adjuntos(0) As String
                Dim _Para_Maeenmail = _Fila.Item("Para_Maeenmail")
                Dim _Doc_Adjuntos = _Fila.Item("Doc_Adjuntos")
                Dim _Adjuntar_DTE = _Fila.Item("Adjuntar_DTE")
                Dim _Id_Dte = _Fila.Item("Id_Dte")
                Dim _Id_Trackid = _Fila.Item("Id_Trackid")
                Dim _Id_Acp = _Fila.Item("Id_Acp")


                If _Adjuntar_DTE And (_Tido = "COV" Or _Tido = "NVV") Then
                    _Adjuntar_DTE = False
                End If

                Dim _Existe_File

                Dim _Enviar_Correo = True
                Dim _Error = String.Empty

                Consulta_Sql = "Select TIDO,NUDO,KOEN,SUEN,NOKOEN,ESDO 
                                From MAEEDO Inner Join MAEEN On KOEN = ENDO And SUEN = SUENDO 
                                Where IDMAEEDO = " & _IdMaeedo
                Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                Dim _Koen, _Suen As String

                If IsNothing(_Row_Documento) AndAlso CBool(_IdMaeedo) Then

                    Consulta_Sql = "Select TIDO,NUDO,KOEN,SUEN,NOKOEN,ESDO 
                                    From MAEEDO Inner Join MAEEN On KOEN = ENDO And SUEN = SUENDO 
                                    Where TIDO = '" & _Tido & "' And NUDO = '" & _Nudo & "'"
                    _Row_Documento = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    If Not IsNothing(_Row_Documento) Then
                        Dim _Esdo = _Row_Documento.Item("ESDO")
                        If _Esdo = "N" Then
                            _Error = "El documento " & _Tido & "-" & _Nudo & " esta NULO"
                        End If
                    Else
                        _Error = "No se encontro el documento " & _Tido & "-" & _Nudo
                    End If

                End If

                If _Adjuntar_Documento Then

                    If IsNothing(_Row_Documento) Then

                        _Error += "No se encontro el documento " & _Tido & "-" & _Nudo & " (IDMAEEDO: " & _IdMaeedo & ")"
                        _Intentos = 4

                    Else

                        _Koen = _Row_Documento.Item("KOEN")
                        _Suen = _Row_Documento.Item("SUEN")

                        Dim _Esdo = _Row_Documento.Item("ESDO")
                        If _Esdo = "N" Then
                            _Error += "El documento " & _Tido & "-" & _Nudo & " esta NULO"
                            _Intentos = 4
                        Else
                            If _Row_Documento.Item("TIDO") <> _Tido Or _Row_Documento.Item("NUDO") <> _Nudo Then
                                _Error += "El documento " & _Tido & "-" & _Nudo & " no pertenece al IDMAEEDO " & _IdMaeedo
                                _Intentos = 4
                            End If
                        End If

                    End If

                End If

                If Not String.IsNullOrEmpty(_Error) Then

                    _Error = "Problemas al enviar correo: " & _Error

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo Set" & Space(1) &
                                   "Enviar = 0," &
                                   "Intentos = 4," &
                                   "Fecha_Envio = Getdate()," &
                                   "Informacion = '" & _Error & "'" & vbCrLf &
                                   "Where Id = " & _Id
                    _Sql.Ej_consulta_IDU(Consulta_Sql, False)

                    _Adjuntar_DTE = False
                    _Enviar_Correo = False
                    _Adjuntar_Documento = False

                End If
#Region "ADJUNTAR DTE"

                If _Adjuntar_DTE Then

                    Dim _Archivo_Xml As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Documentos", "CaratulaXmlEmail", "Id_Dte = " & _Id_Dte)

                    If String.IsNullOrEmpty(_Archivo_Xml) Then

                        _Error = "Problemas al enviar correo: No se encontro el archivo XML en el campo [CaratulaXmlEmail] de la tabla " & _Global_BaseBk & "Zw_DTE_Documentos, Id_Dte = " & _Id_Dte

                        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo Set" & Space(1) &
                                       "Enviar = 0," &
                                       "Fecha_Envio = Getdate()," &
                                       "Informacion = '" & _Error & "'" & vbCrLf &
                                       "Where Id = " & _Id
                        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

                        _Adjuntar_DTE = False
                        _Enviar_Correo = False
                        _Adjuntar_Documento = False

                    End If

                    If Not String.IsNullOrEmpty(_Archivo_Xml) Then

                        Dim _Dir = _Path & "\Dte" '= AppPath() & "\Data\" & RutEmpresa & "\Demonio"

                        If Not Directory.Exists(_Dir) Then
                            System.IO.Directory.CreateDirectory(_Dir)
                        End If

                        Dim _Nombre_Archivo = _Tido & "-" & _Nudo & ".xml"
                        _Dir = _Dir & "\" & _Nombre_Archivo

                        Dim oSW As New System.IO.StreamWriter(_Dir)

                        oSW.WriteLine(_Archivo_Xml)
                        oSW.Close()

                        _Existe_File = System.IO.File.Exists(_Dir)

                        If _Existe_File Then
                            _Archivos_Adjuntos(_Archivos_Adjuntos.Length - 1) = _Dir
                            ReDim Preserve _Archivos_Adjuntos(_Archivos_Adjuntos.Length)
                        End If

                    End If

                End If

#End Region

#Region "ADJUNTAR DOCUMENTOS"

                If _Adjuntar_Documento Then

                    If CBool(_IdMaeedo) Then

                        Dim _Pdf_Adjunto As New Clas_PDF_Crear_Documento(_IdMaeedo,
                                                                         _Tido,
                                                                         _NombreFormato,
                                                                         _Tido & "-" & _Nudo,
                                                                         _Path, _Tido & "-" & _Nudo, False)

                        _Error = _Pdf_Adjunto.Pro_Error

                        If String.IsNullOrEmpty(_Error) Then

                            _Pdf_Adjunto.Sb_Crear_PDF("", False, _Pdf_Adjunto.Pro_Nombre_Archivo)
                            Dim _Error_Pdf = _Pdf_Adjunto.Pro_Error

                            _Existe_File = System.IO.File.Exists(_Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf")

                            If _Existe_File Then
                                _Archivos_Adjuntos(_Archivos_Adjuntos.Length - 1) = _Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf"
                            Else
                                _Archivos_Adjuntos = Nothing
                            End If

                        Else

                            Consulta_Sql = "Select * From MAEEDO Where TIDO = '" & _Tido & "' And NUDO = '" & _Nudo & "'"
                            _Row_Documento = _Sql.Fx_Get_DataRow(Consulta_Sql)

                            If Not IsNothing(_Row_Documento) Then
                                Dim _Esdo = _Row_Documento.Item("ESDO")
                                If _Esdo = "N" Then
                                    _Error += ", el documento " & _Tido & "-" & _Nudo & " esta NULO"
                                End If
                            Else
                                _Error += ", No se encontro el documento " & _Tido & "-" & _Nudo
                            End If

                            _Enviar_Correo = False
                            _Error = "Problemas al enviar correo: No se pudo crear archivo adjunto. " & _Error

                            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo Set" & Space(1) &
                                           "Enviar = 0," &
                                           "Fecha_Envio = Getdate()," &
                                           "Informacion = '" & _Error & "'" & vbCrLf &
                                           "Where Id = " & _Id
                            _Sql.Ej_consulta_IDU(Consulta_Sql, False)

                        End If

                    Else

                        Consulta_Sql = "Select Id,Id_Padre,Idmaeedo,Tido,Nudo,NombreFormato
                                        From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo_Adjuntos
                                        Where Id_Padre = " & _Id
                        Dim _Tbl_Adjuntos As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

                        For Each _FDoc As DataRow In _Tbl_Adjuntos.Rows

                            _IdMaeedo = _FDoc.Item("Idmaeedo")
                            _Tido = _FDoc.Item("Tido")
                            _Nudo = _FDoc.Item("Nudo")
                            _NombreFormato = _FDoc.Item("NombreFormato")

                            If CBool(_IdMaeedo) And Not String.IsNullOrEmpty(_NombreFormato) Then

                                Dim _Pdf_Adjunto As New Clas_PDF_Crear_Documento(_IdMaeedo,
                                                                                     _Tido,
                                                                                     _NombreFormato,
                                                                                     _Tido & "-" & _Nudo,
                                                                                     _Path, _Tido & "-" & _Nudo, False)
                                _Pdf_Adjunto.Sb_Crear_PDF("", False, _Pdf_Adjunto.Pro_Nombre_Archivo)
                                Dim _Error_Pdf = _Pdf_Adjunto.Pro_Error

                                _Existe_File = System.IO.File.Exists(_Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf")

                                If _Existe_File Then
                                    _Archivos_Adjuntos(_Archivos_Adjuntos.Length - 1) = _Pdf_Adjunto.Pro_Full_Path_Archivo_PDF & "\" & _Pdf_Adjunto.Pro_Nombre_Archivo & ".pdf"
                                    ReDim Preserve _Archivos_Adjuntos(_Archivos_Adjuntos.Length)
                                End If

                            End If

                        Next

                        _IdMaeedo = 0

                    End If

                End If

#End Region

                If String.IsNullOrEmpty(_Error) Then

                    Dim _CuerpoMensaje As String = _Fila.Item("Mensaje")

                    Dim _Crea_Html As New Clase_Crear_Documento_Htm
                    Dim _Ruta_Html As String = AppPath() & "\Data\" & RutEmpresa & "\Tmp"

                    Dim _Cuerpo_Html

                    If CBool(_IdMaeedo) And (_CuerpoMensaje.Contains("<HTML>") Or _CuerpoMensaje.Contains("<HTML_SP>")) Then

                        Dim _Mostrar_Precios As Boolean = Not (_CuerpoMensaje.Contains("<HTML_SP>"))

                        If _Crea_Html.Fx_Crear_Documento_Htm(_IdMaeedo, _Ruta_Html, _Mostrar_Precios) Then
                            Dim _Dir As String = _Ruta_Html & "\Documento.Htm"
                            _Cuerpo_Html = LeeArchivo(_Dir)
                        End If

                    End If

                    Consulta_Sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Correos" & vbCrLf &
                                   "Where Nombre_Correo = '" & _Nombre_Correo & "'"
                    Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    If _Row_Correo IsNot Nothing Then


                        Dim _Remitente = Trim(_Row_Correo.Item("Remitente"))
                        Dim _Host = _Row_Correo.Item("Host")
                        Dim _Puerto = _Row_Correo.Item("Puerto")
                        Dim _Contrasena = Trim(_Row_Correo.Item("Contrasena"))
                        Dim _SSL = _Row_Correo.Item("SSL")
                        Dim _Es_Html = _Row_Correo.Item("Es_Html")

                        If _Asunto = "@@" Then _Asunto = _Row_Correo.Item("Asunto")
                        If _CuerpoMensaje = "@@" Then _CuerpoMensaje = _Row_Correo.Item("CuerpoMensaje")


                        If _Sql.Fx_Exite_Campo(_Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion", "Usar_CtaSMTP_Funcionario") Then

                            If Not String.IsNullOrEmpty(_Tido) Then

                                '_Nombre_Equipo = "RANDOM_AUXILIAR"

                                Dim _Usar_CtaSMTP_Funcionario As Boolean = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Demonio_Filtros_X_Estacion",
                                                                                         "Usar_CtaSMTP_Funcionario",
                                                                                         "NombreEquipo = '" & _Nombre_Equipo &
                                                                                         "' And Codigo = '" & _CodFuncionario &
                                                                                         "' And TipoDoc = '" & _Tido & "'", ,,, True)

                                If _Usar_CtaSMTP_Funcionario Then

                                    Dim _Nombre_Usuario = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Usuarios", "Email", "CodFuncionario = '" & _CodFuncionario & "'")

                                    Consulta_Sql = "Select Nombre_Usuario,Contrasena,Host,Puerto, SSL" & vbCrLf &
                                                   "From " & _Global_BaseBk & "Zw_Correos_Cuentas" & vbCrLf &
                                                   "Where Nombre_Usuario = '" & _Nombre_Usuario & "'"
                                    Dim _Row_SmtpUsuario As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                                    If Not IsNothing(_Row_SmtpUsuario) Then

                                        _Remitente = _Row_SmtpUsuario.Item("Nombre_Usuario").ToString.Trim
                                        _Host = _Row_SmtpUsuario.Item("Host")
                                        _Puerto = _Row_SmtpUsuario.Item("Puerto")
                                        _Contrasena = _Row_SmtpUsuario.Item("Contrasena").ToString.Trim
                                        _SSL = _Row_SmtpUsuario.Item("SSL")

                                    Else

                                        _Remitente = _Nombre_Usuario
                                        _Host = "???"
                                        _Puerto = 0
                                        _Contrasena = "???"
                                        _SSL = False
                                        _Enviar_Correo = False
                                        _Error = "Falta la configuración SMTP del usuario " & _CodFuncionario & " - " & _Nombre_Funcionario
                                        _Intentos = 3

                                    End If

                                End If

                            End If

                        End If

                        If String.IsNullOrEmpty(_Asunto) Then
                            _Asunto = "Envío de correo automático por BakApp…"
                        End If

                        _CuerpoMensaje = Replace(_CuerpoMensaje, "<HTML>", "@@HTML@@")    ' Html con precio y cantidad
                        _CuerpoMensaje = Replace(_CuerpoMensaje, "<HTML_SP>", "@@HTML_SP@@") ' Html sin precio, solo cantidades

                        Sb_Llenar_Variables_Etiquetas_Documento(_Asunto, _IdMaeedo)
                        Sb_Llenar_Variables_Etiquetas_Documento(_CuerpoMensaje, _IdMaeedo)

                        _CuerpoMensaje = Replace(_CuerpoMensaje, "@@HTML@@", _Cuerpo_Html & vbCrLf)    ' Html con precio y cantidad
                        _CuerpoMensaje = Replace(_CuerpoMensaje, "@@HTML_SP@@", _Cuerpo_Html & vbCrLf) ' Html sin precio, solo cantidades

                        If Not _Es_Html Then _CuerpoMensaje = Replace(_CuerpoMensaje, Chr(13), "<br/>")

                        Dim _Correo_Enviado As Boolean
                        Dim _Destinatarios As String

                        If String.IsNullOrEmpty(_Para.Trim) Then
                            _Enviar_Correo = False
                            _Error = "El campo [Para] no puede estar vacío"
                        End If

                        If _Enviar_Correo Then

                            Dim EnviarCorreo As New Frm_Correos_Conf

                            _Para = Replace(_Para.Trim().ToLower, ",com", ".com")
                            _Para = Replace(_Para.Trim().ToLower, ",cl", ".cl")

                            '_Para = "jalfaro@bakapp.cl"

                            Dim _Mail_Valido As Boolean = Fx_Validar_Email(_Para)

                            If Not String.IsNullOrEmpty(_Cc) Then

                                Try
                                    _Cc = Replace(_Cc.Trim().ToLower, ",com", ".com")
                                    _Cc = Replace(_Cc.Trim().ToLower, ",cl", ".cl")
                                Catch ex As Exception
                                    _Cc = String.Empty
                                End Try

                            End If

                            '_Para = "jalfaro@bakapp.cl"
                            '_Cc = "alejandro.munoz@huifquenco.cl;fordenes@huifquenco.cl" '"jalfaro@bakapp.cl;jorgealfarogzlz@gmail.com"

                            _Cc = Replace(_Cc, ";" & _Para, "")
                            _Cc = Replace(_Cc, _Para & ";", "")
                            _Cc = Replace(_Cc, _Para, "")

                            '_Correo_Enviado = EnviarCorreo.Fx_Enviar_Mail2(_Host,
                            '                                              _Remitente,
                            '                                              _Contrasena,
                            '                                              _Para,
                            '                                              _Cc,
                            '                                              _Asunto,
                            '                                              _CuerpoMensaje,
                            '                                              _Archivos_Adjuntos,
                            '                                              _Puerto,
                            '                                              _SSL,
                            '                                              False)
                            Dim _Mensaje As New LsValiciones.Mensajes
                            _Mensaje = EnviarCorreo.Fx_Enviar_Mail3IMail(_Host,
                                                                _Remitente,
                                                                _Contrasena,
                                                                _Para,
                                                                _Cc,
                                                                _Asunto,
                                                                _CuerpoMensaje,
                                                                _Archivos_Adjuntos,
                                                                _Puerto,
                                                                _SSL)

                            'If _Mensaje.EsCorrecto = 0 Then
                            _Correo_Enviado = _Mensaje.EsCorrecto
                            'Else
                            '_Correo_Enviado = False
                            'End If


                            _Error = _Mensaje.Mensaje 'EnviarCorreo.Pro_Error
                            EnviarCorreo.Dispose()
                            EnviarCorreo = Nothing

                            _Destinatarios = "Para: " & _Para
                            If Not String.IsNullOrEmpty(_Cc) Then _Destinatarios = _Destinatarios & ", CC: " & _Cc

                            System.Windows.Forms.Application.DoEvents()

                            If Not _Mail_Valido Then
                                _Intentos = 3
                            End If

                        End If

                        If _Correo_Enviado Then

                            _Conteo_envio += 1

                            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo Set" & Space(1) &
                                           "Enviado = 1," &
                                           "Intentos = " & _Intentos + 1 & "," &
                                           "Fecha_Envio = Getdate()," &
                                           "Informacion = 'Envio: Ok'" & vbCrLf &
                                           "Where Id = " & _Id
                            _Sql.Ej_consulta_IDU(Consulta_Sql, False)

                            If CBool(_Id_Dte) Then

                                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set MailEnviado = 1,ErrorMailToDiablito = 0,ErrorEnviarMail = 0" & vbCrLf &
                                               "Where Id = " & _Id_Trackid
                                _Sql.Ej_consulta_IDU(Consulta_Sql, False)

                                Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_DTE_NotifxCorreo (Id_Dte,Idmaeedo,FechaEnvio,Destinatarios,Id_Trackid) Values " &
                                               "(" & _Id_Dte & "," & _IdMaeedo & ",Getdate(),'" & _Destinatarios & "'," & _Id_Trackid & ")"
                                _Sql.Ej_consulta_IDU(Consulta_Sql, False)

                            End If

                            If CBool(_Id_Acp) Then

                                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_AcpAuto Set EmailEnviado = 1, Destinatarios = 'Para: " & _Para & ",Cc: " & _Cc & "'" & vbCrLf &
                                               "Where Id = " & _Id_Acp
                                _Sql.Ej_consulta_IDU(Consulta_Sql, False)

                            End If

                            If _Existe_File Then

                                For Each _Arch_Adj As String In _Archivos_Adjuntos

                                    Try

                                        My.Computer.FileSystem.DeleteFile(_Arch_Adj,
                                                                          FileIO.UIOption.OnlyErrorDialogs,
                                                                          FileIO.RecycleOption.DeletePermanently)

                                    Catch ex As Exception
                                    End Try

                                Next

                            End If

                            Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "MAEEDO", _IdMaeedo, "Diablito",
                                               "Envio: Ok: " & _Destinatarios, "", "", _Koen, _Suen, False, "")

                        Else

                            _Conteo_Error += 1

                            Dim _Problema As String

                            _Error = Replace(_Error, "'", "''")
                            _Problema = "Problema: " & _Error

                            If _Intentos = 3 Then

                                If CBool(_Id_Dte) Then

                                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set MailEnviado = 0,ErrorEnviarMail = 1" & vbCrLf &
                                                   "Where Id = " & _Id_Trackid
                                    _Sql.Ej_consulta_IDU(Consulta_Sql)

                                End If

                                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo Set" & Space(1) &
                                               "Enviar = 0," &
                                               "Fecha_Envio = Getdate()," &
                                               "Informacion = '" & _Problema & "'" & vbCrLf &
                                               "Where Id = " & _Id
                            Else

                                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo Set" & Space(1) &
                                               "Enviar = 1," & vbCrLf &
                                               "Intentos = " & _Intentos + 1 & "," &
                                               "Fecha_Envio = Getdate()," &
                                               "Informacion = '" & _Problema & "'" & vbCrLf &
                                               "Where Id = " & _Id
                            End If

                            If _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then

                                Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "MAEEDO", _IdMaeedo, "Diablito",
                                               _Problema & " - " & _Destinatarios, "", "", _Koen, _Suen, False, "")

                            End If

                        End If

                        System.Windows.Forms.Application.DoEvents()

                        _Lbl_Estado = "Enviados " & _Conteo_envio & " de " & FormatNumber(_Tbl_Correos.Rows.Count, 0) & " (Problemas (" & _Conteo_Error & "))"

                    End If

                End If

            Next

        End If

        '_Procesando = False
        _Lbl_Estado = "Monitoreo Correos"

    End Sub

    Private Sub Sb_Preparacion_Correo_Por_Ordenes_De_Despacho()

#Region "Preparacion Correo ORDENDES De DESPACHO"

#Region "Procesos antes del cierre"

        Dim _SqlQuery_Correo = String.Empty

        Consulta_Sql = "Select Distinct Case When Desp.Id_Despacho_Padre = 0 Then Desp.Id_Despacho Else Desp.Id_Despacho_Padre End As Id_Despacho,
	                    Desp.Tipo_Envio, Desp.Tipo_Venta, Desp.Estado,Desp.Email As Para,Desp.CodFuncionario
                        From " & _Global_BaseBk & "Zw_Despachos_Estados Est
                        Inner Join " & _Global_BaseBk & "Zw_Despachos Desp On Desp.Id_Despacho = Est.Id_Despacho
                        Inner Join " & _Global_BaseBk & "Zw_Despachos_Email_Aviso Eaviso On Desp.Tipo_Envio = Eaviso.Tipo_Envio And Desp.Tipo_Venta = Eaviso.Tipo_Venta And Desp.Estado = Eaviso.Estado
                        Where Mail_Enviado = 0 And Desp.Estado <> 'CIE'"

        Dim _Tbl_Despachos As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)


        For Each _Row_Despacho As DataRow In _Tbl_Despachos.Rows

            Dim _Id_Despacho = _Row_Despacho.Item("Id_Despacho")
            Dim _Tipo_Envio = _Row_Despacho.Item("Tipo_Envio")
            Dim _Tipo_Venta = _Row_Despacho.Item("Tipo_Venta")
            Dim _Estado = _Row_Despacho.Item("Estado")

            Consulta_Sql = "Select Eaviso.Id, Tipo_Envio, Tipo_Venta, Estado, Id_Correo, Adjuntar_Documentos,Zc.*
                            From " & _Global_BaseBk & "Zw_Despachos_Email_Aviso Eaviso
                            Inner Join " & _Global_BaseBk & "Zw_Correos Zc On Eaviso.Id_Correo = Zc.Id
                            Where Tipo_Envio = '" & _Tipo_Envio & "' And Tipo_Venta = '" & _Tipo_Venta & "' And Estado = '" & _Estado & "'"

            Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            If Not IsNothing(_Row_Correo) Then

                Dim _Id_Correo As String = _Row_Correo.Item("Id_Correo")
                Dim _Nombre_Correo As String = _Row_Correo.Item("Nombre_Correo")
                Dim _CodFuncionario As String = _Row_Despacho.Item("CodFuncionario")
                Dim _Para As String = _Row_Despacho.Item("Para")
                Dim _Cc = String.Empty
                Dim _Asunto As String = _Row_Correo.Item("Asunto")
                Dim _Mensaje As String = _Row_Correo.Item("CuerpoMensaje")

                If String.IsNullOrEmpty(_Asunto) Then
                    _Asunto = "Correo de notificación de pedido " & RazonEmpresa
                End If

                Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho(_Asunto, _Id_Despacho)
                Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho(_Mensaje, _Id_Despacho)
                Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho_Documentos_Y_Detalle(_Mensaje, _Id_Despacho)

                If Not String.IsNullOrEmpty(_Nombre_Correo) Then

                    _SqlQuery_Correo += "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo (Id_Correo,Nombre_Correo,CodFuncionario,Asunto," &
                                        "Para,Cc,Idmaeedo,Tido,Nudo,NombreFormato,Enviar,Mensaje,Fecha)" &
                                        vbCrLf &
                                        "Values (" & _Id_Correo & ",'" & _Nombre_Correo & "','" & _CodFuncionario & "','" & _Asunto & "','" & _Para & "','" & _Cc &
                                        "',0,'','','',1,'" & _Mensaje & "',Getdate())" & vbCrLf & vbCrLf

                End If

            End If

        Next

        If Not String.IsNullOrEmpty(_SqlQuery_Correo) Then

            _Lbl_Estado = "Insertando datos despachos..."
            System.Windows.Forms.Application.DoEvents()

            If _Sql.Ej_consulta_IDU(_SqlQuery_Correo, False) Then

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Despachos_Estados Set Mail_Enviado = 1
                                Where Id_Estado In 
                                (Select Distinct Est.Id_Estado
                                From " & _Global_BaseBk & "Zw_Despachos_Estados Est
                                Inner Join " & _Global_BaseBk & "Zw_Despachos Desp On Desp.Id_Despacho = Est.Id_Despacho
                                Inner Join " & _Global_BaseBk & "Zw_Despachos_Email_Aviso Eaviso On Desp.Tipo_Envio = Eaviso.Tipo_Envio And Desp.Tipo_Venta = Eaviso.Tipo_Venta And Desp.Estado = Eaviso.Estado
                                Where Mail_Enviado = 0)"
                _Sql.Ej_consulta_IDU(Consulta_Sql, False)

            End If

        End If

#End Region

#Region "CIERRE"

        Consulta_Sql = "Select Distinct Case When Desp.Id_Despacho_Padre = 0 Then Desp.Id_Despacho Else Desp.Id_Despacho_Padre End As Id_Despacho,
	                    Desp.Tipo_Envio, Desp.Tipo_Venta, Desp.Estado,Desp.Email As Para,Desp.CodFuncionario,Nro_Encomienda
                        From " & _Global_BaseBk & "Zw_Despachos_Estados Est
                        Inner Join " & _Global_BaseBk & "Zw_Despachos Desp On Desp.Id_Despacho = Est.Id_Despacho
                        Inner Join " & _Global_BaseBk & "Zw_Despachos_Email_Aviso Eaviso On Desp.Tipo_Envio = Eaviso.Tipo_Envio And Desp.Tipo_Venta = Eaviso.Tipo_Venta And Desp.Estado = Eaviso.Estado
                        Where Mail_Enviado = 0 And Desp.Estado = 'CIE'"

        _Tbl_Despachos = _Sql.Fx_Get_Tablas(Consulta_Sql)

        _SqlQuery_Correo = String.Empty

        For Each _Row_Despacho As DataRow In _Tbl_Despachos.Rows

            'Dim _Id_Despacho = _Row_Despacho.Item("Id_Despacho")
            Dim _Id_Despacho_Padre = _Row_Despacho.Item("Id_Despacho")

            Dim _Nro_Despacho = _Row_Despacho.Item("Nro_Despacho")
            Dim _Nro_Encomienda = _Row_Despacho.Item("Nro_Encomienda")
            Dim _Tipo_Envio = _Row_Despacho.Item("Tipo_Envio")
            Dim _Tipo_Venta = _Row_Despacho.Item("Tipo_Venta")
            Dim _Estado = _Row_Despacho.Item("Estado")

            Consulta_Sql = "Select Eaviso.Id, Tipo_Envio, Tipo_Venta, Estado, Id_Correo, Adjuntar_Documentos,Zc.*
                            From " & _Global_BaseBk & "Zw_Despachos_Email_Aviso Eaviso
                            Inner Join " & _Global_BaseBk & "Zw_Correos Zc On Eaviso.Id_Correo = Zc.Id
                            Where Tipo_Envio = '" & _Tipo_Envio & "' And Tipo_Venta = '" & _Tipo_Venta & "' And Estado = '" & _Estado & "'"

            Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            If Not IsNothing(_Row_Correo) Then

                Dim _Id_Correo As String = _Row_Correo.Item("Id_Correo")
                Dim _Nombre_Correo As String = _Row_Correo.Item("Nombre_Correo")
                Dim _CodFuncionario As String = _Row_Despacho.Item("CodFuncionario")
                Dim _Para As String = _Row_Despacho.Item("Para")
                Dim _Cc = String.Empty
                Dim _Asunto As String = _Row_Correo.Item("Asunto")
                Dim _Mensaje As String = _Row_Correo.Item("CuerpoMensaje")

                If String.IsNullOrEmpty(_Asunto) Then
                    _Asunto = "Correo de notificación de pedido " & RazonEmpresa
                End If

                'Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho(_Asunto, _Id_Despacho)
                'Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho(_Mensaje, _Id_Despacho)

                Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho_Ordenes_Cerradas_Documentos_Y_Detalles(_Asunto, _Id_Despacho_Padre, _Nro_Encomienda)
                Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho_Ordenes_Cerradas_Documentos_Y_Detalles(_Mensaje, _Id_Despacho_Padre, _Nro_Encomienda)

                If Not String.IsNullOrEmpty(_Nombre_Correo) Then

                    _SqlQuery_Correo += "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo (Id_Correo,Nombre_Correo,CodFuncionario,Asunto," &
                                        "Para,Cc,Idmaeedo,Tido,Nudo,NombreFormato,Enviar,Mensaje,Fecha)" &
                                        vbCrLf &
                                        "Values (" & _Id_Correo & ",'" & _Nombre_Correo & "','" & _CodFuncionario & "','" & _Asunto & "','" & _Para & "','" & _Cc &
                                        "',0,'','','',1,'" & _Mensaje & "',Getdate())" & vbCrLf & vbCrLf

                End If

            End If

        Next

#End Region

        If Not String.IsNullOrEmpty(_SqlQuery_Correo) Then

            _Lbl_Estado = "Insertando datos despachos..."
            System.Windows.Forms.Application.DoEvents()

            If _Sql.Ej_consulta_IDU(_SqlQuery_Correo, False) Then

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Despachos_Estados Set Mail_Enviado = 1
                                Where Id_Estado In 
                                (Select Distinct Est.Id_Estado
                                From " & _Global_BaseBk & "Zw_Despachos_Estados Est
                                Inner Join " & _Global_BaseBk & "Zw_Despachos Desp On Desp.Id_Despacho = Est.Id_Despacho
                                Inner Join " & _Global_BaseBk & "Zw_Despachos_Email_Aviso Eaviso On Desp.Tipo_Envio = Eaviso.Tipo_Envio And Desp.Tipo_Venta = Eaviso.Tipo_Venta And Desp.Estado = Eaviso.Estado
                                Where Mail_Enviado = 0)"
                _Sql.Ej_consulta_IDU(Consulta_Sql, False)

            End If

        End If

#End Region

    End Sub

    Private Sub Sb_Correos_Automaticos_MEENMAIL()

#Region "Correos Automaticos MAEENMAIL, Adjunto de documentos a los cliente o proveedores"

        ' **********************************************************************
        ' ACA SE CREAN LAS FILAS PARA LOS ENVIOS DE CORREOS DE FORMA AUTOMATICA SEGUN LA TABLA DE MAEENMAIL

        ' MAEENEMAIL Códigos de funcionamento

        '001 Envío de correo con PDF/XML de documentos tributarios electrónicos
        '004 Informe de facturas impagas con mas de N días a fecha de emisión
        'CAM Campañas promocionales
        'ODS Envío de notificaciones por ordenes de servicio

        Dim _Fecha = Format(_Fecha_Revision, "yyyyMMdd")

        Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & vbCrLf &
                       "Where Fecha < '" & _Fecha & "' And NombreEquipo = '" & _Nombre_Equipo & "' And Enviado = 1" &
                        vbCrLf &
                        vbCrLf &
                       "Select * From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & vbCrLf &
                       "Where Enviar = 1 And Enviado = 0 And NombreEquipo In ('','" & _Nombre_Equipo & "') And Para = '' And Para_Maeenmail = 1"
        Dim _Tbl_Correos As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Dim _SqlQuery = String.Empty

        For Each _Fila As DataRow In _Tbl_Correos.Rows

            Dim _Id = _Fila.Item("Id")
            Dim _IdMaeedo = _Fila.Item("Idmaeedo")
            Dim _Para_Maeenmail = _Fila.Item("Para_Maeenmail")

            Consulta_Sql = "Select TIDO,NUDO,ENDO,SUENDO From MAEEDO Where IDMAEEDO = " & _IdMaeedo
            Dim _Row_Maeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            Dim _Koen = _Row_Maeedo.Item("ENDO")
            Dim _Suen = _Row_Maeedo.Item("SUENDO")

            'If _IdMaeedo = 2995828 Then
            '    Dim _aca = 0
            'End If

            Consulta_Sql = "Select Distinct Rtrim(Ltrim(MAILTO)) As MAILTO,Rtrim(Ltrim(MAILCC)) As MAILCC,Rtrim(Ltrim(MAILCC2)) As MAILCC2,Rtrim(Ltrim(MAILBCC)) As MAILBCC" & vbCrLf &
                           "From MAEENMAIL Where KOEN = '" & _Koen & "' And KOMAIL = '001'"

            Dim _Tbl_Maeenmail As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

            System.Windows.Forms.Application.DoEvents()

            If Convert.ToBoolean(_Tbl_Maeenmail.Rows.Count) Then

                Dim _Para As String = String.Empty
                Dim _Cc As String = String.Empty

                For Each _Fila_Mail As DataRow In _Tbl_Maeenmail.Rows

                    'If Not _Para.Contains(_Fila_Mail.Item("MAILTO").ToString.Trim) Then
                    '    If String.IsNullOrEmpty(_Para) Then
                    '        _Para = _Fila_Mail.Item("MAILTO").ToString.Trim
                    '    Else
                    '        _Para += ";" & Trim(_Fila_Mail.Item("MAILTO"))
                    '    End If
                    'End If
                    _Para += _Fila_Mail.Item("MAILTO").ToString.Trim & ";"

                    If Not String.IsNullOrWhiteSpace(_Fila_Mail.Item("MAILCC").ToString.Trim) Then

                        'If String.IsNullOrEmpty(_Cc) Then
                        '    _Cc = _Fila_Mail.Item("MAILCC").ToString.Trim
                        'Else
                        '    _Cc += ";" & _Fila_Mail.Item("MAILCC").ToString.Trim
                        'End If

                        _Cc += _Fila_Mail.Item("MAILCC").ToString.Trim & ";"

                        If Not String.IsNullOrWhiteSpace(_Fila_Mail.Item("MAILCC2").ToString.Trim) Then
                            '_Cc += ";" & _Fila_Mail.Item("MAILCC2").ToString.Trim
                            _Cc += _Fila_Mail.Item("MAILCC2").ToString.Trim & ";"
                            If Not String.IsNullOrWhiteSpace(_Fila_Mail.Item("MAILBCC").ToString.Trim) Then
                                '_Cc += ";" & _Fila_Mail.Item("MAILBCC").ToString.Trim
                                _Cc += _Fila_Mail.Item("MAILBCC").ToString.Trim & ";"
                            End If
                        End If

                    End If

                Next

                _Para = Fx_QuitarDuplicadosCorreo(_Para.Trim())
                _Cc = Fx_QuitarDuplicadosCorreo(_Cc.Trim())

                _SqlQuery += "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo (NombreEquipo,Nombre_Correo,CodFuncionario,Asunto," &
                             "Para,Cc,Idmaeedo,Tido,Nudo,NombreFormato,Enviar,Intentos,Enviado,Adjuntar_Documento,Mensaje,Fecha,Informacion,Para_Maeenmail)" &
                             vbCrLf &
                             "Select '" & _Nombre_Equipo & "',Nombre_Correo,CodFuncionario,Asunto,'" & _Para & "','" & _Cc & "',Idmaeedo,Tido,Nudo,NombreFormato,Enviar," &
                             "Intentos,Enviado,Adjuntar_Documento,Mensaje,Fecha,Informacion,Para_Maeenmail" & vbCrLf &
                             "From " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo" & vbCrLf &
                             "Where Id = " & _Id & vbCrLf & vbCrLf

            Else

                Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Log_Gestiones",
                                                    "Archirst = 'MAEEDO' And Idrst = " & _IdMaeedo & " And" & Space(1) &
                                                    "Accion = 'Correo no enviado. Motivo: La entidad no tiene correos asociados en tabla MAEENMAIL' And" & Space(1) &
                                                    "Fecha_Hora >= '" & Format(_Fecha_Revision, "yyyyMMdd") & "'")
                If _Reg = 0 Then
                    Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "MAEEDO", _IdMaeedo, "Diablito",
                                   "Correo no enviado. Motivo: La entidad no tiene correos asociados en tabla MAEENMAIL", "", "", _Koen, _Suen, False, "")
                End If

            End If

        Next

        If Not String.IsNullOrEmpty(_SqlQuery) Then
            _Sql.Ej_consulta_IDU(_SqlQuery)
        End If

        Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo Where Para = '' And NombreEquipo In ('','" & _Nombre_Equipo & "') And Para_Maeenmail = 1"
        _Sql.Ej_consulta_IDU(Consulta_Sql)

#End Region

    End Sub

    Function Fx_QuitarDuplicadosCorreo(_CadenaDeCorreos As String) As String

        ' Dividir la cadena en correos electrónicos individuales
        Dim _Correos As String() = _CadenaDeCorreos.Split(";"c)

        ' Eliminar duplicados
        Dim correosUnicos As List(Of String) = _Correos.Distinct().ToList()

        ' Unir los correos electrónicos únicos nuevamente en una cadena
        Dim _Resultado As String = String.Join(";", correosUnicos)

        If Not String.IsNullOrWhiteSpace(_Resultado) Then
            _Resultado = _Resultado.Substring(0, _Resultado.Length - 1)
        End If

        Return _Resultado

    End Function

    Sub Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho(ByRef _Texto As String, _Id_Despacho As Integer)

        If Convert.ToBoolean(_Id_Despacho) Then

            Dim _Cl_Despacho As New Clas_Despacho(False)
            _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

            Dim _Row_Despacho = _Cl_Despacho.Row_Despacho

            _Texto = Replace(_Texto, "<Despacho_Nro_Despacho>", Fx_Parametro_Vs_Variable("<Despacho_Nro_Despacho>", _Row_Despacho))
            _Texto = Replace(_Texto, "<Despacho_Nombre_Entidad>", Fx_Parametro_Vs_Variable("<Despacho_Nombre_Entidad>", _Row_Despacho))

            _Texto = Replace(_Texto, "<Despacho_Transportista>", Fx_Parametro_Vs_Variable("<Despacho_Transportista>", _Row_Despacho))
            _Texto = Replace(_Texto, "<Despacho_Nro_Encomienda>", Fx_Parametro_Vs_Variable("<Despacho_Nro_Encomienda>", _Row_Despacho))

        End If

    End Sub

    Sub Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho_Documentos_Y_Detalle(ByRef _Texto As String, _Id_Despacho As Integer)

        If Convert.ToBoolean(_Id_Despacho) Then

            Dim _Cl_Despacho As New Clas_Despacho(False)
            _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)

            Dim _Row_Despacho = _Cl_Despacho.Row_Despacho

            Dim _Documentos As String
            Dim _Contador = 0

            For Each _Fila As DataRow In _Cl_Despacho.Tbl_Despacho_Doc.Rows

                _Documentos += _Fila.Item("Tido") & "-" & _Fila.Item("Nudo")

                _Contador += 1

                If _Contador <> _Cl_Despacho.Tbl_Despacho_Doc.Rows.Count Then
                    _Documentos += ", "
                End If

            Next

            Dim _Detalle_Despacho As String

            For Each _FilaE As DataRow In _Cl_Despacho.Tbl_Despacho_Doc.Rows

                Dim _Tido_Nudo = _FilaE.Item("Tido") & "-" & _FilaE.Item("Nudo")
                Dim _Idmaeedo = _FilaE.Item("Idrst")

                For Each _FilaD As DataRow In _Cl_Despacho.Tbl_Despacho_Doc_Det.Rows

                    Dim _IdmaeedoD = _FilaD.Item("Idmaeedo")
                    Dim _Codigo = _FilaD.Item("Codigo")
                    Dim _Descripcion = _FilaD.Item("Descripcion")

                    Dim _DespUd1 = _FilaD.Item("DespUd1")
                    Dim _DespUd2 = _FilaD.Item("DespUd2")

                    If _Idmaeedo = _IdmaeedoD Then

                        _Detalle_Despacho += vbTab & " * " & _Codigo & " - " & _Descripcion & " X " & _DespUd1 & vbCrLf

                    End If

                Next

            Next

            _Texto = Replace(_Texto, "<Despacho_Documentos>", _Documentos)
            _Texto = Replace(_Texto, "<Despacho_Detalle_Despacho>", _Detalle_Despacho)

        End If

    End Sub

    Sub Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho_Ordenes_Cerradas_Documentos_Y_Detalles(ByRef _Texto As String,
                                                                            _Id_Despacho_Padre As Integer,
                                                                            _Nro_Encomienda As String)

        Dim _Documentos As String
        Dim _Detalle_Despacho As String


        Consulta_Sql = "Select Distinct Id_Despacho 
                        From " & _Global_BaseBk & "Zw_Despachos
                        Where (Id_Despacho_Padre = " & _Id_Despacho_Padre & " Or Id_Despacho = " & _Id_Despacho_Padre & ")" &
                        " And Nro_Encomienda = '" & _Nro_Encomienda & "'"
        Dim _Tbl_Despachos As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        For Each _Despacho As DataRow In _Tbl_Despachos.Rows

            Dim _Id_Despacho As Integer = _Despacho.Item("Id_Despacho")


            Sb_Llenar_Variables_Etiquetas_Ordenes_De_Despacho(_Texto, _Id_Despacho)


            If Convert.ToBoolean(_Id_Despacho) Then

                Dim _Cl_Despacho As New Clas_Despacho(False)
                _Cl_Despacho.Sb_Cargar_Despacho(_Id_Despacho)
                Dim _Row_Despacho As DataRow = _Cl_Despacho.Row_Despacho

                _Row_Despacho = _Cl_Despacho.Row_Despacho

                Dim _Contador = 0

                If Not String.IsNullOrEmpty(_Documentos) Then
                    _Documentos += ", "
                End If

                For Each _Fila As DataRow In _Cl_Despacho.Tbl_Despacho_Doc.Rows

                    _Documentos += _Fila.Item("Tido") & "-" & _Fila.Item("Nudo")

                    _Contador += 1

                    If _Contador <> _Cl_Despacho.Tbl_Despacho_Doc.Rows.Count Then
                        _Documentos += ", "
                    End If

                Next

                For Each _FilaE As DataRow In _Cl_Despacho.Tbl_Despacho_Doc.Rows

                    Dim _Tido_Nudo = _FilaE.Item("Tido") & "-" & _FilaE.Item("Nudo")
                    Dim _Idmaeedo = _FilaE.Item("Idrst")

                    For Each _FilaD As DataRow In _Cl_Despacho.Tbl_Despacho_Doc_Det.Rows

                        Dim _IdmaeedoD = _FilaD.Item("Idmaeedo")
                        Dim _Codigo = _FilaD.Item("Codigo")
                        Dim _Descripcion = _FilaD.Item("Descripcion")

                        Dim _DespUd1 = _FilaD.Item("DespUd1")
                        Dim _DespUd2 = _FilaD.Item("DespUd2")

                        If _Idmaeedo = _IdmaeedoD Then

                            _Detalle_Despacho += Space(5) & " * (" & _Tido_Nudo & "), " & _Codigo & " - " & _Descripcion & " X " & _DespUd1 & vbCrLf

                        End If

                    Next

                Next

            End If

        Next

        _Texto = Replace(_Texto, "<Despacho_Documentos>", _Documentos)
        _Texto = Replace(_Texto, "<Despacho_Detalle_Despacho>", _Detalle_Despacho)

    End Sub

    Sub Sb_Llenar_Variables_Etiquetas_Documento(ByRef _Texto As String, _Idmaeedo As Integer)

        Try
            If Convert.ToBoolean(_Idmaeedo) Then

                ' Esto reemplaza variables antiguas

                _Texto = Replace(_Texto, "Doc_Razon", "RAZON")
                _Texto = Replace(_Texto, "RAZON_CLIENTE", "RAZON")
                _Texto = Replace(_Texto, "FOLIO", "NUDO")
                _Texto = Replace(_Texto, "Doc_Razon", "RAZON")
                _Texto = Replace(_Texto, "Doc_Tido", "TIDO")
                _Texto = Replace(_Texto, "Doc_Nudo", "NUDO")
                _Texto = Replace(_Texto, "Doc_Feemdo", "FEEMDO")
                _Texto = Replace(_Texto, "Doc_Vabrdo", "VABRDO")

                _Texto = Replace(_Texto, "<RazonEmpresa>", RazonEmpresa)
                _Texto = Replace(_Texto, "<EMPRESAEMI>", RazonEmpresa)
                _Texto = Replace(_Texto, "<RutEmpresa>", RutEmpresa)
                _Texto = Replace(_Texto, "<RutEmpresaActiva>", RutEmpresaActiva)

                Dim _Dv, _Rut, _RutEmpresaCP, _RutEmpresaActivaCP As String

                _Rut = RutEmpresa
                If _Rut.Contains("-") Then
                    Dim _Rt = Split(_Rut, "-")
                    _Rut = _Rt(0)
                End If
                Try
                    _Dv = RutDigito(_Rut)
                    _Rut = FormatNumber(_Rut, 0) & "-" & _Dv
                Catch ex As Exception
                    _Rut = _Rut
                End Try
                _RutEmpresaCP = _Rut

                _Rut = RutEmpresaActiva
                If _Rut.Contains("-") Then
                    Dim _Rt = Split(_Rut, "-")
                    _Rut = _Rt(0)
                End If
                Try
                    _Dv = RutDigito(_Rut)
                    _Rut = FormatNumber(_Rut, 0) & "-" & _Dv
                Catch ex As Exception
                    _Rut = _Rut
                End Try
                _RutEmpresaActivaCP = _Rut

                _Texto = Replace(_Texto, "<RutEmpresaCP>", _RutEmpresaCP)
                _Texto = Replace(_Texto, "<RutEmpresaActivaCP>", _RutEmpresaActivaCP)


                _Texto = Replace(_Texto, "&lt;", "<")
                _Texto = Replace(_Texto, "&gt;", ">")

                Consulta_Sql = Replace(My.Resources.Recursos_Ver_Documento.Traer_Documento_Random, "#Idmaeedo#", _Idmaeedo)
                Dim _Datos_Documento = _Sql.Fx_Get_DataSet(Consulta_Sql)

                Dim _Row_Encabezado = _Datos_Documento.Tables(0).Rows(0)

                Dim _Funciones As New List(Of String)
                Dim _FuncionesNoEncontradas As New List(Of String)

                Sb_Llenar_Listado_Funciones(0, _Texto, _Funciones)

                For Each _Funcion As String In _Funciones

                    Dim _Row As DataRow

                    _Row = _Row_Encabezado
                    If Not IsNothing(_Row) Then
                        If Not Fx_Encontrar_Funcion(_Row, _Funcion, _Texto, True) Then
                            Fx_Encontrar_Funcion(_Row, _Funcion, _Texto, False)
                        End If
                    End If

                    Dim _Endo = _Row_Encabezado.Item("ENDO")
                    Dim _Suendo = _Row_Encabezado.Item("SUENDO")

                    Dim _Row_Entidad As DataRow = Fx_Traer_Datos_Entidad(_Endo, _Suendo)

                    _Row = _Row_Entidad
                    If Not IsNothing(_Row) Then
                        If Not Fx_Encontrar_Funcion(_Row, _Funcion, _Texto, True) Then
                            Fx_Encontrar_Funcion(_Row, _Funcion, _Texto, False)
                        End If
                    End If

                    Consulta_Sql = "Select * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo
                    Dim _Row_Observaciones As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    _Row = _Row_Observaciones
                    If Not IsNothing(_Row) Then
                        If Not Fx_Encontrar_Funcion(_Row, _Funcion, _Texto, True) Then
                            Fx_Encontrar_Funcion(_Row, _Funcion, _Texto, False)
                        End If
                    End If

                Next

            End If
        Catch ex As Exception

        End Try


    End Sub

    Function Fx_Encontrar_Funcion(_Row As DataRow, _Funcion As String, ByRef _Texto As String, _Exacta As Boolean) As Boolean

        For Each _Columna As DataColumn In _Row.Table.Columns

            Dim _FunEncontrada = False

            If _Exacta Then
                If _Funcion.Trim = _Columna.ColumnName.Trim Then
                    _FunEncontrada = True
                End If
            Else
                If _Funcion.Contains(_Columna.ColumnName) Then
                    _FunEncontrada = True
                End If
            End If

            If _FunEncontrada Then
                Dim _Funcion_Buscar = "<" & _Funcion & ">"
                Dim _Valor_Funcion = Fx_Parametro_Vs_Variable(_Funcion_Buscar, _Row)

                _Texto = Replace(_Texto, _Funcion_Buscar, _Valor_Funcion)
                Exit For
            End If

        Next

    End Function

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

                        If Not _Funcion.Contains("/") And _Funcion <> "div" And _Funcion <> "br" And _Funcion <> "body" And _Funcion <> "title" And _Funcion <> "br /" And _Funcion <> "!DOCTYPE html" And _Funcion <> "html" And _Funcion <> "head" And Not _Funcion.Contains("""") Then
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

    Private Function Fx_Parametro_Vs_Variable(_Parametro As String, _Row As DataRow) As String

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

                    _Valor_Devuelto = NuloPorNro(_Valor.ToString.Trim, "")

                    If _Rango_Hasta > _Rango_Desde Then
                        _Valor_Devuelto = Mid(_Valor_Devuelto, _Rango_Desde, _Rango_Hasta)
                    End If

                End If

            Catch ex As Exception
                _Valor_Devuelto = _Campo & " -> Función desconocida"
            End Try

        Catch ex As Exception
            _Valor_Devuelto = ex.Message & "... Error en función: " & _Parametro
        End Try

        Return _Valor_Devuelto

    End Function


End Class
