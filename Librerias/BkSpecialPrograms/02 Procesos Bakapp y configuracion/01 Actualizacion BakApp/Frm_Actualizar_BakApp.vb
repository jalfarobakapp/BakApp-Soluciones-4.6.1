Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Net

Public Class Frm_Actualizar_BakApp

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Path_Ejecutables = AppPath()
    Dim _URL_Descarga As String
    Dim _Regresivo As Integer = 10

    Dim _Nombre_Archivo As String
    Dim _Ruta_Y_Archivo_Actualizacion As String
    Dim _Version_Nueva As String

    Dim _Directorio_Destino As String
    Dim _Dir_Temp = AppPath() & "\Data\Tmp\Actualizacion"

    Dim _Descarga_Completa As Boolean
    Dim _Descargas As Integer
    Dim _Descarga_Por_Link As Boolean

    Dim _Accion As Enum_Accion
    Enum Enum_Accion
        Descargar_Instalar
        Descargar
    End Enum

    Dim WithEvents _Cliente As New WebClient

    Public ReadOnly Property Pro_Nombre_Archivo()
        Get
            Return _Nombre_Archivo
        End Get
    End Property
    Public Property Descarga_Completa As Boolean
        Get
            Return _Descarga_Completa
        End Get
        Set(value As Boolean)
            _Descarga_Completa = value
        End Set
    End Property
    Public Property Ruta_Y_Archivo_Actualizacion As String
        Get
            Return _Ruta_Y_Archivo_Actualizacion
        End Get
        Set(value As String)
            _Ruta_Y_Archivo_Actualizacion = value
        End Set
    End Property

    Public Property Directorio_Destino As String
        Get
            Return _Directorio_Destino
        End Get
        Set(value As String)
            _Directorio_Destino = value
        End Set
    End Property

    Public Property Descarga_Por_Link As Boolean
        Get
            Return _Descarga_Por_Link
        End Get
        Set(value As Boolean)
            _Descarga_Por_Link = value
        End Set
    End Property

    Public Sub New(URL_Descarga As String, Nombre_Archivo As String, Version_Nueva As Integer, _Accion As Enum_Accion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Not Directory.Exists(_Dir_Temp) Then
            System.IO.Directory.CreateDirectory(_Dir_Temp)
        End If

        If Not Directory.Exists(_Dir_Temp & "\Versiones") Then
            System.IO.Directory.CreateDirectory(_Dir_Temp & "\Versiones")
        End If

        _Dir_Temp = _Dir_Temp & "\Versiones"

        _URL_Descarga = URL_Descarga
        _Nombre_Archivo = Nombre_Archivo
        _Version_Nueva = Version_Nueva

        Link_Descarga.Text = _URL_Descarga
        Link_Descarga.LinkColor = Azul
        Link_Descarga.ActiveLinkColor = Rojo

        Me._Accion = _Accion

    End Sub

    Private Sub Frm_Actualizar_BakApp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = "Actualización BakApp Versión: " & _Version_Nueva

        If _Accion = Enum_Accion.Descargar Then
            Btn_Descargar_Actualizacion.Text = "DESCARGAR..."
        End If

        If _Accion = Enum_Accion.Descargar_Instalar Then
            Btn_Descargar_Actualizacion.Text = "DESCARGAR E INSTALAR"
        End If

        _Directorio_Destino = _Dir_Temp
        _Ruta_Y_Archivo_Actualizacion = _Dir_Temp & "\" & _Nombre_Archivo

    End Sub
    Sub Sb_Descargar_Version()

        Btn_Descargar_Actualizacion.Enabled = False

        Try
            My.Computer.FileSystem.DeleteFile(_Dir_Temp & "\Archivo_Descarga_Tmp")
        Catch ex As Exception

        End Try

        If System.IO.File.Exists(_Ruta_Y_Archivo_Actualizacion) Then
            My.Computer.FileSystem.DeleteFile(_Ruta_Y_Archivo_Actualizacion)
        End If

        Try

            Dim _Uri As New Uri(_URL_Descarga)

            _Cliente = New WebClient
            _Cliente.DownloadFileAsync(_Uri, _Dir_Temp & "\Archivo_Descarga_Tmp")

        Catch ex As Exception

        End Try

    End Sub
    Sub Cliente_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles _Cliente.DownloadProgressChanged
        Barra_Progreso.Value = e.ProgressPercentage
        GroupBox1.Text = "Descargando ... " & e.ProgressPercentage & " %"
    End Sub
    Sub Cliente_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles _Cliente.DownloadFileCompleted

        _Descargas += 1
        GroupBox1.Text = "Descargando ... 100 %"
        System.Windows.Forms.Application.DoEvents()

        Try
            My.Computer.FileSystem.DeleteFile(_Ruta_Y_Archivo_Actualizacion)
        Catch ex As Exception

        End Try

        FileSystem.Rename(_Dir_Temp & "\Archivo_Descarga_Tmp", _Ruta_Y_Archivo_Actualizacion)

        Dim _Existe = System.IO.File.Exists(_Ruta_Y_Archivo_Actualizacion)

        If _Existe Then

            _Descarga_Completa = True
            Me.Close()

        End If

    End Sub

    Private Sub Bnt_Copiar_Link_Descarga_Portapapeles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bnt_Copiar_Link_Descarga_Portapapeles.Click

        Clipboard.SetText(_URL_Descarga)

        Dim _Valida_Sitio = UCase(Fx_Validar_Sitio_Web(_URL_Descarga))

        If _Valida_Sitio = "OK" Then

            System.Diagnostics.Process.Start(_URL_Descarga)

            MessageBoxEx.Show(Me, "Si la página de descarga no se abre, el link de descarga estará en el portapapeles" & vbCrLf &
                             "El sistema se cerrara para que realice la actualización.",
                             "Descarga manual", MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Descarga_Completa = True

        End If

        Me.Close()

    End Sub

    Private Sub Tiempo_Cierre_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tiempo_Cierre.Tick
        Me.Close()
    End Sub


    Private Sub Link_Descarga_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Link_Descarga.LinkClicked

        Clipboard.SetText(_URL_Descarga)

        Try
            System.Diagnostics.Process.Start(_URL_Descarga)

            MessageBoxEx.Show(Me, "Si la página de descarga no se abre, el link de descarga estará en el portapapeles" & vbCrLf &
                                 "El sistema se cerrara para que realice la actualización.",
                                 "Descarga manual", MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Descarga_Por_Link = True

            Me.Close()
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Btn_Descargar_Actualizacion_Click(sender As Object, e As EventArgs) Handles Btn_Descargar_Actualizacion.Click
        Try
            My.Computer.FileSystem.DeleteFile(_Dir_Temp & "\" & _Nombre_Archivo)
        Catch ex As Exception

        End Try

        Try
            My.Computer.FileSystem.DeleteFile(_Ruta_Y_Archivo_Actualizacion)
        Catch ex As Exception

        End Try

        Sb_Descargar_Version()
    End Sub
End Class
