Imports System.IO
Imports DevComponents.DotNetBar
Imports HEFESTO.FIRMA.DOC.FORM
Imports HEFESTO.FIRMA.DOCUMENTO
Imports BkSpecialPrograms

Public Class Form1

    Dim _Cn As String
    Dim _uriCaf As String
    Dim _uriDte As String
    Dim _RutaArchivo As String
    Dim _Nombre_Archivo_Xml As String

    Dim _Formulario_Padre As Form

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Cn = "JUAN PABLO SIERRALTA OREZZOLI"
        _uriCaf = "D:\Nube OneDrive\OneDrive\Documentos\Empresas\Smartrading\CAF Enero\NCV\FoliosSII7659092061192022161442.xml"
        _Nombre_Archivo_Xml = "FCV-0000001124_DTE.xml"
        _RutaArchivo = "D:\Nube OneDrive\OneDrive\Documentos\Empresas\Smartrading"
        _uriDte = _RutaArchivo & "\" & _Nombre_Archivo_Xml

        _Global_Version_BakApp = _Version_BakApp
        _Configuracion_Regional_()
        Me.Hide()

        ' Leer los parámetros de la línea de comandos
        ' y mostrarlos en la caja de textos
        '
        ' Para probar, indicar esto en CommandLine arguments en propiedades
        'Prueba1 prueba2 /file:Nombre del fichero
        '
        ' Comprobar si hay más de un parámetro,
        ' el parámetro CERO es el nombre del ejecutable

        'Cadena_ConexionSQL_Server = "data source = SIERRALTA; initial catalog = SIERRALTA; user id = SIERRALTA; password = SIERRALTA"
        'Cadena_ConexionSQL_Server = Replace(Cadena_ConexionSQL_Server, " ", "@")

        Dim _Ejecutar_Demonio As Boolean

        If Environment.GetCommandLineArgs.Length > 1 Then

            Cadena_ConexionSQL_Server = Environment.GetCommandLineArgs(1)
            'MessageBoxEx.Show(Me, Cadena_ConexionSQL_Server, "Cadena", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cadena_ConexionSQL_Server = Replace(Cadena_ConexionSQL_Server, "@", " ")
            'MessageBoxEx.Show(Me, Cadena_ConexionSQL_Server, "Cadena", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _Ejecutar_Demonio = True

        Else

            Tiempo_Alerta.Start()

        End If

        'If _Ejecutar_Demonio Then

        '    Sb_Ejecutar_Demonio()

        'End If


        Cadena_ConexionSQL_Server = "data source = SIERRALTA; initial catalog = SMARTRADING; user id = SMARTRADING; password = SMARTRADING"

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click

        Dim Fm As New Proceso
        Dim _Indes = 0
        For Each Fl In Fm.cmbCertificados.DataSource

            If Fl = "JUAN PABLO SIERRALTA OREZZOLI" Then
                Fm.cmbCertificados.SelectedIndex = _Indes
                Exit For
            End If
            _Indes += 1
            'Fm.CN = "JUAN PABLO SIERRALTA OREZZOLI"

        Next

        Fm.RutaCAF = "D:\Nube OneDrive\OneDrive\Documentos\Empresas\Smartrading\CAF Enero\NCV\FoliosSII7659092061192022161442.xml"
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click

        '////
        '   //// Inicie el proceso de timbraje y firma de documentos
        '   HEFFirmarDocumento clsFirmarDocumento = New HEFFirmarDocumento();
        '   clsFirmarDocumento.CN = this.CN;
        '   clsFirmarDocumento.uriCaf = this.uriCaf;
        '   clsFirmarDocumento.uriDte = this.uriDte;
        '   clsFirmarDocumento.uriEnvioDte = this.uriEnvioDte;
        '   clsFirmarDocumento.uriSchemaDte = "Schemas\\DTE_v10.xsd";
        '   clsFirmarDocumento.uriSchemaDteSf = "Schemas\\DTE_v10_Sf.xsd";
        '   clsFirmarDocumento.uriSchemaEnvioDteSf = "Schemas\\EnvioDTE_v10_Sf.xsd";
        '   clsFirmarDocumento.uriSchemaEnvioDte = "Schemas\\EnvioDTE_v10.xsd";

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_sql As String

        Consulta_sql = "Select * From CONFIGP"

        Dim _Row_Configp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _RutEmisor As String = _Row_Configp.Item("FIRMAELEC").ToString.Trim
        Dim _RutEnvia As String = _Row_Configp.Item("RUT").ToString.Trim
        Dim _RutReceptor As String = "60803000-K"
        Dim _FchResol As String = Format(_Row_Configp.Item("FECHRESOL"), "yyyy-MM-dd")
        Dim _NroResol As String = _Row_Configp.Item("NRORESOL").ToString.Trim
        Dim _TpoDTE As String

        Dim ClsFirmarDocumento As New HEFFirmarDocumento

        With ClsFirmarDocumento

            If Not .CargarDocumento(_uriDte) Then
                MessageBoxEx.Show(Me, "No se encontro el documento: " & _Nombre_Archivo_Xml & vbCrLf &
                                  _uriDte, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            _TpoDTE = .TipoDTE

            If Not .CrearEnvioDte(_RutEmisor, _RutEnvia, _RutReceptor, _FchResol, _NroResol, _TpoDTE) Then
                MessageBoxEx.Show(Me, .Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            .CN = _Cn '"JUAN PABLO SIERRALTA OREZZOLI"
            .uriCaf = _uriCaf
            .uriDte = _uriDte
            '.uriEnvioDte = _uriEnvioDte
            .uriSchemaDte = "Schemas\\DTE_v10.xsd"
            .uriSchemaDteSf = "Schemas\\DTE_v10_Sf.xsd"
            .uriSchemaEnvioDte = "Schemas\\EnvioDTE_v10.xsd"

        End With

        Dim ArchivoFirmado As String = Path.GetFileName(Path.ChangeExtension(_uriDte, ".Firmado.xml"))

        Dim Respuesta As HEFRespuesta = ClsFirmarDocumento.FirmarArchivo()

        If Not Respuesta.esCorrecto Then
            Dim val As Validacion = New Validacion()
            val.errores = Respuesta.Mensaje
            val.ShowDialog()
            Return
        End If

        Dim uriDocumentoFirmado As String = Respuesta.Resultado.ToString()
        Dim name As String = _RutaArchivo & "\" & ArchivoFirmado
        If File.Exists(name) Then File.Delete(name)
        File.Copy(uriDocumentoFirmado, name)

        MessageBoxEx.Show(Me, "Archivo firmado correctamente" & vbCrLf &
                          name, "Firmar", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Tiempo_Alerta_Tick(sender As Object, e As EventArgs) Handles Tiempo_Alerta.Tick

        Tiempo_Alerta.Stop()

        MessageBoxEx.Show(Me, "No se han indicado parámetros en la línea de comandos" & vbCrLf &
                            "El nombre (y path) del ejecutable es:" & vbCrLf &
                            Environment.GetCommandLineArgs(0), "Falta String de conexión", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Dim _Fmdb As New Frm_ConexionBD()
        _Fmdb.BtnAgregar.Visible = False
        _Fmdb.ShowDialog(Me)
        Dim _RowConexion As DataRow = _Fmdb.Pro_RowConexion
        _Fmdb.Dispose()

        If Not (_RowConexion Is Nothing) Then

            Dim _Cadena = "data source = #SV#; initial catalog = #BD#; user id = #US#; password = #PW#"

            Dim SV, PT, BD, US, PW As String

            SV = _RowConexion.Item("Servidor")
            PT = _RowConexion.Item("Puerto")
            US = _RowConexion.Item("Usuario")
            PW = _RowConexion.Item("Clave")
            BD = _RowConexion.Item("BaseDeDatos")

            If Trim(PT) <> "" Then
                SV = Trim(SV & "," & PT)
            End If

            _Cadena = Replace(_Cadena, "#SV#", SV)
            _Cadena = Replace(_Cadena, "#BD#", BD)
            _Cadena = Replace(_Cadena, "#US#", US)
            _Cadena = Replace(_Cadena, "#PW#", PW)
            Cadena_ConexionSQL_Server = _Cadena
            'Sb_Ejecutar_Demonio()

        Else

            Application.ExitThread()

        End If

    End Sub
End Class
