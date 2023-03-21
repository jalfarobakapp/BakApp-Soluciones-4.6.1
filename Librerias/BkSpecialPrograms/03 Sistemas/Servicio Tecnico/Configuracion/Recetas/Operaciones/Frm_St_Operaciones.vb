Imports DevComponents.DotNetBar
Public Class Frm_St_Operaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Operaciones As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_St_Operaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "Operacion+Descripcion Like '%")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_Operaciones" & vbCrLf &
                       "Where Operacion+Descripcion Like '%" & _Cadena & "%'"
        _Tbl_Operaciones = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Operaciones

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Operacion").Visible = True
            .Columns("Operacion").HeaderText = "Código"
            .Columns("Operacion").Width = 100
            .Columns("Operacion").DisplayIndex = 0

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 390
            .Columns("Descripcion").DisplayIndex = 1

            '.Columns("Activo").Visible = True
            '.Columns("Activo").HeaderText = "Activa"
            '.Columns("Activo").Width = 50
            '.Columns("Activo").DisplayIndex = 2
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With

    End Sub

    Private Sub Btn_Crear_Operacion_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Operacion.Click

        Dim _Grabar As Boolean

        Dim Fm As New Frm_St_OperacionesCrear("")
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Operacion As String = _Fila.Cells("Operacion").Value
        Dim _Grabar, _Eliminar As Boolean

        Dim Fm As New Frm_St_OperacionesCrear(_Operacion)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Or _Eliminar Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

End Class
