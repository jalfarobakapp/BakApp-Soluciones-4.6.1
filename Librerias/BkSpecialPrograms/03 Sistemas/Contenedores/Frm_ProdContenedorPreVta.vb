Public Class Frm_ProdContenedorPreVta

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Empresa As String
    Private _IdCont As Integer
    Private _Contenedor As String

    Dim _Cl_Contenedor As New Cl_Contenedor

    Public Property Seleccionado As Boolean
    Public Property RowProducto As DataRow

    Public Sub New(_Empresa As String, _IdCont As Integer, _Contenedor As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me._Empresa = _Empresa
        Me._IdCont = _IdCont
        Me._Contenedor = _Contenedor

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Contenedores, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Color_Botones_Barra(Bar1)

        _Cl_Contenedor.Zw_Contenedor = _Cl_Contenedor.Fx_Llenar_Contenedor(_IdCont)

    End Sub

    Private Sub Frm_ProdContenedorPreVta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "CONTENEDOR: " & _Cl_Contenedor.Zw_Contenedor.Contenedor & " - " & _Cl_Contenedor.Zw_Contenedor.NombreContenedor

        AddHandler Grilla_Contenedores.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Contenedores.KeyDown, AddressOf Sb_Grilla_KeyDown

        Sb_Actualizar_Grilla()

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Condicion As String = String.Empty

        'If Chk_Abierto.Checked Then
        '    _Condicion = " And Estado = 'Abierto'"
        'End If

        Consulta_sql = "Select Empresa,IdCont,Contenedor,Codigo,NOKOPR,StcfiUd1,StcfiUd2,StcCompUd1,StcCompUd2,StcfiUd1-StcCompUd1 As StDispUd1" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Contenedor_StockProd p" & vbCrLf &
                       "Inner Join MAEPR m On m.KOPR = p.Codigo" & vbCrLf &
                       "Where Empresa = '" & _Empresa & "' And IdCont = " & _IdCont & " And Contenedor = '" & _Contenedor & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _DisplayIndex = 0

        With Grilla_Contenedores

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla_Contenedores, True)

            '.Columns("Id").Width = 40
            '.Columns("Id").HeaderText = "ID"
            '.Columns("Id").Visible = True
            '.Columns("Id").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Empresa").Width = 30
            '.Columns("Empresa").HeaderText = "Emp"
            '.Columns("Empresa").Visible = True
            '.Columns("Empresa").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Codigo").Width = 100
            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").Width = 350
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("StcfiUd1").Width = 60
            '.Columns("StcfiUd1").HeaderText = "StCt Ud1"
            '.Columns("StcfiUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("StcfiUd1").DefaultCellStyle.Format = "##,###0.##"
            '.Columns("StcfiUd1").Visible = True
            '.Columns("StcfiUd1").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("StcCompUd1").Width = 60
            '.Columns("StcCompUd1").HeaderText = "StCt Ud1"
            '.Columns("StcCompUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("StcCompUd1").DefaultCellStyle.Format = "##,###0.##"
            '.Columns("StcCompUd1").Visible = True
            '.Columns("StcCompUd1").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("StDispUd1").Width = 70
            .Columns("StDispUd1").HeaderText = "Disponible Ud1"
            .Columns("StDispUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("StDispUd1").DefaultCellStyle.Format = "##,###0.##"
            .Columns("StDispUd1").Visible = True
            .Columns("StDispUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Grilla_Contenedores_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Contenedores.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla_Contenedores.CurrentRow
        Dim _Codigo As String = _Fila.Cells("Codigo").Value

        Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
        RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

        Seleccionado = True
        Me.Close()

    End Sub

    Private Sub Sb_Grilla_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)

        Try

            Dim _Fila As DataGridViewRow = Grilla_Contenedores.CurrentRow
            Dim _Codigo As String = _Fila.Cells("Codigo").Value

            If e.KeyValue = Keys.Enter Then

                SendKeys.Send("{LEFT}")
                e.Handled = True

                Call Grilla_Contenedores_CellDoubleClick(Nothing, Nothing)

            End If

        Catch ex As Exception
            Beep()
        End Try

    End Sub

    Private Sub Frm_ProdContenedorPreVta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class
