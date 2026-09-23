Public Class Frm_Ferias

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property ModoSeleccion As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Ferias_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String = String.Empty

        Consulta_sql = $"
Select * From {_Global_BaseBk}Zw_Ferias
{_Condicion}
"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            '.Columns("Id").Width = 40
            '.Columns("Id").HeaderText = "ID"
            '.Columns("Id").Visible = True
            '.Columns("Id").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("NOKOPR").Width = 310
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaInicio").HeaderText = "F.Inicio"
            .Columns("FechaInicio").ToolTipText = "Fecha de inicio de las ventas por feria"
            .Columns("FechaInicio").Width = 70
            .Columns("FechaInicio").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaInicio").Visible = True
            .Columns("FechaInicio").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaTermino").HeaderText = "F.Termino"
            .Columns("FechaTermino").ToolTipText = "Fecha de termino para las ventas de la feria"
            .Columns("FechaTermino").Width = 70
            .Columns("FechaTermino").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaTermino").Visible = True
            .Columns("FechaTermino").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1


        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

    End Sub
End Class
