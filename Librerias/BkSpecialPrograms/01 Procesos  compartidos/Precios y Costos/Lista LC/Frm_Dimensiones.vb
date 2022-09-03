Imports DevComponents.DotNetBar

Public Class Frm_Dimensiones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public CodigoRd As String

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

        Dim Rango1 = De_Num_a_Tx_01(TxtR1.Text)
        Dim Rango2 = De_Num_a_Tx_01(TxtR2.Text)

        If Val(Rango1) > Val(Rango2) Then
            MessageBoxEx.Show("El Rango 1 no puede ser Mayor al Rango 2",
                              "Error en Rangos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtR1.Focus()
            Exit Sub

        ElseIf Val(Rango1) = Val(Rango2) And Val(Rango1) > 0 Then
            MessageBoxEx.Show("El Rango 1 y 2 no pueden ser iguales Mayor, solamente 0",
                              "Error en Rangos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtR1.Focus()
            Exit Sub
        End If

        Dim _Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("PDIMEN", "CODIGO = '" & CodigoRd & "' And EMPRESA = '" & ModEmpresa & "'"))

        If Not _Reg Then
            Consulta_sql = "Insert Into PDIMEN (EMPRESA,CODIGO) Values ('" & ModEmpresa & "','" & CodigoRd & "')"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Consulta_sql = "Update PDIMEN Set EMPRESA = '" & ModEmpresa & "', RANGO01 = " & Rango1 & ",RANGO02 = " & Rango2 & vbCrLf & "WHERE CODIGO = '" & CodigoRd & "'"
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then

            MessageBoxEx.Show("Datos guardados correctamente", "Dimensiones", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        End If

    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        AsignarEventos(Grupo)

    End Sub

    Public Sub AsignarEventos(ByVal elControl As Control)
        Dim ctrl As Control
        ' 
        For Each ctrl In elControl.Controls
            ' No asignar estos evento al botón salir
            If ctrl.Name = "TxtR1" Or
               ctrl.Name = "TxtR2" Or
               ctrl.Name = "TxtR3" Or
               ctrl.Name = "TxtR4" Or
               ctrl.Name = "TxtR5" Or
               ctrl.Name = "TxtR6" Then

                ' Curiosamente un control GroupBox en apariencia
                ' no tiene estos eventos, pero... se le asigna y...
                ' ¡funciona!
                AddHandler ctrl.KeyPress, AddressOf PressEnter
                AddHandler ctrl.Enter, AddressOf PosicionarseEnCampo

                AsignarEventos(ctrl)
            End If
        Next
    End Sub

    Private Sub PressEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            SendKeys.Send(vbTab)
            e.Handled = True
        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If

    End Sub

    Private Sub PosicionarseEnCampo(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles TxtPrecioUd1.Enter
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub Frm_Dimensiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TxtR1.Text = _Sql.Fx_Trae_Dato("PDIMEN", "RANGO01", "CODIGO = '" & CodigoRd & "'")
        TxtR2.Text = _Sql.Fx_Trae_Dato("PDIMEN", "RANGO02", "CODIGO = '" & CodigoRd & "'")

    End Sub

    Private Sub TxtR1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtR1.TextChanged
        If Trim(sender.text) = "" Then
            sender.text = 0
        End If
    End Sub

    Private Sub TxtR2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtR2.TextChanged
        If Trim(sender.text) = "" Then
            sender.text = 0
        End If
    End Sub

    Private Sub Frm_Dimensiones_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
