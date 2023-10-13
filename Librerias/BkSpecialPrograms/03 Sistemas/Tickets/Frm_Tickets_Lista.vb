Imports DevComponents.DotNetBar
Public Class Frm_Tickets_Lista

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Tickets As DataTable
    Dim _Funcionario As String

    Public Sub New(_Funcionario As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Funcionario = _Funcionario

    End Sub

    Private Sub Frm_Tickets_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        'Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
        'Dim _Condicion As String = String.Empty

        'Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "CODIGO+DESCRIPTOR Like '%")

        'If Not String.IsNullOrWhiteSpace(Txt_BuscaXProducto.Text) Then
        '_Condicion = "And CODIGO In (Select CODIGO From MAEDRES Where ELEMENTO = '" & Txt_BuscaXProducto.Text & "')"
        'End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tickets" & vbCrLf &
                       "Where CodFuncionario_Crea = '" & _Funcionario & "'"


        _Tbl_Tickets = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Tickets

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("Numero").Visible = True
            .Columns("Numero").HeaderText = "Número"
            .Columns("Numero").Width = 100
            .Columns("Numero").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Asunto").Visible = True
            .Columns("Asunto").HeaderText = "Asunto"
            .Columns("Asunto").Width = 300
            .Columns("Asunto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Estado").Visible = True
            .Columns("Estado").HeaderText = "Fecha inicia"
            .Columns("Estado").ToolTipText = "Fecha de inicio de la oferta"
            .Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Estado").Width = 100
            .Columns("Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaCreacion").Visible = True
            .Columns("FechaCreacion").HeaderText = "Fecha creación"
            '.Columns("FechaCreacion").ToolTipText = "de tope de la oferta"
            .Columns("FechaCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaCreacion").Width = 100
            .Columns("FechaCreacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Dias").Visible = True
            '.Columns("Dias").HeaderText = "Días expira."
            '.Columns("Dias").ToolTipText = "Días que faltan para que termine la oferta"
            '.Columns("Dias").Width = 70
            '.Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Dias").DefaultCellStyle.Format = "###,##0.##"
            '.Columns("Dias").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

        End With

    End Sub

End Class
