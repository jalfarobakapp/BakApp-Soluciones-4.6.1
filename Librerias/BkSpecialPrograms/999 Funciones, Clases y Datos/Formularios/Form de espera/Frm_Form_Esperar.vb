Imports System.ComponentModel

Public Class Frm_Form_Esperar

    Public Property Pro_Texto As String
        Get
            Return Lbl_Texto.Text
        End Get
        Set(value As String)
            Lbl_Texto.Text = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
        Timer1.Enabled = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Private Sub Frm_Form_Esperar_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer1.Start()
        If BackgroundWorker1.IsBusy <> True Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim worker As BackgroundWorker = TryCast(sender, BackgroundWorker)

        For i As Integer = 1 To 10
            If worker.CancellationPending = True Then
                e.Cancel = True
                Exit For
            Else
                System.Threading.Thread.Sleep(100)
                worker.ReportProgress(i * 10)
            End If
        Next

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged_1(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'Lbl_Progreso.Text = (e.ProgressPercentage.ToString() & "%")
        ProgressBarItem1.Value = e.ProgressPercentage
        If Not Me.Visible Then
            Me.Close()
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted_1(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled = True Then
            'Lbl_Progreso.Text = "Canceled!"
        ElseIf e.[Error] IsNot Nothing Then
            'Lbl_Progreso.Text = "Error: " & e.[Error].Message
        Else
            'Lbl_Progreso.Text = "Done!"
            If Me.Visible Then
                If BackgroundWorker1.IsBusy <> True Then
                    BackgroundWorker1.RunWorkerAsync()
                End If
            End If
        End If
    End Sub

    Sub Sb_Detener()

        If BackgroundWorker1.IsBusy Then
            BackgroundWorker1.CancelAsync()
        End If

    End Sub

    Private Sub Frm_Form_Esperar_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Sb_Detener()
    End Sub

End Class
