Imports System.IO
Imports DevComponents.DotNetBar

Public Class EnrollmentForm

    Public Data As AppData
    Dim _CodFuncionario As String

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Sub New(ByVal data As AppData) ', _CodFuncionario As String)
        InitializeComponent()
        Me.Data = data
        'Me._CodFuncionario = _CodFuncionario
        ExchangeData(False)
        AddHandler data.OnChange, AddressOf OnDataChange
    End Sub

    Private Sub OnDataChange()
        ExchangeData(False)
    End Sub

    Public Sub ExchangeData(ByVal read As Boolean)
        If (read) Then
            Data.EnrolledFingersMask = EnrollmentControl.EnrolledFingerMask
            Data.MaxEnrollFingerCount = EnrollmentControl.MaxEnrollFingerCount
            Data.Update()
        Else
            EnrollmentControl.EnrolledFingerMask = Data.EnrolledFingersMask
            EnrollmentControl.MaxEnrollFingerCount = Data.MaxEnrollFingerCount
        End If
    End Sub

    Sub EnrollmentControl_OnEnroll(ByVal Control As Object, ByVal Finger As Integer, ByVal Template As DPFP.Template, ByRef EventHandlerStatus As DPFP.Gui.EventHandlerStatus) Handles EnrollmentControl.OnEnroll
        If (Data.IsEventHandlerSucceeds) Then

            'Dim _Row_Usuario As DataRow = Fx_Revisar_Huella_En_DB(Template.Bytes)

            ''Dim A = New DPFP.FeatureSet.DeSerialize(_Stream)

            ''Dim _Hl As New DPFP.Gui.Verification.VerificationControl '= DPFP.FeatureSet.DeSerialize(_Stream)


            'If Not IsNothing(_Row_Usuario) Then
            '    MessageBoxEx.Show(Me, "Esta huella ya esta registrada a nombre del usuario " &
            '                      _Row_Usuario.Item("KOFU") & " - " & _Row_Usuario.Item("NOKOFU"), "Validación",
            '                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Return
            'End If

            Data.Templates(Finger - 1) = Template
            ExchangeData(True)
            ListEvents.Items.Insert(0, String.Format("OnEnroll: finger {0}", Finger))
        Else
            EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Failure
        End If
    End Sub

    Sub EnrollmentControl_OnDelete(ByVal Control As Object, ByVal Finger As Integer, ByRef EventHandlerStatus As DPFP.Gui.EventHandlerStatus) Handles EnrollmentControl.OnDelete
        If (Data.IsEventHandlerSucceeds) Then
            Data.Templates(Finger - 1) = Nothing
            ExchangeData(True)
            ListEvents.Items.Insert(0, String.Format("OnDelete: finger {0}", Finger))
        Else
            EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Failure
        End If
    End Sub

    Private Sub EnrollmentControl_OnCancelEnroll(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles EnrollmentControl.OnCancelEnroll
        ListEvents.Items.Insert(0, String.Format("OnCancelEnroll: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub EnrollmentControl_OnComplete(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles EnrollmentControl.OnComplete
        ListEvents.Items.Insert(0, String.Format("OnComplete: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub EnrollmentControl_OnFingerRemove(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles EnrollmentControl.OnFingerRemove
        ListEvents.Items.Insert(0, String.Format("OnFingerRemove: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub EnrollmentControl_OnFingerTouch(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles EnrollmentControl.OnFingerTouch
        ListEvents.Items.Insert(0, String.Format("OnFingerTouch: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub EnrollmentControl_OnReaderConnect(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles EnrollmentControl.OnReaderConnect
        ListEvents.Items.Insert(0, String.Format("OnReaderConnect: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub EnrollmentControl_OnReaderDisconnect(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles EnrollmentControl.OnReaderDisconnect
        ListEvents.Items.Insert(0, String.Format("OnReaderDisconnect: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub EnrollmentControl_OnSampleQuality(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32, ByVal CaptureFeedback As DPFP.Capture.CaptureFeedback) Handles EnrollmentControl.OnSampleQuality
        ListEvents.Items.Insert(0, String.Format("OnSampleQuality: {0}, finger {1}, {2}", ReaderSerialNumber, Finger, CaptureFeedback))
    End Sub

    Private Sub EnrollmentControl_OnStartEnroll(ByVal Control As System.Object, ByVal ReaderSerialNumber As System.String, ByVal Finger As System.Int32) Handles EnrollmentControl.OnStartEnroll
        ListEvents.Items.Insert(0, String.Format("OnStartEnroll: {0}, finger {1}", ReaderSerialNumber, Finger))
    End Sub

    Private Sub EnrollmentForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListEvents.Items.Clear()
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs)

    End Sub

    Function Fx_Revisar_Huella_En_DB(_Huella_Leida As Byte()) As DataRow

        Dim _Row_Usuario As DataRow

        Consulta_sql = "Select " & _Global_BaseBk & "Zw_Usuarios_Huellas.*,Isnull(NOKOFU,'Usuario no encontrado en TABFU') As Nokofu 
                        From " & _Global_BaseBk & "Zw_Usuarios_Huellas" & vbCrLf &
                           "Left Join TABFU On KOFU = CodFuncionario"

        Dim _Tbl_Huellas As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim ver As New DPFP.Verification.Verification()
        Dim res As New DPFP.Verification.Verification.Result()

        Dim _Stream As New MemoryStream(_Huella_Leida)

        Dim FeatureSet As DPFP.FeatureSet
        FeatureSet = New DPFP.FeatureSet(_Stream)
        'FeatureSet.Serialize(_Huella_Leida)
        'FeatureSet.DeSerialize(_Huella_Leida)
        'FeatureSet.Bytes()

        ' Process the sample and create a feature set for the enrollment purpose.

        Dim _Sample As New DPFP.Sample(_Stream)

        Dim features2 As DPFP.FeatureSet = ExtractFeatures(_Sample, DPFP.Processing.DataPurpose.Verification)


        For Each _Fila As DataRow In _Tbl_Huellas.Rows

            Try

                Dim _Huella_Uare4500 As Byte() = _Fila.Item("Huella_Uare4500")
                _Stream = New MemoryStream(_Huella_Uare4500)
                Dim _Huella_Bk As New DPFP.Template(_Stream)

                ver.Verify(features2, _Huella_Bk, res)

                If res.Verified Then 'If _Huella_Leida Is _Huella_Uare4500 Then

                    Dim _Kofu As String = _Fila.Item("CodFuncionario").ToString.Trim
                    Dim _Nokofu As String = _Fila.Item("Nokofu").ToString.Trim

                    'EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Success

                    Consulta_sql = "Select * From TABFU Where KOFU = '" & _Kofu & "'"
                    _Row_Usuario = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Exit For ' success

                End If

                'ver.Verify(FeatureSet, _Huella_Bk, res)         '   Compare feature set with particular template.

                'Data.IsFeatureSetMatched = Res.Verified         '   Check the result of the comparison
                'Data.FalseAcceptRate = Res.FARAchieved          '   Determine the current False Accept Rate

                'If res.Verified Then

                '    Dim _Kofu As String = _Fila.Item("CodFuncionario").ToString.Trim
                '    Dim _Nokofu As String = _Fila.Item("Nokofu").ToString.Trim

                '    'EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Success

                '    Consulta_sql = "Select * From TABFU Where KOFU = '" & _Kofu & "'"
                '    Dim _Row_Usuario As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                '    Exit For ' success

                'End If

            Catch ex As Exception

            End Try

        Next

        Return _Row_Usuario

    End Function

    Protected Function ExtractFeatures(ByVal Sample As DPFP.Sample, ByVal Purpose As DPFP.Processing.DataPurpose) As DPFP.FeatureSet

        Dim extractor As New DPFP.Processing.FeatureExtraction()    ' Create a feature extractor
        Dim feedback As DPFP.Capture.CaptureFeedback = DPFP.Capture.CaptureFeedback.None
        Dim features As New DPFP.FeatureSet()
        extractor.CreateFeatureSet(Sample, Purpose, feedback, features) ' TODO: return features as a result?
        If (feedback = DPFP.Capture.CaptureFeedback.Good) Then
            Return features
        Else
            Return Nothing
        End If

    End Function

End Class
