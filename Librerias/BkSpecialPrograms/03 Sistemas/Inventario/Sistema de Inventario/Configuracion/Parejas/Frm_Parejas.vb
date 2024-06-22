Public Class Frm_Parejas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Inventario As Integer

    Public Sub New(_Id_Inventario As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Inventario = _Id_Inventario

        Sb_Formato_Generico_Grilla(Grilla_Parejas, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Parejas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Grilla_Parejas.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown
        AddHandler Grilla_Parejas.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        Sb_Actualizar_Grilla()
    End Sub

    Sub Sb_Actualizar_Grilla()
        Return
        Consulta_sql = "Select Prj.*,Isnull(Op1.Nombre,'') As NombreOp1,Isnull(Op2.Nombre,'') As NombreOp2," & vbCrLf &
                       "(Select Count(*) From " & _Global_BaseBk & "Zw_Inv_Plan Where Id_Inventario = Prj.Id_Inventario And Id_Pareja = Prj.Id_Pareja And TipoPareja = 'TOMA') As Toma," & vbCrLf &
                        "(Select Count(*) From " & _Global_BaseBk & "Zw_Inv_Plan Where Id_Inventario = Prj.Id_Inventario And Id_Pareja = Prj.Id_Pareja And TipoPareja = 'LEVANTE') As Levante" & vbCrLf &
                        "From " & _Global_BaseBk & "Zw_Inv_Parejas Prj" & vbCrLf &
                        "Left Join " & _Global_BaseBk & "Zw_Inv_Operadores Op1 On Prj.Id_Operador1 = Op1.Id_Operador" & vbCrLf &
                        "Left Join " & _Global_BaseBk & "Zw_Inv_Operadores Op2 On Prj.Id_Operador2 = Op2.Id_Operador" & vbCrLf &
                        "Where Prj.Id_Inventario = " & _Id_Inventario
        Dim _Tbl_Parejas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Parejas

            .DataSource = _Tbl_Parejas

            OcultarEncabezadoGrilla(Grilla_Parejas, True)

            Dim _DisplayIndex = 0

            .Columns("Nombre_Pareja").Visible = True
            .Columns("Nombre_Pareja").HeaderText = "Nombre Pareja"
            .Columns("Nombre_Pareja").Width = 150
            .Columns("Nombre_Pareja").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreOp1").Visible = True
            .Columns("NombreOp1").HeaderText = "Operador 1"
            .Columns("NombreOp1").Width = 150
            .Columns("NombreOp1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreOp2").Visible = True
            .Columns("NombreOp2").HeaderText = "Operador 2"
            .Columns("NombreOp2").Width = 150
            .Columns("NombreOp2").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NombreEquipo").Visible = True
            .Columns("NombreEquipo").HeaderText = "Capturador"
            .Columns("NombreEquipo").Width = 150
            '.Columns("NombreEquipo").DefaultCellStyle.Format = "###,##0.##"
            .Columns("NombreEquipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Toma").Visible = True
            .Columns("Toma").HeaderText = "Toma"
            .Columns("Toma").Width = 80
            .Columns("Toma").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Toma").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Levante").Visible = True
            .Columns("Levante").HeaderText = "Levante"
            .Columns("Levante").Width = 80
            .Columns("Levante").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Levante").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Crear_Parejas_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Parejas.Click

        Dim Fm As New Frm_Parejas_Crear(_Id_Inventario, 0)
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

    Private Sub Grilla_Parejas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Parejas.CellDoubleClick

        ShowContextMenu(Menu_Contextual_Parejas)

    End Sub

    Private Sub Sb_Grilla_Detalle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_Parejas)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click

        Dim _Fila As DataGridViewRow = Grilla_Parejas.Rows(Grilla_Parejas.CurrentRow.Index)

        Dim _Id_Pareja As Integer = _Fila.Cells("Id_Pareja").Value

        Dim Fm As New Frm_Parejas_Crear(_Id_Inventario, _Id_Pareja)
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

    Private Sub Btn_Plan_Click(sender As Object, e As EventArgs) Handles Btn_Plan.Click

        Dim _Fila As DataGridViewRow = Grilla_Parejas.Rows(Grilla_Parejas.CurrentRow.Index)

        Dim _Id_Pareja As Integer = _Fila.Cells("Id_Pareja").Value
        Dim _Nombre_Pareja As String = _Fila.Cells("Nombre_Pareja").Value
        Dim _NombreOp1 As String = _Fila.Cells("Nombre_Pareja").Value
        Dim _NombreOp2 As String = _Fila.Cells("Nombre_Pareja").Value

        Dim Fm As New Frm_Parejas_Plan(_Id_Inventario, _Id_Pareja)
        Fm.Text = "Pareja: " & _Id_Pareja & " - " & _Nombre_Pareja.Trim & " (" & _NombreOp1.Trim & " Y " & _NombreOp2.Trim & ")"
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Dim _Toma = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Plan", "Id_Inventario = " & _Id_Inventario & " And Id_Pareja = " & _Id_Pareja & " And TipoPareja = 'TOMA'")
        Dim _Levante = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Inv_Plan", "Id_Inventario = " & _Id_Inventario & " And Id_Pareja = " & _Id_Pareja & " And TipoPareja = 'LEVANTE'")

        _Fila.Cells("Toma").Value = _Toma
        _Fila.Cells("Levante").Value = _Levante

    End Sub
End Class
