Imports System.IO
Imports DevComponents.DotNetBar

Public Class VerificationForm

    Public Data As AppData
    Dim _Huella As DPFP.Template
    Dim _Cerrar_Al_Confirmar As Boolean
    Dim _Verificado As Boolean
    Dim _Graba_Sin_Huella As Boolean
    Dim _Row_Usuario As DataRow

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Huellas As DataTable

    Sub New(ByVal data As AppData)

        If IsNothing(data) Then
            data = New AppData
        End If

        InitializeComponent()
        Me.Data = data

    End Sub

    Public Property Huella As DPFP.Template
        Get
            Return _Huella
        End Get
        Set(value As DPFP.Template)
            _Huella = value
        End Set
    End Property

    Public Property Cerrar_Al_Confirmar As Boolean
        Get
            Return _Cerrar_Al_Confirmar
        End Get
        Set(value As Boolean)
            _Cerrar_Al_Confirmar = value
        End Set
    End Property

    Public Property Verificado As Boolean
        Get
            Return _Verificado
        End Get
        Set(value As Boolean)
            _Verificado = value
        End Set
    End Property

    Public Property Row_Usuario As DataRow
        Get
            Return _Row_Usuario
        End Get
        Set(value As DataRow)
            _Row_Usuario = value
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

    Sub OnComplete_Bakapp(ByVal Control As Object, ByVal FeatureSet As DPFP.FeatureSet, ByRef EventHandlerStatus As DPFP.Gui.EventHandlerStatus) Handles VerificationControl.OnComplete

        'Dim _Verificado As Boolean

        Dim ver As New DPFP.Verification.Verification()
        Dim res As New DPFP.Verification.Verification.Result()

        For Each _Fila As DataRow In _Tbl_Huellas.Rows

            Try

                Dim _Huella_Uare4500 As Byte() = _Fila.Item("Huella_Uare4500")
                Dim _Stream As New MemoryStream(_Huella_Uare4500)
                Dim _Huella_Bk As New DPFP.Template(_Stream)

                ver.Verify(FeatureSet, _Huella_Bk, res)           '   Compare feature set with particular template.
                Data.IsFeatureSetMatched = res.Verified         '   Check the result of the comparison
                Data.FalseAcceptRate = res.FARAchieved          '   Determine the current False Accept Rate

                If res.Verified Then

                    Dim _Kofu As String = _Fila.Item("CodFuncionario").ToString.Trim
                    Dim _Nokofu As String = _Fila.Item("Nokofu").ToString.Trim

                    EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Success

                    Consulta_sql = "Select * From TABFU Where KOFU = '" & _Kofu & "'"
                    _Row_Usuario = _Sql.Fx_Get_DataRow(Consulta_sql)

                    _Verificado = True

                    If _Cerrar_Al_Confirmar Then

                        Lbl_Estatus.TextAlign = ContentAlignment.MiddleCenter
                        Lbl_Estatus.Text = "USUARIO: " & _Nokofu.ToUpper

                        CircularProgress1.Visible = False
                        Btn_Cerrar.Enabled = False
                        Btn_Grabar_Sin_Lector.Enabled = False
                        Tiempo.Interval = 1000
                        Tiempo.Start()

                    Else

                        Me.Text = "Fingerprint successfully verified"
                        Lbl_Estatus.TextAlign = ContentAlignment.MiddleCenter
                        Lbl_Estatus.Text = "USUARIO: " & _Nokofu.ToUpper

                        CircularProgress1.Visible = False
                        Btn_Cerrar.Enabled = False
                        Btn_Grabar_Sin_Lector.Enabled = False
                        Me.ControlBox = False
                        Tiempo2.Interval = 3000
                        Tiempo2.Start()

                    End If

                    Exit For ' success
                End If

            Catch ex As Exception

            End Try

        Next

        If Not res.Verified Then EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Failure
        Data.Update()

        If Not _Verificado Then

            Me.Text = "Verification failed"
            Lbl_Estatus.TextAlign = ContentAlignment.MiddleCenter
            Lbl_Estatus.Text = "¡NO SE ENCONTRO HUELLA, INTENTELO NUEVAMENTE!"

            CircularProgress1.Visible = False
            Btn_Cerrar.Enabled = False
            Btn_Grabar_Sin_Lector.Enabled = False
            Me.ControlBox = False
            Tiempo3.Interval = 2000
            Tiempo3.Start()

        End If

        'If _Verificado And _Cerrar_Al_Confirmar Then
        '    CircularProgress1.Visible = False
        '    Btn_Cerrar.Enabled = False
        '    Btn_Grabar_Sin_Lector.Enabled = False
        '    Tiempo.Interval = 1000
        '    Tiempo.Start()
        'End If

    End Sub

    Private Sub VerificationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CircularProgress1.IsRunning = True

        Consulta_sql = "Select " & _Global_BaseBk & "Zw_Usuarios_Huellas.*,Isnull(NOKOFU,'Usuario no encontrado en TABFU') As Nokofu 
                        From " & _Global_BaseBk & "Zw_Usuarios_Huellas" & vbCrLf &
                           "Left Join TABFU On KOFU = CodFuncionario"

        _Tbl_Huellas = _Sql.Fx_Get_Tablas(Consulta_sql)

    End Sub

    Private Sub VerificationForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub Btn_Grabar_Sin_Lector_Click(sender As Object, e As EventArgs)
        _Graba_Sin_Huella = True
        Close()
    End Sub

    Private Sub Tiempo_Tick(sender As Object, e As EventArgs) Handles Tiempo.Tick
        Me.Close()
    End Sub

    Private Sub Btn_Cerrar_Click(sender As Object, e As EventArgs) Handles Btn_Cerrar.Click
        Me.Close()
    End Sub

    Private Sub Btn_Grabar_Sin_Lector_Click_1(sender As Object, e As EventArgs) Handles Btn_Grabar_Sin_Lector.Click
        Graba_Sin_Huella = True
        Me.Close()
    End Sub

    Private Sub Tiempo2_Tick(sender As Object, e As EventArgs) Handles Tiempo2.Tick
        Tiempo2.Stop()
        Me.Text = "Verify Your Identity"
        Lbl_Estatus.Text = "Para verificar su identidad, toque el lector de huellas digitales con cualquier dedo registrado."
        Btn_Cerrar.Enabled = True
        Btn_Grabar_Sin_Lector.Enabled = True
        CircularProgress1.Visible = True
        Me.ControlBox = True
    End Sub

    Private Sub Tiempo3_Tick(sender As Object, e As EventArgs) Handles Tiempo3.Tick
        Tiempo3.Stop()
        Me.Text = "Verify Your Identity"
        Lbl_Estatus.Text = "Para verificar su identidad, toque el lector de huellas digitales con cualquier dedo registrado."
        Btn_Cerrar.Enabled = True
        Btn_Grabar_Sin_Lector.Enabled = True
        CircularProgress1.Visible = True
        Me.ControlBox = True
    End Sub
End Class
