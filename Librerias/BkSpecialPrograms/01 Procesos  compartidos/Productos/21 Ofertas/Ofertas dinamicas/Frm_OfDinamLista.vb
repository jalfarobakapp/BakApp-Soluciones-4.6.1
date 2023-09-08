Imports DevComponents.DotNetBar
Public Class Frm_OfDinamLista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Maeeres As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Recetas, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Productos, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_OfDinamLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla_Ofertas()
    End Sub

    Sub Sb_Actualizar_Grilla_Ofertas()

        Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
        Dim _Condicion As String = String.Empty

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "CODIGO+DESCRIPTOR Like '%")

        Consulta_sql = "Select * From MAEERES Where TIPORESE = 'din' And CODIGO+DESCRIPTOR Like '%" & _Cadena & "%'"

        _Tbl_Maeeres = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Codigo As String

        If CBool(_Tbl_Maeeres.Rows.Count) Then
            _Codigo = _Tbl_Maeeres.Rows(0).Item("CODIGO")
        End If

        Sb_Actualizar_Grilla_Productos(_Codigo)

        With Grilla_Recetas

            .DataSource = _Tbl_Maeeres

            OcultarEncabezadoGrilla(Grilla_Recetas, True)

            .Columns("CODIGO").Visible = True
            .Columns("CODIGO").HeaderText = "Código"
            .Columns("CODIGO").Width = 100
            .Columns("CODIGO").DisplayIndex = 0

            .Columns("DESCRIPTOR").Visible = True
            .Columns("DESCRIPTOR").HeaderText = "Nombre del tipo de descuento oferta"
            .Columns("DESCRIPTOR").Width = 300
            .Columns("DESCRIPTOR").DisplayIndex = 1

            .Columns("LISTAS").Visible = True
            .Columns("LISTAS").HeaderText = "Listas de precios válidas"
            .Columns("LISTAS").Width = 200
            .Columns("LISTAS").DisplayIndex = 2
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With

    End Sub

    Sub Sb_Actualizar_Grilla_Productos(_Codigo As String)

        Consulta_sql = "Select Mprod.*,Mp.NOKOPR From MAEDRES Mprod" & vbCrLf &
                       "Left Join MAEPR Mp On Mp.KOPR = Mprod.ELEMENTO" & vbCrLf &
                       "Where CODIGO = '" & _Codigo & "'"
        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Productos

            .DataSource = _Tbl_Productos

            OcultarEncabezadoGrilla(Grilla_Productos, True)

            .Columns("ELEMENTO").Visible = True
            .Columns("ELEMENTO").HeaderText = "Código"
            .Columns("ELEMENTO").Width = 100
            .Columns("ELEMENTO").DisplayIndex = 0

            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Width = 390 + 50
            .Columns("NOKOPR").DisplayIndex = 1

        End With

    End Sub

    Private Sub Grilla_Recetas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Recetas.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Recetas.CurrentRow

        Dim _Codigo As String = _Fila.Cells("CODIGO").Value
        Dim _Grabar As Boolean

        Dim Fm As New Frm_OfDinamFicha(_Codigo)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then

        End If

    End Sub

End Class
