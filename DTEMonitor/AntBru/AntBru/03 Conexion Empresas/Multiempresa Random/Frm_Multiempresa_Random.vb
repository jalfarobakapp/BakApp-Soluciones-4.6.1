Imports DevComponents.DotNetBar

Public Class Frm_Multiempresa_Random

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Configp As DataTable

    Dim _Empresa As String

    Public ReadOnly Property Pro_Empresa_Seleccionada() As String
        Get
            Return _Empresa
        End Get
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Multiempresa_Random_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Actualizar_Grilla()

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 10), Color.LightYellow, ScrollBars.Vertical, True, True, False)

        Consulta_sql = "Select EMPRESA+' '+RUT+' '+RAZON AS EMPRESA_SEL,* From CONFIGP Order By EMPRESA"
        _Tbl_Configp = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Configp

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("EMPRESA_SEL").Width = 590
            .Columns("EMPRESA_SEL").HeaderText = "Nombre de conexión"
            .Columns("EMPRESA_SEL").Visible = True

        End With


    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        _Empresa = _Fila.Cells("EMPRESA").Value
        Me.Close()

    End Sub

    Private Sub Frm_Multiempresa_Random_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F5 Then
            Sb_Actualizar_Grilla()
        ElseIf e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        Me.Close()
    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown
        If e.KeyValue = Keys.Enter Then

            SendKeys.Send("{LEFT}")
            e.Handled = True
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
            _Empresa = _Fila.Cells("EMPRESA").Value
            Me.Close()

        End If
    End Sub
End Class
