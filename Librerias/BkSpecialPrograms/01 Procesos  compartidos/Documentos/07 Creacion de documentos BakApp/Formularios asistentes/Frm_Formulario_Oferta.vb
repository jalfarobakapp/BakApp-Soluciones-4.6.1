Imports DevComponents.DotNetBar

Public Class Frm_Formulario_Oferta

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Row_Maeeres As DataRow
    Dim _Tbl_Maedres As DataTable

    Public Property Tbl_Maedres As DataTable
        Get
            Return _Tbl_Maedres
        End Get
        Set(value As DataTable)
            _Tbl_Maedres = value
        End Set
    End Property

    Public Property Row_Maeeres As DataRow
        Get
            Return _Row_Maeeres
        End Get
        Set(value As DataRow)
            _Row_Maeeres = value
        End Set
    End Property

    Public Sub New(_Codigo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_Sql = "Select * From MAEERES Where TIPORESE IN( 'OFE','OFD') And CODIGO = '" & _Codigo & "'"
        _Row_Maeeres = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Formulario_Oferta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _Codigo As String = _Row_Maeeres.Item("CODIGO")

        Me.Text = "Articulos componentes de la oferta asociada al producto" & Space(1) &
                  "(Desde: " & FormatDateTime(_Row_Maeeres.Item("FIOFERTA"), DateFormat.ShortDate) & ")" & Space(1) &
                   "Hasta: " & FormatDateTime(_Row_Maeeres.Item("FTOFERTA"), DateFormat.ShortDate) & ")"

        Consulta_Sql = "Select MAEDRES.*,MAEDRES.PORCDESC/100 As Porcentaje,NOKOPR From MAEDRES" & vbCrLf &
                       "Inner Join MAEPR On KOPR = ELEMENTO " & vbCrLf &
                       "Where CODIGO = '" & _Codigo & "'"
        _Tbl_Maedres = _Sql.Fx_Get_DataTable(Consulta_Sql)

        Lbl_Codigo.Text = _Row_Maeeres.Item("CODIGO")
        Lbl_Descriptor.Text = _Row_Maeeres.Item("DESCRIPTOR")
        Lbl_Cantidad.Text = _Row_Maeeres.Item("CANTIDAD")
        Lbl_Udad.Text = _Row_Maeeres.Item("UDAD")

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Tbl_Maedres

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("ELEMENTO").ReadOnly = True
            .Columns("ELEMENTO").Width = 100
            .Columns("ELEMENTO").HeaderText = "Código"
            .Columns("ELEMENTO").Visible = True
            .Columns("ELEMENTO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CANTIDAD").Width = 60
            .Columns("CANTIDAD").HeaderText = "Cantidad"
            .Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CANTIDAD").DefaultCellStyle.Format = "###,##0.0#"
            .Columns("CANTIDAD").Visible = True
            .Columns("CANTIDAD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").ReadOnly = True
            .Columns("NOKOPR").Width = 390
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UDAD").ReadOnly = True
            .Columns("UDAD").Width = 35
            .Columns("UDAD").HeaderText = "Ud."
            .Columns("UDAD").Visible = True
            .Columns("UDAD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Porcentaje").Width = 60
            .Columns("Porcentaje").HeaderText = "Desc."
            .Columns("Porcentaje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porcentaje").DefaultCellStyle.Format = "% ##0.0#"
            .Columns("Porcentaje").Visible = True
            .Columns("Porcentaje").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Frm_Formulario_Oferta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Or e.KeyValue = Keys.Enter Then
            Me.Close()
        End If
    End Sub

End Class