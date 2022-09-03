Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Modulo_Huellas

    Dim _Fm_Menu_Padre As Metro.MetroAppForm
    Dim _Menu_Extra As Boolean

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Pro_Menu_Extra() As Boolean
        Get
            Return _Menu_Extra
        End Get
        Set(ByVal value As Boolean)
            _Menu_Extra = value
        End Set
    End Property

    Public Sub New(Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click

        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)

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
                '_Tbl_Usuarios = Fm_R.Pro_Tbl_Filtro
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
