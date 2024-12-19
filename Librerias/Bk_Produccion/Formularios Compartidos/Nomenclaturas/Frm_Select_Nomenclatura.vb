Imports BkSpecialPrograms

Public Class Frm_Select_Nomenclatura

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Codigo As String
    Dim _TblNomenclaturas As DataTable

    Public Property Seleccionada As Boolean
    Public Property RowNomenclatura As DataRow
    Public Property OrdenDesc As Boolean

    Public Sub New(_Codigo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Codigo = _Codigo

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

    End Sub

    Private Sub Frm_Select_Nomenclatura_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Orden As String = String.Empty

        If OrdenDesc Then
            _Orden = "Order By PRELA.CODNOMEN Desc"
        End If

        Consulta_sql = "Select PRELA.*,PNPE.DESCRIPTOR" & vbCrLf &
                       "From PRELA" & vbCrLf &
                       "Inner Join PNPE On PRELA.CODNOMEN=PNPE.CODIGO And PNPE.ESODD <> 'S' And PNPE.EMPRESA = '" & ModEmpresa & "'" & vbCrLf &
                       "Where PRELA.CODIGO = '" & _Codigo & "'" & vbCrLf & _Orden
        _TblNomenclaturas = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _TblNomenclaturas

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("CODNOMEN").Width = 100
            .Columns("CODNOMEN").HeaderText = "Código"
            .Columns("CODNOMEN").Visible = True
            .Columns("CODNOMEN").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("DESCRIPTOR").Width = 400
            .Columns("DESCRIPTOR").HeaderText = "Num. MZC"
            .Columns("DESCRIPTOR").Visible = True
            .Columns("DESCRIPTOR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        'If MarcarFilasSinSaldo Then

        '    For Each row As DataGridViewRow In Grilla.Rows

        '        Dim _Saldo As Double = row.Cells("SALDO").Value

        '        If _Saldo = 0 Then
        '            row.DefaultCellStyle.ForeColor = Color.Gray
        '        End If

        '    Next

        'End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow

        Dim _Codnomen As String = _Fila.Cells("CODNOMEN").Value

        Consulta_sql = "Select * From PNPE Where CODIGO = '" & _Codnomen & "'"
        RowNomenclatura = _Sql.Fx_Get_DataRow(Consulta_sql)

        Seleccionada = True
        Me.Close()

    End Sub

End Class
