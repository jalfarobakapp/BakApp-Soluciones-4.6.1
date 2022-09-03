Imports DevComponents.DotNetBar
Imports System.Windows.Forms
Imports System.Drawing
Imports Lib_Bakapp_VarClassFunc

Public Class Frm_BuscarFuncionarios

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public _CodFuncionarioSelec, _NomFuncionarioSelec As String

    Private Sub TxtDescripcionL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescripcion.TextChanged
        ActualizarGrilla()
    End Sub

    Sub ActualizarGrilla()
        Dim cadena As String _
                            = CADENA_A_BUSCAR(RTrim$(TxtDescripcion.Text), "NOKOFU" & " LIKE '%")


        Consulta_sql = "SELECT KOFU,NOKOFU FROM TABFU" & vbCrLf & _
                       "WHERE NOKOFU LIKE '%" & cadena & "%'"


        With Grilla

            Grilla.DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

            'OcultarEncabezadoGrilla(Grilla, True)

            .Columns("KOFU").Width = 100
            .Columns("KOFU").HeaderText = "Código"
            .Columns("KOFU").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("NOKOFU").Width = 350
            .Columns("NOKOFU").HeaderText = "Nombre de Usuario"


        End With

        Grilla.Enabled = CBool(Grilla.RowCount)
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        _CodFuncionarioSelec = Grilla.Rows(Grilla.CurrentRow.Index).Cells("KOFU").Value
        _NomFuncionarioSelec = Grilla.Rows(Grilla.CurrentRow.Index).Cells("NOKOFU").Value

        Me.Close()

    End Sub

    Private Sub Frm_BuscarFuncionarios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, True)
        ActualizarGrilla()
        Me.ActiveControl = TxtDescripcion
    End Sub

    
    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        _CodFuncionarioSelec = String.Empty
        _NomFuncionarioSelec = String.Empty
        Me.Close()
    End Sub
End Class