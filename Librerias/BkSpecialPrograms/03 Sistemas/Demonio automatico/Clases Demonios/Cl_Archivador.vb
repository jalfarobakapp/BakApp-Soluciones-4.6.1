Imports System.ComponentModel
Imports System.IO
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class Cl_Archivador

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

    Public Property Log_Registro As String

    Public Sub New()

        _BackgroundWorker.WorkerReportsProgress = True
        _BackgroundWorker.WorkerSupportsCancellation = True

        _Lbl_Estado = "Monitoreo archivador de documentos"

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

            Sb_Procedimiento_Archivar_Documentos(False)

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
        _Lbl_Estado = "Monitoreo archivador de documentos"

    End Sub

    Sub Sb_Procedimiento_Archivar_Documentos(_Incluir_Levantados As Boolean)

        Procesando = True

        Dim _Year As String = _Fecha_Revision.Year.ToString
        Dim _Month As String = numero_(_Fecha_Revision.Month, 2)
        Dim _Month_Palabra As String = Fx_Mes_Palabra(_Month)
        Dim _Day As String = numero_(_Fecha_Revision.Day, 2)

        Dim _Ruta_Year As String = _Ruta_Archivador & "\" & _Year
        Dim _Ruta_Month As String = _Ruta_Year & "\" & _Month & " " & _Month_Palabra
        Dim _Ruta_Dia As String = _Ruta_Year & "\" & _Month & " " & _Month_Palabra & "\" & _Day
        Dim _Ruta_Archivo As String

        If Not Directory.Exists(_Ruta_Archivador) Then
            System.IO.Directory.CreateDirectory(_Ruta_Archivador)
        End If

        If Not Directory.Exists(_Ruta_Year) Then
            System.IO.Directory.CreateDirectory(_Ruta_Year)
        End If

        If Not Directory.Exists(_Ruta_Month) Then
            System.IO.Directory.CreateDirectory(_Ruta_Month)
        End If

        If Not Directory.Exists(_Ruta_Dia) Then
            System.IO.Directory.CreateDirectory(_Ruta_Dia)
        End If

        Dim _Fecha = Format(_Fecha_Revision, "yyyyMMdd")

        Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Demonio_Archivador Where Fecha < '" & _Fecha & "'"
        _Sql.Ej_consulta_IDU(Consulta_Sql)

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_Archivador (Idmaeedo,Tido,Nudo,Fecha)
                        Select IDMAEEDO,TIDO,NUDO,FEEMDO From MAEEDO
                        Where FEEMDO = '" & _Fecha & "'
                        And IDMAEEDO Not In (Select Idmaeedo From " & _Global_BaseBk & "Zw_Demonio_Archivador Where Fecha = '" & _Fecha & "') And NUDONODEFI = 0"
        _Sql.Ej_consulta_IDU(Consulta_Sql)

        Dim _Archivado As String = "And Archivado = 0"

        If _Incluir_Levantados Then
            _Archivado = String.Empty
        End If

        Dim _Ruta_Documentos As String = _Ruta_Dia & "\Documentos"

        If Not Directory.Exists(_Ruta_Documentos) Then
            System.IO.Directory.CreateDirectory(_Ruta_Documentos)
        End If

        Dim _Ruta_Pagos As String = _Ruta_Dia & "\Pagos"

        If Not Directory.Exists(_Ruta_Pagos) Then
            System.IO.Directory.CreateDirectory(_Ruta_Pagos)
        End If

        _Ruta_Pagos = _Ruta_Pagos & "\Pagos_" & _Fecha & ".xml"

        Consulta_Sql = "Select * From MAEDPCE Where FEEMDP = '" & _Fecha & "'
                        Select Mdp.*,Isnull(Edo.TIDO,Mdp.TIDOPA),Isnull(Edo.NUDO,'') As NUDO From MAEDPCD Mdp 
                        Left Join MAEEDO Edo On Edo.IDMAEEDO = Mdp.IDRST
                        Where Mdp.LAHORA = '" & _Fecha & "'"

        Dim _Dsp As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql, True)
        _Dsp.Tables(0).TableName = "Maedpce"
        _Dsp.Tables(1).TableName = "Maedpcd"
        _Dsp.WriteXml(_Ruta_Pagos)

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_Archivador 
                        Where Fecha = '" & _Fecha & "' " & _Archivado
        Dim _Tbl_Archivos As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Dim _Leyenda As String = _Tbl_Archivos.Rows.Count
        Dim _Contador = 0

        For Each _Fila As DataRow In _Tbl_Archivos.Rows

            Dim _Idmaeedo As Integer = _Fila.Item("Idmaeedo")
            Dim _Tido As String = _Fila.Item("Tido")
            Dim _Nudo As String = _Fila.Item("Nudo")

            Dim _Ruta_Tido As String = _Ruta_Documentos & "\" & _Tido

            If Not Directory.Exists(_Ruta_Tido) Then
                System.IO.Directory.CreateDirectory(_Ruta_Tido)
            End If

            _Ruta_Archivo = _Ruta_Tido & "\" & _Tido & "-" & _Nudo & ".xml"

            Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo & "
                            Select * From MAEDDO Where IDMAEEDO = " & _Idmaeedo & "
                            Select * From MAEIMLI Where IDMAEEDO = " & _Idmaeedo & "
                            Select * From MAEDTLI Where IDMAEEDO = " & _Idmaeedo & "
                            Select * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo & "
                            Select * From MAEVEN Where IDMAEEDO = " & _Idmaeedo & "
                            Select MAEEN.* From MAEEN 
                                Inner Join MAEEDO On ENDO = KOEN And SUENDO = SUEN 
                                Where IDMAEEDO = " & _Idmaeedo

            Try

                Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql, True)

                _Ds.Tables(0).TableName = "Maeedo"
                _Ds.Tables(1).TableName = "Maeddo"
                _Ds.Tables(2).TableName = "Maeimli"
                _Ds.Tables(3).TableName = "Maedtli"
                _Ds.Tables(4).TableName = "Maeedoob"
                _Ds.Tables(5).TableName = "Maeven"
                _Ds.Tables(6).TableName = "Maeen"

                _Ds.WriteXml(_Ruta_Archivo)

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_Archivador Set Archivado = 1 Where Idmaeedo = " & _Idmaeedo
                _Sql.Ej_consulta_IDU(Consulta_Sql)

            Catch ex As Exception

            End Try

            _Contador += 1
            _Leyenda = "Insertandos " & _Contador & " de " & _Tbl_Archivos.Rows.Count & ")..."
            _Lbl_Estado = _Leyenda

            System.Windows.Forms.Application.DoEvents()

        Next

        Log_Registro += _Lbl_Estado

        Procesando = False

    End Sub

End Class
