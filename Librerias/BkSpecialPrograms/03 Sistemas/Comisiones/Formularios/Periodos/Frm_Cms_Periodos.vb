Public Class Frm_Cms_Periodos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Tbl_Periodos As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Cms_Periodos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Sub Sb_Actualizar_Grilla()

        Consulta_Sql = "Select Id,Nombre,Periodo,FechaDesde,FechaHasta,Ano,Mes,Habiles,Sabados,Domingos,Festivos,Semanas" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Comisiones_Enc" & vbCrLf &
                       "Order By Mes,Ano"
        _Tbl_Periodos = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Tbl_Periodos

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Periodo").Width = 1100
            .Columns("Periodo").HeaderText = "Periodo"
            .Columns("Periodo").Visible = True
            .Columns("Periodo").ReadOnly = False
            .Columns("Periodo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nombre").Width = 300
            .Columns("Nombre").HeaderText = "Nombre comisiones"
            .Columns("Nombre").Visible = True
            .Columns("Nombre").ReadOnly = False
            .Columns("Nombre").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

End Class
