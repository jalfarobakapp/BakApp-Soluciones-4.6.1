Imports DevComponents.DotNetBar

Public Class Frm_Inv_Inventarios

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Inventarios, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Both, True, True, False)

    End Sub

    Private Sub Frm_Inventarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Id,Empresa,Sucursal,FechaInicio,Nombre_Inventario,Activo,FechaCierre" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Inv_Inventario Where Empresa = '" & ModEmpresa & "'"
        Dim _Tbl_Inventarios As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Inventarios

            .DataSource = _Tbl_Inventarios

            OcultarEncabezadoGrilla(Grilla_Inventarios, True)

            Dim _DisplayIndex = 0

            .Columns("Activo").Visible = True
            .Columns("Activo").HeaderText = "Activo"
            .Columns("Activo").Width = 40
            .Columns("Activo").ReadOnly = False
            .Columns("Activo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombre_Inventario").Visible = True
            .Columns("Nombre_Inventario").HeaderText = "OT"
            .Columns("Nombre_Inventario").Width = 400
            .Columns("Nombre_Inventario").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaInicio").Visible = True
            .Columns("FechaInicio").HeaderText = "Fecha Inicio"
            .Columns("FechaInicio").Width = 200
            .Columns("FechaInicio").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Crear_Inventario_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Inventario.Click

        Dim _Sucursal As String
        Dim _RowSucursal As DataRow
        Dim _Seleccionado As Boolean

        Dim Fm_s As New Frm_SeleccionarBodega(Frm_SeleccionarBodega.Accion.Sucursal)
        Fm_s.Text = "Seleccione la Sucursal"
        Fm_s.ShowDialog(Me)
        _Seleccionado = Fm_s.Pro_Seleccionado
        _RowSucursal = Fm_s.Pro_RowBodega
        Fm_s.Dispose()

        If Not _Seleccionado Then Return

        _Sucursal = _RowSucursal.Item("KOSU")

        Dim Fm As New Frm_Inv_Crear_Inventario(ModEmpresa, _Sucursal, 0)
        Fm.ShowDialog(Me)

        If Fm.Grabar Then
            Sb_Actualizar_Grilla()
        End If

        Fm.Dispose()

    End Sub

    Private Sub Grilla_Inventarios_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Inventarios.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Inventarios.Rows(Grilla_Inventarios.CurrentRow.Index)

        Dim _Id = _Fila.Cells("Id").Value

        Dim Fm As New Frm_Inv_Ctrl_Inventario(_Id)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub


End Class
