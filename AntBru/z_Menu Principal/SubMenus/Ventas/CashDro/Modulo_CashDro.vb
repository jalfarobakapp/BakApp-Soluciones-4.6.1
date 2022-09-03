Imports BkSpecialPrograms
'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar
Imports System.IO

Public Class Modulo_CashDro

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim _Fm_Menu_Padre As Metro.MetroAppForm

    Dim _Menu_Extra As Boolean
    Public Property Pro_Menu_Extra() As Boolean
        Get
            Return _Menu_Extra
        End Get
        Set(ByVal value As Boolean)
            _Menu_Extra = value
        End Set
    End Property


    Public Sub New(ByVal Fm_Menu_Padre As Metro.MetroAppForm)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Fm_Menu_Padre = Fm_Menu_Padre

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _Fm_Menu_Padre.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub Btn_Pago_Proveedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pago_Proveedores.Click
        Sb_CashDro(_Fm_Menu_Padre)
    End Sub

    Private Sub Btn_Pago_Clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pago_Clientes.Click
        Dim Fm As New Frm_Equipos_CashDro
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

End Class
