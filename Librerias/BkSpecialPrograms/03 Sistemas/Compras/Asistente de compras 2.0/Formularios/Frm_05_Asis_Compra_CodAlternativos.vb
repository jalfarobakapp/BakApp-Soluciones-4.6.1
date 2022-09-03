Imports DevComponents.DotNetBar
'Imports BkSpecialPrograms
'Imports Lib_Bakapp_VarClassFunc


Public Class Frm_05_AsisCompra_CodAlternativos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public CodigoRd As String
    Public ProveedorRd As String
    Public CodigoAlt As String

    Private Sub Frm_04_AsisCompra_Proveedores_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        ActualizarGrilla(ProveedorRd, CodigoRd)
        CodigoAlt = String.Empty

    End Sub

    Sub ActualizarGrilla(ByVal Proveedor As String,
                         ByVal CodigoRd As String)

        Consulta_sql = "Select KOPRAL,NOKOPRAL From TABCODAL Where KOEN = '" & Proveedor & "' And KOPR = '" & CodigoRd & "'"

        With Grilla
            .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

            .Columns("KOPRAL").Width = 100
            .Columns("KOPRAL").HeaderText = "Código Alt."

            .Columns("NOKOPRAL").Width = 400
            .Columns("NOKOPRAL").HeaderText = "Descripción"

        End With
    End Sub



    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        CodigoAlt = Grilla.Rows(Grilla.CurrentRow.Index).Cells("KOPRAL").Value
        Me.Close()
    End Sub

End Class