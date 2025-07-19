Imports System.ComponentModel
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class Cl_LibroDTESII

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim WithEvents _Tiempo As Timer
    Dim WithEvents _BackgroundWorker As New BackgroundWorker

    Dim _Lbl_Estado As String
    Dim _Procesando As Boolean
    Dim _Fecha_Revision As Date
    Dim _Nombre_Equipo As String
    Dim _Path As String
    Dim _Solo_Marcar_No_Imprimir As Boolean
    Dim Lbl_LibroDTESII As New LabelX

    Dim _Segundos_Correo As Integer
    Dim _Input_Tiempo_Correo As Integer

    Dim _Periodo As Integer
    Dim _Mes As Integer
    Dim _Libro_Bajado As Boolean
    Dim _Reenviar_Documentos_al_SII As Boolean

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

    Public Property Solo_Marcar_No_Imprimir As Boolean
        Get
            Return _Solo_Marcar_No_Imprimir
        End Get
        Set(value As Boolean)
            _Solo_Marcar_No_Imprimir = value
        End Set
    End Property

    Public Sub New()

        _BackgroundWorker.WorkerReportsProgress = True
        _BackgroundWorker.WorkerSupportsCancellation = True

        _Lbl_Estado = "Monitoreo Cola Impresión Automática"

    End Sub

    Sub Sb_Iniciar(Periodo As Integer, Mes As Integer, Libro_Bajado As Boolean, Reenviar_Documentos_al_SII As Boolean)

        _Periodo = Periodo
        _Mes = Mes
        _Libro_Bajado = Libro_Bajado
        _Reenviar_Documentos_al_SII = Reenviar_Documentos_al_SII

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

            Sb_Procedimiento_LibroDTESII(_Periodo, _Mes, True, True, True, _Libro_Bajado, _Reenviar_Documentos_al_SII)

            If _Libro_Bajado Then

                If _Mes = 1 Then
                    _Periodo -= 1 : _Mes = 12
                Else
                    _Mes -= 1
                End If

                Sb_Procedimiento_LibroDTESII(_Periodo, _Mes, False, False, True, _Libro_Bajado, False)

            End If

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
        _Lbl_Estado = "Monitoreo Cola Impresión Automática"

    End Sub

    Sub Sb_Procedimiento_LibroDTESII(_Periodo As Integer,
                                     _Mes As Integer,
                                     _Bajar_Libros As Boolean,
                                     _Revisar_Libro_Ventas As Boolean,
                                     _Revisar_Libro_Compras As Boolean,
                               ByRef _Libro_Bajado As Boolean,
                                     _Reenviar_Documentos_al_SII As Boolean)


        Dim _Error = String.Empty

        'Dim _Estatus As String = Lbl_LibroDTESII.Text

        Dim _Clas_Hefesto_Dte_Libro As New Clas_Hefesto_Dte_Libro

        'CircularLibroDTESII.ProgressBarType = eCircularProgressType.Donut

        Dim CircularLibroDTESII As New CircularProgress

        _Clas_Hefesto_Dte_Libro.Circular_Progres_Porc = CircularLibroDTESII

        '_Ubic_Archivo = "D:\OneDrive\Documentos\Empresas\Sierralta\Hefesto_DTE\CONFIGURACION\Salida\" & RutEmpresa & "\" & _Periodo

        If _Bajar_Libros Then

            If System.IO.File.Exists(_Clas_Hefesto_Dte_Libro.Directorio_Hefesto & "\SISTEMA\HEFESTO_LIBROS.exe") Then

                Dim _Cadena_ConexionSQL_Server_Actual As String = Replace(Cadena_ConexionSQL_Server, " ", "@")
                Dim _Ejecutar As String = _Clas_Hefesto_Dte_Libro.Directorio_Hefesto & "\SISTEMA\HEFESTO_LIBROS.exe" & Space(1) & RutEmpresa & Space(1) & _Periodo & "-" & numero_(_Mes, 2)

                Try

                    Shell(_Ejecutar, AppWinStyle.MinimizedNoFocus, True)
                    _Libro_Bajado = True

                Catch ex As Exception

                    _Error = ex.Message

                End Try

            Else

                _Error = "No se encontro el archivo HEFESTO_LIBROS.exe en el directorio (" & _Clas_Hefesto_Dte_Libro.Directorio_Hefesto & "\SISTEMA)"

            End If

        Else

            _Libro_Bajado = True

        End If

        If _Libro_Bajado Then

            Dim _Frm As New Form

            _Clas_Hefesto_Dte_Libro.Formulario = _Frm 'Me

            If _Revisar_Libro_Ventas Then
                'Revisión de libro de ventas
                _Clas_Hefesto_Dte_Libro.Estatus = Lbl_LibroDTESII
                _Clas_Hefesto_Dte_Libro.Fx_Importar_Archivo_SII_Ventas_Desde_XML(_Periodo, _Mes, _Reenviar_Documentos_al_SII)
            End If

            If _Revisar_Libro_Compras Then
                'Revisión de libro de compras
                _Clas_Hefesto_Dte_Libro.Estatus = Lbl_LibroDTESII
                _Clas_Hefesto_Dte_Libro.Fx_Importar_Archivo_SII_Compras_Desde_XML(_Periodo, _Mes)

            End If

        End If

        'Lbl_LibroDTESII.Text = _Estatus

        If Not String.IsNullOrEmpty(_Error) Then

            'Switch_LibroDTESII.Value = False
            CircularLibroDTESII.Visible = False
            Lbl_LibroDTESII.Text = "Monitoreo Libro DTE desde SII, ERROR!!!"
            Fx_Add_Log_Gestion(FUNCIONARIO, Mod_Modalidad, "", 0, "Demonio_Error", _Error, "", "", "", "", False, "")

        End If

        CircularLibroDTESII.ProgressBarType = eCircularProgressType.Line

        'Sb_Pausar(_Pausa.Play)

    End Sub

End Class
