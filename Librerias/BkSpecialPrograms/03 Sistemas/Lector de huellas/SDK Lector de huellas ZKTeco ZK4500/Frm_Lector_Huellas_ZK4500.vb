Imports System.Threading
Imports AxZKFPEngXControl


Public Class Frm_Lector_Huellas_ZK4500

    Dim FMatchType As Integer
    Dim fpcHandle As Integer
    Dim FPID As Integer = 0
    Dim sRegTemplate, sRegTemplate10 As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Lector_Huellas_ZK4500_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rdb10.Checked = True
        chkFakeFunOn.Checked = True
        EnableButton(True)
    End Sub

    Private Sub btnReg_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReg.Click
        If axZKFPEngX1.IsRegister Then
            axZKFPEngX1.CancelEnroll()
        End If

        axZKFPEngX1.EnrollCount = 3
        axZKFPEngX1.BeginEnroll()
        statusBar1.Panels(0).Text = "iniciar registro"
    End Sub

    Private Sub btnCloseSensor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCloseSensor.Click
        axZKFPEngX1.EndEngine()
        EnableButton(True)
    End Sub

    Private Sub btnbrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnbrowse.Click
        If radioButton1.Checked Then
            axZKFPEngX1.SaveBitmap("Fingerprint.bmp")
        Else
            axZKFPEngX1.SaveJPG("Fingerprint.jpg")
        End If

        MessageBox.Show("Imagen de huella digital guardada", "Aviso", MessageBoxButtons.OK)
    End Sub

    Private Sub btnVerify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVerify.Click
        If axZKFPEngX1.IsRegister Then axZKFPEngX1.CancelEnroll()
        statusBar1.Panels(0).Text = "Verificar (1:1)"
        FMatchType = 1
    End Sub

    Private Sub btnIdentify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnIdentify.Click
        If axZKFPEngX1.IsRegister Then axZKFPEngX1.CancelEnroll()
        statusBar1.Panels(0).Text = "Identificar (1:N)"
        FMatchType = 2
    End Sub


    Private Sub btnRegByImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRegByImage.Click
        Dim openFileDialog1 As OpenFileDialog = New OpenFileDialog()
        openFileDialog1.Filter = "Image Files(*.BMP;*.JPG)|*.BMP;*.JPG|All files (*.*)|*.*"

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            If axZKFPEngX1.IsRegister Then axZKFPEngX1.CancelEnroll()
            axZKFPEngX1.EnrollCount = 1

            MessageBox.Show("Extracto fallido o no utilizando la versión estándar de ZKFinger SDK", "error!")
        End If

    End Sub

    Private Sub btnRed_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRed.Click
        axZKFPEngX1.ControlSensor(12, 1)
        Thread.Sleep(100)
        axZKFPEngX1.ControlSensor(12, 0)
    End Sub

    Private Sub btnGreen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGreen.Click
        axZKFPEngX1.ControlSensor(11, 1)
        Thread.Sleep(100)
        axZKFPEngX1.ControlSensor(11, 0)
    End Sub

    Private Sub btnBeep_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBeep.Click
        axZKFPEngX1.ControlSensor(13, 1)
        Thread.Sleep(100)
        axZKFPEngX1.ControlSensor(13, 0)
    End Sub

    Private Sub btnInitialSensor_Click(sender As Object, e As EventArgs) Handles btnInitialSensor.Click

        If chkFakeFunOn.Checked Then
            axZKFPEngX1.FakeFunOn = 1
        Else
            axZKFPEngX1.FakeFunOn = 0
        End If

        If axZKFPEngX1.InitEngine() = 0 Then
            EnableButton(False)

            If rdb9.Checked Then
                axZKFPEngX1.FPEngineVersion = "9"
            Else
                axZKFPEngX1.FPEngineVersion = "10"
            End If

            fpcHandle = axZKFPEngX1.CreateFPCacheDBEx()
            txtb1.Text = axZKFPEngX1.SensorCount.ToString()
            txtb2.Text = axZKFPEngX1.SensorIndex.ToString()
            txtb5.Text = axZKFPEngX1.SensorSN
            statusBar1.Panels(0).Text = "Sensor conectado!"
            MessageBox.Show("¡Éxito inicial!", "Información")
        Else
            axZKFPEngX1.EndEngine()
            MessageBox.Show("¡Falló inicial!", "Error")
        End If

        FMatchType = 2
    End Sub

    Private Sub AxZKFPEngX1_OnCapture(sender As Object, e As IZKFPEngXEvents_OnCaptureEvent) Handles axZKFPEngX1.OnCapture
        If FMatchType = 1 Then
            Dim RegChanged As Boolean = False
            Dim sTemp As String = axZKFPEngX1.GetTemplateAsString()
            Dim sVerTemplate As String

            If rdb9.Checked Then
                sVerTemplate = sRegTemplate
            Else
                sVerTemplate = sRegTemplate10
            End If

            If axZKFPEngX1.VerFingerFromStr(sVerTemplate, sTemp, False, RegChanged) Then
                statusBar1.Panels(0).Text = "Verificar el éxito"

                'Envia color verde al Sensor
                axZKFPEngX1.ControlSensor(11, 1)
                Thread.Sleep(100)
                axZKFPEngX1.ControlSensor(11, 0)
                'Fin color verde

                'Envia Beep al Sensor
                axZKFPEngX1.ControlSensor(13, 1)
                Thread.Sleep(100) 'Duración del Beep
                'Fin del Beep
                axZKFPEngX1.ControlSensor(13, 0)
            Else
                'Envia color rojo al Sensor
                statusBar1.Panels(0).Text = "Verificar falla"
                axZKFPEngX1.ControlSensor(12, 1)
                Thread.Sleep(100)
                'Fin color rojo

                axZKFPEngX1.ControlSensor(12, 0)
            End If
        ElseIf FMatchType = 2 Then
            Dim score As Integer = 8
            Dim processedNum As Integer = 1
            Dim ID As Integer = axZKFPEngX1.IdentificationInFPCacheDB(fpcHandle, e.aTemplate, score, processedNum)

            If ID = -1 Then
                statusBar1.Panels(0).Text = "Identificar fallido"
            Else
                statusBar1.Panels(0).Text = String.Format("Identifique la ID exitosa = {0} Puntuación = {1} Número procesado = {2}", ID, score, processedNum)
            End If
        End If
    End Sub

    Private Sub AxZKFPEngX1_OnEnroll(sender As Object, e As IZKFPEngXEvents_OnEnrollEvent) Handles axZKFPEngX1.OnEnroll
        If Not e.actionResult Then
            MessageBox.Show("Registro Fallido!", "error!")
        Else
            sRegTemplate = axZKFPEngX1.GetTemplateAsStringEx("9")
            sRegTemplate10 = axZKFPEngX1.GetTemplateAsStringEx("10")

            If sRegTemplate.Length > 0 Then

                If sRegTemplate10.Length > 0 Then
                    axZKFPEngX1.AddRegTemplateStrToFPCacheDBEx(fpcHandle, FPID, sRegTemplate, sRegTemplate10)
                Else
                    MessageBox.Show("Falló el registro 10.0, la longitud de la plantilla es cero", "error!")
                End If

                Dim pTemplate As Object

                If rdb9.Checked Then
                    pTemplate = axZKFPEngX1.DecodeTemplate1(sRegTemplate)
                    axZKFPEngX1.SetTemplateLen(pTemplate, 602)
                Else
                    pTemplate = axZKFPEngX1.DecodeTemplate1(sRegTemplate10)
                End If

                axZKFPEngX1.SaveTemplate("fingerprint.tpl", pTemplate)
                FPID += 1
                MessageBox.Show("Registrarse con éxito", "Information!")
            Else
                MessageBox.Show("Error de registro, la longitud de la plantilla es cero", "error!")
            End If
        End If
    End Sub

    Private Sub AxZKFPEngX1_OnImageReceived(ByVal sender As Object, ByVal e As AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEvent) Handles axZKFPEngX1.OnImageReceived
        Dim g As Graphics = pictureBox1.CreateGraphics()
        Dim dc As Integer = g.GetHdc().ToInt32()
        axZKFPEngX1.PrintImageAt(dc, 0, 0, axZKFPEngX1.ImageWidth, axZKFPEngX1.ImageHeight)
    End Sub

    Private Sub AxZKFPEngX1_OnFeatureInfo(ByVal sender As Object, ByVal e As AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEvent) Handles axZKFPEngX1.OnFeatureInfo
        Dim sTemp As String = ""
        If axZKFPEngX1.IsRegister Then sTemp = "Estado de registro: todavía presione el dedo " & axZKFPEngX1.EnrollIndex.ToString() & " times!"
        sTemp = sTemp & " Calidad de huella digital"
        Dim lastq As Integer = axZKFPEngX1.LastQuality

        If e.aQuality = -1 Then
            sTemp = sTemp & " no es bueno, huellas sospechosas, calidad=" & lastq.ToString()
        ElseIf e.aQuality <> 0 Then
            sTemp = sTemp & " no es de buena calidad=" & lastq.ToString()
        Else
            sTemp = sTemp & " buena calidad=" & lastq.ToString()
        End If

        statusBar1.Panels(0).Text = sTemp
    End Sub

    Private Sub Btn_Verificar_Huella_Click(sender As Object, e As EventArgs) Handles Btn_Verificar_Huella.Click

        Dim _Huella As String '= axZKFPEngX1.GetTemplateAsString()
        Dim _Huella_Correcta As Boolean

        Dim Fm As New Frm_Huella_Identificar(Me, _Huella, chkFakeFunOn.Checked, rdb9.Checked, Frm_Huella_Identificar.Enum_Accion.Registrar)
        Fm.ShowDialog(Me)
        _Huella_Correcta = Fm.Pro_Verificado
        Fm.Dispose()

        If _Huella_Correcta Then
            MessageBox.Show(Me, "La huella es correcta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub EnableButton(ByVal bEnable As Boolean)
        btnInitialSensor.Enabled = bEnable
        btnCloseSensor.Enabled = Not bEnable
        btnbrowse.Enabled = Not bEnable
        btnReg.Enabled = Not bEnable
        btnVerify.Enabled = Not bEnable
        btnIdentify.Enabled = Not bEnable
        btnRegByImage.Enabled = Not bEnable
        btnIdentifyByImage.Enabled = Not bEnable
        btnRed.Enabled = Not bEnable
        btnGreen.Enabled = Not bEnable
        btnBeep.Enabled = Not bEnable
        Btn_Verificar_Huella.Enabled = Not bEnable
    End Sub

End Class
