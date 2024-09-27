Imports System.ComponentModel
Public Class Cl_Consolidacion_Stock

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
    Dim _Ruta_Archivador As String

    Dim _Segundos_Correo As Integer
    Dim _Input_Tiempo_Correo As Integer
    Dim _Cons_Stock_Todos As Boolean
    Dim _Cons_Stock_Mov_Hoy As Boolean

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

    Public Property Ruta_Archivador As String
        Get
            Return _Ruta_Archivador
        End Get
        Set(value As String)
            _Ruta_Archivador = value
        End Set
    End Property

    Public Property Cons_Stock_Todos As Boolean
        Get
            Return _Cons_Stock_Todos
        End Get
        Set(value As Boolean)
            _Cons_Stock_Todos = value
        End Set
    End Property

    Public Property Cons_Stock_Mov_Hoy As Boolean
        Get
            Return _Cons_Stock_Mov_Hoy
        End Get
        Set(value As Boolean)
            _Cons_Stock_Mov_Hoy = value
        End Set
    End Property

    Public Property Log_Registro As String
    Public Property Ejecutar As Boolean
    Public Sub New()

        _BackgroundWorker.WorkerReportsProgress = True
        _BackgroundWorker.WorkerSupportsCancellation = True

        _Lbl_Estado = "Consolidación de stock"

    End Sub

    Sub Sb_Iniciar()

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
            Dim _Form As New Form
            Sb_Procedimiento_Consolidar_Stock(_Form)

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
        _Lbl_Estado = "Consolidación de stock"

    End Sub

    Sub Sb_Procedimiento_Consolidar_Stock(_Formulario As Form)

        'Procesando = True

        Dim _Tbl_Productos As DataTable

        Dim _Fecha = Format(_Fecha_Revision, "yyyyMMdd")
        Dim _Hora_Inicio = Date.Now.ToShortTimeString

        If _Cons_Stock_Todos Then
            Consulta_Sql = "SELECT KOPR AS 'Codigo', NOKOPR AS 'Descripcion' FROM MAEPR" & vbCrLf &
                           "WHERE ATPR = '' AND TIPR = 'FPN'"
        ElseIf _Cons_Stock_Mov_Hoy Then
            Consulta_Sql = "SELECT KOPR AS 'Codigo', NOKOPR AS 'Descripcion' FROM MAEPR" & vbCrLf &
                           "WHERE ATPR = '' AND TIPR = 'FPN' AND" & Space(1) &
                           "KOPR IN (SELECT Distinct KOPRCT FROM MAEDDO WHERE FEEMLI = '" & _Fecha & "')"
        End If

        _Tbl_Productos = _Sql.Fx_Get_DataTable(Consulta_Sql, False)

        If Not IsNothing(_Tbl_Productos) AndAlso CBool(_Tbl_Productos.Rows.Count) Then

            Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos, "", "Codigo", False, False, "'")

            'Dim _Formulario As New Form

            Dim Fm As New Frm_Consolidacion_Stock_PP(_Filtro_Productos)
            Fm.Pro_Ejecutar_Automaticamente = True
            Fm.TopMost = True
            Fm.ShowDialog(_Formulario)
            Fm.Dispose()

            Dim _Hora_Termino = Date.Now.ToShortTimeString

            Log_Registro = "Consolidación de stock..." & vbCrLf &
                           vbTab & "Productos: " & FormatNumber(_Tbl_Productos.Rows.Count, 0) & Space(1) &
                           vbCrLf & "Hora inicio: " & _Hora_Inicio & ", Hora termino: " & _Hora_Termino

            'Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "", 0, "Consolidacion",
            '                   "Consolidación de stock automaticamente desde el diablito según programación..." & Space(1) &
            '                   "Productos: " & FormatNumber(_Tbl_Productos.Rows.Count, 0) & Space(1) &
            '                   "Hora inicio: " & _Hora_Inicio & ", Hora termino: " & _Hora_Termino,
            '                   "", "", "", "", 0, "")

        End If

        'Procesando = False

    End Sub

End Class
