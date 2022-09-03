Public Class Frm_Operadores

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Inventario As Integer

    Public Sub New(_Id_Inventario As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Inventario = _Id_Inventario

        Sb_Formato_Generico_Grilla(Grilla_Operadores, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Operadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Operadores Where Id_Inventario = " & _Id_Inventario
        Dim _Tbl_Operadores As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Operadores

            .DataSource = _Tbl_Operadores

            OcultarEncabezadoGrilla(Grilla_Operadores, True)

            Dim _DisplayIndex = 0


            .Columns("Id_Operador").Visible = True
            .Columns("Id_Operador").HeaderText = "Cod."
            .Columns("Id_Operador").Width = 30
            .Columns("Id_Operador").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Rut").Visible = True
            .Columns("Rut").HeaderText = "Rut"
            .Columns("Rut").Width = 80
            .Columns("Rut").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombre").Visible = True
            .Columns("Nombre").HeaderText = "Nombre"
            .Columns("Nombre").Width = 200
            .Columns("Nombre").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Habilitado").Visible = True
            .Columns("Habilitado").HeaderText = "Act."
            .Columns("Habilitado").Width = 40
            .Columns("Habilitado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Crear_Operador_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Operador.Click

        Dim Fm As New Frm_Operadores_Crear(_Id_Inventario, 0)
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

    Private Sub Grilla_Operadores_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Operadores.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Operadores.Rows(Grilla_Operadores.CurrentRow.Index)

        Dim _Id_Operador As Integer = _Fila.Cells("Id_Operador").Value

        Dim Fm As New Frm_Operadores_Crear(_Id_Inventario, _Id_Operador)
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub
End Class
