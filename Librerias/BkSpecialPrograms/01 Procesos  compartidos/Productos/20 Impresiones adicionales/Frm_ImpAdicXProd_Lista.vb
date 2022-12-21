Imports DevComponents.DotNetBar
Public Class Frm_ImpAdicXProd_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_ImpAdicXProd_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select IAd.*,Mp.NOKOPR From " & _Global_BaseBk & "Zw_Prod_ImpAdicional IAd" & vbCrLf &
                       "Inner Join MAEPR Mp On Mp.KOPR = IAd.Codigo" & vbCrLf &
                       "Order By Codigo"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            Grilla.DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").Width = 300
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tido").Width = 30
            .Columns("Tido").HeaderText = "TD"
            .Columns("Tido").Visible = True
            .Columns("Tido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Subtido").Width = 30
            .Columns("Subtido").HeaderText = "Sub"
            .Columns("Subtido").Visible = True
            .Columns("Subtido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreFormato_Origen").Width = 120
            .Columns("NombreFormato_Origen").HeaderText = "Formato activación"
            .Columns("NombreFormato_Origen").Visible = True
            .Columns("NombreFormato_Origen").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreFormato_Destino").Width = 120
            .Columns("NombreFormato_Destino").HeaderText = "Formato impresión"
            .Columns("NombreFormato_Destino").Visible = True
            .Columns("NombreFormato_Destino").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Refresh()

        End With

    End Sub

    Private Sub Btn_Crear_ImpAdicionalXProd_Click(sender As Object, e As EventArgs) Handles Btn_Crear_ImpAdicionalXProd.Click

        Dim Fm As New Frm_ImpAdicXProd(0, "", "", "")
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _Codigo As String = _Fila.Cells("Codigo").Value
        Dim _Tido As String = _Fila.Cells("Tido").Value
        Dim _Subtido As String = _Fila.Cells("Subtido").Value

        Dim _Reg = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_ImpAdicional", "Id = " & _Id)

        If Not CBool(_Reg) Then
            If MessageBoxEx.Show(Me, "Este registro ya no existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop) Then
                Sb_Actualizar_Grilla()
                Return
            End If
        End If

        Dim Fm As New Frm_ImpAdicXProd(_Id, _Codigo, _Tido, _Subtido)
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

    Private Sub BtnActualizarLista_Click(sender As Object, e As EventArgs) Handles BtnActualizarLista.Click
        Sb_Actualizar_Grilla()
    End Sub
End Class
