Imports DevComponents.DotNetBar
Public Class Frm_Huellas_Menu
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Huellas_Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Frm_Huellas_Menu_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_UareU4500_Click(sender As Object, e As EventArgs) Handles Btn_UareU4500.Click

        Dim Fm As New Frm_Huellas_U4500
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_ZK4500_Click(sender As Object, e As EventArgs) Handles Btn_ZK4500.Click

        Dim Fm_R As New Frm_Filtro_Especial_Informes(Frm_Filtro_Especial_Informes._Tabla_Fl._Funcionarios_Random)
        Fm_R.Pro_Seleccionar_Solo_Uno = True
        Fm_R.Pro_Sql_Filtro_Condicion_Extra = "And INACTIVO = 0"
        Fm_R.Text = "SELECCION DE USUARIO PARA REGISTRO DE HUELLA"
        Fm_R.ShowDialog(Me)
        Dim _CodFuncionario As String = String.Empty

        If Not IsNothing(Fm_R.Pro_Tbl_Filtro) Then
            If CBool(Fm_R.Pro_Tbl_Filtro.Rows.Count) Then
                _CodFuncionario = Fm_R.Pro_Tbl_Filtro.Rows(0).Item("Codigo")
            End If
        End If

        Fm_R.Dispose()

        If Not String.IsNullOrEmpty(_CodFuncionario) Then
            Dim Fm_H As New Frm_Huella_Por_Usuario(_CodFuncionario)
            Fm_H.ShowDialog(Me)
            Fm_H.Dispose()
        End If

    End Sub
End Class
