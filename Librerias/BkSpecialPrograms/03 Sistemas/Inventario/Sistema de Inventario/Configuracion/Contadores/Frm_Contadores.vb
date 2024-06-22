Public Class Frm_Contadores

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    'Dim _Id_Inventario As Integer
    Dim _Tbl_Contadores As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Operadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String

        If Chk_Ver_Solo_Habilitados.Checked Then
            _Condicion = "Where Activo = 1"
        End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Inv_Contador" & vbCrLf & _Condicion
        Dim _Tbl_Operadores As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Operadores

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0


            .Columns("Id").Visible = True
            .Columns("Id").HeaderText = "Id"
            .Columns("Id").Width = 40
            .Columns("Id").DisplayIndex = _DisplayIndex
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

            .Columns("Telefono").Visible = True
            .Columns("Telefono").HeaderText = "Nombre"
            .Columns("Telefono").Width = 100
            .Columns("Telefono").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Email").Visible = True
            .Columns("Email").HeaderText = "Email"
            .Columns("Email").Width = 200
            .Columns("Email").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Activo").Visible = True
            .Columns("Activo").HeaderText = "Act."
            .Columns("Activo").Width = 40
            .Columns("Activo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Crear_Operador_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Operador.Click

        Dim _Grabar As Boolean = False

        Dim Fm As New Frm_CrearContador(0)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        Dim _Grabar As Boolean = False
        Dim _Eliminado As Boolean = False

        Dim Fm As New Frm_CrearContador(_Id)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Eliminado = Fm.Eliminado
        Fm.Dispose()

        If _Grabar Or _Eliminado Then
            Sb_Actualizar_Grilla()
        End If

    End Sub
End Class
