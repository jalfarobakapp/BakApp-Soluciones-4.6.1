Imports System.Data.SqlClient
Imports DevComponents.DotNetBar
Public Class Frm_Huellas_U4500

    Dim Consulta_sql As String

    Private Data As AppData
    Private Enroller As EnrollmentForm
    Private Verifier As VerificationForm
    Public WithEvents AppData As AppData

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Sub New()
        InitializeComponent()

        Data = New AppData()
        AddHandler Data.OnChange, AddressOf OnDataChange
        Enroller = New EnrollmentForm(Data)
        Verifier = New VerificationForm(Data)
        ExchangeData(False)
    End Sub

    Private Sub OnDataChange()
        ExchangeData(False)
    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub

    Private Sub ExchangeData(ByVal read As Boolean)
        If (read) Then
            If (Mask.Text.Length > 0) Then
                Data.EnrolledFingersMask = Mask.Value
            Else
                Data.EnrolledFingersMask = 0
            End If

            If (MaxFingers.Text.Length > 0) Then
                Data.MaxEnrollFingerCount = MaxFingers.Value
            Else
                Data.MaxEnrollFingerCount = 0
            End If

            Data.IsEventHandlerSucceeds = IsSuccess.Checked
            Data.Update()
        Else
            Mask.Value = Data.EnrolledFingersMask
            MaxFingers.Value = Data.MaxEnrollFingerCount
            IsSuccess.Checked = Data.IsEventHandlerSucceeds
            IsFailure.Checked = Not IsSuccess.Checked
            IsFeatureSetMatched.Checked = Data.IsFeatureSetMatched
            FalseAcceptRate.Text = Data.FalseAcceptRate.ToString()
            VerifyButton.Enabled = Data.EnrolledFingersMask > 0
        End If
    End Sub

    Private Sub EnrollButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnrollButton.Click
        ExchangeData(True)
        Enroller.ShowDialog()
    End Sub

    Private Sub VerifyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerifyButton.Click
        ExchangeData(True)
        Verifier.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Dim _Huella As DPFP.Template
        'Dim _Verificado As Boolean

        'Consulta_sql = "Select * From " & _Tabla

        'Dim _Tbl_Huellas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim Fm As New VerificationForm(Data)
        'Fm.VerificationControl._OnComplete
        Fm.Btn_Grabar_Sin_Lector.Visible = False
        Fm.ShowDialog(Me)
        '_Verificado = Fm.Verificado
        '_Huella = Fm.Huella
        Fm.Dispose()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try

            Dim _CodFuncionario As String = String.Empty
            Dim _NomFuncionario As String = String.Empty

            Dim Fm_R As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Funcionarios_Random)
            Fm_R.Pro_Seleccionar_Solo_Uno = True
            Fm_R.Pro_Sql_Filtro_Condicion_Extra = "And INACTIVO = 0"
            Fm_R.Text = "SELECCION DE USUARIO PARA REGISTRO DE HUELLA"
            Fm_R.ShowDialog(Me)

            If Not IsNothing(Fm_R.Pro_Tbl_Filtro) Then
                If CBool(Fm_R.Pro_Tbl_Filtro.Rows.Count) Then
                    _CodFuncionario = Fm_R.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
                    _NomFuncionario = Fm_R.Pro_Tbl_Filtro.Rows(0).Item("Descripcion").ToString.Trim
                End If
            End If

            Fm_R.Dispose()

            If String.IsNullOrEmpty(_CodFuncionario) Then
                Return
            End If

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Usuarios_Huellas", "CodFuncionario = '" & _CodFuncionario & "'")

            If CBool(_Reg) Then

                If MessageBoxEx.Show(Me, "Este usuario ya tiene " & _Reg & " huella(s) registrada(s)" & vbCrLf & vbCrLf &
                                    "Si continua con el registro se eliminaran las huellas." & vbCrLf &
                                    "¿Desea continuar con el registro?", "Registrar huellas",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Usuarios_Huellas Where CodFuncionario = '" & _CodFuncionario & "'"
                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                        MessageBoxEx.Show(Me, "Huellas anteriores eliminadas", "Registrar huellas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Else

                    Return

                End If

            End If

                ExchangeData(True)

            Dim Fm As New EnrollmentForm(Data)
            Fm.Text = "ACTIVAR HUELLA USUARIO: " & _CodFuncionario
            Fm.ShowDialog()
            Fm.Dispose()

            Dim _Huella As DPFP.Template

            Dim ver As New DPFP.Verification.Verification()
            Dim res As New DPFP.Verification.Verification.Result()

            Dim _Dedo As Integer = 1
            Dim _Huella_Grabadas = 0

            For Each template As DPFP.Template In Data.Templates    '   Compare feature set with all stored templates:
                If Not template Is Nothing Then                     '   Get template from storage.
                    'ver.Verify(FeatureSet, template, res)          '   Compare feature set with particular template.
                    Data.IsFeatureSetMatched = res.Verified         '   Check the result of the comparison
                    Data.FalseAcceptRate = res.FARAchieved          '   Determine the current False Accept Rate

                    _Huella = template

                    _Huella_Grabadas += Fx_Grabar_Huellas(_CodFuncionario, _Dedo, _Huella)

                End If
                _Dedo += 1
            Next

            If CBool(_Huella_Grabadas) Then

                MessageBox.Show(Me, _Huella_Grabadas & " Huella(s) Grabada(s)", "Ingreso de huella", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            Data = New AppData()

        Catch ex As Exception
            DevComponents.DotNetBar.MessageBoxEx.Show(Me, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Function Fx_Grabar_Huellas(_CodFuncionario As String,
                               _Dedo As Integer,
                               _Huella As DPFP.Template) As Integer

        Dim _Huella_Byte As Byte() = _Huella.Bytes
        Dim _Nro_Huella = _Dedo

        Consulta_sql = "Select top 1 * From MAEPR"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        'Select Case Top(200) CodFuncionario, Nro_Huella, Huella, Huella_Uare4500 From Zw_Usuarios_Huellas

        Dim cn As New SqlConnection
        Dim sCnn = Cadena_ConexionSQL_Server
        cn.ConnectionString = sCnn

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Usuarios_Huellas Where CodFuncionario = @CodFuncionario And Nro_Huella = @Nro_Huella
                        Insert Into " & _Global_BaseBk & "Zw_Usuarios_Huellas (CodFuncionario,Nro_Huella,Huella_Uare4500) Values (@CodFuncionario,@Nro_Huella,@Huella_Uare4500)"

        Dim cmd As SqlCommand = cn.CreateCommand 'cnn.CreateCommand()
        ' Crear la consulta T-SQL para insertar un nuevo registro.
        cmd.CommandText = Consulta_sql

        ' Añadir el único parámetro de entrada existente.
        cmd.Parameters.AddWithValue("@CodFuncionario", _CodFuncionario)
        cmd.Parameters.AddWithValue("@Nro_Huella", _Nro_Huella)

        ' La función ReadBinaryFile tal cual se encuentra implementada no devolverá un valor Nothing,
        ' pero muestro cómo especificar un valor NULL al parámetro de entrada si el valor del campo
        ' binario fuese Nothing. Para insertar un valor NULL, el campo de la tabla lo tiene que permitir.

        cmd.Parameters.AddWithValue("@Huella_Uare4500", If(_Huella_Byte IsNot Nothing, _Huella_Byte, CObj(DBNull.Value)))
        cn.Open()

        Dim c As Cursor = Me.Cursor
        Me.Cursor = Cursors.WaitCursor
        Dim _Grabar As Integer = cmd.ExecuteNonQuery()
        Me.Cursor = c

        Return _Grabar

    End Function

End Class
