Imports System.ComponentModel

Public Class Class_Cronometro

    Dim WithEvents Tiempo As Timer
    Dim WithEvents BackgroundWorker1 As New BackgroundWorker

    Dim _Star As Boolean

    Dim _Objeto As Object
    Dim _Mls As Long

    Public Sub New(ByRef Objeto As Object)

        _Objeto = Objeto

        Tiempo = New Timer

        Tiempo.Interval = 100
        Tiempo.Enabled = True
        Tiempo.Stop()

        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True

    End Sub

    Private Sub Tiempo_Tick(sender As Object, e As EventArgs) Handles Tiempo.Tick

        System.Windows.Forms.Application.DoEvents()

        _Mls += 1
        Dim _Tiempo = Format(Int(_Mls / 36000) Mod 24, "00") & ":" &
                      Format(Int(_Mls / 600) Mod 60, "00") & ":" &
                      Format(Int(_Mls / 10) Mod 60, "00") & ":" &
                      Format(_Mls Mod 10, "00")

        _Objeto.Text = "Tiempo: " & _Tiempo

    End Sub

    Sub Sb_Iniciar()
        'Tiempo.Start()
        _Star = True
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Sub Sb_Detener()
        'Tiempo.Stop()
        _Star = False
        BackgroundWorker1.CancelAsync()
    End Sub
    Sub Sb_Reiniciar()
        _Mls = 0
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim worker As BackgroundWorker = TryCast(sender, BackgroundWorker)

        Do While _Star
            If worker.CancellationPending = True Then
                e.Cancel = True
                'Exit For
            Else
                System.Threading.Thread.Sleep(100)
                'worker.ReportProgress(i * 10)
                System.Windows.Forms.Application.DoEvents()

                _Mls += 1
                Dim _Tiempo = Format(Int(_Mls / 36000) Mod 24, "00") & ":" &
                              Format(Int(_Mls / 600) Mod 60, "00") & ":" &
                              Format(Int(_Mls / 10) Mod 60, "00") '& ":" &
                'Format(_Mls Mod 10, "00")
                _Objeto.Text = "Tiempo: " & _Tiempo
            End If
        Loop

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged_1(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'Lbl_Progreso.Text = (e.ProgressPercentage.ToString() & "%")
        'ProgressBarItem1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted_1(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled = True Then
            'Lbl_Progreso.Text = "Canceled!"
        ElseIf e.[Error] IsNot Nothing Then
            'Lbl_Progreso.Text = "Error: " & e.[Error].Message
        Else
            'Lbl_Progreso.Text = "Done!"
            'If BackgroundWorker1.IsBusy <> True Then
            'BackgroundWorker1.RunWorkerAsync()
            'End If
        End If
    End Sub

End Class
