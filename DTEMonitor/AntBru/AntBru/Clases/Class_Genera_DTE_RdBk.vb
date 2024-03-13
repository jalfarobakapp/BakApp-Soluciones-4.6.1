Imports System.Collections
Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Threading
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.XPath
Imports DevComponents.DotNetBar
Imports HEFESTO.FIRMA.DOC.FORM
Imports HEFESTO.FIRMA.DOCUMENTO
Imports HefestoCesionV12
Imports Ionic.Zip

Public Class Class_Genera_DTE_RdBk

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Configp As DataRow
    Dim _Row_Ffolios As DataRow

    Dim _Ds_Documento As DataSet

    Dim _Maeedo As DataTable
    Dim _Maeddo As DataTable
    Dim _Maeedoob As DataTable
    Dim _Maeen As DataTable
    Dim _RowMaeenEmisor As DataRow
    Dim _Referencias_DTE As DataTable

    Dim _Idmaeedo As Integer
    Dim _Directorio_GenDTE As String

    Dim _Nro_Documento As String

    Dim _Iddte As Integer

    Dim _Formulario As Form

    Dim _Errores As List(Of String)

    Dim _Path As String = AppPath() & "\Data\Dte"

    Dim _UriSchemaDte As String
    Dim _UriSchemaDteSf As String
    Dim _UriSchemaEnvioDteSf As String
    Dim _UriSchemaEnvioDte As String

    Dim _Incorporar_Observaciones_En_DTE As Boolean

    Dim _Id_Dte As Integer
    Dim _Trackid As String
    Dim _Respuesta As String

    Dim _AmbienteCertificacion As Integer

    Public Property Pro_Formulario() As Form
        Get
            Return _Formulario
        End Get
        Set(value As Form)
            _Formulario = value
        End Set
    End Property

    Public ReadOnly Property Pro_Nro_Documento() As String
        Get
            Return _Nro_Documento
        End Get
    End Property

    Public ReadOnly Property Pro_Iddte() As Integer
        Get
            Return _Iddte
        End Get
    End Property

    Public Property Pro_Errores As List(Of String)
        Get
            Return _Errores
        End Get
        Set(value As List(Of String))
            _Errores = value
        End Set
    End Property

    Public Property Pro_Incorporar_Observaciones_En_DTE As Boolean
        Get
            Return _Incorporar_Observaciones_En_DTE
        End Get
        Set(value As Boolean)
            _Incorporar_Observaciones_En_DTE = value
        End Set
    End Property

    Public Property Id_Dte As Integer
        Get
            Return _Id_Dte
        End Get
        Set(value As Integer)
            _Id_Dte = value
        End Set
    End Property

    Public Property Trackid As String
        Get
            Return _Trackid
        End Get
        Set(value As String)
            _Trackid = value
        End Set
    End Property

    Public Property Respuesta As String
        Get
            Return _Respuesta
        End Get
        Set(value As String)
            _Respuesta = value
        End Set
    End Property

    Public Property Maeedo As DataTable
        Get
            Return _Maeedo
        End Get
        Set(value As DataTable)
            _Maeedo = value
        End Set
    End Property

    Public Property Maeddo As DataTable
        Get
            Return _Maeddo
        End Get
        Set(value As DataTable)
            _Maeddo = value
        End Set
    End Property

    Public Property Maeedoob As DataTable
        Get
            Return _Maeedoob
        End Get
        Set(value As DataTable)
            _Maeedoob = value
        End Set
    End Property

    Public Property Maeen As DataTable
        Get
            Return _Maeen
        End Get
        Set(value As DataTable)
            _Maeen = value
        End Set
    End Property

    Public Property AmbienteCertificacion As Integer
        Get
            Return _AmbienteCertificacion
        End Get
        Set(value As Integer)
            _AmbienteCertificacion = value
        End Set
    End Property

    Public Sub New(Idmaeedo As Integer)

        _Errores = New List(Of String)

        If Not Directory.Exists(_Path) Then
            System.IO.Directory.CreateDirectory(_Path)
        End If

        If Not Directory.Exists(_Path & "\Schemas") Then
            System.IO.Directory.CreateDirectory(_Path & "\Schemas")
        End If

        _UriSchemaDte = _Path & "\Schemas\DTE_v10.xsd"
        _UriSchemaDteSf = _Path & "\Schemas\DTE_v10_Sf.xsd"
        _UriSchemaEnvioDteSf = _Path & "\Schemas\EnvioDTE_v10_Sf.xsd"
        _UriSchemaEnvioDte = _Path & "\Schemas\EnvioDTE_v10.xsd"

        _AmbienteCertificacion = Convert.ToInt32(_Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion"))

        _Iddte = 0

        _Idmaeedo = Idmaeedo
        _Directorio_GenDTE = _Global_Row_EstacionBk.Item("Directorio_GenDTE") 'Directorio_GenDTE

        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo & Environment.NewLine &
                       "Select * From MAEDDO Where IDMAEEDO = " & _Idmaeedo & " Order by IDMAEDDO" & Environment.NewLine &
                       "Select * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo & Environment.NewLine &
                       "--Select Distinct 0 As Id_Ref,0 As NroLinRef,Id_Doc,Tido,Nudo,TpoDocRef,FolioRef,RUTOt,IdAdicOtr,FchRef,CodRef,RazonRef From " & _Global_BaseBk & "Zw_Referencias_Dte Where Id_Doc = " & _Idmaeedo & " And Kasi = 0" & vbCrLf &
                       "--Select Top 1 * From " & _Global_BaseBk & "Zw_Referencias_Dte Where 1<0"

        _Ds_Documento = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Maeedo = _Ds_Documento.Tables(0)
        _Maeddo = _Ds_Documento.Tables(1)
        _Maeedoob = _Ds_Documento.Tables(2)
        '_Referencias_DTE = _Ds_Documento.Tables(3)

        If Not CBool(_Maeedo.Rows.Count) Then
            _Maeedo = Nothing
            _Maeddo = Nothing
            _Maeedoob = Nothing
            Return
        End If

        Sb_Crear_Referencias()

        Dim _Koen = _Maeedo.Rows(0).Item("ENDO")
        Dim _Suen = _Maeedo.Rows(0).Item("SUENDO")

        _Maeen = Fx_Traer_Datos_Entidad_Tabla(_Koen, _Suen)

        Dim _RutEmpresa
        Dim _Rten

        If _Maeen.Rows.Count = 0 Then

            If _Maeedo.Rows(0).Item("TIDO") = "GDP" Or _Maeedo.Rows(0).Item("TIDO") = "GTI" Then

                _RutEmpresa = _Global_Row_Empresa.Item("Rut")
                _Rten = Split(_RutEmpresa, "-")

                Dim _RowEntidad As DataRow

                Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _RutEmpresa & "' And TIPOSUC = 'P'"
                _RowEntidad = _Sql.Fx_Get_DataRow(Consulta_sql)

                If IsNothing(_RowEntidad) Then
                    Consulta_sql = "Select Top 1 * From MAEEN Where KOEN LIKE '" & _Rten(0) & "%' AND RTEN = '" & _Rten(0) & "' And TIPOSUC = 'P'"
                    _RowEntidad = _Sql.Fx_Get_DataRow(Consulta_sql)
                End If

                If IsNothing(_RowEntidad) Then
                    Consulta_sql = "Select Top 1 * From MAEEN Where KOEN LIKE '" & _Rten(0) & "%' And TIPOSUC = 'P'"
                    _RowEntidad = _Sql.Fx_Get_DataRow(Consulta_sql)
                End If

                If Not IsNothing(_RowEntidad) Then
                    _Koen = _RowEntidad.Item("KOEN")
                    _Suen = _RowEntidad.Item("SUEN")
                    _Maeen = Fx_Traer_Datos_Entidad_Tabla(_Koen, _Suen)
                End If

            End If

        End If

        If Not IsNothing(_Global_Row_Empresa) Then

            _RutEmpresa = _Global_Row_Empresa.Item("Rut")
            _Rten = Split(_RutEmpresa, "-")

            Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _RutEmpresa & "' And TIPOSUC = 'P'"
            _RowMaeenEmisor = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_RowMaeenEmisor) Then
                Consulta_sql = "Select Top 1 * From MAEEN Where KOEN LIKE '" & _Rten(0) & "%' AND RTEN = '" & _Rten(0) & "' And TIPOSUC = 'P'"
                _RowMaeenEmisor = _Sql.Fx_Get_DataRow(Consulta_sql)
            End If

            If IsNothing(_RowMaeenEmisor) Then
                Consulta_sql = "Select Top 1 * From MAEEN Where KOEN LIKE '" & _Rten(0) & "%' And TIPOSUC = 'P'"
                _RowMaeenEmisor = _Sql.Fx_Get_DataRow(Consulta_sql)
            End If

            If Not IsNothing(_RowMaeenEmisor) Then
                _Koen = _RowMaeenEmisor.Item("KOEN")
                _Suen = _RowMaeenEmisor.Item("SUEN")
                _RowMaeenEmisor = Fx_Traer_Datos_Entidad(_Koen, _Suen)
            End If

        End If

        Dim _Firma_Bakapp As Boolean

        Try
            _Firma_Bakapp = _Global_Row_Configuracion_General.Item("FacElec_Bakapp_Hefesto")
        Catch ex As Exception

        End Try

        If _Firma_Bakapp And File.Exists(AppPath() & "\Dte.zip") Then

            Dim _AppPath = AppPath()

            If Not Directory.Exists(_AppPath & "\Data\Dte") Then
                System.IO.Directory.CreateDirectory(_AppPath & "\Data\Dte")
            End If

            If Not Directory.Exists(_AppPath & "\DocumentosSII") Then
                System.IO.Directory.CreateDirectory(_AppPath & "\DocumentosSII")
            End If

            If Not Directory.Exists(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE") Then
                System.IO.Directory.CreateDirectory(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE")
            End If

            If Not Directory.Exists(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Documentos") Then
                System.IO.Directory.CreateDirectory(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Documentos")
            End If

            If Not Directory.Exists(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Documentos\Boleta") Then
                System.IO.Directory.CreateDirectory(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Documentos\Boleta")
            End If

            Dim _Fullpath = _AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Documentos"

            If Not Directory.Exists(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto") Then
                System.IO.Directory.CreateDirectory(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto")
            End If

            If Not Directory.Exists(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF") Then
                System.IO.Directory.CreateDirectory(_AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF")
            End If

            Try

                Using Zip As ZipFile = ZipFile.Read(_AppPath & "\Dte.zip")
                    Zip.ExtractAll(AppPath())
                End Using

                'RarArchive.WriteToDirectory(_AppPath & "\Dte.Rar", AppPath() & "\Dte", ExtractOptions.Overwrite)

                'Copiamos la carpeta DocumentosSII en la raiz del sistema
                My.Computer.FileSystem.CopyDirectory(AppPath() & "\Dtes\DocumentosSII", _AppPath & "\DocumentosSII", True)
                'Copiamos la carpeta Dte dentro de la carpeta Data
                My.Computer.FileSystem.CopyDirectory(AppPath() & "\Dtes\Dte", _AppPath & "\Data\Dte", True)
                'Copiamos la carpeta Documentos dentro de la carpete DTE de la empresa
                My.Computer.FileSystem.CopyDirectory(AppPath() & "\Dtes\Documentos", _AppPath & "\Data\" & RutEmpresaActiva & "\DTE\Documentos", True)

                My.Computer.FileSystem.DeleteDirectory(AppPath() & "\Dtes", FileIO.DeleteDirectoryOption.DeleteAllContents)
            Catch ex As Exception

            End Try

        End If

    End Sub

    Sub Sb_Crear_Referencias()

        'DTEANUFCV 	Anular Factura de Venta                           
        'DTEANUNCV 	Anular Nota de Credito                            
        'DTECORGIR 	Corrige Texto de Otro Documento                   
        'DTECORMON 	Corrige Monto de Otro Documento                   
        'DTEDEVMER 	Devolucion de Mercaderias
        '
        Try

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Referencias_Dte Where 1<0"
            _Referencias_DTE = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Referencias As New Class_Referencias_DTE(_Idmaeedo)
            _Referencias.Tbl_Referencias = _Referencias_DTE

            If _Maeedo.Rows(0).Item("TIDO") = "NCV" Or _Maeedo.Rows(0).Item("TIDO") = "FDV" Then

                Consulta_sql = "Select Distinct ARCHIRVE,IDRVE,KOTABLA," &
                               "Case KOCARAC " &
                               "When 'DTEANUFCV' Then 1 " &
                               "When 'DTECORGIR' Then 2 " &
                               "When 'DTECORMON' Then 3 " &
                               "When 'DTEDEVMER' Then 3 " &
                               "Else 0 End As 'CodRefm'," &
                               "KOCARAC,NOKOCARAC,NOKOCARAC As 'RazonRef',ISNULL(ARCHIRSE,'')AS ARCHIRSE,ISNULL(IDRSE,0) AS IDRSE,LINK,KOFUDEST," &
                               "Isnull(Edo.IDMAEEDO,0) As IDMAEEDO,Isnull(Edo.TIDO,'') As TIDO,Isnull(Edo.NUDO,'') As NUDO,Isnull(Edo.FEEMDO,Getdate()) As FEEMDO
                                From MEVENTO Mv
                                Left Join MAEEDO Edo On Edo.IDMAEEDO = ISNULL(IDRSE,0)
                                Where ARCHIRVE='MAEEDO' And IDRVE= " & _Idmaeedo
                Dim _TblRefNCV As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                For Each _Fila As DataRow In _TblRefNCV.Rows

                    Dim _Idmaeedo As Integer = _Fila.Item("IDMAEEDO")

                    If CBool(_Idmaeedo) Then

                        Dim _Tido As String = _Fila.Item("TIDO")
                        Dim _Nudo As String = _Fila.Item("NUDO")

                        Dim _NroLinRef = _Referencias_DTE.Rows.Count + 1
                        Dim _TpoDocRef = Fx_Tipo_DTE_VS_TIDO(_Fila.Item("TIDO"))
                        Dim _FolioRef = Convert.ToInt32(_Fila.Item("NUDO"))
                        Dim _RUTOt = String.Empty
                        Dim _IdAdicOtr = String.Empty
                        Dim _FchRef As Date = _Fila.Item("FEEMDO")
                        Dim _CodRef As Integer = _Fila.Item("CodRefm")
                        Dim _RazonRef = _Fila.Item("RazonRef")

                        _Referencias.Fx_Row_Nueva_Referencia(0, _Idmaeedo, _Tido, _Nudo, _NroLinRef, _TpoDocRef, _FolioRef, _RUTOt, _IdAdicOtr, _FchRef, _CodRef, _RazonRef)

                    End If

                Next

            End If

            If _Maeedo.Rows(0).Item("TIDO") = "FCV" Or _Maeedo.Rows(0).Item("TIDO") = "GDV" Or _Maeedo.Rows(0).Item("TIDO") = "GDP" Then

                Dim _In = "''"

                If _Maeedo.Rows(0).Item("TIDO") = "FCV" Then
                    _In = "'GDV','GDP'"
                Else
                    _In = "'FCV'"
                End If

                Consulta_sql = "Select IDMAEEDO,TIDO,NUDO,FEEMDO 
                            From MAEEDO 
                            Where IDMAEEDO In (Select IDMAEEDO From MAEDDO Where IDMAEDDO In (Select IDRST From MAEDDO Where IDMAEEDO = " & _Idmaeedo & "))
                            And TIDO In (" & _In & ") And TIDOELEC = 1"
                Dim _FRef As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                For Each _Fila As DataRow In _FRef.Rows

                    Dim _Idmaeedo As Integer = _Fila.Item("IDMAEEDO")
                    Dim _Tido As String = _Fila.Item("TIDO")
                    Dim _Nudo As String = _Fila.Item("NUDO")

                    Dim _NroLinRef = _Referencias_DTE.Rows.Count + 1
                    Dim _TpoDocRef = Fx_Tipo_DTE_VS_TIDO(_Fila.Item("TIDO"))
                    Dim _FolioRef = _Fila.Item("NUDO")
                    Dim _RUTOt = String.Empty
                    Dim _IdAdicOtr = String.Empty
                    Dim _FchRef As Date = _Fila.Item("FEEMDO")

                    _Referencias.Fx_Row_Nueva_Referencia(0, _Idmaeedo, _Tido, _Nudo, _NroLinRef, _TpoDocRef, _FolioRef, _RUTOt, _IdAdicOtr, _FchRef, 0, "")

                Next

            End If

            If _Maeedo.Rows(0).Item("TIDO") = "FCV" And CBool(_Maeedoob.Rows.Count) Then

                Dim _Ocdo As String = _Maeedoob.Rows(0).Item("OCDO").ToString.Trim

                If Not String.IsNullOrEmpty(_Ocdo) Then

                    Dim _NroLinRef = _Referencias_DTE.Rows.Count + 1
                    Dim _TpoDocRef = Fx_Tipo_DTE_VS_TIDO("OCC")
                    Dim _FolioRef = _Ocdo
                    Dim _RUTOt = String.Empty
                    Dim _IdAdicOtr = String.Empty
                    Dim _FchRef As Date = _Maeedo.Rows(0).Item("FEEMDO")
                    Dim _RazonRef = "ORDEN DE COMPRA"

                    _Referencias.Fx_Row_Nueva_Referencia(0, _Idmaeedo, "OCC", _FolioRef, _NroLinRef, _TpoDocRef, _FolioRef, _RUTOt, _IdAdicOtr, _FchRef, 0, _RazonRef)

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Function Fx_Dte_Genera_Documento(_Formulario As Form, _Reenviar As Boolean) As Integer

        '_Global_Row_EstacionBk.Item("Directorio_GenDTE")

        Dim _Tido As String = _Maeedo.Rows(0).Item("TIDO")
        Dim _Nudo As String = _Maeedo.Rows.Item(0).Item("NUDO")

        If Not _Reenviar Then
            If Not Fx_Revisar_Expiracion_Folio_SII(_Formulario, _Tido, _Nudo, True) Then
                Return 0
            End If
        End If

        Dim _Xml As String
        _Xml = Fx_Crear_Archivo_XML(_Formulario)

        If String.IsNullOrEmpty(_Xml) Then
            Return 0
        End If

        'If Validar_Schema(_uriDteResultado, _UriSchemaDte) Then

        'End If

        'If Fx_Validar_Schema(_uriDteResultado, _UriSchemaEnvioDte) Then

        'End If

        Dim _Iddt As Integer
        Dim _Endo = _Maeedo.Rows(0).Item("ENDO")

        Dim myTrans As SqlTransaction
        Dim Comando As SqlCommand


        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            Consulta_sql = "INSERT INTO FPASODT (XML,IDMAEEDO,TIDO,NUDO,ENDO) Values " &
                           "('" & _Xml & "'," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "','" & _Endo & "')"

            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                _Iddt = dfd1("Identity")
            End While
            dfd1.Close()

            myTrans.Commit()

            Return _Iddt

        Catch ex As Exception

            _Nro_Documento = String.Empty
            myTrans.Rollback()
            _Errores.Add(ex.Message)
            'MessageBoxEx.Show(ex.Message)

        Finally

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

    End Function

    Function Fx_Dte_Firma(_Formulario As Form,
                          _Iddt As Integer,
                          _Reenvio As Boolean) As Integer

        '-- SI NO ES RECEPTOR ELECTRONICO EL RUTRECEP = '60803000-K'
        '-- KOPET = 10 FACTURA, 12 BOLETA

        'INSERT INTO FMAEPETE (KOPET,RUTEMI,RUTENVI,RUTRECEP,FRESOL,NRESOL,EMPRESA)  VALUES (10,'79514800-0' ,'12628844-1' ,'60803000-K' ,{d '2012-06-19'} ,'72', '01' ) 
        '--SELECT @@IDENTITY AS ULTID

        'Set @IDPET = (SELECT @@IDENTITY AS ULTID)
        'INSERT INTO FMAEPETD (IDPET,IDDTE) VALUES (@IDPET,0)

        'Dim _Icono As Image = My.Resources.Recursos_DTE.script_edit
        Dim _Koen As String = _Maeen.Rows(0).Item("KOEN")

        Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "' And TIPOSUC = 'P'"
        Dim _RowMaeen As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Idmaeen As Integer
        Dim _Recepelect As Boolean
        Dim _Email As String

        Dim _Nuevo_RunMonitor As Boolean = _Sql.Fx_Exite_Campo("CONFIGP", "VERSIONACT")

        If _Nuevo_RunMonitor Then
            If Not Fx_Ejecutar_GenDTE_BAT_NewRunmonitor(_Formulario, _Directorio_GenDTE, _Iddt) Then
                Return 0
            End If
        Else
            If Not Fx_Ejecutar_GenDTE_BAT(_Formulario, _Directorio_GenDTE, _Iddt) Then
                Return 0
            End If
        End If

        Beep()
        ToastNotification.Show(_Formulario, "FIRMANDO ...",
                               Nothing,
                               2 * 1000, eToastGlowColor.Red,
                               eToastPosition.MiddleCenter)

        If Not (_RowMaeen Is Nothing) Then
            _Idmaeen = _RowMaeen.Item("IDMAEEN")
            _Recepelect = _RowMaeen.Item("RECEPELECT")
            _Email = _RowMaeen.Item("EMAIL")
            'Return 0
        End If

        '_Iddt = 301706

        Consulta_sql = "Select Top 1 * From FMAEDTE Where IDDT = " & _Iddt
        Dim _RowFaedte As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If (_RowFaedte Is Nothing) Then
            Return 0
        Else
            _Iddte = _RowFaedte.Item("IDDTE")
            _Koen = _RowFaedte.Item("ENDO")
            If Not CBool(_Iddte) Then
                Return 0
            End If
        End If

        Dim _Tido = _Maeedo.Rows.Item(0).Item("TIDO")

        If _Tido = "BLV" Then Return 0


        Consulta_sql = "Select top 1 * From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
        _Row_Configp = _Sql.Fx_Get_Tablas(Consulta_sql).Rows(0)

        Dim _Empresa = _Row_Configp.Item("EMPRESA")
        Dim _Nroresol = _Row_Configp.Item("NRORESOL")
        Dim _Rutemi = _Row_Configp.Item("RUT")
        Dim _Rutenvi = _Row_Configp.Item("FIRMAELEC")

        Dim _Rutrecep As String
        Dim _Kopet As Integer

        'If _Tido <> "BLV" Then
        '    _Rutrecep = Trim(_Maeen.Rows(0).Item("RTEN")) & "-" & Trim(RutDigito(_Maeen.Rows(0).Item("RTEN")))
        'End If



        'If _Nuevo_RunMonitor Then ' Nuevo RunMonitor

        '    Select Case _Tido
        '        Case "BLV"
        '            Return 0
        '        Case "FCV", "NCV", "GTI", "GDP"
        '            _Kopet = 110 : _Rutrecep = "60803000-K"
        '    End Select

        'Else

        '    Select Case _Tido
        '        Case "BLV"
        '            _Kopet = 12 : _Rutrecep = "66666666-6"
        '        Case "FCV", "NCV", "GTI", "GDP"
        '            _Kopet = 10 : _Rutrecep = "60803000-K"
        '    End Select

        'End If

        Dim _Fechresol = Format(_Row_Configp.Item("FECHRESOL"), "yyyMMdd")

        Dim _Idpet As Integer
        Dim _Idpet2 As Integer

        Dim myTrans As SqlTransaction
        Dim Comando As SqlCommand

        '  ESTO ES PARA QUE EL RUN MONITOR ENVIE EL DTE AL SII
        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        If _Nuevo_RunMonitor Then

            Try

                myTrans = Cn2.BeginTransaction()

                _Rutrecep = "60803000-K"
                _Kopet = "110"

                '/* 67320.40 */ INSERT INTO FMAEPETE (KOPET,RUTEMI,RUTENVI,RUTRECEP,FRESOL,NRESOL,EMPRESA,INACTIVO,TSPETIC)  VALUES (110,'85904700-9' ,'8711086-9' ,'60803000-K' ,{d '2009-01-16'} ,'7', '01',0,GETDATE() ) 
                '/* 67320.44 */ SELECT @@IDENTITY AS ULTID
                '/* 67320.47 */ INSERT INTO FMAEPETD (IDPET,IDDTE,IDLG) VALUES (711924,533824,0)
                '/* 67320.50 */ SELECT @@IDENTITY AS ULTID
                '/* 67320.54 */ COMMIT TRANSACTION
                '/* 67320.57 */ BEGIN TRANSACTION
                '/* 67320.62 */ INSERT INTO FMAEPETE (KOPET,RUTEMI,RUTENVI,RUTRECEP,FRESOL,NRESOL,EMPRESA,INACTIVO,TSPETIC)  VALUES (111,'85904700-9' ,'8711086-9' ,'76221827-5' ,{d '2009-01-16'} ,'7', '01',1,GETDATE() ) 
                '/* 67320.65 */ SELECT @@IDENTITY AS ULTID
                '/* 67320.68 */ INSERT INTO FMAEPETD (IDPET,IDDTE,IDLG) VALUES (711925,533824,714265)

                Consulta_sql = "INSERT INTO FMAEPETE (KOPET,RUTEMI,RUTENVI,RUTRECEP,FRESOL,NRESOL,EMPRESA,INACTIVO,TSPETIC)  VALUES " &
                        "(" & _Kopet & ",'" & _Rutemi & "','" & _Rutenvi & "','" & _Rutrecep &
                        "','" & _Fechresol & "','" & _Nroresol & "', '" & _Empresa & "',0,Getdate())"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
                Comando.Transaction = myTrans
                Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    _Idpet = dfd1("Identity")
                End While
                dfd1.Close()

                Consulta_sql = "INSERT INTO FMAEPETD (IDPET,IDDTE) VALUES (" & _Idpet & "," & _Iddte & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Dim _Idptde As Integer

                Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
                Comando.Transaction = myTrans
                dfd1 = Comando.ExecuteReader()
                While dfd1.Read()
                    _Idptde = dfd1("Identity")
                End While
                dfd1.Close()


                ' Esto parece que es para una llamada de correo electronico

                _Kopet = "111"
                _Rutrecep = _Maeen.Rows(0).Item("RTEN").ToString.Trim & "-" & RutDigito(_Maeen.Rows(0).Item("RTEN").ToString.Trim)

                Consulta_sql = "INSERT INTO FMAEPETE (KOPET,RUTEMI,RUTENVI,RUTRECEP,FRESOL,NRESOL,EMPRESA,INACTIVO,TSPETIC)  VALUES " &
                        "(" & _Kopet & ",'" & _Rutemi & "','" & _Rutenvi & "','" & _Rutrecep &
                        "','" & _Fechresol & "','" & _Nroresol & "', '" & _Empresa & "'," & Convert.ToInt32(_Reenvio) & ",Getdate())"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
                Comando.Transaction = myTrans
                dfd1 = Comando.ExecuteReader()
                While dfd1.Read()
                    _Idpet2 = dfd1("Identity")
                End While
                dfd1.Close()

                Consulta_sql = "INSERT INTO FMAEPETD (IDPET,IDDTE,IDLG) VALUES (" & _Idpet2 & "," & _Iddte & "," & _Idptde & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                myTrans.Commit()
                Return _Idpet

            Catch ex As Exception
                myTrans.Rollback()
                'MessageBoxEx.Show(ex.Message, "Documento no fue firmado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)
                'If CBool(_Iddte) Then
                '    Fx_Dte_Enviar_Correo_Cliente(_Formulario, _Iddt)
                'End If
            End Try

        Else

            Try

                _Rutrecep = "60803000-K"
                _Kopet = "10"

                myTrans = Cn2.BeginTransaction()

                Consulta_sql = "INSERT INTO FMAEPETE (KOPET,RUTEMI,RUTENVI,RUTRECEP,FRESOL,NRESOL,EMPRESA)  VALUES " &
                               "(" & _Kopet & ",'" & _Rutemi & "','" & _Rutenvi & "','" & _Rutrecep &
                               "','" & _Fechresol & "','" & _Nroresol & "', '" & _Empresa & "')"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
                Comando.Transaction = myTrans
                Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    _Idpet = dfd1("Identity")
                End While
                dfd1.Close()

                Consulta_sql = "INSERT INTO FMAEPETD (IDPET,IDDTE) VALUES (" & _Idpet & "," & _Iddte & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                myTrans.Commit()
                Return _Idpet

            Catch ex As Exception
                myTrans.Rollback()
                'MessageBoxEx.Show(ex.Message, "Documento no fue firmado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)
                If CBool(_Iddte) Then
                    Fx_Dte_Enviar_Correo_Cliente(_Formulario, _Iddt)
                End If
            End Try

        End If

    End Function

    Function Fx_Dte_Enviar_Correo_Cliente(_Formulario As Form, _Iddt As Integer) As Integer

        Dim _Empresa
        Dim _Nroresol
        Dim _Rutemi
        Dim _Rutenvi

        Dim _Fechresol

        Dim _Rutrecep As String
        Dim _Kopet As Integer

        Try

            '-- SI NO ES RECEPTOR ELECTRONICO EL RUTRECEP = '60803000-K'
            '-- KOPET = 10 FACTURA, 12 BOLETA

            'INSERT INTO FMAEPETE (KOPET,RUTEMI,RUTENVI,RUTRECEP,FRESOL,NRESOL,EMPRESA)  VALUES (10,'79514800-0' ,'12628844-1' ,'60803000-K' ,{d '2012-06-19'} ,'72', '01' ) 
            '--SELECT @@IDENTITY AS ULTID

            'Set @IDPET = (SELECT @@IDENTITY AS ULTID)
            'INSERT INTO FMAEPETD (IDPET,IDDTE) VALUES (@IDPET,0)

            Dim _Icono As Image = Nothing ' My.Resources.Recursos_DTE.script_edit
            Dim _Koen As String = _Maeen.Rows(0).Item("KOEN")

            Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "' And TIPOSUC = 'P'"
            Dim _RowMaeen As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
            Dim _Idmaeen As Integer
            Dim _Recepelect As Boolean
            Dim _Email As String

            If Not (_RowMaeen Is Nothing) Then
                _Idmaeen = _RowMaeen.Item("IDMAEEN")
                _Recepelect = _RowMaeen.Item("RECEPELECT")
                _Email = _RowMaeen.Item("EMAIL")
            End If

            Consulta_sql = "Select Top 1 * From FMAEDTE Where IDDT = " & _Iddt
            Dim _RowFaedte As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If (_RowFaedte Is Nothing) Then
                Return 0
            Else
                _Iddte = _RowFaedte.Item("IDDTE") '_Sql.Fx_Trae_Dato(, "IDDTE", "FMAEDTE", "IDDT = " & _Iddt, True)
                _Koen = _RowFaedte.Item("ENDO")
                If Not CBool(_Iddte) Then
                    Return 0
                End If
            End If


            Dim _Tido = _Maeedo.Rows.Item(0).Item("TIDO")

            Consulta_sql = "Select top 1 * From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
            _Row_Configp = _Sql.Fx_Get_Tablas(Consulta_sql).Rows(0)

            _Empresa = _Row_Configp.Item("EMPRESA")
            _Nroresol = _Row_Configp.Item("NRORESOL")
            _Rutemi = _Row_Configp.Item("RUT")
            _Rutenvi = _Row_Configp.Item("FIRMAELEC")


            If _Tido <> "BLV" Then
                _Rutrecep = Trim(_Maeen.Rows(0).Item("RTEN")) & "-" & Trim(RutDigito(_Maeen.Rows(0).Item("RTEN")))
            End If

            Select Case _Tido
                Case "BLV" : _Kopet = 12 : _Rutrecep = "66666666-6"
                    Return 0
                Case "FCV"

                    _Kopet = 10 : _Rutrecep = "60803000-K"

                    If Not (_RowMaeen Is Nothing) Then
                        _Recepelect = _RowMaeen.Item("RECEPELECT")

                        If _Recepelect Then
                            _Kopet = 11
                            _Rutrecep = Trim(_RowMaeen.Item("RTEN")) & "-" & RutDigito(_RowMaeen.Item("RTEN"))
                        Else
                            Return 0
                        End If
                    End If

            End Select

            _Fechresol = Format(_Row_Configp.Item("FECHRESOL"), "yyyMMdd")

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Documento no fue firmado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return 0
        End Try

        Dim _Idpet As Integer

        'Dim _Cn As New SqlConnection
        Dim myTrans As SqlTransaction
        Dim Comando As SqlCommand

        '  ESTO ES PARA EL ENVIO DEL CORREO AUTOMATICO AL CLIENTE
        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)


        Try

            myTrans = Cn2.BeginTransaction()

            Consulta_sql = "INSERT INTO FMAEPETE (KOPET,RUTEMI,RUTENVI,RUTRECEP,FRESOL,NRESOL,EMPRESA)  VALUES " &
                           "(" & _Kopet & ",'" & _Rutemi & "','" & _Rutenvi & "','" & _Rutrecep &
                           "','" & _Fechresol & "','" & _Nroresol & "', '" & _Empresa & "')"

            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                _Idpet = dfd1("Identity")
            End While
            dfd1.Close()

            Consulta_sql = "INSERT INTO FMAEPETD (IDPET,IDDTE) VALUES (" & _Idpet & "," & _Iddte & ")"

            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            myTrans.Commit()

            Return _Idpet

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Documento no fue firmado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            myTrans.Rollback()
        Finally
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)
        End Try

    End Function

    Private Function Fx_Trae_Ffolio(_Formulario As Form,
                                    _Nro_Documento As Integer,
                                    _Td As Integer,
                                    _Mostrar_Mensaje_Error As Boolean) As DataRow


        Dim _Firma_Bakapp As Boolean

        'Try
        '    _Firma_Bakapp = _Global_Row_Configuracion_General.Item("FacElec_Bakapp_Hefesto")
        'Catch ex As Exception
        '    _Firma_Bakapp = False
        'End Try

        _Firma_Bakapp = Fx_Firmar_X_Bakapp3(_Td)

        If _Firma_Bakapp Then
            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_DTE_Caf With ( NOLOCK )" & vbCrLf &
                      "Where Cast(RNG_D AS INT)<=" & _Nro_Documento & " And Cast(RNG_H AS INT)>=" & _Nro_Documento &
                      " And TD='" & _Td & "' And Empresa='" & ModEmpresa & "' And AmbienteCertificacion = " & _AmbienteCertificacion
        Else
            Consulta_sql = "Select TOP 1 * FROM FFOLIOS WITH ( NOLOCK )" & vbCrLf &
                           "Where CAST(RNG_D AS INT)<=" & _Nro_Documento & " And Cast(RNG_H AS INT)>=" & _Nro_Documento &
                           "  And TD='" & _Td & "'  AND EMPRESA='" & ModEmpresa & "' "
        End If


        Dim _TblPaso As DataTable

        _TblPaso = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_TblPaso.Rows.Count) Then
            Return _TblPaso.Rows(0)
        Else
            If _Mostrar_Mensaje_Error And Not IsNothing(_Formulario) Then
                MessageBoxEx.Show(_Formulario, "No existen folios para esta numeración", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            Return Nothing
        End If

    End Function

    Private Function Fx_XML_DTE_Genera(_Row_Ffolios As DataRow,
                                       _Row_Maeedo As DataRow,
                                       _Row_Maeen_Receptor As DataRow,
                                       _Td As Integer,
                                       _Maeddo As DataTable,
                                       _Incorporar_Observaciones_En_DTE As Boolean,
                                       _Row_Maeedoob As DataRow) As String

        Dim _Nuevo_RunMonitor As Boolean = _Sql.Fx_Exite_Campo("CONFIGP", "VERSIONACT")

        Dim _XML = String.Empty

        If _Row_Maeedo.Item("TIDO") = "BLV" Then
            _XML = My.Resources.Recursos_DTE.SQLQuery_Genera_Encabezado_DTE_RdBkBOLETA
        Else
            _XML = My.Resources.Recursos_DTE.SQLQuery_Genera_Encabezado_DTE_RdBk
        End If

        Dim _ID As String = "F" & CInt(_Row_Maeedo.Item("NUDO")) & "T" & _Td
        _XML = Replace(_XML, "#ID#", _ID)

        ' <IdDoc>
        Dim _TipoDTE = _Td
        Dim _Folio = CInt(_Row_Maeedo.Item("NUDO"))
        Dim _FchEmis = Format(_Row_Maeedo.Item("FEEMDO"), "yyyy-MM-dd")

        _XML = Replace(_XML, "#TipoDTE#", _TipoDTE)
        _XML = Replace(_XML, "#Folio#", _Folio)
        _XML = Replace(_XML, "#FchEmis#", _FchEmis)

        ' <Emisor>

        Dim _RUTEmisor = Trim(_Row_Configp.Item("RUT"))
        Dim _RznSoc = Trim(_Row_Configp.Item("RAZON"))
        Dim _GiroEmis = Mid(Trim(_Row_Configp.Item("GIRO")), 1, 50)
        Dim _Acteco = Trim(_Row_Configp.Item("ACTECO"))
        Dim _DirOrigen = Trim(_Row_Configp.Item("DIRECCION"))
        Dim _CmnaOrigen = Mid(Trim(_Row_Configp.Item("CIUDAD")), 1, 20)
        Dim _CiudadOrigen = Mid(Trim(_Row_Configp.Item("CIUDAD")), 1, 20)  ' "REGION METROPOLITANA"

        If Not IsNothing(_Global_Row_Empresa) Then

            _RUTEmisor = Trim(_Global_Row_Empresa.Item("Rut"))
            _RznSoc = Trim(_Global_Row_Empresa.Item("Razon"))
            _GiroEmis = Mid(Trim(_Global_Row_Empresa.Item("Giro")), 1, 50)
            _Acteco = Trim(_Global_Row_Empresa.Item("Acteco"))
            _DirOrigen = Trim(_Global_Row_Empresa.Item("Direccion"))
            _CmnaOrigen = Mid(Trim(_Global_Row_Empresa.Item("Comuna")), 1, 20)
            _CiudadOrigen = Mid(Trim(_Global_Row_Empresa.Item("Ciudad")), 1, 20)

        End If

        Fx_Caracter_Raro_Quitar(_RznSoc)
        Fx_Caracter_Raro_Quitar(_GiroEmis)
        Fx_Caracter_Raro_Quitar(_DirOrigen)
        Fx_Caracter_Raro_Quitar(_CmnaOrigen)
        Fx_Caracter_Raro_Quitar(_CiudadOrigen)

        _XML = Replace(_XML, "#RUTEmisor#", _RUTEmisor)
        _XML = Replace(_XML, "#RznSoc#", _RznSoc)
        _XML = Replace(_XML, "#GiroEmis#", _GiroEmis)
        _XML = Replace(_XML, "#Acteco#", _Acteco)
        _XML = Replace(_XML, "#DirOrigen#", _DirOrigen)
        _XML = Replace(_XML, "#CmnaOrigen#", _CmnaOrigen)
        _XML = Replace(_XML, "#CiudadOrigen#", _CiudadOrigen)
        '-----------------------------------------------------------------------------------------------

        ' <Receptor>

        Dim _RUTRecep = Trim(_Row_Maeen_Receptor.Item("RTEN")) & "-" & Trim(RutDigito(_Row_Maeen_Receptor.Item("RTEN")))
        Dim _RznSocRecep = Mid(Trim(_Row_Maeen_Receptor.Item("NOKOEN")), 1, 40)
        Dim _GiroRecep = Mid(Trim(_Row_Maeen_Receptor.Item("GIEN")), 1, 40)
        Dim _DirRecep = Trim(_Row_Maeen_Receptor.Item("DIEN"))
        Dim _Paen = _Row_Maeen_Receptor.Item("PAEN")
        Dim _Cien = _Row_Maeen_Receptor.Item("CIEN")
        Dim _Cmen = _Row_Maeen_Receptor.Item("CMEN")
        Dim _CmnaRecep = Mid(Trim(_Row_Maeen_Receptor.Item("COMUNA")), 1, 20)
        Dim _CiudadRecep = Mid(Trim(_Row_Maeen_Receptor.Item("CIUDAD")), 1, 15)

        Fx_Caracter_Raro_Quitar(_RznSocRecep)
        Fx_Caracter_Raro_Quitar(_GiroRecep)
        Fx_Caracter_Raro_Quitar(_DirRecep)
        Fx_Caracter_Raro_Quitar(_CmnaRecep)
        Fx_Caracter_Raro_Quitar(_CiudadRecep)

        _XML = Replace(_XML, "#RUTRecep#", _RUTRecep)
        _XML = Replace(_XML, "#RznSocRecep#", _RznSocRecep)
        _XML = Replace(_XML, "#GiroRecep#", _GiroRecep)
        _XML = Replace(_XML, "#DirRecep#", _DirRecep)
        _XML = Replace(_XML, "#CmnaRecep#", _CmnaRecep)
        _XML = Replace(_XML, "#CiudadRecep#", _CiudadRecep)
        '-----------------------------------------------------------------------------------------------

        ' <Totales>

        Dim _Vanedo As Double = _Row_Maeedo.Item("VANEDO")
        Dim _Vaivdo As Double = _Row_Maeedo.Item("VAIVDO")
        Dim _Vabrdo As Double = _Row_Maeedo.Item("VABRDO")

        Dim _Iva_Calculo As Double = Math.Round(_Vanedo * 0.19, 0)
        Dim _Vanedo_Calculo As Double = Math.Round(_Vabrdo / 1.19, 0)

        _Vaivdo = _Vabrdo - _Vanedo_Calculo

        'If Math.Round(_Vaivdo, 2) <> _Iva_Calculo Then
        '_Vaivdo = Math.Round(_Iva_Calculo, 3) '+ 1
        '_Vabrdo = _Vanedo + _Vaivdo
        'End If

        Dim _Porc_Iva = Math.Round((_Vaivdo * 100) / _Vanedo, 0)

        Dim _MntNeto As Integer = Math.Round(_Vanedo, 0)
        Dim _TasaIVA As Double = _Porc_Iva
        Dim _IVA As Double = Math.Round(_Vaivdo, 0)
        Dim _MntTotal As Double = Math.Round(_Vabrdo, 0)

        Dim _Totales_Netos As String

        Dim _Meardo = _Row_Maeedo.Item("MEARDO")

        Dim _Campo_PrcItem, _Campo_PrcItem_LT
        Dim _Campo_MontoItem

        Dim _IndServicio = String.Empty
        Dim _FormaDePago = String.Empty
        Dim _IndTraslado = String.Empty

        Dim _Tido = _Row_Maeedo.Item("TIDO")
        Dim _Tab = vbTab & vbTab & vbTab & vbTab & vbTab

        If _Tido = "BLV" Or _Tido = "BSV" Then 'If _Meardo = "B" Then

            _Totales_Netos = "<MntNeto>#MntNeto#</MntNeto>" & vbCrLf &
                             "<IVA>#IVA#</IVA>"

            _IndServicio = vbCrLf & "<IndServicio>3</IndServicio>" & vbCrLf
            _FormaDePago = String.Empty

        Else '_Meardo = "N" Then

            _Totales_Netos = "<MntNeto>#MntNeto#</MntNeto>" & vbCrLf &
                             "<TasaIVA>#TasaIVA#</TasaIVA>" & vbCrLf &
                             "<IVA>#IVA#</IVA>"
            _IndServicio = String.Empty
            _FormaDePago = String.Empty

            If _Tido = "FCV" And _Nuevo_RunMonitor Then

                Dim _Endo = _Row_Maeedo.Item("ENDO")
                Dim _Suendo = _Row_Maeedo.Item("SUENDO")

                Dim _Row_Maeen As DataRow = Fx_Traer_Datos_Entidad(_Endo, _Suendo)

                Dim _FchVenc = Format(_Row_Maeedo.Item("FEULVEDO"), "yyyy-MM-dd")
                Dim _Dias = DateDiff(DateInterval.Day, _Row_Maeedo.Item("FEEMDO"), _Row_Maeedo.Item("FEULVEDO"))
                Dim _Cuotas = _Row_Maeedo.Item("NUVEDO")

                _Dias = _Row_Maeen.Item("DIPRVE")
                _Cuotas = _Row_Maeen.Item("NUVECR")

                Dim _FmaPago As Integer
                Dim _TermPagoGlosa As String

                If _Dias <= 1 Then
                    _FmaPago = 1
                    _TermPagoGlosa = "Contado"
                Else
                    _FmaPago = 2
                    _TermPagoGlosa = "Credito a " & _Dias & " dias, " & _Cuotas & " cuotas"
                End If

                _FormaDePago = "<FmaPago>" & _FmaPago & "</FmaPago><TermPagoGlosa>" & _TermPagoGlosa & "</TermPagoGlosa><FchVenc>" & _FchVenc & "</FchVenc>"

            End If

            If _Tido.ToString.Contains("G") Then

                Select Case _Tido.ToString
                    Case "GTI"
                        _IndTraslado = "<IndTraslado>5</IndTraslado>"
                    Case "GDV"
                        _IndTraslado = "<TipoDespacho>1</TipoDespacho><IndTraslado>1</IndTraslado>"
                    Case "GDD"
                        _IndTraslado = "<TipoDespacho>2</TipoDespacho><IndTraslado>6</IndTraslado>"
                    Case "GDP"
                        _IndTraslado = "<TipoDespacho>2</TipoDespacho><IndTraslado>3</IndTraslado>"
                End Select

            End If

        End If

        _XML = Replace(_XML, "#IndServicio#", _IndServicio)
        _XML = Replace(_XML, "#FormaDePago#", _FormaDePago)
        _XML = Replace(_XML, "#IndTraslado#", _IndTraslado)

        _XML = Replace(_XML, "#Totales_Netos#", _Totales_Netos)
        _XML = Replace(_XML, "#MntNeto#", _MntNeto)
        _XML = Replace(_XML, "#TasaIVA#", _TasaIVA)
        _XML = Replace(_XML, "#IVA#", _IVA)

        _XML = Replace(_XML, "#MntTotal#", _MntTotal)

        Dim _Transporte = String.Empty

        If _Tido.ToString.Contains("G") Then

            ' Retirador de mercaderia
            Dim _Koreti As String = NuloPorNro(_Row_Maeedoob.Item("DIENDESP").ToString.Trim, "")
            Dim _Rureti As String = _Sql.Fx_Trae_Dato("TABRETI", "RURETI", "KORETI = '" & _Koreti & "'").ToString.Trim
            Dim _Nokoreti As String = _Sql.Fx_Trae_Dato("TABRETI", "NORETI", "KORETI = '" & _Koreti & "'").ToString.Trim
            Dim _Placapat As String = NuloPorNro(_Row_Maeedoob.Item("PLACAPAT"), "").ToString.Trim

            Dim _Patente = String.Empty
            Dim _Chofer = String.Empty

            If Not String.IsNullOrEmpty(_Rureti.Trim & _Nokoreti.Trim) Or
               Not String.IsNullOrEmpty(_Placapat) Then

                If Not String.IsNullOrEmpty(_Placapat) Then
                    _Patente = "<Patente>" & _Placapat & "</Patente>" & vbCrLf
                End If

                If Not String.IsNullOrEmpty(_Rureti.Trim & _Nokoreti.Trim) Then

                    Dim _Rut As String = _Rureti.ToString.Trim

                    If _Rut.Contains("-") Then
                        Dim _Rt = Split(_Rut, "-")
                        _Rut = _Rt(0)
                    End If

                    _Rut = Convert.ToInt32(_Rut) & "-" & RutDigito(_Rut)
                    _Rureti = _Rut

                    _Chofer = "<Chofer>" & vbCrLf &
                              "<RUTChofer>" & _Rureti & "</RUTChofer>" & vbCrLf &
                              "<NombreChofer>" & _Nokoreti & "</NombreChofer>" & vbCrLf &
                              "</Chofer>" & vbCrLf
                End If

                _Transporte = vbCrLf &
                              "<Transporte>" & vbCrLf &
                              _Patente &
                              _Chofer &
                              "</Transporte>"

            End If

        End If

        _XML = Replace(_XML, "#Transporte#", _Transporte)

        '-----------------------------------------------------------------------------------------------

        'DETALLE
        Dim _NroLinDet = 1
        Dim _It1 As String
        Dim _Mnt As String 'MNT

        Dim _Detalle = String.Empty

        For Each _Fila As DataRow In _Maeddo.Rows

            Dim _Prct As Boolean = _Fila.Item("PRCT")

            If Not _Prct Then

                Dim _Udtrpr = _Fila.Item("UDTRPR")
                Dim _NmbItem = Trim(Trim(_Fila.Item("NOKOPR")))
                Dim _QtyItem = _Fila.Item("CAPRCO" & _Udtrpr)
                Dim _UnmdItem = _Fila.Item("UD0" & _Udtrpr & "PR")

                Dim _Podtglli As Double = _Fila.Item("PODTGLLI")
                Dim _DescuentoMonto As Double
                Dim _Str_DescuentoMonto = String.Empty
                Dim _PrcItem = String.Empty

                If _Tido = "BLV" Or _Tido = "BSV" Then

                    _Campo_PrcItem = "PPPRBR"
                    _Campo_MontoItem = "VABRLI"

                    Dim _ValPrcItem As Double = Math.Round(_Fila.Item("VABRLI") / _QtyItem, 0)

                    '_PrcItem = De_Num_a_Tx_01(_Fila.Item(_Campo_PrcItem), False, 3)
                    _PrcItem = De_Num_a_Tx_01(_ValPrcItem, False, 3)

                Else

                    _Campo_MontoItem = "VANELI"

                    If CBool(_Podtglli) Then

                        _Campo_PrcItem = "PPPRNELT"

                        Dim _Monto_Neto_LT = _Fila.Item("PPPRNELT") * _QtyItem
                        Dim _Monto_Neto = _Fila.Item("PPPRNE") * _QtyItem

                        If _Meardo = "N" Then

                            _PrcItem = _Fila.Item("PPPRNE")
                            _DescuentoMonto = _Fila.Item("VADTNELI")

                            _Str_DescuentoMonto = vbCrLf & "<DescuentoMonto>" & De_Num_a_Tx_01(_DescuentoMonto, True, 0) & "</DescuentoMonto>"

                        Else

                            Dim _Poimgli = _Fila.Item("POIMGLLI")
                            Dim _Poivli = _Fila.Item("POIVLI")

                            Dim _Impuetos = 1 + Math.Round((_Poimgli + _Poivli) / 100, 5)

                            _DescuentoMonto = Math.Round((_Fila.Item("VADTBRLI") / _Impuetos) * _QtyItem, 0)

                            Dim _Vaneli As Double = Math.Round(_Fila.Item("VANELI"), 5)

                            _PrcItem = Math.Round((_Vaneli + _DescuentoMonto) / _QtyItem, 5)

                            '_DescuentoMonto = Math.Round(_DescuentoMonto / _QtyItem, 5)

                            _Str_DescuentoMonto = vbCrLf & "<DescuentoMonto>" & De_Num_a_Tx_01(_DescuentoMonto, True, 0) & "</DescuentoMonto>"

                        End If

                        _PrcItem = De_Num_a_Tx_01(_PrcItem, False, 5)

                    Else

                        _PrcItem = De_Num_a_Tx_01(_Fila.Item("PPPRNE"), False, 3)

                    End If

                End If

                Dim _MontoItem As Integer = Math.Round(_Fila.Item(_Campo_MontoItem), 0) 'De_Num_a_Tx_01(_Fila.Item(_Campo_MontoItem), False, 3)
                Dim _VlrCodigo As String
                Dim _TpoCodigo As String

                'If _Nuevo_RunMonitor Then
                '    _VlrCodigo = _Fila.Item("KOPRCT").ToString.Trim
                '    _TpoCodigo = "INTERNA"
                'Else
                '    _VlrCodigo = Right(Trim(_Fila.Item("KOPRCT")), 3) ' String
                '    _TpoCodigo = "CPCS"
                'End If

                _TpoCodigo = "INTERNO"
                _VlrCodigo = _Fila.Item("KOPRCT").ToString.Trim

                Fx_Caracter_Raro_Quitar(_NmbItem)

                Dim _QtyItem_Str As String = _QtyItem
                Dim _Decimales = Split(_QtyItem, ",")

                If _Decimales.Length = 2 Then
                    _QtyItem_Str = De_Num_a_Tx_01(_QtyItem, False, _Decimales(1).Length)
                End If

                _Detalle += vbCrLf &
                        "<Detalle>" & vbCrLf &
                        "<NroLinDet>" & _NroLinDet & "</NroLinDet>" & vbCrLf &
                        "<CdgItem>" & vbCrLf &
                        "<TpoCodigo>" & _TpoCodigo & "</TpoCodigo>" & vbCrLf &
                        "<VlrCodigo>" & _VlrCodigo & "</VlrCodigo>" & vbCrLf &
                        "</CdgItem>" & vbCrLf &
                        "<NmbItem>" & _NmbItem & "</NmbItem>" & vbCrLf &
                        "<DscItem/>" & vbCrLf &
                        "<QtyItem>" & _QtyItem_Str & "</QtyItem>" & vbCrLf &
                        "<UnmdItem>" & _UnmdItem & "</UnmdItem>" & vbCrLf &
                        "<PrcItem>" & _PrcItem & "</PrcItem>" &
                        _Str_DescuentoMonto & vbCrLf &
                        "<MontoItem>" & _MontoItem & "</MontoItem>" & vbCrLf &
                        "</Detalle>"

                If _NroLinDet = 1 Then

                    _It1 = _NmbItem
                    _Mnt = _Fila.Item("VABRLI")

                End If

                _NroLinDet += 1

            End If

        Next


        Dim _NroLinDR = 1

        Dim _Detalle_DscRcgGlobal = String.Empty

        '<DscRcgGlobal>
        '	<NroLinDR>1</NroLinDR>
        '	<TpoMov>D</TpoMov>
        '	<GlosaDR>DESCUENTO RETIRO EN AGENCIA</GlosaDR>
        '	<TpoValor>$</TpoValor>
        '	<ValorDR>25000.00</ValorDR>
        '</DscRcgGlobal>

        For Each _Fila As DataRow In _Maeddo.Rows

            Dim _Prct As Boolean = _Fila.Item("PRCT")

            If _Prct Then

                Dim _TpoMov = _Fila.Item("TICT")
                Dim _GlosaDR = _Fila.Item("NOKOPR").ToString.Trim
                Dim _TpoValor = _Fila.Item("MOPPPR").ToString.Trim
                Dim _ValorDR = De_Num_a_Tx_01(_Fila.Item("VADTNELI"), False, 2)

                If _TpoMov = "R" Then
                    If _Tido = "BLV" Then
                        _ValorDR = De_Num_a_Tx_01(_Fila.Item("VABRLI"), False, 2)
                    Else
                        _ValorDR = De_Num_a_Tx_01(_Fila.Item("VANELI"), False, 2)
                    End If
                End If

                If _TpoMov = "D" Then
                    If _Tido = "BLV" Then
                        _TpoValor = "%"
                        _ValorDR = De_Num_a_Tx_01(_Fila.Item("PODTGLLI"), False, 2)
                    Else
                        _ValorDR = De_Num_a_Tx_01(_Fila.Item("VADTNELI"), False, 0)
                    End If
                End If

                Fx_Caracter_Raro_Quitar(_GlosaDR)

                _Detalle += vbCrLf &
                            "<DscRcgGlobal>" & vbCrLf &
                            "<NroLinDR>" & _NroLinDR & "</NroLinDR>" & vbCrLf &
                            "<TpoMov>" & _TpoMov & "</TpoMov>" & vbCrLf &
                            "<GlosaDR>" & _GlosaDR & "</GlosaDR>" & vbCrLf &
                            "<TpoValor>" & _TpoValor & "</TpoValor>" & vbCrLf &
                            "<ValorDR>" & _ValorDR & "</ValorDR>" & vbCrLf &
                            "</DscRcgGlobal>"

                _NroLinDR += 1

            End If

        Next

        If _Incorporar_Observaciones_En_DTE Then

            If Not (_Row_Maeedoob Is Nothing) Then

                _Detalle += vbCrLf

                For _i = 1 To 10

                    Dim _Obs = Trim(NuloPorNro(_Row_Maeedoob.Item("TEXTO" & _i), ""))

                    If Not String.IsNullOrEmpty(_Obs) Then
                        _Detalle += "<Detalle>" & vbCrLf &
                                    "<NroLinDet>" & _NroLinDet & "</NroLinDet>" & vbCrLf &
                                    "<NmbItem>" & _Obs & "</NmbItem>" & vbCrLf &
                                    "<DscItem/>" & vbCrLf &
                                    "</Detalle>"
                    End If
                    _NroLinDet += 1
                Next

            End If

        End If


        If Not IsNothing(_Referencias_DTE) Then

            Dim _NroLinRef = 0

            For Each _Row_Referencia As DataRow In _Referencias_DTE.Rows

                _Detalle += vbCrLf

                _NroLinRef += 1

                Dim _TpoDocRef As String = _Row_Referencia.Item("TpoDocRef")
                Dim _FolioRef As String = _Row_Referencia.Item("FolioRef")
                Dim _FchRef As String = Format(_Row_Referencia.Item("FchRef"), "yyyy-MM-dd")
                Dim _CodRef As String = _Row_Referencia.Item("CodRef")
                Dim _RazonRef As String = Trim(_Row_Referencia.Item("RazonRef"))

                If Convert.ToBoolean(Val(_CodRef)) Then
                    _CodRef = "<CodRef>" & _CodRef & "</CodRef>" & vbCrLf
                Else
                    _CodRef = String.Empty
                End If

                If Not String.IsNullOrEmpty(_RazonRef) Then
                    _RazonRef = "<RazonRef>" & _RazonRef & "</RazonRef>" & vbCrLf
                End If

                _Detalle += "<Referencia>" & vbCrLf &
                            "<NroLinRef>" & _NroLinRef & "</NroLinRef>" & vbCrLf &
                            "<TpoDocRef>" & _TpoDocRef & "</TpoDocRef>" & vbCrLf &
                            "<FolioRef>" & _FolioRef & "</FolioRef>" & vbCrLf &
                            "<FchRef>" & _FchRef & "</FchRef>" & vbCrLf &
                            _CodRef &
                            _RazonRef &
                            "</Referencia>"

            Next

        End If

        _XML = Replace(_XML, "#Detalle#", _Detalle)

        '-----------------------------------------------------------------------------------------------
        ' TIEMBRE
        Dim _Sql_Timbre_Electronico = Fx_Crear_Timbre_Electronico(_MntTotal)

        _XML = Replace(_XML, "#Timbre_Electronico#", _Sql_Timbre_Electronico)

        _XML = Replace(_XML, "ñ", "n")
        _XML = Replace(_XML, "Ñ", "N")

        Return _XML

    End Function



    Function Fx_Crear_Timbre_Electronico(Optional _Mnt As String = Nothing) As String

        _Nro_Documento = _Maeedo.Rows(0).Item("NUDO")

        Try
            _Nro_Documento = CInt(_Nro_Documento)
        Catch ex As Exception
            _Nro_Documento = 0
        End Try

        Dim _Tido = _Maeedo.Rows.Item(0).Item("TIDO")
        Dim _TipoDTE As Integer = Fx_Tipo_DTE_VS_TIDO(_Tido)

        Dim _Consulta_sql = "Select top 1 * From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"

        Dim _Row_Configp As DataRow = _Sql.Fx_Get_DataRow(_Consulta_sql)
        Dim _Row_Ffolios = Fx_Trae_Ffolio(Nothing, _Nro_Documento, _TipoDTE, False)


        Dim _Row_Maeedo As DataRow = _Maeedo.Rows(0)
        Dim _Row_Maeen_Receptor As DataRow = _Maeen.Rows(0)

        Dim _RUTRecep = Trim(_Row_Maeen_Receptor.Item("RTEN")) & "-" & Trim(RutDigito(_Row_Maeen_Receptor.Item("RTEN")))
        Dim _RznSocRecep = Mid(Trim(_Row_Maeen_Receptor.Item("NOKOEN")), 1, 40) ' Trim(_Row_Maeen_Receptor.Item("NOKOEN"))

        Fx_Caracter_Raro_Quitar(_RznSocRecep)

        _RznSocRecep = _RznSocRecep.ToString.Trim

        Dim _Folio = _Row_Maeedo.Item("NUDO")
        Dim _FchEmis = Format(_Row_Maeedo.Item("FEEMDO"), "yyyy-MM-dd")

        'Dim _RUTEmisor = Trim(_Row_Configp.Item("RUT"))
        'Dim _RznSoc = Trim(_Row_Configp.Item("RAZON"))

        Dim _Re = String.Empty
        Dim _Rs = String.Empty

        Dim _Rng_d = String.Empty
        Dim _Rng_h = String.Empty
        Dim _Fa = String.Empty
        Dim _Rsapk_m = String.Empty
        Dim _Rsapk_e = String.Empty
        Dim _Idk = String.Empty
        Dim _Frma = String.Empty


        Dim _Firma_Bakapp As Boolean = Fx_Firmar_X_Bakapp2(_Tido)

        'Try
        '    _Firma_Bakapp = _Global_Row_Configuracion_General.Item("FacElec_Bakapp_Hefesto")
        'Catch ex As Exception
        '    _Firma_Bakapp = False
        'End Try

        If Not (_Row_Ffolios Is Nothing) Then

            _Folio = CInt(_Row_Maeedo.Item("NUDO"))

            _Re = _Row_Ffolios.Item("RE").ToString.Trim
            _Rs = _Row_Ffolios.Item("RS").ToString.Trim

            _Rng_d = _Row_Ffolios.Item("RNG_D").ToString.Trim
            _Rng_h = _Row_Ffolios.Item("RNG_H").ToString.Trim

            If _Firma_Bakapp Then
                _Fa = Format(_Row_Ffolios.Item("FA"), "yyyy-MM-dd")
            Else
                _Fa = _Row_Ffolios.Item("FA").ToString
            End If

            _Rsapk_m = _Row_Ffolios.Item("RSAPK_M").ToString.Trim
            _Rsapk_e = _Row_Ffolios.Item("RSAPK_E").ToString.Trim
            _Idk = _Row_Ffolios.Item("IDK").ToString.Trim
            _Frma = _Row_Ffolios.Item("FRMA").ToString.Trim

        End If

        If Not _Frma.Contains("algoritmo=""SHA1withRSA"">") Then
            _Frma = "algoritmo=""SHA1withRSA"">" & _Frma
        End If

        'Dim _MntTotal As Double = Math.Round(_Vabrdo, 0)

        Dim _It1 = Mid(Trim(_Maeddo.Rows(0).Item("NOKOPR")), 1, 40)
        _It1 = _It1.ToString.Trim

        Fx_Caracter_Raro_Quitar(_It1)

        If _Mnt Is Nothing Then
            Dim _Vabrdo As Double = _Maeedo.Rows(0).Item("VABRDO")
            _Mnt = Math.Round(_Vabrdo, 0)
        End If

        Dim _Sql_Timbre_Electronico = My.Resources.Recursos_DTE.SQLQuery_Genera_Timbre_Electronico_DTE_RdBk

        _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#TipoDTE#", _TipoDTE)
        _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#Folio#", _Folio)
        _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#FchEmis#", _FchEmis)

        _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#RUTRecep#", _RUTRecep)
        _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#RznSocRecep#", _RznSocRecep)

        _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#Re#", _Re)
        _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#Rs#", _Rs)
        ' _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#RznSoc#", _RznSoc)

        _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#Mnt#", _Mnt)
        _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#It1#", _It1)

        _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#Rng_d#", _Rng_d)
        _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#Rng_h#", _Rng_h)
        _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#Fa#", _Fa)
        _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#Rsapk_m#", _Rsapk_m)
        _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#Rsapk_e#", _Rsapk_e)
        _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#Idk#", _Idk)
        _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#Frma#", " " & _Frma)

        _Sql_Timbre_Electronico = Replace(_Sql_Timbre_Electronico, "#Tsted#", "")

        '#Tsted#
        '<TSTED>2017-07-05T16:06:30</TSTED>
        _Nro_Documento = _Maeedo.Rows(0).Item("NUDO")

        Return _Sql_Timbre_Electronico

    End Function

    Function Fx_Crear_Archivo_XML(_Formulario As Form) As String

        _Errores.Clear()

        Dim _Tido = _Maeedo.Rows.Item(0).Item("TIDO")
        Dim _Td As Integer = Fx_Tipo_DTE_VS_TIDO(_Tido)

        _Nro_Documento = _Maeedo.Rows(0).Item("NUDO")

        Consulta_sql = "Select top 1 * From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
        _Row_Configp = _Sql.Fx_Get_Tablas(Consulta_sql).Rows(0)

        If _Tido <> "FCC" And _Tido <> "GRC" And _Tido <> "NCC" Then

            _Row_Ffolios = Fx_Trae_Ffolio(_Formulario, CInt(_Nro_Documento), _Td, False)

            If (_Row_Ffolios Is Nothing) Then

                Dim _Msg = "No existe este número como folio autorizado en el SII " & _Tido & "-" & _Nro_Documento
                '& vbCrLf &
                '           "Este documento no sera timbrado electrónicamente" & vbCrLf &
                '           "Corrija el problema antes de seguir creando documentos erroneamente"

                _Errores.Add(_Msg)

                Return ""

            End If

        End If

        Dim _EsElectronico As Boolean = _Maeedo.Rows(0).Item("TIDOELEC") 'Fx_Es_Electronico(_Tido)

        If Not _EsElectronico Then
            _Errores.Add("El documento no es electrónico")
            Return ""
        End If

        If _Tido = "NCV" Then

            If Convert.ToBoolean(_Referencias_DTE.Rows.Count) Then

                For Each _Fila As DataRow In _Referencias_DTE.Rows

                    Dim _TpoDocRef = _Fila.Item("TpoDocRef")

                    If Not Fx_Contiene_TpoDocRef(_TpoDocRef) Then

                        _Errores.Add("Faltan los documentos de Referencia")

                    End If

                Next

            Else

                _Errores.Add("Faltan los documentos de Referencia")

            End If

        End If

        If Convert.ToBoolean(_Errores.Count) Then
            Return ""
        End If

        Dim _Row_Maeedoob As DataRow

        If CBool(_Maeedoob.Rows.Count) Then
            _Row_Maeedoob = _Maeedoob.Rows(0)
        End If

        Dim _Xml As String

        Try

            _Xml = Fx_XML_DTE_Genera(_Row_Ffolios, _Maeedo.Rows(0), _Maeen.Rows(0), _Td, _Maeddo, _Incorporar_Observaciones_En_DTE, _Row_Maeedoob)

            Dim _Dte As New XmlDocument()
            Dim _uriDteResultado As String = _Path & "\NuevoDTE.xml"


            _Dte.PreserveWhitespace = True
            _Dte.LoadXml(_Xml)
            _Dte.Save(_uriDteResultado)
        Catch ex As Exception
            _Errores.Add("Error {" & ex.Message & "}")
        End Try

        'If Validar_Schema(_uriDteResultado, _UriSchemaDte) Then

        'End If

        'If Fx_Validar_Schema(_uriDteResultado, _UriSchemaDte) Then
        Return _Xml
        'Else
        '    Return ""
        'End If

    End Function

    Function Fx_Ejecutar_GenDTE_BAT_NewRunmonitor(_Formulario As Form,
                                                  _Directorio As String,
                                                  _Iddt As Integer) As Boolean

        Dim _FolderBrowserDialog As New FolderBrowserDialog
        Dim _NombreEquipo As String

        If Not Directory.Exists(_Directorio_GenDTE) Then

            MessageBoxEx.Show(_Formulario, "El directorio GenDTE no existe o no esta registrado", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

            'System.IO.Directory.CreateDirectory(_Path)

            With _FolderBrowserDialog

                .Reset() ' resetea  

                ' leyenda  
                .Description = " Seleccionar una carpeta "
                ' Path " Mis documentos "  
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

                ' deshabilita el botón " crear nueva carpeta "  
                .ShowNewFolderButton = False
                '.RootFolder = Environment.SpecialFolder.Desktop  
                '.RootFolder = Environment.SpecialFolder.StartMenu  

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo  

                ' si se presionó el botón aceptar ...  
                If ret = Windows.Forms.DialogResult.OK Then

                    Dim nFiles As ObjectModel.ReadOnlyCollection(Of String)

                    nFiles = My.Computer.FileSystem.GetFiles(.SelectedPath)

                    Dim _Directorio_Seleccionado As String = .SelectedPath

                    If File.Exists(_Directorio_Seleccionado & "\dte\bat\GenDTE.BAT") Then

                        _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Directorio_GenDTE = '" & _Directorio_Seleccionado & "'" & vbCrLf &
                                       "Where NombreEquipo = '" & _NombreEquipo & "'"

                        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                            _Directorio_GenDTE = _Directorio_Seleccionado
                            _Directorio = _Directorio_GenDTE
                        Else
                            Return False
                        End If

                    Else

                        MessageBoxEx.Show(_Formulario,
                        "No se encontro el archivo GenDTE.BAT en el directorio (" & _Directorio_Seleccionado & "\dte\bat\)",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    End If

                End If

                .Dispose()

            End With

        End If

        If File.Exists(_Directorio & "\dte\bat\GenDTE.BAT") Then

            '' \dte\bat

            'Nueva forma de timbrar 
            '' /* 56056.05 */ dte\bat\GenDTE.BAT "C:\Random.Cisternas\\dte\conf" 01 535489

            Dim _Ejecutar As String = _Directorio & "\dte\bat\GenDTE.BAT """ & _Directorio & "\\dte\conf""" & Space(1) & ModEmpresa & " " & _Iddt

            Try
                Shell(_Ejecutar, AppWinStyle.Hide, True)
                Return True
            Catch ex As Exception
                MessageBoxEx.Show(ex.Message)
            End Try

        Else

            MessageBoxEx.Show(_Formulario,
                        "No se encontro el archivo GenDTE.BAT en el directorio (" & _Directorio & ")",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Directorio_GenDTE = '' Where NombreEquipo = '" & _NombreEquipo & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

    End Function

    Function Fx_Ejecutar_GenDTE_BAT(_Formulario As Form,
                                    _Directorio As String,
                                    _Iddt As Integer) As Boolean


        Dim _FolderBrowserDialog As New FolderBrowserDialog

        If Not Directory.Exists(_Directorio_GenDTE) Then
            MessageBoxEx.Show(_Formulario, "El directorio GenDTE no existe o no esta registrado", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)

            'System.IO.Directory.CreateDirectory(_Path)

            With _FolderBrowserDialog

                .Reset() ' resetea  

                ' leyenda  
                .Description = " Seleccionar una carpeta "
                ' Path " Mis documentos "  
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

                ' deshabilita el botón " crear nueva carpeta "  
                .ShowNewFolderButton = False
                '.RootFolder = Environment.SpecialFolder.Desktop  
                '.RootFolder = Environment.SpecialFolder.StartMenu  

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo  

                ' si se presionó el botón aceptar ...  
                If ret = Windows.Forms.DialogResult.OK Then

                    Dim nFiles As ObjectModel.ReadOnlyCollection(Of String)

                    nFiles = My.Computer.FileSystem.GetFiles(.SelectedPath)

                    Dim _Directorio_Seleccionado As String = .SelectedPath

                    If File.Exists(_Directorio_Seleccionado & "\GenDTE.BAT") Then
                        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_EstacionesBkp Set Directorio_GenDTE = '" & _Directorio_Seleccionado & "'" & vbCrLf &
                                       "Where NombreEquipo = '" & _NombreEquipo & "'"

                        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                            _Directorio_GenDTE = _Directorio_Seleccionado
                            _Directorio = _Directorio_GenDTE
                        Else
                            Return False
                        End If
                    Else
                        MessageBoxEx.Show(_Formulario,
                        "No se encontro el archivo GenDTE.BAT en el directorio (" & _Directorio_Seleccionado & ")",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                        'GenDTE.BAT
                    End If
                End If

                .Dispose()

            End With

        End If

        If File.Exists(_Directorio & "\GenDTE.BAT") Then

            'Nueva forma de timbrar 
            '' /* 56056.05 */ dte\bat\GenDTE.BAT "C:\Random.Cisternas\\dte\conf" 01 535489

            Dim _Ejecutar As String = _Directorio & "\GenDTE.BAT " & _Iddt

            Try
                Shell(_Ejecutar, AppWinStyle.Hide, True)
                Return True
            Catch ex As Exception
                MessageBoxEx.Show(ex.Message)
            End Try
        Else
            MessageBoxEx.Show(_Formulario,
                        "No se encontro el archivo GenDTE.BAT en el directorio (" & _Directorio & ")",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Function

    Function Fx_Validar_Schema(uriSetDteResultado As String, uriSchemaEnvioDte As String) As Boolean

        If Not IsNothing(_Errores) Then _Errores.Clear()
        _Errores = Fx_Revisar_Schema(uriSetDteResultado, uriSchemaEnvioDte)

        If Not Convert.ToBoolean(_Errores.Count) Then

            Dim err As String = String.Empty

            _Errores.ForEach(Sub(e As String) err += e & Convert.ToString(""))

            ''_resp.EsCorrecto = False
            ''_resp.Mensaje = err

            ''Return _resp

        End If

    End Function

    Function Fx_Revisar_Schema(_uriDte As String, _uriSchema As String) As List(Of String)

        Const _NS As String = "http://www.sii.cl/SiiDte"

        Dim tr As New XmlTextReader(_uriDte)

        Dim vr As New XmlValidatingReader(tr)

        vr.Schemas.Add(_NS, _uriSchema)

        vr.ValidationType = ValidationType.Schema

        AddHandler vr.ValidationEventHandler, AddressOf Revisar_XML_DTE_SettingsValidationEventHandler

        While vr.Read()
            Dim _DD = vr
        End While

        Console.WriteLine("Documento es válido")

        Console.Read()

    End Function

    Shared Sub Revisar_XML_DTE_SettingsValidationEventHandler(sender As Object, e As ValidationEventArgs)

        'If e.Severity = XmlSeverityType.Warning Then
        '    Console.Write("WARNING: ")
        '    Console.WriteLine(e.Message)
        '    '_Errores.Add(e.Message)
        'ElseIf e.Severity = XmlSeverityType.Error Then
        '    Console.Write("ERROR: ")
        '    Console.WriteLine(e.Message)
        'End If

        Select Case e.Severity
            Case XmlSeverityType.Error
                'sender.Add(e.Message)
                '_Errores.Add("Error {" & e.Message & "}")
                'Debug.WriteLine("Error: {0}", e.Message)
            Case XmlSeverityType.Warning
                'sender.Add(e.Message)
                Console.WriteLine("Warning {0}", e.Message)
                'sender.Add("Warning {0}", e.Message)
                'Debug.WriteLine("Advertencia {0}", e.Message)
        End Select

    End Sub

    'Function Fx_ValidarSchema(uriDte As String, uriSchema As String) As List(Of String)

    '    '
    '    ' Difina la constante namespace SII
    '    Const NS As String = "http://www.sii.cl/SiiDte"

    '    '
    '    ' Defina la lista de errores a rtegresar
    '    Dim errores As New List(Of String)()


    '    '
    '    ' Inicie la validacion de los schemas
    '    Try
    '        '
    '        ' Cree el administrador del schema
    '        Dim schemas As New XmlSchemaSet()

    '        '
    '        ' Asigne el schema al administrador
    '        schemas.Add(NS, uriSchema)

    '        '
    '        ' Recupere el documento xml (DTE) a validar
    '        Dim DocumentoXml As XDocument = XDocument.Load(uriDte)


    '        Dim eventHandler As ValidationEventHandler = New ValidationEventHandler(AddressOf ValidationEventHandler)


    '        ' Inicie la validacion del documento xml contra su schema
    '        DocumentoXml.Validate(schemas, eventHandler)

    '        'DocumentoXml.Validate(schemas, Function(o, e) errores.Add(e.Message)) End Function)

    '    Catch generatedExceptionName As Exception
    '        errores.Add("Error al intentar validar schema contra documento xml")
    '    End Try

    '    '
    '    ' Regrese el valor de retorno 
    '    Return errores

    'End Function

    'Shared Sub ValidationEventHandler(sender As Object, e As ValidationEventArgs)

    '    Select Case e.Severity
    '        Case XmlSeverityType.Error
    '            sender.Add(e.Message)
    '        Case XmlSeverityType.Warning
    '            Console.WriteLine("Warning {0}", e.Message)
    '    End Select

    'End Sub

    Function Fx_Contiene_TpoDocRef(_TpoDocRef As String) As Boolean

        Select Case _TpoDocRef

            ' Case "30" ': factura
            ' Case "32" ': factura de venta bienes y servicios no afectos o exentos de IVA 
            ' Case "35" ': Boleta
            ' Case "38" ': Boleta exenta
            ' Case "45" ': factura de compra
            ' Case "55" ': nota de débito
            ' Case "60" ': nota de crédito
            ' Case "103" ': Liquidación
            ' Case "40" ': Liquidación Factura
            ' Case "43" ': Liquidación-Factura Electrónica
            ' Case "33" ': Factura Electrónica
            ' Case "34" ': Factura No Afecta o Exenta Electrónica
            ' Case "39" ': Boleta Electrónica
            ' Case "41" ': Boleta Exenta Electrónica
            ' Case "46" ': Factura de Compra Electrónica.
            ' Case "56" ': Nota de Débito Electrónica
            ' Case "61" ': Nota de Crédito Electrónica
            ' Case "50" ': Guía de Despacho.
            ' Case "52" ': Guía de Despacho Electrónica
            ' Case "110" ': Factura de Exportación Electrónica
            ' Case "111"  ' Nota de Débito de Exportación Electrónica
            ' Case "112"  ' Nota de Crédito de Exportación Electrónica
            ' Case "801"  ' Orden de Compra
            ' Case "802"  ' Nota de pedido
            ' Case "803"  ' Contrato
            ' Case "804"  ' Resolución
            ' Case "805"  ' Proceso ChileCompra
            ' Case "806"  ' Ficha ChileCompra
            ' Case "807"  ' DUS
            ' Case "808"  ' B/ L(Conocimiento de embarque)
            ' Case "809"  ' AWB(Air Will Bill)
            ' Case "810"  ' MIC/ DTA
            ' Case "811"  ' Carta de Porte
            ' Case "812"  ' Resolución del SNA donde califica Servicios de Exportación
            ' Case "813"  ' Pasaporte
            ' Case "814"  ' Certificado de Depósito Bolsa Prod. Chile.
            ' Case "815"  ' Vale de Prenda Bolsa Prod. Chile
            ' Case "820"  ' Código de Inscripción en el Registro de Acuerdos con Plazo de Pago Excepcional

            Case "30", "32", "35", "38", "55", "60", "40", "43", "33", "34", "39", "41", "46", "56",
                 "61", "110", "111", "112"
                Return True
            Case Else
                Return False
        End Select

    End Function

    Function Fx_Timbrar_Y_Enviar_DTE_SII_Hefesto(ByRef _Id_Dte As Integer, _Formulario As Form) As Boolean

        _Trackid = String.Empty
        _Respuesta = String.Empty

        _Id_Dte = Fx_Timbrar_Documento_Hefesto(_Formulario)

        If CBool(_Id_Dte) Then

            Return True

            'If Fx_Enviar_DTE_Al_SII(_Id_Dte, _Trackid) Then

            '    If IsNumeric(_Trackid) Then

            '        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Trackid = '" & _Trackid & "' Where Id_Dte = " & _Id_Dte
            '        _Sql.Ej_consulta_IDU(Consulta_sql)

            '        If Fx_Consultar_Trackid(_Trackid, _Respuesta) Then

            '            Dim _Estado = String.Empty
            '            Dim _Glosa = String.Empty

            '            Dim _Aceptados As Integer
            '            Dim _Informados As Integer
            '            Dim _Rechazados As Integer
            '            Dim _Reparos As Integer

            '            Sb_Revisar_Respuesta_Trackid(_Respuesta, _Estado, _Glosa, _Aceptados, _Informados, _Rechazados, _Reparos)

            '            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DTE_Trackid (Id_Dte,Idmaeedo,Trackid,Informado,Aceptado,Rechazado," &
            '                            "Reparo,Estado,Glosa,Respuesta) Values " &
            '                            "(" & _Id_Dte & "," & _Idmaeedo & ",'" & _Trackid & "'," & _Informados & "," & _Aceptados & "," & _Rechazados &
            '                            "," & _Reparos & ",'" & _Estado & "','" & _Glosa & "','" & _Respuesta & "')"
            '            _Sql.Ej_consulta_IDU(Consulta_sql)

            '            If CBool(_Aceptados) Or CBool(_Reparos) Then

            '                Dim _Koen = _Maeedo.Rows(0).Item("ENDO")
            '                Dim _Suen = _Maeedo.Rows(0).Item("SUENDO")

            '                Dim _Para = _Maeen.Rows(0).Item("EMAIL").ToString.Trim
            '                Dim _EnvioCorreo As String = Fx_Enviar_Notificacion_Correo_Al_Diablito(_Idmaeedo, _Para, "")

            '                If Not String.IsNullOrEmpty(_EnvioCorreo) Then
            '                    Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "Zw_DTE_Trackid", _Iddte, "Email_DTE_Error", _EnvioCorreo, "", "", _Koen, _Suen, False, "")
            '                End If

            '            End If

            '            Return True

            '        End If

            '    Else

            '        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Respuesta = '" & _Trackid & "' Where Id_Dte = " & _Id_Dte
            '        _Sql.Ej_consulta_IDU(Consulta_sql)

            '    End If

            'End If

        End If

        Return False

    End Function

    Function Fx_Timbrar_Documento_Hefesto(_Formulario As Form) As Integer

        _Errores.Clear()

        Dim _Id_Dte As Integer

        Dim _uriCaf As String
        Dim _uriDte As String
        Dim _RutaArchivo As String
        Dim _Nombre_Archivo_Xml As String

        Dim _Tido As String = _Maeedo.Rows(0).Item("TIDO")
        Dim _Nudo As String = _Maeedo.Rows.Item(0).Item("NUDO")

        Dim _Xml As String
        _Xml = Fx_Crear_Archivo_XML(_Formulario)

        If String.IsNullOrEmpty(_Xml) Then
            Return 0
        End If

        Dim _Td As Integer = Fx_Tipo_DTE_VS_TIDO(_Tido)

        Dim _ID As String = "F" & CInt(_Maeedo.Rows(0).Item("NUDO")) & "T" & _Td
        Dim _a1 = "<Documento ID=""" & _ID & """>"

        _Xml = Replace(_Xml, _a1, "<DTE version=""1.0"">" & vbCrLf & _a1)
        _Xml = Replace(_Xml, "</Documento>", "</Documento>" & vbCrLf & "</DTE>")

        Dim _Fullpath = AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Documentos"

        If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto") Then
            System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto")
        End If

        If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF") Then
            System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF")
        End If

        If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF\" & _Tido) Then
            System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF\" & _Tido)
        End If

        Dim _Dir = AppPath() & "\Data\" & RutEmpresaActiva

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_Caf" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And TD = '" & _Td & "' And RNG_D <= " & CInt(_Nudo) & " And RNG_H >= " & CInt(_Nudo)
        Dim _Row_CAF As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_CAF) Then
            _Errores.Add("No existe archivo CAF")
            Return 0
        End If

        Dim _XmlCAF As String = _Row_CAF.Item("CAF")

        Try
            File.Delete(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF\" & _Tido & "\Caf_" & _Tido & ".xml")
        Catch ex As Exception
            _Errores.Add(ex.Message)
            Return 0
        End Try

        Dim oSW As New System.IO.StreamWriter(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF\" & _Tido & "\Caf_" & _Tido & ".xml")
        oSW.WriteLine(_XmlCAF)
        oSW.Close()

        _uriCaf = AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF\" & _Tido & "\Caf_" & _Tido & ".xml" 'AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF\FCV\FoliosSII7659092061192022161442.xml"

        If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\Doc_Firmando") Then
            System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\Doc_Firmando")
        End If

        _RutaArchivo = AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\Doc_Firmando"
        _Nombre_Archivo_Xml = _Tido & "-" & _Nudo & "_DTE.xml"

        oSW = New System.IO.StreamWriter(_RutaArchivo & "\" & _Nombre_Archivo_Xml)
        oSW.WriteLine(_Xml)
        oSW.Close()

        _uriDte = _RutaArchivo & "\" & _Nombre_Archivo_Xml

        'Consulta_sql = "Select * From CONFIGP"
        'Dim _Row_Configp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _RutEmisor As String '= _Row_ConfEmpresa.Item("RutEmisor")
        Dim _RutEnvia As String '= _Row_ConfEmpresa.Item("RutEnvia")
        Dim _RutReceptor As String '= _Row_ConfEmpresa.Item("RutReceptor")
        Dim _FchResol As String '= Format(_Row_ConfEmpresa.Item("FchResol"), "yyyy-MM-dd")
        Dim _NroResol As String '= _Row_ConfEmpresa.Item("NroResol")
        Dim _TpoDTE As String
        Dim _Cn As String '= _Row_ConfEmpresa.Item("Cn").ToString.Trim

        Consulta_sql = "Select Id,Empresa,Campo,Valor,FechaMod,TipoCampo,TipoConfiguracion" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_DTE_Configuracion" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And TipoConfiguracion = 'ConfEmpresa' And AmbienteCertificacion = " & _AmbienteCertificacion
        Dim _Tbl_ConfEmpresa As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Not CBool(_Tbl_ConfEmpresa.Rows.Count) Then
            _Errores.Add("Faltan los datos de configuración DTE para la empresa")
            Return 0
        End If

        For Each _Fila As DataRow In _Tbl_ConfEmpresa.Rows

            Dim _Campo As String = _Fila.Item("Campo").ToString.Trim

            If _Campo = "RutEmisor" Then _RutEmisor = _Fila.Item("Valor")
            If _Campo = "RutEnvia" Then _RutEnvia = _Fila.Item("Valor")
            If _Campo = "RutReceptor" Then _RutReceptor = _Fila.Item("Valor")
            If _Campo = "FchResol" Then _FchResol = _Fila.Item("Valor")
            If _Campo = "NroResol" Then _NroResol = _Fila.Item("Valor")
            If _Campo = "Cn" Then _Cn = _Fila.Item("Valor")

        Next

        If _AmbienteCertificacion Then
            _NroResol = "0"
            '    _FchResol = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor",
            '                                  "Empresa = '" & ModEmpresa & "' And Campo = 'FchResol' And AmbienteCertificacion = 1")
        End If

        Dim ClsFirmarDocumento As New HEFFirmarDocumento

        With ClsFirmarDocumento

            .Fullpath = _Fullpath

            If _Tido = "BLV" Then
                .TipoDTE = "39"
            End If

            If Not .CargarDocumento(_uriDte) Then

                Try
                    Dim _Dte2 As XDocument
                    _Dte2 = XDocument.Load(_uriDte, LoadOptions.None)
                Catch ex As Exception
                    _Errores.Add(ex.Message)
                End Try

                _Errores.Add("Error al querer firma el documento: " & _uriDte)
                Return 0

            End If

            _TpoDTE = .TipoDTE

            If Not .CrearEnvioDte(_RutEmisor, _RutEnvia, _RutReceptor, _FchResol, _NroResol, _TpoDTE) Then
                MessageBoxEx.Show(Me, .Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return 0
            End If

            .CN = _Cn '"JUAN PABLO SIERRALTA OREZZOLI"
            .uriCaf = _uriCaf
            .uriDte = _uriDte

            If _Tido = "BLV" Then
                .uriSchemaDte = _Path & "\Schemas\BOLETAS\EnvioBOLETA_v11.xsd"
            Else
                .uriSchemaDte = _Path & "\Schemas\DTE_v10.xsd"
            End If

            .uriSchemaDteSf = _Path & "\Schemas\DTE_v10_Sf.xsd"
            .uriSchemaEnvioDteSf = _Path & "\Schemas\EnvioDTE_v10_Sf.xsd"
            .uriSchemaEnvioDte = _Path & "\Schemas\EnvioDTE_v10.xsd"

        End With

        Dim ArchivoFirmado As String = Path.GetFileName(Path.ChangeExtension(_uriDte, ".Firmado.xml"))

        Dim Respuesta As HEFESTO.FIRMA.DOCUMENTO.HEFRespuesta = ClsFirmarDocumento.FirmarArchivo()
        Dim FirmaStr As String

        If Not Respuesta.esCorrecto Then

            Dim val As Validacion = New Validacion()

            val.errores = Respuesta.Mensaje
            _Errores.Add(val.errores)

            Dim _Respuesta As String

            For Each _Er As String In _Errores
                _Respuesta += _Er.Trim & "; "
            Next

            _Respuesta = Replace(_Respuesta, "'", "''")

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DTE_Documentos(Idmaeedo,Tido,Nudo,FechaSolicitud,Xml,Firma," &
                           "CaratulaXml,AmbienteCertificacion,Procesar,Respuesta,ErrorEnvioDTE) Values " &
                           "(" & _Idmaeedo & ", '" & _Tido & "', '" & _Nudo & "',Getdate(),'','',''," & _AmbienteCertificacion & ",0,'" & _Respuesta & "',1)"
            _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Dte)

            'val.ShowDialog()
            Return _Id_Dte

        End If

        Dim uriDocumentoFirmado As String = Respuesta.Resultado.ToString()
        Dim name As String = _RutaArchivo & "\" & ArchivoFirmado
        If File.Exists(name) Then File.Delete(name)
        File.Copy(uriDocumentoFirmado, name)

        Dim _Dte As XDocument
        Dim _DteResultado As String
        Dim _Firma As XElement

        Dim _Fullpath2 = _Fullpath & "\DTEResultado.xml"
        Dim _Fullpath3 = _Fullpath & "\SETDTEResultado.xml"

        _Dte = XDocument.Load(_Fullpath2, LoadOptions.None)

        _DteResultado = My.Computer.FileSystem.ReadAllText(_Fullpath3)


        Dim ns = _Dte.Root.GetDefaultNamespace
        Dim _nsManager = New XmlNamespaceManager(New NameTable())

        _nsManager.AddNamespace("d", "http://www.sii.cl/SiiDte")
        _Firma = _Dte.XPathSelectElement("/d:DTE/d:Documento/d:TED", _nsManager)

        If _Tido = "BLV" Then
            _Firma = _Dte.XPathSelectElement("/DTE/Documento/TED", _nsManager)
        End If

        Dim _DteXml As String = _Dte.Document.ToString
        Dim _CaratulaCml As String = _DteResultado

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DTE_Documentos(Idmaeedo,Tido,Nudo,FechaSolicitud,Xml,Firma," &
                       "CaratulaXml,AmbienteCertificacion,Procesar) Values " &
                     "(" & _Idmaeedo & ", '" & _Tido & "', '" & _Nudo & "',Getdate(),'" & _DteXml & "','" & _Firma.ToString &
                     "','" & _CaratulaCml & "'," & _AmbienteCertificacion & ",1)"
        _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Dte)

        If CBool(_Id_Dte) Then
            Fx_Timbrar_Documento_Hefesto2(_Formulario, _Id_Dte)
        End If

        Return _Id_Dte

    End Function

    ''' <summary>
    ''' Esta funcion permite crear la CaratulaXml para enviarle el correo al cliente
    ''' </summary>
    ''' <param name="_Formulario"></param> Formulario principal
    ''' <param name="_Id_Dte"></param> Id_Dte del envio
    ''' <returns></returns>
    Function Fx_Timbrar_Documento_Hefesto2(_Formulario As Form, _Id_Dte As Integer) As String

        Dim _Error As String

        _Errores.Clear()

        Dim _uriCaf As String
        Dim _uriDte As String
        Dim _RutaArchivo As String
        Dim _Nombre_Archivo_Xml As String

        Dim _Tido As String = _Maeedo.Rows(0).Item("TIDO")
        Dim _Nudo As String = _Maeedo.Rows.Item(0).Item("NUDO")

        Dim _Xml As String
        _Xml = Fx_Crear_Archivo_XML(_Formulario)

        If String.IsNullOrEmpty(_Xml) Then
            Return 0
        End If

        Dim _Td As Integer = Fx_Tipo_DTE_VS_TIDO(_Tido)

        Dim _ID As String = "F" & CInt(_Maeedo.Rows(0).Item("NUDO")) & "T" & _Td
        Dim _a1 = "<Documento ID=""" & _ID & """>"

        _Xml = Replace(_Xml, _a1, "<DTE version=""1.0"">" & vbCrLf & _a1)
        _Xml = Replace(_Xml, "</Documento>", "</Documento>" & vbCrLf & "</DTE>")

        Dim _Fullpath = AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Documentos"

        If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto") Then
            System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto")
        End If

        If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF") Then
            System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF")
        End If

        If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF\" & _Tido) Then
            System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF\" & _Tido)
        End If

        Dim _Dir = AppPath() & "\Data\" & RutEmpresaActiva

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_Caf" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And TD = '" & _Td & "' And RNG_D <= " & CInt(_Nudo) & " And RNG_H >= " & CInt(_Nudo)
        Dim _Row_CAF As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_CAF) Then
            _Errores.Add("No existe archivo CAF")
            Return 0
        End If

        Dim _XmlCAF As String = _Row_CAF.Item("CAF")

        Try
            File.Delete(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF\" & _Tido & "\Caf_" & _Tido & ".xml")
        Catch ex As Exception
            _Errores.Add(ex.Message)
            Return 0
        End Try

        Dim oSW As New System.IO.StreamWriter(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF\" & _Tido & "\Caf_" & _Tido & ".xml")
        oSW.WriteLine(_XmlCAF)
        oSW.Close()

        _uriCaf = AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF\" & _Tido & "\Caf_" & _Tido & ".xml" 'AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\CAF\FCV\FoliosSII7659092061192022161442.xml"

        If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\Doc_Firmando") Then
            System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\Doc_Firmando")
        End If

        _RutaArchivo = AppPath() & "\Data\" & RutEmpresaActiva & "\DTE\Hefesto\Doc_Firmando"
        _Nombre_Archivo_Xml = _Tido & "-" & _Nudo & "_DTE.xml"

        oSW = New System.IO.StreamWriter(_RutaArchivo & "\" & _Nombre_Archivo_Xml)
        oSW.WriteLine(_Xml)
        oSW.Close()

        _uriDte = _RutaArchivo & "\" & _Nombre_Archivo_Xml

        Consulta_sql = "Select * From CONFIGP"
        Dim _Row_Configp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _RutEmisor As String '= _Row_ConfEmpresa.Item("RutEmisor")
        Dim _RutEnvia As String '= _Row_ConfEmpresa.Item("RutEnvia")
        Dim _RutReceptor As String '= _Row_ConfEmpresa.Item("RutReceptor")
        Dim _FchResol As String '= Format(_Row_ConfEmpresa.Item("FchResol"), "yyyy-MM-dd")
        Dim _NroResol As String '= _Row_ConfEmpresa.Item("NroResol")
        Dim _TpoDTE As String
        Dim _Cn As String '= _Row_ConfEmpresa.Item("Cn").ToString.Trim

        Consulta_sql = "Select Id,Empresa,Campo,Valor,FechaMod,TipoCampo,TipoConfiguracion" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_DTE_Configuracion" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And TipoConfiguracion = 'ConfEmpresa'"
        Dim _Tbl_ConfEmpresa As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Not CBool(_Tbl_ConfEmpresa.Rows.Count) Then
            _Errores.Add("Faltan los datos de configuración DTE para la empresa")
            Return 0
        End If

        For Each _Fila As DataRow In _Tbl_ConfEmpresa.Rows

            Dim _Campo As String = _Fila.Item("Campo").ToString.Trim

            If _Campo = "RutEmisor" Then _RutEmisor = _Fila.Item("Valor")
            If _Campo = "RutEnvia" Then _RutEnvia = _Fila.Item("Valor")
            If _Campo = "RutReceptor" Then _RutReceptor = _Fila.Item("Valor")
            If _Campo = "FchResol" Then _FchResol = _Fila.Item("Valor")
            If _Campo = "NroResol" Then _NroResol = _Fila.Item("Valor")
            If _Campo = "Cn" Then _Cn = _Fila.Item("Valor")

        Next

        If _AmbienteCertificacion Then
            _NroResol = "0"
            _FchResol = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor",
                                          "Empresa = '" & ModEmpresa & "' And Campo = 'FchResol' And AmbienteCertificacion = 1")
        End If

        Dim ClsFirmarDocumento As New HEFFirmarDocumento

        With ClsFirmarDocumento

            .Fullpath = _Fullpath

            If _Tido = "BLV" Then
                .TipoDTE = "39"
            Else
                Dim _Row_Maeen_Receptor As DataRow = Maeen.Rows(0)
                _RutReceptor = Trim(_Row_Maeen_Receptor.Item("RTEN")) & "-" & Trim(RutDigito(_Row_Maeen_Receptor.Item("RTEN")))
            End If

            If Not .CargarDocumento(_uriDte) Then

                Try
                    Dim _Dte2 As XDocument
                    _Dte2 = XDocument.Load(_uriDte, LoadOptions.None)
                Catch ex As Exception
                    _Errores.Add(ex.Message)
                End Try

                _Errores.Add("Error al querer firma el documento: " & _uriDte)
                Return 0

            End If

            _TpoDTE = .TipoDTE

            If Not .CrearEnvioDte(_RutEmisor, _RutEnvia, _RutReceptor, _FchResol, _NroResol, _TpoDTE) Then
                MessageBoxEx.Show(Me, .Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return 0
            End If

            .CN = _Cn '"JUAN PABLO SIERRALTA OREZZOLI"
            .uriCaf = _uriCaf
            .uriDte = _uriDte

            If _Tido = "BLV" Then
                .uriSchemaDte = _Path & "\Schemas\BOLETAS\EnvioBOLETA_v11.xsd"
            Else
                .uriSchemaDte = _Path & "\Schemas\DTE_v10.xsd"
            End If

            .uriSchemaDteSf = _Path & "\Schemas\DTE_v10_Sf.xsd"
            .uriSchemaEnvioDteSf = _Path & "\Schemas\EnvioDTE_v10_Sf.xsd"
            .uriSchemaEnvioDte = _Path & "\Schemas\EnvioDTE_v10.xsd"

        End With

        Dim ArchivoFirmado As String = Path.GetFileName(Path.ChangeExtension(_uriDte, ".Firmado.xml"))

        Dim Respuesta As HEFESTO.FIRMA.DOCUMENTO.HEFRespuesta = ClsFirmarDocumento.FirmarArchivo()
        Dim FirmaStr As String

        If Not Respuesta.esCorrecto Then
            Dim val As Validacion = New Validacion()
            val.errores = Respuesta.Mensaje
            _Errores.Add(val.errores)
            val.ShowDialog()
            Return _Errores(0)
        End If

        Dim uriDocumentoFirmado As String = Respuesta.Resultado.ToString()
        Dim name As String = _RutaArchivo & "\" & ArchivoFirmado
        If File.Exists(name) Then File.Delete(name)
        File.Copy(uriDocumentoFirmado, name)

        Dim _Dte As XDocument
        Dim _DteResultado As String
        Dim _Firma As XElement

        Dim _Fullpath2 = _Fullpath & "\DTEResultado.xml"
        Dim _Fullpath3 = _Fullpath & "\SETDTEResultado.xml"

        _Dte = XDocument.Load(_Fullpath2, LoadOptions.None)

        _DteResultado = My.Computer.FileSystem.ReadAllText(_Fullpath3)


        Dim ns = _Dte.Root.GetDefaultNamespace
        Dim _nsManager = New XmlNamespaceManager(New NameTable())

        _nsManager.AddNamespace("d", "http://www.sii.cl/SiiDte")
        _Firma = _Dte.XPathSelectElement("/d:DTE/d:Documento/d:TED", _nsManager)

        If _Tido = "BLV" Then
            _Firma = _Dte.XPathSelectElement("/DTE/Documento/TED", _nsManager)
        End If

        Dim _DteXml As String = _Dte.Document.ToString
        Dim _CaratulaCml As String = _DteResultado

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set CaratulaXmlEmail = '" & _CaratulaCml & "' Where Id_Dte = " & _Id_Dte
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        _Error = _Sql.Pro_Error

        Return _Error

    End Function

    Function Fx_Enviar_Notificacion_Correo_Al_Diablito(_Idmaeedo As Integer, _Para As String, _Cc As String, _Id_Trackid As Integer) As String

        Dim _Error = String.Empty

        Try

            Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo
            Dim _Row_Maeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Tido As String = _Row_Maeedo.Item("TIDO")
            Dim _Nudo As String = _Row_Maeedo.Item("NUDO")

            If String.IsNullOrEmpty(_Para.Trim) Then
                Throw New System.Exception("Falta el correo del cliente")
            End If

            If Not Fx_Validar_Email(_Para) Then
                Throw New System.Exception("El correo para: [" & _Para & "] no es una cuenta de correos valida")
            End If

            If Not String.IsNullOrEmpty(_Cc) Then

                If Not Fx_Validar_Email(_Cc) Then

                    If _Cc.Contains(";") Then
                        Dim _Ccs = _Cc.Split(";")

                        For Each _Correos In _Ccs
                            If Not Fx_Validar_Email(_Correos) Then
                                Throw New System.Exception("El correo CC: [" & _Correos & "] no es una cuenta de correos valida")
                            End If
                        Next
                    Else
                        If Not Fx_Validar_Email(_Cc) Then
                            Throw New System.Exception("El correo CC: [" & _Cc & "] no es una cuenta de correos valida")
                        End If
                    End If

                End If

            End If

            'Dim _Id_Dte As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Trackid", "Id_Dte", "Idmaeedo = " & _Idmaeedo & " And (Aceptado = 1 or Reparo = 1)", True)
            Dim _Id_Dte As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Trackid", "Id_Dte", "Id = " & _Id_Trackid, True)

            If Not CBool(_Id_Dte) Then
                Throw New System.Exception("No se encontro registro en tabla Zw_DTE_Trackid del sistema")
            End If

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_Documentos Where Id_Dte = " & _Id_Dte
            Dim _Row_DTE As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_DTE) Then
                Throw New System.Exception("No se encontro registro en tabla Zw_DTE_Documentos del sistema")
            End If

            If String.IsNullOrEmpty(_Row_DTE.Item("CaratulaXml")) Then
                Throw New System.Exception("No se encontro el archivo CaratulaXml en la tabla Zw_DTE_Documentos del sistema")
            End If

            Dim _Id_Correo As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor", "Campo = 'Id_Correo' And Empresa = '" & ModEmpresa & "'")

            If Not CBool(_Id_Correo) Then
                Throw New System.Exception("Falta asignar un correo de notificación en la configuración del sistema DTE")
            End If

            Dim _NombreFormato_PDF As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Configuracion", "Valor", "Campo = 'NombreFormato_PDF_" & _Tido & "' And Empresa = '" & ModEmpresa & "'")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Correos Corr Where Id = " & _Id_Correo
            Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Correo) Then
                Throw New System.Exception("No existe configuración para el envio de correos")
            End If

            Dim _Nombre_Correo As String = _Row_Correo.Item("Nombre_Correo")
            Dim _Asunto As String = _Row_Correo.Item("Asunto")
            Dim _Mensaje As String = _Row_Correo.Item("CuerpoMensaje")

            If String.IsNullOrEmpty(_Asunto) Then
                _Asunto = "Correo de notificación de pedido " & RazonEmpresa
            End If

            _Mensaje = Replace(_Mensaje, "&lt;", "<")
            _Mensaje = Replace(_Mensaje, "&gt;", ">")
            _Mensaje = Replace(_Mensaje, "&quot;", """")

            _Mensaje = Replace(_Mensaje, "'", "''")

            If Not String.IsNullOrEmpty(_Nombre_Correo) Then

                Dim _Fecha = "Getdate()"
                Dim _Adjuntar_Documento As Boolean = Not String.IsNullOrEmpty(_NombreFormato_PDF)

                'If _Enviar_al_otro_dia Then
                '    _Fecha = "DATEADD(D,1,Getdate())"
                'End If

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Doc_Emitidos_Aviso_Correo (Id_Correo,Nombre_Correo,CodFuncionario,Asunto," &
                                "Para,Cc,Idmaeedo,Tido,Nudo,NombreFormato,Enviar,Mensaje,Fecha,Adjuntar_Documento,Doc_Adjuntos,Adjuntar_DTE,Id_Dte,Id_Trackid)" &
                                vbCrLf &
                                "Values (" & _Id_Correo & ",'" & _Nombre_Correo & "','','" & _Asunto & "','" & _Para & "','" & _Cc &
                                "'," & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "','" & _NombreFormato_PDF & "',1,'" & _Mensaje & "'," & _Fecha &
                                "," & Convert.ToInt32(_Adjuntar_Documento) & ",'',1," & _Id_Dte & "," & _Id_Trackid & ")"

                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                _Error = _Sql.Pro_Error

                If Not String.IsNullOrEmpty(_Error) Then
                    Throw New System.Exception(_Error)
                End If

            End If

        Catch ex As Exception
            _Error = ex.Message
        End Try

        Return _Error

    End Function
    Sub Sb_Revisar_Respuesta_Trackid(_Respuesta As String,
                                     ByRef _Estado As String,
                                     ByRef _Glosa As String,
                                     ByRef _Aceptados As Integer,
                                     ByRef _Informados As Integer,
                                     ByRef _Rechazados As Integer,
                                     ByRef _Reparos As Integer,
                                     ByRef _VolverProcesar As Boolean)

        If _Respuesta.Contains("SII:RESP_BODY") Then

            Dim _Caf As New XDocument
            _Caf = XDocument.Parse(_Respuesta)

            'Dim _ACEPTADOS As Integer
            'Dim _INFORMADOS As Integer
            'Dim _RECHAZADOS As Integer
            'Dim _REPAROS As Integer

            Dim ns = _Caf.Root.GetDefaultNamespace
            Dim _nsManager = New XmlNamespaceManager(New NameTable())

            _nsManager.AddNamespace("d", "http://www.sii.cl/XMLSchema")

            Try
                _Aceptados = _Caf.XPathSelectElement("/d:RESPUESTA/d:RESP_BODY/ACEPTADOS", _nsManager)
                'If CBool(_Aceptados) Then _Estado = "-ACEPTADO"
                _Informados = _Caf.XPathSelectElement("/d:RESPUESTA/d:RESP_BODY/INFORMADOS", _nsManager)
                'If CBool(_Informados) Then _Estado += "-INFORMADO"
                _Rechazados = _Caf.XPathSelectElement("/d:RESPUESTA/d:RESP_BODY/RECHAZADOS", _nsManager)
                'If CBool(_Rechazados) Then _Estado += "-RECHAZADO"
                _Reparos = _Caf.XPathSelectElement("/d:RESPUESTA/d:RESP_BODY/REPAROS", _nsManager)
                'If CBool(_Reparos) Then _Estado += "-REPARO"
            Catch ex As Exception
                _Aceptados = 0 : _Informados = 0 : _Rechazados = 0 : _Reparos = 0
                'Throw New Exception("El documento que intenta cargar no es un archivo CAF.")
            End Try

        End If

        If _Respuesta.Contains("SII:RESP_HDR") Then

            Dim _Caf As New XDocument
            _Caf = XDocument.Parse(_Respuesta)

            Dim ns = _Caf.Root.GetDefaultNamespace
            Dim _nsManager = New XmlNamespaceManager(New NameTable())

            _nsManager.AddNamespace("d", "http://www.sii.cl/XMLSchema")

            Try
                _Estado = _Caf.XPathSelectElement("/d:RESPUESTA/d:RESP_HDR/ESTADO", _nsManager)
            Catch ex As Exception
                _Estado = String.Empty
            End Try

            _Glosa = Fx_GlosaEstados(_Estado, _Aceptados, _Rechazados, _VolverProcesar)

            If _Estado = "EPR" And _Rechazados Then
                _Glosa += " (Revise el SII, puede que el documento este aceptado con otro Trackid)"
            End If

        End If

    End Sub

    'Function Fx_Enviar_Consumo_Folios_Boletas_Al_SII(_FolioInicial As Integer,
    '                                                 _FolioFinal As Integer,
    '                                                 _vFoliosEmitidos As Integer,
    '                                                 _vFoliosUtilizados As Integer,
    '                                                 _vMntNeto As Double,
    '                                                 _vMntIva As Double,
    '                                                 _vMntTotal As Double,
    '                                                 _FechaInicio As DateTime,
    '                                                 _FechaFinal As DateTime,
    '                                                 ByRef _Id_Consumo As Integer,
    '                                                 ByRef _Resultado As String) As Boolean

    '    Try

    '        Dim _YearInicio As String = _FechaInicio.Year
    '        Dim _MonthInicio As String = numero_(_FechaInicio.Month, 2)
    '        Dim _DayInicio As String = numero_(_FechaInicio.Day, 2)

    '        Dim _YearFinal As String = _FechaFinal.Year
    '        Dim _MonthFinal As String = numero_(_FechaFinal.Month, 2)
    '        Dim _DayFinal As String = numero_(_FechaFinal.Day, 2)

    '        Dim _FchInicio As String = _YearInicio & "-" & _MonthInicio & "-" & _DayInicio
    '        Dim _FchFinal As String = _YearFinal & "-" & _MonthFinal & "-" & _DayFinal

    '        Dim _Inicial = _FolioInicial
    '        Dim _Final = _FolioFinal

    '        Dim _MntNeto = De_Num_a_Tx_01(_vMntNeto, True)
    '        Dim _MntIva = De_Num_a_Tx_01(_vMntIva, True)
    '        Dim _MntTotal = De_Num_a_Tx_01(_vMntTotal, True)
    '        Dim _FoliosEmitidos = De_Num_a_Tx_01(_vFoliosEmitidos, True)
    '        Dim _FoliosUtilizados = De_Num_a_Tx_01(_vFoliosUtilizados, True)

    '        Dim _RutEmisor As String
    '        Dim _RutEnvia As String
    '        Dim _RutReceptor As String
    '        Dim _FchResol As String
    '        Dim _NroResol As String
    '        Dim _TpoDTE As String = "39"
    '        Dim _Cn As String

    '        Consulta_sql = "Select Id,Empresa,Campo,Valor,FechaMod,TipoCampo,TipoConfiguracion" & vbCrLf &
    '                       "From " & _Global_BaseBk & "Zw_DTE_Configuracion" & vbCrLf &
    '                       "Where Empresa = '" & ModEmpresa & "' And TipoConfiguracion = 'ConfEmpresa'"
    '        Dim _Tbl_ConfEmpresa As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

    '        If Not CBool(_Tbl_ConfEmpresa.Rows.Count) Then
    '            Throw New System.Exception("Faltan los datos de configuración DTE para la empresa")
    '        End If

    '        For Each _Fila As DataRow In _Tbl_ConfEmpresa.Rows

    '            Dim _Campo As String = _Fila.Item("Campo").ToString.Trim

    '            If _Campo = "RutEmisor" Then _RutEmisor = _Fila.Item("Valor")
    '            If _Campo = "RutEnvia" Then _RutEnvia = _Fila.Item("Valor")
    '            If _Campo = "RutReceptor" Then _RutReceptor = _Fila.Item("Valor")
    '            If _Campo = "FchResol" Then _FchResol = _Fila.Item("Valor")
    '            If _Campo = "NroResol" Then _NroResol = _Fila.Item("Valor")
    '            If _Campo = "Cn" Then _Cn = _Fila.Item("Valor")

    '        Next

    '        Dim _cf As New HefConsumoFolios

    '        _cf.Certificado = _Cn '"JUAN PABLO SIERRALTA OREZZOLI"

    '        Dim _Certificado As Security.Cryptography.X509Certificates.X509Certificate2 = FuncionesComunes.RecuperarCertificado(_Cn)

    '        If IsNothing(_Certificado) Then
    '            Throw New System.Exception("Falta instalar el certificado digital en este equipo" & vbCrLf & "Cetificado: " & _Cn)
    '        End If

    '        _cf.Schema = AppPath() & "\Data\Dte\Schemas\Rcof.xsd"

    '        If Not File.Exists(_cf.Schema) Then
    '            Throw New System.Exception("Falta el archivo Rcof.xsd en la carpeta de Schema: " & AppPath() & "\Data\Dte\Schemas")
    '        End If

    '        _cf.DocumentoConsumoFolios.Caratula.RutEmisor = _RutEmisor '"79514800-0"
    '        _cf.DocumentoConsumoFolios.Caratula.RutEnvia = _RutEnvia ' "12628844-1"
    '        _cf.DocumentoConsumoFolios.Caratula.FchResol = _FchResol '"2012-06-19"
    '        _cf.DocumentoConsumoFolios.Caratula.NroResol = _NroResol '"72"
    '        _cf.DocumentoConsumoFolios.Caratula.FchInicio = _FchInicio
    '        _cf.DocumentoConsumoFolios.Caratula.FchFinal = _FchFinal
    '        _cf.DocumentoConsumoFolios.Caratula.Correlativo = "0"
    '        _cf.DocumentoConsumoFolios.Caratula.SecEnvio = "1"

    '        Dim _Resumen As New HefResumen

    '        _Resumen.TipoDocumento = _TpoDTE
    '        _Resumen.MntNeto = _MntNeto
    '        _Resumen.MntExento = 0
    '        _Resumen.MntIva = _MntIva
    '        _Resumen.MntTotal = _MntTotal
    '        _Resumen.FoliosEmitidos = _FoliosEmitidos
    '        _Resumen.FoliosAnulados = 0
    '        _Resumen.FoliosUtilizados = _FoliosUtilizados

    '        Dim RUtil1 As New HefRangoUtilizados

    '        RUtil1.Inicial = _Inicial
    '        RUtil1.Final = _Final
    '        _Resumen.RangoUtilizados.Add(RUtil1)

    '        _cf.DocumentoConsumoFolios.Resumenes.Add(_Resumen)

    '        If _cf.Publicar() Then

    '            Dim _Trackid = _cf.Trackid
    '            Dim _ArcXml = _cf.ArcXml.ToString

    '            _Resultado = _Trackid

    '            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DTE_ConsFolios (Trackid,FchInicio,FchFinal,Folioinicial,FolioFinal,FoliosEmitidos,FoliosUtilizados,Xml) Values " &
    '                           "('" & _Trackid & "','" & _FchInicio & "','" & _FchFinal & "'," & _FolioInicial & "," & _FolioFinal & "," & _FoliosEmitidos & "," & _FoliosUtilizados & ",'" & _ArcXml & "')"
    '            If Not _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Consumo) Then
    '                _Errores.Add(_Sql.Pro_Error)
    '            End If

    '        End If

    '    Catch ex As Exception
    '        _Errores.Add(ex.Message)
    '        Return False
    '    End Try

    '    Return True

    'End Function

    ''' <summary>
    ''' Enviar a firmar electronicamente al diablito DTEMonitor de Bakapp
    ''' </summary>
    ''' <returns></returns>
    Function Fx_FirmarXHefesto() As Integer

        Dim _Tido = _Maeedo.Rows(0).Item("TIDO")
        Dim _Nudo = _Maeedo.Rows(0).Item("NUDO")
        Dim _Id_Dte As Integer

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DTE_Firmar (Idmaeedo,Tido,Nudo,Firmar,AmbienteCertificacion,FechaEnvio) Values " &
                       "(" & _Idmaeedo & ",'" & _Tido & "','" & _Nudo & "',1," & _AmbienteCertificacion & ",Getdate())"

        Dim _Id As Integer

        If _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id) Then

            For i = 0 To 10

                _Id_Dte = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Firmar", "Id_Dte", "Id = " & _Id)
                If CBool(_Id_Dte) Then
                    Return _Id_Dte
                End If
                Thread.Sleep(1000)

            Next

        End If

    End Function

    Function Fx_AEC_CrearCesion(_Id_Dte As Integer,
                                _RutCesionario As String,
                                _RazonSocialCesionario As String,
                                _DireccionCesionario As String,
                                _eMailCesionario As String,
                                _NmbContacto As String,
                                _FonoContacto As String,
                                _MailContacto As String,
                                _RutAutoriza As String,
                                _NombreAutoriza As String,
                                _eMailCedente As String) As Integer

        _Errores.Clear()

        Consulta_sql = "Select Top 1 Tid.Id As Id_Trackid,Tid.Id_Dte,Isnull(Aec.Id_Aec,0) As Id_Aec" & vbCrLf &
                        "From " & _Global_BaseBk & "Zw_DTE_Trackid Tid" & vbCrLf &
                        "Inner Join " & _Global_BaseBk & "Zw_DTE_Documentos Doc On Tid.Id_Dte = Doc.Id_Dte" & vbCrLf &
                        "Left Join " & _Global_BaseBk & "Zw_DTE_Aec Aec On Aec.Idmaeedo = Tid.Idmaeedo" & vbCrLf &
                        "Where Doc.Idmaeedo = " & _Idmaeedo & " And Tid.Id_Dte <> 0 And Estado In ('EPR','RPR','RLV') "
        Dim _Row_TidDoc As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_TidDoc) Then
            _Errores.Add("No se encontro el archivo XML en la tabla [Zw_DTE_Documentos]")
            Return 0
        End If

        If CBool(_Row_TidDoc.Item("Id_Aec")) Then
            _Errores.Add("Ya existe una solicitud AEC para este documento")
            Return 0
        End If

        Dim _RutCedente = RutEmpresa ' _Maeen.Rows(0).Item("RTEN").ToString.Trim & "-" & RutDigito(_Maeen.Rows(0).Item("RTEN").ToString.Trim)
        _eMailCedente = _Maeen.Rows(0).Item("EMAIL").ToString.Trim
        Dim _Fecha = FechaDelServidor.ToString("yyyy-MM-ddTHH:mm:ss")

        Dim _MontoCesion As Double = _Maeedo.Rows(0).Item("VABRDO")
        Dim _FUltimoVencimiento As DateTime = _Maeedo.Rows(0).Item("FEULVEDO")

        Dim _Row_Maeedo As DataRow = Maeedo.Rows(0)

        Dim _Tido = _Row_Maeedo.Item("TIDO")
        Dim _Nudo = _Row_Maeedo.Item("NUDO")

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DTE_Aec (Idmaeedo,Id_Dte,Tido,Nudo,FechaSolicitud,RutCedente,RutCesionario," &
                       "RazonSocialCesionario,DireccionCesionario,eMailCesionario,MontoCesion,FUltimoVencimiento,RutAutoriza,NombreAutoriza," &
                       "eMailCedente,NmbContacto,FonoContacto,MailContacto,Xml,Procesar,ErrorEnvioAEC,AmbienteCertificacion) Values " &
                       "(" & _Idmaeedo & "," & _Id_Dte & ",'" & _Tido & "','" & _Nudo & "',Getdate(),'" & _RutCedente & "','" & _RutCesionario & "'," &
                       "'" & _RazonSocialCesionario & "','" & _DireccionCesionario & "','" & _eMailCesionario & "'," & De_Num_a_Tx_01(_MontoCesion, False, 5) &
                       ",'" & Format(_FUltimoVencimiento, "yyyyMMdd") & "','" & _RutAutoriza & "','" & _NombreAutoriza & "'," &
                       "'" & _eMailCedente & "','" & _NmbContacto & "','" & _FonoContacto & "','" & _MailContacto & "','',1,0," & _AmbienteCertificacion & ")"

        Dim _Id_Aec As Integer

        If Not _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Aec, False) Then
            _Errores.Add(_Sql.Pro_Error)
            Return 0
        End If

        Return _Id_Aec

    End Function

    Function Fx_AEC_EnviarCesion(_Id_Aec As Integer) As HefestoCesionV12.HefRespuesta 'As Integer

        Dim _Resp As New HefestoCesionV12.HefRespuesta

        Try

            _Errores.Clear()

            Dim _FullpathAEC = _Path & "\Data\" & RutEmpresaActiva & "\DTE\Documentos\AEC"
            Dim _PathSchemas = _Path & "\Schemas"
            Dim _PathCedidas = _FullpathAEC + "\XmlCedidas"

            If Not Directory.Exists(_FullpathAEC) Then
                System.IO.Directory.CreateDirectory(_FullpathAEC)
            End If

            If Not Directory.Exists(_PathCedidas) Then
                System.IO.Directory.CreateDirectory(_PathCedidas)
            End If

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_DTE_Aec Where Id_Aec = " & _Id_Aec
            Dim _Row_DteAec As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Id_Dte = _Row_DteAec.Item("Id_Dte")

            If IsNothing(_Row_DteAec) Then
                _Errores.Add("No se encontro el archivo en la tabla [Zw_DTE_Aec]")
                Throw New System.Exception(_Errores(0))
            End If

            Dim _Archivo_Xml As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_DTE_Documentos", "Xml", "Id_Dte = " & _Id_Dte)
            Dim _Tido As String = Maeedo.Rows(0).Item("TIDO")
            Dim _Nudo As String = Maeedo.Rows(0).Item("NUDO")
            Dim _Dir = _FullpathAEC

            If Not String.IsNullOrEmpty(_Archivo_Xml) Then

                If Not Directory.Exists(_Dir) Then
                    System.IO.Directory.CreateDirectory(_Dir)
                End If

                Dim _Nombre_Archivo = _Tido & "-" & _Nudo & ".xml"
                _Dir = _Dir & "\" & _Nombre_Archivo

                Dim oSW As New System.IO.StreamWriter(_Dir)

                oSW.WriteLine(_Archivo_Xml)
                oSW.Close()

                Dim _Existe_File = System.IO.File.Exists(_Dir)

                If Not _Existe_File Then
                    _Errores.Add("No se encontro el archivo " & _Dir)
                    Throw New System.Exception(_Errores(0))
                End If

            End If


            Dim _cesion As New HefAec(_Dir)

            If _AmbienteCertificacion Then
                _cesion.Configuracion.Ambiente.Procesamiento = HefAmbienteProcesamiento.Certificacion
            Else
                _cesion.Configuracion.Ambiente.Procesamiento = HefAmbienteProcesamiento.Produccion
            End If

            _cesion.Configuracion.ArchivoSchema.FullPath = _PathSchemas & "\AEC_v10.xsd"

            Dim _Cn As String
            Dim _RutEmisor As String

            Consulta_sql = "Select Id,Empresa,Campo,Valor,FechaMod,TipoCampo,TipoConfiguracion" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_DTE_Configuracion" & vbCrLf &
                           "Where Empresa = '" & ModEmpresa & "' And TipoConfiguracion = 'ConfEmpresa' And AmbienteCertificacion = " & _AmbienteCertificacion
            Dim _Tbl_ConfEmpresa As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            If Not CBool(_Tbl_ConfEmpresa.Rows.Count) Then
                _Errores.Add("Faltan los datos de configuración DTE para la empresa")
                Throw New System.Exception(_Errores(0))
            End If

            For Each _Fila As DataRow In _Tbl_ConfEmpresa.Rows

                Dim _Campo As String = _Fila.Item("Campo").ToString.Trim

                If _Campo = "RutEmisor" Then _RutEmisor = _Fila.Item("Valor")
                If _Campo = "Cn" Then _Cn = _Fila.Item("Valor")

            Next

            Dim _RutCedente As String = _Row_DteAec.Item("RutCedente")
            Dim _RutCesionario As String = _Row_DteAec.Item("RutCesionario")
            Dim _RazonSocialCesionario As String = _Row_DteAec.Item("RazonSocialCesionario")
            Dim _DireccionCesionario As String = _Row_DteAec.Item("DireccionCesionario")
            Dim _eMailCesionario As String = _Row_DteAec.Item("eMailCesionario")
            Dim _NmbContacto As String = _Row_DteAec.Item("NmbContacto")
            Dim _FonoContacto As String = _Row_DteAec.Item("FonoContacto")
            Dim _MailContacto As String = _Row_DteAec.Item("MailContacto")
            Dim _RutAutoriza As String = _Row_DteAec.Item("RutAutoriza")
            Dim _NombreAutoriza As String = _Row_DteAec.Item("NombreAutoriza")
            Dim _eMailCedente As String = _Row_DteAec.Item("eMailCedente")

            If _AmbienteCertificacion Then
                _eMailCedente = _MailContacto
            End If

            'Identifique el certificado a utilizar para firmar y enviar el AEC
            _cesion.Configuracion.Certificado.Cn = _Cn
            _cesion.Configuracion.Certificado.Rut = _RutEmisor

#Region "CONSTRUIR EL DOCUMENTO AEC"

            Dim _Fecha = FechaDelServidor.ToString("yyyy-MM-ddTHH:mm:ss")

            ' Complete la cesion ( Caratula )
            _cesion.DocumentoAEC.Caratula.RutCedente = _RutCedente '"85904700-9"
            _cesion.DocumentoAEC.Caratula.RutCesionario = _RutCesionario '"97036000-K"
            _cesion.DocumentoAEC.Caratula.NmbContacto = _NmbContacto '"ROCIO AGUILAR"
            _cesion.DocumentoAEC.Caratula.FonoContacto = _FonoContacto '"22 8213320"
            _cesion.DocumentoAEC.Caratula.MailContacto = _MailContacto '"r.aguiar@alimentoscisternas.cl"
            _cesion.DocumentoAEC.Caratula.TmstFirmaEnvio = _Fecha

            ' Cedente = Datos del dueño del documento, generalmente es Emisor, a veces no.
            ' Agregar los datos del cedente del documento.
            _cesion.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cedente.RUT = _RutCedente '"85904700-9"
            _cesion.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cedente.RazonSocial = RazonEmpresa '_Maeen.Rows(0).Item("NOKOEN").ToString.Trim '
            _cesion.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cedente.Direccion = DireccionEmpresa '_Maeen.Rows(0).Item("DIEN").ToString.Trim ''"3 PONIENTE PARCELA 79-A"
            _cesion.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cedente.eMail = _eMailCedente
            _cesion.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cedente.RUTAutorizado.RUT = _RutAutoriza '"8711086-9"
            _cesion.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cedente.RUTAutorizado.Nombre = _NombreAutoriza '"CARLOS MARCELO CISTERNAS HOCES"

            ' Agregar los datos del cesionario de documento
            _cesion.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cesionario.RUT = _RutCesionario '"97036000-K"
            _cesion.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cesionario.RazonSocial = _RazonSocialCesionario '"BANCO SANTANDER CHILE"
            _cesion.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cesionario.Direccion = _DireccionCesionario '"BOMBERO OSSA 1068 PISO 5"
            _cesion.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cesionario.eMail = _eMailCesionario '"confirmingvox@santander.cl"

            Dim _MontoCesion As Double = _Row_DteAec.Item("MontoCesion") '_Maeedo.Rows(0).Item("VABRDO")
            Dim _FUltimoVencimiento As DateTime = _Row_DteAec.Item("FUltimoVencimiento") '_Maeedo.Rows(0).Item("FEULVEDO") ' FechaDelServidor.ToString("yyyy-MM-ddTHH:mm:ss")

            ' Datos adicionales de la cesion
            _cesion.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.MontoCesion = _Maeedo.Rows(0).Item("VABRDO")
            _cesion.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.UltimoVencimiento = _FUltimoVencimiento.ToString("yyyy-MM-dd")
            _cesion.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.TmstCesion = _Fecha

            'Inicie la publicacion del documento
            _Resp = _cesion.PublicarDocumento()
            Dim _Id_Trackid As Integer

            My.Computer.FileSystem.DeleteFile(_Dir, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

            If _Resp.EsCorrecto Then

                Dim _Xml As String = _Resp.Resultado.ToString()
                Dim _Trackid As String = _Resp.Trackid
                Dim _DeclaracionJurada As String = _cesion.DocumentoAEC.Cesiones.Cesion.DocumentoCesion.Cedente.DeclaracionJurada
                Dim _Respuestas As String = _Resp.Detalle
                _Resp.Mensaje = _DeclaracionJurada

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Aec Set " &
                               "Procesar = 0,Procesado = 1,[Xml] = '" & _Xml & "',DeclaracionJurada = '" & _DeclaracionJurada & "'" & vbCrLf &
                               "Where Id_Aec = " & _Id_Aec
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DTE_Trackid (Idmaeedo,Trackid,Estado,Glosa,Respuesta,FechaEnvSII," &
                               "AmbienteCertificacion,Procesar,Procesado,Intentos,Id_Aec) Values " &
                               "(" & _Idmaeedo & ",'" & _Trackid & "','','" & _Respuestas & "','',Getdate()," & _AmbienteCertificacion & ",1,0,0," & _Id_Aec & ")"
                _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Trackid, False)
                'File.WriteAllText(_PathCedidas & _Resp.NombreArchivoAec, _Resp.Resultado.ToString(), Encoding.GetEncoding("ISO-8859-1"))

            Else
                _Errores.Add(_Resp.Detalle)
                Throw New System.Exception(_Errores(0))
            End If

        Catch ex As Exception
            _Resp.EsCorrecto = False
            _Errores.Add(ex.Message)
            _Resp.Detalle = _Errores(0)
        End Try

#End Region

        Return _Resp '_Id_Trackid

    End Function

    Function Fx_GlosaEstados(_Estado As String,
                             ByRef _Aceptado As Integer,
                             ByRef _Rechazado As Integer,
                             ByRef _VolverProcesar As Boolean) As String

        _Aceptado = 0
        _Rechazado = 0
        _VolverProcesar = False

        Select Case _Estado
            Case "RSC"
                _Rechazado = 1
                Return "Rechazado por Error en Schema"
            Case "SOK"
                _VolverProcesar = True
                Return "Schema Validado"
            Case "CRT"
                _VolverProcesar = True
                Return "Carátula OK"
            Case "RFR"
                _Rechazado = 1
                Return "Rechazado por Error en Firma"
            Case "FOK"
                _VolverProcesar = True
                Return "Firma de Envió Validada"
            Case "PDR"
                _VolverProcesar = True
                Return "Envió en Proceso"
            Case "RCT"
                _Rechazado = 1
                Return "Rechazado por Error en Carátula"
            Case "EPR"
                _Aceptado = 1
                Return "Envió Procesado"
            Case "-1"
                _VolverProcesar = True
                Return "ERROR: RETORNO CAMPO ESTADO, NO EXISTE"
            Case "-2"
                _VolverProcesar = True
                Return "ERROR RETORNO"
            Case "-3"
                _VolverProcesar = True
                Return "ERROR: RUT USUARIO NO EXISTE"
            Case "-4"
                _VolverProcesar = True
                Return "ERROR OBTENCION DE DATOS"
            Case "-5"
                _VolverProcesar = True
                Return "ERROR RETORNO DATOS"
            Case "-6"
                _VolverProcesar = True
                Return "ERROR: USUARIO NO AUTORIZADO"
            Case "-7"
                _VolverProcesar = True
                Return "ERROR RETORNO DATOS"
            Case "-8"
                _VolverProcesar = True
                Return "ERROR: RETORNO DATOS"
            Case "-9"
                Return "ERROR: RETORNO DATOS"
            Case "-10"
                _VolverProcesar = True
                Return "ERROR: VALIDA RUT USUARIO"
            Case "-11"
                _VolverProcesar = True
                Return "ERR_CODE, SQL_CODE, SRV_CODE"
            Case "-12"
                _VolverProcesar = True
                Return "ERROR: RETORNO CONSULTA"
            Case "-13"
                _VolverProcesar = True
                Return "ERROR RUT USUARIO NULO"
            Case "-14"
                _VolverProcesar = True
                Return "ERROR XML RETORNO DATOS"
            Case "001"
                _Rechazado = 1
                Return "COOKIE INACTIV"
            Case "002"
                _Rechazado = 1
                Return "TOKEN+INACTIVO"
            Case "003"
                _Rechazado = 1
                Return "NO+EXISTE"
            Case Else
                Return ""
        End Select

    End Function

End Class
