Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Reflection
Imports System.Threading
Imports System.Data.OleDb
Imports System.Collections
Imports DevComponents.DotNetBar

Public Class Frm_Huella_Identificar

    Dim Consulta_Sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim FMatchType As Integer
    Dim fpcHandle As Integer
    Dim FPID As Integer = 0
    Dim _Graba_Sin_Huella As Boolean

    Dim sRegTemplate, sRegTemplate10 As String
    Dim _Huella As String

    Dim _FakeFunOn As Boolean
    Dim _Conectado As Boolean

    Dim _Verificado As Boolean
    Public Property Pro_Verificado As Boolean
        Get
            Return _Verificado
        End Get
        Set(value As Boolean)
            _Verificado = value
        End Set
    End Property
    Public Property Pro_Registrado As Boolean
        Get
            Return _Registrado
        End Get
        Set(value As Boolean)
            _Registrado = value
        End Set
    End Property
    Public Property Pro_Huella As String
        Get
            Return _Huella
        End Get
        Set(value As String)
            _Huella = value
        End Set
    End Property

    Dim _Registrado As Boolean

    Dim _Form_Padre As Form

    Enum Enum_Accion
        Registrar
        Verificar
        Buscar_Huella
    End Enum

    Dim _Accion As Enum_Accion
    Dim _Row_Usuario As DataRow
    Dim _Cont_Intentos As Integer
    Dim _Intentos As Integer = 3
    Dim _Tbl_Usuarior_Huellas As DataTable

    Public Property Pro_Tbl_Usuarior_Huellas As DataTable
        Get
            Return _Tbl_Usuarior_Huellas
        End Get
        Set(value As DataTable)
            _Tbl_Usuarior_Huellas = value
        End Set
    End Property
    Public Property Pro_Row_Usuario As DataRow
        Get
            Return _Row_Usuario
        End Get
        Set(value As DataRow)
            _Row_Usuario = value
        End Set
    End Property
    Public Property Pro_Intentos As Integer
        Get
            Return _Intentos
        End Get
        Set(value As Integer)
            _Intentos = value
        End Set
    End Property
    Public Property Pro_Conectado As Boolean
        Get
            Return _Conectado
        End Get
        Set(value As Boolean)
            _Conectado = value
        End Set
    End Property

    Public Property Graba_Sin_Huella As Boolean
        Get
            Return _Graba_Sin_Huella
        End Get
        Set(value As Boolean)
            _Graba_Sin_Huella = value
        End Set
    End Property

    Public Sub New(Form_Padre As Form,
                   Huella As String,
                   FakeFunOn As Boolean,
                   _rdb9 As Boolean,
                   Accion As Enum_Accion)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Huella = Huella
        _FakeFunOn = FakeFunOn
        rdb9.Checked = _rdb9
        _Accion = Accion

        If _Accion = Enum_Accion.Buscar_Huella Then
            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Usuarios_Huellas"
            _Tbl_Usuarior_Huellas = _Sql.Fx_Get_Tablas(Consulta_Sql)
        End If

        _Form_Padre = Form_Padre
        Sb_Conectar_Sensor()

    End Sub

    Private Sub Frm_Huella_Identificar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Sb_Conectar_Sensor()
        Tiempo_Encender.Enabled = True

    End Sub

    Sub Sb_Conectar_Sensor()

        If _FakeFunOn Then
            axZKFPEngX1.FakeFunOn = 1
        Else
            axZKFPEngX1.FakeFunOn = 0
        End If

        If axZKFPEngX1.InitEngine() = 0 Then
            'EnableButton(False)

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

            _Conectado = True

        Else
            axZKFPEngX1.EndEngine()
            statusBar1.Panels(0).Text = "¡Fallo de conexión con el sensor!"
            'MessageBox.Show("¡Falló inicial!", "Error")

            Beep()
            ToastNotification.Show(_Form_Padre, "NO SE PUEDE ESTABLECER CONEXION CON EL SENSOR",
                                   My.Resources.cross,
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)

        End If

        FMatchType = 2

    End Sub

    Private Sub axZKFPEngX1_OnCapture(sender As Object, e As IZKFPEngXEvents_OnCaptureEvent) 'Handles axZKFPEngX1.OnCapture

        If FMatchType = 1 Then

            Dim RegChanged As Boolean = False

            Dim sVerTemplate As String

            If rdb9.Checked Then
                sVerTemplate = axZKFPEngX1.GetTemplateAsStringEx("9")
            Else
                sVerTemplate = axZKFPEngX1.GetTemplateAsStringEx("10")
            End If

            If axZKFPEngX1.VerFingerFromStr(sVerTemplate, _Huella, False, RegChanged) Then
                statusBar1.Panels(0).Text = "Verificar el éxito"

                'Envia color verde al Sensor
                axZKFPEngX1.ControlSensor(11, 1)
                Thread.Sleep(100)
                axZKFPEngX1.ControlSensor(11, 0)
                'Fin color verde

                _Huella = sVerTemplate
                _Verificado = True
                Me.Close()

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

    Private Sub axZKFPEngX1_OnCapture2(sender As Object, e As IZKFPEngXEvents_OnCaptureEvent)

        Try
            Enabled = True


            If FMatchType = 1 Then

                Dim RegChanged As Boolean = False

                Dim sVerTemplate As String

                If rdb9.Checked Then
                    sVerTemplate = axZKFPEngX1.GetTemplateAsStringEx("9")
                Else
                    sVerTemplate = axZKFPEngX1.GetTemplateAsStringEx("10")
                End If

                For Each _Fila As DataRow In _Tbl_Usuarior_Huellas.Rows

                    Dim _Funcionario As String = _Fila.Item("CodFuncionario")
                    _Huella = _Fila.Item("Huella")

                    statusBar1.Panels(0).Text = "Analisando: " & _Funcionario
                    System.Windows.Forms.Application.DoEvents()

                    If axZKFPEngX1.VerFingerFromStr(sVerTemplate, _Huella, False, RegChanged) Then

                        statusBar1.Panels(0).Text = "Verificar el éxito"

                        'Envia color verde al Sensor
                        axZKFPEngX1.ControlSensor(11, 1)
                        Thread.Sleep(100)
                        axZKFPEngX1.ControlSensor(11, 0)
                        'Fin color verde

                        _Huella = sVerTemplate
                        _Verificado = True
                        Consulta_Sql = "Select * From TABFU Where KOFU = '" & _Funcionario & "'"
                        _Row_Usuario = _Sql.Fx_Get_DataRow(Consulta_Sql)

                        Beep()
                        ToastNotification.Show(Me, "VERIFICACION ACEPTADA" & vbCrLf &
                                   "USUARIO: " & _Row_Usuario.Item("NOKOFU"), Nothing,
                                       2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
                        Exit For

                    Else
                        'Envia color rojo al Sensor
                        statusBar1.Panels(0).Text = "Verificar falla"
                        axZKFPEngX1.ControlSensor(12, 1)
                        Thread.Sleep(100)
                        'Fin color rojo

                        'ToastNotification.Show(Me, "HUELLA INVALIDA", Nothing,
                        '2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

                        axZKFPEngX1.ControlSensor(12, 0)
                    End If

                Next

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

            _Cont_Intentos += 1

            If _Verificado Then
                Threading.Thread.Sleep(2000)
                Me.Close()
            Else
                If _Cont_Intentos > _Intentos Then
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Error!!", vbOK, MessageBoxIcon.Stop)
        Finally
            pictureBox1.Image = Nothing
            Me.Refresh()
            Me.Enabled = True
        End Try

    End Sub

    Public Function Fx_Existe_Huella_Row(_Huella_Revisar As String) As DataRow

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Usuarios_Huellas Where Zk4500 = 1"
        _Tbl_Usuarior_Huellas = _Sql.Fx_Get_Tablas(Consulta_Sql)

        For Each _Fila As DataRow In _Tbl_Usuarior_Huellas.Rows

            Dim _Kofu As String = _Fila.Item("CodFuncionario")
            _Huella = _Fila.Item("Huella")

            'statusBar1.Panels(0).Text = "Analisando: " & _Funcionario
            'System.Windows.Forms.Application.DoEvents()

            If axZKFPEngX1.VerFingerFromStr(_Huella_Revisar, _Huella, False, False) Then
                Consulta_Sql = "Select Top 1 * From TABFU Where KOFU = '" & _Kofu & "'"
                Dim _RowFuncionario As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)
                Return _RowFuncionario
            End If

        Next

    End Function

    Private Sub axZKFPEngX1_OnEnroll(sender As Object, e As IZKFPEngXEvents_OnEnrollEvent) Handles axZKFPEngX1.OnEnroll
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
                    _Huella = sRegTemplate
                Else
                    pTemplate = axZKFPEngX1.DecodeTemplate1(sRegTemplate10)
                    _Huella = sRegTemplate10
                End If

                axZKFPEngX1.SaveTemplate("fingerprint.tpl", pTemplate)
                FPID += 1
                'MessageBox.Show("Registrarse con éxito", "Information!")
                _Registrado = True
                Me.Close()

            Else
                MessageBox.Show("Error de registro, la longitud de la plantilla es cero", "error!")
            End If
        End If
    End Sub

    Private Sub axZKFPEngX1_OnImageReceived(ByVal sender As Object, ByVal e As AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEvent) Handles axZKFPEngX1.OnImageReceived
        Dim g As Graphics = pictureBox1.CreateGraphics()
        Dim dc As Integer = g.GetHdc().ToInt32()
        axZKFPEngX1.PrintImageAt(dc, 0, 0, axZKFPEngX1.ImageWidth, axZKFPEngX1.ImageHeight)
    End Sub

    Private Sub Tiempo_Encender_Tick(sender As Object, e As EventArgs) Handles Tiempo_Encender.Tick
        Tiempo_Encender.Enabled = False

        Select Case _Accion

            Case Enum_Accion.Buscar_Huella

                AddHandler axZKFPEngX1.OnCapture, AddressOf axZKFPEngX1_OnCapture2

                If axZKFPEngX1.IsRegister Then axZKFPEngX1.CancelEnroll()
                statusBar1.Panels(0).Text = "Buscar huella... (1:1)"
                FMatchType = 1

            Case Enum_Accion.Registrar
                If axZKFPEngX1.IsRegister Then
                    axZKFPEngX1.CancelEnroll()
                End If

                axZKFPEngX1.EnrollCount = 3
                axZKFPEngX1.BeginEnroll()
                statusBar1.Panels(0).Text = "Iniciar registro"
            Case Enum_Accion.Verificar

                AddHandler axZKFPEngX1.OnCapture, AddressOf axZKFPEngX1_OnCapture

                If axZKFPEngX1.IsRegister Then axZKFPEngX1.CancelEnroll()
                statusBar1.Panels(0).Text = "Verificación de huella (1:1)"
                FMatchType = 1


        End Select

        If _Accion = Enum_Accion.Registrar Then


        End If

        If _Accion = Enum_Accion.Verificar Then

        End If
    End Sub

    Private Sub Btn_Grabar_Sin_Lector_Click(sender As Object, e As EventArgs) Handles Btn_Grabar_Sin_Lector.Click
        _Graba_Sin_Huella = True
        Me.Close()
    End Sub

    Private Sub axZKFPEngX1_OnFeatureInfo(ByVal sender As Object, ByVal e As AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEvent) Handles axZKFPEngX1.OnFeatureInfo
        Dim sTemp As String = ""
        If axZKFPEngX1.IsRegister Then sTemp = "Presione el dedo " & axZKFPEngX1.EnrollIndex.ToString() '& " times!"
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

End Class
